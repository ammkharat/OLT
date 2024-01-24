using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormTemplateConfigurationFormPresenter : BaseFormPresenter<IFormTemplateConfigurationView>
    {
        private readonly IFormEdmontonService formService;

        public FormTemplateConfigurationFormPresenter() : base(new FormTemplateConfigurationForm())
        {
            formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            view.Load += HandleFormLoad;
            view.EditButtonClicked += EditButtonClicked;
        }

        private void EditButtonClicked(FormTemplate formTemplate)
        {
            new EditFormTemplateFormPresenter(formTemplate).Run(view);
            
            ReloadTemplates();
            view.SelectedTemplate = formTemplate;
        }

        private void ReloadTemplates()
        {
            List<FormTemplate> formTemplates = formService.QueryFormTemplates(ClientSession.GetUserContext().SiteId);
            view.FormTemplates = formTemplates;
        }

        private void HandleFormLoad(object sender, EventArgs eventArgs)
        {
            ReloadTemplates();

            view.SelectFirstRow();
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Form Template Configuration Form - {0}", site.Id);
        }
    }
}
