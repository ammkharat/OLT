using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - change service to get the list by custom field id, change delete to pass a CustomFieldDropDownValue, and then find way to clear the list cache.
    public interface ICustomFieldDropDownValueDao : IDao
    {
        List<CustomFieldDropDownValue> QueryByCustomFieldId(long? customFieldId);
        List<string> QueryByCustomFieldIdForReading(long? customFieldId);                //ayman action item reading
        void Insert(CustomFieldDropDownValue customFieldDropDownValue);
        void DeleteByCustomFieldId(long id);
    }
}
