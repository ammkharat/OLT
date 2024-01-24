    
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldsLogDTOsByFlocsAndShift')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldsLogDTOsByFlocsAndShift
	END
GO 
        
CREATE Procedure [dbo].QueryCustomFieldsLogDTOsByFlocsAndShift        
    (        
        @CsvFlocIds VARCHAR(MAX),        
        @CreatedShiftPatternId BIGINT,        
        @StartOfDateRange DATETIME,        
        @EndOfDateRange DATETIME,        
        @OnlyReturnLogsFlaggedAsOperatingEngineerLog BIT        
    )        
AS        
WITH Log_Id_CTE (LogId)        
AS         
(        
SELECT         
  DISTINCT l.Id         
FROM        
  [Log] l        
  INNER JOIN LogFunctionalLocation lfl ON lfl.LogId = l.Id        
WHERE        
  l.deleted = 0 AND        
  l.LogType = 1 AND        
  l.CreatedDateTime >= @StartOfDateRange AND        
  l.CreatedDateTime <= @EndOfDateRange AND        
  l.CreationUserShiftPatternId = @CreatedShiftPatternId AND        
  (@OnlyReturnLogsFlaggedAsOperatingEngineerLog = 0 OR l.IsOperatingEngineerLog = 1)        
 AND        
 (         
  EXISTS        
  (        
  -- Floc of Log matches one of the passed in flocs        
  select * From IDSplitter(@CsvFLOCIds) ids        
  WHERE lfl.FunctionalLocationId = ids.Id        
  )        
  OR EXISTS        
  (        
    -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)        
    select a.Id from FunctionalLocationAncestor a        
    INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid        
    WHERE lfl.FunctionalLocationId = a.Id        
  )        
 )        
)        
SELECT        
 l.Id as LogId,        
        
 fl.FullHierarchy AS FunctionalLocationName,        
 fl.Description AS FunctionalLocationDescription,        
 coalesce(flUnit.FullHierarchy, fl.FullHierarchy) AS Unit,        
 coalesce(flUnit.Description, fl.Description) AS UnitDescription,        
        
 l.LogDateTime,        
 l.CreatedDateTime,        
 l.LastModifiedDateTime,        
        
 l.RtfComments,        
 l.PlainTextComments,        
        
 createdByUser.LastName AS CreatedByLastName,        
 createdByUser.FirstName AS CreatedByFirstName,        
 createdByUser.UserName AS CreatedByUserName,        
        
 lastModifiedUser.LastName AS LastModifiedByLastName,        
 lastModifiedUser.FirstName AS LastModifiedByFirstName,        
 lastModifiedUser.UserName AS LastModifiedByUserName,        
        
 s.StartTime AS CreatedShiftStartDateTime,        
 s.EndTime AS CreatedShiftEndDateTime,        
 s.[id] AS CreatedShiftId,        
 s.Name AS CreatedShiftName,        
        
 sc.PreShiftPaddingInMinutes,        
 sc.PostShiftPaddingInMinutes      
       
 ,lcfe.Id as LogCustomFieldEntryId,              
 lcfe.CustomFieldName,              
 lcfe.CustomFieldId,              
 lcfe.FieldEntry,              
 lcfe.NumericFieldEntry,              
 lcfe.DisplayOrder,              
 lcfe.TypeId,              
 lcfe.PhdLinkTypeId      
       
 ,cf.Id as ActualCustomFieldId,              
 cf.Name as ActualCustomFieldName,               
 cfcfg.DisplayOrder as ActualCustomFieldDisplayOrder,              
 lcfg.CustomFieldGroupId,              
 cfg.OriginCustomFieldGroupId,              
 cf.OriginCustomFieldId,              
 cf.TypeId as ActualTypeId,              
 cf.PhdLinkTypeId as ActualPhdLinkTypeId        
     
 ,Substring (DBO.GetCustomFieldColour(lcfg.LogId,lcfe.CustomFieldID),1,1) AS COLOR  
       
FROM        
 [Log] l        
 INNER JOIN Log_Id_CTE ON Log_Id_CTE.LogId = l.Id        
 inner join [Shift] s ON l.CreationUserShiftPatternId = s.Id        
 INNER JOIN [SiteConfiguration] sc ON s.SiteId = sc.SiteId        
 INNER JOIN [User] createdByUser on l.UserId = createdByUser.Id        
 INNER JOIN [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id        
 inner join LogFunctionalLocation lfl on lfl.LogId = l.Id        
 inner join FunctionalLocation fl on fl.Id = lfl.FunctionalLocationId        
    left join FunctionalLocationAncestor a on a.Id = fl.Id and a.AncestorLevel = 3        
    left join FunctionalLocation flUnit on flUnit.Id = a.AncestorId         
          
    left outer join LogCustomFieldEntry lcfe on lcfe.LogId = l.Id       
    left outer join LogCustomFieldGroup lcfg on lcfg.LogId = l.Id              
 left outer join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId              
 left outer join CustomField cf on cf.Id = cfcfg.CustomFieldId           
 left outer join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId       
       
 OPTION (OPTIMIZE FOR UNKNOWN) 
 
 GRANT EXEC ON QueryCustomFieldsLogDTOsByFlocsAndShift TO PUBLIC  
 
 
 