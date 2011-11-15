using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class EditTransportLinkForm : Form
    {
        private TransportLink _link;

        public EditTransportLinkForm(TransportLink link) : this()
        {
            _link = link;
            tlLink.Init(_link);
        }

        public EditTransportLinkForm()
        {
            InitializeComponent();
        }

        private void tlLink_Load(object sender, System.EventArgs e)
        {

        }

        public static bool EditLink(TransportLink link)
        {
            EditTransportLinkForm dlg = new EditTransportLinkForm(link);

            return (dlg.ShowDialog() == DialogResult.OK);
        }
    }
}
