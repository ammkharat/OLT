using System;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    internal class InitialLoadCountdownState
    {
        private readonly long countdownInMilliseconds;
        private readonly DateTime? intendedNextInvokeDateTime;

        public InitialLoadCountdownState(long countdownInMilliseconds, DateTime? intendedNextInvokeDateTime)
        {
            this.countdownInMilliseconds = countdownInMilliseconds;
            this.intendedNextInvokeDateTime = intendedNextInvokeDateTime;
        }

        public long CountdownInMilliseconds
        {
            get { return countdownInMilliseconds; }
        }

        public DateTime? IntendedNextInvokeDateTime
        {
            get { return intendedNextInvokeDateTime; }
        }
    }
}