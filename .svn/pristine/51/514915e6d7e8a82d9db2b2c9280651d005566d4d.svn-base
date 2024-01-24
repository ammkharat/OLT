using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class RequireAdditionalApproversOnOutOfServiceFormOP14sJob : AbstractScheduledJob
    {
        private const string JobName = "Require Additional Approvers On Out Of Service Form OP-14s Job";

        private readonly IFormEdmontonService formService;
        private readonly ISiteService siteService;
        private readonly ITimeService timeService;
        private readonly IUserService userService;

        public RequireAdditionalApproversOnOutOfServiceFormOP14sJob(ISchedule scheduleForJob,
            IFormEdmontonService formService, ITimeService timeService, ISiteService siteService,
            IUserService userService)
            : base(scheduleForJob)
        {
            this.formService = formService;
            this.timeService = timeService;
            this.siteService = siteService;
            this.userService = userService;
        }

        public RequireAdditionalApproversOnOutOfServiceFormOP14sJob(ISchedule scheduleForJob)
            : this(
                scheduleForJob, SchedulerServiceRegistry.Instance.GetService<IFormEdmontonService>(),
                SchedulerServiceRegistry.Instance.GetService<ITimeService>(),
                SchedulerServiceRegistry.Instance.GetService<ISiteService>(),
                SchedulerServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        public override string Name
        {
            get { return JobName; }
        }

        public override void Execute()
        {
            var edmontonSite = siteService.QueryById(Site.EDMONTON_ID);
            var currentTimeAtSite = timeService.GetTime(edmontonSite.TimeZone);
            var systemUser = userService.GetRemoteAppUser();

            var forms = formService.QueryAllFormOP14sThatAreApprovedAndAreMoreThan10DaysOutOfService(currentTimeAtSite);

            foreach (var form in forms)
            {
                foreach (var approval in form.Approvals)
                {
                    if (!approval.Enabled && approval.ShouldBeEnabled(form, currentTimeAtSite))
                    {
                        approval.Enabled = true;
                        form.FormStatus = FormStatus.Draft;
                    }
                }

                // we queried only approved forms, so if it's now a draft form then we know we are the ones who changed it and so it needs saving
                if (FormStatus.Draft.Equals(form.FormStatus))
                {
                    form.LastModifiedBy = systemUser;
                    formService.UpdateOP14(form);
                }
            }
        }
    }
}