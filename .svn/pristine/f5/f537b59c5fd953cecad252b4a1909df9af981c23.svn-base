using System.ServiceProcess;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;

namespace Com.Suncor.Olt.Remote.Scheduling.Services
{
    internal partial class ActionItemScheduler : ServiceBase
    {
        private readonly SchedulerWrapper<ActionItemSchedulingService> schedulerHelper;

        public ActionItemScheduler()
        {
            InitializeComponent();
            schedulerHelper = new SchedulerWrapper<ActionItemSchedulingService>();
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