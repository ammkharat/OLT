using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PermitRequestLubesFormPresenter : AddEditBaseFormPresenter<IPermitRequestLubesView, PermitRequestLubes>
    {
        private readonly IPermitRequestLubesService service;

        private List<Contractor> contractors;
        private List<CraftOrTrade> craftOrTrades;
        private List<WorkPermitLubesGroup> groups;
        private List<string> specialWorkTypeDropdownValues;

        private bool locationChangedByUser;


        public PermitRequestLubesFormPresenter() : this(CreateDefaultPermitRequest())
        {        
        }

        public PermitRequestLubesFormPresenter(PermitRequestLubes editObject) : base(new PermitRequestLubesForm(), editObject)
        {
            view.FormLoad += HandleFormLoad;
            view.FunctionalLocationBrowse += HandleFunctionalLocationBrowse;
            view.ValidateForm += HandleValidate;
            view.ViewHistory += HandleViewHistory;

            service = ClientServiceRegistry.Instance.GetService<IPermitRequestLubesService>();
        }

        private void HandleViewHistory()
        {
            EditPermitRequestLubesHistoryFormPresenter presenter = new EditPermitRequestLubesHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private void HandleValidate()
        {
            view.ClearErrorProviders();
            PermitRequestLubesValidator validator = new PermitRequestLubesValidator(new PermitRequestLubesValidationViewAdapter(view));
            validator.Validate(Clock.Now);

            if (!validator.HasWarnings && !validator.HasErrors)
            {
                view.ShowIsValidMessageBox();
            }
            else if (!validator.HasWarnings && validator.HasErrors)
            {
                view.ShowSaveAndCloseMessageForErrors();
            }
            else if (validator.HasWarnings && !validator.HasErrors)
            {
                view.ValidationMessageForWarnings();
            }
            else if (validator.HasWarnings && validator.HasErrors)
            {
                view.ShowSaveAndCloseMessageForWarningsAndErrors();
            }
        }

        private void HandleFunctionalLocationBrowse()
        {
            SetLocationChangedByUser();

            FunctionalLocation selectedFloc = view.ShowSecondLevelOrLowerFunctionalLocationSelector();

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
            LoadData(new List<Action> { QueryTrades, QueryContractors, QueryGroups, QuerySpecialWorkTypes });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.PermitRequestFormTitle);

            view.PopulateFunctionalLocationSelector(userContext.RootFlocSet.FunctionalLocations);
            SetupFormRequirementValues();
            view.HistoryButtonEnabled = IsEdit;

            if (!editObject.IsSapDescriptionAvailableForDisplay)
            {
                view.HideSapDescription();
            }

            DisableTheWorkOrderAndOperationAndSubOperationNumbersIfNecessary();

            view.Contractors = contractors;
            view.CraftOrTrades = craftOrTrades;
            view.RequestedByGroups = groups;
            view.SpecialWorkTypes = specialWorkTypeDropdownValues;

            UpdateViewFromEditObject();

            if (IsEdit)
            {
                PermitRequestLubesValidator validator = new PermitRequestLubesValidator(new PermitRequestLubesValidationViewAdapter(view));
                validator.Validate(Clock.Now);
            }
        }

        private void DisableTheWorkOrderAndOperationAndSubOperationNumbersIfNecessary()
        {
            bool dataSourceIsNotManualAndNotClone = !editObject.DataSource.Equals(DataSource.MANUAL) && !editObject.DataSource.Equals(DataSource.CLONE);

            view.WorkOrderNumberReadOnly = dataSourceIsNotManualAndNotClone;
            view.OperationNumberReadOnly = dataSourceIsNotManualAndNotClone;
            view.SubOperationNumberReadOnly = dataSourceIsNotManualAndNotClone;
        }

        // no need to implement because we handle the saving process ourselves
        protected override bool ValidateViewHasError()
        {
            throw new NotImplementedException();
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            editObject.IsModified = true;
            PermitRequestLubes permitRequest = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.PermitRequestLubesCreate, service.Insert, editObject);
            editObject.Id = permitRequest.Id;            
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            editObject.IsModified = true;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.PermitRequestLubesUpdate, service.Update, editObject);            
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            view.ClearErrorProviders();

            PermitRequestLubesValidator validator = new PermitRequestLubesValidator(new PermitRequestLubesValidationViewAdapter(view));
            validator.Validate(Clock.Now);

            bool hasValidationWarnings = validator.HasWarnings;
            bool hasErrors = validator.HasErrors;

            PermitRequestLubesOtherWarnings otherWarnings = new PermitRequestLubesOtherWarnings(view);
            otherWarnings.Validate();

            PermitRequestCompletionStatus completionStatus = validator.CompletionStatus;

            if (hasErrors)
            {
                if (hasValidationWarnings)
                {
                    view.ShowSaveAndCloseMessageForWarningsAndErrors();
                }
                else
                {
                    view.ShowSaveAndCloseMessageForErrors();
                }
            }
            else
            {
                if (hasValidationWarnings || otherWarnings.HasWarnings)
                {
                    DialogResult result = view.ShowSaveAndCloseMessageForWarnings(otherWarnings, hasValidationWarnings);
                    if (result == DialogResult.Yes)
                    {
                        FinalizePermitRequestAndSave(completionStatus);
                    }
                }
                else
                {
                    FinalizePermitRequestAndSave(completionStatus);
                }
            }
        }

        private void FinalizePermitRequestAndSave(PermitRequestCompletionStatus completionStatus)
        {
            editObject.CompletionStatus = completionStatus;

            try
            {
                SaveOrUpdate(true);
            }
            catch (Exception e)
            {
                HandleSaveOrUpdateException(e);
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

            if (WorkPermitLubesType.HOT_WORK.Equals(editObject.WorkPermitType))
            {
                editObject.IsVehicleEntry = view.IsVehicleEntry; // Don't save this if it's not hot work.
            }
            else
            {
                editObject.IsVehicleEntry = false;
            }
            
            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.Location = view.Location;
            editObject.DocumentLinks = view.DocumentLinks;

            if (DataSource.MANUAL.Equals(editObject.DataSource))
            {
                editObject.ClearWorkOrderSources();
                editObject.AddWorkOrderSource(view.WorkOrderNumber, view.OperationNumber, view.SubOperationNumber);
            }

            editObject.RequestedStartDate = view.RequestedStartDate;
            editObject.RequestedStartTimeDay = view.RequestedStartTimeDay;
            editObject.RequestedStartTimeNight = view.RequestedStartTimeNight;
            editObject.EndDate = view.RequestedEndDate;

            editObject.ConfinedSpace = view.ConfinedSpace;
            editObject.ConfinedSpaceClass = view.ConfinedSpaceClass;
            editObject.RescuePlan = view.RescuePlan;
            editObject.ConfinedSpaceSafetyWatchChecklist = view.ConfinedSpaceSafetyWatchCheckList;
            editObject.SpecialWork = view.SpecialWork;
            editObject.SpecialWorkType = view.SpecialWorkType;

            editObject.HighEnergy = view.HighEnergy;
            editObject.CriticalLift = view.CriticalLift;
            editObject.Excavation = view.Excavation;
            editObject.EnergyControlPlan = view.EnergyControlPlan;
            editObject.EquivalencyProc = view.EquivalencyProc;
            editObject.TestPneumatic = view.TestPneumatic;
            editObject.LiveFlareWork = view.LiveFlareWork;
            editObject.EntryAndControlPlan = view.EntryAndControlPlan;
            editObject.EnergizedElectrical = view.EnergizedElectrical;

            editObject.Description = view.TaskDescription;
            editObject.SapDescription = view.SapDescription;

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

            editObject.SpecificRequirementsSectionNotApplicableToJob = view.SpecificRequirementsSectionNotApplicableToJob;

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
        }

        private void UpdateViewFromEditObject()
        {
            view.LastModifiedBy = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            view.LastSubmittedBy = editObject.LastSubmittedByUser;
            view.LastSubmittedDateTime = editObject.LastSubmittedDateTime;

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
            view.OperationNumber = editObject.OperationNumberListAsString;
            view.SubOperationNumber = editObject.SubOperationNumberListAsString;

            view.RequestedStartDate = editObject.RequestedStartDate;
            view.RequestedStartTimeDay = editObject.RequestedStartTimeDay;
            view.RequestedStartTimeNight = editObject.RequestedStartTimeNight;
            view.RequestedEndDate = editObject.EndDate;

            view.ConfinedSpace = editObject.ConfinedSpace;
            view.ConfinedSpaceClass = editObject.ConfinedSpaceClass;
            view.RescuePlan = editObject.RescuePlan;
            view.ConfinedSpaceSafetyWatchCheckList = editObject.ConfinedSpaceSafetyWatchChecklist;
            view.SpecialWork = editObject.SpecialWork;
            view.SpecialWorkType = editObject.SpecialWorkType;

            view.HighEnergy = editObject.HighEnergy;
            view.CriticalLift = editObject.CriticalLift;
            view.Excavation = editObject.Excavation;
            view.EnergyControlPlan = editObject.EnergyControlPlan;
            view.EquivalencyProc = editObject.EquivalencyProc;
            view.TestPneumatic = editObject.TestPneumatic;
            view.LiveFlareWork = editObject.LiveFlareWork;
            view.EntryAndControlPlan = editObject.EntryAndControlPlan;
            view.EnergizedElectrical = editObject.EnergizedElectrical;

            view.TaskDescription = editObject.Description;
            view.SapDescription = editObject.SapDescription;

            view.HazardHydrocarbonGas = editObject.HazardHydrocarbonGas;
            view.HazardHydrocarbonLiquid = editObject.HazardHydrocarbonLiquid;
            view.HazardHydrogenSulphide = editObject.HazardHydrogenSulphide;
            view.HazardInertGasAtmosphere = editObject.HazardInertGasAtmosphere;
            view.HazardOxygenDeficiency = editObject.HazardOxygenDeficiency;
            view.HazardRadioactiveSources = editObject.HazardRadioactiveSources;
            view.HazardUndergroundOverheadHazards = editObject.HazardUndergroundOverheadHazards;
            view.HazardDesignatedSubstance = editObject.HazardDesignatedSubstance;

            view.OtherHazardsAndOrRequirements = editObject.OtherHazardsAndOrRequirements;

            view.SetOtherAreasAndOrUnitsAffected(editObject.OtherAreasAndOrUnitsAffected, editObject.OtherAreasAndOrUnitsAffectedArea, editObject.OtherAreasAndOrUnitsAffectedPersonNotified);

            view.SpecificRequirementsSectionNotApplicableToJob = editObject.SpecificRequirementsSectionNotApplicableToJob;

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
        }

        private static PermitRequestLubes CreateDefaultPermitRequest()
        {
            DateTime now = Clock.Now;
            Date defaultDate = now.ToDate();
            UserContext userContext = ClientSession.GetUserContext();
            User currentUser = userContext.User;
            Role currentUsersRole = userContext.Role;

            PermitRequestLubes permitRequest = new PermitRequestLubes(null, defaultDate, null, null, null, DataSource.MANUAL, null, null, null, null, currentUser, now, currentUser, now, currentUsersRole)
                {
                    RequestedStartDate = defaultDate,
                    RequestedStartTimeDay = new Time(7, 0, 0),
                    RequestedStartTimeNight = null,
                    SpecificRequirementsSectionNotApplicableToJob = true
                };

            return permitRequest;
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

        private void QueryContractors()
        {
            Site site = ClientSession.GetUserContext().Site;

            contractors = ClientServiceRegistry.Instance.GetService<IContractorService>().QueryBySite(site);
            contractors.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
            contractors.Insert(0, Contractor.EMPTY);
        }

        private void QueryTrades()
        {
            Site site = ClientSession.GetUserContext().Site;

            craftOrTrades = ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySite(site);
            PermitFormHelper.SortCraftOrTrades(craftOrTrades);
        }

        private void QueryGroups()
        {
            groups = ClientServiceRegistry.Instance.GetService<IWorkPermitLubesService>().QueryAllGroups();
        }

        private void QuerySpecialWorkTypes()
        {
            List<DropdownValue> values = ClientServiceRegistry.Instance.GetService<IDropdownValueService>().QueryByKey(Site.LUBES_ID, WorkPermitLubesDropDownValueKeys.SpecialWorkTypes);
            specialWorkTypeDropdownValues = WorkPermitLubesDropDownValueKeys.SpecialWorkTypeDropdownValues(values);
        }

    }
}
