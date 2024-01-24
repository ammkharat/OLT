IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOvertimeFormDTOsWaitingApproval')
    BEGIN
        DROP PROCEDURE [dbo].QueryOvertimeFormDTOsWaitingApproval
    END
GO

CREATE Procedure [dbo].QueryOvertimeFormDTOsWaitingApproval
    (
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime
    )
AS

SELECT
  f.Id,
  fl.FullHierarchy as FullHierarchy,
  
  f.CreatedByUserId,
  cu.Firstname as CreatedByFirstName,
  cu.LastName as CreatedByLastName,
  cu.Username as CreatedByUserName,
  
  f.CreatedDateTime,
  f.ValidFromDateTime,
  f.ValidToDateTime,
  f.FormStatusId,
  f.ApprovedDateTime,
  f.CancelledDateTime,
  f.Trade,
  f.LastModifiedByUserId,
  lmu.Firstname as LastModifiedByFirstName,
  lmu.LastName as LastModifiedByLastName,
  lmu.Username as LastModifiedByUserName,
  
  au.Firstname as ApprovedByFirstName,
  au.LastName as ApprovedByLastName,
  au.Username as ApprovedByUserName,
  
  approval.Approver,
  
    (SELECT 
    SUM(contractor.ExpectedHours) 
    FROM OvertimeFormContractor contractor WHERE contractor.OvertimeFormId = f.Id and contractor.DELETED = 0) AS TotalHours
FROM
  OvertimeForm f
  INNER JOIN FunctionalLocation fl on fl.Id = f.FunctionalLocationId
  INNER JOIN [User] cu on cu.Id = f.CreatedByUserId
  INNER JOIN [User] lmu on lmu.Id = f.LastModifiedByUserId
  INNER JOIN [OvertimeFormApproval] approval on approval.OvertimeFormId = f.Id
  LEFT OUTER JOIN [User] au on au.Id = approval.ApprovedByUserId
WHERE
	f.FormStatusId = 1
ORDER BY f.Id
GO

GRANT EXEC on QueryOvertimeFormDTOsWaitingApproval TO PUBLIC
GO  