using System;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public abstract class AbstractRespondableDomainPagePresenter<TDto, TDomainObject, TDetails, TPage> :
        AbstractPagePresenter<TDto, TDomainObject, TDetails, TPage>
        where TDto : DomainObject
        where TDomainObject : DomainObject, IHasDefinition
        where TDetails : IRespondableDetails
        where TPage : class, IDomainPage<TDto, TDetails>
    {
        protected AbstractRespondableDomainPagePresenter(TPage page) : this(
            page,
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        protected AbstractRespondableDomainPagePresenter(
            TPage page,
            IAuthorized authorized,
            IRemoteEventRepeater remoteEventRepeater,
            IObjectLockingService objectLockingService,
            ITimeService timeService,
            IUserService userService)
            : base(page, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {
            SubscribeToEvents();
        }

        protected abstract IForm CreateCopyLastResponseForm(TDomainObject item); //DMND0010124 mangesh
        protected abstract IForm CreateResponseForm(TDomainObject item);
        protected abstract PageKey GetDefinitionPageKey();

        private void SubscribeToEvents()
        {
            page.Details.Respond += Details_Respond;
            page.Details.GoToDefinition += Details_GoToDefinition;

            page.Details.CopyLastResponse += Details_CopyLastResponse;//DMND0010124 mangesh
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Respond -= Details_Respond;
            page.Details.GoToDefinition -= Details_GoToDefinition;

            page.Details.CopyLastResponse -= Details_CopyLastResponse;//DMND0010124 mangesh
        }


        //DMND0010124 mangesh
        void Details_CopyLastResponse(object sender, EventArgs e)
        {
            CopyLastResponseButton_Clicked();
        }
        public virtual void CopyLastResponseButton_Clicked()
        {
            LockDatabaseObjectWhileInUse(CopyLastResponse, LockType.Edit);
        }
        protected virtual void CopyLastResponse(TDomainObject item)
        {
            var form = CreateCopyLastResponseForm(item);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }


        private void Details_Respond(object sender, EventArgs e)
        {
            RespondButton_Clicked();
        }

        public virtual void RespondButton_Clicked()
        {
            LockDatabaseObjectWhileInUse(Respond, LockType.Edit);
        }

        protected virtual void Respond(TDomainObject item)
        {
            var form = CreateResponseForm(item);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void Details_GoToDefinition(object sender, EventArgs e)
        {
            GoToDefinition_Clicked();
        }

        private void GoToDefinition_Clicked()
        {
            if (page.SelectedItems.Count == 0) return;

            var item = QueryForFirstSelectedItem();
            if (item != null)
            {
                page.MainParentForm.SelectSectionAndItem(GetDefinitionPageKey(), item.DefinitionId);
            }
            else
            {
                var futureActionItemDTO = page.SelectedItems.First() as FutureActionItemDTO;

                if (futureActionItemDTO != null)
                {
                    page.MainParentForm.SelectSectionAndItem(GetDefinitionPageKey(), futureActionItemDTO.DefinitionId);
                }
            }
        }
    }
}