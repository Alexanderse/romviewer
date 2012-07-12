-- 0 = white / 1 = green / 2 = blue / 3 = purple / 4 = orange / 5 = gold

function CleanBag(sellprize, rarity, _types)
	inventory:update();
		
	if sellprize == nil then sellprize = 750 end
	if rarity == nil then rarity = 2 end
	if _types == nil then _types = { "Weapons", "Armor", "Recipes" }; end;
	
	local typeSet = {};
	for k,v in pairs(_types) do
		typeSet[v]=true;
	end;
	
	for i, item in pairs(inventory.BagSlot) do
		if item.SlotNumber >= settings.profile.options.INV_AUTOSELL_FROMSLOT + 60 and
		settings.profile.options.INV_AUTOSELL_TOSLOT + 60 >= item.SlotNumber then
			
			local itemtype, itemsubtype, itemsubsubtype, objsubsubuniquetype = item:getTypes();
			local isType = ((typeSet[itemtype] == true) or (typeSet[itemsubtype] == true) or (typeSet[itemsubsubtype] == true) or (typeSet[objsubsubuniquetype] == true));
			
			if (isType and sellprize > item.Worth and item.Quality < rarity) then
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

function CleanBagMatch(_names)
	if (_names == nil) then
		printf("CleanBagMatch requires the names parameter to be set\n");
		return;
	end;
	
	inventory:update();
	
	for k,v in pairs(_names) do
		_names[k]=string.lower(v);
	end;

	for i, item in pairs(inventory.BagSlot) do
		if item.SlotNumber >= settings.profile.options.INV_AUTOSELL_FROMSLOT + 60 and
		settings.profile.options.INV_AUTOSELL_TOSLOT + 60 >= item.SlotNumber then

			local match = false;
			local itemName = string.lower(item.Name);
			--printf(""..tostring(itemName).."\n");
			for l,j in pairs(_names) do
				--printf("\t\tcomparing to: "..tostring(j).."\n");
				if (string.find(itemName, j)) then match = true; break; end;
			end;
			
			--printf("\t\t"..tostring(match).."\n");

			if (match == true) then
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