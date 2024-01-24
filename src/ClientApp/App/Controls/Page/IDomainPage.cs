using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IDomainPage<TDomainObject, TDetails> : IItemSelectablePage
        where TDomainObject : DomainObject
        where TDetails : IDetails
    {
        event EventHandler DetailsChanged;
        event EventHandler ButtonsChanged;
        
        event Action<string> SearchButtonClicked;
        event Action CancelSearchButtonClicked;

        //IMainForm MainParentForm { get; } This is already in IItemSelectablePage. Hoping to leave it out here.
        
        void AddItem(TDomainObject item);
        void UpdateItem(TDomainObject item);
        void RemoveItem(TDomainObject item);
        void ShowDetails();
        void HideDetails();
        bool ButtonsEnabled { set; }

        IList<TDomainObject> Items { get; set; }
        TDomainObject FirstSelectedItem { get; }
        List<TDomainObject> SelectedItems { get; }
        bool ItemIsInGrid(TDomainObject item);
        
        TDetails Details { get; }
        DomainSummaryGrid<TDomainObject> Grid { get; }

        void CancelSuccessfulMessage();        
                        
        void DisplayErrorMessageDialog(string message, string title);
        void ShowUnableToReturnTheAmountOfDataRequestedError(string message);

        string PageTitle { set; }
        int SplitterDistance { set; }

        void ExportAll();

        bool EnableLayoutIsActiveIndicator { set; }
        string GetGridLayoutXml();        
        GridLayoutAction ShowGridLayoutConfirmationDialog();

        void ResetSearchTextBox();
    }
}