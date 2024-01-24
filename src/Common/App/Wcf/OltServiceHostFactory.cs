using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class OltServiceHostFactory : ServiceHostFactory
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<OltServiceHostFactory>();

        public static ServiceHostBase CreateServiceHostForReceivingEventNotifications(string serviceName,
            Uri[] baseAddresses)
        {
            var binding = ServiceBindingFactory.CreateOneWayTcpBinding();
            logger.Debug("Tcp binding created.");
            var host = CreateServiceHost(serviceName, baseAddresses, binding);
            logger.Debug("Service Host created");
            return host;
        }

        protected static ServiceHost CreateServiceHost(string serviceName, Uri[] baseAddresses, Binding binding)
        {
            var serviceType = ServiceNameMap.Instance.GetServiceType(serviceName);
            var host = new ServiceHost(serviceType, baseAddresses);

            var interfaceType = ServiceNameMap.Instance.GetServiceInterfaceType(serviceName);

            if (interfaceType == null)
            {
                var errorMessage = string.Format("Could not find interface Type for {0} service.", serviceName);
                logger.Error(errorMessage);
                throw new ServiceActivationException(errorMessage);
            }

            logger.DebugFormat("Adding add service endpoint for {0}", interfaceType.FullName);
            var endPoint = host.AddServiceEndpoint(interfaceType, binding, string.Empty);

            logger.Debug("Adding alternate data contract serializer");
            ServiceEndpointConfiguration.Apply(endPoint);

            {
                logger.Debug("Adding service metadata behavior");
                var behaviour = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (behaviour == null)
                {
                    behaviour = new ServiceMetadataBehavior();
                    host.Description.Behaviors.Add(behaviour);
                }
            }

            {
                logger.Debug("Adding service debug behavior");
                var behaviour = host.Description.Behaviors.Find<ServiceDebugBehavior>();
                if (behaviour == null)
                {
                    behaviour = new ServiceDebugBehavior();
                    host.Description.Behaviors.Add(behaviour);
                }
                behaviour.IncludeExceptionDetailInFaults = true;
            }

            {
                logger.Debug("Adding service throttling behavior");
                var behaviour = host.Description.Behaviors.Find<ServiceThrottlingBehavior>();
                if (behaviour == null)
                {
                    behaviour = new ServiceThrottlingBehavior();
                    behaviour.MaxConcurrentCalls = WcfConfiguration.Instance.MaxConcurrentCalls;
                    behaviour.MaxConcurrentInstances = WcfConfiguration.Instance.MaxConcurrentInstances;
                    behaviour.MaxConcurrentSessions = WcfConfiguration.Instance.MaxConcurrentSessions;

                    host.Description.Behaviors.Add(behaviour);
                }
            }
            return host;
        }
    }
}