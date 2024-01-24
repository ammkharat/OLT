using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class QuestionnaireSection : DomainObject, IHasDisplayOrder
    {
        public const string DISPLAY_ORDER_PROPERTY = "DisplayOrder";

        public QuestionnaireSection(long? id, long questionnaireConfigurationId, int displayOrder,
            decimal percentageWeighting,
            string name)
        {
            this.id = id;
            QuestionnaireConfigurationId = questionnaireConfigurationId;
            DisplayOrder = displayOrder;
            PercentageWeighting = percentageWeighting;
            Name = name;
        }

        public QuestionnaireSection(long? id, long questionnaireConfigurationId, int displayOrder,
            decimal percentageWeighting,
            string name, List<Question> questions)
            : this(id, questionnaireConfigurationId, displayOrder, percentageWeighting, name)
        {
            Questions = questions;
        }

        public List<Question> Questions { get; set; }

        public List<Question> SortedQuestions
        {
            get { return Questions.OrderBy(question => question.DisplayOrder).ToList(); }
        }

        public long QuestionnaireConfigurationId { get; set; }
        public decimal PercentageWeighting { get; set; }
        public string Name { get; set; }

        public string PercentageWeightingAsString
        {
            get { return PercentageWeighting.ToString("N"); }
        }

        public int DisplayOrder { get; set; }

        public int TotalWeightOfAllQuestions()
        {
            return Questions.Sum(question => question.Weight);
        }
    }
}