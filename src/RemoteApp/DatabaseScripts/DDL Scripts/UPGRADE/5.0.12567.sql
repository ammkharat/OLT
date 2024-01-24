Declare @numInserts int = 1
 while @numInserts <= 20
 begin
	if not exists(select 1 from WorkAssignment where name ='Dummy WA For Action Item' and siteid = @numInserts)
	begin
	if exists(select role.id from role where ActiveDirectoryKey = 'Administrator' and siteid = @numInserts)
		begin
			insert into WorkAssignment values('Dummy WA For Action Item','Dummy WA For Action Item',@numInserts,0,(select top 1 role.Id from role where ActiveDirectoryKey = 'Administrator' and siteid = @numInserts),'',1,1,null,0,0)
		end
	end
	set @numInserts = @numInserts + 1
 end


 if not exists(select 1 from WorkAssignment where name = 'Dummy WA For Action Item' and siteid = 9)
begin
	insert into WorkAssignment values('Dummy WA For Action Item','Dummy WA For Action Item',9,0,111,'',1,1,null,0,0)
end







GO

