using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMontrealTemplateConfigurationFormPresenter
    {
        private readonly IWorkPermitMontrealTemplateConfigurationView view;
        private readonly IWorkPermitMontrealTemplateService workPermitMontrealTemplateService;
        private List<WorkPermitMontrealTemplate> allWorkPermitMontrealTemplates;

        public WorkPermitMontrealTemplateConfigurationFormPresenter(IWorkPermitMontrealTemplateConfigurationView view)
        {
            this.view = view;
            workPermitMontrealTemplateService = ClientServiceRegistry.Instance.GetService<IWorkPermitMontrealTemplateService>();
        }
    
        private void RefreshCategoryListFromDatabase()
        {
            allWorkPermitMontrealTemplates = workPermitMontrealTemplateService.QueryAllNotDeleted();            
            view.WorkPermitMontrealTemplateList = allWorkPermitMontrealTemplates;            
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            RefreshCategoryListFromDatabase();
            view.SelectFirstWorkPermitMontrealTemplate();
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            WorkPermitMontrealTemplateFormPresenter workPermitMontrealTemplateFormPresenter = new WorkPermitMontrealTemplateFormPresenter();
            workPermitMontrealTemplateFormPresenter.Run(view);

            RefreshCategoryListFromDatabase();
            view.SelectFirstWorkPermitMontrealTemplate();
        }

        public void CloseButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        public void EditButton_Click(object sender, EventArgs e)
        {            
            if (view.SelectedWorkPermitMontrealTemplate != null)
            {
                ShowEditForm(view.SelectedWorkPermitMontrealTemplate);
            }
        }

        private void ShowEditForm(WorkPermitMontrealTemplate templateToEdit)
        {
            WorkPermitMontrealTemplateFormPresenter workPermitMontrealTemplateFormPresenter = new WorkPermitMontrealTemplateFormPresenter(templateToEdit);
            workPermitMontrealTemplateFormPresenter.Run(view);

            RefreshCategoryListFromDatabase();
            view.SelectedWorkPermitMontrealTemplate = templateToEdit;
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            if (view.SelectedWorkPermitMontrealTemplate != null && view.UserReallyWantsToDeleteWorkPermitMontrealTemplate())
            {
                workPermitMontrealTemplateService.Delete(view.SelectedWorkPermitMontrealTemplate);
                RefreshCategoryListFromDatabase();
                view.SelectFirstWorkPermitMontrealTemplate();
            }
        }
     
        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Log Templates - Site: {0}", site.Id);
        }

        public void ActiveButton_Click(object sender, EventArgs e)
        {
            WorkPermitMontrealTemplate selectedWorkPermitMontrealTemplate = view.SelectedWorkPermitMontrealTemplate;
            if (selectedWorkPermitMontrealTemplate != null)
            {
                selectedWorkPermitMontrealTemplate.IsActive = !selectedWorkPermitMontrealTemplate.IsActive;
                workPermitMontrealTemplateService.Update(selectedWorkPermitMontrealTemplate);
                RefreshCategoryListFromDatabase();
                view.SelectedWorkPermitMontrealTemplate = selectedWorkPermitMontrealTemplate;
            }
        }
    }
}
