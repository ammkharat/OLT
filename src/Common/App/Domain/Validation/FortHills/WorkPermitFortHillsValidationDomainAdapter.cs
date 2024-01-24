using System;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.FortHills
{
    public class WorkPermitFortHillsValidationDomainAdapter : WorkPermitFortHillsBaseValidationAdapter
    {
        private readonly WorkPermitFortHills permit;

        public override bool IssuedToSuncor
        {
            get { return permit.IssuedToSuncor; }
        }

        public override DateTime RequestedStartDateTime
        {
            get { return permit.RequestedStartDateTime; }
        }

        public override DateTime ExpiryDateTime
        {
            get { return permit.ExpiredDateTime; }
        }
        public override DateTime? RevalidationDateTime
        {
            get { return permit.RequestedStartDateTime; }
        }

        public override DateTime? ExtensionDateTime
        {
            get { return permit.ExpiredDateTime; }
        }
        
        public WorkPermitFortHillsValidationDomainAdapter(WorkPermitFortHills permit)
        {
            this.permit = permit;
        }

        public override int? NumberOfWorkers
        {
            get { return permit.NumberOfWorkers; }
        }

        public override WorkPermitFortHillsGroup Group
        {
            get { return permit.Group; }
        }

        public override FunctionalLocation FunctionalLocation
        {
            get { return permit.FunctionalLocation; }
        }

        public override WorkPermitFortHillsType WorkPermitType
        {
            get { return permit.WorkPermitType; }
        }

        public override string Description
        {
            get { return permit.TaskDescription; }
        }
        public override string EquipmentNo
        {
            get { return permit.EquipmentNo; }
        }
        public override bool IssuedToContractor
        {
            get { return permit.IssuedToCompany; }
        }

        public override string Company{get { return permit.Company; }}

        public override bool IsLockboxNumberrequired{get { return permit.LockBoxnumberChecked; }}
        public override string LockBoxNumber { get { return permit.LockBoxNumber; } }
        public override string IsolationNo { get { return permit.IsolationNo; } }
        public override bool IsFieldTourRequired { get { return permit.IsFieldTourRequired; } }
        public override string FieldTourConductedBy { get { return permit.FieldTourConductedBy; } }
        public override string Occupation{get { return permit.Occupation; }}

        public override string Location{get { return permit.Location; }}
        public override string EmergencyAssemblyArea { get { return permit.EmergencyAssemblyArea; } }
        public override string EmergencyContactNo { get { return permit.EmergencyContactNo; } }
        public override string EmergencyMeetingPoint { get { return permit.EmergencyMeetingPoint; } }

        public override bool FlameResistantWorkWear{get { return permit.FlameResistantWorkWear; }}
        public override bool ChemicalSuit{get { return permit.ChemicalSuit; }}
        public override bool FireWatch{get { return permit.FireWatch; }}
        public override bool FireBlanket{get { return permit.FireBlanket; }}
        public override bool SuppliedBreathingAir{get { return permit.SuppliedBreathingAir; }}
        public override bool AirMover{get { return permit.AirMover; }}
        public override bool PersonalFlotationDevice{get { return permit.PersonalFlotationDevice; }}
        public override bool HearingProtection{get { return permit.HearingProtection; }}
        public override bool Other1{get { return permit.Other1Checked; }}
        public override string Other1Value{get { return permit.Other1; }}


        public override bool MonoGoggles{get { return permit.MonoGoggles; }}
        public override bool ConfinedSpaceMoniter{get { return permit.ConfinedSpaceMoniter; }}
        public override bool FireExtinguisher{get { return permit.FireExtinguisher; }}
        public override bool SparkContainment{get { return permit.SparkContainment; }}
        public override bool BottleWatch{get { return permit.BottleWatch; }}
        public override bool StandbyPerson{get { return permit.StandbyPerson; }}
        public override bool WorkingAlone{get { return permit.WorkingAlone; }}
        public override bool SafetyGloves{get { return permit.SafetyGloves; }}
        public override bool Other2{get { return permit.Other2Checked; }}
        public override string Other2Value{get { return permit.Other2; }}

        public override bool FaceShield{get { return permit.FaceShield; }}
        public override bool FallProtection{get { return permit.FallProtection; }}
        public override bool ChargedFireHouse{get { return permit.ChargedFireHouse; }}
        public override bool CoveredSewer{get { return permit.CoveredSewer; }}
        public override bool AirPurifyingRespirator{get { return permit.AirPurifyingRespirator; }}
        public override bool SingalPerson{get { return permit.SingalPerson; }}
        public override bool CommunicationDevice{get { return permit.CommunicationDevice; }}
        public override bool ReflectiveStrips{get { return permit.ReflectiveStrips; }}
        public override bool Other3{get { return permit.Other3Checked; }}
        public override string Other3Value{get { return permit.Other3; }}


        public override string HazardsAndOrRequirements{get { return permit.HazardsAndOrRequirements; }}

        public override bool ConfinedSpace{get { return permit.ConfinedSpace; }}
        public override string ConfinedSpaceClass{get { return permit.ConfinedSpaceClass; }}
        public override bool GroundDisturbance{get { return permit.GroundDisturbance; }}
        public override bool FireProtectionAuthorization{get {return permit.FireProtectionAuthorization;}}
        public override bool CriticalOrSeriousLifts{get{return permit.CriticalOrSeriousLifts;}}
        public override bool VehicleEntry{get{return permit.VehicleEntry;}}
        public override bool IndustrialRadiography{get{return permit.IndustrialRadiography;}}
        public override bool ElectricalEncroachment{get { return permit.IndustrialRadiography; }}
        public override bool MSDS{get { return permit.MSDS; }}
        public override bool OthersPartEChecked{get { return permit.OthersPartEChecked; }}
        public override string OthersPartE{get { return permit.OthersPartE; }}
        
        public override bool MechanicallyIsolated{get { return permit.MechanicallyIsolated; }}
        public override bool BlindedOrBlanked{get { return permit.BlindedOrBlanked; }}
        public override bool DoubleBlockedandBled{get { return permit.DoubleBlockedandBled; }}
        public override bool DrainedAndDepressurised{get { return permit.DrainedAndDepressurised; }} 
        public override bool PurgedorNeutralised{get { return permit.PurgedorNeutralised; }} 
        public override bool ElectricallyIsolated{get { return permit.ElectricallyIsolated; }}
        public override bool TestBumped{get { return permit.TestBumped; }}
        public override bool NuclearSource{get { return permit.NuclearSource; }}
        public override bool ReceiverStafingRequirements {get { return permit.ReceiverStafingRequirements; }}

        public override string Frequency { get { return permit.Frequency; } }
        public override bool Continuous { get { return permit.Continuous; } }
        public override string TesterName { get { return permit.TesterName; } }
        public override bool Oxygen { get { return permit.Oxygen; } }
        public override bool LEL { get { return permit.LEL; } }
        public override bool H2SPPM { get { return permit.H2SPPM; } }
        public override bool CoPPM { get { return permit.CoPPM; } }
        public override bool So2PPM { get { return permit.So2PPM; } }
        public override bool Other1PartG { get { return permit.Other1PartG; } }
        public override string Other1PartGValue { get { return permit.Other2PartGValue; } }
        public override bool Other2PartG { get { return permit.Other2PartG; } }
        public override string Other2PartGValue { get { return permit.Other2PartGValue; } }

        public override bool PartCWorkSectionNotApplicableToJob { get { return permit.PartCWorkSectionNotApplicableToJob; } }
        public override bool PartDWorkSectionNotApplicableToJob { get { return permit.PartDWorkSectionNotApplicableToJob; } }
        public override bool PartEWorkSectionNotApplicableToJob { get { return permit.PartEWorkSectionNotApplicableToJob; } }
        public override bool PartFWorkSectionNotApplicableToJob { get { return permit.PartFWorkSectionNotApplicableToJob; } }
        public override bool PartGWorkSectionNotApplicableToJob { get { return permit.PartGWorkSectionNotApplicableToJob; } }
    }
}