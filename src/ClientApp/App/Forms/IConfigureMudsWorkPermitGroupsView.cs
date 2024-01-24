using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureMudsWorkPermitGroupsView : IBaseForm
    {
        event Action MoveUpButtonClicked;
        event Action MoveDownButtonClicked;
        event Action AddButtonClicked;
        event Action DeleteButtonClicked;
        event Action EditButtonClicked;
        event Action SaveButtonClicked;
        event Action CancelButtonClicked;

        List<WorkPermitMudsGroup> Groups { get; set; }
        WorkPermitMudsGroup Selected { get; set; }
        void SelectFirstRow();
        void DisableView();
        void EnableView();
        void RefreshGrid();
    }
}
