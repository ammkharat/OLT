using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{   
    public class TargetDefinitionPage : AbstractPage<TargetDefinitionDTO, ITargetDefinitionDetails>,
                                        ITargetDefinitionPage
    {
        public TargetDefinitionPage()
            :
                base
                (
                new DomainSummaryGrid<TargetDefinitionDTO>(new TargetDefinitionGridRenderer(),
                                                           OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), string.Empty),
                new TargetDefinitionDetails()
                )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.TARGET_DEFINITION_PAGE; }
        }

        public void DisplayTargetDeleteDeniedMessage(List<string> parentTargetNames)
        {
            string messageBoxText = StringResources.TargetDefinitionForm_DeleteDeniedMessageBoxText.AppendSpace();

            OltMessageBox.Show(Form.ActiveForm,
                               messageBoxText + parentTargetNames.BuildCommaSeparatedList(), 
                               StringResources.DeleteDeniedTitle,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
        }

        public void DisplayTargetDeleteDeniedMessageCausedByExistingActionItemDefinition(List<string> actionItemDefinitionNames)
        {
            StringBuilder message = new StringBuilder();

            string messageBoxText = StringResources.TargetDefinitionForm_DeleteDeniedDueToExistingActionItemMessageBoxText.AppendSpace();

            message.AppendLine(messageBoxText);
            message.AppendLine();

            foreach (string definition in actionItemDefinitionNames)
            {
                message.AppendLine(definition);
            }

            OltMessageBox.Show(Form.ActiveForm, message.ToString(), StringResources.DeleteDeniedTitle, MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
        }

        public void DisplayActionItemDefinitionForm(ActionItemDefinition actionItemDefinition)
        {            
            var actionItemDefinitionForm = new ActionItemDefinitionForm(actionItemDefinition);
            actionItemDefinitionForm.ShowDialog(ParentForm);
        }

        protected override bool IsCreatedByCurrentUser(TargetDefinitionDTO targetDefinition)
        {
            // TODO: This should actually be Created By User Id
            return targetDefinition != null 
                   && targetDefinition.LastModifiedUserId ==ClientSession.GetUserContext().User.Id;
        }

        protected override bool IsUpdatedByCurrentUser(TargetDefinitionDTO targetDefinition)
        {
            return targetDefinition != null
                   && targetDefinition.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

    }
}