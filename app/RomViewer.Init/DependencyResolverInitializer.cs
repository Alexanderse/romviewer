using System.Web.Mvc;
using RomViewer.Core.Character;
using RomViewer.Core.Comms;
using RomViewer.Core.Items;
using RomViewer.Core.NPCs;
using RomViewer.Core.Quests;
using RomViewer.NHibernateProvider;
using NHibernate;
using RomViewer.Tasks;
using RomViewer.Tasks.Repositories;
using SharpLite.Domain.DataInterfaces;
using SharpLite.NHibernateProvider;
using StructureMap;

namespace RomViewer.Init
{
    public static class RomViewContainer
    {
        public static Container Container;

        public static void Initialize() {
            Container = new Container(x => {
                x.For<ISessionFactory>()
                    .Singleton()
                    .Use(() => NHibernateInitializer.Initialize().BuildSessionFactory());
                x.For<IEntityDuplicateChecker>().Use<EntityDuplicateChecker>();
                x.For(typeof(IRepository<>)).Use(typeof(Repository<>));
                x.For(typeof(IRepositoryWithTypedId<,>)).Use(typeof(RepositoryWithTypedId<,>));
                x.For(typeof(IItemRepository)).Use(typeof(ItemRepository));
                x.For(typeof(IQuestRepository)).Use(typeof(QuestRepository));
                x.For(typeof(INonPlayerEntityRepository)).Use(typeof(NonPlayerEntityRespository));
                x.For(typeof(ICharacterRepository)).Use(typeof(CharacterRepository));
                x.For(typeof(GoalSetter)).Use(typeof(GoalSetter));
                x.For(typeof(IRomMessageProcessor)).Use(typeof(RomMessageProcessor));
            });
        }
    }
}