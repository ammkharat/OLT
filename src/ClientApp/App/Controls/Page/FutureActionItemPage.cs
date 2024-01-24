using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class FutureActionItemPage : AbstractPage<FutureActionItemDTO, IFutureActionItemDetails>, IFutureActionItemPage
    {
        public FutureActionItemPage()
            :base(
                  new DomainSummaryGrid<FutureActionItemDTO>(new FutureActionItemGridRenderer(), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), string.Empty),
                  new FutureActionItemDetails()
                )
        {
            splitContainer.SplitterDistance = splitContainer.Height - ((FutureActionItemDetails)details).toolStrip.Height;
            splitContainer.IsSplitterFixed = true;
            splitContainer.FixedPanel = FixedPanel.Panel2;
        }

        public override PageKey PageKey
        {
            get { return PageKey.FUTURE_ACTION_ITEM_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(FutureActionItemDTO actionItem)
        {
            // TODO: this should be using CreatedUserId if it exstined on the DTO
             return (actionItem != null 
                     && actionItem.LastModifiedUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(FutureActionItemDTO actionItem)
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