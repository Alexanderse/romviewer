using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer
{
    public delegate void OnItemEvent(string item);

    public partial class ListManager : UserControl
    {
        public event OnItemEvent OnAddItem = null;
        public event OnItemEvent OnRemoveItem = null;

        public ListManager()
        {
            InitializeComponent();

        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            lbItems.Items.Add(tebItemName.Text);
            if (OnAddItem != null)
            {
                OnAddItem(tebItemName.Text);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string item = lbItems.SelectedItem.ToString();
            
            if (OnRemoveItem != null)
            {
                OnRemoveItem(item);
            }

            lbItems.Items.Remove(lbItems.SelectedItem);
        }
    }
}
