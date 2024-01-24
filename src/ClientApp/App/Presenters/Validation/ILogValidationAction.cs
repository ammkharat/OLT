using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface ILogValidationAction : ICustomFieldValidationAction
    {
        void ClearLogValidationErrorProviders();
        List<FunctionalLocation> FunctionalLocations { get; }
        Time ActualLoggedTime { get; }
        DateTime LogDateTime { get; }
        bool IsCommentEmpty { get; }
        void SetLogDateTimeError();
        void SetLogTimeInTheFutureError();
        void SetFunctionLocationBlankError();
        void SetCommentsBlankError();
    }
}
