IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOnPremisePersonnelSupervisorViewDTO')
    BEGIN
        DROP PROCEDURE [dbo].QueryOnPremisePersonnelSupervisorViewDTO
    END
GO

CREATE Procedure [dbo].QueryOnPremisePersonnelSupervisorViewDTO
    (
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime
    )
AS

select 
  c.Id,
  f.Trade,
  c.PersonnelName,
  c.PrimaryLocation,
  c.IsDayShift,
  c.IsNightShift,
  c.StartDateTime,
  c.EndDateTime,
  c.PhoneNumber,
  c.Radio,
  c.Company,
  c.[Description]
from 
  OvertimeForm f
  INNER JOIN OvertimeFormContractor c on c.OvertimeFormId = f.Id
WHERE
  f.Deleted = 0 
  and f.FormStatusId != 4 -- cancelled
  and c.StartDateTime  <= @EndOfDateRange AND c.EndDateTime >= @StartOfDateRange
  and c.Deleted = 0
ORDER BY 
	f.Trade,
	c.StartDateTime, 
	c.PersonnelName
GO

GRANT EXEC on QueryOnPremisePersonnelSupervisorViewDTO TO PUBLIC
GO