IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestLubesDTOByDateRangeAndFlocs')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestLubesDTOByDateRangeAndFlocs
    END
GO

CREATE Procedure [dbo].QueryPermitRequestLubesDTOByDateRangeAndFlocs
    (
        @CsvFlocIds varchar(MAX),
		@StartOfDateRange DateTime,
		@EndOfDateRange DateTime
    )
AS

WITH PermitRequest_Id_Cte (PermitRequestId)
AS
(
select distinct PermitRequest.id
  from 
    dbo.PermitRequestLubes PermitRequest
    INNER JOIN dbo.FunctionalLocation fl ON PermitRequest.FunctionalLocationId = fl.Id
  WHERE
    PermitRequest.RequestedStartDate <= @EndOfDateRange
	  AND
	  PermitRequest.EndDate >= @StartOfDateRange AND
	  PermitRequest.Deleted = 0
	  AND
	  ( 
		EXISTS
		(
		-- Floc of permit matches one of the passed in flocs
		select ids.Id From IDSplitter(@CsvFlocIds) ids
		WHERE ids.Id = fl.Id
		)
		OR EXISTS
		(
		  -- Floc of permit is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select a.Id from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid
		  WHERE a.Id = fl.Id  
		)
		OR EXISTS
		(
		  -- Floc of permit is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		  select a.Id from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.Id
		  WHERE a.AncestorId = fl.Id  
		)
		
	  )
)

SELECT
    PermitRequest.*,
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
FROM
	PermitRequestLubes PermitRequest
	INNER JOIN PermitRequest_Id_Cte on PermitRequest_Id_Cte.PermitRequestId = PermitRequest.Id
	INNER JOIN FunctionalLocation FunctionalLocation ON PermitRequest.FunctionalLocationId = FunctionalLocation.Id
	INNER JOIN [User] LastModifiedByUser ON PermitRequest.LastModifiedByUserId = LastModifiedByUser.Id
	INNER JOIN WorkPermitLubesGroup wplg ON PermitRequest.RequestedByGroupId = wplg.Id
	LEFT OUTER JOIN [User] LastImportedByUser ON PermitRequest.LastImportedByUserId = LastImportedByUser.Id
	LEFT OUTER JOIN [User] LastSubmittedByUser ON PermitRequest.LastSubmittedByUserId = LastSubmittedByUser.Id
order by 
  PermitRequest.RequestedStartDate, 
  coalesce(PermitRequest.RequestedStartTimeDay, PermitRequest.RequestedStartTimeNight) desc
OPTION (OPTIMIZE FOR UNKNOWN)	  
GO

GRANT EXEC ON QueryPermitRequestLubesDTOByDateRangeAndFlocs TO PUBLIC
GO