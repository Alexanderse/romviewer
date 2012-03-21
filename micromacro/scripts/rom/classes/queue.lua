CQueue = class(
	function(self)
		self.List = {first = 0, last = -1};
	end
)

function CQueue:isEmpty()
	return (self.List.first > self.List.last);
end;

function CQueue:count()
	return (self.List.last - self.List.first);
end;

function CQueue:push(item)
	if (item) then
		--printf("q: pushing "..tostring(item).."\n");
		  local last = self.List.last + 1
		--printf("q: old last "..tostring(last-1).."->"..tostring(last).."\n");
		  self.List.last = last
		  self.List[last] = item
		--printf("q: self.List["..tostring(last).."] = "..tostring(self.List[last]).."\n");
	end;
end;

function CQueue:pop()
	local first = self.List.first
	--printf("q: popping "..tostring(first).."\n");
	if first > self.List.last then error("list is empty") end
	local value = self.List[first]
	--printf("popping: value "..tostring(value).."\n");
	self.List[first] = nil        -- to allow garbage collection
	self.List.first = first + 1
	--printf("q: new first "..tostring(first+1).."\n");
	return value
end;

function CQueue:peek()
  local first = self.List.first
  if first > self.List.last then error("list is empty") end
  local value = self.List[first]
  return value
end	



