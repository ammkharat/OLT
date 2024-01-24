UPDATE 
	WorkAssignment
SET 
	RoleId = (SELECT top 1 Id From [role] where siteid = 12 and [name] = 'LabSpecialist')
WHERE
	SiteId = 12 and RoleId = (SELECT TOP 1 Id from [role] where siteid = 12 and [name] = 'Lab System Analyst/Instrumentation Tech')
GO

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
   re.Id,
   r.Id
FROM
  Role r, RoleElement re
  where r.[Name] = 'Quality Team' and r.SiteId = 12
  and re.[Name] = 'View Priorities - Directives'
  
-- delete role that isn't needed, along with all Work Assignments
DELETE [RoleElementTemplate] WHERE RoleId = (SELECT Id from Role where [name] = 'Lab System Analyst/Instrumentation Tech' and siteid = 12)

DELETE 
  wafl
FROM 
[WorkAssignment] wa 
INNER JOIN WorkAssignmentFunctionalLocation wafl ON wafl.WorkAssignmentId = wa.Id
where 
wa.RoleId = (SELECT Id from Role where [name] = 'Lab System Analyst/Instrumentation Tech' and siteid = 12)

DELETE 
  wavg
FROM 
[WorkAssignment] wa 
INNER JOIN WorkAssignmentVisibilityGroup wavg on wavg.WorkAssignmentId = wa.Id
where 
wa.RoleId = (SELECT Id from Role where [name] = 'Lab System Analyst/Instrumentation Tech' and siteid = 12)

DELETE 
  shcwa
FROM 
[WorkAssignment] wa 
INNER JOIN ShiftHandoverConfigurationWorkAssignment shcwa on shcwa.WorkAssignmentId = wa.Id
where 
wa.RoleId = (SELECT Id from Role where [name] = 'Lab System Analyst/Instrumentation Tech' and siteid = 12)

DELETE WorkAssignment WHERE RoleId = (SELECT Id from Role where [name] = 'Lab System Analyst/Instrumentation Tech' and siteid = 12)

DELETE [Role] where [name] = 'Lab System Analyst/Instrumentation Tech' and siteid = 12
GO

INSERT INTO DocumentRootPathConfiguration ([PathName],UncPath,Deleted) VALUES (
   'Q Drive'  -- PathName - varchar(50)
  ,'\\fsdata\labqadat'  -- UncPath - varchar(200)
  ,0   -- Deleted - bit
)

INSERT INTO DocumentRootPathConfiguration ([PathName],UncPath,Deleted) VALUES (
   'S Drive'  -- PathName - varchar(50)
  ,'\\fsdata\laboppro'  -- UncPath - varchar(200)
  ,0   -- Deleted - bit
)

INSERT INTO DocumentRootPathFunctionalLocation
SELECT c.Id, f.Id FROM DocumentRootPathConfiguration c, FunctionalLocation f
where c.UncPath = '\\fsdata\labqadat' and f.SiteId = 12 and f.FullHierarchy = 'WBL'

INSERT INTO DocumentRootPathFunctionalLocation
SELECT c.Id, f.Id FROM DocumentRootPathConfiguration c, FunctionalLocation f
where c.UncPath = '\\fsdata\laboppro' and f.SiteId = 12 and f.FullHierarchy = 'WBL'
GO

UPDATE SiteConfiguration
SET 
  PreShiftPaddingInMinutes = 60,
  PostShiftPaddingInMinutes = 60,
  AllowCombinedShiftHandoverAndLog = 1,
  DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage = 1,
  ShowCreateShiftHandoverMessageFromNewLogClick = 1
WHERE
  SiteId = 12
  
UPDATE Plant
  SET [Name] = 'Oilsands Labs'
WHERE
  [Name] = 'Oilsands Labs Temp' and SiteId = 12
  
UPDATE Site
  SET 
    [Name] = 'Wood Buffalo Laboratories',
    ActiveDirectoryKey = 'WoodBuffaloLaboratories'
WHERE
  Id = 12
GO

/*
select 'insert ShiftHandoverConfiguration ( Id,Name,Deleted ) '  + 
' select ' +  
case when c.Id is null  then 'null'  else convert(varchar(20),c.Id) end + ',' +  
case when c.[Name] is null  then 'null'  else '''' + c.[Name] COLLATE database_default + '''' end + ',' +  
case when c.Deleted is null  then 'null'  else convert(varchar(20),c.Deleted) end 
from ShiftHandoverConfiguration c 
where EXISTS(select * from ShiftHandoverConfiguration c1 inner join dbo.ShiftHandoverConfigurationWorkAssignment cwa ON cwa.ShiftHandoverConfigurationId = c1.Id
INNER JOIN dbo.WorkAssignment ON dbo.WorkAssignment.Id = cwa.WorkAssignmentId
where dbo.WorkAssignment.SiteId = 12 and c1.Id = c.Id)
order by c.Id

select 'insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId ) '  + 
' select c.Id,' +  
'w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = ''' + b.name + ''' and w.siteid = ' + convert(varchar, b.siteid) +
' and c.[Name] = ''' + c.[name] + '''' + ' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = ''Regular Unit Leader Handover'')'
from ShiftHandoverConfigurationWorkAssignment a,
WorkAssignment b,
ShiftHandoverConfiguration c
where a.shifthandoverconfigurationid = c.id
and a.workassignmentid = b.id
and b.siteid = 12 
and c.[Name] = 'Regular Unit Leader Handover'
order by b.siteid, c.id, b.[name]
*/

UPDATE ShiftHandoverConfiguration SET deleted = 1 where [Name] LIKE 'Wood Buffalo%'
GO

insert ShiftHandoverConfiguration ( [Name],Deleted )  select 'Regular Lab Tech Handover',0
insert ShiftHandoverConfiguration ( [Name],Deleted )  select 'Regular Supervisor Handover',0
insert ShiftHandoverConfiguration ( [Name],Deleted )  select 'Regular Unit Leader Handover',0

insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Extraction 1 Day Shift Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Extraction 2 Day Shift Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'GC Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'ICP Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Instrumentation Technician' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Night Shift Extraction' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Night Shift Projects' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Night Shift Upgrading 1/3' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Night Shift Upgrading 2/4' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Projects Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'QA Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Upgrading 1 Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Upgrading 2 Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Upgrading 3 Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Upgrading 4 Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Waters 1 Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Waters 2 Lab Tech' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')

insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Lab Supervisor' and w.siteid = 12 and c.[Name] = 'Regular Supervisor Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Supervisor Handover')
insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'Unit Leader' and w.siteid = 12 and c.[Name] = 'Regular Unit Leader Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Unit Leader Handover')
GO

/*
select 
replace
(
	replace
	(
		replace
		(
			replace
			(
			'insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, ' + convert(varchar,a.displayorder) + ', ''' + replace(a.text, '''', '''''') + ''', ' + case when HelpText is null  then 'null'  else '''' + replace(HelpText, '''', '''''') COLLATE database_default + '''' end + ', ' + convert(varchar,a.deleted) + ', '  + convert(varchar,a.IsCurrentQuestionVersion) +
      ' FROM ShiftHandoverConfiguration c WHERE c.[Name] = ''Regular Unit Leader Handover''', 
				CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10), 
				''' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + '''
			), 
			CHAR(13) + CHAR(10), 
			''' + CHAR(13) + CHAR(10) + '''
		), 
		' '' + CHAR(13)',
		''' + CHAR(13)'
	),
	'-',
	'-'
)
from dbo.ShiftHandoverQuestion a,
ShiftHandoverConfiguration c
where a.shifthandoverconfigurationid = c.id
and c.[Name] = 'Regular Unit Leader Handover'
and a.Deleted = 0 and a.IsCurrentQuestionVersion = 1
order by c.id, a.displayorder
*/
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 0, 'Were there any Health or Safety concerns during this shift?', 'TBD', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Lab Tech Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 1, 'Were there any problems with calibration or controls?', 'TBD', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Lab Tech Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 2, 'Do you have any work for the next shift to complete?', 'TBD', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Lab Tech Handover'


insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 0, 'Any safety concerns?', 'Briefly describe all safety issues that came up during your shift. Remember to include ILP #s, if any.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Supervisor Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 1, 'Any new projects coming up?', 'Briefly describe new projects started during your shift and/or new projects going to be started in the upcoming shift. Include the scope and start & end dates.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Supervisor Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 2, 'Any projects completed?', 'Briefly mention the projects that were completed during your shift.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Supervisor Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 3, 'Any instrument/procedure/people issues?', 'Briefly state any information that might be useful for the upcoming shift. Information in this report will be shared at the first  08:00 shift meeting of the new shift coming in.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Supervisor Handover'

insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 0, 'Are there any supplies that are critically low?', 'Briefly describe all information to be conveyed to the incoming UL.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Unit Leader Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 1, 'Are there any supplies that need to be ordered?', 'Briefly describe all information to be conveyed to the incoming UL.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Unit Leader Handover'
GO

UPDATE [Role]
  Set [Name] = 'Lab Specialist'
WHERE
  [Name] = 'LabSpecialist' and Siteid = 12
  
UPDATE [Role]
  SET [ActiveDirectoryKey] = 'LabSupervisor'
WHERE
  [Name] = 'Lab Supervisor' and SiteId = 12
GO  

 INSERT INTO RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) SELECT 
   r.Id, 4, 10, null from dbo.[Role] r where r.[Name] = 'Lab Supervisor' and r.SiteId = 12
GO


/*
select * from logtemplate lt
where EXISTS(SELECT * from logtemplate lt1 INNER JOIN dbo.LogTemplateWorkAssignment ltwa ON ltwa.LogTemplateId = lt1.Id
              INNER JOIN dbo.WorkAssignment ON dbo.WorkAssignment.Id = ltwa.WorkAssignmentId where dbo.WorkAssignment.SiteId = 12 and lt.id = lt1.Id)

select 'insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives) '  + 
' select ' +  
case when lt.Name is null  then 'null'  else '''' + Name COLLATE database_default + '''' end + ',' +
case when lt.Text is null  then 'null'  else '''' + 
	replace
	(
		replace
		(
			lt.Text,
			'''',
			''''''
		), 
		CHAR(13) + CHAR(10), 
		''' + CHAR(13) + CHAR(10) + '''
	)
	COLLATE database_default + '''' end + ',' +  
'0, ' +
case when lt.LastModifiedDateTime is null  then 'null'  else '''' + convert(varchar,lt.LastModifiedDateTime,100) COLLATE database_default + '''' end + ',' +  
'0, ' +
case when lt.CreatedDateTime is null  then 'null'  else '''' + convert(varchar,lt.CreatedDateTime,100) COLLATE database_default + '''' end + ',' +
convert(varchar, lt.AppliesToLogs) + ',' +
convert(varchar, lt.AppliesToSummaryLogs) + ',' +
convert(varchar, lt.AppliesToDirectives)
from LogTemplate lt
where EXISTS(SELECT * from logtemplate lt1 INNER JOIN dbo.LogTemplateWorkAssignment ltwa ON ltwa.LogTemplateId = lt1.Id
              INNER JOIN dbo.WorkAssignment ON dbo.WorkAssignment.Id = ltwa.WorkAssignmentId where dbo.WorkAssignment.SiteId = 12 and lt.id = lt1.Id)
order by lt.Id
*/

insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives)  select 'Regular Lab Tech Shift Log','{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1\fcharset2 Symbol;}{\f2 Tahoma;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listtable {\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1524758516}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1196274062}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid1887909711 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1282728252}}{\*\listoverridetable {\listoverride\listid1524758516\listoverridecount0\ls1}{\listoverride\listid1196274062\listoverridecount0\ls2}{\listoverride\listid1282728252\listoverridecount0\ls3}}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f2\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql{\b\ul\f2\fs18\cf0 Quality Notes:}\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls1\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 Instrument Notes:}\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls2\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 Method Notes:}\b\ul\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls3\ql\fi-360\li720\lin720\f2\fs18\par}',0, 'Apr  3 2014  3:56PM',0, 'Mar 30 2014  7:40PM',1,0,0
insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives)  select 'Regular Summary Log','{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1\fcharset2 Symbol;}{\f2 Tahoma;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listtable {\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1183012046}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1745287888}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid2137536830}}{\*\listoverridetable {\listoverride\listid1183012046\listoverridecount0\ls1}{\listoverride\listid1745287888\listoverridecount0\ls2}{\listoverride\listid2137536830\listoverridecount0\ls3}}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f2\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql{\b\ul\f2\fs18\cf0 Instrument Notes:}\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls3\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 Facility Notes:}\b\ul\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls2\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 Upcoming Projects:}\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls1\ql\fi-360\li720\lin720\f2\fs18\par}',0, 'Mar 30 2014  7:50PM',0, 'Mar 30 2014  7:41PM',0,1,0
insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives)  select 'Regular Lab Specialist Shift Log','{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1\fcharset2 Symbol;}{\f2 Tahoma;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listtable {\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid694326048}}{\*\listoverridetable {\listoverride\listid694326048\listoverridecount0\ls1}}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f2\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql{\b\ul\f2\fs18\cf0 Notes:}\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls1\ql\fi-360\li720\lin720\f2\fs18\par}',0, 'Apr  3 2014  3:56PM',0, 'Mar 30 2014  7:42PM',1,0,0
GO

/*
select 'insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId ) '  + 
' select lt.Id,' +  
'w.id from WorkAssignment w, LogTemplate lt where w.name = ''' + b.name + ''' and w.siteid = ' + convert(varchar, b.siteid) +
' and lt.[name] = ' + '''' + 'Regular Lab Tech Shift Log' + ''''
from LogTemplateWorkAssignment a
INNER JOIN WorkAssignment b on a.WorkAssignmentId = b.Id
INNER JOIN LogTemplate t on t.Id = a.LogTemplateId
and b.siteid = 12
and t.[Name] = 'Regular Lab Tech Shift Log'
order by b.siteid, a.LogTemplateId, b.name
*/

insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Extraction 1 Day Shift Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Extraction 2 Day Shift Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'GC Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'ICP Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Instrumentation Technician' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Extraction' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Projects' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Upgrading 1/3' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Upgrading 2/4' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Projects Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'QA Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 1 Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 2 Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 3 Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 4 Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Waters 1 Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Waters 2 Lab Tech' and w.siteid = 12 and lt.[name] = 'Regular Lab Tech Shift Log'

insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Lab Supervisor' and w.siteid = 12 and lt.[name] = 'Regular Summary Log'

insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Lab Specialist' and w.siteid = 12 and lt.[name] = 'Regular Lab Specialist Shift Log'
GO

UPDATE wa
  SET wa.AutoInsertLogTemplateId = lt.Id
FROM WorkAssignment wa
INNER JOIN LogTemplateWorkAssignment a ON wa.Id = a.WorkAssignmentId
INNER JOIN LogTemplate lt ON lt.Id = a.LogTemplateId
WHERE lt.[Name] = 'Regular Lab Tech Shift Log'
and wa.SiteId = 12
GO

UPDATE wa
  SET wa.AutoInsertLogTemplateId = lt.Id
FROM WorkAssignment wa
INNER JOIN LogTemplateWorkAssignment a ON wa.Id = a.WorkAssignmentId
INNER JOIN LogTemplate lt ON lt.Id = a.LogTemplateId
WHERE lt.[Name] = 'Regular Summary Log'
and wa.SiteId = 12
GO