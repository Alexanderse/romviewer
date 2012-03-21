using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class ctrlMovementLink : UserControl
    {
        private GameNodeLink _nodeLink;
 
        public ctrlMovementLink()
        {
            InitializeComponent();
        }

        public void Init(GameNodeLink nodeLink)
        {
            _nodeLink = nodeLink;
            gameNodeLinkBindingSource.DataSource = nodeLink;
        }

    }
}
