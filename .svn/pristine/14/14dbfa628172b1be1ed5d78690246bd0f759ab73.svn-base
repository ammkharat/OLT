using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Infragistics.Win.UltraWinGrid;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class ActionItemTimerManager : ITimerManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ActionItemTimerManager));

        private readonly IDictionary<long, Timer> timers = new Dictionary<long, Timer>();
        private readonly ReaderWriterLock locker = new ReaderWriterLock();

        public void RegisterTimer(ActionItemDTO actionItem, TimeSpan dueTime,
                                  TimerCallback callback, UltraGridRow row)
        {
            if (dueTime < new TimeSpan())
            {
                throw new TimerDueTimeNegativeException();
            }

            //move one minute beyond the current (as a caution?)
            dueTime = dueTime.Add(TimeSpan.FromMinutes(1));
            Timer timer = new Timer(callback, row, ConvertToTimerDueTime(dueTime), Timeout.Infinite);
            try
            {
                locker.AcquireWriterLock(-1);
                bool actionItemAlreadyExisted = timers.Remove(actionItem.Id.Value);
                timers.Add(actionItem.Id.Value, timer);

                if (actionItemAlreadyExisted)
                    logger.Warn("ActionItem {0} already existed in Timer Dictionary. So it was removed first. This should not be happening.");

                if (logger.IsDebugEnabled)
                    logger.DebugFormat("Adding timer to change color of action item id {0} in {1} seconds",
                                       actionItem.Id.Value, dueTime.TotalSeconds);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void Unregister(ActionItemDTO actionItem)
        {
            try
            {
                locker.AcquireWriterLock(-1);
                timers.Remove(actionItem.Id.Value);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        private static int ConvertToTimerDueTime(TimeSpan dueTime)
        {
            double totalMillisecs = dueTime.TotalMilliseconds;
            if (totalMillisecs > int.MaxValue)
            {
                return int.MaxValue - 1;
            }
            return (int)totalMillisecs;
        }
    }
}