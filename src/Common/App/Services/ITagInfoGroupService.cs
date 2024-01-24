using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ITagInfoGroupService
    {
        [OperationContract]
        TagInfoGroup Insert(TagInfoGroup tagInfoGroup);

        [OperationContract]
        void Update(TagInfoGroup tagInfoGroup);

        [OperationContract]
        void Remove(TagInfoGroup tagInfoGroup);

        [OperationContract]
        bool IsNameUniqueToSite(string name, Site site);

        [OperationContract]
        List<TagInfoGroup> QueryTagInfoGroupListBySite(Site site);
    }
}