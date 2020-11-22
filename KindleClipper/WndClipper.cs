using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace KindleClipper
{
    public partial class WndClipper : Form
    {
        const string chunkSeparator = "==========";
        List<Book> Books;
        BookManager BookMgr;
        string BookMgrFile;

        public WndClipper()
        {
            InitializeComponent();
            Books = new List<Book>();

            BookMgrFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "bookmgr.bin");

            // try to get serialized book status 

            try
            {
                if (File.Exists(BookMgrFile))
                {
                    using (var fs = new FileStream(BookMgrFile, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        // Deserialize the hashtable from the file and 
                        // assign the reference to the local variable.
                        BookMgr = (BookManager)formatter.Deserialize(fs);
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception while deserializing book mgr file:\r\n" + ex.Message);
            }

            if (BookMgr == null) { BookMgr = new BookManager(); }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ColTitle.Width = ListBooks.ClientRectangle.Width;
        }
        // books are connected to the tag item 

        private void MenuItemImport_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Import Text File Containing Kindle Clippings" };

            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && File.Exists(ofd.FileName))
            {
                var file = ofd.FileName;
                string rawText;
                if (!string.IsNullOrWhiteSpace((rawText = File.ReadAllText(ofd.FileName, Encoding.UTF8))))
                {
                    Book currentBook = null;
                    Books.Clear();
                    var kindleChunks = rawText.Split(new[] { chunkSeparator }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var chunk in kindleChunks)
                    {
                        string title, text; int location;
                        if (KindleHelper.ExtractChunk(chunk, out title, out location, out text))
                        {
                            // put this into the appropriate book assuming that one exists for this title
                            currentBook = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                            if (currentBook == null) { currentBook = new Book(title); Books.Add(currentBook); }

                            currentBook.Snippets.Add(new Snippet(location, text));
                        }
                    }

                    // add books into the various appropriate places, and hook into tags for the appropriate list items
                    
                    ListBooks.Items.Clear();
                    
                    // iterate through the books and begin to mark their statuses
                    // Tag should equal the boolean?

                    Books = Books.OrderBy(bk => bk.Title).ToList();

                    foreach (var book in Books)
                    {
                        ListViewItem item = new ListViewItem(book.Title);
                        var finished = BookMgr.GetOrMakeNewStatus(book.Title);
                        if (finished) item.BackColor = Color.LightGreen;
                        ListBooks.Items.Add(item);
                    }

                    // ListViewItem 
                    // match against the books that have been finished (serialized stuff)
                    //ListBooks.Items.AddRange(Books.OrderBy(bk => bk.Title).ToArray());
                }
            }
        }

        private void ListBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ListBooks.SelectedItems.Count == 1)
            {
                var selectedItem = ListBooks.SelectedItems[0];
                
                //selectedItem.Text
                var book = Books.FirstOrDefault(bk => bk.Title.Equals(selectedItem.Text, StringComparison.OrdinalIgnoreCase));
                if (book != null)
                {
                    // pull from tag
                    TextContents.Text = book.ExportSnippetsAsRaw();
                }
            }


        }

        private void WndClipper_Load(object sender, EventArgs e)
        {

        }

        private void MenuItemFinished_Click(object sender, EventArgs e)
        {
            if (ListBooks.SelectedItems.Count == 1)
            {
                var bookItem = ListBooks.SelectedItems[0];
                var finishedStripItem = sender as ToolStripMenuItem;

                var finished = !BookMgr.GetOrMakeNewStatus(bookItem.Text);
                BookMgr.SetStatus(bookItem.Text, finished);

                bookItem.BackColor = finished ? Color.LightGreen : Color.White;
            }
        }

        private void ContextMenuStatus_Opening(object sender, CancelEventArgs e)
        {
            if (ListBooks.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
            else
            {
                MenuItemFinished.Checked = BookMgr.GetOrMakeNewStatus(ListBooks.SelectedItems[0].Text);
            }

        }

        private void WndClipper_FormClosing(object sender, FormClosingEventArgs e)
        {
            // write changes back out by iterating across the list
            try
            {
                using (FileStream fs = new FileStream(BookMgrFile, FileMode.Create))
                {
                    new BinaryFormatter().Serialize(fs, BookMgr);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to save changes to book statuses: " + ex.Message);
            }
        }

        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ContainerSplit_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ColTitle.Width = ListBooks.ClientRectangle.Width;
        }
    }

    /* EXAMPLE OF CHUNK
    Parsing the Turing Test: Philosophical and Methodological Issues in the Quest for the Thinking Computer ( )
    - Your Highlight Location 15-16 | Added on Wednesday, April 9, 2014 1:37:46 PM

    anthology. I was chair of the Lochner Prize Committee that administered the competition during its second, third, and fourth years, and have written briefly about that fascinating adventure in my book Brainchildren.
    */

    public class KindleHelper
    {
        public static bool ExtractChunk(string chunk, out string title, out int location, out string text)
        {
            var _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            // remove BOM which apparently exists throughout the entire clippings document (might be better to remove this from the original file readings
            // instead of at a chunk level)
            chunk = chunk.Replace(_byteOrderMarkUtf8, string.Empty);
            
            bool retValue = false;

            title = null; location = 0; text = null;

            var lines = chunk.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            
            if (lines.Length == 3)
            {
                title = lines[0].Trim();
                int leftParan = -1, rightParan = -1;
                if ((leftParan = title.LastIndexOf("(")) > 1 && (rightParan = title.LastIndexOf(")")) > leftParan)
                {
                    title = title.Substring(0, leftParan).Trim();
                }

                // Location \d+?\-
                var match = Regex.Match(lines[1], @"Location (\d+)(-| )");
                if (match.Success)
                {
                    if (!int.TryParse(match.Groups[1].Value, out location)) { location = 0; } // just use a zero-based location
                }

                text = lines[2].Trim();

                retValue = true;
            }

            return retValue;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public List<Snippet> Snippets { get; set; }

        public Book() { Snippets = new List<Snippet>(); } 
        public Book(string title) : this() { Title = title; }

        public override string ToString()
        {
            return Title;
        }

        public string ExportSnippetsAsRaw()
        {
            string text = string.Empty;
            text = string.Join(Environment.NewLine + Environment.NewLine, Snippets.OrderBy(sp => sp.Location).Select(sp => sp.Text));
            return text;
        }
    }

    public class Snippet
    {
        public int Location { get; set; }
        public string Text { get; set; }

        public Snippet() { }
        public Snippet(int loc, string text) { Location = loc; Text = text; }

        
    }

    [Serializable]
    public class BookManager
    {
        public List<BookStatus> BookStatuses { get; set; }

        public BookManager() { BookStatuses = new List<BookStatus>(); }

        public void SetStatus(string title, bool finished)
        {
            var status = BookStatuses.FirstOrDefault(bs => bs.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (status == null) 
                BookStatuses.Add((status = new BookStatus(title, finished)));
            else 
                status.Finished = finished;
        }

        public bool GetOrMakeNewStatus(string title)
        {
            var status = BookStatuses.FirstOrDefault(bs => bs.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (status == null) BookStatuses.Add((status = new BookStatus(title, false)));

            return status.Finished;
        }

     

    }

    [Serializable]
    public class BookStatus
    {
        public string Title { get; set; }
        public bool Finished { get; set; }

        public BookStatus() { }
        public BookStatus(string title, bool finished = false) { Title = title; Finished = finished; }
    }



}
