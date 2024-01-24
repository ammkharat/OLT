IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingSummaryLogs')
BEGIN
	DROP VIEW VReportingSummaryLogs
END
GO

CREATE VIEW dbo.[VReportingSummaryLogs] WITH SCHEMABINDING
AS
select 
	sl.Id as SummaryLogId,
	sl.LogDateTime,
	sl.LastModifiedDateTime,
	sl.CreatedDateTime,
	sl.PlainTextComments,
	sl.DorComments,
	cu.Username as CreatedByUserName,
	cu.Firstname as CreatedByFirstName,
	cu.Lastname as CreatedByLastName,
	cs.Name as ShiftName,
	lmu.Username as LastModifiedByUserName,
	lmu.Firstname as LastModifiedByFirstName,
	lmu.Lastname as LastModifiedByLastName,
	r.Name as CreatedByRole,
	fl.Id as FunctionalLocationId,
	fl.FullHierarchy as FunctionalLocation,
	s.Id as SiteId,
	s.Name as [Site]
from dbo.SummaryLog sl
	inner join dbo.[User] cu on cu.Id = sl.CreatedByUserId
	inner join dbo.[User] lmu on lmu.Id = sl.LastModifiedUserId
	inner join dbo.Shift cs on cs.Id = sl.CreationUserShiftPatternId
	left outer join dbo.WorkAssignment wa on wa.Id = sl.WorkAssignmentId
	inner join dbo.[Role] r on r.Id = sl.CreatedByRoleId
	inner join dbo.SummaryLogFunctionalLocation slfl on slfl.SummaryLogId = sl.Id
	inner join dbo.FunctionalLocation fl on fl.Id = slfl.FunctionalLocationId
	inner join dbo.[Site] s on s.Id = fl.SiteId
where sl.Deleted = 0

GO
