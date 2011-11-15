	-----------------------------------------------------------
	--------------- MiesterMan's Waypoint Finder --------------
	-----------------------------------------------------------

local function roundIt(_number)
	if _number > (math.floor(_number) + 0.5) then
		return math.ceil(_number);
	else
		return math.floor(_number);
	end
end

local function newWPSub(_x, _z, _y)
	return "\n<!-- #000 --><waypoint x=\"" .. _x .. "\" z=\"" .. _z .. "\" y=\"" .. _y .. "\">player:harvest();</waypoint>\n";
end

function findWP()
	player:update();
	local _X = roundIt(player.X);
	local _Z = roundIt(player.Z);
	local _Y = roundIt(player.Y);
	
	print(newWPSub(_X,_Z,_Y));
end