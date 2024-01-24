using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IQuestionnaireConfigurationForm : IBaseForm
    {
        List<QuestionnaireConfigurationDTO> QuestionnaireConfigurationDTOs { set; }
        QuestionnaireConfigurationDTO SelectedItem { get; }
        void LaunchEditQuestionnaireConfigurationForm(QuestionnaireConfiguration selected);
        void SelectFirstRow();
        bool UserIsSure();
    }
}