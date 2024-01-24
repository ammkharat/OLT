using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISelectHazardView : IBaseForm
    {
        event Action FormLoad;

        List<WorkPermitEdmontonHazardDTO> HazardDtos { set; }
        WorkPermitEdmontonHazardDTO SelectedItem { get; }
        bool AddHazardButtonEnabled { set; }
        event Action<WorkPermitEdmontonHazardDTO> AddHazardButtonClick;
        void SelectFirstRow();
        event Action SelectedItemChange;
    }
}
