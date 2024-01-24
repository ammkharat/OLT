using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.FortHills
{
    public class PermitRequestFortHillsValidationDomainAdapter : PermitRequestBaseValidationAdapterFH
    {
        private readonly List<string> missingFields = new List<string>();
        private readonly PermitRequestFortHills permitRequest;


        //public override bool AlkylationEntry
        //{
        //    get { return permitRequest.AlkylationEntry; }
        //}

        //public override string AlkylationEntryClassOfClothing
        //{
        //    get { return permitRequest.AlkylationEntryClassOfClothing; }
        //}

        //public override bool FlarePitEntry
        //{
        //    get { return permitRequest.FlarePitEntry; }
        //}

        //public override string FlarePitEntryType
        //{
        //    get { return permitRequest.FlarePitEntryType; }
        //}
        //public override bool RescuePlan
        //{
        //    get { return permitRequest.RescuePlan; }
        //}

        //public override string RescuePlanFormNumber
        //{
        //    get { return permitRequest.RescuePlanFormNumber; }
        //}

        //public override bool SpecialWork
        //{
        //    get { return permitRequest.SpecialWork; }
        //}

        //public override FortHillsPermitSpecialWorkType SpecialWorkType
        //{
        //    get { return permitRequest.SpecialWorkType; }
        //}

        ////mangesh for SpecialWork
        ////public override SpecialWork specialworktype
        ////{
        ////    get { return permitRequest.specialworktype; }
        ////}

        //public override string SpecialWorkName
        //{
        //    get { return permitRequest.SpecialWorkName; }
        //}
        ////----

        ////mangesh for RoadAccess
        //public override bool RoadAccessOnPermit
        //{
        //    get { return permitRequest.RoadAccessOnPermit; }
        //}

        //public override string RoadAccessOnPermitType
        //{
        //    get { return permitRequest.RoadAccessOnPermitType; }
        //}
        //public override void ActionForNoRescuePlanFormNumber(string message)
        //{
        //    // field optional or not imported
        //}

        //public override void ActionForNoSpecialWorkType()
        //{
        //    // field optional or not imported
        //}

        //public override void ActionForNoRoadAccessOnPermitType()
        //{

        //}
        //public override string ConfinedSpaceCardNumber
        //{
        //    get { return permitRequest.ConfinedSpaceCardNumber; }
        //}
        //public override string WorkersMonitorNumber
        //{
        //    get { return permitRequest.WorkersMonitorNumber; }
        //}

        //public override bool BumpTestMonitorPriorToUse
        //{
        //    get { return permitRequest.BumpTestMonitorPriorToUse; }
        //}
        //public override bool MechVentilationComfortOnly
        //{
        //    get { return permitRequest.MechVentilationComfortOnly; }
        //}

        public PermitRequestFortHillsValidationDomainAdapter(PermitRequestFortHills permitRequest)
        {
            this.permitRequest = permitRequest;
        }

        public override List<string> MissingImportFieldList
        {
            get { return new List<string>(missingFields); }
        }

        public override int? NumberOfWorkers
        {
            get { return permitRequest.NumberOfWorkers; }
        }

        public override WorkPermitFortHillsGroup Group
        {
            get { return permitRequest.Group; }
        }

        public override FunctionalLocation FunctionalLocation
        {
            get { return permitRequest.FunctionalLocation; }
        }

        public override WorkPermitFortHillsType WorkPermitType
        {
            get { return permitRequest.WorkPermitType; }
        }

        public override Date RequestedStartDate
        {
            get { return permitRequest.RequestedStartDate; }
        }

        public override Date RequestedEndDate
        {
            get { return permitRequest.EndDate; }
        }

        public override Time RequestedStartTime
        {
            get { return permitRequest.RequestedStartTime; }
        }

        public override Time RequestedEndTime
        {
            get { return permitRequest.RequestedEndTime; }
        }

        public override string Description
        {
            get { return permitRequest.Description; }
        }
        
        public override bool IssuedToContractor
        {
            get { return permitRequest.Company != null; }
        }

        public override string Company
        {
            get { return permitRequest.Company; }
        }
        public override string Occupation
        {
            get { return permitRequest.Occupation; }
        }
        public override string Location
        {
            get { return permitRequest.Location; }
        }
        #region[Generic form related code]

        public override bool PartCWorkSectionNotApplicableToJob
        {
            get { return permitRequest.PartCWorkSectionNotApplicableToJob; }
        }

        public override bool PartDWorkSectionNotApplicableToJob
        {
            get { return permitRequest.PartDWorkSectionNotApplicableToJob; }
        }
        public override bool PartEWorkSectionNotApplicableToJob
        {
            get { return permitRequest.PartEWorkSectionNotApplicableToJob; }
        }
       
        #endregion
        #region[ part C D E]
       

        public override bool FlameResistantWorkWear
        {
            get { return permitRequest.FlameResistantWorkWear; }
        }
        public override bool ChemicalSuit
        {
            get { return permitRequest.ChemicalSuit;}
        }
        public override bool FireWatch
        {
            get
            {return permitRequest.FireWatch;}
        }
        public override bool FireBlanket
        {
            get
            { return permitRequest.FireBlanket; }
        }
        public override bool SuppliedBreathingAir
        {
            get { return permitRequest.SuppliedBreathingAir; }
        }
        public override bool AirMover
        {
            get { return permitRequest.AirMover; }
        }
        public override bool PersonalFlotationDevice
        {
            get { return permitRequest.PersonalFlotationDevice; }
        }
        public override bool HearingProtection
        {
            get { return permitRequest.HearingProtection ;}
        }
        public override bool  Other1Selected
        {
            get { return !permitRequest.Other1.IsNullOrEmptyOrWhitespace(); }
        }
        public override string Other1Text
        {
            get { return permitRequest.Other1; }
        }
        public override bool MonoGoggles
        {
            get { return permitRequest.MonoGoggles; }
        }
        public override bool ConfinedSpaceMoniter
        {
            get { return permitRequest.ConfinedSpaceMoniter; }
        }
        public override bool FireExtinguisher
        {
            get { return permitRequest.FireExtinguisher; }
        }
        public override bool SparkContainment
        {
            get { return permitRequest.SparkContainment ; }
        }
        public override bool BottleWatch
        {
            get { return permitRequest.BottleWatch ; }
        }
        public override bool StandbyPerson
        {
            get{return permitRequest.StandbyPerson; }
        }
        public override bool WorkingAlone
        {
            get{return permitRequest.WorkingAlone;}
        }
        public override bool SafetyGloves
        {
            get{return permitRequest.SafetyGloves;}
        }
        public override bool Other2Selected
        {
            get { return !permitRequest.Other2.IsNullOrEmptyOrWhitespace(); }
        }
        public override string Other2Text
        {
            get { return permitRequest.Other2; }
        }
        public override bool FaceShield
        {
            get { return permitRequest.FaceShield; }
        }
        public override bool FallProtection
        {
            get { return permitRequest.FallProtection; }
        }
        public override bool ChargedFireHouse
        {
            get { return permitRequest.ChargedFireHouse; }
        }
        public override bool CoveredSewer
        {
            get { return permitRequest.CoveredSewer; }
        }
        public override bool AirPurifyingRespirator
        {
            get { return permitRequest.AirPurifyingRespirator; }
        }
        public override bool SingalPerson
        {
            get { return permitRequest.SingalPerson; }
        }
        public override bool CommunicationDevice
        {
            get { return permitRequest.CommunicationDevice; }
        }
        public override bool ReflectiveStrips  
        {
            get { return permitRequest.ReflectiveStrips; }
        }
        public override bool Other3Selected
        {
            get { return !permitRequest.Other3.IsNullOrEmptyOrWhitespace(); }
        }
        public override string Other3Text
        {
            get { return permitRequest.Other3; }
        }
        public override string HazardsAndOrRequirements
        {
            get { return permitRequest.HazardsAndOrRequirements; }
        }
        public override bool ConfinedSpace
        {
            get { return permitRequest.ConfinedSpace; }
        }
        public override string ConfinedSpaceClass
        {
            get { return permitRequest.ConfinedSpaceClass; }
        }
        public override bool GroundDisturbance 
        {
            get { return permitRequest.GroundDisturbance; }
        }
        public override bool FireProtectionAuthorization
        {
            get { return permitRequest.FireProtectionAuthorization; }
        }
        public override bool CriticalOrSeriousLifts
        {
            get { return permitRequest.CriticalOrSeriousLifts; }
        }
        public override bool VehicleEntry
        {
            get { return permitRequest.VehicleEntry; }
        }
        public override bool IndustrialRadiography
        {
            get { return permitRequest.IndustrialRadiography; }
        }
        public override bool ElectricalEncroachment
        {
            get { return permitRequest.ElectricalEncroachment; }
        }
        public override bool MSDS
        {
            get { return permitRequest.MSDS; }
        }
        public override bool OthersPartE
        {
            get { return !permitRequest.OthersPartE.IsNullOrEmptyOrWhitespace(); }
        }
        public override string OthersPartEValue
        {
            get { return permitRequest.OthersPartE; }
        }
        #endregion

       
        public override void ClearErrors()
        {
            missingFields.Clear();
        }

        public override void ActionForNumberOfWorkersLessThanOrEqualToZero()
        {
             // field not imported
        }

        public override void ActionForNoGroup()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Group);
        }

        public override void ActionForNoFunctionalLocation()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_FunctionalLocation);
        }

        public override void ActionForNoPermitType()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_WorkPermitType);
        }

        public override void ActionForNoStartTime()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_StartTime);
        }

        public override void ActionForNoDescription()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Description);
        }

        public override void ActionForNoContractor()
        {
            // field not imported
        }
        public override void ActionForNoIssuedTo()
        {
            missingFields.Add(StringResources.WorkPermitEdmonton_NoIssuedToOptionChosen);
        }

        public override void ActionForNoSafetyRequirementChosen()
        {
            // field not imported
        }
        public override void ActionForNoworkAuthorizationAndDocumentationChosen()
        {
            // field not imported
        }
        //public override void ActionForNoPersonNotified()
        //{
        //    // field not imported
        //}

        public override void ActionForNoOccupation()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Occupation);
        }

        public override void ActionForNoLocation()
        {
            // field not imported - if there is a floc, then we have this field
        }
        public override void ActionForNoHazardsAndOrRequirements()
        {
           // missingFields.Add(StringResources.PermitRequestFieldName_Description);
        }
        /*
        public override void ActionForNoApprovedGN59Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN6Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN24Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN75AForm(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN1Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForValidTradeCheckGN1Form(string message) //Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        {
            // field optional or not imported
        }

        public override void ActionForNoApprovedGN7Form(string message)
        {
            // field optional or not imported
        }

        public override void ActionForInvalidGN11Value(string message)
        {
            // field optional or not imported
        }

        public override void ActionForInvalidGN27Value(string message)
        {
            // field optional or not imported
        }
        public override bool OtherAreasAndOrUnitsAffected
        {
            get
            {
                return permitRequest.OtherAreasAndOrUnitsAffectedArea != null ||
                       permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified != null;
            }
        }

        public override string OtherAreasAndOrUnitsAffectedArea
        {
            get { return permitRequest.OtherAreasAndOrUnitsAffectedArea; }
        }

        public override string OtherAreasAndOrUnitsAffectedPersonNotified
        {
            get { return permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified; }
        }
        */


        public override void ActionForOther1SelectedWithNoValue()
        {
            // field optional or not imported
        }

        public override void ActionForOther2SelectedWithNoValue()
        {
            // field optional or not imported
        }

        public override void ActionForOther3SelectedWithNoValue()
        {
            // field optional or not imported
        }

        public override void ActionForOtherPartESelectedWithNoValue()
        {
            // field optional or not imported
        }

        public override void ActionForNoConfinedSpaceClass(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoConfinedSpaceCardNumber(string message)
        {
            // field optional or not imported
        }

        public override void ActionForNoStartDate()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_StartDate);
        }

        public override void ActionForNoEndDate()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_EndDate);
        }

        public override void ActionForStartDateAfterEndDate()
        {
            // should be validated by something else since this adapter just sets the list of missing fields.
        }
    }
}