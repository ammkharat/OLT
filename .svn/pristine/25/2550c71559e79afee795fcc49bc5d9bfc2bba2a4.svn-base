using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltPromptMessageBox : Form
    {
        private readonly int originalMessageLabelHeight;

        private OltPromptMessageBox()
        {
            InitializeComponent();
        }

        private OltPromptMessageBox(Form owner, string messagePrompt, string title, MessageBoxIcon icon,
            int maxChars, bool showOkCancelButtonsInsteadOfYesNo)
            : this()
        {
            DialogResult = DialogResult.None;

            Closing += HandleClosing;
            Disposed += HandleDisposed;

            ChooseIconForFormFromEnum(icon);

            Owner = owner;
            Text = title;

            originalMessageLabelHeight = messageLabel.Height;

            messageLabel.Text = messagePrompt;
            memoEdit.Properties.MaxLength = maxChars;

            mainPanel.Paint += HandleMainPanelPaint;

            if (showOkCancelButtonsInsteadOfYesNo)
            {
                okButton.Visible = true;
                cancelButton.Visible = true;
                yesButton.Visible = false;
                noButton.Visible = false;
            }
            else
            {
                okButton.Visible = false;
                cancelButton.Visible = false;
                yesButton.Visible = true;
                noButton.Visible = true;
            }

            okButton.Click += HandleOkClick;
            yesButton.Click += HandleYesClick;
        }

        private void HandleOkClick(object sender, EventArgs e)
        {
            DialogResult = Validate() ? DialogResult.OK : DialogResult.None;
        }

        private void HandleYesClick(object sender, EventArgs e)
        {
            DialogResult = Validate() ? DialogResult.Yes : DialogResult.None;
        }

        private bool Validate()
        {
            if (memoEdit.Text.IsNullOrEmpty())
            {
                SetErrorForDescriptionNotSet();
                return false;
            }

            return true;
        }

        public void SetErrorForDescriptionNotSet()
        {
            errorProvider.SetError(memoEdit, StringResources.FieldCannotBeEmpty);
        }

        private void HandleClosing(object sender, CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK || DialogResult == DialogResult.Yes)
            {
                e.Cancel = !Validate();
            }
            else
            {
                // Allow user to press no or cancel button or close the dialog by pressing X button
                e.Cancel = false;
            }
        }

        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        public string OutputText
        {
            get { return memoEdit.Text; }
        }

        private void HandleDisposed(object sender, EventArgs eventArgs)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            MoveItemsDownIfMessageOneIsTall();
        }

        private void MoveItemsDownIfMessageOneIsTall()
        {
            var messageOneSize = TextRenderer.MeasureText(messageLabel.Text, messageLabel.Font,
                new Size(messageLabel.Width, Int32.MaxValue), TextFormatFlags.WordBreak);

            if (messageOneSize.Height > originalMessageLabelHeight)
            {
                var difference = messageOneSize.Height - originalMessageLabelHeight;
                difference += 10;
                ClientSize = new Size(ClientSize.Width, ClientSize.Height + difference + 10);
                memoEdit.Location = new Point(memoEdit.Location.X, memoEdit.Location.Y + difference);
            }
        }

        public static DialogResult Show(Form owner, string messagePrompt, string title, MessageBoxIcon icon,
            out string userText, bool showOkCancelButtonsInsteadOfYesNo = true, int maxChars = 255)
        {
            string outputText;
            var msgBox = new OltPromptMessageBox(owner, messagePrompt, title, icon, maxChars, showOkCancelButtonsInsteadOfYesNo);
            var result = ShowMessageBox(msgBox, out outputText);
            userText = outputText;
            return result;
        }

        private static DialogResult ShowMessageBox(OltPromptMessageBox msgBox, out string outputText)
        {
            var result = msgBox.ShowDialog();
            var text = result == DialogResult.Yes || result == DialogResult.OK ? msgBox.OutputText : null;
            outputText = text;

            msgBox.Dispose();
            return result;
        }

        private void ChooseIconForFormFromEnum(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                {
                    Icon = SystemIcons.Error;
                    break;
                }
                case MessageBoxIcon.Information:
                {
                    Icon = SystemIcons.Information;
                    break;
                }
                case MessageBoxIcon.Question:
                {
                    Icon = SystemIcons.Question;
                    break;
                }
                case MessageBoxIcon.Warning:
                {
                    Icon = SystemIcons.Warning;
                    break;
                }
                default:
                {
                    Icon = SystemIcons.WinLogo;
                    break;
                }
            }
        }

        private void HandleMainPanelPaint(object sender, PaintEventArgs e)
        {
            if (Icon != null)
            {
                e.Graphics.DrawIcon(Icon, new Rectangle(panelIcon.Location, new Size(32, 32)));
            }
        }
    }
}