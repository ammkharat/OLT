IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDTOByFlocShiftRangeAndAssignment')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogDTOByFlocShiftRangeAndAssignment
    END
GO

CREATE Procedure [dbo].QueryLogDTOByFlocShiftRangeAndAssignment
    (
        @CsvFlocIds VARCHAR(MAX),
		@CsvWorkAssignmentIds VARCHAR(MAX),
		@IncludeNullAssignment BIT,
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime
    )
AS
WITH Log_Id_CTE (LogId)
AS 
(
  SELECT 
    DISTINCT l.Id 
  FROM
    [Log] l
  WHERE
    l.deleted = 0 AND
    l.LogType = 1 AND
    l.CreatedDateTime <= @EndOfDateRange AND
    l.CreatedDateTime >= @StartOfDateRange AND
	(
		(@IncludeNullAssignment = 1 and l.WorkAssignmentId is null) or
		exists
		(	
  			select QueryAssignmentIds.Id
	  		from IDSplitter(@CsvWorkAssignmentIds) QueryAssignmentIds
		  	where QueryAssignmentIds.Id = l.WorkAssignmentId
		)
	)AND
	( 
		EXISTS
		(
		-- Floc of Log matches one of the passed in flocs
		select lfl.LogId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN LogFunctionalLocation lfl ON ids.Id = lfl.FunctionalLocationId
		WHERE lfl.LogId = l.Id
		)
		OR EXISTS
		(
		  -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select lfl.LogId from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		  INNER JOIN LogFunctionalLocation lfl ON a.Id = lfl.FunctionalLocationId
		  WHERE lfl.LogId = l.Id  
		)
	)
)  
SELECT
  l.Id as Id,

  l.EHSFollowup,
  l.InspectionFollowUp,
  l.OperationsFollowUp,
  l.ProcessControlFollowUp,
  l.SupervisionFollowUp,
  l.OtherFollowUp,

  l.LogDateTime,	
  a.[Name] as WorkAssignmentName,
  l.RecommendForShiftSummary,
  l.CreatedByRoleId,
  l.PlainTextComments,
  l.RtfComments,

  lastModifiedUser.LastName as LastModifiedByLastName,
  lastModifiedUser.FirstName as LastModifiedByFirstName,
  lastModifiedUser.UserName as LastModifiedByUserName,

  s.StartTime as ShiftStartTime,
  s.EndTime as ShiftEndTime,
  s.[id] as ShiftId,
  s.[Name] as ShiftName,

  sc.PreShiftPaddingInMinutes as PreShiftPaddingInMinutes,
  sc.PostShiftPaddingInMinutes as PostShiftPaddingInMinutes,

  fl.FullHierarchy as FunctionalLocationName,
  fl.Description as FunctionalLocationDescription,

	d.Title  as DocumentLinkTitle,
  d.Link as DocumentLinkUrl,
	
	lcfe.Id as CustomFieldEntryId,
	lcfe.CustomFieldName as CustomFieldName,
	lcfe.CustomFieldId,
	lcfe.FieldEntry as CustomFieldEntry,
	lcfe.NumericFieldEntry as NumericCustomFieldEntry,
	lcfe.DisplayOrder as CustomFieldDisplayOrder,
	lcfe.TypeId as CustomFieldTypeId,
	lcfe.PhdLinkTypeId as CustomFieldPhdLinkTypeId,
	
	cf.Id as ActualCustomFieldId,
	cf.Name as ActualCustomFieldName,
	cfcfg.DisplayOrder as ActualCustomFieldDisplayOrder,
	cfcfg.CustomFieldGroupId,
	cfg.OriginCustomFieldGroupId,
	cf.OriginCustomFieldId,
	cf.TypeId as ActualCustomFieldTypeId,
	cf.PhdLinkTypeId as ActualCustomFieldPhdLinkTypeId
	
	,Substring (DBO.GetCustomFieldColour(lcfg.LogId,lcfe.CustomFieldID),1,1) AS COLOR,  lcfg.LogId  
FROM
  [Log] l 
  INNER JOIN Log_Id_CTE ON Log_Id_CTE.LogId = l.Id
  INNER JOIN [LogFunctionalLocation] lfl on lfl.LogId = l.Id
  INNER JOIN [FunctionalLocation] fl on fl.Id = lfl.FunctionalLocationId
  INNER JOIN [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
  INNER JOIN [Shift] s on l.CreationUserShiftPatternId = s.Id 	
  INNER JOIN [SiteConfiguration] sc on s.SiteId = sc.SiteId
  LEFT OUTER JOIN [WorkAssignment] a on a.id = l.WorkAssignmentId
  LEFT OUTER JOIN [DocumentLink] d on l.Id = d.LogId
  LEFT OUTER JOIN [LogCustomFieldEntry] lcfe on l.Id = lcfe.LogId
	
  	left outer join LogCustomFieldGroup lcfg on lcfg.LogId = l.Id
	left outer join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId
	left outer join CustomField cf on cf.Id = cfcfg.CustomFieldId
	left outer join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId
	
	left join CustomFieldWithRange cfwr on cf.ID = cfwr.CustomFieldID 
	
OPTION (OPTIMIZE FOR UNKNOWN) 	
GO

GRANT EXEC on QueryLogDTOByFlocShiftRangeAndAssignment TO PUBLIC
GO