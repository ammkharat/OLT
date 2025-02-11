if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGenericTemplateDTOsByFunctionalLocationsAndOtherThingsForPriorityPage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGenericTemplateDTOsByFunctionalLocationsAndOtherThingsForPriorityPage]
GO


CREATE Procedure [dbo].[QueryFormGenericTemplateDTOsByFunctionalLocationsAndOtherThingsForPriorityPage]    
    (    
        @CsvFlocIds VARCHAR(MAX),    
        @StartOfDateRange DateTime,    
        @EndOfDateRange DateTime,    
  @CsvFormStatusIds varchar(max),    
  @IncludeAllDraft bit   
    )    
AS    
    
WITH FormGenericTemplate_Id_Cte (FormGenericTemplateId)    
AS    
(    
  SELECT     
    DISTINCT f.Id    
  FROM    
    FormGenericTemplate f    
  WHERE    
    f.Deleted = 0 AND  
   EXISTS    
   (    
  -- Floc of Form matches one of the passed in flocs    
  select ffl.FormGenericTemplateId From IDSplitter(@CsvFLOCIds) ids    
  INNER JOIN FormGenericTemplateFunctionalLocation ffl ON ids.Id = ffl.FunctionalLocationId    
  WHERE ffl.FormGenericTemplateId = f.Id    
  UNION ALL    
  -- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)    
  select ffl.FormGenericTemplateId from FunctionalLocationAncestor a    
  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id    
  INNER JOIN FormGenericTemplateFunctionalLocation ffl ON a.AncestorId = ffl.FunctionalLocationId    
  WHERE ffl.FormGenericTemplateId = f.Id    
  UNION ALL       
  -- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)    
  select ffl.FormGenericTemplateId from FunctionalLocationAncestor a    
  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid    
  INNER JOIN FormGenericTemplateFunctionalLocation ffl ON a.Id = ffl.FunctionalLocationId    
  WHERE ffl.FormGenericTemplateId = f.Id    
   )    
)    
SELECT    
    f.Id as Id,         
 --3 as FormTypeId, -- //TODO -- don't know why it is 3    
 f.FormTypeId,
 f.PlantId,
 f.CriticalSystemDefeated,    
 f.CreatedDateTime,     
 f.CreatedByUserId,    
 f.LastModifiedByUserId,    
 f.ApprovedDateTime,    
 f.ClosedDateTime,    
     
 f.ValidFromDateTime,    
 f.ValidToDateTime,    
 f.FormStatusId,    
     
    createdByUser.LastName as CreatedByLastName,    
    createdByUser.FirstName as CreatedByFirstName,    
    createdByUser.UserName as CreatedByUserName,    
     
    fl.FullHierarchy as FullHierarchy,    
     
 a.Approver,    
 a.ApprovedByUserId,    
 a.DisplayOrder as ApprovalDisplayOrder    
FROM    
    FormGenericTemplate f    
    INNER JOIN FormGenericTemplate_Id_Cte ON FormGenericTemplateId = f.Id    
    INNER JOIN [FormGenericTemplateFunctionalLocation] ffl on ffl.FormGenericTemplateId = f.Id    
    INNER JOIN [FunctionalLocation] fl on fl.Id = ffl.FunctionalLocationId    
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id    
 LEFT OUTER JOIN [FormGenericTemplateApproval] a on a.FormGenericTemplateId = f.Id and a.Enabled = 1    
WHERE     
 --// To show only waiting for approval 
 f.FormStatusId = 15
 
 -- if we want to include all Draft forms, then return the form if it's status is Draft    
 --(@IncludeAllDraft = 1 ) --AND (f.FormStatusId = 15 or f.FormStatusId = 1))   
 
  
 OR    
 -- otherwise,  we need to check the status and date range to make sure they match the params passed in    
 (f.ValidFromDateTime <= @EndOfDateRange AND f.ValidToDateTime >= @StartOfDateRange AND EXISTS (SELECT * FROM IDSplitter(@CsvFormStatusIds) WHERE Id = f.FormStatusId))    
ORDER BY f.Id, ApprovalDisplayOrder    
OPTION (OPTIMIZE FOR UNKNOWN) 


GO

GRANT EXEC ON QueryFormGenericTemplateDTOsByFunctionalLocationsAndOtherThingsForPriorityPage TO PUBLIC
GO