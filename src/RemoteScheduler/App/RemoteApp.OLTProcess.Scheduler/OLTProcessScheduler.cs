using System.ServiceProcess;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;

namespace RemoteApp.OLTProcess.Scheduler
{
    internal partial class OLTProcessScheduler : ServiceBase
    {
        private readonly SchedulerWrapper<OltProcessSchedulingService> schedulerHelper;

        public OLTProcessScheduler()
        {
            InitializeComponent();
            schedulerHelper = new SchedulerWrapper<OltProcessSchedulingService>();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            StartService();

        }

        public void StartService()
        {
            schedulerHelper.OnStart();
        }

        protected override void OnStop()
        {
            base.OnStop();
            schedulerHelper.OnStop();
        }
    }
}