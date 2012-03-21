using System.Collections.Generic;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public delegate void GameNodeEvent(object sender, GameNode node);

    public partial class ctrlGameNodeSelector : UserControl
    {
        public event GameNodeEvent OnNodeSelected;

        public void DoOnNodeSelected(GameNode node)
        {
            GameNodeEvent handler = OnNodeSelected;
            if (handler != null) handler(this, node);
        }

        public ctrlGameNodeSelector()
        {
            InitializeComponent();
        }

        public void Init(List<Zone> zones, Zone selectedZone, GameNode selectedNode)
        {
            zoneBindingSource.DataSource = zones;

            if (selectedZone != null) zoneBindingSource.Position = zoneComboBox.Items.IndexOf(selectedZone);
            if (selectedNode != null) waypointsBindingSource.Position = waypointsBindingSource.Find("Id", selectedNode.Id);
        }

        public GameNode GetSelectedNode()
        {
            return (GameNode) waypointsBindingSource.Current;
        }

        private void waypointsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (waypointsBindingSource.Current != null)
            {
                DoOnNodeSelected((GameNode)waypointsBindingSource.Current);
            }
        }
    }
}
