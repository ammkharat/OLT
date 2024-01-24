using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CustomFieldGroupConfigurationFormPresenter
    {
        private readonly ICustomFieldGroupConfigurationView view;
        private readonly ICustomFieldService customFieldService;
        private List<CustomFieldGroup> allGroups;

        public CustomFieldGroupConfigurationFormPresenter(ICustomFieldGroupConfigurationView view)
        {
            this.view = view;
            customFieldService = ClientServiceRegistry.Instance.GetService<ICustomFieldService>();
        }
    
        public void HandleLoad(object sender, EventArgs e)
        {
            RefreshList();
        }

        public void CloseButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            DialogResultAndOutput<CustomFieldGroup> result = view.ShowAddEditForm(null, allGroups);
            if (result.Result == DialogResult.OK)
            {
                RefreshList();
                view.SelectedGroup = result.Output;
            }
        }

        private void RefreshList()
        {
            // it's important to requery because editing a group actually creates a new group and soft deletes the old one
            allGroups = customFieldService.QueryBySite(ClientSession.GetUserContext().Site);
            view.CustomFields = allGroups;
        }

        public void EditButton_Click(object sender, EventArgs e)
        {            
            if (view.SelectedGroup != null)
            {
                DialogResultAndOutput<CustomFieldGroup> result = view.ShowAddEditForm(view.SelectedGroup, allGroups);
                if (result.Result == DialogResult.OK)
                {
                    RefreshList();
                    view.SelectedGroup = result.Output;
                }
            }
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            if (view.SelectedGroup != null && view.UserReallyWantsToDelete())
            {
                customFieldService.Delete(view.SelectedGroup);
                view.RemoveGroup(view.SelectedGroup);
            }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Summary Log Custom Field Group - Site: {0}", site.Id);
        }
    }
}
