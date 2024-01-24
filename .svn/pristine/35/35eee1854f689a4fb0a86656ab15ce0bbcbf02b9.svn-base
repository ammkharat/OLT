namespace Com.Suncor.Olt.Common.Utility
{
    public class FakeBackgroundHelper<TArg, TResult> : IBackgroundHelper<TArg>
    {
        private readonly IBackgroundingFriendly<TArg, TResult> backgroundingFriendly;

        public FakeBackgroundHelper(IBackgroundingFriendly<TArg, TResult> backgroundingFriendly)
        {
            this.backgroundingFriendly = backgroundingFriendly;
        }

        public void Run(TArg argument)
        {
            backgroundingFriendly.BeforeDoingWork();
            var result = backgroundingFriendly.DoWork(argument);
            backgroundingFriendly.WorkCompletedOrCancelled();
            backgroundingFriendly.AfterDoingWork();
            backgroundingFriendly.WorkSuccessfullyCompleted(result);
        }

        public void Cancel()
        {
        }
    }
}