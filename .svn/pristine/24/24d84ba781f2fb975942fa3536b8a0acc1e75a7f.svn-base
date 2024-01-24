using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface IShiftHandoverQuestionnaireValidationAction
    {
        void ClearShiftQuestionnaireErrorProviders();

        List<FunctionalLocation> FunctionalLocations { get; }
        bool HasAnsweredYesNo(ShiftHandoverAnswer answer);
        bool? YesNoAnswer(ShiftHandoverAnswer answer);
        string GetAnswerComments(ShiftHandoverAnswer answer);
        bool GetAnswerCommentEnabled(ShiftHandoverAnswer answer);//Added by ppanigrahi
        void SetFunctionLocationBlankError();
        void SetAnswerCommentsError(ShiftHandoverAnswer answer);
        void SetYesNoError(ShiftHandoverAnswer answer);
        void SetFlexibleShiftDateError(string errorToBeDisplayed);


    }
}
