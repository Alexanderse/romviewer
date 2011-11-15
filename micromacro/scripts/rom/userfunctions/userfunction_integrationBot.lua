require "socket"

local commsEnabled = true;

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
						sendChatMessage("Error", "onLoad error: %s\n"..err);
					end

				else
					sendChatMessage("Error", "Invalid Command");
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
	EventMonitorStart("allWorld", "CHAT_MSG_YELL")
	EventMonitorStart("allParty", "CHAT_MSG_PARTY")
	EventMonitorStart("allTrade", "CHAT_MSG_TRADE")
	--EventMonitorStart("allCombat", "CHAT_MSG_COMBAT")
	EventMonitorStart("allGM", "CHAT_MSG_GM")
	EventMonitorStart("allSale", "CHAT_MSG_SALE")
	EventMonitorStart("allSystem", "CHAT_MSG_SYSTEM")
	EventMonitorStart("allChannel", "CHAT_MSG_CHANNEL")
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
end

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
		local sock = socket.udp()
		sock:settimeout(0)
		sock:setpeername(settings.profile.options.UDP_HOST, settings.profile.options.UDP_HOSTPORT)
		
		-- cprintf(cli.white, "[%s - %s] %s: %s\n", tostring(channel), tostring(os.date()), "", tostring(message)) 
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
			result = sprintf("%s%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\n",
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
		
			result = sprintf("%s%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\2%s\n",
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
	local result = sprintf("%s\2%s\2%s\2%s\2%s\2%s\2%s", player.Name, player.HP, player.MaxHP, player.X, player.Y, player.Z, getZone());
					
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

local playerAddress = addresses.staticbase_char;
local charZoneID_offset = 0x6FE; -- I only checked the character
local charZoneID = 0;

function refreshZoneID()
	local zoneID = memoryReadShortPtr(getProc(),playerAddress,charZoneID_offset);
	return zoneID;
end

-- Returns the ZoneID
function getZone()
	return refreshZoneID();
end

local newWPL = {};

--methods for creating waypoints etc!!!
function LoadNewWaypointList(filename)
	printf("Received new waypoint file: "..filename)
	SetCommsState("off");
	loadPaths(filename);
	--__WPL.Type = WPT_TRAVEL;
	sendChatMessage("NavPoint", "start");
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
		if (i == 0) or ((i / 2) == (math.floor(i/2))) then
			_lncolor = cli.lightgray;
		else
			_lncolor = cli.white;
		end
		
		s = sprintf("%s%d\2%d\2%d\2%s\2%s\2%s\2%s\2%x\3",s, roundIt(obj.X), roundIt(obj.Z), roundIt(obj.Y), fixString(tostring(obj.TYPE),5), fixString(obj.Name,24), fixString(tostring(obj.Id),7), fixString(tostring(obj.Attackable),7), obj.Address);

		setCount = setCount -1;
		if (setCount <= 1) then
			sendChatMessage("romObjects", s);
			setCount = 10;
			s = "";
		end;
	end
	if (setCount > 0) then sendChatMessage("romObjects", s); end;
	
	sendChatMessage("romObjects", "end");

end

