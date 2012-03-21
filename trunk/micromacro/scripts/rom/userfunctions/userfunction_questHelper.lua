questHelper = "";

function redirectIfIncomplete(questId, tag, goal)
	local isComplete = false;
	
	if (goal) then 
		isComplete = CheckGoalIsComplete(questId, goal);
	else
		isComplete = CheckGoalsComplete(questId);
	end;
	
	if (not isComplete) then
		printf("Goal '"..tostring(goal).."' not complete - redirecting to '"..tostring(tag).."\n");
		redirectToWaypointTag(tag);
	end;
end;

function redirectIfComplete(questId, tag, goal)
	local isComplete = false;
	
	if (goal) then 
		isComplete = CheckGoalIsComplete(questId, goal);
	else
		isComplete = CheckGoalsComplete(questId);
	end;
	
	if (isComplete) then
		redirectToWaypointTag(tag);
	end;
end;


function redirectToWaypointTag(tag)
	local idx = __WPL:findWaypointTag(tag);
	__WPL:setWaypointIndex(idx);
end;

function Mobs_Add(target)
	if (AddTextToIList(settings.profile.mobs, target)) then
		printf("Added "..tostring(target).." to mob list\n");
	end;
end;

function Mobs_Remove(target)
	if (RemoveTextFromIList(settings.profile.mobs, target)) then
		printf("Removed "..tostring(target).." from mob list\n");
	end;
end;

function Friends_Add(target)
	if (AddTextToIList(settings.profile.friends, target)) then
		printf("Added '"..tostring(target).."' to friends list\n");
	end;
end;

function Friends_Remove(target)
	if (RemoveTextFromIList(settings.profile.friends, target)) then
		printf("Removed "..tostring(target).." from friends list\n");
	end;
end;

function AddTextToIList(plist, text)
	local foundIndex = GetIndexOfListItem(plist,text);
	
	if (foundIndex > -1) then 
		--printf(text.." was already in list\n");
		return false; 
	end;
	table.insert(plist, text);
	return true;
end;

function RemoveTextFromIList(plist, text)
	local foundIndex = GetIndexOfListItem(plist,text);
	
	if (foundIndex == -1) then 
		--printf(text.." was not in list\n");
		return false; 
	end;
	table.remove(plist, foundIndex);
	return true;
end;

function GetIndexOfListItem(plist, item)
	local foundIndex = -1;
	for i,v in ipairs(plist) do
		if (v == item) then
			foundIndex = i;
			break;
		end;
	end;
	
	return foundIndex;
end;

function CheckGoalsComplete(questId)
	-- make sure QuestBook:update() has been called if necessary!!!
	printf("Checking quest: "..tostring(questId).."\n");
	__QB:updateQuest(questId);
	local questInfo = __QB:getQuestById(questId)
	
	if (questInfo) then
		local complete = true;
		
		for i=1,questInfo.Goals.count,1 do
			complete = complete and (questInfo.Goals[i].Status==QB_GOAL_COMPLETE);
		end;
		return complete;
	else
		return false;
	end;
end;

function CheckGoalIsComplete(questId, goal)

	__QB:updateQuest(questId);
	local questInfo = __QB:getQuestById(questId)
	
	if (questInfo == nil) then
		__QB:update();
		questInfo = __QB:getQuestById(questId)
	end;
	
	if (questInfo) then
		local complete = true;
		
		for i=1,questInfo.Goals.count,1 do
			printf("Testing goal: '"..tostring(questInfo.Goals[i].Name).."' with '"..tostring(goal).."'\n");
			if goal and FindNormalisedString(questInfo.Goals[i].Name,string.lower(goal)) then
				printf("Matched on goal: returning "..tostring(questInfo.Goals[i].Status).."("..tostring(type(questInfo.Goals[i].Status)).." == 1\n");
				return (questInfo.Goals[i].Status==QB_GOAL_COMPLETE);
			end;
		end;
		return complete;
	else
		printf("Goal: '"..tostring(goal).."' not found\n");
		return false; --assume that it is not ok as we don't have it
	end;
end;

function PickupQuestIfIDontHaveIt(qst)
	qst:update();
	if (not qst.Accepted) then
		player:target_NPC(qst.StarterId);
		yrest(200);
		AcceptQuestByName(qst.Name);
		yrest(300);
		qst:update();
		__QB:update();
	end;
		
	if (#__QB.Quests < 1) then __QB:update(); end; --just to be sure!~!!
	
	local idx = __QB:getQuestIndex(quest.Id);
	__QB:updateQuest(idx);
	__QB:fetchRewardItems(idx);
	--quest = __QB.Quests[idx];
	--qst should refer to the gloval var 'quest' which we need to upate to the quest reference in questbook as often the quest has been loaded
	--from the external store which also has the reward cat and sub cat
	--quest.RewardCategory = qst.RewardCategory;
	--quest.RewardSubCategory = qst.RewardSubCategory;
end;

function TurnInQuestIfComplete(quest)
	if CheckGoalsComplete(quest.Id) then
		TurnInQuest(quest);
	end;
end;

function TurnInQuest(quest)
	player:target_NPC(quest.EnderId);

	local rewardIndex = nil;
	if ((quest.Rewards == nil) or (quest.Rewards.count == 0)) then
		local idx = __QB:getQuestIndex(quest.Id);
		__QB:fetchRewardItems(idx);
	end;
	if (quest.Rewards.count > 0) then
		rewardIndex = quest:getRewardConfiguredItemIndex();
	end;
	
	CompleteQuestByName(quest.Name,rewardIndex);
	yrest(200);
	quest.Completed= true;
	__QB:update();
	local link = CServerLink();
	local data = sprintf("TOON\1SETQUESTCOMPLETED\1%s\1%d\0",player.Name,quest.Id);
	printf("sending: "..data.."\n");
	link:send(data,false);
	link:close();
end;


--[[
local qCount = RoMScript("GetNumQuestBookButton_QuestBook()");
printf(tostring(qCount).." quests in quest book\n");

for i=1,qCount,1 do
	local questInfo = {};
	questInfo.Id = RoMScript("GetQuestId("..tostring(i)..")"); 
	questInfo.level = RoMScript("GetQuestRequest("..tostring(i)..",-3)"); 
	questInfo.name = RoMScript("GetQuestRequest("..tostring(i)..",-2)");
	printf("Quest: "..tostring(i)..": "..tostring(questInfo.name).." ("..tostring(questInfo.Id)..")\n");

	questInfo.goalnumber = RoMScript("GetQuestRequest("..tostring(i)..",-1)");
	printf("Quest requests: "..tostring(questInfo.goalnumber).."\n");
	for j = 1, questInfo.goalnumber do -- For each goal get name and status
		questInfo[j] = {};
		questInfo[j].goalname, questInfo[j].goalstatus = RoMScript("GetQuestRequest("..tostring(i)..","..tostring(j)..")");
		printf("Quest requests: "..tostring(questInfo[j].goalname)..", "..tostring(questInfo[j].goalstatus).."\n");
	end
end;

]]--

