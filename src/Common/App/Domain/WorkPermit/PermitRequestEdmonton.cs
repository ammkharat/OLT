﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestEdmonton : BaseMergeablePermitRequest
    {
        public PermitRequestEdmonton(long? id, Date endDate, string description, string sapDescription, string company,
            DataSource dataSource, User lastImportedByUser,
            DateTime? lastImportedDateTime, User lastSubmittedByUser, DateTime? lastSubmittedDateTime, User createdBy,
            DateTime createdDateTime,
            User lastModifiedBy, DateTime lastModifiedDateTime) :
                base(id, endDate, description, sapDescription, company, dataSource,
                    lastImportedByUser, lastImportedDateTime, lastSubmittedByUser,
                    lastSubmittedDateTime, createdBy, createdDateTime, lastModifiedBy,
                    lastModifiedDateTime, null, null, null, PermitRequestCompletionStatus.Incomplete)
            // for now, don't pass workOrderNumber, operationNumber and subOperationNumber as Edmonton seems to be doing special stuff right now.
        {
            GN6_Deprecated = WorkPermitSafetyFormState.NotApplicable;
            GN11 = WorkPermitSafetyFormState.NotApplicable;
            GN24_Deprecated = WorkPermitSafetyFormState.NotApplicable;
            GN27 = WorkPermitSafetyFormState.NotApplicable;
            GN75_Deprecated = WorkPermitSafetyFormState.NotApplicable;

            WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = true;

            Priority = Priority.Normal;
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public PermitRequestEdmonton(string templatename, string categories) 
            : base(templatename, categories)
        {
            _templateName = templatename;
            _categories = categories;
        }

        public bool IssuedToSuncor { get; set; }

        public string Occupation { get; set; }
        public int? NumberOfWorkers { get; set; }
        public WorkPermitEdmontonGroup Group { get; set; }
        public WorkPermitEdmontonType WorkPermitType { get; set; }
        public FunctionalLocation FunctionalLocation { get; set; }
        public string Location { get; set; }
        public Priority Priority { get; set; }

        [CachedRelationship]
        public AreaLabel AreaLabel { get; set; }

        public string AlkylationEntryClassOfClothing { get; set; }
        public string FlarePitEntryType { get; set; }
        public string ConfinedSpaceClass { get; set; }
        public string ConfinedSpaceCardNumber { get; set; }
        public string RescuePlanFormNumber { get; set; }
        public int? VehicleEntryTotal { get; set; }
        public string VehicleEntryType { get; set; }
        public EdmontonPermitSpecialWorkType SpecialWorkType { get; set; }
        public string SpecialWorkFormNumber { get; set; }

        //mangesh for RoadAccessOnPermit
        public bool RoadAccessOnPermit { get; set; }
        public string RoadAccessOnPermitFormNumber { get; set; }
        public string RoadAccessOnPermitType { get; set; }

        public bool AlkylationEntry { get; set; }
        public bool FlarePitEntry { get; set; }
        public bool ConfinedSpace { get; set; }
        public bool RescuePlan { get; set; }
        public bool VehicleEntry { get; set; }
        public bool SpecialWork { get; set; }

        public SpecialWork specialworktype { get; set; }//mangesh for SpecialWork
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

        public override string FunctionalLocationNamesAsString
        {
            get { return FunctionalLocation.FullHierarchy; }
        }

        public bool IsSAPDescriptionAvailableForDisplay
        {
            get { return DataSource == DataSource.SAP && SapDescription != Description; }
        }

        public static bool IsSubmittableStatus(PermitRequestCompletionStatus completionStatus)
        {
            return PermitRequestCompletionStatus.Complete.Equals(completionStatus) ||
                   PermitRequestCompletionStatus.ForReview.Equals(completionStatus);
        }

        public override void UpdateFrom(BasePermitRequest baseRequest)
        {
            var request = (PermitRequestEdmonton) baseRequest;

            EndDate = request.EndDate;
            Description = request.Description;
            SapDescription = request.SapDescription;

            WorkOrderNumber = request.WorkOrderNumber;
            ClearWorkOrderSources();
            request.WorkOrderSourceList.ForEach(AddWorkOrderSource);

            Company = request.Company;
            DataSource = request.DataSource;
            LastImportedByUser = request.LastImportedByUser;
            LastImportedDateTime = request.LastImportedDateTime;

            CreatedBy = request.CreatedBy;
                // This is harmless, but really shouldn't be here. This value doesn't get updated to the DB. I'm not changing it to avoid unnecessary changes to existing and tested functionality.
            CreatedDateTime = request.CreatedDateTime;
                // This is harmless, but really shouldn't be here. This value doesn't get updated to the DB. I'm not changing it to avoid unnecessary changes to existing and tested functionality.

            LastModifiedBy = request.LastModifiedBy;
            LastModifiedDateTime = request.LastModifiedDateTime;

            IsModified = request.IsModified;

            IssuedToSuncor = request.IssuedToSuncor;

            Occupation = request.Occupation;
            NumberOfWorkers = request.NumberOfWorkers;
            Group = request.Group;
            AreaLabel = request.AreaLabel;

            WorkPermitType = request.WorkPermitType;
            FunctionalLocation = request.FunctionalLocation;
            Location = request.Location;

            Priority = request.Priority;

            AlkylationEntryClassOfClothing = request.AlkylationEntryClassOfClothing;
            FlarePitEntryType = request.FlarePitEntryType;
            ConfinedSpaceClass = request.ConfinedSpaceClass;
            ConfinedSpaceCardNumber = request.ConfinedSpaceCardNumber;
            RescuePlanFormNumber = request.RescuePlanFormNumber;
            VehicleEntryTotal = request.VehicleEntryTotal;
            VehicleEntryType = request.VehicleEntryType;
            SpecialWorkType = request.SpecialWorkType;
            SpecialWorkFormNumber = request.SpecialWorkFormNumber;

            SpecialWorkName = request.SpecialWorkName;

            AlkylationEntry = request.AlkylationEntry;
            FlarePitEntry = request.FlarePitEntry;
            ConfinedSpace = request.ConfinedSpace;
            RescuePlan = request.RescuePlan;
            VehicleEntry = request.VehicleEntry;
            SpecialWork = request.SpecialWork;

            FormGN59 = request.FormGN59;
            FormGN7 = request.FormGN7;
            FormGN6 = request.FormGN6;
            FormGN24 = request.FormGN24;
            FormGN75A = request.FormGN75A;

            GN59 = request.GN59;
            GN7 = request.GN7;
            GN24 = request.GN24;
            GN6 = request.GN6;
            GN75A = request.GN75A;

            GN11 = request.GN11;
            GN24_Deprecated = request.GN24_Deprecated;
            GN6_Deprecated = request.GN6_Deprecated;
            GN27 = request.GN27;
            GN75_Deprecated = request.GN75_Deprecated;

            RequestedStartDate = request.RequestedStartDate;
            RequestedStartTimeDay = request.RequestedStartTimeDay;
            RequestedStartTimeNight = request.RequestedStartTimeNight;

            HazardsAndOrRequirements = request.HazardsAndOrRequirements;

            OtherAreasAndOrUnitsAffectedArea = request.OtherAreasAndOrUnitsAffectedArea;
            OtherAreasAndOrUnitsAffectedPersonNotified = request.OtherAreasAndOrUnitsAffectedPersonNotified;

            ////Workers Minimum Safety Requirements
            WorkersMinimumSafetyRequirementsSectionNotApplicableToJob =
                request.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

            FaceShield = request.FaceShield;
            Goggles = request.Goggles;
            RubberBoots = request.RubberBoots;
            RubberGloves = request.RubberGloves;
            RubberSuit = request.RubberSuit;
            SafetyHarnessLifeline = request.SafetyHarnessLifeline;
            HighVoltagePPE = request.HighVoltagePPE;
            Other1 = request.Other1;

            EquipmentGrounded = request.EquipmentGrounded;
            FireBlanket = request.FireBlanket;
            FireExtinguisher = request.FireExtinguisher;
            FireMonitorManned = request.FireMonitorManned;
            FireWatch = request.FireWatch;
            SewersDrainsCovered = request.SewersDrainsCovered;
            SteamHose = request.SteamHose;
            Other2 = request.Other2;

            AirPurifyingRespirator = request.AirPurifyingRespirator;
            BreathingAirApparatus = request.BreathingAirApparatus;
            DustMask = request.DustMask;
            LifeSupportSystem = request.LifeSupportSystem;
            SafetyWatch = request.SafetyWatch;
            ContinuousGasMonitor = request.ContinuousGasMonitor;
            WorkersMonitor = request.WorkersMonitor;
            WorkersMonitorNumber = request.WorkersMonitorNumber;
            BumpTestMonitorPriorToUse = request.BumpTestMonitorPriorToUse;
            Other3 = request.Other3;

            AirMover = request.AirMover;
            BarriersSigns = request.BarriersSigns;
            RadioChannel = request.RadioChannel;
            RadioChannelNumber = request.RadioChannelNumber;
            AirHorn = request.AirHorn;
            MechVentilationComfortOnly = request.MechVentilationComfortOnly;
            AsbestosMMCPrecautions = request.AsbestosMMCPrecautions;
            Other4 = request.Other4;

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

            var incomingPermitRequestEdmonton = (PermitRequestEdmonton) incomingPermitRequest;
            RequestedStartTimeDay = incomingPermitRequestEdmonton.RequestedStartTimeDay;
            RequestedStartTimeNight = incomingPermitRequestEdmonton.RequestedStartTimeNight;
            RequestedStartDate = incomingPermitRequestEdmonton.RequestedStartDate;
            CompletionStatus = DetectIsComplete();
        }

        public PermitRequestEdmontonHistory TakeSnapshot()
        {
            var history = new PermitRequestEdmontonHistory(this);
            return history;
        }

        public override PermitRequestCompletionStatus DetectIsComplete()
        {
            var validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(this),
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
            EndDate = new Date(now);

            DataSource = DataSource.CLONE;

            RescuePlanFormNumber = null;
            ConfinedSpaceCardNumber = null;
            SpecialWorkFormNumber = null;
            //Dharmesh -- Start -- 6Jul2017 for INC0165740 (OLT - Clone / Copy issues with Logs and Work permits)
            //DocumentLinks.Clear();
            //Dharmesh end 6Jul2017
            string formList = string.Empty;
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
            }
            return formList;
        }

        public void ConvertToClone(User user)
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
            EndDate = new Date(now);

            DataSource = DataSource.CLONE;

            FormGN59 = null;
            FormGN7 = null;
            FormGN6 = null;
            FormGN24 = null;
            FormGN75A = null;

            RescuePlanFormNumber = null;
            ConfinedSpaceCardNumber = null;
            SpecialWorkFormNumber = null;
            DocumentLinks.Clear();
        }

        public bool AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected()
        {
            return (FaceShield ||
                    Goggles ||
                    RubberBoots ||
                    RubberGloves ||
                    RubberSuit ||
                    SafetyHarnessLifeline ||
                    HighVoltagePPE ||
                    !Other1.IsNullOrEmptyOrWhitespace() ||
                    EquipmentGrounded ||
                    FireBlanket ||
                    FireExtinguisher ||
                    FireMonitorManned ||
                    FireWatch ||
                    SewersDrainsCovered ||
                    SteamHose ||
                    !Other2.IsNullOrEmptyOrWhitespace() ||
                    AirPurifyingRespirator ||
                    BreathingAirApparatus ||
                    DustMask ||
                    LifeSupportSystem ||
                    SafetyWatch ||
                    ContinuousGasMonitor ||
                    WorkersMonitor ||
                    BumpTestMonitorPriorToUse ||
                    !Other3.IsNullOrEmptyOrWhitespace() ||
                    AirMover ||
                    BarriersSigns ||
                    RadioChannel ||
                    AirHorn ||
                    MechVentilationComfortOnly ||
                    AsbestosMMCPrecautions ||
                    !Other4.IsNullOrEmptyOrWhitespace());
        }

        // This method should compare the existing OLT data to the incoming list, and build a list of DTOs that need to be removed from the OLT database.
        // It is assumed that anything that didn't come in from the import should no longer be in OLT.
        public static List<PermitRequestEdmonton> BuildImportRemovalList(
            List<PermitRequestEdmonton> existingOLTDataList, List<IHasPermitKey> incomingPermitRequests,
            List<IHasPermitKey> thingsThatFailedValidation)
        {
            var removalList = new List<PermitRequestEdmonton>();

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

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public string TemplateCreatedBy { get; set; }
        public string Categories { get; set; }

        public bool Global { get; set; }
        public bool Individual { get; set; }
        public string _templateName { get; set; }
        public string _categories { get; set; }

        public long TemplateId { get; set; } //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**
        

    }
}