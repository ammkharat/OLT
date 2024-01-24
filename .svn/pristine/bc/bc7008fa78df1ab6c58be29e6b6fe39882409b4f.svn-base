using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net.Repository.Hierarchy;

namespace Com.Suncor.Olt.Client.Presenters
{
    public enum WorkPermitEdmontonTab
    {
        RunningUnit,
        Turnaround
    };


    public class WorkPermitEdmontonFormPresenter : AddEditBaseFormPresenter<IWorkPermitEdmontonView, WorkPermitEdmonton>,
        IWorkPermitEdmontonPrintable
    {
        private readonly WorkPermitEdmontonTab currentTab = WorkPermitEdmontonTab.RunningUnit;
        private readonly IFormEdmontonService formService;
        private readonly bool isClone;
        private readonly bool isMerge;
        private readonly List<long> mergeSourcePermitIdList = new List<long>();

        private readonly IReportPrintManager<WorkPermitEdmonton> printManager;
        private readonly IWorkPermitEdmontonService service;

        //private readonly ISpecialWorkService specialWorkService;
        private List<SpecialWork> specialWorkList;

        private List<AreaLabel> areaLabels;
        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private List<Contractor> contractors;
        private List<CraftOrTrade> craftOrTrades;
        private List<CraftOrTrade> roadAccessPermitList;
        private FormPage<FormEdmontonGN1DTO, FormEdmontonGN1Details> gn1FormPage;
        private List<WorkPermitEdmontonGroup> groups;

        private bool locationChangedByUser;
        private List<DropdownValue> supervisorDropdownValues;
        private bool userChangedExpireTime;


        public WorkPermitEdmontonFormPresenter(WorkPermitEdmontonTab tab)
            : this(null)
        {
            currentTab = tab;
        }

        private WorkPermitEdmontonFormPresenter(WorkPermitEdmonton editObject, bool isMerge, bool isClone)
            : base(new WorkPermitEdmontonForm(), editObject)
        {
            SubscribeToViewEvents();

            this.isMerge = isMerge;
            this.isClone = isClone;

            var clientServiceRegistry = ClientServiceRegistry.Instance;
            service = clientServiceRegistry.GetService<IWorkPermitEdmontonService>();
            formService = clientServiceRegistry.GetService<IFormEdmontonService>();
            //specialWorkService = clientServiceRegistry.GetService<ISpecialWorkService>();

            printManager =
                new ReportPrintManager<WorkPermitEdmonton, WorkPermitEdmontonReport, WorkPermitEdmontonReportAdapter>(
                    new WorkPermitEdmontonPrintActions(this));
        }

        public WorkPermitEdmontonFormPresenter(WorkPermitEdmonton editObject)
            : this(editObject, false, false)
        {
        }

        public WorkPermitEdmontonFormPresenter(WorkPermitEdmonton editObject, IEnumerable<long> mergeSourcePermitIdList)
            : this(editObject, true, false)
        {
            this.mergeSourcePermitIdList.AddRange(mergeSourcePermitIdList);
        }

        protected override bool IsClone
        {
            get { return isClone; }
        }

        private bool IsMerge
        {
            get { return isMerge; }
        }

        public void ShowUnableToPrintWithExpiryDateInPastMessage()
        {
            view.DisplayErrorMessageDialog(StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPast,
                StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPastDialogTitle);
        }

        public void UpdateWorkPermit(WorkPermitEdmonton permit)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, permit);
        }

        public void ShowPrintingFailedMessage()
        {
            view.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        public bool? AskIfTheyWantToPrintTheForms()
        {
            var dialogResult =
                OltMessageBox.Show(Form.ActiveForm,
                    "Do you want to print all forms associated to this safe work permit?",
                    "Print Associated Forms?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Cancel) return null;
            return dialogResult == DialogResult.Yes;
        }

        public bool IsOnlyPrintingOnePermit { get; set; }
        public bool ShouldNotPrintForms { get; set; }

        public static WorkPermitEdmontonFormPresenter CreateForClone(WorkPermitEdmonton editObject)
        {

            return new WorkPermitEdmontonFormPresenter(editObject, false, true);
        }

        private void SubscribeToViewEvents()
        {
            view.FormLoad += HandleFormLoad;
            view.FunctionalLocationBrowseClicked += HandleFunctionalLocationClick;
            view.ValidateButtonClicked += HandleValidateButtonClick;
            view.SaveAndIssueButtonClicked += HandleSaveAndIssueButtonClick;

            view.SelectFormGN1ButtonClicked += HandleSelectFormGN1ButtonClicked;
            view.SelectFormGN6ButtonClicked += HandleSelectFormGN6ButtonClicked;
            view.SelectFormGN7ButtonClicked += HandleSelectFormGN7ButtonClicked;
            view.SelectFormGN59ButtonClicked += HandleSelectFormGN59ButtonClicked;
            view.SelectFormGN24ButtonClicked += HandleSelectFormGN24ButtonClicked;
            view.SelectFormGN75AButtonClicked += HandleSelectFormGN75AButtonClicked;

            view.FormGN1CheckBoxCheckChanged += HandleFormGN1CheckChanged;

            view.PrintPreferencesButtonClicked += HandlePrintPreferencesButtonClicked;

            view.ViewConfiguredDocumentLinkClicked += HandleViewConfiguredDocumentLinkClicked;
            view.ExpireTimeChangedByUser += HandleExpireTimeChangedByUser;
            view.GroupChanged += HandleGroupChanged;

        }

        private void HandleExpireTimeChangedByUser()
        {
            userChangedExpireTime = true;
        }

        private void HandleViewConfiguredDocumentLinkClicked()
        {
            var configuredDocumentLink = view.SelectedConfiguredDocumentLink;
            if (configuredDocumentLink != null)
            {
                view.OpenFileOrDirectoryOrWebsite(configuredDocumentLink.Link);
            }
        }

        private void HandleFormGN1CheckChanged()
        {
            EdmontonPermitSharedPresenterLogic.HandleFormGN1CheckBoxChanged(view);
            view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = !view.GN1;
            view.ConfinedSpaceWorkSectionNotApplicableToJob = !view.GN1;

        }

        private void LoadGroupsFromDatabase()
        {
            groups = service.QueryAllGroups();
        }

        private void LoadAreaLabelsFromDatabase()
        {
            areaLabels =
                ClientServiceRegistry.Instance.GetService<IAreaLabelService>()
                    .QueryBySiteId(ClientSession.GetUserContext().Site.IdValue);
        }

        private void LoadSupervisorDropdownValuesFromDatabase()
        {
            supervisorDropdownValues =
                ClientServiceRegistry.Instance.GetService<IDropdownValueService>()
                    .QueryByKey(Site.EDMONTON_ID, WorkPermitEdmontonDropDownValueKeys.ShiftSupervisors);
        }

        private void LoadConfiguredDocumentLinks()
        {
            configuredDocumentLinks =
                ClientServiceRegistry.Instance.GetService<IConfiguredDocumentLinkService>()
                    .GetLinks(ConfiguredDocumentLinkLocation.WorkPermitEdmonton);
        }

        private void LoadContractors()
        {
            contractors = ClientServiceRegistry.Instance.GetService<IContractorService>().QueryBySite(userContext.Site);
        }

        private void LoadCraftOrTrades()
        {
            craftOrTrades =
                ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySite(userContext.Site);
        }

        private void LoadRoadOnAccessPermitList()
        {
            roadAccessPermitList =
                ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySiteIdRoadAccessOnPermit(userContext.Site);
        }

        private void LoadSpecialWorkList()
        {
            specialWorkList =
                ClientServiceRegistry.Instance.GetService<ISpecialWorkService>().QueryBySite(userContext.Site);
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action>
            {
                LoadGroupsFromDatabase,
                LoadAreaLabelsFromDatabase,
                LoadSupervisorDropdownValuesFromDatabase,
                LoadConfiguredDocumentLinks,
                LoadContractors,
                LoadCraftOrTrades,
                LoadRoadOnAccessPermitList,
                LoadSpecialWorkList
            });
        }

        protected override void AfterDataLoad()
        {
            view.PopulateFunctionalLocationSelector(userContext.HasFlocsForWorkPermits
                ? userContext.RootFlocSetForWorkPermits.FunctionalLocations
                : userContext.RootFlocSet.FunctionalLocations);
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.CreateOrEditWorkPermitFormTitle);
            //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s
            view.IsEdit = IsEdit;
            view.IsClone = IsClone;
            //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_e
            SetupWorkPermitTypesList();
            SetupContractorsList();
            SetupCraftOrTradesList();
            SetupRoadOnAccessPermitList();
            SetupSpecialWorkList();
            SetToolTips();
            DisableTheSaveAndIssueButtonIfNecessary();

            view.AllGroups = groups;
            view.AllAffectedAreas = PermitFormHelper.GetAreasAffectedList();

            var areaLabelsFromDb = new List<AreaLabel>(areaLabels);
            areaLabelsFromDb.Insert(0, AreaLabel.EMPTY);
            view.AreaLabels = AreaLabel.ManuallySelectableAreaLabels(editObject == null ? null : editObject.AreaLabel,
                areaLabelsFromDb);

            view.AlkylationEntryClassOfClothingSelectionList = PermitFormHelper.GetABCDSelectionList();
            
            view.FlarePitEntryTypeSelectionList = PermitFormHelper.Get12SelectionList();
            
            view.ConfinedSpaceClassSelectionList = PermitFormHelper.GetConfinedSpaceClassSelectionList();
            view.SpecialWorkTypeSelectionList = EdmontonPermitSpecialWorkType.GetAllAsList();
            view.Priorities = new List<Priority>(WorkPermitEdmonton.Priorities);

            view.ShiftSupervisorSelectionList =
                WorkPermitEdmontonDropDownValueKeys.ShiftSupervisorDropdownValues(supervisorDropdownValues);

            if (configuredDocumentLinks.Count == 0)
            {
                view.DisableConfiguredDocumentLinks();
            }
            else
            {
                view.ConfiguredDocumentLinks = configuredDocumentLinks;
            }

            view.AllowEventsToOverrideUserSelectedCheckboxes = false;

            if (IsMerge)
            {
                // set defaults for the View
                UpdateViewWithDefaults();

                // Clear items in Edit object that aren't suppose to be merged.
                editObject.RequestedStartDateTime = view.RequestedStartDateTime;
                editObject.ExpiredDateTime = view.ExpiryDateTime;
                editObject.IssuedDateTime = null;
                editObject.LastModifiedDateTime = Clock.Now;

                editObject.IsolationValvesLocked = view.IsolationValvesLocked;
                editObject.DepressuredDrained = view.DepressuredDrained;
                editObject.Ventilated = view.Ventilated;
                editObject.Purged = view.Purged;
                editObject.BlindedAndTagged = view.BlindedAndTagged;
                editObject.DoubleBlockAndBleed = view.DoubleBlockAndBleed;
                editObject.ElectricalLockout = view.ElectricalLockout;
                editObject.MechanicalLockout = view.MechanicalLockout;
                editObject.BlindSchematicAvailable = view.BlindSchematicAvailable;

                editObject.QuestionOneResponse = view.QuestionOneResponse;
                editObject.QuestionTwoResponse = view.QuestionTwoResponse;
                editObject.QuestionTwoAResponse = view.QuestionTwoAResponse;
                editObject.QuestionTwoBResponse = view.QuestionTwoBResponse;
                editObject.QuestionThreeResponse = view.QuestionThreeResponse;
                editObject.QuestionFourResponse = view.QuestionFourResponse;

                // Now set the View with items from Edit object.
                UpdateViewFromEditObject();
            }
            else if (IsEdit)
            {
                SetupSafetyFormStateValuesWithoutIncludingEmpty();
                UpdateViewFromEditObject();

            }
            else if (IsClone)
            {
                SetupSafetyFormStateValuesWithoutIncludingEmpty();
                UpdateViewFromEditObject();
            }
            else
            {
                UpdateViewWithDefaults();
            }

            var userIsEditingAPermitThatCameFromAPermitRequest = editObject != null &&
                                                                 editObject.DataSource.Equals(DataSource.PERMIT_REQUEST);

            view.WorkOrderNumberReadOnly = userIsEditingAPermitThatCameFromAPermitRequest;
            view.OperationNumberReadOnly = userIsEditingAPermitThatCameFromAPermitRequest;
            view.SubOperationNumberReadOnly = userIsEditingAPermitThatCameFromAPermitRequest;

            view.AllowEventsToOverrideUserSelectedCheckboxes = true;

            SetInitialExpiredDateTime();
            //Dharmesh DMND0009363-OLT - Edmonton Enhancements 2018DMND0009363-OLT - Edmonton Enhancements 2018 - #950321828 12-Sep-2018 start
            if (!view.GN1)
            {
                view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = true;
                view.ConfinedSpaceWorkSectionNotApplicableToJob = true;
            }
            else
            {
                view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = false;
                view.ConfinedSpaceWorkSectionNotApplicableToJob = false;
            }
            //Dharmesh DMND0009363-OLT - Edmonton Enhancements 2018DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - point#2 - 24-Sep-2018 start

            if (view.StatusOfPipingEquipmentSectionNotApplicableToJob)
            {
                view.JobsiteEquipmentInspected = false;
            }
            else
            {
                view.JobsiteEquipmentInspected = true;
            }
            //Dharmesh DMND0009363-OLT - Edmonton Enhancements 2018DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - point#2 - 24-Sep-2018 end

            if (editObject == null)
            {
                editObject = CreatePermit(PermitRequestBasedWorkPermitStatus.Requested, DataSource.MANUAL);
            }

            if (IsMerge)
            {
                view.ClearErrorProviders();
                var validator = CreateValidator();
                validator.ValidateAndSetErrors(Clock.Now);
            }

        }


        private void DisableTheSaveAndIssueButtonIfNecessary()
        {
            var authorized = new Authorized();
            if (!authorized.HasPrintPermitRoleElement(userContext.UserRoleElements))
            {
                view.SaveAndIssueButtonEnabled = false;
            }
        }

        private void SetInitialExpiredDateTime()
        {
            var expiryIsInSessionStore = SessionStore.HasEdmontonWorkPermitExpiryInSessionStore();
            if (IsNew || IsClone)
            {
                if (expiryIsInSessionStore)
                {
                    SetExpiredDateTimeFromSessionStore();
                }
                else
                {
                    SetEndDateTimesToDefaultsForGroup();
                }
            }
            else if (IsEdit)
            {
                if (expiryIsInSessionStore)
                {
                    SetExpiredDateTimeFromSessionStore();
                }
            }
            else if (IsMerge)
            {
                SetEndDateTimesToDefaultsForGroup();
            }
        }

        private void SetExpiredDateTimeFromSessionStore()
        {
            var previousTimeOnExpiryControl = view.ExpiryDateTime;
            var dateTimeInSessionStore = SessionStore.GetEdmontonWorkPermitExpiryFromSessionStore();
            if (dateTimeInSessionStore.HasValue)
            {
                view.ExpiryDateTime = dateTimeInSessionStore.Value;
                if (!previousTimeOnExpiryControl.Equals(view.ExpiryDateTime))
                {
                    view.TurnOnAutosetIndicatorsForDateTimes();
                }
            }
        }

        private void HandleGroupChanged()
        {
            if (userChangedExpireTime || SessionStore.HasEdmontonWorkPermitExpiryInSessionStore())
                return;
            SetEndDateTimesToDefaultsForGroup();
        }

        private void SetToolTips()
        {
            view.SetFormGN1ToolTip(StringResources.FormGN1Description);
            view.SetFormGN11ToolTip(StringResources.FormGN11Description);
            view.SetFormGN24ToolTip(StringResources.FormGN24Description);
            view.SetFormGN27ToolTip(StringResources.FormGN27Description);
            view.SetFormGN59ToolTip(StringResources.FormGN59Description);
            view.SetFormGN6ToolTip(StringResources.FormGN6Description);
            view.SetFormGN75ToolTip(StringResources.FormGN75Description);
            view.SetFormGN7ToolTip(StringResources.FormGN7Description);
        }

        // this presenter's constructor makes an editObject with no id for the manual case, so we can't use the base class's implementation of this

        private void SetupSafetyFormStateValuesWithoutIncludingEmpty()
        {
            view.GN11Values = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.GN27Values = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
        }

        private void SetupWorkPermitTypesList()
        {
            var workPermitTypes = new List<WorkPermitEdmontonType>(WorkPermitEdmontonType.All);
            workPermitTypes.Insert(0, WorkPermitEdmontonType.NULL);
            view.AllPermitTypes = workPermitTypes;


        }

        private void SetupContractorsList()
        {
            contractors.Sort(c => c.CompanyName);
            contractors.Insert(0, Contractor.EMPTY);
            view.AllCompanies = contractors;
        }

        private void SetupCraftOrTradesList()
        {
            craftOrTrades.Sort(c => c.Name);
            craftOrTrades.Insert(0, CraftOrTrade.EMPTY);
            view.AllCraftOrTrades = craftOrTrades;
        }

        private void SetupRoadOnAccessPermitList()
        {
            roadAccessPermitList.Sort(c => c.Name);
            roadAccessPermitList.Insert(0, CraftOrTrade.EMPTY);
            view.AllRoadAccessOnPermitType = roadAccessPermitList;
        }

        private void SetupSpecialWorkList()
        {
            specialWorkList.Sort(c => c.CompanyName);
            specialWorkList.Insert(0, SpecialWork.EMPTY);
            view.AllSpecialWorkType = specialWorkList;
        }

        private void UpdateViewFromEditObject()
        {
            // first set confined space class to null, as otherwise it starts its life as 'A' and the business logic operates on that wrong assumption
            view.ConfinedSpaceClass = null;

            view.PermitNumber = editObject.PermitNumber.HasValue
                ? Convert.ToString(editObject.PermitNumber.Value)
                : string.Empty;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            view.LastModifiedBy = editObject.LastModifiedBy ?? userContext.User;

            view.WorkPermitType = editObject.WorkPermitType;

            view.IssuedToSuncor = editObject.IssuedToSuncor;
            view.ClonedFormDetailEdmonton = editObject.ClonedFormDetailEdmonton; // Added by Vibhor : DMND0011077 - Work Permit Clone History
            view.IssuedToContractor = editObject.IssuedToCompany;
            view.Company = editObject.Company;
            view.Occupation = editObject.Occupation;
            view.NumberOfWorkers = editObject.NumberOfWorkers;
            view.Group = editObject.Group;
            view.DurationPermit = editObject.DurationPermit;
            view.Priority = editObject.Priority;
            view.AreaLabel = editObject.AreaLabel;

            view.FunctionalLocation = editObject.FunctionalLocation;
            view.Location = editObject.Location;

            view.RequestedStartDateTime = editObject.RequestedStartDateTime;
            view.ExpiryDateTime = editObject.ExpiredDateTime;

            view.WorkOrderNumber = editObject.WorkOrderNumber;
            view.OperationNumber = editObject.OperationNumber;
            view.SubOperationNumber = editObject.SubOperationNumber;


            // These are intentionally set before the confined space and rescue plan fields so the events don't fire at the wrong time and wreck everything for everyone.
            {
                view.GN1 = editObject.GN1;
                view.FormGN1 = editObject.FormGN1;

                view.FormGN1TradeChecklistId = editObject.FormGN1TradeChecklistId;
                view.FormGN1TradeChecklistNumber = editObject.FormGN1TradeChecklistDisplayNumber;
            }

            view.AlkylationEntry = editObject.AlkylationEntry;
            view.AlkylationEntryClassOfClothing = editObject.AlkylationEntryClassOfClothing;
            
            view.FlarePitEntry = editObject.FlarePitEntry;
            view.FlarePitEntryType = editObject.FlarePitEntryType;
            
            view.ConfinedSpace = editObject.ConfinedSpace;
            view.ConfinedSpaceCardNumber = editObject.ConfinedSpaceCardNumber;
            view.ConfinedSpaceClass = editObject.ConfinedSpaceClass;

            view.RescuePlan = editObject.RescuePlan;
            view.RescuePlanFormNumber = editObject.RescuePlanFormNumber;

            view.VehicleEntry = editObject.VehicleEntry;
            view.VehicleEntryTotal = editObject.VehicleEntryTotal;
            view.VehicleEntryType = editObject.VehicleEntryType;

            view.SpecialWork = editObject.SpecialWork;
            view.SpecialWorkFormNumber = editObject.SpecialWorkFormNumber;
            view.SpecialWorkType = editObject.SpecialWorkType;

            view.specialworktype = editObject.specialworktype;//mangesh for SpecialWork
            view.SpecialWorkName = editObject.SpecialWorkName;

            view.RoadAccessOnPermit = editObject.RoadAccessOnPermit;
            view.RoadAccessOnPermitFormNumber = editObject.RoadAccessOnPermitFormNumber;
            view.RoadAccessOnPermitType = editObject.RoadAccessOnPermitType;


            view.GN59 = editObject.GN59;
            view.FormGN59 = editObject.FormGN59;
            view.GN7 = editObject.GN7;
            view.FormGN7 = editObject.FormGN7;
            view.GN24 = editObject.GN24;
            view.FormGN24 = editObject.FormGN24;
            view.GN6 = editObject.GN6;
            view.FormGN6 = editObject.FormGN6;
            view.GN75A = editObject.GN75A;
            view.FormGN75A = editObject.FormGN75A;

            view.GN11 = editObject.GN11;
            view.GN27 = editObject.GN27;

            view.Description = editObject.TaskDescription;
            view.HazardsAndOrRequirements = editObject.HazardsAndOrRequirements;

            view.DocumentLinks = editObject.DocumentLinks;

            view.SetOtherAreasAndOrUnitsAffected(editObject.OtherAreasAndOrUnitsAffected,
                editObject.OtherAreasAndOrUnitsAffectedArea, editObject.OtherAreasAndOrUnitsAffectedPersonNotified);

            view.StatusOfPipingEquipmentSectionNotApplicableToJob =
                editObject.StatusOfPipingEquipmentSectionNotApplicableToJob;
            view.ProductNormallyInPipingEquipment = editObject.ProductNormallyInPipingEquipment;
            view.IsolationValvesLocked = editObject.IsolationValvesLocked;
            view.DepressuredDrained = editObject.DepressuredDrained;
            view.Ventilated = editObject.Ventilated;
            view.Purged = editObject.Purged;
            view.BlindedAndTagged = editObject.BlindedAndTagged;
            view.DoubleBlockAndBleed = editObject.DoubleBlockAndBleed;
            view.ElectricalLockout = editObject.ElectricalLockout;
            view.MechanicalLockout = editObject.MechanicalLockout;
            view.BlindSchematicAvailable = editObject.BlindSchematicAvailable;
            view.ZeroEnergyFormNumber = editObject.ZeroEnergyFormNumber;
            view.LockBoxNumber = editObject.LockBoxNumber;
            view.JobsiteEquipmentInspected = editObject.JobsiteEquipmentInspected;

            view.ConfinedSpaceWorkSectionNotApplicableToJob = editObject.ConfinedSpaceWorkSectionNotApplicableToJob;
            view.QuestionOneResponse = editObject.QuestionOneResponse;
            view.QuestionTwoResponse = editObject.QuestionTwoResponse;
            view.QuestionTwoAResponse = editObject.QuestionTwoAResponse;
            view.QuestionTwoBResponse = editObject.QuestionTwoBResponse;
            view.QuestionThreeResponse = editObject.QuestionThreeResponse;
            view.QuestionFourResponse = editObject.QuestionFourResponse;

            view.GasTestsSectionNotApplicableToJob = editObject.GasTestsSectionNotApplicableToJob;
            view.WorkerToProvideGasTestData = editObject.WorkerToProvideGasTestData;
            view.OperatorGasDetectorNumber = editObject.OperatorGasDetectorNumber;

            view.GasTestDataLine1CombustibleGas = editObject.GasTestDataLine1CombustibleGas;
            view.GasTestDataLine1Oxygen = editObject.GasTestDataLine1Oxygen;
            view.GasTestDataLine1ToxicGas = editObject.GasTestDataLine1ToxicGas;
            view.GasTestDataLine1Time = editObject.GasTestDataLine1Time;

            view.GasTestDataLine2CombustibleGas = editObject.GasTestDataLine2CombustibleGas;
            view.GasTestDataLine2Oxygen = editObject.GasTestDataLine2Oxygen;
            view.GasTestDataLine2ToxicGas = editObject.GasTestDataLine2ToxicGas;
            view.GasTestDataLine2Time = editObject.GasTestDataLine2Time;

            view.GasTestDataLine3CombustibleGas = editObject.GasTestDataLine3CombustibleGas;
            view.GasTestDataLine3Oxygen = editObject.GasTestDataLine3Oxygen;
            view.GasTestDataLine3ToxicGas = editObject.GasTestDataLine3ToxicGas;
            view.GasTestDataLine3Time = editObject.GasTestDataLine3Time;

            view.GasTestDataLine4CombustibleGas = editObject.GasTestDataLine4CombustibleGas;
            view.GasTestDataLine4Oxygen = editObject.GasTestDataLine4Oxygen;
            view.GasTestDataLine4ToxicGas = editObject.GasTestDataLine4ToxicGas;
            view.GasTestDataLine4Time = editObject.GasTestDataLine4Time;

            view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob =
                editObject.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

            view.FaceShield = editObject.FaceShield;
            view.Goggles = editObject.Goggles;
            view.RubberBoots = editObject.RubberBoots;
            view.RubberGloves = editObject.RubberGloves;
            view.RubberSuit = editObject.RubberSuit;
            view.SafetyHarnessLifeline = editObject.SafetyHarnessLifeline;
            view.HighVoltagePPE = editObject.HighVoltagePPE;
            view.Other1 = editObject.Other1Checked;
            view.Other1Value = editObject.Other1;

            view.EquipmentGrounded = editObject.EquipmentGrounded;
            view.FireBlanket = editObject.FireBlanket;
            view.FireExtinguisher = editObject.FireExtinguisher;
            view.FireMonitorManned = editObject.FireMonitorManned;
            view.FireWatch = editObject.FireWatch;
            view.SewersDrainsCovered = editObject.SewersDrainsCovered;
            view.SteamHose = editObject.SteamHose;
            view.Other2 = editObject.Other2Checked;
            view.Other2Value = editObject.Other2;

            view.AirPurifyingRespirator = editObject.AirPurifyingRespirator;
            view.BreathingAirApparatus = editObject.BreathingAirApparatus;
            view.DustMask = editObject.DustMask;
            view.LifeSupportSystem = editObject.LifeSupportSystem;
            view.SafetyWatch = editObject.SafetyWatch;
            view.ContinuousGasMonitor = editObject.ContinuousGasMonitor;
            view.WorkersMonitor = editObject.WorkersMonitor;
            view.WorkersMonitorNumber = editObject.WorkersMonitorNumber;
            view.BumpTestMonitorPriorToUse = editObject.BumpTestMonitorPriorToUse;
            view.Other3 = editObject.Other3Checked;
            view.Other3Value = editObject.Other3;

            view.AirMover = editObject.AirMover;
            view.BarriersSigns = editObject.BarriersSigns;
            view.RadioChannel = editObject.RadioChannel;
            view.RadioChannelNumber = editObject.RadioChannelNumber;
            view.AirHorn = editObject.AirHorn;
            view.MechVentilationComfortOnly = editObject.MechVentilationComfortOnly;
            view.AsbestosMMCPrecautions = editObject.AsbestosMMCPrecautions;
            view.Other4 = editObject.Other4Checked;
            view.Other4Value = editObject.Other4;

            view.PermitAcceptor = editObject.PermitAcceptor;
            view.ShiftSupervisor = editObject.ShiftSupervisor;

            view.UseCurrentPermitNumberForZeroEnergyFormNumber =
                editObject.UseCurrentPermitNumberForZeroEnergyFormNumber;

            view.ForceExecutionOfBusinessLogic(editObject.WorkPermitStatus);

            if (view.GN1)
            {
                EdmontonPermitSharedPresenterLogic.UpdateFieldsAfterSelectingFormGN1(view);
            }
        }

        private void UpdateViewWithDefaults()
        {
            view.LastModifiedBy = userContext.User;
            view.LastModifiedDateTime = Clock.Now;

            view.PermitNumber = string.Empty;
            view.Priority = Priority.Normal;
            view.AreaLabel = null;

            view.SetOtherAreasAndOrUnitsAffected(false, null, null);

            view.ConfinedSpace = false;
            view.ConfinedSpaceCardNumber = null;
            view.ConfinedSpaceClass = null;

            //Dharmesh DMND0009363-OLT - Edmonton Enhancements 2018DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - point#2 - 24-Sep-2018 Start
            //view.JobsiteEquipmentInspected = false;
            view.JobsiteEquipmentInspected = true;
            //Dharmesh DMND0009363-OLT - Edmonton Enhancements 2018DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - point#2 - 24-Sep-2018 end

            SetupSafetyFormStateValuesWithoutIncludingEmpty();

            view.GN11 = WorkPermitSafetyFormState.NotApplicable;
            view.GN27 = WorkPermitSafetyFormState.NotApplicable;

            view.QuestionOneResponse = YesNoNotApplicable.YES;

            view.DocumentLinks = new List<DocumentLink>();

            view.AlkylationEntryClassOfClothing = null;
            
            view.FlarePitEntryType = null;
            
            view.SpecialWorkType = null;
            view.Group = null;

            view.PermitAcceptor = null;
            view.ShiftSupervisor = null;
        }

        private DateTime? GetExpiryTimeBasedOnSelectedTab()
        {
            DateTime? expiryTimeBasedOnSelectedGroupOnView = null;

            var userShift = userContext.UserShift;
            var shiftEndDateTime = userShift.EndDateTime;

            if (view.Group == null)
            {
                expiryTimeBasedOnSelectedGroupOnView =
                    shiftEndDateTime.Add(currentTab == WorkPermitEdmontonTab.Turnaround
                        ? WorkPermitEdmonton.TurnaroundPermitEndTimeOffset
                        : WorkPermitEdmonton.NonTurnaroundPermitEndTimeOffset);
            }

            return expiryTimeBasedOnSelectedGroupOnView;
        }

        /// <summary>
        ///     Sets the View's Expiry date time using the following rules
        ///     1.  If the user was on a Work Permit tab when creating a Work permit, use the fact that the tab is turnaround or
        ///     running unit to decide
        ///     2.  Use the Group of the Work Permit
        /// </summary>
        private void SetEndDateTimesToDefaultsForGroup()
        {
            var userShift = userContext.UserShift;

            var expiryTimeBasedOnSelectedGroupOnView = GetExpiryTimeBasedOnSelectedTab();
            if (expiryTimeBasedOnSelectedGroupOnView.HasValue)
            {
                view.ExpiryDateTime = expiryTimeBasedOnSelectedGroupOnView.Value;
            }
            else if (!IsNew)
            {
                // get the selected group off of the view, and set it on the domain object.
                editObject.Group = view.Group;
                var defaultExpiryDateTimeForGroup = editObject.GetDefaultExpiryDateTimeBasedOnGroup(userShift);
                view.ExpiryDateTime = defaultExpiryDateTimeForGroup;
            }
        }

        private void HandleFunctionalLocationClick()
        {
            SetLocationChangedByUser();

            var selectedFloc = view.ShowSecondLevelOrLowerFunctionalLocationSelector();

            if (selectedFloc != null)
            {
                view.FunctionalLocation = selectedFloc;

                if (!locationChangedByUser)
                {
                    view.Location = WorkPermitEdmonton.GetLocation(selectedFloc);
                }
            }
        }

        private void SetLocationChangedByUser()
        {
            locationChangedByUser = view.Location != WorkPermitEdmonton.GetLocation(view.FunctionalLocation);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now);

            var hasValidationWarnings = validator.HasWarnings;
            var hasErrors = validator.HasErrors;

            var otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
            otherWarnings.Validate();

            if (hasErrors)
            {
                if (hasValidationWarnings)
                {
                    view.ShowHasValidationWarningsAndErrorsMessageBox();
                }
                else
                {
                    view.ShowHasValidationErrorsMessageBox();
                }
            }
            else
            {
                if (hasValidationWarnings || otherWarnings.HasWarnings)
                {
                    var result = view.ShowWarnings(otherWarnings, hasValidationWarnings);
                    if (result == DialogResult.Yes)
                    {
                        FinalizePermitAndSave(hasValidationWarnings);
                    }
                }
                else
                {
                    FinalizePermitAndSave(false);
                }
            }
        }

        private void SaveValuesInSession()
        {
            // if the use has changed the time from what was initially set on Load via the SetInitialExpiredDateTime method, then store the value.
            if (userChangedExpireTime)
            {
                var sessionStore = ClientSession.GetInstance().GetSessionStore();
                sessionStore.SetValue(SessionStoreKey.WorkPermitEdmontonEndDateTime, editObject.ExpiredDateTime);
            }

        }

        private void FinalizePermitAndSave(bool hasValidationWarnings)
        {
            editObject.WorkPermitStatus = hasValidationWarnings
                ? PermitRequestBasedWorkPermitStatus.Requested
                : PermitRequestBasedWorkPermitStatus.Pending;

            try
            {
                SaveOrUpdate(true);
            }
            catch (Exception e)
            {
                HandleSaveOrUpdateException(e);
            }
        }

        private WorkPermitEdmontonValidator CreateValidator()
        {
            var attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();

            return new WorkPermitEdmontonValidator(new WorkPermitEdmontonValidationViewAdapter(view),
                attributesForHazardsLabel);
        }

        private void HandleSaveAndIssueButtonClick()
        {
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now);

            var hasValidationWarnings = validator.HasWarnings;
            var hasErrors = validator.HasErrors;

            var otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
            otherWarnings.Validate();

            if (hasErrors)
            {
                if (hasValidationWarnings)
                {
                    view.ShowHasValidationWarningsAndErrorsMessageBox();
                }
                else
                {
                    view.ShowHasValidationErrorsMessageBox();
                }
            }
            else
            {
                if (hasValidationWarnings)
                {
                    view.ShowHasValidationWarningsMessageBox();
                }
                else if (otherWarnings.HasWarnings)
                {
                    var result = view.ShowWarnings(otherWarnings, false);
                    if (result == DialogResult.Yes)
                    {
                        FinalizePermitAndSaveAndPrint();
                    }
                }
                else
                {
                    FinalizePermitAndSaveAndPrint();
                }
            }
        }


        // important: this method should only be called when there are no validation errors or warnings
        private void FinalizePermitAndSaveAndPrint()
        {
            editObject.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;

            try
            {
                SaveOrUpdate(true);

                printManager.PrintReport(new List<WorkPermitEdmonton> { editObject });
            }
            catch (Exception e)
            {
                HandleSaveOrUpdateException(e);
            }
        }

        private void HandleValidateButtonClick()
        {
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now);

            if (!validator.HasWarnings && !validator.HasErrors)
            {
                view.ShowIsValidMessageBox();
            }
            else if (!validator.HasWarnings && validator.HasErrors)
            {
                view.ShowHasValidationErrorsMessageBox();
            }
            else if (validator.HasWarnings && !validator.HasErrors)
            {
                view.ShowHasValidationWarningsMessageBox();
            }
            else if (validator.HasWarnings && validator.HasErrors)
            {
                view.ShowHasValidationWarningsAndErrorsMessageBox();
            }
        }

        // this method is not actually called in our case since we handle the saving process ourselves
        protected override bool ValidateViewHasError()
        {
            throw new NotImplementedException();
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();

            var workPermit = IsMerge
                ? ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.WorkPermitEdmontonCreate, service.InsertMergePermit, editObject,
                    mergeSourcePermitIdList)
                : ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.WorkPermitEdmontonCreate, service.Insert, editObject);

            editObject.Id = workPermit.Id;
            editObject.PermitNumber = workPermit.PermitNumber;
            editObject.MaybeSetZeroEnergyFormNumber(workPermit.PermitNumber);
            SaveValuesInSession();
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            var workPermit =
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.WorkPermitEdmontonUpdate, service.Update, editObject);
            editObject.PermitNumber = workPermit.PermitNumber;
            editObject.MaybeSetZeroEnergyFormNumber(workPermit.PermitNumber);
            SaveValuesInSession();
        }

        private void UpdateEditObjectFromView()
        {
            var id = IsEdit ? editObject.Id : null;

            var editUser = userContext.User;
            var now = Clock.Now;

            if (!IsEdit)
            {
                // If we're cloning or making a new permit, we want to create the permit here so it has the right 'created at' datetime set, but we don't want to overwrite the
                // status or datasource.
                var currentStatus = editObject.WorkPermitStatus;
                var currentDataSource = editObject.DataSource;

                if (editObject.ClonedViaTemplateTab == true) // Added By Vibhor : RITM0625399 - OLT - Include the "templates" as a source
                {
                    editObject = CreatePermit(currentStatus, DataSource.TEMPLATE);
                }
                else
                {
                    editObject = CreatePermit(currentStatus, currentDataSource);
                }

                
            }

            if (IsMerge)
            {
                editObject.DataSource = DataSource.MERGE;
                editObject.IssuedDateTime = null; // Just making sure.
            }

            editObject.Id = id;
            editObject.LastModifiedDateTime = now;
            editObject.LastModifiedBy = editUser;

            editObject.WorkPermitType = view.WorkPermitType;
            editObject.DurationPermit = view.DurationPermit;
            editObject.IssuedToSuncor = view.IssuedToSuncor;
            editObject.IssuedToCompany = view.IssuedToContractor;
            editObject.Company = view.Company;
            editObject.Occupation = view.Occupation;
            editObject.NumberOfWorkers = view.NumberOfWorkers;
            editObject.Group = view.Group;
            editObject.Priority = view.Priority;
            editObject.AreaLabel = AreaLabel.EMPTY == view.AreaLabel ? null : view.AreaLabel;

            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.Location = view.Location;

            editObject.RequestedStartDateTime = view.RequestedStartDateTime;
            editObject.ExpiredDateTime = view.ExpiryDateTime;

            editObject.WorkOrderNumber = view.WorkOrderNumber;
            editObject.OperationNumber = view.OperationNumber;
            editObject.SubOperationNumber = view.SubOperationNumber;

            editObject.AlkylationEntry = view.AlkylationEntry;
            editObject.AlkylationEntryClassOfClothing = view.AlkylationEntryClassOfClothing;
            
            editObject.FlarePitEntry = view.FlarePitEntry;
            editObject.FlarePitEntryType = view.FlarePitEntryType;
            
            editObject.ConfinedSpace = view.ConfinedSpace;
            editObject.ClonedFormDetailEdmonton = view.ClonedFormDetailEdmonton; // Added by Vibhor : DMND0011077 - Work Permit Clone History
            editObject.ConfinedSpaceCardNumber = view.ConfinedSpaceCardNumber;
            editObject.ConfinedSpaceClass = view.ConfinedSpaceClass;
            editObject.RescuePlan = view.RescuePlan;
            editObject.RescuePlanFormNumber = view.RescuePlanFormNumber;

            editObject.VehicleEntry = view.VehicleEntry;
            editObject.VehicleEntryTotal = view.VehicleEntryTotal;
            editObject.VehicleEntryType = view.VehicleEntryType;

            editObject.SpecialWork = view.SpecialWork;
            editObject.SpecialWorkFormNumber = view.SpecialWorkFormNumber;
            //editObject.SpecialWorkType = view.SpecialWorkType;

            editObject.specialworktype = view.specialworktype;//mangesh for SpecialWork
            editObject.SpecialWorkName = view.SpecialWorkName;

            editObject.RoadAccessOnPermit = view.RoadAccessOnPermit;
            editObject.RoadAccessOnPermitFormNumber = view.RoadAccessOnPermit ? view.RoadAccessOnPermitFormNumber : null;
            editObject.RoadAccessOnPermitType = view.RoadAccessOnPermit ? view.RoadAccessOnPermitType : null;

            editObject.GN59 = view.GN59;
            editObject.FormGN59 = view.FormGN59;
            editObject.GN7 = view.GN7;
            editObject.FormGN7 = view.FormGN7;
            editObject.GN24 = view.GN24;
            editObject.FormGN24 = view.FormGN24;
            editObject.GN6 = view.GN6;
            editObject.FormGN6 = view.FormGN6;
            editObject.GN75A = view.GN75A;
            editObject.FormGN75A = view.FormGN75A;
            editObject.GN1 = view.GN1;
            editObject.FormGN1 = view.FormGN1;

            editObject.FormGN1TradeChecklistId = view.FormGN1TradeChecklistId;
            editObject.FormGN1TradeChecklistDisplayNumber = view.FormGN1TradeChecklistNumber;

            editObject.GN11 = view.GN11;
            editObject.GN27 = view.GN27;

            editObject.TaskDescription = view.Description;
            editObject.HazardsAndOrRequirements = view.HazardsAndOrRequirements;

            editObject.DocumentLinks = view.DocumentLinks;

            editObject.OtherAreasAndOrUnitsAffected = view.OtherAreasAndOrUnitsAffected;
            editObject.OtherAreasAndOrUnitsAffectedArea = view.OtherAreasAndOrUnitsAffectedArea;
            editObject.OtherAreasAndOrUnitsAffectedPersonNotified = view.OtherAreasAndOrUnitsAffectedPersonNotified;

            editObject.StatusOfPipingEquipmentSectionNotApplicableToJob =
                view.StatusOfPipingEquipmentSectionNotApplicableToJob;
            editObject.ProductNormallyInPipingEquipment = view.ProductNormallyInPipingEquipment;
            editObject.IsolationValvesLocked = view.IsolationValvesLocked;
            editObject.DepressuredDrained = view.DepressuredDrained;
            editObject.Ventilated = view.Ventilated;
            editObject.Purged = view.Purged;
            editObject.BlindedAndTagged = view.BlindedAndTagged;
            editObject.DoubleBlockAndBleed = view.DoubleBlockAndBleed;
            editObject.ElectricalLockout = view.ElectricalLockout;
            editObject.MechanicalLockout = view.MechanicalLockout;
            editObject.BlindSchematicAvailable = view.BlindSchematicAvailable;
            editObject.ZeroEnergyFormNumber = view.ZeroEnergyFormNumber;
            editObject.LockBoxNumber = view.LockBoxNumber;
            editObject.JobsiteEquipmentInspected = view.JobsiteEquipmentInspected;

            editObject.ConfinedSpaceWorkSectionNotApplicableToJob = view.ConfinedSpaceWorkSectionNotApplicableToJob;
            editObject.QuestionOneResponse = view.QuestionOneResponse;
            editObject.QuestionTwoResponse = view.QuestionTwoResponse;
            editObject.QuestionTwoAResponse = view.QuestionTwoAResponse;
            editObject.QuestionTwoBResponse = view.QuestionTwoBResponse;
            editObject.QuestionThreeResponse = view.QuestionThreeResponse;
            editObject.QuestionFourResponse = view.QuestionFourResponse;

            editObject.GasTestsSectionNotApplicableToJob = view.GasTestsSectionNotApplicableToJob;
            editObject.WorkerToProvideGasTestData = view.WorkerToProvideGasTestData;
            editObject.OperatorGasDetectorNumber = view.OperatorGasDetectorNumber;

            editObject.GasTestDataLine1CombustibleGas = view.GasTestDataLine1CombustibleGas;
            editObject.GasTestDataLine1Oxygen = view.GasTestDataLine1Oxygen;
            editObject.GasTestDataLine1ToxicGas = view.GasTestDataLine1ToxicGas;
            editObject.GasTestDataLine1Time = view.GasTestDataLine1Time;

            editObject.GasTestDataLine2CombustibleGas = view.GasTestDataLine2CombustibleGas;
            editObject.GasTestDataLine2Oxygen = view.GasTestDataLine2Oxygen;
            editObject.GasTestDataLine2ToxicGas = view.GasTestDataLine2ToxicGas;
            editObject.GasTestDataLine2Time = view.GasTestDataLine2Time;

            editObject.GasTestDataLine3CombustibleGas = view.GasTestDataLine3CombustibleGas;
            editObject.GasTestDataLine3Oxygen = view.GasTestDataLine3Oxygen;
            editObject.GasTestDataLine3ToxicGas = view.GasTestDataLine3ToxicGas;
            editObject.GasTestDataLine3Time = view.GasTestDataLine3Time;

            editObject.GasTestDataLine4CombustibleGas = view.GasTestDataLine4CombustibleGas;
            editObject.GasTestDataLine4Oxygen = view.GasTestDataLine4Oxygen;
            editObject.GasTestDataLine4ToxicGas = view.GasTestDataLine4ToxicGas;
            editObject.GasTestDataLine4Time = view.GasTestDataLine4Time;

            editObject.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob =
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

            editObject.FaceShield = view.FaceShield;
            editObject.Goggles = view.Goggles;
            editObject.RubberBoots = view.RubberBoots;
            editObject.RubberGloves = view.RubberGloves;
            editObject.RubberSuit = view.RubberSuit;
            editObject.SafetyHarnessLifeline = view.SafetyHarnessLifeline;
            editObject.HighVoltagePPE = view.HighVoltagePPE;
            editObject.Other1Checked = view.Other1;
            editObject.Other1 = view.Other1Value;

            editObject.EquipmentGrounded = view.EquipmentGrounded;
            editObject.FireBlanket = view.FireBlanket;
            editObject.FireExtinguisher = view.FireExtinguisher;
            editObject.FireMonitorManned = view.FireMonitorManned;
            editObject.FireWatch = view.FireWatch;
            editObject.SewersDrainsCovered = view.SewersDrainsCovered;
            editObject.SteamHose = view.SteamHose;
            editObject.Other2Checked = view.Other2;
            editObject.Other2 = view.Other2Value;

            editObject.AirPurifyingRespirator = view.AirPurifyingRespirator;
            editObject.BreathingAirApparatus = view.BreathingAirApparatus;
            editObject.DustMask = view.DustMask;
            editObject.LifeSupportSystem = view.LifeSupportSystem;
            editObject.SafetyWatch = view.SafetyWatch;
            editObject.ContinuousGasMonitor = view.ContinuousGasMonitor;
            editObject.WorkersMonitor = view.WorkersMonitor;
            editObject.WorkersMonitorNumber = view.WorkersMonitorNumber;
            editObject.BumpTestMonitorPriorToUse = view.BumpTestMonitorPriorToUse;
            editObject.Other3Checked = view.Other3;
            editObject.Other3 = view.Other3Value;

            editObject.AirMover = view.AirMover;
            editObject.BarriersSigns = view.BarriersSigns;
            editObject.RadioChannel = view.RadioChannel;
            editObject.RadioChannelNumber = view.RadioChannelNumber;
            editObject.AirHorn = view.AirHorn;
            editObject.MechVentilationComfortOnly = view.MechVentilationComfortOnly;
            editObject.AsbestosMMCPrecautions = view.AsbestosMMCPrecautions;
            editObject.Other4Checked = view.Other4;
            editObject.Other4 = view.Other4Value;

            editObject.PermitAcceptor = view.PermitAcceptor;
            editObject.ShiftSupervisor = view.ShiftSupervisor;

            editObject.UseCurrentPermitNumberForZeroEnergyFormNumber =
                view.UseCurrentPermitNumberForZeroEnergyFormNumber;
        }

        private WorkPermitEdmonton CreatePermit(PermitRequestBasedWorkPermitStatus status, DataSource dataSource)
        {
            return new WorkPermitEdmonton(dataSource, status, view.WorkPermitType, Clock.Now,
                ClientSession.GetUserContext().User);
        }

        private DialogResult ChooseTradeChecklist(long formId)
        {
            var displayItems = formService.QueryFormGN1TradeChecklistDisplayItemsByFormGN1Id(formId);

            var form = new SelectTradeChecklistForm(displayItems);
            var result = form.ShowDialog(view);

            if (DialogResult.OK.Equals(result))
            {
                view.FormGN1TradeChecklistNumber = form.SelectedTradeChecklistNumber;
                view.FormGN1TradeChecklistId = form.SelectedTradeChecklistId;
                return DialogResult.OK;
            }

            return DialogResult.Cancel;
        }

        private void HandleViewTradeChecklist(TradeChecklist selectedTradeChecklist)
        {
            var checklistPrintActions = new EdmontonGN1FormSingleTradeChecklistPrintActions(selectedTradeChecklist);
            IReportPrintManager<FormGN1> tradeChecklistReportPrintManager =
                new ReportPrintManager<FormGN1, FormGN1SingleTradeChecklistReport, FormGN1TradeChecklistReportAdapter>(
                    checklistPrintActions);

            if (gn1FormPage != null)
            {
                var formEdmontonGn1Dto = gn1FormPage.FirstSelectedItem;
                var selectedFormGn1 = formService.QueryFormGN1ById(formEdmontonGn1Dto.IdValue);
                tradeChecklistReportPrintManager.PreviewReport(selectedFormGn1);
            }
        }

        private void HandleSelectFormGN1ButtonClicked()
        {
            var range = new Range<DateTime>(view.RequestedStartDateTime, view.ExpiryDateTime);
            var formEdmontonGn1Details = new FormEdmontonGN1Details();
            formEdmontonGn1Details.ViewTradeChecklist += HandleViewTradeChecklist;
            gn1FormPage = new FormPage<FormEdmontonGN1DTO, FormEdmontonGN1Details>(formEdmontonGn1Details, range, false,
                true);

            var presenter =
                new SelectFormPresenter
                    <FormEdmontonGN1DTO, FormGN1, FormEdmontonGN1Details,
                        FormPage<FormEdmontonGN1DTO, FormEdmontonGN1Details>>(EdmontonFormType.GN1, gn1FormPage,
                            ChooseTradeChecklist, true, range);

            long? formId = null;
            if (view.FormGN1 != null)
            {
                formId = view.FormGN1.Id;
            }

            var dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                var form = formService.QueryFormGN1ById(formDto.IdValue);
                view.FormGN1 = form;
                EdmontonPermitSharedPresenterLogic.UpdateFieldsAfterSelectingFormGN1(view);
                EdmontonPermitSharedPresenterLogic.AddInNewDocumentLinks(view, form.DocumentLinks);
            }
            formEdmontonGn1Details.ViewTradeChecklist -= HandleViewTradeChecklist;
        }

        private void HandleSelectFormGN6ButtonClicked()
        {
            var range = new Range<DateTime>(view.RequestedStartDateTime, view.ExpiryDateTime);
            var formPage = new FormPage<FormEdmontonGN6DTO, FormEdmontonGN6Details>(new FormEdmontonGN6Details(), range);
            var presenter =
                new SelectFormPresenter
                    <FormEdmontonGN6DTO, FormGN6, FormEdmontonGN6Details,
                        FormPage<FormEdmontonGN6DTO, FormEdmontonGN6Details>>(EdmontonFormType.GN6, formPage, range);

            long? formId = null;
            if (view.FormGN6 != null)
            {
                formId = view.FormGN6.Id;
            }

            var dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                var form = formService.QueryFormGN6ById(formDto.IdValue);
                view.FormGN6 = form;
            }
        }

        private void HandleSelectFormGN7ButtonClicked()
        {
            var range = new Range<DateTime>(view.RequestedStartDateTime, view.ExpiryDateTime);
            var formPage = new FormPage<FormEdmontonDTO, FormEdmontonDetails>(new FormEdmontonDetails(), range);
            var presenter =
                new SelectFormPresenter
                    <FormEdmontonDTO, FormGN7, FormEdmontonDetails, FormPage<FormEdmontonDTO, FormEdmontonDetails>>(
                    EdmontonFormType.GN7, formPage, range);

            long? formId = null;
            if (view.FormGN7 != null)
            {
                formId = view.FormGN7.Id;
            }

            var dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                var formDto = dialogResultAndOutput.Output;
                var form = formService.QueryFormGN7ById(formDto.IdValue);
                view.FormGN7 = form;
            }
        }

        private void HandleSelectFormGN59ButtonClicked()
        {
            var range = new Range<DateTime>(view.RequestedStartDateTime, view.ExpiryDateTime);
            var formPage = new FormPage<FormEdmontonDTO, FormEdmontonDetails>(new FormEdmontonDetails(), range);
            var presenter =
                new SelectFormPresenter
                    <FormEdmontonDTO, FormGN59, FormEdmontonDetails, FormPage<FormEdmontonDTO, FormEdmontonDetails>>(
                    EdmontonFormType.GN59, formPage, range);

            long? formId = null;
            if (view.FormGN59 != null)
            {
                formId = view.FormGN59.Id;
            }

            var dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                var formDto = dialogResultAndOutput.Output;
                var form = formService.QueryFormGN59ById(formDto.IdValue);
                view.FormGN59 = form;
            }
        }

        private void HandleSelectFormGN24ButtonClicked()
        {
            var range = new Range<DateTime>(view.RequestedStartDateTime, view.ExpiryDateTime);
            var formPage = new FormPage<FormEdmontonGN24DTO, FormEdmontonGN24Details>(new FormEdmontonGN24Details(),
                range, false, false);
            var presenter =
                new SelectFormPresenter
                    <FormEdmontonGN24DTO, FormGN24, FormEdmontonGN24Details,
                        FormPage<FormEdmontonGN24DTO, FormEdmontonGN24Details>>(EdmontonFormType.GN24, formPage, range);

            long? formId = null;
            if (view.FormGN24 != null)
            {
                formId = view.FormGN24.Id;
            }

            var dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                var form = formService.QueryFormGN24ById(formDto.IdValue);
                view.FormGN24 = form;
            }
        }

        private void HandleSelectFormGN75AButtonClicked()
        {
            var range = new Range<DateTime>(view.RequestedStartDateTime, view.ExpiryDateTime);
            var formPage = new FormPage<FormEdmontonGN75ADTO, FormEdmontonGN75ADetails>(new FormEdmontonGN75ADetails(),
                range, false, false);
            var presenter =
                new SelectFormPresenter
                    <FormEdmontonGN75ADTO, FormGN75A, FormEdmontonGN75ADetails,
                        FormPage<FormEdmontonGN75ADTO, FormEdmontonGN75ADetails>>(
                    EdmontonFormType.GN75A, formPage, range);

            long? formId = null;
            if (view.FormGN75A != null)
            {
                formId = view.FormGN75A.Id;
            }

            var dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                var form = formService.QueryFormGN75AById(formDto.IdValue);
                view.FormGN75A = form;
            }
        }

        private void HandlePrintPreferencesButtonClicked()
        {
            var printPreferencesFormPresenter = new WorkPermitPrintPreferencesFormPresenter();
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 4 - 03-Oct-2018 start
            var userContext = ClientSession.GetUserContext();
            userContext.User.WorkPermitPrintPreference.JobsiteEquipmentInspected = view.JobsiteEquipmentInspected;
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 4 - 03-Oct-2018 end
            
            printPreferencesFormPresenter.Run(view);
        }

    }
}