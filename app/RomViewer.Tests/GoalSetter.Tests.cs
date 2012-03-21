using NHibernate;
using NHibernate.Context;
using NUnit.Framework;
using RomViewer.Core;
using RomViewer.Core.Character;
using RomViewer.Init;
using RomViewer.Tasks;

namespace DefaultNamespace
{
    [TestFixture]
    public class GoalSetterTest
    {
        [SetUp]
        public virtual void SetUp()
        {
            //_configuration = NHibernateInitializer.Initialize();
            //_sessionFactory = _configuration.BuildSessionFactory();
            RomViewContainer.Initialize();
        }

        [Test]
        public void TestFindQuest()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            //ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);
            GoalSetter gs = RomViewContainer.Container.GetInstance<GoalSetter>();

            ICharacterRepository charRep = RomViewContainer.Container.GetInstance<ICharacterRepository>();
            CharacterDefinition toon = charRep.FindByName("Remedial");
            gs.Character = toon;
            gs.State = new CharacterState();
            gs.State.Location = new Vector3(6130, 137, 23169);

            var a = gs.DetermineNearestQuest();
            CallSessionContext.Unbind(fac);

        }
    }
}