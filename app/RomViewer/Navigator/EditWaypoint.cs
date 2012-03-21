using System;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class EditWaypointForm : Form
    {
        public GameNode Node = null;
        private Zone _currentZone;
        private bool _initializing = true;

        public EditWaypointForm(GameNode node): this()
        {
            Node = node;
            lblId.Text = Node.Id.ToString();
            tbName.Text = Node.Name;
            tbX.Text = node.Coordinates.X.ToString();
            tbY.Text = node.Coordinates.Y.ToString();
            tbZ.Text = node.Coordinates.Z.ToString();

            if (node.Zone != null) zoneComboBox.SelectedItem = node.Zone;
        }

        public EditWaypointForm()
        {
            InitializeComponent();

            _initializing = true;
            try { zoneBindingSource.DataSource = World.Data.Zones; }
            finally { _initializing = false; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Node.Id = Convert.ToInt32(lblId.Text);
            Node.Name = tbName.Text;
            Vector3 coord = Node.Coordinates;
            coord.X = Convert.ToDouble(tbX.Text);
            coord.Y = Convert.ToDouble(tbY.Text);
            coord.Z = Convert.ToDouble(tbZ.Text);

            Node.Zone = (Zone) zoneComboBox.SelectedItem;
            Node.Zone.Waypoints.Add(Node);
        }

        private void zoneBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }
    }
}
