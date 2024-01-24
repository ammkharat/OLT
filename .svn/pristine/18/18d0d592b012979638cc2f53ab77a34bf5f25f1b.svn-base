using System;
using System.Collections.Generic;
using System.Diagnostics;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class TagInformationJob : AbstractScheduledJob
    {
        private const string JobName = "TagInformationJob";
        private readonly ILog logger;
        private readonly IPlantHistorianService plantHistorianService;

        private readonly Site site;
        private readonly ITagService tagService;

        public TagInformationJob(Site siteToRetrieveTags, ISchedule schedule)
            : this(
                siteToRetrieveTags, schedule, SchedulerServiceRegistry.Instance.GetService<ITagService>(),
                SchedulerServiceRegistry.Instance.GetService<IPlantHistorianService>(),
                GenericLogManager.GetLogger<TagInformationJob>())
        {
        }

        public TagInformationJob(Site siteToRetrieveTags, ISchedule schedule, ITagService tagService,
            IPlantHistorianService plantHistorianService, ILog logger)
            : base(schedule)
        {
            this.tagService = tagService;
            this.plantHistorianService = plantHistorianService;
            this.logger = logger;

            site = siteToRetrieveTags;
        }

        public override string Name
        {
            get { return JobName; }
        }

        public override void Execute()
        {
            try
            {
                var stopwatch = new Stopwatch();

                try
                {
                    if (plantHistorianService.HasPlantHistorian(site))
                    {
                        logger.Info("Begin: Pulling tag info from plant historian, Site:" + site.Name);
                        stopwatch.Start();
                        UpdatePlantHistorianTagInfoListByAlphanumericCharacter();
                        stopwatch.Stop();
                        logger.InfoFormat(
                            "Completed: Pulling tag info from plant historian, Site: {0}. Elapsed Time(sec): {1}",
                            site.Name, stopwatch.Elapsed.TotalSeconds);
                        stopwatch.Reset();
                    }
                    else
                    {
                        logger.Info(String.Format("Site: {0}-{1} does not have a plant historian. Skipping.", site.Id,
                            site.Name));
                    }
                }
                catch (TagSchedulerException tagException)
                {
                    logger.Error("Error: TagSchedulerException, "
                                 + tagException.Message + ", "
                                 + tagException.InnerException);
                }
                catch (Exception exception)
                {
                    logger.Error("Error: pulling tag info from plant historian. Site :" + site.Name, exception);
                }
            }
            catch (Exception e)
            {
                logger.Error("An error occured when tag info polling was triggered", e);
            }
        }

        private void UpdatePlantHistorianTagInfoListByAlphanumericCharacter()
        {
            var prefixes = DeterminePrefixesForSite(Constants.ALPHANUMERIC_CHARACTERS);
            if (site.Id == 7)
            {
                prefixes = DeterminePrefixesForSite(Constants.EXPANDED_ALPHANUMERIC_CHARACTERS);
            }
            
            foreach (var p in prefixes)
            {
                logger.Info(String.Format("Working on Site: {0}-{1} Prefix: {2}", site.Id, site.Name, p));
                var phdTags = plantHistorianService.GetTagInfoList(site, p);
                tagService.UpdatePlantHistorianTagInfoList(site, p, phdTags);
            }
        }

        public List<string> DeterminePrefixesForSite(List<string> alphaNumericCharacters)
        {
            var prefixes = new List<string>(alphaNumericCharacters);
            return prefixes;
        }
    }
}