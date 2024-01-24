
  
IF OBJECT_ID('QueryPermitRequestFortHillsDTOByDateRangeAndFlocs', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsDTOByDateRangeAndFlocs
GO 
       
CREATE Procedure [dbo].QueryPermitRequestFortHillsDTOByDateRangeAndFlocs        
    (        
  @CsvFlocIds varchar(MAX),        
  @StartOfDateRange DateTime,        
  @EndOfDateRange DateTime,        
  @PriorityIds varchar(MAX) = null        
  --@ExcludeTheGivenPriorityIds bit = 0        
    )        
AS        
        
WITH PermitRequest_Id_Cte (PermitRequestId)        
AS        
(        
select distinct PermitRequest.id        
  from         
    dbo.PermitRequestFortHills PermitRequest        
    INNER JOIN dbo.FunctionalLocation fl ON PermitRequest.FunctionalLocationId = fl.Id        
 LEFT OUTER JOIN dbo.SAPImportPriorityWorkPermitFortHillsGroup priorityAssoc on priorityAssoc.WorkPermitFortHillsGroupId = PermitRequest.GroupId        
 LEFT OUTER JOIN IDSplitter(@PriorityIds) priorityIds ON priorityIds.Id = priorityAssoc.SAPImportPriority        
  WHERE        
    (PermitRequest.RequestedStartDate is not null and PermitRequest.RequestedStartDate <= @EndOfDateRange)        
   AND        
   PermitRequest.RequestedEndDate >= @StartOfDateRange AND        
   PermitRequest.Deleted = 0 --and        
   --Commented By Vibhor - INC0515708 : OLT : Permit request not getting created for Turnaround 
   --(@PriorityIds is null OR (@ExcludeTheGivenPriorityIds = 0 and priorityIds.Id is not null) OR (@ExcludeTheGivenPriorityIds = 1 and priorityIds.Id is null))         
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
    LastSubmittedByUser.UserName AS LastSubmittedByUserName    
        
FROM        
  PermitRequestFortHills PermitRequest        
  INNER JOIN PermitRequest_Id_Cte on PermitRequest_Id_Cte.PermitRequestId = PermitRequest.Id        
 INNER JOIN FunctionalLocation FunctionalLocation ON PermitRequest.FunctionalLocationId = FunctionalLocation.Id        
 INNER JOIN [User] LastModifiedByUser ON PermitRequest.LastModifiedByUserId = LastModifiedByUser.Id        
 INNER JOIN WorkPermitFortHillsGroup wpeg ON PermitRequest.GroupId = wpeg.Id             
 LEFT OUTER JOIN [User] LastImportedByUser ON PermitRequest.LastImportedByUserId = LastImportedByUser.Id        
 LEFT OUTER JOIN [User] LastSubmittedByUser ON PermitRequest.LastSubmittedByUserId = LastSubmittedByUser.Id           
order by         
  PermitRequest.RequestedStartDate desc        
OPTION (OPTIMIZE FOR UNKNOWN)   
  
      
 GRANT EXEC ON QueryPermitRequestFortHillsDTOByDateRangeAndFlocs TO PUBLIC   