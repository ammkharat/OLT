using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Wcf;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EventService : IEventService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<EventService>();
        private static readonly ClientEventPushServiceRegistry clientRegistry = ClientEventPushServiceRegistry.Instance;

        private readonly IEventSinkDao eventsDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;

        public EventService()
            : this(DaoRegistry.GetDao<IEventSinkDao>(), DaoRegistry.GetDao<ISiteConfigurationDao>())
        {
        }

        public EventService(IEventSinkDao eventsDao, ISiteConfigurationDao siteConfigurationDao)
        {
            this.eventsDao = eventsDao;
            this.siteConfigurationDao = siteConfigurationDao;
        }

        public void Subscribe(string clientAddress, List<FunctionalLocation> relevantFunctionalLocations,
            List<FunctionalLocation> workPermitEdmontonRelevantFunctionalLocations,
            List<FunctionalLocation> rootFlocSetForRestrictions, List<long> clientReadableVisibilityGroupIds,
            long? siteId, string machineName, EventConnectDisconnectReason reason)
        {
            logger.InfoFormat(
                "Subscribe: [ClientAddress={0}] [SiteId={1}] [Machine={2}] [Reason={3}]",
                clientAddress,
                siteId,
                machineName,
                reason);

            DoUnsubscribeWithoutLogging(clientAddress);

            var fullHierarchyList = relevantFunctionalLocations.ConvertAll(floc => floc.FullHierarchy);
            var workPermitEdmontonFullHierarchyList =
                workPermitEdmontonRelevantFunctionalLocations.ConvertAll(floc => floc.FullHierarchy);
            var restrictionFullHierarchyList = rootFlocSetForRestrictions.ConvertAll(floc => floc.FullHierarchy);
            var clientReadableVisibilityGroupIdList = clientReadableVisibilityGroupIds;

            var eventSink = new EventSink(clientAddress, fullHierarchyList, workPermitEdmontonFullHierarchyList,
                restrictionFullHierarchyList, clientReadableVisibilityGroupIdList, siteId);

            eventsDao.Insert(eventSink);
        }

        public void Unsubscribe(string clientAddress, EventConnectDisconnectReason reason)
        {
            logger.InfoFormat("Unsubscribe: [ClientAddress={0}] [Reason={1}]", clientAddress, reason);
            DoUnsubscribeWithoutLogging(clientAddress);
        }

        public void PublishEvent(DomainEventArgs<DomainObject> domainObjectArgs, InitiatingEventSink initiatingEventSink)
        {
            var eventSinks = eventsDao.QueryAll();

            foreach (var eventSink in eventSinks)
            {
                try
                {
                    if (!IsIgnored(eventSink, initiatingEventSink) &&
                        ShouldNotifyClientOfEvent(eventSink, domainObjectArgs.SelectedItem))
                    {
                        NotifyClient(eventSink, domainObjectArgs);
                    }
                }
                catch (Exception e)
                {
                    LogErrorAndDeleteEventSink(string.Empty, domainObjectArgs, eventSink, e);
                }
            }
        }

        private void DoUnsubscribeWithoutLogging(string clientAddress)
        {
            try
            {
                ClientEventPushServiceRegistry.Instance.RemoveEventNotificationProxy(clientAddress);
                eventsDao.DeleteByClientUri(clientAddress);
            }
            catch (Exception ex)
            {
                logger.Error(
                    string.Format("There was a problem unregistering a client at {0}", clientAddress),
                    ex);
            }
        }

        private static bool IsIgnored(EventSink eventSink, InitiatingEventSink initiatingEventSink)
        {
            if (initiatingEventSink == null)
            {
                return false;
            }
            // Don't send back the event to a client who initiated the Event.  This client deals with the change on return of the service call.
            return string.Equals(initiatingEventSink.ClientUri, eventSink.ClientUri);
        }

        private void LogErrorAndDeleteEventSink(string error, DomainEventArgs<DomainObject> domainObjectArgs,
            EventSink eventSink, Exception exceptionToLog)
        {
            try
            {
                if (IsSchedulerEventSink(eventSink))
                {
                    logger.ErrorFormat(
                        error + " An error has occurred while notifying a {0} of {1} with id: {2}.  The error was: {3}",
                        "scheduler event sink at " + eventSink.ClientUri,
                        domainObjectArgs.ApplicationEventType,
                        domainObjectArgs.SelectedItemIdAsString,
                        exceptionToLog);
                }
                else
                {
                    logger.ErrorFormat(
                        error + "An error has occurred while notifying a {0} of {1} with id: {2}.  The error was: {3}",
                        "user event sink at " + eventSink.ClientUri,
                        domainObjectArgs.ApplicationEventType,
                        domainObjectArgs.SelectedItemIdAsString,
                        exceptionToLog);

                    //An error occured, lets remove the client from our list
                    eventsDao.DeleteByClientUri(eventSink.ClientUri);
                }
            }
            catch (Exception currentException)
            {
                logger.ErrorFormat("Error logging error and deleting event sink for {0}: {1}", eventSink.ClientUri,
                    currentException);
            }
        }

        private static bool IsSchedulerEventSink(EventSink eventSink)
        {
            return eventSink.SiteId == null;
        }

        public bool ShouldNotifyClientOfEvent(EventSink eventSink, DomainObject domainObject)
        {
            var isRelevant = true;
            var fullHierarchyList = eventSink.FullHierarchyList;
            var workPermitEdmontonFullHierarchyList = eventSink.WorkPermitEdmontonFullHierarchyList;
            var restrictionFullHierarchyList = eventSink.RestrictionFullHierarchyList;
            var clientReadableVisibilityGroupIds = eventSink.ClientReadableVisibilityGroupIdList;

            if (domainObject is Site)
            {
                var site = domainObject as Site;
                isRelevant = eventSink.SiteId == site.Id;

                if (logger.IsDebugEnabled)
                    logger.DebugFormat("Should Notify Client Of Event Called.  EventSink Site = {0}, Server Site {1}",
                        eventSink.SiteId.GetValueOrDefault(),
                        site.Id);
            }
            else if (domainObject is IFunctionalLocationRelevant ||
                     domainObject is ISiteRelevant ||
                     domainObject is IVisibilityGroupRelevant)
            {
                var domainObjectAsVisibilityGroupRelevant = domainObject as IVisibilityGroupRelevant;

                isRelevant = GetIsSchedulerRelevant(domainObject, fullHierarchyList) ||
                             (GetIsFunctionalLocationRelevant(domainObject, eventSink.SiteId, fullHierarchyList,
                                 workPermitEdmontonFullHierarchyList, restrictionFullHierarchyList) &&
                              (domainObjectAsVisibilityGroupRelevant == null ||
                               GetIsVisibilityGroupRelevant(domainObjectAsVisibilityGroupRelevant,
                                   clientReadableVisibilityGroupIds))) ||
                             (GetIsSiteRelevant(domainObject, eventSink) &&
                              (domainObjectAsVisibilityGroupRelevant == null ||
                               GetIsVisibilityGroupRelevant(domainObjectAsVisibilityGroupRelevant,
                                   clientReadableVisibilityGroupIds)));
            }
            else if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("Should Notify Client of Event Called. Everybody gets the event.");
            }
            return isRelevant;
        }

        private static bool GetIsVisibilityGroupRelevant(IVisibilityGroupRelevant visibilityGroupRelevantObject,
            List<long> clientReadableVisibilityGroupIds)
        {
            // this is the case when they select 'No Assignment'
            if (clientReadableVisibilityGroupIds.IsEmpty())
            {
                return true;
            }

            return visibilityGroupRelevantObject.IsRelevantTo(clientReadableVisibilityGroupIds);
        }

        private static bool GetIsSchedulerRelevant(DomainObject domainObject, List<string> clientFullHierarchies)
        {
            return clientFullHierarchies.Count == 0 &&
                   (domainObject is IFunctionalLocationRelevant || domainObject is ISiteRelevant ||
                    domainObject is IVisibilityGroupRelevant);
        }

        private bool GetIsFunctionalLocationRelevant(DomainObject domainObject, long? siteIdOfClient,
            List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies,
            List<string> restrictionFullHierarchies)
        {
            var isFunctionalLocationRelevant = false;

            if (clientFullHierarchies.Count != 0 && domainObject is IFunctionalLocationRelevant &&
                siteIdOfClient.HasValue)
            {
                var data = domainObject as IFunctionalLocationRelevant;

                var siteConfiguration = siteConfigurationDao.QueryBySiteId(siteIdOfClient.Value);
                isFunctionalLocationRelevant = data.IsRelevantTo(siteIdOfClient.Value, clientFullHierarchies,
                    workPermitEdmontonFullHierarchies,restrictionFullHierarchies, siteConfiguration);

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("Should Notify Client of Event Called.  IsRelevant = {0}",
                        isFunctionalLocationRelevant);
                }
            }
            return isFunctionalLocationRelevant;
        }

        private static bool GetIsSiteRelevant(DomainObject domainObject, EventSink eventSink)
        {
            var isSiteRelevant = false;

            if (eventSink.SiteId.HasValue && domainObject is ISiteRelevant)
            {
                var data = (ISiteRelevant) domainObject;
                isSiteRelevant = data.IsRelevantTo(eventSink.SiteId.Value);

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("Should Notify Client of Event Called. Site = {0}, IsRelevant = {1}",
                        eventSink.SiteId, isSiteRelevant);
                }
            }
            return isSiteRelevant;
        }

        private void NotifyClient(EventSink eventSink, DomainEventArgs<DomainObject> eventArgs)
        {
            var clientAddress = eventSink.ClientUri;
            try
            {
                var proxy = clientRegistry.GetEventNotificationProxy(clientAddress);

                proxy.Notify(eventArgs);
            }
            catch (Exception e)
            {
                LogErrorAndDeleteEventSink("Error calling proxy.", eventArgs, eventSink, e);
            }
        }
    }
}