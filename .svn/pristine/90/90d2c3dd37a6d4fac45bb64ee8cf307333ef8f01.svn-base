using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Validation.FortHills;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Validation.FortHills
{
    public class PermitRequestFortHillsValidationViewAdapter : PermitRequestBaseValidationAdapterFH
    {
        private readonly IPermitRequestFortHillsFormView view;

        public PermitRequestFortHillsValidationViewAdapter(IPermitRequestFortHillsFormView view)
        {
            this.view = view;
        }

        public override void ClearErrors()
        {
            view.ClearErrorProviders();
        }

        public override int? NumberOfWorkers
        {
            get { return view.NumberOfWorkers; }
        }

        public override Date RequestedStartDate
        {
            get { return view.RequestedStartDate; }
        }
        public override Date RequestedEndDate
        {
            get { return view.RequestedEndDate; }
        }
        public override Time RequestedStartTime
        {
            get { return view.RequestedStartTime; }
        }
        public override Time RequestedEndTime
        {
            get { return view.RequestedEndTime; }
        }
        public override WorkPermitFortHillsGroup Group
        {
            get { return view.Group; }
        }

        public override FunctionalLocation FunctionalLocation
        {
            get { return view.FunctionalLocation; }
        }

        public override WorkPermitFortHillsType WorkPermitType
        {
            get { return view.WorkPermitType; }
        }
        #region [Part B]

        public override string Description
        {
            get { return view.Description; }
        }
        #endregion

        public override bool IssuedToContractor
        {
            get { return view.IssuedToContractor; }
        }

        public override string Company
        {
            get { return view.Company; }
        }

        public override string Occupation
        {
            get { return view.Occupation; }
        }

        public override string Location
        {
            get { return view.Location; }
        }
        
        public override bool PartCWorkSectionNotApplicableToJob
        {
            get { return view.PartCWorkSectionNotApplicableToJob; }
        }
        public override bool PartDWorkSectionNotApplicableToJob
        {
            get { return view.PartDWorkSectionNotApplicableToJob; }
        }
        public override bool PartEWorkSectionNotApplicableToJob
        {
            get { return view.PartEWorkSectionNotApplicableToJob; }
        }
        #region[ part C D E]

        public override bool FlameResistantWorkWear
        {
            get { return view.FlameResistantWorkWear; }
        }
        public override bool ChemicalSuit
        {
            get { return view.ChemicalSuit; }
        }
        public override bool FireWatch
        {
            get { return view.FireWatch; }
        }
        public override bool FireBlanket
        {
            get { return view.FireBlanket; }
        }
        public override bool SuppliedBreathingAir
        {
            get { return view.SuppliedBreathingAir; }
        }
        public override bool AirMover
        {
            get { return view.AirMover; }
        }
        public override bool PersonalFlotationDevice
        {
            get { return view.PersonalFlotationDevice; }
        }
        public override bool HearingProtection
        {
            get { return view.HearingProtection; }
        }
        public override bool Other1Selected
        {
            get { return view.Other1; }
        }
        public override string Other1Text
        {
            get { return view.Other1Value; }
        }
        public override bool MonoGoggles
        {
            get { return view.MonoGoggles; }
        }
        public override bool ConfinedSpaceMoniter
        {
            get { return view.ConfinedSpaceMoniter; }
        }
        public override bool FireExtinguisher
        {
            get { return view.FireExtinguisher; }
        }
        public override bool SparkContainment
        {
            get { return view.SparkContainment; }
        }
        public override bool BottleWatch
        {
            get { return view.BottleWatch; }
        } 
        public override bool StandbyPerson
        {
            get { return view.StandbyPerson; }
        }
        public override bool WorkingAlone
        {
            get { return view.WorkingAlone; }
        }
        public override bool SafetyGloves
        {
            get { return view.SafetyGloves; }
        }
        public override bool Other2Selected
        {
            get { return view.Other2; }
        }
        public override string Other2Text
        {
            get { return view.Other2Value; }
        }
        public override bool FaceShield
        {
            get { return view.FlameResistantWorkWear; }
        }
        public override bool FallProtection
        {
            get { return view.FallProtection; }
        }
        public override bool ChargedFireHouse
        {
            get { return view.ChargedFireHouse; }
        }
        public override bool CoveredSewer
        {
            get { return view.CoveredSewer; }           
        }
        public override bool AirPurifyingRespirator
        {
            get { return view.AirPurifyingRespirator; }            
        }
        public override bool SingalPerson
        {
            get { return view.SingalPerson; }           
        }
        public override bool CommunicationDevice
        {
            get { return view.CommunicationDevice; }            
        }
        public override bool ReflectiveStrips  
        {
            get { return view.ReflectiveStrips; }
        }
        public override bool Other3Selected
        {
            get { return view.Other3; }
        }
        public override string Other3Text
        {
            get { return view.Other3Value; }           
        }

        public override string HazardsAndOrRequirements
        {
            get { return view.HazardsAndOrRequirements; }
        }

        public override bool ConfinedSpace
        {
            get { return view.ConfinedSpace; }
        }
        public override string ConfinedSpaceClass
        {
            get { return view.ConfinedSpaceClass; }
        }
        public override bool GroundDisturbance
        {
            get { return view.GoundDisturbance; }
        }
        public override bool FireProtectionAuthorization
        {
            get { return view.FireProtectionAuthorization; }
        }
        public override bool CriticalOrSeriousLifts
        {
            get { return view.CriticalOrSeriousLifts; }
        }
        public override bool VehicleEntry
        {
            get { return view.VehicleEntry; }
        }
        public override bool ElectricalEncroachment
        {
            get { return view.ElectricalEncroachment; }
        }
        public override bool IndustrialRadiography
        {
            get { return view.IndustrialRadiography; }
        }
        public override bool MSDS
        {
            get { return view.MSDS; }
        }
        public override bool OthersPartE
        {
            get { return view.OthersPartEChecked; }
        }
        public override string OthersPartEValue
        {
            get { return view.OthersPartE; }            
        }
    #endregion

       
        public override void ActionForNumberOfWorkersLessThanOrEqualToZero()
        {
            view.SetErrorForNumberOfWorkersLessThanOrEqualToZero();
        }

        public override void ActionForNoGroup()
        {
            view.SetErrorForNoGroup();
        }

        public override void ActionForNoFunctionalLocation()
        {
            view.SetErrorForNoFunctionalLocation();
        }

        public override void ActionForNoPermitType()
        {
            view.SetErrorForNoPermitType();
        }

        public override void ActionForNoStartTime()
        {
            view.SetErrorForNoStartTime();
        }

        public override void ActionForNoDescription()
        {
            view.SetErrorForNoDescription();
        }

        public override void ActionForNoContractor()
        {
            view.SetErrorForNoContractor();
        }

        public override void ActionForNoIssuedTo()
        {
            view.SetErrorForNoIssuedToOptionSelected();
        }

        public override void ActionForNoSafetyRequirementChosen()//partC
        {
            view.SetErrorForNoSafetyRequirementChosen();
        }
        public override void ActionForNoworkAuthorizationAndDocumentationChosen()//partE
        {
            view.SetErrorForNoworkAuthorizationAndDocumentationChosen();
        }
        public override void ActionForNoOccupation()
        {
            view.SetErrorForNoOccupation();
        }

        public override void ActionForNoLocation()
        {
            view.SetErrorForNoLocation();
        }
        


        public override void ActionForNoConfinedSpaceClass(string message)
        {
            view.SetErrorForNoConfinedSpaceClass(message);
        }

        public override void ActionForNoConfinedSpaceCardNumber(string message)
        {
            view.SetErrorForNoConfinedSpaceCardNumber(message);
        }
        public override void ActionForNoStartDate()
        {
            // This should never happen because the WinForm control forces you to have a value by default.
        }

        public override void ActionForNoEndDate()
        {
            // This should never happen because the WinForm control forces you to have a value by default.
        }

        public override void ActionForStartDateAfterEndDate()
        {
            view.SetErrorForStartDateTimeNotBeforeEndDateTime();
        }

        public override void ActionForOther1SelectedWithNoValue()
        {
            view.SetErrorForOther1CheckedWithNoValue();
        }

        public override void ActionForOther2SelectedWithNoValue()
        {
            view.SetErrorForOther2CheckedWithNoValue();
        }

        public override void ActionForOther3SelectedWithNoValue()
        {
            view.SetErrorForOther3CheckedWithNoValue();
        }

        public override void ActionForOtherPartESelectedWithNoValue()
        {
            view.SetErrorForOtherPartECheckedWithNoValue();
        }

        public override void ActionForNoHazardsAndOrRequirements()//partD
        {
            view.SetErrorForNoHazardsAndOrRequirements();
        }
        

        //public override void ActionForNoRescuePlanFormNumber(string message)
        //{
        //    view.SetErrorForNoRescuePlanFormNumber(message);            
        //}

        //public override void ActionForNoSpecialWorkType()
        //{
        //    view.SetErrorForNoSpecialWorkType();
        //}
        //public override bool AlkylationEntry
        //{
        //    get { return view.AlkylationEntry; }
        //}

        //public override string AlkylationEntryClassOfClothing
        //{
        //    get { return view.AlkylationEntryClassOfClothing; }
        //}

        //public override bool FlarePitEntry
        //{
        //    get { return view.FlarePitEntry; }
        //}

        //public override string FlarePitEntryType
        //{
        //    get { return view.FlarePitEntryType; }
        //}
        //public override string ConfinedSpaceCardNumber
        //{
        //    get { return view.ConfinedSpaceCardNumber; }
        //}

        //public override bool RescuePlan
        //{
        //    get { return view.RescuePlan; }
        //}

        //public override string RescuePlanFormNumber
        //{
        //    get { return view.RescuePlanFormNumber; }
        //}

        //public override bool SpecialWork
        //{
        //    get { return view.SpecialWork; }
        //}

        //public override FortHillsPermitSpecialWorkType SpecialWorkType
        //{
        //    get { return view.SpecialWorkType; }
        //}
        //mangesh for SpecialWork
        //public override SpecialWork specialworktype { get
        //{
        //}
        ////get; {// return view.specialworktype;
        //    //}
        //}

        //public override string SpecialWorkName
        //{
        //    get { return view.SpecialWorkName; }
        //}
        //public override string WorkersMonitorNumber
        //{
        //    get { return view.WorkersMonitorNumber; }           
        //}

        //public override bool BumpTestMonitorPriorToUse
        //{
        //    get { return view.BumpTestMonitorPriorToUse; }          
        //}
        //public override bool SafetyHarnessLifeline
        //{
        //    get { return view.SafetyHarnessLifeline; }
        //}
        //public override string RadioChannelNumber
        //{
        //    get { return view.RadioChannelNumber; }            
        //}
        //public override bool MechVentilationComfortOnly
        //{
        //    get { return view.MechVentilationComfortOnly; }            
        //}
        //public override bool AirPurifyingRespirator
        //{
        //    get { return view.FaceShield; }            
        //}
        /*
        public override bool FireMonitorManned
        {
            get { return view.FireMonitorManned; }
        }
        public override bool EquipmentGrounded
        {
            get { return view.MonoGoggles; }
        }
        public override bool RubberSuit
        {
            get { return view.SuppliedBreathingAir; }
        }
        public override bool OtherAreasAndOrUnitsAffected
         {
             get { return view.OtherAreasAndOrUnitsAffected; }
         }
         public override string OtherAreasAndOrUnitsAffectedArea
         {
             get { return view.OtherAreasAndOrUnitsAffectedArea; }
         }
         public override string OtherAreasAndOrUnitsAffectedPersonNotified
         {
             get { return view.OtherAreasAndOrUnitsAffectedPersonNotified; }
         }
        public override void ActionForNoApprovedGN59Form(string message)
        {
            view.SetErrorForNoApprovedGN59Form(message);
        }

        public override void ActionForNoApprovedGN7Form(string message)
        {
            view.SetErrorForNoApprovedGN7Form(message);
        }

        public override void ActionForNoApprovedGN6Form(string message)
        {
            view.SetErrorForNoApprovedGN6Form(message);
        }

        public override void ActionForNoApprovedGN24Form(string message)
        {
            view.SetErrorForNoApprovedGN24Form(message);
        }

        public override void ActionForNoApprovedGN75AForm(string message)
        {
            view.SetErrorForNoApprovedGN75AForm(message);
        }

        public override void ActionForNoApprovedGN1Form(string message)
        {
            view.SetErrorForNoApprovedGN1Form(message);
        }

        //Start Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        public override void ActionForValidTradeCheckGN1Form(string message)
        {
            view.ActionForValidTradeCheckGN1Form(message);
        }
        //End Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016

        public override void ActionForInvalidGN11Value(string message)
        {
            view.SetErrorForInvalidGN11Value(message);
        }

        public override void ActionForInvalidGN27Value(string message)
        {
            view.SetErrorForInvalidGN27Value(message);
        }
        */

    }
}


