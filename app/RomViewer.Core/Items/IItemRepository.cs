using System.Collections.Generic;

namespace RomViewer.Core.Items
{
    public interface IItemRepository
    {
        IList<ItemDefinition> GetAll();
        ItemDefinition Get(int itemId);
        ItemDefinition GetByRomId(int id);
        ItemDefinition Get(string name);

        void AddItem(ItemDefinition item);
        void UpdateItem(ItemDefinition item);
        void DeleteItem(ItemDefinition item);
        void DeleteItem(int itemId);
        void DeleteItemByRomId(int Id);
    }
}