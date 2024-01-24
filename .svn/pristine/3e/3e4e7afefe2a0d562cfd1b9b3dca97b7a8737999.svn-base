IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOnPremisePersonnelAuditViewDTO')
    BEGIN
        DROP PROCEDURE [dbo].QueryOnPremisePersonnelAuditViewDTO
    END
GO

CREATE Procedure [dbo].QueryOnPremisePersonnelAuditViewDTO
    (
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime
    )
AS

select 
  c.Id as ContractorId,
  f.Id as OvertimeFormId,
  c.Company,
  f.Trade,
  c.PersonnelName,
  c.StartDateTime,
  c.EndDateTime,
  c.PrimaryLocation,
  c.ExpectedHours,
  c.[Description],
  c.WorkOrderNumber,
  f.FormStatusId,

  au.Firstname as ApprovedByFirstName,
  au.LastName as ApprovedByLastName
  
from 
  OvertimeForm f
  INNER JOIN OvertimeFormContractor c on c.OvertimeFormId = f.Id
  LEFT OUTER JOIN [OvertimeFormApproval] approval on approval.OvertimeFormId = f.Id
  LEFT OUTER JOIN [User] au on au.Id = approval.ApprovedByUserId

WHERE
  f.Deleted = 0 
  and f.FormStatusId != 4 -- cancelled
  and c.StartDateTime  <= @EndOfDateRange AND c.EndDateTime >= @StartOfDateRange
  and c.Deleted = 0
ORDER BY 
	c.Company,
	f.Trade,
	c.PersonnelName,
	c.StartDateTime
GO

GRANT EXEC on QueryOnPremisePersonnelAuditViewDTO TO PUBLIC
GO