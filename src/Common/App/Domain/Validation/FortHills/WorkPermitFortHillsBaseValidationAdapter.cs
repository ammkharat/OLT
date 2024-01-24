using System;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.FortHills
{
    public abstract class WorkPermitFortHillsBaseValidationAdapter
    {
        public abstract bool IssuedToContractor { get; }
        public abstract bool IssuedToSuncor { get; }
        public abstract string Company { get; }
        public abstract int? NumberOfWorkers { get; }
        public abstract string Occupation { get; }
        public abstract WorkPermitFortHillsGroup Group { get; }
        public abstract WorkPermitFortHillsType WorkPermitType { get; }
        public abstract FunctionalLocation FunctionalLocation { get; }
        public abstract string Description { get; }
        public abstract string EquipmentNo { get; }
        
        public abstract DateTime RequestedStartDateTime { get; }
        public abstract DateTime ExpiryDateTime { get; }

        public abstract DateTime? ExtensionDateTime { get; }
        public abstract DateTime? RevalidationDateTime { get; }

        public abstract string EmergencyAssemblyArea { get; }
        public abstract string EmergencyContactNo { get; }
        public abstract string EmergencyMeetingPoint { get; }

        public abstract string Location { get; }
        public abstract bool IsLockboxNumberrequired { get; }
        public abstract string LockBoxNumber { get; }
        public abstract string IsolationNo { get; }

        public abstract string HazardsAndOrRequirements { get; }

        public abstract bool PartCWorkSectionNotApplicableToJob { get; }
        public abstract bool PartDWorkSectionNotApplicableToJob { get; }
        public abstract bool PartEWorkSectionNotApplicableToJob { get; }
        public abstract bool PartFWorkSectionNotApplicableToJob { get; }
        public abstract bool PartGWorkSectionNotApplicableToJob { get; }


        
        public abstract bool FlameResistantWorkWear { get; }
        public abstract bool ChemicalSuit { get; }
        public abstract bool FireWatch { get; }
        public abstract bool FireBlanket { get; }
        public abstract bool SuppliedBreathingAir { get; }
        public abstract bool AirMover { get; }
        public abstract bool PersonalFlotationDevice { get; }
        public abstract bool HearingProtection { get; }
        public abstract bool Other1 { get; }
        public abstract string Other1Value { get; }


        public abstract bool MonoGoggles { get; } 
        public abstract bool ConfinedSpaceMoniter { get; }
        public abstract bool FireExtinguisher { get; }
        public abstract bool SparkContainment { get; }
        public abstract bool BottleWatch { get; }
        public abstract bool StandbyPerson { get; }
        public abstract bool WorkingAlone { get; }
        public abstract bool SafetyGloves { get; }
        public abstract bool Other2 { get; }
        public abstract string Other2Value { get; }
        
        
        public abstract bool FaceShield { get; }
        public abstract bool FallProtection { get; }
        public abstract bool ChargedFireHouse { get; }
        public abstract bool CoveredSewer { get; }
        public abstract bool AirPurifyingRespirator { get; }
        public abstract bool SingalPerson { get; }
        public abstract bool CommunicationDevice { get; }
        public abstract bool ReflectiveStrips { get; }
        public abstract bool Other3 { get; }
        public abstract string Other3Value { get; }

        public abstract bool ConfinedSpace { get; }
        public abstract string ConfinedSpaceClass { get; }
        public abstract bool GroundDisturbance { get; }
        public abstract bool FireProtectionAuthorization { get; }
        public abstract bool CriticalOrSeriousLifts { get; }
        public abstract bool VehicleEntry { get; }
        public abstract bool IndustrialRadiography { get; }
        public abstract bool ElectricalEncroachment { get; }
        public abstract bool MSDS { get; }
        public abstract bool OthersPartEChecked { get; }
        public abstract string OthersPartE { get; }
        

        public abstract bool MechanicallyIsolated { get; }
        public abstract bool BlindedOrBlanked { get; }
        public abstract bool DoubleBlockedandBled { get; }
        public abstract bool DrainedAndDepressurised { get; }
        public abstract bool PurgedorNeutralised { get; }
        public abstract bool ElectricallyIsolated { get; }
        public abstract bool TestBumped { get; }
        public abstract bool NuclearSource { get; }
        public abstract bool ReceiverStafingRequirements { get; }

        public abstract string Frequency { get; }
        public abstract bool Continuous { get; }
        public abstract string TesterName { get; }
        public abstract bool Oxygen { get; }
        public abstract bool LEL { get; }
        public abstract bool H2SPPM { get; }
        public abstract bool CoPPM { get; }
        public abstract bool So2PPM { get; }
        public abstract bool Other1PartG { get; }
        public abstract string Other1PartGValue { get; }
        public abstract bool Other2PartG { get; }
        public abstract string Other2PartGValue { get; }

        public abstract bool IsFieldTourRequired { get; }
        public abstract string FieldTourConductedBy { get; }

        public virtual void ClearErrors()
        {
        }
        public virtual void ActionForNoSpecialSafetyEquipmentRequirementChosenPartC()
        {
        }
        public virtual void ActionForNoworkAuthorizationAndDocumentationChosenPartE()
        {
        }
        public virtual void ActionForNoControlOfHazardusEnergyChosenPartF()
        {
        }
        public virtual void ActionForNoAtmosphericMoniteringChosenPartG()
        {
        }
        public virtual void ActionForNumberOfWorkersLessThanOrEqualToZero()
        {
        }
        public virtual void ActionForNoFunctionalLocation()
        {
        }

        public virtual void ActionForNoPermitType()
        {
        }

        public virtual void ActionForNoDescription()
        {
        }

        public virtual void ActionForNoNumeric(string name)
        {
        }
        public virtual void ActionForNoContractor()
        {
        }
        public virtual void ActionForNoIssuedTo()
        {
        }
        public virtual void ActionForNoOccupation()
        {
        }

        public virtual void ActionForNoLocation()
        {
        }

        public virtual void ActionForNoLockBoxAndIsolationNo()
        {
        }
        public virtual void ActionForNoEquipmentNo()
        {
        }
        public virtual void ActionForIsFieldTourRequiredYes()
        {
        }
        public virtual void ActionForOther1CheckedWithNoValue()
        {
        }

        public virtual void ActionForOther2CheckedWithNoValue()
        {
        }

        public virtual void ActionForOther3CheckedWithNoValue()
        {
        }

        public virtual void ActionForOtherPartECheckedWithNoValue()
        {
        }
        public virtual void ActionForOther1PartGCheckedWithNoValue()
        {
        }
        public virtual void ActionForOther2PartGCheckedWithNoValue()
        {
        }
        public virtual void ActionForStartDateTimeNotBeforeEndDateTime()
        {
        }
        public virtual void ActionForExpiryDateTimeInThePast()
        {
        }
        public virtual void ActionForNoHazardsAndOrRequirements()
        {
        }
        public virtual void ActionForHazardsTooLong()
        {
        }
        public virtual void ActionForNoEmergencyDetails()
        {
        }
       
    }
}