using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditAdministratorForm : BaseForm, IAddEditAdministratorView
    {
        private readonly AddEditAdministratorFormPresenter presenter;

        public AddEditAdministratorForm(AdministratorList editObject)
        {
            InitializeComponent();

            presenter = new AddEditAdministratorFormPresenter(this, editObject);
            Load += presenter.HandleFormLoad;
            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            FormClosing += presenter.HandleFormClosing;
        }

        public long SiteID
        {
            get { return 0; }
            set { }
        }
        public string SiteName
        {
            get { return siteTextbox.Text.Trim(); }
            set { siteTextbox.Text = value; }
        }
        public string Group
        {
            get { return groupTextBox.Text.Trim(); }
            set { groupTextBox.Text = value; }
        }
        public string SiteRepresentative
        {
            get { return siteRepresentativeTextbox.Text.Trim(); }
            set { siteRepresentativeTextbox.Text = value; }
        }
        public string SiteAdmin
        {
            get { return siteAdminTextbox.Text.Trim(); }
            set { siteAdminTextbox.Text = value; }
        }
        public string BEA
        {
            get { return beaTextbox.Text.Trim(); }
            set { beaTextbox.Text = value; }
        }


        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }

        public void ClearAllErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorNoSite()
        {
            errorProvider.SetError(siteTextbox, StringResources.OLTAdminSiteNameError);
        }

        public void SetErrorNoGroup()
        {
            errorProvider.SetError(groupTextBox, StringResources.OLTAdminGroupNameError);
        }

        public void SetErrorNoSiteRepresentative()
        {
            //no validation require
        }

        public void SetErrorNoSiteAdmin()
        {
            errorProvider.SetError(siteAdminTextbox, StringResources.OLTAdminSiteAdminNameError);
        }

        public void SetErrorNoBEA()
        {
            errorProvider.SetError(beaTextbox, StringResources.OLTAdminBEAError);
        }

        public override void SaveSucceededMessage()
        {
            // Do not display confirmation.
        }
    }
}
