using System;
using System.Collections.Generic;
using RomViewer.Core.Mapping;
using SharpLite.Domain;

namespace RomViewer.Core.NPCs
{
    public class NonPlayerEntity: Entity
    {
        public virtual int RomId { get; set; }
        public virtual int UniqueId { get; set; }
        public virtual string Name { get; set; }
        public virtual int ZoneId { get; set; }
        public virtual double X { get; set; }
        public virtual double Y { get; set; }
        public virtual double Z { get; set; }
        public virtual IList<TeleportLink> Links { get; protected set; } 

        public virtual EntityTypes EntityTypes { get; set; }

        public NonPlayerEntity()
        {
            Links = new List<TeleportLink>();
        }

        public virtual string ToDelimitedString(int delimiter)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}", (char)delimiter, RomId, UniqueId, Name, ZoneId, X, Y, Z, (byte)EntityTypes);
        }

        public static string GetNullDefinitionString(int delimiter)
        {
            return string.Format("{0}{0}{0}{0}{0}{0}{0}", (char)delimiter);
        }

        public NonPlayerEntity(string source, int delimiter)
        {
            char delim = (char)delimiter;
            string[] detail = source.Split(delim);
            int i = 0;
            RomId = Convert.ToInt32(detail[i]); i++;
            UniqueId = Convert.ToInt32(detail[i]); i++;
            Name = detail[i]; i++;
            ZoneId = Convert.ToInt32(detail[i]); i++;
            X = Convert.ToDouble(detail[i]); i++;
            Y = Convert.ToDouble(detail[i]); i++;
            Z = Convert.ToDouble(detail[i]); i++;

            byte et = Convert.ToByte(detail[i]); i++;
            EntityTypes = (EntityTypes) et;
        }
    }
}