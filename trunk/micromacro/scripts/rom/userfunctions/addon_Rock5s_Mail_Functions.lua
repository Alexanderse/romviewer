--==<<          Rock5's mail related functions            >>==--
--==<<           By Rock5        Version 1.7              >>==--
--==<<                                                    >>==--
--==<<   Requirements: modified Ultimate Mail Mod addon   >>==--
--==<<                 ingamefunction addon installed     >>==--
--==<<                 mailbox to already be open         >>==--
--==<<                                                    >>==--
--==<<  www.solarstrike.net/phpBB3/viewtopic.php?p=12952  >>==--

local UMM_FromSlot = 61 -- Default 61, first slot
local UMM_ToSlot = 240 -- Default 240, last slot of bag 6

function UMM_SetSlotRange(_from, _to)
	-------------------------------
	-- Sets the range of slots to send from (61-240)

	-- Error checks
	if type(_from) ~= "number" or type(_to) ~= "number" or
	   _from > _to or _from < 61 or _to > 240 then
		error("Invalid arguments used in UMM_SetSlotRange(_from, _to). Valid values are from 61 to 240.")
	end

	UMM_FromSlot = _from
	UMM_ToSlot = _to
end

local function markToSend(_slotnumber)
	local bagid = math.floor((_slotnumber-1)/30+1)
	local slotid = _slotnumber - (bagid * 30 - 30)
	RoMScript("UMMMassSendItemsSlotTemplate_OnClick(_G['UMMFrameTab3BagsBag"..bagid.."Slot"..slotid.."'])")
end

local function openTab(_tab)
	if _tab == 1 then
		RoMScript("UMMFrameTab1:Show()") yrest(50)
		RoMScript("UMMFrameTab2:Hide()") yrest(50)
		RoMScript("UMMFrameTab3:Hide();") yrest(50)
	elseif _tab == 2 then
		RoMScript("UMMFrameTab1:Hide()") yrest(50)
		RoMScript("UMMFrameTab2:Show()") yrest(50)
		RoMScript("UMMFrameTab3:Hide();") yrest(50)
	elseif _tab == 3 then
		RoMScript("UMMFrameTab1:Hide()") yrest(50)
		RoMScript("UMMFrameTab2:Hide()") yrest(50)
		RoMScript("UMMFrameTab3:Show();") yrest(50)
	end
	yrest(1000)
end

--== Primary functions ==--
function UMM_TakeMail()
	-------------------------------
	-- Takes all mail in the inbox.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendByQuality() function.")
	end

	-- Open correct tab
	openTab(1)

	-- Check if there is mail
	repeat InboxCount = RoMScript("UMMMailManager.MailCount") until InboxCount ~= nil
	if InboxCount == 0 then -- no mail
		printf("No mail to take.\n")
		return
	end

	-- Taking mail
	repeat
		RoMScript("UMMFrameTab1Tools:ButtonClick('take');"); yrest(2000)
	until RoMScript("UMMMailManager.priv_AutoRunning") == true or RoMScript("UMMMailManager.MailCount") == 0
	repeat
		yrest(2000)
	until RoMScript("UMMMailManager.priv_AutoRunning") == nil

	printf("Mail taken.\n")

	inventory:update()
end

function UMM_SendMoney(_recipient, _amount)
	-------------------------------------
	-- Sends amount of gold to recipient.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	repeat Copper = RoMScript("GetPlayerMoney('copper')") until Copper ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendMoney() function.")
	elseif _recipient == nil or _amount == nil then
		error("You must specify a recipient and amount of gold to send when using UMM_SendMoney()")
	elseif type(_amount) ~= "number" and string.lower(_amount) ~= "all" then
		error("Argument #2 to UMM_SendMoney(): Expected type 'number' or text value 'all'.")
	end
	if string.lower(_amount) == "all" or _amount > Copper then
		_amount = Copper
	end

	printf("Sending money to ".._recipient.."...  ")

	-- Open correct tab
	openTab(2)

	-- Enter recipients name
	RoMScript("UMMFrameTab2ComposerHeaderAuthor:SetText('".._recipient.."');")

	-- Set money
	RoMScript("UMMFrameTab2ComposerFooterMoney:SetText(".._amount..");")

	-- Sending
	RoMScript("UMMFrameTab2Composer:Send()")

	printf("Money sent.\n")
end

function UMM_SendAdvanced(_recipient, _itemTable, _quality, _reqlevel, _worth, _objtype, _statNo, _dura, _amount, _stacksize, _fusedtier)
	----------------------------------
	-- Sends if all search terms match

	inventory:update()

	local function passesFilter(_slotitem)
		-- Empty, rented, Bound?
		if not _slotitem.Available or _slotitem.Empty or not bitAnd(_slotitem.BoundStatus, 1) then
			return false
		end

		-- Check name or id
		if _itemTable ~= nil then
			local match = false
			for __, nam in pairs(_itemTable) do
				if string.find(string.lower(_slotitem.Name),string.lower(nam)) or (_slotitem.Id == nam) then
					match = true
					break
				end
			end
			if match == false then
				return false
			end
		end

		-- Check Quality
		if _quality ~= nil and _slotitem.Quality < _quality then
			return false
		end

		-- Check RequiredLvl
		if _reqlevel ~= nil and _slotitem.RequiredLvl < _reqlevel then
			return false
		end

		-- Check Worth
		if _worth ~= nil and _slotitem.Worth < _worth then
			return false
		end

		-- Check ObjType
		if _objtype ~= nil then
			local match = false
			for __, typ in pairs(_objtype) do
				if _slotitem:isType(typ) then
					match = true
					break
				end
			end
			if match == false then
				return false
			end
		end

		-- Check StatNo
		if _statNo ~= nil then
			-- Not Clean?
			if _statNo == 0 and #_slotitem.Stats ~= 0 then -- not clean
				return false
			end

			-- Clean but not weapon or armor
			if _statNo == 0 and not (_slotitem.ObjType == 0 or _slotitem.ObjType == 1) then
				return false
			end

			-- Enough stats
			if _statNo > 0 and #_slotitem.Stats < _statNo then -- not enough stats
				return false
			end
		end

		-- Check Dura
		if _dura ~= nil and (_slotitem.MaxDurability or _slotitem.Durability)  < _dura then
			return false
		end

		-- Check Stacksize
		if _stacksize ~= nil then
			-- Full stack?
			if string.lower(_stacksize) == "max" and _slotitem.ItemCount ~= _stacksize then
				return false
			end

			-- Not big enough stack
			if type(_stacksize) == "number" and _slotitem.ItemCount < _stacksize then
				return false
			end
		end

		-- Check fused tier. That is what tier level mana stone the item would make.
		if _fusedtier ~= nil then
			-- Only weapons and armor can be fused
			if not (_slotitem.ObjType == 0 or _slotitem.ObjType == 1) then
				return false
			end

			-- If weapon, can't be projectile
			if _slotitem.ObjType == 0 and _slotitem.ObjSubType == 6 then
				return false
			end

			-- If weapon, can't be arrows
			if _slotitem.ObjType == 0 and _slotitem.ObjSubType == 5 and _slotitem.ObjSubSubType == 2 then
				return false
			end

			-- Calculate item level including quality
			local level = _slotitem.RequiredLvl
			if _slotitem.Quality > 0 then
				level = level + 2
			end

			if _slotitem.Quality > 1 then
				level = level + (_slotitem.Quality - 1) * 4
			end

			-- Calculate tier level
			local tier = 1
			if level >= 20 and level <= 39 then
				tier = 2
			elseif level >= 40 and level <= 59  then
				tier = 3
			elseif level >= 60 and level <= 79  then
				tier = 4
			end

			if tier < _fusedtier then
				return false
			end
		end

		return true
	end

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendAdvanced() function.")
	elseif _recipient == nil then
		error("You must specify a recipient to use UMM_SendAdvanced()")
	elseif _itemTable ~= nil and type(_itemTable) ~= "table" and type(_itemTable) ~= "number" and type(_itemTable) ~= "string" then
		error("Argument #2 to UMM_SendAdvanced(): Expected type 'table' or 'string' or 'number', got '" .. type(_itemTable) .. "'")
	elseif _quality ~= nil and type(_quality) ~= "number" then
		error("Argument #3 to UMM_SendAdvanced(): Expected type 'number', got '" .. type(_quality) .. "'")
	elseif _reqlevel ~= nil and type(_reqlevel) ~= "number" then
		error("Argument #4 to UMM_SendAdvanced(): Expected type 'number', got '" .. type(_reqlevel) .. "'")
	elseif  _worth ~= nil and type( _worth) ~= "number" then
		error("Argument #5 to UMM_SendAdvanced(): Expected type 'number', got '" .. type(_worth) .. "'")
	elseif _objtype ~= nil and type(_objtype) ~= "string" and type(_objtype) ~= "table" then
		error("Argument #6 to UMM_SendAdvanced(): Expected type 'string' or 'table', got '" .. type(_objtype) .. "'")
	elseif _statNo ~= nil and type(_statNo) ~= "number" then
		error("Argument #7 to UMM_SendAdvanced(): Expected type 'number', got '" .. type(_statNo) .. "'")
	elseif _dura ~= nil and type(_dura) ~= "number" then
		error("Argument #8 to UMM_SendAdvanced(): Expected type 'number', got '" .. type(_dura) .. "'")
	elseif _amount ~= nil and type(_amount) ~= "number" then
		error("Argument #9 to UMM_SendAdvanced(): Expected type 'number', got '" .. type(_amount) .. "'")
	elseif _stacksize ~= nil and type(_stacksize) ~= "number" and string.lower(_stacksize) ~= "max" then
		error("Argument #10 to UMM_SendAdvanced(): Expected type 'number' or string 'max', got '" .. type(_stacksize) .. "'")
	elseif _fusedtier ~= nil and type(_fusedtier) ~= "number" then
		error("Argument #11 to UMM_SendAdvanced(): Expected type 'number', got '" .. type(_fusedtier) .. "'")
	end

	-- place item in table if not already
	if type(_itemTable) == "number" or type(_itemTable) == "string" then
		_itemTable = {_itemTable}
	end

	-- place item type in table if not already
	if type(_objtype) == "string" then
		_objtype = {_objtype}
	end

	-- Make table of items to send
	local counter = 0
	local sendlist = {}
	local finished = false
	for item = UMM_FromSlot, UMM_ToSlot, 1 do -- for each inventory
		local slotitem = inventory.BagSlot[item];
		local slotNumber = slotitem.SlotNumber - 60

		if passesFilter(slotitem) then
			-- Check if split is necessary
			if _amount and (counter + slotitem.ItemCount > _amount) then -- split
				local emptyslot = inventory:findItem(0,"bags")
				if not emptyslot then
					error("Can't split stack for UMM_SendByNameOrId function. Inventory is full.")
				end

				local topickup = slotitem.ItemCount - (_amount - counter)
				RoMScript("SplitBagItem("..slotitem.BagId.." ,"..topickup..")")
				repeat yrest(500) until RoMScript("CursorHasItem()")
				RoMScript("PickupBagItem("..emptyslot.BagId..")")
				yrest(1500)
				slotitem:update()
			end

			-- Increment counter
			counter = counter + slotitem.ItemCount

			-- Add to table
			table.insert(sendlist, slotNumber)

			-- Are we finished
			if _amount and counter >= _amount then
				break
			end
		end
	end

	cprintf(cli.green,"Sending items to ".._recipient.."...  ")

	-- Check if nothing to send
	if #sendlist == 0 then
		cprintf(cli.green,"Nothing to send.\n")
		return
	end

	-- Open correct tab
	openTab(3)

	-- Selecting items
	for __, slotNumber in pairs(sendlist) do
		markToSend(slotNumber)
	end
	yrest(1000)

	-- Enter recipients name
	RoMScript("UMMFrameTab3RecipientRecipient:SetText('".._recipient.."');")

	-- Sending
	RoMScript("UMMFrameTab3Action:Send()")

	-- Waiting until finished
	repeat
		yrest(2000)
	until RoMScript("UMMFrameTab3Status:IsVisible()") == false

	cprintf(cli.green,"Items sent.\n")

	inventory:update()
end

function UMM_SendInventoryItem(_recipient, _item)
	-------------------------------------------------------
	-- Sends an inventory item by item object or slotnumber

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendItem() function.")
	elseif _recipient == nil or _item == nil then
		error("You must specify a recipient and item or slotnumber when using UMM_SendItem()")
	elseif type(_item) ~= "table" and type(_item) ~= "number" then
		error("Argument #2 to UMM_SendItem(): Expected type 'table' or 'number', got '" .. type(_itemTable) .. "'")
	elseif type(_item) == "number" and (_item < 61 or _item > 240) then
		error("UMM_SendItem() can only send items from the bags, from slot 61 to 240.")
	end

	printf("Sending inventory item to ".._recipient.."...  ")

	-- Open correct tab
	openTab(3)

	-- Select item
	local slotitem
	local slotNumber
	if type(_item) == "table" then
		slotitem = _item
		slotNumber = _item.SlotNumber - 60
	else
		slotNumber = _item - 60
		slotitem = inventory.BagSlot[_item]
	end

	if slotitem.Available and not slotitem.Empty and bitAnd(slotitem.BoundStatus, 1) then
		markToSend(slotNumber)
		yrest(1000)
	else
		printf("Nothing to send.\n")
		return
	end

	-- Enter recipients name
	RoMScript("UMMFrameTab3RecipientRecipient:SetText('".._recipient.."');")

	-- Sending
	RoMScript("UMMFrameTab3Action:Send()")

	-- Waiting until finished
	repeat
		yrest(2000)
	until RoMScript("UMMFrameTab3Status:IsVisible()") == false

	printf("Item sent.\n")

	slotitem:update()
end

function UMM_SendByRange(_recipient, _from, _to)
	------------------------------------------------------------
	-- Sends all items in inventory in the slot range specified.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendByRange() function.")
	elseif _recipient == nil then
		error("You must specify a recipient and item or slotnumber when using UMM_SendByRange()")
	elseif type(_from) ~= "number" then
		error("Argument #2 to UMM_SendByRange(): Expected type 'number', got '" .. type(_from) .. "'")
	elseif type(_to) ~= "number" then
		error("Argument #3 to UMM_SendByRange(): Expected type 'number', got '" .. type(_to) .. "'")
	elseif _from < 61 or _to > 240 or _from > _to then
		error("Invalid range used in UMM_SendByRange(). Can only send items from slot 61 to 240.")
	end

	printf("Sending item range to ".._recipient.."...  ")

	-- Open correct tab
	openTab(3)

	-- Mark items to send
	local marked = false
	for slot = _from, _to do
		local slotitem = inventory.BagSlot[slot]
		local slotNumber = slot - 60

		if slotitem.Available and not slotitem.Empty and bitAnd(slotitem.BoundStatus, 1) then
			markToSend(slotNumber)
			yrest(1000)
			marked = true
		end
	end

	-- Were any marked for sending
	if not marked then
		printf("Nothing to send.\n")
		return
	end

	-- Enter recipients name
	RoMScript("UMMFrameTab3RecipientRecipient:SetText('".._recipient.."');")

	-- Sending
	RoMScript("UMMFrameTab3Action:Send()")

	-- Waiting until finished
	repeat
		yrest(2000)
	until RoMScript("UMMFrameTab3Status:IsVisible()") == false

	printf("Items sent.\n")

	inventory:update()
end

--== Customised 'specific need' functions ==--
function UMM_SendByQuality(_recipient, _quality)
	----------------------------------------
	-- Sends bag items by quality or higher.
	-- 1 = green, 2 = blue, 3 = purple, etc.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendByQuality() function.")
	elseif _recipient == nil then
		error("You must specify a recipient to use UMM_SendByQuality()")
	elseif type(_quality) ~= "number" then
		error("Argument #2 to UMM_SendByQuality(): Expected type 'number', got '" .. type(_quality) .. "'")
	elseif _quality < 0 or _quality > 5 then
		error("Incorrect quality level specified. Valid levels are 0 to 5, where 0 = white, 1 = green, etc.")
	end

	printf("Sending items by quality.\n")

	-- Sending items
	UMM_SendAdvanced(_recipient, nil, _quality)
end

function UMM_SendByStatNumber(_recipient, _statNo)
	--------------------------------------
	-- Sends bag items by number of stats.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendByStatNumber() function.")
	elseif _recipient == nil then
		error("You must specify a recipient when using UMM_SendByStatNumber()")
	end

	if type(_statNo) ~= "number" or _statNo < 0 or _statNo > 6 then
		_statNo = 3     -- Default value if value invalid
	end

	printf("Sending items by stat number.\n")

	-- Sending items
	UMM_SendAdvanced(_recipient, nil, nil, nil, nil, nil, _statNo)
end

function UMM_SendByNameOrId(_recipient, _itemTable, _amount)
	---------------------------------
	-- Sends bag items by name or id.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendByNameOrId() function.")
	elseif _recipient == nil or _itemTable == nil then
		error("You must specify a recipient and item table when using UMM_SendByNameOrId()")
	elseif type(_itemTable) ~= "table" and type(_itemTable) ~= "number" and type(_itemTable) ~= "string" then
		error("Argument #2 to UMM_SendByNameOrId(): Expected type 'table' or 'string' or 'number', got '" .. type(_itemTable) .. "'")
	elseif _amount and type(_amount) ~= "number" then
		error("Argument #3 to UMM_SendByNameOrId(): Expected type 'number' or 'nil', got '" .. type(_amount) .. "'")
	end

	-- place item in table if not already
	if type(_itemTable) == "number" or type(_itemTable) == "string" then
		_itemTable = {_itemTable}
	end

	printf("Sending items by name or id.\n")

	-- Sending items
	UMM_SendAdvanced(_recipient, _itemTable, nil, nil, nil, nil, nil, nil, _amount)
end

function UMM_SendByDura(_recipient, _dura, _statNo, _objtype)
	----------------------------------
	-- Sends items by dura and statno.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendByDura() function.")
	elseif _recipient == nil or _dura == nil then
		error("You must specify a recipient and dura level when using UMM_SendByDura()")
	elseif type(_dura) ~= "number" then
		error("Argument #2 to UMM_SendByDura(): Expected type 'number', got '" .. type(_dura) .. "'")
	elseif _statNo ~= nil and type(_statNo) ~= "number" then
		error("Argument #3 to UMM_SendByDura(): Expected type 'number', got '" .. type(_statNo) .. "'")
	elseif _objtype ~= nil and type(_objtype) ~= "string" and type(_objtype) ~= "table" then
		error("Argument #4 to UMM_SendByDura(): Expected type 'string' or 'table', got '" .. type(_objtype) .. "'")
	end

	printf("Sending items by dura.\n")

	-- Sending items
	UMM_SendAdvanced(_recipient, nil, nil, nil, nil, _objtype, _statNo, _dura)
end

function UMM_SendByStackSize(_recipient, _itemTable, _stacksize)
	---------------------------------
	-- Sends bag items by stack size.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendByStackSize() function.")
	elseif _recipient == nil or _itemTable == nil or _stacksize == nil then
		error("You must specify a recipient, item table and stack size when using UMM_SendByStackSize()")
	elseif type(_itemTable) ~= "table" and type(_itemTable) ~= "number" and type(_itemTable) ~= "string" then
		error("Argument #2 to UMM_SendByStackSize(): Expected type 'table' or 'string' or 'number', got '" .. type(_itemTable) .. "'")
	elseif type(_stacksize) ~= "number" and string.lower(_stacksize) ~= "max" then
		error("Argument #3 to UMM_SendByStackSize(): Expected type 'number' or string 'max', got '" .. type(_stacksize) .. "'")
	end

	-- place item in table if not already
	if type(_itemTable) == "number" or type(_itemTable) == "string" then
		_itemTable = {_itemTable}
	end

	printf("Sending items by stack size.\n")

	-- Sending items
	UMM_SendAdvanced(_recipient, _itemTable, nil, nil, nil, nil, nil, nil, nil, _stacksize)
end

function UMM_SendByFusedTierLevel(_recipient, _fusedtier)
	---------------------------------
	-- Sends bag items by fused tier.

	-- Error checks
	repeat UMMOpen = RoMScript("UMMFrame:IsVisible()") until UMMOpen ~= nil
	if UMMOpen ~= true then
		error("The UMM mail interface needs to be open first before using the UMM_SendByFusedTierLevel() function.")
	elseif _recipient == nil or _fusedtier == nil then
		error("You must specify a recipient and fused tier when using UMM_SendByFusedTierLevel()")
	elseif type(_fusedtier) ~= "number" then
		error("Argument #2 to UMM_SendByFusedTierLevel(): Expected type 'number', got '" .. type(_fusedtier) .. "'")
	end

	printf("Sending items by fused tier.\n")

	-- Sending items
	UMM_SendAdvanced(_recipient, nil, nil, nil, nil, nil, nil, nil, nil, nil, _fusedtier)
end
