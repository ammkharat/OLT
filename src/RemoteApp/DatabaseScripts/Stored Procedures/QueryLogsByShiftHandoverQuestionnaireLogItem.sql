IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogsByShiftHandoverQuestionnaireLogItem')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogsByShiftHandoverQuestionnaireLogItem
	END
GO
 
CREATE Procedure [dbo].[QueryLogsByShiftHandoverQuestionnaireLogItem]      
 (      
  @ShiftHandoverId BIGINT      
 )      
AS      
    
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
    --inner join ShiftHandoverQuestionnaireLog assoc ON assoc.LogId = l.Id 
    
    inner join ShiftLogAndSummaryLogMapping m On l.Id  = m.LogId
    inner join SummaryLog sl On sl.Id = m.SummaryLogId
    inner join ShiftHandoverQuestionnaireSummaryLog assocsl On assocsl.SummaryLogId = sl.Id 
         
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
 assocsl.ShiftHandoverQuestionnaireId = @ShiftHandoverId  
 
GRANT EXEC ON QueryLogsByShiftHandoverQuestionnaireLogItem TO PUBLIC
GO
  