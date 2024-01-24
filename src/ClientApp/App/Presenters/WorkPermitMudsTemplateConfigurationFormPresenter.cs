using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMudsTemplateConfigurationFormPresenter
    {
        private readonly IWorkPermitMudsTemplateConfigurationView view;
        private readonly IWorkPermitMudsTemplateService workPermitMudsTemplateService;
        private List<WorkPermitMudsTemplate> allWorkPermitMudsTemplates;

        public WorkPermitMudsTemplateConfigurationFormPresenter(IWorkPermitMudsTemplateConfigurationView view)
        {
            this.view = view;
            workPermitMudsTemplateService = ClientServiceRegistry.Instance.GetService<IWorkPermitMudsTemplateService>();
        }
    
        private void RefreshCategoryListFromDatabase()
        {
            allWorkPermitMudsTemplates = workPermitMudsTemplateService.QueryAllNotDeleted();            
            view.WorkPermitMudsTemplateList = allWorkPermitMudsTemplates;            
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            RefreshCategoryListFromDatabase();
            view.SelectFirstWorkPermitMudsTemplate();
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            WorkPermitMudsTemplateFormPresenter workPermitMudsTemplateFormPresenter = new WorkPermitMudsTemplateFormPresenter();
            workPermitMudsTemplateFormPresenter.Run(view);

            RefreshCategoryListFromDatabase();
            view.SelectFirstWorkPermitMudsTemplate();
        }

        public void CloseButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        public void EditButton_Click(object sender, EventArgs e)
        {            
            if (view.SelectedWorkPermitMudsTemplate != null)
            {
                ShowEditForm(view.SelectedWorkPermitMudsTemplate);
            }
        }

        private void ShowEditForm(WorkPermitMudsTemplate templateToEdit)
        {
            WorkPermitMudsTemplateFormPresenter workPermitMudsTemplateFormPresenter = new WorkPermitMudsTemplateFormPresenter(templateToEdit);
            workPermitMudsTemplateFormPresenter.Run(view);

            RefreshCategoryListFromDatabase();
            view.SelectedWorkPermitMudsTemplate = templateToEdit;
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            if (view.SelectedWorkPermitMudsTemplate != null && view.UserReallyWantsToDeleteWorkPermitMudsTemplate())
            {
                workPermitMudsTemplateService.Delete(view.SelectedWorkPermitMudsTemplate);
                RefreshCategoryListFromDatabase();
                view.SelectFirstWorkPermitMudsTemplate();
            }
        }
     
        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Log Templates - Site: {0}", site.Id);
        }

        public void ActiveButton_Click(object sender, EventArgs e)
        {
            WorkPermitMudsTemplate selectedWorkPermitMudsTemplate = view.SelectedWorkPermitMudsTemplate;
            if (selectedWorkPermitMudsTemplate != null)
            {
                selectedWorkPermitMudsTemplate.IsActive = !selectedWorkPermitMudsTemplate.IsActive;
                workPermitMudsTemplateService.Update(selectedWorkPermitMudsTemplate);
                RefreshCategoryListFromDatabase();
                view.SelectedWorkPermitMudsTemplate = selectedWorkPermitMudsTemplate;
            }
        }
    }
}
