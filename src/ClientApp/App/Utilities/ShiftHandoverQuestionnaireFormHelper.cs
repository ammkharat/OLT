using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class ShiftHandoverQuestionnaireFormHelper
    {
        public static void SetAndFormatComments(ShiftHandoverQuestionnaire handover, List<HasCommentsDTO> summaryLogComments, List<HasCommentsDTO> logComments, RichTextDisplay richTextCommentDisplay)
        {
            ShiftHandoverCommentTextRenderer.ICommentsBuilder commentsBuilder =
                new ShiftHandoverCommentTextRenderer.RichTextCommentsBuilder(richTextCommentDisplay);

            ShiftHandoverCommentTextRenderer renderer = new ShiftHandoverCommentTextRenderer(commentsBuilder);
            renderer.RenderCommentText(handover, summaryLogComments, logComments);
        }

        public static bool ShowHandoverMarkedAsReadWarning(Form owner)
        {
            DialogResult result = OltMessageBox.Show(
                owner,
                StringResources.EditingItemMarkedAsReadWarning,
                StringResources.EditingItemMarkedAsReadWarning_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return DialogResult.Yes.Equals(result);
        }

        public static bool ConfirmDeleteExistingAnswers(Form owner)
        {
            DialogResult result = OltMessageBox.Show(
                owner,
                StringResources.ShiftHandoverQuestionnaireForm_TypeChangeWarningText,
                StringResources.ShiftHandoverQuestionnaireForm_TypeChangeWarningTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        public static void ShowNoConfigurationMessageBox(Form owner)
        {
            OltMessageBox.Show(
                owner,
                StringResources.ShiftHandoverNotConfiguredMessageBoxText,
                StringResources.ShiftHandoverNotConfiguredMessageBoxCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                ContentAlignment.MiddleLeft);
        }
    }
}
