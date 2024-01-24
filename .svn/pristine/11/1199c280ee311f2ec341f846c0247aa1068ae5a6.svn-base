using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Wcf
{
    public abstract class AbstractEventNotificationEnabledServiceRegistry : AbstractServiceRegistry
    {
        private static readonly ILog logger =
            GenericLogManager.GetLogger<AbstractEventNotificationEnabledServiceRegistry>();

        private readonly IRemoteEventRepeater remoteEventRepeater;
        private string clientServiceHostAddress;
        private ServiceHostBase eventNotificationServiceHost;

        protected AbstractEventNotificationEnabledServiceRegistry()
        {
            eventNotificationServiceHost = CreateEventNotificationServiceHost();
            clientServiceHostAddress = eventNotificationServiceHost.BaseAddresses[0].AbsoluteUri;
            remoteEventRepeater = new RemoteEventRepeater(GetService<IEventService>(), ClientServiceHostAddress);
        }

        protected AbstractEventNotificationEnabledServiceRegistry(
            IRemoteEventRepeater remoteEventRepeater,
            ServiceHostBase eventNotificationServiceHost,
            string clientServiceHostAddress)
        {
            this.remoteEventRepeater = remoteEventRepeater;
            this.eventNotificationServiceHost = eventNotificationServiceHost;
            this.clientServiceHostAddress = clientServiceHostAddress;
        }

        public string ClientServiceHostAddress
        {
            get { return clientServiceHostAddress; }
        }

        public IRemoteEventRepeater RemoteEventRepeater
        {
            get { return remoteEventRepeater; }
        }

        private static ServiceHostBase CreateEventNotificationServiceHost()
        {
            if (WcfConfiguration.Instance.ClientPorts.Length == 0)
            {
                var message = StringResources.NoClientPortsInConfigErrorMessage;
                logger.Error(message);
                throw new Exception(message);
            }

            var serviceHost = GetServiceHost();
            return serviceHost;
        }

        private static ServiceHostBase GetServiceHost()
        {
            foreach (var clientPort in WcfConfiguration.Instance.ClientPorts)
            {
                var serviceHost = AttemptCreateServiceHost(clientPort);
                if (serviceHost != null)
                {
                    return serviceHost;
                }
            }

            var message = StringResources.UnableToOpenAClientHostOnAnyPortsErrorMessage +
                          string.Join(",", WcfConfiguration.Instance.ClientPorts);
            logger.Error(message);
            throw new Exception(message);
        }

        private static string CreateClientHostUrl(string clientPort)
        {
            var nameOrIpAddress = GetHostNameOrIpAddress();

            var clientUrl = String.Format("net.tcp://{0}:{1}/", nameOrIpAddress, clientPort);
            return clientUrl;
        }

        private static string GetHostNameOrIpAddress()
        {
            if (!string.IsNullOrEmpty(WcfConfiguration.Instance.ClientHostNameOrIpAddress))
            {
                return WcfConfiguration.Instance.ClientHostNameOrIpAddress;
            }

            return NetworkUtilities.GetLocalIpAddress();
        }

        private static ServiceHostBase AttemptCreateServiceHost(string clientPort)
        {
            var serviceHostAddress = CreateClientHostUrl(clientPort);

            try
            {
                logger.Info("Attempting to create service host for event notification at " + serviceHostAddress);

                var serviceHost =
                    OltServiceHostFactory.CreateServiceHostForReceivingEventNotifications(
                        typeof (IEventNotificationService).Name, new[] {new Uri(serviceHostAddress)});
                logger.DebugFormat("Attempting to open Service Host: {0}", serviceHost);
                serviceHost.Open();

                logger.Info("Successfully created service host for event notification at " + serviceHostAddress);
                return serviceHost;
            }
            catch (Exception e)
            {
                logger.Info(
                    String.Format(
                        "Unable to create service host for event notification at {0}.  The error message for {1} was: {2}",
                        serviceHostAddress, e.GetType().Name, e.Message));
            }

            return null;
        }

        public override void CloseAll()
        {
            base.CloseAll();

            logger.Info("Closing service host.");
            eventNotificationServiceHost.Close();
            logger.Info("Done closing service host.");
        }

        public void ResumeOnWakeup(List<FunctionalLocation> filterFunctionalLocations,
            List<FunctionalLocation> workPermitEdmontonFunctionalLocations,
            List<FunctionalLocation> restrictionFunctionalLocations,
            List<long> clientReadableVisibilityGroupIds)
        {
            try
            {
                ResumeServiceChannels();
            }
            catch
            {
                logger.Error("Problem opening existing service proxies on resume");
            }

            eventNotificationServiceHost = CreateEventNotificationServiceHost();
            clientServiceHostAddress = eventNotificationServiceHost.BaseAddresses[0].AbsoluteUri;

            // don't try to connect to the remote event repeater if we haven't made it far enough along in the application to have the following data.
            if (filterFunctionalLocations.IsEmpty() || clientReadableVisibilityGroupIds.IsEmpty())
                return;

            remoteEventRepeater.ReConnect(GetService<IEventService>(), clientServiceHostAddress,
                filterFunctionalLocations, workPermitEdmontonFunctionalLocations, restrictionFunctionalLocations, clientReadableVisibilityGroupIds);
        }

        public void SleepOrHibernate(EventConnectDisconnectReason eventDisconnectReason)
        {
            // network is lost. So, no reason to try to make a call to the server side to unsubscribe.
            if (eventDisconnectReason != EventConnectDisconnectReason.NetworkConnectionLost)
            {
                remoteEventRepeater.UnsubscribeFromEvents(eventDisconnectReason);
            }

            if (eventNotificationServiceHost != null)
            {
                eventNotificationServiceHost.Close();
            }
            SuspendServiceChannels();
        }
    }
}