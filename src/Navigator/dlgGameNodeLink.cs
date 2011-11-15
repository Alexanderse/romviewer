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
    public partial class dlgGameNodeLink : Form
    {
        public dlgGameNodeLink(GameNodeLink link)
        {
            InitializeComponent();
            ctrlMovementLink1.Init(link);
        }

        public static bool EditLinkScript(GameNodeLink link)
        {
            dlgGameNodeLink f = new dlgGameNodeLink(link);
            return (f.ShowDialog() == DialogResult.OK);
        }
    }
}
