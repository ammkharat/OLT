using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditQuestionnaireSectionForm : IBaseForm
    {
        QuestionnaireSection Section { set; }
        string SectionName { get; }
        string PercentageWeight { set; }
        List<Question> Questions { set; }
        Question SelectedQuestion { get; set; }
        void ClearErrors();
        void SetNameMissingError();
        Question LaunchAddEditQuestionForm(QuestionnaireSection section, Question question);
        void SetAtLeastOneQuestionRequiredError();
        void SelectFirstQuestion();
        bool UserIsSure();
    }
}