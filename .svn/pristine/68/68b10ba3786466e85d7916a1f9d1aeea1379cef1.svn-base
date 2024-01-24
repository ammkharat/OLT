using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltChooseFromAListMessageBox : Form
    {
        private readonly int originalMessageLabelHeight;

        private OltChooseFromAListMessageBox()
        {
            InitializeComponent();
        }

        private OltChooseFromAListMessageBox(Form owner, string messagePrompt, string title, MessageBoxIcon icon,
            List<string> choices)
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
            shiftComboBox.DataSource = choices;
            mainPanel.Paint += HandleMainPanelPaint;

            okButton.Click += HandleOkClick;
        }

        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        public string OutputText
        {
            get {

                return shiftComboBox.SelectedItem.ToString(); 
            }
        }

        private void HandleOkClick(object sender, EventArgs e)
        {
            DialogResult = Validate() ? DialogResult.OK : DialogResult.None;
        }


        private bool Validate()
        {
            return true;
        }

        public void SetErrorForDescriptionNotSet()
        {
            errorProvider.SetError(shiftComboBox, StringResources.FieldCannotBeEmpty);
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
                shiftComboBox.Location = new Point(shiftComboBox.Location.X, shiftComboBox.Location.Y + difference);
            }
        }

        public static DialogResult Show(Form owner, string messagePrompt, string title, List<string> choices,
            MessageBoxIcon icon,
            out string userText)
        {
            string outputText;
            var msgBox = new OltChooseFromAListMessageBox(owner, messagePrompt, title, icon, choices);
            var result = ShowMessageBox(msgBox, out outputText);
            userText = outputText;
            return result;
        }

        private static DialogResult ShowMessageBox(OltChooseFromAListMessageBox msgBox, out string outputText)
        {
            var result = msgBox.ShowDialog();
            var text = result == DialogResult.OK ? msgBox.OutputText : null;
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