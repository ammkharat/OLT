using System.Configuration;

namespace Com.Suncor.Olt.Common.Domain.PlantHistorian
{
    public class PlantHistorianElement : ConfigurationElement
    {
        [ConfigurationProperty("siteId", IsRequired = true, IsKey = true)]
        public long SiteId
        {
            get { return (long) this["siteId"]; }
            set { this["siteId"] = value; }
        }

        [ConfigurationProperty("provider", IsRequired = true)]
        public string Provider
        {
            get { return (string) this["provider"]; }
            set { this["provider"] = value; }
        }

        [ConfigurationProperty("OSIConnection")]
        public OSIConnectionElement OsiConnectionElement
        {
            get { return (OSIConnectionElement) this["OSIConnection"]; }
            set { this["OSIConnection"] = value; }
        }
    }
}