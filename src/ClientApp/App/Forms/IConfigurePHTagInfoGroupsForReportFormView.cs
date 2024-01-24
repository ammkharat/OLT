using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigurePHTagInfoGroupsForReportFormView
    {
        string SiteName { set; }
        List<TagInfoGroup> TagInfoGroupList { get; set; }
        bool EditButtonEnabled { set; }
        bool DeleteButtonEnabled { set; }

        DialogResult AddNewTagInfoGroup();
        TagInfoGroup GetSelectedTagInfoGroup();
        TagInfoGroup ShowTagInfoGroupForm(TagInfoGroup tagInfoGroupToBeEdited);

        bool ConfirmTagInfoGroupDeletion();
        void Close();
    }
}
