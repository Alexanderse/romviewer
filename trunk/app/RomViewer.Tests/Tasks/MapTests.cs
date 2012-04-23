using System;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NUnit.Framework;
using RomViewer.Core;
using RomViewer.Core.Items;
using RomViewer.Core.Mapping;
using RomViewer.Init;
using RomViewer.Tasks;
using RomViewer.Tasks.Repositories;
using SharpLite.Domain.DataInterfaces;

namespace Focus.Tests.Tasks
{
    [TestFixture]
    public class MapTests
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
        public void CanMap()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                MapBuilder mb = RomViewContainer.Container.GetInstance<MapBuilder>();
                Map map = mb.BuildMap();
                MapPoint start = (MapPoint)map.MapPoints[1];
                MapPoint end = (MapPoint)map.MapPoints[5];

                var result = map.BuildRoute(start, end);
                for (int i = 0; i < result.Count; i++)
                {
                    string link = result[i].Start.Id.ToString() + "->" + result[i].End.Id.ToString();
                    Console.WriteLine(link);
                }

                start = (MapPoint)map.MapPoints[735];
                end = (MapPoint)map.MapPoints[1565];

                result = map.BuildRoute(start, end);
                for (int i = 0; i < result.Count; i++)
                {
                    string link = result[i].Start.Id.ToString() + "->" + result[i].End.Id.ToString();
                    Console.WriteLine(link);
                }
            } finally
            {
                tx.Rollback();
            }
        }

        [Test]
        public void CanLocate()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                MapBuilder mb = RomViewContainer.Container.GetInstance<MapBuilder>();
                Map map = mb.BuildMap();
                Vector3 loc = new Vector3(-4574,81,7477);
                int zoneId = 15;

                var result = map.BuildRoute(loc, zoneId, 110245);
                for (int i = 0; i < result.Count; i++)
                {
                    string link = result[i].Start.Id.ToString() + "->" + result[i].End.Id.ToString();
                    Console.WriteLine(link);
                }
            }
            finally
            {
                tx.Rollback();
            }
        }

        [Test]
        public void CanRunFromTo()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                MapBuilder mb = RomViewContainer.Container.GetInstance<MapBuilder>();
                Map map = mb.BuildMap();
                Vector3 loc = new Vector3(-1169, 38, -5527); //logar snoop
                int zoneId = 1;

                Vector3 dV = new Vector3(-20460, -190, 6507);

                PlottedMapPoint dest = map.FindNearest(dV, 6);

                var result = map.BuildRoute(loc, zoneId, dest.MapPoint);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><waypoints>");
                for (int i = 0; i < result.Count; i++)
                {
                    string script = "";
                    //if (i < path.Count - 1) script = path[i + 1].Script;
                    sb.AppendLine(result[i].Start.ToRomBotXML(i + 1, result[i].Script));
                }
                if (result.Count > 0) sb.AppendLine(result[result.Count - 1].End.ToRomBotXML(result.Count, ""));
                Console.WriteLine(sb.ToString());
            }
            finally
            {
                tx.Rollback();
            }            
        }
    }
}