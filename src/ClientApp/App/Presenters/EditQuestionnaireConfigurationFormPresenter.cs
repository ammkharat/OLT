using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditQuestionnaireConfigurationFormPresenter
    {
        private readonly List<QuestionnaireConfigurationDTO> allActiveConfigurationsForSite;
        private readonly QuestionnaireConfiguration editObject;

        private readonly IQuestionnaireConfigurationService questionnaireConfigurationService;
        private readonly IEditQuestionnaireConfigurationForm view;
        private List<QuestionnaireSection> sections;

        public EditQuestionnaireConfigurationFormPresenter(IEditQuestionnaireConfigurationForm view,
            QuestionnaireConfiguration editObject)
        {
            this.view = view;
            this.editObject = editObject;

            questionnaireConfigurationService =
                ClientServiceRegistry.Instance.GetService<IQuestionnaireConfigurationService>();

            allActiveConfigurationsForSite = questionnaireConfigurationService.QueryQuestionnaireConfigurationDtosBySiteId(
                ClientSession.GetUserContext().SiteId);
        }

        public void Load(object sender, EventArgs e)
        {
            sections = new List<QuestionnaireSection>();
            if (editObject != null)
            {
                sections.AddRange(editObject.QuestionnaireSections);
            }

            SortAndSetSectionsOnGrid();
            view.SelectFirstSection();
        }

        private void SortAndSetSectionsOnGrid()
        {
            DisplayOrderHelper.SortAndResetDisplayOrder(sections);
            view.Sections = sections;
        }

        public void SaveAndCloseButton_Clicked(object sender, EventArgs e)
        {
            if (ValidateViewSuccessful())
            {
                if (editObject != null)
                {
                    LoadEditObjectFromViewAndSave();
                }
                else
                {
                    CreateNewObjectFromViewAndSave();
                }

                view.Close();
            }
        }

        private void CreateNewObjectFromViewAndSave()
        {
            var name = view.ConfigurationName;
            var type = QuestionnaireConfigurationType.SafeWorkPermit.GetName();

            var configuration =
                new QuestionnaireConfiguration(null, ClientSession.GetUserContext().SiteId,
                    QuestionnaireConfiguration.NewVersionNumber, type, name, sections);

            questionnaireConfigurationService.InsertQuestionnaireConfiguration(configuration);
        }

        private void LoadEditObjectFromViewAndSave()
        {
            editObject.Name = view.ConfigurationName;
            editObject.QuestionnaireSections = sections;

            questionnaireConfigurationService.UpdateQuestionnaireConfiguration(editObject);
        }

        private bool ValidateViewSuccessful()
        {
            view.ClearErrors();
            var hasErrors = false;

            if (view.ConfigurationName.IsNullOrEmptyOrWhitespace())
            {
                view.SetNameMissingError();
                hasErrors = true;
            }
            if (
                allActiveConfigurationsForSite.Exists(
                    obj => Equals(obj.Name, view.ConfigurationName) && (editObject == null || obj.IdValue != editObject.IdValue)))
            {
                view.SetErrorForDuplicateConfigurationName();
                hasErrors = true;
            }
            if (sections.Count == 0)
            {
                view.SetAtLeastOneSectionRequiredError();
                hasErrors = true;
            }

            return !hasErrors;
        }

        public void MoveSectionUpButton_Clicked(object sender, EventArgs e)
        {
            if (sections.Count == 0)
            {
                return;
            }

            var section = view.SelectedSection;

            var index = sections.IndexOf(section);

            if (index == 0)
            {
                return;
            }

            sections.Remove(section);
            sections.Insert(index - 1, section);

            DisplayOrderHelper.ResetDisplayValues(sections);
            SortAndSetSectionsOnGrid();

            view.SelectedSection = section;
        }

        public void MoveSectionDownButton_Clicked(object sender, EventArgs e)
        {
            if (sections.Count == 0)
            {
                return;
            }

            var section = view.SelectedSection;

            var index = sections.IndexOf(section);

            if (index == sections.Count - 1)
            {
                return;
            }

            sections.Remove(section);
            sections.Insert(index + 1, section);

            DisplayOrderHelper.ResetDisplayValues(sections);
            SortAndSetSectionsOnGrid();

            view.SelectedSection = section;
        }

        public void AddSectionButton_Clicked(object sender, EventArgs e)
        {
            var newSection = view.LaunchAddEditSectionForm(null);
            if (newSection != null)
            {
                newSection.DisplayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(sections) + 1;
                sections.Add(newSection);
                UpdateSectionPercentWeighting();
                SortAndSetSectionsOnGrid();
                view.SelectedSection = newSection;
            }
        }

        public void EditSectionButton_Clicked(object sender, EventArgs e)
        {
            var selectedSection = view.SelectedSection;
            if (selectedSection != null)
            {
                view.LaunchAddEditSectionForm(selectedSection);
                UpdateSectionPercentWeighting();
                SortAndSetSectionsOnGrid();
                view.SelectedSection = selectedSection;
            }
        }

        public void DeleteSectionButton_Clicked(object sender, EventArgs e)
        {
            var selectedSection = view.SelectedSection;
            if (selectedSection != null)
            {
                if (view.UserIsSure())
                {
                    sections.Remove(selectedSection);
                    UpdateSectionPercentWeighting();
                    SortAndSetSectionsOnGrid();
                    view.SelectFirstSection();
                }
            }
        }

        private void UpdateSectionPercentWeighting()
        {
            QuestionnaireConfigurationHelper.UpdateSectionsPercentageWeighting(sections);
        }
    }
}