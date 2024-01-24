using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitEdmontonSharedView : IAddEditBaseFormView
    {
        event Action SelectFormGN6ButtonClicked;
        event Action SelectFormGN7ButtonClicked;
        event Action SelectFormGN59ButtonClicked;
        event Action SelectFormGN24ButtonClicked;
        event Action SelectFormGN75AButtonClicked;
        event Action SelectFormGN1ButtonClicked;

        event Action FormGN1CheckBoxCheckChanged;
        bool ConfinedSpaceCheckBoxEnabled { set; }
        bool RescuePlanCheckBoxEnabled { set; }
        bool RescuePlanFormNumberEnabled { set; }

        bool ConfinedSpaceClassEnabled { set; }
        bool ConfinedSpaceCardNumberEnabled { set; }        

        FunctionalLocation FunctionalLocation { get; set; }

        List<DocumentLink> DocumentLinks { get; set; }
        //void ResetDocumentLinks();

        bool IssuedToSuncor { get; set; }
        bool IssuedToContractor { get; }

        string Occupation { get; set; }
        int? NumberOfWorkers { get; set; }
        WorkPermitEdmontonGroup Group { get; set; }

        WorkPermitEdmontonType WorkPermitType { get; set; }        

        string Location { get; set; }
        string Company { get; set; }

        string WorkOrderNumber { get; set; }
        string OperationNumber { get; set; }
        string SubOperationNumber { get; set; }

        string Description { get; set; }

        string HazardsAndOrRequirements { get; set; }

        // Type of Work Section        

        List<string> AlkylationEntryClassOfClothingSelectionList { set; }
        List<string> FlarePitEntryTypeSelectionList { set; }
        
        List<string> ConfinedSpaceClassSelectionList { set; }
        List<EdmontonPermitSpecialWorkType> SpecialWorkTypeSelectionList { set; }

        string AlkylationEntryClassOfClothing { get; set; }
        bool AlkylationEntry { get; set; }
        bool FlarePitEntry { get; set; }
        string FlarePitEntryType { get; set; }
        bool ConfinedSpace { get; set; }
        string ConfinedSpaceCardNumber { get; set; }
        string ConfinedSpaceClass { get; set; }
        bool RescuePlan { get; set; }
        string RescuePlanFormNumber { get; set; }
        bool VehicleEntry { get; set; }
        int? VehicleEntryTotal { get; set; }
        string VehicleEntryType { get; set; }
        bool SpecialWork { get; set; }
        string SpecialWorkFormNumber { get; set; }
        EdmontonPermitSpecialWorkType SpecialWorkType { get; set; }
        //SpecialWork specialworktypen { get; set; }
        //mangesh for RoadAccessOnPermit 
        bool RoadAccessOnPermit { get; set; }
        string RoadAccessOnPermitFormNumber { get; set; }
        string RoadAccessOnPermitType { get; set; }


        //EdmontonPermitSpecialWorkType RoadAccessOnPermit { get; set; }

        bool GN59 { get; set; }
        bool GN7 { get; set; }
        bool GN6 { get; set; }
        bool GN24 { get; set; }
        bool GN75A { get; set; }
        bool GN1 { get; set; }

        FormGN1 FormGN1 { get; set; }
        FormGN59 FormGN59 { get; set; }
        FormGN7 FormGN7 { get; set; }
        FormGN6 FormGN6 { get; set; }
        FormGN24 FormGN24 { get; set; }
        FormGN75A FormGN75A { get; set; }
        
        string FormGN1TradeChecklistNumber { get; set; }
        long? FormGN1TradeChecklistId { get; set; } // Just to hold on to it for saving later.

        WorkPermitSafetyFormState GN11 { get; set; }
        WorkPermitSafetyFormState GN27 { get; set; }        

        List<WorkPermitSafetyFormState> GN11Values { set; } 
        List<WorkPermitSafetyFormState> GN27Values { set; }

        void SetFormGN1ToolTip(string tip);
        void SetFormGN7ToolTip(string tip);
        void SetFormGN59ToolTip(string tip);
        void SetFormGN11ToolTip(string tip);
        void SetFormGN24ToolTip(string tip);
        void SetFormGN27ToolTip(string tip);
        void SetFormGN6ToolTip(string tip);
        void SetFormGN75ToolTip(string tip);

        string OtherAreasAndOrUnitsAffectedArea { get; }
        string OtherAreasAndOrUnitsAffectedPersonNotified { get; }
        bool OtherAreasAndOrUnitsAffected { get; }

        // Worker's minimum safety requirements
        bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob { get; set; }
        bool FaceShield { get; set; }
        bool Goggles { get; set; }
        bool RubberBoots { get; set; }
        bool RubberGloves { get; set; }
        bool RubberSuit { get; set; }
        bool SafetyHarnessLifeline { get; set; }
        bool HighVoltagePPE { get; set; }
        bool Other1 { get; set; }
        String Other1Value { get; set; }
        bool EquipmentGrounded { get; set; }
        bool FireBlanket { get; set; }
        bool FireExtinguisher { get; set; }
        bool FireMonitorManned { get; set; }
        bool FireWatch { get; set; }
        bool SewersDrainsCovered { get; set; }
        bool SteamHose { get; set; }
        bool Other2 { get; set; }
        String Other2Value { get; set; }
        bool AirPurifyingRespirator { get; set; }
        bool BreathingAirApparatus { get; set; }
        bool DustMask { get; set; }
        bool LifeSupportSystem { get; set; }
        bool SafetyWatch { get; set; }
        bool ContinuousGasMonitor { get; set; }
        bool WorkersMonitor { get; set; }
        string WorkersMonitorNumber { get; set; }
        bool BumpTestMonitorPriorToUse { get; set; }
        bool Other3 { get; set;  }
        String Other3Value { get; set; }
        bool AirMover { get; set; }
        bool BarriersSigns { get; set; }
        bool RadioChannel { get; set; }
        string RadioChannelNumber { get; set; }
        bool AirHorn { get; set; }
        bool MechVentilationComfortOnly { get; set; }
        bool AsbestosMMCPrecautions { get; set; }
        bool Other4 { get; set; }
        String Other4Value { get; set; }

        DateTime LastModifiedDateTime { set; }
        User LastModifiedBy { set; }
        List<AreaLabel> AreaLabels { set; }
        AreaLabel AreaLabel { get; set; }        

        void SetErrorForNoFunctionalLocation();
        void SetErrorForNoPermitType();
        void SetErrorForNoDescription();
        void SetErrorForNoContractor();
        void SetErrorForNumberOfWorkersLessThanOrEqualToZero();
        void SetErrorForNoAreaAffected();
        void SetErrorForNoPersonNotified();
        void SetErrorForStartDateTimeNotBeforeEndDateTime();
        void SetErrorForNoOccupation();
        void SetErrorForNoLocation();
        void SetErrorForNoGroup();

        void SetErrorForNoClassOfClothing();
        
        void SetErrorForNoFlarePitEntryType();
        
        void SetErrorForNoVehicleEntryTotalNumber();
        void SetErrorForNoVehicleEntryType();
        void SetErrorForNoSpecialWorkFormNumber();
        void SetErrorForNoSpecialWorkType();

        void SetErrorForNoRoadAccessOnPermitFormNumber();
        void SetErrorForNoRoadAccessOnPermit();

        void SetErrorForOther1CheckedWithNoValue();
        void SetErrorForOther2CheckedWithNoValue();
        void SetErrorForOther3CheckedWithNoValue();
        void SetErrorForOther4CheckedWithNoValue();

        void SetErrorForNoSafetyRequirementChosen();

        void SetErrorForNoAlphaNumeric(string name); //mangesh - for numeric field
    }
}
