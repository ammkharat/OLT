using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitFortHillsSharedView : IAddEditBaseFormView
    {
        //event Action SelectFormGN6ButtonClicked;
        //event Action SelectFormGN7ButtonClicked;
        //event Action SelectFormGN59ButtonClicked;
        //event Action SelectFormGN24ButtonClicked;
        //event Action SelectFormGN75AButtonClicked;
        //event Action SelectFormGN1ButtonClicked;
        //event Action FormGN1CheckBoxCheckChanged;
        //bool RescuePlanCheckBoxEnabled { set; }
        //bool RescuePlanFormNumberEnabled { set; }
        //bool ConfinedSpaceCardNumberEnabled { set; }        
        

        /**/
        DateTime LastModifiedDateTime { set; }
        User LastModifiedBy { set; }
        bool IssuedToSuncor { get; set; }
        bool IssuedToContractor { get; set; }
        string Company { get; set; }
        string Occupation { get; set; } // dropdown
        int? NumberOfWorkers { get; set; }
        WorkPermitFortHillsGroup Group { get; set; }

        WorkPermitFortHillsType WorkPermitType { get; set; }

        string ClonedFormDetailFortHills { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History


        string Location { get; set; }
        FunctionalLocation FunctionalLocation { get; set; }
        List<DocumentLink> DocumentLinks { get; set; }

        string WorkOrderNumber { get; set; }
        string OperationNumber { get; set; }
        string SubOperationNumber { get; set; }

        //string Craft { get; set; }
        //Int32? CrewSize { get; set; }
        string JobCoordinator { get; set; }
        string CoOrdContactNumber { get; set; }
        //string EmergencyAssemblyArea { get; set; }
        //string EmergencyMeetingPoint { get; set; }
        //string EmergencyContactNo { get; set; }
        string EquipmentNo { get; set; }
        bool LockBoxnumberChecked { get; set; }
        
        
       

        string Description { get; set; }
       

        // PART C-1
        bool PartCWorkSectionNotApplicableToJob { get; set; }

        bool FlameResistantWorkWear { get; set; }
        bool ChemicalSuit { get; set; }
        bool FireWatch { get; set; }
        bool FireBlanket { get; set; }
        bool SuppliedBreathingAir { get; set; }
        bool AirMover { get; set; }
        bool PersonalFlotationDevice { get; set; }
        bool HearingProtection { get; set; }
        bool Other1 { get; set; }
        String Other1Value { get; set; }





        bool MonoGoggles { get; set; }
        bool ConfinedSpaceMoniter { get; set; }
        bool FireExtinguisher { get; set; }
        bool SparkContainment { get; set; }
        bool BottleWatch { get; set; }
        bool StandbyPerson { get; set; }
        bool WorkingAlone { get; set; }
        bool SafetyGloves { get; set; }
        bool Other2 { get; set; }
        String Other2Value { get; set; }

       
        bool FaceShield { get; set; }
        bool FallProtection { get; set; }
        bool ChargedFireHouse { get; set; }
        bool CoveredSewer { get; set; }
        bool AirPurifyingRespirator { get; set; }
        bool SingalPerson { get; set; }
        bool CommunicationDevice { get; set; }
        bool ReflectiveStrips { get; set; }
        bool Other3 { get; set; }
        String Other3Value { get; set; }


        //PART D  SAFETY PRECAUTIONS / HAZARDOUS START
        bool PartDWorkSectionNotApplicableToJob { get; set; }

        string HazardsAndOrRequirements { get; set; }
        //PART D  SAFETY PRECAUTIONS / HAZARDOUS END

        // PART E WORK AUTHORIZATION AND OR DOCUMENTATION 
        bool PartEWorkSectionNotApplicableToJob { get; set; }
        bool PartEWorkSectionNotApplicableToJobEnabled { get; set; }

        List<string> ConfinedSpaceClassSelectionList { set; }
        bool ConfinedSpace { get; set; }
        string ConfinedSpaceClass { get; set; }
        bool GoundDisturbance { get; set; }
        bool FireProtectionAuthorization { get; set; }
        bool CriticalOrSeriousLifts { get; set; }
        bool VehicleEntry { get; set; }
        bool IndustrialRadiography { get; set; }
        bool ElectricalEncroachment { get; set; }
        bool MSDS { get; set; }
        bool OthersPartEChecked { get; set; }
        String OthersPartE { get; set; }

      
        bool ConfinedSpaceCheckBoxEnabled { set; }
        bool ConfinedSpaceClassEnabled { set; }
       

        //List<AreaLabel> AreaLabels { set; }
        //AreaLabel AreaLabel { get; set; }        

        void SetErrorForNoFunctionalLocation();
        void SetErrorForNoPermitType();
        void SetErrorForNoDescription();
        void SetErrorForNoContractor();
        void SetErrorForNoIssuedToOptionSelected();
        void SetErrorForNumberOfWorkersLessThanOrEqualToZero();
        //void SetErrorForNoAreaAffected();
        //void SetErrorForNoPersonNotified();
        void SetErrorForStartDateTimeNotBeforeEndDateTime();
        void SetErrorForNoOccupation();
        void SetErrorForNoLocation();
        void SetErrorForNoGroup();
      
      
        void SetErrorForOther1CheckedWithNoValue();
        void SetErrorForOther2CheckedWithNoValue();
        void SetErrorForOther3CheckedWithNoValue();
        void SetErrorForOtherPartECheckedWithNoValue();
        void SetErrorForNoHazardsAndOrRequirements();
        //void SetErrorForNoSafetyRequirementChosen();

        void SetErrorForNoAlphaNumeric(string name); 
    }
}
