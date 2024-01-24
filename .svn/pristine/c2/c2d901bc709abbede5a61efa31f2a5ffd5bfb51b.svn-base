using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPermitRequestFortHillsFormView : IWorkPermitFortHillsSharedView
    {
        event Action ViewEditHistoryButtonClicked;
        event Action FunctionalLocationButtonClicked;
        event Action SubmitAndCloseButtonClicked;
        event Action ValidateButtonClicked;
        
        //Work Details Start
        List<Contractor> AllCompanies { set; }
        List<DocumentLink> DocumentLinks { get; set; }
        List<Priority> Priorities { set; }
        Priority Priority { get; set; }

        Date RequestedStartDate { get; set; }
        Time RequestedStartTime { get; set; }
        Date RequestedEndDate { get; set; }
        Time RequestedEndTime { get; set; }
        
        //Work Details End


        
        //Work Scope and Description start
        string SapDescription { get; set; }
        bool SapDescriptionVisible { set; }
       
       //Work Scope and Description start
       
   
        void SetErrorForEndDateMustBeOnOrAfterToday();
        void SetErrorForNoStartTime();
        void SetErrorForNoConfinedSpaceCardNumber(string message);
        void SetErrorForNoConfinedSpaceClass(string message);
        void SetErrorForNoRescuePlanFormNumber(string message);
        void SetErrorForNoSafetyRequirementChosen();
        void SetErrorForNoworkAuthorizationAndDocumentationChosen();

        List<WorkPermitFortHillsType> AllPermitTypes { set; }
        List<CraftOrTrade> AllCraftOrTrades { set; }
       
        List<WorkPermitFortHillsGroup> AllGroups { set; }
        List<CraftOrTrade> AllRoadAccessOnPermitType { set; } //mangesh for RoadAccessOnPermit 
      

        void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations);
        FunctionalLocation ShowFunctionalLocationSelector();
        bool ViewEditHistoryEnabled { set; }

        bool WorkOrderNumberEnabled { set; }
        bool OperationNumberEnabled { set; }
        bool SubOperationNumberEnabled { set; }

        
        
        
        bool RequestedEndDatePickerEnabled { set; }
        bool RequestedEndTimePickerEnabled { set; }
        bool RequestedStartDatePickerEnabled { set; }
        bool RequestedStartTimePickerEnabled { set; }
       
        
       
      //  List<string> AllAffectedAreas { set; }
        

        void ShowSaveAndCloseMessageForErrors();
        DialogResult ShowSaveAndCloseMessageForWarnings_NonTurnaroundCase();
        DialogResult ShowSaveAndCloseMessageForWarnings_TurnaroundCase();
        void ShowSaveAndCloseMessageForWarningsAndErrors_NonTurnaroundCase();
        void ShowSaveAndCloseMessageForWarningsAndErrors_TurnaroundCase();

        void ShowSubmitAndCloseMessageForErrors();
        void ShowSubmitAndCloseMessageForWarnings();
        void ShowSubmitAndCloseMessageForWarningsAndErrors_NonTurnaroundCase();
        void ShowSubmitAndCloseMessageForWarningsAndErrors_TurnaroundCase();
        void ShowValidationMessageForTurnaroundWarnings();
        void ShowIsValidMessageBox();
        
        //Date RevalidationDate { get; set; }
        //Time RevalidationTime { get; set; }
        //Date ExtensionDate { get; set; }
        //Time ExtensionTime { get; set; }
        //string WorkAndScopeDescription { get; set; }
        //SPECIAL SAFETY EQUIPMENT REQUIREMENT
        //SPECIAL SAFETY EQUIPMENT REQUIREMENT
        //bool AlkylationEntryClassOfClothingEnabled { set; }
        //bool FlarePitEntryTypeEnabled { set; }
        //bool VehicleEntryTotalEnabled { set; }
        //bool VehicleEntryTypeEnabled { set; }
        //bool SpecialWorkTypeEnabled { set; }
        //bool SpecialWorkFormNumberEnabled { set; }        
        //bool RequestedStartDayTimeCheckboxChecked { set; }
        //bool RequestedStartNightTimeCheckboxChecked { set; }
        //void ApplyConfinedSpaceClassFormRules(); 
        //bool RevalidationTimePickerEnabled { set; }
        //bool RevalidationDatePickerEnabled { set; }
        //bool ExtensionTimePickerEnabled { set; }
        //bool ExtensionDatePickerEnabled { set; }
        //bool RequestedStartTimeNightPickerEnabled { set; }
        //bool RequestedStartTimeNightPickerEnabled { set; }
        //bool RequestedStartTimeDayPickerEnabled { set; }
        //Time RequestedStartTimeNight { get; set; }
        //void SetErrorForNoApprovedGN59Form(string message);
        //void SetErrorForNoApprovedGN6Form(string message);
        //void SetErrorForNoApprovedGN7Form(string message);
        //void SetErrorForNoApprovedGN24Form(string message);
        //void SetErrorForNoApprovedGN75AForm(string message);
        //void SetErrorForNoApprovedGN1Form(string message);
        //void ActionForValidTradeCheckGN1Form(string message); //Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        //void SetErrorForInvalidGN11Value(string message);
        //void SetErrorForInvalidGN27Value(string message);        
        //List<SpecialWork> AllSpecialWorkType { set; }
        //SpecialWork specialworktype { get; set; }//mangesh for SpecialWork
        //string SpecialWorkName { get; set; }
        //void SetErrorForNoAreaLabel();
        //bool GN59CheckBoxEnabled { set; }
        //void SetOtherAreasAndOrUnitsAffected(string otherAreasAndOrUnitsAffectedArea, string otherAreasAndOrUnitsAffectedPersonNotified);

    }
}
