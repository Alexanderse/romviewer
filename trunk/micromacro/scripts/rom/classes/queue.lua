CQueue = class(
	function(self, _debug)
		self.Debug = _debug or false;
		self.List = {first = 0, last = -1};
	end
)

function CQueue:isEmpty()
	if (self.Debug) then printf("q: first="..tostring(self.List.first)..", last="..tostring(self.List.last).."\n"); end;
	return (self.List.first > self.List.last);
end;

function CQueue:count()
	return (self.List.last - self.List.first)+1;
end;

function CQueue:push(item)
	if (item) then
		if (self.Debug) then printf("q: pushing "..tostring(item).."\n"); end;
		  local last = self.List.last + 1
		if (self.Debug) then printf("q: old last "..tostring(last-1).."->"..tostring(last).."\n"); end;
		  self.List.last = last
		  self.List[last] = item
		if (self.Debug) then printf("q: self.List["..tostring(last).."] = "..tostring(self.List[last]).."\n"); end;
	end;
end;

function CQueue:pop()
	local first = self.List.first
	if (self.Debug) then printf("q: popping "..tostring(first).."\n"); end;
	if first > self.List.last then error("list is empty") end
	local value = self.List[first]
	if (self.Debug) then printf("popping: value "..tostring(value).."\n"); end;
	self.List[first] = nil        -- to allow garbage collection
	self.List.first = first + 1
	if (self.Debug) then printf("q: new first "..tostring(first+1).."\n"); end;
	return value
end;

function CQueue:peek()
  local first = self.List.first
  if first > self.List.last then error("list is empty") end
  local value = self.List[first]
  return value
end	



