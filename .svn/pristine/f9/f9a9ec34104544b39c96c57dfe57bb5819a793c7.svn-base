using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;

namespace Com.Suncor.Olt.PlantHistorian
{
    public sealed class PlantHistorianGateway : IPlantHistorianGateway
    {
        private static readonly object syncRoot = new object();
        private static PlantHistorianGateway instance;

        private readonly PhdProviderCache providerCache;

        private PlantHistorianGateway()
        {
            //            var osiPiProvidersConfigurationSection =
            //                (PlantHistorianSection) ConfigurationManager.GetSection("PlantHistorianConfiguration");
            providerCache =
                new PhdProviderCache(GenericServiceRegistry.Instance.GetService<IHoneywellPhdConfigurationService>());
        }

        public static IPlantHistorianGateway Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new PlantHistorianGateway();
                    }
                }
                return instance;
            }
        }

        public bool HasPlantHistorian(Site site)
        {
            return providerCache.ConfigurationExistsForProvider(site.IdValue);
        }

        public List<TagInfo> GetTagInfoList(Site site, string prefixCharacters)
        {
            var tagInfos = new List<TagInfo>();
            var providers = providerCache.GetProvidersForSite(site.IdValue);
            foreach (var provider in providers)
            {
                tagInfos.AddRange(provider.GetTagInfoList(prefixCharacters));
            }
            return tagInfos;
        }

        public bool CanReadTagValue(TagInfo tagInfo)
        {
            try
            {
                ReadTagValues(PlantHistorianOrigin.PlantHistorianGateway_CanReadTagValue, tagInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public decimal? ReadRestrictionDeviationTagValue(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime)
        {
            try
            {
                var provider = GetProvider(tagInfo);

                return provider.FetchDeviationTagValue(tagInfo.Name, fromDateTime, toDateTime);
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianReadException(tagInfo, new[] { fromDateTime, toDateTime }, ex);
            }
        }

        public List<TagValue> ReadLabAlertTagValues(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime)
        {
            try
            {
                var provider = GetProvider(tagInfo);
                return provider.FetchLabAlertTagValues(tagInfo.Name, fromDateTime, toDateTime);
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianReadException(tagInfo, new[] { fromDateTime, toDateTime }, ex);
            }
        }

        public List<TagValue> ReadTagValues(PlantHistorianOrigin origin, List<string> tagNames, Site site,
            DateTime readTime)
        {
            try
            {
                var tagValues = new List<TagValue>();
                var providers = providerCache.GetProvidersForSite(site.IdValue);
                foreach (var provider in providers)
                {
                    readTime = readTime.GetNetworkPortable();
                    tagValues.AddRange(provider.FetchPHDTagValue(origin, tagNames, readTime));
                }
                return tagValues;
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianReadException(tagNames, readTime, ex);
            }
        }

        public void RemoveTagValue(TagInfo tagInfo, DateTime removeTime)
        {
            try
            {
                var phdProvider = GetProvider(tagInfo);
                if (phdProvider.MockTagWrites)
                    return;

                phdProvider.RemovePHDTagValue(tagInfo, removeTime);
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianWriteException(tagInfo, null, ex);
            }
        }

        public decimal?[] ReadTagValues(PlantHistorianOrigin origin, TagInfo tagInfo, params DateTime[] readTimes)
        {
            try
            {
                var provider = GetProvider(tagInfo);
                if (readTimes.Length == 0)
                {
                    readTimes = new[] { DateTime.Now.GetNetworkPortable() };
                }
                return provider.FetchPHDTagValue(origin, tagInfo.Name, readTimes);
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianReadException(tagInfo, readTimes, ex);
            }
        }

        public decimal? ReadTagValue(PlantHistorianOrigin origin, TagInfo info)
        {
            return ReadTagValues(origin, info)[0];
        }

        public bool CanWriteTagValue(TagInfo tagInfo)
        {
            try
            {
                var provider = GetProvider(tagInfo);
                if (provider.MockTagWrites)
                    return true;
                return provider.CanWritePHDTagValue(tagInfo);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void WriteTagValue(TagInfo tagInfo, decimal value)
        {
            WriteTagValue(tagInfo, value, DateTime.Now.GetNetworkPortable());
        }

        public void WriteTagValue(TagInfo tag, decimal value, DateTime writeTime)
        {
            try
            {
                var phdProvider = GetProvider(tag);
                if (phdProvider.MockTagWrites)
                    return;

                phdProvider.UpdatePHDTagValue(tag, value, writeTime);
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianWriteException(tag, value, ex);
            }
        }

        //Added by Mukesh :-RITM0238302
        public void WriteTagValue(TagInfo tag, string value, DateTime writeTime)
        {
            try
            {
                var phdProvider = GetProvider(tag);
                if (phdProvider.MockTagWrites)
                    return;

                phdProvider.UpdatePHDTagValue(tag, value, writeTime);
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianWriteException(tag, value, ex, tag.Name);
            }
        }
#region Added by Mukesh :-RITM0238302
        public string TagType(TagInfo tag)
        {
            if (tag != null)      //added by ayman to fix crash error (the tag was null)
            {
                var phdProvider = GetProvider(tag);
                if (phdProvider.MockTagWrites)
                    return "";
                return phdProvider.TagType(tag);
            }
            else
            {
                return string.Empty;
            }

        }
      
        public List<TagValue> ReadAlphaNumericTagValues(PlantHistorianOrigin origin, List<string> tagNames, Site site,
            DateTime readTime)
        {
            try
            {
                var tagValues = new List<TagValue>();
                var providers = providerCache.GetProvidersForSite(site.IdValue);
                foreach (var provider in providers)
                {
                    readTime = readTime.GetNetworkPortable();
                    tagValues.AddRange(provider.FetchPHDTagValue(origin, tagNames, readTime));
                }
                return tagValues;
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianReadException(tagNames, readTime, ex);
            }
        }
       
      public  object[] ReadAlphaNumericTagValues(PlantHistorianOrigin origin, TagInfo tagInfo, params DateTime[] readTimes)
        {
            try
            {
                var provider = GetProvider(tagInfo);
                if (readTimes.Length == 0)
                {
                    readTimes = new[] { DateTime.Now.GetNetworkPortable() };
                }
                return provider.FetchAlhpaNumericPHDTagValue(origin, tagInfo.Name, readTimes);
            }
            catch (Exception ex)
            {
                throw new InvalidPlantHistorianReadException(tagInfo, readTimes, ex);
            }
        }
#endregion
        private IPHDProvider GetProvider(TagInfo tagInfo)
        {
            var scadaConnectionInfoId = tagInfo.ScadaConnectionInfoId;
            return scadaConnectionInfoId.HasValue
                ? providerCache.Get(scadaConnectionInfoId.Value)
                : default(IPHDProvider);
        }

        private void Clean()
        {
            providerCache.CleanUpProviders();
        }

        public static void Cleanup()
        {
            lock (syncRoot)
            {
                if (instance != null)
                {
                    instance.Clean();
                    instance = null;
                }
            }
        }

        /// <summary>
        ///     When running tests from the command line, it seems that the COM objects get disconnected after each test method
        ///     (you get the "COM object that has been separated from its underlying RCW cannot be used." error).
        ///     Use this method to reinitialize the provider connections in the gateway for testing.
        /// </summary>
        public static void ResetInstanceForTesting()
        {
            instance = null;
        }
    }
}