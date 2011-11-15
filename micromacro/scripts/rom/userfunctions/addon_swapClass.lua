------------------------------------------------
-- Change Class/equip
-- raff & jduartedj
-- v2.1
------------------------------------------------
function swapClass(npc, choice,slot_nr,macro_name)

	--if slot_nr is provided it creates a macro in slot_nr that opens the dialog/swaps Class/swaps equip. you only have to select the housemaid
	if slot_nr then 
		reads, __,__,__ = readMacro(slot_nr); --check if empty macro
		if reads == nil or reads=="" then
			macroNum=slot_nr; 
			if macro_name then 
				name=macro_name;
			else
				name="Swap"
			end
			if hotkey then 
				actionkey = hotkey; 
			else
				actionkey = _G.key.VK_NUMPAD0;
			end
			body = "/cast Attack\n/script ChoiceOption(\"3\")\n/wait 1\n/script ExchangeClass(EXCHANGECLASS_SUBCLASS, EXCHANGECLASS_MAINCLASS); SwapEquipmentItem();"
			writeToMacro(macroNum, body, name, math.random(1,60))
			-- hehe it chooses a diff icon everytime!
			-- setActionKeyToMacro(actionkey, macroNum) TODO
		end
	end
	
	if npc then
		player:target_NPC(npc);yrest(1000) --assumes NPC already targeted if none is provided
	end
	if choice then
		sendMacro("ChoiceOption("..choice..");");yrest(1000);
	else
		sendMacro("ChoiceOption(\"3\");");yrest(1000); -- defaults to 3 (housemaids)
	end
	sendMacro("ExchangeClass(EXCHANGECLASS_SUBCLASS, EXCHANGECLASS_MAINCLASS)");
	sendMacro("SwapEquipmentItem();");
	player:update();
    setupMacros();
end