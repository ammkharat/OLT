using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Validation.Lubes;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestLubes : BaseMergeablePermitRequest
    {
        public static readonly Time DefaultStartTimeForConstructionOrTurnaround = new Time(7, 0, 0);

        public PermitRequestLubes(long? id, Date endDate, string description, string sapDescription, string company,
            DataSource dataSource, User lastImportedByUser,
            DateTime? lastImportedDateTime, User lastSubmittedByUser, DateTime? lastSubmittedDateTime, User createdBy,
            DateTime createdDateTime,
            User lastModifiedBy, DateTime lastModifiedDateTime, Role createdByRole)
            : base(
                id, endDate, description, sapDescription, company, dataSource, lastImportedByUser, lastImportedDateTime,
                lastSubmittedByUser, lastSubmittedDateTime, createdBy,
                createdDateTime, lastModifiedBy, lastModifiedDateTime, null, null, null,
                PermitRequestCompletionStatus.Incomplete)
        {
            HighEnergy = WorkPermitSafetyFormState.NotApplicable;
            CriticalLift = WorkPermitSafetyFormState.NotApplicable;
            Excavation = WorkPermitSafetyFormState.NotApplicable;
            EnergyControlPlan = WorkPermitSafetyFormState.NotApplicable;
            EquivalencyProc = WorkPermitSafetyFormState.NotApplicable;
            TestPneumatic = WorkPermitSafetyFormState.NotApplicable;
            LiveFlareWork = WorkPermitSafetyFormState.NotApplicable;
            EntryAndControlPlan = WorkPermitSafetyFormState.NotApplicable;
            EnergizedElectrical = WorkPermitSafetyFormState.NotApplicable;

            CreatedByRole = createdByRole;
        }

        public bool IssuedToSuncor { get; set; }
        public bool IssuedToCompany { get; set; }
        public string Trade { get; set; }
        public int? NumberOfWorkers { get; set; }
        public WorkPermitLubesGroup RequestedByGroup { get; set; }

        public WorkPermitLubesType WorkPermitType { get; set; }
        public bool IsVehicleEntry { get; set; }
        public FunctionalLocation FunctionalLocation { get; set; }
        public string Location { get; set; }

        public bool ConfinedSpace { get; set; }
        public string ConfinedSpaceClass { get; set; }
        public bool RescuePlan { get; set; }
        public bool ConfinedSpaceSafetyWatchChecklist { get; set; }

        public bool SpecialWork { get; set; }
        public string SpecialWorkType { get; set; }

        public Time RequestedStartTimeDay { get; set; }
        public Time RequestedStartTimeNight { get; set; }

        public override string Description { get; set; }

        public WorkPermitSafetyFormState HighEnergy { get; set; }
        public WorkPermitSafetyFormState CriticalLift { get; set; }
        public WorkPermitSafetyFormState Excavation { get; set; }
        public WorkPermitSafetyFormState EnergyControlPlan { get; set; }
        public WorkPermitSafetyFormState EquivalencyProc { get; set; }
        public WorkPermitSafetyFormState TestPneumatic { get; set; }
        public WorkPermitSafetyFormState LiveFlareWork { get; set; }
        public WorkPermitSafetyFormState EntryAndControlPlan { get; set; }
        public WorkPermitSafetyFormState EnergizedElectrical { get; set; }

        public bool HazardHydrocarbonGas { get; set; }
        public bool HazardHydrocarbonLiquid { get; set; }
        public bool HazardHydrogenSulphide { get; set; }
        public bool HazardInertGasAtmosphere { get; set; }
        public bool HazardOxygenDeficiency { get; set; }
        public bool HazardRadioactiveSources { get; set; }
        public bool HazardUndergroundOverheadHazards { get; set; }
        public bool HazardDesignatedSubstance { get; set; }

        public string OtherHazardsAndOrRequirements { get; set; }

        public bool OtherAreasAndOrUnitsAffected { get; set; }
        public string OtherAreasAndOrUnitsAffectedArea { get; set; }
        public string OtherAreasAndOrUnitsAffectedPersonNotified { get; set; }

        public bool SpecificRequirementsSectionNotApplicableToJob { get; set; }

        public bool AttendedAtAllTimes { get; set; }
        public bool EyeProtection { get; set; }
        public bool FallProtectionEquipment { get; set; }
        public bool FullBodyHarnessRetrieval { get; set; }
        public bool HearingProtection { get; set; }
        public bool ProtectiveClothing { get; set; }
        public bool Other1Checked { get; set; }
        public String Other1Value { get; set; }

        public bool EquipmentBondedGrounded { get; set; }
        public bool FireBlanket { get; set; }
        public bool FireFightingEquipment { get; set; }
        public bool FireWatch { get; set; }
        public bool HydrantPermit { get; set; }
        public bool WaterHose { get; set; }
        public bool SteamHose { get; set; }
        public bool Other2Checked { get; set; }
        public String Other2Value { get; set; }

        public bool AirMover { get; set; }
        public bool ContinuousGasMonitor { get; set; }
        public bool DrowningProtection { get; set; }
        public bool RespiratoryProtection { get; set; }
        public bool Other3Checked { get; set; }
        public String Other3Value { get; set; }

        public bool AdditionalLighting { get; set; }
        public bool DesignateHotOrColdCutChecked { get; set; }
        public String DesignateHotOrColdCutValue { get; set; }
        public bool HoistingEquipment { get; set; }
        public bool Ladder { get; set; }
        public bool MotorizedEquipment { get; set; }
        public bool Scaffold { get; set; }
        public bool ReferToTipsProcedure { get; set; }

        public bool GasDetectorBumpTested { get; set; }

        public override string FunctionalLocationNamesAsString
        {
            get { return FunctionalLocation.FullHierarchy; }
        }

        public bool IsSapDescriptionAvailableForDisplay
        {
            get { return DataSource == DataSource.SAP && SapDescription != Description; }
        }

        public Role CreatedByRole { get; private set; }

        public string PermitKeySortValue
        {
            get
            {
                return string.Format("{0}{1}{2}", WorkOrderNumber, OperationNumberListAsString,
                    SubOperationNumberListAsString);
            }
        }

        public override bool HasNoFunctionalLocation()
        {
            return FunctionalLocation == null;
        }

        public override bool HasAFunctionalLocationHigherThanLevel3()
        {
            return FunctionalLocation.Type < FunctionalLocationType.Level3;
        }

        public override void UpdateIfModifiedFrom(BasePermitRequest incomingPermitRequest)
        {
            base.UpdateIfModifiedFrom(incomingPermitRequest);

            var incomingPermitRequestLubes = (PermitRequestLubes) incomingPermitRequest;
            RequestedStartDate = incomingPermitRequestLubes.RequestedStartDate;
            RequestedStartTimeDay = incomingPermitRequestLubes.RequestedStartTimeDay;
            RequestedStartTimeNight = incomingPermitRequestLubes.RequestedStartTimeNight;
        }

        public override void UpdateFrom(BasePermitRequest basePermitRequest)
        {
            var permitRequest = (PermitRequestLubes) basePermitRequest;

            Description = permitRequest.Description;
            SapDescription = permitRequest.SapDescription;

            LastModifiedBy = permitRequest.LastModifiedBy;
            LastModifiedDateTime = permitRequest.LastModifiedDateTime;

            LastImportedByUser = permitRequest.LastImportedByUser;
            LastImportedDateTime = permitRequest.LastImportedDateTime;

            IssuedToSuncor = permitRequest.IssuedToSuncor;
            IssuedToCompany = permitRequest.IssuedToCompany;
            Trade = permitRequest.Trade;
            NumberOfWorkers = permitRequest.NumberOfWorkers;
            RequestedByGroup = permitRequest.RequestedByGroup;

            SetWorkPermitTypeAndVehicleEntryFlag(permitRequest);

            FunctionalLocation = permitRequest.FunctionalLocation;
            Location = permitRequest.Location;
            DocumentLinks = permitRequest.DocumentLinks;
            ConfinedSpace = permitRequest.ConfinedSpace;
            ConfinedSpaceClass = permitRequest.ConfinedSpaceClass;
            RescuePlan = permitRequest.RescuePlan;
            ConfinedSpaceSafetyWatchChecklist = permitRequest.ConfinedSpaceSafetyWatchChecklist;
            SpecialWork = permitRequest.SpecialWork;
            SpecialWorkType = permitRequest.SpecialWorkType;
            RequestedStartDate = permitRequest.RequestedStartDate;
            RequestedStartTimeDay = permitRequest.RequestedStartTimeDay;
            RequestedStartTimeNight = permitRequest.RequestedStartTimeNight;
            EndDate = permitRequest.EndDate;

            ClearWorkOrderSources();
            permitRequest.WorkOrderSourceList.ForEach(AddWorkOrderSource);

            HighEnergy = permitRequest.HighEnergy;
            CriticalLift = permitRequest.CriticalLift;
            Excavation = permitRequest.Excavation;
            EnergyControlPlan = permitRequest.EnergyControlPlan;
            EquivalencyProc = permitRequest.EquivalencyProc;
            TestPneumatic = permitRequest.TestPneumatic;
            LiveFlareWork = permitRequest.LiveFlareWork;
            EntryAndControlPlan = permitRequest.EntryAndControlPlan;
            EnergizedElectrical = permitRequest.EnergizedElectrical;
            HazardHydrocarbonGas = permitRequest.HazardHydrocarbonGas;
            HazardHydrocarbonLiquid = permitRequest.HazardHydrocarbonLiquid;
            HazardHydrogenSulphide = permitRequest.HazardHydrogenSulphide;
            HazardInertGasAtmosphere = permitRequest.HazardInertGasAtmosphere;
            HazardOxygenDeficiency = permitRequest.HazardOxygenDeficiency;
            HazardRadioactiveSources = permitRequest.HazardRadioactiveSources;
            HazardUndergroundOverheadHazards = permitRequest.HazardUndergroundOverheadHazards;
            HazardDesignatedSubstance = permitRequest.HazardDesignatedSubstance;
            OtherHazardsAndOrRequirements = permitRequest.OtherHazardsAndOrRequirements;
            OtherAreasAndOrUnitsAffected = permitRequest.OtherAreasAndOrUnitsAffected;
            OtherAreasAndOrUnitsAffectedArea = permitRequest.OtherAreasAndOrUnitsAffectedArea;
            OtherAreasAndOrUnitsAffectedPersonNotified = permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified;
            SpecificRequirementsSectionNotApplicableToJob = permitRequest.SpecificRequirementsSectionNotApplicableToJob;
            AttendedAtAllTimes = permitRequest.AttendedAtAllTimes;
            EyeProtection = permitRequest.EyeProtection;
            FallProtectionEquipment = permitRequest.FallProtectionEquipment;
            FullBodyHarnessRetrieval = permitRequest.FullBodyHarnessRetrieval;
            HearingProtection = permitRequest.HearingProtection;
            ProtectiveClothing = permitRequest.ProtectiveClothing;
            Other1Checked = permitRequest.Other1Checked;
            Other1Value = permitRequest.Other1Value;
            EquipmentBondedGrounded = permitRequest.EquipmentBondedGrounded;
            FireBlanket = permitRequest.FireBlanket;
            FireFightingEquipment = permitRequest.FireFightingEquipment;
            FireWatch = permitRequest.FireWatch;
            HydrantPermit = permitRequest.HydrantPermit;
            WaterHose = permitRequest.WaterHose;
            SteamHose = permitRequest.SteamHose;
            Other2Checked = permitRequest.Other2Checked;
            Other2Value = permitRequest.Other2Value;
            AirMover = permitRequest.AirMover;
            ContinuousGasMonitor = permitRequest.ContinuousGasMonitor;
            DrowningProtection = permitRequest.DrowningProtection;
            RespiratoryProtection = permitRequest.RespiratoryProtection;
            Other3Checked = permitRequest.Other3Checked;
            Other3Value = permitRequest.Other3Value;
            AdditionalLighting = permitRequest.AdditionalLighting;
            DesignateHotOrColdCutChecked = permitRequest.DesignateHotOrColdCutChecked;
            DesignateHotOrColdCutValue = permitRequest.DesignateHotOrColdCutValue;
            HoistingEquipment = permitRequest.HoistingEquipment;
            Ladder = permitRequest.Ladder;
            MotorizedEquipment = permitRequest.MotorizedEquipment;
            Scaffold = permitRequest.Scaffold;
            ReferToTipsProcedure = permitRequest.ReferToTipsProcedure;
        }

        private void SetWorkPermitTypeAndVehicleEntryFlag(PermitRequestLubes incomingPermitRequest)
        {
            if (WorkPermitLubesType.HAZARDOUS_COLD_WORK.Equals(incomingPermitRequest.WorkPermitType))
            {
                WorkPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
                IsVehicleEntry = false;
            }
            else if (WorkPermitLubesType.HOT_WORK.Equals(incomingPermitRequest.WorkPermitType))
            {
                WorkPermitType = WorkPermitLubesType.HOT_WORK;
                IsVehicleEntry = incomingPermitRequest.IsVehicleEntry;
            }
            else
            {
                WorkPermitType = incomingPermitRequest.WorkPermitType;
                IsVehicleEntry = incomingPermitRequest.IsVehicleEntry;
            }
        }

        public override bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies, SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkUpRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        public override PermitRequestCompletionStatus Validate(DateTime currentDateTimeInSite)
        {
            var validator = new PermitRequestLubesValidator(new PermitRequestLubesValidationDomainAdapter(this));
            validator.Validate(currentDateTimeInSite);
            return validator.CompletionStatus;
        }

        public static bool IsSubmittableStatus(PermitRequestCompletionStatus completionStatus)
        {
            return PermitRequestCompletionStatus.Complete.Equals(completionStatus);
        }

        public PermitRequestLubesHistory TakeSnapshot()
        {
            return new PermitRequestLubesHistory(this);
        }

        public void ConvertToClone(User user, Role usersRole, UserShift currentShift)
        {
            var now = Clock.Now;

            Id = null;

            LastModifiedBy = user;
            LastModifiedDateTime = now;

            LastSubmittedByUser = null;
            LastSubmittedDateTime = null;

            LastImportedByUser = null;
            LastImportedDateTime = null;

            CreatedDateTime = now;
            CreatedBy = user;

            RequestedStartDate = new Date(now);
            EndDate = currentShift.EndDate;

            DataSource = DataSource.CLONE;

            IsModified = false;
            CreatedByRole = usersRole;

            if (HighEnergy != WorkPermitSafetyFormState.NotApplicable)
            {
                HighEnergy = WorkPermitSafetyFormState.Required;
            }

            if (CriticalLift != WorkPermitSafetyFormState.NotApplicable)
            {
                CriticalLift = WorkPermitSafetyFormState.Required;
            }

            if (Excavation != WorkPermitSafetyFormState.NotApplicable)
            {
                Excavation = WorkPermitSafetyFormState.Required;
            }

            if (EnergyControlPlan != WorkPermitSafetyFormState.NotApplicable)
            {
                EnergyControlPlan = WorkPermitSafetyFormState.Required;
            }

            if (EquivalencyProc != WorkPermitSafetyFormState.NotApplicable)
            {
                EquivalencyProc = WorkPermitSafetyFormState.Required;
            }

            if (TestPneumatic != WorkPermitSafetyFormState.NotApplicable)
            {
                TestPneumatic = WorkPermitSafetyFormState.Required;
            }

            if (CriticalLift != WorkPermitSafetyFormState.NotApplicable)
            {
                CriticalLift = WorkPermitSafetyFormState.Required;
            }

            if (LiveFlareWork != WorkPermitSafetyFormState.NotApplicable)
            {
                LiveFlareWork = WorkPermitSafetyFormState.Required;
            }

            if (EntryAndControlPlan != WorkPermitSafetyFormState.NotApplicable)
            {
                EntryAndControlPlan = WorkPermitSafetyFormState.Required;
            }

            if (EnergizedElectrical != WorkPermitSafetyFormState.NotApplicable)
            {
                EnergizedElectrical = WorkPermitSafetyFormState.Required;
            }

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());
        }

        public bool AtLeastOneAttributeInTheSpecificRequirementsSectionIsSelected()
        {
            return AttendedAtAllTimes ||
                   EyeProtection ||
                   FallProtectionEquipment ||
                   FullBodyHarnessRetrieval ||
                   HearingProtection ||
                   ProtectiveClothing ||
                   !Other1Value.IsNullOrEmptyOrWhitespace() ||
                   EquipmentBondedGrounded ||
                   FireBlanket ||
                   FireFightingEquipment ||
                   FireWatch ||
                   HydrantPermit ||
                   WaterHose ||
                   SteamHose ||
                   !Other2Value.IsNullOrEmptyOrWhitespace() ||
                   AirMover ||
                   ContinuousGasMonitor ||
                   DrowningProtection ||
                   RespiratoryProtection ||
                   !Other3Value.IsNullOrEmptyOrWhitespace() ||
                   AdditionalLighting ||
                   DesignateHotOrColdCutChecked ||
                   !DesignateHotOrColdCutValue.IsNullOrEmptyOrWhitespace() ||
                   HoistingEquipment ||
                   Ladder ||
                   MotorizedEquipment ||
                   Scaffold ||
                   ReferToTipsProcedure;
        }

        public override PermitRequestCompletionStatus DetectIsComplete()
        {
            return PermitRequestCompletionStatus.Complete;
                // mergetodo - why do we have this in Edmonton? Why doesn't lubes need it?
        }

        public void UpdateFromSAPPermitRequest(PermitRequestLubes incomingPermitRequest)
        {
            ClearWorkOrderSources();
            incomingPermitRequest.WorkOrderSourceList.ForEach(AddWorkOrderSource);

            FunctionalLocation = incomingPermitRequest.FunctionalLocation;
            Location = incomingPermitRequest.Location;
            RequestedByGroup = incomingPermitRequest.RequestedByGroup;
            SetWorkPermitType(incomingPermitRequest);
            Trade = incomingPermitRequest.Trade;
            SAPWorkCentre = incomingPermitRequest.SAPWorkCentre;

            if (SapDescription != null && SapDescription.Equals(Description))
            {
                Description = incomingPermitRequest.Description;
            }

            SapDescription = incomingPermitRequest.Description;

            RequestedStartDate = incomingPermitRequest.RequestedStartDate;
            EndDate = incomingPermitRequest.EndDate;
            RequestedStartTimeDay = incomingPermitRequest.RequestedStartTimeDay;
            RequestedStartTimeNight = incomingPermitRequest.RequestedStartTimeNight;

            HighEnergy = GetFormState(() => HighEnergy, () => incomingPermitRequest.HighEnergy);
            CriticalLift = GetFormState(() => CriticalLift, () => incomingPermitRequest.CriticalLift);
            Excavation = GetFormState(() => Excavation, () => incomingPermitRequest.Excavation);
            EnergyControlPlan = GetFormState(() => EnergyControlPlan, () => incomingPermitRequest.EnergyControlPlan);
            EquivalencyProc = GetFormState(() => EquivalencyProc, () => incomingPermitRequest.EquivalencyProc);
            TestPneumatic = GetFormState(() => TestPneumatic, () => incomingPermitRequest.TestPneumatic);
            LiveFlareWork = GetFormState(() => LiveFlareWork, () => incomingPermitRequest.LiveFlareWork);
            EntryAndControlPlan = GetFormState(() => EntryAndControlPlan,
                () => incomingPermitRequest.EntryAndControlPlan);
            EnergizedElectrical = GetFormState(() => EnergizedElectrical,
                () => incomingPermitRequest.EnergizedElectrical);

            HazardHydrocarbonGas = incomingPermitRequest.HazardHydrocarbonGas || HazardHydrocarbonGas;
            HazardHydrocarbonLiquid = incomingPermitRequest.HazardHydrocarbonLiquid || HazardHydrocarbonLiquid;
            HazardHydrogenSulphide = incomingPermitRequest.HazardHydrogenSulphide || HazardHydrogenSulphide;
            HazardInertGasAtmosphere = incomingPermitRequest.HazardInertGasAtmosphere || HazardInertGasAtmosphere;
            HazardOxygenDeficiency = incomingPermitRequest.HazardOxygenDeficiency || HazardOxygenDeficiency;
            HazardRadioactiveSources = incomingPermitRequest.HazardRadioactiveSources || HazardRadioactiveSources;
            HazardUndergroundOverheadHazards = incomingPermitRequest.HazardUndergroundOverheadHazards ||
                                               HazardUndergroundOverheadHazards;
            HazardDesignatedSubstance = incomingPermitRequest.HazardDesignatedSubstance || HazardDesignatedSubstance;

            ConfinedSpace = incomingPermitRequest.ConfinedSpace || ConfinedSpace;
            RescuePlan = incomingPermitRequest.RescuePlan || RescuePlan;

            FireWatch = incomingPermitRequest.FireWatch || FireWatch;
            HydrantPermit = incomingPermitRequest.HydrantPermit || HydrantPermit;
            DesignateHotOrColdCutChecked = incomingPermitRequest.DesignateHotOrColdCutChecked ||
                                           DesignateHotOrColdCutChecked;

            SpecificRequirementsSectionNotApplicableToJob =
                !AtLeastOneAttributeInTheSpecificRequirementsSectionIsSelected();
        }

        private WorkPermitSafetyFormState GetFormState(Func<WorkPermitSafetyFormState> getExistingFormState,
            Func<WorkPermitSafetyFormState> getIncomingFormState)
        {
            if (WorkPermitSafetyFormState.Approved.Equals(getExistingFormState()))
            {
                return WorkPermitSafetyFormState.Approved;
            }

            return getIncomingFormState();
        }

        private void SetWorkPermitType(PermitRequestLubes incomingPermitRequest)
        {
            var workPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
            IsVehicleEntry = false;

            if (incomingPermitRequest.IsVehicleEntry)
            {
                IsVehicleEntry = true;
                workPermitType = WorkPermitLubesType.HOT_WORK;
            }

            if (WorkPermitLubesType.HOT_WORK.Equals(incomingPermitRequest.WorkPermitType))
            {
                workPermitType = WorkPermitLubesType.HOT_WORK;
            }

            WorkPermitType = workPermitType;
        }
    }
}