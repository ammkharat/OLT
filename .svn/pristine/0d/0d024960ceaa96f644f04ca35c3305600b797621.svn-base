IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VDenverLogs')
BEGIN
	DROP VIEW VDenverLogs
END
GO

CREATE VIEW [dbo].[VDenverLogs] WITH SCHEMABINDING
AS
SELECT 
  l.LogDateTime, 
  l.PlainTextComments as Comment,
  f.FullHierarchy, 
  u.Lastname + ', ' + u.Firstname as [User],
  ta.TargetDefinitionID as [TargetDefinitionId],
  Tag.[Name] as TagName,
  l.Id as LogId, -- for internal use so that indexing may be done on view
  f.Id as FlocId -- for internal use so that indexing may be done on view
FROM 
  [dbo].[Log] AS l 
  INNER JOIN [dbo].LogFunctionalLocation AS lfl ON lfl.LogId = l.Id 
  INNER JOIN [dbo].FunctionalLocation AS f ON f.Id = lfl.FunctionalLocationId 
  INNER JOIN [dbo].[User] AS u ON u.Id = l.LastModifiedUserId 
  LEFT OUTER JOIN dbo.LogTargetAlertAssociation ON dbo.LogTargetAlertAssociation.LogId = l.Id
  LEFT OUTER JOIN dbo.TargetAlert ta ON dbo.LogTargetAlertAssociation.TargetAlertId = ta.Id
  LEFT OUTER JOIN dbo.Tag ON ta.TagID = dbo.Tag.Id
WHERE 
  f.SiteId = 2
  AND l.LogType = 1
  AND l.Deleted = 0
GO