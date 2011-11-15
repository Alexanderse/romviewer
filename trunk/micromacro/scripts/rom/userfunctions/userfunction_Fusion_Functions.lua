--==<<               Rock5's Fusion Functions                 >>==--
--==<<             By Rock5        Version 0.2                >>==--
--==<<                                                        >>==--
--==<<   Requirements: Store already open                     >>==--
--==<<                 Fusion addon installed                 >>==--
--==<<                 enough money to buy items required     >>==--
--==<<                                                        >>==--
--==<<  www.solarstrike.net/phpBB3/viewtopic.php?f=21&t=1434  >>==--

function Fusion_NumberToBuy(_beltTierLevel)
------------------------------------------------
-- Calculates minimum number to buy for belts and
-- fusion stones to use up all your charges. Takes
-- into account number of charges and
-- mana stones you already have.
-- Accepts argument:
--    _beltTierLevel = the tier level stone the
--                     belt makes - defaults to 3
------------------------------------------------
	_beltTierLevel = _beltTierLevel or 3 -- defaults to 3

	local ht=9 -- highest tier stone to make. Fusion can only make upto tier 9 mana stones
	local wt=ht -- Current working tier level. Start at top
	local ch = RoMScript("GetMagicBoxEnergy()") -- get charges
	local buy=0 -- Number to buy

	-- Get tier stone counts
	local t={}
	for i = 2, wt do
		t[i]=inventory:getItemCount(202839+i)
	end

	while ch > 0 do
		if t[wt]>2 and ht>wt then -- go up
			ch=ch-1
			t[wt]=t[wt]-3
			wt=wt+1
			t[wt]=t[wt]+1
		elseif wt==2 then -- fuse belt
			ch=ch-1
			buy=buy+1
			t[_beltTierLevel]=t[_beltTierLevel]+1
			wt = _beltTierLevel
		else -- go down
			wt=wt-1
		end
	end
	return buy
end

function Fusion_NumberToMake(_beltTierLevel)
------------------------------------------------
-- Calculates number of each mana stones to make.
-- Takes into account the number of charges and
-- mana stones you already have. Assumes you will
-- have enough belts and Random Fusion Stones.
-- returns a table of values for fusion's boxes
-- Accepts argument:
--    _beltTierLevel = the tier level stone the
--                     belt makes - defaults to 3
-------------------------------------------------
	_beltTierLevel = _beltTierLevel or 3 -- defaults to 3

	local ht=9 -- highest tier stone to make. Fusion can only make upto tier 9 mana stones
	local wt=ht -- Current working tier level. Start at top
	local ch = RoMScript("GetMagicBoxEnergy()") -- get charges
	local make={} -- Number to make

	local t={}
	for i = 2, wt do
		t[i]=inventory:getItemCount(202839+i)-- Get tier stone counts
		make[i]=0 -- Initialise make
	end
	make.fi = 0 -- Fusion stone and item

	while ch>0 do
		if t[wt]>2 and ht>wt then -- go up
			ch=ch-1
			t[wt]=t[wt]-3
			wt=wt+1
			make[wt]=make[wt]+1
			t[wt]=t[wt]+1
		elseif wt==2 then -- fuse belt
			ch=ch-1
			make.fi=make.fi+1
			t[_beltTierLevel]=t[_beltTierLevel]+1
			wt=_beltTierLevel
		else -- go down
			wt=wt-1
		end
	end

	return make -- A table value
end

function Fusion_MakeMaxStones(_beltNameOrId, _beltTierLevel)
------------------------------------------------
-- Makes maximum mana stones taking into account
-- the number of charges and mana stones you
-- already have. Assumes you will have enough
-- belts/items and Random Fusion Stones.
-- Accepts arguments:
--    _beltNameOrId = name or id of the item to use
--                "all" uses all items, no whitelist
--                defaults to "Gold-wrapped Belt"
--    _beltTierLevel = the tier level stone the
--                     belt/item makes - defaults to 3
-------------------------------------------------
	if type(_beltNameOrId) == "number" then -- assume item id
		_beltNameOrId = RoMScript("TEXT('Sys" .. _beltNameOrId .. "_name')")
	elseif _beltNameOrId == nil then
		_beltNameOrId = RoMScript("TEXT('Sys221544_name')") -- default 'Gold-wrapped Belt'
	end
	_beltTierLevel = _beltTierLevel or 3 -- defaults to 3

	cprintf(cli.lightblue,"Making Mana stones...\n")

	-- Empty transmutor only if moveTo function exists
	-- If not, then user must find other way to empty it.
	if CItem.moveTo and inventory:itemTotalCount(0,"magicbox") < 10 then
		print("Moving items from transmutor...")
		for i = 51, 60 do
			local item = inventory.BagSlot[i]
			if not item.Empty then
				item:moveTo("bags") yrest(500)
			end
		end
		if inventory:itemTotalCount(0,"magicbox") ~= 10 then
			cprintf(cli.yellow,"Unable to clear transmutor!\n")
			return
		end
	end

	-- Setup config options
	if string.lower(_beltNameOrId) == "all" then
		Fusion_Config("Use Item Whitelist", false)
	else
		Fusion_Config("Use Item Whitelist", true)
		Fusion_Config("Set Whitelist", _beltNameOrId)
	end

	repeat
		local startcharges = RoMScript("GetMagicBoxEnergy()")
		-- Open dialogs
		print("Opening Transmutor and Fusion frames.")
		if RoMScript("AdvancedMagicBoxFrame ~= nil") then
			RoMScript("AdvancedMagicBoxFrame:Show()"); yrest(1500)
		else
			RoMScript("MagicBoxFrame:Show()"); yrest(1500)
		end
		RoMScript("FusionFrame:Show()"); yrest(1500)

		-- Set number to make
		print("Setting the number of fusion stones to make...")
		local tomake = Fusion_NumberToMake( _beltTierLevel )
		RoMScript("FusionFrameFusionNumberEditBoxFusionAndItem:SetText('"..tomake.fi.."')"); yrest(1000)
		for i = 3,9 do
			RoMScript("FusionFrameFusionNumberEditBox"..i..":SetText('"..tomake[i].."')"); yrest(1000)
		end

		-- Do
		print("Now Fusing ...")
		RoMScript("Fusion_QueueManastones(FusionFrame_Do)");

		repeat
			yrest(1500)
			displayProgressBar((startcharges - RoMScript("GetMagicBoxEnergy()"))/startcharges*100, 20)
		until RoMScript("Fusion.LastGrad")==0
		if RoMScript("GetMagicBoxEnergy()") ~= 0 then print("") end

		-- close
		print("Finished Fusing ...")
		yrest(2000)
		if RoMScript("AdvancedMagicBoxFrame ~= nil") then
			RoMScript("AdvancedMagicBoxFrame:Hide()"); yrest(500)
		else
			RoMScript("MagicBoxFrame:Hide()"); yrest(500)
		end

		local endcharges = RoMScript("GetMagicBoxEnergy()")
	until endcharges == 0 or endcharges == startcharges
end

function Fusion_Config(setting, value)
------------------------------------------------
-- Use to change values on the fusion config page
-- Usage:
--        Fusion_Config(setting, Value)
--
-- Where 'setting' is the name of the setting to
-- change and 'value' is the value to change it to.
-------------------------------------------------
	if setting == "Random Fusion Stones" then
		if type(value) == "boolean" then
			print("Setting \'Random Fusion Stones\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_RandomFusionStones:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Fusion Stones" then
		if type(value) == "boolean" then
			print("Setting \'Fusion Stones\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_FusionStones:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Purified Fusion Stones" then
		if type(value) == "boolean" then
			print("Setting \'Purified Fusion Stones\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_PurifiedFusionStones:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Use Item Whitelist" then
		if type(value) == "boolean" then
			print("Setting \'Use Item Whitelist\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_UseItemlist:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Set Whitelist" then
		if type(value) == "string" then
			print("Setting the Whitelist to " .. value .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_ItemlistEditBox:SetText(\"" .. value .. "\")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "White" then
		if type(value) == "boolean" then
			print("Setting \'White\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_White:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Green" then
		if type(value) == "boolean" then
			print("Setting \'Green\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_Green:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Blue" then
		if type(value) == "boolean" then
			print("Setting \'Blue\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_Blue:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Purple" then
		if type(value) == "boolean" then
			print("Setting \'Purple\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_Purple:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Enable ClearBag" then
		if type(value) == "boolean" then
			print("Setting \'Enable ClearBag\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_UseClearBag:SetChecked(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end
	if setting == "Speed" then
		if type(value) == "number"  and value >= 0.2 and value <= 2.0 then
			print("Setting \'Speed\' to " .. tostring(value) .. ".")
			RoMScript("FusionConfig_OnShow()"); yrest(500)
			RoMScript("FusionConfigFrame_SpeedSlider:SetValue(" .. tostring(value) .. ")"); yrest(500)
			RoMScript("FusionConfig_Save()"); yrest(500)
			return
		end
	end

	cprintf(cli.yellow,"Wrong usage of the Fusion_Config function.\n")
	print("Possible argument values are listed below;")
	print("   Fusion_Config(\"Random Fusion Stones\",true/false)")
	print("   Fusion_Config(\"Fusion Stones\",true/false)")
	print("   Fusion_Config(\"Purified Fusion Stones\",true/false)")
	print("   Fusion_Config(\"Use Item Whitelist\",true/false)")
	print("   Fusion_Config(\"Set Whitelist\",\"item1,item2\")")
	print("   Fusion_Config(\"White\",true/false)")
	print("   Fusion_Config(\"Green\",true/false)")
	print("   Fusion_Config(\"Blue\",true/false)")
	print("   Fusion_Config(\"Purple\",true/false)")
	print("   Fusion_Config(\"Enable ClearBag\",true/false)")
	print("   Fusion_Config(\"Speed\",0.2 to 2.0)")
end

function BuyItemByName(itemname, num)
------------------------------------------------
-- Buy number of items by item name
-- itemname = name of item to buy
-- num = number of items to buy
-- Store should already be open
--
-- Superceeded:
-- Users of newer versions of the bot should use
--       store:buyItem(nameIdOrIndex, quantity) or
--       inventory:storeBuyItem(nameIdOrIndex, quantity)
------------------------------------------------
    if num == nil then num = 1 end -- Assume you want to buy 1

    counter = 1
    icon, name = RoMScript("GetStoreSellItemInfo("..counter..")")
    while name do
        if string.find(name,itemname,0,"plain") then
            for i = 1, num do
                sendMacro("StoreBuyItem("..counter..")"); yrest(1200);
            end
            return true
        end
        counter = counter + 1
        icon, name = RoMScript("GetStoreSellItemInfo("..counter..")")
    end
    return false
end
