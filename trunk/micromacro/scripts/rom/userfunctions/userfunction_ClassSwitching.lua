local classNameMap = 
{
[CLASS_WARRIOR] = "Warrior",
[CLASS_SCOUT] = "Scout",
[CLASS_ROGUE] = "Rogue",
[CLASS_MAGE] = "Mage",
[CLASS_PRIEST] = "Priest",
[CLASS_KNIGHT] = "Knight",
[CLASS_WARDEN] = "Warden",
[CLASS_DRUID] = "Druid"
}

--classChanger = 117291;
--choice=4;

function SwitchClass(npc, option, class1, class2, profilename)
	printf("SwitchClass("..tostring(npc)..", ChoiceOption("..tostring(option).."), "..tostring(class1)..", "..tostring(class2)..", "..profilename..")\n");
	
	player:target_NPC(npc);
	ChoiceOptionByName("switch");
	--sendMacro("ChoiceOption("..tostring(option)..")");
	yrest(200);
	RoMScript("ExchangeClass("..tostring(class1+1)..","..tostring(class2+1)..")");
	yrest(300);
	loadProfile(profilename);
end;

function SwapPrimaryAndSecondary(npc, option)
	player:update();
	local classPrimary = player.Class1;
	local classSecondary = player.Class2;
	local profilename = player.Name..classNameMap[player.Class2]..classNameMap[player.Class1];
	
	SwitchClass(npc, option, classSecondary, classPrimary, profilename);
end;

