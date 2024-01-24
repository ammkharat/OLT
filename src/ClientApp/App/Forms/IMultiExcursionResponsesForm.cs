using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IMultiExcursionResponsesForm : IAddEditBaseFormView
    {
        List<ExcursionResponseEditingGridRowDTO> ExcursionsToUpdate { get; set; }
        string ExcursionResponseCommentForAllExcursions { get; }
        void SetErrorForMissingResponse();
        void WarnThatSomePreviousExcursionResponsesWillBeOverwritten();

        string AssetDropdown { get; }
        string CodeDropdown { get; }
    }
}