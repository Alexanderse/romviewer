--==<<          JackBlonder's quest functions             >>==--
--==<<                   Version 0.97		              >>==--
--==<<====================================================>>==--
function AcceptQuestByName(_name)
	
	local DEBUG = false
	local questNPC
	
	-- Check if we have target
	player:update()
	yrest(100)
	if (player.TargetPtr == 0 or player.TargetPtr == nil) then
		print("No target! Target NPC before using CompleteQuestByName")
		return
	end
	-- Target NPC again to get updated questlist
	RoMScript("UseSkill(1,1)")
	--------------------------------------------
	_name = _name or "all"
	local questToAccept = _name
				if DEBUG then
					printf("questToAccept: %s\n",questToAccept)
				end
	local questOnBoard
	local isQuest
	local availableQuests = RoMScript("GetNumQuest(1)") -- Get number of available quests
				if DEBUG then
					printf("Number of available quests: %d\n",availableQuests)
				end
	local i


	
	-- Accept all available quests
	if (questToAccept == "" or questToAccept == "all") then
		for i=1,availableQuests do
			-- Check to see if we have room to accept quests
			if (30 > RoMScript("GetNumQuestBookButton_QuestBook()")) then
				repeat -- Makes sure we accept the quest
					questOnBoard = normaliseString(RoMScript("GetQuestNameByIndex(1, "..i..")")) -- Get questname
						if DEBUG then
							printf("questOnBoard / Index: %s \t %d\n",questOnBoard,i)
							sendMacro("OnClick_QuestListButton(1, "..i..")") -- Clicks the quest
							yrest(100)
							sendMacro("AcceptQuest()") -- Accepts the quest
							yrest(100)
							printf("Queststatus: %s \n",getQuestStatus(questOnBoard))
						else
							RoMScript("OnClick_QuestListButton(1, "..i..")") -- Clicks the quest
							yrest(100)
							RoMScript("AcceptQuest()") -- Accepts the quest
							yrest(100)
						end

				until (getQuestStatus(questOnBoard)=="incomplete" or getQuestStatus(questOnBoard)=="complete") -- Try again if accepting didn't work
				printf("Quest accepted: %s\n",questOnBoard)
			else
				print("Maxim number of quests in questbook!")
			end
		end
	
	-- Accept a quest by quest name
	else
		for i=1,availableQuests do
			-- Check to see if we have room to accept quests
			if (30 > RoMScript("GetNumQuestBookButton_QuestBook()"))  then
				questOnBoard = normaliseString(RoMScript("GetQuestNameByIndex(1, "..i..")")) -- Get questname
							if DEBUG then
								printf("questOnBoard: %s \n",questOnBoard)
							end
				isQuest = compareQuestnames(questOnBoard,questToAccept)
							if DEBUG then
								printf("isQuest: %s \n",isQuest)
							end
				if (isQuest) then
					repeat
						RoMScript("OnClick_QuestListButton(1,"..i..")") -- Clicks the quest
						yrest(100)
						RoMScript("AcceptQuest()") -- Accepts the quest
						yrest(100)
							if DEBUG then
								printf("Queststatus: %s \n",getQuestStatus(questOnBoard))
							end
					until (getQuestStatus(questOnBoard)=="incomplete" or getQuestStatus(questOnBoard)=="complete") -- Try again if accepting didn't work
					printf("Quest accepted: %s\n",questOnBoard)
					break
				elseif i==availableQuests then
					printf("Questname not found: %s\n",questToAccept) -- Quest not found
				end
			else
				print("Maxim number of quests in questbook!")
			end
		end
	end
end

function CompleteQuestByName(_name, _rewardnumber)

	local DEBUG = false

	local questNPC
	
	-- Check if we have target
	player:update()
	yrest(100)
	if (player.TargetPtr == 0 or player.TargetPtr == nil) then
		print("No target! Target NPC before using CompleteQuestByName")
		return
	end
	-- Target NPC again to get updated questlist
	RoMScript("UseSkill(1,1)")
	--------------------------------------------	
	
	_name = _name or "all"
	local questToComplete = _name
				if DEBUG then
					printf("questToComplete: %s\n",questToComplete)
				end
	local questOnBoard = ""
	local isQuest
	local availableQuests = RoMScript("GetNumQuest(3)")
				if DEBUG then
					printf("Number of available quests: %d\n",availableQuests)
				end
	local i
	
	-- Complete all available quests
	if (questToComplete == "" or questToComplete == "all") then
		for i=1,availableQuests do
			repeat
				questOnBoard = normaliseString(RoMScript("GetQuestNameByIndex(3, "..i..")"))-- Get questname
						if DEBUG then
							printf("questOnBoard / Index: %s \t %d\n",questOnBoard,i)
						end
				RoMScript("OnClick_QuestListButton(3, "..i..")") -- Clicks the quest
				yrest(100)
				if _rewardnumber then
							if DEBUG then
								printf("_rewardnumber: %d \n",_rewardnumber)
							end
					RoMScript("SpeakFrame_ClickQuestReward(SpeakQuestReward1_Item".._rewardnumber..")")
					yrest(100)
				end
				RoMScript("CompleteQuest()") -- Completes the quest
				yrest(100)
			until (getQuestStatus(questOnBoard)~="complete")
			printf("Quest completed: %s\n",questOnBoard)
			
		end
	
	-- Complete a quest by quest name
	else
		for i=1,availableQuests do
			questOnBoard = normaliseString(RoMScript("GetQuestNameByIndex(3, "..i..")"))-- Get questname
						if DEBUG then
							printf("questOnBoard / Index: %s \t %d\n",questOnBoard,i)
						end
			isQuest = compareQuestnames(questOnBoard,questToComplete)
			if (isQuest) then
				repeat
					RoMScript("OnClick_QuestListButton(3,"..i..")") -- Clicks the quest
					yrest(100)
					if _rewardnumber then
							if DEBUG then
								printf("_rewardnumber: %d \n",_rewardnumber)
							end
						RoMScript("SpeakFrame_ClickQuestReward(SpeakQuestReward1_Item".._rewardnumber..")")
						yrest(100)
					end
					RoMScript("CompleteQuest()") -- Completes the quest
					yrest(100)
							if DEBUG then
								printf("Queststatus: %s \n",getQuestStatus(questOnBoard))
							end
				until (getQuestStatus(questOnBoard)~="complete")
				printf("Quest completed: %s\n",questOnBoard)
				break
			elseif i==availableQuests then
				printf("Questname not found: %s\n",questToComplete)
			end
			 
		end
	end
end

function AcceptAllQuests()
	AcceptQuestByName()
end
function CompleteAllQuests()
	CompleteQuestByName()
end

function normaliseString(_str)
	_str = string.gsub(_str, string.char(45), ".")	-- Delete "-" in string
	_str = string.gsub(_str, string.char(34), ".")	-- Delete """ in string
	_str = string.lower(_str) -- Lower case
	return _str
end

function compareQuestnames(_name, _string)
	_string = normaliseString(_string)
	
	if string.find(_name,_string) then
			return true
	else
			return false
	end
end

