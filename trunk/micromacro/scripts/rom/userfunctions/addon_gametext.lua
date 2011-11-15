function gameText(msg,kind,channel,color,item)
--[[ informative:
kinds = { SAY, ZONE, YELL, WORLD, GUILD, RAID, PARTY, WHISPER, CHANNEL, SYSTEM, WARNING, SYSCHAT, MSG }
]]

local macro

colors = {
	white =  "ffffff",
	green =  "00ff00",
	blue =   "0072bc",
	purple = "a864a8",
	orange = "f68e56",
	gold =   "a37d50",
	yellow = "ffff00",
	red =    "ff0000",
};

if not msg then
	cprintf(cli.blue,"I think you might have forgotten an argument, care to guess which?\n");
	return
end

if item then --to use item write ITEM in the mesage and it'll be replace by the item link
	
	if type(item)=="string" then --if item name is supplied gets the CItem object.
		item = inventory:findItem(item)
	end
	msg = string.gsub(msg,"ITEM",item.ItemLink)
end

if color then
	if colors[color]~=nil then
	color = colors[color];
	end
	if item then
		msg = string.gsub(msg,"|H","|h|H") --remove color code start/end tags b4 item
		msg = string.gsub(msg,"|r|h","|r|h|H|h|cff"..color) --add color code start/end tags after item
	end
	msg = "|H|h|cff"..color..msg.."|r|h"
end

if kind == "WORLD" then kind = "YELL" end  --same
if kind == "RAID" then kind = "PARTY" end  --
if kind == "YELL" and inventory:itemTotalCount("Megaphone") == 0 then
	cprint(cli.blue,"Can't speak in World without Megaphones\n")
end 

--replace colors w/ ""
if kind == "SYSCHAT" then --system text in chat window, (orange)
	macro = "SendSystemChat('"..msg.."')"
end
if kind == "WARNING" then --(red) warning in screen with sound
	macro = "SendWarningMsg('"..msg.."')"
end
if kind == "SYSTEM" then --(yellow) msg in screen with sound
	macro = "SendSystemMsg('"..msg.."')"
end

if kind  == "MSG" or not kind then --simple white msg in chat windows
	macro = "DEFAULT_CHAT_FRAME:AddMessage('"..msg.."')"
end

if (kind == "WHISPER" or kind == "CHANNEL") and not channel then
	cprintf(cli.blue,"Must pass the char name to whisper to or channel number to chat in!\n") 
	return
else
--if type(channel)=="string" then channel = "'"..channel.."'" end  --only strings need ' quotes right?
end --must supply args

if not channel then channel = "" end

if not macro then 
	if (kinf=="CHANNEL") then
		macro = "SendChatMessage ( '"..msg.."', '"..kind.."', 0, "..channel.." )"
	else
		macro = "SendChatMessage ( '"..msg.."', '"..kind.."', 0, '"..channel.."' )"
	end
	cprintf(cli.yellow,macro.."\n");
end
--DEBUG: cprintf(cli.yellow,macro.."\n");
sendMacro(macro);
end