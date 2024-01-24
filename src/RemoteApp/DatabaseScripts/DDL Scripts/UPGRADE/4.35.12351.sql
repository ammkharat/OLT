if not exists(select 1 from [Shift] where SiteId = 19 and Name='Night')
begin
	INSERT INTO dbo.[Shift] 
	VALUES 
	('Night','2016-03-08 10:21:14.363',19,'18:00:00','06:00:00')
end




GO

