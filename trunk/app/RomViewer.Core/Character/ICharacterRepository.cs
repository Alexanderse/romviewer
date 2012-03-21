using System.Collections.Generic;

namespace RomViewer.Core.Character
{
    public interface ICharacterRepository
    {
        IList<CharacterDefinition> GetAll();
        CharacterDefinition Get(int characterId);
        CharacterDefinition FindByName(string name);

        void Add(CharacterDefinition characterDefinition);
        void Update(CharacterDefinition characterDefinition);
        void Delete(int questId);         
    }
}