using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftHandoverQuestionnaireAssociationDao : IDao
    {
        void InsertLogAssocications(ShiftHandoverQuestionnaire questionnaire);
        void InsertLogAssocications(Log log);
        void InsertSummaryLogAssocications(ShiftHandoverQuestionnaire questionnaire);
        void InsertSummaryLogAssocications(SummaryLog summaryLog);
        void UpdateSummaryLogAssociations(SummaryLog summaryLog);
    }
}