IF not EXISTS (
	SELECT * from FunctionalLocation 
	where siteid = 3 and  DESCRIPTION LIKE 'Regional Planning & Optimization'
)
begin
	UPDATE FunctionalLocation
	SET description = 'Regional Planning & Optimization'
	where siteid = 3 and fullhierarchy like 'PL%'and DESCRIPTION LIKE 'Planning and Logistics'

end
go
-------------------------------
IF not EXISTS (
	select * from FunctionalLocation 
	where siteid = 3 and fullhierarchy like 'RPO%'
)
begin
	update FunctionalLocation 
	set fullhierarchy = replace( fullhierarchy, 'PL1', 'RPO') 
	where siteid = 3 and fullhierarchy like 'PL%'

end
go
-------------------------------
IF not EXISTS (
	select * from WorkAssignment 
	where name like 'RPO%' and siteid = 3
)
begin
	UPDATE dbo.WorkAssignment
	SET name =replace( NAME, 'P&L', 'RPO'),DESCRIPTION =replace( DESCRIPTION, 'P&L', 'RPO'), category=replace( category, 'P&L', 'RPO')
	where name like 'P&L%' and siteid = 3
end
go
------------------------------
IF not EXISTS (
	select *  from role 
	where name like 'RPO%' and siteid = 3
)
begin
	update role 
	set NAME= replace( NAME, 'P&L', 'RPO') 
	where name like 'P&L%' and siteid = 3
end
go




GO

