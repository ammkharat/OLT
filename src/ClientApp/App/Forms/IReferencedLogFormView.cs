using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IReferencedLogFormView : IBaseForm
    {
        IList<LogDTO> LogList { set; }
        bool GoToLogButtonEnabled { set; }
        LogDTO SelectedItem { get; }
        List<ItemReadBy> MarkedAsReadByList { set; }

        void SetDetails(Log item, List<CustomField> customFields);

        void HighlightSelectedLogInLogTab();
        void SelectFirstLog();
        void DisplayLogDoesNotFallWithinSelectedVisibilityGroupsError();
    }
}
