IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldTrendReportDTOsForLogsByFlocDateRangeAndAssignment')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldTrendReportDTOsForLogsByFlocDateRangeAndAssignment
	END
GO

CREATE Procedure [dbo].QueryCustomFieldTrendReportDTOsForLogsByFlocDateRangeAndAssignment
	(
		@StartOfDateRange DateTime,
        @EndOfDateRange DateTime,   	   
		@CsvFLOCIds varchar(max),
		@CsvAssignmentIds varchar(max),
		@IncludeNullAssignment bit,
		@LogType int
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
	l.Deleted = 0 AND
	l.LogType = @LogType AND
	l.CreatedDateTime <= @EndOfDateRange AND
    l.CreatedDateTime >= @StartOfDateRange AND
	(
		(@IncludeNullAssignment = 1 and l.WorkAssignmentId is null) or
		exists
		(
			select QueryAssignmentIds.Id
			from IDSplitter(@CsvAssignmentIds) QueryAssignmentIds
			where QueryAssignmentIds.Id = l.WorkAssignmentId
		)
	) AND
	( EXISTS
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
select 
	l.Id,
	l.LogType,
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
	lcfe.CustomFieldId,
	lcfe.CustomFieldName,
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
	[Log] l
	INNER JOIN Log_Id_CTE ON Log_Id_CTE.LogId = l.Id
	INNER JOIN LogFunctionalLocationList floclist on flocList.LogId = l.Id
	inner join [User] lastModifiedUser on l.LastModifiedUserId = lastModifiedUser.Id
	inner join Shift s on s.Id = l.CreationUserShiftPatternId
	inner join [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId	
	left outer join WorkAssignment wa on wa.Id = l.WorkAssignmentId
	left outer join LogCustomFieldEntry lcfe on lcfe.LogId = l.Id
	
	left outer join LogCustomFieldGroup lcfg on lcfg.LogId = l.Id
	left outer join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldGroupId = lcfg.CustomFieldGroupId
	left outer join CustomField cf on cf.Id = cfcfg.CustomFieldId
	left outer join CustomFieldGroup cfg on cfg.Id = cfcfg.CustomFieldGroupId
where cf.TypeId not in (3,4)
OPTION (OPTIMIZE FOR UNKNOWN) 	
GO

GRANT EXEC ON QueryCustomFieldTrendReportDTOsForLogsByFlocDateRangeAndAssignment TO PUBLIC
GO
