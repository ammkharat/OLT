IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingTargetAlerts')
BEGIN
	DROP VIEW VReportingTargetAlerts
	
END
GO

CREATE VIEW dbo.VReportingTargetAlerts WITH SCHEMABINDING
AS
select 
	ta.ID as TargetAlertId,
	ta.TargetDefinitionID,
	td.Name as TargetDefinitionName,
	ta.TargetName,
	ta.NeverToExceedMax,
	ta.NeverToExceedMin,
	ta.MaxValue,
	ta.MinValue,
	ta.NeverToExceedMaxFrequency,
	ta.NeverToExceedMinFrequency,
	ta.MaxValueFrequency,
	ta.MinValueFrequency,
	ta.TargetAlertValue,
	ta.GapUnitValue,
	ta.TargetAlertStatusID,
	ta.ExceedingBoundaries,
	ta.LastModifiedDateTime,
	ta.CreatedDateTime,
	ta.TargetCategoryID,
	ta.CreatedByScheduleTypeId,
	ta.Description,
	ta.RequiresResponse,
	ta.ActualValue,
	ta.TargetValueTypeId,	
	ta.AcknowledgedUserId,
	ta.PriorityId,
	ta.OriginalExceedingValue,
	ta.TypeOfViolationStatusId,
	ta.LastViolatedDateTime,
	ta.MaxAtEvaluation,
	ta.MinAtEvaluation,
	ta.NTEMaxAtEvaluation,
	ta.NTEMinAtEvaluation,
	ta.ActualValueAtEvaluation,	
	t.Name as TagName,
	fl.Id as FunctionalLocationId,
	fl.FullHierarchy as FunctionalLocation,
	s.Id as SiteId,
	s.Name as Site,
	lu.Username as LastModifiedUserName,
	lu.Firstname as LastModifiedFirstName,
	lu.Lastname as LastModifiedLastName,
	au.Username as AcknowledgedUserName,
	au.Firstname as AcknowledgedFirstName,
	au.Lastname as AcknowledgedLastName		
from dbo.TargetAlert ta
inner join dbo.Tag t on t.Id = ta.TagID
inner join dbo.FunctionalLocation fl on fl.Id = ta.FunctionalLocationID
inner join dbo.Site s on s.Id = fl.SiteId
inner join dbo.[User] lu on lu.Id = ta.LastModifiedUserId
inner join dbo.TargetDefinition td on td.Id = ta.TargetDefinitionID
left outer join dbo.[User] au on au.Id = ta.AcknowledgedUserId
GO