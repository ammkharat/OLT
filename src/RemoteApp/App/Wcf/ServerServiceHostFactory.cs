using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Com.Suncor.Olt.Common.Wcf;

namespace Com.Suncor.Olt.Remote.Wcf
{
    public class ServerServiceHostFactory : OltServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string serviceName, Uri[] baseAddresses)
        {
            Binding binding = CreateBinding(serviceName);

            ServiceHost serviceHost = CreateServiceHost(serviceName, baseAddresses, binding);
            {
                ServiceMetadataBehavior behaviour = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                behaviour.HttpGetEnabled = true;
            }

            foreach (ServiceEndpoint endpoint in serviceHost.Description.Endpoints)
            {
                foreach (OperationDescription od in endpoint.Contract.Operations)
                {
                    ServerOperationBehavior serverOperationBehavior = new ServerOperationBehavior();
                    od.Behaviors.Add(serverOperationBehavior);
                }
            }
            return serviceHost;
        }

        private static Binding CreateBinding(string serviceName)
        {
            Binding binding;
            if (serviceName.Contains("StreamingRequest"))
            {
                binding = ServiceBindingFactory.CreateStreamingBinaryHttpBinding();
            }
            else if (serviceName.Contains("Streaming"))
            {
                binding = ServiceBindingFactory.CreateBinaryHttpBindingWithStreamingResponse();
            }
            else
            {
                binding = ServiceBindingFactory.CreateClientServerBinding();
            }
            return binding;
        }
    }
}