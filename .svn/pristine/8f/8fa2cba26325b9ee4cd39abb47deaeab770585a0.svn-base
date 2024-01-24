using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogTemplateConfigurationFormPresenter
    {
        private readonly ILogTemplateConfigurationView view;
        private readonly ILogTemplateService logTemplateService;
        private List<LogTemplate> allLogTemplateList;                

        public LogTemplateConfigurationFormPresenter(ILogTemplateConfigurationView view)
        {
            this.view = view;
            logTemplateService = ClientServiceRegistry.Instance.GetService<ILogTemplateService>();
        }
    
        private void RefreshCategoryListFromDatabase()
        {
            allLogTemplateList = logTemplateService.QueryBySite(ClientSession.GetUserContext().Site);            
            view.LogTemplateList = allLogTemplateList;            
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            RefreshCategoryListFromDatabase();
            view.SelectFirstLogTemplate();
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            view.ShowAddEditForm(null, allLogTemplateList);
            RefreshCategoryListFromDatabase();
            view.SelectFirstLogTemplate();
        }

        public void CloseButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        public void EditButton_Click(object sender, EventArgs e)
        {            
            if (view.SelectedLogTemplate != null)
            {
                ShowEditForm(view.SelectedLogTemplate);
            }
        }

        private void ShowEditForm(LogTemplate templateToEdit)
        {
            LogTemplate itemToEdit = new LogTemplate(templateToEdit);
            LogTemplate editedItem = view.ShowAddEditForm(itemToEdit, allLogTemplateList);

            if (editedItem != null)
            {
                RefreshCategoryListFromDatabase();
                view.SelectFirstLogTemplate();
            }
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            if (view.SelectedLogTemplate != null && view.UserReallyWantsToDeleteLogTemplate())
            {
                logTemplateService.Delete(view.SelectedLogTemplate);
                RefreshCategoryListFromDatabase();
                view.SelectFirstLogTemplate();
            }
        }
     
        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Log Templates - Site: {0}", site.Id);
        }
    }
}
