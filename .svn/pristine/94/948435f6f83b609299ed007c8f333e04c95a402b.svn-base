using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class QuestionnaireConfigurationPresenter
    {
        private readonly IQuestionnaireConfigurationService questionnaireConfigurationService;
        private readonly IQuestionnaireConfigurationForm view;

        public QuestionnaireConfigurationPresenter(IQuestionnaireConfigurationForm view)
        {
            this.view = view;
            questionnaireConfigurationService =
                ClientServiceRegistry.Instance.GetService<IQuestionnaireConfigurationService>();
        }

        public void Load(object sender, EventArgs e)
        {
            ReloadGrid();
            view.SelectFirstRow();
        }

        private void ReloadGrid()
        {
            var configurations =
                questionnaireConfigurationService.QueryQuestionnaireConfigurationDtosBySiteId(
                    ClientSession.GetUserContext().SiteId);

            view.QuestionnaireConfigurationDTOs = configurations;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Questionnaire Configuration Form, Site Id: " + site.Id.Value);
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            view.LaunchEditQuestionnaireConfigurationForm(null);
            ReloadGrid();
            view.SelectFirstRow();
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            var selected = view.SelectedItem;

            if (selected != null)
            {
                var configuration =
                    questionnaireConfigurationService.QueryQuestionnaireConfigurationById(selected.Id.Value);
                view.LaunchEditQuestionnaireConfigurationForm(configuration);
                ReloadGrid();
                view.SelectFirstRow();
            }
        }

        public void RemoveButton_Click(object sender, EventArgs e)
        {
            var configurationDTO = view.SelectedItem;
            if (configurationDTO != null)
            {
                if (view.UserIsSure())
                {
                    questionnaireConfigurationService.DeleteQuestionnaireConfiguration(configurationDTO.Id.Value);
                    ReloadGrid();
                    view.SelectFirstRow();
                }
            }
        }

        public void CloseButton_Clicked(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}