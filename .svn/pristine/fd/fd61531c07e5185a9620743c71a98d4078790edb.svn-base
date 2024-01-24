using System;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class DataFetcher : ClientBackgroundingFriendly<object, object>
    {
        private readonly Action carryOnIfAllDataIsDoneLoading;
        private readonly Action loadDataDelegate;
        private readonly Action<Exception> handleDataLoadError;

        public DataFetcher(Action carryOnIfAllDataIsDoneLoading, Action loadDataDelegate, Action<Exception> handleDataLoadError)
        {
            this.carryOnIfAllDataIsDoneLoading = carryOnIfAllDataIsDoneLoading;
            this.loadDataDelegate = loadDataDelegate;
            this.handleDataLoadError = handleDataLoadError;
        }

        public override object DoWork(object arg)
        {
            loadDataDelegate();
            return null;
        }

        public override bool ViewEnabled
        {
            set { }
        }

        public override void WorkSuccessfullyCompleted(object o)
        {
            carryOnIfAllDataIsDoneLoading();
        }

        public override void OnError(Exception e)
        {
            handleDataLoadError(e);
        }
    }
}