using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddNewDocumentLinkForm : BaseForm, IAddNewDocumentLinkFormView
    {
        private readonly AddNewDocumentLinkFormPresenter presenter;

        public AddNewDocumentLinkForm()
        {
            InitializeComponent();

            presenter = new AddNewDocumentLinkFormPresenter(this);

            RegisterPresenterEventHandlers();
        }

        private void RegisterPresenterEventHandlers()
        {
            Load += presenter.HandleLoad;
            addButton.Click += presenter.HandleAddClicked;
            cancelButton.Click += presenter.HandleCancelClicked;
            browseButton.Click += presenter.BrowseClicked;
        }

        public void ShowLinkDocumentIsEmptyError()
        {
            linkErrorProvider.SetError(linkDocumentTextBox, StringResources.URLEmptyError);
        }

        public void ShowLinkDocumentIsNotValidURLError()
        {
            linkErrorProvider.SetError(linkDocumentTextBox, StringResources.URLInvalidURLError);
        }

        public void ShowTitleDocumentIsEmptyError()
        {
            titleErrorProvider.SetError(titleDocumentTextBox, StringResources.TitleEmptyError);
        }

        public void ClearErrorProviders()
        {
            linkErrorProvider.Clear();
            titleErrorProvider.Clear();
        }

        public DocumentLink NewDocumentLink { get; set; }

        public string DocumentLink
        {
            get
            {
                return linkDocumentTextBox.Text;
            }
            private set { linkDocumentTextBox.Text = value; }
        }

        public string Title
        {
            get
            {
                return titleDocumentTextBox.Text;
            }
        }        
        public void CloseForm()
        {
            Close();
        }

        public void DisableFileBrowser()
        {
            browseButton.Visible = false;
        }

        public void SelectFile(DocumentRootUncPath uncPath)
        {
            if (uncPath.Path != null && !uncPath.Path.IsValidUncPath() && uncPath.Path.IsValidUri())
            {
                Process.Start(uncPath.Path);
                return;
            }

            FileDialog fileDialog = new OpenFileDialog {RestoreDirectory = true};

            string path = uncPath.Path;
            
            if (Directory.Exists(path))
            {
                fileDialog.InitialDirectory = path;
                fileDialog.Title = string.Format(StringResources.AddDocumentLinkFileDialogTitle, uncPath.PathName);
            }

            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;
                DocumentLink = fileName;
            }

        }

        public DocumentRootUncPath DisplayRootSelector()
        {
            DocumentRootSelectionForm form = new DocumentRootSelectionForm
                                                 {StartPosition = FormStartPosition.CenterParent};
            DialogResult dialogResult = form.ShowDialog(this);
            
            return dialogResult == DialogResult.OK ? form.SelectedItem : null;
        }
    }
}