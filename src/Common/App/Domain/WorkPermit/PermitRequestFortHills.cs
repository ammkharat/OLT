using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Validation.FortHills;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.Utils.Internal;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestFortHills : BaseMergeablePermitRequest
    {
        public PermitRequestFortHills(long? id, Date endDate, string description, string sapDescription, string company,
            DataSource dataSource, User lastImportedByUser,
            DateTime? lastImportedDateTime, User lastSubmittedByUser, DateTime? lastSubmittedDateTime, User createdBy,
            DateTime createdDateTime,
            User lastModifiedBy, DateTime lastModifiedDateTime) :
                base(id, endDate, description, sapDescription, company, dataSource,
                    lastImportedByUser, lastImportedDateTime, lastSubmittedByUser,
                    lastSubmittedDateTime, createdBy, createdDateTime, lastModifiedBy,
                    lastModifiedDateTime, null, null, null, PermitRequestCompletionStatus.Incomplete)
           
        {
           
            //WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = true;
            Priority = Priority.Normal;
        }

        public bool IssuedToSuncor { get; set; }
        public bool IssuedToContractor { get; set; }
        public string Occupation { get; set; }
        public int? NumberOfWorkers { get; set; }
        public WorkPermitFortHillsGroup Group { get; set; }
        public WorkPermitFortHillsType WorkPermitType { get; set; }
        public FunctionalLocation FunctionalLocation { get; set; }
        public string Location { get; set; }
        public Priority Priority { get; set; }

      /*
       [CachedRelationship]
       public AreaLabel AreaLabel { get; set; }

       public string AlkylationEntryClassOfClothing { get; set; }
       public string FlarePitEntryType { get; set; }
        
       public string ConfinedSpaceCardNumber { get; set; }
       public string RescuePlanFormNumber { get; set; }
       public int? VehicleEntryTotal { get; set; }
       public string VehicleEntryType { get; set; }
       public FortHillsPermitSpecialWorkType SpecialWorkType { get; set; }
       public string SpecialWorkFormNumber { get; set; }
//       mangesh for RoadAccessOnPermit
       public bool RoadAccessOnPermit { get; set; }
       public string RoadAccessOnPermitFormNumber { get; set; }
       public string RoadAccessOnPermitType { get; set; }
       public bool AlkylationEntry { get; set; }
       public bool FlarePitEntry { get; set; }
       public bool RescuePlan { get; set; }
       public bool SpecialWork { get; set; }
       public SpecialWork Specialworktype { get; set; }//mangesh for SpecialWork
       public string SpecialWorkName { get; set; }
       [CachedRelationship]
       public FormGN59 FormGN59 { get; set; }
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
       public bool GN59 { get; set; }
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
        public Date RequestedStartDate { get; set; }
        public Time RequestedStartTime { get; set; }
       // public Date RequestedEndDate { get; set; }
        public Time RequestedEndTime { get; set; }

        //public Date RevalidationDate { get; set; }
        //public Time RevalidationTime { get; set; }
        //public Date ExtensionDate { get; set; }
        //public Time ExtensionTime { get; set; }
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

        //PART B SPECIALITY SAFETY EQUIPMENT REQUIREMENTS start
        // description (WorkAndScopeDescription) and SAP description from base class
        public bool IsSAPDescriptionAvailableForDisplay
        {
            get { return DataSource == DataSource.SAP && SapDescription != Description; }
        }

        //PART C-1 SPECIALITY SAFETY EQUIPMENT REQUIREMENTS start
        public bool PartCWorkSectionNotApplicableToJob { get; set; }
        public bool FlameResistantWorkWear{ get; set; }
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
        public bool PartDWorkSectionNotApplicableToJob { get; set; }
        public string HazardsAndOrRequirements { get; set; }
        
        // PART E WORK AUTHORIZATION AND OR DOCUMENTATION 
       // public List<string> ConfinedSpaceClassSelectionList { set; }
        public bool PartEWorkSectionNotApplicableToJob { get; set; }

        public bool ConfinedSpace { get; set; }
        public string ConfinedSpaceClass { get; set; }
        public bool GroundDisturbance { get; set; }
        public bool FireProtectionAuthorization { get; set; }
        public bool CriticalOrSeriousLifts { get; set; }
        public bool VehicleEntry { get; set; }
        public bool IndustrialRadiography { get; set; }
        public bool ElectricalEncroachment { get; set; }
        public bool MSDS { get; set; }
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


        public override string FunctionalLocationNamesAsString
        {
            get { return FunctionalLocation.FullHierarchy; }
        }

        
        public static bool IsSubmittableStatus(PermitRequestCompletionStatus completionStatus)
        {
            return PermitRequestCompletionStatus.Complete.Equals(completionStatus) ||
                   PermitRequestCompletionStatus.ForReview.Equals(completionStatus);
        }

        public override void UpdateFrom(BasePermitRequest baseRequest)
        {
            ClearWorkOrderSources();

            var request = (PermitRequestFortHills) baseRequest;
           
            IssuedToSuncor = request.IssuedToSuncor;
            IssuedToContractor = request.IssuedToContractor;
            Company = request.Company;
            Occupation = request.Occupation;
            NumberOfWorkers = request.NumberOfWorkers;
            Group = request.Group;
            WorkOrderNumber = request.WorkOrderNumber;
            request.WorkOrderSourceList.ForEach(AddWorkOrderSource);
            WorkPermitType = request.WorkPermitType;
            Priority = request.Priority;
            FunctionalLocation = request.FunctionalLocation;
            Location = request.Location;

            RequestedStartDate = request.RequestedStartDate;
            RequestedStartTime = request.RequestedStartTime;
            EndDate = request.EndDate;
            RequestedEndTime = request.RequestedEndTime;
            //RevalidationDate = request.RevalidationDate;
            //RevalidationTime = request.RevalidationTime;
            //ExtensionDate = request.ExtensionDate;
            //ExtensionTime = request.ExtensionTime;
            EquipmentNo = request.EquipmentNo;

            Description = request.Description;
            SapDescription = request.SapDescription;

            //Craft = request.Craft;
            //CrewSize = request.CrewSize;
            JobCoordinator = request.JobCoordinator;
            CoOrdContactNumber = request.CoOrdContactNumber;
            EmergencyMeetingPoint = request.EmergencyMeetingPoint;
            EmergencyContactNo = request.EmergencyContactNo;
            LockBoxNumber = request.LockBoxNumber;
            IsolationNo = request.IsolationNo;

            PartCWorkSectionNotApplicableToJob = request.PartCWorkSectionNotApplicableToJob;
            FlameResistantWorkWear = request.FlameResistantWorkWear;
            ChemicalSuit = request.ChemicalSuit;
            FireWatch = request.FireWatch;
            FireBlanket = request.FireBlanket;
            SuppliedBreathingAir = request.SuppliedBreathingAir;
            AirMover = request.AirMover;
            PersonalFlotationDevice = request.PersonalFlotationDevice;
            HearingProtection = request.HearingProtection;
            Other1 = request.Other1;
            MonoGoggles = request.MonoGoggles;
            ConfinedSpaceMoniter = request.ConfinedSpaceMoniter;
            FireExtinguisher = request.FireExtinguisher;
            SparkContainment = request.SparkContainment;
            BottleWatch = request.BottleWatch;
            StandbyPerson = request.StandbyPerson;
            WorkingAlone = request.WorkingAlone;
            SafetyGloves = request.SafetyGloves;
            Other2 = request.Other2;
            FaceShield = request.FaceShield;
            FallProtection = request.FallProtection;
            ChargedFireHouse = request.ChargedFireHouse;
            CoveredSewer = request.CoveredSewer;
            AirPurifyingRespirator = request.AirPurifyingRespirator;
            SingalPerson = request.SingalPerson;
            CommunicationDevice = request.CommunicationDevice;
            ReflectiveStrips = request.ReflectiveStrips;
            Other3 = request.Other3;

            PartDWorkSectionNotApplicableToJob = request.PartDWorkSectionNotApplicableToJob;
            HazardsAndOrRequirements = request.HazardsAndOrRequirements;

            PartEWorkSectionNotApplicableToJob = request.PartEWorkSectionNotApplicableToJob;
            ConfinedSpace = request.ConfinedSpace;
            ConfinedSpaceClass = request.ConfinedSpaceClass;
            GroundDisturbance = request.GroundDisturbance;
            FireProtectionAuthorization = request.FireProtectionAuthorization;
            CriticalOrSeriousLifts = request.CriticalOrSeriousLifts;
            VehicleEntry = request.VehicleEntry;
            IndustrialRadiography = request.IndustrialRadiography;
            ElectricalEncroachment = request.ElectricalEncroachment;
            MSDS = request.MSDS;
            OthersPartE = request.OthersPartE;

            MechanicallyIsolated = request.MechanicallyIsolated;
            BlindedOrBlanked = request.BlindedOrBlanked;
            DoubleBlockedandBled = request.DoubleBlockedandBled;
            DrainedAndDepressurised = request.DrainedAndDepressurised;
            PurgedorNeutralised = request.PurgedorNeutralised;
            ElectricallyIsolated = request.ElectricallyIsolated;
            TestBumped = request.TestBumped;
            NuclearSource = request.NuclearSource;
            ReceiverStafingRequirements = request.ReceiverStafingRequirements;
            CompletionStatus = DetectIsComplete();

            PartCWorkSectionNotApplicableToJob = request.PartCWorkSectionNotApplicableToJob;
            PartDWorkSectionNotApplicableToJob = request.PartDWorkSectionNotApplicableToJob;
            PartEWorkSectionNotApplicableToJob = request.PartEWorkSectionNotApplicableToJob;

            //amit8750003578

          //  AreaLabel = request.AreaLabel;
            DataSource = request.DataSource;
            LastImportedByUser = request.LastImportedByUser;
            LastImportedDateTime = request.LastImportedDateTime;


            // This is harmless, but really shouldn't be here. This value doesn't get updated to the DB. I'm not changing it to avoid unnecessary changes to existing and tested functionality.
            CreatedBy = request.CreatedBy; 
            CreatedDateTime = request.CreatedDateTime;
            // This is harmless, but really shouldn't be here. This value doesn't get updated to the DB. I'm not changing it to avoid unnecessary changes to existing and tested functionality. 

            LastModifiedBy = request.LastModifiedBy;
            LastModifiedDateTime = request.LastModifiedDateTime;

            IsModified = request.IsModified;

            IssuedToSuncor = request.IssuedToSuncor;

            CompletionStatus = DetectIsComplete();
        }

        public override bool HasNoFunctionalLocation()
        {
            return FunctionalLocation == null;
        }

        public override bool HasAFunctionalLocationHigherThanLevel3()
        {
            return FunctionalLocation.Type < FunctionalLocationType.Level3;
        }

        public override bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies, SiteConfiguration siteConfiguration)
        {
            List<string> fullHierarchies;

            if (workPermitEdmontonFullHierarchies.IsEmpty())
            {
                fullHierarchies = clientFullHierarchies;
            }
            else
            {
                fullHierarchies = workPermitEdmontonFullHierarchies;
            }

            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, fullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, fullHierarchies) ||
                   new WalkUpRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, fullHierarchies);
        }

        public override PermitRequestCompletionStatus Validate(DateTime currentDateTimeInSite)
        {
            return DetectIsComplete();
        }

        public override void UpdateIfModifiedFrom(BasePermitRequest incomingPermitRequest)
        {
            base.UpdateIfModifiedFrom(incomingPermitRequest);

            var incomingPermitRequestFortHills = (PermitRequestFortHills) incomingPermitRequest;
            RequestedStartTime = incomingPermitRequestFortHills.RequestedStartTime;
            RequestedEndTime = incomingPermitRequestFortHills.RequestedEndTime;
            RequestedStartDate = incomingPermitRequestFortHills.RequestedStartDate;
            CompletionStatus = DetectIsComplete();
        }

        public PermitRequestFortHillsHistory TakeSnapshot()
        {
            var history = new PermitRequestFortHillsHistory(this);
            return history;
        }

        public override PermitRequestCompletionStatus DetectIsComplete()
        {
            var validator = new PermitRequestValidator(new PermitRequestFortHillsValidationDomainAdapter(this),
                DataSource);
            validator.Validate();
            return validator.CompletionStatus;
        }

        //mangesh - clone - permit request
        public string ConvertToCloneNew(User user)
        {
            var now = Clock.Now;
           
            Id = null;

            LastModifiedBy = user;
            LastModifiedDateTime = now;

            LastSubmittedByUser = null;

            LastImportedByUser = null;
            LastImportedDateTime = null;

            CreatedDateTime = now;
            CreatedBy = user;

            // Note: ExpiredDateTime gets set properly on the form after the clone happens
            RequestedStartDate = new Date(now);
            RequestedStartTime = new Time(now);
            EndDate = new Date(now);
            RequestedEndTime = new Time(now);

            DataSource = DataSource.CLONE;

            //RescuePlanFormNumber = null;
            //ConfinedSpaceCardNumber = null;
            //SpecialWorkFormNumber = null;
            //Dharmesh -- Start -- 6Jul2017 for INC0165740 (OLT - Clone / Copy issues with Logs and Work permits)
            //DocumentLinks.Clear();
            //Dharmesh end 6Jul2017
            
            string formList = string.Empty;
            /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            /*
            if (FormGN1 != null && (FormGN1.IsDeleted || FormGN1.IsWorkPermitDatesWithinFormDates(this)))
            {
                formList += "GN-1" + "\n";
                FormGN1 = null;
                FormGN1TradeChecklistDisplayNumber = null;
                FormGN1TradeChecklistId = null;
            }
            if (FormGN6 != null && (FormGN6.IsDeleted || FormGN6.IsWorkPermitDatesWithinFormDates(this)))
            {
                formList += "GN-6" + "\n";
                FormGN6 = null;
            }
            if (FormGN7 != null && (FormGN7.IsDeleted || FormGN7.IsWorkPermitDatesWithinFormDates(this)))
            {
                formList += "GN-7" + "\n";
                FormGN7 = null;
            }
            if (FormGN24 != null && (FormGN24.IsDeleted || FormGN24.IsWorkPermitDatesWithinFormDates(this)))
            {
                formList += "GN-24" + "\n";
                FormGN24 = null;
            }
            if (FormGN59 != null && (FormGN59.IsDeleted || FormGN59.IsWorkPermitDatesWithinFormDates(this)))
            {
                formList += "GN-59" + "\n";
                FormGN59 = null;
            }
            if (FormGN75A != null && (FormGN75A.IsDeleted || FormGN75A.IsWorkPermitDatesWithinFormDates(this)))
            {
                formList += "GN-75A" + "\n";
                FormGN75A = null;
            }*/
            return formList;
        }

       
        //public bool AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected()
        //{
        //    return (FaceShield ||
        //            ChemicalSuit ||
        //            BottleWatch ||
        //            ConfinedSpaceMoniter ||
        //            SuppliedBreathingAir ||
        //            PersonalFlotationDevice ||
        //            !Other1.IsNullOrEmptyOrWhitespace() ||
        //            MonoGoggles ||
        //            FireBlanket ||
        //            FireExtinguisher ||
                   
        //            FireWatch ||
        //            //SewersDrainsCovered ||
        //            //SteamHose ||
        //            !Other2.IsNullOrEmptyOrWhitespace() ||
        //            AirPurifyingRespirator ||
        //            //BreathingAirApparatus ||
        //            //DustMask ||
        //            //LifeSupportSystem ||
        //            //SafetyWatch ||
        //            //ContinuousGasMonitor ||
        //            //WorkersMonitor ||
        //            //BumpTestMonitorPriorToUse ||
        //            !Other3.IsNullOrEmptyOrWhitespace() ||
        //            AirMover ||
        //            GoundDisturbance ||
        //            !OthersPartE.IsNullOrEmptyOrWhitespace());
        //}

        // This method should compare the existing OLT data to the incoming list, and build a list of DTOs that need to be removed from the OLT database.
        // It is assumed that anything that didn't come in from the import should no longer be in OLT.

        public static List<PermitRequestFortHills> BuildImportRemovalList(
            List<PermitRequestFortHills> existingOLTDataList, List<IHasPermitKey> incomingPermitRequests,
            List<IHasPermitKey> thingsThatFailedValidation)
        {
            var removalList = new List<PermitRequestFortHills>();

            foreach (var item in existingOLTDataList)
            {
                var match = incomingPermitRequests.Find(ipr => item.ContainsWorkOrderSource(ipr));

                if (match == null && !thingsThatFailedValidation.Exists(ttfv => item.ContainsWorkOrderSource(ttfv)))
                {
                    removalList.Add(item);
                }
            }

            return removalList;
        }
    }
}