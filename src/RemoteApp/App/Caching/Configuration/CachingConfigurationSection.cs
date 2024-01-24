using System.Configuration;

namespace Com.Suncor.Olt.Remote.Caching.Configuration
{
    public class CachingConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("IgnoreCaching")]
        public IgnoreCachingCollection IgnoreCaching
        {
            get { return ((IgnoreCachingCollection) (base["IgnoreCaching"])); }
        }
    }

    [ConfigurationCollection(typeof(DaoElement), AddItemName = "Dao")]
    public class IgnoreCachingCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DaoElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DaoElement)element).InterfaceName;
        }

        public ConfigurationElement this[int idx]
        {
            get { return (ConfigurationElement)BaseGet(idx); }
        }

    }
    public class DaoElement : ConfigurationElement
    {
        [ConfigurationProperty("InterfaceName", IsRequired = true, IsKey = true)]
        public string InterfaceName
        {
            get { return (string)this["InterfaceName"]; }
            set { this["InterfaceName"] = value; }
        }
    }

}