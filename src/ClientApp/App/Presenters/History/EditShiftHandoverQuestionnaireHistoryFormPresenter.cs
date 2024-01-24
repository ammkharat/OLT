using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditShiftHandoverQuestionnaireHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly ShiftHandoverQuestionnaire questionnaire;

        public EditShiftHandoverQuestionnaireHistoryFormPresenter(ShiftHandoverQuestionnaire questionnaire) : base(questionnaire)
        {
            this.questionnaire = questionnaire;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_ShiftHandover; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.NotApplicable; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForShiftHandoverQuestionnaire(questionnaire.IdValue);
        }
    }
}
