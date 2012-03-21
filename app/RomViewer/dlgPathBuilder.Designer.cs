namespace RomViewer
{
    partial class dlgPathBuilder
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
            System.Windows.Forms.Label movementTypeLabel;
            System.Windows.Forms.Label scriptLabel;
            System.Windows.Forms.Label tagLabel;
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartNode = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pathWaypointDataGridView = new System.Windows.Forms.DataGridView();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.scriptTextBox = new System.Windows.Forms.TextBox();
            this.movementTypeTextBox = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathWaypointBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            movementTypeLabel = new System.Windows.Forms.Label();
            scriptLabel = new System.Windows.Forms.Label();
            tagLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathWaypointDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathWaypointBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // movementTypeLabel
            // 
            movementTypeLabel.AutoSize = true;
            movementTypeLabel.Location = new System.Drawing.Point(14, 18);
            movementTypeLabel.Name = "movementTypeLabel";
            movementTypeLabel.Size = new System.Drawing.Size(87, 13);
            movementTypeLabel.TabIndex = 0;
            movementTypeLabel.Text = "Movement Type:";
            // 
            // scriptLabel
            // 
            scriptLabel.AutoSize = true;
            scriptLabel.Location = new System.Drawing.Point(14, 70);
            scriptLabel.Name = "scriptLabel";
            scriptLabel.Size = new System.Drawing.Size(37, 13);
            scriptLabel.TabIndex = 2;
            scriptLabel.Text = "Script:";
            // 
            // tagLabel
            // 
            tagLabel.AutoSize = true;
            tagLabel.Location = new System.Drawing.Point(16, 44);
            tagLabel.Name = "tagLabel";
            tagLabel.Size = new System.Drawing.Size(29, 13);
            tagLabel.TabIndex = 4;
            tagLabel.Text = "Tag:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Node:";
            // 
            // btnStartNode
            // 
            this.btnStartNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartNode.Location = new System.Drawing.Point(81, 12);
            this.btnStartNode.Name = "btnStartNode";
            this.btnStartNode.Size = new System.Drawing.Size(409, 23);
            this.btnStartNode.TabIndex = 1;
            this.btnStartNode.Text = "Select a Start Node";
            this.btnStartNode.UseVisualStyleBackColor = true;
            this.btnStartNode.Click += new System.EventHandler(this.btnStartNode_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.pathWaypointDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(tagLabel);
            this.splitContainer1.Panel2.Controls.Add(this.tagTextBox);
            this.splitContainer1.Panel2.Controls.Add(scriptLabel);
            this.splitContainer1.Panel2.Controls.Add(this.scriptTextBox);
            this.splitContainer1.Panel2.Controls.Add(movementTypeLabel);
            this.splitContainer1.Panel2.Controls.Add(this.movementTypeTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(498, 380);
            this.splitContainer1.SplitterDistance = 166;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(39, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(24, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pathWaypointDataGridView
            // 
            this.pathWaypointDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathWaypointDataGridView.AutoGenerateColumns = false;
            this.pathWaypointDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pathWaypointDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.pathWaypointDataGridView.DataSource = this.pathWaypointBindingSource;
            this.pathWaypointDataGridView.Location = new System.Drawing.Point(5, 41);
            this.pathWaypointDataGridView.Name = "pathWaypointDataGridView";
            this.pathWaypointDataGridView.RowHeadersVisible = false;
            this.pathWaypointDataGridView.Size = new System.Drawing.Size(156, 319);
            this.pathWaypointDataGridView.TabIndex = 0;
            // 
            // tagTextBox
            // 
            this.tagTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathWaypointBindingSource, "Tag", true));
            this.tagTextBox.Location = new System.Drawing.Point(109, 41);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(199, 20);
            this.tagTextBox.TabIndex = 5;
            // 
            // scriptTextBox
            // 
            this.scriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathWaypointBindingSource, "Script", true));
            this.scriptTextBox.Location = new System.Drawing.Point(57, 67);
            this.scriptTextBox.Multiline = true;
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.Size = new System.Drawing.Size(251, 186);
            this.scriptTextBox.TabIndex = 3;
            // 
            // movementTypeTextBox
            // 
            this.movementTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathWaypointBindingSource, "MovementType", true));
            this.movementTypeTextBox.Location = new System.Drawing.Point(109, 15);
            this.movementTypeTextBox.Name = "movementTypeTextBox";
            this.movementTypeTextBox.Size = new System.Drawing.Size(199, 20);
            this.movementTypeTextBox.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 428);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(94, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Tag";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MovementType";
            this.dataGridViewTextBoxColumn4.HeaderText = "MovementType";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Coordinates";
            this.dataGridViewTextBoxColumn1.HeaderText = "Coordinates";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Script";
            this.dataGridViewTextBoxColumn3.HeaderText = "Script";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // pathWaypointBindingSource
            // 
            this.pathWaypointBindingSource.DataSource = typeof(RomViewer.PathWaypoint);
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "*.xml";
            this.dlgOpen.FileName = "*.xml";
            this.dlgOpen.Filter = "XML files (*.xml) | *.xml | All files (*.*) | *.*";
            this.dlgOpen.ShowReadOnly = true;
            this.dlgOpen.Title = "Select a waypoint file";
            // 
            // dlgPathBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 470);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnStartNode);
            this.Controls.Add(this.label1);
            this.Name = "dlgPathBuilder";
            this.Text = "dlgPathBuilder";
            this.Shown += new System.EventHandler(this.dlgPathBuilder_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pathWaypointDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathWaypointBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartNode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView pathWaypointDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource pathWaypointBindingSource;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.TextBox scriptTextBox;
        private System.Windows.Forms.TextBox movementTypeTextBox;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}