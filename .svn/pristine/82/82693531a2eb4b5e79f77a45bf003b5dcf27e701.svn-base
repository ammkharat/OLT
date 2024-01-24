using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.PlantHistorian
{
    public interface IPlantHistorianGateway
    {
        List<TagInfo> GetTagInfoList(Site site, string prefixCharacters);

        bool CanReadTagValue(TagInfo tagInfo);
        bool CanWriteTagValue(TagInfo tagInfo);
        void WriteTagValue(TagInfo tagInfo, decimal value);
        void WriteTagValue(TagInfo tagInfo, decimal value, DateTime writeTime);
        void RemoveTagValue(TagInfo tagInfo, DateTime removeTime);

        decimal?[] ReadTagValues(PlantHistorianOrigin origin, TagInfo tagInfo, DateTime[] readTimes);
        List<TagValue> ReadTagValues(PlantHistorianOrigin origin, List<string> tagNames, Site site, DateTime readTime);
        decimal? ReadTagValue(PlantHistorianOrigin descriptionOfOrigin, TagInfo info);
        decimal? ReadRestrictionDeviationTagValue(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime);
        List<TagValue> ReadLabAlertTagValues(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime);
        bool HasPlantHistorian(Site site);

#region Added by Mukesh :-RITM0238302

        void WriteTagValue(TagInfo tagInfo, string value, DateTime writeTime);
         string TagType(TagInfo tag);
         List<TagValue> ReadAlphaNumericTagValues(PlantHistorianOrigin origin, List<string> tagNames, Site site, DateTime readTime);
         object[] ReadAlphaNumericTagValues(PlantHistorianOrigin origin, TagInfo tagInfo, params DateTime[] readTimes);
         
#endregion
    }
}