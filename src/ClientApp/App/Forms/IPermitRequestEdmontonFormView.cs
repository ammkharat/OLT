using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPermitRequestEdmontonFormView : IWorkPermitEdmontonSharedView
    {
        event Action ViewEditHistoryButtonClicked;
        event Action FunctionalLocationButtonClicked;
        event Action SubmitAndCloseButtonClicked;
        event Action ValidateButtonClicked;

        Date RequestedStartDate { get; set; }
        Date RequestedEndDate { get; set; }
        Time RequestedStartTimeDay { get; set; }
        Time RequestedStartTimeNight { get; set; }

        string SapDescription { get; set; }
        bool SapDescriptionVisible { set; }
   
        void SetErrorForEndDateMustBeOnOrAfterToday();
        void SetErrorForNoStartTime();
        
        void SetErrorForNoApprovedGN59Form(string message);
        void SetErrorForNoApprovedGN6Form(string message);
        void SetErrorForNoApprovedGN7Form(string message);
        void SetErrorForNoApprovedGN24Form(string message);
        void SetErrorForNoApprovedGN75AForm(string message);
        void SetErrorForNoApprovedGN1Form(string message);
        void ActionForValidTradeCheckGN1Form(string message); //Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        
        void SetErrorForNoConfinedSpaceCardNumber(string message);
        void SetErrorForNoConfinedSpaceClass(string message);
        void SetErrorForNoRescuePlanFormNumber(string message);
        
        void SetErrorForInvalidGN11Value(string message);
        void SetErrorForInvalidGN27Value(string message);        
        
        void SetErrorForNoAreaLabel();

        List<WorkPermitEdmontonType> AllPermitTypes { set; }
        List<CraftOrTrade> AllCraftOrTrades { set; }
        List<Contractor> AllCompanies { set; }
        List<WorkPermitEdmontonGroup> AllGroups { set; }
        List<CraftOrTrade> AllRoadAccessOnPermitType { set; } //mangesh for RoadAccessOnPermit 
        List<SpecialWork> AllSpecialWorkType { set; }
        SpecialWork specialworktype { get; set; }//mangesh for SpecialWork
        string SpecialWorkName { get; set; }

        void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations);
        FunctionalLocation ShowFunctionalLocationSelector();
        bool ViewEditHistoryEnabled { set; }

        bool WorkOrderNumberEnabled { set; }
        bool OperationNumberEnabled { set; }
        bool SubOperationNumberEnabled { set; }

        bool GN59CheckBoxEnabled { set; }

        void SetOtherAreasAndOrUnitsAffected(string otherAreasAndOrUnitsAffectedArea, string otherAreasAndOrUnitsAffectedPersonNotified);
        
        bool AlkylationEntryClassOfClothingEnabled { set; }
        bool FlarePitEntryTypeEnabled { set; }
        bool VehicleEntryTotalEnabled { set; }
        bool VehicleEntryTypeEnabled { set; }
        bool SpecialWorkTypeEnabled { set; }
        bool SpecialWorkFormNumberEnabled { set; }        
        bool RequestedStartDayTimeCheckboxChecked { set; }
        bool RequestedStartNightTimeCheckboxChecked { set; }
        bool RequestedStartTimeNightPickerEnabled { set; }
        bool RequestedStartTimeDayPickerEnabled { set; }

        List<DocumentLink> DocumentLinks { get; set; }
        List<Priority> Priorities { set; }
        Priority Priority { get; set; }
        List<string> AllAffectedAreas { set; }
        

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

        void ApplyConfinedSpaceClassFormRules();        
    }
}
