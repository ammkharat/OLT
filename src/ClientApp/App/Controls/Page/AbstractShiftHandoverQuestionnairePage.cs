using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public abstract class AbstractShiftHandoverQuestionnairePage : AbstractPage<ShiftHandoverQuestionnaireDTO, IShiftHandoverQuestionnaireDetails>, IShiftHandoverQuestionnairePage
    {
        protected AbstractShiftHandoverQuestionnairePage()
            : base(
                new DomainSummaryGrid<ShiftHandoverQuestionnaireDTO>(
                    new ShiftHandoverQuestionnaireGridRenderer(),
                    OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT),
                    string.Empty),
                new ShiftHandoverQuestionnaireDetails())
        {
        }

        protected override bool IsCreatedByCurrentUser(ShiftHandoverQuestionnaireDTO questionnaire)
        {
            return questionnaire != null && questionnaire.CreateUserId == ClientSession.GetUserContext().User.Id;
        }

        protected override bool IsUpdatedByCurrentUser(ShiftHandoverQuestionnaireDTO questionnaire)
        {
            // TODO: #1490 need to have last modified user so that we can decide to scroll to this item in the case that the user updated the item and it disappeared from the grid.
            return false;
        }
    }
}
