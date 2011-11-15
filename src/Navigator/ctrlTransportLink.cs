using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class ctrlTransportLink : UserControl
    {
        private TransportLink _link = null;

        public void Init(TransportLink link)
        {
            _link = link;
            transportLinkBindingSource.DataSource = _link;
            gameNodeBindingSource.DataSource = World.Data.Nodes;
        }

        public ctrlTransportLink()
        {
            InitializeComponent();
        }

        private void destinationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //open select node form
            using (dlgSelectGameNode dlg = new dlgSelectGameNode(_link.Destination))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _link.Destination = dlg.SelectedNode;
                }
            }
        }

        private void btnGetNode_Click(object sender, System.EventArgs e)
        {
            GameNode node = dlgSelectGameNode.SelectNode(null);
            _link.Destination = node;
            transportLinkBindingSource.ResetCurrentItem();
            //transportLinkBindingSource.DataSource = _link;
            //gameNodeBindingSource.DataSource = World.Data.Nodes;

        }
    }
}
