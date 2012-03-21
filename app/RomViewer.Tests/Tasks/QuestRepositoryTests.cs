using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using HtmlAgilityPack;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NUnit.Framework;
using RomViewer.Core.Items;
using RomViewer.Core.Quests;
using RomViewer.Init;
using RomViewer.Tasks.Repositories;
using SharpLite.Domain.DataInterfaces;
using SharpLite.NHibernateProvider;

namespace Focus.Tests.Tasks
{
    [TestFixture]
    public class QuestRepositoryTests
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
        public void TestCanAddSingleItem()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                IRepository<QuestDefinition> rep =
                    RomViewContainer.Container.GetInstance<IRepository<QuestDefinition>>();
                IQuestRepository repository = new QuestRepository(rep);

                QuestChain chain = new QuestChain()
                                       {
                                           Name = "Saving a Marriage"
                                       };

                IRepository<QuestChain> chainRep = RomViewContainer.Container.GetInstance<IRepository<QuestChain>>();
                try
                {
                    chain = chainRep.SaveOrUpdate(chain);
                }
                catch
                {
                }

                QuestDefinition def = new QuestDefinition()
                                          {
                                              RomId = 423924,
                                              Name = "Act First and Report Later",
                                              MinLevel = 25,
                                              Level = 27,
                                              StarterId = 117396,
                                              EnderId = 117396,
                                              Gold = 1515,
                                              XP = 17301,
                                              TP = 1730,
                                              RewardCategory = RewardCategory.Armor,
                                              RewardSubCategory = RewardSubCategory.Head,
                                              ChainIndex = 4,
                                              QuestChain = chain
                                          };

                IRepository<ItemDefinition> idef = RomViewContainer.Container.GetInstance<IRepository<ItemDefinition>>();

                ItemRepository irep = new ItemRepository(idef);
                ItemDefinition item = irep.GetByRomId(228250);
                item.ItemType = "armor";
                item.ItemSubType = "cloth";
                item.ItemSubSubType = "head";
                item.Value = 196;
                irep.UpdateItem(item);

                QuestReward reward = new QuestReward()
                                         {
                                             Item = item,
                                             RewardIndex = 1,
                                             RewardType = "Cloth",
                                             Quest = def
                                         };
                def.Rewards.Add(reward);

                item = irep.GetByRomId(228251);
                item.ItemType = "armor";
                item.ItemSubType = "leather";
                item.ItemSubSubType = "head";
                item.Value = 261;
                irep.UpdateItem(item);

                reward = new QuestReward() {Item = item, RewardIndex = 2, RewardType = "Leather", Quest = def};
                def.Rewards.Add(reward);

                repository.Add(def);

            }
            finally
            {
                tx.Rollback();
                session.Close();
            }
        }

        [Test]
        public void ImportFromQuestListXML()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);
            //LazySessionContext.Bind(new Lazy<ISession>(() => session), fac);
            try
            {
                IRepository<QuestDefinition> rep = RomViewContainer.Container.GetInstance<IRepository<QuestDefinition>>();
                IQuestRepository repository = new QuestRepository(rep);
                IList<QuestDefinition> items = repository.GetAll();

                string filename = "Data\\questlist.xml";
                if (!File.Exists(filename)) throw new Exception("File missing");

                list data = new list();
                data = list.LoadFromFile(filename);

                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                XmlNodeList quests = doc.SelectNodes("//romquest");

                foreach (XmlNode romquest in quests)
                {
                    int id = Convert.ToInt32(romquest.Attributes["id"].Value);
                    string name = romquest.Attributes["name"].Value;

                    QuestDefinition quest = items.FirstOrDefault(definition => definition.RomId == id);
                    if (quest == null)
                    {
                        quest = new QuestDefinition() {RomId = id, Name = name};
                        repository.Add(quest);
                    }
                    else
                    {
                        quest.RomId = id;
                        quest.Name = name;
                        repository.Update(quest);
                    }
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
