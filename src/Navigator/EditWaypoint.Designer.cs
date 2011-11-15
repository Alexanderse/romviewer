namespace RomViewer.Navigator
{
    partial class EditWaypointForm
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
            System.Windows.Forms.Label zoneLabel;
            this.labelId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.zoneComboBox = new System.Windows.Forms.ComboBox();
            this.gameNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            zoneLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // zoneLabel
            // 
            zoneLabel.AutoSize = true;
            zoneLabel.Location = new System.Drawing.Point(16, 92);
            zoneLabel.Name = "zoneLabel";
            zoneLabel.Size = new System.Drawing.Size(35, 13);
            zoneLabel.TabIndex = 11;
            zoneLabel.Text = "Zone:";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(16, 9);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Coordinates";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(111, 11);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "-1";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(114, 35);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(158, 20);
            this.tbName.TabIndex = 4;
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(113, 63);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(46, 20);
            this.tbX.TabIndex = 5;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(165, 63);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(46, 20);
            this.tbY.TabIndex = 6;
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(215, 63);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(46, 20);
            this.tbZ.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(200, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(119, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // zoneComboBox
            // 
            this.zoneComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameNodeBindingSource, "Zone", true));
            this.zoneComboBox.DataSource = this.zoneBindingSource;
            this.zoneComboBox.FormattingEnabled = true;
            this.zoneComboBox.Location = new System.Drawing.Point(113, 89);
            this.zoneComboBox.Name = "zoneComboBox";
            this.zoneComboBox.Size = new System.Drawing.Size(159, 21);
            this.zoneComboBox.TabIndex = 12;
            // 
            // gameNodeBindingSource
            // 
            this.gameNodeBindingSource.DataSource = typeof(RomViewer.Model.GameNode);
            // 
            // zoneBindingSource
            // 
            this.zoneBindingSource.DataSource = typeof(RomViewer.Model.Zone);
            this.zoneBindingSource.CurrentChanged += new System.EventHandler(this.zoneBindingSource_CurrentChanged);
            // 
            // EditWaypointForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(277, 143);
            this.Controls.Add(zoneLabel);
            this.Controls.Add(this.zoneComboBox);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbZ);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelId);
            this.Name = "EditWaypointForm";
            this.Text = "EditWaypoint";
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.BindingSource gameNodeBindingSource;
        private System.Windows.Forms.ComboBox zoneComboBox;
        private System.Windows.Forms.BindingSource zoneBindingSource;
    }
}