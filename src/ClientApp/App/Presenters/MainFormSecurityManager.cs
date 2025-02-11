using Com.Suncor.Olt.Client.Controls.ToolStrips;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Section;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class MainFormSecurityManager : IMainFormSecurityManager
    {
        private readonly IAuthorized authorized;
        private readonly IMainForm view;

        public MainFormSecurityManager(IMainForm view, IAuthorized authorized)
        {
            this.view = view;
            this.authorized = authorized;
        }

        public void ApplySecurityToMenuItems(UserRoleElements userRoleElements, SiteConfiguration siteConfiguration)
        {
            ApplyRoleElementSecurityToCreationMenuItems(userRoleElements, siteConfiguration);

            ApplySecurityToFileMenuItems();
            ApplyRoleElementSecurityToReportMenuItems(userRoleElements, siteConfiguration);
            ApplyRoleElementSecurityToAdminMenuItems();
            ApplyRoleElementSecurityToTechnicalAdminMenuItems();
            ApplyOperatingEngineerShiftLogSecurity();
            ApplyConfigureOLTCommunitySecurity();  //olt admin list - mangesh
        }

        public void AddNavigationSections(SiteConfiguration siteConfiguration, UserRoleElements userRoleElements)
        {
            if (authorized.ToViewDirectiveNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.DirectiveSection);
            }
            if (authorized.ToViewActionItemsNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.ActionItemSection);
            }
            if (authorized.ToViewReadingNavigation(userRoleElements))                   //ayman action item reading
            {
                view.AddNavigation(SectionKey.ReadingSection);
            }
            if (authorized.ToViewTargetsNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.TargetSection);
            }
            if (authorized.ToViewRestrictionNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.RestrictionSection);
            }
            if (authorized.ToViewLabAlertsNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.LabAlertSection);
            }
            if (authorized.ToViewEventsNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.EventSection);
            }
            if (authorized.ToViewLogsNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.LogSection);
            }
            if (authorized.ToViewShiftHandoverNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.ShiftHandoverSection);
            }
            if (authorized.ToViewFormNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.FormSection);
            }
            if (authorized.ToViewWorkPermitsNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.WorkPermitSection);
            }
            if (authorized.ToViewOnPremisePersonnelNavigation(userRoleElements))
            {
                view.AddNavigation(SectionKey.OnPremisePersonnelSection);
            }

            //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
            if (ClientSession.GetUserContext().Site.Id == Site.Contruction_Mgnt_ID)
            {
                view.SetShiftLogMenuItemName = StringResources.LogSectionNavigationTextForConstructionSite;
                SectionKey.LogSection.Name = StringResources.LogSectionNavigationTextForConstructionSite;
            }
            else
            {
                view.SetShiftLogMenuItemName = StringResources.LogSectionNavigationText;
                SectionKey.LogSection.Name = StringResources.LogSectionNavigationText;
            }
            //END
        }

        public CreateAction GetActionForSelectedSection(UserRoleElements userRoleElements,
            ISectionRegistry sectionRegistry)
        {
            if (view.SelectedSection == null)
            {
                return CreateAction.CreateNone;
            }
            var selectedSection = view.SelectedSection;

            if (authorized.ToCreateActionItemDefinitions(userRoleElements) && selectedSection == SectionKey.ActionItemSection)
            {
                return CreateAction.CreateActionItemDefinition;
            }
            if (authorized.ToCreateActionItemDefinitions(userRoleElements) && selectedSection == SectionKey.ReadingSection)
            {
                return CreateAction.CreateActionItemDefinition;
            }
            if (authorized.ToCreateTargets(userRoleElements) && selectedSection == SectionKey.TargetSection)
            {
                return CreateAction.CreateTargetDefinition;
            }
            if (authorized.ToCreateRestrictionDefinitions(userRoleElements) &&
                selectedSection == SectionKey.RestrictionSection)
            {
                return CreateAction.CreateRestrictionDefinition;
            }
            if (authorized.ToCreateLabAlertDefinitions(userRoleElements) &&
                selectedSection == SectionKey.LabAlertSection)
            {
                if (sectionRegistry.IsPageVisible(SectionKey.LabAlertSection, PageKey.LAB_ALERT_DEFINITION_PAGE))
                {
                    return CreateAction.CreateLabAlertDefinition;
                }
            }
            else if (selectedSection == SectionKey.LogSection)
            {
                if (authorized.ToCreateSummaryLogs(userRoleElements) &&
                    sectionRegistry.IsPageVisible(SectionKey.LogSection, PageKey.SUMMARY_LOG_PAGE))
                {
                    return CreateAction.CreateShiftSummaryLog;
                }
                if (authorized.ToCreateDirectiveLogs(userRoleElements) &&
                    sectionRegistry.IsPageVisible(SectionKey.LogSection, PageKey.DAILY_DIRECTIVES_LOG_PAGE))
                {
                    return CreateAction.CreateDailyDirective;
                }
                if (authorized.ToCreateDirectiveLogs(userRoleElements) &&
                    sectionRegistry.IsPageVisible(SectionKey.LogSection, PageKey.STANDING_ORDERS_PAGE))
                {
                    return CreateAction.CreateStandingOrder;
                }
                if (authorized.ToCreateCokerCard(userRoleElements) &&
                    sectionRegistry.IsPageVisible(SectionKey.LogSection, PageKey.COKER_CARD_PAGE))
                {
                    return CreateAction.CreateCokerCard;
                }
                if (authorized.ToCreateLogs(userRoleElements) &&
                    sectionRegistry.IsPageVisible(SectionKey.LogSection, PageKey.LOG_DEFINITION_PAGE))
                {
                    return CreateAction.CreateRepeatingLog;
                }
                if (authorized.ToCreateLogs(userRoleElements))
                {
                    return CreateAction.CreateLog;
                }
            }
            else if (authorized.ToCreateShiftHandoverQuestionnaire(userRoleElements) &&
                     selectedSection == SectionKey.ShiftHandoverSection)
            {
                return CreateAction.CreateShiftHandover;
            }
            else if (selectedSection == SectionKey.WorkPermitSection)
            {
                if (sectionRegistry.IsPageVisible(SectionKey.WorkPermitSection, PageKey.PERMIT_REQUEST_PAGE) ||
                    sectionRegistry.IsPageVisible(SectionKey.WorkPermitSection,
                        PageKey.PERMIT_REQUEST_RUNNING_UNIT_PAGE) ||
                    sectionRegistry.IsPageVisible(SectionKey.WorkPermitSection,
                        PageKey.PERMIT_REQUEST_TURNAROUND_PAGE))
                {
                    if (authorized.ToCreatePermitRequest(userRoleElements))
                    {
                        return CreateAction.CreatePermitRequest;
                    }
                }
                else if (sectionRegistry.IsPageVisible(SectionKey.WorkPermitSection, PageKey.CONFINED_SPACE_PAGE))
                {
                    if (authorized.ToCreateConfinedSpace(userRoleElements))
                    {
                        return CreateAction.CreateConfinedSpace;
                    }
                }
                else
                {
                    if (authorized.ToCreateWorkPermits(userRoleElements))
                    {
                        return CreateAction.CreateWorkPermit;
                    }
                }
            }
            else if (selectedSection == SectionKey.FormSection)
            {
                if (authorized.ToCreateForms(userRoleElements, ClientSession.GetUserContext().Site) ||
                    authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(userRoleElements) ||
                    authorized.ToCreateFormDocumentSuggestion(userRoleElements, ClientSession.GetUserContext().SiteId) ||
                    authorized.ToCreateFormProcedureDeviation(userRoleElements, ClientSession.GetUserContext().SiteId))
                {
                    return CreateAction.CreateForm;
                }
            }
            else if (authorized.ToCreateDirectives(userRoleElements) &&
                     selectedSection == SectionKey.DirectiveSection)
            {
                return CreateAction.CreateDirective;
            }

            return CreateAction.CreateNone;
        }

        private void ApplySecurityToFileMenuItems()
        {
            view.PreferencesVisible = PreferencesForm.UserShouldSeePreferencesAtAll(ClientSession.GetUserContext());
        }

        private void ApplyOperatingEngineerShiftLogSecurity()
        {
            var siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;
            view.OperatingEngineerShiftLogReportVisible = siteConfiguration.CreateOperatingEngineerLogs;
            var displayName = siteConfiguration.OperatingEngineerLogDisplayName;
            view.OperatingEngineerShiftLogReportDisplayText = "&" + displayName;
        }

        private void ApplyRoleElementSecurityToCreationMenuItems(UserRoleElements userRoleElements,
            SiteConfiguration siteConfiguration)
        {
            var siteId = siteConfiguration.IdValue;

            var createActionItemsAuthorized = authorized.ToCreateActionItemDefinitions(userRoleElements);
            var createTargetsAuthorized = authorized.ToCreateTargets(userRoleElements);
            var createRestrictionsAuthorized = authorized.ToCreateRestrictionDefinitions(userRoleElements);
            var createLogsAuthorized = authorized.ToCreateLogs(userRoleElements);
            var createRepeatingLogsAuthorized = authorized.ToCreateLogDefinition(userRoleElements);
            var createShiftSummaryLogsAuthorized = authorized.ToCreateSummaryLogs(userRoleElements);
            var createNewDirectivesAuthorized = authorized.ToCreateDirectives(userRoleElements);
            var createDailyDirectivesAuthorized = authorized.ToCreateDirectiveLogs(userRoleElements);
            var createShiftHandoverQuestionnaireAuthorized =
                authorized.ToCreateShiftHandoverQuestionnaire(userRoleElements);
            var createWorkPermitsAuthorized = authorized.ToCreateWorkPermits(userRoleElements);
            var createLabAlertsAuthorized = authorized.ToCreateLabAlertDefinitions(userRoleElements);
            var createCokerCardAuthorized = authorized.ToCreateCokerCard(userRoleElements);
            var createPermitRequestAuthorized = authorized.ToCreatePermitRequest(userRoleElements);
            var createConfinedSpaceAuthorized = authorized.ToCreateConfinedSpace(userRoleElements);

            var createEdmontonFormsAuthorized =
                authorized.ToCreateForms(userRoleElements, ClientSession.GetUserContext().Site)  && siteId == Site.EDMONTON_ID;

            //ayman generic forms
            var createSarniaFormsAuthorized = authorized.ToCreateForms(userRoleElements, ClientSession.GetUserContext().Site) && siteId == Site.SARNIA_ID;

            //ayman Sarnia eip DMND0008992
            var createSarniaEipIssueAuthorized = authorized.ToCreateEipIssue(userRoleElements) && ClientSession.GetUserContext().Site.IdValue == Site.SARNIA_ID;   //ayman 4.37
            var editSarniaEipIssueAuthorized = authorized.ToEditEipIssue(userRoleElements);
            var viewSarniaEipIssueAuthorized = authorized.ToViewEipIssue(userRoleElements);
            var approveSarniaEipIssueAuthorized = authorized.ToApproveEipIssue(userRoleElements);



            //ayman selc
            var createSelcFormsAuthorized =
                authorized.ToCreateForms(userRoleElements, ClientSession.GetUserContext().Site) &&
                siteId == Site.SELC_ID;

            var createOilsandsTrainingFormAuthorized =
                authorized.ToCreateTrainingForm(userRoleElements, ClientSession.GetUserContext().Site) &&
                siteId == Site.OILSAND_ID;
            
            //ayman forthills
            var createForthillsTrainingFormAuthorized =
                authorized.ToCreateTrainingForm(userRoleElements, ClientSession.GetUserContext().Site) &&
                siteId == Site.FORT_HILLS_ID;

            //ayman E&U
            var createSiteWideTrainingFormsAuthorized =
                authorized.ToCreateTrainingForm(userRoleElements, ClientSession.GetUserContext().Site) &&
                siteId == Site.SITE_WIDE_SERVICES_ID;

            //mangesh - ETF
            var createETFTrainingFormAuthorized =
                authorized.ToCreateTrainingForm(userRoleElements, ClientSession.GetUserContext().Site) &&
                siteId == Site.VOYAGEUR_ID;

            var createEdmontonOvertimeFormAuthorized = authorized.ToCreateOvertimeForm(userRoleElements) &&
                                                       siteId == Site.EDMONTON_ID;

            var createLubesCsdAuthorized = authorized.ToCreateLubesCsdForm(userRoleElements) &&
                                           siteId == Site.LUBES_ID;

            var createMontrealCsdAuthorized = authorized.ToCreateMontrealCsdForm(userRoleElements) &&
                                              siteId == Site.MONTREAL_ID;

            // DMND0011225 CSD for WBR
            var createGenericCsdAuthorized = authorized.ToCreateGenericCsdForm(userRoleElements);

            //RITM0268131 - mangesh
            var createMudsTemporaryInstallationsAuthorized = authorized.ToCreateMudsTemporaryInstallationsForm(userRoleElements) &&
                                              siteId == Site.MontrealSulphur_ID;

            var createLubesAlarmDisableAuthorized = authorized.ToCreateLubesAlarmDisableForm(userRoleElements) &&
                                                    siteId == Site.LUBES_ID;

            var createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized =
                authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(userRoleElements) && siteId == Site.OILSAND_ID;

            //ayman forthills questionnaire
            var createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized =
                authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(userRoleElements) && siteId == Site.FORT_HILLS_ID;

            var createFormDocumentSuggestionAuthorized =
                authorized.ToCreateFormDocumentSuggestion(userRoleElements, siteId);

            var createFormProcedureDeviationAuthorized =
                authorized.ToCreateFormProcedureDeviation(userRoleElements, siteId);            

            //ayman sarnia - ayman selc - ayman forthills - ayman E&u  - ayman forthills questionnaire
            var hasAtLeastOneCreateAction = createActionItemsAuthorized || createCokerCardAuthorized ||
                                            createNewDirectivesAuthorized ||
                                            createDailyDirectivesAuthorized || createRepeatingLogsAuthorized ||
                                            createLabAlertsAuthorized || createLogsAuthorized ||
                                            createPermitRequestAuthorized || createRestrictionsAuthorized ||
                                            createShiftHandoverQuestionnaireAuthorized ||
                                            createShiftSummaryLogsAuthorized || createTargetsAuthorized ||
                                            createWorkPermitsAuthorized || createConfinedSpaceAuthorized ||
                                            createEdmontonFormsAuthorized || createOilsandsTrainingFormAuthorized ||
                                            createEdmontonOvertimeFormAuthorized || createLubesCsdAuthorized ||
                                            createMontrealCsdAuthorized || createLubesAlarmDisableAuthorized ||
                                            createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized || 
                                            createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized ||  //ayman forthills questionnaire
                                            createFormDocumentSuggestionAuthorized ||
                                            createFormProcedureDeviationAuthorized || createSarniaFormsAuthorized || createSelcFormsAuthorized || createForthillsTrainingFormAuthorized || createSiteWideTrainingFormsAuthorized ||
                                            createETFTrainingFormAuthorized //mangesh ETF
                                            || createMudsTemporaryInstallationsAuthorized  //RITM0268131 - mangesh
                                            || createGenericCsdAuthorized;


            //generic template - mangesh
            var createEdmontonOdourNoiseFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements,null, EdmontonFormType.OdourNoiseComplaint, ClientSession.GetUserContext().Site) && siteId == Site.EDMONTON_ID;
            var createEdmontonDeviationFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements, null, EdmontonFormType.Deviation, ClientSession.GetUserContext().Site) && siteId == Site.EDMONTON_ID;
            var createEdmontonRoadClosureFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements, null, EdmontonFormType.RoadClosure, ClientSession.GetUserContext().Site) && siteId == Site.EDMONTON_ID;
            var createEdmontonGN11GroundDistrubanceFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements, null, EdmontonFormType.GN11GroundDisturbance, ClientSession.GetUserContext().Site) && siteId == Site.EDMONTON_ID;
            var createEdmontonGN27FreezePlugFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements, null, EdmontonFormType.GN27FreezePlug, ClientSession.GetUserContext().Site) && siteId == Site.EDMONTON_ID;
            var createEdmontonHazardAssessmentFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements, null, EdmontonFormType.HazardAssessment, ClientSession.GetUserContext().Site) && siteId == Site.EDMONTON_ID;

            //TASK0593631 - mangesh
            var createEdmontonNonEmergencyWaterSystemApprovalFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements, null, EdmontonFormType.NonEmergencyWaterSystemApproval, ClientSession.GetUserContext().Site) && siteId == Site.EDMONTON_ID;

            //RITM0341710 mangesh
            var createFortHillOilSampleFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements, null, EdmontonFormType.FortHillOilSample, ClientSession.GetUserContext().Site) && siteId == Site.FORT_HILLS_ID;
            var createFortHillDailyInspectionFormAuthorized =
                authorized.ToCreateFormGenericTemplate(userRoleElements, null, EdmontonFormType.FortHillDailyInspection, ClientSession.GetUserContext().Site) && siteId == Site.FORT_HILLS_ID;
            

            var mainUserStrip = view.UserStrip;

            view.CreateNewItemVisible = hasAtLeastOneCreateAction;
            mainUserStrip.CreateNewItemEnabled = hasAtLeastOneCreateAction;

            if (!hasAtLeastOneCreateAction)
            {
                return;
            }

            view.CreateActionItemVisible = createActionItemsAuthorized;
            mainUserStrip.CreateActionItemVisible = createActionItemsAuthorized;

            view.CreateTargetVisible = createTargetsAuthorized;
            mainUserStrip.CreateTargetVisible = createTargetsAuthorized;

            view.CreateRestrictionVisible = createRestrictionsAuthorized;
            mainUserStrip.CreateRestrictionVisible = createRestrictionsAuthorized;

            view.CreateLogVisible = createLogsAuthorized;
            view.CreateRepeatingLogVisible = createRepeatingLogsAuthorized;

            view.CreateShiftSummaryLogVisible = createShiftSummaryLogsAuthorized;

            view.CreateDirectiveVisible = createNewDirectivesAuthorized;
            view.CreateDailyDirectiveLogEntryVisible = createDailyDirectivesAuthorized &&
                                                       siteConfiguration.UseLogBasedDirectives;

            view.CreateStandingOrdersVisible = createDailyDirectivesAuthorized && siteConfiguration.UseLogBasedDirectives;
            view.CreateCokerCardVisible = createCokerCardAuthorized;
            view.CreateLogSubMenuVisible = createLogsAuthorized || createShiftSummaryLogsAuthorized ||
                                           createDailyDirectivesAuthorized || createCokerCardAuthorized;

            mainUserStrip.CreateDirectiveVisible = createNewDirectivesAuthorized;


            var logBasedDirectivesVisible = createDailyDirectivesAuthorized && siteConfiguration.UseLogBasedDirectives;
            var createStandingOrdersAuthorized = createDailyDirectivesAuthorized &&
                                                 siteConfiguration.UseLogBasedDirectives;
            mainUserStrip.CreateLogVisible(createLogsAuthorized, createShiftSummaryLogsAuthorized,
                logBasedDirectivesVisible, createCokerCardAuthorized, createRepeatingLogsAuthorized,
                createStandingOrdersAuthorized);

            view.CreateShiftHandoverQuestionnaireVisible = createShiftHandoverQuestionnaireAuthorized;
            mainUserStrip.CreateShiftHandoverQuestionnaireVisible = createShiftHandoverQuestionnaireAuthorized;

            view.CreateWorkPermitVisible = createWorkPermitsAuthorized;
            mainUserStrip.CreatePermitVisible = createWorkPermitsAuthorized;

            view.CreatePermitRequestVisible = createPermitRequestAuthorized;
            mainUserStrip.CreatePermitRequestVisible = createPermitRequestAuthorized;

            view.CreateConfinedSpaceVisible = createConfinedSpaceAuthorized;
            mainUserStrip.CreateConfinedSpaceVisible = createConfinedSpaceAuthorized;

            view.CreateLabAlertVisible = createLabAlertsAuthorized;
            mainUserStrip.CreateLabAlertVisible = createLabAlertsAuthorized;

            // DMND0011225 CSD for WBR
            view.CreateGenericCsdVisible = createGenericCsdAuthorized;
            mainUserStrip.CreateGenericCsdItemVisible = createGenericCsdAuthorized;

            //generic template - mangesh
            view.CreateGenericTemplateFormVisible(createEdmontonOdourNoiseFormAuthorized, createEdmontonDeviationFormAuthorized, createEdmontonRoadClosureFormAuthorized,
                                                    createEdmontonGN11GroundDistrubanceFormAuthorized, createEdmontonGN27FreezePlugFormAuthorized, createEdmontonHazardAssessmentFormAuthorized,
                                                    createEdmontonNonEmergencyWaterSystemApprovalFormAuthorized); //TASK0593631 - mangesh
            mainUserStrip.CreateGenericTemplateFormVisible(createEdmontonOdourNoiseFormAuthorized, createEdmontonDeviationFormAuthorized, createEdmontonRoadClosureFormAuthorized,
                                                    createEdmontonGN11GroundDistrubanceFormAuthorized, createEdmontonGN27FreezePlugFormAuthorized, createEdmontonHazardAssessmentFormAuthorized,
                                                    createEdmontonNonEmergencyWaterSystemApprovalFormAuthorized); //TASK0593631 - mangesh

            //ayman sarnia - ayman selc - ayman forthills - ayman E&U

            view.CreateFormsVisible(createEdmontonFormsAuthorized,createSarniaFormsAuthorized, createSelcFormsAuthorized, createForthillsTrainingFormAuthorized, createOilsandsTrainingFormAuthorized,
                createEdmontonOvertimeFormAuthorized, createLubesCsdAuthorized, createMontrealCsdAuthorized,
                createLubesAlarmDisableAuthorized, createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized,
                createFormDocumentSuggestionAuthorized, createFormProcedureDeviationAuthorized, createSiteWideTrainingFormsAuthorized,createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized, //ayman forthills questionnaire
                createETFTrainingFormAuthorized //mangesh ETF
                , createMudsTemporaryInstallationsAuthorized //RITM0268131 - mangesh
                , createFortHillOilSampleFormAuthorized, createFortHillDailyInspectionFormAuthorized,  //RITM0341710 -mangesh
                createGenericCsdAuthorized);

            //INC0398755 : added by Vibhor
            view.CreateEipIssueVisible(createSarniaEipIssueAuthorized);

            //ayman sarnia - ayman selc - ayman forthills - ayman E&u
            mainUserStrip.CreateFormsVisible(createEdmontonFormsAuthorized,createSarniaFormsAuthorized, createSelcFormsAuthorized, createForthillsTrainingFormAuthorized, createOilsandsTrainingFormAuthorized,
                createEdmontonOvertimeFormAuthorized, createLubesCsdAuthorized, createMontrealCsdAuthorized,
                createLubesAlarmDisableAuthorized, createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized,
                createFormDocumentSuggestionAuthorized, createFormProcedureDeviationAuthorized, createSiteWideTrainingFormsAuthorized, createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized,  //ayman forthills questionnaire
                createETFTrainingFormAuthorized,
                createMudsTemporaryInstallationsAuthorized,  //RITM0268131 - mangesh
                createFortHillOilSampleFormAuthorized, createFortHillDailyInspectionFormAuthorized, createGenericCsdAuthorized); //RITM0341710 -mangesh

            mainUserStrip.CreateEipIssueVisible(createSarniaEipIssueAuthorized);        //ayman Sarnia eip DMND0008992


        }

        private void ApplyRoleElementSecurityToReportMenuItems(UserRoleElements elements,
            SiteConfiguration siteConfiguration)
        {
            view.RestrictionReportsVisible = authorized.ToViewRestrictionReporting(elements);

            view.LogReportsVisible = authorized.ToViewLogs(elements) ||
                                     (siteConfiguration.UseLogBasedDirectives &&
                                      authorized.ToViewDirectiveLogs(elements)) ||
                                     authorized.ToViewSummaryLogs(elements);

            view.CokerCardReportsVisible = authorized.ToViewCokerCards(elements);
            
            view.TargetReportsVisible = authorized.ToViewTargetAlerts(elements);

            view.ShiftHandoverReportsVisible = authorized.ToViewShiftHandover(elements);

            // ayman reports
            view.FormReportsVisible = authorized.ToViewFormReport(elements);

            view.TrainingFormExcelVisible = authorized.ToViewTrainingFormExcel(elements); //siteConfiguration.IdValue == Site.FORT_HILLS_ID; //Site.OILSAND_ID;
            view.TrainingFormReportVisible = authorized.ToViewTrainingFormReport(elements); //siteConfiguration.IdValue == Site.FORT_HILLS_ID; //siteConfiguration.IdValue == Site.OILSAND_ID; ayman temp
            view.OnPremisePersonnelReportVisible = authorized.ToViewOnPremisePersonnelNavigation(elements);
            /*RITM0265746 - Sarnia CSD marked as read start */
            view.FormOP14MarkAsReadReportVisible = authorized.ToViewFormReport(elements);
            /*RITM0265746 - Sarnia CSD marked as read end */
            view.SafeWorkPermitMenuItemVisible = ClientSession.GetUserContext().IsLubesSite;

            //INC0458108 : added by Vibhor

            if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                view.CSDMarkAsReadReportForSarnia = StringResources.CSDMarkAsReadReportForSarnia;
            }
            else
            {
                view.CSDMarkAsReadReportForSarnia = StringResources.CSDMarkAsReadReportForOtherSite;
            }

            view.DirectiveReportsVisible = authorized.ToViewDirectives(elements);

            //ayman reports
            view.SafeWorkPermitAssessmentReportVisible = authorized.ToViewSWPAssessmentReport(elements);

            ///// <summary>
            ///// Changed for: RITM0088705
            ///// Changed By: Komal Sahu (ksahu)
            ///// Changed Date: 15/03/2017
            ///// </summary>
            ///// Change starts/////////
            ////if(siteConfiguration.IdValue == Site.EDMONTON_ID)                 // as Aditya asked it should be controlled thru role matrix
            ////view.SafeWorkPermitAssessmentReportVisible = false;
            ///// Change Ends/////////
        }

        private void ApplyRoleElementSecurityToAdminMenuItems()
        {
            var anyAdministrationConfigurationsAllowed =
                ConfigureSecurityForItemsInPrioritiesAdminSection() |
                ConfigureSecurityForItemsInActionItemsAdminSection() |
                ConfigureSecurityForItemsInLogsAdminSection() |
                ConfigureSecurityForItemsInLabAlertsAdminSection() |
                ConfigureSecurityForItemsInRestrictionsAdminSection() |
                ConfigureSecurityForItemInTargetsAdminSection() |
                ConfigureSecurityForItemsInShiftHandoverAdminSection() |
                ConfigureSecurityForItemsInCokerCardsAdminSection() |
                ConfigureSecurityForItemsInWorkPermitAdminSection() |
                ConfigureSecurityForItemsInDisplaySettingsAdminSection() |
                ConfigureSecurityForItemsInWorkAssignmentAdminSection() |
                ConfigureSecurityForItemsInSiteConfigurationAdminSection() |
                ConfigureSecurityForItemsInFormAdminSection();

            view.AdminstrationVisible(anyAdministrationConfigurationsAllowed);
        }

        private void ApplyRoleElementSecurityToTechnicalAdminMenuItems()
        {
            var userContext = ClientSession.GetUserContext();
            view.ConfigureSapAutoImportVisible = userContext.IsEdmontonSite || userContext.IsLubesSite;

            var anyAdministrationConfigurationsAllowed =
                authorized.ToPerformTechnicalAdminTasks(userContext.UserRoleElements);
            view.TechnicalAdminstrationVisible(anyAdministrationConfigurationsAllowed);
        }

        private bool ConfigureSecurityForItemsInSiteConfigurationAdminSection()
        {
            var anySiteConfigurationMenuItemsAllowed =
                ApplyManageOperationalModeSecurity() |
                ApplyConfigureRestrictionFlocsForWorkAssignments() |
                ApplyLinkConfigurationSecurity() |
                ApplyConfigureSiteCommunicationsSecurity() |
                ApplyConfigureFunctionalLocations();

            view.SiteConfigurationAdminSectionVisible = anySiteConfigurationMenuItemsAllowed;
            return anySiteConfigurationMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInWorkAssignmentAdminSection()
        {
            var anyAssignmentMenuItemsAllowed = ApplyConfigureWorkAssignmentNotSelectedWarningSecurity() |
                                                ApplyConfigureDefaultFlocsForAssignments() |
                                                ApplyConfigureWorkAssignmentSecurity() |
                                                ApplyConfigureVisibilityGroupSecurity();

            view.WorkAssignmentAdminSectionVisible = anyAssignmentMenuItemsAllowed;
            return anyAssignmentMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInDisplaySettingsAdminSection()
        {
            var anyDisplaySettingsMenuItemsAllowed = ApplyConfigureDisplayLimitsSecurity() |
                                                     ApplyConfigureDisplayDefaultTabsSecurity();

            view.DisplaySettingsAdminSectionVisible = anyDisplaySettingsMenuItemsAllowed;
            return anyDisplaySettingsMenuItemsAllowed;
        }
        //sarika

        //private bool ConfigureSecurityForItemsFlocLevelSettingsAdminSection()
        //{
        //    var anyDisplaySettingsMenuItemsAllowed = ApplyConfigureDisplayLimitsSecurity();
        //    view.DisplaySettingsAdminSectionVisible = anyDisplaySettingsMenuItemsAllowed;
        //    return anyDisplaySettingsMenuItemsAllowed;
        //}

        private bool ConfigureSecurityForItemsInCokerCardsAdminSection()
        {
            var anyCokerCardMenuItemsAllowed = ApplyEditCokerCardConfigurationSecurity();
            view.CokerCardAdminSectionvisible = anyCokerCardMenuItemsAllowed;
            return anyCokerCardMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInShiftHandoverAdminSection()
        {
            var anyHandoverMenuItemsAllowed = ApplyEditShiftHandoverConfigurationSecurity() |
                                              ApplyEditShiftHandoverEmailConfigurationSecurity();

            view.ShiftHandoverAdminSectionVisible = anyHandoverMenuItemsAllowed;
            return anyHandoverMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInFormAdminSection()
        {
            var anyFormMenuItemsAllowed = ApplyConfigureFormTemplateSecurity() |
                                          ApplyConfigureTrainingBlockSecurity() |
                                          ApplyConfigurePermitAssessmentQuestionnaireSecurity() |
                                          ApplyConfigureFormDropdownsSecurity();

            view.FormsAdminSectionVisible = anyFormMenuItemsAllowed;
            return anyFormMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInWorkPermitAdminSection()
        {
            var anyPermitMenuItemsAllowed =
                ApplyConfigGasTestLimitsSecurity() |
                ApplyConfigureWorkPermitArchivalProcess() |
                ApplyConfigureWorkPermitContractorsSecurity() |
                ApplyConfigureCraftOrTradeSecurity() |
                ApplyConfigureWorkPermitMontrealTemplateSecurity() |
                ApplyConfigureDefaultFlocsForAssignmentsForPermitAutoAssignment() |
                ApplyConfigureAssignmentsForPermits() |
                ApplyConfigureWorkPermitDropdownsSecurity() |
                ApplyConfigureConfiguredDocumentLinksSecurity() |
                ApplyAreaLabelConfigurationSecurity() |
                ApplyConfigureWorkPermitGroupsSecurity() |
                ApplyConfigureWorkPermitOilsandsContractorListSecurity() |
                ApplyConfigureWorkPermitOilsandsTradeListSecurity() |
                ApplyConfigureRoadAccessOnPermit() | 
                ApplyConfigureSpecialWork ();

            view.SafeWorkPermitsAdminSectionVisible = anyPermitMenuItemsAllowed;
            return anyPermitMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemInTargetsAdminSection()
        {
            var anyTargetMenuItemsAllowed = ApplyConfigureAutoReApprovalByField() |
                                            ApplyConfigurePlantHistorianTagList();

            view.TargetsAdminSectionVisible = anyTargetMenuItemsAllowed;
            return anyTargetMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInRestrictionsAdminSection()
        {
            var anyRestrictionMenuItemsAllowed = ApplyConfigureRestrictionReasonCodeSecurity() |
                                                 ApplyConfigureDeviationAlertResponseTimeLimitSecurity();

            view.RestrictionReportingAdminSectionVisible = anyRestrictionMenuItemsAllowed;
            return anyRestrictionMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInLabAlertsAdminSection()
        {
            var anyLabAlertMenuItemsAllowed = ApplyLabAlertConfigurationSecurity();

            view.LabAlertsAdminSectionVisible = anyLabAlertMenuItemsAllowed;
            return anyLabAlertMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInLogsAdminSection()
        {
            var anyLogMenuItemsAllowed = ApplyConfigureLogGuidelinesSecurity() |
                                         ApplyConfigureLogTemplatesSecurity() |
                                         ApplyConfigureCustomFieldsSecurity() |
                                         ApplyConfigureDORCutoffTimeSecurity();

            view.LogsAdminSectionVisible = anyLogMenuItemsAllowed;
            return anyLogMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInActionItemsAdminSection()
        {
            var anyActionItemMenuItemsAllowed = ApplyConfigureAutoApproveSapActionItemDefinition() |
                                                ApplyConfigureBusinessCategorySecurity() |
                                                ApplyConfigureBusinessCategoryFlocAssociationSecurity() |
                                                ApplyConfigureAutoReApprovalByField();

            view.ActionItemsAdminSectionVisible = anyActionItemMenuItemsAllowed;
            return anyActionItemMenuItemsAllowed;
        }

        private bool ConfigureSecurityForItemsInPrioritiesAdminSection()
        {
            var anyPrioritiesMenuItemsAllowed = ApplyConfigurePrioritiesPage();

            view.PrioritiesAdminSectionVisible = anyPrioritiesMenuItemsAllowed;
            return anyPrioritiesMenuItemsAllowed;
        }

        private bool ApplyConfigGasTestLimitsSecurity()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToConfigureGasTestElementLimits(user);
            view.ConfigureGasTestLimitsEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyConfigureFunctionalLocations()
        {
            var roleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToConfigureFunctionalLocations(roleElements);
            view.ConfigureFunctionalLocationsEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyManageOperationalModeSecurity()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToManageOperationalModes(user);
            view.ConfigureOperationalModeEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyConfigureRestrictionFlocsForWorkAssignments()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToConfigureRestrictionFlocsForWorkAssignments(user);
            view.ConfigureRestrictionFlocsForWorkAssignmentsEnabled = isAuthorized;
            return isAuthorized;
        }



        private bool ApplyConfigureDisplayLimitsSecurity()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureFlocLevelEnabled = authorized.ToConfigureDisplayLimits(user);
            return authorized.ToConfigureDisplayLimits(user);
        }
        /////Sarika... Floc structure level changes...9Jan2017
        //private bool ApplyConfigureFlocLevelSettings()
        //{
        //    var user = ClientSession.GetUserContext().UserRoleElements;
        //    view.ConfigureFlocLevelEnabled = authorized.ToConfigureFlocLevelSettings(user);
        //    return authorized.ToConfigureFlocLevelSettings(user);
        //}

        private bool ApplyConfigureDisplayDefaultTabsSecurity()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureDefaultTabsEnabled = authorized.ToConfigureDefaultTabs(user);
            return authorized.ToConfigureDefaultTabs(user);
        }

        private bool ApplyConfigureWorkAssignmentNotSelectedWarningSecurity()
        {
            var roleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureWorkAssignmentNotSelectedWarningEnabled =
                authorized.ToConfigureWorkAssignmentNotSelectedWarning(roleElements);
            return authorized.ToConfigureWorkAssignmentNotSelectedWarning(roleElements);
        }

        private bool ApplyLinkConfigurationSecurity()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            var isAllowedToConfigureLinks = authorized.ToConfigureLinks(user);
            view.ConfigureLinkConfigurationEnabled = isAllowedToConfigureLinks;
            return isAllowedToConfigureLinks;
        }

        private bool ApplyConfigureSiteCommunicationsSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var configureSiteCommunicationsEnabled = authorized.ToConfigureSiteCommunications(userRoleElements);
            view.ConfigureSiteCommunicationsEnabled = configureSiteCommunicationsEnabled;
            return configureSiteCommunicationsEnabled;
        }

        private bool ApplyAreaLabelConfigurationSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAllowedToConfigureAreaLabels = authorized.ToConfigureAreaLabels(userRoleElements);
            view.ConfigureAreaLabelsEnabled = isAllowedToConfigureAreaLabels;
            return isAllowedToConfigureAreaLabels;
        }

        private bool ApplyLabAlertConfigurationSecurity()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureLabAlertsEnabled = authorized.ToConfigureLabAlerts(user);
            return authorized.ToConfigureLabAlerts(user);
        }

        private bool ApplyConfigureWorkPermitArchivalProcess()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureWorkPermitArchivalProcessEnabled = authorized.ToConfigureWorkPermitArchivalProcess(user);
            return authorized.ToConfigureWorkPermitArchivalProcess(user);
        }

        private bool ApplyConfigureAutoApproveSapActionItemDefinition()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureAutoApproveSAPAIDEnabled = authorized.ToConfigureAutoApproveSAPActionItemDefinition(user);
            return authorized.ToConfigureAutoApproveSAPActionItemDefinition(user);
        }

        private bool ApplyConfigureWorkPermitContractorsSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureWorkPermitContractorEnabled = authorized.ToConfigureWorkPermitContractor(userRoleElements);
            return authorized.ToConfigureWorkPermitContractor(userRoleElements);
        }

        private bool ApplyConfigureWorkPermitOilsandsContractorListSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            return userRoleElements.AuthorizedTo(RoleElement.ADMIN_FORM_SWP);
        }

        private bool ApplyConfigureWorkPermitOilsandsTradeListSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            return userRoleElements.AuthorizedTo(RoleElement.ADMIN_FORM_SWP);
        }

        private bool ApplyConfigureDefaultFlocsForAssignments()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureDefaultFLOCsForDailyAssignmentsEnabled =
                authorized.ToConfigureDefaultFLOCsForAssignments(userRoleElements);
            return authorized.ToConfigureDefaultFLOCsForAssignments(userRoleElements);
        }

        private bool ApplyConfigureDefaultFlocsForAssignmentsForPermitAutoAssignment()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureAssociateWorkAssignmentsToFLOCsForPermitAutoAssignmentEnabled =
                authorized.ToConfigureDefaultFLOCsForAssignmentsForPermitAutoAssignment(userRoleElements);
            return authorized.ToConfigureDefaultFLOCsForAssignmentsForPermitAutoAssignment(userRoleElements);
        }

        private bool ApplyConfigureAssignmentsForPermits()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureAssociateWorkAssignmentsForPermitsEnabled =
                authorized.ToConfigureAssignmentsForPermits(userRoleElements);
            return authorized.ToConfigureAssignmentsForPermits(userRoleElements);
        }

        private bool ApplyConfigurePrioritiesPage()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var configurePriorityPageEnabled = authorized.ToConfigurePrioritiesPage(userRoleElements);
            view.ConfigurePriorityPageEnabled = configurePriorityPageEnabled;
            return configurePriorityPageEnabled;
        }

        private bool ApplyConfigurePlantHistorianTagList()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigurePlantHistorianTagListEnabled = authorized.ToConfigurePlantHistorianTagList(userRoleElements);
            return authorized.ToConfigurePlantHistorianTagList(userRoleElements);
        }

        private bool ApplyConfigureWorkAssignmentSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureWorkAssignmentsEnabled = authorized.ToConfigureWorkAssignments(userRoleElements);
            return authorized.ToConfigureWorkAssignments(userRoleElements);
        }

        private bool ApplyConfigureVisibilityGroupSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureVisibilityGroupsEnabled = authorized.ToConfigureWorkAssignments(userRoleElements);
            // this uses work assignment authorization intentionally
            return authorized.ToConfigureWorkAssignments(userRoleElements);
        }

        private bool ApplyConfigureBusinessCategorySecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureBusinessCategoriesEnabled = authorized.ToConfigureBusinessCategories(userRoleElements);
            return authorized.ToConfigureBusinessCategories(userRoleElements);
        }

        private bool ApplyConfigureLogGuidelinesSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToConfigureLogGuidelines(userRoleElements);
            view.ConfigureLogGuidelinesEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyConfigureLogTemplatesSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToConfigureLogTemplates(userRoleElements);
            view.ConfigureLogTemplatesEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyConfigureCustomFieldsSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToConfigureCustomFields(userRoleElements);
            view.ConfigureCustomFieldsEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyEditShiftHandoverConfigurationSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToEditShiftHandoverConfigurations(userRoleElements);
            view.ConfigureShiftHandoverEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyEditShiftHandoverEmailConfigurationSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToEditShiftHandoverEmailConfigurations(userRoleElements);
            view.ConfigureShiftHandoverEmailEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyEditCokerCardConfigurationSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToEditCokerCardConfigurations(userRoleElements);
            view.ConfigureCokerCardsEnabled = isAuthorized;
            return isAuthorized;
        }

        private bool ApplyConfigureDORCutoffTimeSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var isAuthorized = authorized.ToConfigureDORCutoffTime(userRoleElements);
            view.ConfigureDORCutoffTimeEnabled = isAuthorized;
            view.ConfigureDORCutoffTimeVisible = !ClientSession.GetUserContext().SiteConfiguration.HideDORCommentEntry;
            return isAuthorized;
        }

        private bool ApplyConfigureBusinessCategoryFlocAssociationSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureBusinessCategoryFlocAssociationsEnabled =
                authorized.ToConfigureBusinessCategoryFlocAssociations(userRoleElements);
            return authorized.ToConfigureBusinessCategoryFlocAssociations(userRoleElements);
        }

        private bool ApplyConfigureRestrictionReasonCodeSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var configureRestrictionReasonCodeEnabled = authorized.ToConfigureRestrictionReasonCode(userRoleElements);
            view.ConfigureRestrictionReasonCodeEnabled = configureRestrictionReasonCodeEnabled;
            view.ConfigurationRestrictionListsEnabled = configureRestrictionReasonCodeEnabled;
            return configureRestrictionReasonCodeEnabled;
        }

        private bool ApplyConfigureDeviationAlertResponseTimeLimitSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureDeviationAlertResponseTimeLimitEnabled =
                authorized.ToConfigureDeviationAlertResponseTimeLimit(userRoleElements);
            return authorized.ToConfigureDeviationAlertResponseTimeLimit(userRoleElements);
        }

        private bool ApplyConfigureAutoReApprovalByField()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureAutoReApprovalByFieldEnabled = authorized.ToConfigureAutoReApprovalByField(userRoleElements);
            return authorized.ToConfigureAutoReApprovalByField(userRoleElements);
        }

        private bool ApplyConfigureCraftOrTradeSecurity() //ayman forthills cleaned the code
        {
            bool retuenValue = false;
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureCraftOrTradeEnabled = authorized.ToConfigureCraftOrTrade(userRoleElements);
            return authorized.ToConfigureCraftOrTrade(userRoleElements);
        }

        private bool ApplyConfigureRoadAccessOnPermit()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureRoadAccessOnPermitEnabled = authorized.ToConfigureRoadAccessOnPermit(userRoleElements);
            return authorized.ToConfigureRoadAccessOnPermit(userRoleElements);
        }

        private bool ApplyConfigureSpecialWork()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureSpecialWorkEnabled = authorized.ToConfigureSpecialWork(userRoleElements);
            return authorized.ToConfigureSpecialWork(userRoleElements);
        }

        private bool ApplyConfigureWorkPermitMontrealTemplateSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            view.ConfigureWorkPermitMontrealTemplatesEnabled =
                authorized.ToConfigureWorkPermitMontrealTemplates(userRoleElements);

            //view.ConfigureWorkPermitMontrealTemplatesEnabled = true; // TODO delete this line after testing RITM0301321

            return authorized.ToConfigureWorkPermitMontrealTemplates(userRoleElements);
        }

        private bool ApplyConfigureFormDropdownsSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var authorizedToConfigureFormDropdowns = authorized.ToConfigureFormDropdowns(userRoleElements);
            view.ConfigureFormDropdownsEnabled = authorizedToConfigureFormDropdowns;
            return authorizedToConfigureFormDropdowns;
        }

        private bool ApplyConfigureWorkPermitDropdownsSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var authorizedToConfigureWorkPermitDropdowns = authorized.ToConfigureWorkPermitDropdowns(userRoleElements);
            view.ConfigureWorkPermitMontrealDropdownsEnabled = authorizedToConfigureWorkPermitDropdowns;
            return authorizedToConfigureWorkPermitDropdowns;
        }

        private bool ApplyConfigureWorkPermitGroupsSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var authorizedTo = authorized.ToConfigureWorkPermitGroups(userRoleElements);
            view.ConfigureWorkPermitGroupsEnabled = authorizedTo;
            return authorizedTo;
        }

        private bool ApplyConfigureConfiguredDocumentLinksSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var authorizedToConfigureConfiguredDocumentLinks =
                authorized.ToConfigureConfiguredDocumentLinks(userRoleElements);
            view.ConfigureConfiguredDocumentLinksEnabled = authorizedToConfigureConfiguredDocumentLinks;
            return authorizedToConfigureConfiguredDocumentLinks;
        }

        private bool ApplyConfigureFormTemplateSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var authorizedToConfigureFormTemplates = authorized.ToConfigureFormTemplates(userRoleElements);
            view.ConfigureFormTemplatesEnabled = authorizedToConfigureFormTemplates;
            view.ConfigureGenericTemplateApprovalEnabled = authorizedToConfigureFormTemplates; //generic template approver - mangesh
            return authorizedToConfigureFormTemplates;
        }

        //olt admin - list - mangesh
        private bool ApplyConfigureOLTCommunitySecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var authorizedToConfigureOltCommunity = authorized.ToConfigureOltCommunity(userRoleElements);
            view.ConfigureOltCommunityEnabled = authorizedToConfigureOltCommunity;
            return authorizedToConfigureOltCommunity;
        }

        //generic template mangesh
        //TODO- to check to implement this functionality or not(to control by admin or not)
        private bool ApplyConfigureEFormTemplateApprovalSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var authorizedToConfigureEFormTemplatesApproval = authorized.ToConfigureEFormTemplatesApproval(userRoleElements);
            view.ConfigureGenericTemplateApprovalEnabled = authorizedToConfigureEFormTemplatesApproval;
            return authorizedToConfigureEFormTemplatesApproval;
        }

        private bool ApplyConfigureTrainingBlockSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var authorizedToConfigureTrainingBlocks = authorized.ToConfigureTrainingBlocks(userRoleElements);
            view.ConfigureTrainingBlocksEnabled = authorizedToConfigureTrainingBlocks;
            return authorizedToConfigureTrainingBlocks;
        }

        private bool ApplyConfigurePermitAssessmentQuestionnaireSecurity()
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            var adminSafeWorkPermitQuestionnaires = authorized.ToAdminSafeWorkPermitQuestionnaires(userRoleElements);
            view.AdminSafeWorkPermitQuestionnairesEnabled = adminSafeWorkPermitQuestionnaires;
            return adminSafeWorkPermitQuestionnaires;
        }
    }

    public enum CreateAction
    {
        CreateNone,
        CreateActionItemDefinition,
        CreateTargetDefinition,
        CreateRestrictionDefinition,
        CreateLabAlertDefinition,
        CreateShiftSummaryLog,
        CreateDailyDirective,
        CreateCokerCard,
        CreateLog,
        CreateShiftHandover,
        CreatePermitRequest,
        CreateWorkPermit,
        CreateConfinedSpace,
        CreateStandingOrder,
        CreateRepeatingLog,
        CreateForm,
        CreateDirective,
        CreateFormSafeWorkPermitAuditQuestionnaire,
        CreateFormDocumentSuggestion,
        CreateFormProcedureDeviation
    }
}