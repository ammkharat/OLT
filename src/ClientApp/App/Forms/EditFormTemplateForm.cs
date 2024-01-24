using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditFormTemplateForm : BaseForm, IEditFormTemplateView
    {
        public event Action SaveButtonClick;
        public event Action CancelButtonClick;

        public EditFormTemplateForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
        }

        public string Title
        {
            set { Text = value; }
        }

        public string Template
        {
            get { return richTextEditor.Text; }
            set { richTextEditor.Text = value; }
        }

        private void HandleSaveButtonClick(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClick != null)
            {
                SaveButtonClick();
            }
        }

        private void HandleCancelButtonClick(object sender, EventArgs eventArgs)
        {
            if (CancelButtonClick != null)
            {
                CancelButtonClick();
            }
        }

    }
}
