IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingActionItems')
BEGIN
	DROP VIEW VReportingActionItems
END
GO

CREATE VIEW dbo.[VReportingActionItems] WITH SCHEMABINDING
AS
select
	ai.Id as ActionItemId,
	ai.ResponseRequired,
	ai.ActionItemStatusId,
	ai.[Description],
	ai.StartDateTime,
	ai.EndDateTime,
	ai.ShiftAdjustedEndDateTime,
	ai.SourceId,
	ai.createdByScheduleTypeId,
	ai.Name,
	ai.PreviousActionItemStatusId,
	ai.StatusModifiedDateTime,
	ai.CreatedByActionItemDefinitionId,
	ai.PriorityId,
	bc.Name as BusinessCategory,
	wa.Id as WorkAssignmentId,
	wa.Name as WorkAssignment,
	fl.Id as FunctionalLocationId,
	fl.FullHierarchy as FunctionalLocation,
	s.Id as SiteId,
	s.Name as Site
from 
	dbo.ActionItem ai	
	inner join dbo.BusinessCategory bc on bc.Id = ai.BusinessCategoryId
	left outer join dbo.WorkAssignment wa on wa.Id = ai.WorkAssignmentId
	inner join dbo.ActionItemFunctionalLocation aifl on aifl.ActionItemId = ai.Id
	inner join dbo.FunctionalLocation fl on fl.Id = aifl.FunctionalLocationId
	inner join dbo.Site s on s.Id = fl.SiteId
where 
	ai.Deleted = 0

GO
