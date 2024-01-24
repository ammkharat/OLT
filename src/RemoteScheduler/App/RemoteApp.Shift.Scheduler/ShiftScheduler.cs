using System.ServiceProcess;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;

namespace RemoteApp.Shift.Scheduler
{
    partial class ShiftScheduler : ServiceBase
    {
        private readonly SchedulerWrapper<ShiftSchedulingService> schedulerHelper;

        public ShiftScheduler()
        {
            InitializeComponent();
            schedulerHelper = new SchedulerWrapper<ShiftSchedulingService>();
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