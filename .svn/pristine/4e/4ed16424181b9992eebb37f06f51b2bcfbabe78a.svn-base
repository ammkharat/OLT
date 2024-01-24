using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPermitRequestMontrealFormView : IAddEditBaseFormView
    {
        event Action ViewEditHistoryButtonClicked;
        event Action FunctionalLocationButtonClicked;
        event Action SubmitAndCloseButtonClicked;

        User LastModifiedBy { set; }
        DateTime LastModifiedDateTime { set; }

        WorkPermitMontrealType WorkPermitType { get; set; }
        List<FunctionalLocation> FunctionalLocations { get; set; }
        Date StartDate { get; set; }
        Date EndDate { get; set; }
        WorkPermitMontrealGroup RequestedByGroup { get; set; }
        string Trade { get; set; }
        string WorkOrderNumber { get; set; }
        string OperationNumber { get; set; }
        string Description { get; set;}
        string SapDescription { set; }
        bool SapDescriptionVisible { set; }

        string Company { get; set;}
        string Supervisor { get; set;}
        string ExcavationNumber { get; set;}

        List<PermitAttribute> SelectedAttributes { get; set; }

        void ShowNoWorkPermitTypeSelectedError();
        void ShowNoFunctionalLocationsSelectedError();
        void ShowStartDateMustBeBeforeEndDateError();
        void ShowEndDateMustBeOnOrAfterTodayError();
        void ShowTradeIsEmptyError();
        void ShowDescriptionIsEmptyError();
        void ShowNoRequestedByGroupSelectedError();

        List<WorkPermitMontrealType> AllPermitTypes { set; }
        List<CraftOrTrade> AllCraftOrTrades { set; }
        List<Contractor> AllCompanies { set; }
        List<PermitAttribute> AllAttributes { set; }
        List<WorkPermitMontrealGroup> AllRequestedByGroups { set; }

        List<FunctionalLocation> ShowFunctionalLocationSelector(List<FunctionalLocation> selectedFlocs);
        bool ViewEditHistoryEnabled { set; }

        bool WorkOrderNumberEnabled { set; }
        bool OperationNumberEnabled { set; }
        List<DocumentLink> DocumentLinks { get; set; }
    }
}
