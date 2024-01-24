IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonDTOByCompletenessAndGroupAndDateWithinRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonDTOByCompletenessAndGroupAndDateWithinRange
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonDTOByCompletenessAndGroupAndDateWithinRange
    (
		@CompletionStatusIds varchar(max),
		@GroupId bigint,
		@QueryDate DateTime
    )
AS

SELECT
    pr.*,
	wpeg.[Name] as GroupName,
    FunctionalLocation.FullHierarchy as FunctionalLocationName,
    LastModifiedByUser.LastName AS LastModifiedByLastName,
    LastModifiedByUser.FirstName AS LastModifiedByFirstName,
    LastModifiedByUser.UserName AS LastModifiedByUserName,
    LastImportedByUser.LastName AS LastImportedByLastName,
    LastImportedByUser.FirstName AS LastImportedByFirstName,
    LastImportedByUser.UserName AS LastImportedByUserName,
    LastSubmittedByUser.LastName AS LastSubmittedByLastName,
    LastSubmittedByUser.FirstName AS LastSubmittedByFirstName,
    LastSubmittedByUser.UserName AS LastSubmittedByUserName,
	al.Name AS AreaLabelName
FROM PermitRequestEdmonton pr
INNER JOIN IDSplitter(@CompletionStatusIds) Ids ON Ids.Id = pr.CompletionStatusId
INNER JOIN FunctionalLocation FunctionalLocation ON pr.FunctionalLocationId = FunctionalLocation.Id
INNER JOIN [User] LastModifiedByUser ON pr.LastModifiedByUserId = LastModifiedByUser.Id
INNER JOIN WorkPermitEdmontonGroup wpeg ON pr.GroupId = wpeg.Id
LEFT OUTER JOIN [User] LastImportedByUser ON pr.LastImportedByUserId = LastImportedByUser.Id
LEFT OUTER JOIN [User] LastSubmittedByUser ON pr.LastSubmittedByUserId = LastSubmittedByUser.Id
LEFT OUTER JOIN AreaLabel al ON al.Id = pr.AreaLabelId
WHERE
pr.[GroupId] = @GroupId AND
pr.Deleted = 0 AND
pr.RequestedStartDate <= @QueryDate AND
@QueryDate <= pr.EndDate


GRANT EXEC ON QueryPermitRequestEdmontonDTOByCompletenessAndGroupAndDateWithinRange TO PUBLIC
GO