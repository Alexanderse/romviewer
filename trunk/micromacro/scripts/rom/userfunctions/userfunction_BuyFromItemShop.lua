------------------------------------------------------------------
--  Rock5's BuyFromItemShop userfunction
--               Version 1.0
--
--  Syntax:
--  BuyFromItemShop(itemGUID, secondaryPassword [, number] )
--
--  Arguments:
--    itemGUID (type number) - The uniquie id of the shop selection. See below for instructions on how to get this value.
--    secondaryPassword (type string) - Your secondary password for that account
--    number (type number) - The number you want to buy of that selection. Optional. If not specified will, buy only one.
--
--  Example:
--    To buy 2 '10 Arcane Transmutor Charges' with Phirius Coins
--       BuyFromItemShop(96, "secpass', 2)
--
--  How to get 'itemGUID':
--    1. Open the Item Shop.
--    2. Find the item you want to buy. Make sure it's the right item. I take no responsability if your make a mistake.
--    3. Select the 'Buy' button so that the 'Buy' popup appears.
--    4. Now enter this command,
--         /script SendSystemChat(ItemMallFrame.selectItem.GUID)
--    5. The number it prints is the 'itemGUID' of the item you want to buy.


function BuyFromItemShop(_itemGUID, _secondaryPassword, _number )
	if type(_itemGUID) ~=  "number" then
		print("You must use the Item Shop itemGUID number when using the BuyFromItemShop function.")
		return
	end

	if _number == nil then
		_number = 1
	end

	if _secondaryPassword == nil then
		print("You must specify a secondary password for the 'BuyFromItemShop' function to work.")
		return
	end

	RoMScript("CheckPasswordState(); StaticPopup1EditBox:ClearFocus()")
	yrest(1000)
	if RoMScript("StaticPopup1:IsVisible()") then
		RoMScript("StaticPopup1EditBox:SetText(\"".._secondaryPassword.."\")") rest(1000)
		RoMScript("StaticPopup_EnterPressed(StaticPopup1);") yrest(1000)
		RoMScript("StaticPopup1:Hide();");
	end
	RoMScript("ItemMallFrame.lock=1") yrest(500)
	RoMScript("CIMF_ShoppingBuy(".._itemGUID.." ,".._number..")"); yrest(500) -- buy items
	RoMScript("ItemMall_LockUpdate(ItemMallFrame);")
end
