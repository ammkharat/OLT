using System.ServiceProcess;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;

namespace RemoteApp.Log.Scheduler
{
    partial class LogScheduler : ServiceBase
    {
        private readonly SchedulerWrapper<LogSchedulingService> schedulerHelper;

        public LogScheduler()
        {
            InitializeComponent();
            schedulerHelper = new SchedulerWrapper<LogSchedulingService>();
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