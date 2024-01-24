@echo off
rem This script can be used to regenerate the bcp files for re-baselining the database to a new version

set user=sa
set password=pass@word1
set server=localhost\SQL2008
set dbInstance=PROD_BACKUP

set bcp_params=-c -t"|"\t"|" -r\n~~ -U%user% -P%password% -S%server% -d%dbInstance%

rem Action Item
bcp "select a.* from ActionItem a INNER JOIN ActionItemDefinition d on d.id = a.CreatedByActionItemDefinitionId and d.GN75BId IS NULL where d.Id > (SELECT MAX(Id) - 200 FROM ActionItemDefinition)" queryout actionitem\ActionItem.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Action Item Functional Location
bcp "select m.* from ActionItemFunctionalLocation m inner join ActionItem a on a.Id = m.ActionItemId INNER JOIN ActionItemDefinition d on d.id = a.CreatedByActionItemDefinitionId and d.GN75BId IS NULL where d.Id > (SELECT MAX(Id) - 200 FROM ActionItemDefinition)" queryout actionitem\ActionItemFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Action Item Definition Auto Reapproval Configuration
bcp "SELECT * FROM dbo.ActionItemDefinitionAutoReApprovalConfiguration ORDER BY SiteId" queryout master\ActionItemDefinitionAutoReApprovalConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Action Item Definition (don't create any with FK to Gn75B)
bcp "SELECT * FROM dbo.ActionItemDefinition WHERE GN75BId IS NULL AND Id > (SELECT MAX(Id) - 200 FROM ActionItemDefinition)" queryout actionitem\ActionItemDefinition.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem ActionItem Definition Floc
bcp "SELECT m.* from ActionItemDefinitionFunctionalLocation m INNER JOIN ActionItemDefinition a on a.Id = m.ActionItemDefinitionId WHERE a.GN75BId IS NULL AND a.Id > (SELECT MAX(Id) - 200 FROM ActionItemDefinition)" queryout actionitem\ActionItemDefinitionFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * from AreaLabel Order By Id" queryout permit\AreaLabel.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR
 
rem Action Item Definition Schedules
bcp "select s.* FROM Schedule s INNER JOIN ActionItemDefinition a on a.ScheduleId = s.Id where a.GN75BId IS NULL AND a.Id > (SELECT MAX(Id) - 200 FROM ActionItemDefinition)" queryout actionitem\Schedule.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Action Item Definition History
bcp "select h.* from ActionItemDefinitionHistory h INNER JOIN dbo.ActionItemDefinition a ON a.Id = h.Id WHERE a.GN75BId IS NULL AND a.Id > (SELECT MAX(Id) - 200 FROM ActionItemDefinition)" queryout actionitem\ActionItemDefinitionHistory.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Business Category
bcp "SELECT * FROM dbo.BusinessCategory ORDER BY Id" queryout master\BusinessCategory.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Business Category FLOC Association
bcp "SELECT * FROM dbo.BusinessCategoryFLOCAssociation" queryout master\BusinessCategoryFLOCAssociation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT cc.* from CokerCard cc" queryout cokercard\CokerCard.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from CokerCardCycleStepEntry" queryout cokercard\CokerCardCycleStepEntry.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from CokerCardDrumEntry" queryout cokercard\CokerCardDrumEntry.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CokerCardConfiguration
bcp "SELECT * FROM dbo.CokerCardConfiguration" queryout cokercard\CokerCardConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CokerCardConfigurationCycleStep
bcp "SELECT * FROM dbo.CokerCardConfigurationCycleStep" queryout cokercard\CokerCardConfigurationCycleStep.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CokerCardConfigurationDrum
bcp "SELECT * FROM dbo.CokerCardConfigurationDrum" queryout cokercard\CokerCardConfigurationDrum.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CokerCardConfigurationWorkAssignment
bcp "SELECT * FROM dbo.CokerCardConfigurationWorkAssignment ORDER BY CokerCardConfigurationId" queryout cokercard\CokerCardConfigurationWorkAssignment.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Contractor
bcp "SELECT * FROM dbo.Contractor order by siteid, companyname" queryout permit\Contractor.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CraftOrTrade
bcp "SELECT * FROM dbo.CraftOrTrade" queryout permit\CraftOrTrade.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CustomField
bcp "SELECT * FROM dbo.CustomField" queryout master\CustomField.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CustomFieldDropDownValue
bcp "SELECT * FROM dbo.CustomFieldDropDownValue" queryout master\CustomFieldDropDownValue.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CustomFieldGroup
bcp "SELECT * FROM dbo.CustomFieldGroup" queryout master\CustomFieldGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM CustomFieldCustomFieldGroup" queryout master\CustomFieldCustomFieldGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem CustomFieldGroupWorkAssignment
bcp "SELECT * FROM dbo.CustomFieldGroupWorkAssignment" queryout master\CustomFieldGroupWorkAssignment.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select a.* from DeviationAlert a WHERE a.LastModifiedDateTime >= (SELECT MAX(LastModifiedDateTime) - 14 FROM DeviationAlert)" queryout restriction\DeviationAlert.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select r.* from DeviationAlertResponse r INNER JOIN DeviationAlert a ON a.DeviationAlertResponseId = r.Id where a.LastModifiedDateTime >= (SELECT MAX(LastModifiedDateTime) - 14 FROM DeviationAlert)" queryout restriction\DeviationAlertResponse.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select m.* from DeviationAlertResponseReasonCodeAssignment m INNER JOIN dbo.DeviationAlertResponse r ON r.Id = m.DeviationAlertResponseId INNER JOIN DeviationAlert a ON a.DeviationAlertResponseId = r.Id where a.LastModifiedDateTime >= (SELECT MAX(LastModifiedDateTime) - 14 FROM DeviationAlert)" queryout restriction\DeviationAlertResponseReasonCodeAssignment.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from restrictionlocationitem" queryout restriction\restrictionlocationitem.dat %bcp_params%

bcp "select * from RestrictionLocation" queryout restriction\restrictionlocation.dat %bcp_params%

rem DocumentRootPathConfiguration
bcp "SELECT * FROM dbo.DocumentRootPathConfiguration" queryout master\DocumentRootPathConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem DocumentRootPathFunctionalLocation
bcp "SELECT * FROM dbo.DocumentRootPathFunctionalLocation" queryout master\DocumentRootPathFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem DropdownValue
bcp "SELECT * FROM dbo.DropdownValue order by siteid, [key], displayorder" queryout master\DropdownValue.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem FormTemplate
bcp "SELECT * FROM dbo.FormTemplate" queryout master\FormTemplate.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Functional Location
bcp "SELECT * FROM dbo.FunctionalLocation ORDER BY Id" queryout master\FunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Functional Location Ancestor
bcp "SELECT a.* FROM FunctionalLocationAncestor a Order by a.Id" queryout master\FunctionalLocationAncestor.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Functional Location Operational Mode
bcp "SELECT * FROM dbo.FunctionalLocationOperationalMode" queryout master\FunctionalLocationOperationalMode.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem GasLimitUnit
bcp "SELECT * FROM dbo.GasLimitUnit" queryout permit\GasLimitUnit.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem GasTestElementInfo  (these are the master or standard ones)
bcp "SELECT * FROM dbo.GasTestElementInfo WHERE Standard = 1" queryout master\GasTestElementInfo.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from Honeywellphdconnectioninfo" queryout master\Honeywellphdconnectioninfo.dat  %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from LabAlertDefinition" queryout labalert\LabAlertDefinition.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select s.* from Schedule s INNER JOIN LabAlertDefinition lad on lad.ScheduleId = s.Id" queryout labalert\Schedule.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from LabAlert" queryout labalert\LabAlert.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from LabAlertResponse" queryout labalert\LabAlertResponse.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select l.* from [Log] l WHERE l.ReplyToLogId IS NULL and l.Id >= (SELECT max(Id) - 10000 FROM [Log]) and l.LogDefinitionId IS NULL" queryout log\Log.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select m.* from LogActionItemAssociation m INNER JOIN ActionItem a on a.Id = m.ActionItemId INNER JOIN dbo.[Log] l on l.Id = m.LogId INNER JOIN ActionItemDefinition d on d.id = a.CreatedByActionItemDefinitionId where d.Id > (SELECT MAX(Id) - 200 FROM ActionItemDefinition) and l.ReplyToLogId IS NULL and l.CreatedDateTime >= (SELECT max(CreatedDateTime) - 10 FROM [Log]) and l.LogDefinitionId IS NULL" queryout log\LogActionItemAssociation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select m.* from LogFunctionallocation m inner join [Log] l on l.Id = m.LogId where l.ReplyToLogId IS NULL and l.Id >= (SELECT max(ll.Id) - 10000 FROM [Log] ll) and l.LogDefinitionId IS NULL" queryout log\LogFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select list.* from LogFunctionalLocationList list inner join [Log] l on l.Id = list.LogId where l.ReplyToLogId IS NULL and l.Id >= (SELECT max(ll.Id) - 10000 FROM [Log] ll) and l.LogDefinitionId IS NULL" queryout log\LogFunctionalLocationList.dat  %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from LogGuideline" queryout log\LogGuideline.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select cfe.* from LogCustomFieldEntry cfe inner join [Log] l on cfe.LogId = l.Id where l.ReplyToLogId IS NULL and l.Id >= (SELECT max(Id) - 10000 FROM [Log]) and l.LogDefinitionId IS NULL" queryout log\LogCustomFieldEntry.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select g.* from LogCustomFieldGroup g INNER JOIN [log] l on l.Id = g.LogId WHERE l.ReplyToLogId IS NULL and l.Id >= (SELECT max(Id) - 10000 FROM [Log]) and l.LogDefinitionId IS NULL" queryout log\LogCustomFieldGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR 

rem LogDefinition
bcp "SELECT ld.* from LogDefinition ld Where ld.Id > (SELECT MAX(Id) - 200 FROM LogDefinition)" queryout log\LogDefinition.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem LogDefinitionFunctionalLocation
bcp "select m.* FROM LogDefinitionFunctionalLocation m INNER JOIN LogDefinition ld on ld.Id = m.LogDefinitionId Where ld.Id > (SELECT MAX(Id) - 200 FROM LogDefinition)" queryout log\LogDefinitionFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select cfe.* FROM LogDefinitionCustomFieldEntry cfe INNER JOIN dbo.LogDefinition ld ON ld.Id = cfe.LogDefinitionId Where ld.Id > (SELECT MAX(Id) - 200 FROM LogDefinition)" queryout log\LogDefinitionCustomFieldEntry.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Log Definition Schedule
bcp "select s.* FROM Schedule s INNER JOIN LogDefinition ld on ld.ScheduleId = s.Id Where ld.Id > (SELECT MAX(Id) - 200 FROM LogDefinition)" queryout log\Schedule.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem LogTemplate
bcp "SELECT * FROM dbo.[LogTemplate]" queryout log\LogTemplate.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem LogTemplateWorkAssignment
bcp "SELECT * FROM dbo.[LogTemplateWorkAssignment]" queryout log\LogTemplateWorkAssignment.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem PermitAttribute
bcp "SELECT * FROM dbo.[PermitAttribute]" queryout permit\PermitAttribute.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Plant
bcp "SELECT * FROM dbo.[Plant] ORDER BY SiteId, [Name]" queryout master\Plant.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from RestrictionDefinition" queryout restriction\RestrictionDefinition.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem RestrictionReasonCode
bcp "SELECT * FROM dbo.[RestrictionReasonCode]" queryout restriction\RestrictionReasonCode.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Role
bcp "SELECT * FROM dbo.[Role] ORDER BY Id" queryout master\Role.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem RoleDisplayConfiguration
bcp "SELECT * FROM dbo.[RoleDisplayConfiguration]" queryout master\RoleDisplayConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem RoleElement
bcp "SELECT * FROM dbo.[RoleElement] ORDER BY Id" queryout master\RoleElement.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem RoleElementTemplate
bcp "SELECT * FROM dbo.[RoleElementTemplate] order by RoleId, RoleElementId" queryout master\RoleElementTemplate.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem RolePermission
bcp "SELECT * FROM dbo.[RolePermission] order by RoleId, RoleElementId, CreatedByRoleId" queryout master\RolePermission.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem SAPNotification
bcp "select n.* from sapnotification n where n.CreationDateTime >= (SELECT MAX(CreationDateTime) - 30 FROM SapNotification)" queryout log\sapnotification.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from SapAutoImportConfiguration" queryout permit\SapAutoImportConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select s.* from Schedule s INNER JOIN SapAutoImportConfiguration i ON i.ScheduleId = s.Id" queryout permit\Schedule.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from SAPImportPriorityWorkPermitLubesGroup" queryout permit\SAPImportPriorityWorkPermitLubesGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from SAPImportPriorityWorkPermitEdmontonGroup" queryout permit\SAPImportPriorityWorkPermitEdmontonGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Shift
bcp "SELECT * FROM dbo.[Shift] order by SiteId, name" queryout master\Shift.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem ShiftHandoverConfiguration
bcp "SELECT * FROM dbo.ShiftHandoverConfiguration ORDER BY Id" queryout handover\ShiftHandoverConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem ShiftHandoverConfigurationWorkAssignment
bcp "SELECT * FROM dbo.ShiftHandoverConfigurationWorkAssignment" queryout handover\ShiftHandoverConfigurationWorkAssignment.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem ShiftHandoverQuestion
bcp "SELECT * FROM dbo.ShiftHandoverQuestion order by DisplayOrder" queryout handover\ShiftHandoverQuestion.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem ShiftHandoverQuestionnaire
bcp "select q.* from ShiftHandoverQuestionnaire q where q.LastModifiedDateTime >= (SELECT MAX(LastModifiedDateTime) - 7 FROM ShiftHandoverQuestionnaire)" queryout handover\ShiftHandoverQuestionnaire.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select m.* from ShiftHandoverQuestionnaireFunctionallocation m inner join ShiftHandoverQuestionnaire q on q.Id = m.ShiftHandoverQuestionnaireId where q.LastModifiedDateTime >= (SELECT MAX(LastModifiedDateTime) - 7 FROM ShiftHandoverQuestionnaire)" queryout handover\ShiftHandoverQuestionnaireFunctionallocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select list.* from ShiftHandoverQuestionnaireFunctionalLocationList list inner join ShiftHandoverQuestionnaire q on q.Id = list.ShiftHandoverQuestionnaireId where q.LastModifiedDateTime >= (SELECT MAX(LastModifiedDateTime) - 7 FROM ShiftHandoverQuestionnaire)" queryout handover\ShiftHandoverQuestionnaireFunctionalLocationList.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select a.* from ShiftHandoverAnswer a inner join dbo.ShiftHandoverQuestionnaire q ON q.Id = a.ShiftHandoverQuestionnaireId where q.LastModifiedDateTime >= (SELECT MAX(LastModifiedDateTime) - 7 FROM ShiftHandoverQuestionnaire)" queryout handover\ShiftHandoverAnswer.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select m.* from ShiftHandoverQuestionnaireCokerCardConfiguration m INNER JOIN dbo.ShiftHandoverQuestionnaire q ON q.Id = m.ShiftHandoverQuestionnaireId where q.LastModifiedDateTime >= (SELECT MAX(LastModifiedDateTime) - 7 FROM ShiftHandoverQuestionnaire)" queryout handover\ShiftHandoverQuestionnaireCokerCardConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Site
bcp "SELECT * FROM dbo.Site ORDER BY Id" queryout master\Site.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem SiteConfiguration
bcp "SELECT * FROM dbo.SiteConfiguration ORDER BY SiteId" queryout master\SiteConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.SiteConfigurationDefaults" queryout master\SiteConfigurationDefaults.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Summary Log
bcp "select l.* from SummaryLog l WHERE l.CreatedDateTime >= (SELECT MAX(CreatedDateTime) - 14 FROM SummaryLog)" queryout log\SummaryLog.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Summary Log Floc
bcp "select m.* from SummaryLogFunctionallocation m inner join summarylog l on l.Id = m.SummaryLogId WHERE l.CreatedDateTime >= (SELECT MAX(CreatedDateTime) - 14 FROM SummaryLog)" queryout log\SummaryLogFunctionallocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select list.* from SummaryLogFunctionalLocationList list inner join summarylog l on l.Id = list.SummaryLogId WHERE l.CreatedDateTime >= (SELECT MAX(CreatedDateTime) - 14 FROM SummaryLog)" queryout log\SummaryLogFunctionalLocationList.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Summary Log Custom Field Entrries
bcp "select cfe.* from SummaryLogCustomFieldEntry cfe inner join [SummaryLog] l on cfe.SummaryLogId = l.Id where l.CreatedDateTime >= (SELECT max(CreatedDateTime) - 14 FROM SummaryLog)" queryout log\SummaryLogCustomFieldEntry.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select g.* from SummaryLogCustomFieldGroup g INNER JOIN SummaryLog l on l.Id = g.SummaryLogId WHERE l.CreatedDateTime >= (SELECT MAX(CreatedDateTime) - 14 FROM SummaryLog)" queryout log\SummaryLogCustomFieldGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Tag
bcp "SELECT * FROM dbo.Tag ORDER BY Id" queryout master\Tag.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * from dbo.TagGroup" queryout master\TagGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * from dbo.TagGroupAssociation" queryout master\TagGroupAssociation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem TargetDefinitionAutoReApprovalConfiguration
bcp "SELECT * FROM dbo.TargetDefinitionAutoReApprovalConfiguration order by SiteId" queryout target\TargetDefinitionAutoReApprovalConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT td.* FROM dbo.TargetDefinition td INNER JOIN Tag t on t.Id = td.TagID INNER JOIN dbo.Schedule s ON s.Id = td.ScheduleId where s.ScheduleTypeId = 8 and t.SiteId IN (3,6) and td.Deleted = 0 and t.Deleted = 0 and s.EndDateTime IS NULL ORDER BY TD.ID DESC" queryout target\TargetDefinition.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Target Definition Schedules
bcp "select s.* FROM Schedule s INNER JOIN TargetDefinition td ON td.ScheduleId = s.Id INNER JOIN Tag t on t.Id = td.TagID where s.ScheduleTypeId = 8 and t.SiteId IN (3,6) and td.Deleted = 0 and t.Deleted = 0 and s.EndDateTime IS NULL ORDER BY TD.ID DESC" queryout target\Schedule.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem User
bcp "SELECT * FROM dbo.[User] where id != 1 ORDER BY Id" queryout master\User.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem UserPrintPreference
bcp "SELECT * FROM dbo.[UserPrintPreference] ORDER BY Id" queryout master\UserPrintPreference.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from VisibilityGroup" queryout master\VisibilityGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Work Assignment
bcp "SELECT * FROM dbo.WorkAssignment ORDER BY Id" queryout master\WorkAssignment.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem Work Assignment Functional Location
bcp "SELECT * FROM dbo.WorkAssignmentFunctionalLocation" queryout master\WorkAssignmentFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select wp.* FROM WorkPermit wp where wp.Id >= (SELECT MAX(Id) - 150 FROM WorkPermit)" queryout permit\WorkPermit.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem WorkPermitCloseConfiguration
bcp "SELECT * FROM dbo.WorkPermitCloseConfiguration order by SiteId" queryout permit\WorkPermitCloseConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem WorkPermitFunctionalLocationConfiguration
bcp "SELECT * FROM dbo.WorkPermitFunctionalLocationConfiguration" queryout permit\WorkPermitFunctionalLocationConfiguration.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

rem WorkPermitEdmontonGroup
bcp "SELECT * FROM dbo.WorkPermitEdmontonGroup" queryout permit\WorkPermitEdmontonGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.FormGN24" queryout forms\FormGN24.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.FormGN24Approval" queryout forms\FormGN24Approval.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.FormGN24FunctionalLocation" queryout forms\FormGN24FunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.FormGN6" queryout forms\FormGN6.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.FormGN6Approval" queryout forms\FormGN6Approval.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.FormGN6FunctionalLocation" queryout forms\FormGN6FunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select wp.* FROM WorkPermitMontreal wp where wp.Id >= (SELECT MAX(Id)-150 From WorkPermitMontreal)" queryout permit\WorkPermitMontreal.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select wpd.* from WorkPermitMontrealDetails wpd INNER JOIN dbo.WorkPermitMontreal wp ON wp.Id = wpd.Id where wp.Id >= (SELECT MAX(Id) -150 From WorkPermitMontreal)" queryout permit\WorkPermitMontrealDetails.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select wpfl.* from WorkPermitMontrealFunctionalLocation wpfl INNER JOIN dbo.WorkPermitMontreal wp ON wpfl.WorkPermitMontrealId = wp.Id where wp.Id >= (SELECT MAX(Id) -150 From WorkPermitMontreal)" queryout permit\WorkPermitMontrealFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select assoc.* from WorkPermitMontrealPermitAttributeAssociation assoc INNER JOIN dbo.WorkPermitMontreal wp ON assoc.WorkPermitMontrealId = wp.Id where wp.Id >= (SELECT MAX(Id) -150 From WorkPermitMontreal)" queryout permit\WorkPermitMontrealPermitAttributeAssociation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select DISTINCT pr.* from PermitRequestMontreal pr INNER JOIN dbo.WorkPermitMontreal wp ON pr.Id = wp.PermitRequestId where wp.Id >= (SELECT MAX(Id) -150 From WorkPermitMontreal)" queryout permit\PermitRequestMontreal.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select DISTINCT prfl.* from PermitRequestMontrealFunctionalLocation prfl INNER JOIN PermitRequestMontreal pr ON pr.Id = prfl.PermitRequestMontrealId INNER JOIN dbo.WorkPermitMontreal wp ON pr.Id = wp.PermitRequestId where wp.Id >= (SELECT MAX(Id) -150 From WorkPermitMontreal)" queryout permit\PermitRequestMontrealFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select DISTINCT assoc.* from PermitRequestMontrealPermitAttributeAssociation assoc INNER JOIN PermitRequestMontreal pr ON pr.Id = assoc.PermitRequestId INNER JOIN dbo.WorkPermitMontreal wp ON pr.Id = wp.PermitRequestId where wp.Id >= (SELECT MAX(Id) -150 From WorkPermitMontreal)" queryout permit\PermitRequestMontrealPermitAttributeAssociation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.WorkPermitMontrealTemplate" queryout permit\WorkPermitMontrealTemplate.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * FROM dbo.WorkPermitMontrealGroup" queryout permit\WorkPermitMontrealGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select info.* from WorkPermitGasTestElementInfo info INNER JOIN dbo.WorkPermit wp ON wp.Id = info.WorkPermitId where wp.Id >= (SELECT MAX(Id) - 150 FROM WorkPermit)" queryout permit\WorkPermitGasTestElementInfo.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select gtei.* from GasTestElementInfo gtei INNER JOIN dbo.WorkPermitGasTestElementInfo info ON info.GasTestElementInfoId = gtei.Id INNER JOIN dbo.WorkPermit wp ON wp.Id = info.WorkPermitId where wp.Id >= (SELECT MAX(Id) - 150 FROM WorkPermit) and gtei.Standard = 0" queryout permit\GasTestElementInfo.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "SELECT * from WorkPermitLubesGroup" queryout permit\WorkPermitLubesGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from WorkAssignmentVisibilityGroup" queryout master\WorkAssignmentVisibilityGroup.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

bcp "select * from WorkPermitAutoAssignmentConfigurationFunctionalLocation" queryout master\WorkPermitAutoAssignmentConfigurationFunctionalLocation.dat %bcp_params%
IF ERRORLEVEL 1 goto PRINTERROR

:PRINTERROR