namespace KindleClipper
{
    partial class WndClipper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndClipper));
            this.GrpBooks = new System.Windows.Forms.GroupBox();
            this.ListBooks = new System.Windows.Forms.ListView();
            this.ColTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemFinished = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClipper = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.GrpContents = new System.Windows.Forms.GroupBox();
            this.TextContents = new System.Windows.Forms.TextBox();
            this.ContainerSplit = new System.Windows.Forms.SplitContainer();
            this.GrpBooks.SuspendLayout();
            this.ContextMenuStatus.SuspendLayout();
            this.MenuClipper.SuspendLayout();
            this.GrpContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerSplit)).BeginInit();
            this.ContainerSplit.Panel1.SuspendLayout();
            this.ContainerSplit.Panel2.SuspendLayout();
            this.ContainerSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBooks
            // 
            this.GrpBooks.Controls.Add(this.ListBooks);
            this.GrpBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBooks.Location = new System.Drawing.Point(0, 0);
            this.GrpBooks.Name = "GrpBooks";
            this.GrpBooks.Size = new System.Drawing.Size(382, 556);
            this.GrpBooks.TabIndex = 0;
            this.GrpBooks.TabStop = false;
            this.GrpBooks.Text = "Book List";
            // 
            // ListBooks
            // 
            this.ListBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColTitle});
            this.ListBooks.ContextMenuStrip = this.ContextMenuStatus;
            this.ListBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBooks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListBooks.HideSelection = false;
            this.ListBooks.Location = new System.Drawing.Point(3, 18);
            this.ListBooks.MultiSelect = false;
            this.ListBooks.Name = "ListBooks";
            this.ListBooks.Size = new System.Drawing.Size(376, 535);
            this.ListBooks.TabIndex = 0;
            this.ListBooks.UseCompatibleStateImageBehavior = false;
            this.ListBooks.View = System.Windows.Forms.View.Details;
            this.ListBooks.SelectedIndexChanged += new System.EventHandler(this.ListBooks_SelectedIndexChanged);
            // 
            // ColTitle
            // 
            this.ColTitle.Text = "Title";
            // 
            // ContextMenuStatus
            // 
            this.ContextMenuStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFinished});
            this.ContextMenuStatus.Name = "ContextMenuStatus";
            this.ContextMenuStatus.Size = new System.Drawing.Size(119, 26);
            this.ContextMenuStatus.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStatus_Opening);
            // 
            // MenuItemFinished
            // 
            this.MenuItemFinished.Name = "MenuItemFinished";
            this.MenuItemFinished.Size = new System.Drawing.Size(118, 22);
            this.MenuItemFinished.Text = "&Finished";
            this.MenuItemFinished.Click += new System.EventHandler(this.MenuItemFinished_Click);
            // 
            // MenuClipper
            // 
            this.MenuClipper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile});
            this.MenuClipper.Location = new System.Drawing.Point(0, 0);
            this.MenuClipper.Name = "MenuClipper";
            this.MenuClipper.Size = new System.Drawing.Size(1163, 24);
            this.MenuClipper.TabIndex = 1;
            this.MenuClipper.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemImport});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.MenuItemFile.Text = "&File";
            // 
            // MenuItemImport
            // 
            this.MenuItemImport.Name = "MenuItemImport";
            this.MenuItemImport.Size = new System.Drawing.Size(179, 22);
            this.MenuItemImport.Text = "Import Clipping File";
            this.MenuItemImport.Click += new System.EventHandler(this.MenuItemImport_Click);
            // 
            // GrpContents
            // 
            this.GrpContents.Controls.Add(this.TextContents);
            this.GrpContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpContents.Location = new System.Drawing.Point(0, 0);
            this.GrpContents.Name = "GrpContents";
            this.GrpContents.Size = new System.Drawing.Size(761, 556);
            this.GrpContents.TabIndex = 2;
            this.GrpContents.TabStop = false;
            this.GrpContents.Text = "Contents";
            // 
            // TextContents
            // 
            this.TextContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextContents.Location = new System.Drawing.Point(3, 18);
            this.TextContents.Multiline = true;
            this.TextContents.Name = "TextContents";
            this.TextContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextContents.Size = new System.Drawing.Size(755, 535);
            this.TextContents.TabIndex = 0;
            // 
            // ContainerSplit
            // 
            this.ContainerSplit.Location = new System.Drawing.Point(12, 27);
            this.ContainerSplit.Name = "ContainerSplit";
            // 
            // ContainerSplit.Panel1
            // 
            this.ContainerSplit.Panel1.Controls.Add(this.GrpBooks);
            this.ContainerSplit.Panel1MinSize = 100;
            // 
            // ContainerSplit.Panel2
            // 
            this.ContainerSplit.Panel2.Controls.Add(this.GrpContents);
            this.ContainerSplit.Panel2MinSize = 100;
            this.ContainerSplit.Size = new System.Drawing.Size(1147, 556);
            this.ContainerSplit.SplitterDistance = 382;
            this.ContainerSplit.TabIndex = 4;
            this.ContainerSplit.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.ContainerSplit_SplitterMoved);
            // 
            // WndClipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 588);
            this.Controls.Add(this.MenuClipper);
            this.Controls.Add(this.ContainerSplit);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuClipper;
            this.Name = "WndClipper";
            this.Text = "Kindle Clipper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WndClipper_FormClosing);
            this.Load += new System.EventHandler(this.WndClipper_Load);
            this.GrpBooks.ResumeLayout(false);
            this.ContextMenuStatus.ResumeLayout(false);
            this.MenuClipper.ResumeLayout(false);
            this.MenuClipper.PerformLayout();
            this.GrpContents.ResumeLayout(false);
            this.GrpContents.PerformLayout();
            this.ContainerSplit.Panel1.ResumeLayout(false);
            this.ContainerSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContainerSplit)).EndInit();
            this.ContainerSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBooks;
        private System.Windows.Forms.MenuStrip MenuClipper;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImport;
        private System.Windows.Forms.ListView ListBooks;
        private System.Windows.Forms.ColumnHeader ColTitle;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStatus;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFinished;
        private System.Windows.Forms.GroupBox GrpContents;
        private System.Windows.Forms.TextBox TextContents;
        private System.Windows.Forms.SplitContainer ContainerSplit;
    }
}

