--=== 								===--
--===    Original done by Tsutomu 	===--
--=== Version 1.5 patch 4.0.4.2456	===--
--=== 		Updated by lisa			===--
--=== 								===--

--===  								===--
--===  swimfunction_ptr = 0x44E230	===--
--===  charPtr_offset = 0x598		===--
--===  skillbuffFlag_offset = 0xF0	===--
--===  swim_offset = 0xB4			===--
--===  								===--

local swimfunction_ptr = 0x44E240
local offsets = {0x598, 0xF0, 0xB4}
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
