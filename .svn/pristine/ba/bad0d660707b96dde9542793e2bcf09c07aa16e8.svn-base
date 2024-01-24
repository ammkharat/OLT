using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class Question : DomainObject, IHasDisplayOrder
    {
        public const string DISPLAY_ORDER_PROPERTY = "DisplayOrder";

        public Question(long? id, long questionnaireSectionId, long questionnaireConfigurationId, int displayOrder,
            int weight, string questionText)
        {
            this.id = id;
            QuestionnaireSectionId = questionnaireSectionId;
            QuestionnaireConfigurationId = questionnaireConfigurationId;
            DisplayOrder = displayOrder;
            Weight = weight;
            QuestionText = questionText;
        }

        public int Weight { get; set; }
        public string QuestionText { get; set; }
        public long QuestionnaireConfigurationId { get; set; }
        public long QuestionnaireSectionId { get; set; }
        public int DisplayOrder { get; set; }
    }
}