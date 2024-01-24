using System;
using System.Collections.Generic;
using System.ServiceModel.Description;
using Castle.DynamicProxy;

namespace Com.Suncor.Olt.Common.Wcf
{
    public abstract class AbstractServiceRegistry
    {
        private static readonly ProxyGenerator proxyGenerator =
            new ProxyGenerator(new DefaultProxyBuilder(new ModuleScope(false, true)));

        private readonly Dictionary<Type, IChannelFactoryWrapper> channelFactories =
            new Dictionary<Type, IChannelFactoryWrapper>();

        private readonly string defaultBaseAddress = WcfConfiguration.Instance.BaseAddress;
        private readonly object lockObject = new object();

        public T GetService<T>(string baseAddress) where T : class
        {
            var serviceType = typeof (T);

            lock (lockObject)
            {
                if (!channelFactories.ContainsKey(serviceType))
                {
                    IChannelFactoryWrapper channelFactoryWrapper = new ClientServerChannelFactoryWrapper<T>(
                        baseAddress, GetEndpointBehaviours());
                    channelFactories.Add(serviceType, channelFactoryWrapper);
                }

                var channelFactory = channelFactories[serviceType];
                var clientProxy = WrapProxyInChannelInterceptor<T>(channelFactory);
                clientProxy = WrapProxy(clientProxy);
                return clientProxy;
            }
        }

        public T GetService<T>() where T : class
        {
            return GetService<T>(defaultBaseAddress);
        }

        private T WrapProxyInChannelInterceptor<T>(IChannelFactoryWrapper channelFactory) where T : class
        {
            var interceptor = new ChannelInterceptor(channelFactory);
            var proxy = proxyGenerator.CreateInterfaceProxyWithoutTarget<T>(interceptor);
            return proxy;
        }

        protected virtual List<IEndpointBehavior> GetEndpointBehaviours()
        {
            return new List<IEndpointBehavior>();
        }

        protected virtual T WrapProxy<T>(T proxy)
        {
            return proxy;
        }

        /// <summary>
        ///     Used to recreate all the ChannelFactories, rather than destroy them all.
        /// </summary>
        protected void ResumeServiceChannels()
        {
            // Don't clear all the channel factories. Simply, set them to a reset state.   
            lock (lockObject)
            {
                var channelFactoryWrappers = new List<IChannelFactoryWrapper>(channelFactories.Values);
                foreach (var wrapper in channelFactoryWrappers)
                {
                    wrapper.Recreate();
                }
            }
        }

        protected void SuspendServiceChannels()
        {
            // Don't clear all the channel factories. Simply, close them for later re-use.
            lock (lockObject)
            {
                var channelFactoryWrappers = new List<IChannelFactoryWrapper>(channelFactories.Values);
                foreach (var wrapper in channelFactoryWrappers)
                {
                    wrapper.Close();
                }
            }
        }

        /// <summary>
        ///     Only use this during complete shutdown, with no intent to reuse an existing service that is Initialized.
        /// </summary>
        public virtual void CloseAll()
        {
            lock (lockObject)
            {
                var channelFactoryWrappers = new List<IChannelFactoryWrapper>(channelFactories.Values);

                foreach (var wrapper in channelFactoryWrappers)
                {
                    wrapper.Close();
                }

                channelFactories.Clear();
            }
        }
    }
}