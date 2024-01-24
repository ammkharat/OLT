using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitLubes : ModifiableDomainObject, IDocumentLinksObject, IFunctionalLocationRelevant
    {
        private static string NameOfDayShift = "D";

        public WorkPermitLubes(DateTime createdDateTime, User createdBy)
        {
            CreatedDateTime = createdDateTime;
            CreatedBy = createdBy;

            LastModifiedBy = createdBy;
            LastModifiedDateTime = createdDateTime;
            Version = Constants.CURRENT_VERSION;
            DepressuredDrained = YesNoNotApplicable.NOT_APPLICABLE;
            WaterWashed = YesNoNotApplicable.NOT_APPLICABLE;
            ChemicallyWashed = YesNoNotApplicable.NOT_APPLICABLE;
            Steamed = YesNoNotApplicable.NOT_APPLICABLE;
            Purged = YesNoNotApplicable.NOT_APPLICABLE;
            Disconnected = YesNoNotApplicable.NOT_APPLICABLE;
            DepressuredAndVented = YesNoNotApplicable.NOT_APPLICABLE;
            Ventilated = YesNoNotApplicable.NOT_APPLICABLE;
            Blanked = YesNoNotApplicable.NOT_APPLICABLE;
            DrainsCovered = YesNoNotApplicable.NOT_APPLICABLE;
            AreaBarricaded = YesNoNotApplicable.NOT_APPLICABLE;
            EnergySourcesLockedOutTaggedOut = YesNoNotApplicable.NOT_APPLICABLE;

            HighEnergy = WorkPermitSafetyFormState.NotApplicable;
            CriticalLift = WorkPermitSafetyFormState.NotApplicable;
            Excavation = WorkPermitSafetyFormState.NotApplicable;
            EnergyControlPlanFormRequirement = WorkPermitSafetyFormState.NotApplicable;
            EquivalencyProc = WorkPermitSafetyFormState.NotApplicable;
            TestPneumatic = WorkPermitSafetyFormState.NotApplicable;
            LiveFlareWork = WorkPermitSafetyFormState.NotApplicable;
            EntryAndControlPlan = WorkPermitSafetyFormState.NotApplicable;
            EnergizedElectrical = WorkPermitSafetyFormState.NotApplicable;

            DocumentLinks = new List<DocumentLink>();
        }

        public DataSource DataSource { get; set; }
        public DateTime CreatedDateTime { get; private set; }
        public User CreatedBy { get; private set; }
        public DateTime? IssuedDateTime { get; set; }
        public User IssuedBy { get; set; }
        public long? PermitNumber { get; set; }

        public string PermitNumberDisplayValue
        {
            get { return GetPermitNumberDisplayValue(PermitNumber); }
        }

        public PermitRequestBasedWorkPermitStatus WorkPermitStatus { get; set; }
        public User PermitRequestSubmittedByUser { get; set; }
        public User PermitRequestCreatedByUser { get; set; }
        public DataSource PermitRequestDataSource { get; set; }
        public bool UsePreviousPermitAnswered { get; set; }

        public bool IssuedToSuncor { get; set; }
        public bool IssuedToCompany { get; set; }
        public string Company { get; set; }
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
        public bool HazardousWorkApproverAdvised { get; set; }
        public bool AdditionalFollowupRequired { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }

        // This is for when we need a start date, but since the permit might not have been issued yet we have to use the requested start instead.
        // The issued date time is when the permit is valid from, so it's the most correct value.        
        public DateTime StartOrIssuedDateTime
        {
            get { return IssuedDateTime != null ? IssuedDateTime.Value : StartDateTime; }
        }

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
        public YesNoNotApplicable DepressuredDrained { get; set; }
        public YesNoNotApplicable WaterWashed { get; set; }
        public YesNoNotApplicable ChemicallyWashed { get; set; }
        public YesNoNotApplicable Steamed { get; set; }
        public YesNoNotApplicable Purged { get; set; }
        public YesNoNotApplicable Disconnected { get; set; }
        public YesNoNotApplicable DepressuredAndVented { get; set; }
        public YesNoNotApplicable Ventilated { get; set; }
        public YesNoNotApplicable Blanked { get; set; }
        public YesNoNotApplicable DrainsCovered { get; set; }
        public YesNoNotApplicable AreaBarricaded { get; set; }
        public YesNoNotApplicable EnergySourcesLockedOutTaggedOut { get; set; }
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

        public static Time StartOfDefaultDayShift
        {
            get { return new Time(5, 30, 0); }
        }

        public static Time StartOfDefaultNightShift
        {
            get { return new Time(17, 30, 0); }
        }

        public string DescriptionForLog
        {
            get
            {
                var sb = new StringBuilder();

                string firstLineFormat;
                if (IssuedDateTime != null)
                {
                    firstLineFormat = "{0}: {1}, {2}, {3}";
                }
                else
                {
                    firstLineFormat = "{0}: {1}, NOT ISSUED, {2}, {3}";
                }

                sb.AppendLine(String.Format(firstLineFormat,
                    StringResources.WorkPermitDescription_PermitNumberLabel,
                    PermitNumberDisplayValue,
                    WorkPermitType.Name,
                    WorkPermitStatus));

                sb.AppendLine(String.Format("{0}: {1}",
                    StringResources.WorkPermitLubesHistoryClassTaskDescriptionPropertyKey, TaskDescription));

                return sb.ToString();
            }
        }

        public Version Version { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkUpRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        public static string GetPermitNumberDisplayValue(long? permitNumber)
        {
            return permitNumber == null ? string.Empty : permitNumber.Value.ToString("000000000");
        }

        public WorkPermitLubesHistory TakeSnapshot()
        {
            return new WorkPermitLubesHistory(this);
        }

        public static bool IsABroadFunctionalLocation(FunctionalLocation functionalLocation)
        {
            return functionalLocation != null && functionalLocation.Level <= 2;
        }

        public static string GetLocation(FunctionalLocation floc)
        {
            if (floc == null)
            {
                return null;
            }

            return floc.Description;
        }

        private static ShiftPattern CreateDayShiftPattern(int preShiftPaddingInMinutes, int postShiftPaddingInMinutes)
        {
            var preShiftPaddingTimeSpan = new TimeSpan(0, preShiftPaddingInMinutes, 0);
            var postShiftPaddingTimeSpan = new TimeSpan(0, postShiftPaddingInMinutes, 0);

            return new ShiftPattern(0, NameOfDayShift, StartOfDefaultDayShift, StartOfDefaultNightShift,
                new DateTime(2000, 1, 1), null, preShiftPaddingTimeSpan, postShiftPaddingTimeSpan);
        }

        private static ShiftPattern CreateNightShiftPattern(int preShiftPaddingInMinutes, int postShiftPaddingInMinutes)
        {
            var preShiftPaddingTimeSpan = new TimeSpan(0, preShiftPaddingInMinutes, 0);
            var postShiftPaddingTimeSpan = new TimeSpan(0, postShiftPaddingInMinutes, 0);

            return new ShiftPattern(0, "N", StartOfDefaultNightShift, StartOfDefaultDayShift, new DateTime(2000, 1, 1),
                null, preShiftPaddingTimeSpan, postShiftPaddingTimeSpan);
        }

        public static UserShift UserShift(DateTime dateTime, int preShiftPaddingInMinutes, int postShiftPaddingInMinutes)
        {
            var currentTime = dateTime.ToTime();
            var currentDate = dateTime.ToDate();

            var shiftPattern = IsDayShift(currentTime)
                ? CreateDayShiftPattern(preShiftPaddingInMinutes, postShiftPaddingInMinutes)
                : CreateNightShiftPattern(preShiftPaddingInMinutes, postShiftPaddingInMinutes);

            if (currentTime < StartOfDefaultDayShift)
            {
                currentDate = currentDate.SubtractDays(1);
            }

            var userShift = new UserShift(shiftPattern, currentDate);
            return userShift;
        }

        public static UserShift UserShift(DateTime dateTime)
        {
            return UserShift(dateTime, 0, 0);
        }

        public void CopyContentsIntoNextDayPermit(ref WorkPermitLubes nextDayPermit)
        {
            var newNextDayPermit = this.DeepClone();
            newNextDayPermit.Id = nextDayPermit.Id;
            newNextDayPermit.WorkPermitStatus = nextDayPermit.WorkPermitStatus;
            newNextDayPermit.Version = Constants.CURRENT_VERSION;
            newNextDayPermit.PermitNumber = null;
            newNextDayPermit.LastModifiedBy = nextDayPermit.LastModifiedBy;
            newNextDayPermit.LastModifiedDateTime = nextDayPermit.LastModifiedDateTime;
            newNextDayPermit.Version = Constants.CURRENT_VERSION;
            newNextDayPermit.PermitRequestCreatedByUser = nextDayPermit.PermitRequestCreatedByUser;
            newNextDayPermit.StartDateTime = nextDayPermit.StartDateTime;
            newNextDayPermit.ExpireDateTime = nextDayPermit.ExpireDateTime;

            newNextDayPermit.IssuedDateTime = null;
            newNextDayPermit.IssuedBy = null;

            newNextDayPermit.PermitRequestSubmittedByUser = nextDayPermit.PermitRequestSubmittedByUser;

            newNextDayPermit.DocumentLinks = newNextDayPermit.DocumentLinks.ConvertAll(link => link.CloneWithoutId());

            nextDayPermit = newNextDayPermit;
        }

        public static bool IsDayShift(Time time)
        {
            return (time >= StartOfDefaultDayShift && time < StartOfDefaultNightShift);
        }

        public void BuildPermitToSubmit(PermitRequestLubes request, User user, DateTime now, Date workPermitDate,
            DateTime startDateTime)
        {
            DataSource = DataSource.PERMIT_REQUEST;
            WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Requested;
            Version = Constants.CURRENT_VERSION;
            PermitRequestSubmittedByUser = user;
            PermitRequestCreatedByUser = request.CreatedBy;
            PermitRequestDataSource = request.DataSource;

            LastModifiedBy = user;
            LastModifiedDateTime = now;

            IssuedToSuncor = request.IssuedToSuncor;
            IssuedToCompany = request.IssuedToCompany;
            Company = request.Company;
            Trade = request.Trade;
            NumberOfWorkers = request.NumberOfWorkers;
            RequestedByGroup = request.RequestedByGroup;

            WorkPermitType = request.WorkPermitType;
            IsVehicleEntry = request.IsVehicleEntry;
            FunctionalLocation = request.FunctionalLocation;
            Location = request.Location;
            DocumentLinks = request.DocumentLinks.ConvertAll(link => new DocumentLink(link.Url, link.Title));

            ConfinedSpace = request.ConfinedSpace;
            ConfinedSpaceClass = request.ConfinedSpaceClass;
            RescuePlan = request.RescuePlan;
            ConfinedSpaceSafetyWatchChecklist = request.ConfinedSpaceSafetyWatchChecklist;
            SpecialWork = request.SpecialWork;
            SpecialWorkType = request.SpecialWorkType;

            HighEnergy = request.HighEnergy;
            CriticalLift = request.CriticalLift;
            Excavation = request.Excavation;
            EnergyControlPlanFormRequirement = request.EnergyControlPlan;
            EquivalencyProc = request.EquivalencyProc;
            TestPneumatic = request.TestPneumatic;
            LiveFlareWork = request.LiveFlareWork;
            EntryAndControlPlan = request.EntryAndControlPlan;
            EnergizedElectrical = request.EnergizedElectrical;

            StartDateTime = workPermitDate.CreateDateTime(startDateTime.ToTime());
            ExpireDateTime = GetExpireDateTimeForSubmitAndCloneAndNew(StartDateTime);

            WorkOrderNumber = request.WorkOrderNumber;
            OperationNumber = request.OperationNumberListAsString;
            SubOperationNumber = request.SubOperationNumberListAsString;

            TaskDescription = request.Description;

            HazardHydrocarbonGas = request.HazardHydrocarbonGas;
            HazardHydrocarbonLiquid = request.HazardHydrocarbonLiquid;
            HazardHydrogenSulphide = request.HazardHydrogenSulphide;
            HazardInertGasAtmosphere = request.HazardInertGasAtmosphere;
            HazardOxygenDeficiency = request.HazardOxygenDeficiency;
            HazardRadioactiveSources = request.HazardRadioactiveSources;
            HazardUndergroundOverheadHazards = request.HazardUndergroundOverheadHazards;
            HazardDesignatedSubstance = request.HazardDesignatedSubstance;

            OtherHazardsAndOrRequirements = request.OtherHazardsAndOrRequirements;

            OtherAreasAndOrUnitsAffected = request.OtherAreasAndOrUnitsAffected;
            OtherAreasAndOrUnitsAffectedArea = request.OtherAreasAndOrUnitsAffectedArea;
            OtherAreasAndOrUnitsAffectedPersonNotified = request.OtherAreasAndOrUnitsAffectedPersonNotified;

            SpecificRequirementsSectionNotApplicableToJob = request.SpecificRequirementsSectionNotApplicableToJob;

            AttendedAtAllTimes = request.AttendedAtAllTimes;
            EyeProtection = request.EyeProtection;
            FallProtectionEquipment = request.FallProtectionEquipment;
            FullBodyHarnessRetrieval = request.FullBodyHarnessRetrieval;
            HearingProtection = request.HearingProtection;
            ProtectiveClothing = request.ProtectiveClothing;
            Other1Checked = request.Other1Checked;
            Other1Value = request.Other1Value;

            EquipmentBondedGrounded = request.EquipmentBondedGrounded;
            FireBlanket = request.FireBlanket;
            FireFightingEquipment = request.FireFightingEquipment;
            FireWatch = request.FireWatch;
            HydrantPermit = request.HydrantPermit;
            WaterHose = request.WaterHose;
            SteamHose = request.SteamHose;
            Other2Checked = request.Other2Checked;
            Other2Value = request.Other2Value;

            AirMover = request.AirMover;
            ContinuousGasMonitor = request.ContinuousGasMonitor;
            DrowningProtection = request.DrowningProtection;
            RespiratoryProtection = request.RespiratoryProtection;
            Other3Checked = request.Other3Checked;
            Other3Value = request.Other3Value;

            AdditionalLighting = request.AdditionalLighting;
            DesignateHotOrColdCutChecked = request.DesignateHotOrColdCutChecked;
            DesignateHotOrColdCutValue = request.DesignateHotOrColdCutValue;
            HoistingEquipment = request.HoistingEquipment;
            Ladder = request.Ladder;
            MotorizedEquipment = request.MotorizedEquipment;
            Scaffold = request.Scaffold;
            ReferToTipsProcedure = request.ReferToTipsProcedure;

            GasDetectorBumpTested = request.GasDetectorBumpTested;

            if (request.HydrantPermit || request.ConfinedSpace)
            {
                AdditionalFollowupRequired = true;
            }

            if (AtmosphericGasTestShouldBeRequired(request.WorkPermitType, request.ConfinedSpace))
            {
                AtmosphericGasTestRequired = true;
            }
        }

        public static bool AtmosphericGasTestShouldBeRequired(WorkPermitLubesType permitType, bool isConfinedSpace)
        {
            return (isConfinedSpace || WorkPermitLubesType.HOT_WORK.Equals(permitType));
        }

        public static DateTime GetExpireDateTimeForSubmitAndCloneAndNew(DateTime startDateTime)
        {
            return UserShift(startDateTime).EndDateTime.AddHours(-1);
        }

        public void ConvertToClone(DateTime now, User user)
        {
            Id = null;
            PermitNumber = null;
            CreatedBy = user;
            CreatedDateTime = now;
            LastModifiedBy = user;
            LastModifiedDateTime = now;

            DataSource = DataSource.CLONE;
            Version = Constants.CURRENT_VERSION;
            PermitRequestDataSource = null;
            PermitRequestCreatedByUser = null;
            PermitRequestSubmittedByUser = null;

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());
            IssuedDateTime = null;
            IssuedBy = null;

            StartDateTime = now;
            ExpireDateTime = GetExpireDateTimeForSubmitAndCloneAndNew(StartDateTime);

            HighEnergy = ClonedFormState(HighEnergy);
            CriticalLift = ClonedFormState(CriticalLift);
            Excavation = ClonedFormState(Excavation);
            EnergyControlPlanFormRequirement = ClonedFormState(EnergyControlPlanFormRequirement);
            EquivalencyProc = ClonedFormState(EquivalencyProc);
            TestPneumatic = ClonedFormState(TestPneumatic);
            LiveFlareWork = ClonedFormState(LiveFlareWork);
            EntryAndControlPlan = ClonedFormState(EntryAndControlPlan);
            EnergizedElectrical = ClonedFormState(EnergizedElectrical);
        }

        private WorkPermitSafetyFormState ClonedFormState(WorkPermitSafetyFormState currentFormState)
        {
            return currentFormState != WorkPermitSafetyFormState.NotApplicable
                ? WorkPermitSafetyFormState.Required
                : WorkPermitSafetyFormState.NotApplicable;
        }

        public static bool StartAndExpireDateTimesDoNotFallWithinTheSameShiftOrTheShiftIsInThePast(DateTime nowInLubes,
            DateTime startDateTime, DateTime expireDateTime, int preShiftPaddingInMinutes, int postShiftPaddingInMinutes)
        {
            var dayShiftPattern = CreateDayShiftPattern(preShiftPaddingInMinutes, postShiftPaddingInMinutes);
            var nightShiftPattern = CreateNightShiftPattern(preShiftPaddingInMinutes, postShiftPaddingInMinutes);

            var isStartTimeInDayShift = dayShiftPattern.IsTimeInShiftIncludingPadding(startDateTime.ToTime());
            var isEndTimeInDayShift = dayShiftPattern.IsTimeInShiftIncludingPadding(expireDateTime.ToTime());

            var isStartTimeInNightShift = nightShiftPattern.IsTimeInShiftIncludingPadding(startDateTime.ToTime());
            var isEndTimeInNightShift = nightShiftPattern.IsTimeInShiftIncludingPadding(expireDateTime.ToTime());

            if (isStartTimeInDayShift && isEndTimeInDayShift)
            {
                var startUserShiftForDay = new UserShift(dayShiftPattern, startDateTime);
                var endUserShiftForDay = new UserShift(dayShiftPattern, expireDateTime);

                var shiftsAreNotTheSame = startUserShiftForDay.StartDateTimeWithPadding !=
                                          endUserShiftForDay.StartDateTimeWithPadding ||
                                          startUserShiftForDay.EndDateTimeWithPadding !=
                                          endUserShiftForDay.EndDateTimeWithPadding;
                var shiftsAreInThePast = startUserShiftForDay.EndDateTimeWithPadding < nowInLubes ||
                                         endUserShiftForDay.EndDateTimeWithPadding < nowInLubes;

                if (!shiftsAreNotTheSame && !shiftsAreInThePast)
                {
                    return false;
                }
            }

            if (isStartTimeInNightShift && isEndTimeInNightShift)
            {
                var startUserShiftForNight = new UserShift(nightShiftPattern, startDateTime);
                var endUserShiftForNight = new UserShift(nightShiftPattern, expireDateTime);

                var shiftsAreNotTheSame = startUserShiftForNight.StartDateTimeWithPadding !=
                                          endUserShiftForNight.StartDateTimeWithPadding ||
                                          startUserShiftForNight.EndDateTimeWithPadding !=
                                          endUserShiftForNight.EndDateTimeWithPadding;
                var shiftsAreInThePast = startUserShiftForNight.EndDateTimeWithPadding < nowInLubes ||
                                         endUserShiftForNight.EndDateTimeWithPadding < nowInLubes;

                if (!shiftsAreNotTheSame && !shiftsAreInThePast)
                {
                    return false;
                }
            }

            return true;
        }
    }
}