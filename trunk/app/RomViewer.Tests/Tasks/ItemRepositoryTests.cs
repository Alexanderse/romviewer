using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using Focus.Tests;
using HtmlAgilityPack;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NUnit.Framework;
using RomViewer.Core.Items;
using RomViewer.Init;
using RomViewer.NHibernateProvider;
using RomViewer.Tasks.Repositories;
using SharpLite.Domain.DataInterfaces;
using SharpLite.NHibernateProvider;

namespace RomViewer.Tests.Tasks
{
    [TestFixture]
    public class ItemRepositoryTests
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
                IRepository<ItemDefinition> rep = RomViewContainer.Container.GetInstance<IRepository<ItemDefinition>>();
                IItemRepository repository = new ItemRepository(rep);

                ItemDefinition def = new ItemDefinition
                                         {
                                             RomId = 225932,
                                             Name = "Augury Cloth Boots",
                                             ItemType = "Armor",
                                             ItemSubType = "Boots",
                                             ItemSubSubType = "Cloth",
                                             Value = 100
                                         };

                string expected = def.ToDelimitedString(1);

                repository.AddItem(def);

                ItemDefinition result = repository.GetByRomId(def.RomId);
                Assert.AreEqual(expected, result.ToDelimitedString(1));
            }
            finally
            {
                tx.Rollback();
                session.Close();
            }
        }

        [Test]
        public void TestCanFetchByName()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                IRepository<ItemDefinition> rep = RomViewContainer.Container.GetInstance<IRepository<ItemDefinition>>();
                IItemRepository repository = new ItemRepository(rep);

                ItemDefinition def = new ItemDefinition
                                         {
                                             RomId = 999999,
                                             Name = "Augury Cloth Bootses",
                                             ItemType = "Armor",
                                             ItemSubType = "Boots",
                                             ItemSubSubType = "Cloth",
                                             Value = 100
                                         };

                string expected = def.ToDelimitedString(1);

                repository.AddItem(def);

                ItemDefinition result = repository.Get(def.Name);
                Assert.AreEqual(expected, result.ToDelimitedString(1));
            }
            finally
            {
                tx.Rollback();
                session.Close();
            }
        }

        [Test]
        public void TestHandlesInvalidFetchByName()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session);

            try
            {
                IRepository<ItemDefinition> rep = RomViewContainer.Container.GetInstance<IRepository<ItemDefinition>>();
                IItemRepository repository = new ItemRepository(rep);

                ItemDefinition result = repository.Get("asdfasdas");
                Assert.IsNull(result);
            }
            finally
            {
                tx.Rollback();
                session.Close();
            }
        }

        [Test]
        public void CanImportItems()
        {
            string filename = "Items.txt";

            if (File.Exists(filename))
            {
                string[] data = File.ReadAllLines(filename);

                ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
                ISession session = fac.OpenSession();
                ITransaction tx = session.BeginTransaction();
                CallSessionContext.Bind(session);
                //CallSessionContext.Bind(); 
                //LazySessionContext.Bind(new Lazy<ISession>(() => session), fac);
                try
                {
                    IRepository<ItemDefinition> rep =
                        RomViewContainer.Container.GetInstance<IRepository<ItemDefinition>>();

                    IItemRepository repository = new ItemRepository(rep);

                    foreach (string s in data)
                    {
                        string[] detail = s.Split('|');
                        int romId = Convert.ToInt32(detail[0]);

                        ItemDefinition def = repository.Get(romId);
                        if (def == null)
                        {
                            def = new ItemDefinition();
                        }
                        def.RomId = romId;
                        def.Name = detail[1];

                        repository.AddItem(def);
                    }

                    tx.Commit();
                }
                finally
                {
                    session.Close();
                }
            }

        }

        private string[] _itemTypes =
            {
                "Weapons",
                "Mounts",
                "Armor",
                "Supplies",
                "Recipes",
                "Household",
                "Special Items",
                "Equipment Enhancement",
                "Quest Items",
                "Materials",
                "Monster Cards",
                "Money",
                "Others"
            };

        private string[] _itemTypeFixes = {
                                              "Weapons=Weapon",
                                              "Mounts=Mount",
                                              "Armor=Armor",
                                              "Supplies=Supply",
                                              "Recipes=Recipe",
                                              "Household=Household",
                                              "Special Items=Special Item",
                                              "Equipment Enhancement=Equipment Enhancement",
                                              "Quest Items=Quest Item",
                                              "Materials=Material",
                                              "Monster Cards=Monster Card",
                                              "Money=Money",
                                              "Others=Other"
                                          };

        private string[] _itemSubTypes =
            {
                "Projectiles",
                "Hammers",
                "Hammer",
                "Daggers",
                "Dagger",
                "Axes",
                "Axe",
                "Staves",
                "Stave",
                "Staff",
                "Ranged Weapons",
                "Ranged Weapon",
                "Swords",
                "Sword",
                "Plate",
                "Back",
                "Chain",
                "Leather",
                "Accessories",
                "Accessory",
                "Off-hand",
                "Shield",
                "Cloth",
                "Amulets",
                "Amulet",
                "Desserts",
                "Dessert",
                "Potions",
                "Potion",
                "Foods",
                "Food",
                "Blacksmithing",
                "Armor Crafting",
                "Tailoring",
                "Carpentry",
                "Alchemy",
                "Cooking",
                "Furniture",
                "Knowledge Books",
                "Knowledge Book",
                "House Contracts",
                "House Contract",
                "Runes",
                "Rune",
                "Fusion Stones",
                "Fusion Stone",
                "Refining Gems",
                "Refining Gem",
                "Ores",
                "Ore",
                "Herbs",
                "Herb",
                "Raw Materials",
                "Raw Material",
                "Wood",
                "Production Runes",
                "Production Rune",
                "Prepared Materials",
                "Prepared Material",
                "Diamonds",
                "Gold",
                "Daily quest Item",
                "Quest Item",
                "Magic Sigil",
                "Item Shop Item",
                "General",
                "Seed",
                "Tools",
                "Tool"
            };

        private string[] _itemSubTypeFixes = {
                                                 "Projectiles=Projectile",
                                                 "Hammers=Hammer",
                                                 "Daggers=Dagger",
                                                 "Axes=Axe",
                                                 "Staves=Staff",
                                                 "Stave=Staff",
                                                 "Ranged Weapons=Ranged Weapon",
                                                 "Swords=Sword",
                                                 "Plate=Plate",
                                                 "Back=Back",
                                                 "Chain=Chain",
                                                 "Leather=Leather",
                                                 "Accessories=Accessory",
                                                 "Off-hand=Off-hand",
                                                 "Cloth=Cloth",
                                                 "Amulets=Amulet",
                                                 "Desserts=Dessert",
                                                 "Potions=Potion",
                                                 "Foods=Food",
                                                 "Blacksmithing=Blacksmithing",
                                                 "Armor Crafting=Armor Crafting",
                                                 "Tailoring=Tailoring",
                                                 "Carpentry=Carpentry",
                                                 "Alchemy=Alchemy",
                                                 "Cooking=Cooking",
                                                 "Furniture=Furniture",
                                                 "Knowledge Books=Knowledge Book",
                                                 "House Contracts=House Contract",
                                                 "Runes=Rune",
                                                 "Fusion Stones=Fusion Stone",
                                                 "Refining Gems=Refining Gem",
                                                 "Ores=Ore",
                                                 "Herbs=Herb",
                                                 "Raw Materials=Raw Material",
                                                 "Wood=Wood",
                                                 "Production Runes=Production Rune",
                                                 "Prepared Materials=Prepared Material",
                                                 "Diamonds=Diamonds",
                                                 "Gold=Gold",
                                                 "Daily quest Item=Daily quest Item",
                                                 "Quest Item=Quest Item",
                                                 "Magic Sigil=Magic Sigil",
                                                 "Item Shop Item=Item Shop Item",
                                                 "General=General",
                                                 "Seed=Seed",
                                                 "Tools=Tool"
                                             };

        private string[] _itemSubSubTypes = {
                                               "2-Handed Hammers",
                                               "1-Handed Hammers",
                                               "2-Handed Axes",
                                               "1-Handed Axes",
                                               "2-Handed Staves",
                                               "1-Handed Staves",
                                               "2-Handed Swords",
                                               "1-Handed Swords",
                                               "Crossbows",
                                               "Arrows",
                                               "Bows",
                                               "Bow",
                                               "Lower Body",
                                               "Capes",
                                               "Head",
                                               "Feet",
                                               "Shoulders",
                                               "Upper Body",
                                               "Belt",
                                               "Belts",
                                               "Hands",
                                               "Ring",
                                               "Necklace",
                                               "Earring",
                                               "Talisman",
                                               "Shield",
                                               "Rings",
                                               "Necklaces",
                                               "Earrings",
                                               "Talismans",
                                               "Amulets",
                                               "Amulet",
                                               "Shields"
                                           };

        private string[] _itemSubSubTypeFixes = {
                                                 "1-H=1-Handed",
                                                 "2-H=2-Handed",
                                                 "2-Handed Hammers=2-Handed",
                                                 "1-Handed Hammers=1-Handed",
                                                 "2-Handed Axes=2-Handed",
                                                 "1-Handed Axes=1-Handed",
                                                 "2-Handed Staves=2-Handed",
                                                 "1-Handed Staves=1-Handed",
                                                 "2-Handed Swords=2-Handed",
                                                 "1-Handed Swords=1-Handed",
                                                 "Crossbows=Crossbow",
                                                 "Arrows=Arrow",
                                                 "Bows=Bow",
                                                 "Lower Body=Lower Body",
                                                 "Capes=Cape",
                                                 "Head=Head",
                                                 "Feet=Feet",
                                                 "Shoulders=Shoulder",
                                                 "Upper Body=Upper Body",
                                                 "Belts=Belt",
                                                 "Hands=Hands",
                                                 "Rings=Ring",
                                                 "Amulets=Amulet",
                                                 "Necklace=Necklace",
                                                 "Earrings=Earring",
                                                 "Talismans=Talisman",
                                                 "Shields=Shield"
                                             };


        private string[] _itemSubTypeToTypeMap =
            {
                "Projectile=Weapon",
                "Hammer=Weapon",
                "Dagger=Weapon",
                "Axe=Weapon",
                "Staff=Weapon",
                "Ranged Weapon=Weapon",
                "Sword=Weapon",
                "Plate=Armor",
                "Back=Armor",
                "Chain=Armor",
                "Leather=Armor",
                "Accessories=Armor",
                "Accessory=Armor",
                "Off-hand=Armor",
                "Cloth=Armor",
                "Amulet=Armor",
                "Dessert=Supply",
                "Potion=Supply",
                "Food=Supply",
                "Seed=Supply",
                "Blacksmithing=Recipe",
                "Armor Crafting=Recipe",
                "Tailoring=Recipe",
                "Carpentry=Recipe",
                "Alchemy=Recipe",
                "Cooking=Recipe",
                "Furniture=Household",
                "Knowledge Book=Household",
                "House Contract=Household",
                "Runes=Equipment Enhancement",
                "Fusion Stone=Equipment Enhancement",
                "Refining Gem=Equipment Enhancement",
                "Rune=Equipment Enhancement",
                "Ore=Material",
                "Herb=Supply",
                "Raw Material=Material",
                "Wood=Material",
                "Production Rune=Material",
                "Prepared Material=Material",
                "Diamonds=Money",
                "Gold=Money",
                "Daily quest Item=Quest Item",
                "Quest Item=Quest Item",
                "Card=Monster Cards",
                "Magic Sigil=Special Item",
                "Item Shop Item=Other",
                "General=Other",
                "Tool=Other",
                "Shield=Armor"
            };

        private string[] _subTypeTx = {
                                          "1-H Hammer=Weapon,Hammer,1-Handed",
                                          "2-H Hammer=Weapon,Hammer,2-Handed",
                                          "2-H Axe=Weapon,Axe,2-Handed",
                                          "2-H Sword=Weapon,Sword,2-Handed",
                                          "Wand=Weapon,Staff,1-Handed",
                                          "Bow=Weapon,Ranged Weapon,Bow",
                                          "Crossbow=Weapon,Ranged Weapon,Crossbow",
                                          "Arrow=Weapon,Projectile,Arrow",
                                          "Necklace=Armor,Accessory,Necklace",
                                          "Ring=Armor,Accessory,Ring",
                                          "Amulet=Armor,Accessory,Amulet",
                                          "Earring=Armor,Accessory,Earring",
                                          "Talisman=Armor,Accessory,Talisman",
                                          "Rune=Equipement Enhancement,Rune,Rune",

                                     };

        [Test]
        public void CanUpdateItemsFromRomDB()
        {
            ISessionFactory fac = RomViewContainer.Container.GetInstance<ISessionFactory>();
            ISession session = fac.OpenSession();
            ITransaction tx = session.BeginTransaction();
            CallSessionContext.Bind(session); 
            //LazySessionContext.Bind(new Lazy<ISession>(() => session), fac);
            try
            {
                List<string> itemTypes = new List<string>(_itemTypes);
                List<string> itemSubTypes = new List<string>(_itemSubTypes);
                List<string> itemSubSubTypes = new List<string>(_itemSubSubTypes);

                Hashtable _typeFromSubTypeMap = new Hashtable(_itemSubTypeToTypeMap.Length);
                Hashtable _customTypeMap = new Hashtable(_subTypeTx.Length);
                Hashtable _subTypeFix = new Hashtable(_itemSubTypeFixes.Length);
                Hashtable _subSubTypeFix = new Hashtable(_itemSubSubTypeFixes.Length);
    

                foreach (string s in _itemSubTypeToTypeMap)
                {
                    string[] map = s.Split('=');
                    _typeFromSubTypeMap[map[0]] = map[1];
                }

                foreach (string s in _subTypeTx)
                {
                    string[] map = s.Split('=');
                    _customTypeMap[map[0]] = map[1];
                }

                foreach (string s in _itemSubTypeFixes)
                {
                    string[] map = s.Split('=');
                    _subTypeFix[map[0]] = map[1];
                }

                foreach (string s in _itemSubSubTypeFixes)
                {
                    string[] map = s.Split('=');
                    _subSubTypeFix[map[0]] = map[1];
                }

                IRepository<ItemDefinition> rep = RomViewContainer.Container.GetInstance<IRepository<ItemDefinition>>();
                IItemRepository repository = new ItemRepository(rep);
                
                var src = repository.GetAll().Where(definition => String.IsNullOrEmpty(definition.ItemType) && (definition.Value < 1));
                IList<ItemDefinition> items = new List<ItemDefinition>(src);


                string url = "http://www.runesdatabase.com/xml/en_US/items/xmls/{0}.xml";
                Regex _goldMatch = new Regex(@"Worth: (\d+) Gold", RegexOptions.IgnoreCase);
                Regex _reqLevelMatch = new Regex(@"Required level (\d+)", RegexOptions.IgnoreCase);
                Regex _cardMatch = new Regex(@"Card - ", RegexOptions.IgnoreCase);
                Regex _questMatch = new Regex(@"Daily quest", RegexOptions.IgnoreCase);

                int tCount = 0;
                for (int i = 0; i < items.Count; i++)
                //int i = 207141;
                {
                    if (!string.IsNullOrEmpty(items[i].ItemType))
                    {
                        //Debug.WriteLine("Ignoring "+items[i].RomId);
                        continue;
                    }

                    if (tCount > 10)
                    {
                        tx.Commit();
                        tx = session.BeginTransaction();
                        tCount = 0;
                        Debug.WriteLine("Committed 10");
                        
                    }

                    
                //}
                //foreach (ItemDefinition item in items)
                //{
                    string xml;
                    ItemDefinition item = items[i];
                    if ((item.RomId > 550001) && (item.RomId < 770000)) continue;

                    Debug.WriteLine("Working on item " + item.RomId);
                    //if (item.RomId < 204499) continue;

                    try
                    {
                        string filename = "data\\" + item.RomId.ToString() + ".xml";

                        if (File.Exists(filename))
                        {
                            xml = File.ReadAllText(filename);
                            Debug.WriteLine("Data fetched from disk.");
                        }
                        else
                        {
                            using (var webClient = new WebClient())
                            {
                                xml = webClient.DownloadString(string.Format(url, item.RomId));
                                File.WriteAllText(filename, xml);
                            }
                        }


                        romitem rItem = new romitem();
                        romitem.Deserialize(xml,out rItem);



                        /*
                        bool isArmour = rItem.tooltip.Contains("Physical Defense");
                        bool isWeapon = rItem.tooltip.Contains("Physical Damage");
                        bool isItemShopItem = rItem.tooltip.Contains("Item Shop Item");
                        bool isQuestItem = rItem.tooltip.Contains("Quest Item");
                        bool isQuestStartItem = rItem.tooltip.Contains("(Daily Quest)");
                        bool isMaterial = rItem.tooltip.Contains("Production Rune");
                        bool isEqEnhancement = rItem.tooltip.Contains("Rune");
                        if (isQuestStartItem) isQuestItem = true;
                        */
                        bool changed = false;
                        

                        HtmlDocument doc = new HtmlDocument();
                        string html = string.Format("<html><body>{0}</body></html>", rItem.tooltip);
                        //File.AppendAllText("itemHtml.xml", html);
                        doc.LoadHtml(html);
                        foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
                        {
                            var rows = table.SelectNodes("tr");
                            bool typeFound = false;

                            foreach (HtmlNode row in rows)
                            {
                                var cells = row.SelectNodes("td");

                                string firstCell = "";
                                string secondCell = "";
                                if (cells.Count > 0) firstCell = cells[0].InnerText;
                                if (cells.Count > 1) secondCell = cells[1].InnerText;

                                if (Regex.IsMatch(firstCell, "Not dropped on PK")) continue;
                                if (Regex.IsMatch(firstCell, "Tier ")) continue;
                                if (Regex.IsMatch(firstCell, "Durability ")) continue;
                                if (Regex.IsMatch(firstCell, "Physical ")) continue;
                                if (Regex.IsMatch(firstCell, "Magical ")) continue;
                                if (Regex.IsMatch(firstCell, "Binds ")) continue;

                                Match match = _goldMatch.Match(firstCell);
                                if (match.Success)
                                {
                                    item.Value = Convert.ToInt32(match.Groups[1].Value);
                                    changed = true;
                                }
                                match = _reqLevelMatch.Match(firstCell);
                                if (match.Success)
                                {
                                    item.RequiredLevel = Convert.ToInt32(match.Groups[1].Value);
                                    changed = true;
                                }

                                if (!string.IsNullOrEmpty(firstCell) && (itemSubTypes.Contains(firstCell)))
                                {
                                    if (_subTypeFix.Contains(firstCell)) firstCell = _subTypeFix[firstCell].ToString();
                                    item.ItemSubType = firstCell;
                                    changed = true;
                                    typeFound = true;
                                }
                                if (!string.IsNullOrEmpty(secondCell) && (itemSubSubTypes.Contains(secondCell)))
                                {
                                    if (_subTypeFix.Contains(secondCell)) secondCell = _subTypeFix[secondCell].ToString();
                                    item.ItemSubSubType = secondCell;
                                    changed = true;
                                }

                                if (!typeFound)
                                {
                                    if (_cardMatch.IsMatch(firstCell))
                                    {
                                        item.ItemSubType = "Card";
                                        changed = true;
                                    } else if (_questMatch.IsMatch(firstCell))
                                    {
                                        item.ItemSubType = "Daily quest Item";
                                        changed = true;
                                    } else if (_customTypeMap.ContainsKey(firstCell))
                                    {
                                        string[] data = _customTypeMap[firstCell].ToString().Split(',');

                                        item.ItemType = data[0];
                                        item.ItemSubType = data[1];
                                        item.ItemSubSubType = data[2];
                                    }
                                }
                            }
                        }

                        if ((changed) && (!string.IsNullOrEmpty(item.ItemSubType)))
                        {
                            if (_typeFromSubTypeMap.ContainsKey(item.ItemSubType))
                            {
                                item.ItemType = (string) _typeFromSubTypeMap[item.ItemSubType];
                                changed = true;
                            }
                        }

                        if (changed)
                        {
                            repository.UpdateItem(item);
                            tCount++;
                        }

                    } catch
                    {
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