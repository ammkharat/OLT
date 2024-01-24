-- temporarily add view back in for just this update, then remove it
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VLogRelationships]'))
BEGIN
	DROP VIEW [dbo].[VLogRelationships]
END
GO

CREATE VIEW [dbo].[VLogRelationships] WITH SCHEMABINDING
AS

	With ParentLogs(LogId, ChildLogCount)
	AS
	(
		SELECT 
			replytologid, 
			COUNT(*) 
		FROM 
			[dbo].[LOG]
		WHERE 
			replytologid IS NOT NULL
			AND
			[log].[Deleted] = 0

		GROUP BY replytologid 
	)
	
	SELECT 
		[LOG].Id, replytologid AS ParentLogId, 
			 COALESCE(ParentLogs.ChildLogCount, 0) AS ChildLogCount
	FROM 
		[dbo].[log]
		LEFT OUTER JOIN ParentLogs ON [Log].Id = ParentLogs.LogId
GO
		
IF ObjectProperty(object_id('VLogRelationships'),'IsIndexable') = 1
BEGIN
	CREATE UNIQUE CLUSTERED INDEX IDX_VLogRelationships ON VLogRelationships(Id)
END

ALTER TABLE [dbo].[Log] ADD [HasChildren] bit NULL;
GO

-- set 'is parent log' to false first
UPDATE 
  [dbo].[Log]
SET
  HasChildren = 0

-- set 'is parent log' to true for those that do have children
UPDATE l
SET
  l.HasChildren = 1
FROM
  [dbo].[Log] l
  INNER JOIN dbo.VLogRelationships v On v.Id = l.Id
WHERE
  v.ChildLogCount > 0
GO

ALTER TABLE [dbo].[Log] ALTER COLUMN [HasChildren] bit NOT NULL;
GO

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VLogRelationships]'))
BEGIN
	DROP VIEW [dbo].[VLogRelationships]
END
GO



GO

