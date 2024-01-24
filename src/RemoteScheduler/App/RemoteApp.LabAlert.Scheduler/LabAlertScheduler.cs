using System.ServiceProcess;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;

namespace RemoteApp.LabAlert.Scheduler
{
    public partial class LabAlertScheduler : ServiceBase
    {
        private readonly SchedulerWrapper<LabAlertSchedulingService> schedulerWrapper;

        public LabAlertScheduler()
        {
            InitializeComponent();

            schedulerWrapper = new SchedulerWrapper<LabAlertSchedulingService>();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            StartService();
        }

        public void StartService()
        {
            schedulerWrapper.OnStart();
        }

        protected override void OnStop()
        {
            base.OnStop();
            schedulerWrapper.OnStop();
        }
    }
}