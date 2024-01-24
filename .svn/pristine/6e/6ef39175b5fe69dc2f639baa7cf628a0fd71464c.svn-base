using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class ChannelFactoryCreator
    {
        public static ChannelFactory<T> CreateClientToServerChannelFactory<T>(string baseAddress,
            IList<IEndpointBehavior> endpointBehaviors)
        {
            var binding = ServiceBindingFactory.CreateClientServerBinding();
            var fullAddress = GetFullAddress<T>(baseAddress);
            return Create<T>(fullAddress, binding, endpointBehaviors);
        }

        public static ChannelFactory<T> CreateChannelFactoryForReceivingOltServerEvents<T>(string hostAddress)
        {
            var binding = ServiceBindingFactory.CreateOneWayTcpBinding();
            return Create<T>(hostAddress, binding, new List<IEndpointBehavior>(0));
        }

        public static ChannelFactory<T> CreateClientToServerChannelFactory<T>(BindingType bindingType,
            string baseAddress)
        {
            var binding = ServiceBindingFactory.CreateClientServerBinding(bindingType);
            var fullAddress = GetFullAddress<T>(baseAddress);
            return Create<T>(fullAddress, binding, new List<IEndpointBehavior>(0));
        }

        private static ChannelFactory<T> Create<T>(string fullAddress, Binding binding,
            IEnumerable<IEndpointBehavior> endpointBehaviors)
        {
            var factory = new ChannelFactory<T>(binding, new EndpointAddress(fullAddress));
            ServiceEndpointConfiguration.Apply(factory.Endpoint);
            foreach (var endpointBehavior in endpointBehaviors)
            {
                factory.Endpoint.Behaviors.Add(endpointBehavior);
            }

            return factory;
        }

        public static string GetFullAddress<T>(string baseAddress)
        {
            baseAddress = baseAddress.EndsWith("/") ? baseAddress : baseAddress + "/";
            return baseAddress + typeof (T).Name + ".svc";
        }
    }
}