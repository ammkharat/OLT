IF NOT EXISTS(SELECT * FROM sys.stats WHERE NAME = 'Floc_Id_UnitId')
BEGIN
	CREATE STATISTICS [Floc_Id_UnitId] ON [dbo].[FunctionalLocation]([Id], [Unit])
END
GO
