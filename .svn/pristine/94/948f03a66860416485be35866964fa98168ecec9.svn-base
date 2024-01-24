using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITagDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(TagInfo tagInfo);

        [CachedRemove(false, false)]
        void Remove(TagInfo tagInfo);

        [CachedInsertOrUpdate(false, false)]
        void Update(TagInfo tagInfo);

        List<TagInfo> QueryTagInfoByFilter(Site site, SearchCriteria criteria);

        [CachedQueryById]
        TagInfo QueryById(long id);

        List<TagInfo> QueryBySiteIdAndPrefixCharacterIncludeDeleted(long siteId, string prefixCharacters);
        List<TagInfo> QueryByTagGroupId(long tagGroupId);
    }
}