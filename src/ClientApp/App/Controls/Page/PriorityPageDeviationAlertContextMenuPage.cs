using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PriorityPageDeviationAlertContextMenuPage : DeviationAlertPage
    {
        private readonly List<DeviationAlertDTO> selectedItems;

        public PriorityPageDeviationAlertContextMenuPage(List<DeviationAlertDTO> selectedItems)
        {
            this.selectedItems = selectedItems;
        }

        public override List<DeviationAlertDTO> SelectedItems
        {
            get { return selectedItems; }
        }
    }
}