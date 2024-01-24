using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Controls.ToolStrips;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;
using DevExpress.XtraSpellChecker;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IMainForm : IBaseForm
    {
        SectionKey SelectedSection { get; }

        string Title { set; }
        bool ButtonsEnabled { set; }

        IMainUserStrip UserStrip { get; }
        SharedDictionaryStorage SharedDictionaryStorage { get; }
        string BuildVersion { set; }

        IList<FunctionalLocation> TooltipFunctionalLocations { set; }
        List<FunctionalLocation> AllSelectedFunctionalLocationsForWorkPermits { get; }

        bool PreferencesVisible { set; }

        string SetShiftLogMenuItemName { set; } //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}

        bool CreateActionItemVisible { set; }
        bool CreateTargetVisible { set; }
        bool CreateRestrictionVisible { set; }
        bool CreateLogSubMenuVisible { set; }
        bool CreateLogVisible { set; }
        bool CreateShiftSummaryLogVisible { set; }
        bool CreateDailyDirectiveLogEntryVisible { set; }
        bool CreateShiftHandoverQuestionnaireVisible { set; }
        bool CreateDirectiveVisible { set; }
        bool CreateWorkPermitVisible { set; }
        bool CreateLabAlertVisible { set; }

        bool ConfigureGasTestLimitsEnabled { set; }
        bool ConfigureOperationalModeEnabled { set; }
        bool ConfigureRestrictionFlocsForWorkAssignmentsEnabled { set; }
        bool ConfigureDisplayLimitsEnabled { set; }
        bool ConfigureDefaultTabsEnabled { set; }
        bool ConfigureWorkAssignmentNotSelectedWarningEnabled { set; }
        bool ConfigureLabAlertsEnabled { set; }
        bool ConfigureWorkPermitArchivalProcessEnabled { set; }
        bool ConfigureAutoApproveSAPAIDEnabled { set; }
        bool ConfigureWorkPermitContractorEnabled { set; }
        bool ConfigurePlantHistorianTagListEnabled { set; }
        bool ConfigureCraftOrTradeEnabled { set; }
        bool ConfigureRoadAccessOnPermitEnabled { set; } //mangesh for RoadAccessOnPermit 
        bool ConfigureSpecialWorkEnabled { set; }
        bool ConfigureWorkAssignmentsEnabled { set; }
        bool ConfigureVisibilityGroupsEnabled { set; }
        bool ConfigureWorkPermitGroupsEnabled { set; }
        bool ConfigureAutoReApprovalByFieldEnabled { set; }
        bool ConfigureDefaultFLOCsForDailyAssignmentsEnabled { set; }
        bool ConfigureAssociateWorkAssignmentsToFLOCsForPermitAutoAssignmentEnabled { set; }
        bool ConfigureAssociateWorkAssignmentsForPermitsEnabled { set; }
        bool ConfigurePriorityPageEnabled { set; }
        bool ConfigureShiftHandoverEnabled { set; }
        bool ConfigureShiftHandoverEmailEnabled { set; }
        bool ConfigureCokerCardsEnabled { set; }

        bool ConfigureSapAutoImportVisible { set; }

        bool OperatingEngineerShiftLogReportVisible { set; }
        string OperatingEngineerShiftLogReportDisplayText { set; }

        bool ConfigureRestrictionReasonCodeEnabled { set; }
        bool ConfigurationRestrictionListsEnabled { set; }
        bool ConfigureDeviationAlertResponseTimeLimitEnabled { set; }

        bool RestrictionReportsVisible { set; }
        bool LogReportsVisible { set; }
        bool FormReportsVisible { set; }
        bool ShiftHandoverReportsVisible { set; }
        bool DirectiveReportsVisible { set; }
        bool TargetReportsVisible { set; }
        bool CokerCardReportsVisible { set; }
        bool SafeWorkPermitMenuItemVisible { set; }

        bool ConfigureBusinessCategoriesEnabled { set; }
        bool ConfigureBusinessCategoryFlocAssociationsEnabled { set; }
        bool ConfigureLogGuidelinesEnabled { set; }
        bool ConfigureLogTemplatesEnabled { set; }
        bool ConfigureCustomFieldsEnabled { set; }
        bool ConfigureDORCutoffTimeEnabled { set; }
        bool ConfigureDORCutoffTimeVisible { set; }
        bool ConfigureLinkConfigurationEnabled { set; }
        bool ConfigureSiteCommunicationsEnabled { set; }
        bool CreateCokerCardVisible { set; }
        bool ConfigureWorkPermitMontrealTemplatesEnabled { set; }
        bool ConfigureWorkPermitMontrealDropdownsEnabled { set; }
        bool ConfigureConfiguredDocumentLinksEnabled { set; }
        bool CreatePermitRequestVisible { set; }
        bool ConfigureFormTemplatesEnabled { set; }
        bool ConfigureGenericTemplateApprovalEnabled { set; } //generic template - mangesh
        bool ConfigureGenericEmailTemplateApprovalEnabled { set; }//generic Email template for Sarnia

        bool CreateGenericCsdVisible { set; } // DMND0011225 CSD for WBR

        bool ConfigureTrainingBlocksEnabled { set; }
        bool ConfigureOltCommunityEnabled { set; }  //olt admin/cop member list - mangesh

        bool PrioritiesAdminSectionVisible { set; }
        bool ActionItemsAdminSectionVisible { set; }
        bool LogsAdminSectionVisible { set; }
        bool LabAlertsAdminSectionVisible { set; }
        bool RestrictionReportingAdminSectionVisible { set; }
        bool TargetsAdminSectionVisible { set; }
        bool ShiftHandoverAdminSectionVisible { set; }
        bool CokerCardAdminSectionvisible { set; }
        bool SafeWorkPermitsAdminSectionVisible { set; }
        bool FormsAdminSectionVisible { set; }
        bool DisplaySettingsAdminSectionVisible { set; }
        bool WorkAssignmentAdminSectionVisible { set; }
        bool SiteConfigurationAdminSectionVisible { set; }
        bool CreateNewItemVisible { set; }
        bool CreateConfinedSpaceVisible { set; }
        bool CreateRepeatingLogVisible { set; }
        bool CreateStandingOrdersVisible { set; }
        bool ConfigureAreaLabelsEnabled { set; }
        bool ConfigureFunctionalLocationsEnabled { set; }
        bool OnPremisePersonnelReportVisible { set; }
        bool TrainingFormExcelVisible { set; }
        /*RITM0265746 - Sarnia CSD marked as read end  Report Part*/
        bool FormOP14MarkAsReadReportVisible { set; }
        string CSDMarkAsReadReportForSarnia { get; set; }   //INC0458108 : added by Vibhor
        


        /// <summary>
        /// Changed for: RITM0088705
        /// Changed By: Komal Sahu (ksahu)
        /// Changed Date: 15/03/2017
        /// </summary>
        /// Change starts/////////
        bool SafeWorkPermitAssessmentReportVisible { set; }
        /// Change Ends/////////
        
        bool TrainingFormReportVisible { set; }
        bool ConfigureFormDropdownsEnabled { set; }
        bool AdminSafeWorkPermitQuestionnairesEnabled {  set; }
        List<FunctionalLocation> AllSelectedFunctionalLocationsForRestrictions { get; }

        //Sarika... Floc structure level changes...9Jan2017
        bool ConfigureFlocLevelEnabled { set; }
        
        void RegisterShiftEndHandler();
        void LaunchEndOfGracePeriodMessage();
        void LaunchShiftHandoverAlertEvent(DateTime now, TimeSpan timeRemainingToWork);//RITM0387753-Shift Handover creation alert:Aarti
        void LaunchNoShiftFoundMessage(string message);
        void LaunchEndOfShiftMessage(DateTime now, TimeSpan timeRemainingToWork);
        void NavigateTo(SectionKey key);
        void UnSelectPageInNavigationList();
        void SelectSectionAndItem(PageKey pageKey, long domainObjectId);
        void SelectSectionAndItem(SectionKey key, DomainObject item);
        void SelectSectionAndItem(SectionKey key, DomainObject item, bool suppressItemNotFoundMessage);

        bool GetSelectSectionAndItem(PageKey pageKey, long domainObjectId);


        void ClearNavigation();
        void AddNavigation(SectionKey key);
        void LoadSectionIntoMainContentPanel(ISection section);
        void LoadControlIntoMainContentPanel(Control page);
        void SetPageNamePrefix(string name);
        void LaunchLockDeniedMessage(string message, string title);
        DialogResult DisplayChangeActiveWorkPermitFunctionalLocationForm();
        DialogResult DisplayChangeActiveRestrictionFunctionalLocationForm();
        DialogResultAndOutput<UserLoginSelections> DisplayAssignmentAndFunctionalLocationForm(bool changeActiveFlocsMode);
        DialogResultAndOutput<Role> DisplayRoleSelector();
        DialogResult DisplaySignInForm();
        DialogResult DisplaySiteSelector();

        void CreateGenericTemplateFormVisible(bool createEdmontonOdourNoiseFormAuthorized, bool createEdmontonDeviationFormAuthorized, bool createEdmontonRoadClosureFormAuthorized,
                                                    bool createEdmontonGN11GroundDistrubanceFormAuthorized, bool createEdmontonGN27FreezePlugFormAuthorized, bool createEdmontonHazardAssessmentFormAuthorized
                                    , bool createEdmontonNonEmergencyWaterSystemApprovalFormAuthorized); // TASK0593631 - mangesh

        //ayman sarnia - ayman selc - ayman forthills - ayman E&U
        void CreateFormsVisible(bool createEdmontonFormsVisible, bool createSarniaFormsVisible, bool createSelcCSDFormVisible, bool createForthillsTrainingVisible, bool createOilsandsTrainingVisible,
            bool createEdmontonOvertimeFormsVisible, bool createLubesCsdAuthorized, bool createMontrealCsdAuthorized,
            bool createLubesAlarmDisableAuthorized, bool createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized,
            bool createFormDocumentSuggestionAuthorized, bool createFormProcedureDeviationAuthorized, bool createSiteWideTrainingVisible, bool createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized,   //ayman forthills questionnaire
            bool createETFTrainingFormAuthorized, // mangeh ETF
           bool createMudsTemporaryInstallationsAuthorized, //RITM0268131 - mangesh
            bool createFortHillOilSampleFormAuthorized, Boolean createFortHillDailyInspectionFormAuthorized,  //RITM0341710 -mangesh
            bool createGenericCsdAuthorized);// DMND0011225 CSD for WBR
        
        void CreateEipIssueVisible(bool createEipIssueAuthorised);                 //ayman Sarnia eip DMND0008992

        void AdminstrationVisible(bool visible);
        void TechnicalAdminstrationVisible(bool visible);

        void DisplayConfigureGasTestElementInfoForm();
        void DisplayManageOperationalModeForUnitsForm();
        void DisplayConfigureSiteForm();
        void DisplayConfigureDefaultTabsForm();
        void DisplayConfigureWorkAssignmentNotSelectedWarningForm();
        void DisplayLabAlertConfigurationForm();
        void DisplayConfigureRestrictionReportingLimitsForm();
        void DisplayEditRestrictionReasonCodesForm();
        void DisplayRestrictionLocationListConfigurationForm();
        void DisplayConfigureWorkPermitArchivalProcessForm();
        void DisplayConfigureActionItemsForm();
        void DisplayConfigureWorkPermitContractorForm();
        void DisplayConfigureDefaultFlocsForDailyAssignnmentForm();
        void DisplayWorkPermitAutoAssignmentConfigurationForm();
        void DisplayRestrictionsFlocsConfigurationForm();
        void DisplayWorkPermitAssignmentConfigurationForm();
        void DisplayConfigurePlantHistorianTagListForm();
        void DisplayConfigureCraftOrTradeForm();
        void DisplayConfigureRoadAccessOnPermitForm(); //mangesh for RoadAccessOnPermit 
        void DisplayConfigureSpecialWorkForm();
        void DisplayAssignmentConfigurationForm();
        void DisplayLogGuidelinesConfigurationForm();
        void DisplayLogTemplatesConfigurationForm();
        void DisplayFieldAutoReApprovalConfigurationForm();
        void DisplayBusinessCategoriesForm();
        void DisplayBusinessCategoryFLOCAssociationForm();
        void LaunchNoOLTRolesMessage(string message, string title);
        void LaunchReadOnlyRoleMessage(string message, string title);
        void DisplayShiftHandoverConfigurationForm();
        void DisplayQuestionnaireConfigurationForm();
        void DisplayCokerCardConfigurationForm();
        void DisplayCustomFieldConfigurationForm();
        void DisplayConfigureDORCutoffTimeForm();
        void DisplayPriorityCriteriaForm();
        void DisplayWorkPermitMontrealTemplatesConfigurationForm();
        void DisplayWorkPermitMontrealDropdownsConfigurationForm();
        void DisplayConfiguredDocumentLinkConfigurationForm();
        void DisplayFormTemplateConfigurationForm();
        void DisplayTrainingBlockConfigurationForm();
        void DisplayConfigureRoleMatrixForm();
        void DisplayConfigureWorkPermitGroupsForm();
        void DisplayConfigureRolePermissionsForm();
        void DisplayConfigureAreaLabelsForm();
        void DisplayTechnicalSiteConfigurationForm();
        void DisplaySapAutoImportConfigurationForm();
        void DisplayConfigureSiteCommunicationsForm();
        void DisplayHoneywellPhdConfigurationForm();
        void DisplaySplashScreen();
        void CloseSplashScreen();
        void DisplayConfigureFunctionalLocationsForm();
        void DisplayFormDropdownsConfigurationForm();

        void DisplayConvertLogBasedDirectivesIntoNewDirectivesForm();
        void DisplayEnableSecurityForNewDirectivesForm();
        //Sarika... Floc structure level changes...9Jan2017
        void DisplayFlocLevelSettingsForm();
        void DisplayGenericTemplateApprovalConfigurationForm();//mangesh - generic template approval 
        void DisplayGenericTemplateEmailApprovalConfigurationForm();//Email approval Sarnia
        //OLT admin lis - mangesh
        void DisplayAdministratorListConfigurationForm();
        void DisplayAdministratorListForm();
        //RITM0164850 Mukesh
        void DisplayConfigureRoleForm();
        void DisplayWorkPermitMudsTemplatesConfigurationForm(); //RITM0301321 mangesh
        void DisplayMudsConfigureWorkPermitGroupsForm(); //RITM0301321 mangesh
    }
}