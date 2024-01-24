
using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditConfiguredDocumentLinkForm : BaseForm, IAddEditConfiguredDocumentLinkView
    {
        public event EventHandler OkButtonClicked;

        public AddEditConfiguredDocumentLinkForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            okButton.Click += OkButtonOnClick;
        }

        private void OkButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (OkButtonClicked != null)
            {
                OkButtonClicked(sender, eventArgs);
            }
        }

        public string Title
        {
            set { Text = value; }
        }

        public string LinkTitle
        {
            get { return titleTextBox.Text; }
            set { titleTextBox.Text = value; }
        }

        public string Link
        {
            get { return linkTextBox.Text; }
            set { linkTextBox.Text = value; }
        }

        public void SetErrorNoLink()
        {
            errorProvider.SetError(linkTextBox, StringResources.FieldEmptyError);
        }

        public void SetErrorNoTitle()
        {
            errorProvider.SetError(titleTextBox, StringResources.TitleEmptyError);
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }
    }
}
