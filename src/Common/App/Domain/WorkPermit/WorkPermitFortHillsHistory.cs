using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitFortHillsHistory : DomainObjectHistorySnapshot
    {
        public WorkPermitFortHillsHistory(long id, User lastModifiedBy, DateTime lastModifiedDateTime)
            : base(id, lastModifiedBy, lastModifiedDateTime)
        {
        }

        public WorkPermitFortHillsHistory(WorkPermitFortHills workPermit)
            : base(workPermit.IdValue, workPermit.LastModifiedBy, workPermit.LastModifiedDateTime)
        {
            DataSource = workPermit.DataSource;
            PermitNumber = workPermit.PermitNumber;

            //IdValue = workPermit.Id.Value;
            WorkPermitStatus = workPermit.WorkPermitStatus;
            Company = workPermit.Company;
            Occupation = workPermit.Occupation;
            NumberOfWorkers = workPermit.NumberOfWorkers;
            FunctionalLocation = workPermit.FunctionalLocation.FullHierarchy;
            Location = workPermit.Location;
            RequestedStartDateTime = workPermit.RequestedStartDateTime;
            IssuedDateTime = workPermit.IssuedDateTime;
            ExpiredDateTime = workPermit.ExpiredDateTime;
            WorkOrderNumber = workPermit.WorkOrderNumber;
            OperationNumber = workPermit.OperationNumber;
            SubOperationNumber = workPermit.SubOperationNumber;
            TaskDescription = workPermit.TaskDescription;
            HazardsAndOrRequirements = workPermit.HazardsAndOrRequirements;
            IssuedToSuncor = workPermit.IssuedToSuncor;
            IssuedToCompany = workPermit.IssuedToCompany;
            Group = workPermit.Group != null ? workPermit.Group.Name : null;
            Priority = workPermit.Prioritydata;
            EquipmentNo = workPermit.EquipmentNo;
            Craft = workPermit.Craft;
            CrewSize = workPermit.CrewSize;
            JobCoordinator = workPermit.JobCoordinator;
            CoOrdContactNumber = workPermit.CoOrdContactNumber;
            EmergencyMeetingPoint = workPermit.EmergencyMeetingPoint;
            EmergencyAssemblyArea = workPermit.EmergencyAssemblyArea;
            LockBoxnumberChecked = workPermit.LockBoxnumberChecked;
            LockBoxNumber = workPermit.LockBoxNumber;
            IsolationNo = workPermit.IsolationNo;
            RevalidationDateTime = workPermit.RevalidationDateTime;
            ExtensionDateTime = workPermit.ExtensionDateTime;
            
            FlameResistantWorkWear = workPermit.FlameResistantWorkWear;
            ChemicalSuit = workPermit.ChemicalSuit;
            FireWatch = workPermit.FireWatch;
            FireBlanket = workPermit.FireBlanket;
            SuppliedBreathingAir = workPermit.SuppliedBreathingAir;
            AirMover = workPermit.AirMover;
            PersonalFlotationDevice = workPermit.PersonalFlotationDevice;
            HearingProtection = workPermit.HearingProtection;
            Other1 = workPermit.Other1;
            Other1Checked = workPermit.Other1Checked;
            MonoGoggles = workPermit.MonoGoggles;
            ConfinedSpaceMoniter = workPermit.ConfinedSpaceMoniter;
            FireExtinguisher = workPermit.FireExtinguisher;
            SparkContainment = workPermit.SparkContainment;
            BottleWatch = workPermit.BottleWatch;
            StandbyPerson = workPermit.StandbyPerson;
            WorkingAlone = workPermit.WorkingAlone;
            SafetyGloves = workPermit.SafetyGloves;
            Other2 = workPermit.Other2;
            Other2Checked = workPermit.Other2Checked;
            FaceShield = workPermit.FaceShield;
            FallProtection = workPermit.FallProtection;
            ChargedFireHouse = workPermit.ChargedFireHouse;
            CoveredSewer = workPermit.CoveredSewer;
            AirPurifyingRespirator = workPermit.AirPurifyingRespirator;
            SingalPerson = workPermit.SingalPerson;
            CommunicationDevice = workPermit.CommunicationDevice;
            ReflectiveStrips = workPermit.ReflectiveStrips;
            Other3 = workPermit.Other3;
            Other2Checked = workPermit.Other2Checked;
            ConfinedSpace = workPermit.ConfinedSpace;
            ConfinedSpaceClass = workPermit.ConfinedSpaceClass;
            GoundDisturbance = workPermit.GroundDisturbance;
            FireProtectionAuthorization = workPermit.FireProtectionAuthorization;
            CriticalOrSeriousLifts = workPermit.CriticalOrSeriousLifts;
            VehicleEntry = workPermit.VehicleEntry;
            IndustrialRadiography = workPermit.IndustrialRadiography;
            ElectricalEncroachment = workPermit.ElectricalEncroachment;
            MSDS = workPermit.MSDS;
            OthersPartE = workPermit.OthersPartE;
            OthersPartEChecked = workPermit.OthersPartEChecked;
            MechanicallyIsolated = workPermit.MechanicallyIsolated;
            BlindedOrBlanked = workPermit.BlindedOrBlanked;
            DoubleBlockedandBled = workPermit.DoubleBlockedandBled;
            DrainedAndDepressurised = workPermit.DrainedAndDepressurised;
            PurgedorNeutralised = workPermit.PurgedorNeutralised;
            ElectricallyIsolated = workPermit.ElectricallyIsolated;
            TestBumped = workPermit.TestBumped;
            NuclearSource = workPermit.NuclearSource;
            ReceiverStafingRequirements = workPermit.ReceiverStafingRequirements;

            WorkPermitType = workPermit.WorkPermitType;
           // DurationPermit = workPermit.DurationPermit; 
            DocumentLinks = workPermit.DocumentLinks.AsString(link => link.TitleWithUrl);
            ConfinedSpaceClass = workPermit.ConfinedSpaceClass;
            VehicleEntry = workPermit.VehicleEntry;
            PermitAcceptor = workPermit.PermitAcceptor;
            //ShiftSupervisor = workPermit.ShiftSupervisor;

        }

        public PermitRequestBasedWorkPermitStatus WorkPermitStatus { get; set; }
        public DataSource DataSource { get; set; }

        public string Company { get; set; }
        public string Occupation { get; set; }
        public int? NumberOfWorkers { get; set; }
        public WorkPermitFortHillsType WorkPermitType { get; set; }
        public bool DurationPermit { get; set; }
        public string FunctionalLocation { get; set; }
        public string Location { get; set; }
        public DateTime RequestedStartDateTime { get; set; }
        public DateTime RequestedOrIssuedDateTime
        {
            get { return IssuedDateTime != null ? IssuedDateTime.Value : RequestedStartDateTime; }
        }
        public DateTime? IssuedDateTime { get; set; }
        public DateTime ExpiredDateTime { get; set; }
        public long? PermitNumber { get; set; }
        public string WorkOrderNumber { get; set; }
        public string OperationNumber { get; set; }
        public string SubOperationNumber { get; set; }

        //PART D start
        public string TaskDescription { get; set; }
        public string HazardsAndOrRequirements { get; set; }
        //PART D end

        public DateTime CreatedDateTime { get; private set; }
        public User CreatedBy { get; private set; }
        public bool IssuedToSuncor { get; set; }
        public bool IssuedToCompany { get; set; }
        public string Group { get; set; }
        public User IssuedByUser { get; set; }
        public User PermitRequestCreatedByUser { get; set; }
        public Priority Priority { get; set; }

        public string EquipmentNo { get; set; }
        public string Craft { get; set; }
        public Int32? CrewSize { get; set; }
        public string JobCoordinator { get; set; }
        public string CoOrdContactNumber { get; set; }
        public string EmergencyAssemblyArea { get; set; }
        public string EmergencyMeetingPoint { get; set; }
        public string EmergencyContactNo { get; set; }
        public bool LockBoxnumberChecked { get; set; }
        public string LockBoxNumber { get; set; }
        public string IsolationNo { get; set; }
        public DateTime? RevalidationDateTime { get; set; }
        // public Time RevalidationTime { get; set; }
        public DateTime? ExtensionDateTime { get; set; }
        public string ExtensionReasonPartJ { get; set; }
        // public Time ExtensionTime { get; set; }


        public string DocumentLinks { get; set; }

        //PART C-1 SPECIALITY SAFETY EQUIPMENT REQUIREMENTS start
        public bool FlameResistantWorkWear { get; set; }
        public bool ChemicalSuit { get; set; }
        public bool FireWatch { get; set; }
        public bool FireBlanket { get; set; }
        public bool SuppliedBreathingAir { get; set; }
        public bool AirMover { get; set; }
        public bool PersonalFlotationDevice { get; set; }
        public bool HearingProtection { get; set; }
        public string Other1 { get; set; }
        public bool Other1Checked { get; set; }

        //PART C-2
        public bool MonoGoggles { get; set; }
        public bool ConfinedSpaceMoniter { get; set; }
        public bool FireExtinguisher { get; set; }
        public bool SparkContainment { get; set; }
        public bool BottleWatch { get; set; }
        public bool StandbyPerson { get; set; }
        public bool WorkingAlone { get; set; }
        public bool SafetyGloves { get; set; }
        public string Other2 { get; set; }
        public bool Other2Checked { get; set; }

        //PART C-3
        public bool FaceShield { get; set; }
        public bool FallProtection { get; set; }
        public bool ChargedFireHouse { get; set; }
        public bool CoveredSewer { get; set; }
        public bool AirPurifyingRespirator { get; set; }
        public bool SingalPerson { get; set; }
        public bool CommunicationDevice { get; set; }
        public bool ReflectiveStrips { get; set; }
        public string Other3 { get; set; }
        public bool Other3Checked { get; set; }

        // PART E WORK AUTHORIZATION AND OR DOCUMENTATION 
        public bool ConfinedSpace { get; set; }
        public string ConfinedSpaceClass { get; set; }
        public bool GoundDisturbance { get; set; }
        public bool FireProtectionAuthorization { get; set; }
        public bool CriticalOrSeriousLifts { get; set; }
        public bool VehicleEntry { get; set; }
        public bool IndustrialRadiography { get; set; }
        public bool ElectricalEncroachment { get; set; }
        public bool MSDS { get; set; }
        public bool OthersPartEChecked { get; set; }
        public string OthersPartE { get; set; }

        // PART F CONTROL OF HAZARDUS ENERGY - SAFING STATUS 
        public bool MechanicallyIsolated { get; set; }
        public bool BlindedOrBlanked { get; set; }
        public bool DoubleBlockedandBled { get; set; }
        public bool DrainedAndDepressurised { get; set; }
        public bool PurgedorNeutralised { get; set; }
        public bool ElectricallyIsolated { get; set; }
        public bool TestBumped { get; set; }
        public bool NuclearSource { get; set; }
        public bool ReceiverStafingRequirements { get; set; }
        
        public User RequestedByUser { get; set; }
        public string PermitAcceptor { get; set; }
        public string ShiftSupervisor { get; set; }

        public string ConfinedSpaceCardNumber { get; set; }

        /*Oxygen*/
        public string OxygenInitialEquip { get; set; }
        public string OxygenSecondEquip { get; set; }
        public string OxygenThirdEquip { get; set; }
        public string OxygenFourthEquip { get; set; }
        public string OxygenFifthEquip { get; set; }
        public string OxygenSixthEquip { get; set; }

        public string OxygenInitialArea { get; set; }
        public string OxygenSecondArea { get; set; }
        public string OxygenThirdArea { get; set; }
        public string OxygenFourthArea { get; set; }
        public string OxygenFifthArea { get; set; }
        public string OxygenSixthArea { get; set; }

        /*Lel*/
        public string LELInitialEquip { get; set; }
        public string LELSecondEquip { get; set; }
        public string LELThirdEquip { get; set; }
        public string LELFourthEquip { get; set; }
        public string LELFifthEquip { get; set; }
        public string LELSixthEquip { get; set; }

        public string LELInitialArea { get; set; }
        public string LELSecondArea { get; set; }
        public string LELThirdArea { get; set; }
        public string LELFourthArea { get; set; }
        public string LELFifthArea { get; set; }
        public string LELSixthArea { get; set; }

        /*H2SPPM*/
        public string H2SPPMInitialEquip { get; set; }
        public string H2SPPMSecondEquip { get; set; }
        public string H2SPPMThirdEquip { get; set; }
        public string H2SPPMFourthEquip { get; set; }
        public string H2SPPMFifthEquip { get; set; }
        public string H2SPPMSixthEquip { get; set; }

        public string H2SPPMInitialArea { get; set; }
        public string H2SPPMSecondArea { get; set; }
        public string H2SPPMThirdArea { get; set; }
        public string H2SPPMFourthArea { get; set; }
        public string H2SPPMFifthArea { get; set; }
        public string H2SPPMSixthArea { get; set; }

        /*CoPPM*/
        public string CoPPMInitialEquip { get; set; }
        public string CoPPMSecondEquip { get; set; }
        public string CoPPMThirdEquip { get; set; }
        public string CoPPMFourthEquip { get; set; }
        public string CoPPMFifthEquip { get; set; }
        public string CoPPMSixthEquip { get; set; }

        public string CoPPMInitialArea { get; set; }
        public string CoPPMSecondArea { get; set; }
        public string CoPPMThirdArea { get; set; }
        public string CoPPMFourthArea { get; set; }
        public string CoPPMFifthArea { get; set; }
        public string CoPPMSixthArea { get; set; }

        /*So2PPM*/
        public string So2PPMInitialEquip { get; set; }
        public string So2PPMSecondEquip { get; set; }
        public string So2PPMThirdEquip { get; set; }
        public string So2PPMFourthEquip { get; set; }
        public string So2PPMFifthEquip { get; set; }
        public string So2PPMSixthEquip { get; set; }

        public string So2PPMInitialArea { get; set; }
        public string So2PPMSecondArea { get; set; }
        public string So2PPMThirdArea { get; set; }
        public string So2PPMFourthArea { get; set; }
        public string So2PPMFifthArea { get; set; }
        public string So2PPMSixthArea { get; set; }

        /*Other1*/
        public string Other1InitialEquip { get; set; }
        public string Other2SecondEquip { get; set; }
        public string Other3ThirdEquip { get; set; }
        public string Other4FourthEquip { get; set; }
        public string Other5FifthEquip { get; set; }
        public string Other6SixthEquip { get; set; }

        public string Other1InitialArea { get; set; }
        public string Other2SecondArea { get; set; }
        public string Other3ThirdArea { get; set; }
        public string Other4FourthArea { get; set; }
        public string Other5FifthArea { get; set; }
        public string Other6SixthArea { get; set; }

        /*Other2*/
        public string Other2InitialEquip { get; set; }
        public string Other3SecondEquip { get; set; }
        public string Other4ThirdEquip { get; set; }
        public string Other5FourthEquip { get; set; }
        public string Other6FifthEquip { get; set; }
        public string Other7SixthEquip { get; set; }

        public string Other2InitialArea { get; set; }
        public string Other3SecondArea { get; set; }
        public string Other4ThirdArea { get; set; }
        public string Other5FourthArea { get; set; }
        public string Other6FifthArea { get; set; }
        public string Other7SixthArea { get; set; }

        /*Tester*/
        public string TimeOfTestInitial { get; set; }
        public string TimeOfTestSecond { get; set; }
        public string TimeOfTestThird { get; set; }
        public string TimeOfTestFourth { get; set; }
        public string TimeOfTestFifth { get; set; }
        public string TimeOfTestSixth { get; set; }

        public string TesterNameInitial { get; set; }
        public string TesterNameSecond { get; set; }
        public string TesterNameThird { get; set; }
        public string TesterNameFourth { get; set; }
        public string TesterNameFifth { get; set; }
        public string TesterNameSixth { get; set; }

        //public DataSource DataSource { get; set; }
        //public Priority Priority { get; set; }

        //public long? PermitNumber { get; set; }

        //public bool IssuedToSuncor { get; set; }
        //public bool IssuedToCompany { get; set; }
        //public string Company { get; set; }
        //public string Occupation { get; set; }
        //public int? NumberOfWorkers { get; set; }
        //public string Group { get; set; }
        //public WorkPermitFortHillsType WorkPermitType { get; set; }
        //public bool DurationPermit { get; set; }
        //public string FunctionalLocation { get; set; }
        //public string Location { get; set; }
        
        //public string AreaLabel { get; set; }

        //public bool AlkylationEntry { get; set; }
        //public string AlkylationEntryClassOfClothing { get; set; }
        //public bool FlarePitEntry { get; set; }
        //public string FlarePitEntryType { get; set; }

       // public bool ConfinedSpace { get; set; }
        
      //  public string ConfinedSpaceClass { get; set; }

        //public bool RescuePlan { get; set; }
        //public string RescuePlanFormNumber { get; set; }

        //public bool VehicleEntry { get; set; }
        //public int? VehicleEntryTotal { get; set; }
        //public string VehicleEntryType { get; set; }

        //public bool SpecialWork { get; set; }
        //public string SpecialWorkFormNumber { get; set; }
        //public string SpecialWorkType { get; set; }

        //mangesh for RoadAccessOnPermit
        //public bool RoadAccessOnPermit { get; set; }
        //public string RoadAccessOnPermitFormNumber { get; set; }
        //public string RoadAccessOnPermitType { get; set; }

        //public string SpecialWorkName { get; set; }

        //public bool GN59 { get; set; }
        //public long? FormGN59Id { get; set; }

        //public bool GN7 { get; set; }
        //public long? FormGN7Id { get; set; }

        //public bool GN24 { get; set; }
        //public long? FormGN24Id { get; set; }

        //public bool GN6 { get; set; }
        //public long? FormGN6Id { get; set; }

        //public bool GN75A { get; set; }
        //public long? FormGN75AId { get; set; }

        //public bool GN1 { get; set; }
        //public long? FormGN1Id { get; set; }
        //public string FormGN1TradeChecklistDisplayNumber { get; set; }

        //public string GN11 { get; set; }
        //public string GN6_Deprecated { get; set; }
        //public string GN24_Deprecated { get; set; }
        //public string GN75_Deprecated { get; set; }
        //public string GN27 { get; set; }

      //  public DateTime RequestedStartDateTime { get; set; }
      //  public DateTime? IssuedDateTime { get; set; }
      //  public DateTime ExpiredDateTime { get; set; }

      //  public string WorkOrderNumber { get; set; }
      //  public string OperationNumber { get; set; }
      //  public string SubOperationNumber { get; set; }

      //  public string TaskDescription { get; set; }

      //  public string HazardsAndOrRequirements { get; set; }

      //  public bool OtherAreasAndOrUnitsAffected { get; set; }
      //  public string OtherAreasAndOrUnitsAffectedArea { get; set; }
      //  public string OtherAreasAndOrUnitsAffectedPersonNotified { get; set; }

      //  // Status of Piping/Equipment
      //  public bool StatusOfPipingEquipmentSectionNotApplicableToJob { get; set; }
      //  public string ProductNormallyInPipingEquipment { get; set; }

      //  public string IsolationValvesLocked { get; set; }
      //  public string DepressuredDrained { get; set; }
      //  public string Ventilated { get; set; }
      //  public string Purged { get; set; }
      //  public string BlindedAndTagged { get; set; }
      //  public string DoubleBlockAndBleed { get; set; }
      //  public string ElectricalLockout { get; set; }
      //  public string MechanicalLockout { get; set; }
      //  public string BlindSchematicAvailable { get; set; }

      //  public string ZeroEnergyFormNumber { get; set; }
      //  public string LockBoxNumber { get; set; }
      //  public bool JobsiteEquipmentInspected { get; set; }


      //  // ayman Edmonton work permit
      //  public bool SignatureOfSiteInspected { get; set; }

        
      //  // Confined space work 
      //  public bool ConfinedSpaceWorkSectionNotApplicableToJob { get; set; }

      //  public string QuestionOneResponse { get; set; }
      //  public string QuestionTwoResponse { get; set; }
      //  public string QuestionTwoAResponse { get; set; }
      //  public string QuestionTwoBResponse { get; set; }
      //  public string QuestionThreeResponse { get; set; }
      //  public string QuestionFourResponse { get; set; }

      //  // Gas Tests
      //  public bool GasTestsSectionNotApplicableToJob { get; set; }
      //  public bool WorkerToProvideGasTestData { get; set; }
      //  public string OperatorGasDetectorNumber { get; set; }

      //  public string GasTestDataLine1CombustibleGas { get; set; }
      //  public string GasTestDataLine1Oxygen { get; set; }
      //  public string GasTestDataLine1ToxicGas { get; set; }
      //  public Time GasTestDataLine1Time { get; set; }

      //  public string GasTestDataLine2CombustibleGas { get; set; }
      //  public string GasTestDataLine2Oxygen { get; set; }
      //  public string GasTestDataLine2ToxicGas { get; set; }
      //  public Time GasTestDataLine2Time { get; set; }

      //  public string GasTestDataLine3CombustibleGas { get; set; }
      //  public string GasTestDataLine3Oxygen { get; set; }
      //  public string GasTestDataLine3ToxicGas { get; set; }
      //  public Time GasTestDataLine3Time { get; set; }

      //  public string GasTestDataLine4CombustibleGas { get; set; }
      //  public string GasTestDataLine4Oxygen { get; set; }
      //  public string GasTestDataLine4ToxicGas { get; set; }
      //  public Time GasTestDataLine4Time { get; set; }

      //  //Workers Minimum Safety Requirements
      //  public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; set; }

      //  public bool FaceShield { get; set; }
      //  public bool ChemicalSuit { get; set; }
      //  public bool RubberBoots { get; set; }
      //  public bool ConfinedSpaceMoniter { get; set; }
      ////  public bool RubberSuit { get; set; }
      //  public bool SuppliedBreathingAir { get; set; }
      //  public bool SafetyHarnessLifeline { get; set; }
      //  public bool PersonalFlotationDevice { get; set; }
      //  public bool Other1Checked { get; set; }
      //  public String Other1 { get; set; }

      // // public bool EquipmentGrounded { get; set; }
      //  public bool MonoGoggles { get; set; }
      //  public bool FireBlanket { get; set; }
      //  public bool FireExtinguisher { get; set; }
      //  public bool FireMonitorManned { get; set; }
      //  public bool FireWatch { get; set; }
      //  public bool SewersDrainsCovered { get; set; }
      //  public bool SteamHose { get; set; }
      //  public bool Other2Checked { get; set; }
      //  public String Other2 { get; set; }

      //  public bool AirPurifyingRespirator { get; set; }
      //  public bool BreathingAirApparatus { get; set; }
      //  public bool DustMask { get; set; }
      //  public bool LifeSupportSystem { get; set; }
      //  public bool SafetyWatch { get; set; }
      //  public bool ContinuousGasMonitor { get; set; }
      //  public bool WorkersMonitor { get; set; }
      //  public string WorkersMonitorNumber { get; set; }
      //  public bool BumpTestMonitorPriorToUse { get; set; }
      //  public bool Other3Checked { get; set; }
      //  public String Other3 { get; set; }

      //  public bool AirMover { get; set; }
      //  public bool BarriersSigns { get; set; }
      //  public bool RadioChannel { get; set; }
      //  public string RadioChannelNumber { get; set; }
      //  public bool AirHorn { get; set; }
      //  public bool MechVentilationComfortOnly { get; set; }
      //  public bool AsbestosMMCPrecautions { get; set; }
      //  public bool Other4Checked { get; set; }
      //  public String Other4 { get; set; }

      
      //  public bool UseCurrentPermitNumberForZeroEnergyFormNumber { get; set; }

      //  private string YesNoNotApplicableToString(YesNoNotApplicable value)
      //  {
      //      return YesNoNotApplicable.ToString(value);
      //  }
    }
}