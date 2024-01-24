IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitLubesDTOByDateRangeAndFlocIds')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitLubesDTOByDateRangeAndFlocIds
    END
GO


CREATE Procedure [dbo].QueryWorkPermitLubesDTOByDateRangeAndFlocIds
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
    dbo.WorkPermitLubes wp
    INNER JOIN dbo.FunctionalLocation fl ON wp.FunctionalLocationId = fl.Id		
  WHERE 
    wp.StartDateTime <= @EndOfDateRange AND
    wp.ExpireDateTime >= @StartOfDateRange AND
    wp.Deleted = 0
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
wp.WorkPermitStatus,
wp.AdditionalFollowupRequired,
wp.PermitNumber,
fl.FullHierarchy as FunctionalLocationFullHierarchy,
wp.StartDateTime,
wp.ExpireDateTime,
wp.Version,
wp.IssuedDateTime,
wp.Trade,
wplg.Name as RequestedByGroupName,
wp.TaskDescription,
wp.WorkOrderNumber,
wp.CreatedByUserId,
wp.LastModifiedByUserId,

lmu.LastName as LastModifiedByLastName,
lmu.FirstName as LastModifiedByFirstName,
lmu.UserName as LastModifiedByUserName,

permitRequestCreatedByUser.LastName as PermitRequestCreatedByLastName, 
permitRequestCreatedByUser.FirstName as PermitRequestCreatedByFirstName,
permitRequestCreatedByUser.UserName as PermitRequestCreatedByUserName,

permitRequestSubmittedByUser.LastName as PermitRequestSubmittedByLastName,
permitRequestSubmittedByUser.FirstName as PermitRequestSubmittedByFirstName,
permitRequestSubmittedByUser.UserName as PermitRequestSubmittedByUserName,

issuedByUser.LastName as IssuedByLastName, 
issuedByUser.FirstName as IssuedByFirstName,
issuedByUser.UserName as IssuedByUserName,

wp.Company

FROM
  WorkPermitLubes wp
  INNER JOIN WorkPermit_Id_Cte on WorkPermit_Id_Cte.WorkPermitId = wp.Id
  INNER JOIN FunctionalLocation fl ON fl.Id = wp.FunctionalLocationId
  LEFT OUTER JOIN WorkPermitLubesGroup wplg on wplg.Id = wp.RequestedByGroupId
  INNER JOIN [User] lmu ON wp.LastModifiedByUserId = lmu.Id  
  LEFT OUTER JOIN [User] permitRequestSubmittedByUser ON wp.PermitRequestSubmittedByUserId = permitRequestSubmittedByUser.Id  
  LEFT OUTER JOIN PermitRequestLubes prl ON prl.Id = wp.PermitRequestId
  LEFT OUTER JOIN [User] permitRequestCreatedByUser ON prl.CreatedByUserId = permitRequestCreatedByUser.Id
  LEFT OUTER JOIN [User] issuedByUser ON wp.IssuedByUserId = issuedByUser.Id
OPTION (OPTIMIZE FOR UNKNOWN)	      
GO

GRANT EXEC ON QueryWorkPermitLubesDTOByDateRangeAndFlocIds TO PUBLIC
GO