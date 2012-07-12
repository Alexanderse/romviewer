using System;
using System.Collections.Generic;

namespace RomViewer
{
    [Serializable]
    public class ToonSettings
    {
        public string name;
        public int msgPort;
        public int cmdPort;
        public bool lootActive;
        public List<string> lootIncludes = new List<string>();
        public List<string> lootExcludes = new List<string>();
        public string quality;
        public List<string>  targets = new List<string>();
    }

}