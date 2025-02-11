
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMudsDTOsByDateRangeAndFlocIds')
	BEGIN
		DROP Procedure [dbo].QueryWorkPermitMudsDTOsByDateRangeAndFlocIds
	END
GO

CREATE Procedure [dbo].[QueryWorkPermitMudsDTOsByDateRangeAndFlocIds]
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
    dbo.WorkPermitMuds wp
  WHERE 
    wp.StartDateTime <= @EndOfDateRange and
    wp.EndDateTime >= @StartOfDateRange and
    wp.Deleted = 0	AND
	( 
		EXISTS
		(
		-- Floc of Log matches one of the passed in flocs
		select wpfl.WorkPermitMudsId From IDSplitter(@CsvFlocIds) ids
		INNER JOIN WorkPermitMudsFunctionalLocation wpfl ON ids.Id = wpfl.FunctionalLocationId
		WHERE wpfl.WorkPermitMudsId = wp.Id
		)
		OR EXISTS
		(
		  -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select wpfl.WorkPermitMudsId from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid
		  INNER JOIN WorkPermitMudsFunctionalLocation wpfl ON a.Id = wpfl.FunctionalLocationId
		  WHERE wpfl.WorkPermitMudsId = wp.Id  
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
	wpmdtl.InterrupteursEtVannesCadenassesValue,  -- Added By Vibhor
	wpmdtl.InterrupteursEtVannesCadenasses,  -- Added By Vibhor
	wpm.CreatedDateTime,
	wpm.CreatedByUserId,
	wpm.LastModifiedDateTime,
	wpm.LastModifiedByUserId,
	wpm.IssuedDateTime,
	wpm.MudsAnswerTextBox,
	--wpmg.Name as RequestedByGroup,
	wpm.RequestedByGroupId , 
	lastModifiedUser.LastName as LastModifiedByLastName,
	lastModifiedUser.FirstName as LastModifiedByFirstName,
	lastModifiedUser.UserName as LastModifiedByUserName
FROM
	WorkPermitMuds wpm
	INNER JOIN WorkPermit_Id_Cte ON WorkPermit_Id_Cte.WorkPermitId = wpm.Id
	inner join WorkPermitMudsFunctionalLocation wpmfl on wpmfl.WorkPermitMudsId = wpm.Id
	inner join FunctionalLocation fl on fl.Id = wpmfl.FunctionalLocationId
	INNER JOIN [User] lastModifiedUser ON wpm.[LastModifiedByUserId] = lastModifiedUser.[Id]
	INNER JOIN WorkPermitMudsDetails wpmdtl ON wpm.Id = wpmdtl.Id   -- Added By Vibhor
	--left outer join WorkPermitMudsGroup wpmg on wpmg.Id = wpm.RequestedByGroupId
OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryWorkPermitMudsDTOsByDateRangeAndFlocIds TO PUBLIC
GO
