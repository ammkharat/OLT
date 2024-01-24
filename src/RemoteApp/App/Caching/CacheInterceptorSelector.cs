using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Utility.Cache;
using Com.Suncor.Olt.Remote.Caching.Configuration;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    /// <summary>
    /// Good to put Intercept Selectors here because the result is cached.  So, this is only checked the first time the method is intercepted in the AppDomain.
    /// </summary>
    public class CacheInterceptorSelector : IInterceptorSelector
    {
        private static readonly ILog logger = LogManager.GetLogger("CachingLogger");

        private static bool isDaoTest;

        public static bool IsDaoTest
        {
            set { isDaoTest = value; }
        }

        private readonly List<string> daosToSkipCaching = new List<string>(0);

        public CacheInterceptorSelector()
        {
            AddDaosToSkipCaching();
        }

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            Type declaringType = method.DeclaringType;

            // don't use caching interceptors if this is a Dao Test
            ParameterInfo[] methodParameters = method.GetParameters();
            if (isDaoTest || ShouldSkipCaching(declaringType))
            {
                return GetNonCachingInterceptors(interceptors);
            }

            if (method.HasAttribute<CachedQueryBySiteIdAttribute>())
            {
                Type typeofList = method.ReturnType.GetGenericArguments()[0];

                if (!typeofList.GetInterfaces().Contains(typeof(ICacheBySiteId)))
                {
                    logger.WarnFormat("{0} does not implement ICacheBySiteId.  So, no way of knowing how to clear this list from the cache on Insert, Update and Delete. Therefore, not caching 'QueryBySiteId'!", typeofList.FullName);
                    return GetNonCachingInterceptors(interceptors);
                }
                return FilterOutAllCachingInterceptorsExcept<ICacheQueryAllBySiteIdInterceptor>(interceptors);
            }

            if (method.HasAttribute<CachedQueryAllAttribute>())
            {
                return FilterOutAllCachingInterceptorsExcept<ICacheQueryAllInterceptor>(interceptors);
            }

            if (method.HasAttribute<CachedQueryHistoryAttribute>())
            {
                return FilterOutAllCachingInterceptorsExcept<ICacheHistoryInterceptor>(interceptors);
            }

            if (method.HasAttribute<CachedInsertHistoryAttribute>())
            {
                return FilterOutAllCachingInterceptorsExcept<ICacheInsertHistoryInterceptor>(interceptors);
            }

            CachedQueryListAttribute cachedQueryListAttribute = method.GetAttribute<CachedQueryListAttribute>();
            if (cachedQueryListAttribute != null)
            {
                if (methodParameters.Length == 1 && methodParameters[0].ParameterType == typeof(long))
                {
                    return FilterOutAllCachingInterceptorsExcept<ICacheQueryListByIdInterceptor>(interceptors);
                }
                if (!string.IsNullOrEmpty(cachedQueryListAttribute.CachePrefix))
                {
                    return FilterOutAllCachingInterceptorsExcept<ICacheQueryListInterceptor>(interceptors);
                }
                logger.ErrorFormat("No attribute property 'CachePrefix' found for method {0}.{1}.  Skipping caching of QueryList!", type.Name, method.Name);
            }

            if (method.HasAttribute<CachedInsertOrUpdateAttribute>())
            {
                if (methodParameters.Length != 1)
                {
                    logger.ErrorFormat("For Insert and Update, the method must contain only one parameter that is not an interface. Skipping caching of method {0}", method);
                }
                else
                {
                    return FilterOutAllCachingInterceptorsExcept<ICacheInsertOrUpdateInterceptor>(interceptors);
                }
            }

            if (method.HasAttribute<CachedRemoveAttribute>())
            {
                return FilterOutAllCachingInterceptorsExcept<ICacheRemoveInterceptor>(interceptors);
            }

            CachedQueryByIdAttribute cachedQueryByIdAttribute = method.GetAttribute<CachedQueryByIdAttribute>();
            if (cachedQueryByIdAttribute != null)
            {
                // these are the QueryById caches. 
                if (methodParameters.Length == 1 && methodParameters[0].ParameterType == typeof(long))
                {
                    if (!method.ReturnType.IsInterface)
                    {
                        return FilterOutAllCachingInterceptorsExcept<ICacheQueryByIdInterceptor>(interceptors);
                    }
                    if (method.ReturnType.IsInterface && declaringType.HasAttribute<CachePrefixAttribute>())
                    {
                        return FilterOutAllCachingInterceptorsExcept<ICacheQueryByIdInterceptor>(interceptors);
                    }
                    logger.ErrorFormat("No attribute 'CachePrefix' declared on the Dao interface {0}. This is required because the Return type {1} is an interface. Skipping caching of Query!", declaringType, method.ReturnType);
                }
            }

            CachedQueryAttribute cachedQueryAttribute = method.GetAttribute<CachedQueryAttribute>();
            if (cachedQueryAttribute != null)
            {
                if (!string.IsNullOrEmpty(cachedQueryAttribute.CachePrefix))
                {
                    return FilterOutAllCachingInterceptorsExcept<ICacheQueryInterceptor>(interceptors);
                }
                logger.ErrorFormat("No attribute property 'CachePrefix' found for method {0}.{1}.  Skipping caching of Query!", type.Name, method.Name);
            }

            // otherwise return the regular old Interceptors that don't include the caching interceptors.
            return GetNonCachingInterceptors(interceptors);
        }

        private static IInterceptor[] GetNonCachingInterceptors(IEnumerable<IInterceptor> interceptors)
        {
            return interceptors.Where(i => !(i is ICacheInterceptor)).ToArray();
        }

        private IInterceptor[] FilterOutAllCachingInterceptorsExcept<T>(IEnumerable<IInterceptor> interceptors) where T : class, ICacheInterceptor
        {   
            // this is the best way to do this to make sure the order of interceptors doesn't get changed.
            IInterceptor[] result = interceptors.Where(i => (i is T) || !(i is ICacheInterceptor)).ToArray();
            return result;
        }

        private void AddDaosToSkipCaching()
        {
            try
            {
                object section = ConfigurationManager.GetSection("Caching");
                if (section == null)
                {
                    logger.Info("No Section named 'Caching' found in configuration file.");
                    return;
                }

                CachingConfigurationSection cachingConfigurationSection = section as CachingConfigurationSection;
                if (cachingConfigurationSection == null)
                {
                    logger.Info("No Section named 'Caching' found in configuration file.");
                    return;
                }

                IgnoreCachingCollection ignoreCachingCollection = cachingConfigurationSection.IgnoreCaching;
                if (ignoreCachingCollection == null || ignoreCachingCollection.Count == 0)
                {
                    logger.Info("No collection 'IgnoreCaching' found in 'Caching' section. All items are marked for caching.");
                    return;
                }
                logger.InfoFormat("Found {0} items to skip caching", ignoreCachingCollection.Count);
                foreach (DaoElement daoToSkipCaching in ignoreCachingCollection)
                {
                    string interfaceName = daoToSkipCaching.InterfaceName;
                    if (!string.IsNullOrEmpty(interfaceName))
                    {
                        daosToSkipCaching.Add(interfaceName);
                        logger.InfoFormat("Skipping caching for dao named '{0}'.", interfaceName);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Could not get items to skip from the configuration with key 'CachingDaoToSkip'", e);
            }
        }

        private bool ShouldSkipCaching(Type declaringType)
        {
            return  daosToSkipCaching.Exists(dao => declaringType.Name.EndsWith(dao));
        }
    }
}