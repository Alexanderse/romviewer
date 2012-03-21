using System;
using System.Collections.Generic;
using System.Linq;
using RomViewer.Core.Items;
using SharpLite.Domain.DataInterfaces;

namespace RomViewer.Tasks.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IRepository<ItemDefinition> _repository;

        public ItemRepository(IRepository<ItemDefinition> repository)
        {
            _repository = repository;
        }

        public IList<ItemDefinition> GetAll()
        {
            return new List<ItemDefinition>(_repository.GetAll());
        }

        public ItemDefinition Get(int itemId)
        {
            return _repository.Get(itemId);
        }

        public ItemDefinition GetByRomId(int id)
        {
            ItemDefinition result = null;
            try
            {
                result = _repository.GetAll().First(definition => definition.RomId == id);
            } catch
            {
            }

            return result;
        }

        public ItemDefinition Get(string name)
        {
            return _repository.GetAll().FirstOrDefault(definition => definition.Name.ToLower() == name);
        }

        public void AddItem(ItemDefinition item)
        {
            _repository.SaveOrUpdate(item);
        }

        public void UpdateItem(ItemDefinition item)
        {
            _repository.SaveOrUpdate(item);
        }

        public void DeleteItem(ItemDefinition item)
        {
            _repository.Delete(item);
        }

        public void DeleteItem(int itemId)
        {
            ItemDefinition item = _repository.Get(itemId);
            _repository.Delete(item);
        }

        public void DeleteItemByRomId(int Id)
        {
            ItemDefinition item = GetByRomId(Id);
            if (item != null) _repository.Delete(item);
        }
    }
}