using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAnalyticsExcelExportView : IBaseForm
    {
        event Action RunButtonClicked;
        event Action FormLoad;
        List<string> EventNameValues { set; }
        List<string> SelectedEventNames { get; }
        DateTime FromDateTime { get; }
        DateTime ToDateTime { get; }
        void SetErrorForFromDateAfterToDate();
        void SetErrorForNoEventNamesSelected();
    }
}
