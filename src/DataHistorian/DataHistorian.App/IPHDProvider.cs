using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.PlantHistorian
{
    public interface IPHDProvider : IDisposable
    {
        bool MockTagWrites { get; }
        long? SiteId { get; }
        DateTime ConfigurationLastModified { get; }
        List<TagInfo> GetTagInfoList(string prefixCharacters);
        void UpdatePHDTagValue(TagInfo tag, decimal value, DateTime writeTime);
        bool CanWritePHDTagValue(TagInfo tag);
        decimal?[] FetchPHDTagValue(PlantHistorianOrigin origin, string tagName, DateTime[] requestedTimes);
        List<TagValue> FetchPHDTagValue(PlantHistorianOrigin origin, List<string> tagList, DateTime requestedTime);
        decimal? FetchDeviationTagValue(string tagName, DateTime fromDateTime, DateTime toDateTime);
        List<TagValue> FetchLabAlertTagValues(string tagName, DateTime fromDateTime, DateTime toDateTime);
        void RemovePHDTagValue(TagInfo tag, DateTime removeTime);

        //Added by Mukesh :-RITM0238302
        void UpdatePHDTagValue(TagInfo tag, string value, DateTime writeTime);
       string TagType(TagInfo tag);
       List<TagValue> FetchAlhpaNumericPHDTagValue(PlantHistorianOrigin origin, List<string> tagList, DateTime requestedTime);
       object[] FetchAlhpaNumericPHDTagValue(PlantHistorianOrigin origin, string tagName, DateTime[] requestedTimes);
    }
}