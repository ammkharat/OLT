if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormDTOsThatAreMudsTemporaryInstallationApprovedDraftExpiredByFunctionalLocations]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormDTOsThatAreMudsTemporaryInstallationApprovedDraftExpiredByFunctionalLocations]
GO

  
CREATE Procedure [dbo].[QueryFormDTOsThatAreMudsTemporaryInstallationApprovedDraftExpiredByFunctionalLocations]  
    (  
        @CsvFlocIds VARCHAR(MAX),  
        @Now DATETIME  
    )  
AS  
  
WITH FormMudsTemporaryInstallation_Id_Cte (FormMudsTemporaryInstallationId)  
AS  
(  
  SELECT   
    DISTINCT f.Id  
  FROM  
    FormMudsTemporaryInstallation f  
  WHERE  
    f.Deleted = 0 AND  
   EXISTS  
   (  
  -- Floc of Form matches one of the passed in flocs  
  select ffl.FormMudsTemporaryInstallationId From IDSplitter(@CsvFLOCIds) ids  
  INNER JOIN FormMudsTemporaryInstallationFunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId  
  WHERE ffl.FormMudsTemporaryInstallationId = f.Id  
  UNION ALL  
  -- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)  
  select ffl.FormMudsTemporaryInstallationId from FunctionalLocationAncestor a  
  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id  
  INNER JOIN FormMudsTemporaryInstallationFunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId  
  WHERE ffl.FormMudsTemporaryInstallationId = f.Id  
  UNION ALL     
  -- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)  
  select ffl.FormMudsTemporaryInstallationId from FunctionalLocationAncestor a  
  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid  
  INNER JOIN FormMudsTemporaryInstallationFunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId  
  WHERE ffl.FormMudsTemporaryInstallationId = f.Id  
   )  
)  
SELECT  
    f.Id as Id,   
 11 as FormTypeId,  
 --f.CriticalSystemDefeated,  
 substring(f.CsdReason,1,50) as 'CriticalSystemDefeated',--TASK0428706 by ppanigrahi
 f.CreatedDateTime,   
 f.CreatedByUserId,  
 f.LastModifiedByUserId,  
 f.ApprovedDateTime,  
 f.ClosedDateTime,  
   
 f.ValidFromDateTime,  
 f.ValidToDateTime,  
 f.FormStatusId,  
 f.HasBeenApproved,  
   
    createdByUser.LastName as CreatedByLastName,  
    createdByUser.FirstName as CreatedByFirstName,  
    createdByUser.UserName as CreatedByUserName,  
   
 lastModifiedByUser.LastName as LastModifiedByLastName,  
    lastModifiedByUser.FirstName as LastModifiedByFirstName,  
    lastModifiedByUser.UserName as LastModifiedByUserName,  
  
    fl.FullHierarchy as FullHierarchy,  
   
 a.Approver,  
 a.ApprovedByUserId,  
 a.DisplayOrder as ApprovalDisplayOrder  
FROM  
    FormMudsTemporaryInstallation f  
    INNER JOIN FormMudsTemporaryInstallation_Id_Cte ON FormMudsTemporaryInstallationId = f.Id  
    INNER JOIN [FormMudsTemporaryInstallationFunctionalLocation] ffl on ffl.FormMudsTemporaryInstallationId = f.Id  
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId  
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id  
    INNER JOIN [User] lastModifiedByUser on f.LastModifiedByUserId = lastModifiedByUser.Id  
 LEFT OUTER JOIN [FormMudsTemporaryInstallationApproval] a on a.FormMudsTemporaryInstallationId = f.Id and a.Enabled = 1  
WHERE   
    FormStatusId = 2 OR FormStatusId = 5 OR FormStatusId = 1 OR FormStatusId = 3  OR FormStatusId = 15 
ORDER BY f.Id, ApprovalDisplayOrder  
OPTION (OPTIMIZE FOR UNKNOWN)  



GRANT EXEC ON QueryFormDTOsThatAreMudsTemporaryInstallationApprovedDraftExpiredByFunctionalLocations TO PUBLIC
GO