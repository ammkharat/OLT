using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICustomFieldGroupConfigurationView : IBaseForm
    {
        DialogResultAndOutput<CustomFieldGroup> ShowAddEditForm(CustomFieldGroup editObject, List<CustomFieldGroup> allGroupsForSite);
        List<CustomFieldGroup> CustomFields { set; }
        CustomFieldGroup SelectedGroup { get; set; }
        bool UserReallyWantsToDelete();
        void RemoveGroup(CustomFieldGroup group);
        void RefreshView();
    }
}
