-- 0 = white / 1 = green / 2 = blue / 3 = purple / 4 = orange / 5 = gold

function CleanBag(sellprize, rarity)
	inventory:update();
	
	if sellprize == nil then sellprize = 750 end
	if rarity == nil then rarity = 2 end
	
	for i, item in pairs(inventory.BagSlot) do
		if item.SlotNumber >= settings.profile.options.INV_AUTOSELL_FROMSLOT + 60 and
		settings.profile.options.INV_AUTOSELL_TOSLOT + 60 >= item.SlotNumber then
			if (item:isType("Weapons") or item:isType("Armor")) and sellprize > item.Worth and item.Quality < rarity then
				printf("Deleting Item:  "..item.Name.." [$"..tostring(item.Worth).." : "..tostring(item.Quality).."]\n");
				item:delete()
				local filename = getExecutionPath() .. "/logs/CleanBag.log";
				local file, err = io.open(filename, "a+");
				if file then
					file:write(" Deleted: " ..item.Name.. ". [$"..tostring(item.Worth).." : "..tostring(item.Quality).."] \tDate: " .. os.date() .. ".\n")
					file:close();
				end
			end
		end
	end
end