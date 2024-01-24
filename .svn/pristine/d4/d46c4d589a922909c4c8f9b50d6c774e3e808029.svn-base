using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigurePHTagInfoGroupsForReportFormPresenter
    {
        private readonly IConfigurePHTagInfoGroupsForReportFormView view;
        private readonly ITagInfoGroupService tagInfoGroupService;

        public ConfigurePHTagInfoGroupsForReportFormPresenter(IConfigurePHTagInfoGroupsForReportFormView view) : this(
            view,
            ClientServiceRegistry.Instance.GetService<ITagInfoGroupService>())
        {
            
        }

        public ConfigurePHTagInfoGroupsForReportFormPresenter(
            IConfigurePHTagInfoGroupsForReportFormView view,
            ITagInfoGroupService tagInfoGroupService)
        {
            this.view = view;
            this.tagInfoGroupService = tagInfoGroupService;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Plant Historian Tag List - Site: {0}", site.Id);
        }

        public void HandleLoad(object sender, EventArgs args)
        {
            Site site = ClientSession.GetUserContext().Site;
            List<TagInfoGroup> tagInfoGroupList = tagInfoGroupService.QueryTagInfoGroupListBySite(site);

            view.SiteName = site.Name;
            view.TagInfoGroupList = tagInfoGroupList;
            ControlEnablementOfButtons();
        }

        public void HandleNewButtonClick(object sender, EventArgs args)
        {
            DialogResult result = view.AddNewTagInfoGroup();
            if (result == DialogResult.OK)
            {
                view.TagInfoGroupList
                        = tagInfoGroupService.QueryTagInfoGroupListBySite(ClientSession.GetUserContext().Site);
                ControlEnablementOfButtons();
            }
        }
        public void HandleDoubleClickSelected(object sender, DomainEventArgs<TagInfoGroup> e)
        {
            EditTagInfoGroup();
        }
        public void HandleEditButtonClick(object sender, EventArgs args)
        {
            EditTagInfoGroup();
        }

        private void EditTagInfoGroup() {
            TagInfoGroup tagInfoGroupToBeEdited = view.GetSelectedTagInfoGroup();

            if ( tagInfoGroupToBeEdited != null)
            {
                TagInfoGroup tagInfoGroupAfterEditing = view.ShowTagInfoGroupForm(tagInfoGroupToBeEdited);
                List<TagInfoGroup> tagInfoGroupList = view.TagInfoGroupList;

                foreach(TagInfoGroup group in tagInfoGroupList)
                {
                    if (group.Id == tagInfoGroupAfterEditing.Id)
                    {
                        group.Name = tagInfoGroupAfterEditing.Name;
                        group.TagInfoList = tagInfoGroupAfterEditing.TagInfoList;
                        break;
                    }
                }
                view.TagInfoGroupList = tagInfoGroupList;
            }
        }

        public void HandleDeleteButtonClick(object sender, EventArgs args)
        {
            TagInfoGroup selectedGroup = view.GetSelectedTagInfoGroup();
            if (selectedGroup != null && view.ConfirmTagInfoGroupDeletion())
            {
                tagInfoGroupService.Remove(selectedGroup);
                List<TagInfoGroup> tagInfoGroupList = view.TagInfoGroupList;
                tagInfoGroupList.Remove(selectedGroup);
                view.TagInfoGroupList = tagInfoGroupList;
                ControlEnablementOfButtons();
            }
        }

        public void HandleSelectedItemChanged(object sender, EventArgs args)
        {
            ControlEnablementOfButtons();
        }

        public void HandleCloseButtonClick(object sender, EventArgs args)
        {
            view.Close();
        }

        private void ControlEnablementOfButtons()
        {
            TagInfoGroup selectedGroup = view.GetSelectedTagInfoGroup();
            bool editAndDeleteButtonsEnabled = selectedGroup != null;
            view.EditButtonEnabled = editAndDeleteButtonsEnabled;
            view.DeleteButtonEnabled = editAndDeleteButtonsEnabled;
        }

       
    }
}
