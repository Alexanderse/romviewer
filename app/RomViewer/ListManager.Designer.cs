namespace RomViewer
{
    partial class ListManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListManager));
            this.tsItems = new System.Windows.Forms.ToolStrip();
            this.tebItemName = new System.Windows.Forms.ToolStripTextBox();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.tsItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsItems
            // 
            this.tsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tebItemName,
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tsbDelete});
            this.tsItems.Location = new System.Drawing.Point(0, 0);
            this.tsItems.Name = "tsItems";
            this.tsItems.Size = new System.Drawing.Size(273, 25);
            this.tsItems.TabIndex = 2;
            this.tsItems.Text = "toolStrip1";
            // 
            // tebItemName
            // 
            this.tebItemName.Name = "tebItemName";
            this.tebItemName.Size = new System.Drawing.Size(100, 25);
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbAdd.Text = "+";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "-";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // lbItems
            // 
            this.lbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(0, 25);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(273, 218);
            this.lbItems.TabIndex = 3;
            // 
            // ListManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.tsItems);
            this.Name = "ListManager";
            this.Size = new System.Drawing.Size(273, 243);
            this.tsItems.ResumeLayout(false);
            this.tsItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsItems;
        private System.Windows.Forms.ToolStripTextBox tebItemName;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ListBox lbItems;
    }
}
