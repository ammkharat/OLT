
Update dbo.FunctionalLocation 
Set Deleted = 1 
where FullHierarchy like 'FE1%' And SiteID = 13

if not exists(select 1 from FunctionalLocation where SiteId = 13 and PlantId=1030 and FullHierarchy like 'FH1%')
begin
	INSERT [dbo].[FunctionalLocation] ([SiteId], [Description], [FullHierarchy], [OutOfService], [Deleted], [Level], [PlantId], [Culture], [Source]) 
	VALUES (13, N'FORT HILLS', N'FH1', 0, 0, 1, 1030, N'en', 1)
end





GO

