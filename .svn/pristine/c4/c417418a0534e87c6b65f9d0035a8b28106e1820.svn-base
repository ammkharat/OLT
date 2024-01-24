insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog) values ('OS Waters 3', 'Oilsands Waters 3 Lab Tech' , 12, 0, 185, 'Day Shift', 1, 0);

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'OS Waters 3' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'OS Waters 3' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'OS Waters 3' and fl.FullHierarchy = 'WBL-OSL-WAT'
GO

INSERT INTO WorkAssignmentVisibilityGroup (VisibilityGroupId, WorkAssignmentId, VisibilityType)
SELECT vg.Id, wa.Id, 1 
from VisibilityGroup vg, WorkAssignment wa 
	where vg.SiteId = 12 and wa.SiteId = 12 and wa.[Name] = 'OS Waters 3';
	
INSERT INTO WorkAssignmentVisibilityGroup (VisibilityGroupId, WorkAssignmentId, VisibilityType)
SELECT vg.Id, wa.Id, 2
from VisibilityGroup vg, WorkAssignment wa 
	where vg.SiteId = 12 and wa.SiteId = 12 and wa.[Name] = 'OS Waters 3';
GO

insert ShiftHandoverConfigurationWorkAssignment ( ShiftHandoverConfigurationId,WorkAssignmentId )  select c.Id,w.id from WorkAssignment w, ShiftHandoverConfiguration c where w.name = 'OS Waters 3' and w.siteid = 12 and c.[Name] = 'Regular Lab Tech Handover' and c.Id = (SELECT MAX(id) FROM ShiftHandoverConfiguration where Name = 'Regular Lab Tech Handover')
GO

DELETE ltwa
FROM
  LogTemplateWorkAssignment ltwa
  INNER JOIN LogTemplate lt on lt.Id = ltwa.LogTemplateId
WHERE
  lt.[Name] IN ('Regular Lab Tech Shift Log', 'Regular Summary Log', 'Regular Lab Specialist Shift Log')
GO

UPDATE WorkAssignment 
  SET AutoInsertLogTemplateId = NULL
WHERE SiteId = 12
GO

DELETE FROM LogTemplate
WHERE [Name] IN ('Regular Lab Tech Shift Log', 'Regular Summary Log', 'Regular Lab Specialist Shift Log')
GO

insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives)  select 'Routine Instrument Maintenance','{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Tahoma;}{\f2 Calibri;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f1\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\trowd\irow0\irowband0\trleft-15\trrh300\trftsWidth3\trwWidth8680\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth8680\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8685\pard\plain\ql\intbl{\b\ul\f2\fs22\cf0 Instrument Maintenance}\cell\trowd\irow0\irowband0\trleft-15\trrh300\trftsWidth3\trwWidth8680\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth8680\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8685\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Instrument Name:}\b\f2\fs20\cf0\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow1\irowband1\trleft-15\trrh300\trftsWidth3\trwWidth8680\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2085\clvertalb\clbrdrt\brdrs\brdrw10\brdrcf0\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8685\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 SAP Number:}\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow2\irowband2\trleft-15\trrh300\trftsWidth3\trwWidth8680\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2085\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8685\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Reason for Maintenance:}\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow3\irowband3\trleft-15\trrh300\trftsWidth3\trwWidth8680\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2085\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8685\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Actions Taken:\~}\b\f2\fs20\cf0\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow4\irowband4\lastrow\trleft-15\trrh300\trftsWidth3\trwWidth8680\trautofit1\tblindtype3\tblind0\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2085\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8685\row\pard\plain\ql\par}',0, 'May 22 2014  1:59PM',0, 'Mar 30 2014  7:40PM',1,0,0
insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives)  select 'Regular Summary Log','{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1\fcharset2 Symbol;}{\f2 Tahoma;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listtable {\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1183012046}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid1745287888}{\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid554359499 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid2137536830}}{\*\listoverridetable {\listoverride\listid1183012046\listoverridecount0\ls1}{\listoverride\listid1745287888\listoverridecount0\ls2}{\listoverride\listid2137536830\listoverridecount0\ls3}}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f2\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql{\b\ul\f2\fs18\cf0 Instrument Notes:}\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls3\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 Facility Notes:}\b\ul\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls2\ql\fi-360\li720\lin720\f2\fs18\par\pard\plain\ql\f2\fs18\par\pard\plain\ql{\b\ul\f2\fs18\cf0 Upcoming Projects:}\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls1\ql\fi-360\li720\lin720\f2\fs18\par}',0, 'Mar 30 2014  7:50PM',0, 'Mar 30 2014  7:41PM',0,1,0
insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives)  select 'Regular Lab Specialist Shift Log','{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1\fcharset2 Symbol;}{\f2 Tahoma;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listtable {\list\listtemplateid-1\listhybrid{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li720\lin720}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li1440\lin1440}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2160\lin2160}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li2880\lin2880}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li3600\lin3600}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li4320\lin4320}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5040\lin5040}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01o;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li5760\lin5760}{\listlevel\levelnfc23\levelnfcn23\leveljc0\leveljcn0\levelfollow0\levelstartat1{\leveltext\leveltemplateid544443840 \''01\u183\''b7;}{\levelnumbers;}\levellegal0\levelnorestart0\f1\cf0\fi-360\li6480\lin6480}{\listname ;}\listid694326048}}{\*\listoverridetable {\listoverride\listid694326048\listoverridecount0\ls1}}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f2\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql{\b\ul\f2\fs18\cf0 Notes:}\f2\fs18\par{\listtext\pard \u183\''b7\tab }\pard\plain\ilvl0\ls1\ql\fi-360\li720\lin720\f2\fs18\par}',0, 'May 15 2014  1:03PM',0, 'Mar 30 2014  7:42PM',1,0,0
insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives)  select 'Quality Control Issue','{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Tahoma;}{\f2 Calibri;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f1\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\trowd\irow0\irowband0\trleft-15\trrh300\trftsWidth3\trwWidth9160\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth2680\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2685\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth6480\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx9165\pard\plain\ql\intbl{\b\ul\f2\fs22\cf0 Quality Control Issue}\f1\fs18\cell\pard\plain\ql\intbl\f1\cell\trowd\irow0\irowband0\trleft-15\trrh300\trftsWidth3\trwWidth9160\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth2680\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2685\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth6480\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx9165\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Quality Issue:}\f1\fs18\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow1\irowband1\trleft-15\trrh300\trftsWidth3\trwWidth9160\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2685\clvertalb\clbrdrt\brdrs\brdrw10\brdrcf0\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx9165\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Who Was Informed:}\f1\fs18\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow2\irowband2\trleft-15\trrh300\trftsWidth3\trwWidth9160\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2685\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx9165\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 How Were They Informed:}\f1\fs18\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow3\irowband3\trleft-15\trrh300\trftsWidth3\trwWidth9160\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2685\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx9165\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Actions Taken:\~}\f1\fs18\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow4\irowband4\lastrow\trleft-15\trrh300\trftsWidth3\trwWidth9160\trautofit1\tblindtype3\tblind0\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2685\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx9165\row\pard\plain\ql\f1\fs18\par}',0, 'May 22 2014  1:59PM',0, 'May 22 2014  1:56PM',1,0,0
insert LogTemplate ( Name,Text,LastModifiedUserId,LastModifiedDateTime,CreatedUserId,CreatedDateTime, AppliesToLogs, AppliesToSummaryLogs, AppliesToDirectives)  select 'Testing Issue (Resolved)','{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Tahoma;}{\f2 Calibri;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql Normal;}{\*\cs1 Default Paragraph Font;}{\*\cs2\sbasedon1\f1\fs18 Line Number;}{\*\cs3\ul\cf1 Hyperlink;}{\*\ts4\tsrowd\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\trowd\irow0\irowband0\trleft-15\trrh300\trftsWidth3\trwWidth8740\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth2260\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2265\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth6480\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8745\pard\plain\ql\intbl{\b\ul\f2\fs22\cf0 Resolved Testing Issue}\cell\pard\plain\ql\intbl\cell\trowd\irow0\irowband0\trleft-15\trrh300\trftsWidth3\trwWidth8740\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth2260\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2265\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth3\clwWidth6480\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8745\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Test Name:}\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow1\irowband1\trleft-15\trrh300\trftsWidth3\trwWidth8740\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2265\clvertalb\clbrdrt\brdrs\brdrw10\brdrcf0\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8745\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Instrument Name:}\b\f2\fs20\cf0\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow2\irowband2\trleft-15\trrh300\trftsWidth3\trwWidth8740\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2265\clvertalb\clbrdrt\brdrnil\brdrw10\brdrcf0\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8745\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 SAP Number:}\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow3\irowband3\trleft-15\trrh300\trftsWidth3\trwWidth8740\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2265\clvertalb\clbrdrt\brdrnil\brdrw10\brdrcf0\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8745\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Issue:}\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow4\irowband4\trleft-15\trrh300\trftsWidth3\trwWidth8740\trautofit1\tblindtype3\tblind0\clvertalb\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2265\clvertalb\clbrdrt\brdrnil\brdrw10\brdrcf0\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8745\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Actions Taken:}\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow5\irowband5\trleft-15\trrh300\trftsWidth3\trwWidth8740\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2265\clvertalb\clbrdrt\brdrnil\brdrw10\brdrcf0\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8745\row\pard\plain\ql\intbl{\b\f2\fs20\cf0 Current Status:}\cell\pard\plain\ql\intbl{\f2\fs20\cf0 \~}\f2\fs20\cell\trowd\irow6\irowband6\lastrow\trleft-15\trrh300\trftsWidth3\trwWidth8740\trautofit1\tblindtype3\tblind0\clvertalc\clbrdrt\brdrnil\clbrdrl\brdrnil\clbrdrb\brdrnil\clbrdrr\brdrnil\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx2265\clvertalb\clbrdrt\brdrnil\brdrw10\brdrcf0\clbrdrl\brdrs\brdrw10\brdrcf0\clbrdrb\brdrs\brdrw10\brdrcf0\clbrdrr\brdrs\brdrw10\brdrcf0\cltxlrtb\clNoWrap\clftsWidth1\clpadfl3\clpadl15\clpadfr3\clpadr15\clpadft3\clpadt15\cellx8745\row\pard\plain\ql\par}',0, 'May 22 2014  2:03PM',0, 'May 22 2014  1:58PM',1,0,0
GO

insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Extraction 1 Day Shift Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Extraction 2 Day Shift Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'GC Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'ICP Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Instrumentation Technician' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Extraction' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Projects' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Upgrading 1/3' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Upgrading 2/4' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Projects Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'QA Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 1 Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 2 Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 3 Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 4 Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Waters 1 Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Waters 2 Lab Tech' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'OS Waters 3' and w.siteid = 12 and lt.[name] = 'Quality Control Issue'
GO

insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Lab Specialist' and w.siteid = 12 and lt.[name] = 'Regular Lab Specialist Shift Log'
GO

insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Lab Supervisor' and w.siteid = 12 and lt.[name] = 'Regular Summary Log'
GO

insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Extraction 1 Day Shift Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Extraction 2 Day Shift Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'GC Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'ICP Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Instrumentation Technician' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Extraction' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Projects' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Upgrading 1/3' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Upgrading 2/4' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Projects Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'QA Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 1 Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 2 Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 3 Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 4 Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Waters 1 Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Waters 2 Lab Tech' and w.siteid = 12 and lt.[name] = 'Routine Instrument Maintenance'
GO

insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Extraction 1 Day Shift Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Extraction 2 Day Shift Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'GC Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'ICP Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Instrumentation Technician' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Extraction' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Projects' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Upgrading 1/3' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Night Shift Upgrading 2/4' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Projects Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'QA Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 1 Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 2 Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 3 Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Upgrading 4 Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Waters 1 Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
insert LogTemplateWorkAssignment ( LogTemplateId,WorkAssignmentId )  select lt.Id,w.id from WorkAssignment w, LogTemplate lt where w.name = 'Waters 2 Lab Tech' and w.siteid = 12 and lt.[name] = 'Testing Issue (Resolved)'
GO



UPDATE
  WorkAssignment
SET
  [Name] = 'OS Extraction 1',
  Description = 'Oilsands Extraction 1 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Extraction 1 Day Shift Lab Tech'
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Extraction 2',
  Description = 'Oilsands Extraction 2 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Extraction 2 Day Shift Lab Tech'
    
UPDATE
  WorkAssignment
SET
  [Name] = 'OS GC',
  Description = 'Oilsands GC Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'GC Lab Tech'
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS ICP',
  Description = 'Oilsands ICP Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'ICP Lab Tech'  
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Lab Manager',
  Description = 'Oilsands Lab Manager'
WHERE
  SiteId = 12 and
  [Name] = 'Lab Manager'  
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Lab Specialist',
  Description = 'Oilsands Lab Specialist'
WHERE
  SiteId = 12 and
  [Name] = 'Lab Specialist'

UPDATE
  WorkAssignment
SET
  [Name] = 'OS Lab Supervisor',
  Description = 'Oilsands Lab Supervisor'
WHERE
  SiteId = 12 and
  [Name] = 'Lab Supervisor'   
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Lab Administrator',
  Description = 'Oilsands Lab Administrator'
WHERE
  SiteId = 12 and
  [Name] = 'Oilsands Lab Administrator'
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Extraction Nights',
  Description = 'Oilsands Extraction Nights Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Night Shift Extraction'  
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Projects Nights',
  Description = 'Oilsands Projects Nights Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Night Shift Projects'
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Upgrading Nights 1',
  Description = 'Oilsands Upgrading Nights 1 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Night Shift Upgrading 1/3'    
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Upgrading Nights 2',
  Description = 'Oilsands Upgrading Nights 2 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Night Shift Upgrading 2/4'
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Projects',
  Description = 'Oilsands Projects Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Projects Lab Tech'  
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS QA',
  Description = 'Oilsands Quality Assurance Tech'
WHERE
  SiteId = 12 and
  [Name] = 'QA Lab Tech'

-- don't associate to Functional Locations at this time.
DELETE wafl
FROM
	WorkAssignmentFunctionalLocation wafl
	INNER JOIN WorkAssignment wa ON wa.Id = wafl.WorkAssignmentId
WHERE
	wa.SiteId = 12
	and wa.[Name] = 'OS QA'
	
	
UPDATE
  WorkAssignment
SET
  [Name] = 'OS QA Staff',
  Description = 'Oilsands Quality Assurance Staff'
WHERE
  SiteId = 12 and
  [Name] = 'QA Staff'

UPDATE
  WorkAssignment
SET
  [Name] = 'OS Unit Leader',
  Description = 'Oilsands Unit Leader'
WHERE
  SiteId = 12 and
  [Name] = 'Unit Leader'
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Upgrading 1',
  Description = 'Oilsands Upgrading 1 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Upgrading 1 Lab Tech'  
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Upgrading 2',
  Description = 'Oilsands Upgrading 2 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Upgrading 2 Lab Tech'   
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Upgrading 3',
  Description = 'Oilsands Upgrading 3 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Upgrading 3 Lab Tech'  
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Upgrading 4',
  Description = 'Oilsands Upgrading 4 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Upgrading 4 Lab Tech'    
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Waters 1',
  Description = 'Oilsands Waters 1 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Waters 1 Lab Tech'  
  
UPDATE
  WorkAssignment
SET
  [Name] = 'OS Waters 2',
  Description = 'Oilsands Waters 2 Lab Tech'
WHERE
  SiteId = 12 and
  [Name] = 'Waters 2 Lab Tech'
GO

DELETE wafl
FROM
  WorkAssignmentFunctionalLocation wafl
  INNER JOIN WorkAssignment wa on wa.Id = wafl.WorkAssignmentId
WHERE
  wa.[Name] = 'Instrumentation Technician'
  and wa.SiteId = 12

DELETE shcwa
FROM
  ShifthandoverConfigurationWorkAssignment shcwa
  INNER JOIN WorkAssignment wa on wa.Id = shcwa.WorkAssignmentId
WHERE
  wa.[Name] = 'Instrumentation Technician'
  and wa.SiteId = 12

DELETE ltwa
FROM
  LogTemplateWorkAssignment ltwa
  INNER JOIN WorkAssignment wa on wa.Id = ltwa.WorkAssignmentId
WHERE
  wa.[Name] = 'Instrumentation Technician'
  and wa.SiteId = 12

DELETE wavg
FROM
  WorkAssignmentVisibilityGroup wavg
  INNER JOIN WorkAssignment wa on wa.Id = wavg.WorkAssignmentId
WHERE
  wa.[Name] = 'Instrumentation Technician'
  and wa.SiteId = 12
  
DELETE FROM WorkAssignment
WHERE
  [Name] = 'Instrumentation Technician'
  and SiteId = 12
GO

DELETE wafl
FROM
  WorkAssignmentFunctionalLocation wafl
  INNER JOIN WorkAssignment wa on wa.Id = wafl.WorkAssignmentId
WHERE
  wa.[Name] = 'Lab System Analyst'
  and wa.SiteId = 12

DELETE shcwa
FROM
  ShifthandoverConfigurationWorkAssignment shcwa
  INNER JOIN WorkAssignment wa on wa.Id = shcwa.WorkAssignmentId
WHERE
  wa.[Name] = 'Lab System Analyst'
  and wa.SiteId = 12

DELETE ltwa
FROM
  LogTemplateWorkAssignment ltwa
  INNER JOIN WorkAssignment wa on wa.Id = ltwa.WorkAssignmentId
WHERE
  wa.[Name] = 'Lab System Analyst'
  and wa.SiteId = 12

DELETE wavg
FROM
  WorkAssignmentVisibilityGroup wavg
  INNER JOIN WorkAssignment wa on wa.Id = wavg.WorkAssignmentId
WHERE
  wa.[Name] = 'Lab System Analyst'
  and wa.SiteId = 12
  
DELETE FROM WorkAssignment
WHERE
  [Name] = 'Lab System Analyst'
  and SiteId = 12  
GO

DELETE shq
FROM
  ShiftHandoverQuestion shq
  INNER JOIN ShiftHandoverConfiguration c ON c.Id = shq.ShiftHandoverConfigurationId
WHERE
  c.[Name] IN ('Regular Lab Tech Handover', 'Regular Supervisor Handover', 'Regular Unit Leader Handover')
GO

insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 0, 'Were there any Health or Safety concerns during this shift?', 'If �Yes� is selected a comment MUST be entered into this question�s comment box.' + CHAR(13) + CHAR(10) + 'REMINDER: All health and safety concerns must still be communicated to you Shift Supervisor and Lab Safety Representative.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Lab Tech Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 1, 'Were there any problems with calibration or controls?', 'If �Yes� is selected a comment MUST be entered into this question�s comment box.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Lab Tech Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 2, 'Do you have any work for the next shift to complete?', 'If �Yes� is selected a comment MUST be entered into this question�s comment box.' + CHAR(13) + CHAR(10) + 'Please include information such as samples left.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Lab Tech Handover'
GO
  
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 0, 'Any safety concerns?', 'Briefly describe all safety issues that came up during your shift. Remember to include ILP #s, if any.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Supervisor Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 1, 'Any new projects coming up?', 'Briefly describe new projects started during your shift and/or new projects going to be started in the upcoming shift. Include the scope and start & end dates.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Supervisor Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 2, 'Any projects completed?', 'Briefly mention the projects that were completed during your shift.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Supervisor Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 3, 'Any instrument/procedure/people issues?', 'Briefly state any information that might be useful for the upcoming shift. Information in this report will be shared at the first  08:00 shift meeting of the new shift coming in.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Supervisor Handover'
GO
  
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 0, 'Were there any Health or Safety concerns during this shift?', 'If �Yes� is selected a comment MUST be entered into this question�s comment box.' + CHAR(13) + CHAR(10) + 'REMINDER: All health and safety concerns must still be communicated to you Shift Supervisor and Lab Safety Representative.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Unit Leader Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 1, 'Do you have any work for the next shift to complete?', 'If �Yes� is selected a comment MUST be entered into this question�s comment box.' + CHAR(13) + CHAR(10) + 'Please include information such as samples left.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Unit Leader Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 2, 'Are there any supplies that are critically low?', 'If �Yes� is selected a comment MUST be entered into this question�s comment box.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Unit Leader Handover'
insert into ShiftHandoverQuestion (ShiftHandoverConfigurationId, DisplayOrder, Text, HelpText, Deleted, IsCurrentQuestionVersion) select c.Id, 3, 'Are there any supplies that need to be ordered?', 'If �Yes� is selected a comment MUST be entered into this question�s comment box.', 0, 1 FROM ShiftHandoverConfiguration c WHERE c.[Name] = 'Regular Unit Leader Handover'
GO

UPDATE ShiftHandoverConfiguration
SET
	[Name] = 'Lab Tech Handover'
WHERE
	[Name] = 'Regular Lab Tech Handover'

UPDATE ShiftHandoverConfiguration
SET
	[Name] = 'Supervisor Handover'
WHERE
	[Name] = 'Regular Supervisor Handover'

UPDATE ShiftHandoverConfiguration
SET
	[Name] = 'Unit Leader Handover'
WHERE
	[Name] = 'Regular Unit Leader Handover'
GO

insert into LogGuideline (FunctionalLocationId, Text)
select Id, 
'Select a Template from the Template drop down menu then click insert. 

If a suitable template is not available a custom comment may be written in the comment box.

For multiple issues of the same type (ex. maintenance on several instruments) insert an additional template for each occurrence.'
from FunctionalLocation where FullHierarchy = 'WBL';

UPDATE WorkAssignment
  SET AutoInsertLogTemplateId = (SELECT Id From LogTemplate where [Name] = 'Regular Lab Specialist Shift Log')
WHERE
  WorkAssignment.[Name] = 'Lab Specialist' and SiteId = 12
  
UPDATE WorkAssignment
  SET AutoInsertLogTemplateId = (SELECT Id From LogTemplate where [Name] = 'Regular Summary Log')
WHERE
  WorkAssignment.[Name] = 'Lab Supervisor' and SiteId = 12  
GO


GO

