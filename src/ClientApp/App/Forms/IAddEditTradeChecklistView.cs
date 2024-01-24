using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditTradeChecklistView : IBaseForm
    {
        event Action FormLoad;
        event Action SaveAndCloseButtonClick;
        event Action ViewHistoryButtonClick;

        string Trade { get; set; }
        List<string> TradeList { set; }
        string TradeChecklistInformation { set; }

        string Content { get; set; }
        string PlainTextContent { get; }

        User LastModifiedUser { set; }
        DateTime LastModifiedDateTime { set; }

        void ShowMustSelectATradeError();
        DialogResult ShowFormWillNeedReapprovalQuestion();
    }
}
