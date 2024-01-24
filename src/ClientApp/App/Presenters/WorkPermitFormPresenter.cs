using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitFormPresenter<T> : AbstractFormPresenter<T, WorkPermit> where T : IWorkPermitFormView
    {
        private readonly IWorkPermitService service;
        private readonly ICraftOrTradeService serviceCraftOrTrade;
        private readonly IContractorService contractorService;
        private readonly IGasTestElementInfoService gasTestElementInfoService;
        private readonly IWorkAssignmentService workAssignmentService;
        private readonly IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfiguration;
        private readonly IDictionary<IGasTestElementDetails, GasTestElement> detailsToGasTestElementTable;
        private readonly IAuthorized authorized;
        private readonly IWorkPermitBinder workPermitBinder;
        private readonly IFunctionalLocationService functionalLocationService;
        public bool gasTestFlag = false;

        private readonly WorkPermitFormSiteSpecificEventHandler workPermitFormSpecificSiteEventHandler;

        private List<GasTestElementInfo> standardGasTestElementInfoList;
        private List<WorkAssignment> allWorkAssignmentsForUserFlocs = new List<WorkAssignment>();
        private List<CraftOrTrade> craftOrTrades;
        private List<Contractor> contractors;

        public WorkPermitFormPresenter(T view, WorkPermit editItem) : this(
            view,
            editItem,
            new Authorized(), 
            new WorkPermitBinder(ClientSession.GetUserContext().SiteId),
            ClientServiceRegistry.Instance.GetService<IWorkPermitService>(),
            ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>(),
            ClientServiceRegistry.Instance.GetService<IContractorService>(),
            ClientServiceRegistry.Instance.GetService<IGasTestElementInfoService>(),
            ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>(),
            ClientServiceRegistry.Instance.GetService<IWorkPermitAutoAssignmentConfigurationService>(),
            ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>())
        {
        }

        public WorkPermitFormPresenter(
            T view,
            WorkPermit editItem,
            IAuthorized authorized,
            IWorkPermitBinder workPermitBinder,
            IWorkPermitService service,
            ICraftOrTradeService serviceCraftOrTrade,
            IContractorService contractorService,
            IGasTestElementInfoService gasTestElementInfoService,
            IWorkAssignmentService workAssignmentService,
            IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfiguration,
            IFunctionalLocationService functionalLocationService)
            : base(view, editItem)
        {
            this.workPermitBinder = workPermitBinder;

            this.authorized = authorized;
            workPermitFormSpecificSiteEventHandler = WorkPermitFormSiteSpecificEventHandler.Create(view);
            this.service = service;
            this.serviceCraftOrTrade = serviceCraftOrTrade;
            this.contractorService = contractorService;
            this.gasTestElementInfoService = gasTestElementInfoService;
            this.workAssignmentService = workAssignmentService;
            this.functionalLocationService = functionalLocationService;
            this.workPermitAutoAssignmentConfiguration = workPermitAutoAssignmentConfiguration;

            detailsToGasTestElementTable = new Dictionary<IGasTestElementDetails, GasTestElement>();
            QueryStandardGasTestElementInfoList();
        }

        private const bool AlwaysGiveAccess = true;

        private void EnableFormByAuthorizedUser()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            
            bool hasFullAccess = authorized.ToCreateWorkPermitsWithNoRestriction(userRoleElements);

            view.SetEnableOnWorkPermitSection(WorkPermitSection.PermitType, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.PermitAttributes, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.PermitTypeAndAttributes, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.AdditionalForms, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.LocationJobSpecificsScope, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.EquipmentPreparationCondition, hasFullAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.JobWorksitePreparation, hasFullAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.RadiationInformation, hasFullAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.Asbestos, hasFullAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.FireConfinedSpaceRequirements, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.RespiratoryProtectionRequirements, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.SpecialPPERequirements, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.SpecialPrecautionsOrConsiderations, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.GasTests, hasFullAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.NotificationAuthorization, AlwaysGiveAccess);
            view.SetEnableOnWorkPermitSection(WorkPermitSection.Miscellaneous, AlwaysGiveAccess);
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            LoadData(new List<Action> { QueryCraftOrTrades, QueryContractors, QueryWorkAssignments });
        }

        protected override void AfterDataLoad()
        {
            view.InitializeStandardGasTestElementInfoList(standardGasTestElementInfoList);

            EnableFormByAuthorizedUser();
            view.EquipmentConditionPurgedMethodTextBoxEnabled = false;

            view.CraftOrTrades = craftOrTrades;
            view.AcidClothingTypes = AcidClothingType.All; // These are only used in Sarnia. The Denver implementation is empty.
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.CreateOrEditWorkPermitFormTitle);
            view.ExpandOrCollapseGroups(true);

            view.Contractors = contractors;
            view.ViewEditHistoryEnabled = IsEdit;

            if (view.HasWorkAssignmentFunctionality)
            {
                view.WorkAssignmentSelectionList = allWorkAssignmentsForUserFlocs;
            }

            if (IsEdit)
            {
                UpdateViewFromEditObject();
            }
            else if (IsCloneOrCopy())
            {
                UpdateViewFromEditObject();
                view.StartTimeNotApplicable = true;
            }
            else
            {
                UpdateViewWithDefaults();
            }

            view.SetInitialFocus();
            view.RegisterUIEventHandlers(this);

            if (view.WorkPermitType == WorkPermitType.HOT && editObject.SapOperationId !=null) //DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
            {
                workPermitFormSpecificSiteEventHandler.HandlePermitTypeHotCheckChanged();
            }
            
        }

        private void QueryWorkAssignments()
        {
            if (!view.HasWorkAssignmentFunctionality)
            {
                return;
            }

            allWorkAssignmentsForUserFlocs = workAssignmentService.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(userContext.RootFlocSet);

            allWorkAssignmentsForUserFlocs.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.CurrentCulture));

            if (IsEdit && editObject.WorkAssignment != null && !allWorkAssignmentsForUserFlocs.ExistsById(editObject.WorkAssignment))
            {
                allWorkAssignmentsForUserFlocs.Add(editObject.WorkAssignment);
            }

            allWorkAssignmentsForUserFlocs.Insert(0, WorkAssignment.NoneWorkAssignment);
        }

        private void QueryStandardGasTestElementInfoList()
        {
            standardGasTestElementInfoList = gasTestElementInfoService.QueryStandardElementInfosBySiteId(ClientSession.GetUserContext().SiteId);
        }

        private void QueryContractors()
        {
            contractors = contractorService.QueryBySite(userContext.Site);
        }

        private void QueryCraftOrTrades()
        {
            craftOrTrades = serviceCraftOrTrade.QueryBySite(userContext.Site);
        }

        private bool IsCloneOrCopy()
        {
            return (editObject != null) && (editObject.IsInDatabase() == false);
        }

        private void SetValuesOnWorkPermit(WorkPermit workPermit)
        {
            // This maps view to the model automatically for almost every property.
            workPermitBinder.ToModel(view, workPermit, Common.Utility.Constants.CURRENT_VERSION);
            workPermit.Version = Common.Utility.Constants.CURRENT_VERSION;

            // These following are a bit odd in terms of being able to using reflection to map the domain object to the view.
            // In general, use the Binder class.
            workPermit.LastModifiedBy = ClientSession.GetUserContext().User;

            SaveWorkItemGasTests(workPermit.GasTests);
        }

        /// <summary>
        /// Get the data from the view and update the working domain object
        /// </summary>
        private void UpdateEditWorkPermitFromView()
        {
            SetValuesOnWorkPermit(editObject);
        }

        private void SaveWorkItemGasTests(WorkPermitGasTests gasTests)
        {
            List<IGasTestElementDetails> gasTestElementDetailsList = view.GasTestElementDetailsList;
            foreach(IGasTestElementDetails details in gasTestElementDetailsList)
            {
                GasTestElement element;
                if (detailsToGasTestElementTable.Keys.Contains(details) == false)
                {
                    GasTestElementInfo info;
                    if (details.IsStandard)
                    {
                        long? detailElementInfoId = details.GasTestElementInfoId;
                        info = FindStandardGasTestElementInfoById(detailElementInfoId);
                    }
                    else
                    {
                        Site site = ClientSession.GetUserContext().Site;
                        info = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                        //info = GasTestElementInfo.CreateOtherGasTestElementInfo_Other(site);
                    }
                    element = GasTestElement.CreateGasTestElement(info);
                    detailsToGasTestElementTable.Add(details, element);
                }
                else
                {
                    element = detailsToGasTestElementTable[details];
                }

                SaveGasTestElement(details, element);
                if (element.HasData() && gasTests.Elements.Contains(element) == false)
                {
                    gasTests.Elements.Add(element);
                }
                else if (element.HasData() == false && gasTests.Elements.Contains(element))
                {
                    gasTests.Elements.Remove(element);
                }
            }
        }

        private static void SaveGasTestElement(IGasTestElementDetails details, GasTestElement element)
        {
            element.ImmediateAreaTestResult = details.ImmediateAreaTestResult;
            element.ImmediateAreaTestRequired = details.ImmediateAreaTestRequired;
            element.ConfinedSpaceTestResult = details.ConfinedSpaceTestResult;
            element.ConfinedSpaceTestRequired = details.ConfinedSpaceTestRequired;
            element.SystemEntryTestResult = details.SystemEntryTestResult;
            element.SystemEntryTestNotApplicable= details.SystemEntryTestNotApplicable;
            
            if (element.ElementInfo.IsStandard == false)
            {
                element.ElementInfo.OtherLimits = details.Limits;
                element.ElementInfo.Name = details.ElementName;
                element.ElementInfo.Name = details.ElementNameOther;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                
            }
        }

        private void SaveWorkPermitAttributes(WorkPermitAttributes attributes)
        {
            attributes.IsConfinedSpaceEntry = view.IsConfinedSpaceEntry;
            attributes.IsVehicleEntry = view.IsVehicleEntry;
            attributes.IsBurnOrOpenFlame = view.IsBurnOrOpenFlame;
            attributes.IsExcavation = view.IsExcavation;
            attributes.IsAsbestos = view.IsAsbestos;
            attributes.IsRadiationRadiography = view.IsRadiationRadiography;
            attributes.IsFreshAir = view.IsFreshAir;
        }

        /// <summary>
        /// Push the data from the working domain object on to the view
        /// </summary>
        private void UpdateViewFromEditObject()
        {
            if (editObject.StartAndOrEndTimesFinalized == false)
            {
                UserShift currentShift = userContext.UserShift;
                //Changes for CRM SO # 8003676816 On 18Aug2016 by Dharmesh_s               
                UserShift shiftOnPermitStartDate = currentShift.RollToStartDate(currentShift.StartDate);
                //UserShift shiftOnPermitStartDate = currentShift.RollToStartDate(editObject.StartDate); //dharmesh
                //Changes for CRM SO # 8003676816 On 18Aug2016 by Dharmesh_e   
                editObject.Specifics.ReInitializeStartAndOrEndDateTimes(ClientSession.GetUserContext().User.WorkPermitDefaultTimePreferences, shiftOnPermitStartDate, Clock.Now);
            }
            
            MapPermitToView(editObject);
            if (view.IsRadiationRadiography == true && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID) // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            {
                view.ControlRoomsHasBeenContactedGroupBox = true;
            }
            if (view.AsbestosHazardsConsideredYesRadioButtonChecked == true && IsEdit && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID) // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            {
                view.IsAsbestosHazardPanel = true;
            }
            if (view.IsBurnOrOpenFlame && editObject.SapOperationId != null) // Added By vibhor -INC0538564 : Sarnia:: Gas Test Validation for SAP Generated records
            {
                HandleOpenFlameCheckChanged();
            }
            
        }

        private void MapPermitToView(WorkPermit aWorkPermitToMapToView)
        {
            workPermitBinder.ToView(aWorkPermitToMapToView, view, Common.Utility.Constants.CURRENT_VERSION);
            view.Author = aWorkPermitToMapToView.LastModifiedBy ?? aWorkPermitToMapToView.CreatedBy;

            if (view.CraftOrTrades.Count == 0)
            {
                view.EnableCraftOrTradeRadio = false;
                view.ToggleInputBoxEnabled = true;
            }

            LoadWorkItemGasTests(aWorkPermitToMapToView);
        }


        #region Load WorkItem - GasTests

        private void LoadWorkItemGasTests(WorkPermit workPermit)
        {
            view.GasTestEventsEnabled = false;

            WorkPermitGasTests gasTests = workPermit.GasTests;
            detailsToGasTestElementTable.Clear();
            List<IGasTestElementDetails> detailsList = view.GasTestElementDetailsList;
            foreach (IGasTestElementDetails details in detailsList)
            {
                GasTestElement element = FindOrCreateGasTestElementForDetails(gasTests.Elements, details);
                LoadGasTestElement(details, element, workPermit);
                detailsToGasTestElementTable.Add(details, element);
            }

            view.GasTestEventsEnabled = true;
        }

        private readonly List<string> _listElement = new List<string>(); //// RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        private bool has = false;           // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        private GasTestElement FindOrCreateGasTestElementForDetails(IEnumerable<GasTestElement> elementList, IGasTestElementDetails gasTestElementDetails)
        {
            long? gasTestElementInfoId = gasTestElementDetails.GasTestElementInfoId;

            foreach (GasTestElement element in elementList)
            {
                
                if (gasTestElementDetails.IsStandard)
                {
                    if (element.ElementInfo.Id == gasTestElementInfoId)
                    {
                        return element;
                    }
                }
                else if (element.ElementInfo.Id == null ||
                        (element.ElementInfo.IsStandard == false && gasTestElementInfoId == null) ||
                        element.ElementInfo.Id == gasTestElementInfoId)
                {
                    //return element;
                    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                    if (_listElement.Count == 0)
                    {
                        _listElement.Add(Convert.ToString(element.ElementInfo.Name));
                        return element;
                    }

                    has = _listElement.Any(s => s == Convert.ToString(element.ElementInfo.Name));
                    if (!has) return element;


                }
            }
            
            if (gasTestElementInfoId == null)
            {
                Site site = ClientSession.GetUserContext().Site;
                GasTestElementInfo otherInfo = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                return GasTestElement.CreateGasTestElement(otherInfo);
            }
            GasTestElementInfo info = FindStandardGasTestElementInfoById(gasTestElementInfoId);
            return GasTestElement.CreateGasTestElement(info);
        }

        private static void LoadGasTestElement(IGasTestElementDetails details, GasTestElement element, WorkPermit workPermit)
        {
            details.ElementName = element.ElementInfo.Name;
            details.ElementNameOther = element.ElementInfo.Name; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            details.Limits = new GasTestElementLimitFormatter().ToLimitWithUnits(element, workPermit.WorkPermitType, workPermit.Attributes);
            details.GasTestElementInfoId = element.ElementInfo.Id;
            details.IsStandard = element.ElementInfo.IsStandard;
            details.ImmediateAreaTestResult = element.ImmediateAreaTestResult;
            details.ImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
            details.ConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
            details.ConfinedSpaceTestResult = element.ConfinedSpaceTestResult;
            details.SystemEntryTestNotApplicable = element.SystemEntryTestNotApplicable;
            details.SystemEntryTestResult = element.SystemEntryTestResult;
        }

        #endregion Load Work Item - Gas Tests

        /// <summary>
        /// default stuff here
        /// </summary>
        private void UpdateViewWithDefaults()
        {
            MapPermitToView(CreateNewWorkPermitWithDefaults());
            SetStateOfRespiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox();
            SetStateOfContractorFields();
        }

        private WorkPermit CreateNewWorkPermitWithDefaults()
        {
            var newPermit = new WorkPermit(userContext.Site);
            newPermit.InitializeWithSensibleDefaults(GetCraftOrTrade(),
                                                     userContext.User, !userContext.Role.IsWorkPermitNonOperationsRole, Clock.Now, userContext.SiteConfiguration, userContext.UserShift, SiteSpecificHandlerFactory.GetDateTimeHandler(userContext.Site));
            return newPermit;
        }

        private ICraftOrTrade GetCraftOrTrade()
        {
            List<CraftOrTrade> craftOrTrades = view.CraftOrTrades;
            if (craftOrTrades.Count == 0)
            {
                return new UserSpecifiedCraftOrTrade(string.Empty);
            }
            return craftOrTrades[0];
        }

        #region Event Handlers

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            FunctionalLocation selectedFloc = view.ShowFunctionalLocationSelector();
            if (selectedFloc != null)
            {
                FunctionalLocationChanged(selectedFloc);
                view.FunctionalLocation = selectedFloc;
            }
        }

        private void FunctionalLocationChanged(FunctionalLocation selectedFloc)
        {
            workPermitFormSpecificSiteEventHandler.HandleFunctionalLocationChanged(
                    selectedFloc, allWorkAssignmentsForUserFlocs, functionalLocationService, workPermitAutoAssignmentConfiguration);            
        }

        public void HandleValidateButtonClick(object sender, EventArgs e)
        {
            view.ClearErrorProviders();

            editObject = GetWorkPermit();
            UpdateEditWorkPermitFromView();

            var sectionValidationErrors = new WorkPermitSectionsValidator(editObject, authorized).Validate();
            var allErrors = RunNonSectionValidationRules();
            allErrors.AddRange(sectionValidationErrors);

            allErrors.ForEach(error => error.Bind(view));

            if (allErrors.Exists(error => error.ProblemLevel == ProblemLevel.RequiredForSave))
            {
                view.ValidateFullyFailedMessage();
            }
            else if (allErrors.Exists(error => error.ProblemLevel == ProblemLevel.RequiredForApproval ||
                error.ProblemLevel == ProblemLevel.Warning))
            {
                view.ValidatePassedButCannotApproveMessage();
            }
            
            else
            {
                view.ValidateFullySucceededMessage();
            }
        }

        public void RespiratoryProtectionRequirementsHalfFaceRespiratorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetStateOfRespiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox();
        }

        public void RespiratoryProtectionRequirementsFullFaceRespiratorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetStateOfRespiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox();
        }

        public void SetStateOfRespiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox()
        {
            bool halfCartridge = view.RespiratoryIsHalfFaceRespirator;
            bool fullCartridge = view.RespiratoryIsFullFaceRespirator;
            view.RespiratoryCartridgeTypeTextBoxEnabled = halfCartridge || fullCartridge;
        }

        private void SetStateOfContractorFields()
        {
            view.SetContractorFieldsToDefaultState();
        }

        #endregion

        #region Implementing Abstract Presenter methods
        
        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();
            editObject = GetWorkPermit();
            UpdateEditWorkPermitFromView();
            List<IValidationIssue> errorList = RunNonSectionValidationRules();
            errorList.ForEach(error => error.Bind(view));

            return errorList.Exists(ve => ve.ProblemLevel == ProblemLevel.RequiredForSave); 
        }
        
        private List<IValidationIssue> RunNonSectionValidationRules()
        {
            var coreViewValidator = new NewCoreWorkPermitValidator(editObject);
            List<IValidationIssue> errorList = coreViewValidator.Validate();

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            bool shouldFullyValidateBasedOnUser = authorized.ToFullyValidateWorkPermit(userRoleElements);
            if (shouldFullyValidateBasedOnUser)
            {
                var validator = new FullWorkPermitValidator(editObject);
                List<IValidationIssue> errors = validator.Validate();
                errorList.AddRange(errors);

                var gasTestElementValidator = new NewGasTestElementValidator(editObject, standardGasTestElementInfoList);
                List<IValidationIssue> gasTestElementErrors = gasTestElementValidator.Validate();
                errorList.AddRange(gasTestElementErrors);
            }

            return errorList;
        }

        public override void Insert(SaveUpdateDomainObjectContainer<WorkPermit> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, container.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<WorkPermit> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, container.Item);
        }

        protected override SaveUpdateDomainObjectContainer<WorkPermit> GetNewObjectToInsert()
        {
            WorkPermit workPermit = GetWorkPermit();
            SetValuesOnWorkPermit(workPermit);
            return new SaveUpdateDomainObjectContainer<WorkPermit>(workPermit);
        }

        protected override SaveUpdateDomainObjectContainer<WorkPermit> GetPopulatedEditObjectToUpdate()
        {
            UpdateEditWorkPermitFromView();
            return new SaveUpdateDomainObjectContainer<WorkPermit>(editObject);
        }
       
        private WorkPermit GetWorkPermit()
        {
            WorkPermit workPermit;

            if (editObject == null)
            {
                workPermit = CreateNewWorkPermitWithDefaults();
                workPermit.Source = DataSource.MANUAL;
            }
            else
            {
                workPermit = editObject;
            }
            
            workPermit.SetWorkPermitStatus(WorkPermitStatus.Pending);
            
            return workPermit;
        }

        #endregion

        public void OnWorkPermitTypeChanged(object sender, EventArgs args)
        {
            HandleWorkPermitTypeOrWorkAttributesChanged();
        }

        public void HandleWorkAttributesChanged(object sender, EventArgs args)
        {
            HandleWorkPermitTypeOrWorkAttributesChanged();
            HandleConfinedSpaceEntryCheckChanged();   // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        }


        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        //Start :
        public void HandleOpenFlameChanged(object sender, EventArgs args)
        {
            HandleOpenFlameCheckChanged();
        }

        private void HandleOpenFlameCheckChanged()
        {
            
            List<IGasTestElementDetails> gasTestElementDetails = view.GasTestElementDetailsList;
            

            foreach (IGasTestElementDetails details in gasTestElementDetails)
            {
                
                if (view.IsBurnOrOpenFlame && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                {
                    if (details.ElementName == "LEL")
                    {
                        details.ImmediateAreaTestRequired = true;
                        details.ImmediateAreaTestRequiredEnabledDisabled = false;

                    }
                }
                else
                {
                    details.ImmediateAreaTestRequired = false;
                    details.ImmediateAreaTestRequiredEnabledDisabled = true;
                }
                
            }
        }

        private void HandleConfinedSpaceEntryCheckChanged()
        {

            List<IGasTestElementDetails> gasTestElementDetails = view.GasTestElementDetailsList;


            foreach (IGasTestElementDetails details in gasTestElementDetails)
            {

                if (view.IsConfinedSpaceEntry && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                {
                    if (details.ElementName == "Oxygen" || details.ElementName == "LEL")
                    {
                        details.ConfinedSpaceTestRequired = true;
                        details.ConfinedSpaceTestRequiredEnabledDisabled = false;
                    }
                }
                else
                {
                    details.ConfinedSpaceTestRequired = false;
                    details.ConfinedSpaceTestRequiredEnabledDisabled = true;
                }

            }
        }
        
        //END

        private void HandleWorkPermitTypeOrWorkAttributesChanged()
        {
            WorkPermitType permitType = view.WorkPermitType;
            List<IGasTestElementDetails> gasTestElementDetails = view.GasTestElementDetailsList;

            var attributes = new WorkPermitAttributes();
            SaveWorkPermitAttributes(attributes);

            foreach(IGasTestElementDetails details in gasTestElementDetails)
            {
                bool isStandard = details.IsStandard;
                long? elementInfoId = details.GasTestElementInfoId;

                if (isStandard)
                {
                    GasTestElementInfo standardInfo = FindStandardGasTestElementInfoById(elementInfoId);
                    GasLimitRange range = standardInfo.GetLimitRange(permitType, attributes);
                    details.Limits = range.ToLimitStringWithUnit(standardInfo.IsRangedLimit, standardInfo.DecimalPlaceCount, standardInfo.Unit);
                    
                }
            }
        }

        /// <summary>
        /// The event handler for handling clicking of the view edit history button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            EditWorkPermitHistoryFormPresenter presenter = new EditWorkPermitHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public void HandleBurnOpenFlameCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleBurnOpenFlameCheckChanged();
        }

        public void HandleWorkPermitTypeHotCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandlePermitTypeHotCheckChanged();
        }

        public void HandleVehicleEntryCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleVehicleEntryCheckChanged();
        }

        public void StartDatePickValueChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleStartDateValueChanged();
        }

        public void HandleExcavationCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleExcavationCheckChanged();
        }

        public void HandleConfinedSpaceEntryCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleConfinedSpaceEntryCheckChanged();
           
        }

        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        public void HandleRadiationRadiographyCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleRadiationRadiographyCheckChanged();
        }

        public void HandleVestedBuddySystemInEffectYesRadioButtonCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleVestedBuddySystemInEffectYesRadioButtonCheckChanged();
        }

        public void HandleequipmentIsHazardousEnergyIsolationRequiredYesRadioButtonCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleequipmentIsHazardousEnergyIsolationRequiredYesRadioButtonCheckChanged();
        }

        public void HandleequipmentIsHazardousEnergyIsolationRequiredNoRadioButtonCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleequipmentIsHazardousEnergyIsolationRequiredNoRadioButtonCheckChanged();
        }
        public void HandleasbestosHazardsConsideredNACheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleasbestosHazardsConsideredNACheckBoxCheckChanged();
        }
        
        
        public void HandlefreshAirCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandlefreshAirCheckBoxCheckChanged();
        }
        public void HandleAsbestosHazardsConsideredYesRadioButtonCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleAsbestosHazardsConsideredYesRadioButtonCheckChanged();
        }

        public void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButtonCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButtonCheckChanged();
        }

        public void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBoxCheckChanged();
        }
        public void HandleasbestosHazardsConsideredNoRadioButtonChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleasbestosHazardsConsideredNoRadioButtonChanged();
        }
        public void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButtonCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButtonCheckChanged();
        }
        //END

        //DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
        
         public void HandleequipmentLockOutMethodIndividualByOperationsRadioButtonCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleequipmentLockOutMethodIndividualByOperationsRadioButtonCheckChanged();
        }
        
       //END


        private GasTestElementInfo FindStandardGasTestElementInfoById(long? elementInfoId)
        {
            foreach (GasTestElementInfo standardInfo in standardGasTestElementInfoList)
            {
                if (standardInfo.Id == elementInfoId)
                {
                    return standardInfo;
                }
            }
            throw new ApplicationException("Invalid Standard Gas Test Element Info Id : " + elementInfoId);
        }

        public void HandleAdditionalElectricalCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleAdditionalElectricalCheckChanged();
        }

        public void HandleEquipmentLockOutMethodComplexGroupRadioButtonCheckChanged(object sender, EventArgs e)
        {
            workPermitFormSpecificSiteEventHandler.HandleEquipmentLockOutMethodComplexGroupCheckChanged();
        }
    }
}
