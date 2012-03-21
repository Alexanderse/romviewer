--==<<            Rock5'scatchCavy function               >>==--
--==<<           By Rock5        Version 1.02             >>==--
--==<<                                                    >>==--
--==<<  www.solarstrike.net/phpBB3/viewtopic.php?p=12979  >>==--

function catchCavy(_cavy)

	local hpper = 50 -- Players hp percent threshhold to give-up catching the cavy
	_cavy = _cavy or 103567 -- Default value "Golden Magic Cavy"
	if string.lower(_cavy) == "cavy" then -- Look for all cavies
		_cavy = {103566,103567}
	end

	local cavy = player:findNearestNameOrId(_cavy, player.IgnoreCavy)

	if not cavy then return end -- No cavy, return

	yrest(200); -- Make sure you've come to a complete stop.
	player:update()

	-- Don't catch cavy if still battling.
	if player.Battling  and
		player:findEnemy(true, nil, evalTargetDefault) then
		return
	end

	local function CalcNewPos(_trap, _cavy, _player)
		--it takes time for the player to move, so we need to make sure the player moves further if they are futher away as the cavy would have moved too.
		local HerdDist = 50 -- distance to herd cavy
		local TrapCavyDist = distance(_trap.X, _trap.Z, _cavy.X, _cavy.Z)
		local Ratio = (TrapCavyDist + HerdDist) / TrapCavyDist
		local x = (_cavy.X - _trap.X) * Ratio + _trap.X + ((_cavy.X - _player.X) / 2)
		local z = (_cavy.Z - _trap.Z) * Ratio + _trap.Z + ((_cavy.Z - _player.Z) / 2)
		local NewPos = CWaypoint(x, z)
		
		NewPos.Type = 4 -- Travel
		return NewPos
	end

	if cavy and inventory:useItem(206776) then -- Huntsman's Trap
		cprintf(cli.yellow,"\a\aAttempting to catch cavy...\n")
		yrest(3000)
		player:update()
		trap = {X = player.X, Z = player.Z}

		while true do
			cavy:update()
			if cavy.Id == 0 then break end -- cavy is gone
			if ((cavy.X >= 0) and (cavy.X < 1)) then break end -- cavy gone
			if distance(cavy.X, cavy.Z, trap.X, trap.Z ) < 8 then -- cavy is in trap
				printf("Cavy is in trap\n")
				local tgt = CWaypoint(trap.X, trap.Z)
				cprintf(cli.red,"Moving to("..tostring(tgt.X)..","..tostring(tgt.Z)..")...\n")
				player:moveTo(tgt, true)
				memoryWriteInt(getProc(), player.Address + addresses.pawnTargetPtr_offset, cavy.Address);
				RoMScript("UseSkill(1,1)"); yrest(50); RoMScript("UseSkill(1,1)"); -- 'click' again to be sure
				yrest(2000);
				break
			end
			if player.Battling and (100*player.HP/player.MaxHP) < hpper then -- taking too much damage. fight
				player.IgnoreCavy = cavy.Address
				break
			end

			NewPos = CalcNewPos(trap, cavy, player)
			player:moveTo(NewPos, true)
			yrest(100)
			player:update()
		end
	end
end
