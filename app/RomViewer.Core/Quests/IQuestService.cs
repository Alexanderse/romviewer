using System.Collections.Generic;

namespace RomViewer.Core.Quests
{
    public interface IQuestService
    {
        IList<QuestDefinition> GetAll();
        IList<QuestDefinition> GetAllInZone(int zoneId);
        QuestDefinition GetQuestDefinition(int questId);

    }
}