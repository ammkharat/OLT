IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDefinitionDTOsByFLOCIDs')
    BEGIN
        DROP PROCEDURE [dbo].QueryLabAlertDefinitionDTOsByFLOCIDs
    END
GO

CREATE Procedure [dbo].QueryLabAlertDefinitionDTOsByFLOCIDs
    (
        @IDs varchar(MAX),
		@FromDate DateTime,
		@ToDate DateTime
    )
AS

SELECT
    LabAlertDefinition.Id,
    LabAlertDefinition.Name,
    LabAlertDefinition.LabAlertDefinitionStatusID,
    LabAlertDefinition.IsActive,
    LabAlertDefinition.Description,
	LabAlertDefinition.LastModifiedByUserId,
    LastModifiedByUser.LastName as LastModifiedLastName,
    LastModifiedByUser.FirstName as LastModifiedFirstName,
    LastModifiedByUser.UserName as LastModifiedUserName,
    FunctionalLocation.FullHierarchy as FunctionalLocationName,
    T.Name as TagName
FROM
    LabAlertDefinition LabAlertDefinition
    INNER JOIN FunctionalLocation FunctionalLocation ON LabAlertDefinition.FunctionalLocationID = FunctionalLocation.Id
    INNER JOIN Tag T ON LabAlertDefinition.TagID = T.Id
    INNER JOIN [User] LastModifiedByUser ON LabAlertDefinition.LastModifiedByUserId = LastModifiedByUser.Id 
WHERE
	LabAlertDefinition.CreatedDateTime <= @ToDate AND 
	LabAlertDefinition.CreatedDateTime >= @FromDate AND
    LabAlertDefinition.Deleted = 0 AND
	EXISTS
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
		where 
			Relationship.AncestorId = LabAlertDefinition.FunctionalLocationId
		UNION ALL
		-- definition floc is descendent of query floc
		select Relationship.Id 
		from FunctionalLocationAncestor Relationship
		inner join IDSplitter(@IDs) QueryIds on Relationship.AncestorId = QueryIds.Id
		where Relationship.Id = LabAlertDefinition.FunctionalLocationId
	)
OPTION (OPTIMIZE FOR UNKNOWN)		
GO

GRANT EXEC ON [QueryLabAlertDefinitionDTOsByFLOCIDs] TO PUBLIC
GO