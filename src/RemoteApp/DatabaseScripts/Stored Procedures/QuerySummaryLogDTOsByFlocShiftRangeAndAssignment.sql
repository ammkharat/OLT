IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogDTOsByFlocShiftRangeAndAssignment')
    BEGIN
        DROP PROCEDURE [dbo].QuerySummaryLogDTOsByFlocShiftRangeAndAssignment
    END
GO

CREATE Procedure [dbo].QuerySummaryLogDTOsByFlocShiftRangeAndAssignment
    (
        @CsvFlocIds VARCHAR(MAX),
		@CsvWorkAssignmentIds VARCHAR(MAX),
		@IncludeNullAssignment BIT,
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime
    )
as
WITH l_cte (LogId)
AS
(
select distinct l.id
from 
	[SummaryLog] l
WHERE 
    l.deleted = 0 AND
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
    ) AND
	( 
		EXISTS
		(
		-- Floc of Log matches one of the passed in flocs
		select lfl.SummaryLogId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN SummaryLogFunctionalLocation lfl ON ids.Id = lfl.FunctionalLocationId
		WHERE lfl.SummaryLogId = l.Id
		)
		OR EXISTS
		(
		  -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select lfl.SummaryLogId from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		  INNER JOIN SummaryLogFunctionalLocation lfl ON a.Id = lfl.FunctionalLocationId
		  WHERE lfl.SummaryLogId = l.Id  
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
	l.DataSourceId,

    l.LogDateTime,	
	a.Name as WorkAssignmentName,
	null as RecommendForShiftSummary,
	l.CreatedByRoleId,
	l.PlainTextComments,
	l.RtfComments,

    lastModifiedUser.LastName as LastModifiedByLastName,
    lastModifiedUser.FirstName as LastModifiedByFirstName,
    lastModifiedUser.UserName as LastModifiedByUserName,

    s.StartTime as ShiftStartTime,
    s.EndTime as ShiftEndTime,
    s.[id] as ShiftId,
    s.Name as ShiftName,
	
	sc.PreShiftPaddingInMinutes as PreShiftPaddingInMinutes,
	sc.PostShiftPaddingInMinutes as PostShiftPaddingInMinutes,

    fl.FullHierarchy as FunctionalLocationName,
	fl.Description as FunctionalLocationDescription,
	
	d.Title  as DocumentLinkTitle,
	d.Link as DocumentLinkUrl,

	slcfe.Id as CustomFieldEntryId,
	slcfe.SummaryLogCustomFieldName as CustomFieldName,
	slcfe.CustomFieldId,
	slcfe.FieldEntry as CustomFieldEntry,
	slcfe.NumericFieldEntry as NumericCustomFieldEntry,
	slcfe.DisplayOrder as CustomFieldDisplayOrder,
	slcfe.TypeId as CustomFieldTypeId,
	slcfe.PhdLinkTypeId as CustomFieldPhdLinkTypeId,
	
	cf.Id as ActualCustomFieldId,
	cf.Name as ActualCustomFieldName,
	cfcfg.DisplayOrder as ActualCustomFieldDisplayOrder,
	cfcfg.CustomFieldGroupId,
	cfg.OriginCustomFieldGroupId,
	cf.OriginCustomFieldId,
	cf.TypeId as ActualCustomFieldTypeId,
	cf.PhdLinkTypeId as ActualCustomFieldPhdLinkTypeId

	 ,Substring (DBO.GetcustomfieldcolourForSummaryLog(lcfg.SummaryLogId,slcfe.CustomFieldID),1,1) AS COLOR,  lcfg.SummaryLogId 
FROM
	l_cte 
    INNER JOIN [SummaryLog] l on l.Id = l_cte.LogId
    INNER JOIN [SummaryLogFunctionalLocation] lfl on lfl.SummaryLogId = l.Id
    INNER JOIN [FunctionalLocation] fl on fl.Id = lfl.FunctionalLocationId
    INNER JOIN [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
    INNER JOIN [Shift] s on l.CreationUserShiftPatternId = s.Id 	
	INNER JOIN [SiteConfiguration] sc on s.SiteId = sc.SiteId
	LEFT OUTER JOIN [WorkAssignment] a on a.id = l.WorkAssignmentId
	LEFT OUTER JOIN [DocumentLink] d on l.Id = d.SummaryLogId
	LEFT OUTER JOIN [SummaryLogCustomFieldEntry] slcfe on l.Id = slcfe.SummaryLogId
	
	left outer join SummaryLogCustomFieldGroup lcfg on lcfg.SummaryLogId = l.Id
	left outer join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId
	left outer join CustomField cf on cf.Id = cfcfg.CustomFieldId
	left outer join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId

	 left join CustomFieldWithRange cfwr on cf.ID = cfwr.CustomFieldID 
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC on QuerySummaryLogDTOsByFlocShiftRangeAndAssignment TO PUBLIC
GO