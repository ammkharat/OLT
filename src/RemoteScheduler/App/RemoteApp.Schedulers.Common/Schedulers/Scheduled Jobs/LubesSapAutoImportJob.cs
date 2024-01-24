using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class LubesSapAutoImportJob : AbstractScheduledJob
    {
        private const int NumberOfDaysToRequest = 14;

        private readonly IFunctionalLocationInfoService functionalLocationInfoService;
        private readonly ILubesPermitRequestMultiDayImportService importService;
        private readonly ILog logger;
        private readonly IPermitRequestLubesService permitRequestLubesService;
        private readonly ISiteService siteService;
        private readonly IUserService userService;
        private readonly IWorkPermitLubesService workPermitLubesService;

        public LubesSapAutoImportJob(
            SapAutoImportConfiguration scheduleForJob,
            IPermitRequestLubesService permitRequestLubesService,
            IWorkPermitLubesService workPermitLubesService,
            IUserService userService,
            IFunctionalLocationInfoService functionalLocationInfoService,
            ILubesPermitRequestMultiDayImportService importService,
            ISiteService siteService,
            ILog logger) : base(scheduleForJob.Schedule)
        {
            this.permitRequestLubesService = permitRequestLubesService;
            this.workPermitLubesService = workPermitLubesService;
            this.userService = userService;
            this.functionalLocationInfoService = functionalLocationInfoService;
            this.importService = importService;
            this.siteService = siteService;
            this.logger = logger;
        }

        public LubesSapAutoImportJob(SapAutoImportConfiguration configuration)
            : this(configuration,
                SchedulerServiceRegistry.Instance.GetService<IPermitRequestLubesService>(),
                SchedulerServiceRegistry.Instance.GetService<IWorkPermitLubesService>(),
                SchedulerServiceRegistry.Instance.GetService<IUserService>(),
                SchedulerServiceRegistry.Instance.GetService<IFunctionalLocationInfoService>(),
                SchedulerServiceRegistry.Instance.GetService<ILubesPermitRequestMultiDayImportService>(),
                SchedulerServiceRegistry.Instance.GetService<ISiteService>(),
                GenericLogManager.GetLogger<LubesSapAutoImportJob>())
        {
        }

        public override string Name
        {
            get { return "Import and Auto-submit Lubes Permit Requests."; }
        }

        public override void Execute()
        {
            var sapUser = userService.GetSAPUser();

            var today = Clock.Now.ToDate();
            var startDate = today.AddDays(1);
            var daysInTheFuture = startDate.AddDays(NumberOfDaysToRequest - 1);
            var dateRange = new DateRange(startDate, daysInTheFuture);

            DoImport(dateRange, sapUser);
            DoSubmit(today, sapUser);
        }

        private void DoImport(DateRange dateRange, User importUser)
        {
            var dates = new List<Date>();
            dateRange.ForEachDay(dates.Add);

            var batchId = importService.GetNewBatchId();

            var importResults = new List<WorkOrderDataImportResult>();

            var site = siteService.QueryById(Site.LUBES_ID);

            foreach (var importDate in dates)
            {
                var result = importService.Import(importUser, importDate, batchId, site);
                importResults.Add(result);

                // if we get an Error for any dates, then let's stop processing, and throw up an error with no inserts/updates/deletes for any records.
                if (result.HasError)
                    break;
            }
            var thereWasAnErrorDuringImport = importResults.Exists(r => r.HasError);

            var finalizeResult = thereWasAnErrorDuringImport
                ? new PermitRequestPostFinalizeResult(new List<NotifiedEvent>(0),
                    new List<PermitRequestImportRejection>(0), 0)
                : importService.FinalizeImport(dateRange.LowerBound, dateRange.UpperBound, batchId, importUser, site);

            if (thereWasAnErrorDuringImport || finalizeResult.RejectList.Count > 0)
            {
                var errorText = WorkOrderDataImportResult.BuildDisplayText(finalizeResult, importResults);
                logger.Warn(errorText);
            }
        }

        private void DoSubmit(Date today, User submissionUser)
        {
            var tomorrow = today.AddDays(1);
            var divisions = functionalLocationInfoService.QueryDivisionsBySiteId(Site.LUBES_ID);

            // Lubes only has one division, so let's just count on that.
            IFlocSet flocSet = new ExactFlocSet(divisions[0].Floc);
            var permitRequestDtos = permitRequestLubesService.QueryByDateRangeAndFlocs(flocSet,
                new DateRange(tomorrow, tomorrow));

            // Remove those that are not submittable
            permitRequestDtos.RemoveAll(
                permitRequest => !PermitRequestLubes.IsSubmittableStatus(permitRequest.CompletionStatus));

            var permitRequestsToSubmit = new List<PermitRequestLubesDTO>();

            foreach (var permitRequest in permitRequestDtos)
            {
                if (permitRequest.LastSubmittedDateTime.HasNoValue())
                {
                    // This permit request has never been Submitted.  So, we don't need to do any further checking to decide if we can create a Work Permit from it.
                    permitRequestsToSubmit.Add(permitRequest);
                }
                else
                {
                    var workPermitAlreadyExists =
                        workPermitLubesService.DoesPermitRequestLubesAssociationExist(
                            new List<PermitRequestLubesDTO> {permitRequest}, tomorrow);
                    if (!workPermitAlreadyExists)
                    {
                        permitRequestsToSubmit.Add(permitRequest);
                    }
                }
            }

            permitRequestLubesService.Submit(tomorrow, permitRequestsToSubmit, submissionUser);
        }
    }
}