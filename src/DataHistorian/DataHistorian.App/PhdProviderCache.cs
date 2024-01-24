using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.PlantHistorian
{
    public class PhdProviderCache
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<PhdProviderCache>();

        private static readonly object syncRoot = new object();

        private static IDictionary<long, CachedProvider> honeywellProviders;
        private readonly IHoneywellPhdConfigurationService honeywellPhdConfigurationService;

        public PhdProviderCache(IHoneywellPhdConfigurationService honeywellPhdConfigurationService)
        {
            this.honeywellPhdConfigurationService = honeywellPhdConfigurationService;
            honeywellProviders = new Dictionary<long, CachedProvider>();
        }


        public bool ConfigurationExistsForProvider(long siteId)
        {
            lock (syncRoot)
            {
                return honeywellProviders.Any(pair => pair.Value.SiteId == siteId) ||
                       honeywellPhdConfigurationService.QueryAll()
                           .Exists(connectionInfo => connectionInfo.SiteId == siteId);
            }
        }

        public void CleanUpProviders()
        {
            lock (syncRoot)
            {
                foreach (var cachedProvider in honeywellProviders.Values)
                {
                    cachedProvider.Dispose();
                }
            }
        }

        public List<IPHDProvider> GetProvidersForSite(long siteId)
        {
            var allProvidersForSite = new List<IPHDProvider>();

            foreach (
                var connectionInfo in honeywellPhdConfigurationService.QueryAll().Where(info => info.SiteId == siteId))
            {
                allProvidersForSite.Add(Get(connectionInfo.Id));
            }


            if (allProvidersForSite.Count == 0)
            {
                throw new MissingPHDConnectionException("PHD or PI Provider does not exist for SiteId: " + siteId);
            }

            return allProvidersForSite;
        }

        public IPHDProvider Get(long scadaConnectionInfoId)
        {
            lock (syncRoot)
            {
                if (honeywellProviders.ContainsKey(scadaConnectionInfoId))
                {
                    var cachedProvider = honeywellProviders[scadaConnectionInfoId];

                    if (cachedProvider.IsStale)   //ayman pi change
                    {
                        var connectionInfo =
                            honeywellPhdConfigurationService.QueryByScadaConnectionInfoId(scadaConnectionInfoId);
                        if (connectionInfo.LastModifiedDateTime > cachedProvider.Provider.ConfigurationLastModified)
                        {
                            logger.DebugFormat(
                                "Provider for ScadaConnectionInfoId {0} was stale, and there is a new version in db now. Updating to it.",
                                scadaConnectionInfoId);
                            // there is a new version of the Phd Connection Info. So clean up the existing one and create a new one.
                            cachedProvider.Dispose();
                            if (connectionInfo.ScadaConnectionType == ScadaConnectionType.PhdConnection)
                            {
                                cachedProvider = new CachedProvider(new HoneywellPHDProvider(connectionInfo));
                            }
                        }
                        // always replace these when stale every 10 mins by default or appconfig's value of HoneywellPhdConfigurationCacheMinutes, 
                        // they drop connections and don't report as dropped 
                        if (connectionInfo.ScadaConnectionType == ScadaConnectionType.PiConnection)
                        {
                            cachedProvider.Dispose();
                            var osiPiConnectionInfo = new OSIPiConnectionInfo(connectionInfo);
                            cachedProvider = new CachedProvider(new OSIPIPHDProvider(osiPiConnectionInfo));
                        }
                        honeywellProviders[scadaConnectionInfoId] = cachedProvider;
                    }
                    return cachedProvider.Provider;
                }
            }

            var newConnectionInfo =
                honeywellPhdConfigurationService.QueryByScadaConnectionInfoId(scadaConnectionInfoId);
            if (newConnectionInfo == null)
            {
                throw new MissingPHDConnectionException(
                    "PHD or PI Provider does not exist for ScadaConnectionInfoId: " +
                    scadaConnectionInfoId);
            }
            CachedProvider newCachedProvider = null;
            if (newConnectionInfo.ScadaConnectionType == ScadaConnectionType.PhdConnection)
            {
                var honeywellPHDProvider = new HoneywellPHDProvider(newConnectionInfo);
                newCachedProvider = new CachedProvider(honeywellPHDProvider);
            }
            else
            {
                var osiPiConnectionInfo = new OSIPiConnectionInfo(newConnectionInfo);
                newCachedProvider = new CachedProvider(new OSIPIPHDProvider(osiPiConnectionInfo));
            }

            honeywellProviders[scadaConnectionInfoId] = newCachedProvider;
            return newCachedProvider.Provider;
        }
    }

    internal class CachedProvider : IDisposable
    {
        private readonly int cachingMinutes;

        internal CachedProvider(IPHDProvider provider)
        {
            cachingMinutes = Constants.HoneywellPhdConfigurationCacheMinutes;
            CachedDateTime = DateTime.Now;
            SiteId = provider.SiteId;
            Provider = provider;
        }

        public long? SiteId { get; set; }

        private DateTime CachedDateTime { get; set; }
        internal IPHDProvider Provider { get; private set; }

        internal bool IsStale
        {
            get { return CachedDateTime.AddMinutes(cachingMinutes) < DateTime.Now; }
        }


        public void Dispose()
        {
            if (Provider != null)
            {
                Provider.Dispose();
                Provider = null;
            }
        }
    }
}

