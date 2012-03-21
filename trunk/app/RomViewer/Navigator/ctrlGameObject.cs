using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class ctrlGameObject : UserControl
    {
        public ctrlGameObject()
        {
            InitializeComponent();
        }

        public void SetBinding(GameObject o)
        {
            bsObject.DataSource = o;
            gameNodeBindingSource1.DataSource = World.Data.Nodes;
        }


        private void bsObject_CurrentChanged(object sender, EventArgs e)
        {
            GameObject obj = (GameObject)bsObject.Current;

            xbAuctionHouse.Checked = (obj.ObjectTypes.Contains(GameObjectType.AuctionHouse));
            xbMailBox.Checked = (obj.ObjectTypes.Contains(GameObjectType.Mailbox));
            xbVendorGeneral.Checked = (obj.ObjectTypes.Contains(GameObjectType.VendorGeneral));
            xbVendorPet.Checked = (obj.ObjectTypes.Contains(GameObjectType.VendorPet));
            xbHouse.Checked = (obj.ObjectTypes.Contains(GameObjectType.Housemaid));

            //bsTransportLinks.DataSource = obj.TransportLinks;
        }

        private void xbVendorGeneral_CheckedChanged(object sender, EventArgs e)
        {
            List<GameObjectType> upd = new List<GameObjectType>();
            if (xbAuctionHouse.Checked) upd.Add(GameObjectType.AuctionHouse);
            if (xbMailBox.Checked) upd.Add(GameObjectType.Mailbox);
            if (xbVendorGeneral.Checked) upd.Add(GameObjectType.VendorGeneral);
            if (xbVendorPet.Checked) upd.Add(GameObjectType.VendorPet);
            if (xbHouse.Checked) upd.Add(GameObjectType.Housemaid);

            GameObject obj = (GameObject)bsObject.Current;
            obj.ObjectTypes.Clear();
            obj.ObjectTypes.AddRange(upd);
        }

        private void transportLinksBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TransportLink link = new TransportLink();

            if (EditTransportLinkForm.EditLink(link))
                e.NewObject = link;
        }


        private void transportLinksDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TransportLink link = (TransportLink) transportLinksBindingSource.Current;

            if (link != null)
            {
                EditTransportLinkForm.EditLink(link);
            }
        }
    }
}
