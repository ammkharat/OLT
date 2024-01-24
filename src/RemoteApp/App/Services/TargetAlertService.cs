using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;
using log4net.Core;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TargetAlertService : ITargetAlertService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<TargetAlertService>();
        private readonly ITargetAlertDao targetAlertDao;
        private readonly ITargetAlertDTODao targetAlertDtoDao;
        private readonly ITargetDefinitionDao targetDefinitionDao;
        private readonly ITargetDefinitionStateDao targetDefinitionStateDao;
        private readonly ITargetAlertResponseDao responseDao;
        private readonly ICommentDao commentDao;
        private readonly ITimeDao timeDao;        
        private readonly IUserService userService;        
        private readonly ILogService logService;
        private readonly IPlantHistorianService plantHistorianService;
        private readonly IEditHistoryService editHistoryService;

        public TargetAlertService(): this(
            new LogService(),
            new PlantHistorianService(),
            new UserService(),
            new EditHistoryService())
        {
        }

        public TargetAlertService(ILogService logService, IPlantHistorianService plantHistorianService, IUserService userService, IEditHistoryService editHistoryService)
        {
            targetAlertDao = DaoRegistry.GetDao<ITargetAlertDao>();
            targetAlertDtoDao = DaoRegistry.GetDao<ITargetAlertDTODao>();
            targetDefinitionDao = DaoRegistry.GetDao<ITargetDefinitionDao>();
            targetDefinitionStateDao = DaoRegistry.GetDao<ITargetDefinitionStateDao>();
            responseDao = DaoRegistry.GetDao<ITargetAlertResponseDao>();
            commentDao = DaoRegistry.GetDao<ICommentDao>();
            timeDao = DaoRegistry.GetDao<ITimeDao>();
            this.userService = userService;
            this.logService = logService;
            this.plantHistorianService = plantHistorianService;
            this.editHistoryService = editHistoryService;
        }

        public bool IsTargetAndAllAssociatedTargetsExceedingBoundary(TargetDefinition parentTargetDefinition, TargetDefinitionState parentTargetDefinitionState)
        {
            return parentTargetDefinitionState.IsExceedingBoundary && HasAllChildrenExceedingBoundary(parentTargetDefinition);
        }

        /// <summary>
        /// Checks that all Associated Targets are also exceeding their boundaries.
        /// </summary>
        /// <param name="parentTargetDefinition"></param>
        /// <returns></returns>
        // TODO (Performance) Just get a count of all children with ExceedingBoundary = false, before iterating through to get children and their state to pass to recursive method.
        private bool HasAllChildrenExceedingBoundary(TargetDefinition parentTargetDefinition)
        {
            foreach(TargetDefinitionDTO childTargetDefinitionDto in parentTargetDefinition.AssociatedTargetDTOs)
            {
                TargetDefinition childTargetDefinition = targetDefinitionDao.QueryById(childTargetDefinitionDto.IdValue);
                TargetDefinitionState childTargetDefinitionState =
                    targetDefinitionStateDao.QueryById(childTargetDefinitionDto.IdValue);
                if (!IsTargetAndAllAssociatedTargetsExceedingBoundary(childTargetDefinition, childTargetDefinitionState))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Uses PHD "batching" to read multiple tags at once for a list of Target Definitions with 
        /// </summary>
        /// <param name="targetDefinitions"></param>
        public void EvaluateTargets(List<TargetDefinition> targetDefinitions)
        {
            if (targetDefinitions == null)
                return;

            logger.DebugFormat("Starting to evalulate {0} target Definitions", targetDefinitions.Count);

            targetDefinitions.RemoveAll(td => !td.IsInStateForGeneratingAlerts);

            if (targetDefinitions.Count == 0)
                return;

            // get one schedule, since they are all the same to figure out evaluation times.
            ISchedule schedule = targetDefinitions[0].Schedule;

            DateTime currentTimeAtSite = timeDao.GetTime(schedule.Site.TimeZone);

            List<TagReadRequest> requests = new List<TagReadRequest>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            targetDefinitions.ForEach(td => requests.AddRange(td.CreateRequestsForTarget(currentTimeAtSite)));
            stopwatch.Stop();
            logger.DebugFormat("Creating {0} tag requests for {1} Target Definitions took {2} seconds", requests.Count, targetDefinitions.Count, stopwatch.Elapsed.TotalSeconds);

            stopwatch.Reset();
            stopwatch.Start();
            
            // Now that we have all the requests that need to be made, we need to call by Requested Time
            IEnumerable<IGrouping<DateTime, string>> groupings = requests.GroupBy(req => req.EvaluationTime, req => req.TagName);
            stopwatch.Stop();
            logger.DebugFormat("Grouping {0} requests by Evaluation Time took {1} seconds", requests.Count, stopwatch.Elapsed.TotalSeconds);

            Values values = new Values();

            foreach (IGrouping<DateTime, string> grouping in groupings)
            {
                // want to get a unique list of tag names because many will be duplicated and there is no reason to get them multiple times.
                stopwatch.Reset();
                stopwatch.Start();
                List<string> tagNames = grouping.Unique().ToList();
                stopwatch.Stop();
                logger.DebugFormat("Creating a unique list of Tags for group took {0} seconds", stopwatch.Elapsed.TotalSeconds);

                stopwatch.Reset();
                stopwatch.Start();
                List<TagValue> tagValues = plantHistorianService.ReadTagValues(PlantHistorianOrigin.TargetAlertService_Evaluation, tagNames, schedule.Site, grouping.Key);
                stopwatch.Stop();
                logger.DebugFormat("Reading {0} tags at {1} for Site {2} took {3} seconds", tagNames.Count, grouping.Key, schedule.Site.Name, stopwatch.Elapsed.TotalSeconds);

                foreach (TagValue tagValue in tagValues)
                {
                    values.Add(tagValue);
                }
            }
            stopwatch.Reset();
            stopwatch.Start();
            foreach (TargetDefinition targetDefinition in targetDefinitions)
            {
                ILog log = new TargetDefinitionLogDecorator(logger, targetDefinition);

                // first populate the Min/Max/GapUnit Value/Target Value from what was read in PHD.
                ReadWriteTagConfiguration maxValue = targetDefinition.ReadWriteTagsConfiguration.MaxValue;
                if (maxValue.IsReadDirection())
                {
                    targetDefinition.MaxValue = values.GetNewestValue(maxValue.Tag.Name);
                }
                ReadWriteTagConfiguration minvalue = targetDefinition.ReadWriteTagsConfiguration.MinValue;
                if (minvalue.IsReadDirection())
                {
                    targetDefinition.MinValue = values.GetNewestValue(minvalue.Tag.Name);
                }
                ReadWriteTagConfiguration gapUnitValue = targetDefinition.ReadWriteTagsConfiguration.GapUnitValue;
                if (gapUnitValue.IsReadDirection())
                {
                    targetDefinition.GapUnitValue = values.GetNewestValue(gapUnitValue.Tag.Name);
                }
                ReadWriteTagConfiguration targetValue = targetDefinition.ReadWriteTagsConfiguration.TargetValue;
                if (targetValue.IsReadDirection())
                {
                    decimal? specifiedValue = values.GetNewestValue(targetValue.Tag.Name);
                    targetDefinition.TargetValue = specifiedValue.HasValue ? TargetValue.CreateSpecifiedTarget(specifiedValue.Value) : TargetValue.CreateEmptyTarget();
                }
                
                // Get the Values that were read from PHD for the Tag Associated to the current Target Definition.
                string tagAssociatedToTargetDefinition = targetDefinition.TagInfo.Name;
                List<decimal?> valuesForTargetDefinition = values.GetAllValues(tagAssociatedToTargetDefinition);

                if (valuesForTargetDefinition.TrueForAll(value => value.HasNoValue()))
                {
                    HandleInvalidTagAccess(targetDefinition, tagAssociatedToTargetDefinition, currentTimeAtSite);
                    log.Warn(string.Format("Unable to read tag: {0}.", tagAssociatedToTargetDefinition));
                    continue;
                }

                EvaluateTargetDefinitionBasedOnTagValues(targetDefinition, valuesForTargetDefinition, log, currentTimeAtSite);
            }
            stopwatch.Stop();
            logger.DebugFormat("Took {0} seconds to evaluate {1} Target Definitions, create Target Alerts and .", stopwatch.Elapsed.TotalSeconds, targetDefinitions.Count);
        }

        public void EvaluateTarget(TargetDefinition targetDefinition)
        {
            ILog log = new TargetDefinitionLogDecorator(logger, targetDefinition);

            // Guard against inactive definitions, including targets with invalid tags.
            if (!targetDefinition.IsInStateForGeneratingAlerts)
            {
                if (logger.IsDebugEnabled)
                    logger.DebugFormat(
                        "Target {0} with ID {1} and status {2} not evaluated since it is not in a state to be Evaluated (i.e. it is inactive or deleted.)",
                        targetDefinition.Name, targetDefinition.Id, targetDefinition.Status.Name);
                return;
            }

            Site site = targetDefinition.FunctionalLocation.Site;
            DateTime currentTimeAtSite = timeDao.GetTime(site.TimeZone);

            List<decimal?> actualValues;
           
            // 1.  Read the Target tag
            try
            {
                actualValues = ReadActualValues(targetDefinition);
            }                                    
            catch (InvalidPlantHistorianReadException e)
            {
                string tagName = targetDefinition.TagInfo != null ? targetDefinition.TagInfo.Name : "null";

                HandleInvalidTagAccess(targetDefinition, tagName, currentTimeAtSite);                
                log.Warn(string.Format("Unable to read tag: {0}.", tagName), e);
                return;
            }            

            EvaluateTargetDefinitionBasedOnTagValues(targetDefinition, actualValues, log, currentTimeAtSite);
        }

        private void EvaluateTargetDefinitionBasedOnTagValues(TargetDefinition targetDefinition, List<decimal?> actualValues, ILog log, DateTime currentTimeAtSite)
        {
            // 1.  Evaluate the Target tag value against the Target Definition min/max/actual/etc.
            TargetThresholdEvaluation evaluation = targetDefinition.EvaluateNewReadings(actualValues);

            if (log.IsDebugEnabled)
            {
                log.DebugFormat("Evaluated actual:<{0}> against threshold values... exceeded:<{1}> by:<{2}>",
                                evaluation.ActualValueUsed,
                                evaluation.ExcessLevel,
                                evaluation.GapValue);
            }

            // 2.  Write tag values back to Plant Historian (in the case they are configured)
            try
            {
                targetDefinitionDao.WriteTagValues(targetDefinition);
            }
            catch (InvalidPlantHistorianWriteException e)
            {
                TagInfo tag = e.Tag;
                string tagName = tag != null ? tag.Name : "null";
                HandleInvalidTagAccess(targetDefinition, tagName, currentTimeAtSite);
                log.Warn(string.Format("Unable to write tag: {0}.", tagName));
                return;
            }

            // 3.  Set the new state of the TargetDefinition
            TargetDefinitionState currentTargetDefinitionState = targetDefinitionStateDao.QueryById(targetDefinition.IdValue);
            UpdateState(currentTargetDefinitionState, currentTimeAtSite, evaluation);

            // Note: Not calling target definition service to do the update.
            //       No need to raise update event as this update is not essential
            //       (only the ExceedingBoundary flag would be changed).
            // Guard against definitions not requiring alerts:
            if (!targetDefinition.IsAlertRequired)
            {
                return;
            }

            
            TargetAlert alertNeedingAttention = QueryTargetAlertNeedingAttentionByTargetDefinition(targetDefinition);

            if (alertNeedingAttention == null)
            {
                bool inGap = IsTargetAndAllAssociatedTargetsExceedingBoundary(targetDefinition, currentTargetDefinitionState);
                log.DebugFormat("Is in gap?:<{0}>", inGap);

                // Raise new alert if necesary:
                if (inGap == false)
                {
                    log.Debug("Done evaluating since it's not in gap.");
                    return;
                }
                User systemUser = userService.GetRemoteAppUser();
                TargetAlert newAlert = targetDefinition.CreateTargetAlert(evaluation, currentTimeAtSite, systemUser);
                log.Debug("Inserting new alert.");
                targetAlertDao.Insert(newAlert);
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.TargetAlertCreate, newAlert);
            }
            else
            {
                TargetAlert previousAlert = (TargetAlert) alertNeedingAttention.Clone();
                alertNeedingAttention.UpdateWithNewEvaluation(evaluation, targetDefinition, currentTimeAtSite);

                // Let's be smart about Updating.  If nothing changed from the previous values, 
                // then don't set the Last Modified stuff, Update the db record, and send an unnecessary Event to client.
                if (previousAlert.DoesNotEqual(alertNeedingAttention))
                {
                    User systemUser = userService.GetRemoteAppUser();
                    alertNeedingAttention.LastModifiedBy = systemUser;
                    alertNeedingAttention.LastModifiedDateTime = currentTimeAtSite;
                    log.DebugFormat("Updating existing non-closed alert:<{0}>.", alertNeedingAttention.Id);
                    UpdateTargetAlertFromAnotherService(alertNeedingAttention);
                }
            }
        }

        private void UpdateState(TargetDefinitionState currentTargetDefinitionState, DateTime currentTimeAtSite, TargetThresholdEvaluation evaluation)
        {
            bool stateChanged = false;
            if (evaluation.AnyLimitExceeded != currentTargetDefinitionState.IsExceedingBoundary)
            {
                currentTargetDefinitionState.IsExceedingBoundary = evaluation.AnyLimitExceeded;
                stateChanged = true;
            }

            if (currentTimeAtSite != currentTargetDefinitionState.LastSuccessfulTagAccess)
            {
                currentTargetDefinitionState.LastSuccessfulTagAccess = currentTimeAtSite;
                stateChanged = true;
            }

            if (stateChanged)
                targetDefinitionStateDao.Update(currentTargetDefinitionState);
        }

        private void HandleInvalidTagAccess(TargetDefinition targetDefinition, string tagName, DateTime currentTimeAtSite)
        {
            TargetDefinitionState targetDefinitionState = targetDefinitionStateDao.QueryById(targetDefinition.IdValue);
            DateTime? lastSuccessfulRead = targetDefinitionState.LastSuccessfulTagAccess;

            TimeSpan timeSpan;

            if (lastSuccessfulRead == null)
            {
                // tag has never been read
                timeSpan = currentTimeAtSite - targetDefinition.LastModifiedDate;
            }
            else
            {
                timeSpan = currentTimeAtSite - lastSuccessfulRead.Value;
            }
                
            if (timeSpan.Days > Constants.TAG_DAYS_SINCE_LAST_READ_LIMIT)
            {
                targetDefinition.IsActive = false;
                string message = string.Format("{0} The tag is {1}", StringResources.UnableToAccessTag, tagName);
                User systemUser = userService.GetRemoteAppUser();
                targetDefinition.Comments.Add(new Comment(systemUser, currentTimeAtSite, message));
                targetDefinition.LastModifiedDate = currentTimeAtSite;
                UpdateTargetDefinitionForUnableToAccessTag(targetDefinition);                                        
            }            
        }

        public void CheckCircularDependencyCreated(TargetDefinition targetDefinition)
        {
            var stack = new Stack<long>();
            stack.Push(targetDefinition.IdValue);
            CheckChildrenForCircularDependencies(targetDefinition, stack);
        }

        /// <summary>
        /// Checks children Targets for Circular Dependencies.
        /// </summary>
        /// <param name="targetDefinition"></param>
        /// <param name="stack">Contains the target ids up the tree of items.</param>
        private void CheckChildrenForCircularDependencies(TargetDefinition targetDefinition, Stack<long> stack)
        {
            foreach(TargetDefinitionDTO childTargetDto in targetDefinition.AssociatedTargetDTOs)
            {
                // if the stack already has a child id, then a circular dependency has been found.
                long childTargetId = childTargetDto.IdValue;
                if(stack.Contains(childTargetId))
                {
                    stack.Push(childTargetId);
                    TargetDefinition target = targetDefinitionDao.QueryById(childTargetId);
                    throw new LinkedTargetCircularReferenceException(stack.ToArray(), target);
                }
                stack.Push(childTargetId);
                CheckChildrenForCircularDependencies(targetDefinitionDao.QueryById(childTargetId), stack);
            }
            // no circular dependencies found at the current level. So, pop the targetId off the stack
            // and return up a level.
            stack.Pop();
        }

        public TargetAlert QueryById(long id)
        {
            return targetAlertDao.QueryById(id);
        }

        private Comparison<TargetAlertDTO> SortByCreatedDateTimeDescending()
        {
            return (dto1, dto2) => dto1.CreatedDateTime.CompareTo(dto2.CreatedDateTime) * -1;
        }

        public List<TargetAlertDTO> QueryByFunctionalLocationsAndStatuses(IFlocSet flocSet, List<TargetAlertStatus> targetAlertStatuses)
        {
            var dtos = new List<TargetAlertDTO>();

            dtos.AddRange(targetAlertDtoDao.QueryByFunctionalLocationsAndStatuses(flocSet, targetAlertStatuses, new DateRange(null, null)));

            dtos.Sort(SortByCreatedDateTimeDescending());

            return dtos;
        }

        public List<TargetAlertDTO> QueryDTOsNeedingAttention(IFlocSet flocSet, Range<Date> dateRange)
        {
            return targetAlertDtoDao.QueryByFunctionalLocationsAndStatuses(flocSet, TargetAlertStatus.AllNeedingAttention, new DateRange(dateRange));
        }

        public TargetAlert QueryTargetAlertNeedingAttentionByTargetDefinition(TargetDefinition targetDefinition)
        {
            List<TargetAlert> alertsNeedingAttention
                = targetAlertDao.QueryByTargetDefinitionAndStatuses(targetDefinition, TargetAlertStatus.AllNeedingAttention);

            if (alertsNeedingAttention.Count > 1)
            {
                throw new ApplicationException(GetFoundTooManyNonClosedTargetAlertsMessage(targetDefinition, alertsNeedingAttention));
            }

            if (alertsNeedingAttention.Count == 0)
            {
                return null;
            }

            return alertsNeedingAttention[0];
        }
        
        public List<NotifiedEvent> CreateTargetAlertResponse(TargetAlertResponse response, bool createLog, bool isLogOperationalEngineerLog, User currentUser, ShiftPattern shiftPattern, Role currentUserRole, WorkAssignment workAssignment)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            // Update the target alert, whose status could have changed when the response was created:
            response.Alert.LastModifiedBy = currentUser;
            notifiedEvents.Add(UpdateTargetAlertFromAnotherService(response.Alert));
            response.ResponseComment = commentDao.InsertComment(response.ResponseComment);
            response = responseDao.Insert(response);
            if(createLog)
            {
                DateTime currentTimeAtSite = timeDao.GetTime(response.Alert.FunctionalLocation.Site.TimeZone);                

                Log log = response.CreateLog(
                    currentUser, isLogOperationalEngineerLog, shiftPattern, currentTimeAtSite, currentUserRole, workAssignment);
                notifiedEvents.AddRange(logService.InsertForTargetAlert(log, response.Alert));
            }

            return notifiedEvents;
        }

        private NotifiedEvent UpdateTargetAlertFromAnotherService(TargetAlert alert)
        {
            targetAlertDao.Update(alert);
            return ServiceUtility.PushEventIntoQueue(ApplicationEvent.TargetAlertUpdate, alert);
        }

        public List<NotifiedEvent> UpdateTargetAlert(TargetAlert alert)
        {
            targetAlertDao.Update(alert);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.TargetAlertUpdate, alert));
            return notifiedEvents;
        }

        private void UpdateTargetDefinitionForUnableToAccessTag(TargetDefinition targetDefinition)
        {            
            targetDefinitionDao.UpdateAfterUnableToAccessTags(targetDefinition);
            editHistoryService.TakeSnapshot(targetDefinition);
            ServiceUtility.PushEventIntoQueue(ApplicationEvent.TargetDefinitionUpdate, targetDefinition);
        }

        public void ClearAllTargetAlertsAtOrBelowFlocs(List<FunctionalLocation> functionalLocations)
        {
            if (functionalLocations.Count == 0)
                return;

            User systemUser = userService.GetRemoteAppUser();
            List<TargetAlert> targetAlerts = targetAlertDao.QueryAllTargetAlertsNeedingAttention(functionalLocations, TargetAlertStatus.AllNeedingAttention);
            
            foreach (TargetAlert alert in targetAlerts)
            {
                alert.LastModifiedBy = systemUser;
                alert.Status = TargetAlertStatus.Cleared;
                UpdateTargetAlertFromAnotherService(alert);
            }
        }

        private List<decimal?> ReadActualValues(TargetDefinition targetDefinition)
        {
            // TODO (Joe) - the Honeywell system seems to expect times in MST, so we'll use the server time.
            // DateTime currentTimeAtSite = timeDao.GetTime(targetDefinition.FunctionalLocation.SiteId);
            List<DateTime> readTimes = targetDefinition.GetReadTimesToEvaluateTarget(DateTime.Now.GetNetworkPortable());

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            decimal?[] readings = plantHistorianService.ReadTagValues(PlantHistorianOrigin.TargetAlertService_Evaluation, targetDefinition.TagInfo, readTimes.ToArray());
            TimeSpan timeToReadTagValues = stopWatch.Elapsed;

            List<decimal?> actualValues = new List<decimal?>(readings);

            logger.DebugFormat("Read tag:<{0}> at times:<{1}> values:<{2}>", targetDefinition.TagInfo.Name,
                               readTimes.BuildCommaSeparatedList(rt => rt.ToString()),
                               actualValues.BuildCommaSeparatedList(av => av.ToString()));

            logger.DebugFormat("Time to read target values for tag <{0}>, definition <{1}>: {2}", 
                targetDefinition.TagInfo.Name, targetDefinition.Name, timeToReadTagValues);

            return actualValues;
        }

        private static string GetFoundTooManyNonClosedTargetAlertsMessage(DomainObject targetDefinition, List<TargetAlert> nonClosedAlerts)
        {
            return "Unexpected finding of multiple non-closed target alerts:<"
                   + nonClosedAlerts.BuildIdStringFromList() + "> for target definition:<" + targetDefinition.Id + ">";
        }

        class TargetDefinitionLogDecorator : ILog
        {
            private readonly ILog logDecoratorLogger;
            private readonly string prefix;

            public TargetDefinitionLogDecorator(ILog logDecoratorLoggerToDecorate, TargetDefinition targetDefinition)
            {
                logDecoratorLogger = logDecoratorLoggerToDecorate;
                prefix = string.Format("Target definition:<{0}> for Tag:<{1}>", targetDefinition.Id,
                                       targetDefinition.TagInfo.Name);
            }

            public void Debug(object message, Exception exception)
            {
                logDecoratorLogger.Debug(AddPrefix(message), exception);
            }

            public void Debug(object message)
            {
                logDecoratorLogger.Debug(AddPrefix(message));
            }

            public void DebugFormat(string format, object arg0, object arg1, object arg2)
            {
                logDecoratorLogger.DebugFormat(AddPrefix(format), arg0, arg1, arg2);
            }

            public void DebugFormat(IFormatProvider provider, string format, params object[] args)
            {
                logDecoratorLogger.DebugFormat(provider, AddPrefix(format), args);
            }

            public void DebugFormat(string format, params object[] args)
            {
                logDecoratorLogger.DebugFormat(AddPrefix(format), args);
            }

            public void DebugFormat(string format, object arg0)
            {
                logDecoratorLogger.DebugFormat(AddPrefix(format), arg0);
            }

            public void DebugFormat(string format, object arg0, object arg1)
            {
                logDecoratorLogger.DebugFormat(AddPrefix(format), arg0, arg1);
            }

            public void Error(object message, Exception exception)
            {
                logDecoratorLogger.Error(AddPrefix(message), exception);
            }

            public void Error(object message)
            {
                logDecoratorLogger.Error(AddPrefix(message));
            }

            public void ErrorFormat(string format, object arg0, object arg1, object arg2)
            {
                logDecoratorLogger.ErrorFormat(AddPrefix(format), arg0, arg1, arg2);
            }

            public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
            {
                logDecoratorLogger.ErrorFormat(provider, AddPrefix(format), args);
            }

            public void ErrorFormat(string format, params object[] args)
            {
                logDecoratorLogger.ErrorFormat(AddPrefix(format), args);
            }

            public void ErrorFormat(string format, object arg0)
            {
                logDecoratorLogger.ErrorFormat(AddPrefix(format), arg0);
            }

            public void ErrorFormat(string format, object arg0, object arg1)
            {
                logDecoratorLogger.ErrorFormat(AddPrefix(format), arg0, arg1);
            }

            public void Fatal(object message, Exception exception)
            {
                logDecoratorLogger.Fatal(AddPrefix(message), exception);
            }

            public void Fatal(object message)
            {
                logDecoratorLogger.Fatal(AddPrefix(message));
            }

            public void FatalFormat(string format, object arg0, object arg1, object arg2)
            {
                logDecoratorLogger.FatalFormat(AddPrefix(format), arg0, arg1, arg2);
            }

            public void FatalFormat(IFormatProvider provider, string format, params object[] args)
            {
                logDecoratorLogger.FatalFormat(provider, AddPrefix(format), args);
            }

            public void FatalFormat(string format, params object[] args)
            {
                logDecoratorLogger.FatalFormat(AddPrefix(format), args);
            }

            public void FatalFormat(string format, object arg0)
            {
                logDecoratorLogger.FatalFormat(AddPrefix(format), arg0);
            }

            public void FatalFormat(string format, object arg0, object arg1)
            {
                logDecoratorLogger.FatalFormat(AddPrefix(format), arg0, arg1);
            }

            public void Info(object message, Exception exception)
            {
                logDecoratorLogger.Info(AddPrefix(message), exception);
            }

            public void Info(object message)
            {
                logDecoratorLogger.Info(AddPrefix(message));
            }

            public void InfoFormat(string format, object arg0, object arg1, object arg2)
            {
                logDecoratorLogger.InfoFormat(AddPrefix(format), arg0, arg1, arg2);
            }

            public void InfoFormat(IFormatProvider provider, string format, params object[] args)
            {
                logDecoratorLogger.InfoFormat(provider, AddPrefix(format), args);
            }

            public void InfoFormat(string format, params object[] args)
            {
                logDecoratorLogger.InfoFormat(AddPrefix(format), args);
            }

            public void InfoFormat(string format, object arg0)
            {
                logDecoratorLogger.InfoFormat(AddPrefix(format), arg0);
            }

            public void InfoFormat(string format, object arg0, object arg1)
            {
                logDecoratorLogger.InfoFormat(AddPrefix(format), arg0, arg1);
            }

            public bool IsDebugEnabled
            {
                get { return logDecoratorLogger.IsDebugEnabled; }
            }

            public bool IsErrorEnabled
            {
                get { return logDecoratorLogger.IsErrorEnabled; }
            }

            public bool IsFatalEnabled
            {
                get { return logDecoratorLogger.IsFatalEnabled; }
            }

            public bool IsInfoEnabled
            {
                get { return logDecoratorLogger.IsInfoEnabled; }
            }

            public bool IsWarnEnabled
            {
                get { return logDecoratorLogger.IsWarnEnabled; }
            }

            public void Warn(object message, Exception exception)
            {
                logDecoratorLogger.Warn(AddPrefix(message), exception);
            }

            public void Warn(object message)
            {
                logDecoratorLogger.Warn(AddPrefix(message));
            }

            public void WarnFormat(string format, object arg0, object arg1, object arg2)
            {
                logDecoratorLogger.WarnFormat(AddPrefix(format), arg0, arg1, arg2);
            }

            public void WarnFormat(IFormatProvider provider, string format, params object[] args)
            {
                logDecoratorLogger.WarnFormat(provider, AddPrefix(format), args);
            }

            public void WarnFormat(string format, params object[] args)
            {
                logDecoratorLogger.WarnFormat(AddPrefix(format), args);
            }

            public void WarnFormat(string format, object arg0)
            {
                logDecoratorLogger.WarnFormat(AddPrefix(format), arg0);
            }

            public void WarnFormat(string format, object arg0, object arg1)
            {
                logDecoratorLogger.WarnFormat(AddPrefix(format), arg0, arg1);
            }

            public ILogger Logger
            {
                get { return logDecoratorLogger.Logger; }
            }

            private string AddPrefix(string value)
            {
                return prefix + " " + value;
            }

            private object AddPrefix(object value)
            {
                return prefix + " " + value;
            }
        }

        private class Values
        {
            private readonly Dictionary<string, List<TagValue>> dictionary = new Dictionary<string, List<TagValue>>(StringComparer.InvariantCulture);

            public void Add(TagValue tagValue)
            {
                if (!dictionary.ContainsKey(tagValue.TagName))
                {
                    List<TagValue> tagValues = new List<TagValue> { tagValue };
                    dictionary.Add(tagValue.TagName, tagValues);
                }
                else
                {
                    dictionary[tagValue.TagName].Add(tagValue);
                }
            }

            public decimal? GetNewestValue(string name)
            {
                if (dictionary.ContainsKey(name))
                {
                    List<TagValue> tagValues = dictionary[name];
                    tagValues.Sort(item => item.DateTime, true);
                    return tagValues.Last().Value;
                }
                return new decimal?();
            }

            public List<decimal?> GetAllValues(string name)
            {
                if (dictionary.ContainsKey(name))
                {
                    return dictionary[name].ConvertAll(item => item.Value);
                }
                return new List<decimal?>(0);
            }
        }
    }
}
