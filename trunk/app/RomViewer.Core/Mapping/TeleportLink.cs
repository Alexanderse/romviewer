using RomViewer.Core.NPCs;
using SharpLite.Domain;

namespace RomViewer.Core.Mapping
{
    public class TeleportLink : Entity
    {
        public virtual NonPlayerEntity Start { get; set; }
        public virtual MapPoint End { get; set; }
        public virtual LinkType LinkType { get; set; }
        public virtual string Script { get; set; }
    }
}