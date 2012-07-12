using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RomViewer.Core.Mapping;

namespace GraphViewer
{
    public partial class dlgLoadMap : Form
    {
        private MapZone[] _zones = null;

        public dlgLoadMap(MapZone[] zones)
        {
            _zones = zones;
            InitializeComponent();
        }

        private void dlgLoadMap_Load(object sender, EventArgs e)
        {
                cbZones.Items.AddRange(_zones);
        }

        public List<MapZone> GetZones()
        {
            return cbZones.CheckedItems.OfType<MapZone>().ToList();
        }

        private void cbZones_Format(object sender, ListControlConvertEventArgs e)
        {
            MapZone zone = (MapZone) e.ListItem;
            if (zone != null)
            {
                e.Value = zone.Name;
            }
            else e.Value = "";
        }
    }
}
