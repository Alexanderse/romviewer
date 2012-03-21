require "socket"

CViewerLink = class(
	function (self, readTimeout)

		self.ReadTimeout = readTimeout;
		
		self.Socket = socket.udp();
		self.Socket:settimeout(readTimeout);
	end
)

function CViewerLink:send(data)
	self.Socket:setpeername(settings.profile.options.UDP_HOST, settings.profile.options.UDP_HOSTPORT)
	self.Socket:send(data);
	self.Socket:close()
end;

function CViewerLink:close()
	self.Socket:close();
end;




