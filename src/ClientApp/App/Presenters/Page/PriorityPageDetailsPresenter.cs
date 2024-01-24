using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public abstract class PriorityPageDetailsPresenter<T>
        where T : class, IDetails
    {
        protected readonly IGridAndDetailsView view;
        protected readonly T details;
        protected readonly UserContext userContext;
        private readonly IObjectLockingService lockingService;

        protected PriorityPageDetailsPresenter(string title, T details)
        {
            this.details = details;
            userContext = ClientSession.GetUserContext();
            lockingService = ClientServiceRegistry.Instance.GetService<IObjectLockingService>();

            view = new GridAndDetailsForm();
            view.Title = title;
            view.Details = details;

            view.Disposed += View_Disposed;
        }

        private void View_Disposed(object sender, EventArgs e)
        {
            view.Disposed -= View_Disposed;
            UnsubscribeToEvents();
        }

        protected abstract void UnsubscribeToEvents();

        public void Run(IWin32Window parent)
        {
            view.ShowDialog(parent);
            view.Dispose();
        }

        protected LockResult<TResult> LockDatabaseObjectWhileInUse<TDomainObject, TResult>(Func<TDomainObject, TResult> action, TDomainObject domainObject)
            where TDomainObject : DomainObject
        {
            User user = userContext.User;
            string lockIdentifier = domainObject.ObjectIdentifier;
            ObjectLockResult lockResult = lockingService.GetLock(lockIdentifier, user.IdValue, ClientSession.GetInstance().GuidAsString);

            TResult actionResult = default(TResult);
            bool lockAquired = lockResult.Succeeded;

            if (lockAquired)
            {
                try
                {
                    actionResult = action(domainObject);
                }
                finally
                {
                    lockingService.ReleaseLock(lockIdentifier, user.IdValue);
                }
            }
            else
            {
                LaunchLockDeniedMessage(lockResult.LockedByUserName);
            }

            return new LockResult<TResult>(lockAquired, actionResult);
        }

        private static void LaunchLockDeniedMessage(string nameOfUserThatIsCurrentlyEditing)
        {
            OltMessageBox.Show(Form.ActiveForm,
                               String.Format(StringResources.EditDeniedMessage, nameOfUserThatIsCurrentlyEditing),
                               StringResources.EditDeniedTitle,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
        }

        protected class LockResult<TActionResult>
        {
            public bool LockAquired { get; private set; }
            public TActionResult ActionResult { get; private set; }

            public LockResult(bool lockAquired, TActionResult actionResult)
            {
                LockAquired = lockAquired;
                ActionResult = actionResult;
            }
        }
    }
}
