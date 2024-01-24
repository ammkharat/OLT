IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldTrendReportDTOsForSummaryLogsByFlocDateRangeAndAssignment')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldTrendReportDTOsForSummaryLogsByFlocDateRangeAndAssignment
	END
GO

CREATE Procedure [dbo].QueryCustomFieldTrendReportDTOsForSummaryLogsByFlocDateRangeAndAssignment
	(
		@StartOfDateRange DateTime,
        @EndOfDateRange DateTime,   	   
		@CsvFLOCIds varchar(max),
		@CsvAssignmentIds varchar(max),
		@IncludeNullAssignment bit
	)
AS

select 
	l.Id,
	l.LogDateTime, 
	s.Name as ShiftName,
	s.StartTime as ShiftStartDateTime,
    s.EndTime as ShiftEndDateTime,
	s.Id as ShiftId,
	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes,
	floclist.FunctionalLocationList as FunctionalLocations,
	lastModifiedUser.Username as LastModifiedByUserName,
	lastModifiedUser.Firstname as LastModifiedByFirstName,
	lastModifiedUser.Lastname as LastModifiedByLastName,
	wa.Name as WorkAssignmentName,
	
	lcfe.Id as CustomFieldEntryId,
	lcfe.CustomFieldId as CustomFieldId,
	lcfe.SummaryLogCustomFieldName as CustomFieldName,
	lcfe.FieldEntry,
	lcfe.NumericFieldEntry,
	lcfe.DisplayOrder,
	lcfe.TypeId,
	lcfe.PhdLinkTypeId,
	
	cf.Id as ActualCustomFieldId,
	cf.Name as ActualCustomFieldName,
	cfcfg.DisplayOrder as ActualCustomFieldDisplayOrder,
	cfcfg.CustomFieldGroupId,
	cfg.OriginCustomFieldGroupId,
	cf.OriginCustomFieldId,
	cf.TypeId as ActualTypeId,
	cf.PhdLinkTypeId as ActualPhdLinkTypeId
from 
    SummaryLog l
	INNER JOIN SummaryLogFunctionalLocationList floclist on flocList.SummaryLogId = l.Id
    inner join [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
	inner join Shift s on s.Id = l.CreationUserShiftPatternId
	inner join [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId
	left outer join WorkAssignment wa on wa.Id = l.WorkAssignmentId
	left outer join SummaryLogCustomFieldEntry lcfe on lcfe.SummaryLogId = l.Id
	left outer join SummaryLogCustomFieldGroup lcfg on lcfg.SummaryLogId = l.Id
	left outer join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId
	left outer join CustomField cf on cf.Id = cfcfg.CustomFieldId
	left outer join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId
WHERE 
	cf.TypeId not in (3,4) AND
	l.Deleted = 0 AND
	l.CreatedDateTime <= @EndOfDateRange AND
    l.CreatedDateTime >= @StartOfDateRange AND
	EXISTS
	(
		-- Floc of Log matches one of the passed in flocs
		select lfl.SummaryLogId From IDSplitter(@CsvFLOCIds) ids
		INNER JOIN SummaryLogFunctionalLocation lfl ON ids.Id = lfl.FunctionalLocationId
		WHERE lfl.SummaryLogId = l.Id
		UNION ALL   
		-- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select lfl.SummaryLogId from FunctionalLocationAncestor a
		INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
		INNER JOIN SummaryLogFunctionalLocation lfl ON a.Id = lfl.FunctionalLocationId
		WHERE lfl.SummaryLogId = l.Id
	)
	and
	(
		(@IncludeNullAssignment = 1 and l.WorkAssignmentId is null) or
		exists
		(
			select QueryAssignmentIds.Id
			from IDSplitter(@CsvAssignmentIds) QueryAssignmentIds
			where QueryAssignmentIds.Id = l.WorkAssignmentId
		)
	)
OPTION (OPTIMIZE FOR UNKNOWN) 
GO

GRANT EXEC ON QueryCustomFieldTrendReportDTOsForSummaryLogsByFlocDateRangeAndAssignment TO PUBLIC
GO
