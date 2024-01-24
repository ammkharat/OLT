IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDTOsByFLOCIDs')
    BEGIN
        DROP PROCEDURE [dbo].QueryLabAlertDTOsByFLOCIDs
    END
GO

CREATE Procedure [dbo].QueryLabAlertDTOsByFLOCIDs
    (
        @IDs varchar(MAX),
		@FromDate DateTime,
		@ToDate DateTime,
		@StatusIds varchar(MAX) = null
    )
AS

SELECT
    LabAlert.Id,
    LabAlert.LabAlertStatusID,
    LabAlert.Name,
	LabAlert.MinimumNumberOfSamples,
	LabAlert.ActualNumberOfSamples,
	LabAlert.CreatedDateTime,	
	LabAlert.LastModifiedByUserId,
    FunctionalLocation.FullHierarchy as FunctionalLocationName,
    T.Name as TagName
FROM
    LabAlert LabAlert
    INNER JOIN FunctionalLocation FunctionalLocation ON LabAlert.FunctionalLocationID = FunctionalLocation.Id
    INNER JOIN Tag T ON LabAlert.TagID = T.Id
WHERE
	LabAlert.CreatedDateTime <= @ToDate AND 
	LabAlert.CreatedDateTime >= @FromDate AND
	(	
		@StatusIds is null or 
		exists
		(
			select Status.Id 
			from IDSplitter(@StatusIds) Status 
			where Status.Id = LabAlert.LabAlertStatusId
		)
	) AND EXISTS
	(
		-- definition floc is equal to query floc
		SELECT Id 
		FROM IDSplitter(@Ids) 
		WHERE Id = FunctionalLocation.Id
		UNION ALL
		-- definition floc is ancestor of query floc
		select Relationship.Id 
		from FunctionalLocationAncestor Relationship
		inner join IDSplitter(@IDs) QueryIds on Relationship.Id = QueryIds.Id
		where Relationship.AncestorId = LabAlert.FunctionalLocationId
		UNION ALL
		-- definition floc is descendent of query floc
		select Relationship.Id 
		from FunctionalLocationAncestor Relationship
		inner join IDSplitter(@IDs) QueryIds on Relationship.AncestorId = QueryIds.Id
		where Relationship.Id = LabAlert.FunctionalLocationId
	)
OPTION (OPTIMIZE FOR UNKNOWN)		
GO

GRANT EXEC ON QueryLabAlertDTOsByFLOCIDs TO PUBLIC
GO