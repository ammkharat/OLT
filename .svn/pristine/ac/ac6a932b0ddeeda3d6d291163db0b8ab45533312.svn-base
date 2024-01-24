using System;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public abstract class AbstractApprovableDomainPagePresenter<TDto, TDomainObject, TDetails, TPage> : AbstractDeletableDomainPagePresenter<TDto, TDomainObject, TDetails, TPage>
        where TDto : DomainObject
        where TDomainObject : DomainObject
        where TDetails : IApprovableDetails
        where TPage : class, IDomainPage<TDto, TDetails>
    {
        protected AbstractApprovableDomainPagePresenter(
            TPage page, 
            IAuthorized authorized, 
            IRemoteEventRepeater remoteEventRepeater, 
            IObjectLockingService objectLockingService,
            ITimeService timeService,
            IUserService userService) : base(page, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            page.Details.Approve += Details_Approve;
            page.Details.Reject += Details_Reject;
            page.Details.Comment += Details_Comment;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Approve -= Details_Approve;
            page.Details.Reject -= Details_Reject;
            page.Details.Comment -= Details_Comment;
        }

        private void Details_Approve(object sender, EventArgs e)
        {
            ApproveButton_Clicked();
        }

        public virtual void ApproveButton_Clicked()
        {
            bool confirmed = page.ShowOKCancelDialog(
                string.Format(StringResources.ApproveItemDialogText, DomainObjectName),
                string.Format(StringResources.ApproveItemDialogTitle, DomainObjectName));
            if (confirmed)
            {
                LockMultipleDomainObjects(Approve, null);
            }
        }

        private void Details_Reject(object sender, EventArgs e)
        {
            RejectButton_Clicked();
        }

        public void RejectButton_Clicked()
        {
            bool confirmed = page.ShowOKCancelDialog(
               string.Format(StringResources.RejectItemDialogText, DomainObjectName),
               string.Format(StringResources.RejectItemDialogTitle, DomainObjectName));
            if (confirmed)
            {
                LockMultipleDomainObjects(Reject, null);
            }
        }

        private void Details_Comment(object sender, EventArgs e)
        {
            CommentButton_Clicked();
        }

        public void CommentButton_Clicked()
        {
            LockDatabaseObjectWhileInUse(Comment, LockType.Edit);
        }

        protected abstract void Approve(TDomainObject domainObject);
        protected abstract void Comment(TDomainObject domainObject);
        protected abstract void Reject(TDomainObject domainObject);
    }
}
