using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.FortHills
{
    public abstract class PermitRequestBaseValidationAdapterFH
    {
        public abstract int? NumberOfWorkers { get; }

        public abstract WorkPermitFortHillsGroup Group { get; }

        public abstract FunctionalLocation FunctionalLocation { get; }

        public abstract WorkPermitFortHillsType WorkPermitType { get; }

        public abstract Date RequestedStartDate { get; }
        public abstract Date RequestedEndDate { get; }

        public abstract Time RequestedStartTime{ get; }
        public abstract Time RequestedEndTime { get; }
        public abstract bool PartDWorkSectionNotApplicableToJob { get; }
        public abstract string HazardsAndOrRequirements { get; }

        public abstract string Description { get; }
        //public abstract string WorkAndScopeDescription { get; }
        
        public abstract bool IssuedToContractor { get; }
        public abstract string Company { get; }

        
        public abstract string Occupation { get; }
        public abstract string Location { get; }
        /*
        public abstract bool OtherAreasAndOrUnitsAffected { get; }
        public abstract string OtherAreasAndOrUnitsAffectedArea { get; }
        public abstract string OtherAreasAndOrUnitsAffectedPersonNotified { get; }

        public abstract bool GN59 { get; }
        public abstract FormGN59 FormGN59 { get; }

        public abstract bool GN7 { get; }
        public abstract FormGN7 FormGN7 { get; }

        public abstract bool GN6 { get; }
        public abstract FormGN6 FormGN6 { get; }

        public abstract bool GN24 { get; }
        public abstract FormGN24 FormGN24 { get; }

        public abstract bool GN75A { get; }
        public abstract FormGN75A FormGN75A { get; }

        public abstract bool GN1 { get; }
        public abstract FormGN1 FormGN1 { get; }
       
        public abstract WorkPermitSafetyFormState GN11 { get; }

        public abstract WorkPermitSafetyFormState GN27 { get; }
        // public abstract bool SafetyHarnessLifeline { get; }
        // public abstract bool Goggles { get; }
        public abstract bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; }
         */
        public abstract bool PartCWorkSectionNotApplicableToJob { get; }
        public abstract bool FlameResistantWorkWear { get; }
        public abstract bool ChemicalSuit { get; }
        public abstract bool FireWatch { get; }
        public abstract bool FireBlanket { get; }
        public abstract bool SuppliedBreathingAir { get; }
        public abstract bool AirMover { get; }
        public abstract bool PersonalFlotationDevice { get; }
        public abstract bool HearingProtection { get; }
        public abstract bool Other1Selected { get; }
        public abstract string Other1Text { get; }
        public abstract bool MonoGoggles { get; }
        public abstract bool ConfinedSpaceMoniter { get; }
        public abstract bool FireExtinguisher { get; }
        public abstract bool SparkContainment { get; }
        public abstract bool BottleWatch { get; }
        public abstract bool StandbyPerson { get; }
        public abstract bool WorkingAlone { get; }
        public abstract bool SafetyGloves { get; }
        public abstract bool Other2Selected { get; }
        public abstract string Other2Text { get; }
       
        public abstract bool FaceShield { get; }
        public abstract bool FallProtection { get; }
        public abstract bool ChargedFireHouse { get; }
        public abstract bool CoveredSewer { get; }
        public abstract bool AirPurifyingRespirator { get; }
        public abstract bool SingalPerson { get; }
        public abstract bool CommunicationDevice { get; }
        public abstract bool ReflectiveStrips { get; }
        public abstract bool Other3Selected { get; }
        public abstract string Other3Text { get; }
        public abstract bool ConfinedSpace { get; }

        public abstract bool PartEWorkSectionNotApplicableToJob { get; }
        public abstract string ConfinedSpaceClass { get; }
        public abstract bool GroundDisturbance { get; }
        public abstract bool FireProtectionAuthorization { get; }
        public abstract bool CriticalOrSeriousLifts { get; }
        public abstract bool VehicleEntry { get; }
        public abstract bool IndustrialRadiography { get; }
        public abstract bool ElectricalEncroachment { get; }
        public abstract bool MSDS { get; }
        public abstract bool OthersPartE { get; }
        public abstract string OthersPartEValue { get; }
        //public abstract bool MechanicallyIsolated { get; }
        //public abstract bool BlindedOrBlanked { get; }
        //public abstract bool DoubleBlockedandBled { get; }
        //public abstract bool DrainedAndDepressurised { get; }
        //public abstract bool PurgedorNeutralised { get; }
        //public abstract bool ElectricallyIsolated { get; }
        //public abstract bool TestBumped { get; }
        //public abstract bool NuclearSource { get; }
        //public abstract bool ReceiverStafingRequirements { get; }

        //public abstract bool ConfinedSpace { get; }
        //public abstract string ConfinedSpaceClass { get; }

       public virtual List<string> MissingImportFieldList
        {
            get { throw new NotImplementedException(); }
        }

        public abstract void ClearErrors();
        public abstract void ActionForNumberOfWorkersLessThanOrEqualToZero();
        public abstract void ActionForNoGroup();
        public abstract void ActionForNoFunctionalLocation();
        public abstract void ActionForNoPermitType();
        public abstract void ActionForNoStartTime();
        public abstract void ActionForNoDescription();
        public abstract void ActionForNoContractor();
        public abstract void ActionForNoIssuedTo();
        //public abstract void ActionForNoAreaAffected();
        //public abstract void ActionForNoPersonNotified();
        public abstract void ActionForNoOccupation();
        public abstract void ActionForNoLocation();
        public abstract void ActionForNoSafetyRequirementChosen();
        public abstract void ActionForNoworkAuthorizationAndDocumentationChosen();
        public abstract void ActionForOther1SelectedWithNoValue();
        public abstract void ActionForOther2SelectedWithNoValue();
        public abstract void ActionForOther3SelectedWithNoValue();
        public abstract void ActionForOtherPartESelectedWithNoValue();
        public abstract void ActionForNoConfinedSpaceClass(string message);
        public abstract void ActionForNoConfinedSpaceCardNumber(string message);

        public abstract void ActionForNoHazardsAndOrRequirements();
        

        public abstract void ActionForNoStartDate();
        public abstract void ActionForNoEndDate();
        public abstract void ActionForStartDateAfterEndDate();
    }
}