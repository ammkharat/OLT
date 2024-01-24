using System.Configuration;

namespace Com.Suncor.Olt.Common.Domain.PlantHistorian
{
    [ConfigurationCollection(typeof (PlantHistorianElement), AddItemName = "PlantHistorian")]
    public class PlantHistoriansCollection : ConfigurationElementCollection
    {
        public PlantHistorianElement this[int idx]
        {
            get { return (PlantHistorianElement) BaseGet(idx); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PlantHistorianElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PlantHistorianElement) element).SiteId;
        }

        public PlantHistorianElement GetBySiteId(long id)
        {
            return (PlantHistorianElement) BaseGet(id);
        }
    }
}