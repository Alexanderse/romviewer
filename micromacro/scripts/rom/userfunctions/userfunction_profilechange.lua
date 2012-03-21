function changeOptionFriendMob(_type,_name,_addremove)
--examples	changeOptionFriendMob("mob", "Wolf", "Add")
--examples	changeOptionFriendMob("friend", "Hokeypokey", "Remove")

	if _name == nil or _name == "" then
	printf("Need to specify name.\n")
	end

	if _addremove == nil then _addremove = "add" end
	 addremove = string.lower(_addremove)

	if addremove ~= "add" and addremove ~= "remove" then
	printf("Wrong usage of arg#2, _addremove")
	end

	if( _name ) then name = trim(_name); 
	end;
	if _type == "friend" then 
		if addremove == "add" then 
			table.insert(settings.profile.friends, name);
			for k,v in ipairs(settings.profile.friends) do
				printf(k.." "..v.."\n")
			end
		end

		if addremove == "remove" then 
			for k,v in ipairs(settings.profile.friends) do
				if v == name then
				table.remove(settings.profile.friends,k);
				printf("Removing friend "..v.."\n")
				end
				printf(k.." "..v.."\n")
			end
		end
	end
	if _type == "mob" then 
		if addremove == "add" then 
			table.insert(settings.profile.mobs, name);
			for k,v in ipairs(settings.profile.mobs) do
				printf(k.." "..v.."\n")
			end
		end

		if addremove == "remove" then 
			for k,v in ipairs(settings.profile.mobs) do
				if v == name then
				table.remove(settings.profile.mobs,k);
				printf("Removing friend "..v.."\n")
				end
				printf(k.." "..v.."\n")
			end
		end
	end

end