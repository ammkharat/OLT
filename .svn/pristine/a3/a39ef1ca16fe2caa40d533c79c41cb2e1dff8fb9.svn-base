using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ShiftHandoverQuestionnairePagePresenter : AbstractShiftHandoverQuestionnairePagePresenter
    {
        public ShiftHandoverQuestionnairePagePresenter()  : base(new ShiftHandoverQuestionnairePage())
        {
        }

        protected override IList<ShiftHandoverQuestionnaireDTO> QueryDtos(Common.Utility.Range<Date> dateRange)
        {
            return service.QueryShiftHandoverQuestionnaireDTOsByFunctionalLocation(userContext.RootFlocSet, 
                dateRange,
                ClientSession.GetUserContext().User.Id,
                userContext.ReadableVisibilityGroupIds, ClientSession.GetUserContext().Role.IdValue);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ShiftHandovers; }
        }
    }
}