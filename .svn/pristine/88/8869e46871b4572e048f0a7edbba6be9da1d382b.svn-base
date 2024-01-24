using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEditQuestionnaireConfigurationForm : IBaseForm
    {
        string ConfigurationName { get; }
        List<QuestionnaireSection> Sections { set; }
        QuestionnaireSection SelectedSection { get; set; }
        void ClearErrors();
        void SetNameMissingError();
        void SetErrorForDuplicateConfigurationName();
        QuestionnaireSection LaunchAddEditSectionForm(QuestionnaireSection section);
        void SetAtLeastOneSectionRequiredError();
        void SelectFirstSection();
        bool UserIsSure();
    }
}