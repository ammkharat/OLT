using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPermitRequestMudsFormView : IAddEditBaseFormView
    {
        event Action ViewEditHistoryButtonClicked;
        event Action FunctionalLocationButtonClicked;
        event Action SubmitAndCloseButtonClicked;

        User LastModifiedBy { set; }
        DateTime LastModifiedDateTime { set; }

        WorkPermitMudsType WorkPermitType { get; set; }
        List<FunctionalLocation> FunctionalLocations { get; set; }
        Date StartDate { get; set; }
        Date EndDate { get; set; }
        WorkPermitMudsGroup RequestedByGroup { get; set; }
        string RequestedByGroupText { get; set; }
        string Trade { get; set; }
        string WorkOrderNumber { get; set; }
        string OperationNumber { get; set; }
        string Description { get; set;}
        string SapDescription { set; }
        bool SapDescriptionVisible { set; }

        string Company { get; set;}
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        string Company_1 { get; set; }
        string Company_2 { get; set; }
        string Supervisor { get; set;}
        string ExcavationNumber { get; set;}

        string NbTravail { get; set; }
        bool FormationCheck { get; set; }
        string Noms { get; set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        string Noms_1 { get; set; }
        string Noms_2 { get; set; }
        string Noms_3 { get; set; }

        string Surveilant { get; set; }

        List<PermitAttribute> SelectedAttributes { get; set; }

        void ShowNoWorkPermitTypeSelectedError();
        void ShowNoFunctionalLocationsSelectedError();
        void ShowStartDateMustBeBeforeEndDateError();
        void ShowEndDateMustBeOnOrAfterTodayError();
        void ShowTradeIsEmptyError();
        void ShowDescriptionIsEmptyError();
        void ShowNoRequestedByGroupSelectedError();

        List<WorkPermitMudsType> AllPermitTypes { set; }
        List<CraftOrTrade> AllCraftOrTrades { set; }
        List<Contractor> AllCompanies { set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        List<Contractor> AllCompanies_1 { set; }
        List<Contractor> AllCompanies_2 { set; }
        List<PermitAttribute> AllAttributes { set; }
        List<WorkPermitMudsGroup> AllRequestedByGroups { set; }

        List<FunctionalLocation> ShowFunctionalLocationSelector(List<FunctionalLocation> selectedFlocs);
        bool ViewEditHistoryEnabled { set; }

        bool WorkOrderNumberEnabled { set; }
        bool OperationNumberEnabled { set; }
        List<DocumentLink> DocumentLinks { get; set; }

        DateTime StartDateTime { get; set; }
        DateTime EndDateTime { get; set; }


        bool Analyse_Attribute_CheckBox { get; set; }
        bool Cadenassage_multiple_Attribute_CheckBox { get; set; }
        bool Cadenassage_simple_Attribute_CheckBox { get; set; }
        bool Procédure_Attribute_CheckBox { get; set; }
        bool Espace_clos_Attribute_CheckBox { get; set; }
        
        

    }
}
