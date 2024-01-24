using System;
using System.Reflection;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public enum LoginResult
    {
        Success, InvalidUsernamePassword, IncompleteUser
    }

    public class SignInFormPresenter
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SignInFormPresenter));
        private readonly ISignInFormView view;
        private readonly ISecurityService securityService;
        private readonly IObjectLockingService lockingService;

        public SignInFormPresenter(ISignInFormView view) : this(
            view,
            ClientServiceRegistry.Instance.GetService<ISecurityService>(),
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>())
        {
        }

        public SignInFormPresenter(ISignInFormView view, ISecurityService securityService, IObjectLockingService lockingService)
        {
            this.view = view;
            this.securityService = securityService;
            this.lockingService = lockingService;
        }

        public void SignInButtonClickEvent(object sender, EventArgs eventArgs)
        {
            CheckForVersionIncompatibility();
            view.Authenticated = AttemptToLogin();
        }
        //Dharmesh 13-Sep-2017 start FOR RITM0156565 - OLT User Access-Instructions link on Login page 
        public void RequestLinkLabelClickEvent(object sender, EventArgs eventArgs)
        {
            UIUtils.LaunchURL(StringResources.OltAccessRaiseRequestURL);
        }
        //Dharmesh 13-Sep-2017 end
        private LoginResult AttemptToLogin()
        {
            User user = securityService.Authenticate(view.Username, view.Password.Encrypt());
            if (user == null)
            {
                return LoginResult.InvalidUsernamePassword;
            }
            if (user.SiteRolePlants.Count == 0)
            {
                return LoginResult.IncompleteUser;
            }

            if(lockingService != null)
            {
                lockingService.ReleaseLock(ClientSession.GetInstance().GuidAsString);
            }
            UserContext incompleteUserContext = ClientSession.GetUserContext();
            incompleteUserContext.User = user;
            return LoginResult.Success;
        }

        private void CheckForVersionIncompatibility()
        {
            Version remoteVersion = securityService.GetAssemblyVersion();
            Version localVersion = Assembly.GetExecutingAssembly().GetName().Version;
            if(remoteVersion.Major != localVersion.Major || remoteVersion.Minor != localVersion.Minor)
            {
                Exception ve = new VersionNotMatchingException("remote version is " + remoteVersion + " local version is " + localVersion);
                logger.Error("remote and local version doesn't match", ve);
                throw ve;
            }
        }
    }


}