-- temporarily add view back in for just this update, then remove it
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VSummaryLogRelationships]'))
BEGIN
	DROP VIEW [dbo].[VSummaryLogRelationships]
END
GO

CREATE VIEW [dbo].[VSummaryLogRelationships] WITH SCHEMABINDING
AS

	With ParentLogs(SummaryLogId, ChildLogCount)
	AS
	(
		SELECT 
			ReplyToLogId, 
			COUNT(*) 
		FROM 
			[dbo].[SummaryLog]
		WHERE 
			ReplyToLogId IS NOT NULL
			AND
			[SummaryLog].[Deleted] = 0

		GROUP BY ReplyToLogId 
	)
	
	SELECT 
		[SummaryLog].Id, ReplyToLogId AS ParentLogId, 
			 COALESCE(ParentLogs.ChildLogCount, 0) AS ChildLogCount
	FROM 
		[dbo].[SummaryLog]
		LEFT OUTER JOIN ParentLogs ON [SummaryLog].Id = ParentLogs.SummaryLogId
GO
		
IF ObjectProperty(object_id('VSummaryLogRelationships'),'IsIndexable') = 1
BEGIN
	CREATE UNIQUE CLUSTERED INDEX IDX_VSummaryLogRelationships ON VSummaryLogRelationships(Id)
END

ALTER TABLE [dbo].[SummaryLog] ADD [HasChildren] bit NULL;
GO

-- set 'is parent log' to false first
UPDATE 
  [dbo].[SummaryLog]
SET
  HasChildren = 0

-- set 'is parent log' to true for those that do have children
UPDATE l
SET
  l.HasChildren = 1
FROM
  [dbo].[SummaryLog] l
  INNER JOIN dbo.VSummaryLogRelationships v On v.Id = l.Id
WHERE
  v.ChildLogCount > 0
GO

ALTER TABLE [dbo].[SummaryLog] ALTER COLUMN [HasChildren] bit NOT NULL;
GO

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VSummaryLogRelationships]'))
BEGIN
	DROP VIEW [dbo].[VSummaryLogRelationships]
END
GO


GO

