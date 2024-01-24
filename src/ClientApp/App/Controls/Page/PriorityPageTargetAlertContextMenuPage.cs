using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PriorityPageTargetAlertContextMenuPage : TargetAlertPage
    {
        private readonly List<TargetAlertDTO> selectedItems;

        public PriorityPageTargetAlertContextMenuPage(List<TargetAlertDTO> selectedItems)
        {
            this.selectedItems = selectedItems;
        }

        public override List<TargetAlertDTO> SelectedItems
        {
            get { return selectedItems; }
        }
    }
}