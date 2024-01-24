using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class EdmontonSapAutoImportJob : AbstractScheduledJob
    {
        private const string JobName = "Import and Auto Submit Work Permits Job";
        private const int NumberOfDaysToRequest = 7;

        private readonly IFunctionalLocationService functionalLocationService;

        private readonly ILog logger;
        private readonly IPermitRequestEdmontonService permitRequestEdmontonService;
        private readonly IUserService userService;
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;


        public EdmontonSapAutoImportJob(ISchedule scheduleForJob,
            IPermitRequestEdmontonService permitRequestEdmontonService,
            IWorkPermitEdmontonService workPermitEdmontonService, IUserService userService,
            IFunctionalLocationService functionalLocationService, ILog logger)
            : base(scheduleForJob)
        {
            this.permitRequestEdmontonService = permitRequestEdmontonService;
            this.workPermitEdmontonService = workPermitEdmontonService;
            this.userService = userService;
            this.functionalLocationService = functionalLocationService;
            this.logger = logger;
        }

        public EdmontonSapAutoImportJob(ISchedule scheduleForJob)
            : this(
                scheduleForJob, SchedulerServiceRegistry.Instance.GetService<IPermitRequestEdmontonService>(),
                SchedulerServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>(),
                SchedulerServiceRegistry.Instance.GetService<IUserService>(),
                SchedulerServiceRegistry.Instance.GetService<IFunctionalLocationService>(),
                GenericLogManager.GetLogger<EdmontonSapAutoImportJob>())
        {
        }

        public EdmontonSapAutoImportJob(SapAutoImportConfiguration configuration)
            : this(configuration.Schedule)
        {
        }

        public override string Name
        {
            get { return JobName; }
        }

        public override void Execute()
        {
            var unitLevelAndHigherFlocsForSite =
                functionalLocationService.GetUnitLevelAndHigherFunctionalLocationsForSite(Site.EDMONTON_ID);
            var rootFlocSet = new RootFlocSet(unitLevelAndHigherFlocsForSite);

            var sapUser = userService.GetSAPUser();
            var today = Clock.Now.ToDate();

            AutoImportNextSevenDaysOfPermitRequests(rootFlocSet, sapUser, today);
            AutoSubmitNextDaysPermitRequests(sapUser, rootFlocSet, today);
        }

        private void AutoSubmitNextDaysPermitRequests(User sapUser, RootFlocSet rootFlocSet, Date today)
        {
            var tomorrow = today.AddDays(1);

            // now automatically submit those permit requests that can be, and have not already been.
            var tomorrowsPermitRequests = permitRequestEdmontonService.QueryByFlocUnitAndBelow(rootFlocSet,
                new DateRange(tomorrow, tomorrow));

            // Remove those that are not Complete or in 'For Review'
            tomorrowsPermitRequests.RemoveAll(
                permitRequest => !PermitRequestEdmonton.IsSubmittableStatus(permitRequest.CompletionStatus));

            var permitRequestsToSubmit = new List<PermitRequestEdmontonDTO>();

            foreach (var permitRequest in tomorrowsPermitRequests)
            {
                if (permitRequest.LastSubmittedDateTime.HasNoValue())
                {
                    // This permit request has never been Submitted.  So, we don't need to do any further checking to decide if we can create a Work Permit from it.
                    permitRequestsToSubmit.Add(permitRequest);
                }
                else
                {
                    var workPermitAlreadyExists =
                        workPermitEdmontonService.DoesPermitRequestEdmontonAssociationExist(
                            new List<PermitRequestEdmontonDTO> {permitRequest}, tomorrow);
                    if (!workPermitAlreadyExists)
                    {
                        permitRequestsToSubmit.Add(permitRequest);
                    }
                }
            }

            permitRequestEdmontonService.Submit(tomorrow, permitRequestsToSubmit, sapUser);
        }

        private void AutoImportNextSevenDaysOfPermitRequests(RootFlocSet rootFlocSet, User sapUser, Date today)
        {
            var tomorrow = today.AddDays(1);
            var daysInTheFuture = today.AddDays(NumberOfDaysToRequest);
            var dateRange = new DateRange(tomorrow, daysInTheFuture);

            var dates = new List<Date>();
            dateRange.ForEachDay(dates.Add);

            var importResults = new List<PermitRequestImportResult>();

            var newBatchId = permitRequestEdmontonService.GetNewBatchId();

            foreach (var date in dates)
            {
                var resultsImportedThusFar = importResults.GetPermitKeyDataFromPermitRequests();
                var result = permitRequestEdmontonService.Import(sapUser, date, rootFlocSet.FunctionalLocations,
                    resultsImportedThusFar, newBatchId);
                importResults.Add(result);

                if (result.HasError)
                {
                    // don't continue trying to import if we have an error. 
                    break;
                }
            }

            LogErrors(importResults);
            var hasError = importResults.Exists(r => r.HasError);

            var importRequestDataList = importResults.GetProcessedWorkOrderData();
            var rejections = importResults.GetKeysForRejectedPermitRequests();

            if (!hasError)
            {
                // If there is an error, then just don't complete the import.
                permitRequestEdmontonService.FinalizeImport(tomorrow, daysInTheFuture, importRequestDataList, rejections,
                    newBatchId, sapUser);
            }
        }

        private void LogErrors(List<PermitRequestImportResult> importResults)
        {
            foreach (var result in importResults)
            {
                if (result.Error.HasError)
                {
                    logger.Error(result.Error.Message);
                }
                else
                {
                    logger.Info(result.BuildDisplayText());
                }
            }
        }
    }
}