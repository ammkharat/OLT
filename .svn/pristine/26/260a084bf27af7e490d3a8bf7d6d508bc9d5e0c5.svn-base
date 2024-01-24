IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VOilSandsSummaryLogs')
BEGIN
	DROP VIEW VOilSandsSummaryLogs
END
GO

CREATE VIEW [dbo].[VOilSandsSummaryLogs] WITH SCHEMABINDING
AS

SELECT	sl.id as [SummaryLog-Id], 
		sl.LogDateTime as [SummaryLog-Date],  		
		'General Comments' as [Comment-Category-Name], 
		3 as [Comment-Category-Id], 
		sl.PlainTextComments as [Comment-Text], 
		sl.DorComments as [Comment-DorText], 
		f.id as [Floc-Id], 
		f.description as [Floc-Description], 
		f.fullhierarchy as [Floc-Full-Hierarchy],
    COALESCE(f2.FullHierarchy, f.FullHierarchy) as [Floc-Level-2]
from 
	dbo.SummaryLog sl	
	INNER JOIN dbo.SummaryLogFunctionalLocation slfl 
    ON slfl.summarylogid = sl.id
	INNER JOIN dbo.FunctionalLocation f 
    ON f.id = slfl.functionallocationid
  LEFT OUTER JOIN dbo.FunctionalLocationAncestor A2
    ON A2.Id = f.Id and A2.AncestorLevel = 2
  LEFT OUTER JOIN dbo.FunctionalLocation f2 
    ON A2.AncestorId = f2.Id
	WHERE 
	sl.Deleted = 0 AND
    f.SiteId = 3 AND
		(f.FullHierarchy LIKE 'UP1%'  or 
		f.FullHierarchy LIKE 'UP2%' or 
		f.FullHierarchy LIKE 'EX1%' or 
		f.FullHierarchy LIKE 'EU1%')
GO

