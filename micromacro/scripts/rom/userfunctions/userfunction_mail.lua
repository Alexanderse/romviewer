	-----------------------------------------------------------
	------------- MiesterMan's Mailing Functions --------------
	-----------------------------------------------------------

-- Version 1.0

-- I really should have done an XML DB for this but I've had trouble with it in
-- the past so I just made a table with names.  If a crafting class is made later
-- I'll convert this to XML with level info for whoever does it.
CRAFTMATS = {
	ORE = {"Zinc Ore", "Zinc Sand", "Zinc Nugget", "Zinc Ingot", 
		"Flame Dust", "Flame Dust Sand", "Flame Dust Nugget", "Flame Dust Ingot", 
		"Tin Ore", "Tin Sand", "Tin Nugget", "Tin Ingot", 
		"Cyanide", "Cyanide Sand", "Cyanide Nugget", "Cyanide Ingot", 
		"Iron Ore", "Iron Sand", "Iron Nugget", "Iron Ingot", 
		"Copper Ore", "Copper Sand", "Copper Nugget", "Copper Ingot", 
		"Rock Crystal", "Rock Crystal Sand", "Rock Crystal Nugget", "Rock Crystal Ingot", 
		"Dark Crystal", "Dark Crystal Sand", "Dark Crystal Nugget", "Dark Crystal Ingot", 
		"Mysticite", "Mysticite Sand", "Mysticite Nugget", "Mysticite Ingot", 
		"Silver Ore", "Silver Sand", "Silver Nugget", "Silver Ingot", 
		"Wizard-Iron Ore", "Wizard-Iron Sand", "Wizard-Iron Nugget", "Wizard-Iron Ingot", 
		"Mithril", "Mithril Sand", "Mithril Nugget", "Mithril Ingot", 
		"Moon Silver Ore", "Moon Silver Sand", "Moon Silver Nugget", "Moon Silver Ingot", 
		"Abyss-Mercury", "Abyss-Mercury Sand", "Abyss-Mercury Nugget", "Abyss-Mercury Ingot", 
		"Frost Crystal", "Frost Crystal Sand", "Frost Crystal Nugget", "Frost Crystal Ingot", 
		"Rune Obsidian Ore", "Rune Obsidian Sand", "Rune Obsidian Nugget", "Rune Obsidian Ingot", 
		"Mica", "Mica Sand", "Mica Nugget", "Mica Ingot"}, -- End MINING
	HERB = {"Mountain Demon Grass","Mountain Demon Grass Bundle","Mountain Demon Grass Sap","Mountain Demon Grass Extract", 
		"Rosemary","Rosemary Bundle","Rosemary Sap","Rosemary Extract", 
		"Beetroot","Beetroot Bundle","Beetroot Sap","Beetroot Extract", 
		"Bison Grass","Bison Grass Bundle","Bison Grass Sap","Bison Grass Extract", 
		"Bitterleaf","Bitterleaf Bundle","Bitterleaf Sap","Bitterleaf Extract", 
		"Moxa","Moxa Bundle","Moxa Sap","Moxa Extract", 
		"Foloin Nut","Foloin Nut Bundle","Foloin Nut Sap","Foloin Nut Extract", 
		"Dusk Orchid","Dusk Orchid Bundle","Dusk Orchid Sap","Dusk Orchid Extract", 
		"Green Thistle","Green Thistle Bundle","Green Thistle Sap","Green Thistle Extract", 
		"Barsaleaf","Barsaleaf Bundle","Barsaleaf Sap","Barsaleaf Extract", 
		"Moon Orchid","Moon Orchid Bundle","Moon Orchid Sap","Moon Orchid Extract", 
		"Straw Mushroom","Straw Mushroom Bundle","Straw Mushroom Sap","Straw Mushroom Extract", 
		"Sinners Palm","Sinners Palm Bundle","Sinners Palm Sap","Sinners Palm Extract", 
		"Dragon Mallow","Dragon Mallow Bundle","Dragon Mallow Sap","Dragon Mallow Extract", 
		"Mirror Sedge","Mirror Sedge Bundle","Mirror Sedge Sap","Mirror Sedge Extract", 
		"Thorn Apple","Thorn Apple Bundle","Thorn Apple Sap","Thorn Apple Extract", 
		"Goblin Grass","Goblin Grass Bundle","Goblin Grass Sap","Goblin Grass Extract"}, -- End HERBALISM
	COOK = {"Pineapple", "Lettuce", "Celery", "Oriental Tea Leaves"}, -- End COOKING
	WOOD = {"Ash Wood", "Ash Timber", "Ash Lumber", "Ash Plank", 
		"Chime Wood", "Chime Wood Timber", "Chime Wood Lumber", "Chime Wood Plank", 
		"Willow Wood", "Willow Timber", "Willow Lumber", "Willow Plank", 
		"Stone Rotan Wood", "Stone Rotan Timber", "Stone Rotan Lumber", "Stone Rotan Plank", 
		"Maple Wood", "Maple Timber", "Maple Lumber", "Maple Plank", 
		"Oak Wood", "Oak Timber", "Oak Lumber", "Oak Plank", 
		"Redwood", "Redwood Timber", "Redwood Lumber", "Redwood Plank", 
		"Pine Wood", "Pine Timber", "Pine Lumber", "Pine Plank", 
		"Dragon Beard Root Wood", "Dragon Beard Root Timber", "Dragon Beard Root Lumber", "Dragon Beard Root Plank", 
		"Holly Wood", "Holly Timber", "Holly Lumber", "Holly Plank", 
		"Yew Wood", "Yew Timber", "Yew Lumber", "Yew Plank", 
		"Sagewood", "Sagewood Timber", "Sagewood Lumber", "Sagewood Plank", 
		"Tarslin Demon Wood", "Tarslin Demon Wood", "Tarslin Demon Wood", "Tarslin Demon Wood", 
		"Dragonlair Wood", "Dragonlair Wood", "Dragonlair Wood", "Dragonlair Wood", 
		"Fairywood", "Fairywood Timber", "Fairywood Lumber", "Fairywood Plank", 
		"Ancient Spirit Oak Wood", "Ancient Spirit Oak Timber", "Ancient Spirit Oak Lumber", "Ancient Spirit Oak Plank", 
		"Aeontree Wood", "Aeontree Timber", "Aeontree Lumber", "Aeontree Plank"} -- End WOODCUTTING
	}

-- This function sends one bag slot worth and/or gold to the recipient.
-- It will only send one mail at a time. This function will NOT send spam mail.
function botSendMail(_charname,_bagslot,_money)  

	-- Defaults for the arguments
	if _bagslot == 0 then _bagslot = false;end;
	if _money and _money == 0 then _money = false;end;

	-- Validate arguments
	if not _bagslot and not _money then return false;end;   --This is not a mail spammer...
	if not _charname or type(_charname) ~= "string" then	--No Recipient/Invalid Argument
		cprintf(cli.red,"ERROR:  botSendMail(_charname,_bagslot,_money) Error, invalid value for _charname!\nERROR:  Please make sure there are quotes around the character name, i.e.('_charname')\n");
		return false;
	end
	if _money and type(_money) ~= "number" then			--Can't send "dollars"
		cprintf(cli.red,"ERROR:  botSendMail(_charname,_bagslot,_money) Error, invalid value for _money!\nERROR:  Number expected, got %s\n",string.upper(type(_money)));
		return false;
	end
	
	-- Setting Local Variables
	local sendingItem = false;
	local sendingMoney = false;
	local RSString = "SendMail('".._charname.."','";			--RoMScript SendMail String
	if not RoMScript("tmpMailBody1") then						--Too many RoMScripts when sending multiple mails
		local mailBody1 = "'Hi " .. _charname .. "\\n\\nI used Ultimate Mail Mod to send this item to you.\\n\\n'";
		local mailBody2 = "'Please enjoy.\\n\\nKind regards\\n" .. player.Name .. "\\n\\nUMM v'..UMM_VERSION.Major";
		local mailBody3 = "'.'..UMM_VERSION.Minor..'.'..UMM_VERSION.Revision..' ('..UMM_VERSION.Build..')'";
		RoMScript("}igf_events.tmpMailBody1 = " .. mailBody1 .. ";a={");
		RoMScript("}igf_events.tmpMailBody2 = " .. mailBody2 .. ";a={");
		RoMScript("}igf_events.tmpMailBody3 = " .. mailBody3 .. ";a={");
	end
	
	-- Build mail
	if _bagslot and type(_bagslot) ~= "number" then				-- Find specified item
		if type(_bagslot) == "string" then
			for i=1,240,1 do if inventory.BagSlot[i].Name:lower() == _bagslot:lower() then _bagslot = i;break;end;end;
		end
		if type(_bagslot) ~= "number" and _bagslot ~= "none" then
			cprintf(cli.red,"ERROR:  Unable to find item specified.\n");
			return false;
		end
	elseif _bagslot and inventory.BagSlot[_bagslot].Empty then	-- Bagslot is empty?
		cprintf(cli.red,"ERROR:  botSendMail(_charname,_bagslot,_money) Error, _bagslot slot is empty!\nERROR:  Item expected, got %s\n",inventory.BagSlot[_bagslot].Name);
		return false;
	elseif _bagslot and type(_bagslot) == "number" then			-- Attaching Item
		inventory:update();
		if not RoMScript("IsMouseEnter();") then				-- If the mouse is holding a bag item, put it down
			inventory:update();
			for i=1,240,1 do 
				if  inventory.BagSlot[i].InUse then 
					RoMScript("PickupBagItem(" .. inventory.BagSlot[i].BagId .. ");");
				end
			end
			yrest(500);											-- Rest after putting item down
		end
		sendingItem = true;
		RoMScript("PickupBagItem("..inventory.BagSlot[_bagslot].BagId..");");yrest(200);
		RoMScript("ClickSendMailItemButton();");
	end
	if _money then												-- Attaching Money
		sendingMoney = true;
		RoMScript("SetSendMailMoney(" .. _money .. ", 0);");
	end
	if sendingMoney and not sendingItem then					-- Set subject for money only
		RSString = RSString .. "Money: " .. tostring(_money) .. "', '');";
	elseif sendingItem then										-- Set subject for item included
		RSString = RSString .. inventory.BagSlot[_bagslot].Name .. "', " .. "igf_events.tmpMailBody1 .. igf_events.tmpMailBody2 .. igf_events.tmpMailBody3);";
	end
	
	-- Output info and send mail
	cprintf(cli.yellow,"Mailing to:  %s\nSending gold:  ", _charname);
	if sendingMoney then 
		cprintf(cli.yellow,"%d",  _money);
	else 
		cprintf(cli.yellow,"0")
	end
	if sendingItem then
		cprintf(cli.yellow,"\nSending item:  %s\n", inventory.BagSlot[_bagslot].Name);
	else
		cprintf(cli.yellow,"\nSending item:  NONE\n");
	end
	RoMScript(RSString);
	return true;
end

-- This function will quickly gather all mail from your mailbox until it is completely empty.
-- WARNING:  I've only ever tested this with 120 items.  If your game is slow this might
-- cause you to lose items.  Use the argument (in miliseconds) to slow the pace (default 100 ms).
function botGetMail(_wait)
	if not _wait then _wait = 100;end;
	local mailEmpty = false;
	local mailCount = 0;
	repeat		-- Test Success, 115 items of 115 items, no item loss
		player:target_Object("Mailbox");yrest(1000);
		mailCount = RoMScript("GetInboxNumItems();");
		if mailCount == 0 then mailEmpty = true;end;
		repeat
			RoMScript("};for i=1,5,1 do TakeInboxItem(i);end;a={");yrest(1000);
			RoMScript("}for i=1,5,1 do DeleteInboxItem(i);end;a={");
			yrest(_wait);
		until tonumber(RoMScript("GetInboxNumItems();")) == 0;
		RoMScript("CloseMail();CloseWindows();");				
	until mailEmpty
end

-- This function will mail all of an item by name or specified craft materials.
-- It also defaults to "all" so it will send all crafting mats if no item is
-- specified.  You can also use "mining", "herbalism", "woodcutting", and "cook"
-- to send all mats of their kind.
function mailCraft(_charname,_craft)
	if not _charname or type(_charname) ~= "string" then
		cprintf(cli.red,"ERROR:  mailCraft(_charname,_craft) Error, invalid value for _charname!\nERROR:  Please make sure there are quotes around the character name, i.e.('_charname')\n");
		return false;
	end
	
	if not _craft or _craft:lower() == "all" then _craft = "all";end;
	
	player:target_Object("Mailbox");
	
	local function _mailcraft(_item)
		for slotNumber = 51, settings.profile.options.INV_MAX_SLOTS + 60, 1 do
			inventory:update();
			local slotitem = inventory.BagSlot[slotNumber];
			if not slotitem.Empty then
				for i,v in pairs(CRAFTMATS[_item]) do
					if slotitem.Name == CRAFTMATS[_item][i] then 
						botSendMail(_charname,slotNumber);
						break;
					end
				end
			end
		end
		return true;
	end
	
	if _craft == "all" then
		_mailcraft("ORE");
		_mailcraft("WOOD");
		_mailcraft("HERB");
		_mailcraft("COOK");
		return true;
	end
	if _craft:lower() == "mining" then
		_mailcraft("ORE");
	elseif _craft:lower() == "woodcutting" then
		_mailcraft("WOOD");
	elseif _craft:lower() == "herbalism" then
		_mailcraft("HERB");
	elseif _craft:lower() == "cooking" then
		_mailcraft("COOK");
	else
		for slotNumber = 51, settings.profile.options.INV_MAX_SLOTS + 60, 1 do
			inventory:update();
			local slotitem = inventory.BagSlot[slotNumber];
			if slotitem.Name:find(_craft) then
				botSendMail(_charname,slotNumber);
			end
		end
	end
	return true;
end
