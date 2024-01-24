using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class DirectiveTimerManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DirectiveTimerManager));

        private readonly IDictionary<long, Timer> timers = new Dictionary<long, Timer>();
        private readonly IDictionary<long, DateTime> approximateFireTimes = new Dictionary<long, DateTime>();
        private readonly ReaderWriterLock locker = new ReaderWriterLock();

        public void RegisterTimer(DirectiveDTO directiveDto, TimeSpan dueTime, TimerCallback callback)
        {
            if (dueTime < new TimeSpan())
            {
                throw new TimerDueTimeNegativeException();
            }

            // move ten seconds beyond the current (as a caution?)
            dueTime = dueTime.Add(TimeSpan.FromSeconds(10));

            int dueTimeInMilliseconds = ConvertToTimerDueTime(dueTime);
            Timer timer = new Timer(callback, directiveDto, dueTimeInMilliseconds, Timeout.Infinite);
            DateTime approximateFireTime = Clock.Now.AddMilliseconds(dueTimeInMilliseconds);

            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);
                bool itemAlreadyExisted = RemoveFromTimersDictionary(directiveDto.IdValue);
                AddToTimersDictionary(directiveDto.IdValue, timer, approximateFireTime);

                if (itemAlreadyExisted)
                {
                    logger.WarnFormat("Directive {0} already existed in Timer Dictionary. So it was removed first. This should not be happening.", directiveDto.IdValue);
                }                    

                logger.DebugFormat("Adding timer to change grouping of directive id {0} in {1} seconds", directiveDto.IdValue, dueTime.TotalSeconds);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void Unregister(DirectiveDTO directiveDto)
        {
            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);

                if (timers.ContainsKey(directiveDto.IdValue))
                {
                    Timer timer = timers[directiveDto.IdValue];
                    InvalidateAndDisposeTimer(timer);
                    RemoveFromTimersDictionary(directiveDto.IdValue);
                }
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

        public void Clear()
        {
            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);

                foreach (Timer timer in timers.Values)
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
            timer.Change(Timeout.Infinite, Timeout.Infinite);  // apparently a disposed timer can still fire, so change the time to infinite
            timer.Dispose();
        }

        private void AddToTimersDictionary(long directiveId, Timer timer, DateTime approximateFireTime)
        {
            timers.Add(directiveId, timer);
            approximateFireTimes.Add(directiveId, approximateFireTime);
        }

        private void ClearTimersDictionary()
        {
            timers.Clear();
            approximateFireTimes.Clear();
        }

        private bool RemoveFromTimersDictionary(long directiveId)
        {
            bool itemExisted = timers.Remove(directiveId);
            approximateFireTimes.Remove(directiveId);

            return itemExisted;
        }
    }
}