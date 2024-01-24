using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class ExcursionEventTimerManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (ExcursionEventTimerManager));

        private readonly IDictionary<long, DateTime> approximateFireTimes = new Dictionary<long, DateTime>();
        private readonly ReaderWriterLock locker = new ReaderWriterLock();
        private readonly IDictionary<long, Timer> timers = new Dictionary<long, Timer>();

        public void RegisterTimer(ExcursionEventPriorityPageDTO excursionEventPriorityPageDto, TimeSpan dueTime,
            TimerCallback callback)
        {
            if (dueTime < new TimeSpan())
            {
                throw new TimerDueTimeNegativeException();
            }

            // move ten seconds beyond the current (as a caution?)
            dueTime = dueTime.Add(TimeSpan.FromSeconds(10));

            var dueTimeInMilliseconds = ConvertToTimerDueTime(dueTime);
            var timer = new Timer(callback, excursionEventPriorityPageDto, dueTimeInMilliseconds, Timeout.Infinite);
            var approximateFireTime = Clock.Now.AddMilliseconds(dueTimeInMilliseconds);

            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);
                var itemAlreadyExisted = RemoveFromTimersDictionary(excursionEventPriorityPageDto.IdValue);
                AddToTimersDictionary(excursionEventPriorityPageDto.IdValue, timer, approximateFireTime);

                if (itemAlreadyExisted)
                {
                    logger.WarnFormat(
                        "OP!$ {0} already existed in Timer Dictionary. So it was removed first. This should not be happening.",
                        excursionEventPriorityPageDto.IdValue);
                }

                logger.DebugFormat("Adding timer to change grouping of Lubes CSD id {0} in {1} seconds",
                    excursionEventPriorityPageDto.IdValue, dueTime.TotalSeconds);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void Unregister(ExcursionEventPriorityPageDTO excursionEventPriorityPageDto)
        {
            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);

                if (timers.ContainsKey(excursionEventPriorityPageDto.IdValue))
                {
                    var timer = timers[excursionEventPriorityPageDto.IdValue];
                    InvalidateAndDisposeTimer(timer);
                    RemoveFromTimersDictionary(excursionEventPriorityPageDto.IdValue);
                }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        private static int ConvertToTimerDueTime(TimeSpan dueTime)
        {
            var totalMillisecs = dueTime.TotalMilliseconds;
            if (totalMillisecs > int.MaxValue)
            {
                return int.MaxValue - 1;
            }
            return (int) totalMillisecs;
        }

        public void Clear()
        {
            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);

                foreach (var timer in timers.Values)
                {
                    InvalidateAndDisposeTimer(timer);
                }

                ClearTimersDictionary();
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        private void InvalidateAndDisposeTimer(Timer timer)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
                // apparently a disposed timer can still fire, so change the time to infinite
            timer.Dispose();
        }

        private void AddToTimersDictionary(long excursionEventPriorityPageDtoId, Timer timer, DateTime approximateFireTime)
        {
            timers.Add(excursionEventPriorityPageDtoId, timer);
            approximateFireTimes.Add(excursionEventPriorityPageDtoId, approximateFireTime);
        }

        private void ClearTimersDictionary()
        {
            timers.Clear();
            approximateFireTimes.Clear();
        }

        private bool RemoveFromTimersDictionary(long excursionEventPriorityPageDtoId)
        {
            var itemExisted = timers.Remove(excursionEventPriorityPageDtoId);
            approximateFireTimes.Remove(excursionEventPriorityPageDtoId);

            return itemExisted;
        }
    }
}