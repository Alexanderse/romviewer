
function Renumber(waypt_file)

	if waypt_file == nil then
		printf("No file name. Usage Renumber(\"YourWaypointFile\")\nDo not the path or extension.\nThis script creates a renumbered copy.\n\n");
		return false
	end

	local filenameIn = getExecutionPath() .. "/waypoints/" .. waypt_file .. ".xml";
	local filenameOut = getExecutionPath() .. "/waypoints/" .. waypt_file .. "_renum.xml";
	local fileIn, err = io.open(filenameIn, "r");
	local fileOut, err = io.open(filenameOut, "w+");

	local newNumString = "";
	local padding = "";
	local startVal1 = 0;
	local startVal2 = 0;
	local endVal1 = 0;
	local endVal2 = 0;
	local line = "";
	local lineNumber = 1;
	local replCount = 0;
	
	if fileIn and fileOut then
		for line in fileIn:lines() do 
			startVal1, endVal1 = string.find(line, "<!-- #", 1, true);
			if startVal1 ~= nil then
				startVal2, endVal2 = string.find(line, "-->", 1, true);
				newNumString = "<!-- #"
				if lineNumber < 10 then 
					padding = "  "
				elseif lineNumber < 100 then
					padding = " "
				else
					padding = ""
				end
				newNumString = newNumString .. padding .. lineNumber .. " -->";
				line = string.sub(line, 1, startVal1-1) .. newNumString .. string.sub(line, endVal2 + 1, -1)
				lineNumber = lineNumber + 1;
			end
			fileOut:write(line .. "\n");
		end
	else
		printf("Couldn't open/create the files. Usage Renumber(\"YourWaypointFile\")\nDo not the path or extension.\nThis script creates a renumbered copy.\n\n");
		return false
	end
	
	fileIn:close();
	fileOut:close();
	printf("Done. New file is " .. waypt_file .. "_renum.xml\n");
end