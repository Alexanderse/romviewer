using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NUnit.Framework;
using RomViewer.Core.Character;
using RomViewer.Core.Quests;
using RomViewer.Init;
using SharpLite.Domain.DataInterfaces;
using SharpLite.NHibernateProvider;

namespace Focus.Tests.Tasks
{
    [TestFixture]
    public class CharacterTests
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        [SetUp]
        public virtual void SetUp()
        {
            //_configuration = NHibernateInitializer.Initialize();
            //_sessionFactory = _configuration.BuildSessionFactory();
            RomViewContainer.Initialize();
        }
        [Test]
        public void TestCanAddItem()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                IRepository<CharacterDefinition> rep = RomViewContainer.Container.GetInstance<IRepository<CharacterDefinition>>();

                CharacterDefinition def = new CharacterDefinition
                {
                    Name = "Remedial", Race = "Human"
                };

                IRepository<QuestDefinition> qRep = RomViewContainer.Container.GetInstance<IRepository<QuestDefinition>>();
                QuestDefinition dummy = new QuestDefinition() {RomId = -1, Name = "TestQuest"};
                session.Save(dummy);

                def.CompletedQuests.Add(dummy);
                session.Save(def);

            }
            finally
            {
                tx.Rollback();
                session.Close();
            }
        }

        [Test]
        public void TestCanUpdateRemedial()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                ICharacterRepository rep = RomViewContainer.Container.GetInstance<ICharacterRepository>();

                CharacterDefinition def = rep.FindByName("Remedial");
                def.PrimaryClass = CharacterClass.Scout;
                def.PrimaryLevel = 56;
                def.SecondaryLevel = 55;
                def.SecondayClass = CharacterClass.Mage;
                def.Race = "Human";
                def.Sex = Sex.Female;

                rep.Update(def);
                tx.Commit();
                
            }
            finally
            {
                session.Close();
            }
        }
    }
}