namespace RomViewer.Navigator
{
    partial class ctrlMovementLink
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.gameNodeLinkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scriptTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeLinkBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Script";
            // 
            // gameNodeLinkBindingSource
            // 
            this.gameNodeLinkBindingSource.DataSource = typeof(RomViewer.Model.GameNodeLink);
            // 
            // scriptTextBox
            // 
            this.scriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameNodeLinkBindingSource, "Script", true));
            this.scriptTextBox.Location = new System.Drawing.Point(12, 26);
            this.scriptTextBox.Multiline = true;
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.Size = new System.Drawing.Size(440, 194);
            this.scriptTextBox.TabIndex = 4;
            // 
            // ctrlMovementLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scriptTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ctrlMovementLink";
            this.Size = new System.Drawing.Size(468, 234);
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeLinkBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource gameNodeLinkBindingSource;
        private System.Windows.Forms.TextBox scriptTextBox;
    }
}
