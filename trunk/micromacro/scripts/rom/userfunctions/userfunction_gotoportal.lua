function GoToPortal(_range)
	_range = _range or 150 -- Default value

	player:update()
	ignore = ignore or 0;
	local closestObject = nil;
	local closestDist = nil;
	local obj = nil;
	local objectList = CObjectList();
	objectList:update();

	for i = 0,objectList:size() do
		obj = objectList:getObject(i);

		if obj ~= nil  and obj.Name == "" then
			local dist = distance(player.X, player.Z, player.Y, obj.X, obj.Z, obj.Y);
			if dist <= _range then
				if( closestObject == nil ) then
					closestObject = obj;
				else
					if( dist < distance(player.X, player.Z, player.Y, closestObject.X, closestObject.Z, closestObject.Y) ) then
						-- this node is closer
						closestObject = obj;
						closestDist = dist
					end
				end
			end
		end
	end

	if closestObject then
		print("Targeting object "..closestObject.Id)
		player:target(closestObject.Address) yrest(500)
		Attack()
		return true
	else
		print("Portal not found within range of "..tostring(_range))
		return false
	end
end
