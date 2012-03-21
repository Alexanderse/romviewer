using System;
using System.Drawing;

namespace RomViewer.Domain
{
    //Issues: BindingType and ItemQuality seem to be bitmasks, so need to change to handle that at some point.
    public class Item
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public Color Color { get; set; }
        public int SlotNo { get; set; }
        public string ItemLink { get; set; }
        public double Durability { get; set; }
        public ItemQuality Quality { get; set; }
        public BindingType BindingDetails { get; set; }
        public int RequiredLevel { get; set; }
        public string ObjectType { get; set; }
        public string ObjectSubType { get; set; }
        public string ObjectSubSubType { get; set; }

        public Item(string source)
        {
            string[] detail = source.Split((char) 2);

            int idx = 0;
            Name = detail[idx]; idx++;
            Count = Convert.ToInt32(detail[idx]); idx++;
            //Color = ROMHelper.TranslateColorCode(detail[idx]); 
            //idx++;
            SlotNo = Convert.ToInt32(detail[idx]); idx++;
            ItemLink = detail[idx]; idx++;
            Durability = Convert.ToDouble(detail[idx]); idx++;
            Quality = ROMHelper.GetItemQuality(detail[idx]); idx++;
            BindingDetails = ROMHelper.GetBindingType(detail[idx]); idx++;
            RequiredLevel = Convert.ToInt32(detail[idx]); idx++;
            ObjectType = detail[idx]; idx++; 
            ObjectSubType = detail[idx]; idx++; 
            ObjectSubSubType = detail[idx];
        }
    }

    public enum BindingType
    {
        Pickup = 0,
        Unbound = 1,
        Bound1 = 2,
        Bound2 = 3,
        OnEquip = 4,
        ItemShop = 32,
        BT_33 = 33,
        BT_1026 = 1026,
        BT_1027 = 1027,
        BT_65537 = 65537,
        BT_65538 = 65538,
        BT_66562 = 66562
    }

    public enum ItemQuality
    {
        White = 0,
        Green = 1,
        Blue = 2,
        IQ_3 = 3,
        IQ_4 = 4,
        Gold = 5,
        Purple = 8,
        IQ_9 = 9,
        ItemShop = 16
    }
}