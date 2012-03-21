using System.Collections.Generic;

namespace RomViewer.Core.NPCs
{
    public interface INonPlayerEntityRepository
    {
        IList<NonPlayerEntity> GetAll();
        NonPlayerEntity Get(int entityId);
        NonPlayerEntity GetByRomId(int romId, int uniqueId);

        void Add(NonPlayerEntity entity);
        void Update(NonPlayerEntity entity);
        void Delete(int entityId);         
    }
}