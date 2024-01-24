-- Part 1: add the display order column

alter table WorkPermitMontrealDropdownValue add DisplayOrder int null;
go

-- Part 2: set the display orders


declare KeyCursor cursor for 
select distinct [Key]
from WorkPermitMontrealDropdownValue;

open KeyCursor;

declare @AKey as varchar(100);
fetch next from KeyCursor into @AKey;

while @@FETCH_STATUS = 0
begin
	
	DECLARE @counter int
	SET @counter = -1
	UPDATE WorkPermitMontrealDropdownValue
	SET @counter = DisplayOrder = @counter + 1
	WHERE [Key] = @AKey;
	
	fetch next from KeyCursor into @AKey;
end

close KeyCursor;
deallocate KeyCursor;

go

-- Part 3: set the display order column to be non-nullable

alter table WorkPermitMontrealDropdownValue alter column DisplayOrder int not null;
go




GO

