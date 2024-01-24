using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigurationVisibilityGroupsFormPresenter
    {
        private readonly IConfigureVisibilityGroupsView view;
        private readonly IVisibilityGroupService visibilityGroupService;
        private readonly Site site;

        public ConfigurationVisibilityGroupsFormPresenter(IConfigureVisibilityGroupsView view)
        {
            this.view = view;
            site = ClientSession.GetUserContext().Site;
            visibilityGroupService = ClientServiceRegistry.Instance.GetService<IVisibilityGroupService>();
        }

        public void HandleNewVisibilityGroupClick(object sender, EventArgs e)
        {
            List<VisibilityGroup> visibilityGroups = visibilityGroupService.QueryAll(site);
            AddVisibilityGroupForm form = new AddVisibilityGroupForm(visibilityGroups);
            
            form.ShowDialog();
            if (!form.ShouldAddOrUpdate)
            {
                return;
            }

            string nameOfNewVisibilityGroup = form.NameOfNewVisibilityGroup;
            VisibilityGroup visibilityGroup = new VisibilityGroup(null, nameOfNewVisibilityGroup, site.IdValue, false);

            visibilityGroupService.Insert(visibilityGroup);

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            List<VisibilityGroup> visibilityGroups = visibilityGroupService.QueryAll(site);
            view.VisibilityGroups = visibilityGroups;
        }

        public void HandleEditVisibilityGroupClick(object sender, EventArgs e)
        {
            VisibilityGroup selectedVisibilityGroup = view.SelectedVisibilityGroup;
            if (selectedVisibilityGroup == null)
            {
                OltMessageBox.ShowError(StringResources.VisibilityGroupNotSelectedForEditError);
                return;
            }

            List<VisibilityGroup> visibilityGroups = visibilityGroupService.QueryAll(site);

            AddVisibilityGroupForm form = new AddVisibilityGroupForm(visibilityGroups, selectedVisibilityGroup);

            form.ShowDialog();
            
            if (!form.ShouldAddOrUpdate)
            {
                return;
            }

            string nameOfNewVisibilityGroup = form.NameOfNewVisibilityGroup;
            selectedVisibilityGroup.Name = nameOfNewVisibilityGroup;
            visibilityGroupService.Update(selectedVisibilityGroup);

            RefreshGrid();
        }

        public void HandleDeleteVisibilityGroupClick(object sender, EventArgs e)
        {
            VisibilityGroup selectedVisibilityGroup = view.SelectedVisibilityGroup;
            if (selectedVisibilityGroup == null)
            {
                OltMessageBox.ShowError(StringResources.VisibilityGroupNotSelectedForDeletionError);
                return;
            }

            if (selectedVisibilityGroup.IsSiteDefault)
            {
                string format = StringResources.VisibilityGroupCannotDeleteDefault;
                string formatedMessage = string.Format(format, selectedVisibilityGroup.Name);
                OltMessageBox.ShowError(formatedMessage);
                return; 
            }
            
            if (visibilityGroupService.IsAssociatedToWorkAssignmentsWithWrite(selectedVisibilityGroup))
            {
                OltMessageBox.ShowError(StringResources.VisibilityGroupAssociatedToWorkAssignmentsAsAssignedToError);
                return;
            }

            if (visibilityGroupService.IsAssociatedToWorkAssignmentsWithRead(selectedVisibilityGroup))
            {
                DialogResult dialogResult = OltMessageBox.ShowCustomYesNo(StringResources.VisibilityGroupAssociatedToWorkAssignmentsWarning);

                if (DialogResult.Yes != dialogResult)
                {
                    return;
                }
            }

            visibilityGroupService.Remove(selectedVisibilityGroup);
            RefreshGrid();
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}