ALTER TABLE dbo.FunctionalLocation DROP COLUMN Division;
ALTER TABLE dbo.FunctionalLocation DROP COLUMN [Section];

IF EXISTS (select * from sys.[stats] where name = 'Floc_Id_UnitId')
	BEGIN
		DROP STATISTICS [dbo].[FunctionalLocation].[Floc_Id_UnitId];
	END

ALTER TABLE dbo.FunctionalLocation DROP COLUMN Unit;

ALTER TABLE dbo.FunctionalLocation DROP COLUMN Equipment1;
ALTER TABLE dbo.FunctionalLocation DROP COLUMN Equipment2;
GO

