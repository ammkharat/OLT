using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;

namespace Com.Suncor.Olt.Client.Services
{
    public sealed class ClientServiceRegistry : AbstractEventNotificationEnabledServiceRegistry
    {
        private static readonly ProxyGenerator generator =
            new ProxyGenerator(new DefaultProxyBuilder(new ModuleScope(false, true)));

        private static ClientServiceRegistry instance;

        private ClientServiceRegistry()
        {
        }

        private ClientServiceRegistry(
            IRemoteEventRepeater remoteEventRepeater, ServiceHostBase eventNotificationServiceHost, string clientServiceHostAddress) 
            : base(remoteEventRepeater, eventNotificationServiceHost, clientServiceHostAddress)
        {
        }

        public static void InitializeMockedInstance(IRemoteEventRepeater repeater)
        {
            instance = new ClientServiceRegistry(repeater, null, null);
        }

        public static ClientServiceRegistry Instance
        {
            get { return instance ?? (instance = new ClientServiceRegistry()); }
        }

        protected override List<IEndpointBehavior> GetEndpointBehaviours()
        {
            List<IEndpointBehavior> endpointBehaviours = base.GetEndpointBehaviours();
            endpointBehaviours.Add(new ClientMessageInspectionEndpointBehavior());
            return endpointBehaviours;
        }

        protected override T WrapProxy<T>(T proxy)
        {
            if (typeof(T) == typeof(ITimeService))
            {
                return (T)GetTimeServiceCache((ITimeService)proxy);
            }
            return WrapServiceInHourGlassProxy(proxy);
        }

        private static ITimeService GetTimeServiceCache(ITimeService proxy)
        {
            return new TimeServiceCache(proxy, new TimeSpan(0, 5, 0));
        }

        private static T WrapServiceInHourGlassProxy<T>(T service) 
        {
            object result = generator.CreateInterfaceProxyWithTargetInterface(typeof(T), service, new HourGlassInterceptor());
            return (T) result;
        }
    }
}