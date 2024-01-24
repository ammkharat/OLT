using System;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Wcf
{
    public abstract class AbstractChannelFactoryWrapper<T> : IChannelFactoryWrapper
    {
        private readonly ILog logger = GenericLogManager.GetLogger<AbstractChannelFactoryWrapper<T>>();
        private ChannelFactory<T> channelFactory;

        public void Recreate()
        {
            try
            {
                if (channelFactory != null)
                {
                    channelFactory.CloseOrAbort();
                    channelFactory.Faulted -= HandleChannelFactoryFaulted;
                }

                channelFactory = CreateChannelFactory();
                channelFactory.Faulted += HandleChannelFactoryFaulted;
            }
            catch (Exception e)
            {
                logger.Error("Unable to Reset a Channel Factory", e);
            }
        }

        public IClientChannel CreateChannel()
        {
            var channel = channelFactory.CreateChannel();
            return channel as IClientChannel;
        }

        public void Close()
        {
            try
            {
                channelFactory.CloseOrAbort();
            }
            catch (Exception e)
            {
                logger.Error("Unable to Close a channel or Channel Factory", e);
            }
        }

        protected abstract ChannelFactory<T> CreateChannelFactory();

        private void HandleChannelFactoryFaulted(object sender, EventArgs e)
        {
            LogChannelEvent("has faulted", sender);
        }

        private void LogChannelEvent(string descriptor, object sender)
        {
            try
            {
                var stackTrace = Environment.StackTrace;

                if (stackTrace.Contains("CleanupOnExit"))
                {
                    return;
                }

                var cf = (ChannelFactory) sender;
                var genericType = cf.GetType().GetGenericArguments()[0];
                logger.Warn(string.Format("The ChannelFactory {0}. Generic Type: {1}", descriptor, genericType));
                logger.Warn("Stack trace for ChannelFactory: " + stackTrace);
            }
            catch (Exception e)
            {
                logger.Error("There was an error logging a channel event.", e);
            }
        }
    }
}