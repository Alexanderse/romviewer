-- Rock5's PlusItem function
-- version 0.02

function PlusBagItem(_slot, _level, _jewel)
	inventory:update()
	local item = inventory.BagSlot[_slot]
	local byte = memoryReadByte(getProc(),item.Address+0x17)
	local plusLevel =(bitAnd(byte,0x1) and 1 or 0)+(bitAnd(byte,0x2) and 2 or 0)+(bitAnd(byte,0x4) and 4 or 0)+(bitAnd(byte,0x8) and 8 or 0)
	while plusLevel < _level do
		-- check jewels
		if inventory:itemTotalCount(_jewel) == 0 then
			-- try to buy one
			store:update()
			if store:buyItem(_jewel) == false then
				print("Out of jewels and can't buy any.")
				return
			end
			yrest(500)
		end

		RoMScript("UseItemByName(\"".._jewel.."\"); PickupBagItem(GetBagItemInfo(".. (_slot - 60) .."))")
		yrest(500)

		repeat
			yrest(100)
			player:update()
		until not player.Casting
		yrest(500)
		byte = memoryReadByte(getProc(),item.Address+0x17)
		plusLevel =(bitAnd(byte,0x1) and 1 or 0)+(bitAnd(byte,0x2) and 2 or 0)+(bitAnd(byte,0x4) and 4 or 0)+(bitAnd(byte,0x8) and 8 or 0)
	end
	print("Completed plusing.")
end
