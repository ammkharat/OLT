IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VFirebagLogs')
BEGIN
	DROP VIEW VFirebagLogs
END
GO

CREATE VIEW [dbo].[VFirebagLogs] WITH SCHEMABINDING
AS
select 
	l.LogDateTime [Logged Date],
	u.firstname + ' ' + u.lastname as [User name],
	'General Comments' as [Comment Category],
	l.PlainTextComments as comment,
	f.description as [floc description],
	f.FullHierarchy as [FullHiearchy],
	CASE 
		WHEN (level2.FullHierarchy IS NOT NULL) THEN
			SUBSTRING(level2.FullHierarchy, CHARINDEX('-', level2.FullHierarchy) + 1, LEN(level2.FullHierarchy))  
		ELSE
			SUBSTRING(f.FullHierarchy, CHARINDEX('-', f.FullHierarchy) + 1, LEN(f.FullHierarchy))  
	END as [Section],
	r.id as [role id],
	r.[name] as RoleName,
	f.Siteid
FROM
	[dbo].[Log] l
	INNER JOIN [dbo].LogFunctionalLocation lfl ON
		lfl.Logid = l.id
	INNER JOIN [dbo].FunctionalLocation f ON
		f.id = lfl.functionallocationid
	LEFT OUTER JOIN [dbo].FunctionalLocationAncestor a oN
		a.id = f.id and a.AncestorLevel = 2
	LEFT OUTER JOIN [dbo].FunctionalLocation level2 ON
		level2.Id = a.AncestorId
	INNER JOIN [dbo].[User] u ON
		u.[id] = l.userid
	INNER JOIN [dbo].[Role] r ON
		l.CreatedByRoleId = r.id	
WHERE
	(f.SiteId = 5 or f.SiteId = 7)
	and l.deleted = 0
UNION ALL

Select
	sl.LogDateTime [Logged Date],
	u.firstname + ' ' + u.lastname as [User name],
	'General Comments' as [Comment Category],
	sl.PlainTextComments as comment,
	f.description as [floc description],
	f.FullHierarchy as [FullHiearchy],
	CASE 
		WHEN (level2.FullHierarchy IS NOT NULL) THEN
			SUBSTRING(level2.FullHierarchy, CHARINDEX('-', level2.FullHierarchy) + 1, LEN(level2.FullHierarchy))  
		ELSE
			SUBSTRING(f.FullHierarchy, CHARINDEX('-', f.FullHierarchy) + 1, LEN(f.FullHierarchy))  
	END as [Section],
	r.id as [role id],
	r.name as RoleName,
	f.Siteid
FROM
	[dbo].[SummaryLog] sl
	INNER JOIN [dbo].SummaryLogFunctionalLocation slfl ON
		slfl.summarylogid = sl.id
	INNER JOIN [dbo].FunctionalLocation f ON
		f.id = slfl.functionallocationid
	INNER JOIN [dbo].FunctionalLocationAncestor a oN
		a.id = f.id and a.AncestorLevel = 2
	INNER JOIN [dbo].FunctionalLocation level2 ON
		level2.Id = a.AncestorId
	INNER JOIN [dbo].[User] u ON
		u.[id] = sl.createdbyuserid	
	LEFT JOIN [dbo].Role r ON
		r.Name = 'Supervisor' and r.SiteId = f.SiteId
WHERE
	(f.SiteId = 5 or f.SiteId = 7)
	and sl.deleted = 0
GO