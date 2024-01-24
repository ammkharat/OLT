using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SignInForm : BaseForm, ISignInFormView
    {
        private readonly SignInFormPresenter presenter;

        public SignInForm()
        {
            InitializeComponent();
            presenter = new SignInFormPresenter(this);
            signInButton.Click += presenter.SignInButtonClickEvent;
            //Dharmesh 13-Sep-2017 start FOR RITM0156565 - OLT User Access-Instructions link on Login page 
            requestLinkLabel.Click += presenter.RequestLinkLabelClickEvent;
            //Dharmesh 13-Sep-2017 END
        }

        public string Username
        {
            get { return usernameTextbox.Text.Trim(); }
        }

        public string Password
        {
            get { return passwordTextbox.Text.Trim(); }
        }

        public LoginResult Authenticated
        {
            set
            {
                switch (value)
                {
                    case LoginResult.InvalidUsernamePassword:
                        {
                            DialogResult = DialogResult.None;
                            OltMessageBox.Show(
                                this,
                                StringResources.InvalidUsernamePassword,
                                StringResources.LoginError,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                ContentAlignment.MiddleLeft);
                            break;
                        }
                    case LoginResult.Success:
                        {
                            DialogResult = DialogResult.OK;
                            break;
                        }
                    case LoginResult.IncompleteUser:
                        {
                            DialogResult = DialogResult.None;

                            if (OltMessageBox.Show(
                                this,
                                //Dharmesh 13-Sep-2017 start FOR RITM0156565 - OLT User Access-Instructions link on Login page 
                                //StringResources.SitePlantRoleNotConfigured,
                                StringResources.SitePlantRoleNotConfigured + "\n" + StringResources.OltAccessRaiseRequestButton,
                                //Dharmesh 13-Sep-2017 end
                                StringResources.LoginError,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Exclamation,
                                ContentAlignment.MiddleLeft)
                                == DialogResult.OK)
                            {
                                System.Diagnostics.Process.Start(StringResources.OltAccessRaiseRequestURL);
                            }

                            break;
                        }
                }
            }
        }
    }
}