using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PriorityPageLabAlertContextMenuPage : LabAlertPage
    {
        private readonly List<LabAlertDTO> selectedItems;

        public PriorityPageLabAlertContextMenuPage(List<LabAlertDTO> selectedItems)
        {
            this.selectedItems = selectedItems;
        }

        public override List<LabAlertDTO> SelectedItems
        {
            get { return selectedItems; }
        }
    }
}