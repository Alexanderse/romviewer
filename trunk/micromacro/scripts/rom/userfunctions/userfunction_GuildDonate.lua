-- =============================================
-- Joint effort by the solarstrike/rom dev team.
-- =============================================


function GuildDonate(_type, _quality, _lesser)
	inventory:update()
if ( _type == nil and _quality == nil and _lesser == nil ) then 
	_lesser = "true"
	_type = "all"
	_quality = 5
	end



-- argument fool proofing
if ( _type == "white" or _type == "green" or _type == "blue" or _type == "purple" ) then _quality = _type end

-- _lesser if "true" then lesser qualities will be donated, otherwise only specified quality will be donated.

-- for _quality use names "white", "green", "blue", "purple", "orange", "gold".


			if _quality == "green" then _quality = 1 end
			if _quality == "blue" then _quality = 2  end
			if _quality == "purple" then _quality = 3 end
			if _quality == "orange" then _quality = 4 end
			if _quality == "gold" then _quality = 5  end
			if type(_quality) ~= "number" then _quality = 0 end

			if _type == "wood" or _type == "woods" then _type = "Wood" end
			if _type == "ore" or _type == "ores" then _type = "Ores" end
			if _type == "herb" or _type == "herbs" then _type = "Herbs" end
         		if _type ~= "Herbs" and _type ~= "Wood" and _type ~= "Ores" then _type = "all" end


for slot, item in pairs(inventory.BagSlot) do


		if ( _type == "all" and (item:isType("Ores") or item:isType("Herbs") or item:isType("Wood")) ) or 
			( _type ~= "all" and item:isType(_type) ) then

		if  _lesser == "true"  then -- Donates quality stated and lesser

		if _quality >= item.Quality then

			RoMScript("PickupBagItem("..item.BagId..")")
         		RoMScript("GCB_GetContributionItem(n)")
         	if RoMScript("CursorHasItem()") then
            		RoMScript("PickupBagItem("..item.BagId..")")            -- Put it back in the bag
         	else
            		RoMScript("GCB_OnOK()")
         	end
printf("Donating " .. item.Name .. "\n")

		end

		elseif _quality == item.Quality then
			RoMScript("PickupBagItem("..item.BagId..")")
			RoMScript("GCB_GetContributionItem(n)")
         	if RoMScript("CursorHasItem()") then
            		RoMScript("PickupBagItem("..item.BagId..")") -- Put it back in the bag
         	else
            		RoMScript("GCB_OnOK()")
         	end
printf("Donating " .. item.Name .. "\n")


		end
		end

end
end