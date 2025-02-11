using System;
using System.Collections.Generic;
using System.Configuration;
using System.Deployment.Application;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Forms.Reporting;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Presenters.Reporting;
using Com.Suncor.Olt.Client.Presenters.Section;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;


namespace Com.Suncor.Olt.Client.Presenters
{
    /// <summary>
    ///     This is the presenter controller for the main form, it is responsible for handling
    ///     the page selection of the content panel as well as the user strip information and
    ///     switch button.
    /// </summary>
    //  TODO: Refactor this class. It's so huge, and has so many things in it now:
    // Event Handlers
    // Choosing/setting next form
    // Showing different forms for startup.  StartUp.  Maybe that should actually be another class where all the startup logic is?
    // Stuff to deal with tabs
    // Stuff to deal with Network issues
    // Security
    // Page locking
    public class MainFormPresenter
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainFormPresenter));
        private readonly IApplicationService applicationService;
        private readonly IAuthorized authorized;
        private readonly SpellCheckerDictionaryManager dictionaryManager;
        private readonly IFunctionalLocationService flocService;
        private readonly IMainForm form;
        private readonly IUserLoginHistoryService loginHistoryService;
        private readonly IObjectLockingService objectLockingService;
        private readonly IRemoteEventRepeater repeater;
        private readonly IRoleDisplayConfigurationService roleDisplayConfigurationService;
        private readonly IRoleElementService roleElementService;
        private readonly IRolePermissionService rolePermissionService;
        private readonly IRoleService roleService;
        private readonly ISectionRegistry sectionRegistry;
        private readonly IMainFormSecurityManager securityManager;
        private readonly IShiftHandoverService shiftHandoverService;
        private readonly IShiftPatternService shiftPatternService;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly UserContext userContext;
       

        public MainFormPresenter(IMainForm form)
            : this(
                form,
                new SectionRegistry(),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<IRoleElementService>(),
                ClientServiceRegistry.Instance.GetService<IRolePermissionService>(),
                ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>(),
                ClientServiceRegistry.Instance.GetService<IUserLoginHistoryService>(),
                ClientServiceRegistry.Instance.GetService<IShiftPatternService>(),
                ClientServiceRegistry.Instance.GetService<IApplicationService>(),
                ClientServiceRegistry.Instance.GetService<IRoleDisplayConfigurationService>(),
                ClientServiceRegistry.Instance.GetService<IRoleService>(),
                ClientServiceRegistry.Instance.GetService<IShiftHandoverService>(),
                ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>(),
                new MainFormSecurityManager(form, new Authorized()))
        {
            authorized = new Authorized();
            userContext = ClientSession.GetUserContext();
        }

        public MainFormPresenter(
            IMainForm form,
            ISectionRegistry sectionRegistry,
            IRemoteEventRepeater repeater,
            IObjectLockingService objectLockingService,
            IRoleElementService roleElementService,
            IRolePermissionService rolePermissionService,
            IFunctionalLocationService flocService,
            IUserLoginHistoryService loginHistoryService,
            IShiftPatternService shiftPatternService,
            IApplicationService applicationService,
            IRoleDisplayConfigurationService roleDisplayConfigurationService,
            IRoleService roleService,
            IShiftHandoverService shiftHandoverService,
            ISiteConfigurationService siteConfigurationService,
            IMainFormSecurityManager securityManager)
        {
            this.form = form;
            this.sectionRegistry = sectionRegistry;
            this.repeater = repeater;
            this.objectLockingService = objectLockingService;
            this.roleElementService = roleElementService;
            this.rolePermissionService = rolePermissionService;
            this.flocService = flocService;
            this.loginHistoryService = loginHistoryService;
            this.shiftPatternService = shiftPatternService;
            this.applicationService = applicationService;
            this.roleDisplayConfigurationService = roleDisplayConfigurationService;
            this.roleService = roleService;
            this.shiftHandoverService = shiftHandoverService;
            this.siteConfigurationService = siteConfigurationService;
            this.securityManager = securityManager;

            dictionaryManager = new SpellCheckerDictionaryManager();

            SetTheBuildNumberForTraining(form);
            SetPageNamePrefix();
        }

        private static void SetTheBuildNumberForTraining(IMainForm form)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            form.BuildVersion = String.Format("Build {0}.{1}.{2}", versionInfo.FileMajorPart, versionInfo.FileMinorPart,
                versionInfo.FileBuildPart);
        }

        private void SetPageNamePrefix()
        {
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            var productName = fileVersionInfo.ProductName;

            var buildEnvironment = applicationService.GetBuildConfiguration();

            if (productName.IsNullOrEmptyOrWhitespace())
            {
                productName = StringResources.ApplicationName;
            }

            form.SetPageNamePrefix(buildEnvironment.IsNullOrEmptyOrWhitespace()
                ? productName
                : String.Format("{0} ({1})", productName, buildEnvironment));
        }

        /// <summary>
        ///     Handle the logic of displaying different form sequence.  Here is the form sequence
        ///     state diagram.
        ///     [Program]          [Stop Watch]
        ///     |                   |
        ///     |                   |
        ///     Load Event       Force Log Off Event
        ///     |                   |
        ///     |                   |
        ///     +------------------------>[Log In Form]
        ///     <----------+
        ///         |                             |      |
        ///         |                             OK     |
        ///         |                             |      +--- Cancel--->
        ///         [Quit]
        ///         |                             |
        ///         |                     [Select FLOC Form]
        ///         <-------------------------+
        ///             OK                             |                                   |
        ///             | OK                                  |
        ///             |                             |                                   |
        ///             |                     [ Select Shift Form]                         |
        ///             |                             |                                   |
        ///             | OK OK
        ///             |                             |                                   |
        ///             |                  [ Continue Re/ loading Main Form]                |
        ///             |                          |       |                              |
        ///             |             +------------+       +----------+                   |
        ///             |             |                               |                   |
        ///             | Log Out Switch Active FLOC          |
        ///             | Button Click Event Button Click Event          |
        ///             |             |                               |                   |
        ///             +---------[ Switch User]              [ Switch Active FLOC]---------+
        ///             |                               |
        ///             |                               |
        ///             Cancel Cancel
        ///             |                               |
        ///             +------------>
        ///             [None]<-----------+
        /// </summary>
        /// <param name="nextForm">Form to be displayed upon closing current form</param>
        private void ShowNextForm(NextForm nextForm)
        {
            do
            {
                switch (nextForm)
                {
                    case NextForm.None:
                        return;
                    case NextForm.MainForm:
                        RefreshUserDataAndSecurity();
                        return;
                    case NextForm.SplashScreenForm:
                        nextForm = ShowSplashScreenForm();
                        break;
                    case NextForm.LogInForm:
                        nextForm = ShowLogInForm();
                        break;
                    case NextForm.SelectFLOCForm:
                        nextForm = ShowSelectAssignmentAndFLOCsOnLogInForm();
                        break;
                    case NextForm.SelectRoleForm:
                        nextForm = ShowSelectRoleForm();
                        break;
                    case NextForm.SelectShiftForm:
                        nextForm = ShowShiftSelector();
                        break;
                    case NextForm.SelectSiteForm:
                        nextForm = ShowSiteSelector();
                        break;
                    case NextForm.SwitchActiveFLOCForm:
                        nextForm = ShowSwitchActiveFunctionalLocationForm();
                        break;
                    case NextForm.SelectRoleFormForSwitchActiveFlocProcess:
                        nextForm = ShowSelectRoleFormForSwitchActiveFlocs();
                        break;
                    case NextForm.ExitForm:
                        Application.Exit();
                        return;
                    default:
                        throw new ApplicationException("Unhandled next form : " + nextForm);
                }
            } while (true);
        }

        public ISection GetSection(SectionKey key)
        {
            return sectionRegistry.GetSection(key);
        }

        /// <summary>
        ///     Reloads All the page within main form and refresh user tool strip
        ///     display data
        /// </summary>
        public void RefreshUserDataAndSecurity()
        {
            var ctx = ClientSession.GetUserContext();
            var clientSession = ClientSession.GetInstance();

            repeater.Connect(ctx.RootsForSelectedFunctionalLocations, ctx.RootFlocSetForWorkPermits.FunctionalLocations, ctx.RootFlocSetForRestrictions.FunctionalLocations,
                ctx.ReadableVisibilityGroupIds, EventConnectDisconnectReason.RefreshConnect);

            if (clientSession.UserIsInGracePeriod())
            {
                HandleCurrentShiftHasEnded(this, EventArgs.Empty);
            }
            if (clientSession.ShiftHandoverAlertCreated())
            {
                HandleShiftHandoverAlertEvent(this, EventArgs.Empty);//RITM0387753-Shift Handover creation alert(Aarti)
            }
            sectionRegistry.Clear();
            PopulateUserStripDataAndCheckSecurity();
        }


        private void PopulateUserStripDataAndCheckSecurity()
        {
            var userStrip = form.UserStrip;
            var userContext = ClientSession.GetUserContext();
            var user = userContext.User;
            var userRoleElements = userContext.UserRoleElements;
            var siteConfiguration = userContext.SiteConfiguration;
            var userShift = userContext.UserShift;
            if (user == null)
            {
                return;
            }
            userStrip.FullName = user.FullName;
            userStrip.Shift = userShift.ShiftPattern.DisplayName;
            userStrip.Site = userContext.Site.Name;
            userStrip.Role = userContext.Role.Name;
            userStrip.WorkAssignment = userContext.Assignment != null
                ? userContext.Assignment.Name
                : StringResources.NullWorkAssignment;

            //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
            if (ClientSession.GetUserContext().Site.Id == Site.Contruction_Mgnt_ID)
            {
                userStrip.SetShiftLogMenuItemName = StringResources.LogSectionNavigationTextForConstructionSite;
                userStrip.SetShiftSummaryLogMenuItemName = StringResources.SummaryLogTabTextForConstSite;
                SectionKey.LogSection.Name = StringResources.LogSectionNavigationTextForConstructionSite;
                
            }
            else
            {
                userStrip.SetShiftLogMenuItemName = StringResources.LogSectionNavigationText;
                SectionKey.LogSection.Name = StringResources.LogSectionNavigationText;
            }
            //END

            securityManager.ApplySecurityToMenuItems(userRoleElements, siteConfiguration);

            userStrip.ChangePermitFLOCButtonVisible = ClientSession.GetUserContext().HasFlocsForWorkPermits;
            userStrip.ChangeRestrictionFLOCButtonVisible = ClientSession.GetUserContext().HasFlocsForRestrictions;

            userStrip.ChangeSiteEnabled = ClientSession.GetUserContext().User.AvailableSites.Count > 1 ? true : false;  //RITM0386914 : OLT users to switch from one site to another - Added By Vibhor

            PopulateNavigationListView(siteConfiguration);


            //Mukesh for Permit search Demand
            userStrip.SetSearchvisible = ClientSession.GetUserContext().UserRoleElements.HasRoleElement(RoleElement.VIEW_PERMIT) && (ClientSession.GetUserContext().IsSarniaSite || ClientSession.GetUserContext().IsEdmontonSite || ClientSession.GetUserContext().IsDenverSite || ClientSession.GetUserContext().IsMontrealSulphurSite || ClientSession.GetUserContext().IsMontrealSite);
            if (ClientSession.GetUserContext().UserRoleElements.HasRoleElement(RoleElement.VIEW_PERMIT) && (ClientSession.GetUserContext().IsSarniaSite || ClientSession.GetUserContext().IsEdmontonSite || ClientSession.GetUserContext().IsDenverSite || ClientSession.GetUserContext().IsMontrealSulphurSite || ClientSession.GetUserContext().IsMontrealSite))
            {
                
                AutoCompleteStringCollection allowedStatorTypes = new AutoCompleteStringCollection();
                ScanPdfFormPresenter presenter = new ScanPdfFormPresenter();
                List<string> lst = presenter.GetAutoSearchWorkpermit();

                foreach (string item in lst)
                {
                    if (item != "")
                        allowedStatorTypes.Add(item);
                }
                userStrip.AutoSearchPermitNumber = allowedStatorTypes;
            }

            
        }

        private void PopulateNavigationListView(SiteConfiguration siteConfiguration)
        {
            var originallySelectedSection = form.SelectedSection;

            form.ClearNavigation();
            form.AddNavigation(SectionKey.PrioritiesSection);

            securityManager.AddNavigationSections(siteConfiguration, ClientSession.GetUserContext().UserRoleElements);

            form.NavigateTo(originallySelectedSection);
        }

        private void LaunchLockedPage(LaunchForm launchFormDelegate, string lockIdentifier)
        {
            var clientSession = ClientSession.GetInstance();
            var userId = ClientSession.GetUserContext().User.IdValue;
            var lockResult = objectLockingService.GetLock(lockIdentifier, userId, clientSession.GuidAsString);
            if (lockResult.Succeeded)
            {
                try
                {
                    launchFormDelegate();
                }
                finally
                {
                    objectLockingService.ReleaseLock(lockIdentifier, userId);
                }
            }
            else
            {
                form.LaunchLockDeniedMessage(LockDeniedMessage(lockResult), StringResources.ScreenLockedMessageBoxTitle);
            }
        }

        private static string LockDeniedMessage(ObjectLockResult lockResult)
        {
            return String.Format(StringResources.ScreenLockedMessage, lockResult.LockedByUserName);
        }

        public void HandleConfigureFunctionalLocationMenuItemClick(object sender, EventArgs e)
        {
            var lockIdentifier = ConfigureFunctionalLocationsForm.CreateObjectLockKey();
            LaunchLockedPage(form.DisplayConfigureFunctionalLocationsForm, lockIdentifier);
        }

        public void HandleManageOpModeForUnitsToolStripMenuClick(object sender, EventArgs e)
        {
            var lockIdentifier = ManageOpModeForUnitLevelFLOCForm.CreateObjectLockKey();
            LaunchLockedPage(form.DisplayManageOperationalModeForUnitsForm, lockIdentifier);
        }

        public void HandleConfigGasTestElementInfoItemClick(object sender, EventArgs arg)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = ConfigGasTestElementInfoFormPresenter.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayConfigureGasTestElementInfoForm, lockIdentifier);
        }

        public void HandlePreferencesClick(object sender, EventArgs e)
        {
            var preferencesForm = new PreferencesForm();
            preferencesForm.ShowDialog(form);
            preferencesForm.Dispose();
        }

        public void HandleSiteConfigurationToolStripMenuClick(object sender, EventArgs e)
        {
            form.DisplayConfigureSiteForm();
        }

        public void HandleConfigureDefaultTabsToolStripMenuClick(object sender, EventArgs e)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = ConfigureDefaultTabsForm.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayConfigureDefaultTabsForm, lockIdentifier);
        }
        //Sarika... Floc structure level changes...9Jan2017
        public void HandleFlocLevelSettingsMenuItemClick(object sender, EventArgs e)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = FlocLevelSettingForAdminPresenter.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayFlocLevelSettingsForm, lockIdentifier);
        }
        public void HandleConfigureWorkAssignmentNotSelectedWarningToolStripMenuClick(object sender, EventArgs e)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = ConfigureWorkAssignmentNotSelectedWarningForm.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayConfigureWorkAssignmentNotSelectedWarningForm, lockIdentifier);
        }

        public void HandleLabAlertConfigurationToolStripMenuClick(object sender, EventArgs e)
        {
            form.DisplayLabAlertConfigurationForm();
        }

        public void HandleConfigureRestrictionReportingLimitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.DisplayConfigureRestrictionReportingLimitsForm();
        }

        public void HandleShiftHandoverConfigurationMenuItemClick(object sender, EventArgs e)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = ShiftHandoverConfigurationPresenter.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayShiftHandoverConfigurationForm, lockIdentifier);
        }

        public void HandleQuestionnaireConfigurationMenuItemClick(object sender, EventArgs e)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = QuestionnaireConfigurationPresenter.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayQuestionnaireConfigurationForm, lockIdentifier);
        }

        public void HandleShiftHandoverEmailConfigurationMenuItemClick(object sender, EventArgs e)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = ShiftHandoverEmailConfigurationPresenter.CreateLockIdentifier(site);
            var presenter = new ShiftHandoverEmailConfigurationPresenter();
            LaunchLockedPage(() => presenter.Run(form), lockIdentifier);
        }

        public void HandleCokerCardConfigurationMenuItemClick(object sender, EventArgs e)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = CokerCardConfigurationPresenter.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayCokerCardConfigurationForm, lockIdentifier);
        }

        public void HandleConfigureRestrictionListsMenuItem_Click(object sender, EventArgs e)
        {
            var lockIdentifier = RestrictionLocationListConfigurationFormPresenter.CreateLockIdentifier();
            LaunchLockedPage(() => form.DisplayRestrictionLocationListConfigurationForm(), lockIdentifier);
        }

        public void HandleEditRestrictionReasonCodesToolStripMenuItemClick(object sender, EventArgs e)
        {
            var lockIdentifier = EditRestrictionReasonCodesPresenter.CreateLockIdentifier();
            LaunchLockedPage(() => form.DisplayEditRestrictionReasonCodesForm(), lockIdentifier);
        }

        public void HandleConfigureWorkPermitArchivalProcessMenuItemClick(object sender, EventArgs args)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockIdentifier = ConfigureWorkPermitArchivalProcessFormPresenter.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayConfigureWorkPermitArchivalProcessForm, lockIdentifier);
        }

        public void HandleConfigActionItemSettingsClick(object sender, EventArgs args)
        {
            var site = ClientSession.GetUserContext().Site;
            var lockItdentifier = ConfigureActionItemsFormPresenter.CreateLockIdentifier(site);
            LaunchLockedPage(form.DisplayConfigureActionItemsForm, lockItdentifier);
        }

        public void HandleConfigureWorkPermitContractorClick(object sender, EventArgs args)
        {
            LaunchLockedPage(form.DisplayConfigureWorkPermitContractorForm,
                ConfigureSiteContractorPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigurePlantHistorianTagListMenuItemClicked(object sender, EventArgs args)
        {
            LaunchLockedPage(form.DisplayConfigurePlantHistorianTagListForm,
                ConfigurePHTagInfoGroupsForReportFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureDefaultFLOCsForDailyAssignmentToolStripMenuItemClicked(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayConfigureDefaultFlocsForDailyAssignnmentForm,
                ConfigureDefaultFlocsForDailyAssignnmentPresenter.CreateLockIdentifier(
                    ClientSession.GetUserContext().Site));
        }

        public void HandleAssociateWorkAssignmentsToFLOCsForPermitAutoAssignmentToolStripMenuItemClicked(object sender,
            EventArgs e)
        {
            LaunchLockedPage(form.DisplayWorkPermitAutoAssignmentConfigurationForm,
                WorkPermitAutoAssignmentConfigurationPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleAssociateWorkAssignmentsForPermitsToolStripMenuItemClicked(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayWorkPermitAssignmentConfigurationForm,
                WorkPermitAssignmentConfigurationPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleAssociateFlocsForRestrictionsMenuItemClicked(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayRestrictionsFlocsConfigurationForm,
                RestrictionFlocsPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureWorkCentersClick(object sender, EventArgs args)
        {
            LaunchLockedPage(form.DisplayConfigureCraftOrTradeForm,
                ConfigureCraftOrTradePresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureRoadAccessOnPermitClick(object sender, EventArgs args)
        {
            LaunchLockedPage(form.DisplayConfigureRoadAccessOnPermitForm,
                ConfigureRoadAccessOnPermitPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureSpecialWorkClick(object sender, EventArgs args)
        {
            LaunchLockedPage(form.DisplayConfigureSpecialWorkForm,
                ConfigureSpecialWorkPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureAssignmentMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayAssignmentConfigurationForm,
                AssignmentConfigurationPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleLogGuidelineConfigurationMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayLogGuidelinesConfigurationForm,
                LogGuidelineConfigurationSelectionFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleLogTemplatesMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayLogTemplatesConfigurationForm,
                LogTemplateConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleCustomFieldsMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayCustomFieldConfigurationForm,
                CustomFieldGroupConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureDORCutoffTimeMenuItemClick(object sender, EventArgs e)
        {
            form.DisplayConfigureDORCutoffTimeForm();
        }

        public void HandleConfigureAutoReApprovalByFieldClick(object sender, EventArgs args)
        {
            LaunchLockedPage(form.DisplayFieldAutoReApprovalConfigurationForm,
                FieldAutoReApprovalConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureConfigureBusinessCategoriesToolStripMenuItem(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayBusinessCategoriesForm,
                BusinessCategoryPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleFlocBusinessCategoryAssignmentClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayBusinessCategoryFLOCAssociationForm,
                BusinessCategoryFLOCAssociationPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void OnDailyShiftLogReportMenuItemClick()
        {
            var page = new DevExpressDailyShiftLogReportPresenter().Page;
            LoadReportPage(page);
        }

        public void OnPremisePersonnelReportMenuItemClick()
        {
            var page = new OnPremisePersonnelShiftReportPresenter().Page;
            LoadReportPage(page);
        }

        public void OnDailyShiftAlertReportMenuItemClick()
        {
            var page = new DevExpressDailyShiftTargetAlertReportPresenter().Page;
            LoadReportPage(page);
        }

        public void OnOperatingEngineerShiftLogReportMenuItemClick()
        {
            var page = new DevExpressDailyShiftOperatingEngineerLogReportPresenter().Page;
            LoadReportPage(page);
        }

        public void OnShiftGapReasonReportMenuItemClick()
        {
            var page = new DevExpressDailyShiftTargetAlertGapReasonReportPresenter().Page;
            LoadReportPage(page);
        }

        //ayman action item reading
        public void onReadingReportMenuItemClick()
        {
           // var page = new ReadingReportPresenter().Page;
           // LoadReportPage(page);
            var presenter = new ActionItemReadingReportFormPresenter();
            presenter.Run(form);
        }

        public void ShiftHandoverReportMenuItem_Click()
        {
            LoadReportPage(new ShiftHandoverReportPresenter().Page);
        }


        public void DetailedLogReportMenuItem_Click()
        {
            var page = new DevExpressDetailedLogReportPresenter().Page;
            LoadReportPage(page);
        }

        public void HandleConfigureWorkPermitMontrealTemplatesMenuItemClick(object sender, EventArgs e)
        {
            ////RITM0301321 mangesh 
            if (ClientSession.GetUserContext().Site.IdValue == Site.MontrealSulphur_ID)
            {
                LaunchLockedPage(form.DisplayWorkPermitMudsTemplatesConfigurationForm,
                WorkPermitMudsTemplateConfigurationFormPresenter.CreateLockIdentifier(
                    ClientSession.GetUserContext().Site));
            }
            else
            {
                LaunchLockedPage(form.DisplayWorkPermitMontrealTemplatesConfigurationForm,
                WorkPermitMontrealTemplateConfigurationFormPresenter.CreateLockIdentifier(
                    ClientSession.GetUserContext().Site));
            }
           
            //LaunchLockedPage(form.DisplayWorkPermitMontrealTemplatesConfigurationForm,
            //    WorkPermitMontrealTemplateConfigurationFormPresenter.CreateLockIdentifier(
            //        ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureWorkPermitMontrealDropdownsMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayWorkPermitMontrealDropdownsConfigurationForm,
                WorkPermitDropdownsConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureConfiguredDocumentLinksMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayConfiguredDocumentLinkConfigurationForm,
                ConfiguredDocumentLinkConfigurationFormPresenter.CreateLockIdentifier(
                    ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureFormTemplatesClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayFormTemplateConfigurationForm,
                FormTemplateConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        //generic template - mangesh
        public void HandleConfigureGenericTemplateApprovalTemplatesClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayGenericTemplateApprovalConfigurationForm,
                ConfigureGenericTemplateApprovalPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }
        //Added by ppanigrahi
        public void HandleConfigureGenericTemplateApprovalEmailTemplatesClick(object sender, EventArgs e)
        {
                 LaunchLockedPage(form.DisplayGenericTemplateEmailApprovalConfigurationForm,
                GenericTemplateEmailApprovalPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }
        //mangesh - cop member list
        public void HandleViewAdministratorListClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayAdministratorListForm,
                FormTemplateConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }
        public void HandleConfigureAdministratorListClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayAdministratorListConfigurationForm,
             FormTemplateConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }
        //------------
        public void HandleConfigureFormDropdownsMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayFormDropdownsConfigurationForm,
                FormDropdownsConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureTrainingBlocksClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayTrainingBlockConfigurationForm,
                TrainingBlockConfigurationFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        private void LoadReportPage(IReportsPage page)
        {
            if (page != null)
            {
                form.UnSelectPageInNavigationList();
                form.LoadControlIntoMainContentPanel((Control)page);
                form.Title = page.Title;
            }
        }

        public void OnCreateDailyDirectivesClick()
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService,
                ClientSession.GetUserContext().SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            var newForm = new DirectiveLogForm();
            newForm.ShowDialog(form as Form);
            newForm.Dispose();
        }

        public void OnCreateStandingOrderClick()
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService,
                ClientSession.GetUserContext().SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            var newForm = LogDefinitionForm.CreateForStandingOrder();
            newForm.ShowDialog(form as Form);
            newForm.Dispose();
        }

        public void OnCreateCokerCardClick()
        {
            new CokerCardFormLauncher(form).AttemptLaunch();
        }

        public void RestrictionReportMenuItem_Click(object sender, EventArgs e)
        {
            var reportFormPresenter = new RestrictionReportFormPresenter();
            reportFormPresenter.Run(form);
        }

        public void TargetAlertExcelReportMenuItem_Click(object sender, EventArgs e)
        {
            var presenter = new TargetAlertExcelFormPresenter();
            presenter.Run(form);
        }

        public void SafeWorkPermitAssessmentExcelReportMenuItem_Click(object sender, EventArgs e)
        {
            var presenter = new SafeWorkPermitAssessmentReportFormPresenter();
            presenter.Run(form);
        }

        public void CustomFieldTrendReportMenuItem_Click(object sender, EventArgs e)
        {
            var presenter = new CustomFieldTrendReportFormPresenter();
            presenter.Run(form);
        }

        public void FormOilsandsTrainingExcelReportMenuItem_Click(object sender, EventArgs e)
        {
            var presenter = new FormOilsandsTrainingExcelReportFormPresenter();
            presenter.Run(form);
        }

        public void FormOilsandsTrainingFormReportMenuItem_Click(object sender, EventArgs e)
        {
            var page = new TrainingFormReportPresenter().Page;
            LoadReportPage(page);
        }

        public void CokerCardReportMenuItem_Click(object sender, EventArgs e)
        {
            var cokerCardReportForm = new CokerCardReportForm();
            cokerCardReportForm.ShowDialog(form);
        }

        public void MarkedAsReadLogReportMenuItem_Click(object sender, EventArgs e)
        {
            var siteUsesLogBasedDirectives = ClientSession.GetUserContext().SiteConfiguration.UseLogBasedDirectives;

            var newForm = new MarkedAsReadReportForm(true, false, siteUsesLogBasedDirectives);
            newForm.ShowDialog(form);
            newForm.Dispose();
        }

        public void MarkedAsReadShiftHandoverReportMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new MarkedAsReadReportForm(false, true, false);
            newForm.ShowDialog(form);
            newForm.Dispose();
        }
        public void MarkedAsNotReadShiftHandoverReportMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new MarkedAsNotReadReportForm( true,true);
            newForm.ShowDialog(form);
            newForm.Dispose();
        }


        public void MarkedAsReadDirectiveReportMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new MarkedAsReadReportForm(false, false, true);
            newForm.ShowDialog(form);
            newForm.Dispose();
        }

        public void HandleHelpMenuItemClick(object sender, EventArgs e)
        {
            HelpRequested();
        }

        public void HandleReleaseNotesMenuItemClick(object sender, EventArgs e)
        {
            var releaseNotesUrl = applicationService.GetReleaseNotesURL();
            UIUtils.LaunchURL(releaseNotesUrl);
        }

        public void HelpRequested()
        {
            var helpUrl = applicationService.GetHelpURL() + "/" + Culture.CultureInfo.TwoLetterISOLanguageName +
                          "/index.html";
            UIUtils.LaunchURL(helpUrl);
        }

        public void HandleLinkPathsMenuItemClick(object sender, EventArgs e)
        {
            var linksForm = new ConfigureLinkRootsForm();
            linksForm.ShowDialog(form);
            linksForm.Dispose();
        }

        public void HandleSiteCommunicationsMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayConfigureSiteCommunicationsForm,
                ConfigureSiteCommunicationsPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }


        public static void RoleMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RoleMatrixPresenter().Run();
        }

        public static void OpenLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggingUtilities.OpenLogFile();
        }

        public static void EmailLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggingUtilities.EmailLogFile();
        }

        public void HandlePriorityDisplayCriteriaMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayPriorityCriteriaForm,
                PriorityCriteriaFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public List<FunctionalLocation> GetSectionsForSelectedFunctionalLocations(Site site,
            List<FunctionalLocation> allFunctionalLocations)
        {
            var sections = new List<FunctionalLocation>();

            if (allFunctionalLocations != null)
            {
                //TODO (performance): Consider convertin this to a Set rather than using a List.
                var sectionFullHierarchyList = new List<string>();

                foreach (var functionalLocation in allFunctionalLocations)
                {
                    if (functionalLocation.IsSection)
                    {
                        if (!sections.ExistsById(functionalLocation))
                        {
                            sections.Add(functionalLocation);
                        }
                    }
                    else if (!functionalLocation.IsDivision)
                    {
                        var fullHierarchy = functionalLocation.ParentSectionFullHeirarchy;
                        if (!sectionFullHierarchyList.Contains(fullHierarchy) &&
                            !sections.Exists(floc => floc.FullHierarchy == fullHierarchy))
                        {
                            sectionFullHierarchyList.Add(fullHierarchy);
                        }
                    }
                    else
                    {
                        // floc is a division so get its child sections
                        var sectionLevelFunctionalLocations =
                            flocService.GetSectionLevelFunctionalLocation(functionalLocation);
                        if (sectionLevelFunctionalLocations != null)
                        {
                            //TODO: Shouldn't we check to make sure the Section isn't already in the List/Set?
                            sections.AddRange(sectionLevelFunctionalLocations);
                        }
                    }
                }

                foreach (var fullHierarchy in sectionFullHierarchyList)
                {
                    sections.Add(flocService.QueryByFullHierarchy(fullHierarchy, site.IdValue));
                }
            }

            return sections;
        }

        public List<FunctionalLocation> GetDivisionsForSelectedFunctionalLocations(Site site,
            List<FunctionalLocation> allFunctionalLocations)
        {
            //TODO (performance): This is a bit strange.  Why not have a method to query the Floc service to get all Division flocs fir a site, 
            // and then only keep those Division level flocs that are ancestors of at least one floc in allFunctionalLocations.
            var divisions = new List<FunctionalLocation>();

            if (allFunctionalLocations != null)
            {
                var divisionFullHierarchyList = allFunctionalLocations.DivisionFullHierarchies();

                foreach (var divisionFullHierarchy in divisionFullHierarchyList)
                {
                    divisions.Add(flocService.QueryByFullHierarchy(divisionFullHierarchy, site.IdValue));
                }
            }

            return divisions;
        }

        public void HandleVisibilityGroupsClick(object sender, EventArgs e)
        {
            var form = new ConfigureVisibilityGroupsForm();
            form.ShowDialog();
            form.Dispose();
        }

        public void HandleConfigureWorkPermitGroupsClick(object sender, EventArgs e)
        {
            //LaunchLockedPage(form.DisplayConfigureWorkPermitGroupsForm,
            //    ConfigureWorkPermitGroupsPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
            if (ClientSession.GetUserContext().Site.IdValue == Site.MontrealSulphur_ID) //RITM0301321 mangesh
            {
                LaunchLockedPage(form.DisplayMudsConfigureWorkPermitGroupsForm,
                    ConfigureMudsWorkPermitGroupsPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
            }
            else
            {
                LaunchLockedPage(form.DisplayConfigureWorkPermitGroupsForm,
                    ConfigureWorkPermitGroupsPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
            }
        }

        public void HandleChangeRestrictionFLOCsButtonClick(object sender, EventArgs e)
        {
            ShowChangeActiveRestrictionFunctionalLocationSelector();
        }

        public void HandleChangeActivePermitFLOCsButtonClick(object sender, EventArgs e)
        {
            ShowChangeActiveWorkPermitFunctionalLocationSelector();
        }

        public void HandleConfigureRoleMatrixMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayConfigureRoleMatrixForm,
                ConfigureRoleMatrixPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        //RITM-RITM0164850   Mukesh
        public void HandleConfigureRoleMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayConfigureRoleForm,
                ConfigureRoleMatrixPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }




        public void HandleConfigureRolePermissionsMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayConfigureRolePermissionsForm,
                ConfigureRolePermissionsPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConfigureAreaLabelsMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayConfigureAreaLabelsForm,
                ConfigureAreaLabelsPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleSiteConfigurationMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayTechnicalSiteConfigurationForm,
                TechnicalSiteConfigurationPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleSapAutoImportConfigurationToolStripMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplaySapAutoImportConfigurationForm,
                SapAutoImportConfigurationPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleHoneywellPhdConfigureMenuItemClick(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayHoneywellPhdConfigurationForm,
                ConfigureHoneywellPhdFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleAnalyticsExcelExportMenuItemClick(object sender, EventArgs e)
        {
            var presenter = new AnalyticsExcelExportFormPresenter();
            presenter.Run(form);
        }

        public void HandleEnableSecurityForNewDirectivesMenuItemClicked(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayEnableSecurityForNewDirectivesForm,
                EnableSecurityForNewDirectivesFormPresenter.CreateLockIdentifier(ClientSession.GetUserContext().Site));
        }

        public void HandleConvertLogBasedDirectivesIntoNewDirectivesMenuItemClicked(object sender, EventArgs e)
        {
            LaunchLockedPage(form.DisplayConvertLogBasedDirectivesIntoNewDirectivesForm,
                ConvertLogBasedDirectivesIntoNewDirectivesFormPresenter.CreateLockIdentifier(
                    ClientSession.GetUserContext().Site));
        }

        public void OnCreateFormOvertimeRequestClick()
        {
            var presenter = new FormOvertimeFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormCriticalSystemDefeatClick()
        {
            var presenter = new FormLubesCsdFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormLubesAlarmDisableClick()
        {
            var presenter = new FormLubesAlarmDisableFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormOilSandsSafeWorkPermitAuditQuestionnaireClick()
        {
            var presenter = new PermitAssessmentFormPresenter();
            presenter.Run(form);
        }

        //ayman Forthills Questionnaire
        public void OnCreateFormForthillsSafeWorkPermitAuditQuestionnaireClick()
        {
            var presenter = new PermitAssessmentFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormDocumentSuggestionClick()
        {
            var presenter = new DocumentSuggestionFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormProcedureDeviationClick()
        {
            var presenter = new ProcedureDeviationFormPresenter();
            presenter.Run(form);
        }

        /*RITM0265746 - Sarnia CSD marked as read start Report Part */
        public void OnFormOP14MarkAsReadReportMenuItemClick()
        {
            var page = new DevExpressFormOP14MarkAsReadReportPresenter().Page;
            LoadReportPage(page);
        }

        //public void OnCreateFormSarniaGN75BClick()
        //{
        //    var presenter = new FormGN75BFormPresenter();
        //    presenter.Run(form);
        //}


        #region event handlers

        public void MainForm_Load(object sender, EventArgs e)
        {
            dictionaryManager.LoadSpellCheckerDictionaries(form.SharedDictionaryStorage);

            ShowNextForm(NextForm.SplashScreenForm);
        }

        public void HandleCurrentShiftHasEnded(object sender, EventArgs e)
        {
            var timeRemaining = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            form.LaunchEndOfShiftMessage(Clock.Now, timeRemaining);
        }

        public void HandleShiftGracePeriodHasEnded(object sender, EventArgs e)
        {
            try
            {
                ClientServiceRegistry.Instance.RemoteEventRepeater.Disconnect(
                    EventConnectDisconnectReason.ShiftGracePeriodEnd);
            }
            catch (Exception exception)
            {
                logger.Error("Shift grace period ended.  Error disconnecting remote event repeater.", exception);
            }
            form.LaunchEndOfGracePeriodMessage();
            ClientSession.GetInstance().ForceLogoff = true;
            Application.Exit();
        }

        //RITM0387753-Shift Handover creation alert(Aarti)
        public void HandleShiftHandoverAlertEvent(object sender, EventArgs e)
        {
           bool userPrefShowAlert = ClientSession.GetUserContext().User.WorkPermitPrintPreference.ShowShiftHandoverAlertDialog;
            Authorized auth = new Authorized();
            bool isAccess = auth.ToCreateShiftHandoverQuestionnaire(userContext.UserRoleElements);
            bool isEnable = userContext.SiteConfiguration.EnableShiftHandoverAlert;
            var timeEnd = ClientSession.GetInstance().GetShiftHandoverAlertTime();
            if (isAccess && isEnable && userPrefShowAlert)
            {
                form.LaunchShiftHandoverAlertEvent(Clock.Now, timeEnd);
            }
        }

        public void HandleSelectedSectionChanged(SectionKey key)
        {
            var section = sectionRegistry.GetSection(key);
            form.LoadSectionIntoMainContentPanel(section);
            section.OnSelect();
        }

        public void HandleLogOutButtonClick(object sender, EventArgs e)
        {
            ClientSession.GetInstance().ForceLogoff = true;
            Application.Exit();
        }

        private NextForm ShowSiteSelector()
        {
            var result = form.DisplaySiteSelector();
            if (result == DialogResult.OK)
            {
                return NextForm.SelectFLOCForm;
            }
            return NextForm.LogInForm;
        }

        private NextForm ShowLogInForm()
        {
            return ShowSignInForm(NextForm.ExitForm);
        }

        private NextForm ShowSplashScreenForm()
        {
            form.DisplaySplashScreen();

            // This is a performance hack. Instantiate a RichTextEditor() here (takes 2-4 seconds the 1st time) so that future instantiations are fast.
            new RichTextEditor();

            form.CloseSplashScreen();

            return NextForm.LogInForm;
        }

        private NextForm ShowSignInForm(NextForm nextFormOnCancel)
        {
            var result = form.DisplaySignInForm();
            if (result == DialogResult.OK)
            {
                return GetNextFormAfterSignIn();
            }
            return nextFormOnCancel;
        }

        private NextForm GetNextFormAfterSignIn()
        {
            var clientSession = ClientSession.GetInstance();

            if (clientSession.UserHasMultipleSites)
            {
                return NextForm.SelectSiteForm;
            }
            var userContext = ClientSession.GetUserContext();

            var selectedSite = userContext.User.AvailableSites[0];
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConfiguration = siteConfigurationService.QueryBySiteId(selectedSite.IdValue);
            userContext.SetSite(selectedSite, siteConfiguration);

            return NextForm.SelectFLOCForm;
        }

        private UserRoleElements GetRoleElements(Role role)
        {
            var roleElements = roleElementService.QueryTemplateForRole(role);
            var userRoleElements = new UserRoleElements(role, roleElements);
            return userRoleElements;
        }

        private List<RolePermission> GetRolePermissions(Role role)
        {
            return rolePermissionService.QueryByRoleId(role.IdValue);
        }


        private List<RoleDisplayConfiguration> GetRoleDisplayConfigurations(Site site, Role role)
        {
            return roleDisplayConfigurationService.QueryBySiteAndRole(site, role);
        }

        public void OnCreateActionItemItemClick()
        {
            var newForm = new ActionItemDefinitionForm();
            newForm.ShowDialog(form as Form);
        }

        // DMND0011225 CSD for WBR
        public void OnCreateGenericCSDItemItemClick()
        {
            var newForm = new FormGenericCsdForm();
            newForm.ShowDialog(form as Form);
        }


        //ayman action item reading
        public void OnCreateReadingItemClick()
        {
            var newForm = new ActionItemDefinitionForm();
            newForm.SetTitle("Rading Definition");
            newForm.ShowDialog(form as Form);
        }

        public void OnCreateTargetClick()
        {
            var newForm = new TargetDefinitionForm();
            newForm.ShowDialog(form as Form);
        }

        public void OnCreateRestrictionClick()
        {
            var newForm = new RestrictionDefinitionForm();
            newForm.ShowDialog(form as Form);
        }

        public void OnCreateLabAlertClick()
        {
            var newForm = new LabAlertDefinitionForm();
            newForm.ShowDialog(form as Form);
        }

        public void OnCreateLogClick()
        {
            var authorized = new Authorized();
            var userContext = ClientSession.GetUserContext();

            var authorizedToCreateSummaryLogs = authorized.ToCreateSummaryLogs(userContext.UserRoleElements);

            if (!authorizedToCreateSummaryLogs && ShouldShowCombinedHandoverFormInstead())
            {
                CreateCombinedHandoverAndGotoHandoverSection(userContext);
            }
            else
            {
                var logForm = new LogForm();
                logForm.ShowDialog(form);
            }
        }


        private bool ShouldShowCombinedHandoverFormInstead()
        {
            var userContext = ClientSession.GetUserContext();

            var siteConfiguration = userContext.SiteConfiguration;

            //ayman test
            if (userContext.Assignment != null)
            {
                if (!siteConfiguration.AllowCombinedShiftHandoverAndLog ||
                    shiftHandoverService.GetAllQuestions(userContext.Assignment.IdValue).Count == 0)
                {
                    return false;
                }
            }

            var existingQuestionnaires = shiftHandoverService.QueryByUserWorkAssignmentAndShift(
                userContext.User.IdValue, userContext.WorkAssignmentId, userContext.UserShift);

            if (existingQuestionnaires.Count > 0)
            {
                return false;
            }
            var result = userContext.SiteConfiguration.ShowCreateShiftHandoverMessageFromNewLogClick
                ? ShiftHandoverQuestionnaireAndLogFormPresenter
                    .DisplayShiftHandoverDoesNotExistMessageAndAskUserIfTheyWantToCreateAComboHandoverAndLog(
                        form)
                : DialogResult.No;

            return result == DialogResult.Yes;
        }

        private void CreateCombinedHandoverAndGotoHandoverSection(UserContext userContext)
        {
            var handoverCreated = ShiftHandoverQuestionnaireFormPresenter.ShowForm(form, null);
            if (handoverCreated)
            {
                var newQuestionnaires = shiftHandoverService.QueryByUserWorkAssignmentAndShift(
                    userContext.User.IdValue, userContext.WorkAssignmentId, userContext.UserShift);
                if (newQuestionnaires.Count > 0) // it should be, we just created one!
                {
                    newQuestionnaires.Sort(q => q.CreateDateTime, false);
                    form.SelectSectionAndItem(SectionKey.ShiftHandoverSection,
                        new ShiftHandoverQuestionnaireDTO(newQuestionnaires[0]), true);
                }
            }
        }

        public void OnCreateRepeatingLogClick()
        {
            var newForm = LogDefinitionForm.CreateForRepeatingLog();
            newForm.ShowDialog(form as Form);
        }

        public void OnCreateShiftHandoverQuestionnaireClick()
        {
            ShiftHandoverQuestionnaireFormPresenter.CheckForExistingQuestionnaireBeforeOpeningForm(form);
        }

        public void OnCreateShiftSummaryLogClick()
        {
            var userContext = ClientSession.GetUserContext();

            if (ShouldShowCombinedHandoverFormInstead())
            {
                CreateCombinedHandoverAndGotoHandoverSection(userContext);
            }
            else
            {
                var allowedToAddShiftInfo = new Authorized().ToAddShiftInformation(userContext.UserRoleElements);
                var siteConfiguration = userContext.SiteConfiguration;
                var summaryLogForm = new SummaryLogForm(siteConfiguration.HideDORCommentEntry, allowedToAddShiftInfo);
                summaryLogForm.ShowDialog(form);
            }
        }

        public void OnNewButtonClick()
        {
            var actionEnum = securityManager.GetActionForSelectedSection(
                ClientSession.GetUserContext().UserRoleElements, sectionRegistry);
            switch (actionEnum)
            {
                case CreateAction.CreateActionItemDefinition:
                    OnCreateActionItemItemClick();
                    break;
                case CreateAction.CreateCokerCard:
                    OnCreateCokerCardClick();
                    break;
                case CreateAction.CreateConfinedSpace:
                    OnCreateConfinedSpaceClick();
                    break;
                case CreateAction.CreateDailyDirective:
                    OnCreateDailyDirectivesClick();
                    break;
                case CreateAction.CreateStandingOrder:
                    OnCreateStandingOrderClick();
                    break;
                case CreateAction.CreateLabAlertDefinition:
                    OnCreateLabAlertClick();
                    break;
                case CreateAction.CreateLog:
                    OnCreateLogClick();
                    break;
                case CreateAction.CreateRepeatingLog:
                    OnCreateRepeatingLogClick();
                    break;
                case CreateAction.CreatePermitRequest:
                    OnCreatePermitRequestClick();
                    break;
                case CreateAction.CreateRestrictionDefinition:
                    OnCreateRestrictionClick();
                    break;
                case CreateAction.CreateShiftHandover:
                    OnCreateShiftHandoverQuestionnaireClick();
                    break;
                case CreateAction.CreateShiftSummaryLog:
                    OnCreateShiftSummaryLogClick();
                    break;
                case CreateAction.CreateTargetDefinition:
                    OnCreateTargetClick();
                    break;
                case CreateAction.CreateWorkPermit:
                    OnCreatePermitClick();
                    break;
                case CreateAction.CreateFormSafeWorkPermitAuditQuestionnaire:
                    OnCreateFormClick();
                    break;
                case CreateAction.CreateFormDocumentSuggestion:
                    OnCreateFormClick();
                    break;
                case CreateAction.CreateFormProcedureDeviation:
                    OnCreateFormClick();
                    break;
                case CreateAction.CreateForm:
                    OnCreateFormClick();
                    break;
                case CreateAction.CreateDirective:
                    OnCreateDirectiveClick();
                    break;
            }
        }

        public void OnCreateConfinedSpaceClick()
        {
            if (ClientSession.GetUserContext().SiteId == Site.MONTREAL_ID) 
            {
                var presenter = new ConfinedSpaceFormPresenter();
                presenter.Run(form);
            }
            //RITM0301321 - mangesh
            else if (ClientSession.GetUserContext().SiteId == Site.MontrealSulphur_ID)
            {
                var presenter = new ConfinedSpaceFormMudsPresenter();
                presenter.Run(form);
            }
        }

        public void OnCreatePermitClick()
        {
            if (ClientSession.GetUserContext().IsMontrealSite)
            {
                var presenter = new WorkPermitMontrealFormPresenter();
                presenter.Run(form);
            }
            //RITM0301321 - mangesh
            else if (ClientSession.GetUserContext().IsMontrealSulphurSite)
            {
                var presenter = new WorkPermitMudsFormPresenter();
                presenter.Run(form);
            }
            else if (ClientSession.GetUserContext().IsEdmontonSite)
            {
                var isTurnaround = sectionRegistry.IsPageVisible(SectionKey.WorkPermitSection,
                    PageKey.WORK_PERMIT_TURNAROUND_PAGE);
                var presenter =
                    new WorkPermitEdmontonFormPresenter(isTurnaround
                        ? WorkPermitEdmontonTab.Turnaround
                        : WorkPermitEdmontonTab.RunningUnit);
                presenter.Run(form);
            }
            else if (ClientSession.GetUserContext().IsLubesSite)
            {
                var presenter = new WorkPermitLubesFormPresenter();
                presenter.Run(form);
            }
            else if (ClientSession.GetUserContext().IsForthillsSite)
            {
                var isTurnaround = sectionRegistry.IsPageVisible(SectionKey.WorkPermitSection,
                    PageKey.WORK_PERMIT_TURNAROUND_PAGE);
                var presenter =
                   new WorkPermitFortHillsFormPresenter(isTurnaround
                       ? WorkPermitFortHillsTab.Turnaround
                       : WorkPermitFortHillsTab.RunningUnit); ;
                presenter.Run(form);
            }
            else
            {
                IForm view = new WorkPermitFormsFactory().Build().NewForm();
                view.ShowDialog(form as Form);
                view.Dispose();
            }
        }

        public void OnCreatePermitRequestClick()
        {
            if (ClientSession.GetUserContext().IsMontrealSite)
            {
                var presenter = new PermitRequestMontrealFormPresenter();
                presenter.Run(form);
            }
            else if (ClientSession.GetUserContext().IsEdmontonSite)
            {
                var presenter = new PermitRequestEdmontonFormPresenter();
                presenter.Run(form);
            }
            else if (ClientSession.GetUserContext().IsLubesSite)
            {
                var presenter = new PermitRequestLubesFormPresenter();
                presenter.Run(form);
            }
            /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            else if (ClientSession.GetUserContext().IsForthillsSite)
            {
                var presenter = new PermitRequestFortHillsFormPresenter();
                presenter.Run(form);
            }
            //RITM0301321 mangesh
            if (ClientSession.GetUserContext().IsMontrealSulphurSite)
            {
                var presenter = new PermitRequestMudsFormPresenter();
                presenter.Run(form);
            }
        }

        public void PrintBlankWorkPermit_Click(object sender, EventArgs e)
        {
            if (ClientSession.GetUserContext().IsLubesSite)
            {
                var service = ClientServiceRegistry.Instance.GetService<IWorkPermitLubesService>();
                IReportPrintManager<WorkPermitLubes> reportPrintManager =
                    new ReportPrintManager<WorkPermitLubes, WorkPermitLubesReport, WorkPermitLubesReportAdapter>(
                        new WorkPermitLubesPrintActions(service, true));

                var blankPermit = new WorkPermitLubes(Clock.Now, ClientSession.GetUserContext().User);
                reportPrintManager.PreviewReport(blankPermit);
            }
        }

        private EdmontonFormType GetCurrentFormTypeSelection(ISection formSection)
        {
            IMultiGridContextSelection multiGridContextSelection = null;

            if (ClientSession.GetUserContext().IsLubesSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridLubesFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }

            //ayman fort hills forms
            if (ClientSession.GetUserContext().IsForthillsSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }

            if (ClientSession.GetUserContext().IsEdmontonSite)               //ayman generic forms
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridEdmontonFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }
            //ayman generic forms
            if (ClientSession.GetUserContext().IsSarniaSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridSarniaFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }
            //ayman E&U
            if (ClientSession.GetUserContext().IsSiteWideServicesSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }

            if (ClientSession.GetUserContext().IsOilsandsSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }

            else if (ClientSession.GetUserContext().IsWoodBuffaloRegionSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridWoodBuffaloRegionFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }




            if (multiGridContextSelection != null)
            {
                var edmontonFormType = multiGridContextSelection as EdmontonFormType;
                return edmontonFormType;
            }

            return null;
        }

        private OilsandsFormType GetCurrentOilsandsFormTypeSelection(ISection formSection)
        {
            IMultiGridContextSelection multiGridContextSelection = null;

            if (ClientSession.GetUserContext().IsOilsandsSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }

            if (multiGridContextSelection != null)
            {
                var oilsandsFormType = multiGridContextSelection as OilsandsFormType;
                return oilsandsFormType;
            }

            return null;
        }


        //ayman forthills
        private OilsandsFormType GetCurrentForthillsFormTypeSelection(ISection formSection)
        {
            IMultiGridContextSelection multiGridContextSelection = null;

            if (ClientSession.GetUserContext().IsForthillsSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }

            if (multiGridContextSelection != null)
            {
                var ForthillsFormType = multiGridContextSelection as OilsandsFormType;
                return ForthillsFormType;
            }

            return null;
        }


        //ayman E&U
        private OilsandsFormType GetCurrentSiteWideFormTypeSelection(ISection formSection)
        {
            IMultiGridContextSelection multiGridContextSelection = null;

            if (ClientSession.GetUserContext().IsSiteWideServicesSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }

            if (multiGridContextSelection != null)
            {
                var SiteWideFormType = multiGridContextSelection as OilsandsFormType;
                return SiteWideFormType;
            }

            return null;
        }

        //mangesh ETF
        private OilsandsFormType GetCurrentETFFormTypeSelection(ISection formSection)
        {
            IMultiGridContextSelection multiGridContextSelection = null;

            if (ClientSession.GetUserContext().IsWoodBuffaloRegionSite)
            {
                var pagePresenter = formSection.SelectedPagePresenter as MultiGridWoodBuffaloRegionFormPagePresenter;
                if (pagePresenter != null)
                {
                    multiGridContextSelection = pagePresenter.CurrentGridContext;
                }
            }

            if (multiGridContextSelection != null)
            {
                var ETFFormType = multiGridContextSelection as OilsandsFormType;
                return ETFFormType;
            }

            return null;
        }

        public void OnCreateFormClick()
        {
            var userRoleElements = userContext.UserRoleElements;

            if (userContext.IsMontrealSite)
            {
                OnCreateFormMontrealCsdClick();
            }
           
                //RITM0268131 - mangesh
            else if (userContext.IsMontrealSulphurSite)
            {
                if (authorized.ToCreateMudsTemporaryInstallationsForm(userRoleElements))  //INC0401892 : Added by Vibhor
                {
                    OnCreateFormMontrealSulphurClick();
                } 
            }                        
            else
            {
                var formSection = sectionRegistry.GetSection(SectionKey.FormSection);
                if (formSection != null)
                {
                    var edmontonFormType = GetCurrentFormTypeSelection(formSection);

                    if (userContext.IsWoodBuffaloRegionSite)
                    {
                        if (EdmontonFormType.DocumentSuggestion.Equals(edmontonFormType) &&
                            authorized.ToCreateFormDocumentSuggestion(userRoleElements, userContext.SiteId))
                        {
                            OnCreateFormDocumentSuggestionClick();                            
                        }                        
                        else if (EdmontonFormType.ProcedureDeviation.Equals(edmontonFormType) &&
                            authorized.ToCreateFormProcedureDeviation(userRoleElements, userContext.SiteId))
                        {
                            OnCreateFormProcedureDeviationClick();                            
                        }
                        //DMND0010261-SELC CSD EdmontonPipeline
                        else if (EdmontonFormType.OP14.Equals(edmontonFormType) &&
                            authorized.ToCreateForms(userRoleElements, userContext.Site))
                        {
                            OnCreateFormEdmontonPipelineCsdClick();
                            return;
                        }
                        //mangesh ETF
                        else
                        {
                            var ETFFormType = GetCurrentETFFormTypeSelection(formSection);

                            if (OilsandsFormType.Training.Equals(ETFFormType))
                            {
                                if (authorized.ToCreateTrainingForm(userRoleElements, ClientSession.GetUserContext().Site))
                                {
                                    var presenter = new FormOilsandsTrainingFormPresenter();
                                    presenter.Run(form);
                                }
                            }
                        }

                    }
                    if (userContext.IsLubesSite)
                    {
                        if (EdmontonFormType.LubesCsd.Equals(edmontonFormType) &&
                            authorized.ToCreateLubesCsdForm(userRoleElements))
                        {
                            OnCreateFormLubesCsdClick();
                        }
                        else if (EdmontonFormType.LubesAlarmDisable.Equals(edmontonFormType) &&
                                 authorized.ToCreateLubesAlarmDisableForm(userRoleElements))
                        {
                            OnCreateFormLubesAlarmDisableClick();
                        }
                    }
                    if (userContext.IsOilsandsSite)
                    {
                        if (EdmontonFormType.OilsandsPermitAssessment.Equals(edmontonFormType))
                        {
                            if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(userRoleElements))
                            {
                                var presenter = new PermitAssessmentFormPresenter();
                                presenter.Run(form);
                            }
                        }
                        else
                        {
                            var oilsandsFormType = GetCurrentOilsandsFormTypeSelection(formSection);

                            if (OilsandsFormType.Training.Equals(oilsandsFormType))
                            {
                                if (authorized.ToCreateForms(userRoleElements, ClientSession.GetUserContext().Site))
                                {
                                    var presenter = new FormOilsandsTrainingFormPresenter();
                                    presenter.Run(form);
                                }
                            }
                        }
                    }

                //ayman forthills
                    if (userContext.IsForthillsSite)
                    {
                        if (EdmontonFormType.OilsandsPermitAssessment.Equals(edmontonFormType))
                        {
                            if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(userRoleElements))
                            {
                                var presenter = new PermitAssessmentFormPresenter();
                                presenter.Run(form);
                            }
                        }
                        else
                        {
                            var ForthillsFormType = GetCurrentForthillsFormTypeSelection(formSection);

                            if (OilsandsFormType.Training.Equals(ForthillsFormType))
                            {
                                if (authorized.ToCreateTrainingForm(userRoleElements, ClientSession.GetUserContext().Site))
                                {
                                    var presenter = new FormOilsandsTrainingFormPresenter();
                                    presenter.Run(form);
                                }
                            }
                        }
                    }

                    //ayman E&U
                    if (userContext.IsSiteWideServicesSite)
                    {
                        if (EdmontonFormType.OilsandsPermitAssessment.Equals(edmontonFormType))
                        {
                            if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(userRoleElements))
                            {
                                var presenter = new PermitAssessmentFormPresenter();
                                presenter.Run(form);
                            }
                        }
                        else
                        {
                            var SiteWideFormType = GetCurrentSiteWideFormTypeSelection(formSection);

                            if (OilsandsFormType.Training.Equals(SiteWideFormType))
                            {
                                if (authorized.ToCreateTrainingForm(userRoleElements, ClientSession.GetUserContext().Site))
                                {
                                    var presenter = new FormOilsandsTrainingFormPresenter();
                                    presenter.Run(form);
                                }
                            }
                        }
                    }


                    //ayman Sarnia eip DMND0008992
                    if (userContext.IsSarniaSite)
                    {
                        if (EdmontonFormType.GN75BTemplate.Equals(edmontonFormType)) 
                        {
                            OnCreateSarniaFormGN75BTemplateClick();
                        }

                        if (EdmontonFormType.GN75BSarniaEIP.Equals(edmontonFormType))
                        {
                            OnCreateSarniaFormGN75BFormClick();
                        }
                        if (EdmontonFormType.OP14.Equals(edmontonFormType))
                        {
                            OnCreateFormOP14Click();
                        }
                    }


                    else if (EdmontonFormType.GN7.Equals(edmontonFormType))
                    {
                        OnCreateFormGN7Click();
                    }
                    else if (EdmontonFormType.GN59.Equals(edmontonFormType))
                    {
                        OnCreateFormGN59Click();
                    }
                    else if (EdmontonFormType.OP14.Equals(edmontonFormType))
                    {
                        OnCreateFormOP14Click();
                    }
                    //generic template - mangesh
                    else if (EdmontonFormType.OdourNoiseComplaint.Equals(edmontonFormType)
                                || (EdmontonFormType.Deviation.Equals(edmontonFormType))
                                || (EdmontonFormType.RoadClosure.Equals(edmontonFormType))
                                || (EdmontonFormType.GN11GroundDisturbance.Equals(edmontonFormType))
                                || (EdmontonFormType.GN27FreezePlug.Equals(edmontonFormType))
                                || (EdmontonFormType.HazardAssessment.Equals(edmontonFormType))
                                || (EdmontonFormType.FortHillOilSample.Equals(edmontonFormType))    //RITM0341710 - mangesh
                                || (EdmontonFormType.FortHillDailyInspection.Equals(edmontonFormType)
                                || (EdmontonFormType.NonEmergencyWaterSystemApproval.Equals(edmontonFormType)) // TASK0593631 - mangesh
                        ) )
                    {
                        //OnCreateFormGenericTemplateClick(edmontonFormType);

                        if (CreateForm(userRoleElements, edmontonFormType))
                        {
                            OnCreateFormGenericTemplateClick(edmontonFormType);
                        }
                    }
                   
                    else if (EdmontonFormType.GN24.Equals(edmontonFormType))
                    {
                        OnCreateFormGN24Click();
                    }
                    else if (EdmontonFormType.GN6.Equals(edmontonFormType))
                    {
                        OnCreateFormGN6Click();
                    }
                    else if (EdmontonFormType.GN75A.Equals(edmontonFormType))
                    {
                        OnCreateFormGN75AClick();
                    }

                    else if (EdmontonFormType.GN75B.Equals(edmontonFormType))
                    {
                        OnCreateFormGN75BClick();
                    }

                    else if (EdmontonFormType.GN1.Equals(edmontonFormType))
                    {
                        OnCreateFormGN1Click();
                    }
                    else if (EdmontonFormType.Overtime.Equals(edmontonFormType))
                    {
                        OnCreateOvertimeFormClick();
                    }
                }
            }
        }

        //generic template - mangesh
        private bool CreateForm(UserRoleElements userRoleElements, EdmontonFormType formType)
        {
            bool canCreate = false;
            if (formType == EdmontonFormType.OdourNoiseComplaint)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_ODOURNOISE);
            }
            else if (formType == EdmontonFormType.Deviation)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_DEVIATION);
            }
            else if (formType == EdmontonFormType.RoadClosure)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_ROADCLOSURE);
            }
            else if (formType == EdmontonFormType.GN11GroundDisturbance)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_GN11GROUNDDISTURBANCE);
            }
            else if (formType == EdmontonFormType.GN27FreezePlug)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_GN27FREEZEPLUG);
            }
            else if (formType == EdmontonFormType.HazardAssessment)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_HAZARDASSESSMENT);
            }
            //TASK0593631- mangesh
            if (formType == EdmontonFormType.NonEmergencyWaterSystemApproval)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_NonEmergencyWaterSystemApproval);
            }
            //RITM0341710 - mangesh
            else if (formType == EdmontonFormType.FortHillOilSample)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_OILSAMPLE);
            }
            else if (formType == EdmontonFormType.FortHillDailyInspection)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_DAILYINSPECTION);
            }
            return canCreate;
        }

        private void OnCreateOvertimeFormClick()
        {
            var presenter = new FormOvertimeFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateDirectiveClick()
        {
            var presenter = new DirectiveFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormGN7Click()
        {
            var presenter = new FormGN7FormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormGN59Click()
        {
            var presenter = new FormGN59FormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormOP14Click()
        {
            var presenter = new FormOP14FormPresenter();
            presenter.Run(form);
        }

        //generic template - mangesh
        public void OnCreateFormGenericTemplateClick(EdmontonFormType edmontonFormType)
        {
            var presenter = new FormGenericTemplateFormPresenter(edmontonFormType);
            presenter.Run(form);
        }
        //Addded by ppanigrahi
        public void OnCreateFormGenericEmailTemplateClick(EdmontonFormType edmontonFormType)
        {
            var presenter = new FormGenericTemplateFormPresenter(edmontonFormType);
        }

        public void OnCreateFormLubesCsdClick()
        {
            var presenter = new FormLubesCsdFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormMontrealCsdClick()
        {
            var presenter = new MontrealCsdPresenter();
            presenter.Run(form);
        }

        //RITM0268131 - mangesh
        public void OnCreateFormMontrealSulphurClick()
        {
            var presenter = new TemporaryInstallationsFormPresenter();
            presenter.Run(form);
        }

        //DMND0010261-SELC CSD EdmontonPipeline
        public void OnCreateFormEdmontonPipelineCsdClick()
        {
            var presenter = new EdmontonPipelineOP14Presenter();
            presenter.Run(form);
        }
        //END DMND0010261-SELC CSD EdmontonPipeline

        public void OnCreateFormGN24Click()
        {
            var presenter = new FormGN24FormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormGN6Click()
        {
            var presenter = new FormGN6FormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormGN75AClick()
        {
            var presenter = new FormGN75AFormPresenter();
            presenter.Run(form);
        }


        //ayman Sarnia eip DMND0008992
        public void OnCreateSarniaFormGN75BTemplateClick()
        {
            var presenter = new FormGN75BSarniaTemplatePresenter();
            presenter.Run(form);
        }

        //ayman Sarnia eip DMND0008992
        public void OnCreateSarniaFormGN75BFormClick()
        {
            var presenter = new FormGN75BSarniaFormPresenter();
            presenter.Run(form);
        }


        public void OnCreateFormGN75BClick()
        {
            var presenter = new FormGN75BFormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormGN1Click()
        {
            var presenter = new FormGN1FormPresenter();
            presenter.Run(form);
        }

        public void OnCreateFormOilsandsTrainingClick()
        {
            var presenter = new FormOilsandsTrainingFormPresenter();
            presenter.Run(form);
        }

        //ayman forthills
        public void OnCreateFormForthillsTrainingClick()
        {
            var presenter = new FormOilsandsTrainingFormPresenter();
            presenter.Run(form);
        }

        //ayman E&U
        public void OnCreateFormSiteWideTrainingClick()
        {
            var presenter = new FormOilsandsTrainingFormPresenter();
            presenter.Run(form);
        }

        //mangesh ETF
        public void OnCreateFormETFTrainingClick()
        {
            var presenter = new FormOilsandsTrainingFormPresenter();
            presenter.Run(form);
        }

        public void HandleExitMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            ShowNextForm(NextForm.SwitchActiveFLOCForm);
        }

        //RITM0386914 : OLT users to switch from one site to another - Added By Vibhor
        public void HandleChangeSiteButtonClick(object sender, EventArgs e)
        {
            DialogResult result = OltMessageBox.Show(Form.ActiveForm, StringResources.OltChangeSiteMessage,
                "Alert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ShowNextForm(NextForm.SelectSiteForm);
            }
        }
        //END

        private NextForm ShowSelectAssignmentAndFLOCsOnLogInForm()
        {
            return ShowAssignmentAndFunctionalLocationSelector(NextForm.LogInForm, NextForm.SelectRoleForm, false);
        }

        private NextForm ShowSelectRoleForm()
        {
            return ShowRoleSelector(NextForm.LogInForm, NextForm.SelectShiftForm);
        }

        private NextForm ShowSelectRoleFormForSwitchActiveFlocs()
        {
            return ShowRoleSelector(NextForm.SwitchActiveFLOCForm, NextForm.MainForm);
        }

        private NextForm ShowSwitchActiveFunctionalLocationForm()
        {
            return ShowAssignmentAndFunctionalLocationSelector(NextForm.None,
                NextForm.SelectRoleFormForSwitchActiveFlocProcess, true);
        }

        private NextForm ShowAssignmentAndFunctionalLocationSelector(NextForm nextFormOnCancel,
            NextForm nextFormOnSuccess, bool changeActiveFlocsMode)
        {
            var dialogResultAndOutput = form.DisplayAssignmentAndFunctionalLocationForm(changeActiveFlocsMode);
            var result = dialogResultAndOutput.Result;

            var selectedAssignment = dialogResultAndOutput.Output.WorkAssignment;
            var allCheckedFunctionalLocations = dialogResultAndOutput.Output.SelectedFlocs;
            var readableVisibilityGroupIds = dialogResultAndOutput.Output.ReadableVisibilityGroupIds;


            //ayman visibility group
            var writeableVisibilityGroupIds = dialogResultAndOutput.Output.WorkAssignment == null ? null :
              dialogResultAndOutput.Output.WorkAssignment.WriteWorkAssignmentVisibilityGroups.ConvertAll(vg => vg.VisibilityGroupId);


            if (result == DialogResult.OK)
            {
                var userContext = ClientSession.GetUserContext();
                userContext.SetSelectedFunctionalLocations(
                    allCheckedFunctionalLocations,
                    GetDivisionsForSelectedFunctionalLocations(userContext.Site, allCheckedFunctionalLocations),
                    GetSectionsForSelectedFunctionalLocations(userContext.Site, allCheckedFunctionalLocations));
                userContext.Assignment = selectedAssignment;
                userContext.SetReadableVisibilityGroupIds(readableVisibilityGroupIds);

                //ayman visibility group
                userContext.SetWritableVisibilityGroupIds(writeableVisibilityGroupIds);


                if (selectedAssignment != null)
                {
                    var role = selectedAssignment.Role;
                    userContext.SetRole(role, GetRoleElements(role),
                        GetRoleDisplayConfigurations(userContext.Site, role), GetRolePermissions(role));

                    var flocsForPermits = flocService.QueryByWorkAssignmentIdForWorkPermits(selectedAssignment.IdValue);
                    userContext.FunctionalLocationsForWorkPermits = flocsForPermits;

                    var flocsForRestrictions =
                        flocService.QueryByWorkAssignmentIdForRestrictionFlocs(selectedAssignment.IdValue);
                    userContext.FunctionalLocationsForRestrictions = flocsForRestrictions;
                }

                form.TooltipFunctionalLocations = userContext.RootsForSelectedFunctionalLocations;
                return nextFormOnSuccess;
            }

            return nextFormOnCancel;
        }

        private void ShowChangeActiveWorkPermitFunctionalLocationSelector()
        {
            var result = form.DisplayChangeActiveWorkPermitFunctionalLocationForm();
            if (result == DialogResult.OK)
            {
                var allSelectedFunctionalLocations = form.AllSelectedFunctionalLocationsForWorkPermits;
                var userContext = ClientSession.GetUserContext();

                userContext.FunctionalLocationsForWorkPermits = allSelectedFunctionalLocations;

                ShowNextForm(NextForm.MainForm);
            }
        }

        private void ShowChangeActiveRestrictionFunctionalLocationSelector()
        {
            var result = form.DisplayChangeActiveRestrictionFunctionalLocationForm();
            if (result == DialogResult.OK)
            {
                var allSelectedFunctionalLocations = form.AllSelectedFunctionalLocationsForRestrictions;
                var userContext = ClientSession.GetUserContext();

                userContext.FunctionalLocationsForRestrictions = allSelectedFunctionalLocations;

                ShowNextForm(NextForm.MainForm);
            }
        }

        private NextForm ShowRoleSelector(NextForm nextFormOnCancel, NextForm nextFormOnSuccess)
        {
            var userContext = ClientSession.GetUserContext();
            if (userContext.Assignment == null)
            {
                IList<Role> roles = userContext.User.GetRoles(userContext.Site);
                if (roles.Count == 1)
                {
                    var newRole = roles[0];
                    userContext.SetRole(newRole, GetRoleElements(newRole),
                        GetRoleDisplayConfigurations(userContext.Site, newRole), GetRolePermissions(newRole));
                }
                else if (roles.Count > 1)
                {
                    var result = form.DisplayRoleSelector();

                    if (result.Result == DialogResult.OK)
                    {
                        var newRole = result.Output;
                        userContext.SetRole(newRole, GetRoleElements(newRole),
                            GetRoleDisplayConfigurations(userContext.Site, newRole), GetRolePermissions(newRole));
                    }
                    else
                    {
                        return nextFormOnCancel;
                    }
                }
                else
                {
                    // There should always be one or more roles because a check is done at login, but what the heck.
                    form.LaunchNoOLTRolesMessage(StringResources.NoOLTRolesMessageBoxText,
                        StringResources.NoOLTRolesMessageBoxCaption);
                    return nextFormOnCancel;
                }
            }

            SetUserRoleToReadOnlyIfNecessary(userContext);

            if (userContext.Role == null)
            {
                throw new Exception("Internal Error: A role must be set to continue.");
            }

            userContext.PlantIds = SiteRolePlant.ChoosePlantIds(userContext.Role, userContext.User.SiteRolePlants);

            return nextFormOnSuccess;
        }

        private void SetUserRoleToReadOnlyIfNecessary(UserContext userContext)
        {
            if (ReadOnlyRoleChecker.ShouldBeConvertedToReadOnlyRole(
                userContext.User,
                userContext.Role,
                userContext.Assignment,
                userContext.RootsForSelectedFunctionalLocations))
            {
                form.LaunchReadOnlyRoleMessage(StringResources.ReadOnlyAccess, StringResources.ReadOnlyAccessTitle);

                var newRole = roleService.GetReadOnlyRole(userContext.Site);
                userContext.SetRole(newRole, GetRoleElements(newRole),
                    GetRoleDisplayConfigurations(userContext.Site, newRole), GetRolePermissions(newRole));
            }
        }

        /// <summary>
        ///     Show the shiftPattern selector if there is more then one shiftPattern associated in the selected functional
        ///     locations
        /// </summary>
        private NextForm ShowShiftSelector()
        {
            //if there is only one shiftPattern that comes back, jam it into the clientSession.
            //otherwise pop-up the SingleSelectShiftForm
            var shifts = GetListOfShiftsBySiteForCurrentTimeAndShiftPadding();
            if (shifts == null || shifts.Count == 0)
            {
                form.LaunchNoShiftFoundMessage(
                    String.Format("There is no shift at this time ({0}) at the selected site.",
                        Clock.TimeNow.ToStringWithSeconds()));
                return NextForm.SelectFLOCForm;
            }
            var userContext = ClientSession.GetUserContext();
            if (shifts.Count == 1)
            {
                userContext.UserShift = new UserShift(shifts[0], Clock.Now);
            }
            else
            {
                var shiftSelectForm = new SingleSelectShiftForm(shifts);
                shiftSelectForm.ShowDialog(form as Form);
            }
            form.TooltipFunctionalLocations = userContext.RootsForSelectedFunctionalLocations;
            form.RegisterShiftEndHandler();

            var loginHistory = new UserLoginHistory(
                null,
                userContext.User,
                Clock.Now,
                userContext.UserShift.ShiftPattern,
                userContext.UserShift.StartDateTime,
                userContext.UserShift.EndDateTime,
                userContext.Assignment,
                userContext.RootsForSelectedFunctionalLocations,
                ClientServiceRegistry.Instance.ClientServiceHostAddress,
                ConfigurationManager.AppSettings["FileUpdateSourceDirectory"],
                OltEnvironment.MachineName,
                Environment.OSVersion.ToString(),
                OltEnvironment.DotNetVersion,
                ApplicationDeployment.IsNetworkDeployed);
            loginHistoryService.SaveLoginHistory(loginHistory);

            logger.Info("User login information:" + Environment.NewLine + UserLoginLogEntry.CreateLogMessage());

            return NextForm.MainForm;
        }

        /// <summary>
        ///     Get the list of shiftPattern functional locations
        /// </summary>
        /// <returns>The list of shiftFlocs associated with the usercontext's functional locations</returns>
        public List<ShiftPattern> GetListOfShiftsBySiteForCurrentTimeAndShiftPadding()
        {
            var timeDuringShift = Clock.TimeNow;
            //            if (System.TimeZoneName.CurrentTimeZone.IsDaylightSavingTime(Clock.Now))
            //            if (new DateTime(Clock.Now.Ticks, DateTimeKind.Local).IsDaylightSavingTime())
            //            {
            //                timeDuringShift = timeDuringShift.Add(1);
            //            }
            return
                shiftPatternService.GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding(
                    ClientSession.GetUserContext().Site,
                    timeDuringShift);
        }

        #endregion

        private delegate void LaunchForm();

        private enum NextForm
        {
            None,
            MainForm,
            SplashScreenForm,
            LogInForm,
            SelectFLOCForm,
            SelectRoleForm,
            SelectShiftForm,
            SelectSiteForm,
            SwitchActiveFLOCForm,
            SelectRoleFormForSwitchActiveFlocProcess,
            ExitForm
        }
    }
}