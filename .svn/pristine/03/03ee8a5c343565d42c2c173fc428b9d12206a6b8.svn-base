using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class ActionItemPage : AbstractPage<ActionItemDTO, IActionItemDetails>, IActionItemPage
    {
        public ActionItemPage()
            :base(
                  new DomainSummaryGrid<ActionItemDTO>(new ActionItemGridRenderer(), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), string.Empty),
                  new ActionItemDetails()
                )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.ACTION_ITEM_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(ActionItemDTO actionItem)
        {
            // TODO: this should be using CreatedUserId if it exstined on the DTO
             return (actionItem != null 
                     && actionItem.LastModifiedUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(ActionItemDTO actionItem)
        {
            return (actionItem != null
                    && actionItem.LastModifiedUserId == ClientSession.GetUserContext().User.Id);
        }

        public void ShowAssociatedLogForm(List<LogDTO> logDtos)
        {
            ReferencedLogForm form = new ReferencedLogForm(logDtos, MainParentForm);
            form.SetTitle(StringResources.AssociatedLogsPageTitle);
            form.ShowDialog(this);
        }        
    }
}