using System;
using System.Threading;
using Com.Suncor.Olt.Common.DTO;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public interface ITimerManager
    {
        void RegisterTimer(ActionItemDTO actionItem, TimeSpan dueTime,
                           TimerCallback callback, UltraGridRow row);
        void Unregister(ActionItemDTO actionItem);

    }
}