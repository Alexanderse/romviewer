using System;
using System.Collections.Generic;
using SharpLite.Domain;

namespace RomViewer.Core.Mapping
{
    public class MapPoint: Entity
    {
        public virtual double X { get; set; }
        public virtual double Y { get; set; }
        public virtual double Z { get; set; }
        public virtual MapZone MapZone { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<MapLink> Links { get; protected set; }

        public MapPoint()
        {
            Links = new List<MapLink>();
        }

        public virtual string ToRomBotXML(int num, string script)
        {
            string s = "";
            if ((script != null) && (script.Length > 0))
            {
                s = Environment.NewLine + script + Environment.NewLine;
            }
            string result = string.Format("	<!-- #  {0:00} --><waypoint x=\"{1}\" z=\"{2}\"  type=\"RUN\">{3}</waypoint>", num, X, Z, s);
            return result;
        }
        
    }
}