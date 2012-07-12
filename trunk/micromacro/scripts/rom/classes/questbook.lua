QB_GOAL_NOT_COMPLETE = 0;
QB_GOAL_COMPLETE = 1;


CQuestBook = class(
	function(self)
		self.Quests = {};
	end
);

quest_DEBUG=true;

local function PrintLine(s)
	if (quest_DEBUG == true) then printf(s.."\n"); end;
end;

function CQuestBook:update()
	self.Quests = {};
	local qCount = RoMScript("GetNumQuestBookButton_QuestBook()");
	PrintLine("Found "..tostring(qCount).." quests in quest book\n");
	
	for i=1,qCount,1 do
		coroutine.yield();
		RoMScript("ViewQuest_QuestBook("..tostring(i)..");");
		
		local qi = {};
		qi.id = RoMScript("GetQuestId("..tostring(i)..")"); 
		qi.level = RoMScript("GetQuestRequest("..tostring(i)..",-3)"); 
		qi.name = RoMScript("GetQuestRequest("..tostring(i)..",-2)");
		qi.starterId = RoMScript("QuestDetail_GetQuestNPC()");
		qi.enderId = RoMScript("QuestDetail_GetRequestQuestNPC()");
		qi.gold = RoMScript("GetQuestMoney_QuestDetail()");
		qi.xp = RoMScript("GetQuestExp_QuestDetail()");
		qi.tp = RoMScript("GetQuestTP_QuestDetail()");
		
		PrintLine(tostring(i)..": "..tostring(qi.id).." - "..tostring(qi.name).."\n");
		PrintLine("\tlevel: "..tostring(qi.level).." starterid: "..tostring(qi.starterId).." enderid: "..tostring(qi.enderId).."\n");
		PrintLine("\tgold: "..tostring(qi.gold).." xp: "..tostring(qi.xp).." tp: "..tostring(qi.tp).."\n");

		local quest = CQuest(qi.id, qi.level-3, qi.level, qi.starterId, qi.enderId, qi.gold, qi.xp, qi.tp, "", "");
		
		quest.Goals.count= RoMScript("GetQuestRequest("..tostring(i)..",-1)");
		for j = 1, quest.Goals.count do -- For each goal get name and status
			coroutine.yield();
			quest.Goals[j] = {};
			quest.Goals[j].Name, quest.Goals[j].Status = RoMScript("GetQuestRequest("..tostring(i)..","..tostring(j)..")");
		end
		
		--qi.rewards = {}
		
		self.Quests[i] = quest;
	end;
end

function CQuestBook:updateQuest(questId)
	PrintLine("updateQuest goals for quest: "..tostring(questId));
	local idx = self:getQuestIndex(questId);
	
	if (idx < 0) then 
		PrintLine("Could not find index for quest!!!");
		return; 
	end;
	
	local quest = self.Quests[idx];
	RoMScript("ViewQuest_QuestBook("..tostring(idx)..");");
	quest.Goals.count = RoMScript("GetQuestRequest("..tostring(idx)..",-1)");
	for j = 1, quest.Goals.count do -- For each goal get name and status
		quest.Goals[j] = {};
		quest.Goals[j].Name, quest.Goals[j].Status = RoMScript("GetQuestRequest("..tostring(idx)..","..tostring(j)..")");
		PrintLine("Added goal '"..quest.Goals[j].Name.."' at status '"..tostring(quest.Goals[j].Status));
	end
end;


function CQuestBook:getQuestIndex(questId)
	local i = 1;
	local idx = -1;

	while ((idx == -1) and (i <= #self.Quests)) do
		if (tonumber(self.Quests[i].Id) == tonumber(questId)) then
			idx = i;
		end;
		i = i + 1;
	end;
	
	return idx;
end;

function CQuestBook:getQuestById(questId)
	local idx = self:getQuestIndex(questId);
	if (idx > -1) then
		return self.Quests[idx];
	else
		return nil;
	end;
end;

function CQuestBook:updateRewardItems()
	local qCount = #self.Quests;
	for index=1,qCount,1 do
		coroutine.yield();
		self:fetchRewardItems(index)
	end
end;

function CQuestBook:fetchRewardItems(index)
	PrintLine("Fetching rewards for quest index: "..tostring(index));
	RoMScript("ViewQuest_QuestBook("..tostring(index)..");");

	--local _name = RoMScript("GetQuestName_QuestDetail()");
	PrintLine("Checking quest: "..self.Quests[index].Name);
	--printf("Checking quest: ".._name.."\n");
	
---***********************Quest data***********************
	local numItem 	= {};
	local rewardItems = RoMScript("GetQuestItemNumByType_QuestDetail( 3 )");  --number of reward items
	local choiceItems = RoMScript("GetQuestItemNumByType_QuestDetail( 2 )");  --Choice reward count
	if (self.Quests[index].Rewards == nil) then self.Quests[index].Rewards = {} end;
	self.Quests[index].Rewards.count = choiceItems;
	if( choiceItems ~= 0 ) then
		PrintLine("  - "..tostring(choiceItems).." rewards found:");
		for i = 1, choiceItems, 1 do
			local itemsName, itemsIconPath, itemiItemVal = RoMScript("GetQuestItemInfo_QuestDetail( 2, "..tostring(i).." )");		
			local reward = {};
			
			reward.itemName=itemsName;
			reward.itemCount=itemiItemVal;
			PrintLine("     : "..tostring(i)..". "..itemsName.."("..tostring(itemiItemVal)..")");
			
			self.Quests[index].Rewards[i]=reward;
		end
	end
end;

local FMT_QB_UPDATE = "QUEST\1BOOKUPDATE\1%s\1%s\0";
local FMT_QB_QUEST = "%d\2%s\2%d\2%d\2%d\2%d\2%d\2%d";

local FMT_QB_REWARD = "%d\3%s\3%d\2";

function CQuestBook:syncWithServer()
--send a message like: QUESTBOOK|UPDATE|Quest,rewards...
	local link = CServerLink("127.0.0.1", 31001, 5);
	
	local qCount = #self.Quests;
	for index=1,qCount,1 do
		self:syncQuestWithServer(index, link);
	end
	link:close();
end;

function CQuestBook:syncQuestWithServer(index, link)
--send a message like: QUESTBOOK|UPDATE|Quest,rewards...
	local linkDefined = (link ~= nil);
	if (not linkDefined) then
		link = CServerLink("127.0.0.1", 31001, 5);
	end;
	
	local quest = self.Quests[index];
	PrintLine("Sending quest: "..quest.Name..": reward count "..tostring(quest.Rewards.count));
	
	local rewardsText = "";
	for i=1,quest.Rewards.count,1 do
		local reward = quest.Rewards[i];
		if (reward) then
			local rewardFmt = sprintf(FMT_QB_REWARD, i, reward.itemName, reward.itemCount);
			rewardsText=rewardsText..rewardFmt;
		end;
	end;
	
	PrintLine("Level: "..tostring(quest.Level));
	PrintLine("StarterId: "..tostring(quest.StarterId));
	PrintLine("EnderId: "..tostring(quest.EnderId));
	local questDetail = sprintf(FMT_QB_QUEST, tonumber(quest.Id), tostring(quest.Name), tonumber(quest.Level), tonumber(quest.StarterId), tonumber(quest.EnderId or quest.StarterId), tonumber(quest.Gold), tonumber(quest.XP), tonumber(quest.TP));
	
	local questFmt = sprintf(FMT_QB_UPDATE, questDetail, rewardsText);
	link:send(questFmt, false);
	
	if (not linkDefined) then
		link:close();
	end;
end;