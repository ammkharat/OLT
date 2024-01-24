using System.ServiceProcess;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;

namespace RemoteApp.Restriction.Scheduler
{
    public partial class RestrictionScheduler : ServiceBase
    {
        private readonly SchedulerWrapper<RestrictionSchedulingService> schedulerHelper;

        public RestrictionScheduler()
        {
            InitializeComponent();
            schedulerHelper = new SchedulerWrapper<RestrictionSchedulingService>();
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