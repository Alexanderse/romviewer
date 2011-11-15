namespace RomViewer
{
    partial class CommandSelector
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
            this.dgvSelector = new System.Windows.Forms.DataGridView();
            this.commandNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCommands = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.lbWaypoints = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommands)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSelector
            // 
            this.dgvSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelector.AutoGenerateColumns = false;
            this.dgvSelector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commandNameDataGridViewTextBoxColumn,
            this.commandTextDataGridViewTextBoxColumn});
            this.dgvSelector.DataSource = this.bsCommands;
            this.dgvSelector.Location = new System.Drawing.Point(0, 228);
            this.dgvSelector.Name = "dgvSelector";
            this.dgvSelector.RowHeadersVisible = false;
            this.dgvSelector.Size = new System.Drawing.Size(750, 204);
            this.dgvSelector.TabIndex = 0;
            this.dgvSelector.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // commandNameDataGridViewTextBoxColumn
            // 
            this.commandNameDataGridViewTextBoxColumn.DataPropertyName = "CommandName";
            this.commandNameDataGridViewTextBoxColumn.HeaderText = "Command";
            this.commandNameDataGridViewTextBoxColumn.Name = "commandNameDataGridViewTextBoxColumn";
            // 
            // commandTextDataGridViewTextBoxColumn
            // 
            this.commandTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commandTextDataGridViewTextBoxColumn.DataPropertyName = "CommandText";
            this.commandTextDataGridViewTextBoxColumn.HeaderText = "CommandText";
            this.commandTextDataGridViewTextBoxColumn.Name = "commandTextDataGridViewTextBoxColumn";
            // 
            // bsCommands
            // 
            this.bsCommands.DataSource = typeof(RomViewer.GameCommand);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // tbCommand
            // 
            this.tbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommand.Location = new System.Drawing.Point(0, 27);
            this.tbCommand.Multiline = true;
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(750, 166);
            this.tbCommand.TabIndex = 2;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(0, 192);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(750, 30);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.lbWaypoints);
            this.gb1.Location = new System.Drawing.Point(0, 438);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(750, 175);
            this.gb1.TabIndex = 4;
            this.gb1.TabStop = false;
            this.gb1.Text = "Waypoint files";
            // 
            // lbWaypoints
            // 
            this.lbWaypoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWaypoints.FormattingEnabled = true;
            this.lbWaypoints.Location = new System.Drawing.Point(3, 16);
            this.lbWaypoints.Name = "lbWaypoints";
            this.lbWaypoints.Size = new System.Drawing.Size(744, 156);
            this.lbWaypoints.TabIndex = 0;
            this.lbWaypoints.DoubleClick += new System.EventHandler(this.lbWaypoints_DoubleClick);
            // 
            // CommandSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 613);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.dgvSelector);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CommandSelector";
            this.Text = "CommandSelector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandSelector_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommands)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsCommands;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.ListBox lbWaypoints;
    }
}