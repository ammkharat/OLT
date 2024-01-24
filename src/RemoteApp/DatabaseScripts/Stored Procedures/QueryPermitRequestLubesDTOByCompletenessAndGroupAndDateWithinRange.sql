IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestLubesDTOByCompletenessAndGroupAndDateWithinRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestLubesDTOByCompletenessAndGroupAndDateWithinRange
    END
GO

CREATE Procedure [dbo].QueryPermitRequestLubesDTOByCompletenessAndGroupAndDateWithinRange
    (
		@CompletionStatusIds varchar(max),
		@GroupId bigint,
		@QueryDate DateTime
    )
AS

SELECT
    pr.*,
	wplg.[Name] as GroupName,
    FunctionalLocation.FullHierarchy as FunctionalLocationName,
    LastModifiedByUser.LastName AS LastModifiedByLastName,
    LastModifiedByUser.FirstName AS LastModifiedByFirstName,
    LastModifiedByUser.UserName AS LastModifiedByUserName,
    LastImportedByUser.LastName AS LastImportedByLastName,
    LastImportedByUser.FirstName AS LastImportedByFirstName,
    LastImportedByUser.UserName AS LastImportedByUserName,
    LastSubmittedByUser.LastName AS LastSubmittedByLastName,
    LastSubmittedByUser.FirstName AS LastSubmittedByFirstName,
    LastSubmittedByUser.UserName AS LastSubmittedByUserName
FROM PermitRequestLubes pr
INNER JOIN IDSplitter(@CompletionStatusIds) Ids ON Ids.Id = pr.CompletionStatusId
INNER JOIN FunctionalLocation FunctionalLocation ON pr.FunctionalLocationId = FunctionalLocation.Id
INNER JOIN [User] LastModifiedByUser ON pr.LastModifiedByUserId = LastModifiedByUser.Id
INNER JOIN WorkPermitLubesGroup wplg ON pr.RequestedByGroupId = wplg.Id
LEFT OUTER JOIN [User] LastImportedByUser ON pr.LastImportedByUserId = LastImportedByUser.Id
LEFT OUTER JOIN [User] LastSubmittedByUser ON pr.LastSubmittedByUserId = LastSubmittedByUser.Id
WHERE
pr.RequestedByGroupId = @GroupId AND
pr.Deleted = 0 AND
pr.RequestedStartDate <= @QueryDate AND
@QueryDate <= pr.EndDate


GRANT EXEC ON QueryPermitRequestLubesDTOByCompletenessAndGroupAndDateWithinRange TO PUBLIC
GO