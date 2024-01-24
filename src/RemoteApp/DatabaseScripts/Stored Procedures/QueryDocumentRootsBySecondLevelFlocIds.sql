IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentRootsBySecondLevelFlocIds')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentRootsBySecondLevelFlocIds
	END
GO

CREATE Procedure [dbo].QueryDocumentRootsBySecondLevelFlocIds
    (
        @CsvFLOCIds VARCHAR(MAX)
    )
AS

SELECT 
  Id, PathName, UncPath
FROM
  dbo.DocumentRootPathConfiguration dr
WHERE 
  dr.Deleted = 0
  AND EXISTS
  (
	-- Document Root is associated with Second Level Floc
	select 
		QueryIds.Id
	from 
		IDSplitter(@CsvFLOCIds) QueryIds
		inner join DocumentRootPathFunctionalLocation drfloc 
			on drfloc.FunctionalLocationId = QueryIds.Id
    where
      drfloc.DocumentRootPathId = dr.Id
	UNION ALL
	-- Document Root is associated with a First Level Floc
	select 
		QueryIds.Id
	from 
		IDSplitter(@CsvFLOCIds) QueryIds
		inner join FunctionalLocation floc 
			on floc.Id = QueryIds.Id
		inner join FunctionalLocationAncestor a 
			ON Floc.Id = a.Id and (a.AncestorLevel + 1) = floc.[Level]
		inner join DocumentRootPathFunctionalLocation drfloc 
			on drfloc.FunctionalLocationId = a.AncestorId 
    WHERE
    	drfloc.DocumentRootPathId = dr.Id
        and floc.[Level] = 2
	)
OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON [QueryDocumentRootsBySecondLevelFlocIds] TO PUBLIC
GO

