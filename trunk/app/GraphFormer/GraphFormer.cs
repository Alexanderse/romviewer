// Copyright 2003 Eric Marchesin - <eric.marchesin@laposte.net>
//
// This source file(s) may be redistributed by any means PROVIDING they
// are not sold for profit without the authors expressed written consent,
// and providing that this notice and the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EMK.Cartography;
using EMK.LightGeometry;
using NHibernate;
using NHibernate.Context;
using RomViewer.Core;
using RomViewer.Core.Mapping;
using RomViewer.Core.NPCs;
using RomViewer.Init;
using RomViewer.Tasks;
using SharpLite.Domain.DataInterfaces;

namespace GraphViewer
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class GraphFormer : System.Windows.Forms.Form
    {
        #region Construction / Destruction

        private ContextMenu MenuContextuel;
        APropos DialogueAPropos = new APropos();

        private System.Windows.Forms.ToolBarButton AStarStep;
        private System.Windows.Forms.ImageList ImagesActions;
        private System.Windows.Forms.ImageList ImagesPasAPas;
        private System.Windows.Forms.ToolBar FichierToolBar;
        private System.Windows.Forms.ImageList ImagesFichier;
        private System.Windows.Forms.ToolBarButton BoutonSauver;
        private System.Windows.Forms.ToolBarButton BoutonCharger;
        private System.Windows.Forms.ToolBarButton Sep1;
        private System.Windows.Forms.ToolBarButton Sep2;
        private System.Windows.Forms.Label LabelAide;
        private System.Windows.Forms.ToolBarButton BoutonNouveau;
        private System.Windows.Forms.ToolBarButton BoutonDessiner;
        private System.Windows.Forms.ToolBarButton BoutonEffacer;
        private System.Windows.Forms.ToolBarButton BoutonDeplacer;
        private System.Windows.Forms.ToolBarButton BoutonChangerEtat;
        private System.Windows.Forms.ToolBarButton btnAStar;
        private System.Windows.Forms.ToolBarButton BoutonAProposDe;
        private System.Windows.Forms.StatusBar GraphStatusBar;
        private System.Windows.Forms.StatusBarPanel NbNodesPanel;
        private System.Windows.Forms.StatusBarPanel NbArcsPanel;
        private System.Windows.Forms.StatusBarPanel CoordsPanel;
        private System.Windows.Forms.ToolBar EditionToolBar;
        private System.Windows.Forms.ToolBar AEtoileToolBar;
        private System.Windows.Forms.ToolBarButton AStarStart;
        private System.Windows.Forms.ToolBarButton AStarFinish;
        private System.ComponentModel.IContainer components;

        static int Radius = 7;
        static int Epaisseur = 1;
        static Pen _nodePen;
        static Pen _arcPen;
        static Pen _inactiveNodePen;
        static Pen _inactiveArcPen;
        static Pen tmpPen;
        static Pen _pathPen;
        static Pen _noArcPen;

        int _minX = 0;
        int _maxX = 0;
        int _minY = 0;
        int _maxY = 0;
        private double _width = 0;
        private double _height;
        private int _zoomDelta = 0; //0-10000
        private double _movedX;
        private Panel panel1;
        private Splitter splitter1;
        private FlickerFreePanel GraphPanel;
        private double _movedY;

        static GraphFormer()
        {
            _nodePen = new Pen(Color.Black, Epaisseur);
            _inactiveNodePen = new Pen(Color.Gray, Epaisseur);

            _arcPen = new Pen(Color.Black, Epaisseur);
            _arcPen.EndCap = LineCap.Custom;
            _arcPen.CustomEndCap = new AdjustableArrowCap(3, 6, true);
            _inactiveArcPen = new Pen(Color.Gray, Epaisseur);
            _inactiveArcPen.EndCap = LineCap.Custom;
            _inactiveArcPen.CustomEndCap = new AdjustableArrowCap(3, 6, true);

            tmpPen = new Pen(Color.Gray, Epaisseur);
            tmpPen.DashStyle = DashStyle.Dash;

            _pathPen = new Pen(Color.DarkTurquoise, 3);
            _pathPen.DashStyle = DashStyle.Dot;

            _noArcPen = new Pen(Color.LawnGreen, 3);
            _noArcPen.EndCap = LineCap.Custom;
            _noArcPen.CustomEndCap = new AdjustableArrowCap(4, 8, true);

        }

        private void OnMouseWheel(object sender, MouseEventArgs mouseEventArgs)
        {
            // mouseEventArgs.Delta
            double ratio = ((double)_width + mouseEventArgs.Delta) / _width;

            _zoomDelta += mouseEventArgs.Delta;

            foreach (RomNode node in _graph.Nodes)
            {
                PlottedMapPoint pt = (PlottedMapPoint)node.Data;

                node.ChangeXYZ(node.X * ratio, node.Y * ratio, node.Z * ratio);
            }
            GraphPanel.Invalidate();
        }


        public GraphFormer()
        {
            MenuContextuel = new ContextMenu();
            MenuContextuel.MenuItems.Add(new MenuItem("Automatic", new EventHandler(AutoRoute)));
            MenuContextuel.MenuItems.Add(new MenuItem("Step by step", new EventHandler(StepByStepRoute)));
            InitializeComponent();
            btnAStar.DropDownMenu = MenuContextuel;

            _graph = new Graph();
            NewGraph();
            Mode = Action.Move;
            this.MouseWheel += OnMouseWheel;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing && components != null) components.Dispose();
            base.Dispose( disposing );
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphFormer));
            this.EditionToolBar = new System.Windows.Forms.ToolBar();
            this.BoutonDessiner = new System.Windows.Forms.ToolBarButton();
            this.BoutonEffacer = new System.Windows.Forms.ToolBarButton();
            this.BoutonDeplacer = new System.Windows.Forms.ToolBarButton();
            this.BoutonChangerEtat = new System.Windows.Forms.ToolBarButton();
            this.btnAStar = new System.Windows.Forms.ToolBarButton();
            this.ImagesActions = new System.Windows.Forms.ImageList(this.components);
            this.GraphStatusBar = new System.Windows.Forms.StatusBar();
            this.NbNodesPanel = new System.Windows.Forms.StatusBarPanel();
            this.NbArcsPanel = new System.Windows.Forms.StatusBarPanel();
            this.CoordsPanel = new System.Windows.Forms.StatusBarPanel();
            this.FichierToolBar = new System.Windows.Forms.ToolBar();
            this.BoutonNouveau = new System.Windows.Forms.ToolBarButton();
            this.BoutonCharger = new System.Windows.Forms.ToolBarButton();
            this.BoutonSauver = new System.Windows.Forms.ToolBarButton();
            this.BoutonAProposDe = new System.Windows.Forms.ToolBarButton();
            this.Sep1 = new System.Windows.Forms.ToolBarButton();
            this.ImagesFichier = new System.Windows.Forms.ImageList(this.components);
            this.AEtoileToolBar = new System.Windows.Forms.ToolBar();
            this.Sep2 = new System.Windows.Forms.ToolBarButton();
            this.AStarStart = new System.Windows.Forms.ToolBarButton();
            this.AStarStep = new System.Windows.Forms.ToolBarButton();
            this.AStarFinish = new System.Windows.Forms.ToolBarButton();
            this.ImagesPasAPas = new System.Windows.Forms.ImageList(this.components);
            this.LabelAide = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.GraphPanel = new GraphViewer.FlickerFreePanel();
            ((System.ComponentModel.ISupportInitialize)(this.NbNodesPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbArcsPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoordsPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // EditionToolBar
            // 
            this.EditionToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.EditionToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.BoutonDessiner,
            this.BoutonEffacer,
            this.BoutonDeplacer,
            this.BoutonChangerEtat,
            this.btnAStar});
            this.EditionToolBar.ButtonSize = new System.Drawing.Size(16, 16);
            this.EditionToolBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditionToolBar.Divider = false;
            this.EditionToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.EditionToolBar.DropDownArrows = true;
            this.EditionToolBar.ImageList = this.ImagesActions;
            this.EditionToolBar.Location = new System.Drawing.Point(104, 0);
            this.EditionToolBar.Name = "EditionToolBar";
            this.EditionToolBar.ShowToolTips = true;
            this.EditionToolBar.Size = new System.Drawing.Size(136, 26);
            this.EditionToolBar.TabIndex = 0;
            this.EditionToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.GraphToolBar_ButtonClick);
            // 
            // BoutonDessiner
            // 
            this.BoutonDessiner.ImageIndex = 0;
            this.BoutonDessiner.Name = "BoutonDessiner";
            this.BoutonDessiner.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.BoutonDessiner.Tag = 0;
            this.BoutonDessiner.ToolTipText = "Draw nodes and arcs";
            // 
            // BoutonEffacer
            // 
            this.BoutonEffacer.ImageIndex = 1;
            this.BoutonEffacer.Name = "BoutonEffacer";
            this.BoutonEffacer.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.BoutonEffacer.Tag = 1;
            this.BoutonEffacer.ToolTipText = "Erase nodes and arcs";
            // 
            // BoutonDeplacer
            // 
            this.BoutonDeplacer.ImageIndex = 2;
            this.BoutonDeplacer.Name = "BoutonDeplacer";
            this.BoutonDeplacer.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.BoutonDeplacer.Tag = 2;
            this.BoutonDeplacer.ToolTipText = "Move nodes";
            // 
            // BoutonChangerEtat
            // 
            this.BoutonChangerEtat.ImageIndex = 3;
            this.BoutonChangerEtat.Name = "BoutonChangerEtat";
            this.BoutonChangerEtat.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.BoutonChangerEtat.Tag = 3;
            this.BoutonChangerEtat.ToolTipText = "Change the state of nodes and arcs";
            // 
            // btnAStar
            // 
            this.btnAStar.ImageIndex = 4;
            this.btnAStar.Name = "btnAStar";
            this.btnAStar.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.btnAStar.Tag = 4;
            this.btnAStar.ToolTipText = "Place starting and ending flags, then find the best path.";
            // 
            // ImagesActions
            // 
            this.ImagesActions.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagesActions.ImageStream")));
            this.ImagesActions.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagesActions.Images.SetKeyName(0, "");
            this.ImagesActions.Images.SetKeyName(1, "");
            this.ImagesActions.Images.SetKeyName(2, "");
            this.ImagesActions.Images.SetKeyName(3, "");
            this.ImagesActions.Images.SetKeyName(4, "");
            // 
            // GraphStatusBar
            // 
            this.GraphStatusBar.Location = new System.Drawing.Point(0, 494);
            this.GraphStatusBar.Name = "GraphStatusBar";
            this.GraphStatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.NbNodesPanel,
            this.NbArcsPanel,
            this.CoordsPanel});
            this.GraphStatusBar.ShowPanels = true;
            this.GraphStatusBar.Size = new System.Drawing.Size(744, 24);
            this.GraphStatusBar.TabIndex = 1;
            this.GraphStatusBar.Text = "GraphStatusBar";
            // 
            // NbNodesPanel
            // 
            this.NbNodesPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.NbNodesPanel.Icon = ((System.Drawing.Icon)(resources.GetObject("NbNodesPanel.Icon")));
            this.NbNodesPanel.Name = "NbNodesPanel";
            this.NbNodesPanel.Text = "NbNodes";
            this.NbNodesPanel.ToolTipText = "Number of nodes";
            this.NbNodesPanel.Width = 82;
            // 
            // NbArcsPanel
            // 
            this.NbArcsPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.NbArcsPanel.Icon = ((System.Drawing.Icon)(resources.GetObject("NbArcsPanel.Icon")));
            this.NbArcsPanel.Name = "NbArcsPanel";
            this.NbArcsPanel.Text = "NbArcs";
            this.NbArcsPanel.ToolTipText = "Number of arcs";
            this.NbArcsPanel.Width = 72;
            // 
            // CoordsPanel
            // 
            this.CoordsPanel.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.CoordsPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.CoordsPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.CoordsPanel.Name = "CoordsPanel";
            this.CoordsPanel.Text = "Coordinates";
            this.CoordsPanel.Width = 573;
            // 
            // FichierToolBar
            // 
            this.FichierToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.FichierToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.BoutonNouveau,
            this.BoutonCharger,
            this.BoutonSauver,
            this.BoutonAProposDe,
            this.Sep1});
            this.FichierToolBar.ButtonSize = new System.Drawing.Size(16, 16);
            this.FichierToolBar.Divider = false;
            this.FichierToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.FichierToolBar.DropDownArrows = true;
            this.FichierToolBar.ImageList = this.ImagesFichier;
            this.FichierToolBar.Location = new System.Drawing.Point(0, 0);
            this.FichierToolBar.Name = "FichierToolBar";
            this.FichierToolBar.ShowToolTips = true;
            this.FichierToolBar.Size = new System.Drawing.Size(104, 26);
            this.FichierToolBar.TabIndex = 0;
            this.FichierToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.FichierToolBar_ButtonClick);
            // 
            // BoutonNouveau
            // 
            this.BoutonNouveau.ImageIndex = 0;
            this.BoutonNouveau.Name = "BoutonNouveau";
            this.BoutonNouveau.Tag = 0;
            this.BoutonNouveau.ToolTipText = "Clear the current graph to create a new one";
            // 
            // BoutonCharger
            // 
            this.BoutonCharger.ImageIndex = 1;
            this.BoutonCharger.Name = "BoutonCharger";
            this.BoutonCharger.Tag = 1;
            this.BoutonCharger.ToolTipText = "Load a graph";
            // 
            // BoutonSauver
            // 
            this.BoutonSauver.ImageIndex = 2;
            this.BoutonSauver.Name = "BoutonSauver";
            this.BoutonSauver.Tag = 2;
            this.BoutonSauver.ToolTipText = "Save the current graph";
            // 
            // BoutonAProposDe
            // 
            this.BoutonAProposDe.ImageIndex = 3;
            this.BoutonAProposDe.Name = "BoutonAProposDe";
            this.BoutonAProposDe.Tag = 3;
            this.BoutonAProposDe.ToolTipText = "About GraphFormer...";
            // 
            // Sep1
            // 
            this.Sep1.Name = "Sep1";
            this.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // ImagesFichier
            // 
            this.ImagesFichier.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagesFichier.ImageStream")));
            this.ImagesFichier.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagesFichier.Images.SetKeyName(0, "");
            this.ImagesFichier.Images.SetKeyName(1, "");
            this.ImagesFichier.Images.SetKeyName(2, "");
            this.ImagesFichier.Images.SetKeyName(3, "");
            // 
            // AEtoileToolBar
            // 
            this.AEtoileToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.AEtoileToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.Sep2,
            this.AStarStart,
            this.AStarStep,
            this.AStarFinish});
            this.AEtoileToolBar.ButtonSize = new System.Drawing.Size(16, 16);
            this.AEtoileToolBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AEtoileToolBar.Divider = false;
            this.AEtoileToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.AEtoileToolBar.DropDownArrows = true;
            this.AEtoileToolBar.ImageList = this.ImagesPasAPas;
            this.AEtoileToolBar.Location = new System.Drawing.Point(240, 0);
            this.AEtoileToolBar.Name = "AEtoileToolBar";
            this.AEtoileToolBar.ShowToolTips = true;
            this.AEtoileToolBar.Size = new System.Drawing.Size(80, 26);
            this.AEtoileToolBar.TabIndex = 3;
            this.AEtoileToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.AEtoileToolBar_ButtonClick);
            // 
            // Sep2
            // 
            this.Sep2.Name = "Sep2";
            this.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // AStarStart
            // 
            this.AStarStart.ImageIndex = 0;
            this.AStarStart.Name = "AStarStart";
            this.AStarStart.Tag = 0;
            this.AStarStart.ToolTipText = "Initialize A*";
            // 
            // AStarStep
            // 
            this.AStarStep.ImageIndex = 1;
            this.AStarStep.Name = "AStarStep";
            this.AStarStep.Tag = 1;
            this.AStarStep.ToolTipText = "Perform A*\'s next step";
            // 
            // AStarFinish
            // 
            this.AStarFinish.ImageIndex = 2;
            this.AStarFinish.Name = "AStarFinish";
            this.AStarFinish.Tag = 2;
            this.AStarFinish.ToolTipText = "Perform A* to the end";
            // 
            // ImagesPasAPas
            // 
            this.ImagesPasAPas.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagesPasAPas.ImageStream")));
            this.ImagesPasAPas.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagesPasAPas.Images.SetKeyName(0, "");
            this.ImagesPasAPas.Images.SetKeyName(1, "");
            this.ImagesPasAPas.Images.SetKeyName(2, "");
            // 
            // LabelAide
            // 
            this.LabelAide.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelAide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAide.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.LabelAide.Location = new System.Drawing.Point(0, 0);
            this.LabelAide.Name = "LabelAide";
            this.LabelAide.Size = new System.Drawing.Size(744, 24);
            this.LabelAide.TabIndex = 4;
            this.LabelAide.Text = "Aide";
            this.LabelAide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(544, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 470);
            this.panel1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(541, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 470);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // GraphPanel
            // 
            this.GraphPanel.AutoScroll = true;
            this.GraphPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GraphPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GraphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphPanel.Location = new System.Drawing.Point(0, 24);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(541, 470);
            this.GraphPanel.TabIndex = 7;
            this.GraphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPanel_Paint);
            this.GraphPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseDown);
            this.GraphPanel.MouseLeave += new System.EventHandler(this.GraphPanel_MouseLeave);
            this.GraphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseMove);
            this.GraphPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseUp);
            // 
            // GraphFormer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 518);
            this.Controls.Add(this.GraphPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GraphStatusBar);
            this.Controls.Add(this.FichierToolBar);
            this.Controls.Add(this.EditionToolBar);
            this.Controls.Add(this.AEtoileToolBar);
            this.Controls.Add(this.LabelAide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GraphFormer";
            this.Text = "GraphFormer";
            this.Load += new System.EventHandler(this.GraphFormer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NbNodesPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbArcsPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoordsPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region State

        bool RightButtonDown = false;
        bool LeftButtonDown = false;

        Graph _graph;
        Node tmpNodeA, tmpNodeB;
        bool _nodeAWasAdded, _addedNodeB;
        AStar pathBuilder;
        Node sourceNode, destinationNode;
        Node[] _path;
        Point TempP;
        int _chosenHeuristic = 0;
        
        bool _stepByStep;
        bool StepByStep
        {
            get { return _stepByStep; }
            set
            {
                _stepByStep = value;
                if ( UpdateAStar() ) GraphPanel.Invalidate();
                MenuContextuel.MenuItems[0].Checked = !_stepByStep;
                MenuContextuel.MenuItems[1].Checked = _stepByStep;
                AEtoileToolBar.Visible = _stepByStep;
            }
        }

        bool CalcIsPossible { get { return sourceNode!=null && destinationNode!=null; } }

        enum Action { Draw, Delete, Move, ChangeState, AStar }
        Action _Mode;
        private Node _origin;
        private Node _termination;
        private Map _map;
        private ISessionFactory _factory;
        private ISession _session;
        private INonPlayerEntityRepository _npeRepo;
        private IRepository<MapPoint> _pointRepo;
        private IRepository<MapZone> _zoneRepo;

        Action Mode
        {
            get { return _Mode; }
            set
            {
                _Mode = value;
                foreach ( ToolBarButton B in EditionToolBar.Buttons ) B.Pushed = false; // Actions exclusives
                EditionToolBar.Buttons[(int)_Mode].Pushed = true;
                switch( _Mode )
                {
                    case Action.AStar:
                    {
                        LabelAide.Text = "Choose starting and ending nodes with the respective left and right mouse buttons";
                        ShowResultInfo();
                        break;
                    }
                    case Action.ChangeState:
                    {
                        LabelAide.Text = "Select a node or an arc to activate/deactivate";
                        break;
                    }
                    case Action.Move:
                    {
                        LabelAide.Text = "Select a node with left button to move it (right button to move the entire graph)";
                        break;
                    }
                    case Action.Draw:
                    {
                        LabelAide.Text = "Clic and drag to draw an arc between 2 nodes (right button for bidirectional arcs)";
                        break;
                    }
                    case Action.Delete:
                    {
                        LabelAide.Text = "Chose nodes to delete (clic or select a rectangle)";
                        break;
                    }
                }
            }
        }
        #endregion

        #region Util methods
        static Rectangle BoundingBox(params Node[] nodes)
        {
            Rectangle R = RectangleCentres(nodes);
            Size S = new Size(Radius+2*Epaisseur, Radius+2*Epaisseur);
            R.Inflate(S);
            return R;
        }

        static Rectangle RectangleCentres(params Node[] nodes)
        {
            double[] Min, Max;
            Node.BoundingBox(nodes, out Min, out Max);
            return Rectangle.FromLTRB((int)Min[0], (int)Min[1], (int)Max[0], (int)Max[1]);
        }

        static bool Collision(Node N1, Node N2)
        {
            return Node.SquareEuclidianDistance(N1, N2)<=Radius*Radius;
        }

        bool AddSelectOrMoveNodeAt(int X, int Y, ref Node currentNode)
        {
            Node node = NodeAt(X, Y);
            if ( node!=null )
            {
                currentNode = node;
                return false;
            }
            else
            {
                if (currentNode==null) currentNode = new Node(X, Y, 0, "");
                else currentNode.ChangeXYZ(X, Y, 0);
                return true;
            }
        }

        Node NodeAt(int X, int Y)
        {
            double Distance;
            Node ClosestNode = _graph.ClosestNode(X, Y, 0, out Distance, false);
            return Distance<=2*Radius ? ClosestNode : null;
        }

        Arc GetArcAt(int X, int Y)
        {
            double Distance;
            Arc nearestArc = _graph.ClosestArc(X, Y, 0, out Distance, false);
            return Distance<=Radius ? nearestArc : null;
        }
        #endregion

        #region Events
        private void GraphToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            Mode = (Action)e.Button.Tag;
        }

        private void AutoRoute(object sender, EventArgs e) { StepByStep = false; }
        private void StepByStepRoute(object sender, EventArgs e) { StepByStep = true; }

        private void GraphPanel_MouseLeave(object sender, System.EventArgs e)
        {
            if ( !CalcIsPossible ) CoordsPanel.Text = String.Empty;
        }

        private void GraphPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ( e.Button==MouseButtons.Left ) LeftButtonDown = true;
            else if ( e.Button==MouseButtons.Right ) RightButtonDown = true;
            else return;
            if ( LeftButtonDown && RightButtonDown ) return;

            tmpNodeA = tmpNodeB = null;
            switch ( Mode )
            {
                case Action.Delete:
                case Action.Draw:
                {
                    _nodeAWasAdded = AddSelectOrMoveNodeAt(e.X, e.Y, ref tmpNodeA);
                    tmpNodeB = new Node(tmpNodeA.X, tmpNodeA.Y, 0, "");
                    GraphPanel.Invalidate( BoundingBox(tmpNodeA, tmpNodeB) );
                    break;
                }
                case Action.Move:
                {
                    TempP = new Point(e.X, e.Y);
                    tmpNodeA = NodeAt(e.X, e.Y);
                    if (tmpNodeA == _origin) tmpNodeA = null;
                    if (tmpNodeA == _termination) tmpNodeA = null;
                    _updateSelected(tmpNodeA);
                    break;
                }
                default: break;
            }
        }

        private void _updateSelected(Node node)
        {
            //throw new NotImplementedException();
        }

        public Node AddNode(double X, double Y, PlottedMapPoint data)
        {
            var result = new RomNode(X, Y, 0, data);
            result.Isolate(); _graph.AddNode(result);

            return result;
        }

        private void ResizePanel(int width, int height)
        {
            //if ((GraphPanel.Width != width) || (GraphPanel.Height != height))
            //{
           //     GraphPanel.SetBounds(GraphPanel.Left,GraphPanel.Top,width,height);
           //     GraphPanel.Invalidate();
           // }
        }

        string SB_Point(int X, int Y) { return "{"+X+";"+Y+"}"; }
        string SB_Noeud(int X, int Y) { return "Node "+SB_Point(X, Y); }
        string SB_TempArc(int X, int Y, bool DoubleSens)
        {
            string Fleche = DoubleSens ? " <-> " : " -> ";
            Node N = NodeAt(X, Y);
            string Cible = N!=null ? SB_Noeud((int)N.X, (int)N.Y) : SB_Point((int)tmpNodeB.X, (int)tmpNodeB.Y);
            return SB_Point((int)tmpNodeA.X, (int)tmpNodeA.Y)+Fleche+Cible+" : Length = "+(int)Node.EuclidianDistance(tmpNodeA, tmpNodeB);
        }
        string SB_TempRectangle()
        {
            return SB_Point((int)tmpNodeA.X, (int)tmpNodeA.Y)+" + "+SB_Point((int)Math.Abs(tmpNodeA.X-tmpNodeB.X), (int)Math.Abs(tmpNodeA.Y-tmpNodeB.Y));
        }
        string SB_DetecterNoeud(int X, int Y)
        {
            Node N = NodeAt(X, Y);
            return N!=null ? SB_Noeud((int)N.X, (int)N.Y) : SB_Point(X, Y);
        }
        string SB_DetecterNoeudOuArc(int X, int Y)
        {
            Node N = NodeAt(X, Y);
            if ( N!=null ) return SB_Noeud((int)N.X, (int)N.Y);
            Arc A = GetArcAt(X, Y);
            if ( A!=null ) return "Arc "+SB_Point((int)A.StartNode.X, (int)A.StartNode.Y)+" -> "+SB_Point((int)A.EndNode.X, (int)A.EndNode.Y);
            return SB_Point(X, Y);
        }
        string SB_NearestNode(int X, int Y)
        {
            double Distance;
            Node N = _graph.ClosestNode(X, Y, 0, out Distance, true);
            return N!=null ? SB_Noeud((int)N.X, (int)N.Y) : SB_Point(X, Y);
        }

        void StatusBarMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;
            bool BoutonEnfonce = e.Button==MouseButtons.Left || e.Button==MouseButtons.Right;

            switch( Mode )
            {
                case Action.Draw:
                {
                    CoordsPanel.Text = BoutonEnfonce ? SB_TempArc(X, Y, e.Button==MouseButtons.Right) : SB_DetecterNoeud(X, Y);
                    break;
                }
                case Action.Delete:
                {
                    CoordsPanel.Text = BoutonEnfonce ? SB_TempRectangle() : SB_DetecterNoeudOuArc(X, Y);
                    break;
                }
                case Action.Move:
                {
                    if ( e.Button==MouseButtons.Right ) CoordsPanel.Text = String.Empty;
                    else
                    {
                        if ( BoutonEnfonce )
                            CoordsPanel.Text = tmpNodeA!=null ? SB_Noeud(X, Y) : SB_Point(X, Y);
                        else
                            CoordsPanel.Text = SB_DetecterNoeud(X, Y);
                    }
                    break;
                }
                case Action.ChangeState:
                {
                    CoordsPanel.Text = SB_DetecterNoeudOuArc(X, Y);
                    break;
                }
                case Action.AStar:
                {
                    string S = String.Empty;
                    if ( sourceNode==null && destinationNode==null ) S = "Select STARTING and ENDING nodes";
                    else if ( sourceNode==null ) S = "Select STARTING node (with left button)";
                    else if ( destinationNode==null ) S = "Select ENDING node (with right button)";
                    CoordsPanel.Text = S+". Current : "+SB_NearestNode(X, Y);
                    break;
                }
            }
        }

        private void GraphPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ( LeftButtonDown && RightButtonDown ) return;
            switch( Mode )
            {
                case Action.Delete:
                case Action.Draw:
                {
                    if ( e.Button==MouseButtons.Left || e.Button==MouseButtons.Right )
                    {
                        if ( tmpNodeA==null || tmpNodeB==null ) return;
                        Rectangle oldRect = BoundingBox(tmpNodeA, tmpNodeB);
                        tmpNodeB.ChangeXYZ(e.X, e.Y, 0);
                        Rectangle newRect = BoundingBox(tmpNodeA, tmpNodeB);
                        GraphPanel.Invalidate( Rectangle.Union(oldRect, newRect) );
                    }
                    break;
                }
                case Action.Move:
                {
                    if ( e.Button==MouseButtons.Left )
                    {
                        if ( tmpNodeA==null ) break;
                        Rectangle oldRect = BoundingBox(tmpNodeA.Molecule);

                        Node[] oldPath = null;
                        if ( _path!=null )
                        {
                            oldPath = new Node[_path.Length];
                            for ( int i=0; i<oldPath.Length; i++ ) oldPath[i] = (Node)_path[i].Clone();
                        }
                        _movedX += (e.X - tmpNodeA.X);
                        _movedY += (e.Y - tmpNodeA.Y);
                        tmpNodeA.ChangeXYZ(e.X, e.Y, 0);
                        _updateSelected(tmpNodeA);
                        Rectangle newRect = BoundingBox(tmpNodeA.Molecule);
                        if ( UpdateAStar() && DifferentPaths(oldPath, _path) ) GraphPanel.Invalidate();
                        else GraphPanel.Invalidate( Rectangle.Union(oldRect, newRect) );
                    }
                    else if ( e.Button==MouseButtons.Right )
                    {
                        int DX = (int)(e.X-TempP.X);
                        int DY = (int)(e.Y-TempP.Y);
                        TempP.X = e.X;
                        TempP.Y = e.Y;
                        foreach ( Node N in _graph.Nodes ) N.ChangeXYZ(N.X+DX, N.Y+DY, 0);
                        GraphPanel.Invalidate();
                    }
                    break;
                }
                default: break;
            }
            if ( !CalcIsPossible ) StatusBarMouseMove(e);
        }

        private void GraphPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bool doNothing = LeftButtonDown && RightButtonDown;
            if ( e.Button==MouseButtons.Left ) LeftButtonDown = false;
            else if ( e.Button==MouseButtons.Right ) RightButtonDown = false;
            else return;
            if ( doNothing ) return;

            switch( Mode )
            {
                case Action.Draw:
                {
                    if ( tmpNodeA==null || tmpNodeB==null ) return;
                    bool arcAdded = false;
                    Rectangle oldRect = BoundingBox(tmpNodeA, tmpNodeB);
                    _addedNodeB = AddSelectOrMoveNodeAt(e.X, e.Y, ref tmpNodeB);
                    if ( _nodeAWasAdded ) { tmpNodeA.Isolate(); _graph.AddNode(tmpNodeA); }
                    if ( !Collision(tmpNodeA, tmpNodeB) )
                    {
                        if ( _addedNodeB ) { tmpNodeB.Isolate(); _graph.AddNode(tmpNodeB); }
                        if ( e.Button == MouseButtons.Left )
                            _graph.AddArc(tmpNodeA, tmpNodeB, 1);
                        else if ( e.Button == MouseButtons.Right ) _graph.Add2Arcs(tmpNodeA, tmpNodeB, 1);
                        NbArcsPanel.Text = _graph.Arcs.Count.ToString();
                        arcAdded = true;
                    }
                    NbNodesPanel.Text = _graph.Nodes.Count.ToString();

                    if ( arcAdded && ( !_nodeAWasAdded || !_addedNodeB ) && UpdateAStar() ) GraphPanel.Invalidate();
                    else
                    {
                        Rectangle newRect = BoundingBox(tmpNodeA, tmpNodeB);
                        GraphPanel.Invalidate( Rectangle.Union(oldRect, newRect) );
                    }
                    break;
                }
                case Action.Delete:
                {
                    if ( tmpNodeA==null || tmpNodeB==null ) return;
                    bool Selection = false;
                    Rectangle Zone = RectangleCentres(tmpNodeA, tmpNodeB);
                    Zone.Inflate(1,1);
                    Region Invalide = new Region(Zone);
                    if ( Zone.Size.Width<2*Radius && Zone.Size.Height<2*Radius )
                    {
                        Node N = NodeAt(e.X, e.Y);
                        if ( N!=null )
                        {
                            TestAStar(N, ref Invalide);
                            Invalide.Union(BoundingBox(N.Molecule));
                            _graph.RemoveNode(N);
                            NbNodesPanel.Text = _graph.Nodes.Count.ToString();
                            NbArcsPanel.Text = _graph.Arcs.Count.ToString();
                            Selection = true;
                        }
                        else
                        {
                            Arc A = GetArcAt(e.X, e.Y);
                            if ( A!=null )
                            {
                                Invalide.Union( BoundingBox(A.StartNode, A.EndNode) );
                                _graph.RemoveArc(A);
                                NbArcsPanel.Text = _graph.Arcs.Count.ToString();
                                Selection = true;
                            }
                        }
                    }
                    else
                    {
                        ArrayList ListeNoeuds = new ArrayList();
                        foreach ( Node N in _graph.Nodes )
                        {
                            if ( Zone.Contains(new Point((int)N.X, (int)N.Y)) )
                            {
                                TestAStar(N, ref Invalide);
                                Invalide.Union( BoundingBox(N.Molecule) );
                                ListeNoeuds.Add(N);
                                Selection = true;
                            }
                        }
                        foreach ( Node N in ListeNoeuds ) _graph.RemoveNode(N);
                        NbNodesPanel.Text = _graph.Nodes.Count.ToString();
                        NbArcsPanel.Text = _graph.Arcs.Count.ToString();
                    }

                    if ( Selection && UpdateAStar() ) GraphPanel.Invalidate();
                    else GraphPanel.Invalidate(Invalide);
                    break;
                }
                case Action.ChangeState:
                {
                    Node N = NodeAt(e.X, e.Y);
                    Region Invalide = null;
                    if ( N!=null )
                    {
                        N.Passable = !N.Passable;
                        Invalide = new Region(BoundingBox(N.Molecule));
                    }
                    else
                    {
                        Arc A = GetArcAt(e.X, e.Y);
                        if ( A!=null )
                        {
                            A.IsPassable = !A.IsPassable;
                            Invalide = new Region(BoundingBox(A.StartNode, A.EndNode));
                        }
                    }

                    if ( Invalide!=null )
                    {
                        if ( UpdateAStar() ) GraphPanel.Invalidate();
                        else GraphPanel.Invalidate(Invalide);
                    }
                    break;
                }
                case Action.AStar:
                {
                    double Distance;
                    Node NearestNode = _graph.ClosestNode(e.X, e.Y, 0, out Distance, true);
                    if ( NearestNode==null ) break;
                    Rectangle Invalide = BoundingBox(NearestNode);

                    if ( sourceNode!=null ) Invalide = Rectangle.Union(Invalide, BoundingBox(sourceNode));
                    if ( destinationNode!=null ) Invalide = Rectangle.Union(Invalide, BoundingBox(destinationNode));

                    if ( e.Button==MouseButtons.Left ) sourceNode = sourceNode==NearestNode ? null : NearestNode;
                    else if ( e.Button==MouseButtons.Right ) destinationNode = destinationNode==NearestNode ? null : NearestNode;

                    if ( UpdateAStar() ) GraphPanel.Invalidate();
                    else
                    {
                        if ( _path!=null )
                        {
                            _path = null;
                            GraphPanel.Invalidate();
                        }
                        else GraphPanel.Invalidate(Invalide);
                    }
                    break;
                }
                default: break;
            }
            tmpNodeA = tmpNodeB = null;
        }

        // retourne true s'il faut invalider tout le panel
        bool UpdateAStar()
        {
            if ( !StepByStep )
            {
                if ( !CalcIsPossible ) return false;
                AStarEnd();
                return true;
            }
            else
            {
                bool notAtEnd  = pathBuilder.Closed.Length>0 || pathBuilder.Open.Length>1;
                AStarBegin();
                return notAtEnd;
            }
        }

        bool DifferentPaths(Node[] C1, Node[] C2)
        {
            if ( C1==null || C2==null || C1.Length!=C2.Length ) return true;
            for ( int i=0; i<C1.Length; i++) if ( !C1[i].Equals(C2[i]) ) return true;
            return false;
        }

        void TestAStar(Node N, ref Region invalidZone)
        {
            if ( N!=null )
            {
                if ( N==sourceNode ) sourceNode=null;
                if ( N==destinationNode ) destinationNode=null;
                if ( _path!=null && Array.IndexOf(_path, N)>=0 )
                {
                    _path=null;
                    invalidZone.Union(new Rectangle(new Point(0,0),GraphPanel.Size));				
                }
            }
        }

        private void AEtoileToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if ( !CalcIsPossible ) MessageBox.Show(
                                       @"Before performing A* you must choose the starting and ending nodes
with the respective left and right mouse buttons.", "Impossible action", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            switch( (int)e.Button.Tag )
            {
                case 0:
                {
                    AStarBegin();
                    break;
                }
                case 1:
                {
                    AStar_Step();
                    break;
                }
                case 2:
                {
                    AStarEnd();
                    break;
                }
            }
            GraphPanel.Invalidate();
        }

        private void AStarBegin()
        {
            if ( !CalcIsPossible )
            {
                foreach ( ToolBarButton B in AEtoileToolBar.Buttons ) B.Enabled = false;
                return;
            }
            else
            {
                AStarStart.Enabled = false;
                AStarFinish.Enabled = true;
                AStarStep.Enabled = true;
                _path = null;
                pathBuilder.Initialize(sourceNode, destinationNode);
                ShowResultInfo();
            }
        }

        private void AStar_Step()
        {
            if ( !CalcIsPossible ) return;
            if ( !pathBuilder.NextStep() )
            {
                _path = pathBuilder.PathByNodes;
                AStarFinish.Enabled = false;
                AStarStep.Enabled = false;
            }
            ShowResultInfo();
            AStarStart.Enabled = true;
        }

        private void AStarEnd()
        {
            if ( !CalcIsPossible ) return;
            _path = pathBuilder.SearchPath(sourceNode, destinationNode) ? pathBuilder.PathByNodes : null;
            ShowResultInfo();
            AStarStart.Enabled = true;
            AStarFinish.Enabled = false;
            AStarStep.Enabled = false;
        }

        void ShowResultInfo()
        {
            if ( !CalcIsPossible ) return;

            else if ( _path==null )
            {
                if ( StepByStep ) CoordsPanel.Text = String.Format("Open list : {0} (green) ; Closed list : {1} (red)   -   Current step : {2}", pathBuilder.Open.Length, pathBuilder.Closed.Length, pathBuilder.StepCounter);
                else CoordsPanel.Text = "There is no possible path in this configuration.";
            }
            else 
            {
                int arcsInPath;
                double costOfPath;
                if ( pathBuilder.PathFound )
                {
                    pathBuilder.ResultInformation(out arcsInPath, out costOfPath);
                    CoordsPanel.Text = String.Format("Shortest path found in {0} step(s) : {1} arc(s) \\ cost = {2}", pathBuilder.StepCounter, arcsInPath, (int)costOfPath);
                }
            }

            if ( StepByStep && pathBuilder.SearchEnded && !pathBuilder.PathFound )
            {
                GraphPanel.Invalidate();
                MessageBox.Show(
                    @"In this configuration, there is no possible path. You can :
- either modify the graph
- or change the starting and/or ending nodes.", "No result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FichierToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch( (int)e.Button.Tag )
            {
                case 0:
                {
                    if ( _graph.Nodes.Count>0 )
                    {
                        DialogResult DR = MessageBox.Show("You are about to clear the current graph. Do you confirm ?", "New graph", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if ( DR==DialogResult.No ) break;
                    }
                    _graph.Clear();
                    NewGraph();
                    GraphPanel.Invalidate();
                    break;
                }
                case 1:
                    {
                        List<int> zones = new List<int>();

                        using (var f = new dlgLoadMap(_zoneRepo.GetAll().ToArray()))
                        {
                            if (f.ShowDialog() == DialogResult.Cancel) return;
                            foreach (var zone in f.GetZones())
                            {
                                zones.Add(zone.RomId);
                            }
                        }
                        _graph.Clear();
                        _movedX = 0;
                        _movedY = 0;
                        _zoomDelta = 0;
                        _origin = null;
                        _termination = null;

                        //NewGraph();

                        List<PlottedMapPoint> points = new List<PlottedMapPoint>();

                        foreach (DictionaryEntry entry in _map.MappedPoints)
                        {
                            var point = (PlottedMapPoint)entry.Value;
                            if (zones.Contains(point.MapPoint.MapZone.RomId)) points.Add(point);
                        }
                        
                        bool first = true;

                        foreach (var point in points)
                        {
                            if (first)
                            {
                                _minX = (int)point.Location.X;
                                _maxX = (int)point.Location.X;
                                _minY = -(int)point.Location.Z;
                                _maxY = -(int)point.Location.Z;
                                first = false;
                            }

                            if (point.Location.X < _minX) _minX = (int)point.Location.X;
                            if (-point.Location.Z < _minY) _minY = (int)-point.Location.Z;
                            if (point.Location.X > _maxX) _maxX = (int)point.Location.X;
                            if (-point.Location.Z > _maxY) _maxY = (int)-point.Location.Z;
                        }

                        _minX -= 10;
                        _maxX += 10;
                        _minY -= 10;
                        _maxY += 10;
                        _width = (_maxX - _minX);
                        _height = (_maxY - _minY);

                        List<Node> nodes = new List<Node>();
                        
                        Dictionary<int, Node> map = new Dictionary<int, Node>();
                        _origin = AddNode(-_minX, -_minY, new PlottedMapPoint(new MapPoint()){Location=new Vector3(0,0,0)});  //a reference point for calculations later on
                        _termination = AddNode(-_maxX, -_maxY, new PlottedMapPoint(new MapPoint()){Location=new Vector3(_width,_height,0)});  //a reference point for calculations later on
                        foreach (var point in points)
                        {
                            double x = point.Location.X + _origin.X;
                            double y = -point.Location.Z + _origin.Y;
                            var node = AddNode(x, y, point);
                            nodes.Add(node);
                            map.Add(point.MapPoint.Id,  node);
                        }

                        foreach (var point in points)
                        {
                            Node pNode = map[point.MapPoint.Id];
                            foreach (MapLink link in point.Links)
                            {
                                if (!map.ContainsKey(link.End.Id)) continue;

                                Node endNode = map[link.End.Id];
                                if (endNode == pNode) continue;
                                _graph.AddArc(pNode, endNode, (int)Node.SquareEuclidianDistance(pNode, endNode));
                            }
                        }

                        double ratio = GraphPanel.ClientSize.Width / _width;
                        double yRatio = GraphPanel.ClientSize.Height / _height;
                        if (yRatio < ratio) ratio = yRatio;

                        foreach (RomNode node in _graph.Nodes)
                        {
                            PlottedMapPoint pt = (PlottedMapPoint)node.Data;

                            node.ChangeXYZ(node.X * ratio, node.Y * ratio, node.Z * ratio);
                        }

                        nodes.Clear();
                        map.Clear();

                        GraphPanel.Invalidate();
                        MessageBox.Show(string.Format("{0},{1} to {2},{3}", _minX, _minY, _maxX, _maxY));
                    
/*					if ( _graph.Nodes.Count>0 )
                    {
                        DialogResult DR = MessageBox.Show("You are about to replace the current graph with another. Do you confirm ?", "Load a graph", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if ( DR==DialogResult.No ) break;
                    }
                    if ( _load() )
                    {
                        NewGraph();
                        GraphPanel.Invalidate();
                    }
 * */
                    break;
                }
                case 2:
                {
                    if ( _save() ) GraphPanel.Invalidate();
                    break;
                }
                case 3:
                {
                    DialogueAPropos.DijkstraHeuristiqueBalance = pathBuilder.DijkstraHeuristicBalance;
                    DialogueAPropos.HeuristiqueChoisie = _chosenHeuristic;

                    DialogResult DR = DialogueAPropos.ShowDialog(this);
                    if ( DR==DialogResult.OK ) ApplyChanges(DialogueAPropos);
                    break;
                }
            }
        }

        internal void ApplyChanges(APropos dlgAbout)
        {
            pathBuilder.DijkstraHeuristicBalance = dlgAbout.DijkstraHeuristiqueBalance;
            if ( _chosenHeuristic != dlgAbout.HeuristiqueChoisie )
            {
                _chosenHeuristic = dlgAbout.HeuristiqueChoisie;
                switch ( _chosenHeuristic )
                {
                    case 0: pathBuilder.ChoosenHeuristic = AStar.EuclidianHeuristic; break;
                    case 1: pathBuilder.ChoosenHeuristic = AStar.ManhattanHeuristic; break;
                    case 2: pathBuilder.ChoosenHeuristic = AStar.MaxAlongAxisHeuristic; break;
                }
            }
            UpdateAStar();
            GraphPanel.Invalidate();
        }

        void NewGraph()
        {
            tmpNodeA = tmpNodeB = null;
            _nodeAWasAdded = _addedNodeB = false;
            pathBuilder = new AStar(_graph);
            CoordsPanel.Text = String.Empty;;
            NbNodesPanel.Text = _graph.Nodes.Count.ToString();
            NbArcsPanel.Text = _graph.Arcs.Count.ToString();
            sourceNode = destinationNode = null;
            _path = null;
            StepByStep = false;
            AEtoileToolBar.Visible = false;
        }
        #endregion

        #region FileIO
        bool _load()
        {
            try
            {
                Stream StreamRead;
                OpenFileDialog DialogueCharger = new OpenFileDialog();
                if( DialogueCharger.ShowDialog() == DialogResult.OK )
                {
                    if( (StreamRead = DialogueCharger.OpenFile())!= null )
                    {
                        BinaryFormatter BinaryRead = new BinaryFormatter();
                        _graph = (Graph) BinaryRead.Deserialize(StreamRead);
                        StreamRead.Close();
                        return true;
                    }
                }
            }
            catch {}
            return false;
        }

        bool _save()
        {
            try
            {
                    Point3D origin = new Point3D(_origin.Position.X, _origin.Position.Y, _origin.Position.Z);
                    Point3D expectedOrigin = new Point3D(-_minX - (_width / 2), -_minY - (_height / 2), 0);
                    Point3D terminator = new Point3D(_termination.Position.X, _termination.Position.Y, _termination.Position.Z);
                    Point3D expectedTerminator = new Point3D((-_maxX - (_width / 2)), -_maxY - (_height / 2), 0);

                    //calculate factor to recale back to correct scaling
                    double currentWidth = (terminator.X - origin.X);
                    double expectedWidth = (expectedTerminator.X - expectedOrigin.X);
                    double ratio = expectedWidth/currentWidth;


                    //reverse and zooming
                    foreach (RomNode node in _graph.Nodes)
                    {
                        if ((node == _origin) || (node == _termination)) continue;

                        Point3D nodePos = new Point3D((node.Position.X-origin.X) * ratio, (node.Position.Y-origin.Y) * ratio, (node.Position.Z-origin.Z) * ratio);
                        //                            var node = AddNode(x - ((_maxX-_minX)/2), -(y-((_maxY-_minY)/2)), point);
                        PlottedMapPoint pt = (PlottedMapPoint) node.Data;
                        if (pt != null)
                        {
                            if (!areEqual(nodePos.X, pt.MapPoint.X))
                                pt.MapPoint.X = nodePos.X;
                            if (!areEqual(-nodePos.Y, pt.MapPoint.Z))
                                pt.MapPoint.Z = -nodePos.Y;
                        } else
                        {
                        }

                        _pointRepo.SaveOrUpdate(pt.MapPoint);
                    }
                    _session.Flush();
            }
            catch { }
            return false;
        }

        private bool areEqual(double d, double d1)
        {
            return Math.Abs(d1 - d) < 2;
        }

        #endregion

        #region Drawing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.PixelOffsetMode = PixelOffsetMode.None;

            SuspendLayout();
            // Dessin du graphe
            foreach ( Node N in _graph.Nodes ) DrawNode(graphics, N.Passable? _nodePen:_inactiveNodePen, N);
            foreach ( Arc A in _graph.Arcs ) DrawArc(graphics, A.IsPassable? _arcPen:_inactiveArcPen, A);

            // Dessin du tracé temporaire courant
            if ( Mode==Action.Draw )
            {
                DrawNode(graphics, tmpPen, tmpNodeA);
                DrawNode(graphics, tmpPen, tmpNodeB);
                DrawArc(graphics, tmpPen, tmpNodeA, tmpNodeB);
            }
            else if ( Mode==Action.Delete )
            {
                if ( tmpNodeA!=null && tmpNodeB!=null )
                    graphics.DrawRectangle(tmpPen, RectangleCentres(tmpNodeA, tmpNodeB));
            }

            DrawFlag(graphics, sourceNode, 1);
            DrawFlag(graphics, destinationNode, 2);

            // Draw the nodes "step by step"
            if ( StepByStep && CalcIsPossible )
            {
                Node[] DerniersNoeudsClosed = new Node[pathBuilder.Closed.Length];
                for ( int i=0; i<pathBuilder.Closed.Length; i++ )
                {
                    DerniersNoeudsClosed[i] = pathBuilder.Closed[i][pathBuilder.Closed[i].Length-1];
                    DrawFullNode(graphics, Brushes.Red, DerniersNoeudsClosed[i]);
                }
                if (_path==null)
                {
                    for ( int i=0; i<pathBuilder.Open.Length; i++ )
                    {
                        Node[] Nodes = pathBuilder.Open[i];
                        int L = Nodes.Length;
                        Node DernierNoeud = Nodes[L-1];
                        if ( Array.IndexOf(DerniersNoeudsClosed, DernierNoeud)>=0 )
                            DrawHalfNode(graphics, Brushes.LawnGreen, DernierNoeud);
                        else
                            DrawFullNode(graphics, Brushes.LimeGreen, DernierNoeud);
                    }
                    for ( int i=0; i<pathBuilder.Open.Length; i++ )
                    {
                        Node[] Nodes = pathBuilder.Open[i];
                        int L = Nodes.Length;
                        if ( L>1 )
                        {
                            DrawArc(graphics, _noArcPen, Nodes[L-2], Nodes[L-1]);
                            DrawNumber(graphics, Nodes[L-2], Nodes[L-1], i+1);
                        }
                    }
                }
            }
            
            // Draw AStar
            if ( _path!=null ) DrawPath(graphics, _pathPen, _path);
            ResumeLayout(false);
        }

        private void DrawNode(Graphics Grfx, Pen P, Node N)
        {
            if ((N == _origin) || (N == _termination) || (N==null )) return;
            int x = (int) (N.X + Radius + 5);
            int y = (int) (N.Y);
            Grfx.DrawEllipse(P, (int)N.X-Radius, (int)N.Y-Radius, 2*Radius+1, 2*Radius+1);
            Font fnt = new Font("Arial", 10);
            Grfx.DrawString(N.GetText(), DefaultFont, Brushes.Black, (float)x, (float)y);
        }

        static private void DrawArc(Graphics Grfx, Pen P, Arc A)
        {
            DrawArc(Grfx, P, A.StartNode, A.EndNode);
        }

        static private void DrawArc(Graphics Grfx, Pen P, Node N1, Node N2)
        {
            if ( N1==null || N2==null ) return;
            Grfx.DrawLine(P, (int)N1.X, (int)N1.Y, (int)N2.X, (int)N2.Y);
        }

        static private void DrawFullNode(Graphics Grfx, Brush B, Node N)
        {
            if ( N==null ) return;
            Rectangle R = new Rectangle((int)N.X-Radius, (int)N.Y-Radius, 2*Radius+1, 2*Radius+1);
            Grfx.FillEllipse(B, R);
        }

        static private void DrawHalfNode(Graphics Grfx, Brush B, Node N)
        {
            if ( N==null ) return;
            Rectangle R = new Rectangle((int)N.X-Radius, (int)N.Y-Radius, 2*Radius+1, 2*Radius+1);
            Grfx.FillPie(B, R, 0, 180);
        }

        static private void DrawNumber(Graphics Grfx, Node N1, Node N2, int i)
        {
            StringFormat F = new StringFormat();
            F.Alignment = StringAlignment.Center;
            F.LineAlignment = StringAlignment.Center;
            Rectangle R = RectangleCentres(N1, N2);
            Font Police = DefaultFont;
            int LargeurMin = (int)Police.GetHeight();
            R.Inflate(LargeurMin, LargeurMin);
            Grfx.DrawString(i.ToString(), Police, Brushes.Black, R, F);
        }

        static private void DrawFlag(Graphics Grfx, Node N, int Numero)
        {
            if ( N==null ) return;
            Point[] Pts = new Point[5];

            double AnglePortion = (2*Math.PI)/Pts.Length;
            for ( int i=0; i<Pts.Length; i++ )
            {
                double Angle = 2*i*AnglePortion;
                if ( Numero==1 ) Angle += AnglePortion/2;
                Pts[i] = new Point(1+(int)(N.X+(Radius+1)*Math.Cos(Angle)), 1+(int)(N.Y+(Radius+1)*Math.Sin(Angle)));
            }
            GraphicsPath GP = new GraphicsPath();
            GP.AddLines(Pts);
            GP.FillMode = FillMode.Winding;
            Grfx.FillPath(Numero==1 ? Brushes.DarkTurquoise : Brushes.Blue, GP);
        }

        static private void DrawPath(Graphics Grfx, Pen P, Node[] C)
        {
            Point[] Pnts = new Point[C.Length];
            if ( Pnts.Length>1 )
            {
                for ( int i=0; i<Pnts.Length; i++ )
                {
                    Pnts[i].X = (int)C[i].X;
                    Pnts[i].Y = (int)C[i].Y;
                }
                Grfx.DrawCurve(P, Pnts);
            }
        }
        #endregion

        public void SetSize(int x, int y)
        {
            ResizePanel(x,y);
        }

        private void GraphFormer_Load(object sender, EventArgs e)
        {
            RomViewContainer.Initialize();
            _factory = RomViewContainer.Container.GetInstance<ISessionFactory>();
            _session = _factory.OpenSession();
            CallSessionContext.Bind(_session);
            //ITransaction tx = session.BeginTransaction();
            _npeRepo = RomViewContainer.Container.GetInstance<INonPlayerEntityRepository>();
            _pointRepo = RomViewContainer.Container.GetInstance<IRepository<MapPoint>>();
            _zoneRepo = RomViewContainer.Container.GetInstance<IRepository<MapZone>>();

            MapBuilder mb = new MapBuilder(_npeRepo, _pointRepo, _zoneRepo);
            _map = mb.BuildMap(100);
            RomViewContainer.Container.Inject(typeof(Map), _map);
        }

    }

    public class RomNode : Node
    {
        public RomNode(double PositionX, double PositionY, double PositionZ, object data) : base(PositionX, PositionY, PositionZ, data)
        {
        }

        public override string GetText()
        {
            PlottedMapPoint point = _data as PlottedMapPoint;
            string pos;
            if (point != null)
            {
                pos = string.Format("{0:0},{1:0} : {2:0},{3:0}", point.Location.X, point.Location.Y, X, Y);
                return point.MapPoint.Name ?? point.MapPoint.Id.ToString(CultureInfo.InvariantCulture);// +" " + pos;
            }
            pos = string.Format("{0},{1}", X, Y);
            return base.GetText();// +" " + pos;
        }
    }
}
