using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Context;
using RomViewer.Core;
using RomViewer.Core.Character;
using RomViewer.Core.Comms;
using RomViewer.Core.Items;
using RomViewer.Core.Mapping;
using RomViewer.Core.NPCs;
using RomViewer.Core.Quests;
using log4net;

namespace RomViewer.Tasks
{
    public class RomMessageProcessor : IRomMessageProcessor
    {
        private IItemRepository _itemRepository;
        private INonPlayerEntityRepository _npeRepository;
        private IQuestRepository _questRepository;
        private ISessionFactory _factory;
        private ICharacterRepository _characterRepository;
        private ILog _logger = LogManager.GetLogger(typeof (RomMessageProcessor));
        private Map _map;

        public RomMessageProcessor(IItemRepository itemRepository, INonPlayerEntityRepository npeRepository, IQuestRepository questRepository, ISessionFactory factory, ICharacterRepository characterRepository, Map map)
        {
            _itemRepository = itemRepository;
            _npeRepository = npeRepository;
            _questRepository = questRepository;
            _factory = factory;
            _characterRepository = characterRepository;
            _map = map;
        }


        public string GetDelimiter()
        {
            return ((char) 0).ToString();
        }

        public string HandleMessage(String oneLine)
        {
            _logger.InfoFormat("HandleMessage: {0}", oneLine);
            ISession session = _factory.OpenSession();
            CallSessionContext.Bind(session);
            ITransaction tx = session.BeginTransaction();
            try
            {

                string response = null;

                //log!!!
                if (oneLine == null) return null;

                string[] sections = oneLine.Split((char) 1);
                if (sections.Length < 2) return null;

                switch (sections[0])
                {
                    case "ITEM":
                        response = _handleItemMessage(sections);
                        break;
                    case "QUEST":
                        response = _handleQuestMessage(sections);
                        break;
                    case "NPC":
                        response = _handleNPEMessage(sections);
                        break;
                    case "TOON":
                        response = _handleToonMessage(sections);
                        break;
                    case "MAP":
                        response = _handleMapMessage(sections);
                        break;
                    default:
                        //log
                        break;
                }

                tx.Commit();
                if (!string.IsNullOrEmpty(response)) response += GetDelimiter();
                return response;
            } catch (Exception ex)
            {
                tx.Rollback();
                LogManager.GetLogger(typeof(RomMessageProcessor)).Error(ex.ToString());
                return null;
            }
            finally
            {
                CallSessionContext.Unbind(_factory);
            }
        }

        private string _handleMapMessage(string[] sections)
        {
            string response = "";

            QuestDefinition entity;
            int romId;
            QuestDefinition match;
            switch (sections[1])
            {
                case "GETROUTE":

                    string[] data = sections[2].Split((char) 2);
                    double x, y, z;
                    x = Convert.ToDouble(data[0]);
                    y = Convert.ToDouble(data[1]);
                    z = Convert.ToDouble(data[2]);
                    int zoneID = Convert.ToInt32(data[3]);
                    int npeID = Convert.ToInt32(data[4]);
                    int uniqueID = -1;
                    if (data.Length > 5) uniqueID = Convert.ToInt32(data[5]);

                    Vector3 start = new Vector3(x, y, z);

                    List<MapLink> result = null;
                    if (data.Length > 5)
                        result = _map.BuildRoute(start, zoneID, npeID, uniqueID);
                    else
                        result = _map.BuildRoute(start, zoneID, npeID);

                    foreach (MapLink link in result)
                    {
                        response += link.ToDelimitedString(2) + ((char) 1);
                    }
                    if (response.Length > 0)
                        response = response.Remove(response.Length - 1);
                    else
                        response += (char)0;
                    break;
                default:
                    break;
            }

            return response;
            
        }

        private string _handleToonMessage(string[] sections)
        {
            switch (sections[1])
            {
                case "SETQUESTCOMPLETED":
                    int questId = Convert.ToInt32(sections[3]);
                    string toonName = sections[2];
                    QuestDefinition quest = _questRepository.GetByRomId(questId);
                    CharacterDefinition toon = _characterRepository.FindByName(toonName);
                    if (toon == null)
                    {
                        toon = new CharacterDefinition();
                        toon.Name = toonName;
                        LogManager.GetLogger(typeof(RomMessageProcessor)).Warn("Could not load character: " + toonName +" so created a new one.");
                    }
                    if (!toon.CompletedQuests.Contains(quest))
                    {
                        toon.CompletedQuests.Add(quest);
                        _characterRepository.Update(toon);
                    }
                    break;
            }

            return null;
        }

        private string _handleNPEMessage(string[] sections)
        {
            string response = null;

            NonPlayerEntity entity;
            int romId;
            NonPlayerEntity match;
            switch (sections[1])
            {
                case "SAVE":
                    entity = new NonPlayerEntity(sections[2], 2);
                    match = _npeRepository.GetByRomId(entity.RomId, entity.UniqueId);
                    if (match != null)
                    {
                        match.Name = entity.Name;
                        match.ZoneId = entity.ZoneId;
                        match.X = entity.X;
                        match.Y = entity.Y;
                        match.Z = entity.Z;
                        match.EntityTypes = entity.EntityTypes;
                        _npeRepository.Update(match);
                    }
                    else
                    {
                        _npeRepository.Add(entity);
                    }
                    break;
                case "BOTUPDATE":
                    entity = new NonPlayerEntity(sections[2], 2);
                    match = _npeRepository.GetByRomId(entity.RomId, entity.UniqueId);
                    if (match == null) match = _npeRepository.GetByRomId(entity.RomId, 0);
                    if (match != null)
                    {
                        if (entity.Name.Length > 0) match.Name = entity.Name;
                        if (entity.ZoneId > 0) match.ZoneId = entity.ZoneId;
                        match.X = entity.X;
                        match.Y = entity.Y;
                        match.Z = entity.Z;
                        _npeRepository.Update(match);
                    }
                    else
                    {
                        _npeRepository.Add(entity);
                    }
                    break;
                case "DELETE":
                    romId = Convert.ToInt32(sections[2]);
                    //_npeRepository.Delete(romId);
                    break;
                case "GET":
                    romId = Convert.ToInt32(sections[2]);
                    int uniqueId = Convert.ToInt32(sections[2]);
                    entity = _npeRepository.GetByRomId(romId, uniqueId);
                    if (entity != null)
                    {
                        response = entity.ToDelimitedString(1);
                    }
                    else
                    {
                        response = NonPlayerEntity.GetNullDefinitionString(1);
                    }
                    break;
            }

            return response;
        }

        private string _handleQuestMessage(string[] sections)
        {
            string response = null;

            QuestDefinition entity;
            int romId;
            QuestDefinition match;
            switch (sections[1])
            {
                case "SAVE":
                    entity = new QuestDefinition(sections[2], 2);
                    match = _questRepository.GetByRomId(entity.RomId);
                    if (match != null)
                    {
                        match.Gold = entity.Gold;
                        match.Level = entity.Level;
                        match.MinLevel = entity.MinLevel;
                        match.QuestChain = entity.QuestChain;
                        match.RewardCategory = entity.RewardCategory;
                        match.RewardSubCategory = entity.RewardSubCategory;
                        match.StarterId = entity.StarterId;
                        match.EnderId = entity.EnderId;
                        match.TP = entity.TP;
                        match.XP = entity.XP;

                        //need to loop through rewards, matching up and copying
                        //match.Rewards = entity.XP;

                        _questRepository.Update(match);
                    }
                    else
                    {
                        _questRepository.Add(entity);
                    }
                    break;
                case "SAVEFROMAQB":
                    entity = new QuestDefinition(sections[2], 2);
                    match = _questRepository.GetByRomId(entity.RomId);
                    if (match != null)
                    {
                        if ((entity.Gold > 0) && (match.Gold < 1)) match.Gold = entity.Gold;
                        if ((entity.Level > 0) && (match.Level < 1)) match.Level = entity.Level;
                        if ((entity.MinLevel > 0) && (match.MinLevel < 1)) match.MinLevel = entity.MinLevel;
                        if ((entity.StarterId > 0) && (match.StarterId < 1)) match.StarterId = entity.StarterId;
                        if ((entity.EnderId > 0) && (match.EnderId < 1)) match.EnderId = entity.EnderId;
                        if ((entity.TP > 0) && (match.TP < 1)) match.TP = entity.TP;
                        if ((entity.XP > 0) && (match.XP < 1)) match.XP = entity.XP;

                        //need to loop through rewards, matching up and copying
                        //match.Rewards = entity.XP;

                        _questRepository.Update(match);
                    }
                    else
                    {
                        _questRepository.Add(entity);
                    }
                    break;
                case "DELETE":
                    romId = Convert.ToInt32(sections[2]);
                    _questRepository.Delete(romId);
                    break;
                case "GET":
                    romId = Convert.ToInt32(sections[2]);
                    entity = _questRepository.GetByRomId(romId);
                    if (entity != null)
                    {
                        response = entity.ToDelimitedString(1);
                    }
                    else
                    {
                        response = QuestDefinition.GetNullDefinitionString(1);
                    }
                    break;
                case "BOOKUPDATE":
                    string[] questData = sections[2].Split((char) 2);
                    int i = 0;
                    romId = Convert.ToInt32(questData[i]);i++;
                    string qName = questData[i];i++;
                    int lvl = Convert.ToInt32(questData[i]);i++;
                    int starterId = Convert.ToInt32(questData[i]);i++;
                    int enderId = Convert.ToInt32(questData[i]);i++;
                    int gold = Convert.ToInt32(questData[i]);i++;
                    int xp = Convert.ToInt32(questData[i]);i++;
                    int tp = Convert.ToInt32(questData[i]);

                    bool isUpdate = true;
                    entity = _questRepository.GetByRomId(romId);
                    if (entity == null)
                    {
                        entity = new QuestDefinition() {RomId = romId, Name = qName, Level = lvl, StarterId = starterId, EnderId = enderId, Gold = gold, XP = xp, TP = tp};
                        isUpdate = false;
                    }
                    else
                    {
                        entity.Name = qName;
                        entity.StarterId = starterId;
                        entity.EnderId = enderId;
                        entity.Level = lvl;
                        entity.MinLevel = lvl - 3;
                        if (entity.MinLevel < 1) entity.MinLevel = 0;
                        entity.Gold = gold;
                        entity.XP = xp;
                        entity.TP = tp;
                    }

                    if ((entity.Rewards.Count < 1) && (!string.IsNullOrEmpty(sections[3])))
                    {
                        string[] rewards =  sections[3].Split((char) 2);

                        foreach (string rewardString in rewards)
                        {
                            if (string.IsNullOrEmpty(rewardString)) continue;

                            try
                            {
                                QuestReward reward = new QuestReward(rewardString, 3, _itemRepository);
                                if ((reward.RewardType != null) || (reward.Item != null))
                                {
                                    entity.Rewards.Add(reward);

                                    reward.Quest = entity;
                                }
                            } catch
                            {
                            }
                        }

                        //IRepository<QuestReward> rewardRep = new Repository<QuestReward>(_factory);
                        _questRepository.Update(entity);
                        //foreach (QuestReward reward in entity.Rewards)
                        //{
                        //    rewardRep.SaveOrUpdate(reward);
                        //}
                    }
                    break;
            }

            return response;
        }

        private string _handleItemMessage(string[] sections)
        {
            string response = null;

            ItemDefinition def;
            int romId;
            switch (sections[1])
            {
                case "SAVE":
                    def = new ItemDefinition(sections[2],2);
                    ItemDefinition match = _itemRepository.GetByRomId(def.RomId);
                    if (match != null)
                    {
                        match.Name = def.Name;
                        match.ItemType = def.ItemType;
                        match.ItemSubType = def.ItemSubType;
                        match.ItemSubSubType = def.ItemSubSubType;
                        match.Value = def.Value;
                        _itemRepository.UpdateItem(match);
                    }
                    else
                    {
                        _itemRepository.AddItem(def);
                    }
                    break;
                case "DELETE":
                    romId = Convert.ToInt32(sections[2]);
                    _itemRepository.DeleteItem(romId);
                    break;
                case "GET":
                    romId = Convert.ToInt32(sections[2]);
                    def = _itemRepository.GetByRomId(romId);
                    if (def != null)
                    {
                        response = def.ToDelimitedString(1);
                    }
                    else
                    {
                        response = ItemDefinition.GetNullDefinitionString(1);
                    }
                    break;
                case "FIND":
                    switch (sections[2])
                    {
                        case "NAME":
                            string name = sections[3];
                            def = _itemRepository.Get(name);
                            if (def != null)
                            {
                                response = def.ToDelimitedString(1);
                            }
                            else
                            {
                                response = ItemDefinition.GetNullDefinitionString(1);
                            }
                            break;
                    }
                    break;
            }

            return response;
        }
    }
}