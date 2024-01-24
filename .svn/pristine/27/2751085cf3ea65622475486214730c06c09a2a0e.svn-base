IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionDefinitionDTOsByFLOCIDs')
    BEGIN
        DROP PROCEDURE [dbo].QueryRestrictionDefinitionDTOsByFLOCIDs
    END
GO

CREATE Procedure [dbo].QueryRestrictionDefinitionDTOsByFLOCIDs
    (
        @IDs varchar(MAX),
		@FromDate DateTime,
		@ToDate DateTime
    )
AS

SELECT
    RestrictionDefinition.Id,
    RestrictionDefinition.Name,
    RestrictionDefinition.RestrictionDefinitionStatusID,
    RestrictionDefinition.IsActive,
    RestrictionDefinition.IsOnlyVisibleOnReports,
    RestrictionDefinition.[Description],
    RestrictionDefinition.ProductionTargetValue,
	RestrictionDefinition.LastModifiedUserId,
    LastModifiedUser.LastName as LastModifiedLastName,
    LastModifiedUser.FirstName as LastModifiedFirstName,
    LastModifiedUser.UserName as LastModifiedUserName,
    FunctionalLocation.FullHierarchy as FunctionalLocationName,
    MeasurementTag.Name as MeasurementTagName,
    ProductionTargetTag.Name as ProductionTargetTagName
    
    ,RestrictionDefinition.HourFrequency     --DMND0010124 mangesh 
FROM
    RestrictionDefinition RestrictionDefinition
    INNER JOIN FunctionalLocation FunctionalLocation ON RestrictionDefinition.FunctionalLocationID = FunctionalLocation.Id
    INNER JOIN Tag MeasurementTag ON RestrictionDefinition.MeasurementTagID = MeasurementTag.Id
    LEFT OUTER JOIN Tag ProductionTargetTag ON RestrictionDefinition.ProductionTargetTagID = ProductionTargetTag.Id
    INNER JOIN [User] LastModifiedUser ON RestrictionDefinition.LastModifiedUserId = LastModifiedUser.Id 
WHERE
	EXISTS
	(
		-- Floc of restriction def'n matches one of the passed in flocs
		select ids.Id
		from IDSplitter(@Ids) ids
		where ids.Id = FunctionalLocation.Id
		
		UNION ALL
		
		-- Floc of restriction def'n is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ids.Id
		from FunctionalLocationAncestor a
		inner join IDSplitter(@Ids) ids on ids.Id = a.AncestorId
		where a.Id = FunctionalLocation.Id
	) AND
	(RestrictionDefinition.CreatedDateTime is null or (RestrictionDefinition.CreatedDateTime <= @ToDate AND RestrictionDefinition.CreatedDateTime >= @FromDate)) AND
    RestrictionDefinition.Deleted = 0
ORDER BY FunctionalLocationID
OPTION (OPTIMIZE FOR UNKNOWN)	  
GO

GRANT EXEC ON [QueryRestrictionDefinitionDTOsByFLOCIDs] TO PUBLIC
GO