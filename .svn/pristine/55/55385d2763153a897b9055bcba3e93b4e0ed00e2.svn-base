IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonDTOByFormGN59Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonDTOByFormGN59Id
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonDTOByFormGN59Id
    (
		@FormGN59Id bigint
    )
AS

SELECT
wp.Id,
wp.DataSourceId,
wp.WorkPermitStatusId,
wp.WorkPermitTypeId,
wp.RequestedStartDateTime,
wp.IssuedDateTime,
wp.ExpiredDateTime,
wp.PermitNumber,
wp.WorkOrderNumber,
fl.FullHierarchy,
wp.TaskDescription,
wp.Occupation,
wpeg.Name as GroupName,
wp.CreatedDateTime,
wp.CreatedByUserId,
wp.LastModifiedDateTime,
wp.LastModifiedByUserId,

lmu.LastName as LastModifiedByLastName,
lmu.FirstName as LastModifiedByFirstName,
lmu.UserName as LastModifiedByUserName,

permitRequestCreatedByUser.LastName as PermitRequestCreatedByLastName,
permitRequestCreatedByUser.FirstName as PermitRequestCreatedByFirstName,
permitRequestCreatedByUser.UserName as PermitRequestCreatedByUserName,

issuedByUser.LastName as IssuedByLastName,
issuedByUser.FirstName as IssuedByFirstName,
issuedByUser.UserName as IssuedByUserName,

wp.Company,
wped.PermitAcceptor,
wp.PriorityId,
al.Name AS AreaLabelName
FROM
	WorkPermitEdmonton wp
	INNER JOIN FunctionalLocation fl ON fl.Id = wp.FunctionalLocationId
	INNER JOIN WorkPermitEdmontonDetails wped ON wped.WorkPermitEdmontonId = wp.Id
	LEFT OUTER JOIN WorkPermitEdmontonGroup wpeg on wpeg.Id = wp.GroupId
	LEFT OUTER JOIN [User] lmu ON wp.LastModifiedByUserId = lmu.Id
	LEFT OUTER JOIN [User] permitRequestCreatedByUser ON wp.PermitRequestCreatedByUserId = permitRequestCreatedByUser.Id
	LEFT OUTER JOIN [User] issuedByUser ON wp.IssuedByUserId = issuedByUser.Id
	LEFT OUTER JOIN AreaLabel al on al.Id = wp.AreaLabelId
WHERE
	wped.FormGN59Id = @FormGN59Id AND
	wp.Deleted = 0

GRANT EXEC ON QueryWorkPermitEdmontonDTOByFormGN59Id TO PUBLIC
GO