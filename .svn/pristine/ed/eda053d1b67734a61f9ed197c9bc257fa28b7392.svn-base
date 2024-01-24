using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class ProcedureDeviationTimerManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (ProcedureDeviationTimerManager));

        private readonly IDictionary<long, DateTime> approximateFireTimes = new Dictionary<long, DateTime>();
        private readonly ReaderWriterLock locker = new ReaderWriterLock();
        private readonly IDictionary<long, Timer> timers = new Dictionary<long, Timer>();

        public void RegisterTimer(ProcedureDeviationDTO procedureDeviationDTO, TimeSpan dueTime, TimerCallback callback)
        {
            if (dueTime < new TimeSpan())
            {
                throw new TimerDueTimeNegativeException();
            }

            // move ten seconds beyond the current (as a caution?)
            dueTime = dueTime.Add(TimeSpan.FromSeconds(10));

            var dueTimeInMilliseconds = ConvertToTimerDueTime(dueTime);
            var timer = new Timer(callback, procedureDeviationDTO, dueTimeInMilliseconds, Timeout.Infinite);
            var approximateFireTime = Clock.Now.AddMilliseconds(dueTimeInMilliseconds);

            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);
                var itemAlreadyExisted = RemoveFromTimersDictionary(procedureDeviationDTO.IdValue);
                AddToTimersDictionary(procedureDeviationDTO.IdValue, timer, approximateFireTime);

                if (itemAlreadyExisted)
                {
                    logger.WarnFormat(
                        "Procedure Deviation id {0} already existed in Timer Dictionary. So it was removed first. This should not be happening.",
                        procedureDeviationDTO.IdValue);
                }

                logger.DebugFormat("Adding timer to refresh status of Procedure Deviation id {0} in {1} seconds",
                    procedureDeviationDTO.IdValue, dueTime.TotalSeconds);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void Unregister(ProcedureDeviationDTO procedureDeviationDTO)
        {
            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);

                if (timers.ContainsKey(procedureDeviationDTO.IdValue))
                {
                    var timer = timers[procedureDeviationDTO.IdValue];
                    InvalidateAndDisposeTimer(timer);
                    RemoveFromTimersDictionary(procedureDeviationDTO.IdValue);
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
            // apparently a disposed timer can still fire, so change the time to infinite
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            timer.Dispose();
        }

        private void AddToTimersDictionary(long procedureDeviationId, Timer timer, DateTime approximateFireTime)
        {
            timers.Add(procedureDeviationId, timer);
            approximateFireTimes.Add(procedureDeviationId, approximateFireTime);
        }

        private void ClearTimersDictionary()
        {
            timers.Clear();
            approximateFireTimes.Clear();
        }

        private bool RemoveFromTimersDictionary(long procedureDeviationId)
        {
            var itemExisted = timers.Remove(procedureDeviationId);
            approximateFireTimes.Remove(procedureDeviationId);

            return itemExisted;
        }
    }
}