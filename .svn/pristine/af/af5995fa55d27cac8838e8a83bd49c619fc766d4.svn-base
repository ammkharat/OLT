      

IF OBJECT_ID('QueryWorkPermitFortHillsDTOByDateRangeAndFlocIds', 'P') IS NOT NULL
DROP PROC QueryWorkPermitFortHillsDTOByDateRangeAndFlocIds
GO  
   
CREATE Procedure [dbo].QueryWorkPermitFortHillsDTOByDateRangeAndFlocIds      
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
    dbo.WorkPermitFortHills wp      
    INNER JOIN dbo.FunctionalLocation fl ON wp.FunctionalLocationId = fl.Id      
 LEFT OUTER JOIN dbo.SAPImportPriorityWorkPermitFortHillsGroup priorityAssoc on priorityAssoc.WorkPermitFortHillsGroupId = wp.GroupId      
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
wpd.Revalidationdatetime,
wpd.ExtensionDatetime,      
wp.PriorityId     
--al.Name AS AreaLabelName,      
      
--wpd.RoadAccessOnPermit1,        
--wpd.RoadAccessOnPermitFormNumber1,        
--wpd.RoadAccessOnPermitType1     
      
FROM      
  WorkPermitFortHills wp      
  INNER JOIN WorkPermit_Id_Cte on WorkPermit_Id_Cte.WorkPermitId = wp.Id      
  INNER JOIN FunctionalLocation fl ON fl.Id = wp.FunctionalLocationId      
  INNER JOIN WorkPermitFortHillsDetails wpd on wpd.WorkPermitFortHillsId = wp.Id       
  LEFT OUTER JOIN WorkPermitFortHillsGroup wpeg on wpeg.Id = wp.GroupId      
  INNER JOIN [User] lmu ON wp.LastModifiedByUserId = lmu.Id      
  LEFT OUTER JOIN [User] permitRequestCreatedByUser ON wp.PermitRequestCreatedByUserId = permitRequestCreatedByUser.Id      
  LEFT OUTER JOIN [User] issuedByUser ON wp.IssuedByUserId = issuedByUser.Id      
       
OPTION (OPTIMIZE FOR UNKNOWN)   
  
GRANT EXEC ON QueryWorkPermitFortHillsDTOByDateRangeAndFlocIds TO PUBLIC     