IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingTargetDefinitions')
BEGIN
	DROP VIEW VReportingTargetDefinitions
	
END
GO

CREATE VIEW dbo.VReportingTargetDefinitions WITH SCHEMABINDING
AS
select 
	td.Id as TargetDefinitionId,
	td.Name as TargetDefinitionName,
	td.NeverToExceedMax,
	td.NeverToExceedMin,
	td.MaxValue,
	td.MinValue,
	td.NeverToExceedMaxFrequency,
	td.MaxValueFrequency,
	td.TargetDefinitionValue,
	td.GapUnitValue,
	td.TargetDefinitionStatusID,
	td.TargetCategoryID,
	t.Name as TagName,
	fl.Id as FunctionalLocationId,
	fl.FullHierarchy as FunctionalLocation,
	s.Id as SiteId,
	s.Name as [Site],	
	lu.Username as LastModifiedUserName,
	lu.FirstName as LastModifiedFirstName,
	lu.Lastname as LastModifiedLastName,
	td.LastModifiedDateTime,
	td.GenerateActionItem,
	td.Description,
	sch.ScheduleTypeId,
	sch.LastInvokedDateTime as ScheduleLastInvokedDateTime,
	sch.StartDateTime as ScheduleStartDateTime,
	sch.EndDateTime as ScheduleEndDateTime,
	sch.FromTime as ScheduleFromTime,
	sch.ToTime as ScheduleToTime,
	td.AlertRequired,
	td.RequiresApproval,
	td.RequiresResponseWhenAlerted,
	td.IsActive,
	td.OperationalModeId,
	td.TargetValueTypeId,
	td.PriorityId,
	td.PreApprovedNeverToExceedMax,
	td.PreApprovedNeverToExceedMin,
	td.PreApprovedMax,
	td.PreApprovedMin
from dbo.TargetDefinition td
	inner join dbo.Tag t on t.Id = td.TagID	
	inner join dbo.FunctionalLocation fl on fl.Id = td.FunctionalLocationID
	inner join dbo.[Site] s on s.Id = fl.SiteId
	inner join dbo.[User] lu on lu.Id = td.LastModifiedUserId
	inner join dbo.Schedule sch on sch.Id = td.ScheduleId
where td.Deleted = 0
GO