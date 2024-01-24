  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDTOByFlocDateRangeShiftAndAssignment')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogDTOByFlocDateRangeShiftAndAssignment
    END
GO

CREATE  Procedure [dbo].QueryLogDTOByFlocDateRangeShiftAndAssignment  
 (  
  @StartOfDateRange DateTime,  
  @EndOfDateRange DateTime,         
  @CsvFLOCIds varchar(max),  
  @ShiftId bigint,  
  @WorkAssignmentId bigint = null,  
  @UserId bigint ,
  @IsFlexible bit = 0  
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
 l.Deleted = 0 AND  
 l.LogType = 1 AND  
 l.CreatedDateTime <= @EndOfDateRange AND  
 l.CreatedDateTime >= @StartOfDateRange AND
 -- flexi shift handover 
 l.CreationuserShiftPatternId = case when  @IsFlexible = 0 then @ShiftId else l.CreationuserShiftPatternId end AND      
 --l.CreationuserShiftPatternId = @ShiftId AND   
 (  
  (@WorkAssignmentId is not null AND @WorkAssignmentId = l.WorkAssignmentId) OR  
  (@WorkAssignmentId is null AND l.WorkAssignmentId is null AND l.UserId = @UserId)  
 )  
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
 cf.PhdLinkTypeId as ActualPhdLinkTypeId  
FROM  
    [Log] l   
    inner join Log_Id_CTE ON Log_Id_CTE.LogId = l.Id  
 INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id  
    inner join [User] createdByUser on l.UserId = createdByUser.Id  
 left outer join LogCustomFieldEntry lcfe on lcfe.LogId = l.Id  
   
 left outer join LogCustomFieldGroup lcfg on lcfg.LogId = l.Id  
 left outer join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId  
 left outer join CustomField cf on cf.Id = cfcfg.CustomFieldId  
 left outer join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId  
OPTION (OPTIMIZE FOR UNKNOWN)    

GRANT EXEC ON QueryLogDTOByFlocDateRangeShiftAndAssignment TO PUBLIC
