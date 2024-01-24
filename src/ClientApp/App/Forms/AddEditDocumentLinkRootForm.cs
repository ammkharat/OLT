using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditDocumentLinkRootForm : BaseForm, IAddEditDocmentLinkRootView
    {
        private readonly AddEditDocumentLinkRootFormPresenter presenter;

        public AddEditDocumentLinkRootForm(DocumentRootUncPath editObject)
        {
            InitializeComponent();
            flocControl.Mode = FunctionalLocationMode.LevelTwoAndAbove;

            presenter = new AddEditDocumentLinkRootFormPresenter(this, editObject);
            Load += presenter.HandleFormLoad;
            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            FormClosing += presenter.HandleFormClosing;
        }

        public string PathName
        {
            get { return pathNameTextBox.Text.Trim(); }
            set { pathNameTextBox.Text = value; }
        }

        public string UncPath
        {
            get { return uncPathTextBox.Text.Trim(); }
            set { uncPathTextBox.Text = value; }
        }

        public IList<FunctionalLocation> FunctionalLocations
        {
            get { return flocControl.UserCheckedFunctionalLocations; }
            set { flocControl.UserCheckedFunctionalLocations = value; }
        }

        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }

        public void ClearAllErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorNoFunctionalLocations()
        {
            errorProvider.SetError(flocGroupBox, StringResources.FlocEmptyError);
        }

        public void SetErrorNoPathName()
        {
            errorProvider.SetError(pathNameTextBox, StringResources.NameEmptyError);
        }

        public void SetErrorNoUncPath()
        {
            errorProvider.SetError(uncPathTextBox, StringResources.UNCPathEmpty);
        }

        public void SetErrorIsNotUncPath()
        {
            errorProvider.SetError(uncPathTextBox, StringResources.UNCPathInvalid);
        }

        public void SetErrorIsNotExistingUncPath()
        {
            errorProvider.SetError(uncPathTextBox, StringResources.UNCPathDoesNotExist);
        }

        public override void SaveSucceededMessage()
        {
            // Do not display confirmation.
        }
    }
}
