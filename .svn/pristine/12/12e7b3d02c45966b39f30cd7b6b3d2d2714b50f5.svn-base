using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestLubesHistory : BasePermitRequestHistory
    {
        public PermitRequestLubesHistory(long id, User lastModifiedUser, DateTime lastModifiedDateTime)
            : base(id, lastModifiedUser, lastModifiedDateTime)
        {
        }

        public PermitRequestLubesHistory(PermitRequestLubes permitRequest)
            : base(
                permitRequest.IdValue, permitRequest.EndDate, permitRequest.WorkOrderNumber,
                permitRequest.OperationNumberListAsString, permitRequest.Description,
                permitRequest.SapDescription, permitRequest.Company, null, permitRequest.LastImportedByUser,
                permitRequest.LastImportedDateTime, permitRequest.LastSubmittedByUser,
                permitRequest.LastSubmittedDateTime,
                permitRequest.LastModifiedBy, permitRequest.LastModifiedDateTime)
        {
            CompletionStatus = permitRequest.CompletionStatus;
            IssuedToSuncor = permitRequest.IssuedToSuncor;
            IssuedToCompany = permitRequest.IssuedToCompany;
            Company = permitRequest.Company;
            Trade = permitRequest.Trade;
            NumberOfWorkers = permitRequest.NumberOfWorkers;
            RequestedByGroup = permitRequest.RequestedByGroup != null ? permitRequest.RequestedByGroup.Name : null;

            WorkPermitType = permitRequest.WorkPermitType;
            IsVehicleEntry = permitRequest.IsVehicleEntry;
            FunctionalLocation = permitRequest.FunctionalLocation.FullHierarchy;
            Location = permitRequest.Location;

            DocumentLinks = permitRequest.DocumentLinks.AsString(link => link.TitleWithUrl);

            ConfinedSpace = permitRequest.ConfinedSpace;
            ConfinedSpaceClass = permitRequest.ConfinedSpaceClass;
            RescuePlan = permitRequest.RescuePlan;
            ConfinedSpaceSafetyWatchChecklist = permitRequest.ConfinedSpaceSafetyWatchChecklist;
            SpecialWork = permitRequest.SpecialWork;
            SpecialWorkType = permitRequest.SpecialWorkType;

            RequestedStartDate = permitRequest.RequestedStartDate;
            RequestedStartTimeDay = permitRequest.RequestedStartTimeDay;
            RequestedStartTimeNight = permitRequest.RequestedStartTimeNight;

            SubOperationNumber = permitRequest.SubOperationNumberListAsString;

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

            GasDetectorBumpTested = permitRequest.GasDetectorBumpTested;
        }

        public bool IssuedToSuncor { get; set; }
        public bool IssuedToCompany { get; set; }
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

        public Date RequestedStartDate { get; set; }
        public Time RequestedStartTimeDay { get; set; }
        public Time RequestedStartTimeNight { get; set; }

        public string SubOperationNumber { get; set; }

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

        [IgnoreDifference]
        public PermitRequestCompletionStatus CompletionStatus { get; set; }

        public string Status
        {
            get { return CompletionStatus.GetName(); }
        }
    }
}