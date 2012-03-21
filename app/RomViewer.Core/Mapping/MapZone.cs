using System.Collections.Generic;
using SharpLite.Domain;

namespace RomViewer.Core.Mapping
{
    public class MapZone: Entity
    {
        public virtual int RomId { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsPublic { get; set; }

        public virtual IList<MapPoint> Points { get; protected set; }

        public MapZone()
        {
            Points = new List<MapPoint>();
        }
    }
}