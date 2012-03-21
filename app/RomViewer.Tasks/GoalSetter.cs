using System.Collections.Generic;
using System.Linq;
using RomViewer.Core;
using RomViewer.Core.Character;
using RomViewer.Core.Items;
using RomViewer.Core.NPCs;
using RomViewer.Core.Quests;

namespace RomViewer.Tasks
{
    /// <summary>
    /// Determines the best current goal for the toon
    /// </summary>
    public class GoalSetter
    {
        private CharacterDefinition _character;
        private IQuestRepository _questRep;
        private INonPlayerEntityRepository _npeRep;
        private IItemRepository _itemRep;
        private CharacterState _state;

        public CharacterDefinition Character
        {
            get { return _character; }
            set { _character = value; }
        }

        public CharacterState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public GoalSetter(IQuestRepository questRep, INonPlayerEntityRepository npeRep, IItemRepository itemRep)
        {
            _questRep = questRep;
            _npeRep = npeRep;
            _itemRep = itemRep;
        }

        public LocatedQuest DetermineNearestQuest()
        {
            return _determineBestNearestQuestToDo();
        }

        private LocatedQuest _determineBestNearestQuestToDo()
        {
            Dictionary<int, NonPlayerEntity> npcs = new Dictionary<int, NonPlayerEntity>();
            List<QuestDefinition> quests = new List<QuestDefinition>(_questRep.FindByLevelRange(_character.PrimaryLevel, _character.PrimaryLevel + 1));
            //determine distance from current location
            SortableList locatedQuests = new SortableList(new LocatedQuestComparer());
            locatedQuests.KeepSorted = true;
            locatedQuests.AddDuplicates = true;
            foreach (QuestDefinition quest in quests)
            {
                if (_character.CompletedQuests.Count(q => q.Id == quest.Id) > 0) continue;

                if (quest.StarterId > 0)
                {
                    if (!npcs.ContainsKey(quest.StarterId))
                    {
                        NonPlayerEntity npc = _npeRep.GetAll().FirstOrDefault(npe => npe.RomId == quest.StarterId);
                        
                        if (npc != null) npcs.Add(quest.StarterId, npc);
                    }
                    if (npcs.ContainsKey(quest.StarterId))
                    {
                        NonPlayerEntity npc = npcs[quest.StarterId];
                        Vector3 loc = new Vector3(npc.X, npc.Y, npc.Z);
                        LocatedQuest lQ = new LocatedQuest()
                                              {
                                                  Location = loc,
                                                  Quest = quest,
                                                  Starter = npc,
                                                  Distance = _state.Location.Distance(loc)
                                              };
                        locatedQuests.Add(lQ); ////////store quest, item +locations.......
                    }
                }
            }

            if (locatedQuests.Count > 0) return (LocatedQuest) locatedQuests[0];
            return null;
        }
    }
}