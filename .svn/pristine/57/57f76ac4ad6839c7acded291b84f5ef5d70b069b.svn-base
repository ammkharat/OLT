UPDATE WorkAssignment 
SET
  [Name] = 'TDS ' + [Name],
  Description = 'TDS ' + Description
where siteid = 6

UPDATE ActionItemDefinitionAutoReApprovalConfiguration
SET
  DocumentLinksChange = 0
WHERE SiteId = 6

INSERT INTO DocumentRootPathConfiguration
(
   [PathName]
  ,UncPath
  ,Deleted
) VALUES (
   'TDS Documents'  -- PathName - varchar(50)
  ,'\\file026\EDD'  -- UncPath - varchar(200)
  ,0   -- Deleted - bit
)

INSERT INTO DocumentRootPathFunctionalLocation
(
   DocumentRootPathId
  ,FunctionalLocationId
) SELECT 
   IDENT_CURRENT('DocumentRootPathConfiguration'),
   Id From FunctionalLocation where SiteId = 6 and [Level] = 2 and FullHierarchy like 'OS1-%'



GO

