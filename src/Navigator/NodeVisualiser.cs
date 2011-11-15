using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class NodeVisualiser : Form
    {
        public static NodeVisualiser Visualiser = null;

        private bool _sysEvent = false;
        private Zone _zone;
        private NodeViewer _viewer;
        private GameNode _selectedNode;
        private MapSettings _mapSettings;
        private bool _dontRepaint;
        private GameNode _startNode;
        private GameNode _endNode;

        public void UpdatePlayerPosition()
        {
            SetPlayerPosition();

            if (xbUpdate.Checked)
            {
                GameNode node = World.FindNearestNode(World.PlayerPos);
                if (node != null) _selectedNode = node;
            }

            DisplayMap();
        }

        private void SetPlayerPosition()
        {
            bool canShow = (rbWorld.Checked || ((rbZone.Checked) && ((zoneComboBox.SelectedItem == World.PlayerZone))));

            if (canShow)
            {
                _viewer.SetPlayerPos(World.PlayerPos);
            }
        }

        public NodeVisualiser()
        {
            Visualiser = this;

            InitializeComponent();
            zoneBindingSource.DataSource = World.Data.Zones;
            gameNodeBindingSource.DataSource = World.Data.Nodes;
            targetBindingSource.DataSource = World.Data.Nodes;
            vsbMap.Minimum = 0;
            vsbMap.Maximum = pbMap.Height;
            hsbMap.Minimum = 0;
            hsbMap.Maximum = pbMap.Width;

        }

        public NodeVisualiser(Zone zone, GameNode currentNode): this()
        {
            Visualiser = this;

            _sysEvent = true;
            try
            {
                _zone = zone;
                rbWorld.Checked = (zone == null);
                rbZone.Checked = !rbWorld.Checked;
                zoneComboBox.SelectedItem = zone;
                if (currentNode != null) cbSelected.SelectedItem = currentNode;
                DisplayMap();
            }
            finally
            {
                _sysEvent = false;
            }
        }

        private MapSettings GetMapSettings()
        {

            Pen movementPen = new Pen(Brushes.Black);
            movementPen.DashStyle = DashStyle.Dot;
            Pen linkPen = new Pen(Brushes.CornflowerBlue);
            linkPen.DashStyle = DashStyle.Dash;
            _mapSettings = new MapSettings(200, 8, (double)tkScale.Value / 10, Color.AntiqueWhite, Color.Black, movementPen, linkPen);

            _mapSettings.OnGetNodeBrush = OnGetNodeBrush;
            _mapSettings.OnGetLinkPen = OnGetLinkPen;

            return _mapSettings;
        }

        private Pen OnGetLinkPen(GameNode source, object link)
        {
            if ((waypointLinkBindingSource.DataSource != null) && (waypointLinkBindingSource.Count > 0))
            {
                List<WaypointLink> path = (List<WaypointLink>)waypointLinkBindingSource.DataSource;

                //see if this link is present.
                GameNode target = null;
                if (link is TransportLink)
                    target = ((TransportLink)link).Destination;
                else
                    target = ((GameNodeLink)link).Target;

                if (target != null)
                {
                    bool found = false;
                    foreach (var join in path)
                    {
                        if (((join.Source.Node == source) && (join.Destination.Node == target)) || ((join.Source.Node == target) && (join.Destination.Node == source)))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found) return new Pen(Color.Aquamarine,3);
                }
            }

            return (link is TransportLink) ? _mapSettings.TeleportLinkPen : _mapSettings.MovementLinkPen;
        }

        private Brush OnGetNodeBrush(GameNode node)
        {
            if (node == _selectedNode) return Brushes.DeepSkyBlue;
            if (node == cbSelected.SelectedItem) return Brushes.Chartreuse;
            if (node == cbTarget.SelectedItem) return Brushes.LightCoral;
            if (node == _startNode) return Brushes.Pink;
            if (node == _endNode) return Brushes.Red;
            return _mapSettings.NodeBrush;
        }

        public void DisplayMap()
        {
            _dontRepaint = true;
            try
            {
                if (rbZone.Checked && _zone == null)
                {
                    pbMap.Image = null;
                    return;
                }

                double xratio, yratio;
                xratio = 1;
                yratio = 1;
                if (_viewer != null)
                {
                    //record current center
                    if (hsbMap.Maximum > 0) xratio = (((double)hsbMap.Value) / ((double)hsbMap.Maximum));
                    if (vsbMap.Maximum > 0) yratio = (((double)vsbMap.Value) / ((double)vsbMap.Maximum));
                }

                if (_zone != null)
                    _viewer = new NodeViewer(_zone, GetMapSettings());
                else
                    _viewer = new NodeViewer(World.Data.Zones, GetMapSettings());


                Rectangle view = new Rectangle(hsbMap.Value, vsbMap.Value, pbMap.ClientSize.Width,pbMap.ClientSize.Height);
                _viewer.SetView(view);
                _viewer.SetPlayerPos(World.PlayerPos);
                Bitmap img = _viewer.GetMap();
                SetPlayerPosition();


                pbMap.Image = img;
                Size size = splitContainer2.Panel1.ClientSize;
                size.Width -= vsbMap.Width;
                size.Height -= hsbMap.Height;
                pbMap.Size = size;
                int maxX, maxY;

                maxY = _viewer.MapDimensions.Height - pbMap.Height;
                if (maxY < 1) vsbMap.Maximum = vsbMap.Minimum;
                else vsbMap.Maximum = maxY;

                maxX = _viewer.MapDimensions.Width - pbMap.Width;
                if (maxX < 1) hsbMap.Maximum = hsbMap.Minimum;
                else hsbMap.Maximum = maxX;

                hsbMap.Value = (int)(hsbMap.Maximum*xratio);
                vsbMap.Value = (int) (vsbMap.Maximum*yratio);
                hsbMap.SmallChange = (int)(hsbMap.Maximum / 50);
                hsbMap.LargeChange = (int) (hsbMap.Maximum/10);
                vsbMap.SmallChange = (int)(vsbMap.Maximum / 50);
                vsbMap.LargeChange = (int)(vsbMap.Maximum / 10);
            }
            finally
            {
                _dontRepaint = false;
            }
        }

        private void rbZone_CheckedChanged(object sender, EventArgs e)
        {
            if (_sysEvent) return;
            _zone = (Zone) zoneBindingSource.Current;
            vsbMap.Minimum = 0;
            vsbMap.Maximum = pbMap.Height;
            hsbMap.Minimum = 0;
            hsbMap.Maximum = pbMap.Width; 
            DisplayMap();
        }

        private void rbWorld_CheckedChanged(object sender, EventArgs e)
        {
            if (_sysEvent) return;
            _zone = null;
            zoneComboBox.SelectedIndex = -1;
            vsbMap.Minimum = 0;
            vsbMap.Maximum = pbMap.Height;
            hsbMap.Minimum = 0;
            hsbMap.Maximum = pbMap.Width; 
            DisplayMap();
        }

        private void zoneBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (_sysEvent) return;

            _zone = (Zone)zoneBindingSource.Current;
            if (rbZone.Checked) DisplayMap();
        }

        private void tkScale_ValueChanged(object sender, EventArgs e)
        {
            if (_sysEvent) return;

            DisplayMap();
        }

        private void pbMap_Click(object sender, EventArgs e)
        {

        }

        private void setSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbSelected.SelectedItem = _selectedNode;
        }

        private void setTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbTarget.SelectedItem = _selectedNode;
        }

        private void btnGeneratePath_Click(object sender, EventArgs e)
        {
            GameNode startNode = (GameNode) cbSelected.SelectedItem;
            GameNode endNode = (GameNode) cbTarget.SelectedItem;

            Waypoint start = World.Waypoints.Find(waypoint => (waypoint.Id == startNode.Id));
            Waypoint end = World.Waypoints.Find(waypoint => (waypoint.Id == endNode.Id));

            List<WaypointLink> path = World.GetShortestPath(end, start);
            path.Insert(0, new WaypointLink(start, start, LinkStyle.Walk));
            waypointLinkBindingSource.DataSource = path;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<WaypointLink> path = (List<WaypointLink>)waypointLinkBindingSource.DataSource;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><waypoints>");
            for (int i = 0; i < path.Count; i++)
            {
                string script = "";
                if (i < path.Count-1) script = path[i + 1].Script;
                sb.AppendLine(path[i].Destination.ToRomBotXML(i + 1, script));
            }
            sb.AppendLine("</waypoints>");

            string filename = @"C:\Installs\micromacro\scripts\rom\waypoints\newWP.xml";

            if (File.Exists(filename)) File.Delete(filename);
            string data = sb.ToString();
            File.WriteAllLines(filename, new string[] {data});

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string filename = @"C:\Installs\micromacro\scripts\rom\waypoints\newWP.xml";
            //send a message
            filename = filename.Replace("\"", "\\\"");
            mmServer.ServerInstance.QueueCommand("LoadNewWaypointList(\"newWP.xml\")");
        }

        private void NodeVisualiser_FormClosed(object sender, FormClosedEventArgs e)
        {
            NodeVisualiser.Visualiser = null;
        }

        private void vsbMap_Scroll(object sender, ScrollEventArgs e)
        {
            DisplayMap();
        }

        private void hsbMap_Scroll(object sender, ScrollEventArgs e)
        {
            DisplayMap();
        }

        private void cbTarget_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = e.ListItem.ToString();
           
        }

        private void pbMap_Resize(object sender, EventArgs e)
        {
            if (_dontRepaint) return;
            DisplayMap();
        }

        private void gameObjectsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == btnTarget.Index)
            {
                if (gameObjectsBindingSource.Current != null)
                {
                    GameObject obj = (GameObject) gameObjectsBindingSource.Current;

                    mmServer.ServerInstance.QueueCommand("player:target_NPC(" + obj.Id.ToString() + ");");
                }
            }
        }

        private void pbMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //get mouse xy etc
                PointF mouseLocation = new PointF(e.Location.X, e.Location.Y);

                //find node
                GameNode node = _viewer.FindNodeAtPoint(mouseLocation);
                _startNode = node;
            }
            else if (e.Button == MouseButtons.Right)
            {
                //context menu
            }
        }

        private void pbMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //get mouse xy etc
                PointF mouseLocation = new PointF(e.Location.X, e.Location.Y);

                //find node
                GameNode node = _viewer.FindNodeAtPoint(mouseLocation);
                if (node != _startNode)
                {
                    _endNode = node;

                    //addlink
                    //confirm first!!!!
                    if ((_startNode != null) && (_endNode != null))
                        if (MessageBox.Show("Create link?", "New Link", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _startNode.AddNeighbour(_endNode, true);

                        }

                    _startNode = null;
                    _endNode = null;

                    DisplayMap();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                //context menu
            }
        }

        private void pbMap_MouseClick(object sender, MouseEventArgs e)
        {
            //get mouse xy etc
            PointF mouseClick = new PointF(e.Location.X, e.Location.Y);

            if (e.Button == MouseButtons.Left)
            {
                //find node
                GameNode node = _viewer.FindNodeAtPoint(mouseClick);
                if (node != _selectedNode)
                {
                    _selectedNode = node;
                    DisplayMap();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                //context menu
                GameNode node = new GameNode();
                node.Id = World.GetNextNodeId();
                Vector3 gamePoint = _viewer.GetMapCoordsAtPoint(mouseClick);

                node.Coordinates = gamePoint;
                node.Name = node.Id.ToString();
                node.Zone = (Zone)zoneComboBox.SelectedItem;


                using (EditWaypointForm f = new EditWaypointForm(node))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        World.Data.Nodes.Add(node);
                        Zone currentZone = (Zone)zoneBindingSource.Current;
                        DisplayMap();
                    }
                    else
                    {
                        node.Zone.Waypoints.Remove(node);
                    }
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            waypointLinkBindingSource.DataSource = new List<WaypointLink>();
        }

        private void NodeVisualiser_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void NodeVisualiser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Delete node " + _selectedNode.Name, "Delete Node", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //delete the node
                    World.DeleteNode(_selectedNode);
                }
            }
        }
    }
}
