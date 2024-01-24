using System;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.ToolStrips;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.navigationListView = new Com.Suncor.Olt.Client.Controls.MainNavigationListView();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.buildVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuItemEdit = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewActionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewRestriction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewLabAlert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewLogEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewLogDefinitionEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCokerCardEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewShiftSummaryLogEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyDirectiveLogEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewStandingOrderEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewShiftHandoverQuestionnaire = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewWorkPermit = new System.Windows.Forms.ToolStripMenuItem();
            this.permitRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confinedSpaceDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN7 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN24 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN59 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN75A = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN75B = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewSarniaGN75BForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewSarniaGN75BTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewSarniaOP14 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewSelcOP14 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewOP14 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewOdourNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewDeviation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewRoadClosure = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN11GroundDistrubance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGN27FreezePlug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewHazardAssessment = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewNonEmergencyWaterSystemApproval = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewFormOilsandsTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewFormForthillsTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewFormSiteWideTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewFormETFTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewFormOvertimeRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewFormCriticalSystemDefeat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewMontrealFormCriticalSystemDefeat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewFormAlarmDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOilSandsSafeWorkPermitAuditQuestionnaire = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemForthillsSafeWorkPermitAuditQuestionnaire = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDocumentSuggestion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProcedureDeviation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewMudsTemporaryInstallation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewOilSample = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewDailyInspection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewDirective = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeActiveFLOC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReports = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsTargetsToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDailyShiftAlertReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShiftGapReasonReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTargetAlertExcelReport = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsRestrictionsToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRestrictionReport = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsCokerCardsToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCokerCardReport = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsLogsToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDailyShiftLogReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOperatingEngineerShiftLogReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDetailedLogReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMarkedAsReadLogReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCustomFieldTrendReport = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsShiftHandoverToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShiftHandoverReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMarkedAsReadShiftHandoverReport = new System.Windows.Forms.ToolStripMenuItem();
            this.markedAsNotReadReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsFormsToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTrainingFormExcelReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTrainingFormReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOnPremisePersonnelReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeWorkPermitAssessmentsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFormOP14MarkAsReadReport = new System.Windows.Forms.ToolStripMenuItem();
            this.safeWorkPermitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPrintBlankWorkPermit = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsDirectivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMarkedAsReadDirectiveReport = new System.Windows.Forms.ToolStripMenuItem();
            this.readingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminPrioritiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priorityDisplayCriteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminActionItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureActionItemSettingsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureBusinessCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flocBusinessCategoryAssignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureActionItemReApprovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminTargetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureTargetsReApprovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurePlantHistorianTagListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminRestrictionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editReasonCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureRestrictionReportingLimitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureRestrictionListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminLabAlertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labAlertConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureCutoffTimeForEditingDORCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logGuidelineConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminCokerCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cokerCardConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminShiftHandoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftHandoverConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftHandoverEmailConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminWorkPermitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureWorkPermitArchivalProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureWorkPermitContractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureWorkCentersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureGasTestLimitsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.configureWorkPermitMontrealTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureWorkPermitMontrealDropdownsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureConfiguredDocumentLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.associateWorkAssignmentsForPermitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureWorkPermitGroupsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureRoadAccessOnPermitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureSpecialWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restrictionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restrictionFlocsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureFormTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureTrainingBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureFormDropdownsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureGenericTemplateApprovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureGenericTemplateEmailApprovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.adminDisplaySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureDefaultTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureDisplayLimitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminWorkAssignmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureAssignmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureDefaultFLOCsForDailyAssignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visibilityGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureWorkAssignmentNotSelectedWarningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminSiteConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionalLocationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageOperationalModeForUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siteCommunicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainForm_FlocLevelSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.configureOLTCommunityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.technicalAdministrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureRoleMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureRolePermissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.technicalSiteConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sapAutoImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.honeywellPHDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyticsExcelExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.enableSecurityForNewDirectivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOLTApplicationHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.oltApplicationHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roleMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oltAdministratorListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userStrip = new Com.Suncor.Olt.Client.Controls.ToolStrips.MainUserStrip();
            this.sharedDictionaryStorage = new DevExpress.XtraSpellChecker.SharedDictionaryStorage(this.components);
            this.menuItemNewGenericFormCriticalSystemDefeat = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuItemEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            resources.ApplyResources(this.mainSplitContainer, "mainSplitContainer");
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.navigationListView);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.contentPanel);
            // 
            // navigationListView
            // 
            resources.ApplyResources(this.navigationListView, "navigationListView");
            this.navigationListView.Name = "navigationListView";
            // 
            // contentPanel
            // 
            resources.ApplyResources(this.contentPanel, "contentPanel");
            this.contentPanel.Name = "contentPanel";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildVersion});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // buildVersion
            // 
            this.buildVersion.Name = "buildVersion";
            resources.ApplyResources(this.buildVersion, "buildVersion");
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuItemEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemReports,
            this.administrationToolStripMenuItem,
            this.technicalAdministrationToolStripMenuItem,
            this.menuItemOLTApplicationHelp});
            resources.ApplyResources(this.menuItemEdit, "menuItemEdit");
            this.menuItemEdit.Name = "menuItemEdit";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNew,
            this.menuItemLogOut,
            this.menuItemChangeActiveFLOC,
            this.menuItemPreferences,
            this.toolStripMenuItem2,
            this.menuItemFileExit});
            this.menuItemFile.Name = "menuItemFile";
            resources.ApplyResources(this.menuItemFile, "menuItemFile");
            // 
            // menuItemNew
            // 
            this.menuItemNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewActionItem,
            this.menuItemNewTarget,
            this.menuItemNewRestriction,
            this.menuItemNewLabAlert,
            this.menuItemLog,
            this.menuItemNewShiftHandoverQuestionnaire,
            this.menuItemNewWorkPermit,
            this.permitRequestToolStripMenuItem,
            this.confinedSpaceDocumentToolStripMenuItem,
            this.menuItemForm,
            this.menuItemNewDirective});
            this.menuItemNew.Image = global::Com.Suncor.Olt.Client.Properties.Resources.New;
            this.menuItemNew.Name = "menuItemNew";
            resources.ApplyResources(this.menuItemNew, "menuItemNew");
            // 
            // menuItemNewActionItem
            // 
            this.menuItemNewActionItem.Image = global::Com.Suncor.Olt.Client.Properties.Resources.actionItems_16;
            this.menuItemNewActionItem.Name = "menuItemNewActionItem";
            resources.ApplyResources(this.menuItemNewActionItem, "menuItemNewActionItem");
            // 
            // menuItemNewTarget
            // 
            this.menuItemNewTarget.Image = global::Com.Suncor.Olt.Client.Properties.Resources.target_16;
            this.menuItemNewTarget.Name = "menuItemNewTarget";
            resources.ApplyResources(this.menuItemNewTarget, "menuItemNewTarget");
            // 
            // menuItemNewRestriction
            // 
            this.menuItemNewRestriction.Image = global::Com.Suncor.Olt.Client.Properties.Resources.target_16;
            this.menuItemNewRestriction.Name = "menuItemNewRestriction";
            resources.ApplyResources(this.menuItemNewRestriction, "menuItemNewRestriction");
            // 
            // menuItemNewLabAlert
            // 
            this.menuItemNewLabAlert.Image = global::Com.Suncor.Olt.Client.Properties.Resources.lab_alert_16;
            this.menuItemNewLabAlert.Name = "menuItemNewLabAlert";
            resources.ApplyResources(this.menuItemNewLabAlert, "menuItemNewLabAlert");
            // 
            // menuItemLog
            // 
            this.menuItemLog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewLogEntry,
            this.menuItemNewLogDefinitionEntry,
            this.menuItemCokerCardEntry,
            this.menuItemNewShiftSummaryLogEntry,
            this.dailyDirectiveLogEntryToolStripMenuItem,
            this.menuItemNewStandingOrderEntry});
            this.menuItemLog.Image = global::Com.Suncor.Olt.Client.Properties.Resources.log_16;
            this.menuItemLog.Name = "menuItemLog";
            resources.ApplyResources(this.menuItemLog, "menuItemLog");
            // 
            // menuItemNewLogEntry
            // 
            this.menuItemNewLogEntry.Image = global::Com.Suncor.Olt.Client.Properties.Resources.log_16;
            this.menuItemNewLogEntry.Name = "menuItemNewLogEntry";
            resources.ApplyResources(this.menuItemNewLogEntry, "menuItemNewLogEntry");
            // 
            // menuItemNewLogDefinitionEntry
            // 
            this.menuItemNewLogDefinitionEntry.Image = global::Com.Suncor.Olt.Client.Properties.Resources.log_16;
            this.menuItemNewLogDefinitionEntry.Name = "menuItemNewLogDefinitionEntry";
            resources.ApplyResources(this.menuItemNewLogDefinitionEntry, "menuItemNewLogDefinitionEntry");
            // 
            // menuItemCokerCardEntry
            // 
            this.menuItemCokerCardEntry.Image = global::Com.Suncor.Olt.Client.Properties.Resources.log_16;
            this.menuItemCokerCardEntry.Name = "menuItemCokerCardEntry";
            resources.ApplyResources(this.menuItemCokerCardEntry, "menuItemCokerCardEntry");
            // 
            // menuItemNewShiftSummaryLogEntry
            // 
            this.menuItemNewShiftSummaryLogEntry.Image = global::Com.Suncor.Olt.Client.Properties.Resources.log_16;
            this.menuItemNewShiftSummaryLogEntry.Name = "menuItemNewShiftSummaryLogEntry";
            resources.ApplyResources(this.menuItemNewShiftSummaryLogEntry, "menuItemNewShiftSummaryLogEntry");
            // 
            // dailyDirectiveLogEntryToolStripMenuItem
            // 
            this.dailyDirectiveLogEntryToolStripMenuItem.Image = global::Com.Suncor.Olt.Client.Properties.Resources.log_16;
            this.dailyDirectiveLogEntryToolStripMenuItem.Name = "dailyDirectiveLogEntryToolStripMenuItem";
            resources.ApplyResources(this.dailyDirectiveLogEntryToolStripMenuItem, "dailyDirectiveLogEntryToolStripMenuItem");
            // 
            // menuItemNewStandingOrderEntry
            // 
            this.menuItemNewStandingOrderEntry.Image = global::Com.Suncor.Olt.Client.Properties.Resources.log_16;
            this.menuItemNewStandingOrderEntry.Name = "menuItemNewStandingOrderEntry";
            resources.ApplyResources(this.menuItemNewStandingOrderEntry, "menuItemNewStandingOrderEntry");
            // 
            // menuItemNewShiftHandoverQuestionnaire
            // 
            this.menuItemNewShiftHandoverQuestionnaire.Image = global::Com.Suncor.Olt.Client.Properties.Resources.shift_handover_16;
            this.menuItemNewShiftHandoverQuestionnaire.Name = "menuItemNewShiftHandoverQuestionnaire";
            resources.ApplyResources(this.menuItemNewShiftHandoverQuestionnaire, "menuItemNewShiftHandoverQuestionnaire");
            // 
            // menuItemNewWorkPermit
            // 
            this.menuItemNewWorkPermit.Image = global::Com.Suncor.Olt.Client.Properties.Resources.permit_16;
            this.menuItemNewWorkPermit.Name = "menuItemNewWorkPermit";
            resources.ApplyResources(this.menuItemNewWorkPermit, "menuItemNewWorkPermit");
            // 
            // permitRequestToolStripMenuItem
            // 
            this.permitRequestToolStripMenuItem.Image = global::Com.Suncor.Olt.Client.Properties.Resources.permit_16;
            this.permitRequestToolStripMenuItem.Name = "permitRequestToolStripMenuItem";
            resources.ApplyResources(this.permitRequestToolStripMenuItem, "permitRequestToolStripMenuItem");
            // 
            // confinedSpaceDocumentToolStripMenuItem
            // 
            this.confinedSpaceDocumentToolStripMenuItem.Image = global::Com.Suncor.Olt.Client.Properties.Resources.permit_16;
            this.confinedSpaceDocumentToolStripMenuItem.Name = "confinedSpaceDocumentToolStripMenuItem";
            resources.ApplyResources(this.confinedSpaceDocumentToolStripMenuItem, "confinedSpaceDocumentToolStripMenuItem");
            // 
            // menuItemForm
            // 
            this.menuItemForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewGN1,
            this.menuItemNewGN6,
            this.menuItemNewGN7,
            this.menuItemNewGN24,
            this.menuItemNewGN59,
            this.menuItemNewGN75A,
            this.menuItemNewGN75B,
            this.menuItemNewSarniaGN75BForm,
            this.menuItemNewSarniaGN75BTemplate,
            this.menuItemNewSarniaOP14,
            this.menuItemNewSelcOP14,
            this.menuItemNewOP14,
            this.menuItemNewOdourNoise,
            this.menuItemNewDeviation,
            this.menuItemNewRoadClosure,
            this.menuItemNewGN11GroundDistrubance,
            this.menuItemNewGN27FreezePlug,
            this.menuItemNewHazardAssessment,
            this.menuItemNewNonEmergencyWaterSystemApproval,
            this.menuItemNewFormOilsandsTraining,
            this.menuItemNewFormForthillsTraining,
            this.menuItemNewFormSiteWideTraining,
            this.menuItemNewFormETFTraining,
            this.menuItemNewFormOvertimeRequest,
            this.menuItemNewFormCriticalSystemDefeat,
            this.menuItemNewMontrealFormCriticalSystemDefeat,
            this.menuItemNewFormAlarmDisable,
            this.menuItemOilSandsSafeWorkPermitAuditQuestionnaire,
            this.menuItemForthillsSafeWorkPermitAuditQuestionnaire,
            this.menuItemDocumentSuggestion,
            this.menuItemProcedureDeviation,
            this.menuItemNewMudsTemporaryInstallation,
            this.menuItemNewOilSample,
            this.menuItemNewDailyInspection,
            this.menuItemNewGenericFormCriticalSystemDefeat});
            this.menuItemForm.Image = global::Com.Suncor.Olt.Client.Properties.Resources.form_16;
            this.menuItemForm.Name = "menuItemForm";
            resources.ApplyResources(this.menuItemForm, "menuItemForm");
            // 
            // menuItemNewGN1
            // 
            this.menuItemNewGN1.Name = "menuItemNewGN1";
            resources.ApplyResources(this.menuItemNewGN1, "menuItemNewGN1");
            // 
            // menuItemNewGN6
            // 
            this.menuItemNewGN6.Name = "menuItemNewGN6";
            resources.ApplyResources(this.menuItemNewGN6, "menuItemNewGN6");
            // 
            // menuItemNewGN7
            // 
            this.menuItemNewGN7.Name = "menuItemNewGN7";
            resources.ApplyResources(this.menuItemNewGN7, "menuItemNewGN7");
            // 
            // menuItemNewGN24
            // 
            this.menuItemNewGN24.Name = "menuItemNewGN24";
            resources.ApplyResources(this.menuItemNewGN24, "menuItemNewGN24");
            // 
            // menuItemNewGN59
            // 
            this.menuItemNewGN59.Name = "menuItemNewGN59";
            resources.ApplyResources(this.menuItemNewGN59, "menuItemNewGN59");
            // 
            // menuItemNewGN75A
            // 
            this.menuItemNewGN75A.Name = "menuItemNewGN75A";
            resources.ApplyResources(this.menuItemNewGN75A, "menuItemNewGN75A");
            // 
            // menuItemNewGN75B
            // 
            this.menuItemNewGN75B.Name = "menuItemNewGN75B";
            resources.ApplyResources(this.menuItemNewGN75B, "menuItemNewGN75B");
            // 
            // menuItemNewSarniaGN75BForm
            // 
            this.menuItemNewSarniaGN75BForm.Name = "menuItemNewSarniaGN75BForm";
            resources.ApplyResources(this.menuItemNewSarniaGN75BForm, "menuItemNewSarniaGN75BForm");
            // 
            // menuItemNewSarniaGN75BTemplate
            // 
            this.menuItemNewSarniaGN75BTemplate.Name = "menuItemNewSarniaGN75BTemplate";
            resources.ApplyResources(this.menuItemNewSarniaGN75BTemplate, "menuItemNewSarniaGN75BTemplate");
            // 
            // menuItemNewSarniaOP14
            // 
            this.menuItemNewSarniaOP14.Name = "menuItemNewSarniaOP14";
            resources.ApplyResources(this.menuItemNewSarniaOP14, "menuItemNewSarniaOP14");
            // 
            // menuItemNewSelcOP14
            // 
            this.menuItemNewSelcOP14.Name = "menuItemNewSelcOP14";
            resources.ApplyResources(this.menuItemNewSelcOP14, "menuItemNewSelcOP14");
            // 
            // menuItemNewOP14
            // 
            this.menuItemNewOP14.Name = "menuItemNewOP14";
            resources.ApplyResources(this.menuItemNewOP14, "menuItemNewOP14");
            // 
            // menuItemNewOdourNoise
            // 
            this.menuItemNewOdourNoise.Name = "menuItemNewOdourNoise";
            resources.ApplyResources(this.menuItemNewOdourNoise, "menuItemNewOdourNoise");
            // 
            // menuItemNewDeviation
            // 
            this.menuItemNewDeviation.Name = "menuItemNewDeviation";
            resources.ApplyResources(this.menuItemNewDeviation, "menuItemNewDeviation");
            // 
            // menuItemNewRoadClosure
            // 
            this.menuItemNewRoadClosure.Name = "menuItemNewRoadClosure";
            resources.ApplyResources(this.menuItemNewRoadClosure, "menuItemNewRoadClosure");
            // 
            // menuItemNewGN11GroundDistrubance
            // 
            this.menuItemNewGN11GroundDistrubance.Name = "menuItemNewGN11GroundDistrubance";
            resources.ApplyResources(this.menuItemNewGN11GroundDistrubance, "menuItemNewGN11GroundDistrubance");
            // 
            // menuItemNewGN27FreezePlug
            // 
            this.menuItemNewGN27FreezePlug.Name = "menuItemNewGN27FreezePlug";
            resources.ApplyResources(this.menuItemNewGN27FreezePlug, "menuItemNewGN27FreezePlug");
            // 
            // menuItemNewHazardAssessment
            // 
            this.menuItemNewHazardAssessment.Name = "menuItemNewHazardAssessment";
            resources.ApplyResources(this.menuItemNewHazardAssessment, "menuItemNewHazardAssessment");
            // 
            // menuItemNewNonEmergencyWaterSystemApproval
            // 
            this.menuItemNewNonEmergencyWaterSystemApproval.Name = "menuItemNewNonEmergencyWaterSystemApproval";
            resources.ApplyResources(this.menuItemNewNonEmergencyWaterSystemApproval, "menuItemNewNonEmergencyWaterSystemApproval");
            // 
            // menuItemNewFormOilsandsTraining
            // 
            this.menuItemNewFormOilsandsTraining.Name = "menuItemNewFormOilsandsTraining";
            resources.ApplyResources(this.menuItemNewFormOilsandsTraining, "menuItemNewFormOilsandsTraining");
            // 
            // menuItemNewFormForthillsTraining
            // 
            this.menuItemNewFormForthillsTraining.Name = "menuItemNewFormForthillsTraining";
            resources.ApplyResources(this.menuItemNewFormForthillsTraining, "menuItemNewFormForthillsTraining");
            // 
            // menuItemNewFormSiteWideTraining
            // 
            this.menuItemNewFormSiteWideTraining.Name = "menuItemNewFormSiteWideTraining";
            resources.ApplyResources(this.menuItemNewFormSiteWideTraining, "menuItemNewFormSiteWideTraining");
            // 
            // menuItemNewFormETFTraining
            // 
            this.menuItemNewFormETFTraining.Name = "menuItemNewFormETFTraining";
            resources.ApplyResources(this.menuItemNewFormETFTraining, "menuItemNewFormETFTraining");
            // 
            // menuItemNewFormOvertimeRequest
            // 
            this.menuItemNewFormOvertimeRequest.Name = "menuItemNewFormOvertimeRequest";
            resources.ApplyResources(this.menuItemNewFormOvertimeRequest, "menuItemNewFormOvertimeRequest");
            // 
            // menuItemNewFormCriticalSystemDefeat
            // 
            this.menuItemNewFormCriticalSystemDefeat.Name = "menuItemNewFormCriticalSystemDefeat";
            resources.ApplyResources(this.menuItemNewFormCriticalSystemDefeat, "menuItemNewFormCriticalSystemDefeat");
            // 
            // menuItemNewMontrealFormCriticalSystemDefeat
            // 
            this.menuItemNewMontrealFormCriticalSystemDefeat.Name = "menuItemNewMontrealFormCriticalSystemDefeat";
            resources.ApplyResources(this.menuItemNewMontrealFormCriticalSystemDefeat, "menuItemNewMontrealFormCriticalSystemDefeat");
            // 
            // menuItemNewFormAlarmDisable
            // 
            this.menuItemNewFormAlarmDisable.Name = "menuItemNewFormAlarmDisable";
            resources.ApplyResources(this.menuItemNewFormAlarmDisable, "menuItemNewFormAlarmDisable");
            // 
            // menuItemOilSandsSafeWorkPermitAuditQuestionnaire
            // 
            this.menuItemOilSandsSafeWorkPermitAuditQuestionnaire.Name = "menuItemOilSandsSafeWorkPermitAuditQuestionnaire";
            resources.ApplyResources(this.menuItemOilSandsSafeWorkPermitAuditQuestionnaire, "menuItemOilSandsSafeWorkPermitAuditQuestionnaire");
            // 
            // menuItemForthillsSafeWorkPermitAuditQuestionnaire
            // 
            this.menuItemForthillsSafeWorkPermitAuditQuestionnaire.Name = "menuItemForthillsSafeWorkPermitAuditQuestionnaire";
            resources.ApplyResources(this.menuItemForthillsSafeWorkPermitAuditQuestionnaire, "menuItemForthillsSafeWorkPermitAuditQuestionnaire");
            // 
            // menuItemDocumentSuggestion
            // 
            this.menuItemDocumentSuggestion.Name = "menuItemDocumentSuggestion";
            resources.ApplyResources(this.menuItemDocumentSuggestion, "menuItemDocumentSuggestion");
            // 
            // menuItemProcedureDeviation
            // 
            this.menuItemProcedureDeviation.Name = "menuItemProcedureDeviation";
            resources.ApplyResources(this.menuItemProcedureDeviation, "menuItemProcedureDeviation");
            // 
            // menuItemNewMudsTemporaryInstallation
            // 
            this.menuItemNewMudsTemporaryInstallation.Name = "menuItemNewMudsTemporaryInstallation";
            resources.ApplyResources(this.menuItemNewMudsTemporaryInstallation, "menuItemNewMudsTemporaryInstallation");
            // 
            // menuItemNewOilSample
            // 
            this.menuItemNewOilSample.Name = "menuItemNewOilSample";
            resources.ApplyResources(this.menuItemNewOilSample, "menuItemNewOilSample");
            // 
            // menuItemNewDailyInspection
            // 
            this.menuItemNewDailyInspection.Name = "menuItemNewDailyInspection";
            resources.ApplyResources(this.menuItemNewDailyInspection, "menuItemNewDailyInspection");
            // 
            // menuItemNewDirective
            // 
            this.menuItemNewDirective.Image = global::Com.Suncor.Olt.Client.Properties.Resources.directives_16;
            this.menuItemNewDirective.Name = "menuItemNewDirective";
            resources.ApplyResources(this.menuItemNewDirective, "menuItemNewDirective");
            // 
            // menuItemLogOut
            // 
            this.menuItemLogOut.Image = global::Com.Suncor.Olt.Client.Properties.Resources.switchUser_16;
            this.menuItemLogOut.Name = "menuItemLogOut";
            resources.ApplyResources(this.menuItemLogOut, "menuItemLogOut");
            // 
            // menuItemChangeActiveFLOC
            // 
            this.menuItemChangeActiveFLOC.Image = global::Com.Suncor.Olt.Client.Properties.Resources.changeFLOC_16;
            this.menuItemChangeActiveFLOC.Name = "menuItemChangeActiveFLOC";
            resources.ApplyResources(this.menuItemChangeActiveFLOC, "menuItemChangeActiveFLOC");
            // 
            // menuItemPreferences
            // 
            this.menuItemPreferences.Name = "menuItemPreferences";
            resources.ApplyResources(this.menuItemPreferences, "menuItemPreferences");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // menuItemFileExit
            // 
            this.menuItemFileExit.Name = "menuItemFileExit";
            resources.ApplyResources(this.menuItemFileExit, "menuItemFileExit");
            // 
            // menuItemReports
            // 
            this.menuItemReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsTargetsToolStripSubMenuItem,
            this.reportsRestrictionsToolStripSubMenuItem,
            this.reportsCokerCardsToolStripSubMenuItem,
            this.reportsLogsToolStripSubMenuItem,
            this.reportsShiftHandoverToolStripSubMenuItem,
            this.reportsFormsToolStripSubMenuItem,
            this.safeWorkPermitToolStripMenuItem,
            this.reportsDirectivesToolStripMenuItem,
            this.readingReportToolStripMenuItem});
            this.menuItemReports.Name = "menuItemReports";
            resources.ApplyResources(this.menuItemReports, "menuItemReports");
            // 
            // reportsTargetsToolStripSubMenuItem
            // 
            this.reportsTargetsToolStripSubMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDailyShiftAlertReport,
            this.menuItemShiftGapReasonReport,
            this.menuItemTargetAlertExcelReport});
            this.reportsTargetsToolStripSubMenuItem.Name = "reportsTargetsToolStripSubMenuItem";
            resources.ApplyResources(this.reportsTargetsToolStripSubMenuItem, "reportsTargetsToolStripSubMenuItem");
            // 
            // menuItemDailyShiftAlertReport
            // 
            this.menuItemDailyShiftAlertReport.Name = "menuItemDailyShiftAlertReport";
            resources.ApplyResources(this.menuItemDailyShiftAlertReport, "menuItemDailyShiftAlertReport");
            // 
            // menuItemShiftGapReasonReport
            // 
            this.menuItemShiftGapReasonReport.Name = "menuItemShiftGapReasonReport";
            resources.ApplyResources(this.menuItemShiftGapReasonReport, "menuItemShiftGapReasonReport");
            // 
            // menuItemTargetAlertExcelReport
            // 
            this.menuItemTargetAlertExcelReport.Name = "menuItemTargetAlertExcelReport";
            resources.ApplyResources(this.menuItemTargetAlertExcelReport, "menuItemTargetAlertExcelReport");
            // 
            // reportsRestrictionsToolStripSubMenuItem
            // 
            this.reportsRestrictionsToolStripSubMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRestrictionReport});
            this.reportsRestrictionsToolStripSubMenuItem.Name = "reportsRestrictionsToolStripSubMenuItem";
            resources.ApplyResources(this.reportsRestrictionsToolStripSubMenuItem, "reportsRestrictionsToolStripSubMenuItem");
            // 
            // menuItemRestrictionReport
            // 
            this.menuItemRestrictionReport.Name = "menuItemRestrictionReport";
            resources.ApplyResources(this.menuItemRestrictionReport, "menuItemRestrictionReport");
            // 
            // reportsCokerCardsToolStripSubMenuItem
            // 
            this.reportsCokerCardsToolStripSubMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCokerCardReport});
            this.reportsCokerCardsToolStripSubMenuItem.Name = "reportsCokerCardsToolStripSubMenuItem";
            resources.ApplyResources(this.reportsCokerCardsToolStripSubMenuItem, "reportsCokerCardsToolStripSubMenuItem");
            // 
            // menuItemCokerCardReport
            // 
            this.menuItemCokerCardReport.Name = "menuItemCokerCardReport";
            resources.ApplyResources(this.menuItemCokerCardReport, "menuItemCokerCardReport");
            // 
            // reportsLogsToolStripSubMenuItem
            // 
            this.reportsLogsToolStripSubMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDailyShiftLogReport,
            this.menuItemOperatingEngineerShiftLogReport,
            this.menuItemDetailedLogReport,
            this.menuItemMarkedAsReadLogReport,
            this.menuItemCustomFieldTrendReport});
            this.reportsLogsToolStripSubMenuItem.Name = "reportsLogsToolStripSubMenuItem";
            resources.ApplyResources(this.reportsLogsToolStripSubMenuItem, "reportsLogsToolStripSubMenuItem");
            // 
            // menuItemDailyShiftLogReport
            // 
            this.menuItemDailyShiftLogReport.Name = "menuItemDailyShiftLogReport";
            resources.ApplyResources(this.menuItemDailyShiftLogReport, "menuItemDailyShiftLogReport");
            // 
            // menuItemOperatingEngineerShiftLogReport
            // 
            this.menuItemOperatingEngineerShiftLogReport.Name = "menuItemOperatingEngineerShiftLogReport";
            resources.ApplyResources(this.menuItemOperatingEngineerShiftLogReport, "menuItemOperatingEngineerShiftLogReport");
            // 
            // menuItemDetailedLogReport
            // 
            this.menuItemDetailedLogReport.Name = "menuItemDetailedLogReport";
            resources.ApplyResources(this.menuItemDetailedLogReport, "menuItemDetailedLogReport");
            // 
            // menuItemMarkedAsReadLogReport
            // 
            this.menuItemMarkedAsReadLogReport.Name = "menuItemMarkedAsReadLogReport";
            resources.ApplyResources(this.menuItemMarkedAsReadLogReport, "menuItemMarkedAsReadLogReport");
            // 
            // menuItemCustomFieldTrendReport
            // 
            this.menuItemCustomFieldTrendReport.Name = "menuItemCustomFieldTrendReport";
            resources.ApplyResources(this.menuItemCustomFieldTrendReport, "menuItemCustomFieldTrendReport");
            // 
            // reportsShiftHandoverToolStripSubMenuItem
            // 
            this.reportsShiftHandoverToolStripSubMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShiftHandoverReport,
            this.menuItemMarkedAsReadShiftHandoverReport,
            this.markedAsNotReadReportToolStripMenuItem});
            this.reportsShiftHandoverToolStripSubMenuItem.Name = "reportsShiftHandoverToolStripSubMenuItem";
            resources.ApplyResources(this.reportsShiftHandoverToolStripSubMenuItem, "reportsShiftHandoverToolStripSubMenuItem");
            // 
            // menuItemShiftHandoverReport
            // 
            this.menuItemShiftHandoverReport.Name = "menuItemShiftHandoverReport";
            resources.ApplyResources(this.menuItemShiftHandoverReport, "menuItemShiftHandoverReport");
            // 
            // menuItemMarkedAsReadShiftHandoverReport
            // 
            this.menuItemMarkedAsReadShiftHandoverReport.Name = "menuItemMarkedAsReadShiftHandoverReport";
            resources.ApplyResources(this.menuItemMarkedAsReadShiftHandoverReport, "menuItemMarkedAsReadShiftHandoverReport");
            // 
            // markedAsNotReadReportToolStripMenuItem
            // 
            this.markedAsNotReadReportToolStripMenuItem.Name = "markedAsNotReadReportToolStripMenuItem";
            resources.ApplyResources(this.markedAsNotReadReportToolStripMenuItem, "markedAsNotReadReportToolStripMenuItem");
            // 
            // reportsFormsToolStripSubMenuItem
            // 
            this.reportsFormsToolStripSubMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTrainingFormExcelReport,
            this.menuItemTrainingFormReport,
            this.menuItemOnPremisePersonnelReportToolStripMenuItem,
            this.safeWorkPermitAssessmentsReportToolStripMenuItem,
            this.menuItemFormOP14MarkAsReadReport});
            this.reportsFormsToolStripSubMenuItem.Name = "reportsFormsToolStripSubMenuItem";
            resources.ApplyResources(this.reportsFormsToolStripSubMenuItem, "reportsFormsToolStripSubMenuItem");
            // 
            // menuItemTrainingFormExcelReport
            // 
            this.menuItemTrainingFormExcelReport.Name = "menuItemTrainingFormExcelReport";
            resources.ApplyResources(this.menuItemTrainingFormExcelReport, "menuItemTrainingFormExcelReport");
            // 
            // menuItemTrainingFormReport
            // 
            this.menuItemTrainingFormReport.Name = "menuItemTrainingFormReport";
            resources.ApplyResources(this.menuItemTrainingFormReport, "menuItemTrainingFormReport");
            // 
            // menuItemOnPremisePersonnelReportToolStripMenuItem
            // 
            this.menuItemOnPremisePersonnelReportToolStripMenuItem.Name = "menuItemOnPremisePersonnelReportToolStripMenuItem";
            resources.ApplyResources(this.menuItemOnPremisePersonnelReportToolStripMenuItem, "menuItemOnPremisePersonnelReportToolStripMenuItem");
            // 
            // safeWorkPermitAssessmentsReportToolStripMenuItem
            // 
            this.safeWorkPermitAssessmentsReportToolStripMenuItem.Name = "safeWorkPermitAssessmentsReportToolStripMenuItem";
            resources.ApplyResources(this.safeWorkPermitAssessmentsReportToolStripMenuItem, "safeWorkPermitAssessmentsReportToolStripMenuItem");
            // 
            // menuItemFormOP14MarkAsReadReport
            // 
            this.menuItemFormOP14MarkAsReadReport.Name = "menuItemFormOP14MarkAsReadReport";
            resources.ApplyResources(this.menuItemFormOP14MarkAsReadReport, "menuItemFormOP14MarkAsReadReport");
            // 
            // safeWorkPermitToolStripMenuItem
            // 
            this.safeWorkPermitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPrintBlankWorkPermit});
            this.safeWorkPermitToolStripMenuItem.Name = "safeWorkPermitToolStripMenuItem";
            resources.ApplyResources(this.safeWorkPermitToolStripMenuItem, "safeWorkPermitToolStripMenuItem");
            // 
            // menuItemPrintBlankWorkPermit
            // 
            this.menuItemPrintBlankWorkPermit.Name = "menuItemPrintBlankWorkPermit";
            resources.ApplyResources(this.menuItemPrintBlankWorkPermit, "menuItemPrintBlankWorkPermit");
            // 
            // reportsDirectivesToolStripMenuItem
            // 
            this.reportsDirectivesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMarkedAsReadDirectiveReport});
            this.reportsDirectivesToolStripMenuItem.Name = "reportsDirectivesToolStripMenuItem";
            resources.ApplyResources(this.reportsDirectivesToolStripMenuItem, "reportsDirectivesToolStripMenuItem");
            // 
            // menuItemMarkedAsReadDirectiveReport
            // 
            this.menuItemMarkedAsReadDirectiveReport.Name = "menuItemMarkedAsReadDirectiveReport";
            resources.ApplyResources(this.menuItemMarkedAsReadDirectiveReport, "menuItemMarkedAsReadDirectiveReport");
            // 
            // readingReportToolStripMenuItem
            // 
            this.readingReportToolStripMenuItem.Name = "readingReportToolStripMenuItem";
            resources.ApplyResources(this.readingReportToolStripMenuItem, "readingReportToolStripMenuItem");
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminPrioritiesToolStripMenuItem,
            this.adminActionItemsToolStripMenuItem,
            this.adminTargetsToolStripMenuItem,
            this.adminRestrictionsToolStripMenuItem,
            this.adminLabAlertsToolStripMenuItem,
            this.adminLogsToolStripMenuItem,
            this.adminCokerCardsToolStripMenuItem,
            this.adminShiftHandoverToolStripMenuItem,
            this.adminWorkPermitsToolStripMenuItem,
            this.restrictionsToolStripMenuItem,
            this.adminFormsToolStripMenuItem,
            this.toolStripSeparator2,
            this.adminDisplaySettingsToolStripMenuItem,
            this.adminWorkAssignmentsToolStripMenuItem,
            this.adminSiteConfigurationToolStripMenuItem});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            resources.ApplyResources(this.administrationToolStripMenuItem, "administrationToolStripMenuItem");
            // 
            // adminPrioritiesToolStripMenuItem
            // 
            this.adminPrioritiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.priorityDisplayCriteriaToolStripMenuItem});
            this.adminPrioritiesToolStripMenuItem.Name = "adminPrioritiesToolStripMenuItem";
            resources.ApplyResources(this.adminPrioritiesToolStripMenuItem, "adminPrioritiesToolStripMenuItem");
            // 
            // priorityDisplayCriteriaToolStripMenuItem
            // 
            this.priorityDisplayCriteriaToolStripMenuItem.Name = "priorityDisplayCriteriaToolStripMenuItem";
            resources.ApplyResources(this.priorityDisplayCriteriaToolStripMenuItem, "priorityDisplayCriteriaToolStripMenuItem");
            // 
            // adminActionItemsToolStripMenuItem
            // 
            this.adminActionItemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureActionItemSettingsStripMenuItem,
            this.configureBusinessCategoriesToolStripMenuItem,
            this.flocBusinessCategoryAssignmentToolStripMenuItem,
            this.configureActionItemReApprovalToolStripMenuItem});
            this.adminActionItemsToolStripMenuItem.Name = "adminActionItemsToolStripMenuItem";
            resources.ApplyResources(this.adminActionItemsToolStripMenuItem, "adminActionItemsToolStripMenuItem");
            // 
            // configureActionItemSettingsStripMenuItem
            // 
            this.configureActionItemSettingsStripMenuItem.Name = "configureActionItemSettingsStripMenuItem";
            resources.ApplyResources(this.configureActionItemSettingsStripMenuItem, "configureActionItemSettingsStripMenuItem");
            // 
            // configureBusinessCategoriesToolStripMenuItem
            // 
            this.configureBusinessCategoriesToolStripMenuItem.Name = "configureBusinessCategoriesToolStripMenuItem";
            resources.ApplyResources(this.configureBusinessCategoriesToolStripMenuItem, "configureBusinessCategoriesToolStripMenuItem");
            // 
            // flocBusinessCategoryAssignmentToolStripMenuItem
            // 
            this.flocBusinessCategoryAssignmentToolStripMenuItem.Name = "flocBusinessCategoryAssignmentToolStripMenuItem";
            resources.ApplyResources(this.flocBusinessCategoryAssignmentToolStripMenuItem, "flocBusinessCategoryAssignmentToolStripMenuItem");
            // 
            // configureActionItemReApprovalToolStripMenuItem
            // 
            this.configureActionItemReApprovalToolStripMenuItem.Name = "configureActionItemReApprovalToolStripMenuItem";
            resources.ApplyResources(this.configureActionItemReApprovalToolStripMenuItem, "configureActionItemReApprovalToolStripMenuItem");
            // 
            // adminTargetsToolStripMenuItem
            // 
            this.adminTargetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureTargetsReApprovalToolStripMenuItem,
            this.configurePlantHistorianTagListToolStripMenuItem});
            this.adminTargetsToolStripMenuItem.Name = "adminTargetsToolStripMenuItem";
            resources.ApplyResources(this.adminTargetsToolStripMenuItem, "adminTargetsToolStripMenuItem");
            // 
            // configureTargetsReApprovalToolStripMenuItem
            // 
            this.configureTargetsReApprovalToolStripMenuItem.Name = "configureTargetsReApprovalToolStripMenuItem";
            resources.ApplyResources(this.configureTargetsReApprovalToolStripMenuItem, "configureTargetsReApprovalToolStripMenuItem");
            // 
            // configurePlantHistorianTagListToolStripMenuItem
            // 
            this.configurePlantHistorianTagListToolStripMenuItem.Name = "configurePlantHistorianTagListToolStripMenuItem";
            resources.ApplyResources(this.configurePlantHistorianTagListToolStripMenuItem, "configurePlantHistorianTagListToolStripMenuItem");
            // 
            // adminRestrictionsToolStripMenuItem
            // 
            this.adminRestrictionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editReasonCodesToolStripMenuItem,
            this.configureRestrictionReportingLimitsToolStripMenuItem,
            this.configureRestrictionListsToolStripMenuItem});
            this.adminRestrictionsToolStripMenuItem.Name = "adminRestrictionsToolStripMenuItem";
            resources.ApplyResources(this.adminRestrictionsToolStripMenuItem, "adminRestrictionsToolStripMenuItem");
            // 
            // editReasonCodesToolStripMenuItem
            // 
            this.editReasonCodesToolStripMenuItem.Name = "editReasonCodesToolStripMenuItem";
            resources.ApplyResources(this.editReasonCodesToolStripMenuItem, "editReasonCodesToolStripMenuItem");
            // 
            // configureRestrictionReportingLimitsToolStripMenuItem
            // 
            this.configureRestrictionReportingLimitsToolStripMenuItem.Name = "configureRestrictionReportingLimitsToolStripMenuItem";
            resources.ApplyResources(this.configureRestrictionReportingLimitsToolStripMenuItem, "configureRestrictionReportingLimitsToolStripMenuItem");
            // 
            // configureRestrictionListsToolStripMenuItem
            // 
            this.configureRestrictionListsToolStripMenuItem.Name = "configureRestrictionListsToolStripMenuItem";
            resources.ApplyResources(this.configureRestrictionListsToolStripMenuItem, "configureRestrictionListsToolStripMenuItem");
            // 
            // adminLabAlertsToolStripMenuItem
            // 
            this.adminLabAlertsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labAlertConfigurationToolStripMenuItem});
            this.adminLabAlertsToolStripMenuItem.Name = "adminLabAlertsToolStripMenuItem";
            resources.ApplyResources(this.adminLabAlertsToolStripMenuItem, "adminLabAlertsToolStripMenuItem");
            // 
            // labAlertConfigurationToolStripMenuItem
            // 
            this.labAlertConfigurationToolStripMenuItem.Name = "labAlertConfigurationToolStripMenuItem";
            resources.ApplyResources(this.labAlertConfigurationToolStripMenuItem, "labAlertConfigurationToolStripMenuItem");
            // 
            // adminLogsToolStripMenuItem
            // 
            this.adminLogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureCutoffTimeForEditingDORCommentsToolStripMenuItem,
            this.customFieldsToolStripMenuItem,
            this.logGuidelineConfigurationToolStripMenuItem,
            this.logTemplatesToolStripMenuItem});
            this.adminLogsToolStripMenuItem.Name = "adminLogsToolStripMenuItem";
            resources.ApplyResources(this.adminLogsToolStripMenuItem, "adminLogsToolStripMenuItem");
            // 
            // configureCutoffTimeForEditingDORCommentsToolStripMenuItem
            // 
            this.configureCutoffTimeForEditingDORCommentsToolStripMenuItem.Name = "configureCutoffTimeForEditingDORCommentsToolStripMenuItem";
            resources.ApplyResources(this.configureCutoffTimeForEditingDORCommentsToolStripMenuItem, "configureCutoffTimeForEditingDORCommentsToolStripMenuItem");
            // 
            // customFieldsToolStripMenuItem
            // 
            this.customFieldsToolStripMenuItem.Name = "customFieldsToolStripMenuItem";
            resources.ApplyResources(this.customFieldsToolStripMenuItem, "customFieldsToolStripMenuItem");
            // 
            // logGuidelineConfigurationToolStripMenuItem
            // 
            this.logGuidelineConfigurationToolStripMenuItem.Name = "logGuidelineConfigurationToolStripMenuItem";
            resources.ApplyResources(this.logGuidelineConfigurationToolStripMenuItem, "logGuidelineConfigurationToolStripMenuItem");
            // 
            // logTemplatesToolStripMenuItem
            // 
            this.logTemplatesToolStripMenuItem.Name = "logTemplatesToolStripMenuItem";
            resources.ApplyResources(this.logTemplatesToolStripMenuItem, "logTemplatesToolStripMenuItem");
            // 
            // adminCokerCardsToolStripMenuItem
            // 
            this.adminCokerCardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cokerCardConfigurationToolStripMenuItem});
            this.adminCokerCardsToolStripMenuItem.Name = "adminCokerCardsToolStripMenuItem";
            resources.ApplyResources(this.adminCokerCardsToolStripMenuItem, "adminCokerCardsToolStripMenuItem");
            // 
            // cokerCardConfigurationToolStripMenuItem
            // 
            this.cokerCardConfigurationToolStripMenuItem.Name = "cokerCardConfigurationToolStripMenuItem";
            resources.ApplyResources(this.cokerCardConfigurationToolStripMenuItem, "cokerCardConfigurationToolStripMenuItem");
            // 
            // adminShiftHandoverToolStripMenuItem
            // 
            this.adminShiftHandoverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shiftHandoverConfigurationToolStripMenuItem,
            this.shiftHandoverEmailConfigurationToolStripMenuItem});
            this.adminShiftHandoverToolStripMenuItem.Name = "adminShiftHandoverToolStripMenuItem";
            resources.ApplyResources(this.adminShiftHandoverToolStripMenuItem, "adminShiftHandoverToolStripMenuItem");
            // 
            // shiftHandoverConfigurationToolStripMenuItem
            // 
            this.shiftHandoverConfigurationToolStripMenuItem.Name = "shiftHandoverConfigurationToolStripMenuItem";
            resources.ApplyResources(this.shiftHandoverConfigurationToolStripMenuItem, "shiftHandoverConfigurationToolStripMenuItem");
            // 
            // shiftHandoverEmailConfigurationToolStripMenuItem
            // 
            this.shiftHandoverEmailConfigurationToolStripMenuItem.Name = "shiftHandoverEmailConfigurationToolStripMenuItem";
            resources.ApplyResources(this.shiftHandoverEmailConfigurationToolStripMenuItem, "shiftHandoverEmailConfigurationToolStripMenuItem");
            // 
            // adminWorkPermitsToolStripMenuItem
            // 
            this.adminWorkPermitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureWorkPermitArchivalProcessToolStripMenuItem,
            this.associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem,
            this.configureWorkPermitContractorToolStripMenuItem,
            this.configureWorkCentersToolStripMenuItem,
            this.configureGasTestLimitsToolStrip,
            this.configureWorkPermitMontrealTemplatesToolStripMenuItem,
            this.configureWorkPermitMontrealDropdownsToolStripMenuItem,
            this.configureConfiguredDocumentLinksToolStripMenuItem,
            this.associateWorkAssignmentsForPermitsToolStripMenuItem,
            this.areaLabelsToolStripMenuItem,
            this.configureWorkPermitGroupsMenuItem,
            this.configureRoadAccessOnPermitToolStripMenuItem,
            this.configureSpecialWorkToolStripMenuItem});
            this.adminWorkPermitsToolStripMenuItem.Name = "adminWorkPermitsToolStripMenuItem";
            resources.ApplyResources(this.adminWorkPermitsToolStripMenuItem, "adminWorkPermitsToolStripMenuItem");
            // 
            // configureWorkPermitArchivalProcessToolStripMenuItem
            // 
            this.configureWorkPermitArchivalProcessToolStripMenuItem.Name = "configureWorkPermitArchivalProcessToolStripMenuItem";
            resources.ApplyResources(this.configureWorkPermitArchivalProcessToolStripMenuItem, "configureWorkPermitArchivalProcessToolStripMenuItem");
            // 
            // associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem
            // 
            this.associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem.Name = "associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem";
            resources.ApplyResources(this.associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem, "associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem");
            // 
            // configureWorkPermitContractorToolStripMenuItem
            // 
            this.configureWorkPermitContractorToolStripMenuItem.Name = "configureWorkPermitContractorToolStripMenuItem";
            resources.ApplyResources(this.configureWorkPermitContractorToolStripMenuItem, "configureWorkPermitContractorToolStripMenuItem");
            // 
            // configureWorkCentersToolStripMenuItem
            // 
            this.configureWorkCentersToolStripMenuItem.Name = "configureWorkCentersToolStripMenuItem";
            resources.ApplyResources(this.configureWorkCentersToolStripMenuItem, "configureWorkCentersToolStripMenuItem");
            // 
            // configureGasTestLimitsToolStrip
            // 
            this.configureGasTestLimitsToolStrip.Name = "configureGasTestLimitsToolStrip";
            resources.ApplyResources(this.configureGasTestLimitsToolStrip, "configureGasTestLimitsToolStrip");
            // 
            // configureWorkPermitMontrealTemplatesToolStripMenuItem
            // 
            this.configureWorkPermitMontrealTemplatesToolStripMenuItem.Name = "configureWorkPermitMontrealTemplatesToolStripMenuItem";
            resources.ApplyResources(this.configureWorkPermitMontrealTemplatesToolStripMenuItem, "configureWorkPermitMontrealTemplatesToolStripMenuItem");
            // 
            // configureWorkPermitMontrealDropdownsToolStripMenuItem
            // 
            this.configureWorkPermitMontrealDropdownsToolStripMenuItem.Name = "configureWorkPermitMontrealDropdownsToolStripMenuItem";
            resources.ApplyResources(this.configureWorkPermitMontrealDropdownsToolStripMenuItem, "configureWorkPermitMontrealDropdownsToolStripMenuItem");
            // 
            // configureConfiguredDocumentLinksToolStripMenuItem
            // 
            this.configureConfiguredDocumentLinksToolStripMenuItem.Name = "configureConfiguredDocumentLinksToolStripMenuItem";
            resources.ApplyResources(this.configureConfiguredDocumentLinksToolStripMenuItem, "configureConfiguredDocumentLinksToolStripMenuItem");
            // 
            // associateWorkAssignmentsForPermitsToolStripMenuItem
            // 
            this.associateWorkAssignmentsForPermitsToolStripMenuItem.Name = "associateWorkAssignmentsForPermitsToolStripMenuItem";
            resources.ApplyResources(this.associateWorkAssignmentsForPermitsToolStripMenuItem, "associateWorkAssignmentsForPermitsToolStripMenuItem");
            // 
            // areaLabelsToolStripMenuItem
            // 
            this.areaLabelsToolStripMenuItem.Name = "areaLabelsToolStripMenuItem";
            resources.ApplyResources(this.areaLabelsToolStripMenuItem, "areaLabelsToolStripMenuItem");
            // 
            // configureWorkPermitGroupsMenuItem
            // 
            this.configureWorkPermitGroupsMenuItem.Name = "configureWorkPermitGroupsMenuItem";
            resources.ApplyResources(this.configureWorkPermitGroupsMenuItem, "configureWorkPermitGroupsMenuItem");
            // 
            // configureRoadAccessOnPermitToolStripMenuItem
            // 
            this.configureRoadAccessOnPermitToolStripMenuItem.Name = "configureRoadAccessOnPermitToolStripMenuItem";
            resources.ApplyResources(this.configureRoadAccessOnPermitToolStripMenuItem, "configureRoadAccessOnPermitToolStripMenuItem");
            // 
            // configureSpecialWorkToolStripMenuItem
            // 
            this.configureSpecialWorkToolStripMenuItem.Name = "configureSpecialWorkToolStripMenuItem";
            resources.ApplyResources(this.configureSpecialWorkToolStripMenuItem, "configureSpecialWorkToolStripMenuItem");
            // 
            // restrictionsToolStripMenuItem
            // 
            this.restrictionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restrictionFlocsToolStripMenuItem});
            this.restrictionsToolStripMenuItem.Name = "restrictionsToolStripMenuItem";
            resources.ApplyResources(this.restrictionsToolStripMenuItem, "restrictionsToolStripMenuItem");
            // 
            // restrictionFlocsToolStripMenuItem
            // 
            this.restrictionFlocsToolStripMenuItem.Name = "restrictionFlocsToolStripMenuItem";
            resources.ApplyResources(this.restrictionFlocsToolStripMenuItem, "restrictionFlocsToolStripMenuItem");
            // 
            // adminFormsToolStripMenuItem
            // 
            this.adminFormsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureFormTemplatesToolStripMenuItem,
            this.configureTrainingBlocksToolStripMenuItem,
            this.configureFormDropdownsToolStripMenuItem,
            this.configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem,
            this.configureGenericTemplateApprovalToolStripMenuItem,
            this.configureGenericTemplateEmailApprovalToolStripMenuItem});
            this.adminFormsToolStripMenuItem.Name = "adminFormsToolStripMenuItem";
            resources.ApplyResources(this.adminFormsToolStripMenuItem, "adminFormsToolStripMenuItem");
            // 
            // configureFormTemplatesToolStripMenuItem
            // 
            this.configureFormTemplatesToolStripMenuItem.Name = "configureFormTemplatesToolStripMenuItem";
            resources.ApplyResources(this.configureFormTemplatesToolStripMenuItem, "configureFormTemplatesToolStripMenuItem");
            // 
            // configureTrainingBlocksToolStripMenuItem
            // 
            this.configureTrainingBlocksToolStripMenuItem.Name = "configureTrainingBlocksToolStripMenuItem";
            resources.ApplyResources(this.configureTrainingBlocksToolStripMenuItem, "configureTrainingBlocksToolStripMenuItem");
            // 
            // configureFormDropdownsToolStripMenuItem
            // 
            this.configureFormDropdownsToolStripMenuItem.Name = "configureFormDropdownsToolStripMenuItem";
            resources.ApplyResources(this.configureFormDropdownsToolStripMenuItem, "configureFormDropdownsToolStripMenuItem");
            // 
            // configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem
            // 
            this.configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem.Name = "configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem";
            resources.ApplyResources(this.configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem, "configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem");
            // 
            // configureGenericTemplateApprovalToolStripMenuItem
            // 
            this.configureGenericTemplateApprovalToolStripMenuItem.Name = "configureGenericTemplateApprovalToolStripMenuItem";
            resources.ApplyResources(this.configureGenericTemplateApprovalToolStripMenuItem, "configureGenericTemplateApprovalToolStripMenuItem");
            // 
            // configureGenericTemplateEmailApprovalToolStripMenuItem
            // 
            this.configureGenericTemplateEmailApprovalToolStripMenuItem.Name = "configureGenericTemplateEmailApprovalToolStripMenuItem";
            resources.ApplyResources(this.configureGenericTemplateEmailApprovalToolStripMenuItem, "configureGenericTemplateEmailApprovalToolStripMenuItem");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // adminDisplaySettingsToolStripMenuItem
            // 
            this.adminDisplaySettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureDefaultTabsToolStripMenuItem,
            this.configureDisplayLimitsToolStripMenuItem});
            this.adminDisplaySettingsToolStripMenuItem.Name = "adminDisplaySettingsToolStripMenuItem";
            resources.ApplyResources(this.adminDisplaySettingsToolStripMenuItem, "adminDisplaySettingsToolStripMenuItem");
            // 
            // configureDefaultTabsToolStripMenuItem
            // 
            this.configureDefaultTabsToolStripMenuItem.Name = "configureDefaultTabsToolStripMenuItem";
            resources.ApplyResources(this.configureDefaultTabsToolStripMenuItem, "configureDefaultTabsToolStripMenuItem");
            // 
            // configureDisplayLimitsToolStripMenuItem
            // 
            this.configureDisplayLimitsToolStripMenuItem.Name = "configureDisplayLimitsToolStripMenuItem";
            resources.ApplyResources(this.configureDisplayLimitsToolStripMenuItem, "configureDisplayLimitsToolStripMenuItem");
            // 
            // adminWorkAssignmentsToolStripMenuItem
            // 
            this.adminWorkAssignmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureAssignmentsToolStripMenuItem,
            this.configureDefaultFLOCsForDailyAssignmentToolStripMenuItem,
            this.visibilityGroupsToolStripMenuItem,
            this.configureWorkAssignmentNotSelectedWarningToolStripMenuItem});
            this.adminWorkAssignmentsToolStripMenuItem.Name = "adminWorkAssignmentsToolStripMenuItem";
            resources.ApplyResources(this.adminWorkAssignmentsToolStripMenuItem, "adminWorkAssignmentsToolStripMenuItem");
            // 
            // configureAssignmentsToolStripMenuItem
            // 
            this.configureAssignmentsToolStripMenuItem.Name = "configureAssignmentsToolStripMenuItem";
            resources.ApplyResources(this.configureAssignmentsToolStripMenuItem, "configureAssignmentsToolStripMenuItem");
            // 
            // configureDefaultFLOCsForDailyAssignmentToolStripMenuItem
            // 
            this.configureDefaultFLOCsForDailyAssignmentToolStripMenuItem.Name = "configureDefaultFLOCsForDailyAssignmentToolStripMenuItem";
            resources.ApplyResources(this.configureDefaultFLOCsForDailyAssignmentToolStripMenuItem, "configureDefaultFLOCsForDailyAssignmentToolStripMenuItem");
            // 
            // visibilityGroupsToolStripMenuItem
            // 
            this.visibilityGroupsToolStripMenuItem.Name = "visibilityGroupsToolStripMenuItem";
            resources.ApplyResources(this.visibilityGroupsToolStripMenuItem, "visibilityGroupsToolStripMenuItem");
            // 
            // configureWorkAssignmentNotSelectedWarningToolStripMenuItem
            // 
            this.configureWorkAssignmentNotSelectedWarningToolStripMenuItem.Name = "configureWorkAssignmentNotSelectedWarningToolStripMenuItem";
            resources.ApplyResources(this.configureWorkAssignmentNotSelectedWarningToolStripMenuItem, "configureWorkAssignmentNotSelectedWarningToolStripMenuItem");
            // 
            // adminSiteConfigurationToolStripMenuItem
            // 
            this.adminSiteConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkPathsToolStripMenuItem,
            this.functionalLocationsToolStripMenuItem,
            this.manageOperationalModeForUnitsToolStripMenuItem,
            this.siteCommunicationsToolStripMenuItem,
            this.MainForm_FlocLevelSettings,
            this.configureOLTCommunityToolStripMenuItem});
            this.adminSiteConfigurationToolStripMenuItem.Name = "adminSiteConfigurationToolStripMenuItem";
            resources.ApplyResources(this.adminSiteConfigurationToolStripMenuItem, "adminSiteConfigurationToolStripMenuItem");
            // 
            // linkPathsToolStripMenuItem
            // 
            this.linkPathsToolStripMenuItem.Name = "linkPathsToolStripMenuItem";
            resources.ApplyResources(this.linkPathsToolStripMenuItem, "linkPathsToolStripMenuItem");
            // 
            // functionalLocationsToolStripMenuItem
            // 
            this.functionalLocationsToolStripMenuItem.Name = "functionalLocationsToolStripMenuItem";
            resources.ApplyResources(this.functionalLocationsToolStripMenuItem, "functionalLocationsToolStripMenuItem");
            // 
            // manageOperationalModeForUnitsToolStripMenuItem
            // 
            this.manageOperationalModeForUnitsToolStripMenuItem.Name = "manageOperationalModeForUnitsToolStripMenuItem";
            resources.ApplyResources(this.manageOperationalModeForUnitsToolStripMenuItem, "manageOperationalModeForUnitsToolStripMenuItem");
            // 
            // siteCommunicationsToolStripMenuItem
            // 
            this.siteCommunicationsToolStripMenuItem.Name = "siteCommunicationsToolStripMenuItem";
            resources.ApplyResources(this.siteCommunicationsToolStripMenuItem, "siteCommunicationsToolStripMenuItem");
            // 
            // MainForm_FlocLevelSettings
            // 
            this.MainForm_FlocLevelSettings.Name = "MainForm_FlocLevelSettings";
            resources.ApplyResources(this.MainForm_FlocLevelSettings, "MainForm_FlocLevelSettings");
            // 
            // configureOLTCommunityToolStripMenuItem
            // 
            this.configureOLTCommunityToolStripMenuItem.Name = "configureOLTCommunityToolStripMenuItem";
            resources.ApplyResources(this.configureOLTCommunityToolStripMenuItem, "configureOLTCommunityToolStripMenuItem");
            // 
            // technicalAdministrationToolStripMenuItem
            // 
            this.technicalAdministrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureRoleMatrixToolStripMenuItem,
            this.configureRolePermissionsToolStripMenuItem,
            this.configureRoleToolStripMenuItem,
            this.toolStripSeparator4,
            this.technicalSiteConfigurationToolStripMenuItem,
            this.sapAutoImportToolStripMenuItem,
            this.honeywellPHDToolStripMenuItem,
            this.analyticsExcelExportToolStripMenuItem,
            this.toolStripSeparator3,
            this.enableSecurityForNewDirectivesToolStripMenuItem,
            this.convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem});
            this.technicalAdministrationToolStripMenuItem.Name = "technicalAdministrationToolStripMenuItem";
            resources.ApplyResources(this.technicalAdministrationToolStripMenuItem, "technicalAdministrationToolStripMenuItem");
            // 
            // configureRoleMatrixToolStripMenuItem
            // 
            this.configureRoleMatrixToolStripMenuItem.Name = "configureRoleMatrixToolStripMenuItem";
            resources.ApplyResources(this.configureRoleMatrixToolStripMenuItem, "configureRoleMatrixToolStripMenuItem");
            // 
            // configureRolePermissionsToolStripMenuItem
            // 
            this.configureRolePermissionsToolStripMenuItem.Name = "configureRolePermissionsToolStripMenuItem";
            resources.ApplyResources(this.configureRolePermissionsToolStripMenuItem, "configureRolePermissionsToolStripMenuItem");
            // 
            // configureRoleToolStripMenuItem
            // 
            this.configureRoleToolStripMenuItem.Name = "configureRoleToolStripMenuItem";
            resources.ApplyResources(this.configureRoleToolStripMenuItem, "configureRoleToolStripMenuItem");
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // technicalSiteConfigurationToolStripMenuItem
            // 
            this.technicalSiteConfigurationToolStripMenuItem.Name = "technicalSiteConfigurationToolStripMenuItem";
            resources.ApplyResources(this.technicalSiteConfigurationToolStripMenuItem, "technicalSiteConfigurationToolStripMenuItem");
            // 
            // sapAutoImportToolStripMenuItem
            // 
            this.sapAutoImportToolStripMenuItem.Name = "sapAutoImportToolStripMenuItem";
            resources.ApplyResources(this.sapAutoImportToolStripMenuItem, "sapAutoImportToolStripMenuItem");
            // 
            // honeywellPHDToolStripMenuItem
            // 
            this.honeywellPHDToolStripMenuItem.Name = "honeywellPHDToolStripMenuItem";
            resources.ApplyResources(this.honeywellPHDToolStripMenuItem, "honeywellPHDToolStripMenuItem");
            // 
            // analyticsExcelExportToolStripMenuItem
            // 
            this.analyticsExcelExportToolStripMenuItem.Name = "analyticsExcelExportToolStripMenuItem";
            resources.ApplyResources(this.analyticsExcelExportToolStripMenuItem, "analyticsExcelExportToolStripMenuItem");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // enableSecurityForNewDirectivesToolStripMenuItem
            // 
            this.enableSecurityForNewDirectivesToolStripMenuItem.Name = "enableSecurityForNewDirectivesToolStripMenuItem";
            resources.ApplyResources(this.enableSecurityForNewDirectivesToolStripMenuItem, "enableSecurityForNewDirectivesToolStripMenuItem");
            // 
            // convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem
            // 
            this.convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem.Name = "convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem";
            resources.ApplyResources(this.convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem, "convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem");
            // 
            // menuItemOLTApplicationHelp
            // 
            this.menuItemOLTApplicationHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oltApplicationHelpToolStripMenuItem,
            this.toolStripMenuItem3,
            this.supportToolStripMenuItem,
            this.releaseNotesToolStripMenuItem,
            this.oltAdministratorListToolStripMenuItem});
            this.menuItemOLTApplicationHelp.Name = "menuItemOLTApplicationHelp";
            resources.ApplyResources(this.menuItemOLTApplicationHelp, "menuItemOLTApplicationHelp");
            // 
            // oltApplicationHelpToolStripMenuItem
            // 
            this.oltApplicationHelpToolStripMenuItem.Name = "oltApplicationHelpToolStripMenuItem";
            resources.ApplyResources(this.oltApplicationHelpToolStripMenuItem, "oltApplicationHelpToolStripMenuItem");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roleMatrixToolStripMenuItem,
            this.toolStripSeparator1,
            this.openLogFileToolStripMenuItem,
            this.emailLogFileToolStripMenuItem});
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            resources.ApplyResources(this.supportToolStripMenuItem, "supportToolStripMenuItem");
            // 
            // roleMatrixToolStripMenuItem
            // 
            this.roleMatrixToolStripMenuItem.Name = "roleMatrixToolStripMenuItem";
            resources.ApplyResources(this.roleMatrixToolStripMenuItem, "roleMatrixToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // openLogFileToolStripMenuItem
            // 
            this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            resources.ApplyResources(this.openLogFileToolStripMenuItem, "openLogFileToolStripMenuItem");
            // 
            // emailLogFileToolStripMenuItem
            // 
            this.emailLogFileToolStripMenuItem.Name = "emailLogFileToolStripMenuItem";
            resources.ApplyResources(this.emailLogFileToolStripMenuItem, "emailLogFileToolStripMenuItem");
            // 
            // releaseNotesToolStripMenuItem
            // 
            this.releaseNotesToolStripMenuItem.Name = "releaseNotesToolStripMenuItem";
            resources.ApplyResources(this.releaseNotesToolStripMenuItem, "releaseNotesToolStripMenuItem");
            // 
            // oltAdministratorListToolStripMenuItem
            // 
            this.oltAdministratorListToolStripMenuItem.Name = "oltAdministratorListToolStripMenuItem";
            resources.ApplyResources(this.oltAdministratorListToolStripMenuItem, "oltAdministratorListToolStripMenuItem");
            // 
            // userStrip
            // 
            resources.ApplyResources(this.userStrip, "userStrip");
            this.userStrip.Name = "userStrip";
            // 
            // menuItemNewGenericFormCriticalSystemDefeat
            // 
            this.menuItemNewGenericFormCriticalSystemDefeat.Name = "menuItemNewGenericFormCriticalSystemDefeat";
            resources.ApplyResources(this.menuItemNewGenericFormCriticalSystemDefeat, "menuItemNewGenericFormCriticalSystemDefeat");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.userStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuItemEdit);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuItemEdit;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MainForm_HelpRequested);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuItemEdit.ResumeLayout(false);
            this.menuItemEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip;
        private MenuStrip menuItemEdit;
        private ToolStripMenuItem menuItemFile;
        private ToolStripMenuItem menuItemFileExit;
        private MainUserStrip userStrip;
        private Panel contentPanel;
        private MainNavigationListView navigationListView;
        private SplitContainer mainSplitContainer;
        private ToolStripStatusLabel buildVersion;
        private ToolStripMenuItem menuItemNew;
        private ToolStripMenuItem menuItemLogOut;
        private ToolStripMenuItem menuItemChangeActiveFLOC;
        private ToolStripMenuItem menuItemNewActionItem;
        private ToolStripMenuItem menuItemNewTarget;
        private ToolStripMenuItem menuItemNewRestriction;
        private ToolStripMenuItem menuItemLog;
        private ToolStripMenuItem menuItemNewLogEntry;
        private ToolStripMenuItem menuItemNewShiftSummaryLogEntry;
        private ToolStripMenuItem menuItemNewWorkPermit;
        private ToolStripMenuItem menuItemNewLabAlert;
        private ToolStripMenuItem menuItemNewShiftHandoverQuestionnaire;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem menuItemReports;
        private ToolStripMenuItem menuItemOLTApplicationHelp;
        private ToolStripMenuItem oltApplicationHelpToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem administrationToolStripMenuItem;
        private ToolStripMenuItem configureGasTestLimitsToolStrip;
        private ToolStripMenuItem menuItemPreferences;
        private ToolStripMenuItem configureWorkPermitArchivalProcessToolStripMenuItem;
        private ToolStripMenuItem configureWorkPermitContractorToolStripMenuItem;
        private ToolStripMenuItem configureDefaultFLOCsForDailyAssignmentToolStripMenuItem;
        private ToolStripMenuItem configureAssignmentsToolStripMenuItem;
        private ToolStripMenuItem configureWorkCentersToolStripMenuItem;
        private ToolStripMenuItem adminSiteConfigurationToolStripMenuItem;
        private ToolStripMenuItem adminDisplaySettingsToolStripMenuItem;
        private ToolStripMenuItem adminWorkAssignmentsToolStripMenuItem;
        private ToolStripMenuItem adminWorkPermitsToolStripMenuItem;
        private ToolStripMenuItem manageOperationalModeForUnitsToolStripMenuItem;
        private ToolStripMenuItem adminRestrictionsToolStripMenuItem;
        private ToolStripMenuItem configureRestrictionReportingLimitsToolStripMenuItem;
        private ToolStripMenuItem editReasonCodesToolStripMenuItem;
        private ToolStripMenuItem dailyDirectiveLogEntryToolStripMenuItem;
        private ToolStripMenuItem configureDisplayLimitsToolStripMenuItem;
        private ToolStripMenuItem configureDefaultTabsToolStripMenuItem;
        private ToolStripMenuItem configureWorkAssignmentNotSelectedWarningToolStripMenuItem;
        private ToolStripMenuItem adminLogsToolStripMenuItem;
        private ToolStripMenuItem configureCutoffTimeForEditingDORCommentsToolStripMenuItem;
        private ToolStripMenuItem logGuidelineConfigurationToolStripMenuItem;
        private ToolStripMenuItem customFieldsToolStripMenuItem;
        private ToolStripMenuItem logTemplatesToolStripMenuItem;
        private ToolStripMenuItem linkPathsToolStripMenuItem;
        private ToolStripMenuItem menuItemCokerCardEntry;
        private ToolStripMenuItem supportToolStripMenuItem;
        private ToolStripMenuItem roleMatrixToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem openLogFileToolStripMenuItem;
        private ToolStripMenuItem emailLogFileToolStripMenuItem;
		private ToolStripMenuItem configureWorkPermitMontrealTemplatesToolStripMenuItem;
        private ToolStripMenuItem adminPrioritiesToolStripMenuItem;
        private ToolStripMenuItem priorityDisplayCriteriaToolStripMenuItem;
        private ToolStripMenuItem permitRequestToolStripMenuItem;
        private ToolStripMenuItem reportsCokerCardsToolStripSubMenuItem;
        private ToolStripMenuItem menuItemCokerCardReport;
        private ToolStripMenuItem reportsLogsToolStripSubMenuItem;
        private ToolStripMenuItem menuItemDetailedLogReport;
        private ToolStripMenuItem menuItemOperatingEngineerShiftLogReport;
        private ToolStripMenuItem menuItemDailyShiftLogReport;
        private ToolStripMenuItem menuItemMarkedAsReadLogReport;
        private ToolStripMenuItem reportsRestrictionsToolStripSubMenuItem;
        private ToolStripMenuItem menuItemRestrictionReport;
        private ToolStripMenuItem reportsShiftHandoverToolStripSubMenuItem;
        private ToolStripMenuItem menuItemShiftHandoverReport;
        private ToolStripMenuItem reportsTargetsToolStripSubMenuItem;
        private ToolStripMenuItem menuItemShiftGapReasonReport;
        private ToolStripMenuItem adminActionItemsToolStripMenuItem;
        private ToolStripMenuItem configureActionItemSettingsStripMenuItem;
        private ToolStripMenuItem adminCokerCardsToolStripMenuItem;
        private ToolStripMenuItem cokerCardConfigurationToolStripMenuItem;
        private ToolStripMenuItem configureBusinessCategoriesToolStripMenuItem;
        private ToolStripMenuItem flocBusinessCategoryAssignmentToolStripMenuItem;
        private ToolStripMenuItem configureActionItemReApprovalToolStripMenuItem;
        private ToolStripMenuItem adminLabAlertsToolStripMenuItem;
        private ToolStripMenuItem labAlertConfigurationToolStripMenuItem;
        private ToolStripMenuItem adminShiftHandoverToolStripMenuItem;
        private ToolStripMenuItem shiftHandoverConfigurationToolStripMenuItem;
        private ToolStripMenuItem adminTargetsToolStripMenuItem;
        private ToolStripMenuItem configureTargetsReApprovalToolStripMenuItem;
        private ToolStripMenuItem configurePlantHistorianTagListToolStripMenuItem;
        private ToolStripMenuItem associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem menuItemDailyShiftAlertReport;
        private ToolStripMenuItem confinedSpaceDocumentToolStripMenuItem;
        private DevExpress.XtraSpellChecker.SharedDictionaryStorage sharedDictionaryStorage;
        private ToolStripMenuItem menuItemMarkedAsReadShiftHandoverReport;
        private ToolStripMenuItem configureWorkPermitMontrealDropdownsToolStripMenuItem;
        private ToolStripMenuItem menuItemNewLogDefinitionEntry;
        private ToolStripMenuItem menuItemNewStandingOrderEntry;
        private ToolStripMenuItem configureConfiguredDocumentLinksToolStripMenuItem;
        private ToolStripMenuItem menuItemTargetAlertExcelReport;
        private ToolStripMenuItem menuItemCustomFieldTrendReport;
        private ToolStripMenuItem menuItemForm;
        private ToolStripMenuItem menuItemNewGN7;
        private ToolStripMenuItem menuItemNewGN59;
        private ToolStripMenuItem menuItemNewOP14;
        private ToolStripMenuItem adminFormsToolStripMenuItem;
        private ToolStripMenuItem configureFormTemplatesToolStripMenuItem;
        private ToolStripMenuItem associateWorkAssignmentsForPermitsToolStripMenuItem;
        private ToolStripMenuItem visibilityGroupsToolStripMenuItem;
        private ToolStripMenuItem technicalAdministrationToolStripMenuItem;
        private ToolStripMenuItem configureRoleMatrixToolStripMenuItem;
        private ToolStripMenuItem configureRolePermissionsToolStripMenuItem;
        private ToolStripMenuItem areaLabelsToolStripMenuItem;
        private ToolStripMenuItem technicalSiteConfigurationToolStripMenuItem;
        private ToolStripMenuItem releaseNotesToolStripMenuItem;
        private ToolStripMenuItem shiftHandoverEmailConfigurationToolStripMenuItem;
        private ToolStripMenuItem menuItemNewFormOilsandsTraining;
        private ToolStripMenuItem menuItemNewFormForthillsTraining;                //ayman forthills
        private ToolStripMenuItem menuItemNewFormSiteWideTraining;                 //ayman E&U
        private ToolStripMenuItem reportsFormsToolStripSubMenuItem;
        private ToolStripMenuItem menuItemTrainingFormExcelReport;
        private ToolStripMenuItem configureTrainingBlocksToolStripMenuItem;
        private ToolStripMenuItem sapAutoImportToolStripMenuItem;
        private ToolStripMenuItem safeWorkPermitToolStripMenuItem;
        private ToolStripMenuItem menuItemPrintBlankWorkPermit;
        private ToolStripMenuItem siteCommunicationsToolStripMenuItem;
        private ToolStripMenuItem honeywellPHDToolStripMenuItem;
        private ToolStripMenuItem analyticsExcelExportToolStripMenuItem;
        private ToolStripMenuItem configureWorkPermitGroupsMenuItem;
        private ToolStripMenuItem menuItemNewGN24;
        private ToolStripMenuItem menuItemNewGN6;
        private ToolStripMenuItem reportsDirectivesToolStripMenuItem;
        private ToolStripMenuItem menuItemMarkedAsReadDirectiveReport;
        private ToolStripMenuItem menuItemNewDirective;
        private ToolStripMenuItem menuItemNewGN75A;
        private ToolStripMenuItem menuItemNewGN75B;
        private ToolStripMenuItem menuItemNewGN1;
        private ToolStripMenuItem configureRestrictionListsToolStripMenuItem;
        private ToolStripMenuItem menuItemTrainingFormReport;
        private ToolStripMenuItem functionalLocationsToolStripMenuItem;
        private ToolStripMenuItem menuItemNewFormOvertimeRequest;
        private ToolStripMenuItem menuItemOnPremisePersonnelReportToolStripMenuItem;
        private ToolStripMenuItem menuItemNewFormCriticalSystemDefeat;
        private ToolStripMenuItem configureFormDropdownsToolStripMenuItem;
        private ToolStripMenuItem menuItemNewMontrealFormCriticalSystemDefeat;
        private ToolStripMenuItem menuItemNewFormAlarmDisable;
        private ToolStripMenuItem configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem;
        private ToolStripMenuItem menuItemOilSandsSafeWorkPermitAuditQuestionnaire;

        //ayman Forthills
        private ToolStripMenuItem menuItemForthillsSafeWorkPermitAuditQuestionnaire;

        private ToolStripMenuItem restrictionsToolStripMenuItem;
        private ToolStripMenuItem restrictionFlocsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem enableSecurityForNewDirectivesToolStripMenuItem;
        private ToolStripMenuItem convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem;
        private ToolStripMenuItem safeWorkPermitAssessmentsReportToolStripMenuItem;



        private ToolStripMenuItem menuItemDocumentSuggestion;
        private ToolStripMenuItem menuItemProcedureDeviation;

        private ToolStripMenuItem configureRoadAccessOnPermitToolStripMenuItem;
        //ayman generic forms
        private ToolStripMenuItem menuItemNewSarniaOP14;
        private ToolStripMenuItem menuItemNewSarniaGN75BForm;      //ayman Sarnia eip DMND0008992
        private ToolStripMenuItem menuItemNewSarniaGN75BTemplate;  //ayman Sarnia eip DMND0008992

        //ayman selc
        private ToolStripMenuItem menuItemNewSelcOP14;

        private ToolStripMenuItem configureSpecialWorkToolStripMenuItem;
        private ToolStripMenuItem MainForm_FlocLevelSettings;
        private ToolStripMenuItem menuItemNewOdourNoise;
        private ToolStripMenuItem menuItemNewDeviation;
        private ToolStripMenuItem menuItemNewRoadClosure;
        private ToolStripMenuItem menuItemNewGN11GroundDistrubance;
        private ToolStripMenuItem menuItemNewGN27FreezePlug;
        private ToolStripMenuItem menuItemNewHazardAssessment;
        private ToolStripMenuItem configureGenericTemplateApprovalToolStripMenuItem;
        private ToolStripMenuItem oltAdministratorListToolStripMenuItem;
        private ToolStripMenuItem menuItemNewFormETFTraining;
        private ToolStripMenuItem configureOLTCommunityToolStripMenuItem;
        private ToolStripMenuItem configureRoleToolStripMenuItem;
  private ToolStripMenuItem menuItemNewMudsTemporaryInstallation;
  private ToolStripMenuItem menuItemFormOP14MarkAsReadReport;
  private ToolStripMenuItem menuItemNewOilSample;
  private ToolStripMenuItem menuItemNewDailyInspection;
        private ToolStripMenuItem readingReportToolStripMenuItem;
        private ToolStripMenuItem menuItemNewNonEmergencyWaterSystemApproval;
        private ToolStripMenuItem markedAsNotReadReportToolStripMenuItem;
        private ToolStripMenuItem configureGenericTemplateEmailApprovalToolStripMenuItem;
        private ToolStripMenuItem menuItemNewGenericFormCriticalSystemDefeat;
    }
}
