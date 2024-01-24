IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOnPremisePersonnelByDateRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryOnPremisePersonnelByDateRange
    END
GO

CREATE Procedure [dbo].QueryOnPremisePersonnelByDateRange
    (
		 @StartOfDateRange DateTime,
        @EndOfDateRange DateTime
    )
AS
SELECT c.Id, c.PersonnelName, c.StartDateTime, c.EndDateTime, c.PhoneNumber, c.Radio, c.[Description], c.Company, c.PrimaryLocation, c.IsDayShift, c.IsNightShift, f.Trade
FROM dbo.OvertimeFormContractor AS c
    INNER JOIN dbo.OvertimeForm AS f
    ON c.OvertimeFormId = f.Id
WHERE  
	f.Deleted = 0 
  AND f.FormStatusId != 4 -- cancelled
  AND c.StartDateTime  <= @EndOfDateRange AND c.EndDateTime >= @StartOfDateRange
  AND c.Deleted = 0  
  ORDER BY c.StartDateTime
GO

GRANT EXEC ON QueryOnPremisePersonnelByDateRange TO PUBLIC
GO