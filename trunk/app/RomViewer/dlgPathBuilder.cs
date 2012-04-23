using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using RomViewer.Model;
using RomViewer.Navigator;

namespace RomViewer
{
    public partial class dlgPathBuilder : Form
    {
        private GameNode _startNode;
        private List<PathWaypoint> _path = new List<PathWaypoint>();

        public dlgPathBuilder()
        {
            InitializeComponent();
            pathWaypointBindingSource.DataSource = _path;
        }

        private void btnStartNode_Click(object sender, EventArgs e)
        {
            _startNode = dlgSelectGameNode.SelectNode(null);
            if (_startNode != null) 
                btnStartNode.Text = _startNode.ToString();
            else
            {
                btnStartNode.Text = "Select a start node";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PathWaypoint point = new PathWaypoint();
            point.Coordinates = new Vector3(World.PlayerPos);
            _path.Add(point);
            pathWaypointBindingSource.ResetBindings(false);
        }

        private void dlgPathBuilder_Shown(object sender, EventArgs e)
        {
            if (_startNode == null)
            {
                _startNode = World.FindNearestNode(World.PlayerPos);
                btnStartNode.Text = _startNode.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //build the xml file
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><waypoints>");
            for (int i = 0; i < _path.Count; i++)
            {
                PathWaypoint p = _path[i];

                string line = "";
                string tag = null;
                if (!String.IsNullOrEmpty(p.Tag)) tag = string.Format(" tag=\"{0}\"", p.Tag);
                string movement = null;
                if (p.MovementType != MovementType.None) movement = string.Format(" type=\"{0}\"", p.MovementType.ToString().ToUpper());

                line = string.Format("	<!-- #{0,4} --><waypoint x=\"{1}\" z=\"{2}\" y=\"{3}\"{5}{6}>{4}</waypoint>", i, p.Coordinates.X, p.Coordinates.Z, p.Coordinates.Y, p.Script, tag ?? "", movement ?? "");
                
                sb.AppendLine(line);
            }

            sb.AppendLine("</waypoints>");

            string result = sb.ToString();
            string filename = Path.Combine(Path.Combine(Path.GetDirectoryName(ToonController._settings.MicroMacroPath), "scripts\\rom\\waypoints\\_newPath.xml"));

            File.WriteAllText(filename, result);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string filename = "";

            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            filename = dlgOpen.FileName;

            _path.Clear();
            
            if (File.Exists(filename))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                XmlNodeList list = doc.GetElementsByTagName("waypoint");
                for (int i = 0; i < list.Count; i++)
                {
                    PathWaypoint p = new PathWaypoint();

                    XmlNode node = list[i];

                    double x = 0,y = 0,z = 0;
                   
                    if (node.Attributes["x"] != null) x = Convert.ToDouble(node.Attributes["x"].Value);
                    if (node.Attributes["y"] != null) y = Convert.ToDouble(node.Attributes["y"].Value);
                    if (node.Attributes["z"] != null) z = Convert.ToDouble(node.Attributes["z"].Value);

                    if (node.Attributes["tag"] != null) p.Tag = node.Attributes["tag"].Value.ToString();
                    string movement = "None";
                    if (node.Attributes["type"] != null) movement = node.Attributes["type"].Value.ToString();
                    p.MovementType = (MovementType) Enum.Parse(typeof (MovementType), movement, true);

                    p.Coordinates = new Vector3(x,y,z);

                    if (node.InnerText != null) p.Script = node.InnerText;

                    _path.Add(p);
                }
            }

            pathWaypointBindingSource.ResetBindings(false);
        }
    }

    public class PathWaypoint
    {
        private Vector3 _coordinates = new Vector3();
        private MovementType _movementType = MovementType.None;
        private string _tag = "";
        private string _script = "";

        public Vector3 Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }

        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public string Script
        {
            get { return _script; }
            set { _script = value; }
        }

        public MovementType MovementType
        {
            get { return _movementType; }
            set { _movementType = value; }
        }
    }

    public enum MovementType
    {
        None,
        Run,
        Travel
    }
}
