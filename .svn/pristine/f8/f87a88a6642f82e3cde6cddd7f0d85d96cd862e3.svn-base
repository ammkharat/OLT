using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Utilities
{
    public abstract class ClientBackgroundingFriendly<TArg, TResult> : IBackgroundingFriendly<TArg, TResult>
    {
        public abstract bool ViewEnabled { set; }
        public abstract TResult DoWork(TArg argument);
        public abstract void WorkSuccessfullyCompleted(TResult result);
        public abstract void OnError(Exception e);        
        public virtual void WorkCompletedOrCancelled() {}

        public void BeforeDoingWork()
        {
            ViewEnabled = false;
        }

        public void AfterDoingWork()
        {
            ViewEnabled = true;
        }
    }
}
