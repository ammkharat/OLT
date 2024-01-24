using System.ServiceProcess;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;

namespace RemoteApp.Target.Scheduler
{
    partial class TargetScheduler : ServiceBase
    {
        private readonly SchedulerWrapper<TargetSchedulingService> schedulerHelper;

        public TargetScheduler()
        {
            InitializeComponent();
            schedulerHelper = new SchedulerWrapper<TargetSchedulingService>();
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