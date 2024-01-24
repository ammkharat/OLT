using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditFormTemplateFormPresenter : BaseFormPresenter<IEditFormTemplateView>
    {
        private readonly IFormEdmontonService formService;
        private readonly FormTemplate formTemplate;

        public EditFormTemplateFormPresenter(FormTemplate formTemplate) : base(new EditFormTemplateForm())
        {
            this.formTemplate = formTemplate;

            view.Load += HandleViewLoad;
            view.SaveButtonClick += HandleSaveButtonClick;
            view.CancelButtonClick += CancelButton_Click;

            formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
        }

        private void HandleViewLoad(object sender, EventArgs eventArgs)
        {
            view.Title = String.Format("Edit {0}", formTemplate.DisplayName);
            view.Template = formTemplate.Template;
        }

        private void HandleSaveButtonClick()
        {
            formTemplate.Template = view.Template;
            formService.ReplaceFormTemplate(formTemplate, ClientSession.GetUserContext().User, Clock.Now,
                ClientSession.GetUserContext().SiteId);
            CloseButton_Clicked();
        }
    }
}