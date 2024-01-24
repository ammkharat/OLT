IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonDTOByDateRangeAndFlocIds')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonDTOByDateRangeAndFlocIds
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonDTOByDateRangeAndFlocIds
    (
		@CsvFlocIds varchar(MAX),
		@StartOfDateRange DateTime,
		@EndOfDateRange DateTime,
		@CsvPriorityIds varchar(MAX) = null,
		@ExcludeTheGivenPriorityIds bit = 0
    )
AS

WITH WorkPermit_Id_Cte (WorkPermitId)
AS
(
select distinct wp.id
  from 
    dbo.WorkPermitEdmonton wp
    INNER JOIN dbo.FunctionalLocation fl ON wp.FunctionalLocationId = fl.Id
	LEFT OUTER JOIN dbo.SAPImportPriorityWorkPermitEdmontonGroup priorityAssoc on priorityAssoc.WorkPermitEdmontonGroupId = wp.GroupId
	LEFT OUTER JOIN IDSplitter(@CsvPriorityIds) priorityIds ON priorityIds.Id = priorityAssoc.SAPImportPriority
  WHERE 
    wp.RequestedStartDateTime <= @EndOfDateRange AND
    wp.ExpiredDateTime >= @StartOfDateRange AND
    wp.Deleted = 0 AND
	(@CsvPriorityIds is null OR (@ExcludeTheGivenPriorityIds = 0 and priorityIds.Id is not null) OR (@ExcludeTheGivenPriorityIds = 1 and priorityIds.Id is null)) 
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
wpd.PermitAcceptor,
wp.PriorityId,
al.Name AS AreaLabelName,

wpd.RoadAccessOnPermit1,  
wpd.RoadAccessOnPermitFormNumber1,  
wpd.RoadAccessOnPermitType1 ,

sw.Id as SpecialWorkId,    
sw.CompanyName as SpecialWorkName  

FROM
  WorkPermitEdmonton wp
  INNER JOIN WorkPermit_Id_Cte on WorkPermit_Id_Cte.WorkPermitId = wp.Id
  INNER JOIN FunctionalLocation fl ON fl.Id = wp.FunctionalLocationId
  INNER JOIN WorkPermitEdmontonDetails wpd on wpd.WorkPermitEdmontonId = wp.Id
  LEFT OUTER JOIN SpecialWork sw on wpd.SpecialWorkType = sw.Id  -- by mangesh for Special Work
  LEFT OUTER JOIN WorkPermitEdmontonGroup wpeg on wpeg.Id = wp.GroupId
  INNER JOIN [User] lmu ON wp.LastModifiedByUserId = lmu.Id
  LEFT OUTER JOIN [User] permitRequestCreatedByUser ON wp.PermitRequestCreatedByUserId = permitRequestCreatedByUser.Id
  LEFT OUTER JOIN [User] issuedByUser ON wp.IssuedByUserId = issuedByUser.Id
  LEFT OUTER JOIN AreaLabel al on al.Id = wp.AreaLabelId
OPTION (OPTIMIZE FOR UNKNOWN)	    
GO

GRANT EXEC ON QueryWorkPermitEdmontonDTOByDateRangeAndFlocIds TO PUBLIC
GO