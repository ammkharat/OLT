using System;
using Castle.DynamicProxy.Generators.Emitters;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestFortHillsHistory : BasePermitRequestHistory
    {
        public PermitRequestFortHillsHistory(long id, User lastModifiedBy, DateTime lastModifiedDate)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
        }

        public PermitRequestFortHillsHistory(PermitRequestFortHills permitRequest)
            : base(
                permitRequest.IdValue, permitRequest.EndDate, permitRequest.WorkOrderNumber,
                permitRequest.OperationNumberListAsString, permitRequest.Description,
                permitRequest.SapDescription, permitRequest.Company, null, permitRequest.LastImportedByUser,
                permitRequest.LastImportedDateTime,
                permitRequest.LastSubmittedByUser, permitRequest.LastSubmittedDateTime, permitRequest.LastModifiedBy,
                permitRequest.LastModifiedDateTime)
        {

            IssuedToSuncor = permitRequest.IssuedToSuncor;
            IssuedToContractor = permitRequest.IssuedToContractor;
            Company = permitRequest.Company;
            Occupation = permitRequest.Occupation;
            NumberOfWorkers = permitRequest.NumberOfWorkers;
            Group = permitRequest.Group != null ? permitRequest.Group.Name : null;
            WorkOrderNumber = permitRequest.WorkOrderNumber;
            WorkPermitType = permitRequest.WorkPermitType;
            Priority = permitRequest.Priority;
            FunctionalLocation = permitRequest.FunctionalLocation.FullHierarchy;
            Location = permitRequest.Location;
            RequestedStartDate = permitRequest.RequestedStartDate;
            RequestedStartTime = permitRequest.RequestedStartTime;
            RequestedEndDate = permitRequest.EndDate;
            RequestedEndTime = permitRequest.RequestedEndTime;
            //RevalidationDate = permitRequest.RevalidationDate;
            //RevalidationTime = permitRequest.RevalidationTime;
            //ExtensionDate = permitRequest.ExtensionDate;
            //ExtensionTime = permitRequest.ExtensionTime;
            EquipmentNo = permitRequest.EquipmentNo;
            Craft = permitRequest.Craft;
            CrewSize = permitRequest.CrewSize;
            JobCoordinator = permitRequest.JobCoordinator;
            EmergencyMeetingPoint = permitRequest.EmergencyMeetingPoint;
            EmergencyContactNo = permitRequest.EmergencyContactNo;
            LockBoxNumber = permitRequest.LockBoxNumber;
            IsolationNo = permitRequest.IsolationNo;

            OperationNumber = permitRequest.OperationNumber;
            SubOperationNumber = permitRequest.SubOperationNumberListAsString;

            FlameResistantWorkWear = permitRequest.FlameResistantWorkWear;
            ChemicalSuit = permitRequest.ChemicalSuit;
            FireWatch = permitRequest.FireWatch;
            FireBlanket = permitRequest.FireBlanket;
            SuppliedBreathingAir = permitRequest.SuppliedBreathingAir;
            AirMover = permitRequest.AirMover;
            PersonalFlotationDevice = permitRequest.PersonalFlotationDevice;
            HearingProtection = permitRequest.HearingProtection;
            Other1 = permitRequest.Other1;
            MonoGoggles = permitRequest.MonoGoggles;
            ConfinedSpaceMoniter = permitRequest.ConfinedSpaceMoniter;
            FireExtinguisher = permitRequest.FireExtinguisher;
            SparkContainment = permitRequest.SparkContainment;
            BottleWatch = permitRequest.BottleWatch;
            StandbyPerson = permitRequest.StandbyPerson;
            WorkingAlone = permitRequest.WorkingAlone;
            SafetyGloves = permitRequest.SafetyGloves;
            Other2 = permitRequest.Other2;

            FaceShield = permitRequest.FaceShield;
            FallProtection = permitRequest.FallProtection;
            AirPurifyingRespirator = permitRequest.AirPurifyingRespirator;
            ChargedFireHouse = permitRequest.ChargedFireHouse;
            SingalPerson = permitRequest.SingalPerson;
            CommunicationDevice = permitRequest.CommunicationDevice;
            ReflectiveStrips = permitRequest.ReflectiveStrips;
            Other3 = permitRequest.Other3;
            
            HazardsAndOrRequirements = permitRequest.HazardsAndOrRequirements;
            ConfinedSpace = permitRequest.ConfinedSpace;
            ConfinedSpaceClass = permitRequest.ConfinedSpaceClass;

            GoundDisturbance = permitRequest.GroundDisturbance;
            FireProtectionAuthorization = permitRequest.FireProtectionAuthorization;
            CriticalOrSeriousLifts = permitRequest.CriticalOrSeriousLifts;
            VehicleEntry = permitRequest.VehicleEntry;
            IndustrialRadiography = permitRequest.IndustrialRadiography;
            ElectricalEncroachment = permitRequest.ElectricalEncroachment;
            MSDS = permitRequest.MSDS;
            OthersPartE = permitRequest.OthersPartE;
            MechanicallyIsolated = permitRequest.MechanicallyIsolated;
            BlindedOrBlanked = permitRequest.BlindedOrBlanked;
            DoubleBlockedandBled = permitRequest.DoubleBlockedandBled;
            DrainedAndDepressurised = permitRequest.DrainedAndDepressurised;
            PurgedorNeutralised = permitRequest.PurgedorNeutralised;
            ElectricallyIsolated = permitRequest.ElectricallyIsolated;
            TestBumped = permitRequest.TestBumped;
            NuclearSource = permitRequest.NuclearSource;
            ReceiverStafingRequirements = permitRequest.ReceiverStafingRequirements;
            CompletionStatus = permitRequest.CompletionStatus;


            DocumentLinks = permitRequest.DocumentLinks.AsString(link => link.TitleWithUrl);
           

         
           
            
            CompletionStatus = permitRequest.CompletionStatus;

            //AlkylationEntryClassOfClothing = permitRequest.AlkylationEntryClassOfClothing;
            //FlarePitEntryType = permitRequest.FlarePitEntryType;
            //ConfinedSpaceCardNumber = permitRequest.ConfinedSpaceCardNumber;
            //RescuePlanFormNumber = permitRequest.RescuePlanFormNumber;
            //VehicleEntryTotal = permitRequest.VehicleEntryTotal;
            //VehicleEntryType = permitRequest.VehicleEntryType;
            ////SpecialWorkType = permitRequest.SpecialWorkType != null ? permitRequest.SpecialWorkType.Name : null;
            //SpecialWorkType = permitRequest.specialworktype != null ? permitRequest.specialworktype.CompanyName : null;//mangesh for SpecialWork
            //SpecialWorkFormNumber = permitRequest.SpecialWorkFormNumber;
            //AlkylationEntry = permitRequest.AlkylationEntry;
            //FlarePitEntry = permitRequest.FlarePitEntry;
            //RescuePlan = permitRequest.RescuePlan;
           

            //FormGN59Id = permitRequest.FormGN59 == null ? null : permitRequest.FormGN59.Id;
            //FormGN7Id = permitRequest.FormGN7 == null ? null : permitRequest.FormGN7.Id;
            //FormGN6Id = permitRequest.FormGN6 == null ? null : permitRequest.FormGN6.Id;
            //FormGN24Id = permitRequest.FormGN24 == null ? null : permitRequest.FormGN24.Id;
            //FormGN75AId = permitRequest.FormGN75A == null ? null : permitRequest.FormGN75A.Id;
            //FormGN1TradeChecklistDisplayNumber = permitRequest.FormGN1TradeChecklistDisplayNumber;
            //GN59 = permitRequest.GN59;
            //GN7 = permitRequest.GN7;
            //GN6 = permitRequest.GN6;
            //GN24 = permitRequest.GN24;
            //GN75A = permitRequest.GN75A;
            //GN1 = permitRequest.GN1;
            //GN11 = permitRequest.GN11.ToString();
            //GN6_Deprecated = permitRequest.GN6_Deprecated.ToString();
            //GN24_Deprecated = permitRequest.GN24_Deprecated.ToString();
            //GN27 = permitRequest.GN27.ToString();
            //GN75_Deprecated = permitRequest.GN75_Deprecated.ToString();
            //RequestedStartTimeDay = permitRequest.RequestedStartTime;
            //RequestedStartTimeNight = permitRequest.RequestedEndTime;
            //OtherAreasAndOrUnitsAffectedArea = permitRequest.OtherAreasAndOrUnitsAffectedArea;
            //OtherAreasAndOrUnitsAffectedPersonNotified = permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified;
            //WorkersMinimumSafetyRequirementsSectionNotApplicableToJob =
            //    permitRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;
            // SafetyHarnessLifeline = permitRequest.SafetyHarnessLifeline;

            

            //LifeSupportSystem = permitRequest.LifeSupportSystem;
            //SafetyWatch = permitRequest.SafetyWatch;
            //ContinuousGasMonitor = permitRequest.ContinuousGasMonitor;
            //WorkersMonitor = permitRequest.WorkersMonitor;
            //WorkersMonitorNumber = permitRequest.WorkersMonitorNumber;
            //BumpTestMonitorPriorToUse = permitRequest.BumpTestMonitorPriorToUse;
            //RadioChannel = permitRequest.RadioChannel;
            //RadioChannelNumber = permitRequest.RadioChannelNumber;
            //AirHorn = permitRequest.AirHorn;
            //MechVentilationComfortOnly = permitRequest.MechVentilationComfortOnly;
            //AsbestosMMCPrecautions = permitRequest.AsbestosMMCPrecautions;
            //Other4 = permitRequest.Other4;
            //AreaLabel = permitRequest.AreaLabel == null ? null : permitRequest.AreaLabel.Name;
            ////mangesh for RoadAccessOnPermit and SpecialWork
            //RoadAccessOnPermit = permitRequest.RoadAccessOnPermit;
            //RoadAccessOnPermitFormNumber = permitRequest.RoadAccessOnPermitFormNumber;
            //RoadAccessOnPermitType = permitRequest.RoadAccessOnPermitType;
            //SpecialWorkName = permitRequest.SpecialWorkName;
        }

        public bool RoadAccessOnPermit { get; set; }
        public string RoadAccessOnPermitFormNumber { get; set; }
        public string RoadAccessOnPermitType { get; set; }
        //public string SpecialWorkName { get; set; }

        public string SubOperationNumber { get; set; }

        public bool IssuedToSuncor { get; set; }
        public bool IssuedToContractor { get; set; }

        public Priority Priority { get; set; }
        public string Occupation { get; set; }
        public int? NumberOfWorkers { get; set; }
        public string Group { get; set; }
        public WorkPermitFortHillsType WorkPermitType { get; set; }
        public string FunctionalLocation { get; set; }
        public string Location { get; set; }
        public string DocumentLinks { get; set; }
        public string AreaLabel { get; set; }
       
        public Date RequestedStartDate { get; set; }
        public Time RequestedStartTime { get; set; }
        public Date RequestedEndDate { get; set; }
        public Time RequestedEndTime { get; set; }

        public Date RevalidationDate { get; set; }
        public Time RevalidationTime { get; set; }
        public Date ExtensionDate { get; set; }
        public Time ExtensionTime { get; set; }
        public string Craft { get; set; }
        public Int32? CrewSize { get; set; }
        public string JobCoordinator { get; set; }
        public string CoOrdContactNumber { get; set; }
        public string EmergencyAssemblyArea { get; set; }
        public string EmergencyMeetingPoint { get; set; }
        public string EmergencyContactNo { get; set; }
        public string EquipmentNo { get; set; }

        public bool LockBoxnumberChecked { get; set; }
        public string LockBoxNumber { get; set; }
        public string IsolationNo { get; set; }

        public string WorkAndScopeDescription { get; set; }

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

        //PART C SPECIALITY SAFETY EQUIPMENT REQUIREMENTS End 

        //PART D  SAFETY PRECAUTIONS / HAZARDOUS
        public string HazardsAndOrRequirements { get; set; }
        
        // PART E WORK AUTHORIZATION AND OR DOCUMENTATION 
        // public List<string> ConfinedSpaceClassSelectionList { set; }
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


        public bool MechanicallyIsolated { get; set; }
        public bool BlindedOrBlanked { get; set; }
        public bool DoubleBlockedandBled { get; set; }
        public bool DrainedAndDepressurised { get; set; }
        public bool PurgedorNeutralised { get; set; }
        public bool ElectricallyIsolated { get; set; }
        public bool TestBumped { get; set; }
        public bool NuclearSource { get; set; }
        public bool ReceiverStafingRequirements { get; set; }
        /*
        public string AlkylationEntryClassOfClothing { get; set; }
        public string FlarePitEntryType { get; set; }
        public string ConfinedSpaceClass { get; set; }
        public string ConfinedSpaceCardNumber { get; set; }
        public string RescuePlanFormNumber { get; set; }
        public int? VehicleEntryTotal { get; set; }
        public string VehicleEntryType { get; set; }
        public string SpecialWorkType { get; set; }
        public string SpecialWorkFormNumber { get; set; }

        public bool AlkylationEntry { get; set; }
        public bool FlarePitEntry { get; set; }
        public bool ConfinedSpace { get; set; }
        public bool RescuePlan { get; set; }
        public bool VehicleEntry { get; set; }
        public bool SpecialWork { get; set; }
        */
        //public long? FormGN59Id { get; set; }
        //public long? FormGN6Id { get; set; }
        //public long? FormGN7Id { get; set; }
        //public long? FormGN24Id { get; set; }
        //public long? FormGN75AId { get; set; }
        //public string FormGN1TradeChecklistDisplayNumber { get; set; }

        //public bool GN59 { get; set; }
        //public bool GN7 { get; set; }
        //public bool GN24 { get; set; }
        //public bool GN6 { get; set; }
        //public bool GN75A { get; set; }
        //public bool GN1 { get; set; }

        //public string GN11 { get; set; }
        //public string GN24_Deprecated { get; set; }
        //public string GN6_Deprecated { get; set; }
        //public string GN27 { get; set; }
        //public string GN75_Deprecated { get; set; }

        //public Date RequestedStartDate { get; set; }
        //public Time RequestedStartTimeDay { get; set; }
        //public Time RequestedStartTimeNight { get; set; }

        //public string OtherAreasAndOrUnitsAffectedArea { get; set; }
        //public string OtherAreasAndOrUnitsAffectedPersonNotified { get; set; }

        //Workers Minimum Safety Requirements
       // public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; set; }
        /*
        public bool FaceShield { get; set; }
        public bool ChemicalSuit { get; set; }
        public bool RubberBoots { get; set; }
        public bool ConfinedSpaceMoniter { get; set; }
       // public bool RubberSuit { get; set; } 
        public bool SuppliedBreathingAir { get; set; }

        public bool SafetyHarnessLifeline { get; set; }
        public bool HighVoltagePPE { get; set; }
        public string Other1 { get; set; }

        //public bool EquipmentGrounded { get; set; }
        public bool MonoGoggles { get; set; }
        public bool FireBlanket { get; set; }
        public bool FireExtinguisher { get; set; }
        public bool FireMonitorManned { get; set; }
        public bool FireWatch { get; set; }
        public bool SewersDrainsCovered { get; set; }
        public bool SteamHose { get; set; }
        public string Other2 { get; set; }

        public bool AirPurifyingRespirator { get; set; }
        public bool BreathingAirApparatus { get; set; }
        public bool DustMask { get; set; }
        public bool LifeSupportSystem { get; set; }
        public bool SafetyWatch { get; set; }
        public bool ContinuousGasMonitor { get; set; }
        public bool WorkersMonitor { get; set; }
        public string WorkersMonitorNumber { get; set; }
        public bool BumpTestMonitorPriorToUse { get; set; }
        public string Other3 { get; set; }

        public bool AirMover { get; set; }
        public bool BarriersSigns { get; set; }
        public bool RadioChannel { get; set; }
        public string RadioChannelNumber { get; set; }
        public bool AirHorn { get; set; }
        public bool MechVentilationComfortOnly { get; set; }
        public bool AsbestosMMCPrecautions { get; set; }
        public string Other4 { get; set; }
       
       //[CachedRelationship]
       //public FormGN59 FormGN59 { get; set; }

       [CachedRelationship]
       public FormGN7 FormGN7 { get; set; }

       [CachedRelationship]
       public FormGN24 FormGN24 { get; set; }

       [CachedRelationship]
       public FormGN6 FormGN6 { get; set; }

       [CachedRelationship]
       public FormGN75A FormGN75A { get; set; }

       [CachedRelationship]
       public FormGN1 FormGN1 { get; set; }

       public long? FormGN1TradeChecklistId { get; set; }
       public string FormGN1TradeChecklistDisplayNumber { get; set; }

       //public bool GN59 { get; set; }
       public bool GN7 { get; set; }
       public bool GN24 { get; set; }
       public bool GN6 { get; set; }
       public bool GN75A { get; set; }
       public bool GN1 { get; set; }

       public WorkPermitSafetyFormState GN6_Deprecated { get; set; }
       public WorkPermitSafetyFormState GN11 { get; set; }
       public WorkPermitSafetyFormState GN24_Deprecated { get; set; }
       public WorkPermitSafetyFormState GN27 { get; set; }
       public WorkPermitSafetyFormState GN75_Deprecated { get; set; }
       */
        [IgnoreDifference]
        public PermitRequestCompletionStatus CompletionStatus { get; set; }

        public string Status
        {
            get { return CompletionStatus.GetName(); }
        }
    }
}