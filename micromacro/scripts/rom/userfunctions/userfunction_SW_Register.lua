function sw_StartThread()
	print("Starting thread\n");
	if (settings.profile.options.SW_REGISTER) then
		sw_CalculateStartAndEnd();
		createThread("swThread", sw_Execute);
	end;
end

function sw_CalculateStartAndEnd()
	local swstart = os.date("*t", os.time()); 
	local swend = os.date("*t", os.time()); 
	swstart.hour=settings.profile.options.SW_START_HOUR; 
	swstart.min=settings.profile.options.SW_START_MIN; 
	swstart.sec=settings.profile.options.SW_START_SEC; 

	swend.hour=settings.profile.options.SW_END_HOUR; 
	swend.min=settings.profile.options.SW_END_MIN; 
	swend.sec=settings.profile.options.SW_END_SEC; 


	
	sw_Start = os.time(swstart);
	sw_End = os.time(swend);
	
	if (((os.time() - sw_Start) > 0) and ((os.time() - sw_End) > 0)) then
		swstart.day = swstart.day + 1;
		swend.day = swstart.day;
		sw_Start = os.time(swstart);
		sw_End = os.time(swend);
	end
	
	print("Siege War registration time set to: "..tostring(os.date("%c", sw_Start)).." -> "..tostring(os.date("%c", sw_End)));
	registeringForSW = false
end

function sw_Execute()
	while(true) do
		if ((os.time() - sw_Start) > 0) then
			if ((os.time() - sw_End) < 0) then
				if (not registeringForSW) then registeringForSW = true; end

				print("sending GuildHousesWar_Register()\n");
				sendMacro("GuildHousesWar_Register()");
			else
				if (registeringForSW) then 
					registeringForSW = false; 
					--load any waypoint file specified
					
					local wp_to_load = settings.profile.options.SW_POST_REGISTER_WAYPOINT;
					
					if (not ((wp_to_load == nil) or (wp_to_load == ""))) then
						loadPaths(wp_to_load, rp_to_load);	-- load the waypoint path / return path
					end;
				end;

				--have past the time - get ready for next day
				sw_CalculateStartAndEnd();
			end
		else
			coroutine.yield();
		end;
		yrest(50);
			--print("Siege War registration time is: "..tostring(os.date(os.time(sw_Start))).." -> "..tostring(os.date(os.time(sw_End))));

	end
end;

