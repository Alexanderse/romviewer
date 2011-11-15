using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class NodeManager : Form
    {
        public NodeManager()
        {
            InitializeComponent();
            RefreshData();
        }

        private Dictionary<TreeNode, GameNode> _map = new Dictionary<TreeNode, GameNode>();
        private GameNode _node;
        private bool _changingNode;
        private Zone _currentZone;
        private GameNode _currentNode;
        public static NodeManager Manager;

        public void RefreshData()
        {
                gameNodeBindingSource.DataSource = World.Data.Nodes;
                zoneBindingSource.DataSource = World.Data.Zones;
        }

        private void gameNodeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            _changingNode = true;
            try
            {
                GameNode node = (GameNode) gameNodeBindingSource.Current;

                tbX.Text = node.Coordinates.X.ToString();
                tbY.Text = node.Coordinates.Y.ToString();
                tbZ.Text = node.Coordinates.Z.ToString();

                _currentNode = node;
                _currentZone = node.Zone;

                if (node.Zone != null)
                    zoneComboBox.SelectedItem = _currentZone;
                else
                    zoneComboBox.SelectedIndex = -1;
            } finally
            {
                _changingNode = false;
            }
        }

        private void gameObjectsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            GameObject obj = new GameObject();
            obj.Id = World.GetNextObjectId();

            if (EditGameObject.PerformEdit(obj)) 
                e.NewObject = obj;
        }

        private void neighboursBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            GameNode node = dlgSelectGameNode.SelectNode(_currentZone);

            if (node != null) e.NewObject = node;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            World.SaveToDirectory(Path.GetFullPath("."));
        }

        private void visualiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void gameObjectsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GameObject o = (GameObject)gameObjectsBindingSource.Current;
            if (o == null) return;

            EditGameObject.PerformEdit(o);

        }

        private void zoneComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_currentNode != null)
            {
                Zone zone = (Zone) zoneComboBox.SelectedItem;
                if (_currentZone != null) _currentZone.Waypoints.Remove(_currentNode);

                if (zone != null) zone.Waypoints.Add(_currentNode);

                _currentNode.Zone = zone;
                gameNodeBindingSource.ResetBindings(false);
                ;
            }
        }

        private void NodeManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            NodeManager.Manager = null;
        }

        private void gameNodeLinksBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            GameNode node = dlgSelectGameNode.SelectNode(_currentZone);
            GameNodeLink link = new GameNodeLink(node, "");

            GameNode source = (GameNode)gameNodeBindingSource.Current;
            source.GameNodeLinks.Add(link);

            if (link != null) e.NewObject = link;
        }

        private void gameNodeDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GameNodeLink link = (GameNodeLink)gameNodeLinksBindingSource.Current;

            dlgGameNodeLink.EditLinkScript(link);
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {
            if (_changingNode) return;
            Vector3 newV = new Vector3(_currentNode.Coordinates);
            try { newV.X = Convert.ToInt32(((TextBox)sender).Text); }catch { }

            _currentNode.Coordinates = newV;
        }

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            if (_changingNode) return;
            Vector3 newV = new Vector3(_currentNode.Coordinates);
            try { newV.Y = Convert.ToInt32(((TextBox)sender).Text); }catch { }

            _currentNode.Coordinates = newV;
        }

        private void tbZ_TextChanged(object sender, EventArgs e)
        {
            if (_changingNode) return;
            Vector3 newV = new Vector3(_currentNode.Coordinates);
            try { newV.Z = Convert.ToInt32(((TextBox)sender).Text); }catch { }

            _currentNode.Coordinates = newV;
        }



    }
}
