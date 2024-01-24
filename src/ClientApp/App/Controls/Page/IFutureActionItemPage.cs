using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IFutureActionItemPage : IDomainPage<FutureActionItemDTO, IFutureActionItemDetails>
    {
        void ShowAssociatedLogForm(List<LogDTO> logDtos);
    }
}