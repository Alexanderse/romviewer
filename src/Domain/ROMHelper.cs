using System;
using System.Drawing;

namespace RomViewer.Domain
{
    public static class ROMHelper
    {
        public static Color TranslateColorCode(string source)
        {
            return Color.White;
            //return Color.FromArgb(Convert.ToInt32(source));
        }

        public static ItemQuality GetItemQuality(string source)
        {
            int qual = Convert.ToInt32(source);
            return GetItemQuality(qual);
        }

        public static ItemQuality GetItemQuality(int quality)
        {
            return (ItemQuality) quality;
        }

        public static BindingType GetBindingType(string source)
        {
            return GetBindingType(Convert.ToInt32(source));
        }

        public static BindingType GetBindingType(int bindingType)
        {
            return (BindingType) bindingType;
        }
    }
}