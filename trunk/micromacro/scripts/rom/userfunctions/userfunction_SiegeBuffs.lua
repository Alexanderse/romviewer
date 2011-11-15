function SiegeBuffs()
	while(true) do
		local objectList = CObjectList()
		objectList:update()
		local objSize = objectList:size()

		for i = 0,objSize do
			local obj = objectList:getObject(i)
			local distance = distance(player.X, player.Z, obj.X ,obj.Z)
			
			if player.Y >= (obj.Y - 10) and obj.Y >= (player.Y - 10) and 50 > distance then
				player:target(obj)
				player:update();
				
				if (player:haveTarget() ~= nil) then
					player:update();
					
					local target = player:getTarget()
					
					target:update()
					target:updateBuffs()

					player:checkSkills(true)
					player:checkPotions()
				end
			end
		end
	end
end