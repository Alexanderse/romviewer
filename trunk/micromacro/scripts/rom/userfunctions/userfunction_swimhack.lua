--=== 								===--
--===    Original done by Tsutomu 	===--
--=== 		Updated by lisa			===--
--=== 								===--
--===  charPtr_offset = 0x598		===--
--===  skillbuffFlag_offset = 0xF0	===--
--===  swim_offset = 0xB4			===--
--===  								===--

local offsets = {addresses.charPtr_offset, addresses.pawnSwim_offset1, addresses.pawnSwim_offset2}
local swimfunction_ptr = addresses.swimAddress
local active = 4

function fly()
	memoryWriteString(getProc(), swimfunction_ptr, string.char(0x90, 0x90, 0x90, 0x90, 0x90, 0x90));
	memoryWriteIntPtr(getProc(), addresses.staticbase_char, offsets, active);
	printf("Swimhack ACTIVATED!\n");
end

function flyoff()
	memoryWriteString(getProc(), swimfunction_ptr, string.char(0x89, 0x83, 0xB4, 0x0, 0x0, 0x0));
	printf("Swimhack DEactivated.\n");
end
