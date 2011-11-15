local function roundIt(_number)
	if _number > (math.floor(_number) + 0.5) then
		return math.ceil(_number);
	else
		return math.floor(_number);
	end
end

local function fixString(_string,_length)
	_string = _string:sub(1,_length);
	xTra = _length-_string:len();
	if xTra > 0 then
		for i=1,xTra do
		_string = _string .. " ";
		end
	end
	return _string;
end

--Basic object list iteration
function displayObjects()
	local objectList = CObjectList();
	objectList:update();
	local objSize = objectList:size();
	cprintf(cli.yellow,"X\tZ\tY\tTYPE Name                     Id     Atkble Address\n")
	cprintf(cli.yellow,"-\t-\t-\t---- ----                     --     ------ -------\n")
	local lncolor,obj;
	for i = 0,objSize do 
		obj = objectList:getObject(i);
		if (i == 0) or ((i / 2) == (math.floor(i/2))) then
			_lncolor = cli.lightgray;
		else
			_lncolor = cli.white;
		end
		cprintf(_lncolor,"%d",roundIt(obj.X));
		cprintf(_lncolor,"\t%d",roundIt(obj.Z));
		cprintf(_lncolor,"\t%d",roundIt(obj.Y));
		cprintf(_lncolor,"\t%s",fixString(tostring(obj.TYPE),5));
		cprintf(_lncolor,"%s",fixString(obj.Name,24));
		cprintf(_lncolor," %s",fixString(tostring(obj.Id),7));
		cprintf(_lncolor,"%s",fixString(tostring(obj.Attackable),7));
		cprintf(_lncolor,"%x\n",obj.Address);
	end
end
