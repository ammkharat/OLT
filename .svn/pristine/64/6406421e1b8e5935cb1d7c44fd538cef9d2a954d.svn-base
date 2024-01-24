using System;
using System.ComponentModel;

namespace Com.Suncor.Olt.Common.Utility
{
    public interface IBackgroundingFriendly<TArg, TResult>
    {
        TResult DoWork(TArg argument);
        void BeforeDoingWork();
        void AfterDoingWork();
        void WorkSuccessfullyCompleted(TResult result);
        void OnError(Exception e);
        void WorkCompletedOrCancelled();
    }

    public interface IBackgroundHelper<TArg>
    {
        void Run(TArg argument);
        void Cancel();
    }

    public class BackgroundHelper<TArg, TResult> : IBackgroundHelper<TArg>
    {
        private readonly BackgroundWorker backgroundWorker;
        private readonly IBackgroundingFriendly<TArg, TResult> backgroundingFriendly;

        public BackgroundHelper(BackgroundWorker backgroundWorker,
            IBackgroundingFriendly<TArg, TResult> backgroundingFriendly)
        {
            this.backgroundingFriendly = backgroundingFriendly;
            this.backgroundWorker = backgroundWorker;

            backgroundWorker.DoWork += DoBackgroundWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorkCompleted;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        public void Run(TArg argument)
        {
            backgroundingFriendly.BeforeDoingWork();
            backgroundWorker.RunWorkerAsync(argument);
        }

        public void Cancel()
        {
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void DoBackgroundWork(object sender, DoWorkEventArgs e)
        {
            e.Result = backgroundingFriendly.DoWork((TArg) e.Argument);

            var bgWorker = (BackgroundWorker) sender;
            if (bgWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void BackgroundWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundingFriendly.WorkCompletedOrCancelled();

            if (e.Cancelled)
            {
                return;
            }

            backgroundingFriendly.AfterDoingWork();

            if (e.Error != null)
            {
                backgroundingFriendly.OnError(e.Error);
                return;
            }

            backgroundingFriendly.WorkSuccessfullyCompleted((TResult) e.Result);
        }
    }
}