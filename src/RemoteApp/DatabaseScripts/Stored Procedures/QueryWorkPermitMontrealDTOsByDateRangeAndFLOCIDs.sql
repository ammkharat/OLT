-- Delete old stored procedure
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMontrealDTOsByDateRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitMontrealDTOsByDateRange
    END
GO

-- Create the new replacement procedure that inculdes FLOC Ids
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMontrealDTOsByDateRangeAndFlocIds')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitMontrealDTOsByDateRangeAndFlocIds
    END
GO

CREATE Procedure [dbo].QueryWorkPermitMontrealDTOsByDateRangeAndFlocIds
    (
		@CsvFlocIds varchar(MAX),
		@StartOfDateRange DateTime,
		@EndOfDateRange DateTime
    )
AS

WITH WorkPermit_Id_Cte (WorkPermitId)
AS
(
select distinct wp.id
  from 
    dbo.WorkPermitMontreal wp
  WHERE 
    wp.StartDateTime <= @EndOfDateRange and
    wp.EndDateTime >= @StartOfDateRange and
    wp.Deleted = 0	AND
	( 
		EXISTS
		(
		-- Floc of Log matches one of the passed in flocs
		select wpfl.WorkPermitMontrealId From IDSplitter(@CsvFlocIds) ids
		INNER JOIN WorkPermitMontrealFunctionalLocation wpfl ON ids.Id = wpfl.FunctionalLocationId
		WHERE wpfl.WorkPermitMontrealId = wp.Id
		)
		OR EXISTS
		(
		  -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select wpfl.WorkPermitMontrealId from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid
		  INNER JOIN WorkPermitMontrealFunctionalLocation wpfl ON a.Id = wpfl.FunctionalLocationId
		  WHERE wpfl.WorkPermitMontrealId = wp.Id  
		)
	)
)

SELECT
	wpm.Id,
	wpm.SourceId,
	wpm.WorkPermitStatusId,
	wpm.WorkPermitTypeId,
	wpm.StartDateTime,
	wpm.EndDateTime,
	wpm.PermitNumber,
	wpm.WorkOrderNumber,
	fl.FullHierarchy,
	wpm.Trade,
	wpm.Description,
	wpm.CreatedDateTime,
	wpm.CreatedByUserId,
	wpm.LastModifiedDateTime,
	wpm.LastModifiedByUserId,
	wpm.IssuedDateTime,
	wpmg.Name as RequestedByGroup,
	lastModifiedUser.LastName as LastModifiedByLastName,
	lastModifiedUser.FirstName as LastModifiedByFirstName,
	lastModifiedUser.UserName as LastModifiedByUserName
FROM
	WorkPermitMontreal wpm
	INNER JOIN WorkPermit_Id_Cte ON WorkPermit_Id_Cte.WorkPermitId = wpm.Id
	inner join WorkPermitMontrealFunctionalLocation wpmfl on wpmfl.WorkPermitMontrealId = wpm.Id
	inner join FunctionalLocation fl on fl.Id = wpmfl.FunctionalLocationId
	INNER JOIN [User] lastModifiedUser ON wpm.[LastModifiedByUserId] = lastModifiedUser.[Id]
	left outer join WorkPermitMontrealGroup wpmg on wpmg.Id = wpm.RequestedByGroupId
OPTION (OPTIMIZE FOR UNKNOWN)  			
GO

GRANT EXEC ON QueryWorkPermitMontrealDTOsByDateRangeAndFlocIds TO PUBLIC
GO