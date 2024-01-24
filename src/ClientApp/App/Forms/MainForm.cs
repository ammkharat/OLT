using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Controls.ToolStrips;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.Senders;
using DevExpress.XtraSpellChecker;
using DevExpress.XtraSplashScreen;
using CommonConstants = Com.Suncor.Olt.Common.Utility.Constants;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class MainForm : BaseForm, IMainForm
    {
        private readonly MainFormPresenter presenter;
        private string pageNamePrefix;
        private ChangeActiveRestrictionFunctionalLocationForm restrictionFlocsSelectForm;
        private ChangeActiveFunctionalLocationForm workPermitFlocsSelectForm;


        public event Action GetDefinitionsButtonClicked;  //ayman action item reading

        public MainForm()
        {
            InitializeComponent();

            MinimizeBox = true;
            UserLookAndFeel.Default.UseWindowsXPTheme = true;
            UserLookAndFeel.Default.Style = LookAndFeelStyle.Style3D;
            presenter = new MainFormPresenter(this);
            HookUpEventHandlers();
        }

        public void SetPageNamePrefix(string name)
        {
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            var productName = fileVersionInfo.ProductName;

            var buildEnvironment = string.Empty;
            var configurationSettings = ConfigurationManager.AppSettings;
            if (configurationSettings.Exists("BuildConfiguration"))
            {
                buildEnvironment = configurationSettings["BuildConfiguration"];
            }
            if (productName.IsNullOrEmptyOrWhitespace())
                productName = StringResources.ApplicationName;

            pageNamePrefix = buildEnvironment.IsNullOrEmptyOrWhitespace()
                ? productName
                : string.Format("{0} ({1})", productName, buildEnvironment);
            pageNamePrefix = name;
        }

        public bool ButtonsEnabled
        {
            set
            {
                menuItemEdit.Enabled = value;
                userStrip.Enabled = value;
            }
        }


        public void RegisterShiftEndHandler()
        {
            ClientSession.GetInstance().CurrentShiftHasEnded -= presenter.HandleCurrentShiftHasEnded;
            ClientSession.GetInstance().CurrentShiftGracePeriodHasEnded -= presenter.HandleShiftGracePeriodHasEnded;
            ClientSession.GetInstance().ShiftHandoverAlertEvent -= presenter.HandleShiftHandoverAlertEvent;//Arati
            ClientSession.GetInstance().CurrentShiftHasEnded += presenter.HandleCurrentShiftHasEnded;
            ClientSession.GetInstance().CurrentShiftGracePeriodHasEnded += presenter.HandleShiftGracePeriodHasEnded;
            ClientSession.GetInstance().ShiftHandoverAlertEvent += presenter.HandleShiftHandoverAlertEvent;//Arati
        }

        public void LaunchNoShiftFoundMessage(string message)
        {
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(LaunchNoShiftFoundMessage), message);
                }
                else
                {
                    OltMessageBox.Show(ActiveForm, message, StringResources.MainFormNoShiftFoundMessageBoxText);
                }
            }
        }

        //Addded by ppanigrahi
        public void DisplayGenericTemplateEmailApprovalConfigurationForm()
        {
            new GenericTemplateEmailApprovalConfigurationForm().ShowDialog(this);
        }
        public void LaunchEndOfGracePeriodMessage()
        {
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(LaunchEndOfGracePeriodMessage));
                }
                else
                {
                    var endTimeWithGracePeriod =
                        ClientSession.GetUserContext().UserShift.EndDateTimeWithPadding.ToTime();
                    OltMessageBox.Show(ActiveForm,
                        string.Format(StringResources.EndOfGracePeriodMessageBoxText,
                            endTimeWithGracePeriod.ToStringWithSeconds()));
                }
            }
        }


        //RITM0387753-Shift Handover creation alert (Aarti)
        public void LaunchShiftHandoverAlertEvent(DateTime now, TimeSpan timeRemainingToWork)
        {
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<DateTime, TimeSpan>(LaunchShiftHandoverAlertEvent), now, timeRemainingToWork);
                }
                else
                {
                    var shiftEndTime = ClientSession.GetUserContext().UserShift.EndDateTime.ToTime();
                    var currentTime = new Time(now);
                    //int alertTime=ClientSession.GetUserContext().SiteConfiguration.ShiftHandoverAlert;

                    DialogResult result = OltMessageBox.Show(this,
                 string.Format(StringResources.ShiftHandoverAlertMessageBoxText, (shiftEndTime - currentTime)),
                "Shift Handover Reminder",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        ShiftHandoverQuestionnaireFormPresenter.CheckForExistingQuestionnaireBeforeOpeningForm(this);
                    }

                }
            }
        }

        public void LaunchEndOfShiftMessage(DateTime now, TimeSpan timeRemainingToWork)
        {
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<DateTime, TimeSpan>(LaunchEndOfShiftMessage), now, timeRemainingToWork);
                }
                else
                {
                    var currentTime = new Time(now);
                    var message = string.Format(
                        StringResources.EndOfShiftMessage,
                        currentTime.ToStringWithSeconds(),
                        Convert.ToInt32(timeRemainingToWork.TotalMinutes),
                        timeRemainingToWork.Seconds);
                    OltMessageBox.Show(ActiveForm, message);
                }
            }
        }

        public DialogResult DisplayChangeActiveWorkPermitFunctionalLocationForm()
        {
            workPermitFlocsSelectForm = new ChangeActiveFunctionalLocationForm();
            return workPermitFlocsSelectForm.ShowDialog(this);
        }


        public DialogResult DisplayChangeActiveRestrictionFunctionalLocationForm()
        {
            restrictionFlocsSelectForm = new ChangeActiveRestrictionFunctionalLocationForm();
            return restrictionFlocsSelectForm.ShowDialog(this);
        }

        public DialogResultAndOutput<UserLoginSelections> DisplayAssignmentAndFunctionalLocationForm(
            bool changeActiveFlocsMode)
        {
            var assignmentSelectionForm =
                new AssignmentAndFunctionalLocationsSelectionForm();
            var assignmentSelectionPresenter =
                new AssignmentAndFunctionalLocationsSelectionFormPresenter(assignmentSelectionForm,
                    changeActiveFlocsMode);
            return assignmentSelectionPresenter.Run(this);
        }

        public void DisplayShiftHandoverConfigurationForm()
        {
            new ShiftHandoverConfigurationForm().ShowDialog(this);
        }

        public void DisplayQuestionnaireConfigurationForm()
        {
            new QuestionnaireConfigurationForm().ShowDialog(this);
        }

        public void DisplayCokerCardConfigurationForm()
        {
            new CokerCardConfigurationForm().ShowDialog(this);
        }

        public void DisplayCustomFieldConfigurationForm()
        {
            new CustomFieldGroupConfigurationForm().ShowDialog(this);
        }

        public void DisplayConfigureDORCutoffTimeForm()
        {
            new ConfigureDORCutoffTimeForm().ShowDialog(this);
        }

        public void DisplayPriorityCriteriaForm()
        {
            var priorityCriteriaFormPresenter = new PriorityCriteriaFormPresenter();
            priorityCriteriaFormPresenter.Run(this);
        }

        public DialogResultAndOutput<Role> DisplayRoleSelector()
        {
            var roleSelectionForm = new RoleSelectionForm();
            var result = roleSelectionForm.ShowDialog(this);
            var selectedRole = roleSelectionForm.SelectedRole;
            return new DialogResultAndOutput<Role>(result, selectedRole);
        }

        public List<FunctionalLocation> AllSelectedFunctionalLocationsForWorkPermits
        {
            get { return workPermitFlocsSelectForm.AllSelectedFunctionalLocations; }
        }

        public List<FunctionalLocation> AllSelectedFunctionalLocationsForRestrictions
        {
            get { return restrictionFlocsSelectForm.AllSelectedFunctionalLocations; }
        }

        public void UnSelectPageInNavigationList()
        {
            navigationListView.UnSelectPageInNavigationList();
        }


        public bool GetSelectSectionAndItem(PageKey pageKey, long domainObjectId)
        {
           // navigationListView.NavigateTo(pageKey.SectionKey);
            var section = presenter.GetSection(pageKey.SectionKey);
            if (section != null)
            {
                return section.GetSelectSingleItem(pageKey, domainObjectId, false);
            }
            return false;
        }

        public void SelectSectionAndItem(PageKey pageKey, long domainObjectId)
        {
            navigationListView.NavigateTo(pageKey.SectionKey);
            var section = presenter.GetSection(pageKey.SectionKey);
            if (section != null)
            {
                section.SelectSingleItem(pageKey, domainObjectId, false);
            }
        }

        public void SelectSectionAndItem(SectionKey key, DomainObject item)
        {
            SelectSectionAndItem(key, item, false);
        }

        public void SelectSectionAndItem(SectionKey key, DomainObject item, bool suppressItemNotFoundMessage)
        {
            navigationListView.NavigateTo(key);
            var section = presenter.GetSection(key);
            if (section != null)
            {
                section.SelectSingleItem(item, suppressItemNotFoundMessage);
            }
        }

        public void LoadSectionIntoMainContentPanel(ISection section)
        {
            LoadControlIntoMainContentPanel((Control) section);

            Title = navigationListView.SelectedSectionName;
        }

        public void LoadControlIntoMainContentPanel(Control control)
        {
            control.Visible = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(control);

            control.Dock = DockStyle.Fill;
            control.Size = contentPanel.Size;
            control.Visible = true;
        }

        public void ClearNavigation()
        {
            navigationListView.ClearNavigation();
        }

        public void AddNavigation(SectionKey key)
        {
            navigationListView.AddNavigation(key);
        }

        public SectionKey SelectedSection
        {
            get { return navigationListView.SelectedSection; }
        }

        public void NavigateTo(SectionKey key)
        {
            navigationListView.NavigateTo(key);
        }

        public IMainUserStrip UserStrip
        {
            get { return userStrip; }
        }

        public SharedDictionaryStorage SharedDictionaryStorage
        {
            get { return sharedDictionaryStorage; }
        }

        /// <summary>
        ///     Sets the title of the form
        /// </summary>
        public string Title
        {
            set { Text = pageNamePrefix + " - " + value; }
        }

        public IList<FunctionalLocation> TooltipFunctionalLocations
        {
            set
            {
                var flocNameList = new List<string>();
                value.ForEach(floc => flocNameList.Add(floc.FullHierarchyWithDescription));
                userStrip.ActiveFLOCNames = flocNameList;
            }
        }

        public string BuildVersion
        {
            set { buildVersion.Text = value; }
        }

        public DialogResult DisplaySignInForm()
        {
            var signInForm = new SignInForm();
            return signInForm.ShowDialog(this);
        }

        public void DisplaySplashScreen()
        {
            SplashScreenManager.ShowForm(typeof (OLTSplashScreen));
        }

        public void CloseSplashScreen()
        {
            SplashScreenManager.CloseForm();
        }

        public DialogResult DisplaySiteSelector()
        {
            var siteSelector = new SiteSelectionForm();
            var result = siteSelector.ShowDialog();
            siteSelector.Dispose();
            return result;
        }
        //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        public string SetShiftLogMenuItemName
        {
            set
            {
                menuItemNewLogEntry.Text = value;
                menuItemLog.Text = value;
            }
        }
        //END

        public bool PreferencesVisible
        {
            set { menuItemPreferences.Visible = value; }
        }

        // DMND0011225 CSD for WBR
        public bool CreateGenericCsdVisible
        {
            set { menuItemNewGenericFormCriticalSystemDefeat.Visible = value; }
        }

        public bool CreateActionItemVisible
        {
            set { menuItemNewActionItem.Visible = value; }
        }

        public bool CreateTargetVisible
        {
            set { menuItemNewTarget.Visible = value; }
        }

        public bool CreateRestrictionVisible
        {
            set { menuItemNewRestriction.Visible = value; }
        }

        public bool CreateLogSubMenuVisible
        {
            set { menuItemLog.Visible = value; }
        }

        public bool CreateLogVisible
        {
            set { menuItemNewLogEntry.Visible = value; }
        }

        public bool CreateRepeatingLogVisible
        {
            set { menuItemNewLogDefinitionEntry.Visible = value; }
        }

        public bool CreateShiftSummaryLogVisible
        {
            set { menuItemNewShiftSummaryLogEntry.Visible = value; }
        }

        public bool CreateDailyDirectiveLogEntryVisible
        {
            set { dailyDirectiveLogEntryToolStripMenuItem.Visible = value; }
        }

        public bool CreateStandingOrdersVisible
        {
            set { menuItemNewStandingOrderEntry.Visible = value; }
        }

        public bool CreateShiftHandoverQuestionnaireVisible
        {
            set { menuItemNewShiftHandoverQuestionnaire.Visible = value; }
        }

        public bool CreateDirectiveVisible
        {
            set { menuItemNewDirective.Visible = value; }
        }

        public bool CreateCokerCardVisible
        {
            set { menuItemCokerCardEntry.Visible = value; }
        }

        public bool CreateWorkPermitVisible
        {
            set { menuItemNewWorkPermit.Visible = value; }
        }

        public bool CreateLabAlertVisible
        {
            set { menuItemNewLabAlert.Visible = value; }
        }

        public bool CreatePermitRequestVisible
        {
            set { permitRequestToolStripMenuItem.Visible = value; }
        }

        public bool ConfigureFormTemplatesEnabled
        {
            set { configureFormTemplatesToolStripMenuItem.Enabled = value; }
        }

        //generic template - mangesh
        public bool ConfigureGenericTemplateApprovalEnabled
        {
            set { configureGenericTemplateApprovalToolStripMenuItem.Enabled = value; }
        }
        //Addded by ppanigrahi
        public bool ConfigureGenericEmailTemplateApprovalEnabled
        {

            set { configureGenericTemplateEmailApprovalToolStripMenuItem.Enabled = value; }
        }
        //cop member list - mangesh
        public bool ConfigureAdministratorListEnabled
        {
            set { oltAdministratorListToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureTrainingBlocksEnabled
        {
            set { configureTrainingBlocksToolStripMenuItem.Enabled = value; }
        }

        public bool AdminSafeWorkPermitQuestionnairesEnabled
        {
            set { configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem.Enabled = value; }
        }


        public bool ConfigureGasTestLimitsEnabled
        {
            set { configureGasTestLimitsToolStrip.Enabled = value; }
        }

        public bool ConfigureOperationalModeEnabled
        {
            set { manageOperationalModeForUnitsToolStripMenuItem.Enabled = value; }
        }
        
        public bool ConfigureRestrictionFlocsForWorkAssignmentsEnabled
        {
            set
            {
                restrictionsToolStripMenuItem.Visible = value;
                restrictionFlocsToolStripMenuItem.Enabled = value;
            }
        }

        public bool ConfigureDisplayLimitsEnabled
        {
            set { configureDisplayLimitsToolStripMenuItem.Enabled = value; }
        }
        //Sarika... Floc structure level changes...9Jan2017
        public bool ConfigureFlocLevelEnabled
        {
            set { MainForm_FlocLevelSettings.Enabled = value; }
        }

        public bool ConfigureDefaultTabsEnabled
        {
            set { configureDefaultTabsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureWorkAssignmentNotSelectedWarningEnabled
        {
            set { configureWorkAssignmentNotSelectedWarningToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureLabAlertsEnabled
        {
            set { labAlertConfigurationToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureWorkPermitArchivalProcessEnabled
        {
            set { configureWorkPermitArchivalProcessToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureAutoApproveSAPAIDEnabled
        {
            set { configureActionItemSettingsStripMenuItem.Enabled = value; }
        }

        public bool ConfigureWorkPermitContractorEnabled
        {
            set { configureWorkPermitContractorToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureCraftOrTradeEnabled
        {
            set { configureWorkCentersToolStripMenuItem.Enabled = value; }
        }
        //mangesh for RoadAccessOnPermit 
        public bool ConfigureRoadAccessOnPermitEnabled
        {
            set { configureRoadAccessOnPermitToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureSpecialWorkEnabled
        {
            set { configureSpecialWorkToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureWorkAssignmentsEnabled
        {
            set { configureAssignmentsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureVisibilityGroupsEnabled
        {
            set { visibilityGroupsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureWorkPermitGroupsEnabled
        {
            set { configureWorkPermitGroupsMenuItem.Enabled = value; }
        }

        public bool ConfigureAutoReApprovalByFieldEnabled
        {
            set
            {
                configureActionItemReApprovalToolStripMenuItem.Enabled = value;
                configureTargetsReApprovalToolStripMenuItem.Enabled = value;
            }
        }

        public bool ConfigurePlantHistorianTagListEnabled
        {
            set { configurePlantHistorianTagListToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureDefaultFLOCsForDailyAssignmentsEnabled
        {
            set { configureDefaultFLOCsForDailyAssignmentToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureAssociateWorkAssignmentsToFLOCsForPermitAutoAssignmentEnabled
        {
            set { associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureAssociateWorkAssignmentsForPermitsEnabled
        {
            set { associateWorkAssignmentsForPermitsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigurePriorityPageEnabled
        {
            set { priorityDisplayCriteriaToolStripMenuItem.Enabled = value; }
        }

        public bool OperatingEngineerShiftLogReportVisible
        {
            set { menuItemOperatingEngineerShiftLogReport.Visible = value; }
        }

        public string OperatingEngineerShiftLogReportDisplayText
        {
            set { menuItemOperatingEngineerShiftLogReport.Text = value; }
        }

        public bool CreateNewItemVisible
        {
            set { menuItemNew.Visible = value; }
        }

        public bool CreateConfinedSpaceVisible
        {
            set { confinedSpaceDocumentToolStripMenuItem.Visible = value; }
        }

        public bool ConfigureFunctionalLocationsEnabled
        {
            set
            {
                functionalLocationsToolStripMenuItem.Enabled = value;
            }
        }

        public void DisplayConfigureGasTestElementInfoForm()
        {
            new ConfigGasTestElementInfoForm().ShowDialog(this);
        }

        public void LaunchLockDeniedMessage(string message, string title)
        {
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LaunchNoOLTRolesMessage(string message, string title)
        {
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        public void LaunchReadOnlyRoleMessage(string message, string title)
        {
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DisplayConfigureFunctionalLocationsForm()
        {
            var form =
                new ConfigureFunctionalLocationsForm(
                    FunctionalLocationMode.GetAdmin(ClientSession.GetUserContext().SiteConfiguration));
            form.ShowDialog(this);
        }

        public void DisplayManageOperationalModeForUnitsForm()
        {
            new ManageOpModeForUnitLevelFLOCForm().ShowDialog(this);
        }

        public void DisplayConfigureSiteForm()
        {
            new ConfigureDisplayLimitsForm().ShowDialog(this);
        }

        public void DisplayConfigureDefaultTabsForm()
        {
            new ConfigureDefaultTabsForm().ShowDialog(this);
        }

        public void DisplayConfigureWorkAssignmentNotSelectedWarningForm()
        {
            new ConfigureWorkAssignmentNotSelectedWarningForm().ShowDialog(this);
        }

        public void DisplayLabAlertConfigurationForm()
        {
            new LabAlertConfigurationForm().ShowDialog(this);
        }

        public void DisplayConfigureRestrictionReportingLimitsForm()
        {
            new ConfigureRestrictionReportingLimitsForm().ShowDialog(this);
        }

        public void DisplayEditRestrictionReasonCodesForm()
        {
            new EditRestrictionReasonCodesForm().ShowDialog(this);
        }

        public void DisplayRestrictionLocationListConfigurationForm()
        {
            new RestrictionLocationListConfigurationForm().ShowDialog(this);
        }

        public void DisplayConfigureWorkPermitArchivalProcessForm()
        {
            new ConfigureWorkPermitArchivalProcessForm().ShowDialog(this);
        }

        public void DisplayConfigureActionItemsForm()
        {
            new ConfigureActionItemsForm().ShowDialog(this);
        }

        public void DisplayConfigureWorkPermitContractorForm()
        {
            new ConfigureSiteContractorForm().ShowDialog(this);
        }

        public void DisplayConfigureDefaultFlocsForDailyAssignnmentForm()
        {
            new ConfigureDefaultFlocsForDailyAssignmentForm().ShowDialog(this);
        }

        public void DisplayWorkPermitAutoAssignmentConfigurationForm()
        {
            var workPermitAutoAssignmentConfigurationPresenter =
                new WorkPermitAutoAssignmentConfigurationPresenter(new WorkPermitAssignmentConfigurationForm());
            workPermitAutoAssignmentConfigurationPresenter.Run(this);
        }

        public void DisplayRestrictionsFlocsConfigurationForm()
        {
            var restrictionFlocsPresenter =
                new RestrictionFlocsPresenter(new RestrictionFlocsForm());
            restrictionFlocsPresenter.Run(this);
        }

        public void DisplayWorkPermitAssignmentConfigurationForm()
        {
            var workPermitAssignmentConfigurationPresenter =
                new WorkPermitAssignmentConfigurationPresenter(new WorkPermitAssignmentConfigurationForm());
            workPermitAssignmentConfigurationPresenter.Run(this);
        }

        public void DisplayConfigurePlantHistorianTagListForm()
        {
            new ConfigurePHTagInfoGroupsForReportForm().ShowDialog(this);
        }

        public void DisplayConfigureCraftOrTradeForm()
        {
            new ConfigureCraftOrTradeForm().ShowDialog(this);
        }
        //mangesh for RoadAccessOnPermit 
        public void DisplayConfigureRoadAccessOnPermitForm()
        {
            new ConfigureRoadAccessOnPermitForm().ShowDialog(this);
        }

        public void DisplayConfigureSpecialWorkForm()
        {
            new ConfigureSpecialWorkForm().ShowDialog(this);
        }

        //mangesh - generic template
        public void DisplayGenericTemplateApprovalConfigurationForm()
        {
            new ConfigureGenericTemplateApprovalForm().ShowDialog(this);
        }

        //mangesh - cop member list
        public void DisplayAdministratorListConfigurationForm()
        {
            //new ConfigureAdministratorListForm().ShowDialog(this);
            new ConfigureAdministratorListForm("Configure Administrator List").ShowDialog(this);
        }
        public void DisplayAdministratorListForm()
        {
            //new OLTAdministratorListForm().ShowDialog(this);
            new ConfigureAdministratorListForm("Administrator / Contact List").ShowDialog(this);
        }
        //---------

        public void DisplayAssignmentConfigurationForm()
        {
            new AssignmentConfigurationForm().ShowDialog(this);
        }

        public void DisplayLogGuidelinesConfigurationForm()
        {
            var guidelinePresenter =
                new LogGuidelineConfigurationSelectionFormPresenter();
            guidelinePresenter.Run(this);
        }

        public void DisplayLogTemplatesConfigurationForm()
        {
            new LogTemplateConfigurationForm().ShowDialog(this);
        }

        public void DisplayFieldAutoReApprovalConfigurationForm()
        {
            var view = new FieldAutoReApprovalConfigurationForm();
            view.ShowDialog(this);
        }

        public void DisplayBusinessCategoriesForm()
        {
            new BusinessCategoryForm().ShowDialog(this);
        }

        public void DisplayBusinessCategoryFLOCAssociationForm()
        {
            new BusinessCategoryFLOCAssociationForm().ShowDialog(this);
        }

        public void DisplayWorkPermitMontrealTemplatesConfigurationForm()
        {
            new WorkPermitMontrealTemplateConfigurationForm().ShowDialog(this);
        }

        //RITM0301321 mangesh
        public void DisplayWorkPermitMudsTemplatesConfigurationForm()
        {
            new WorkPermitMudsTemplateConfigurationForm().ShowDialog(this);
        }

        public void DisplayWorkPermitMontrealDropdownsConfigurationForm()
        {
            new WorkPermitDropdownsConfigurationForm().ShowDialog(this);
        }

        public void DisplayFormDropdownsConfigurationForm()
        {
            new FormDropdownsConfigurationForm().ShowDialog(this);
        }

        public void DisplayConfiguredDocumentLinkConfigurationForm()
        {
            var configuredDocumentLinkConfigurationFormPresenter =
                new ConfiguredDocumentLinkConfigurationFormPresenter();
            configuredDocumentLinkConfigurationFormPresenter.Run(this);
        }

        public void DisplayFormTemplateConfigurationForm()
        {
            var formTemplateConfigurationFormPresenter =
                new FormTemplateConfigurationFormPresenter();
            formTemplateConfigurationFormPresenter.Run(this);
        }

        public void DisplayTrainingBlockConfigurationForm()
        {
            var trainingBlockConfigurationFormPresenter =
                new TrainingBlockConfigurationFormPresenter();
            trainingBlockConfigurationFormPresenter.Run(this);
        }

        public void AdminstrationVisible(bool visible)
        {
            administrationToolStripMenuItem.Visible = visible;
        }

        public void TechnicalAdminstrationVisible(bool visible)
        {
            technicalAdministrationToolStripMenuItem.Visible = visible;
        }

        public bool ConfigureSapAutoImportVisible
        {
            set { sapAutoImportToolStripMenuItem.Visible = value; }
        }

        public bool ConfigureRestrictionReasonCodeEnabled
        {
            set { editReasonCodesToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigurationRestrictionListsEnabled
        {
            set { configureRestrictionListsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureDeviationAlertResponseTimeLimitEnabled
        {
            set { configureRestrictionReportingLimitsToolStripMenuItem.Enabled = value; }
        }

        public bool RestrictionReportsVisible
        {
            set { reportsRestrictionsToolStripSubMenuItem.Visible = value; }
        }

        public bool CokerCardReportsVisible
        {
            set { reportsCokerCardsToolStripSubMenuItem.Visible = value; }
        }

        public bool LogReportsVisible
        {
            set { reportsLogsToolStripSubMenuItem.Visible = value; }
        }

        public bool FormReportsVisible
        {
            set { reportsFormsToolStripSubMenuItem.Visible = value; }
        }

        public bool OnPremisePersonnelReportVisible
        {
            set { menuItemOnPremisePersonnelReportToolStripMenuItem.Visible = value; }
        }

        public bool TrainingFormExcelVisible
        {
            set { menuItemTrainingFormExcelReport.Visible = value; }
        }

        /// <summary>
        /// Changed for: RITM0088705
        /// Changed By: Komal Sahu (ksahu)
        /// Changed Date: 15/03/2017
        /// </summary>
        /// Change starts/////////
        public bool SafeWorkPermitAssessmentReportVisible
        {
            set { safeWorkPermitAssessmentsReportToolStripMenuItem.Visible = value; }
        }
        /// Change Ends/////////

        public bool TrainingFormReportVisible
        {
            set { menuItemTrainingFormReport.Visible = value; }
        }

        public bool SafeWorkPermitMenuItemVisible
        {
            set { safeWorkPermitToolStripMenuItem.Visible = value; }
        }

        public bool ShiftHandoverReportsVisible
        {
            set { reportsShiftHandoverToolStripSubMenuItem.Visible = value; }
        }

        public bool DirectiveReportsVisible
        {
            set { reportsDirectivesToolStripMenuItem.Visible = value; }
        }

        public bool TargetReportsVisible
        {
            set { reportsTargetsToolStripSubMenuItem.Visible = value; }
        }

        public bool PrioritiesAdminSectionVisible
        {
            set { adminPrioritiesToolStripMenuItem.Visible = value; }
        }

        public bool ActionItemsAdminSectionVisible
        {
            set { adminActionItemsToolStripMenuItem.Visible = value; }
        }

        public bool LogsAdminSectionVisible
        {
            set { adminLogsToolStripMenuItem.Visible = value; }
        }

        public bool LabAlertsAdminSectionVisible
        {
            set { adminLabAlertsToolStripMenuItem.Visible = value; }
        }

        public bool RestrictionReportingAdminSectionVisible
        {
            set { adminRestrictionsToolStripMenuItem.Visible = value; }
        }

        public bool TargetsAdminSectionVisible
        {
            set { adminTargetsToolStripMenuItem.Visible = value; }
        }

        public bool ShiftHandoverAdminSectionVisible
        {
            set { adminShiftHandoverToolStripMenuItem.Visible = value; }
        }

        public bool CokerCardAdminSectionvisible
        {
            set { adminCokerCardsToolStripMenuItem.Visible = value; }
        }

        public bool SafeWorkPermitsAdminSectionVisible
        {
            set { adminWorkPermitsToolStripMenuItem.Visible = value; }
        }

        public bool FormsAdminSectionVisible
        {
            set { adminFormsToolStripMenuItem.Visible = value; }
        }

        public bool DisplaySettingsAdminSectionVisible
        {
            set { adminDisplaySettingsToolStripMenuItem.Visible = value; }
        }

        public bool WorkAssignmentAdminSectionVisible
        {
            set { adminWorkAssignmentsToolStripMenuItem.Visible = value; }
        }

        public bool SiteConfigurationAdminSectionVisible
        {
            set { adminSiteConfigurationToolStripMenuItem.Visible = value; }
        }

        public bool ConfigureBusinessCategoriesEnabled
        {
            set { configureBusinessCategoriesToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureBusinessCategoryFlocAssociationsEnabled
        {
            set { flocBusinessCategoryAssignmentToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureLogGuidelinesEnabled
        {
            set { logGuidelineConfigurationToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureLogTemplatesEnabled
        {
            set { logTemplatesToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureShiftHandoverEnabled
        {
            set { shiftHandoverConfigurationToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureShiftHandoverEmailEnabled
        {
            set { shiftHandoverEmailConfigurationToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureCokerCardsEnabled
        {
            set { cokerCardConfigurationToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureCustomFieldsEnabled
        {
            set { customFieldsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureDORCutoffTimeEnabled
        {
            set { configureCutoffTimeForEditingDORCommentsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureDORCutoffTimeVisible
        {
            set { configureCutoffTimeForEditingDORCommentsToolStripMenuItem.Visible = value; }
        }

        public bool ConfigureLinkConfigurationEnabled
        {
            set { linkPathsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureSiteCommunicationsEnabled
        {
            set { siteCommunicationsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureWorkPermitMontrealTemplatesEnabled
        {
            set { configureWorkPermitMontrealTemplatesToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureWorkPermitMontrealDropdownsEnabled
        {
            set { configureWorkPermitMontrealDropdownsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureFormDropdownsEnabled
        {
            set { configureFormDropdownsToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureConfiguredDocumentLinksEnabled
        {
            set { configureConfiguredDocumentLinksToolStripMenuItem.Enabled = value; }
        }

        public bool ConfigureAreaLabelsEnabled
        {
            set { areaLabelsToolStripMenuItem.Enabled = value; }
        }
        /*RITM0265746 - Sarnia CSD marked as read start  Report Part*/
        public bool FormOP14MarkAsReadReportVisible
        {
            set { menuItemFormOP14MarkAsReadReport.Visible = value; }
        }
        /*RITM0265746 - Sarnia CSD marked as read end  Report Part*/
        public void DisplayConfigureWorkPermitGroupsForm()
        {
            var workPermitGroupsPresenter =
                new ConfigureWorkPermitGroupsPresenter(new ConfigureWorkPermitGroupsForm());
            workPermitGroupsPresenter.Run(this);
        }

        //RITM0301321 mangesh
        public void DisplayMudsConfigureWorkPermitGroupsForm()
        {
            var workPermitGroupsPresenter =
                new ConfigureMudsWorkPermitGroupsPresenter(new ConfigureMudsWorkPermitGroupsForm());
            workPermitGroupsPresenter.Run(this);
        }

        public void DisplayConfigureRoleMatrixForm()
        {
            var configureRoleMatrixPresenter =
                new ConfigureRoleMatrixPresenter(new ConfigureRoleMatrixForm());
            configureRoleMatrixPresenter.Run(this);
        }

        //RITM0164850   Mukesh
        public void DisplayConfigureRoleForm()
        {
            new ConfigureRoleForm().ShowDialog(this);
        }

        public void DisplayConfigureRolePermissionsForm()
        {
            var configureRolePermissionsPresenter =
                new ConfigureRolePermissionsPresenter(new ConfigureRolePermissionsForm());
            configureRolePermissionsPresenter.Run(this);
        }

        public void DisplayConfigureAreaLabelsForm()
        {
            var configureAreaLabelsPresenter =
                new ConfigureAreaLabelsPresenter(new ConfigureAreaLabelsForm());
            configureAreaLabelsPresenter.Run(this);
        }

        public void DisplayTechnicalSiteConfigurationForm()
        {
            var siteConfigurationPresenter =
                new TechnicalSiteConfigurationPresenter(new TechnicalSiteConfigurationForm());
            siteConfigurationPresenter.Run(this);
        }

        public void DisplaySapAutoImportConfigurationForm()
        {
            var sapAutoImportConfigurationPresenter =
                new SapAutoImportConfigurationPresenter(new SapAutoImportConfigurationForm(),
                    ClientSession.GetUserContext().Site);
            sapAutoImportConfigurationPresenter.Run(this);
        }

        public void DisplayConfigureSiteCommunicationsForm()
        {
            var siteCommunicationsPresenter =
                new ConfigureSiteCommunicationsPresenter(new ConfigureSiteCommunicationsForm());
            siteCommunicationsPresenter.Run(this);
        }

        public void DisplayHoneywellPhdConfigurationForm()
        {
            var formPresenter =
                new ConfigureHoneywellPhdFormPresenter(new ConfigureHoneywellPhdForm());
            formPresenter.Run(this);
        }

        public void DisplayEnableSecurityForNewDirectivesForm()
        {
            var formPresenter = new EnableSecurityForNewDirectivesFormPresenter();
            formPresenter.Run(this);
        }

        public void DisplayConvertLogBasedDirectivesIntoNewDirectivesForm()
        {
            var formPresenter = new ConvertLogBasedDirectivesIntoNewDirectivesFormPresenter();
            formPresenter.Run(this);
        }

        //Sarika... Floc structure level changes...9Jan2017
         public void DisplayFlocLevelSettingsForm()
        {
            var flocLevelSettingForAdminPresenter =
                new FlocLevelSettingForAdminPresenter(new FlocLevelSettingForAdmin());
            flocLevelSettingForAdminPresenter.Run(this);
        }

        //olt admin list - mangesh
         public bool ConfigureOltCommunityEnabled
         {
             //set { configureOLTCommunityToolStripMenuItem.Enabled = value; }
             set { configureOLTCommunityToolStripMenuItem.Visible = value; }
         }

        //generic template - mangesh
        public void CreateGenericTemplateFormVisible(bool createEdmontonOdourNoiseFormAuthorized, bool createEdmontonDeviationFormAuthorized, bool createEdmontonRoadClosureFormAuthorized,
                                                    bool createEdmontonGN11GroundDistrubanceFormAuthorized, bool createEdmontonGN27FreezePlugFormAuthorized, bool createEdmontonHazardAssessmentFormAuthorized
                                        , bool createEdmontonNonEmergencyWaterSystemApprovalFormAuthorized)// TASK0593631 - mangesh
        {
            menuItemNewOdourNoise.Visible = createEdmontonOdourNoiseFormAuthorized;
            menuItemNewDeviation.Visible = createEdmontonDeviationFormAuthorized;
            menuItemNewRoadClosure.Visible = createEdmontonRoadClosureFormAuthorized;
            menuItemNewGN11GroundDistrubance.Visible = createEdmontonGN11GroundDistrubanceFormAuthorized;
            menuItemNewGN27FreezePlug.Visible = createEdmontonGN27FreezePlugFormAuthorized;
            menuItemNewHazardAssessment.Visible = createEdmontonHazardAssessmentFormAuthorized;
            menuItemNewNonEmergencyWaterSystemApproval.Visible = createEdmontonNonEmergencyWaterSystemApprovalFormAuthorized; //TASK0593631 - mangesh
        }


        //ayman Sarnia eip DMND0008992
        public void CreateEipIssueVisible(bool createEipIssueAuthorised)
        {
            menuItemNewSarniaGN75BForm.Visible = createEipIssueAuthorised;
            menuItemNewSarniaGN75BTemplate.Visible = createEipIssueAuthorised; //INC0398755 : added by Vibhor
        }

        //ayman sarnia - ayman selc - ayman forthills - ayman E&U
        public void CreateFormsVisible(bool createEdmontonFormsVisible,bool createSarniaFormsVisible, bool createSelcFormsVisible, bool createForthillsTrainingVisible, bool createOilsandsTrainingVisible,
            bool createEdmontonOvertimeFormsVisible, bool createLubesCsdAuthorized,
            bool createMontrealCsdAuthorized, bool createLubesAlarmDisableAuthorized,
            bool createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized, bool createFormDocumentSuggestionAuthorized,
            bool createFormProcedureDeviationAuthorized, bool createSiteWideTrainingVisible, bool createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized,   //ayman forthills questionnaire
            bool createETFTrainingFormAuthorized, //mangesh ETF
            bool createMudsTemporaryInstallationsAuthorized, //RITM0268131 - mangesh
            bool createFortHillOilSampleFormAuthorized, bool createFortHillDailyInspectionFormAuthorized,  //RITM0341710 -mangesh
            bool createGenericCsdAuthorized) 
        {

          
                menuItemNewGN75B.Visible = createEdmontonFormsVisible;
                menuItemNewOP14.Visible = createEdmontonFormsVisible;
                menuItemNewGN1.Visible = createEdmontonFormsVisible;
                menuItemNewGN6.Visible = createEdmontonFormsVisible;
                menuItemNewGN7.Visible = createEdmontonFormsVisible;
                menuItemNewGN24.Visible = createEdmontonFormsVisible;
                menuItemNewGN59.Visible = createEdmontonFormsVisible;
                menuItemNewGN75A.Visible = createEdmontonFormsVisible;
                menuItemNewFormOilsandsTraining.Visible = createOilsandsTrainingVisible;

                //ayman forthills
                menuItemNewFormForthillsTraining.Visible = createForthillsTrainingVisible;

                //ayman E&U
                menuItemNewFormSiteWideTraining.Visible = createSiteWideTrainingVisible;

                //mangesh ETF
                menuItemNewFormETFTraining.Visible = createETFTrainingFormAuthorized;

                menuItemNewFormOvertimeRequest.Visible = createEdmontonOvertimeFormsVisible;
                menuItemNewFormCriticalSystemDefeat.Visible = createLubesCsdAuthorized;
                menuItemNewMontrealFormCriticalSystemDefeat.Visible = createMontrealCsdAuthorized;
                menuItemNewFormAlarmDisable.Visible = createLubesAlarmDisableAuthorized;
                menuItemOilSandsSafeWorkPermitAuditQuestionnaire.Visible = createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized;

                // DMND0011225 CSD for WBR    
            menuItemNewGenericFormCriticalSystemDefeat.Visible = createGenericCsdAuthorized;

                menuItemForthillsSafeWorkPermitAuditQuestionnaire.Visible =
                createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized;   //ayman forthills questionnaire

                menuItemDocumentSuggestion.Visible = createFormDocumentSuggestionAuthorized;
                menuItemProcedureDeviation.Visible = createFormProcedureDeviationAuthorized;

                //ayman generic forms
            menuItemNewSarniaOP14.Visible = createSarniaFormsVisible;
            menuItemNewSarniaGN75BForm.Visible = createSarniaFormsVisible;        //ayman Sarnia eip DMND0008992

            //ayman selc
            menuItemNewSelcOP14.Visible = createSelcFormsVisible;

            //RITM0268131 - mangesh
            menuItemNewMudsTemporaryInstallation.Visible = createMudsTemporaryInstallationsAuthorized;

            //RITM0341710 -mangesh
            menuItemNewOilSample.Visible = createFortHillOilSampleFormAuthorized;
            menuItemNewDailyInspection.Visible = createFortHillDailyInspectionFormAuthorized;
          
            //ayman sarnia  -  ayman selc - ayman forthills - ayman E&U
            menuItemForm.Visible = createEdmontonFormsVisible || createSarniaFormsVisible|| createSelcFormsVisible ||createForthillsTrainingVisible || createOilsandsTrainingVisible ||
                                   createEdmontonOvertimeFormsVisible || createLubesCsdAuthorized ||
                                   createMontrealCsdAuthorized || createLubesAlarmDisableAuthorized ||
                                   createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized || createFormDocumentSuggestionAuthorized ||
                                   createFormProcedureDeviationAuthorized || createSiteWideTrainingVisible || createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized   //ayman forthills questionaire
                                   || createMudsTemporaryInstallationsAuthorized //RITM0268131 - mangesh
                                    || createFortHillOilSampleFormAuthorized || createFortHillDailyInspectionFormAuthorized //RITM0341710 -mangesh
                                    || createGenericCsdAuthorized;
        }

        private void HookUpEventHandlers()
        {
            navigationListView.SelectedSectionChanged += presenter.HandleSelectedSectionChanged;
            userStrip.LogOutClick += presenter.HandleLogOutButtonClick;

            userStrip.CreateActionItemClick += ((sender, e) => presenter.OnCreateActionItemItemClick());
            //userStrip.CreateReadingClick += ((sender, e) => presenter.OnCreateReadingItemClick());           //ayman action item reading
            userStrip.CreatePermitClick += ((sender, e) => presenter.OnCreatePermitClick());
            userStrip.CreateTargetClick += ((sender, e) => presenter.OnCreateTargetClick());
            userStrip.CreateRestrictionClick += ((sender, e) => presenter.OnCreateRestrictionClick());
            userStrip.CreateLabAlertClick += ((sender, e) => presenter.OnCreateLabAlertClick());
            userStrip.CreateLogClick += ((sender, e) => presenter.OnCreateLogClick());
            userStrip.CreateRepeatingLogClick += ((sender, e) => presenter.OnCreateRepeatingLogClick());
            userStrip.CreateShiftSummaryLogClick += ((sender, e) => presenter.OnCreateShiftSummaryLogClick());
            userStrip.CreateCokerCardClick += ((sender, e) => presenter.OnCreateCokerCardClick());
            userStrip.CreateShiftHandoverQuestionnaireClick +=
                ((sender, e) => presenter.OnCreateShiftHandoverQuestionnaireClick());
            userStrip.CreateDirectiveLogClick += ((sender, e) => presenter.OnCreateDailyDirectivesClick());
            userStrip.CreateDirectiveClick += ((sender, e) => presenter.OnCreateDirectiveClick());
            userStrip.CreateStandingOrderClick += ((sender, e) => presenter.OnCreateStandingOrderClick());
            userStrip.CreatePermitRequestClick += ((sender, e) => presenter.OnCreatePermitRequestClick());
            userStrip.CreateConfinedSpaceClick += ((sender, e) => presenter.OnCreateConfinedSpaceClick());
            userStrip.CreateFormGN7Click += ((sender, e) => presenter.OnCreateFormGN7Click());
            userStrip.CreateFormGN59Click += ((sender, e) => presenter.OnCreateFormGN59Click());
            userStrip.CreateFormOP14Click += ((sender, e) => presenter.OnCreateFormOP14Click());

            //generic template - mangesh
            userStrip.CreateFormOdourNoiseClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.OdourNoiseComplaint));
            userStrip.CreateFormDeviationClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.Deviation));
            userStrip.CreateFormRoadClosureClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.RoadClosure));
            userStrip.CreateFormGN11GroundDisturbanceClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.GN11GroundDisturbance));
            userStrip.CreateFormGN27FreezePlugClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.GN27FreezePlug));
            userStrip.CreateFormHazardAssessmentClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.HazardAssessment));

            //TASK0593631 - mangesh
            userStrip.CreateFormNonEmergencyWaterSystemApprovalClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.NonEmergencyWaterSystemApproval));

            //ayman generic forms
            userStrip.CreateFormSarniaOP14Click += ((sender, e) => presenter.OnCreateFormOP14Click());
            userStrip.CreateFormSarniaGN75BTemplateClick += ((sender, e) => presenter.OnCreateSarniaFormGN75BTemplateClick());       //ayman Sarnia eip DMND0008992
            userStrip.CreateFormSarniaGN75BFormClick += ((sender, e) => presenter.OnCreateSarniaFormGN75BFormClick());       //ayman Sarnia eip DMND0008992

            //ayman selc
            userStrip.CreateFormSelcOP14Click += ((sender, e) => presenter.OnCreateFormEdmontonPipelineCsdClick()); //presenter.OnCreateFormOP14Click());////DMND0010261-SELC CSD EdmontonPipeline

            userStrip.CreateFormLubesCsdClick += ((sender, e) => presenter.OnCreateFormLubesCsdClick());
            userStrip.CreateFormMontrealCsdClick += ((sender, e) => presenter.OnCreateFormMontrealCsdClick());
            userStrip.CreateFormLubesAlarmDisableClick +=
                ((sender, e) => presenter.OnCreateFormLubesAlarmDisableClick());
            userStrip.CreateFormGN24Click += ((sender, e) => presenter.OnCreateFormGN24Click());
            userStrip.CreateFormGN6Click += ((sender, e) => presenter.OnCreateFormGN6Click());
            userStrip.CreateFormGN75AClick += ((sender, e) => presenter.OnCreateFormGN75AClick());
            userStrip.CreateFormGN75BClick += ((sender, e) => presenter.OnCreateFormGN75BClick());
            userStrip.CreateFormGN1Click += ((sender, e) => presenter.OnCreateFormGN1Click());
            userStrip.CreateFormOilsandsTrainingClick += ((sender, e) => presenter.OnCreateFormOilsandsTrainingClick());

            //ayman Forthills
            userStrip.CreateFormForthillsTrainingClick += ((sender, e) => presenter.OnCreateFormForthillsTrainingClick());

            //ayman E&U
            userStrip.CreateFormSiteWideTrainingClick +=
                ((sender, e) => presenter.OnCreateFormSiteWideTrainingClick());

            //RITM0341710 - mangesh
            userStrip.CreateFormFortHillOilSampleClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.FortHillOilSample));
            userStrip.CreateFormFortHillDailyInspectionClick += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.FortHillDailyInspection));

            //mangesh ETF
            userStrip.CreateFormETFTrainingClick += ((sender, e) => presenter.OnCreateFormETFTrainingClick());

            userStrip.CreateFormOverTimeFormClick += ((sender, e) => presenter.OnCreateFormOvertimeRequestClick());

            userStrip.CreateFormOilSandsSafeWorkPermitAuditQuestionnaireClick +=
                ((sender, e) => presenter.OnCreateFormOilSandsSafeWorkPermitAuditQuestionnaireClick());

            //ayman Forthills Questionnaire
            userStrip.CreateFormForthillsSafeWorkPermitAuditQuestionnaireClick +=
                ((sender, e) => presenter.OnCreateFormForthillsSafeWorkPermitAuditQuestionnaireClick());

            userStrip.NewButtonClick += ((sender, e) => presenter.OnNewButtonClick());
            userStrip.ChangeActiveFLOCsButtonClick += presenter.HandleFunctionalLocationButtonClick;

            userStrip.ChangeSiteClick += presenter.HandleChangeSiteButtonClick; //RITM0386914 : OLT users to switch from one site to another - Added By Vibhor

            userStrip.ChangeActivePermitFLOCsButtonClick += presenter.HandleChangeActivePermitFLOCsButtonClick;
            userStrip.ChangeRestrictionFLOCsButtonClick += presenter.HandleChangeRestrictionFLOCsButtonClick;

            userStrip.CreateFormDocumentSuggestionClick +=
                ((sender, e) => presenter.OnCreateFormDocumentSuggestionClick());
            userStrip.CreateFormProcedureDeviationClick +=
                ((sender, e) => presenter.OnCreateFormProcedureDeviationClick());

            //RITM0268131 - mangesh
            userStrip.CreateFormMudsTemporaryInstallationClick += ((sender, e) => presenter.OnCreateFormMontrealSulphurClick());

            menuItemNewActionItem.Click += ((sender, e) => presenter.OnCreateActionItemItemClick());
           
            menuItemNewTarget.Click += ((sender, e) => presenter.OnCreateTargetClick());
            menuItemNewRestriction.Click += ((sender, e) => presenter.OnCreateRestrictionClick());
            menuItemNewLogEntry.Click += ((sender, e) => presenter.OnCreateLogClick());
            menuItemNewLogDefinitionEntry.Click += ((sender, e) => presenter.OnCreateRepeatingLogClick());
            menuItemNewShiftSummaryLogEntry.Click += ((sender, e) => presenter.OnCreateShiftSummaryLogClick());
            menuItemNewShiftHandoverQuestionnaire.Click +=
                ((sender, e) => presenter.OnCreateShiftHandoverQuestionnaireClick());
            menuItemCokerCardEntry.Click += ((sender, e) => presenter.OnCreateCokerCardClick());
            menuItemNewLabAlert.Click += ((sender, e) => presenter.OnCreateLabAlertClick());
            dailyDirectiveLogEntryToolStripMenuItem.Click += ((sender, e) => presenter.OnCreateDailyDirectivesClick());
            menuItemNewDirective.Click += (sender, e) => presenter.OnCreateDirectiveClick();
            menuItemNewStandingOrderEntry.Click += ((sender, e) => presenter.OnCreateStandingOrderClick());
            menuItemNewWorkPermit.Click += ((sender, e) => presenter.OnCreatePermitClick());
            permitRequestToolStripMenuItem.Click += ((sender, e) => presenter.OnCreatePermitRequestClick());
            confinedSpaceDocumentToolStripMenuItem.Click += ((sender, e) => presenter.OnCreateConfinedSpaceClick());
            menuItemNewGN7.Click += ((sender, e) => presenter.OnCreateFormGN7Click());
            menuItemNewGN59.Click += ((sender, e) => presenter.OnCreateFormGN59Click());
            menuItemNewOP14.Click += ((sender, e) => presenter.OnCreateFormOP14Click());
            menuItemNewGN24.Click += ((sender, e) => presenter.OnCreateFormGN24Click());
            menuItemNewGN6.Click += ((sender, e) => presenter.OnCreateFormGN6Click());
            menuItemNewGN75A.Click += ((sender, e) => presenter.OnCreateFormGN75AClick());
            menuItemNewGN75B.Click += ((sender, e) => presenter.OnCreateFormGN75BClick());
            menuItemNewSarniaGN75BTemplate.Click += ((sender, e) => presenter.OnCreateSarniaFormGN75BTemplateClick());   //ayman Sarnia eip DMND0008992
            menuItemNewSarniaGN75BForm.Click += ((sender, e) => presenter.OnCreateSarniaFormGN75BFormClick());   //ayman Sarnia eip DMND0008992
            menuItemNewGN1.Click += ((sender, e) => presenter.OnCreateFormGN1Click());
            menuItemNewFormOilsandsTraining.Click += ((sender, e) => presenter.OnCreateFormOilsandsTrainingClick());

            //generic template - mangesh
            menuItemNewOdourNoise.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.OdourNoiseComplaint));
            menuItemNewDeviation.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.Deviation));
            menuItemNewRoadClosure.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.RoadClosure));
            menuItemNewGN11GroundDistrubance.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.GN11GroundDisturbance));
            menuItemNewGN27FreezePlug.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.GN27FreezePlug));
            menuItemNewHazardAssessment.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.HazardAssessment));

            //TASK0593631 - mangesh
            menuItemNewNonEmergencyWaterSystemApproval.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.NonEmergencyWaterSystemApproval));

            //ayman forthills
            menuItemNewFormForthillsTraining.Click += ((sender, e) => presenter.OnCreateFormForthillsTrainingClick());

            //ayman E&U
            menuItemNewFormSiteWideTraining.Click += ((sender, e) => presenter.OnCreateFormSiteWideTrainingClick());

            //mangesh ETF
            menuItemNewFormETFTraining.Click += ((sender, e) => presenter.OnCreateFormETFTrainingClick());

            menuItemNewFormOvertimeRequest.Click += (sender, args) => presenter.OnCreateFormOvertimeRequestClick();
            menuItemNewFormCriticalSystemDefeat.Click +=
                (sender, args) => presenter.OnCreateFormCriticalSystemDefeatClick();
            menuItemNewMontrealFormCriticalSystemDefeat.Click +=
                (sender, args) => presenter.OnCreateFormMontrealCsdClick();
            menuItemNewFormAlarmDisable.Click += (sender, args) => presenter.OnCreateFormLubesAlarmDisableClick();
            
            menuItemOilSandsSafeWorkPermitAuditQuestionnaire.Click +=
                (sender, args) => presenter.OnCreateFormOilSandsSafeWorkPermitAuditQuestionnaireClick();

            //ayman Forthills Questionnaire
            menuItemForthillsSafeWorkPermitAuditQuestionnaire.Click +=
                (sender, args) => presenter.OnCreateFormForthillsSafeWorkPermitAuditQuestionnaireClick();

            //RITM0268131 - mangesh
            menuItemNewMudsTemporaryInstallation.Click +=
               (sender, args) => presenter.OnCreateFormMontrealSulphurClick();

            //RITM0341710 - mangesh
            menuItemNewOilSample.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.FortHillOilSample));
            menuItemNewDailyInspection.Click += ((sender, e) => presenter.OnCreateFormGenericTemplateClick(EdmontonFormType.FortHillDailyInspection));

            // DMND0011225 CSD for WBR
            menuItemNewGenericFormCriticalSystemDefeat.Click += ((sender, e) => presenter.OnCreateGenericCSDItemItemClick());
            userStrip.CreateGenericCSDItemClick += ((sender, e) => presenter.OnCreateGenericCSDItemItemClick());

            menuItemNewSelcOP14.Click +=
               (sender, args) => presenter.OnCreateFormEdmontonPipelineCsdClick();//DMND0010261-SELC CSD EdmontonPipeline


            menuItemDocumentSuggestion.Click +=
                ((sender, e) => presenter.OnCreateFormDocumentSuggestionClick());
            menuItemProcedureDeviation.Click +=
                ((sender, e) => presenter.OnCreateFormProcedureDeviationClick());

            menuItemLogOut.Click += presenter.HandleLogOutButtonClick;
            menuItemChangeActiveFLOC.Click += presenter.HandleFunctionalLocationButtonClick;
            menuItemPreferences.Click += presenter.HandlePreferencesClick;
            oltApplicationHelpToolStripMenuItem.Click += presenter.HandleHelpMenuItemClick;
            releaseNotesToolStripMenuItem.Click += presenter.HandleReleaseNotesMenuItemClick;

            menuItemDailyShiftLogReport.Click += OnDailyShiftLogReportMenuItemClick;
            menuItemDailyShiftAlertReport.Click += OnDailyShiftAlertReportMenuItem_Click;

            

            menuItemOperatingEngineerShiftLogReport.Click += OnOperatingEngineerShiftLogReportMenuItemClick;
            menuItemShiftGapReasonReport.Click += OnShiftGapReasonReportMenuItemClick;
            menuItemRestrictionReport.Click += presenter.RestrictionReportMenuItem_Click;
            menuItemMarkedAsReadLogReport.Click += presenter.MarkedAsReadLogReportMenuItem_Click;
            menuItemMarkedAsReadShiftHandoverReport.Click += presenter.MarkedAsReadShiftHandoverReportMenuItem_Click;
            markedAsNotReadReportToolStripMenuItem.Click += presenter.MarkedAsNotReadShiftHandoverReportMenuItem_Click;
            readingReportToolStripMenuItem.Click += onReadingReportMenuItemClick;
            menuItemMarkedAsReadDirectiveReport.Click += presenter.MarkedAsReadDirectiveReportMenuItem_Click;
            menuItemShiftHandoverReport.Click += OnShiftHandoverReportMenuItemClick;
            menuItemDetailedLogReport.Click += DetailedLogReportMenuItem_Click;
            menuItemCokerCardReport.Click += presenter.CokerCardReportMenuItem_Click;
            menuItemTargetAlertExcelReport.Click += presenter.TargetAlertExcelReportMenuItem_Click;
            safeWorkPermitAssessmentsReportToolStripMenuItem.Click += presenter.SafeWorkPermitAssessmentExcelReportMenuItem_Click;
            menuItemCustomFieldTrendReport.Click += presenter.CustomFieldTrendReportMenuItem_Click;
            menuItemTrainingFormExcelReport.Click += presenter.FormOilsandsTrainingExcelReportMenuItem_Click;
            menuItemTrainingFormReport.Click += presenter.FormOilsandsTrainingFormReportMenuItem_Click;
            menuItemOnPremisePersonnelReportToolStripMenuItem.Click +=
                MenuItemOnPremisePersonnelReportToolStripMenuItemOnClick;
            menuItemPrintBlankWorkPermit.Click += presenter.PrintBlankWorkPermit_Click;


            configureRestrictionReportingLimitsToolStripMenuItem.Click +=
                presenter.HandleConfigureRestrictionReportingLimitsToolStripMenuItem_Click;
            configureRestrictionListsToolStripMenuItem.Click +=
                presenter.HandleConfigureRestrictionListsMenuItem_Click;
            editReasonCodesToolStripMenuItem.Click += presenter.HandleEditRestrictionReasonCodesToolStripMenuItemClick;

            shiftHandoverConfigurationToolStripMenuItem.Click += presenter.HandleShiftHandoverConfigurationMenuItemClick;
            shiftHandoverEmailConfigurationToolStripMenuItem.Click +=
                presenter.HandleShiftHandoverEmailConfigurationMenuItemClick;

            configureSafeWorkPermitAuditQuestionnaireToolStripMenuItem.Click +=
                presenter.HandleQuestionnaireConfigurationMenuItemClick;

            cokerCardConfigurationToolStripMenuItem.Click += presenter.HandleCokerCardConfigurationMenuItemClick;

            manageOperationalModeForUnitsToolStripMenuItem.Click +=
                presenter.HandleManageOpModeForUnitsToolStripMenuClick;
            functionalLocationsToolStripMenuItem.Click += presenter.HandleConfigureFunctionalLocationMenuItemClick;
            configureGasTestLimitsToolStrip.Click += presenter.HandleConfigGasTestElementInfoItemClick;

            configureDisplayLimitsToolStripMenuItem.Click += presenter.HandleSiteConfigurationToolStripMenuClick;
            configureDefaultTabsToolStripMenuItem.Click += presenter.HandleConfigureDefaultTabsToolStripMenuClick;
            configureWorkAssignmentNotSelectedWarningToolStripMenuItem.Click +=
                presenter.HandleConfigureWorkAssignmentNotSelectedWarningToolStripMenuClick;

            labAlertConfigurationToolStripMenuItem.Click += presenter.HandleLabAlertConfigurationToolStripMenuClick;

            configureWorkPermitArchivalProcessToolStripMenuItem.Click +=
                presenter.HandleConfigureWorkPermitArchivalProcessMenuItemClick;
            configureActionItemSettingsStripMenuItem.Click += presenter.HandleConfigActionItemSettingsClick;
            configureWorkPermitContractorToolStripMenuItem.Click += presenter.HandleConfigureWorkPermitContractorClick;
            configureDefaultFLOCsForDailyAssignmentToolStripMenuItem.Click +=
                presenter.HandleConfigureDefaultFLOCsForDailyAssignmentToolStripMenuItemClicked;
            associateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItem.Click +=
                presenter.HandleAssociateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItemClicked;
            restrictionFlocsToolStripMenuItem.Click +=
                presenter.HandleAssociateFlocsForRestrictionsMenuItemClicked;
            associateWorkAssignmentsForPermitsToolStripMenuItem.Click +=
                presenter.HandleAssociateWorkAssignmentsForPermitsToolStripMenuItemClicked;
            configurePlantHistorianTagListToolStripMenuItem.Click +=
                presenter.HandleConfigurePlantHistorianTagListMenuItemClicked;
            configureWorkCentersToolStripMenuItem.Click += presenter.HandleConfigureWorkCentersClick;
            configureAssignmentsToolStripMenuItem.Click += presenter.HandleConfigureAssignmentMenuItemClick;
            configureActionItemReApprovalToolStripMenuItem.Click += presenter.HandleConfigureAutoReApprovalByFieldClick;
            configureTargetsReApprovalToolStripMenuItem.Click += presenter.HandleConfigureAutoReApprovalByFieldClick;
            configureFormTemplatesToolStripMenuItem.Click += presenter.HandleConfigureFormTemplatesClick;
            configureTrainingBlocksToolStripMenuItem.Click += presenter.HandleConfigureTrainingBlocksClick;
            visibilityGroupsToolStripMenuItem.Click += presenter.HandleVisibilityGroupsClick;
            configureWorkPermitGroupsMenuItem.Click += presenter.HandleConfigureWorkPermitGroupsClick;

            configureRoadAccessOnPermitToolStripMenuItem.Click += presenter.HandleConfigureRoadAccessOnPermitClick;//mangesh for RoadAccessOnPermit 
            configureSpecialWorkToolStripMenuItem.Click += presenter.HandleConfigureSpecialWorkClick;//mangesh for SpecialWork 
            configureGenericTemplateApprovalToolStripMenuItem.Click += presenter.HandleConfigureGenericTemplateApprovalTemplatesClick; // mangesh - generic template approval
            configureGenericTemplateEmailApprovalToolStripMenuItem.Click += presenter.HandleConfigureGenericTemplateApprovalEmailTemplatesClick;
            //mangesh - cop member list--
            oltAdministratorListToolStripMenuItem.Click += presenter.HandleViewAdministratorListClick;  
            configureOLTCommunityToolStripMenuItem.Click += presenter.HandleConfigureAdministratorListClick;
            //-----------------

            configureBusinessCategoriesToolStripMenuItem.Click +=
                presenter.HandleConfigureConfigureBusinessCategoriesToolStripMenuItem;
            flocBusinessCategoryAssignmentToolStripMenuItem.Click += presenter.HandleFlocBusinessCategoryAssignmentClick;

            logGuidelineConfigurationToolStripMenuItem.Click += presenter.HandleLogGuidelineConfigurationMenuItemClick;
            logTemplatesToolStripMenuItem.Click += presenter.HandleLogTemplatesMenuItemClick;
            customFieldsToolStripMenuItem.Click += presenter.HandleCustomFieldsMenuItemClick;
            configureCutoffTimeForEditingDORCommentsToolStripMenuItem.Click +=
                presenter.HandleConfigureDORCutoffTimeMenuItemClick;
            linkPathsToolStripMenuItem.Click += presenter.HandleLinkPathsMenuItemClick;
            siteCommunicationsToolStripMenuItem.Click += presenter.HandleSiteCommunicationsMenuItemClick;
            menuItemFileExit.Click += presenter.HandleExitMenuItemClick;
                    //Sarika... Floc structure level changes...9Jan2017
            MainForm_FlocLevelSettings.Click += presenter.HandleFlocLevelSettingsMenuItemClick;

            roleMatrixToolStripMenuItem.Click += MainFormPresenter.RoleMatrixToolStripMenuItem_Click;
            openLogFileToolStripMenuItem.Click += MainFormPresenter.OpenLogFileToolStripMenuItem_Click;
            emailLogFileToolStripMenuItem.Click += MainFormPresenter.EmailLogFileToolStripMenuItem_Click;

            priorityDisplayCriteriaToolStripMenuItem.Click += presenter.HandlePriorityDisplayCriteriaMenuItemClick;

            configureWorkPermitMontrealTemplatesToolStripMenuItem.Click +=
                presenter.HandleConfigureWorkPermitMontrealTemplatesMenuItemClick;
            configureWorkPermitMontrealDropdownsToolStripMenuItem.Click +=
                presenter.HandleConfigureWorkPermitMontrealDropdownsMenuItemClick;
            configureConfiguredDocumentLinksToolStripMenuItem.Click +=
                presenter.HandleConfigureConfiguredDocumentLinksMenuItemClick;

            configureRoleMatrixToolStripMenuItem.Click += presenter.HandleConfigureRoleMatrixMenuItemClick;
            configureRolePermissionsToolStripMenuItem.Click += presenter.HandleConfigureRolePermissionsMenuItemClick;
            technicalSiteConfigurationToolStripMenuItem.Click += presenter.HandleSiteConfigurationMenuItemClick;
            sapAutoImportToolStripMenuItem.Click += presenter.HandleSapAutoImportConfigurationToolStripMenuItemClick;
            honeywellPHDToolStripMenuItem.Click += presenter.HandleHoneywellPhdConfigureMenuItemClick;
            analyticsExcelExportToolStripMenuItem.Click += presenter.HandleAnalyticsExcelExportMenuItemClick;

            enableSecurityForNewDirectivesToolStripMenuItem.Click +=
                presenter.HandleEnableSecurityForNewDirectivesMenuItemClicked;
            convertLogBasedDirectivesIntoNewDirectivesToolStripMenuItem.Click +=
                presenter.HandleConvertLogBasedDirectivesIntoNewDirectivesMenuItemClicked;

            areaLabelsToolStripMenuItem.Click += presenter.HandleConfigureAreaLabelsMenuItemClick;

            configureFormDropdownsToolStripMenuItem.Click += presenter.HandleConfigureFormDropdownsMenuItemClick;
            
            Load += presenter.MainForm_Load;

            //RITM by mukesh
            configureRoleToolStripMenuItem.Click += presenter.HandleConfigureRoleMenuItemClick;
            /*RITM0265746 - Sarnia CSD marked as read end Report Part */
            menuItemFormOP14MarkAsReadReport.Click += OnFormOP14MarkAsReadReportMenuItemClick;

            
        }

        //ayman action item reading
        private void HandleGetDefinitions(object sender, EventArgs e)
        {
            if (GetDefinitionsButtonClicked != null)
            {
                GetDefinitionsButtonClicked();
            }
        }


        private void OnDailyShiftAlertReportMenuItem_Click(object sender, EventArgs e)
        {
            presenter.OnDailyShiftAlertReportMenuItemClick();
        }

        private void OnShiftGapReasonReportMenuItemClick(object sender, EventArgs e)
        {
            presenter.OnShiftGapReasonReportMenuItemClick();
        }

        private void OnDailyShiftLogReportMenuItemClick(object sender, EventArgs e)
        {
            presenter.OnDailyShiftLogReportMenuItemClick();
        }

        private void OnShiftHandoverReportMenuItemClick(object sender, EventArgs e)
        {
            presenter.ShiftHandoverReportMenuItem_Click();
        }

        private void OnOperatingEngineerShiftLogReportMenuItemClick(object sender, EventArgs e)
        {
            presenter.OnOperatingEngineerShiftLogReportMenuItemClick();
        }

        private void DetailedLogReportMenuItem_Click(object sender, EventArgs e)
        {
            presenter.DetailedLogReportMenuItem_Click();
        }

        private void onReadingReportMenuItemClick(object sender, EventArgs e)
        {
            presenter.onReadingReportMenuItemClick();
        }

        private void MenuItemOnPremisePersonnelReportToolStripMenuItemOnClick(object sender, EventArgs eventArgs)
        {
            presenter.OnPremisePersonnelReportMenuItemClick();
        }

        private void MainForm_HelpRequested(object sender, HelpEventArgs helpEventArgs)
        {
            presenter.HelpRequested();
            helpEventArgs.Handled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = pageNamePrefix;

            AdminstrationVisible(false);
            TechnicalAdminstrationVisible(false);
           }

       ////Sarika... Floc structure level changes...9Jan2017

       // private void MainForm_FlocLevelSettings_Click(object sender, EventArgs e)
       // {
       //     presenter.OnFloclevelSettingsMenuItemClick(sender, e);
       // }

        /*RITM0265746 - Sarnia CSD marked as read end Report Part*/
        private void OnFormOP14MarkAsReadReportMenuItemClick(object sender, EventArgs e)
        {
            presenter.OnFormOP14MarkAsReadReportMenuItemClick();
        }

        public string CSDMarkAsReadReportForSarnia  //INC0458108 : added by Vibhor
        {
            get { return menuItemFormOP14MarkAsReadReport.Text; }
            set { menuItemFormOP14MarkAsReadReport.Text = value; }
        }

       
        DateTime _lastKeystroke = new DateTime(0);
        List<char> _barcode = new List<char>(10);

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // check timing (keystrokes within 100 ms)
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 50)
                _barcode.Clear();

            // record keystroke & timestamp
            _barcode.Add(e.KeyChar);
            _lastKeystroke = DateTime.Now;

            // process barcode
            if (e.KeyChar == 13 && _barcode.Count > 0)
            {
                string msg = new String(_barcode.ToArray());
                msg=msg.Replace("\r", "");
                if (msg=="")
                {
                    return;
                }
                showForm(msg);
               // MessageBox.Show(msg);
                _barcode.Clear();
            }
        }



        private void showForm(string txtSearchText)
        {
            if (!ClientSession.GetUserContext().IsSarniaSite)
            {
                int indexofFirst = txtSearchText.IndexOf("-");
                int indexoflast = txtSearchText.LastIndexOf("-");
                if (indexofFirst > 0 && indexoflast > 0 && indexofFirst != indexoflast)
                {
                    txtSearchText = txtSearchText.Substring(indexofFirst + 1, (txtSearchText.LastIndexOf("-") - (txtSearchText.IndexOf("-") + 1)));
                }
            }
            else if (ClientSession.GetUserContext().IsSarniaSite)
            {
                var cnt = txtSearchText.Split('-').Length - 1;
                if (cnt > 1)
                {
                    int indexofFirst = txtSearchText.IndexOf("-");
                    int indexoflast = txtSearchText.LastIndexOf("-");
                    if (indexofFirst >= 0 && indexoflast > 0 && indexofFirst != indexoflast)
                    {
                        txtSearchText = txtSearchText.Substring(indexofFirst + 1, (txtSearchText.LastIndexOf("-") - (txtSearchText.IndexOf("-") + 1)));

                    }
                }


            }

               if (ClientSession.GetUserContext().IsEdmontonSite)
                {
                    ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                    int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(txtSearchText);
                    if (WOrkPermitId > 0)
                    {
                        var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                        Com.Suncor.Olt.Common.Services.IWorkPermitEdmontonService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitEdmontonService>(); ;
                        var presenter = new Com.Suncor.Olt.Client.Presenters.Page.PriorityPageWorkPermitEdmontonDetailsPresenter(WOrkPermitId, true);
                        presenter.Run(this.ParentForm);
                    }

                    else
                    {
                        OltMessageBox.Show(StringResources.MessageErrorPermitnotExists, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (ClientSession.GetUserContext().IsMontrealSulphurSite)
                {
                    ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                    int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(txtSearchText);
                    if (WOrkPermitId > 0)
                    {
                        var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                        Com.Suncor.Olt.Common.Services.IWorkPermitMudsService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitMudsService>(); ;
                        var presenter = new Com.Suncor.Olt.Client.Presenters.Page.PriorityPageWorkPermitMudsDetailsPresenter(WOrkPermitId,true);
                        presenter.Run(this.ParentForm);

                    }
                    else
                    {
                        OltMessageBox.Show(StringResources.MessageErrorPermitnotExists, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
               else if (ClientSession.GetUserContext().IsMontrealSite)
               {
                   ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                   int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(txtSearchText);
                   if (WOrkPermitId > 0)
                   {
                       var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                       Com.Suncor.Olt.Common.Services.IWorkPermitMontrealService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitMontrealService>(); ;
                       var presenter = new Com.Suncor.Olt.Client.Presenters.Page.PriorityPageWorkPermitMontrealDetailsPresenter(WOrkPermitId, true);
                       presenter.Run(this.ParentForm);

                   }
                   else
                   {
                       OltMessageBox.Show(StringResources.MessageErrorPermitnotExists, MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }


               }
               else if (ClientSession.GetUserContext().IsSarniaSite || ClientSession.GetUserContext().IsDenverSite)
               {
                   ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                   int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(txtSearchText);
                   if (WOrkPermitId > 0)
                   {
                       var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                       Com.Suncor.Olt.Common.Services.IWorkPermitService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitService>(); ;
                       var presenter = new Com.Suncor.Olt.Client.Presenters.Page.SearchSarniaWorkpemitPresenter(WOrkPermitId, true);
                       presenter.Run(this.ParentForm);

                   }
                   else
                   {
                       OltMessageBox.Show(StringResources.MessageErrorPermitnotExists, MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }

               }
              

        }

    }
}