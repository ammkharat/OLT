using System.ServiceModel;
using Castle.DynamicProxy;

namespace Com.Suncor.Olt.Common.Wcf
{
    /// <summary>
    ///     This Castle Dynamic Interceptor makes sure to Open the channel, performs the wcf service call, and close the
    ///     channel.
    /// </summary>
    public class ChannelInterceptor : IInterceptor
    {
        private readonly IChannelFactoryWrapper channelFactory;

        public ChannelInterceptor(IChannelFactoryWrapper channelFactory)
        {
            this.channelFactory = channelFactory;
        }

        public void Intercept(IInvocation invocation)
        {
            IClientChannel clientChannel = null;
            try
            {
                clientChannel = channelFactory.CreateChannel();
                clientChannel.Open();
                var returnValue = invocation.Method.Invoke(clientChannel, invocation.Arguments);
                invocation.ReturnValue = returnValue;
            }
            catch (FaultException faultException)
            {
                throw faultException.InnerException ?? faultException;
            }
            finally
            {
                if (clientChannel != null)
                {
                    clientChannel.CloseOrAbort();
                }
            }
        }
    }
}