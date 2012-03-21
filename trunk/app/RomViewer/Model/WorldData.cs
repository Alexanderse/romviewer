using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RomViewer.Model
{
    [DataContract]
    public class WorldData
    {
        public List<GameNode> Nodes = new List<GameNode>();
        [DataMember]
        public List<Zone> Zones = new List<Zone>();
        [DataMember]
        public List<GameObject> RomObjects = new List<GameObject>();

    }
}