using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TagInfoGroupService : ITagInfoGroupService
    {
        private readonly ITagGroupDao dao;

        public TagInfoGroupService()
        {
            dao = DaoRegistry.GetDao<ITagGroupDao>();
        }

        public TagInfoGroup Insert(TagInfoGroup tagInfoGroup)
        {
            if (dao.IsNameUniqueToSite(tagInfoGroup.Name, tagInfoGroup.Site))
                return dao.Insert(tagInfoGroup);

            throw new TagInfoGroupNameUniquenessException(tagInfoGroup.Name, tagInfoGroup.Site.Name);
        }

        public void Update(TagInfoGroup tagInfoGroup)
        {
            if (IsTagInfoGroupValid(tagInfoGroup) == false)
                throw new InconsistentTagInfoGroupDataException(tagInfoGroup);

            TagInfoGroup groupBeforeUpdate = dao.QueryById(tagInfoGroup.Id.Value);

            bool isNameUnique = true;
            if ( groupBeforeUpdate.Name != tagInfoGroup.Name)
            {
                isNameUnique = dao.IsNameUniqueToSite(tagInfoGroup.Name, tagInfoGroup.Site);
            }

            if ( isNameUnique )
                dao.Update(tagInfoGroup);
            else
                throw new TagInfoGroupNameUniquenessException(tagInfoGroup.Name, tagInfoGroup.Site.Name);
        }

        public void Remove(TagInfoGroup tagInfoGroup)
        {
            dao.Remove(tagInfoGroup);
        }

        public bool IsNameUniqueToSite(string name, Site site)
        {
            return dao.IsNameUniqueToSite(name, site);
        }

        public List<TagInfoGroup> QueryTagInfoGroupListBySite(Site site)
        {
            return dao.QueryTagInfoGroupListBySite(site);
        }

        private static bool IsTagInfoGroupValid(TagInfoGroup tagInfoGroup)
        {
            Site groupSite = tagInfoGroup.Site;
            foreach(TagInfo tagInfo in tagInfoGroup.TagInfoList)
            {
                if (groupSite.Id != tagInfo.SiteId)
                    return false;
            }
            return true;
        }
    }
}
