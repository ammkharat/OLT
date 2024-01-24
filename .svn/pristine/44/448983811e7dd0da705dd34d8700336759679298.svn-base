using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IPlantHistorianService
    {
        [OperationContract]
        [NonTransactionalOperation]
        List<TagInfo> GetTagInfoList(Site site, string prefixCharacters);

        [OperationContract]
        [NonTransactionalOperation]
        bool CanReadTagValue(TagInfo tagInfo);

        [OperationContract]
        [NonTransactionalOperation]
        bool CanWriteTagValue(TagInfo tagInfo);

        [OperationContract]
        [NonTransactionalOperation]
        decimal?[] ReadTagValues(PlantHistorianOrigin origin, TagInfo tagInfo, params DateTime[] dateTime);

        [OperationContract(Name = "ReadMultipleTags")]
        [NonTransactionalOperation]
        List<TagValue> ReadTagValues(PlantHistorianOrigin origin, List<string> tagNames, Site site, DateTime readTime);

        [OperationContract]
        [NonTransactionalOperation]
        decimal? ReadRestrictionDeviationTagValue(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime);

        [OperationContract]
        [NonTransactionalOperation]
        List<TagValue> ReadLabAlertTagValues(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime);

        [OperationContract]
        [NonTransactionalOperation]
        bool HasPlantHistorian(Site site);

        [OperationContract]
        [NonTransactionalOperation]
        void WriteTagValue(TagInfo tagInfo, decimal value, DateTime writeTime);

        [OperationContract]
        [NonTransactionalOperation]
        void RemoveTagValue(TagInfo tagInfo, DateTime removeTime);

        [OperationContract(IsOneWay = true)]
        [NonTransactionalOperation]
        void WriteCustomFieldsToPhd(IHasCustomFieldEntries log);

        [OperationContract(IsOneWay = true)]
        [NonTransactionalOperation]
        void UpdateCustomFieldsToPhd(IHasCustomFieldEntries oldLog, IHasCustomFieldEntries newLog);

        [OperationContract(IsOneWay = true)]
        [NonTransactionalOperation]
        void RemoveCustomFieldsFromPhd(IHasCustomFieldEntries log);


        #region   //Added by Mukesh :-RITM0238302
        [OperationContract]
        string TagType(TagInfo tag);

        [OperationContract]
        [NonTransactionalOperation]
        object[] ReadAlphaNumericTagValues(PlantHistorianOrigin origin, TagInfo tagInfo, params DateTime[] dateTime);

        [OperationContract(Name = "ReadMultipleAlhaNumericTags")]
        [NonTransactionalOperation]
        List<TagValue> ReadAlphaNumericTagValues(PlantHistorianOrigin origin, List<string> tagNames, Site site, DateTime readTime);

        #endregion
    }
}