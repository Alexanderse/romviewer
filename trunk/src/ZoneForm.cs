using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer
{
    public partial class ZoneForm : Form
    {
        public ZoneForm()
        {
            InitializeComponent();
        }

        public void SetZone(Zone zone)
        {
            zoneBindingSource.DataSource = zone;
        }

        public static bool EditZone(Zone zone)
        {
            ZoneForm z = new ZoneForm();
            z.SetZone(zone);
            return (z.ShowDialog() == DialogResult.OK);
        }
    }
}
