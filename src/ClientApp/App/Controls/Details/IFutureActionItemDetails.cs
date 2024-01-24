using System;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IFutureActionItemDetails :  IRespondableDetails
    {
        event EventHandler RefreshAll;
        bool GoToDefinitionVisible { set;}
        void HideRefreshButton();
    }
}

