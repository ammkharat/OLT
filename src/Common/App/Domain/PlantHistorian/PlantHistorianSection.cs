using System.Configuration;

namespace Com.Suncor.Olt.Common.Domain.PlantHistorian
{
    public class PlantHistorianSection : ConfigurationSection
    {
        [ConfigurationProperty("PlantHistorians")]
        public PlantHistoriansCollection PlantHistorians
        {
            get { return ((PlantHistoriansCollection) (base["PlantHistorians"])); }
        }
    }
}