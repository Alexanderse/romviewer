namespace RomViewer.Navigator
{
    partial class ctrlTransportLink
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
            System.Windows.Forms.Label destinationLabel1;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scriptTextBox = new System.Windows.Forms.TextBox();
            this.btnGetNode = new System.Windows.Forms.Button();
            this.transportLinkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.destinationComboBox = new System.Windows.Forms.ComboBox();
            destinationLabel1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transportLinkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // destinationLabel1
            // 
            destinationLabel1.AutoSize = true;
            destinationLabel1.Location = new System.Drawing.Point(15, 14);
            destinationLabel1.Name = "destinationLabel1";
            destinationLabel1.Size = new System.Drawing.Size(63, 13);
            destinationLabel1.TabIndex = 4;
            destinationLabel1.Text = "Destination:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.scriptTextBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 304);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script";
            // 
            // scriptTextBox
            // 
            this.scriptTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transportLinkBindingSource, "Script", true));
            this.scriptTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptTextBox.Location = new System.Drawing.Point(3, 16);
            this.scriptTextBox.Multiline = true;
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.Size = new System.Drawing.Size(497, 285);
            this.scriptTextBox.TabIndex = 5;
            // 
            // btnGetNode
            // 
            this.btnGetNode.Location = new System.Drawing.Point(89, 11);
            this.btnGetNode.Name = "btnGetNode";
            this.btnGetNode.Size = new System.Drawing.Size(44, 23);
            this.btnGetNode.TabIndex = 8;
            this.btnGetNode.Text = "...";
            this.btnGetNode.UseVisualStyleBackColor = true;
            this.btnGetNode.Click += new System.EventHandler(this.btnGetNode_Click);
            // 
            // transportLinkBindingSource
            // 
            this.transportLinkBindingSource.DataSource = typeof(RomViewer.Model.TransportLink);
            // 
            // gameNodeBindingSource
            // 
            this.gameNodeBindingSource.DataSource = typeof(RomViewer.Model.GameNode);
            // 
            // destinationComboBox
            // 
            this.destinationComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transportLinkBindingSource, "Destination", true));
            this.destinationComboBox.DataSource = this.gameNodeBindingSource;
            this.destinationComboBox.FormattingEnabled = true;
            this.destinationComboBox.Location = new System.Drawing.Point(152, 13);
            this.destinationComboBox.Name = "destinationComboBox";
            this.destinationComboBox.Size = new System.Drawing.Size(366, 21);
            this.destinationComboBox.TabIndex = 9;
            // 
            // ctrlTransportLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.destinationComboBox);
            this.Controls.Add(this.btnGetNode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(destinationLabel1);
            this.Name = "ctrlTransportLink";
            this.Size = new System.Drawing.Size(535, 355);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transportLinkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource transportLinkBindingSource;
        private System.Windows.Forms.BindingSource gameNodeBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox scriptTextBox;
        private System.Windows.Forms.Button btnGetNode;
        private System.Windows.Forms.ComboBox destinationComboBox;
    }
}
