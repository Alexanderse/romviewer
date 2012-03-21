require "socket"
include "../classes/viewerlink.lua";
include "../functions.lua";
include "../queues.lua";

local commsEnabled = true;

local oldPrintF = printf;
local function locPrintf(format, ...)
	pcall(sendChatMessage, "Printf", sprintf(format, ...));
	oldPrintF(format,...);
end
printf = locPrintf;

local oldCPrintF = cprintf;
local function locCPrintf(color, format, ...)
	pcall(sendChatMessage, "Printf", sprintf(format, ...));
	oldCPrintF(color, format,...);
end
global.cprintf = locCPrintf;

function SetCommsState(state)
	if (state=="off") then
		commsEnabled = false;
	else
		commsEnabled = true;
	end
end

function runChatMonitors()
	startChatMonitors()

	c = socket.udp()
	c:settimeout(0)

	cprintf(cli.white, "Starting chat monitors on: %s %s\n", settings.profile.options.UDP_HOST, settings.profile.options.UDP_HOSTPORT);
	c:setpeername(settings.profile.options.UDP_HOST, settings.profile.options.UDP_HOSTPORT)	
	while (true) do
		if (commsEnabled == true) then
			sendPlayerCoords();
			coroutine.yield();
			printEvents("Guild", cli.green)
			printEvents("Whisper", cli.turquoise)
			printEvents("Say", cli.white)
			printEvents("World", cli.red)
			printEvents("Zone", cli.purple)
			sendPlayerCoords();
			coroutine.yield();
			printEvents("Party", cli.lightgreen)
			printEvents("Trade", cli.lightblue)
			printEvents("GM", cli.lightblue)
			printEvents("Sale", cli.lightblue)
			printEvents("System", cli.lightgray)
			printEvents("Channel", cli.lightgray)
			printEvents("newQuest", cli.lightgray)
			--printEvents("Combat", cli.lightgray)
		end;
		sendPlayerCoords();
		coroutine.yield();
	end
	c:close()	
	coroutine.yield();
	stopChatMonitors()	
end

function runCommandListener()
	romSocket = socket.udp()
	cprintf(cli.white, "Starting command listener on: %s\n", settings.profile.options.UDP_LOCALPORT);
	romSocket:setsockname('*', settings.profile.options.UDP_LOCALPORT)
	romSocket:settimeout(0)
	
	while (true) do
		coroutine.yield();
		local recv = romSocket:receive()
		if (recv ~= nil) then
			local res = SplitString(recv, '\1', -1)
			local style = string.upper(res[1])
			
			if (style=="CHAT") then
				local channel = string.upper(res[2])
			
				local p1 = string.gsub(res[3], "\\", "\\\\")
				p1 = string.gsub(p1, "'", "\\'")

				
				local p2 = res[4]
				
				
				if (channel == "WORLD") then channel="YELL" end
				if (not(channel == nil or channel =="")) then
					if ((channel == "WHISPER") and not (p2 == nil or p2 == "")) then
						cprintf(cli.white, "Sending [%s] %s to %s\n", channel, p1, p2);
						gameText(p1,channel,p2);
					else
						cprintf(cli.white, "Sending [%s] %s\n", channel, p1);
						gameText(p1,channel);
					end
				end
				
			elseif( style=="COMMAND") then
				local p1 = res[2];
				funct=loadstring(p1)
				if type(funct) == "function" then
					local status,err = pcall(funct);
					if status == false then
						sendChatMessage("Error", "onLoad error: "..err);
					end

				else
					sendChatMessage("Error", "Invalid Command: "..p1);
				end
			end
		end	
		
	end
	romSocket.close()
end
	
function startChatMonitors()
	EventMonitorStart("allGuild", "CHAT_MSG_GUILD")
	EventMonitorStart("allSay", "CHAT_MSG_SAY")
	EventMonitorStart("allWhisper", "CHAT_MSG_WHISPER")
	EventMonitorStart("allZone", "CHAT_MSG_ZONE")
	EventMonitorStart("allZone", "CHAT_MSG_ZONE")
	EventMonitorStart("allWorld", "CHAT_MSG_YELL")
	EventMonitorStart("allParty", "CHAT_MSG_PARTY")
	EventMonitorStart("allTrade", "CHAT_MSG_TRADE")
	--EventMonitorStart("allCombat", "CHAT_MSG_COMBAT")
	EventMonitorStart("allGM", "CHAT_MSG_GM")
	EventMonitorStart("allSale", "CHAT_MSG_SALE")
	EventMonitorStart("allSystem", "CHAT_MSG_SYSTEM")
	EventMonitorStart("allChannel", "CHAT_MSG_CHANNEL")
	EventMonitorStart("allnewQuest", "ADDNEW_QUESTBOOK")
	 
end

function stopChatMonitors()
	EventMonitorEnd("allGuild")
	EventMonitorEnd("allSay")
	EventMonitorEnd("allWhisper")
	EventMonitorEnd("allZone")
	EventMonitorEnd("allWorld")
	EventMonitorEnd("allParty")
	EventMonitorEnd("allTrade")
	--EventMonitorEnd("allCombat")
	EventMonitorEnd("allGM")
	EventMonitorEnd("allSale")
	EventMonitorEnd("allSystem")
	EventMonitorEnd("allChannel")
	EventMonitorEnd("allnewQuest")
end

function runQueueProcessor()
	while (true) do
		if ((__npcQ) and (not __npcQ:isEmpty())) then
			local link = CServerLink(nil,nil, 5);
			while (not __npcQ:isEmpty()) do
				--printf("Count: "..tostring(__npcQ:count()).."\n");
				link:send(__npcQ:pop(),false);
			end;
			link:close();
		end;
		yrest(500);
	end;
end;

function printEvents(channel, color)
	local _count = 0;
	local _time, more, msg, name = EventMonitorCheck("all"..channel)
	repeat
		if (_time ~= nil) then 
			--cprintf(cli.white, "[%s] (%s) %s %s", os.date(), channel, getPlayerNameFromLink(name), msg);
			local st = sprintf("CHAT\1%s\1%s\1%s\1%s", channel, getPlayerNameFromLink(name), stripColorCodes(msg), os.date())
			c:send(st)
		end
		if (more) then _time, more, msg, name = EventMonitorCheck("all"..channel) end
		_count = _count + 1;
		if (_count > 10) then
			_count = 0;
			coroutine.yield();
		end
	until (not more)
end

function getPlayerNameFromLink(playerLink)
	if playerLink == "" or playerLink == nil then
		return "";
 	end

	local s,e, name = string.find(playerLink, "|Hplayer:(.+).*|h%[");
	name = name or "<unknown>";

	return name;
end

function stripColorCodes(source)
	if (source == "") or (source == nil) then
		return "";
	end
	
	if (type(source) == "boolean") then return "true"; end;
	
	print("Stripping: "..source.."\n");
	
	source = string.gsub(source, "|Hitem:(%x+).*|h|c(%x+)", "");
	source = string.gsub(source, "|H|h|c%x%x%x%x%x%x%x%x", "");
	source = string.gsub(source, "|c%x%x%x%x%x%x%x%x", "");
	source = string.gsub(source, "|h", "");
	source = string.gsub(source, "%]|r", "]");
	return source;
end

function SplitString(str, delim, maxNb)
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

function sendChatMessage(channel, message)
	if (settings.profile.options.UDP_ENABLED) then
		local sock = CViewerLink(0);
		local st = sprintf("CHAT\1%s\1%s\1%s\1%s", channel, "", message, os.date())
		sock:send(st)
		sock:close()
	end
end

function sendInventory()
	sendChatMessage("Inventory", getInventory());
	yrest(30);
	sendChatMessage("Equipment", getEquipment())
	yrest(30);
	sendChatMessage("Gold", getGold())
	
end

function getInventory()
	inventory:update(nil);
	local result = "";
 	for slot,item in pairs(inventory.BagSlot) do
	    if (item.Available and (not item.Empty)) then
			result = sprintf("%s%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\3",
							result, item.Name, item.ItemCount, item.SlotNumber, item.ItemLink, 
							item.Durability, item.Quality, item.BoundStatus, item.RequiredLvl, item.ObjType, 
							item.ObjSubType, item.ObjSubSubType);
			
			--result = result..item.Id.." - "..item.Name.."["..item.ItemCount.."]\n";
		end;
	end;
	
	return result;
end

function getEquipment()
	inventory:update(nil);
	local result = "";
 	for slot,item in pairs(inventory.EquipSlots) do
		local bind = 0;
		if (item.Bound) then bind = 1; end;
		
			result = sprintf("%s%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\3",
							result, item.Name, item.ItemCount, item.Slot, item.ItemLink, 
							item.Durability, item.Quality, bind, item.RequiredLvl, "", "", "");
			
			--result = result..item.Id.." - "..item.Name.."["..item.ItemCount.."]\n";
	end;
	
	return result;
end

function getGold()
	inventory:update(nil);
	return inventory.Money;
end

function sendPlayerCoords()
	local result = sprintf("%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s", player.Name, player.HP, player.MaxHP, player.X, player.Y, player.Z, getZoneId(), player.MP, player.MaxMP, player.MP2, player.MaxMP2);
					
	sendChatMessage("PlayerUpdate", result);
end

function sendPlayerDetails()
	player:update();
	yrest(50);
	
	local result = sprintf("%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s", 
					player.Id, player.Name, player.Class1, player.Class2, player.Level, player.Level2, player.Guild, 
					player.HP, player.MaxHP, player.MP, player.MaxMP, player.MP2, player.MaxMP2, 
					player.Race, player.X, player.Y, player.Z, player.Mounted, player.LastExp);
					
	sendChatMessage("PlayerDetails", result);
end

local function myUnstick3()
			local wp = nil; local wpnum = nil;
			local isEndWP = false;
			
			if( player.Returning ) then
				wp = __RPL:getNextWaypoint();
				wpnum = __RPL.CurrentWaypoint;
			else
				wp = __WPL:getNextWaypoint();
				wpnum = __WPL.CurrentWaypoint;
			end;
	teleportToWP(wp.wpnum);
end;
unStick3 = myUnstick3;

function sendTargetDetails()
	player:update();
	yrest(50);
	if( player:haveTarget() ) then
		local target = player:getTarget();
		
		local result = sprintf("%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s", 
					target.Id, target.Name, target.Class1, target.Class2, target.Level, target.Level2, 
					target.HP, target.MaxHP, target.Race, target.X, target.Y, target.Z);
		
		sendChatMessage("TargetDetails", result);
	else
	end
end

function sendTargetDetailsEx()
	player:update();
	yrest(100);
	if( player:haveTarget() ) then
		local target = player:getTarget();
		
		local result = sprintf("%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s", 
					target.Id, target.Name, target.Class1, target.Class2, target.Level, target.Level2, 
					target.HP, target.MaxHP, target.Race, target.X, target.Y, target.Z);
		
		sendChatMessage("TargetDetails", result);
	else
		sendChatMessage("TargetDetails", "");
	end
end

function sendACSSetup()
	local s = sendMacro("acsGetSettings()");
	
	sendChatMessage("ACSSettings", s);
end

local playerAddress = addresses.staticbase_char;
local charZoneID_offset = 0x6FE; -- I only checked the character
local charZoneID = 0;

local newWPL = {};

loadingNewWaypoint = false

--methods for creating waypoints etc!!!
function LoadNewWaypointList(filename)
	loadingNewWaypoint = true
	printf("Received new waypoint file: "..filename)
	SetCommsState("off");
	loadPaths(filename);
	--__WPL.Type = WPT_TRAVEL;
	sendChatMessage("NavPoint", "start");
	loadingNewWaypoint = false;
end

function refreshZoneID()
	local zoneID = memoryReadShortPtr(getProc(),playerAddress,charZoneID_offset);
	return zoneID;
end

local function roundIt(_number)
	if _number > (math.floor(_number) + 0.5) then
		return math.ceil(_number);
	else
		return math.floor(_number);
	end
end

local function fixString(_string,_length)
	_string = _string:sub(1,_length);
	xTra = _length-_string:len();
	if xTra > 0 then
		for i=1,xTra do
		_string = _string .. " ";
		end
	end
	return _string;
end

--Basic object list iteration
function sendObjects()
	local objectList = CObjectList();
	objectList:update();
	local objSize = objectList:size();
	

	sendChatMessage("romObjects", "new");
	local lncolor,obj;
	local setCount = 10;
	local s = "";
	
	
	for i = 0,objSize do 
		obj = objectList:getObject(i);
				
		s = sprintf("%s%d\2%d\2%d\2%s\2%s\2%s\2%s\2%x\2%d\3",s, roundIt(obj.X), roundIt(obj.Z), roundIt(obj.Y), fixString(tostring(obj.Type),5), fixString(obj.Name,24), fixString(tostring(obj.Id),7), fixString(tostring(obj.Attackable),7), obj.Address, obj.GUID);
           -- return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}", (char)2, RomId, UniqueId, Name, ZoneId, X, Y, Z, (byte)EntityTypes);

		setCount = setCount -1;
		if (setCount <= 1) then
			sendChatMessage("romObjects", s);
			setCount = 10;
			s = "";
		end;

		if (obj.Type == PT_NPC and (obj.Id > 0) and (string.len(obj.Name) > 0) and (obj.Name~="<UNKNOWN>")) then
			local npc = sprintf("NPC\1BOTUPDATE\1%d\2%d\2%s\2%d\2%d\2%d\2%d\2%d\0",obj.Id, obj.GUID, tostring(obj.Name), getZoneId(), roundIt(obj.X), roundIt(obj.Y), roundIt(obj.Z), 0);

			__npcQ:push(npc);		
		end;
	end
	if (setCount > 0) then sendChatMessage("romObjects", s); end;
	
	sendChatMessage("romObjects", "end");
end

local captureWaypointPress = false;

wpKey = key.VK_NUMPAD1;			-- insert a movement point

function SetWaypointCapture(state)
	captureInsertPress = (state == "on");
end

function __log(filename, text)
	if ((filename ~= nil) and (text ~= nil)) then
		filename = getExecutionPath() .. "/logs/"..filename;
		file, err = io.open(filename, "a+");
		if( not file ) then
			error(err, 0);
		end

		file:write(text.."\n")
		file:close();
	end
end

function __logWithTime(filename, text)
	text = tostring(os.date("%c"))..": "..text
	__log(filename, text)
end

function CreateItemLink( item_id, quality )
  assert(type(item_id)=="number")
  qualit = quality or 1;
  local r,g,b = RoMScript("GetItemQualityColor("..tostring(quality).." or 1)");
  return string.format('|Hitem:%6x|h|cff%2x%2x%2x[dummy]|r|h',item_id,r*255,g*255,b*255)
end

function RVGetPath(x,y,z,zoneid,npcid)
	local data = sprintf("%s\2%s\2%s\2%s\2%s", tostring(x), tostring(y), tostring(z), tostring(zoneid), tostring(npcid));
	local query = sprintf("MAP\1GETROUTE\1%s\0", data);
	
	local link = CServerLink();
	printf("RVGetPath-sending: "..tostring(query).."\n");
	local q=link:send(query, true);
	printf("RVGetPath-got: "..tostring(q).."\n");
	link:close();
end;

--player:update();
--yrest(100);
--RVGetPath(player.X, player.Y, player.Z, getZoneId(), 110245);

function SendQuestStatus(questId)
	printf("SendQuestStatus("..tostring(questId)..")\n");
	if (questId == nil) then return; end;
	if (type(questId)=='string') then questId = tonumber(questId); end;
	
	quest = CQuest(questId,0,0,0,0,0,0,0,"","");
	--self, qId, minLevel, level, starterid, enderid, gold, xp, tp, rewardcategory, rewardsubcategory
	quest:update();

	if (quest.Completed) then
		local link = CServerLink("127.0.0.1", 31001, 5);
		local data = sprintf("TOON\1SETQUESTCOMPLETED\1%s\1%d\0",player.Name,questId);
		printf("sending: "..data.."\n");
		link:send(data,false);
		link:close();
		yrest(50);
	end;

end;