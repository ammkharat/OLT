using System.ServiceModel;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class ServerClientChannelFactoryWrapper<T> : AbstractChannelFactoryWrapper<T>
    {
        private readonly string clientAddress;

        public ServerClientChannelFactoryWrapper(string clientAddress)
        {
            this.clientAddress = clientAddress;
            Recreate();
        }

        protected override ChannelFactory<T> CreateChannelFactory()
        {
            return ChannelFactoryCreator.CreateChannelFactoryForReceivingOltServerEvents<T>(clientAddress);
        }
    }
}