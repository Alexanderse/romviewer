CQuest = class(
	function (self, qId, minLevel, level, starterid, enderid, gold, xp, tp, rewardcategory, rewardsubcategory)
		self.Id = qId;
		self.Name = GetIdName(qId);
		self.MinLevel = minlevel;
		self.Level = level;
		self.StarterId = starterid;
		self.StarterName = GetIdName(starterid);
		self.EnderId = enderid;
		self.EnderName = GetIdName(enderid);
		self.Gold = gold;
		self.XP = xp;
		self.TP = tp;
		self.RewardCategory = rewardcategory;
		self.RewardSubCategory = rewardsubcategory;
		self.Rewards = {count=0}; 
		self.Accepted=false;
		self.Completed=false;
		self.Goals = {count=0};
	end
)

SELECTION_TYPE_GOLD = "gold";
SELECTION_TYPE_TYPE = "type";

local function SplitString(str, delim, maxNb)
    -- Eliminate bad cases...
    if string.find(str, delim) == nil then
        return { str }
    end
    if maxNb == nil or maxNb < 1 then
        maxNb = 0    -- No limit
    end
    local result = {}
    local pat = "(.-)" .. delim .. "()"
    local nb = 0
    local lastPos
    for part, pos in string.gfind(str, pat) do
        nb = nb + 1
        result[nb] = part
        lastPos = pos
        if nb == maxNb then break end
    end
    -- Handle the last field
    if nb ~= maxNb then
        result[nb + 1] = string.sub(str, lastPos)
    end
    return result
end

function CQuest:toString()
		printf("  "..tostring(self.Id).."\n");
		printf("  "..tostring(self.Name).."\n");
		printf("  "..tostring(self.MinLevel).."\n");
		printf("  "..tostring(self.Level).."\n");
		printf("  "..tostring(self.StarterId).."\n");
		printf("  "..tostring(self.StarterName).."\n");
		printf("  "..tostring(self.EnderId).."\n");
		printf("  "..tostring(self.EnderName).."\n");
		printf("  "..tostring(self.Gold).."\n");
		printf("  "..tostring(self.XP).."\n");
		printf("  "..tostring(self.TP).."\n");
		printf("  "..tostring(self.RewardCategory).."\n");
		printf("  "..tostring(self.RewardSubCategory).."\n");
		printf("  "..tostring(self.Accepted).."\n");
		printf("  "..tostring(self.Completed).."\n");
end;

function CQuest:getRewardConfiguredItemIndex()
	printf("********getRewardConfiguredItemIndex**********\n");
	--figure out which reward item to take based on user preferences
	local selectionType = settings.profile.options.QUEST_REWARD_SELECTION_TYPE;
	if (selectionType == nil) then selectionType=SELECTION_TYPE_GOLD; end;
	selectionType = string.lower(selectionType);
	printf(" : selectionType = "..selectionType.."\n");

	local rewardTypeOrder;
	
	if (selectionType == SELECTION_TYPE_TYPE) then
		rewardTypeOrder = settings.profile.options["QUEST_REWARD_TYPE_ORDER_"..string.upper(tostring(self.RewardCategory)).."_"..string.upper(tostring(self.RewardSubCategory))];
		if (rewardTypeOrder == nil) then rewardTypeOrder = settings.profile.options["QUEST_REWARD_TYPE_ORDER_"..string.upper(tostring(self.RewardCategory))]; end;
		if (rewardTypeOrder == nil) then rewardTypeOrder = settings.profile.options.QUEST_REWARD_TYPE_ORDER; end;
		
		if (rewardTypeOrder == nil) then selectionType = SELECTION_TYPE_GOLD; end;
		printf(" : rewardTypeOrder = "..tostring(rewardTypeOrder).."\n");
	end;
	
	local rewardIndex = 0;
	if (selectionType == SELECTION_TYPE_TYPE) then
		printf(" : selecting on type, reward order = "..tostring(rewardTypeOrder).."\n");
		local res = SplitString(rewardTypeOrder, ',');
		for k,j in pairs(res) do
			printf("    : checking for type "..tostring(j).."\n");
			for i, v in pairs(self.Rewards) do
				if (i ~= "count") then 
					printf("       : checking against "..tostring(v.value).."\n");
					if (string.upper(j) == string.upper(v.type)) then
						rewardIndex = i;
						break;
					end;
				end;
			end;
			if (rewardIndex > 0) then break; end;
		end;
		printf(" : rewardindex = "..tostring(rewardIndex).."\n");
		
	end
	
	if (rewardIndex == 0) then --always default to selecting on valuye
		printf(" : basing choice off value\n");
		local rewardGold = 0;
		--iterate over rewards and select most valuable
		printf("reward count: "..tostring(self.Rewards.count).."\n");
		for i,v in pairs(self.Rewards) do
			printf("Checking reward: "..tostring(i).." - "..tostring(v).."\n");
			if (i ~= "count") then 
				for k,l in pairs(v) do
					printf("\t\ttbl: "..tostring(k).." - "..tostring(l).."\n");
				end;
				printf("\t\titem: "..tostring(v.itemName).." - "..tostring(v.itemValue).."\n");
				if (tonumber(v.itemValue) > rewardGold) then 
					rewardIndex = i;
					rewardGold=tonumber(v.itemValue);
				end;
			end;
		end;
	end;

	printf(" : rewardindex = "..tostring(rewardIndex).."\n");
	
	return rewardIndex;
end;

function CQuest:update()
	local questState = RoMScript("CheckQuest("..self.Id..")");
	printf("questState="..tostring(questState).."\n");
	if (questState==0) then 
		self.Accepted = false;
		self.Completed = false;
	elseif (questState == 2) then
		self.Accepted = true;
		self.Completed = true;
	else
		self.Accepted = true;
		self.Completed = false;
	end;
end;