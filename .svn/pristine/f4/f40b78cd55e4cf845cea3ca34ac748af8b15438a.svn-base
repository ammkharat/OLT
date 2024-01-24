declare @sqlDropConstraint NVARCHAR(1000)
select 
@sqlDropConstraint = 'ALTER TABLE ' + tbl.[name] + ' DROP CONSTRAINT ' + idx.[name]
from sys.indexes idx 
inner join sys.tables tbl on idx.object_id = tbl.object_id 
where idx.[type] <> 0 and
        tbl.[name] = 'VisibilityGroup' 
        and idx.[name] like 'UQ__%'
exec sp_executeSql @sqlDropConstraint

ALTER TABLE [dbo].[VisibilityGroup] ADD [Deleted] bit NULL
GO
UPDATE 
	[dbo].[VisibilityGroup]
SET
	DELETED = 0
GO
ALTER TABLE [dbo].[VisibilityGroup] ALTER COLUMN [Deleted] bit NOT NULL
GO


GO

