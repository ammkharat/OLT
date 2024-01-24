using System;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.Caching
{
    public static class CacheKeyGenerator
    {
        private const string QueryAllBySiteId = "QueryAllBySiteId";

        public static string GenerateQueryAllBySiteIdCachingKey(Type listObjectType, long key)
        {
            return GenerateQueryListByIdKey(QueryAllBySiteId, listObjectType, key);
        }

        public static string GenerateQueryListByIdKey(string prefix, Type listObjectType, long key)
        {
            return string.Format("{0}:{1}:{2}", prefix, listObjectType.Name, key);
        }

        public static string GenerateQueryByIdKey(Type objectType, long key)
        {
            return GenerateQueryByIdKey(objectType.Name, key);
        }

        public static string GenerateQueryByIdKey(string prefix, long key)
        {
            return string.Format("{0}:{1}", prefix, key);
        }

        public static string GenerateQueryKey(string prefix, object[] args)
        {
            string arguments = string.Join(":", Array.ConvertAll(args, a =>
                {
                    DomainObject domainObject = a as DomainObject;
                    return domainObject != null ? domainObject.IdValue.ToString(CultureInfo.InvariantCulture) : a.ToString();
                }));

            return string.Format("{0}:{1}", prefix, arguments);
        }

        public static string GenerateQueryByIdKey<T>(T domainObject) where T : DomainObject
        {
            return GenerateQueryByIdKey(domainObject.GetType(), domainObject.IdValue);
        }

        public static string GenerateQueryAllCachingKey(Type objectType)
        {
            return string.Format("QueryAll:{0}", objectType);
        }

        public static string GenerateQueryHistoryByIdKey<T>(T domainObjectHistory) where T: DomainObjectHistorySnapshot
        {
            return GenerateQueryHistoryByIdKey(domainObjectHistory.GetType(), domainObjectHistory.IdValue);
        }

        public static string GenerateQueryHistoryByIdKey(Type objectType, long key)
        {
            return GenerateQueryByIdKey(objectType, key);
        }
    }
}