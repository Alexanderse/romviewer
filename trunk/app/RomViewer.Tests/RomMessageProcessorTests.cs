using System;
using NHibernate;
using NUnit.Framework;
using RomViewer.Core.Comms;
using RomViewer.Core.Items;
using RomViewer.Init;
using SharpLite.NHibernateProvider;

namespace Focus.Tests
{
    [TestFixture]
    public class RomMessageProcessorTests
    {
        [SetUp]
        public virtual void SetUp()
        {
            //_configuration = NHibernateInitializer.Initialize();
            //_sessionFactory = _configuration.BuildSessionFactory();
            RomViewContainer.Initialize();
        }


        [Test]
        public void TestCanRequestItem()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            //LazySessionContext.Bind(new Lazy<ISession>(() => session), fac);

            IRomMessageProcessor p = RomViewContainer.Container.GetInstance<IRomMessageProcessor>();

            //romItem id = 228216
            int itemId = 228216;
            string source = string.Format("ITEM{0}GET{0}{1}", (char) 1, itemId);
            string response = p.HandleMessage(source);
            string[] result = response.Split((char) 1);
            Assert.AreEqual(itemId.ToString(), result[0]);
        }

        [Test]
        public void TestCanAddAndCanDeleteItem()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            LazySessionContext.Bind(new Lazy<ISession>(() => session), fac);

            IRomMessageProcessor p = RomViewContainer.Container.GetInstance<IRomMessageProcessor>();
            IItemRepository repository = RomViewContainer.Container.GetInstance<IItemRepository>();

            ItemDefinition expected = new ItemDefinition()
                                          {
                                              RomId = 999999,
                                              Name = "TestItem",
                                              ItemType = "ItemType",
                                              ItemSubType = "ItemSubType",
                                              ItemSubSubType = "ItemSubSubType",
                                              Value = 999
                                          };




            //romItem id = 228216
            string source = string.Format("ITEM{0}SAVE{0}{1}", (char)1, expected.ToDelimitedString(2));
            string response = p.HandleMessage(source);
            Assert.IsNull(response);

            ItemDefinition result = repository.GetByRomId(expected.RomId);
            Assert.IsNotNull(result);

            Assert.AreEqual(expected.ToDelimitedString(1), result.ToDelimitedString(1));
            tx.Rollback();
        }


    }
}