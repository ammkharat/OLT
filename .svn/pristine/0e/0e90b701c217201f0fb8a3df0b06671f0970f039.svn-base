using System.Collections.Generic;
using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;

namespace Com.Suncor.Olt.Remote.Wcf
{
    public sealed class ClientEventPushServiceRegistry
    {
        private static readonly ClientEventPushServiceRegistry instance = new ClientEventPushServiceRegistry();

        private ClientEventPushServiceRegistry()
        {
        }

        public static ClientEventPushServiceRegistry Instance
        {
            get { return instance; }
        }

        private static readonly ProxyGenerator proxyGenerator = new ProxyGenerator(new DefaultProxyBuilder(new ModuleScope(false, true)));

        private readonly object lockObject = new object();
        private readonly Dictionary<string, IChannelFactoryWrapper> clientChannelFactories = new Dictionary<string, IChannelFactoryWrapper>();

        public IEventNotificationService GetEventNotificationProxy(string clientAddress)
        {
            lock (lockObject)
            {
                if (!clientChannelFactories.ContainsKey(clientAddress))
                {
                    IChannelFactoryWrapper wrapper = new ServerClientChannelFactoryWrapper<IEventNotificationService>(clientAddress);
                    clientChannelFactories.Add(clientAddress, wrapper);
                }

                IChannelFactoryWrapper channelFactoryWrapper = clientChannelFactories[clientAddress];
                IEventNotificationService clientProxy = WrapProxyInChannelInterceptor<IEventNotificationService>(channelFactoryWrapper);
                return clientProxy;
            }
        }

        private T WrapProxyInChannelInterceptor<T>(IChannelFactoryWrapper channelFactory) where T : class
        {
            ChannelInterceptor interceptor = new ChannelInterceptor(channelFactory);
            T proxy = proxyGenerator.CreateInterfaceProxyWithoutTarget<T>(interceptor);
            return proxy;
        }

        public void CloseAll()
        {
            lock (lockObject)
            {
                List<IChannelFactoryWrapper> channelFactoryWrappers = new List<IChannelFactoryWrapper>(clientChannelFactories.Values);

                foreach (IChannelFactoryWrapper wrapper in channelFactoryWrappers)
                {
                    wrapper.Close();
                }

                clientChannelFactories.Clear();
            }
        }

        public void RemoveEventNotificationProxy(string clientAddress)
        {
            lock (lockObject)
            {
                if (clientChannelFactories.ContainsKey(clientAddress))
                {
                    IChannelFactoryWrapper channelFactoryWrapper = clientChannelFactories[clientAddress];
                    channelFactoryWrapper.Close();
                    
                    clientChannelFactories.Remove(clientAddress);
                }
            }
        }
    }
}