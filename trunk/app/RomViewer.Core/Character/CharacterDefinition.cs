using System.Collections.Generic;
using RomViewer.Core.Quests;
using SharpLite.Domain;

namespace RomViewer.Core.Character
{
    public class CharacterDefinition: Entity
    {
        public virtual string Name { get; set; }
        public virtual string Race { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual CharacterClass PrimaryClass { get; set; }
        public virtual int PrimaryLevel { get; set; }
        public virtual CharacterClass SecondayClass { get; set; }
        public virtual int SecondaryLevel { get; set; }
        public virtual CharacterClass ThirdClass { get; set; }
        public virtual int ThirdLevel { get; set; }

        public virtual IList<QuestDefinition> CompletedQuests { get; protected set; }

        public CharacterDefinition()
        {
            CompletedQuests = new List<QuestDefinition>();
        }
    }

    public enum CharacterClass
    {
        None=-1,
        GM=0,
        Warrior=2,
        Scout=3,
        Rogue=4,
        Mage=5,
        Priest=6,
        Knight=7,
        Warden=8,
        Druid=9
    }

    public enum Sex
    {
        None,
        Male,
        Female
    }
}