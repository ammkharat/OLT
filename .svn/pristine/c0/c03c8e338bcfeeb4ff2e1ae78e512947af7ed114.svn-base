using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class QuestionnaireConfiguration : DomainObject
    {
        public const int NewVersionNumber = 1;

        public QuestionnaireConfiguration(long? id, long siteId, int version, string type, string name)
        {
            SiteId = siteId;
            Version = version;
            Type = type;
            Name = name;
            this.id = id;
        }

        public QuestionnaireConfiguration(long? id, long siteId, int version, string type, string name,
            List<QuestionnaireSection> questionnaireSections) : this(id, siteId, version, type, name)
        {
            QuestionnaireSections = questionnaireSections;
        }

        public List<QuestionnaireSection> QuestionnaireSections { get; set; }

        public List<QuestionnaireSection> SortedQuestionnaireSections
        {
            get { return QuestionnaireSections.OrderBy(section => section.DisplayOrder).ToList(); }
        }

        public long SiteId { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public int TotalWeightOfAllQuestions(QuestionnaireSection sectionToIgnore)
        {
            return
                QuestionnaireSections.Where(
                    questionnaireSection =>
                        sectionToIgnore == null || questionnaireSection.IdValue != sectionToIgnore.IdValue)
                    .Sum(questionnaireSection => questionnaireSection.Questions.Sum(question => question.Weight));
        }

        public QuestionnaireConfigurationDTO CreateDTO()
        {
            return new QuestionnaireConfigurationDTO(IdValue, Type, Name, Version);
        }
    }
}