using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestEdmontonHistory : BasePermitRequestHistory
    {
        public PermitRequestEdmontonHistory(long id, User lastModifiedBy, DateTime lastModifiedDate)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
        }

        public PermitRequestEdmontonHistory(PermitRequestEdmonton permitRequest)
            : base(
                permitRequest.IdValue, permitRequest.EndDate, permitRequest.WorkOrderNumber,
                permitRequest.OperationNumberListAsString, permitRequest.Description,
                permitRequest.SapDescription, permitRequest.Company, null, permitRequest.LastImportedByUser,
                permitRequest.LastImportedDateTime,
                permitRequest.LastSubmittedByUser, permitRequest.LastSubmittedDateTime, permitRequest.LastModifiedBy,
                permitRequest.LastModifiedDateTime)
        {
            SubOperationNumber = permitRequest.SubOperationNumberListAsString;
            IssuedToSuncor = permitRequest.IssuedToSuncor;
            Occupation = permitRequest.Occupation;
            NumberOfWorkers = permitRequest.NumberOfWorkers;
            Group = permitRequest.Group != null ? permitRequest.Group.Name : null;
            WorkPermitType = permitRequest.WorkPermitType;
            FunctionalLocation = permitRequest.FunctionalLocation.FullHierarchy;
            Location = permitRequest.Location;
            DocumentLinks = permitRequest.DocumentLinks.AsString(link => link.TitleWithUrl);

            AlkylationEntryClassOfClothing = permitRequest.AlkylationEntryClassOfClothing;
            FlarePitEntryType = permitRequest.FlarePitEntryType;
            ConfinedSpaceClass = permitRequest.ConfinedSpaceClass;
            ConfinedSpaceCardNumber = permitRequest.ConfinedSpaceCardNumber;
            RescuePlanFormNumber = permitRequest.RescuePlanFormNumber;
            VehicleEntryTotal = permitRequest.VehicleEntryTotal;
            VehicleEntryType = permitRequest.VehicleEntryType;
            //SpecialWorkType = permitRequest.SpecialWorkType != null ? permitRequest.SpecialWorkType.Name : null;
            SpecialWorkType = permitRequest.specialworktype != null ? permitRequest.specialworktype.CompanyName : null;//mangesh for SpecialWork
            SpecialWorkFormNumber = permitRequest.SpecialWorkFormNumber;

            AlkylationEntry = permitRequest.AlkylationEntry;
            FlarePitEntry = permitRequest.FlarePitEntry;
            ConfinedSpace = permitRequest.ConfinedSpace;
            RescuePlan = permitRequest.RescuePlan;
            VehicleEntry = permitRequest.VehicleEntry;
            SpecialWork = permitRequest.SpecialWork;

            FormGN59Id = permitRequest.FormGN59 == null ? null : permitRequest.FormGN59.Id;
            FormGN7Id = permitRequest.FormGN7 == null ? null : permitRequest.FormGN7.Id;
            FormGN6Id = permitRequest.FormGN6 == null ? null : permitRequest.FormGN6.Id;
            FormGN24Id = permitRequest.FormGN24 == null ? null : permitRequest.FormGN24.Id;
            FormGN75AId = permitRequest.FormGN75A == null ? null : permitRequest.FormGN75A.Id;
            FormGN1TradeChecklistDisplayNumber = permitRequest.FormGN1TradeChecklistDisplayNumber;

            GN59 = permitRequest.GN59;
            GN7 = permitRequest.GN7;
            GN6 = permitRequest.GN6;
            GN24 = permitRequest.GN24;
            GN75A = permitRequest.GN75A;
            GN1 = permitRequest.GN1;

            GN11 = permitRequest.GN11.ToString();
            GN6_Deprecated = permitRequest.GN6_Deprecated.ToString();
            GN24_Deprecated = permitRequest.GN24_Deprecated.ToString();
            GN27 = permitRequest.GN27.ToString();
            GN75_Deprecated = permitRequest.GN75_Deprecated.ToString();

            RequestedStartDate = permitRequest.RequestedStartDate;
            RequestedStartTimeDay = permitRequest.RequestedStartTimeDay;
            RequestedStartTimeNight = permitRequest.RequestedStartTimeNight;

            HazardsAndOrRequirements = permitRequest.HazardsAndOrRequirements;

            OtherAreasAndOrUnitsAffectedArea = permitRequest.OtherAreasAndOrUnitsAffectedArea;
            OtherAreasAndOrUnitsAffectedPersonNotified = permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified;

            WorkersMinimumSafetyRequirementsSectionNotApplicableToJob =
                permitRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

            FaceShield = permitRequest.FaceShield;
            Goggles = permitRequest.Goggles;
            RubberBoots = permitRequest.RubberBoots;
            RubberGloves = permitRequest.RubberGloves;
            RubberSuit = permitRequest.RubberSuit;
            SafetyHarnessLifeline = permitRequest.SafetyHarnessLifeline;
            HighVoltagePPE = permitRequest.HighVoltagePPE;
            Other1 = permitRequest.Other1;

            EquipmentGrounded = permitRequest.EquipmentGrounded;
            FireBlanket = permitRequest.FireBlanket;
            FireExtinguisher = permitRequest.FireExtinguisher;
            FireMonitorManned = permitRequest.FireMonitorManned;
            FireWatch = permitRequest.FireWatch;
            SewersDrainsCovered = permitRequest.SewersDrainsCovered;
            SteamHose = permitRequest.SteamHose;
            Other2 = permitRequest.Other2;

            AirPurifyingRespirator = permitRequest.AirPurifyingRespirator;
            BreathingAirApparatus = permitRequest.BreathingAirApparatus;
            DustMask = permitRequest.DustMask;
            LifeSupportSystem = permitRequest.LifeSupportSystem;
            SafetyWatch = permitRequest.SafetyWatch;
            ContinuousGasMonitor = permitRequest.ContinuousGasMonitor;
            WorkersMonitor = permitRequest.WorkersMonitor;
            WorkersMonitorNumber = permitRequest.WorkersMonitorNumber;
            BumpTestMonitorPriorToUse = permitRequest.BumpTestMonitorPriorToUse;
            Other3 = permitRequest.Other3;

            AirMover = permitRequest.AirMover;
            BarriersSigns = permitRequest.BarriersSigns;
            RadioChannel = permitRequest.RadioChannel;
            RadioChannelNumber = permitRequest.RadioChannelNumber;
            AirHorn = permitRequest.AirHorn;
            MechVentilationComfortOnly = permitRequest.MechVentilationComfortOnly;
            AsbestosMMCPrecautions = permitRequest.AsbestosMMCPrecautions;
            Other4 = permitRequest.Other4;

            CompletionStatus = permitRequest.CompletionStatus;
            Priority = permitRequest.Priority;
            AreaLabel = permitRequest.AreaLabel == null ? null : permitRequest.AreaLabel.Name;

            //mangesh for RoadAccessOnPermit and SpecialWork
            RoadAccessOnPermit = permitRequest.RoadAccessOnPermit;
            RoadAccessOnPermitFormNumber = permitRequest.RoadAccessOnPermitFormNumber;
            RoadAccessOnPermitType = permitRequest.RoadAccessOnPermitType;

            SpecialWorkName = permitRequest.SpecialWorkName;
        }

        public bool RoadAccessOnPermit { get; set; }
        public string RoadAccessOnPermitFormNumber { get; set; }
        public string RoadAccessOnPermitType { get; set; }
        public string SpecialWorkName { get; set; }

        public string SubOperationNumber { get; set; }

        public bool IssuedToSuncor { get; set; }

        public Priority Priority { get; set; }
        public string Occupation { get; set; }
        public int? NumberOfWorkers { get; set; }
        public string Group { get; set; }
        public WorkPermitEdmontonType WorkPermitType { get; set; }
        public string FunctionalLocation { get; set; }
        public string Location { get; set; }
        public string DocumentLinks { get; set; }
        public string AreaLabel { get; set; }

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

        public long? FormGN59Id { get; set; }
        public long? FormGN6Id { get; set; }
        public long? FormGN7Id { get; set; }
        public long? FormGN24Id { get; set; }
        public long? FormGN75AId { get; set; }
        public string FormGN1TradeChecklistDisplayNumber { get; set; }

        public bool GN59 { get; set; }
        public bool GN7 { get; set; }
        public bool GN24 { get; set; }
        public bool GN6 { get; set; }
        public bool GN75A { get; set; }
        public bool GN1 { get; set; }

        public string GN11 { get; set; }
        public string GN24_Deprecated { get; set; }
        public string GN6_Deprecated { get; set; }
        public string GN27 { get; set; }
        public string GN75_Deprecated { get; set; }

        public Date RequestedStartDate { get; set; }
        public Time RequestedStartTimeDay { get; set; }
        public Time RequestedStartTimeNight { get; set; }

        public string HazardsAndOrRequirements { get; set; }

        public string OtherAreasAndOrUnitsAffectedArea { get; set; }
        public string OtherAreasAndOrUnitsAffectedPersonNotified { get; set; }

        //Workers Minimum Safety Requirements
        public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; set; }

        public bool FaceShield { get; set; }
        public bool Goggles { get; set; }
        public bool RubberBoots { get; set; }
        public bool RubberGloves { get; set; }
        public bool RubberSuit { get; set; }
        public bool SafetyHarnessLifeline { get; set; }
        public bool HighVoltagePPE { get; set; }
        public string Other1 { get; set; }

        public bool EquipmentGrounded { get; set; }
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

        [IgnoreDifference]
        public PermitRequestCompletionStatus CompletionStatus { get; set; }

        public string Status
        {
            get { return CompletionStatus.GetName(); }
        }
    }
}