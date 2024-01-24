using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - not really worth caching only used by admin screens
    public interface ICustomFieldGroupDao : IDao
    {
        CustomFieldGroup QueryById(long id);
        List<CustomFieldGroup> QueryCustomFieldGroupsForActionItems();
        List<CustomFieldGroup> QueryBySite(Site site);
        CustomFieldGroup Insert(CustomFieldGroup group);
        CustomFieldGroup Update(CustomFieldGroup group);
        void Remove(CustomFieldGroup group);

        void AddFieldsToGroup(long customFieldGroupId, List<CustomField> fields);
        List<CustomFieldGroup> QueryByLogDefinitionId(long logDefinitionId);
        CustomFieldGroup QueryCustomFieldGroupByActionItemDefinitionId(long? ActionitemdefinitionId);                  //ayman custom fields DMND0010030
        CustomFieldGroup QueryCustomFieldGroupByActionItemId(long? ActionitemId);                  //ayman custom fields DMND0010030
    }
}
