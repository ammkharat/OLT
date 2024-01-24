using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Annotations;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.Utils.Internal;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitFortHills : ModifiableDomainObject, IFunctionalLocationRelevant, IDocumentLinksObject
    {
        public const string A = "A";
        public const string B = "B";
        public const string C = "C";
        public const string D = "D";

        public const string ConfinedSpaceLevel1 = "1";
        public const string ConfinedSpaceLevel2 = "2";
        public const string ConfinedSpaceLevel3 = "3";
        public static readonly TimeSpan NonTurnaroundPermitEndTimeOffset = new TimeSpan(1, 30, 0).Negate();
       // public static readonly TimeSpan TurnaroundPermitEndTimeOffset = new TimeSpan(1, 0, 0).Negate();

        // note: these are not necessarily Edmonton's shift times but are just defaults used for permit requests
        public static readonly Time DayShiftStartTime = new Time(6, 00);
        public static readonly Time NightShiftStartTime = new Time(18, 00);

        public static readonly Time PermitDefaultDayStart = DayShiftStartTime.Add(0, 30);
        public static readonly Time PermitDefaultNightStart = NightShiftStartTime.Add(0, 30);

        public static readonly Priority[] Priorities = {Priority.Normal, Priority.CriticalPath};

        public WorkPermitFortHills(DataSource dataSource, PermitRequestBasedWorkPermitStatus workPermitStatus,
            WorkPermitFortHillsType workPermitType, DateTime createdDateTime, User createdBy)
        {
            DataSource = dataSource;
            WorkPermitStatus = workPermitStatus;
            WorkPermitType = workPermitType;

            CreatedDateTime = createdDateTime;
            CreatedBy = createdBy;
            //QuestionOneResponse = YesNoNotApplicable.YES;
            Prioritydata = Priority.Normal;

            DocumentLinks = new List<DocumentLink>();
        }



        #region["Properties"]



        #endregion
        public PermitRequestBasedWorkPermitStatus WorkPermitStatus { get; set; }

        public DataSource DataSource { get; set; }

        public string ClonedFormDetailFortHills { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History
        
        public string Company { get; set; }
        public string Occupation { get; set; }
        public int? NumberOfWorkers { get; set; }
        public WorkPermitFortHillsType WorkPermitType { get; set; }
        public FunctionalLocation FunctionalLocation { get; set; }
        public string Location { get; set; }
        public DateTime RequestedStartDateTime { get; set; }
       
        public DateTime RequestedOrIssuedDateTime
        {
            get { return IssuedDateTime != null ? IssuedDateTime.Value : RequestedStartDateTime; }
        }
        public DateTime? IssuedDateTime { get; set; }
        public bool HasBeenIssued
        {
            get { return IssuedDateTime.HasValue; }
        }
       
        public DateTime ExpiredDateTime { get; set; }
        public long ? PermitNumber { get; set; }
        public string WorkOrderNumber { get; set; }
        public string OperationNumber { get; set; }
        public string SubOperationNumber { get; set; }
       
        //PART D start
        public bool PartDWorkSectionNotApplicableToJob { get; set; }
        public string TaskDescription { get; set; }
        public string HazardsAndOrRequirements { get; set; }

        //PART D end

        public DateTime CreatedDateTime { get; private set; }
        public User CreatedBy { get; private set; }
        public bool IssuedToSuncor { get; set; }
        public bool IssuedToCompany { get; set; }
        public WorkPermitFortHillsGroup Group { get; set; }
        public User IssuedByUser { get; set; }
        public User PermitRequestCreatedByUser { get; set; }
        public Priority Prioritydata { get; set; }

        public string EquipmentNo { get; set; }
        public string Craft { get; set; }
        public Int32? CrewSize { get; set; }
        public string JobCoordinator { get; set; }
        public string CoOrdContactNumber { get; set; }
        public string EmergencyAssemblyArea { get; set; }
        public string EmergencyMeetingPoint { get; set; }
        public string EmergencyContactNo { get; set; }
        public string LockBoxNumber { get; set; }
        public string IsolationNo { get; set; }
        public bool LockBoxnumberChecked { get; set; }
        public DateTime ? RevalidationDateTime { get; set; }
        public DateTime ? ExtensionDateTime { get; set; }
        public string ExtensionReasonPartJ { get; set; }
        public User ExtendedByUser { get; set; }

        //PART C-1 SPECIALITY SAFETY EQUIPMENT REQUIREMENTS start
        public bool PartCWorkSectionNotApplicableToJob { get; set; }
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
        public bool OthersPartEChecked { get; set; }
        public string OthersPartE { get; set; }

        // PART F CONTROL OF HAZARDUS ENERGY - SAFING STATUS 
        public bool PartFWorkSectionNotApplicableToJob { get; set; }
        public bool MechanicallyIsolated { get; set; }
        public bool BlindedOrBlanked { get; set; }
        public bool DoubleBlockedandBled { get; set; }
        public bool DrainedAndDepressurised { get; set; }
        public bool PurgedorNeutralised { get; set; }
        public bool ElectricallyIsolated { get; set; }
        public bool TestBumped { get; set; }
        public bool NuclearSource { get; set; }
        public bool ReceiverStafingRequirements { get; set; }

      //  public bool DurationPermit { get; set; }

        /*Oxygen*/
        public bool PartGWorkSectionNotApplicableToJob { get; set; }
        public string Frequency { get; set; }
        public bool Continuous { get; set; }
        public string TesterName { get; set; }
        public bool Oxygen{get; set;}
        public bool LEL { get; set; }
        public bool H2SPPM { get; set; }
        public bool CoPPM { get; set; }
        public bool So2PPM { get; set; }
        public bool Other1PartG { get; set; }
        public string Other1PartGValue { get; set; }
        public bool Other2PartG { get; set; }
        public string Other2PartGValue { get; set; }


        public string PermitIssuer { get; set; }
        public string AreaAuthority { get; set; }
        public string CoAuthorizingIssuer { get; set; }
        public string AddationalAuthority { get; set; }
        public string PermitIssuerContact { get; set; }
        public string AreaAuthorityContact { get; set; }
        public  string CoAuthorizingIssuerContact { get; set; }
        public string AddationalAuthorityContact { get; set; }
        public bool IsFieldTourRequired { get; set; }
        public string FieldTourConductedBy { get; set; }
 
        /*
        //public User SubmittedByUser
        //{
        //    get { return DataSource.PERMIT_REQUEST == DataSource ? CreatedBy : null; }
        //}

        */

        public string PermitAcceptor { get; set; }
       // public string ShiftSupervisor { get; set; }

        public bool UseCurrentPermitNumberForZeroEnergyFormNumber { get; set; }

       

        public string DescriptionForLog
        {
            get
            {
                var sb = new StringBuilder();

                sb.AppendLine(String.Format("{0}: {1}, {2}, {3}",
                    StringResources.WorkPermitDescription_PermitNumberLabel,
                    PermitNumber,
                    WorkPermitType.Name,
                    WorkPermitStatus));

                sb.AppendLine(String.Format("{0}: {1}",
                    StringResources.WorkPermitEdmontonHistoryClassTaskDescriptionPropertyKey, TaskDescription));

                return sb.ToString();
            }
        }

        public List<DocumentLink> DocumentLinks { get; set; }

        public bool IsRelevantTo(long siteIdOfClient,  List<string> clientFullHierarchies, List<string> workPermitFirtHillsFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
        {
            List<string> fullHierarchies;

            if (workPermitFirtHillsFullHierarchies.IsEmpty())
            {
                fullHierarchies = clientFullHierarchies;
            }
            else
            {
                fullHierarchies = workPermitFirtHillsFullHierarchies;
            }

            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, fullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, fullHierarchies) ||
                   new WalkUpRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, fullHierarchies);
        }

        public void CopyContentsIntoNextDayPermit(ref WorkPermitFortHills nextDayPermit)
        {
            var newNextDayPermit = this.DeepClone();
            newNextDayPermit.Id = nextDayPermit.Id;
            newNextDayPermit.WorkPermitStatus = nextDayPermit.WorkPermitStatus;

            newNextDayPermit.PermitNumber = null;
            newNextDayPermit.LastModifiedBy = nextDayPermit.LastModifiedBy;
            newNextDayPermit.LastModifiedDateTime = nextDayPermit.LastModifiedDateTime;

            newNextDayPermit.PermitRequestCreatedByUser = nextDayPermit.PermitRequestCreatedByUser;
            newNextDayPermit.RequestedStartDateTime = nextDayPermit.RequestedStartDateTime;

            newNextDayPermit.IssuedDateTime = null;
            newNextDayPermit.IssuedByUser = null;
            newNextDayPermit.ExpiredDateTime = nextDayPermit.ExpiredDateTime;

            newNextDayPermit.UseCurrentPermitNumberForZeroEnergyFormNumber = false;

            newNextDayPermit.WorkOrderNumber = nextDayPermit.WorkOrderNumber;
            newNextDayPermit.OperationNumber = nextDayPermit.OperationNumber;
            newNextDayPermit.SubOperationNumber = nextDayPermit.SubOperationNumber;
            newNextDayPermit.DocumentLinks = newNextDayPermit.DocumentLinks.ConvertAll(link => link.CloneWithoutId());
            nextDayPermit = newNextDayPermit;
        }

        private bool IncludeFormInCopy(BaseEdmontonForm form, WorkPermitFortHills targetPermit)
        {
            return form != null && !form.IsDeleted && form.FormStatus.IsOneOf(FormStatus.Draft, FormStatus.Approved);
                //&& form.IsWorkPermitDatesWithinFormDates(targetPermit);
        }

        public void ConvertToCloneNew() // Swapnil Patki For DMND0005325 Point Number 3
        {
            DataSource = DataSource.CLONE;

            CreatedBy = null;
        }

        public void ConvertToClone(DateTime expiryDateTime)
        {
            Id = null;
            PermitNumber = null;
            LastModifiedBy = null;
            LastModifiedDateTime = Clock.Now;

            DataSource = DataSource.CLONE;

            CreatedBy = null;

            DocumentLinks.Clear();
            UseCurrentPermitNumberForZeroEnergyFormNumber = false;

            RequestedStartDateTime = Clock.Now;
            ExpiredDateTime = expiryDateTime;
            IssuedDateTime = null;
            IssuedByUser = null;
        }

        public void BuildPermitToSubmit(PermitRequestFortHills request, User user, DateTime now, Date workPermitDate,
            DateTime startDateTime)
        {
            IssuedToSuncor = request.IssuedToSuncor;
            IssuedToCompany = !request.Company.IsNullOrEmptyOrWhitespace();
            Company = request.Company;
            Occupation = request.Occupation;
            NumberOfWorkers = request.NumberOfWorkers;
            Group = request.Group;
            Prioritydata = request.Priority;
            
            FunctionalLocation = request.FunctionalLocation;
            Location = request.Location;
            
            WorkOrderNumber = request.WorkOrderNumber;
            OperationNumber = request.OperationNumberListAsString;
            SubOperationNumber = request.SubOperationNumberListAsString;
            LockBoxnumberChecked = request.LockBoxnumberChecked;

            JobCoordinator = request.JobCoordinator;
            CoOrdContactNumber = request.CoOrdContactNumber;
            EmergencyMeetingPoint = request.EmergencyMeetingPoint;
            EmergencyContactNo = request.EmergencyContactNo;
            LockBoxNumber = request.LockBoxNumber;
            IsolationNo = request.IsolationNo;
            EquipmentNo = request.EquipmentNo;

            PartDWorkSectionNotApplicableToJob = request.PartDWorkSectionNotApplicableToJob;
            TaskDescription = request.Description;
            HazardsAndOrRequirements = request.HazardsAndOrRequirements;

            PartCWorkSectionNotApplicableToJob = request.PartCWorkSectionNotApplicableToJob;
            FlameResistantWorkWear = request.FlameResistantWorkWear;
            ChemicalSuit = request.ChemicalSuit;
            FireWatch = request.FireWatch;
            FireBlanket = request.FireBlanket;
            SuppliedBreathingAir = request.SuppliedBreathingAir;
            AirMover = request.AirMover;
            PersonalFlotationDevice = request.PersonalFlotationDevice;
            HearingProtection = request.HearingProtection;
            Other1Checked = !request.Other1.IsNullOrEmptyOrWhitespace();
            Other1 = request.Other1;
            MonoGoggles = request.MonoGoggles;
            ConfinedSpaceMoniter = request.ConfinedSpaceMoniter;
            FireExtinguisher = request.FireExtinguisher;
            SparkContainment = request.SparkContainment;
            BottleWatch = request.BottleWatch;
            StandbyPerson = request.StandbyPerson;
            WorkingAlone = request.WorkingAlone;
            SafetyGloves = request.SafetyGloves;
            Other2Checked = !request.Other2.IsNullOrEmptyOrWhitespace();
            Other2 = request.Other2;
            FaceShield = request.FaceShield;
            FallProtection = request.FallProtection;
            ChargedFireHouse = request.ChargedFireHouse;
            CoveredSewer = request.CoveredSewer;
            AirPurifyingRespirator = request.AirPurifyingRespirator;
            SingalPerson = request.SingalPerson;
            CommunicationDevice = request.CommunicationDevice;
            ReflectiveStrips = request.ReflectiveStrips;
            Other3Checked = !request.Other3.IsNullOrEmptyOrWhitespace();
            Other3 = request.Other3;

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
            OthersPartEChecked = !request.OthersPartE.IsNullOrEmptyOrWhitespace();
            OthersPartE = request.OthersPartE;

            //PartFWorkSectionNotApplicableToJob = request.PartFWorkSectionNotApplicableToJob;
            //MechanicallyIsolated = request.MechanicallyIsolated;
            //BlindedOrBlanked = request.BlindedOrBlanked;
            //DoubleBlockedandBled = request.DoubleBlockedandBled;
            //DrainedAndDepressurised = request.DrainedAndDepressurised;
            //PurgedorNeutralised = request.PurgedorNeutralised;
            //ElectricallyIsolated = request.ElectricallyIsolated;
            //TestBumped = request.TestBumped;
            //NuclearSource = request.NuclearSource;
            //ReceiverStafingRequirements = request.ReceiverStafingRequirements;



            DocumentLinks = request.DocumentLinks.ConvertAll(link => new DocumentLink(link.Url, link.Title));

            RequestedStartDateTime = workPermitDate.CreateDateTime(startDateTime.ToTime()); ;
            ExpiredDateTime = request.EndDate.CreateDateTime(request.RequestedEndTime);
            PermitRequestCreatedByUser = request.CreatedBy;
            LastModifiedBy = user;
            LastModifiedDateTime = now;

            

            //ConfinedSpace = request.ConfinedSpace;
            //VehicleEntry = request.VehicleEntry;
            //VehicleEntryTotal = request.VehicleEntryTotal;
            //VehicleEntryType = request.VehicleEntryType;
            //SpecialWork = request.SpecialWork;
            //SpecialWorkFormNumber = request.SpecialWorkFormNumber;
            //SpecialWorkList = request.Specialworktype;//mangesh for SpecialWork
            //SpecialWorkName = request.SpecialWorkName;
            //var endDateTime = UserShift(RequestedStartDateTime).EndDateTime;
            //var permitEndDateTime =
            //    endDateTime.Add(request.Group.IsTurnaround
            //        ? TurnaroundPermitEndTimeOffset
            //        : NonTurnaroundPermitEndTimeOffset);
            //ExpiredDateTime = permitEndDateTime;
            
            

            

            //OtherAreasAndOrUnitsAffected = !request.OtherAreasAndOrUnitsAffectedArea.IsNullOrEmptyOrWhitespace() ||
            //                               !request.OtherAreasAndOrUnitsAffectedPersonNotified.IsNullOrEmptyOrWhitespace
            //                                   ();
            //OtherAreasAndOrUnitsAffectedArea = request.OtherAreasAndOrUnitsAffectedArea;
            //OtherAreasAndOrUnitsAffectedPersonNotified = request.OtherAreasAndOrUnitsAffectedPersonNotified;

            //WorkersMinimumSafetyRequirementsSectionNotApplicableToJob =
            //    request.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

           
               
                //RubberSuit = request.RubberSuit;
                
               // EquipmentGrounded = request.EquipmentGrounded;
                
               // WorkersMonitorNumber = request.WorkersMonitorNumber;
               // BumpTestMonitorPriorToUse = request.BumpTestMonitorPriorToUse;
               
                //RadioChannel = request.RadioChannel;
                //RadioChannelNumber = request.RadioChannelNumber;
                //AirHorn = request.AirHorn;
                //MechVentilationComfortOnly = request.MechVentilationComfortOnly;
                //AsbestosMMCPrecautions = request.AsbestosMMCPrecautions;
                //Other4Checked = !request.Other4.IsNullOrEmptyOrWhitespace();
                //Other4 = request.Other4;
            

           
        }

        public static UserShift UserShift(DateTime dateTime)
        {
            var currentTime = dateTime.ToTime();
            var currentDate = dateTime.ToDate();

            var shiftPattern = IsDayShift(currentTime)
                ? new ShiftPattern(0, "D", DayShiftStartTime, NightShiftStartTime, dateTime, null, TimeSpan.Zero,
                    TimeSpan.Zero)
                : new ShiftPattern(0, "N", NightShiftStartTime, DayShiftStartTime, dateTime, null, TimeSpan.Zero,
                    TimeSpan.Zero);

            if (currentTime < DayShiftStartTime)
            {
                currentDate = currentDate.SubtractDays(1);
            }

            var userShift = new UserShift(shiftPattern, currentDate);
            return userShift;
        }

        public static bool IsDayShift(Time time)
        {
            return (time >= DayShiftStartTime && time < NightShiftStartTime);
        }

        public WorkPermitFortHillsHistory TakeSnapshot()
        {
            return new WorkPermitFortHillsHistory(this);
        }
        
        public static string GetLocation(FunctionalLocation floc)
        {
            if (floc == null)
            {
                return null;
            }

            return floc.Description;
        }

        public DateTime GetDefaultExpiryDateTimeBasedOnGroup(UserShift userShift)
        {
            var shiftEndDateTime = userShift.EndDateTime;
            //return
            //    shiftEndDateTime.Add(Group.IsTurnaround
            //        ? TurnaroundPermitEndTimeOffset
            //        : NonTurnaroundPermitEndTimeOffset);

            //mangesh - Cloning fails for incomplete Work Permit
            //Error occured when : 1.select only mandatory field and save running unit work permit 2.clone it :- null reference error 
            
            shiftEndDateTime = shiftEndDateTime.Add(NonTurnaroundPermitEndTimeOffset);
           
            return shiftEndDateTime;
        }

        //public void MaybeSetZeroEnergyFormNumber(long? permitNumber)
        //{
        //    if (ZeroEnergyFormNumber.IsNullOrEmptyOrWhitespace() && UseCurrentPermitNumberForZeroEnergyFormNumber &&
        //        permitNumber.HasValue)
        //    {
        //        ZeroEnergyFormNumber = permitNumber.ToString();
        //    }
        //}
    }
}