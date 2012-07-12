using System.Collections.Generic;
using System.Linq;
using RomViewer.Core.NPCs;
using SharpLite.Domain.DataInterfaces;

namespace RomViewer.Tasks.Repositories
{
    public class NonPlayerEntityRespository : INonPlayerEntityRepository
    {
        private readonly IRepository<NonPlayerEntity> _repository;

        public NonPlayerEntityRespository(IRepository<NonPlayerEntity> repository)
        {
            _repository = repository;
        }

        public IList<NonPlayerEntity> GetAll()
        {
            return new List<NonPlayerEntity>(_repository.GetAll());
        }

        public NonPlayerEntity Get(int entityId)
        {
            return _repository.Get(entityId);
        }

        public NonPlayerEntity GetByRomId(int romId, int uniqueId)
        {
            NonPlayerEntity result = null;
            try
            {
                result = _repository.GetAll().First(entity => ((entity.RomId == romId) && ((entity.UniqueId == uniqueId))));
            }
            catch
            {
            }

            return result;
        }

        public IEnumerable<NonPlayerEntity> GetByRomId(int romId)
        {
            try
            {
                return _repository.GetAll().Where(entity => (entity.RomId == romId));
            }catch{}

            return new List<NonPlayerEntity>();
        }

        public void Add(NonPlayerEntity entity)
        {
            _repository.SaveOrUpdate(entity);
        }

        public void Update(NonPlayerEntity entity)
        {
            _repository.SaveOrUpdate(entity);
        }

        public void Delete(int entityId)
        {
            NonPlayerEntity entity = Get(entityId);
            _repository.Delete(entity);
        }
    }
}