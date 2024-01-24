using System;
using System.Collections.Generic;
using System.Diagnostics;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using Com.Suncor.Olt.Remote.Services;
using log4net;
using log4net.Config;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class OpmExcursionImportJob : AbstractScheduledJob
    {
        private const string JobName = "OPM Excursion and TOE Definition synchronization";
        private readonly IEventNotificationService eventNotificationService;

        private readonly ILog logger = GenericLogManager.GetLogger<OpmExcursionImportJob>();
        private readonly IExcursionImportService service;
        private readonly Site site;
        private DateTime? lastOpmQueryTime;

        public OpmExcursionImportJob(Site siteToImportExcursions, ISchedule scheduleForJob)
            : this(
                siteToImportExcursions, scheduleForJob,
                SchedulerServiceRegistry.Instance.GetService<IExcursionImportService>())
        {
        }

        public OpmExcursionImportJob(Site siteToImportExcursions, ISchedule scheduleForJob,
            IExcursionImportService service)
            : base(scheduleForJob)
        {
            site = siteToImportExcursions;
            this.service = service;
        }

        public override string Name
        {
            get { return JobName; }
        }

        public DateTime LastOpmQueryTime
        {
            get
            {
                if (!lastOpmQueryTime.HasValue)
                {
                    lastOpmQueryTime = GetMostRecentExcursionUpdateDateTime();
                }

                return lastOpmQueryTime.Value;
            }

            set { lastOpmQueryTime = value; }
        }

        /// <summary>
        ///     Defaults to 3 days ago if no excursions have ever been imported and there is no last updated datetime
        /// </summary>
        private DateTime GetMostRecentExcursionUpdateDateTime()
        {
            var lastUpdatedDateTime = service.GetMostRecentExcursionUpdateDateTime();

            return lastUpdatedDateTime;
        }

        public override void Execute()
        {
            var stopwatch = new Stopwatch();

            try
            {
                logger.InfoFormat("Begin: OPM Excursion and TOE Definition Sync, Site: {0}", site.Name);
                stopwatch.Start();

                SynchonizeOpmExcursionsAndToeDefinitions();

                var availableOpmExcursionImportStatusDTO = new OpmExcursionImportStatusDTO(1,
                    OpmExcursionImportStatus.Available,
                    DateTime.Now);
                service.NotifyOpmExcursionImportStatus(availableOpmExcursionImportStatusDTO, ApplicationEvent.OpmExcursionImportStatusUpdate);
                service.UpdateExcursionImportStatus(availableOpmExcursionImportStatusDTO);

                service.NotifyOpmExcursionItemRefresh(site);
                
                stopwatch.Stop();
                logger.InfoFormat(
                    "Completed: OPM Excursion and TOE Definition Sync, Site: {0}. Elapsed Time(sec): {1}", site.Name,
                    stopwatch.Elapsed.TotalSeconds);
                stopwatch.Reset();
            }
            catch (Exception exception)
            {
                logger.Error(
                    string.Format("Error: Synchronizing Excursions and TOE Definitions from OPM. Site: {0}", site.Name),
                    exception);

                var unavailableOpmExcursionImportStatusDTO = new OpmExcursionImportStatusDTO(1,
                    OpmExcursionImportStatus.Unavailable,
                    null);
                service.NotifyOpmExcursionImportStatus(unavailableOpmExcursionImportStatusDTO, ApplicationEvent.OpmExcursionImportStatusUpdate);
                service.UpdateExcursionImportStatus(unavailableOpmExcursionImportStatusDTO);
            }
            finally
            {
                // Set the last query time to be the most recent LastUpdatedDateTime for all excursions 
                LastOpmQueryTime = GetMostRecentExcursionUpdateDateTime();
            }
        }

        private void SynchonizeOpmExcursionsAndToeDefinitions()
        {
            var excursionImportResult = service.ImportOpmExcursionDtosFromDate(LastOpmQueryTime);
            LogErrors(excursionImportResult);

            List<ToeDefinitionTuple> uniqueToeDefinitionTuples =
                GetUniqueToeDefinitions(excursionImportResult.ImportedExcursions);

            foreach (var toeDefinitionTuple in uniqueToeDefinitionTuples)
            {
                try
                {
                    var toeDefinitionImportResult = service.ImportOpmToeDefinition(toeDefinitionTuple.HistorianTag,
                        toeDefinitionTuple.ToeVersion);

                    LogErrors(toeDefinitionImportResult);
                }
                catch (Exception exception)
                {
                    logger.Error(
                        string.Format(
                            "Error: Synchronizing TOE Definition for Historian Tag {0} and Version {1} from OPM. Site: {2}",
                            toeDefinitionTuple.HistorianTag,
                            toeDefinitionTuple.ToeVersion,
                            site.Name),
                        exception);
                }
            }
        }

        private List<ToeDefinitionTuple> GetUniqueToeDefinitions(List<OpmExcursionDTO> importedExcursions)
        {
            List<ToeDefinitionTuple> toeDefinitionTuples = new List<ToeDefinitionTuple>();

            foreach (var importedExcursion in importedExcursions)
            {
                var toeDefinitionTuple = new ToeDefinitionTuple(importedExcursion.HistorianTag,
                    importedExcursion.ToeVersion);

                if (!toeDefinitionTuples.Contains(toeDefinitionTuple))
                {
                    toeDefinitionTuples.Add(toeDefinitionTuple);
                }
            }

            return toeDefinitionTuples;
        }

        private void LogErrors(OpmExcursionImportResult importResults)
        {
            if (importResults.Error.HasError)
            {
                logger.Error(importResults.Error.Message);
            }
            else
            {
                logger.Info(importResults.BuildDisplayText());
            }
        }

        private void LogErrors(OpmToeDefinitionImportResult importResults)
        {
            if (importResults.Error.HasError)
            {
                logger.Error(importResults.Error.Message);
            }
            else if (importResults.HasRejection && importResults.Rejection.Reason.Contains("No data returned"))
            {
                logger.Warn(importResults.BuildDisplayText());
            }
            else
            {
                logger.Info(importResults.BuildDisplayText());
            }
        }

        private class ToeDefinitionTuple : IEquatable<ToeDefinitionTuple>
        {
            private string Id { get; set; }
            public string HistorianTag { get; private set; }
            public long ToeVersion { get; private set; }

            public ToeDefinitionTuple(string historianTag, long toeVersion)
            {
                this.Id = historianTag + toeVersion;
                this.HistorianTag = historianTag;
                this.ToeVersion = toeVersion;
            }

            public bool Equals(ToeDefinitionTuple other)
            {
                if (other == null) return false;
                return (this.Id.Equals(other.Id));
            }
        }
    }
}