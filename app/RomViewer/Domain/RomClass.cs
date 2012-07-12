using System;

namespace RomViewer.Domain
{
    public enum RomClass
    {
        NONE = -1,
        GM = 1,
        WARRIOR = 2,
        SCOUT = 3,
        ROGUE = 4,
        MAGE = 5,
        PRIEST = 6,
        KNIGHT = 7,
        WARDEN = 8,
        DRUID = 9
    }

    public static class RomClassHelper
    {
        public static string GetPrefixChar(int romClass)
        {
            RomClass rClass = (RomClass) romClass;
            string result = rClass.ToString().Substring(0, 1);
            if (rClass == RomClass.WARDEN) result = "WD";

            return result;
        }

        public static string GetClassName(int romClass)
        {
            switch ((RomClass)romClass)
            {
                case RomClass.NONE: return "";
                case RomClass.GM: return "GM";
                case RomClass.WARRIOR: return "Warrior";
                case RomClass.SCOUT: return "Scout";
                case RomClass.ROGUE: return "Rogue";
                case RomClass.MAGE: return "Mage";
                case RomClass.PRIEST: return "Priest";
                case RomClass.KNIGHT: return "Knight";
                case RomClass.WARDEN: return "Warden";
                case RomClass.DRUID: return "Druid";
                default:
                    throw new ArgumentOutOfRangeException("romClass");
            }
        }
    }

    
}