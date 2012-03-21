using System.Collections.Generic;
using RomViewer.Core.NPCs;

namespace RomViewer.Core.Quests
{
    public interface IQuestRepository
    {
        IList<QuestDefinition> GetAll();
        QuestDefinition GetQuestDefinition(int questId);
        IList<QuestDefinition> FindByLevelRange(int min, int max);
        QuestDefinition GetByRomId(int id);

        void Add(QuestDefinition quest);
        void Update(QuestDefinition quest);
        void Delete(int questId);
    }
}