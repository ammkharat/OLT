using System.ComponentModel;
using System.Globalization;
using System.Threading;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class ClientBackgroundWorker : BackgroundWorker
    {
        private readonly CultureInfo cultureInfo;

        public ClientBackgroundWorker()
        {
            cultureInfo = Thread.CurrentThread.CurrentCulture;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            Culture.SetSpecificCultureOnThread(cultureInfo);
            base.OnDoWork(e);
        }
    }
}