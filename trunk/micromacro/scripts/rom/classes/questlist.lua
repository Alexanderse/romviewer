CQuestList = class(
	function(self)
		self.Quests = {};
		self.Filename= nil;
	end
);

function CQuestList:load(filename)
--	local root = xml.open(filename);
--	if( not root ) then
--		error(sprintf("Failed to load quests from \'%s\'", filename), 0);
--	end
--	local elements = root:getElements();
--	self.FileName = getFileName(filename);
--	self.Quests = {}; 
--
--	for i,v in pairs(elements) do
--		local subElements = v:getElements();
--		local id, minLevel, level, starterId, enderId, gold, xp, tp, rewardcategory, rewardsubcat = v:getAttribute("id"), v:getAttribute("minlevel"), v:getAttribute("level"), v:getAttribute("starterid"), v:getAttribute("enderid"), v:getAttribute("gold"), v:getAttribute("xp"), v:getAttribute("tp"), v:getAttribute("rewardcategory"), v:getAttribute("rewardsubcategory");
--
--		printf("CQuest("..tostring(id)..", "..tostring(minLevel)..", "..tostring(level)..", "..tostring(starterId)..", "..tostring(enderId)..", "..tostring(gold)..", "..tostring(xp)..", "..tostring(tp)..", "..tostring(rewardcategory)..", "..tostring(rewardsubcategory)..");\n");
--		local quest = CQuest(id, minLevel, level, starterId, enderId, gold, xp, tp, rewardcategory, rewardsubcategory);
--	
--		for k,j in pairs(subElements) do
--			local rId, rIndex, rType, rValue = j:getAttribute("id"), j:getAttribute("index"), j:getAttribute("type"), j:getAttribute("value");
--			
--			local reward = { ["id"]=rId, ["index"]=rIndex, ["type"]=rType, ["value"]=rValue};
--			--printf("Adding reward: "..tostring(rId)..", "..tostring(rIndex)..", "..tostring(rType)..", "..tostring(rValue).."\n");
--			--printf("       reward: "..tostring(reward.id)..", "..tostring(reward.index)..", "..tostring(reward.type)..", "..tostring(reward.value).."\n");
--			table.insert(quest.Rewards, reward);
--		end;
--		
--		--add to quest list
--		self.Quests[id] = quest;
--	end;
end;

function CQuestList:getQuestById(id)
	if (self.Quests[id] == nil) then
		local result = self:loadQuest(id);
		self.Quests[id] = result;
	end;
	
	return self.Quests[id];
end;

function CQuestList:loadQuest(id)
	local link = CServerLink();
	local req = sprintf("QUEST\1GET\1"..tostring(id).."\0");
	printf("questList-sending: "..tostring(req).."\n");
	local q=link:send(req, true);
	printf("questList-got: "..tostring(q).."\n");
	link:close();
	return inflateQuest(q);
end;

function inflateQuest(source)
	local q = SplitString(source, "\1");
	local qid=tonumber(q[1]);
	local qName=q[2];
	local qMinLevel=tonumber(q[3]);
	local qLevel=tonumber(q[4]);
	local qStarter=tonumber(q[5]);
	local qEnder=tonumber(q[6]);
	local qGold=tonumber(q[7]);
	local qXP=tonumber(q[8]);
	local qTP=tonumber(q[9]);
	local qCat=q[10];
	local qSubCat=q[11];
	--chain
	--chain index
	--local rewards = q[14];
	local rewards = {count=0};
	printf("Reading rewards: "..tostring(q[14]).."\n");
    if (string.find(q[14], "\2") ~= nil) then
		local r = SplitString(q[14], "\2");
		
		--itemName, itemValue, type
		rewards.count = #r;
		for i=1,#r,1 do
			printf(" processing: "..tostring(r[i]).."\n");
			local reward = {};
			local rdata = SplitString(r[i],"\3");
			reward.Type = rdata[2];
			reward.itemCount = rdata[4];
			reward.itemName = rdata[5];
			reward.itemValue = rdata[6];
			table.insert(rewards, reward);
		end;
	end;
	
	local quest = CQuest(qid, qMinLevel, qLevel, qStarter, qEnder, qGold, qXP, qTP, qCat, qSubCat);
	quest.Rewards = rewards;
	return quest;
end;



__QL = CQuestList();
