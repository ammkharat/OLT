using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class DocumentSuggestionTimerManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (DocumentSuggestionTimerManager));

        private readonly IDictionary<long, DateTime> approximateFireTimes = new Dictionary<long, DateTime>();
        private readonly ReaderWriterLock locker = new ReaderWriterLock();
        private readonly IDictionary<long, Timer> timers = new Dictionary<long, Timer>();

        public void RegisterTimer(DocumentSuggestionDTO documentSuggestionDTO, TimeSpan dueTime, TimerCallback callback)
        {
            if (dueTime < new TimeSpan())
            {
                throw new TimerDueTimeNegativeException();
            }

            // move ten seconds beyond the current (as a caution?)
            dueTime = dueTime.Add(TimeSpan.FromSeconds(10));

            var dueTimeInMilliseconds = ConvertToTimerDueTime(dueTime);
            var timer = new Timer(callback, documentSuggestionDTO, dueTimeInMilliseconds, Timeout.Infinite);
            var approximateFireTime = Clock.Now.AddMilliseconds(dueTimeInMilliseconds);

            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);
                var itemAlreadyExisted = RemoveFromTimersDictionary(documentSuggestionDTO.IdValue);
                AddToTimersDictionary(documentSuggestionDTO.IdValue, timer, approximateFireTime);

                if (itemAlreadyExisted)
                {
                    logger.WarnFormat(
                        "Document Suggestion id {0} already existed in Timer Dictionary. So it was removed first. This should not be happening.",
                        documentSuggestionDTO.IdValue);
                }

                logger.DebugFormat("Adding timer to refresh status of Document Suggestion id {0} in {1} seconds",
                    documentSuggestionDTO.IdValue, dueTime.TotalSeconds);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        public void Unregister(DocumentSuggestionDTO documentSuggestionDTO)
        {
            try
            {
                locker.AcquireWriterLock(Timeout.Infinite);

                if (timers.ContainsKey(documentSuggestionDTO.IdValue))
                {
                    var timer = timers[documentSuggestionDTO.IdValue];
                    InvalidateAndDisposeTimer(timer);
                    RemoveFromTimersDictionary(documentSuggestionDTO.IdValue);
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

        private void AddToTimersDictionary(long documentSuggestionId, Timer timer, DateTime approximateFireTime)
        {
            timers.Add(documentSuggestionId, timer);
            approximateFireTimes.Add(documentSuggestionId, approximateFireTime);
        }

        private void ClearTimersDictionary()
        {
            timers.Clear();
            approximateFireTimes.Clear();
        }

        private bool RemoveFromTimersDictionary(long documentSuggestionId)
        {
            var itemExisted = timers.Remove(documentSuggestionId);
            approximateFireTimes.Remove(documentSuggestionId);

            return itemExisted;
        }
    }
}