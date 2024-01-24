using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CommentsForm : BaseForm, ICommentsFormView
    {
        public event EventHandler SubmitButtonClick;
        public event EventHandler CancelButtonClick;
        public event EventHandler CreateLogCheckedChanged;

        public CommentsForm()
        {
            InitializeComponent();
            createLogCheckBox.Checked = false;
            createLogCheckBox.CheckedChanged += createLogCheckBox_CheckedChanged;
        }

        public string Title
        {
            set
            {
                Text = value;
            }
        }

        public string UserComments
        {
            get { return commentTextBox.Text.TrimWhitespace(); }
        }

        public bool IsLogRequired
        {
            get { return createLogCheckBox.Checked; }
        }

        public bool IsLogAnOperatingEngineeringLog
        {
            get { return MakeLogAnOperatingEngineerCheckBox.Checked; }
            set { MakeLogAnOperatingEngineerCheckBox.Checked = value; }
        }

        public void EnableLogAsOperatingEngineeringLog(bool enabled, string displayText)
        {
            MakeLogAnOperatingEngineerCheckBox.Enabled = enabled;
            MakeLogAnOperatingEngineerCheckBox.Text = displayText;
        }

        public void HideOperatingEngineerLogCheckbox()
        {
            MakeLogAnOperatingEngineerCheckBox.Hide();
        }

        public DateTime CreateDateTime
        {
            get { return oltLastModifiedDateAuthorHeader.LastModifiedDate; }
            set { oltLastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public string ShiftName
        {
            set { shiftLabelData.Text = value; }
        }

        public User Author
        {
            set { oltLastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public Control SummaryView
        {
            set
            {
                ResizeFormToFitSummaryView(value);
                summaryPanel.Controls.Add(value);
            }
        }

        private void ResizeFormToFitSummaryView(Control summaryControl)
        {
            Size newSize = new Size(Size.Width, Size.Height + summaryControl.Size.Height);
            Size = newSize;
            MinimumSize = Size;
            CenterToParent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (SubmitButtonClick != null)
            {
                SubmitButtonClick(sender, e);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClick != null)
            {
                CancelButtonClick(sender, e);
            }
        }

        private void createLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CreateLogCheckedChanged != null)
            {
                CreateLogCheckedChanged(sender, e);
            }
        }       
    }
}
