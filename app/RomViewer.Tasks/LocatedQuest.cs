using System.Collections;
using RomViewer.Core;
using RomViewer.Core.NPCs;
using RomViewer.Core.Quests;

namespace RomViewer.Tasks
{
    public class LocatedQuest
    {
        public QuestDefinition Quest { get; set; }
        public Vector3 Location { get; set; }
        public double Distance { get; set; }
        public NonPlayerEntity Starter { get; set; }
    }
    class LocatedQuestComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            LocatedQuest q1 = (LocatedQuest)x;
            LocatedQuest q2 = (LocatedQuest)y;

            return (int)(q1.Distance - q2.Distance);
        }
    }
}