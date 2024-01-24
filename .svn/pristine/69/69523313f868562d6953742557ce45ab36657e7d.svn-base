using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitEdmontonHistory : DomainObjectHistorySnapshot
    {
        public WorkPermitEdmontonHistory(long id, User lastModifiedBy, DateTime lastModifiedDateTime)
            : base(id, lastModifiedBy, lastModifiedDateTime)
        {
        }

        public WorkPermitEdmontonHistory(WorkPermitEdmonton workPermit)
            : base(workPermit.IdValue, workPermit.LastModifiedBy, workPermit.LastModifiedDateTime)
        {
            IssuedDateTime = workPermit.IssuedDateTime;
            ExpiredDateTime = workPermit.ExpiredDateTime;
            RequestedStartDateTime = workPermit.RequestedStartDateTime;

            WorkPermitStatus = workPermit.WorkPermitStatus;
            DataSource = workPermit.DataSource;
            Priority = workPermit.Priority;

            PermitNumber = workPermit.PermitNumber;

            IssuedToSuncor = workPermit.IssuedToSuncor;
            IssuedToCompany = workPermit.IssuedToCompany;
            Company = workPermit.Company;
            Occupation = workPermit.Occupation;
            NumberOfWorkers = workPermit.NumberOfWorkers;
            Group = workPermit.Group != null ? workPermit.Group.Name : null;
            WorkPermitType = workPermit.WorkPermitType;
            DurationPermit = workPermit.DurationPermit;
            FunctionalLocation = workPermit.FunctionalLocation.FullHierarchy;
            Location = workPermit.Location;
            DocumentLinks = workPermit.DocumentLinks.AsString(link => link.TitleWithUrl);
            AreaLabel = workPermit.AreaLabel == null ? null : workPermit.AreaLabel.Name;

            AlkylationEntry = workPermit.AlkylationEntry;
            AlkylationEntryClassOfClothing = workPermit.AlkylationEntryClassOfClothing;
            FlarePitEntry = workPermit.FlarePitEntry;
            FlarePitEntryType = workPermit.FlarePitEntryType;

            ConfinedSpace = workPermit.ConfinedSpace;
            ConfinedSpaceCardNumber = workPermit.ConfinedSpaceCardNumber;
            ConfinedSpaceClass = workPermit.ConfinedSpaceClass;

            RescuePlan = workPermit.RescuePlan;
            RescuePlanFormNumber = workPermit.RescuePlanFormNumber;

            VehicleEntry = workPermit.VehicleEntry;
            VehicleEntryTotal = workPermit.VehicleEntryTotal;
            VehicleEntryType = workPermit.VehicleEntryType;

            SpecialWork = workPermit.SpecialWork;
            SpecialWorkFormNumber = workPermit.SpecialWorkFormNumber;
            //SpecialWorkType = workPermit.SpecialWorkType != null ? workPermit.SpecialWorkType.Name : null;
            SpecialWorkType = workPermit.specialworktype != null ? workPermit.specialworktype.CompanyName : null;//mangesh for SpecialWork

            GN59 = workPermit.GN59;
            FormGN59Id = workPermit.FormGN59 == null ? null : workPermit.FormGN59.Id;
            GN7 = workPermit.GN7;
            FormGN7Id = workPermit.FormGN7 == null ? null : workPermit.FormGN7.Id;
            GN24 = workPermit.GN24;
            FormGN24Id = workPermit.FormGN24 == null ? null : workPermit.FormGN24.Id;
            GN6 = workPermit.GN6;
            FormGN6Id = workPermit.FormGN6 == null ? null : workPermit.FormGN6.Id;
            GN75A = workPermit.GN75A;
            FormGN75AId = workPermit.FormGN75A == null ? null : workPermit.FormGN75A.Id;
            GN1 = workPermit.GN1;
            FormGN1Id = workPermit.FormGN1 == null ? null : workPermit.FormGN1.Id;
            FormGN1TradeChecklistDisplayNumber = workPermit.FormGN1TradeChecklistDisplayNumber;

            GN11 = workPermit.GN11.ToString();
            GN6_Deprecated = workPermit.GN24_Deprecated.ToString();
            GN24_Deprecated = workPermit.GN24_Deprecated.ToString();
            GN27 = workPermit.GN27.ToString();
            GN75_Deprecated = workPermit.GN75_Deprecated.ToString();

            WorkOrderNumber = workPermit.WorkOrderNumber;
            OperationNumber = workPermit.OperationNumber;
            SubOperationNumber = workPermit.SubOperationNumber;

            TaskDescription = workPermit.TaskDescription;
            HazardsAndOrRequirements = workPermit.HazardsAndOrRequirements;

            OtherAreasAndOrUnitsAffected = workPermit.OtherAreasAndOrUnitsAffected;
            OtherAreasAndOrUnitsAffectedArea = workPermit.OtherAreasAndOrUnitsAffectedArea;
            OtherAreasAndOrUnitsAffectedPersonNotified = workPermit.OtherAreasAndOrUnitsAffectedPersonNotified;

            StatusOfPipingEquipmentSectionNotApplicableToJob =
                workPermit.StatusOfPipingEquipmentSectionNotApplicableToJob;
            ProductNormallyInPipingEquipment = workPermit.ProductNormallyInPipingEquipment;
            IsolationValvesLocked = YesNoNotApplicableToString(workPermit.IsolationValvesLocked);
            DepressuredDrained = YesNoNotApplicableToString(workPermit.DepressuredDrained);
            Ventilated = YesNoNotApplicableToString(workPermit.Ventilated);
            Purged = YesNoNotApplicableToString(workPermit.Purged);
            BlindedAndTagged = YesNoNotApplicableToString(workPermit.BlindedAndTagged);
            DoubleBlockAndBleed = YesNoNotApplicableToString(workPermit.DoubleBlockAndBleed);
            ElectricalLockout = YesNoNotApplicableToString(workPermit.ElectricalLockout);
            MechanicalLockout = YesNoNotApplicableToString(workPermit.MechanicalLockout);
            BlindSchematicAvailable = YesNoNotApplicableToString(workPermit.BlindSchematicAvailable);
            ZeroEnergyFormNumber = workPermit.ZeroEnergyFormNumber;
            LockBoxNumber = workPermit.LockBoxNumber;
            JobsiteEquipmentInspected = workPermit.JobsiteEquipmentInspected;

            //ayman Edmonton work permit
            SignatureOfSiteInspected = workPermit.SignatureOfSiteInspected;

            ConfinedSpaceWorkSectionNotApplicableToJob = workPermit.ConfinedSpaceWorkSectionNotApplicableToJob;
            QuestionOneResponse = YesNoNotApplicableToString(workPermit.QuestionOneResponse);
            QuestionTwoResponse = YesNoNotApplicableToString(workPermit.QuestionTwoResponse);
            QuestionTwoAResponse = YesNoNotApplicableToString(workPermit.QuestionTwoAResponse);
            QuestionTwoBResponse = YesNoNotApplicableToString(workPermit.QuestionTwoBResponse);
            QuestionThreeResponse = YesNoNotApplicableToString(workPermit.QuestionThreeResponse);
            QuestionFourResponse = YesNoNotApplicableToString(workPermit.QuestionFourResponse);

            GasTestsSectionNotApplicableToJob = workPermit.GasTestsSectionNotApplicableToJob;
            WorkerToProvideGasTestData = workPermit.WorkerToProvideGasTestData;
            OperatorGasDetectorNumber = workPermit.OperatorGasDetectorNumber;

            GasTestDataLine1CombustibleGas = workPermit.GasTestDataLine1CombustibleGas;
            GasTestDataLine1Oxygen = workPermit.GasTestDataLine1Oxygen;
            GasTestDataLine1ToxicGas = workPermit.GasTestDataLine1ToxicGas;
            GasTestDataLine1Time = workPermit.GasTestDataLine1Time;

            GasTestDataLine2CombustibleGas = workPermit.GasTestDataLine2CombustibleGas;
            GasTestDataLine2Oxygen = workPermit.GasTestDataLine2Oxygen;
            GasTestDataLine2ToxicGas = workPermit.GasTestDataLine2ToxicGas;
            GasTestDataLine2Time = workPermit.GasTestDataLine2Time;

            GasTestDataLine3CombustibleGas = workPermit.GasTestDataLine3CombustibleGas;
            GasTestDataLine3Oxygen = workPermit.GasTestDataLine3Oxygen;
            GasTestDataLine3ToxicGas = workPermit.GasTestDataLine3ToxicGas;
            GasTestDataLine3Time = workPermit.GasTestDataLine3Time;

            GasTestDataLine4CombustibleGas = workPermit.GasTestDataLine4CombustibleGas;
            GasTestDataLine4Oxygen = workPermit.GasTestDataLine4Oxygen;
            GasTestDataLine4ToxicGas = workPermit.GasTestDataLine4ToxicGas;
            GasTestDataLine4Time = workPermit.GasTestDataLine4Time;

            WorkersMinimumSafetyRequirementsSectionNotApplicableToJob =
                workPermit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

            FaceShield = workPermit.FaceShield;
            Goggles = workPermit.Goggles;
            RubberBoots = workPermit.RubberBoots;
            RubberGloves = workPermit.RubberGloves;
            RubberSuit = workPermit.RubberSuit;
            SafetyHarnessLifeline = workPermit.SafetyHarnessLifeline;
            HighVoltagePPE = workPermit.HighVoltagePPE;
            Other1Checked = workPermit.Other1Checked;
            Other1 = workPermit.Other1;

            EquipmentGrounded = workPermit.EquipmentGrounded;
            FireBlanket = workPermit.FireBlanket;
            FireExtinguisher = workPermit.FireExtinguisher;
            FireMonitorManned = workPermit.FireMonitorManned;
            FireWatch = workPermit.FireWatch;
            SewersDrainsCovered = workPermit.SewersDrainsCovered;
            SteamHose = workPermit.SteamHose;
            Other2Checked = workPermit.Other2Checked;
            Other2 = workPermit.Other2;

            AirPurifyingRespirator = workPermit.AirPurifyingRespirator;
            BreathingAirApparatus = workPermit.BreathingAirApparatus;
            DustMask = workPermit.DustMask;
            LifeSupportSystem = workPermit.LifeSupportSystem;
            SafetyWatch = workPermit.SafetyWatch;
            ContinuousGasMonitor = workPermit.ContinuousGasMonitor;
            WorkersMonitor = workPermit.WorkersMonitor;
            WorkersMonitorNumber = workPermit.WorkersMonitorNumber;
            BumpTestMonitorPriorToUse = workPermit.BumpTestMonitorPriorToUse;
            Other3Checked = workPermit.Other3Checked;
            Other3 = workPermit.Other3;

            AirMover = workPermit.AirMover;
            BarriersSigns = workPermit.BarriersSigns;
            RadioChannel = workPermit.RadioChannel;
            RadioChannelNumber = workPermit.RadioChannelNumber;
            AirHorn = workPermit.AirHorn;
            MechVentilationComfortOnly = workPermit.MechVentilationComfortOnly;
            AsbestosMMCPrecautions = workPermit.AsbestosMMCPrecautions;
            Other4Checked = workPermit.Other4Checked;
            Other4 = workPermit.Other4;

            UseCurrentPermitNumberForZeroEnergyFormNumber = workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber;
            PermitAcceptor = workPermit.PermitAcceptor;
            ShiftSupervisor = workPermit.ShiftSupervisor;

            //mangesh for RoadAccessOnPermit & SpecialWork
            RoadAccessOnPermit = workPermit.RoadAccessOnPermit;
            RoadAccessOnPermitFormNumber = workPermit.RoadAccessOnPermitFormNumber;
            RoadAccessOnPermitType = workPermit.RoadAccessOnPermitType;

            SpecialWorkName = workPermit.SpecialWorkName;
        }

        public PermitRequestBasedWorkPermitStatus WorkPermitStatus { get; set; }
        public DataSource DataSource { get; set; }
        public Priority Priority { get; set; }

        public long? PermitNumber { get; set; }

        public bool IssuedToSuncor { get; set; }
        public bool IssuedToCompany { get; set; }
        public string Company { get; set; }
        public string Occupation { get; set; }
        public int? NumberOfWorkers { get; set; }
        public string Group { get; set; }
        public WorkPermitEdmontonType WorkPermitType { get; set; }
        public bool DurationPermit { get; set; }
        public string FunctionalLocation { get; set; }
        public string Location { get; set; }
        public string DocumentLinks { get; set; }
        public string AreaLabel { get; set; }

        public bool AlkylationEntry { get; set; }
        public string AlkylationEntryClassOfClothing { get; set; }
        public bool FlarePitEntry { get; set; }
        public string FlarePitEntryType { get; set; }

        public bool ConfinedSpace { get; set; }
        public string ConfinedSpaceCardNumber { get; set; }
        public string ConfinedSpaceClass { get; set; }

        public bool RescuePlan { get; set; }
        public string RescuePlanFormNumber { get; set; }

        public bool VehicleEntry { get; set; }
        public int? VehicleEntryTotal { get; set; }
        public string VehicleEntryType { get; set; }

        public bool SpecialWork { get; set; }
        public string SpecialWorkFormNumber { get; set; }
        public string SpecialWorkType { get; set; }

        //mangesh for RoadAccessOnPermit
        public bool RoadAccessOnPermit { get; set; }
        public string RoadAccessOnPermitFormNumber { get; set; }
        public string RoadAccessOnPermitType { get; set; }

        public string SpecialWorkName { get; set; }

        public bool GN59 { get; set; }
        public long? FormGN59Id { get; set; }

        public bool GN7 { get; set; }
        public long? FormGN7Id { get; set; }

        public bool GN24 { get; set; }
        public long? FormGN24Id { get; set; }

        public bool GN6 { get; set; }
        public long? FormGN6Id { get; set; }

        public bool GN75A { get; set; }
        public long? FormGN75AId { get; set; }

        public bool GN1 { get; set; }
        public long? FormGN1Id { get; set; }
        public string FormGN1TradeChecklistDisplayNumber { get; set; }

        public string GN11 { get; set; }
        public string GN6_Deprecated { get; set; }
        public string GN24_Deprecated { get; set; }
        public string GN75_Deprecated { get; set; }
        public string GN27 { get; set; }

        public DateTime RequestedStartDateTime { get; set; }
        public DateTime? IssuedDateTime { get; set; }
        public DateTime ExpiredDateTime { get; set; }

        public string WorkOrderNumber { get; set; }
        public string OperationNumber { get; set; }
        public string SubOperationNumber { get; set; }

        public string TaskDescription { get; set; }

        public string HazardsAndOrRequirements { get; set; }

        public bool OtherAreasAndOrUnitsAffected { get; set; }
        public string OtherAreasAndOrUnitsAffectedArea { get; set; }
        public string OtherAreasAndOrUnitsAffectedPersonNotified { get; set; }

        // Status of Piping/Equipment
        public bool StatusOfPipingEquipmentSectionNotApplicableToJob { get; set; }
        public string ProductNormallyInPipingEquipment { get; set; }

        public string IsolationValvesLocked { get; set; }
        public string DepressuredDrained { get; set; }
        public string Ventilated { get; set; }
        public string Purged { get; set; }
        public string BlindedAndTagged { get; set; }
        public string DoubleBlockAndBleed { get; set; }
        public string ElectricalLockout { get; set; }
        public string MechanicalLockout { get; set; }
        public string BlindSchematicAvailable { get; set; }

        public string ZeroEnergyFormNumber { get; set; }
        public string LockBoxNumber { get; set; }
        public bool JobsiteEquipmentInspected { get; set; }


        // ayman Edmonton work permit
        public bool SignatureOfSiteInspected { get; set; }

        
        // Confined space work 
        public bool ConfinedSpaceWorkSectionNotApplicableToJob { get; set; }

        public string QuestionOneResponse { get; set; }
        public string QuestionTwoResponse { get; set; }
        public string QuestionTwoAResponse { get; set; }
        public string QuestionTwoBResponse { get; set; }
        public string QuestionThreeResponse { get; set; }
        public string QuestionFourResponse { get; set; }

        // Gas Tests
        public bool GasTestsSectionNotApplicableToJob { get; set; }
        public bool WorkerToProvideGasTestData { get; set; }
        public string OperatorGasDetectorNumber { get; set; }

        public string GasTestDataLine1CombustibleGas { get; set; }
        public string GasTestDataLine1Oxygen { get; set; }
        public string GasTestDataLine1ToxicGas { get; set; }
        public Time GasTestDataLine1Time { get; set; }

        public string GasTestDataLine2CombustibleGas { get; set; }
        public string GasTestDataLine2Oxygen { get; set; }
        public string GasTestDataLine2ToxicGas { get; set; }
        public Time GasTestDataLine2Time { get; set; }

        public string GasTestDataLine3CombustibleGas { get; set; }
        public string GasTestDataLine3Oxygen { get; set; }
        public string GasTestDataLine3ToxicGas { get; set; }
        public Time GasTestDataLine3Time { get; set; }

        public string GasTestDataLine4CombustibleGas { get; set; }
        public string GasTestDataLine4Oxygen { get; set; }
        public string GasTestDataLine4ToxicGas { get; set; }
        public Time GasTestDataLine4Time { get; set; }

        //Workers Minimum Safety Requirements
        public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; set; }

        public bool FaceShield { get; set; }
        public bool Goggles { get; set; }
        public bool RubberBoots { get; set; }
        public bool RubberGloves { get; set; }
        public bool RubberSuit { get; set; }
        public bool SafetyHarnessLifeline { get; set; }
        public bool HighVoltagePPE { get; set; }
        public bool Other1Checked { get; set; }
        public String Other1 { get; set; }

        public bool EquipmentGrounded { get; set; }
        public bool FireBlanket { get; set; }
        public bool FireExtinguisher { get; set; }
        public bool FireMonitorManned { get; set; }
        public bool FireWatch { get; set; }
        public bool SewersDrainsCovered { get; set; }
        public bool SteamHose { get; set; }
        public bool Other2Checked { get; set; }
        public String Other2 { get; set; }

        public bool AirPurifyingRespirator { get; set; }
        public bool BreathingAirApparatus { get; set; }
        public bool DustMask { get; set; }
        public bool LifeSupportSystem { get; set; }
        public bool SafetyWatch { get; set; }
        public bool ContinuousGasMonitor { get; set; }
        public bool WorkersMonitor { get; set; }
        public string WorkersMonitorNumber { get; set; }
        public bool BumpTestMonitorPriorToUse { get; set; }
        public bool Other3Checked { get; set; }
        public String Other3 { get; set; }

        public bool AirMover { get; set; }
        public bool BarriersSigns { get; set; }
        public bool RadioChannel { get; set; }
        public string RadioChannelNumber { get; set; }
        public bool AirHorn { get; set; }
        public bool MechVentilationComfortOnly { get; set; }
        public bool AsbestosMMCPrecautions { get; set; }
        public bool Other4Checked { get; set; }
        public String Other4 { get; set; }

        public User RequestedByUser { get; set; }
        public string PermitAcceptor { get; set; }
        public string ShiftSupervisor { get; set; }
        public bool UseCurrentPermitNumberForZeroEnergyFormNumber { get; set; }

        private string YesNoNotApplicableToString(YesNoNotApplicable value)
        {
            return YesNoNotApplicable.ToString(value);
        }
    }
}