using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class RequireManagerOperationsApprovalForCsdsOutOfServiceMoreThan3DaysJob : AbstractScheduledJob
    {
        private const string JobName = "Require Additional Manager Operations Approval For Montreal CSDs Job";

        private static readonly ILog logger =
            GenericLogManager.GetLogger<RequireAdditionalDirectorApprovalForLubeCsdsJob>();

        private readonly IFormEdmontonService formService;
        private readonly ISiteService siteService;
        private readonly ITimeService timeService;
        private readonly IUserService userService;

        public RequireManagerOperationsApprovalForCsdsOutOfServiceMoreThan3DaysJob(ISchedule scheduleForJob,
            IFormEdmontonService formService, ITimeService timeService, ISiteService siteService,
            IUserService userService)
            : base(scheduleForJob)
        {
            this.formService = formService;
            this.timeService = timeService;
            this.siteService = siteService;
            this.userService = userService;
        }

        public RequireManagerOperationsApprovalForCsdsOutOfServiceMoreThan3DaysJob(ISchedule scheduleForJob)
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
            var montrealSite = siteService.QueryById(Site.MONTREAL_ID);
            var currentTimeAtSite = timeService.GetTime(montrealSite.TimeZone);
            var systemUser = userService.GetRemoteAppUser();

            var forms = formService.QueryAllMontrealCsdsThatAreApprovedAndAreMoreThan3DaysOutOfService(currentTimeAtSite);
            foreach (var form in forms)
            {
                foreach (var approval in form.Approvals)
                {
                    if (!approval.Enabled && approval.ShouldBeEnabled(form, currentTimeAtSite))
                    {
                        approval.Enabled = true;
                        form.FormStatus = FormStatus.Draft;
                        form.ApprovedDateTime = null;
                    }
                }

                // we queried only approved forms, so if it's now a draft form then we know we are the ones who changed it and so it needs saving
                if (FormStatus.Draft.Equals(form.FormStatus))
                {
                    form.LastModifiedBy = systemUser;
                    formService.UpdateMontrealCsd(form);
                }
            }
        }
    }
}