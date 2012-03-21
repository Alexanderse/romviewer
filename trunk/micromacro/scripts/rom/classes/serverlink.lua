require "socket"

CServerLink = class(
	function (self, server, port, readTimeout)
		self.Server = server or settings.profile.options.SERVER_NAME;
		self.Port = port or tonumber(settings.profile.options.SERVER_PORT);
		self.ReadTimeout = readTimeout or 5;
		
		self.Socket = socket.tcp();
		self.Socket:settimeout(readTimeout);
		self.Socket:connect(self.Server, self.Port);
	end
)

function CServerLink:send(data, waitForResult)
	self.Socket:send(data);
	--printf("serverlink:send->"..data.."\n");
	if ((waitForResult) and (waitForResult == true)) then
		local data = "";
		local sIn = self.Socket:receive(1);
		while (sIn ~= "\0") do
			if (sIn) then data = data..sIn; end;
			sIn = self.Socket:receive(1);
		end;
		--printf(data.."\n");	
		return data;
	end;
--	self.Socket:close();
end;

function CServerLink:close()
	self.Socket:close();
end;




