using System;
using System.Threading;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Domain
{
    public delegate void BlastOff(DateTime? intendedEventExecutionTime);

    public class StopWatch : IStopWatch
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<StopWatch>();

        private readonly BlastOff blastOffHandler;
        private readonly Timer timer;
        private DateTime? intendedEventExecutionTime;

        public StopWatch(BlastOff blastOffHandler)
        {
            this.blastOffHandler = blastOffHandler;
            timer = new Timer(TimerFired, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Stop()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void CountDown(long dueTime, DateTime? intendedExecutionTime)
        {
            intendedEventExecutionTime = intendedExecutionTime;
            timer.Change(dueTime, Timeout.Infinite);
        }

        private void TimerFired(object obj)
        {
            // In the event of an error when we fire the timer, log the error and eat the exception.
            // We don't want the exception trickling up and killing the scheduler service.
            try
            {
                var executionTime = intendedEventExecutionTime;
                intendedEventExecutionTime = null;
                blastOffHandler(executionTime);
            }
            catch (Exception e)
            {
                logger.Error("An error occurred while invoking a scheduled event.", e);
            }
        }
    }
}