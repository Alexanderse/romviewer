function LogNextToon(profile, waypoint)
	if profile == "" then profile = "UserDefault" end
	if waypoint == "" then 
		print("No waypoint defined!")
		player:sleep();
		return 
	end
	
	sendMacro("}LoginNextToon=true;a={")
	sendMacro("Logout();"); yrest(2*60*1000) -- wait 3m for next toon to load

	
	 -- Re-initialize player
	 player = CPlayer.new();
	 settings.load();
	 settings.loadProfile(profile); -- Profile name
	 yrest (4000)
	 
	 loadPaths(waypoint); -- First script
end