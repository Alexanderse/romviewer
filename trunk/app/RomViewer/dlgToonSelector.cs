using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomViewer
{
    public partial class dlgToonSelector : Form
    {
        public ToonSettings Selected = null;

        public dlgToonSelector(List<ToonSettings> toons)
        {
            InitializeComponent();

            cbToon.Items.AddRange(toons.ToArray());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Selected = (ToonSettings) cbToon.SelectedItem;
        }

        private void cbToon_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem != null)
            {
                e.Value = ((ToonSettings)e.ListItem).name;
            }
            else e.Value = "";
        }

        public static ToonSettings SelectToon(List<ToonSettings> toons)
        {
            using (dlgToonSelector dlg = new dlgToonSelector(toons))
            {
                if (dlg.ShowDialog() == DialogResult.OK) return dlg.Selected;
                return null;
            }
        }
    }
}
