using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Criterion;
using NUnit.Framework;
using RomViewer;
using RomViewer.Core.NPCs;
using RomViewer.Init;
using RomViewer.Tasks.Repositories;
using SharpLite.Domain.DataInterfaces;
using SharpLite.NHibernateProvider;

namespace Focus.Tests.Tasks
{
    [TestFixture]
    public class NpeRepositoryTests
    {
        private static List<NPCRecord> LoadNPCs(string filename)
        {
            if (File.Exists(filename))
            {
                using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<NPCRecord>));
                    return (List<NPCRecord>)ser.Deserialize(stream);
                }
            }

            return null;
        }

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
        public void TestCanAddSingleItem()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            LazySessionContext.Bind(new Lazy<ISession>(() => session), fac);

            try
            {
                IRepository<NonPlayerEntity> rep = RomViewContainer.Container.GetInstance<IRepository<NonPlayerEntity>>();
                INonPlayerEntityRepository repository = new NonPlayerEntityRespository(rep);

                NonPlayerEntity def = new NonPlayerEntity
                {
                    RomId = 225932,
                    Name = "MyNPC",
                };

                string expected = def.ToDelimitedString(1);

                repository.Add(def);

                //NonPlayerEntity result = repository.GetByRomId(def.RomId);
                //Assert.AreEqual(expected, result.ToDelimitedString(1));
            }
            finally
            {
                tx.Rollback();
                session.Close();
            }
        }

        [Test]
        public void ImportFile()
        {
            var npcs = LoadNPCs("data\\_npcs.xml");

            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                IRepository<NonPlayerEntity> rep = RomViewContainer.Container.GetInstance<IRepository<NonPlayerEntity>>();
                INonPlayerEntityRepository repository = new NonPlayerEntityRespository(rep);
                List<int> addedIdList = new List<int>();

                foreach (NPCRecord npc in npcs)
                {
                    //if (addedIdList.Contains(npc.id)) continue;
                    NonPlayerEntity test = repository.GetByRomId(npc.id, npc.guid);
                        //session.CreateCriteria<NonPlayerEntity>()
                        //.Add(Restrictions.Eq("RomId", npc.id))
                        //.Add(Restrictions.Eq("UniqueId", npc.guid))
                        //.UniqueResult<NonPlayerEntity>();

                    if (test != null)
                    {
                        continue;
                    }

                    test = repository.GetAll().FirstOrDefault(m => ((m.RomId == npc.id) && (m.ZoneId == npc.zoneid)));
                    if (test == null)
                    {

                        NonPlayerEntity entity = new NonPlayerEntity();
                        entity.RomId = npc.id;
                        entity.UniqueId = npc.guid;
                        entity.Name = npc.name;
                        entity.X = npc.x;
                        entity.Y = npc.y;
                        entity.Z = npc.z;
                        entity.ZoneId = npc.zoneid;

                        repository.Add(entity);
                    }
                    else
                    {
                        test.UniqueId = npc.guid;
                        repository.Update(test);
                    }

                    addedIdList.Add(npc.id);
                    ;
                }
                tx.Commit();
            }
            finally
            {
                session.Close();
            }
        }
    }
}