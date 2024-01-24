using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class ClientServerChannelFactoryWrapper<T> : AbstractChannelFactoryWrapper<T>
    {
        private readonly string baseAddress;
        private readonly IList<IEndpointBehavior> endpointBehaviors;

        internal ClientServerChannelFactoryWrapper(string baseAddress, IList<IEndpointBehavior> endpointBehaviors)
        {
            this.baseAddress = baseAddress;
            this.endpointBehaviors = endpointBehaviors;

            Recreate();
        }

        protected override ChannelFactory<T> CreateChannelFactory()
        {
            return ChannelFactoryCreator.CreateClientToServerChannelFactory<T>(baseAddress, endpointBehaviors);
        }
    }
}