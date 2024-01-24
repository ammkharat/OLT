IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonDTOByDateRangeAndFlocs')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonDTOByDateRangeAndFlocs
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonDTOByDateRangeAndFlocs
    (
        @CsvFlocIds varchar(MAX),
		@StartOfDateRange DateTime,
		@EndOfDateRange DateTime,
		@PriorityIds varchar(MAX) = null,
		@ExcludeTheGivenPriorityIds bit = 0
    )
AS

WITH PermitRequest_Id_Cte (PermitRequestId)
AS
(
select distinct PermitRequest.id
  from 
    dbo.PermitRequestEdmonton PermitRequest
    INNER JOIN dbo.FunctionalLocation fl ON PermitRequest.FunctionalLocationId = fl.Id
	LEFT OUTER JOIN dbo.SAPImportPriorityWorkPermitEdmontonGroup priorityAssoc on priorityAssoc.WorkPermitEdmontonGroupId = PermitRequest.GroupId
	LEFT OUTER JOIN IDSplitter(@PriorityIds) priorityIds ON priorityIds.Id = priorityAssoc.SAPImportPriority
  WHERE
    (PermitRequest.RequestedStartDate is not null and PermitRequest.RequestedStartDate <= @EndOfDateRange)
	  AND
	  PermitRequest.EndDate >= @StartOfDateRange AND
	  PermitRequest.Deleted = 0 and
	  (@PriorityIds is null OR (@ExcludeTheGivenPriorityIds = 0 and priorityIds.Id is not null) OR (@ExcludeTheGivenPriorityIds = 1 and priorityIds.Id is null)) 
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
	al.Name AS AreaLabelName,
	      
	sw.Id as SpecialWorkId,        
	sw.CompanyName as SpecialWorkName
FROM
  PermitRequestEdmonton PermitRequest
  INNER JOIN PermitRequest_Id_Cte on PermitRequest_Id_Cte.PermitRequestId = PermitRequest.Id
	INNER JOIN FunctionalLocation FunctionalLocation ON PermitRequest.FunctionalLocationId = FunctionalLocation.Id
	INNER JOIN [User] LastModifiedByUser ON PermitRequest.LastModifiedByUserId = LastModifiedByUser.Id
	INNER JOIN WorkPermitEdmontonGroup wpeg ON PermitRequest.GroupId = wpeg.Id
	LEFT OUTER JOIN SpecialWork sw on PermitRequest.SpecialWorkType = sw.Id 
	LEFT OUTER JOIN [User] LastImportedByUser ON PermitRequest.LastImportedByUserId = LastImportedByUser.Id
	LEFT OUTER JOIN [User] LastSubmittedByUser ON PermitRequest.LastSubmittedByUserId = LastSubmittedByUser.Id
	LEFT OUTER JOIN AreaLabel al ON al.Id = PermitRequest.AreaLabelId
order by 
  PermitRequest.RequestedStartDate, 
  coalesce(PermitRequest.RequestedStartTimeDay, PermitRequest.RequestedStartTimeNight) desc
OPTION (OPTIMIZE FOR UNKNOWN)	  
GO

GRANT EXEC ON QueryPermitRequestEdmontonDTOByDateRangeAndFlocs TO PUBLIC
GO