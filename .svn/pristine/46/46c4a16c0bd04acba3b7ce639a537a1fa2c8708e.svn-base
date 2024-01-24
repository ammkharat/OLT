using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitLubesFormPresenter : AddEditBaseFormPresenter<IWorkPermitLubesView, WorkPermitLubes>
    {
        private readonly IReportPrintManager<WorkPermitLubes> pre418PrintManager;
        private readonly IReportPrintManager<WorkPermitLubes> pre420PrintManager;
        private readonly IReportPrintManager<WorkPermitLubes> printManager;
        private readonly IWorkPermitLubesService service;
        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private List<Contractor> contractors;
        private List<CraftOrTrade> craftOrTrades;
        private DateTime expireDateTimeBeforeChanges;
        private List<WorkPermitLubesGroup> groups;

        private bool locationChangedByUser;
        private List<string> specialWorkTypeDropdownValues;

        public WorkPermitLubesFormPresenter() : this(CreateDefaultWorkPermit())
        {
        }

        public WorkPermitLubesFormPresenter(WorkPermitLubes editObject) : base(new WorkPermitLubesForm(), editObject)
        {
            view.FormLoad += HandleFormLoad;
            view.FunctionalLocationBrowse += HandleFunctionalLocationBrowse;
            view.ValidateForm += HandleValidate;
            view.ViewConfiguredDocumentLink += HandleViewConfiguredDocumentLink;

            view.ConfinedSpaceCheckedChanged += HandleChangesAffectingWorkPreparationsCompletedSection;
            view.PermitTypeChanged += HandleChangesAffectingWorkPreparationsCompletedSection;
            view.ConfinedSpaceCheckedChanged += HandleChangesAffectingAtmosphericGasTestRequired;
            view.PermitTypeChanged += HandleChangesAffectingAtmosphericGasTestRequired;

            view.SaveAndIssue += HandleSaveAndIssue;
            view.ViewHistory += HandleViewHistory;

            service = ClientServiceRegistry.Instance.GetService<IWorkPermitLubesService>();
            printManager =
                new ReportPrintManager<WorkPermitLubes, WorkPermitLubesReport, WorkPermitLubesReportAdapter>(
                    new WorkPermitLubesPrintActions(service));
            pre418PrintManager =
                new ReportPrintManager<WorkPermitLubes, WorkPermitLubesReport_Pre_4_18, WorkPermitLubesReportAdapter>(
                    new WorkPermitLubesPrintActions_Pre_4_18(service));
        pre420PrintManager =
                new ReportPrintManager<WorkPermitLubes, WorkPermitLubesReport_Pre_4_20, WorkPermitLubesReportAdapter>(
                    new WorkPermitLubesPrintActions_Pre_4_20(service));
        }

        protected override bool IsClone
        {
            get { return !editObject.IsInDatabase() && DataSource.CLONE.Equals(editObject.DataSource); }
        }

        private void HandleChangesAffectingWorkPreparationsCompletedSection()
        {
            if (view.ConfinedSpace || WorkPermitLubesType.HOT_WORK.Equals(view.WorkPermitType))
            {
                view.WorkPreparationsCompletedSectionNotApplicableToJob = false;
                view.WorkPreparationsCompletedSectionNotApplicableToJobEnabled = false;
            }
            else
            {
                view.WorkPreparationsCompletedSectionNotApplicableToJobEnabled = true;
            }
        }

        private void HandleChangesAffectingAtmosphericGasTestRequired()
        {
            if (WorkPermitLubes.AtmosphericGasTestShouldBeRequired(view.WorkPermitType, view.ConfinedSpace))
            {
                view.AtmosphericGasTestRequired = true;
                view.AtmosphericGasTestRequiredEnabled = false;
            }
            else
            {
                view.AtmosphericGasTestRequiredEnabled = true;
            }
        }

        private void HandleViewConfiguredDocumentLink()
        {
            var configuredDocumentLink = view.SelectedConfiguredDocumentLink;
            if (configuredDocumentLink != null)
            {
                view.OpenFileOrDirectoryOrWebsite(configuredDocumentLink.Link);
            }
        }

        private void HandleValidate()
        {
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now, userContext.SiteConfiguration.PreShiftPaddingInMinutes,
                userContext.SiteConfiguration.PostShiftPaddingInMinutes);

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

        private void HandleFunctionalLocationBrowse()
        {
            SetLocationChangedByUser();

            var selectedFloc = view.ShowSecondLevelOrLowerFunctionalLocationSelector();

            if (selectedFloc != null)
            {
                if (WorkPermitLubes.IsABroadFunctionalLocation(selectedFloc))
                {
                    if (view.IsTheUserWantingToSelectAMoreSpecificFunctionalLocation())
                    {
                        HandleFunctionalLocationBrowse();
                        return;
                    }
                }

                view.FunctionalLocation = selectedFloc;

                if (!locationChangedByUser)
                {
                    view.Location = WorkPermitLubes.GetLocation(selectedFloc);
                }
            }
        }

        private void SetLocationChangedByUser()
        {
            locationChangedByUser = false;

            if (view.Location != WorkPermitLubes.GetLocation(view.FunctionalLocation))
            {
                locationChangedByUser = true;
            }
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action>
            {
                QueryTrades,
                QueryContractors,
                QueryGroups,
                QuerySpecialWorkTypes,
                QueryConfiguredDocumentLinks
            });
        }

        protected override void AfterDataLoad()
        {
            view.PopulateFunctionalLocationSelector(userContext.RootFlocSet.FunctionalLocations);
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.CreateOrEditWorkPermitFormTitle);
            SetupFormRequirementValues();
            view.PopulateWorkPreparationsComboBoxes(new List<YesNoNotApplicable>
            {
                YesNoNotApplicable.NOT_APPLICABLE,
                YesNoNotApplicable.YES,
                YesNoNotApplicable.NO
            });
            view.HistoryButtonEnabled = IsEdit;
            DisableTheWorkOrderAndOperationAndSubOperationNumbersIfNecessary();
            DisableTheSaveAndIssueButtonIfNecessary();

            view.Contractors = contractors;
            view.CraftOrTrades = craftOrTrades;
            view.RequestedByGroups = groups;
            view.SpecialWorkTypes = specialWorkTypeDropdownValues;

            if (configuredDocumentLinks.Count == 0)
            {
                view.DisableConfiguredDocumentLinks();
            }
            else
            {
                view.ConfiguredDocumentLinks = configuredDocumentLinks;
            }

            UpdateViewFromEditObject();
            expireDateTimeBeforeChanges = view.ExpireDateTime;
            SetExpireDateTimeFromSessionStore();
        }

        private void DisableTheSaveAndIssueButtonIfNecessary()
        {
            var authorized = new Authorized();
            if (!authorized.HasPrintPermitRoleElement(userContext.UserRoleElements))
            {
                view.DisableSaveAndIssueButton();
            }
        }

        private void DisableTheWorkOrderAndOperationAndSubOperationNumbersIfNecessary()
        {
            var userIsEditingAPermitThatCameFromAnSapPermitRequest = IsEdit &&
                                                                     DataSource.SAP.Equals(
                                                                         editObject.PermitRequestDataSource);

            view.WorkOrderNumberReadOnly = userIsEditingAPermitThatCameFromAnSapPermitRequest;
            view.OperationNumberReadOnly = userIsEditingAPermitThatCameFromAnSapPermitRequest;
            view.SubOperationNumberReadOnly = userIsEditingAPermitThatCameFromAnSapPermitRequest;
        }

        private void SetupFormRequirementValues()
        {
            view.HighEnergyValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.CriticalLiftValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.ExcavationValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.EnergyControlPlanValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.EquivalencyProcValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.TestPneumaticValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.LiveFlareWorkValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.EntryAndControlPlanValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
            view.EnergizedElectricalValues = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
        }

        private void HandleViewHistory()
        {
            var presenter = new EditWorkPermitLubesHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        // this method is not actually called in our case since we handle the saving process ourselves
        protected override bool ValidateViewHasError()
        {
            throw new NotImplementedException();
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();

            var workPermit =
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.WorkPermitLubesCreate, service.Insert, editObject);

            editObject.Id = workPermit.Id;
            editObject.PermitNumber = workPermit.PermitNumber;
            SaveValuesInSession();
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            var workPermit =
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.WorkPermitLubesUpdate, service.Update, editObject);

            editObject.PermitNumber = workPermit.PermitNumber;
            SaveValuesInSession();
        }

        private void SetExpireDateTimeFromSessionStore()
        {
            var sessionStore = ClientSession.GetInstance().GetSessionStore();
            var possiblyStoredEndDateTime = sessionStore.GetValue(SessionStoreKey.WorkPermitLubesEndDateTime);

            if (possiblyStoredEndDateTime != null)
            {
                view.ExpireDateTime = (DateTime) possiblyStoredEndDateTime;
            }

            if (!expireDateTimeBeforeChanges.Equals(view.ExpireDateTime))
            {
                view.TurnOnAutosetIndicatorsForDateTimes();
            }
        }

        private void SaveValuesInSession()
        {
            if (!expireDateTimeBeforeChanges.Equals(editObject.ExpireDateTime))
            {
                var sessionStore = ClientSession.GetInstance().GetSessionStore();
                sessionStore.SetValue(SessionStoreKey.WorkPermitLubesEndDateTime, editObject.ExpireDateTime);
            }
        }

        private void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDateTime = Clock.Now;

            editObject.IssuedToSuncor = view.IssuedToSuncor;
            editObject.IssuedToCompany = view.IssuedToCompany;
            editObject.Company = view.Company;

            editObject.Trade = view.Trade;
            editObject.NumberOfWorkers = view.NumberOfWorkers;
            editObject.RequestedByGroup = view.RequestedByGroup;
            editObject.WorkPermitType = view.WorkPermitType;

            // Don't save this if it's not hot work.
            if (WorkPermitLubesType.HOT_WORK.Equals(editObject.WorkPermitType))
            {
                editObject.IsVehicleEntry = view.IsVehicleEntry;
            }
            else
            {
                editObject.IsVehicleEntry = false;
            }

            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.Location = view.Location;
            editObject.DocumentLinks = view.DocumentLinks ?? new List<DocumentLink>();

            editObject.WorkOrderNumber = view.WorkOrderNumber;
            editObject.OperationNumber = view.OperationNumber;
            editObject.SubOperationNumber = view.SubOperationNumber;

            editObject.StartDateTime = view.StartDateTime;
            editObject.ExpireDateTime = view.ExpireDateTime;

            editObject.ConfinedSpace = view.ConfinedSpace;
            editObject.ConfinedSpaceClass = view.ConfinedSpaceClass;
            editObject.RescuePlan = view.RescuePlan;
            editObject.ConfinedSpaceSafetyWatchChecklist = view.ConfinedSpaceSafetyWatchCheckList;
            editObject.SpecialWork = view.SpecialWork;
            editObject.SpecialWorkType = view.SpecialWorkType;
            editObject.HazardousWorkApproverAdvised = view.HazardousWorkApproverAdvised;
            editObject.AdditionalFollowupRequired = view.AdditionalFollowupRequired;

            editObject.HighEnergy = view.HighEnergy;
            editObject.CriticalLift = view.CriticalLift;
            editObject.Excavation = view.Excavation;
            editObject.EnergyControlPlanFormRequirement = view.EnergyControlPlanFormRequirement;
            editObject.EquivalencyProc = view.EquivalencyProc;
            editObject.TestPneumatic = view.TestPneumatic;
            editObject.LiveFlareWork = view.LiveFlareWork;
            editObject.EntryAndControlPlan = view.EntryAndControlPlan;
            editObject.EnergizedElectrical = view.EnergizedElectrical;

            editObject.TaskDescription = view.TaskDescription;

            editObject.HazardHydrocarbonGas = view.HazardHydrocarbonGas;
            editObject.HazardHydrocarbonLiquid = view.HazardHydrocarbonLiquid;
            editObject.HazardHydrogenSulphide = view.HazardHydrogenSulphide;
            editObject.HazardInertGasAtmosphere = view.HazardInertGasAtmosphere;
            editObject.HazardOxygenDeficiency = view.HazardOxygenDeficiency;
            editObject.HazardRadioactiveSources = view.HazardRadioactiveSources;
            editObject.HazardUndergroundOverheadHazards = view.HazardUndergroundOverheadHazards;
            editObject.HazardDesignatedSubstance = view.HazardDesignatedSubstance;

            editObject.OtherHazardsAndOrRequirements = view.OtherHazardsAndOrRequirements;

            editObject.OtherAreasAndOrUnitsAffected = view.OtherAreasAndOrUnitsAffected;
            editObject.OtherAreasAndOrUnitsAffectedArea = view.OtherAreasAndOrUnitsAffectedArea;
            editObject.OtherAreasAndOrUnitsAffectedPersonNotified = view.OtherAreasAndOrUnitsAffectedPersonNotified;

            editObject.WorkPreparationsCompletedSectionNotApplicableToJob =
                view.WorkPreparationsCompletedSectionNotApplicableToJob;
            editObject.ProductNormallyInPipingEquipment = view.ProductNormallyInPipingEquipment;

            editObject.DepressuredDrained = view.DepressuredDrained;
            editObject.WaterWashed = view.WaterWashed;
            editObject.ChemicallyWashed = view.ChemicallyWashed;
            editObject.Steamed = view.Steamed;
            editObject.Purged = view.Purged;
            editObject.Disconnected = view.Disconnected;

            editObject.DepressuredAndVented = view.DepressuredAndVented;
            editObject.Ventilated = view.Ventilated;
            editObject.Blanked = view.Blanked;
            editObject.DrainsCovered = view.DrainsCovered;
            editObject.AreaBarricaded = view.AreaBarricaded;

            editObject.EnergySourcesLockedOutTaggedOut = view.EnergySourcesLockedOutTaggedOut;
            editObject.EnergyControlPlan = view.EnergyControlPlan;
            editObject.LockBoxNumber = view.LockBoxNumber;
            editObject.OtherPreparations = view.OtherPreparations;

            editObject.SpecificRequirementsSectionNotApplicableToJob =
                view.SpecificRequirementsSectionNotApplicableToJob;

            editObject.AttendedAtAllTimes = view.AttendedAtAllTimes;
            editObject.EyeProtection = view.EyeProtection;
            editObject.FallProtectionEquipment = view.FallProtectionEquipment;
            editObject.FullBodyHarnessRetrieval = view.FullBodyHarnessRetrieval;
            editObject.HearingProtection = view.HearingProtection;
            editObject.ProtectiveClothing = view.ProtectiveClothing;
            editObject.Other1Checked = view.Other1Checked;
            editObject.Other1Value = view.Other1Value;

            editObject.EquipmentBondedGrounded = view.EquipmentBondedGrounded;
            editObject.FireBlanket = view.FireBlanket;
            editObject.FireFightingEquipment = view.FireFightingEquipment;
            editObject.FireWatch = view.FireWatch;
            editObject.HydrantPermit = view.HydrantPermit;
            editObject.WaterHose = view.WaterHose;
            editObject.SteamHose = view.SteamHose;
            editObject.Other2Checked = view.Other2Checked;
            editObject.Other2Value = view.Other2Value;

            editObject.AirMover = view.AirMover;
            editObject.ContinuousGasMonitor = view.ContinuousGasMonitor;
            editObject.DrowningProtection = view.DrowningProtection;
            editObject.RespiratoryProtection = view.RespiratoryProtection;
            editObject.Other3Checked = view.Other3Checked;
            editObject.Other3Value = view.Other3Value;

            editObject.AdditionalLighting = view.AdditionalLighting;
            editObject.DesignateHotOrColdCutChecked = view.DesignateHotOrColdCutChecked;
            editObject.DesignateHotOrColdCutValue = view.DesignateHotOrColdCutValue;
            editObject.HoistingEquipment = view.HoistingEquipment;
            editObject.Ladder = view.Ladder;
            editObject.MotorizedEquipment = view.MotorizedEquipment;
            editObject.Scaffold = view.Scaffold;
            editObject.ReferToTipsProcedure = view.ReferToTipsProcedure;

            editObject.GasDetectorBumpTested = view.GasDetectorBumpTested;
            editObject.AtmosphericGasTestRequired = view.AtmosphericGasTestRequired;
        }

        private void UpdateViewFromEditObject()
        {
            view.LastModifiedBy = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            view.PermitNumber = editObject.PermitNumberDisplayValue;

            view.IssuedToSuncor = editObject.IssuedToSuncor;
            view.IssuedToCompany = editObject.IssuedToCompany;
            view.Company = editObject.Company;

            view.Trade = editObject.Trade;
            view.NumberOfWorkers = editObject.NumberOfWorkers;
            view.RequestedByGroup = editObject.RequestedByGroup;
            view.WorkPermitType = editObject.WorkPermitType;
            view.IsVehicleEntry = editObject.IsVehicleEntry;

            view.FunctionalLocation = editObject.FunctionalLocation;
            view.Location = editObject.Location;
            view.DocumentLinks = editObject.DocumentLinks;

            view.WorkOrderNumber = editObject.WorkOrderNumber;
            view.OperationNumber = editObject.OperationNumber;
            view.SubOperationNumber = editObject.SubOperationNumber;

            view.StartDateTime = editObject.StartDateTime;
            view.ExpireDateTime = editObject.ExpireDateTime;

            view.ConfinedSpace = editObject.ConfinedSpace;
            view.ConfinedSpaceClass = editObject.ConfinedSpaceClass;
            view.RescuePlan = editObject.RescuePlan;
            view.ConfinedSpaceSafetyWatchCheckList = editObject.ConfinedSpaceSafetyWatchChecklist;
            view.SpecialWork = editObject.SpecialWork;
            view.SpecialWorkType = editObject.SpecialWorkType;
            view.HazardousWorkApproverAdvised = editObject.HazardousWorkApproverAdvised;
            view.AdditionalFollowupRequired = editObject.AdditionalFollowupRequired;

            view.HighEnergy = editObject.HighEnergy;
            view.CriticalLift = editObject.CriticalLift;
            view.Excavation = editObject.Excavation;
            view.EnergyControlPlanFormRequirement = editObject.EnergyControlPlanFormRequirement;
            view.EquivalencyProc = editObject.EquivalencyProc;
            view.TestPneumatic = editObject.TestPneumatic;
            view.LiveFlareWork = editObject.LiveFlareWork;
            view.EntryAndControlPlan = editObject.EntryAndControlPlan;
            view.EnergizedElectrical = editObject.EnergizedElectrical;

            view.TaskDescription = editObject.TaskDescription;

            view.HazardHydrocarbonGas = editObject.HazardHydrocarbonGas;
            view.HazardHydrocarbonLiquid = editObject.HazardHydrocarbonLiquid;
            view.HazardHydrogenSulphide = editObject.HazardHydrogenSulphide;
            view.HazardInertGasAtmosphere = editObject.HazardInertGasAtmosphere;
            view.HazardOxygenDeficiency = editObject.HazardOxygenDeficiency;
            view.HazardRadioactiveSources = editObject.HazardRadioactiveSources;
            view.HazardUndergroundOverheadHazards = editObject.HazardUndergroundOverheadHazards;
            view.HazardDesignatedSubstance = editObject.HazardDesignatedSubstance;

            view.OtherHazardsAndOrRequirements = editObject.OtherHazardsAndOrRequirements;

            view.SetOtherAreasAndOrUnitsAffected(editObject.OtherAreasAndOrUnitsAffected,
                editObject.OtherAreasAndOrUnitsAffectedArea, editObject.OtherAreasAndOrUnitsAffectedPersonNotified);

            view.WorkPreparationsCompletedSectionNotApplicableToJob =
                editObject.WorkPreparationsCompletedSectionNotApplicableToJob;
            view.ProductNormallyInPipingEquipment = editObject.ProductNormallyInPipingEquipment;

            view.DepressuredDrained = editObject.DepressuredDrained;
            view.WaterWashed = editObject.WaterWashed;
            view.ChemicallyWashed = editObject.ChemicallyWashed;
            view.Steamed = editObject.Steamed;
            view.Purged = editObject.Purged;
            view.Disconnected = editObject.Disconnected;

            view.DepressuredAndVented = editObject.DepressuredAndVented;
            view.Ventilated = editObject.Ventilated;
            view.Blanked = editObject.Blanked;
            view.DrainsCovered = editObject.DrainsCovered;
            view.AreaBarricaded = editObject.AreaBarricaded;

            view.EnergySourcesLockedOutTaggedOut = editObject.EnergySourcesLockedOutTaggedOut;
            view.EnergyControlPlan = editObject.EnergyControlPlan;
            view.LockBoxNumber = editObject.LockBoxNumber;
            view.OtherPreparations = editObject.OtherPreparations;

            view.SpecificRequirementsSectionNotApplicableToJob =
                editObject.SpecificRequirementsSectionNotApplicableToJob;

            view.AttendedAtAllTimes = editObject.AttendedAtAllTimes;
            view.EyeProtection = editObject.EyeProtection;
            view.FallProtectionEquipment = editObject.FallProtectionEquipment;
            view.FullBodyHarnessRetrieval = editObject.FullBodyHarnessRetrieval;
            view.HearingProtection = editObject.HearingProtection;
            view.ProtectiveClothing = editObject.ProtectiveClothing;
            view.Other1Checked = editObject.Other1Checked;
            view.Other1Value = editObject.Other1Value;

            view.EquipmentBondedGrounded = editObject.EquipmentBondedGrounded;
            view.FireBlanket = editObject.FireBlanket;
            view.FireFightingEquipment = editObject.FireFightingEquipment;
            view.FireWatch = editObject.FireWatch;
            view.HydrantPermit = editObject.HydrantPermit;
            view.WaterHose = editObject.WaterHose;
            view.SteamHose = editObject.SteamHose;
            view.Other2Checked = editObject.Other2Checked;
            view.Other2Value = editObject.Other2Value;

            view.AirMover = editObject.AirMover;
            view.ContinuousGasMonitor = editObject.ContinuousGasMonitor;
            view.DrowningProtection = editObject.DrowningProtection;
            view.RespiratoryProtection = editObject.RespiratoryProtection;
            view.Other3Checked = editObject.Other3Checked;
            view.Other3Value = editObject.Other3Value;

            view.AdditionalLighting = editObject.AdditionalLighting;
            view.DesignateHotOrColdCutChecked = editObject.DesignateHotOrColdCutChecked;
            view.DesignateHotOrColdCutValue = editObject.DesignateHotOrColdCutValue;
            view.HoistingEquipment = editObject.HoistingEquipment;
            view.Ladder = editObject.Ladder;
            view.MotorizedEquipment = editObject.MotorizedEquipment;
            view.Scaffold = editObject.Scaffold;
            view.ReferToTipsProcedure = editObject.ReferToTipsProcedure;

            view.GasDetectorBumpTested = editObject.GasDetectorBumpTested;
            view.AtmosphericGasTestRequired = editObject.AtmosphericGasTestRequired;
        }

        private static WorkPermitLubes CreateDefaultWorkPermit()
        {
            var now = Clock.Now;
            var userContext = ClientSession.GetUserContext();
            var currentUser = userContext.User;

            var permit = new WorkPermitLubes(now, currentUser);
            permit.DataSource = DataSource.MANUAL;
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Requested;
            permit.StartDateTime = now;
            permit.ExpireDateTime = WorkPermitLubes.GetExpireDateTimeForSubmitAndCloneAndNew(permit.StartDateTime);
            permit.OtherAreasAndOrUnitsAffected = false;

            return permit;
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now, userContext.SiteConfiguration.PreShiftPaddingInMinutes,
                userContext.SiteConfiguration.PostShiftPaddingInMinutes);

            var hasValidationWarnings = validator.HasWarnings;
            var hasErrors = validator.HasErrors;

            var otherWarnings = new WorkPermitLubesOtherWarnings(view);
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

        private void HandleSaveAndIssue()
        {
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now, userContext.SiteConfiguration.PreShiftPaddingInMinutes,
                userContext.SiteConfiguration.PostShiftPaddingInMinutes);

            var hasValidationWarnings = validator.HasWarnings;
            var hasErrors = validator.HasErrors;

            var otherWarnings = new WorkPermitLubesOtherWarnings(view);
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

        private void FinalizePermitAndSaveAndPrint()
        {
            editObject.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;

            try
            {
                SaveOrUpdate(true);
                if (editObject.Version == Common.Utility.Constants.VERSION_4_17)
                {
                    pre418PrintManager.PrintReport(new List<WorkPermitLubes> {editObject});
                }
                if (editObject.Version == Common.Utility.Constants.VERSION_4_18 || editObject.Version == Common.Utility.Constants.VERSION_4_19)
                {
                    pre420PrintManager.PrintReport(new List<WorkPermitLubes> {editObject});
                }

                else
                {
                    printManager.PrintReport(new List<WorkPermitLubes> {editObject});
                }
            }
            catch (Exception e)
            {
                HandleSaveOrUpdateException(e);
            }
        }

        private WorkPermitLubesValidator CreateValidator()
        {
            var lubesReportPre418 = new WorkPermitLubesReport_Pre_4_18();
            var attributesForHazardsLabel = lubesReportPre418.GetAttributesForHazardsLabel();
            var attributesForTaskDescriptionLabel = lubesReportPre418.GetAttributesForTaskDescriptionLabel();

            return new WorkPermitLubesValidator(new WorkPermitLubesValidationViewAdapter(view),
                attributesForTaskDescriptionLabel, attributesForHazardsLabel);
        }

        private void QueryContractors()
        {
            contractors = ClientServiceRegistry.Instance.GetService<IContractorService>().QueryBySite(userContext.Site);
            contractors.Sort((x, y) => string.Compare(x.CompanyName, y.CompanyName, StringComparison.Ordinal));
            contractors.Insert(0, Contractor.EMPTY);
        }

        private void QueryTrades()
        {
            craftOrTrades =
                ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySite(userContext.Site);
            PermitFormHelper.SortCraftOrTrades(craftOrTrades);
        }

        private void QueryGroups()
        {
            groups = ClientServiceRegistry.Instance.GetService<IWorkPermitLubesService>().QueryAllGroups();
        }

        private void QuerySpecialWorkTypes()
        {
            var values = ClientServiceRegistry.Instance.GetService<IDropdownValueService>()
                .QueryByKey(Site.LUBES_ID, WorkPermitLubesDropDownValueKeys.SpecialWorkTypes);
            specialWorkTypeDropdownValues = WorkPermitLubesDropDownValueKeys.SpecialWorkTypeDropdownValues(values);
        }

        private void QueryConfiguredDocumentLinks()
        {
            configuredDocumentLinks =
                ClientServiceRegistry.Instance.GetService<IConfiguredDocumentLinkService>()
                    .GetLinks(ConfiguredDocumentLinkLocation.WorkPermitLubes);
        }
    }
}