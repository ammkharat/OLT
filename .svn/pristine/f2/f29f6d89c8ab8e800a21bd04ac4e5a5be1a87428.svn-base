using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitLubesHistory : DomainObjectHistorySnapshot
    {
        public WorkPermitLubesHistory(long id, User lastModifiedBy, DateTime lastModifiedDateTime)
            : base(id, lastModifiedBy, lastModifiedDateTime)
        {
        }

        public WorkPermitLubesHistory(WorkPermitLubes workPermit)
            : base(workPermit.IdValue, workPermit.LastModifiedBy, workPermit.LastModifiedDateTime)
        {
            PermitNumber = workPermit.PermitNumber;
            WorkPermitStatus = workPermit.WorkPermitStatus;

            IssuedBy = workPermit.IssuedBy;
            IssuedDateTime = workPermit.IssuedDateTime;

            IssuedToSuncor = workPermit.IssuedToSuncor;
            IssuedToCompany = workPermit.IssuedToCompany;
            Company = workPermit.Company;
            Trade = workPermit.Trade;
            NumberOfWorkers = workPermit.NumberOfWorkers;
            RequestedByGroup = workPermit.RequestedByGroup != null ? workPermit.RequestedByGroup.Name : null;

            WorkPermitType = workPermit.WorkPermitType;
            IsVehicleEntry = workPermit.IsVehicleEntry;

            FunctionalLocation = workPermit.FunctionalLocation.FullHierarchy;
            Location = workPermit.Location;

            DocumentLinks = workPermit.DocumentLinks.AsString(link => link.TitleWithUrl);

            ConfinedSpace = workPermit.ConfinedSpace;
            ConfinedSpaceClass = workPermit.ConfinedSpaceClass;
            RescuePlan = workPermit.RescuePlan;
            ConfinedSpaceSafetyWatchChecklist = workPermit.ConfinedSpaceSafetyWatchChecklist;

            SpecialWork = workPermit.SpecialWork;
            SpecialWorkType = workPermit.SpecialWorkType;
            HazardousWorkApproverAdvised = workPermit.HazardousWorkApproverAdvised;
            AdditionalFollowupRequired = workPermit.AdditionalFollowupRequired;

            StartDateTime = workPermit.StartDateTime;
            ExpireDateTime = workPermit.ExpireDateTime;

            WorkOrderNumber = workPermit.WorkOrderNumber;
            OperationNumber = workPermit.OperationNumber;
            SubOperationNumber = workPermit.SubOperationNumber;

            HighEnergy = workPermit.HighEnergy;
            CriticalLift = workPermit.CriticalLift;
            Excavation = workPermit.Excavation;
            EnergyControlPlanFormRequirement = workPermit.EnergyControlPlanFormRequirement;
            EquivalencyProc = workPermit.EquivalencyProc;
            TestPneumatic = workPermit.TestPneumatic;
            LiveFlareWork = workPermit.LiveFlareWork;
            EntryAndControlPlan = workPermit.EntryAndControlPlan;
            EnergizedElectrical = workPermit.EnergizedElectrical;

            TaskDescription = workPermit.TaskDescription;

            HazardHydrocarbonGas = workPermit.HazardHydrocarbonGas;
            HazardHydrocarbonLiquid = workPermit.HazardHydrocarbonLiquid;
            HazardHydrogenSulphide = workPermit.HazardHydrogenSulphide;
            HazardInertGasAtmosphere = workPermit.HazardInertGasAtmosphere;
            HazardOxygenDeficiency = workPermit.HazardOxygenDeficiency;
            HazardRadioactiveSources = workPermit.HazardRadioactiveSources;
            HazardUndergroundOverheadHazards = workPermit.HazardUndergroundOverheadHazards;
            HazardDesignatedSubstance = workPermit.HazardDesignatedSubstance;

            OtherHazardsAndOrRequirements = workPermit.OtherHazardsAndOrRequirements;

            OtherAreasAndOrUnitsAffected = workPermit.OtherAreasAndOrUnitsAffected;
            OtherAreasAndOrUnitsAffectedArea = workPermit.OtherAreasAndOrUnitsAffectedArea;
            OtherAreasAndOrUnitsAffectedPersonNotified = workPermit.OtherAreasAndOrUnitsAffectedPersonNotified;

            WorkPreparationsCompletedSectionNotApplicableToJob =
                workPermit.WorkPreparationsCompletedSectionNotApplicableToJob;
            ProductNormallyInPipingEquipment = workPermit.ProductNormallyInPipingEquipment;

            DepressuredDrained = YesNoNotApplicable.ToString(workPermit.DepressuredDrained);
            WaterWashed = YesNoNotApplicable.ToString(workPermit.WaterWashed);
            ChemicallyWashed = YesNoNotApplicable.ToString(workPermit.ChemicallyWashed);
            Steamed = YesNoNotApplicable.ToString(workPermit.Steamed);
            Purged = YesNoNotApplicable.ToString(workPermit.Purged);
            Disconnected = YesNoNotApplicable.ToString(workPermit.Disconnected);
            DepressuredAndVented = YesNoNotApplicable.ToString(workPermit.DepressuredAndVented);
            Ventilated = YesNoNotApplicable.ToString(workPermit.Ventilated);
            Blanked = YesNoNotApplicable.ToString(workPermit.Blanked);
            DrainsCovered = YesNoNotApplicable.ToString(workPermit.DrainsCovered);
            AreaBarricaded = YesNoNotApplicable.ToString(workPermit.AreaBarricaded);
            EnergySourcesLockedOutTaggedOut = YesNoNotApplicable.ToString(workPermit.EnergySourcesLockedOutTaggedOut);
            EnergyControlPlan = workPermit.EnergyControlPlan;
            LockBoxNumber = workPermit.LockBoxNumber;
            OtherPreparations = workPermit.OtherPreparations;

            SpecificRequirementsSectionNotApplicableToJob = workPermit.SpecificRequirementsSectionNotApplicableToJob;
            AttendedAtAllTimes = workPermit.AttendedAtAllTimes;
            EyeProtection = workPermit.EyeProtection;
            FallProtectionEquipment = workPermit.FallProtectionEquipment;
            FullBodyHarnessRetrieval = workPermit.FullBodyHarnessRetrieval;
            HearingProtection = workPermit.HearingProtection;
            ProtectiveClothing = workPermit.ProtectiveClothing;
            Other1Checked = workPermit.Other1Checked;
            Other1Value = workPermit.Other1Value;

            EquipmentBondedGrounded = workPermit.EquipmentBondedGrounded;
            FireBlanket = workPermit.FireBlanket;
            FireFightingEquipment = workPermit.FireFightingEquipment;
            FireWatch = workPermit.FireWatch;
            HydrantPermit = workPermit.HydrantPermit;
            WaterHose = workPermit.WaterHose;
            SteamHose = workPermit.SteamHose;
            Other2Checked = workPermit.Other2Checked;
            Other2Value = workPermit.Other2Value;

            AirMover = workPermit.AirMover;
            ContinuousGasMonitor = workPermit.ContinuousGasMonitor;
            DrowningProtection = workPermit.DrowningProtection;
            RespiratoryProtection = workPermit.RespiratoryProtection;
            Other3Checked = workPermit.Other3Checked;
            Other3Value = workPermit.Other3Value;

            AdditionalLighting = workPermit.AdditionalLighting;
            DesignateHotOrColdCutChecked = workPermit.DesignateHotOrColdCutChecked;
            DesignateHotOrColdCutValue = workPermit.DesignateHotOrColdCutValue;
            HoistingEquipment = workPermit.HoistingEquipment;
            Ladder = workPermit.Ladder;
            MotorizedEquipment = workPermit.MotorizedEquipment;
            Scaffold = workPermit.Scaffold;
            ReferToTipsProcedure = workPermit.ReferToTipsProcedure;

            GasDetectorBumpTested = workPermit.GasDetectorBumpTested;
            AtmosphericGasTestRequired = workPermit.AtmosphericGasTestRequired;
        }

        [IgnoreDifference]
        public long? PermitNumber { get; set; }

        public string PermitNumberDisplayValue
        {
            get { return WorkPermitLubes.GetPermitNumberDisplayValue(PermitNumber); }
        }

        public PermitRequestBasedWorkPermitStatus WorkPermitStatus { get; set; }

        public DateTime? IssuedDateTime { get; set; }
        public User IssuedBy { get; set; }

        public bool IssuedToSuncor { get; set; }
        public bool IssuedToCompany { get; set; }
        public string Company { get; set; }
        public string Trade { get; set; }
        public int? NumberOfWorkers { get; set; }
        public string RequestedByGroup { get; set; }

        public WorkPermitLubesType WorkPermitType { get; set; }
        public bool IsVehicleEntry { get; set; }

        public string FunctionalLocation { get; set; }
        public string Location { get; set; }

        public string DocumentLinks { get; set; }

        public bool ConfinedSpace { get; set; }
        public string ConfinedSpaceClass { get; set; }
        public bool RescuePlan { get; set; }
        public bool ConfinedSpaceSafetyWatchChecklist { get; set; }

        public bool SpecialWork { get; set; }
        public string SpecialWorkType { get; set; }
        public bool HazardousWorkApproverAdvised { get; set; }
        public bool AdditionalFollowupRequired { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }

        public string WorkOrderNumber { get; set; }
        public string OperationNumber { get; set; }
        public string SubOperationNumber { get; set; }

        public WorkPermitSafetyFormState HighEnergy { get; set; }
        public WorkPermitSafetyFormState CriticalLift { get; set; }
        public WorkPermitSafetyFormState Excavation { get; set; }
        public WorkPermitSafetyFormState EnergyControlPlanFormRequirement { get; set; }
        public WorkPermitSafetyFormState EquivalencyProc { get; set; }
        public WorkPermitSafetyFormState TestPneumatic { get; set; }
        public WorkPermitSafetyFormState LiveFlareWork { get; set; }
        public WorkPermitSafetyFormState EntryAndControlPlan { get; set; }
        public WorkPermitSafetyFormState EnergizedElectrical { get; set; }

        public string TaskDescription { get; set; }

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

        public bool WorkPreparationsCompletedSectionNotApplicableToJob { get; set; }
        public string ProductNormallyInPipingEquipment { get; set; }
        public string DepressuredDrained { get; set; }
        public string WaterWashed { get; set; }
        public string ChemicallyWashed { get; set; }
        public string Steamed { get; set; }
        public string Purged { get; set; }
        public string Disconnected { get; set; }
        public string DepressuredAndVented { get; set; }
        public string Ventilated { get; set; }
        public string Blanked { get; set; }
        public string DrainsCovered { get; set; }
        public string AreaBarricaded { get; set; }
        public string EnergySourcesLockedOutTaggedOut { get; set; }
        public string EnergyControlPlan { get; set; }
        public string LockBoxNumber { get; set; }
        public string OtherPreparations { get; set; }

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
        public bool AtmosphericGasTestRequired { get; set; }
    }
}