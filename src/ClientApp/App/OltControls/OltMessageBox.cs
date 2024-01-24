using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.OltControls
{
    /// <summary>
    /// Custom Message box that makes sure that buttons are aligned correctly in both Win XP and Win7.  In Windows 7, single buttons are not centered.
    /// </summary>
    public partial class OltMessageBox : Form
    {
        private static readonly string OK_STR = StringResources.OltMessageBox_OK;
        private static readonly string ABORT_STR = StringResources.OltMessageBox_Abort;
        private static readonly string RETRY_STR = StringResources.OltMessageBox_Retry;
        private static readonly string IGNORE_STR = StringResources.OltMessageBox_Ignore;
        private static readonly string CANCEL_STR = StringResources.OltMessageBox_Cancel;
        private static readonly string YES_STR = StringResources.OltMessageBox_Yes;
        private static readonly string NO_STR = StringResources.OltMessageBox_No;

        private const int BOTTOM_PADDING = 10;
        private const int SIDE_PADDING = 5;

        private readonly List<OltMessageBoxButton> buttons = new List<OltMessageBoxButton>();

        private OltMessageBox()
        {
            InitializeComponent();
        }

        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        private OltMessageBox(Form owner, MessageBoxButtons btns, MessageBoxIcon icon, string message, string title) : this()
        {
            Owner = owner;
            ChoosButtonsForFormFromEnum(btns);
            ChooseIconForFormFromEnum(icon);
            base.Text = title;
            msgLabel.Font = new Font(FontFamily.GenericSansSerif, 10);
            msgLabel.Text = message;
            LayoutControls();
        }

        private void ChoosButtonsForFormFromEnum(MessageBoxButtons btns)
        {
            buttons.Clear();
            switch (btns)
            {
                case MessageBoxButtons.OK:
                    AddButton(new OltMessageBoxButton(OK_STR, DialogResult.OK));
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    AddButton(new OltMessageBoxButton(ABORT_STR, DialogResult.Abort));
                    AddButton(new OltMessageBoxButton(RETRY_STR, DialogResult.Retry));
                    AddButton(new OltMessageBoxButton(IGNORE_STR, DialogResult.Ignore));
                    break;
                case MessageBoxButtons.OKCancel:
                    AddButton(new OltMessageBoxButton(OK_STR, DialogResult.OK));
                    AddButton(new OltMessageBoxButton(CANCEL_STR, DialogResult.Cancel));
                    break;
                case MessageBoxButtons.RetryCancel:
                    AddButton(new OltMessageBoxButton(RETRY_STR, DialogResult.Retry));
                    AddButton(new OltMessageBoxButton(CANCEL_STR, DialogResult.Cancel));
                    break;
                case MessageBoxButtons.YesNo:
                    AddButton(new OltMessageBoxButton(YES_STR, DialogResult.Yes));
                    AddButton(new OltMessageBoxButton(NO_STR, DialogResult.No));
                    break;
                case MessageBoxButtons.YesNoCancel:
                    AddButton(new OltMessageBoxButton(YES_STR, DialogResult.Yes));
                    AddButton(new OltMessageBoxButton(NO_STR, DialogResult.No));
                    AddButton(new OltMessageBoxButton(CANCEL_STR, DialogResult.Cancel));
                    break;
            }
        }

        private void AddButton(OltMessageBoxButton button)
        {
            button.Click += OnButton_Click;
            buttons.Add(button);
            Controls.Add(button);
        }

        private void OnButton_Click(object sender, EventArgs e)
        {
            OltMessageBoxButton btn = sender as OltMessageBoxButton;
            if (btn != null) DialogResult = btn.Result;
            Close();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Icon != null)
            {
                e.Graphics.DrawIcon(Icon, new Rectangle(iconPanel.Location, new Size(32, 32)));
            }
        }

        /// <summary>
        /// Layout All the controls 
        /// </summary>
        private void LayoutControls()
        {
            int msgLabelY;
            int iconPanelY;
            if (iconPanel.Size.Height > msgLabel.Size.Height)
            {
                // the icon is bigger than the label, so center align the label to the icon
                int yCenter = iconPanel.Location.Y + (iconPanel.Size.Height/2);
                msgLabelY = yCenter - msgLabel.Size.Height/2;
                iconPanelY = iconPanel.Location.Y;
            }
            else
            {
                // the label is bigger than the icon, so center align the icon to the label.
                int yCenter = msgLabel.Location.Y + (msgLabel.Size.Height/2);
                iconPanelY = yCenter - (iconPanel.Size.Height/2);
                msgLabelY = msgLabel.Location.Y;
            }
            
            // Center align the label and Icon
            msgLabel.Location = new Point(iconPanel.Right + 10, msgLabelY);
            iconPanel.Location = new Point(iconPanel.Location.X, iconPanelY);


            // Center Buttons under label and Icon
            Size buttonSize = OltMessageBoxButton.BUTTON_SIZE;
            int allButtonsWidth = buttons.Count*buttonSize.Width + SIDE_PADDING*(buttons.Count - 1);

            if (ClientSize.Width < allButtonsWidth)
            {
                ClientSize = new Size(allButtonsWidth + SIDE_PADDING * 2, ClientSize.Height);
            }

            int firstButtonX = ((ClientSize.Width - allButtonsWidth)/2);
            // get the bottom of which ever is further down the form and use it as the basis of where the buttons will start.
            int firstButtonY = Math.Max(msgLabel.Bottom, iconPanel.Bottom) + BOTTOM_PADDING + BOTTOM_PADDING;
            Point nextButtonLocation = new Point(firstButtonX, firstButtonY);

            foreach (OltMessageBoxButton button in buttons)
            {
                button.Location = nextButtonLocation;
                nextButtonLocation.X += buttonSize.Width + SIDE_PADDING;
            }

        }

        public static DialogResult ShowCustomYesNo(Form owner, string message, string title,MessageBoxIcon icon, ContentAlignment alignment, string yesText, string noText)
        {
            OltMessageBox msgBox = GetMsgBox(owner, message, title, MessageBoxButtons.YesNo, icon, alignment);

            OltMessageBoxButton yesButton = msgBox.buttons.Find(obj => obj.Text == YES_STR);
            yesButton.Text = yesText;
            OltMessageBoxButton noButton = msgBox.buttons.Find(obj => obj.Text == NO_STR);
            noButton.Text = noText;

            return ShowMessageBox(msgBox);
        }

        public static DialogResult Show(Form owner, string message, string title, MessageBoxButtons btns, MessageBoxIcon icon, ContentAlignment alignment)
        {
            OltMessageBox msgBox = GetMsgBox(owner, message, title, btns, icon, alignment);
            return ShowMessageBox(msgBox);
        }

        private static OltMessageBox GetMsgBox(Form owner, string message, string title, MessageBoxButtons btns, MessageBoxIcon icon, ContentAlignment alignment)
        {
            OltMessageBox msgBox = new OltMessageBox(owner, btns, icon, message, title);
//            msgBox.msgLabel.TextAlign = alignment;
            return msgBox;
        }

        private static DialogResult ShowMessageBox(OltMessageBox msgBox)
        {
            DialogResult result = msgBox.ShowDialog();
            msgBox.Dispose();
            return result;
        }

        public static DialogResult Show(Form owner, string message, string title, MessageBoxButtons btns, MessageBoxIcon icon)
        {
            return Show(owner, message, title, btns, icon, ContentAlignment.MiddleCenter);
        }

        public static DialogResult Show(Form owner, string message, string title, MessageBoxButtons btns)
        {
            return Show(owner, message, title, btns, MessageBoxIcon.None);
        }

        public static DialogResult Show(Form owner, string message, string title)
        {
            return Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowError(string message)
        {
            return Show(ActiveForm, message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowError(string message, string title)
        {
            return Show(ActiveForm, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Show(string message)
        {
            return Show(ActiveForm, message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Show(Form owner, string message)
        {
            return Show(owner, message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowCustomYesNo(Form owner, string message, string title, MessageBoxIcon icon, string yesText, string noText)
        {
            return ShowCustomYesNo(owner, message, title, icon, ContentAlignment.MiddleLeft, yesText, noText);
        }

        public static DialogResult ShowCustomYesNo(string message, string title)
        {
            return ShowCustomYesNo(ActiveForm, message, title, MessageBoxIcon.Question, StringResources.Yes, StringResources.No);
        }
        
        public static DialogResult ShowCustomYesNo(string message)
        {
            return ShowCustomYesNo(ActiveForm, message, string.Empty, MessageBoxIcon.Question, StringResources.Yes, StringResources.No);
        }

        public static DialogResult Show(string message, MessageBoxButtons btns, MessageBoxIcon icon)
        {
            return Show(ActiveForm, message, string.Empty, btns, icon);
        }
    }
}