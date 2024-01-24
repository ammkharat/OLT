using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ITagService
    {
        /// <summary>
        ///     Return a list of All TagInfo that meet All criterias i nthe criteria list.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [OperationContract]
        List<TagInfo> QueryTagInfoByFilter(Site site, SearchCriteria criteria);

        /// <summary>
        ///     Update the database with TagInfos with TagInfos from PlantHistorian of given site.
        /// </summary>
        [OperationContract]
        void UpdatePlantHistorianTagInfoList(Site site, string tagPrefix, List<TagInfo> phdTags);
    }
}