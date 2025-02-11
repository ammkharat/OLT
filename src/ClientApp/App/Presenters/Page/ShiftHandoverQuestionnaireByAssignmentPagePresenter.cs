﻿using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ShiftHandoverQuestionnaireByAssignmentPagePresenter : AbstractShiftHandoverQuestionnairePagePresenter
    {
        public ShiftHandoverQuestionnaireByAssignmentPagePresenter() : base(new ShiftHandoverQuestionnaireByAssignmentPage())
        {
        }

        protected override IList<ShiftHandoverQuestionnaireDTO> QueryDtos(Range<Date> dateRange)
        {
            UserContext context = ClientSession.GetUserContext();
            return service.QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment(context.RootFlocSet,
                context.WorkAssignmentId,
                dateRange,
                context.User.Id,
                context.ReadableVisibilityGroupIds,context.Role.IdValue);
        }

        protected override bool ShouldBeDisplayed(ShiftHandoverQuestionnaire questionnaire)
        {
            return userContext.HasSameAssignment(questionnaire.Assignment);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ShiftHandoversByAssignment; }
        }
    }
}