IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VLog_Internal')
BEGIN
	DROP VIEW VLog_Internal
END
GO

CREATE VIEW dbo.VLog_Internal WITH SCHEMABINDING
AS
select 
	l.Id as LogId,
	l.SourceId,
	l.LogDateTime,
	l.LogType,
	l.WorkAssignmentId,	
	l.PlainTextComments,
	l.CreatedDateTime,
	l.CreatedByRoleId,
	cu.UserName as CreatedByUserName,
	cu.FirstName as CreatedByFirstName,
	cu.LastName as CreatedByLastName,
	cs.Name as ShiftName,
	lu.Username as LastModifiedByUserName,
	lu.Firstname as LastModifiedByFirstName,
	lu.Lastname as LastModifiedByLastName,	
	wa.Name as WorkAssignmentName,
	cr.Name as CreatedByRoleName,
	fl.Id as FunctionalLocationId,
	fl.FullHierarchy as FunctionalLocation,
	s.Id as SiteId,
	s.Name as [Site]
from dbo.[Log] l
inner join dbo.[User] cu on cu.Id = l.UserId
inner join dbo.[User] lu on lu.Id = l.LastModifiedUserId
inner join dbo.Shift cs on cs.Id = l.CreationUserShiftPatternId
left outer join dbo.WorkAssignment wa on wa.Id = l.WorkAssignmentId
inner join dbo.[Role] cr on cr.Id = l.CreatedByRoleId
inner join dbo.LogFunctionalLocation lfl on lfl.LogId = l.Id
inner join dbo.FunctionalLocation fl on fl.Id = lfl.FunctionalLocationId
inner join dbo.[Site] s on s.Id = fl.SiteId
where l.Deleted = 0
GO