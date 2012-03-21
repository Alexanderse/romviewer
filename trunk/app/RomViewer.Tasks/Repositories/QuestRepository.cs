using System;
using System.Collections.Generic;
using RomViewer.Core;
using RomViewer.Core.Quests;
using SharpLite.Domain.DataInterfaces;
using System.Linq;
using log4net;

namespace RomViewer.Tasks.Repositories
{
    public class QuestRepository: IQuestRepository
    {
        private readonly IRepository<QuestDefinition> _repository;

        public QuestRepository(IRepository<QuestDefinition> repository)
        {
            _repository = repository;
        }


        public IList<QuestDefinition> GetAll()
        {
            List<QuestDefinition> result = new List<QuestDefinition>();

            result.AddRange(_repository.GetAll());

            return result;
        }

        public QuestDefinition GetQuestDefinition(int questId)
        {
            return _repository.Get(questId);
        }

        public void Add(QuestDefinition quest)
        {
            _repository.SaveOrUpdate(quest);
        }

        public void Update(QuestDefinition quest)
        {
            _repository.SaveOrUpdate(quest);
        }

        public void Delete(int questId)
        {
            QuestDefinition quest = _repository.Get(questId);
            _repository.Delete(quest);
        }

        public IList<QuestDefinition> FindByLevelRange(int min, int max)
        {
            var source = _repository.GetAll();
            List<QuestDefinition> result = new List<QuestDefinition>(source.Where(definition => ((definition.MinLevel >= min) && (definition.MinLevel <= max)) ));
            return result;
        }

        public QuestDefinition GetByRomId(int id)
        {
            QuestDefinition result = null;
            try
            {
                result = _repository.GetAll().First(entity => entity.RomId == id);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger(typeof(QuestRepository)).Error(ex.ToString());
            }

            return result;
            
        }
    }
}