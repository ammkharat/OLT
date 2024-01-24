IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogsByShiftHandoverQuestionnaire')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogsByShiftHandoverQuestionnaire
    END
GO

  
CREATE Procedure [dbo].QueryLogsByShiftHandoverQuestionnaire      
 (      
  @ShiftHandoverId BIGINT,
  @SiteId int      
 )      
AS      
IF(Select EnableLogsFromOtherUsers from Siteconfiguration where SiteId=@SiteId)=0
SELECT      
    l.Id as LogId,      
    floclist.FunctionalLocationList as FunctionalLocations,      
    l.LogDateTime,      
 l.LastModifiedDateTime,      
    
    createdByUser.LastName AS CreatedByLastName,      
    createdByUser.FirstName AS CreatedByFirstName,      
 createdByUser.Id As CreatedByUserId,      
    
 l.RtfComments,      
 l.PlainTextComments,      
    
 lcfe.Id as LogCustomFieldEntryId,      
 lcfe.CustomFieldName,      
 lcfe.CustomFieldId,      
 lcfe.FieldEntry,      
 lcfe.NumericFieldEntry,      
 lcfe.DisplayOrder,      
 lcfe.TypeId,      
 lcfe.PhdLinkTypeId,      
    
 cf.Id as ActualCustomFieldId,      
 cf.Name as ActualCustomFieldName,       
 cfcfg.DisplayOrder as ActualCustomFieldDisplayOrder,      
 lcfg.CustomFieldGroupId,      
 cfg.OriginCustomFieldGroupId,      
 cf.OriginCustomFieldId,      
 cf.TypeId as ActualTypeId,      
 cf.PhdLinkTypeId as ActualPhdLinkTypeId ,    
    
 GreaterThanValue,LessThanValue,RangeGreaterThanValue,RangeLessThanValue, Substring(DBO.GetCustomFieldColour(l.Id,cfwr.CustomFieldID),1,1) AS COLOR        
    
FROM      
    [Log] l       
    inner join ShiftHandoverQuestionnaireLog assoc ON assoc.LogId = l.Id      
 INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id      
    inner join [User] createdByUser on l.UserId = createdByUser.Id      
 left outer join LogCustomFieldEntry lcfe on lcfe.LogId = l.Id      
 left outer join LogCustomFieldGroup lcfg on lcfg.LogId = l.Id      
 left outer join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId      
 left outer join CustomField cf on cf.Id = cfcfg.CustomFieldId      
 left outer join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId      
    
 left join CustomFieldWithRange cfwr on lcfe.CustomFieldId = cfwr.CustomFieldID    
 And cfwr.id = Substring (DBO.GetCustomFieldColour(l.Id,lcfe.CustomFieldID),3,8)      
    
WHERE      
 l.Deleted = 0 and      
 assoc.ShiftHandoverQuestionnaireId = @ShiftHandoverId 
 AND  l.UserId= (select CreatedByUserId from ShiftHandoverQuestionnaire where Id = @ShiftHandoverId)
-- AND
 --((select EnableLogsFromOtherUsers from Siteconfiguration where SiteId=@SiteId)=0 AND l.UserId= (select CreatedByUserId from ShiftHandoverQuestionnaire where Id = @ShiftHandoverId))

 
 else

 SELECT      
    l.Id as LogId,      
    floclist.FunctionalLocationList as FunctionalLocations,      
    l.LogDateTime,      
 l.LastModifiedDateTime,      
    
    createdByUser.LastName AS CreatedByLastName,      
    createdByUser.FirstName AS CreatedByFirstName,      
 createdByUser.Id As CreatedByUserId,      
    
 l.RtfComments,      
 l.PlainTextComments,      
    
 lcfe.Id as LogCustomFieldEntryId,      
 lcfe.CustomFieldName,      
 lcfe.CustomFieldId,      
 lcfe.FieldEntry,      
 lcfe.NumericFieldEntry,      
 lcfe.DisplayOrder,      
 lcfe.TypeId,      
 lcfe.PhdLinkTypeId,      
    
 cf.Id as ActualCustomFieldId,      
 cf.Name as ActualCustomFieldName,       
 cfcfg.DisplayOrder as ActualCustomFieldDisplayOrder,      
 lcfg.CustomFieldGroupId,      
 cfg.OriginCustomFieldGroupId,      
 cf.OriginCustomFieldId,      
 cf.TypeId as ActualTypeId,      
 cf.PhdLinkTypeId as ActualPhdLinkTypeId ,    
    
 GreaterThanValue,LessThanValue,RangeGreaterThanValue,RangeLessThanValue, Substring(DBO.GetCustomFieldColour(l.Id,cfwr.CustomFieldID),1,1) AS COLOR        
    
FROM      
    [Log] l       
    inner join ShiftHandoverQuestionnaireLog assoc ON assoc.LogId = l.Id      
 INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id      
    inner join [User] createdByUser on l.UserId = createdByUser.Id      
 left outer join LogCustomFieldEntry lcfe on lcfe.LogId = l.Id      
 left outer join LogCustomFieldGroup lcfg on lcfg.LogId = l.Id      
 left outer join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId      
 left outer join CustomField cf on cf.Id = cfcfg.CustomFieldId      
 left outer join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId      
    
 left join CustomFieldWithRange cfwr on lcfe.CustomFieldId = cfwr.CustomFieldID    
 And cfwr.id = Substring (DBO.GetCustomFieldColour(l.Id,lcfe.CustomFieldID),3,8)      
    
WHERE      
 l.Deleted = 0 and      
 assoc.ShiftHandoverQuestionnaireId = @ShiftHandoverId 

 GO

GRANT EXEC ON dbo.QueryLogsByShiftHandoverQuestionnaire TO PUBLIC