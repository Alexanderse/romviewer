using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class dlgSelectGameNode : Form
    {
        private GameNode _node;

        public dlgSelectGameNode()
        {
            InitializeComponent();
        }

        public dlgSelectGameNode(GameNode node): this()
        {
            _node = node;
            ctrlGameNodeSelector1.Init(World.Data.Zones, (node == null) ? null : node.Zone, node);
        }

        public dlgSelectGameNode(Zone zone)
            : this()
        {
            ctrlGameNodeSelector1.Init(World.Data.Zones, zone, null);
        }

        public GameNode SelectedNode { get { return ctrlGameNodeSelector1.GetSelectedNode(); } }

        public static GameNode SelectNode(Zone zone)
        {
            using (dlgSelectGameNode dlg = new dlgSelectGameNode(zone))
            {
                if (dlg.ShowDialog() == DialogResult.OK) return dlg.SelectedNode;
            }

            return null;
        }

        private void ctrlGameNodeSelector1_OnNodeSelected(object sender, GameNode node)
        {
            btnOK.PerformClick();
        }
    }
}
