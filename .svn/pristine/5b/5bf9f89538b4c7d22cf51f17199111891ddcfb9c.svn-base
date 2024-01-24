using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class EipIssueTimerManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(EipIssueTimerManager));

        private readonly IDictionary<long, Timer> timers = new Dictionary<long, Timer>();
        private readonly IDictionary<long, DateTime> approximateFireTimes = new Dictionary<long, DateTime>();
        private readonly ReaderWriterLock locker = new ReaderWriterLock();

        public void RegisterTimer(FormEdmontonGN75BDTO eipissuedto, TimeSpan dueTime, TimerCallback callback)
        {
            if (dueTime < new TimeSpan())
            {
                throw new TimerDueTimeNegativeException();
            }

            // move ten seconds beyond the current (as a caution?)
            dueTime = dueTime.Add(TimeSpan.FromSeconds(5));

            int dueTimeInMilliseconds = ConvertToTimerDueTime(dueTime);
            Timer timer = new Timer(callback, eipissuedto, dueTimeInMilliseconds, Timeout.Infinite);
            DateTime approximateFireTime = Clock.Now.AddMilliseconds(dueTimeInMilliseconds);

            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);
                bool itemAlreadyExisted = RemoveFromTimersDictionary(eipissuedto.IdValue);
                AddToTimersDictionary(eipissuedto.IdValue, timer, approximateFireTime);

                if (itemAlreadyExisted)
                {
                    logger.WarnFormat("Eip Issue {0} already existed in Timer Dictionary. So it was removed first. This should not be happening.", eipissuedto.IdValue);
                }

                logger.DebugFormat("Adding timer to change grouping of op14 id {0} in {1} seconds", eipissuedto.IdValue, dueTime.TotalSeconds);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }


        public void Unregister(FormEdmontonGN75BDTO eipissue)
        {
            try
            {
                locker.AcquireWriterLock(-1);
                timers.Remove(eipissue.Id.Value);
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

        //ayman Sarnia eip DMND0008992
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

        private void AddToTimersDictionary(long eipissueId, Timer timer, DateTime approximateFireTime)
        {
            timers.Add(eipissueId, timer);
            approximateFireTimes.Add(eipissueId, approximateFireTime);
        }

        private void ClearTimersDictionary()
        {
            timers.Clear();
            approximateFireTimes.Clear();
        }

        private bool RemoveFromTimersDictionary(long eipissueId)
        {
            bool itemExisted = timers.Remove(eipissueId);
            approximateFireTimes.Remove(eipissueId);

            return itemExisted;
        }
    }
}