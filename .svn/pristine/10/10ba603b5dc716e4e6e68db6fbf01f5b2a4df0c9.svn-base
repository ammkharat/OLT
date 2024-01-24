using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureCraftOrTradeView
    {
        event EventHandler Load;
        event EventHandler New;
        event EventHandler Edit;
        event EventHandler Delete;
        event DomainGridEventHandler<CraftOrTrade> EditDoubleClick;
        
        string CraftOrTradeSite { set; }
        List<CraftOrTrade> CraftOrTrades { get; set; }
        CraftOrTrade SelectedCraftOrTrade { get; set; }
        DialogResult CreateNewCraftOrTrade();
        DialogResult EditCraftOrTrade(CraftOrTrade craftOrTrade);
    }
}
