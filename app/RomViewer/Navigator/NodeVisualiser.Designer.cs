namespace RomViewer.Navigator
{
    partial class NodeVisualiser
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWorld = new System.Windows.Forms.RadioButton();
            this.zoneComboBox = new System.Windows.Forms.ComboBox();
            this.zoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rbZone = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.cmMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hsbMap = new System.Windows.Forms.HScrollBar();
            this.vsbMap = new System.Windows.Forms.VScrollBar();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.waypointLinkDataGridView = new System.Windows.Forms.DataGridView();
            this.distanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.styleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scriptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waypointLinkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnGeneratePath = new System.Windows.Forms.Button();
            this.cbTarget = new System.Windows.Forms.ComboBox();
            this.targetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbSelected = new System.Windows.Forms.ComboBox();
            this.gameNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tkScale = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gameObjectsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTarget = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gameObjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xbUpdate = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.cmMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waypointLinkDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waypointLinkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkScale)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbWorld);
            this.groupBox1.Controls.Add(this.zoneComboBox);
            this.groupBox1.Controls.Add(this.rbZone);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Selection";
            // 
            // rbWorld
            // 
            this.rbWorld.AutoSize = true;
            this.rbWorld.Location = new System.Drawing.Point(389, 30);
            this.rbWorld.Name = "rbWorld";
            this.rbWorld.Size = new System.Drawing.Size(53, 17);
            this.rbWorld.TabIndex = 2;
            this.rbWorld.Text = "World";
            this.rbWorld.UseVisualStyleBackColor = true;
            this.rbWorld.CheckedChanged += new System.EventHandler(this.rbWorld_CheckedChanged);
            // 
            // zoneComboBox
            // 
            this.zoneComboBox.DataSource = this.zoneBindingSource;
            this.zoneComboBox.DisplayMember = "Name";
            this.zoneComboBox.FormattingEnabled = true;
            this.zoneComboBox.Location = new System.Drawing.Point(75, 29);
            this.zoneComboBox.Name = "zoneComboBox";
            this.zoneComboBox.Size = new System.Drawing.Size(274, 21);
            this.zoneComboBox.TabIndex = 1;
            this.zoneComboBox.ValueMember = "Id";
            // 
            // zoneBindingSource
            // 
            this.zoneBindingSource.DataSource = typeof(RomViewer.Model.Zone);
            this.zoneBindingSource.CurrentChanged += new System.EventHandler(this.zoneBindingSource_CurrentChanged);
            // 
            // rbZone
            // 
            this.rbZone.AutoSize = true;
            this.rbZone.Checked = true;
            this.rbZone.Location = new System.Drawing.Point(19, 30);
            this.rbZone.Name = "rbZone";
            this.rbZone.Size = new System.Drawing.Size(50, 17);
            this.rbZone.TabIndex = 0;
            this.rbZone.TabStop = true;
            this.rbZone.Text = "Zone";
            this.rbZone.UseVisualStyleBackColor = true;
            this.rbZone.CheckedChanged += new System.EventHandler(this.rbZone_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 602);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 42);
            this.panel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 92);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(848, 510);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pbMap);
            this.splitContainer2.Panel1.Controls.Add(this.hsbMap);
            this.splitContainer2.Panel1.Controls.Add(this.vsbMap);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.btnRun);
            this.splitContainer2.Panel2.Controls.Add(this.btnCreate);
            this.splitContainer2.Panel2.Controls.Add(this.btnClear);
            this.splitContainer2.Panel2.Controls.Add(this.waypointLinkDataGridView);
            this.splitContainer2.Panel2.Controls.Add(this.btnGeneratePath);
            this.splitContainer2.Panel2.Controls.Add(this.cbTarget);
            this.splitContainer2.Panel2.Controls.Add(this.cbSelected);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.tkScale);
            this.splitContainer2.Size = new System.Drawing.Size(848, 341);
            this.splitContainer2.SplitterDistance = 521;
            this.splitContainer2.TabIndex = 9;
            // 
            // pbMap
            // 
            this.pbMap.ContextMenuStrip = this.cmMap;
            this.pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMap.Location = new System.Drawing.Point(0, 0);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(504, 324);
            this.pbMap.TabIndex = 2;
            this.pbMap.TabStop = false;
            this.pbMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseClick);
            this.pbMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseDown);
            this.pbMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseUp);
            this.pbMap.Resize += new System.EventHandler(this.pbMap_Resize);
            // 
            // cmMap
            // 
            this.cmMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setSelectedToolStripMenuItem,
            this.setTargetToolStripMenuItem,
            this.toolStripMenuItem1});
            this.cmMap.Name = "cmMap";
            this.cmMap.Size = new System.Drawing.Size(138, 54);
            // 
            // setSelectedToolStripMenuItem
            // 
            this.setSelectedToolStripMenuItem.Name = "setSelectedToolStripMenuItem";
            this.setSelectedToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.setSelectedToolStripMenuItem.Text = "Set Selected";
            this.setSelectedToolStripMenuItem.Click += new System.EventHandler(this.setSelectedToolStripMenuItem_Click);
            // 
            // setTargetToolStripMenuItem
            // 
            this.setTargetToolStripMenuItem.Name = "setTargetToolStripMenuItem";
            this.setTargetToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.setTargetToolStripMenuItem.Text = "Set Target";
            this.setTargetToolStripMenuItem.Click += new System.EventHandler(this.setTargetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
            // 
            // hsbMap
            // 
            this.hsbMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hsbMap.Location = new System.Drawing.Point(0, 324);
            this.hsbMap.Name = "hsbMap";
            this.hsbMap.Size = new System.Drawing.Size(504, 17);
            this.hsbMap.TabIndex = 1;
            this.hsbMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbMap_Scroll);
            // 
            // vsbMap
            // 
            this.vsbMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsbMap.Location = new System.Drawing.Point(504, 0);
            this.vsbMap.Name = "vsbMap";
            this.vsbMap.Size = new System.Drawing.Size(17, 341);
            this.vsbMap.TabIndex = 0;
            this.vsbMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbMap_Scroll);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(187, 82);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create WPL";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(106, 82);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // waypointLinkDataGridView
            // 
            this.waypointLinkDataGridView.AllowUserToAddRows = false;
            this.waypointLinkDataGridView.AllowUserToDeleteRows = false;
            this.waypointLinkDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.waypointLinkDataGridView.AutoGenerateColumns = false;
            this.waypointLinkDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.waypointLinkDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.waypointLinkDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.distanceDataGridViewTextBoxColumn,
            this.styleDataGridViewTextBoxColumn,
            this.sourceDataGridViewTextBoxColumn,
            this.destinationDataGridViewTextBoxColumn,
            this.scriptDataGridViewTextBoxColumn});
            this.waypointLinkDataGridView.DataSource = this.waypointLinkBindingSource;
            this.waypointLinkDataGridView.Location = new System.Drawing.Point(23, 111);
            this.waypointLinkDataGridView.Name = "waypointLinkDataGridView";
            this.waypointLinkDataGridView.ReadOnly = true;
            this.waypointLinkDataGridView.RowHeadersVisible = false;
            this.waypointLinkDataGridView.Size = new System.Drawing.Size(288, 216);
            this.waypointLinkDataGridView.TabIndex = 6;
            // 
            // distanceDataGridViewTextBoxColumn
            // 
            this.distanceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.distanceDataGridViewTextBoxColumn.DataPropertyName = "Distance";
            this.distanceDataGridViewTextBoxColumn.HeaderText = "Distance";
            this.distanceDataGridViewTextBoxColumn.Name = "distanceDataGridViewTextBoxColumn";
            this.distanceDataGridViewTextBoxColumn.ReadOnly = true;
            this.distanceDataGridViewTextBoxColumn.Width = 74;
            // 
            // styleDataGridViewTextBoxColumn
            // 
            this.styleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.styleDataGridViewTextBoxColumn.DataPropertyName = "Style";
            this.styleDataGridViewTextBoxColumn.HeaderText = "Style";
            this.styleDataGridViewTextBoxColumn.Name = "styleDataGridViewTextBoxColumn";
            this.styleDataGridViewTextBoxColumn.ReadOnly = true;
            this.styleDataGridViewTextBoxColumn.Width = 55;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            this.sourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // destinationDataGridViewTextBoxColumn
            // 
            this.destinationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.destinationDataGridViewTextBoxColumn.DataPropertyName = "Destination";
            this.destinationDataGridViewTextBoxColumn.HeaderText = "Destination";
            this.destinationDataGridViewTextBoxColumn.Name = "destinationDataGridViewTextBoxColumn";
            this.destinationDataGridViewTextBoxColumn.ReadOnly = true;
            this.destinationDataGridViewTextBoxColumn.Width = 85;
            // 
            // scriptDataGridViewTextBoxColumn
            // 
            this.scriptDataGridViewTextBoxColumn.DataPropertyName = "Script";
            this.scriptDataGridViewTextBoxColumn.HeaderText = "Script";
            this.scriptDataGridViewTextBoxColumn.Name = "scriptDataGridViewTextBoxColumn";
            this.scriptDataGridViewTextBoxColumn.ReadOnly = true;
            this.scriptDataGridViewTextBoxColumn.Visible = false;
            // 
            // waypointLinkBindingSource
            // 
            this.waypointLinkBindingSource.DataSource = typeof(RomViewer.Model.WaypointLink);
            // 
            // btnGeneratePath
            // 
            this.btnGeneratePath.Location = new System.Drawing.Point(25, 82);
            this.btnGeneratePath.Name = "btnGeneratePath";
            this.btnGeneratePath.Size = new System.Drawing.Size(75, 23);
            this.btnGeneratePath.TabIndex = 5;
            this.btnGeneratePath.Text = "Path";
            this.btnGeneratePath.UseVisualStyleBackColor = true;
            this.btnGeneratePath.Click += new System.EventHandler(this.btnGeneratePath_Click);
            // 
            // cbTarget
            // 
            this.cbTarget.DataSource = this.targetBindingSource;
            this.cbTarget.DisplayMember = "Name";
            this.cbTarget.FormattingEnabled = true;
            this.cbTarget.Location = new System.Drawing.Point(75, 43);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(236, 21);
            this.cbTarget.TabIndex = 4;
            this.cbTarget.ValueMember = "Coordinates";
            this.cbTarget.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbTarget_Format);
            // 
            // targetBindingSource
            // 
            this.targetBindingSource.DataSource = typeof(RomViewer.Model.GameNode);
            // 
            // cbSelected
            // 
            this.cbSelected.DataSource = this.gameNodeBindingSource;
            this.cbSelected.DisplayMember = "Name";
            this.cbSelected.FormattingEnabled = true;
            this.cbSelected.Location = new System.Drawing.Point(75, 16);
            this.cbSelected.Name = "cbSelected";
            this.cbSelected.Size = new System.Drawing.Size(236, 21);
            this.cbSelected.TabIndex = 3;
            this.cbSelected.ValueMember = "Coordinates";
            this.cbSelected.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbTarget_Format);
            // 
            // gameNodeBindingSource
            // 
            this.gameNodeBindingSource.DataSource = typeof(RomViewer.Model.GameNode);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start";
            // 
            // tkScale
            // 
            this.tkScale.Dock = System.Windows.Forms.DockStyle.Left;
            this.tkScale.Location = new System.Drawing.Point(0, 0);
            this.tkScale.Margin = new System.Windows.Forms.Padding(1);
            this.tkScale.Maximum = 500;
            this.tkScale.MaximumSize = new System.Drawing.Size(18, 0);
            this.tkScale.Minimum = 1;
            this.tkScale.Name = "tkScale";
            this.tkScale.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkScale.Size = new System.Drawing.Size(18, 341);
            this.tkScale.TabIndex = 0;
            this.tkScale.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkScale.Value = 200;
            this.tkScale.ValueChanged += new System.EventHandler(this.tkScale_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gameObjectsDataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(848, 165);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nodes";
            // 
            // gameObjectsDataGridView
            // 
            this.gameObjectsDataGridView.AllowUserToAddRows = false;
            this.gameObjectsDataGridView.AllowUserToDeleteRows = false;
            this.gameObjectsDataGridView.AutoGenerateColumns = false;
            this.gameObjectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameObjectsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.btnTarget});
            this.gameObjectsDataGridView.DataSource = this.gameObjectsBindingSource;
            this.gameObjectsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameObjectsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gameObjectsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.gameObjectsDataGridView.Name = "gameObjectsDataGridView";
            this.gameObjectsDataGridView.ReadOnly = true;
            this.gameObjectsDataGridView.RowHeadersVisible = false;
            this.gameObjectsDataGridView.Size = new System.Drawing.Size(842, 146);
            this.gameObjectsDataGridView.TabIndex = 0;
            this.gameObjectsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameObjectsDataGridView_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 41;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // btnTarget
            // 
            this.btnTarget.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnTarget.HeaderText = "Target";
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.ReadOnly = true;
            this.btnTarget.Width = 44;
            // 
            // gameObjectsBindingSource
            // 
            this.gameObjectsBindingSource.DataMember = "GameObjects";
            this.gameObjectsBindingSource.DataSource = this.gameNodeBindingSource;
            // 
            // xbUpdate
            // 
            this.xbUpdate.AutoSize = true;
            this.xbUpdate.Checked = true;
            this.xbUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xbUpdate.Location = new System.Drawing.Point(761, 7);
            this.xbUpdate.Name = "xbUpdate";
            this.xbUpdate.Size = new System.Drawing.Size(90, 17);
            this.xbUpdate.TabIndex = 8;
            this.xbUpdate.Text = "Synchronise?";
            this.xbUpdate.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(262, 82);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(49, 23);
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // NodeVisualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 644);
            this.Controls.Add(this.xbUpdate);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NodeVisualiser";
            this.Text = "NodeVisualiser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NodeVisualiser_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NodeVisualiser_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NodeVisualiser_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.cmMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waypointLinkDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waypointLinkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkScale)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbWorld;
        private System.Windows.Forms.ComboBox zoneComboBox;
        private System.Windows.Forms.BindingSource zoneBindingSource;
        private System.Windows.Forms.RadioButton rbZone;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TrackBar tkScale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip cmMap;
        private System.Windows.Forms.ToolStripMenuItem setSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Button btnGeneratePath;
        private System.Windows.Forms.ComboBox cbTarget;
        private System.Windows.Forms.BindingSource gameNodeBindingSource;
        private System.Windows.Forms.ComboBox cbSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView waypointLinkDataGridView;
        private System.Windows.Forms.BindingSource waypointLinkBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn styleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scriptDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource targetBindingSource;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.HScrollBar hsbMap;
        private System.Windows.Forms.VScrollBar vsbMap;
        private System.Windows.Forms.BindingSource gameObjectsBindingSource;
        private System.Windows.Forms.DataGridView gameObjectsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn btnTarget;
        private System.Windows.Forms.CheckBox xbUpdate;
        private System.Windows.Forms.Button btnRun;

    }
}