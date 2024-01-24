using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public interface IMultiGridContext
    {
 
        IDomainSummaryGrid Grid { get; }
        IDetails Details { get; }
        AbstractMultiGridPage Page { get; }
        List<DomainObject> SelectedItems { get; }
        bool IsItemSelected { get; }
        IMultiGridContextSelection Key { get; }
        IList<DomainObject> Items { get; set; }
        bool IsDataLoaded { get; set; }
        string MostRecentSearchTerm { get; }
        long? SelectedDomainObjectId { get; set; }
        IList<DomainObject> GetData(DtoFilters args);
        void HookToServiceEvents(IRemoteEventRepeater repeater);
        void UnHookToServiceEvents(IRemoteEventRepeater repeater);
        void SubscribeToEvents();
        void UnSubscribeFromEvents();
        void ApplySearchTerm(string searchTerm, Action actionOnCancel);
        void ControlDetailButtons();
        void ControlShowingOfDetailsPane();
        void SetPageTitle();
        void MakeAllDetailsButtonsInvisible();

        void RefreshData(bool loadInForeground);
        void RefreshData(IList<DomainObject> dtos);
        void ResetSearchBox();
        DomainObject QueryById(long id);

        //ayman generic forms
        DomainObject QueryByIdAndSiteId(long id,long siteid);

        Range<Date> GetDefaultDateRange();
        FormStatus GetDefaultFormStatus();
        void Edit(DomainObject item);

        bool DataNeedsRefresh { get; set; }
    }
}