using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class WorkPermitFortHillsReportAdapter : DomainObject, IReportAdapter
    {
        private readonly WorkPermitFortHills permit;
        private readonly bool taskDescriptionTooLong;

        public WorkPermitFortHillsReportAdapter(WorkPermitFortHills permit, bool taskDescriptionTooLong)
        {
            this.permit = permit;
            this.taskDescriptionTooLong = taskDescriptionTooLong;
        }

        public string WorkPermitTitle
        {
            get { return string.Format("{0} - Safe Work Permit", WorkPermitType); }
        }

        public string WorkPermitStatus
        {
            get { return permit.WorkPermitStatus.ToString(); }
        }

        public string DataSource
        {
            get { return permit.DataSource.ToString(); }
        }

        public string PermitNumber
        {
            get { return permit.PermitNumber.NullableToString(); }
        }

        public bool IssuedToSuncor
        {
            get { return permit.IssuedToSuncor; }
        }

        public bool IssuedToContractor
        {
            get { return permit.IssuedToCompany; }
        }

        public bool IsRoutineMaintenanceType
        {
            get { return permit.WorkPermitType == WorkPermitFortHillsType.BLANKET_HOT; }
        }

        public bool IsColdWorkType
        {
            get { return permit.WorkPermitType == WorkPermitFortHillsType.SPECIFIC_COLD; }
        }

        public bool IsNormalHotWorkType
        {
            get { return permit.WorkPermitType == WorkPermitFortHillsType.SPECIFIC_HOT; }
        }

        public bool IsHighEnergyHotWorkType
        {
            get { return permit.WorkPermitType == WorkPermitFortHillsType.BLANKET_COLD; }
        }

        public string Company
        {
            get { return permit.Company; }
        }

        public string Occupation
        {
            get { return permit.Occupation; }
        }

        public int? NumberOfWorkers
        {
            get { return permit.NumberOfWorkers; }
        }

        public string Group
        {
            get { return permit.Group != null ? permit.Group.Name : string.Empty; }
        }

        public string WorkPermitType
        {
            get { return permit.WorkPermitType.ToString(); }
        }

        public string FunctionalLocation
        {
            get { return permit.FunctionalLocation.FullHierarchy; }
        }

        public string Location
        {
            get { return permit.Location; }
        }
        public bool ConfinedSpace
        {
            get { return permit.ConfinedSpace; }
        }
    /*
      
        */
        public string RequestedStartDateTime
        {
            get { return permit.RequestedStartDateTime.ToShortDateString(); }
        }

        public DateTime? IssuedDateTime
        {
            get { return permit.IssuedDateTime; }
        }

        public DateTime ExpiredDateTime
        {
            get { return permit.ExpiredDateTime; }
        }
        public DateTime? ExtensionDateTime
        {
            get { return permit.ExtensionDateTime; }
        }
        public string ExtensionReasonPartJ
        {
            get { return permit.ExtensionReasonPartJ; }
        }
        public User ExtendedByUser
        {
            get { return permit.ExtendedByUser; }
        }
        public DateTime? RevalidationDateTime
        {
            get { return permit.RevalidationDateTime; }
        }

        public string WorkOrderNumber
        {
            get { return permit.WorkOrderNumber; }
        }

        public string OperationNumber
        {
            get { return permit.OperationNumber; }
        }

        public string SubOperationNumber
        {
            get { return permit.SubOperationNumber; }
        }

        public string EquipmentNo { get { return permit.EquipmentNo; } }
        public string Craft { get { return permit.Craft; } }
        public Int32? CrewSize { get { return permit.CrewSize; } }
        public string JobCoordinator { get { return permit.JobCoordinator; } }
        public string CoOrdContactNumber { get { return permit.CoOrdContactNumber; } }
        public string EmergencyAssemblyArea { get { return permit.EmergencyAssemblyArea; } }
        public string EmergencyMeetingPoint { get { return permit.EmergencyMeetingPoint; } }
        public string EmergencyContactNo { get { return permit.EmergencyContactNo; } }
        public string LockBoxNumber
        {
            get { return permit.LockBoxNumber; }
        }
        public string IsolationNo
        {
            get { return permit.IsolationNo; }
        }
        public string CreatedDateTime
        {
            get { return permit.CreatedDateTime.ToString(); }
        }
        public string CreatedBy
        {
            get { return permit.CreatedBy.FullNameWithUserName; }
        }
        
        public string TaskDescription
        {
            get { return permit.TaskDescription; }
        }

        public string TaskDescriptionTooLongWarning
        {
            get
            {
                if (taskDescriptionTooLong)
                {
                    return
                        "Please refer to the electronic version of the Safe Work Permit for the full Task Description as entered by the Permit Issuer.";
                }
                return string.Empty;
            }
        }

        public bool PartDWorkSectionNotApplicableToJob { get { return permit.PartDWorkSectionNotApplicableToJob; } }
        public string HazardsAndOrRequirements
        {
            get { return permit.HazardsAndOrRequirements; }
        }

        public bool PartCWorkSectionNotApplicableToJob { get { return permit.PartCWorkSectionNotApplicableToJob; } }
        public bool FlameResistantWorkWear { get { return permit.FlameResistantWorkWear; } }
        public bool ChemicalSuit { get { return permit.ChemicalSuit; } }
        public bool FireWatch { get { return permit.FireWatch; } }
        public bool FireBlanket { get { return permit.FireBlanket; } }
        public bool SuppliedBreathingAir { get { return permit.SuppliedBreathingAir; } }
        public bool AirMover { get { return permit.AirMover; } }
        public bool PersonalFlotationDevice { get { return permit.PersonalFlotationDevice; } }
        public bool HearingProtection { get { return permit.HearingProtection; } }
        public string Other1 { get { return permit.Other1; } }
        public bool Other1Checked { get { return Other1.IsNullOrEmptyOrWhitespace()?false:true; } }
        public bool MonoGoggles { get { return permit.MonoGoggles; } }
        public bool ConfinedSpaceMoniter { get { return permit.ConfinedSpaceMoniter; } }
        public bool FireExtinguisher { get { return permit.FireExtinguisher; } }
        public bool SparkContainment { get { return permit.SparkContainment; } }
        public bool BottleWatch { get { return permit.BottleWatch; } }
        public bool StandbyPerson { get { return permit.StandbyPerson; } }
        public bool WorkingAlone { get { return permit.WorkingAlone; } }
        public bool SafetyGloves { get { return permit.SafetyGloves; } }
        public string   Other2 { get { return permit.Other2; } }
        public bool Other2Checked { get { return Other2.IsNullOrEmptyOrWhitespace() ? false : true; } }
        public bool FaceShield { get { return permit.FaceShield; } }
        public bool FallProtection { get { return permit.FallProtection; } }
        public bool ChargedFireHouse { get { return permit.ChargedFireHouse; } }
        public bool CoveredSewer { get { return permit.CoveredSewer; } }
        public bool AirPurifyingRespirator { get { return permit.AirPurifyingRespirator; } }
        public bool SingalPerson { get { return permit.SingalPerson; } }
        public bool CommunicationDevice { get { return permit.CommunicationDevice; } }
        public bool ReflectiveStrips { get { return permit.ReflectiveStrips; } }
        public string Other3 { get { return permit.Other3; } }
        public bool Other3Checked { get { return Other3.IsNullOrEmptyOrWhitespace() ? false : true; } }
        //public bool ConfinedSpace { get { return permit.ConfinedSpace; } }

        public bool PartEWorkSectionNotApplicableToJob { get { return permit.PartEWorkSectionNotApplicableToJob; } }
        public string   ConfinedSpaceClass { get { return permit.ConfinedSpaceClass; } }
        public bool GoundDisturbance { get { return permit.GroundDisturbance; } }
        public bool FireProtectionAuthorization { get { return permit.FireProtectionAuthorization; } }
        public bool CriticalOrSeriousLifts { get { return permit.CriticalOrSeriousLifts; } }
        public bool VehicleEntry { get { return permit.VehicleEntry; } }
        public bool IndustrialRadiography { get { return permit.IndustrialRadiography; } }
        public bool ElectricalEncroachment { get { return permit.ElectricalEncroachment; } }
        public bool MSDS { get { return permit.MSDS; } }
        public string   OthersPartE { get { return permit.OthersPartE; } }
        public bool OthersPartEChecked { get { return permit.OthersPartEChecked; } }
        //Part F
        public bool PartFWorkSectionNotApplicableToJob { get { return permit.PartFWorkSectionNotApplicableToJob; } }
        public bool MechanicallyIsolated { get { return permit.MechanicallyIsolated; } }
        public bool BlindedOrBlanked { get { return permit.BlindedOrBlanked; } }
        public bool DoubleBlockedandBled { get { return permit.DoubleBlockedandBled; } }
        public bool DrainedAndDepressurised { get { return permit.DrainedAndDepressurised; } }
        public bool PurgedorNeutralised { get { return permit.PurgedorNeutralised; } }
        public bool ElectricallyIsolated { get { return permit.ElectricallyIsolated; } }
        public bool TestBumped { get { return permit.TestBumped; } }
        public bool NuclearSource { get { return permit.NuclearSource; } }
        public bool ReceiverStafingRequirements { get { return permit.ReceiverStafingRequirements; } }
        //Part G
        public bool PartGWorkSectionNotApplicableToJob {get { return permit.PartGWorkSectionNotApplicableToJob; } }
        public string Frequency { get {return permit.Frequency; } }
        public bool Continuous { get { return permit.Continuous; } }
        public string TesterName { get {return permit.TesterName; }  }
        public bool Oxygen { get {return permit.Oxygen; }  }
        public bool LEL { get {return permit.LEL; }  }
        public bool H2SPPM { get {return permit.H2SPPM; }  }
        public bool CoPPM { get {return permit.CoPPM; }  }
        public bool So2PPM { get {return permit.So2PPM; }  }
        public bool Other1PartG { get {return permit.Other1PartG; }  }
        public string Other1PartGValue { get {return permit.Other1PartGValue; }  }
        public bool Other2PartG { get {return permit.Other2PartG; }  }
        public string Other2PartGValue { get { return permit.Other2PartGValue; } }

        public string IssuedByUser
        {
            get { return permit.IssuedByUser != null ? permit.IssuedByUser.FullNameWithFirstNameFirst : string.Empty; }
        } // This should never be null when printing but I'm paranoid since its nullable in the DB

        #region ["Contact Details Part"]
        public string PermitIssuer
        {
            get { return permit.PermitIssuer; }
          
        }
        public string AreaAuthority
        {
            get { return permit.AreaAuthority; }
        }
        public string CoAuthorizingIssuer
        {
            get { return permit.CoAuthorizingIssuer; }
            
        }
        public string AddationalAuthority
        {
            get { return permit.AddationalAuthority; }
        }
        public string PermitIssuerContact
        {
            get { return permit.PermitIssuerContact; }
        }
        public string AreaAuthorityContact
        {
            get { return permit.AddationalAuthorityContact; }
        }
        public string CoAuthorizingIssuerContact
        {
            get { return permit.CoAuthorizingIssuerContact; }
        }
        public string AddationalAuthorityContact
        {
            get { return permit.AddationalAuthorityContact; }
        }
        public bool IsFieldTourRequired
        {
            get { return permit.IsFieldTourRequired; }   
        }

        public string FieldTourConductedBy
        {
            get { return permit.FieldTourConductedBy; }
           
        }

        #endregion

        public string PermitAcceptor
        {
            get { return permit.PermitAcceptor; }
        }

        //public string ShiftSupervisor
        //{
        //    get { return permit.ShiftSupervisor; }
        //}

        public string WaterMarkText { get; set; }

        public WorkPermitFortHills Permit
        {
            get { return permit; }
        }
    }
}