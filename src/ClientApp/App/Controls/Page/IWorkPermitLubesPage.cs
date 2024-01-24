using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IWorkPermitLubesPage : IDomainPage<WorkPermitLubesDTO, IWorkPermitLubesDetails>
    {
        void ShowAssociatedLogForm(List<LogDTO> associatedLogDtos);
        void ShowCannotPrintMessage();
    }
}
