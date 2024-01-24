IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonHazardDTOByFlocIdsAndStatusIds')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonHazardDTOByFlocIdsAndStatusIds
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonHazardDTOByFlocIdsAndStatusIds
    (
		@FlocIds varchar(max),
		@StatusIds varchar(max)
    )
AS

SELECT
wp.Id,
wp.DataSourceId,
wp.WorkPermitStatusId,
wp.IssuedDateTime,
wp.TaskDescription,
wp.HazardsAndOrRequirements,
wp.Occupation,
cu.LastName as CreatedByLastName,
cu.FirstName as CreatedByFirstName,
cu.UserName as CreatedByUserName
FROM
WorkPermitEdmonton wp
INNER JOIN FunctionalLocation fl ON fl.Id = wp.FunctionalLocationId
INNER JOIN IdSplitter(@StatusIds) Ids ON Ids.Id = wp.WorkPermitStatusId
LEFT OUTER JOIN [User] cu ON wp.CreatedByUserId = cu.Id
WHERE
	wp.Deleted = 0 AND
	(
		EXISTS
		(
			-- Floc of permit matches one of the passed in flocs
			select ids.Id
			from IDSplitter(@FlocIds) ids
			where ids.Id = fl.Id
		)
		OR EXISTS
		(
			-- Floc of permit is child of one of the passed in flocs (look down the floc tree from my selected flocs)
			select ids.Id
			from FunctionalLocationAncestor a
			inner join IDSplitter(@FlocIds) ids on ids.Id = a.AncestorId
			where a.Id = fl.Id
		)
		OR EXISTS
		(
			-- Floc of permit is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
			select a.Id from FunctionalLocationAncestor a
			INNER JOIN IDSplitter(@FlocIds) ids ON ids.Id = a.Id
			WHERE a.AncestorId = fl.Id  
		)
	)
OPTION (OPTIMIZE FOR UNKNOWN)	      	

GRANT EXEC ON QueryWorkPermitEdmontonHazardDTOByFlocIdsAndStatusIds TO PUBLIC
GO