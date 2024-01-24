using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IThreadedItemsPage
    {       
        bool ShowLogThread { get; set; }
        void SelectThreadItem(IThreadableDTO logDTO);
        void SetIsParentMissing(bool isMissing);

        IThreadableDTO FirstSelectedThreadableItem { get; }
        List<IThreadableDTO> ThreadableItems { get; }

        IThreadedItemDetails ThreadedItemDetails { get; }
    }
}
