using System;

namespace Com.Suncor.Olt.Common.Domain
{
    public interface IStopWatch
    {
        void Stop();
        void CountDown(long dueTimeInMilliSeconds, DateTime? intendedEventExecutionTime);
    }
}