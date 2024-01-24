using System.ServiceModel;

namespace Com.Suncor.Olt.Common.Wcf
{
    public interface IChannelFactoryWrapper
    {
        void Recreate();
        IClientChannel CreateChannel();
        void Close();
    }
}