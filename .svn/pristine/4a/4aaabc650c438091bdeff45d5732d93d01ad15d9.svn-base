using System;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public abstract class AbstractDeletableDomainPagePresenter<TDto, TDomainObject, TDetails, TPage> : AbstractPagePresenter<TDto, TDomainObject, TDetails, TPage>
        where TDto : DomainObject
        where TDomainObject : DomainObject
        where TDetails : IDeletableDetails
        where TPage : class, IDomainPage<TDto, TDetails>
    {
        protected AbstractDeletableDomainPagePresenter(TPage page)
            : this(
                page,
                new Authorized(),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        protected AbstractDeletableDomainPagePresenter(
            TPage page, 
            IAuthorized authorized, 
            IRemoteEventRepeater remoteEventRepeater, 
            IObjectLockingService objectLockingService,
            ITimeService timeService,
            IUserService userService) : base(page, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {
            SubscribeToEvents();
        }

        protected abstract EditHistoryFormPresenter CreateHistoryPresenter(TDomainObject item);
        protected abstract IForm CreateEditForm(TDomainObject item);
        protected abstract void Delete(TDomainObject item);

        private void SubscribeToEvents()
        {
            page.Details.ViewEditHistory += Details_ViewEditHistory;
            page.Details.Edit += Details_Edit;
            page.Details.Delete += Details_Delete;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.ViewEditHistory -= Details_ViewEditHistory;
            page.Details.Edit -= Details_Edit;
            page.Details.Delete -= Details_Delete;
        }

        private void Details_ViewEditHistory(object sender, EventArgs e)
        {
            HistoryButton_Clicked();
        }

        private void HistoryButton_Clicked()
        {
            TDomainObject item = QueryForFirstSelectedItem();
            if (item != null)
            {
                EditHistoryFormPresenter presenter = CreateHistoryPresenter(item);
                presenter.Run(page.ParentForm);
            }
        }

        private void Details_Delete(object sender, EventArgs e)
        {
            DeleteButton_Clicked();
        }

        public virtual void DeleteButton_Clicked()
        {
            DeleteWithOkCancelDialog(StringResources.DeleteItemDialogText);
        }

        private void Details_Edit(object sender, EventArgs e)
        {
            EditButton_Clicked();
        }

        public void EditButton_Clicked()
        {
            LockDatabaseObjectWhileInUse(Edit, LockType.Edit);
        }

        protected virtual void Edit(TDomainObject domainObject)
        {
            IForm form = CreateEditForm(domainObject);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        protected virtual IForm CreateEditFormForClone(TDomainObject domainObject)
        {
            return CreateEditForm(domainObject);
        }

        protected virtual void EditForClone(TDomainObject domainObject)
        {
            IForm form = CreateEditFormForClone(domainObject);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        protected void DeleteWithOkCancelDialog(string dialogText)
        {
            bool confirmed = page.ShowOKCancelDialog(
                string.Format(dialogText, DomainObjectName),
                string.Format(StringResources.DeleteItemDialogTitle, DomainObjectName));

            if (confirmed)
            {
                LockMultipleDomainObjects(Delete, () => page.DeleteSuccessfulMessage());
            }
        }
    }
}