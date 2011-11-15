------------------------------------------------
-- Use food/pots/items and check for its buff with table support
-- JDuarteDJ & Giram
-- Version 3.1
------------------------------------------------

-- I suggest we use the buff effect as name in every pot/food
-- like 'speed' instead of 'unbrindledenthusiasm'
-- also replaced potID with just ID, not all are pots :P

-- jump has 1 minute cd so it now pauses script for min it it tries to jump many times.
local itemTable

function useGoodie(_itemName,_buffName) --ofc I came up with a silly name
	itemTable = itemTable or {
         --potions
			--lvl 1+
		 giant = {ID = 207199, buffName = 506683, castTime = 0}, -- Fullness(tested r5)
		 speed = {ID = 207200, buffName = 506684, castTime = 0}, -- Unbridled Enthusiasm (tested r5)
         frog = {ID = 207201, buffName = 506685, castTime = 1500}, -- Princely Look (tested r5)
			--lvl 31+
		 casting = {ID = 207202, buffName = 506686, castTime = 0}, -- Clear Thought (tested r5)
			--lvl 41+
		 luck = {ID = 207203, buffName = 506687, castTime = 0}, --Turn of Luck Powder Dust (tested r5)
			--lvl 51+
		 riding = {ID = 207204, buffName = 506688, castTime = 1000}, --Galloping Gale  (tested r5)
			--lvl 61+
		 jump = {ID = 207205, buffName = "", castTime = 3000}, --crazy breakout (tested)
			--lvl 71+
		 defense = {ID = 207206, buffName = 495644, castTime = 2500}, --Scarlet Love (506690 = gmatch error)
			--lvl 81+
		 agro = {ID = 207207, buffName = 495645, castTime = 1000}, --Pungent Vileness 506691 (some wait time but no cast time, tested)
			--lvl 91+
		 godspeed = {ID = 207208, buffName = 495646, castTime = 0}, --Godspeed. Instant cast. 1 min CD. (tested)

		 --foods
			--lvl 1-20
		 pdmg = {ID = 207209, buffName = 506673, castTime = 0}, -- Housekeeper Special Salted Fish with Sauce (tested r5)
		 mdmg = {ID = 207210, buffName = 506674, castTime = 0}, -- 501132, 506674. Housekeeper Special Smoked Bacon with Herbs (tested r5)
			--lvl 21-40
		 critp = {ID = 207211, buffName = 506675, castTime = 0}, -- 501138, 506675. Housekeeper Special Caviar Sandwich (tested r5)
		 matt = {ID = 207212, buffName = 506676, castTime = 0}, -- 501143, 506676. Housekeeper Special Deluxe Seafood (tested r5)
			--lvl 41-80
		 patt2 = {ID = 207213, buffName = 495631, castTime = 0}, -- Housekeeper Special Spicy Meatsauce Burrito (tested)
		 mdmg2 = {ID = 207214, buffName = 495632, castTime = 0}, -- Housekeeper Special Delicious Swamp Mix (tested)
			--lvl 81-100
         patt3 = {ID = 207215, buffName = 495633, castTime = 0}, -- 506679. Housekeeper Special Unimaginable Salad (checked)
         matt3 = {ID = 207216, buffName = 495634, castTime = 0} -- 501145, 506680. Housekeeper Special Cheese Fishcake
		}

	local option = itemTable[_itemName]
	if not option then
		option = {}
		if not _buffName then
			option.buffName = _itemName --Assume  both have same name like in mounts
		else
			option.buffName = _buffName
		end
		option.ID = _itemName --luckily the inventory functions use Name Or ID
		option.castTime = 0
	end

	-- If still id, change to name
	if type(option.buffName) == "number" then
		option.buffName = GetIdName(option.buffName) or RoMScript("TEXT('Sys"..option.buffName.."_name')")
	end

	-- Check if failed to get name
	if type(option.buffName) ~= "string" or string.match(option.buffName,"Sys%d%d%d%d%d%d-name") then
		print("Failed to get buff name for ".._itemName)
		return
	end

	if inventory:itemTotalCount(option.ID,"all") >= 1 and not player:hasBuff(option.buffName) then

		inventory:useItem(option.ID);

		cprintf(cli.yellow,"Used " .._itemName.. ".\n",_itemName)

		if option.castTime > 0 then
			yrest(option.castTime);
		end

		inventory:update();
		yrest(800);

	end
end
