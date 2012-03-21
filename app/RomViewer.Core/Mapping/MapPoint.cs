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
    }
}