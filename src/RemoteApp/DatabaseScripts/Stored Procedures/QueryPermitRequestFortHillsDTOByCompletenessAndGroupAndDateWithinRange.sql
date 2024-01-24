 
  
IF OBJECT_ID('QueryPermitRequestFortHillsDTOByCompletenessAndGroupAndDateWithinRange', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsDTOByCompletenessAndGroupAndDateWithinRange
GO 

CREATE Procedure [dbo].QueryPermitRequestFortHillsDTOByCompletenessAndGroupAndDateWithinRange        
    (        
  @CompletionStatusIds varchar(max),        
  @GroupId bigint,        
  @QueryDate DateTime        
    )        
AS        
        
SELECT        
    pr.*,        
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
          
FROM PermitRequestFortHills pr        
INNER JOIN IDSplitter(@CompletionStatusIds) Ids ON Ids.Id = pr.CompletionStatusId        
INNER JOIN FunctionalLocation FunctionalLocation ON pr.FunctionalLocationId = FunctionalLocation.Id        
INNER JOIN [User] LastModifiedByUser ON pr.LastModifiedByUserId = LastModifiedByUser.Id        
INNER JOIN WorkPermitFortHillsGroup wpeg ON pr.GroupId = wpeg.Id        
LEFT OUTER JOIN [User] LastImportedByUser ON pr.LastImportedByUserId = LastImportedByUser.Id        
LEFT OUTER JOIN [User] LastSubmittedByUser ON pr.LastSubmittedByUserId = LastSubmittedByUser.Id        
      
WHERE        
pr.[GroupId] = @GroupId AND        
pr.Deleted = 0 AND        
pr.RequestedStartDate <= @QueryDate AND        
@QueryDate <= pr.RequestedEndDate        
        
        
GRANT EXEC ON QueryPermitRequestFortHillsDTOByCompletenessAndGroupAndDateWithinRange TO PUBLIC  