using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class ActionItemDefinitionPage : AbstractPage<ActionItemDefinitionDTO, IActionItemDefinitionDetails>, IActionItemDefinitionPage
    {
        public ActionItemDefinitionPage()
            :base
                (
                new DomainSummaryGrid<ActionItemDefinitionDTO>(new ActionItemDefinitionGridRenderer(), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), string.Empty),
                new ActionItemDefinitionDetails()
                )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.ACTION_ITEM_DEFINITION_PAGE; }
        }

        public void ShowAssociatedLogForm(List<LogDTO> logDtos)
        {
            ReferencedLogForm form = new ReferencedLogForm(logDtos, MainParentForm);
            form.SetTitle(StringResources.AssociatedLogsPageTitle);
            form.ShowDialog(this);
        }

        protected override bool IsCreatedByCurrentUser(ActionItemDefinitionDTO actionItemDefinition)
        {
            // TODO: this should be using CreatedUserId if it exstined on the DTO
            return (actionItemDefinition != null 
                    && actionItemDefinition.LastModifiedUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(ActionItemDefinitionDTO actionItemDefinition)
        {
            return (actionItemDefinition != null
                    && actionItemDefinition.LastModifiedUserId == ClientSession.GetUserContext().User.Id);
        }
        
        public bool ShouldClearCurrentActionItemsForDefinitionUpdate
        {
            get
            {
                DialogResult result = OltMessageBox.Show(
                    ParentForm, 
                    StringResources.ClearCurrentActionItemsForDefinitionUpdate,
                    StringResources.ClearCurrentActionItemsForDefinitionUpdateTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                return result == DialogResult.Yes;
            }
        }
    }
}