IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'zz_TDSInsertLogTemplate')
	BEGIN
		DROP  Procedure  zz_TDSInsertLogTemplate
	END
GO

CREATE Procedure [dbo].[zz_TDSInsertLogTemplate]
(    
    @Name varchar(128),
	@Text varchar(MAX),
	@AppliesToLogs bit,
	@AppliesToSummaryLogs bit,
 	@AppliesToDirectives bit	
)
AS

DECLARE @dateValue as datetime;
set @dateValue = GETDATE();

INSERT INTO [LogTemplate]
(	
    [Name], 
	[Text],
	[AppliesToLogs],
	[AppliesToSummaryLogs],
  [AppliesToDirectives],
	[LastModifiedUserId],
	[LastModifiedDateTime],
	[CreatedUserId],
	[CreatedDateTime]	
)
VALUES
(
    @Name,
	@Text,
	@AppliesToLogs,
	@AppliesToSummaryLogs,
  @AppliesToDirectives,
	-1,
	@dateValue,
	-1,
	@dateValue
)
GO


DECLARE @bigText as varchar(max);
set @bigText = '{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1\fcharset2 Symbol;}{\f2 Tahoma;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listtable {\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1572813336}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1657843079}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid860227452}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid994469251 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1848920920}}{\*\listoverridetable {\listoverride\listid1572813336\listoverridecount0\ls1}{\listoverride\listid1657843079\listoverridecount0\ls2}{\listoverride\listid860227452\listoverridecount0\ls3}{\listoverride\listid1848920920\listoverridecount0\ls4}}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f2\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql{\b\ul\f2\fs18\cf0 EHS Concerns:}\b\ul\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls1\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 Switching Activities:}\b\ul\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls2\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 Maintenance Concerns:}\b\ul\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls3\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 General Comments:}\b\ul\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls4\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par}'
exec zz_TDSInsertLogTemplate 'Log Template', @bigText, 1, 1, 0
GO

INSERT INTO LogTemplateWorkAssignment (LogTemplateId, WorkAssignmentId) SELECT IDENT_CURRENT('LogTemplate'), wa.Id from WorkAssignment wa where SiteId = 6 and [Name] = 'Firebag OM Technician';
INSERT INTO LogTemplateWorkAssignment (LogTemplateId, WorkAssignmentId) SELECT IDENT_CURRENT('LogTemplate'), wa.Id from WorkAssignment wa where SiteId = 6 and [Name] = 'Oilsands OM Technician';
INSERT INTO LogTemplateWorkAssignment (LogTemplateId, WorkAssignmentId) SELECT IDENT_CURRENT('LogTemplate'), wa.Id from WorkAssignment wa where SiteId = 6 and [Name] = 'Firebag Protection Specialist';
INSERT INTO LogTemplateWorkAssignment (LogTemplateId, WorkAssignmentId) SELECT IDENT_CURRENT('LogTemplate'), wa.Id from WorkAssignment wa where SiteId = 6 and [Name] = 'Oilsands Protection Specialist';
INSERT INTO LogTemplateWorkAssignment (LogTemplateId, WorkAssignmentId) SELECT IDENT_CURRENT('LogTemplate'), wa.Id from WorkAssignment wa where SiteId = 6 and [Name] = 'SCC Operator';
INSERT INTO LogTemplateWorkAssignment (LogTemplateId, WorkAssignmentId) SELECT IDENT_CURRENT('LogTemplate'), wa.Id from WorkAssignment wa where SiteId = 6 and [Name] = 'Firebag Shift Supervisor';
INSERT INTO LogTemplateWorkAssignment (LogTemplateId, WorkAssignmentId) SELECT IDENT_CURRENT('LogTemplate'), wa.Id from WorkAssignment wa where SiteId = 6 and [Name] = 'Oilsands Shift Supervisor';
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'zz_TDSInsertLogTemplate')
	BEGIN
		DROP  Procedure  zz_TDSInsertLogTemplate
	END
GO