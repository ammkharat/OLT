using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITagGroupDao : IDao
    {
        TagInfoGroup Insert(TagInfoGroup newTagInfoGroup);
        TagInfoGroup QueryById(long id);
        List<TagInfoGroup> QueryTagInfoGroupListBySite(Site site);

        void Update(TagInfoGroup tagInfoGroupToBeUpdated);
        void Remove(TagInfoGroup tagInfoGroup);
        bool IsNameUniqueToSite(string name, Site site);
    }
}
