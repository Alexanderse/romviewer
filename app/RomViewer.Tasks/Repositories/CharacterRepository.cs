using System.Collections.Generic;
using System.Linq;
using RomViewer.Core.Character;
using SharpLite.Domain.DataInterfaces;

namespace RomViewer.Tasks.Repositories
{
    public class CharacterRepository: ICharacterRepository
    {
        private readonly IRepository<CharacterDefinition> _repository;

        public CharacterRepository(IRepository<CharacterDefinition> repository)
        {
            _repository = repository;
        }

        public IList<CharacterDefinition> GetAll()
        {
            List<CharacterDefinition> result = new List<CharacterDefinition>();

            result.AddRange(_repository.GetAll());

            return result;
        }

        public CharacterDefinition Get(int id)
        {
            return _repository.Get(id);
        }

        public void Add(CharacterDefinition characterDefinition)
        {
            _repository.SaveOrUpdate(characterDefinition);
        }

        public void Update(CharacterDefinition characterDefinition)
        {
            _repository.SaveOrUpdate(characterDefinition);
        }

        public void Delete(int characterId)
        {
            CharacterDefinition characterDefinition = _repository.Get(characterId);
            _repository.Delete(characterDefinition);
        }

        public CharacterDefinition FindByName(string name)
        {
            return _repository.GetAll().FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
}