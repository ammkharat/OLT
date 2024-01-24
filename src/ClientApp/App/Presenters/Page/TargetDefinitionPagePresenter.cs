using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class TargetDefinitionPagePresenter
        : AbstractApprovableDomainPagePresenter<TargetDefinitionDTO, TargetDefinition, ITargetDefinitionDetails, ITargetDefinitionPage>
    {
        private readonly ITargetDefinitionService targetDefinitionService;
        private readonly IActionItemDefinitionService actionItemDefinitionService;

        public TargetDefinitionPagePresenter()
            : base(
            new TargetDefinitionPage(),
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            targetDefinitionService = ClientServiceRegistry.Instance.GetService<ITargetDefinitionService>();
            actionItemDefinitionService = ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(TargetDefinition item)
        {
            return new EditTargetDefinitionHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(TargetDefinition item)
        {
            return new TargetDefinitionForm(item);
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            if (userRoleElements != null)
            {
                List<TargetDefinitionDTO> selectedItems = page.SelectedItems;
                bool hasSingleItemSelected = selectedItems.Count == 1;
                bool hasItemsSelected = selectedItems.Count > 0;
                
                TargetDefinitionDTO firstSelectedItem = page.FirstSelectedItem;
                
                ITargetDefinitionDetails details = page.Details;
                details.ApproveEnabled = hasItemsSelected && authorized.ToApproveTargetDefinitions(userRoleElements, selectedItems);
                details.RejectEnabled = hasItemsSelected && authorized.ToRejectTargetDefinitions(userRoleElements, selectedItems);
                details.DeleteEnabled = hasItemsSelected && authorized.ToDeleteTargetDefinitions(userRoleElements, selectedItems);
                details.EditEnabled = hasSingleItemSelected && authorized.ToEditTargetTargetDefinition(userRoleElements, firstSelectedItem);
                details.CommentEnabled = hasSingleItemSelected && authorized.ToCommentTargetDefinition(userRoleElements, firstSelectedItem);
                details.ViewEditHistoryEnabled = hasSingleItemSelected;
            }
        }

        protected override void Delete(TargetDefinition targetDefinition)
        {
            if (targetDefinitionService.HasLinkedActionItemDefinition(targetDefinition.Id))
            {
                List<string> names =
                    actionItemDefinitionService.QueryForActionItemNameListByTargetDefinitionId(targetDefinition.Id);
                page.DisplayTargetDeleteDeniedMessageCausedByExistingActionItemDefinition(names);
                
                throw new UserActionException("Cannot delete the Target Definition because it is linked with an Action Item Definition");
            }
            try
            {
                targetDefinition.LastModifiedBy = ClientSession.GetUserContext().User;
                targetDefinition.LastModifiedDate = Clock.Now;
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(targetDefinitionService.Remove, targetDefinition);
            }
            catch (ParentTargetExistsException ex)
            {
                page.DisplayTargetDeleteDeniedMessage(ex.TargetNames);
               
                throw new UserActionException(ex.Message);
            }
        }

        protected override void Approve(TargetDefinition domainObject)
        {
            List<NotifiedEvent> notifiedEvents = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(targetDefinitionService.Approve, domainObject, ClientSession.GetUserContext().User, Clock.Now);
            NotifiedEvent notifiedEvent = notifiedEvents.Find(obj => obj.ApplicationEvent == ApplicationEvent.TargetDefinitionUpdate);
            TargetDefinition targetDefinition = (TargetDefinition) notifiedEvent.DomainObject;

            ShowActionItemDefinitionForm(targetDefinition);
        }

        protected override void Comment(TargetDefinition targetDefinition)
        {
            var commentsView = new CommentsForm();
            new TargetDefinitionCommentsFormPresenter(commentsView, targetDefinition);
            commentsView.ShowDialog(page.ParentForm);
        }

        protected override void Reject(TargetDefinition targetDefinition)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(targetDefinitionService.Reject, targetDefinition, ClientSession.GetUserContext().User, Clock.Now);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerTargetDefinitionCreated += repeater_Created;
            remoteEventRepeater.ServerTargetDefinitionUpdated += repeater_Updated;
            remoteEventRepeater.ServerTargetDefinitionRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerTargetDefinitionCreated -= repeater_Created;
            remoteEventRepeater.ServerTargetDefinitionUpdated -= repeater_Updated;
            remoteEventRepeater.ServerTargetDefinitionRemoved -= repeater_Removed;
        }

        protected override TargetDefinition QueryByDto(TargetDefinitionDTO dto)
        {
            return targetDefinitionService.QueryById(dto.IdValue);
        }

        protected override void SetDetailData(ITargetDefinitionDetails details, TargetDefinition targetDefinition)
        {
            new TargetDefinitionDetailsPresenter(details, targetDefinition).LoadView();
        }

        protected override TargetDefinitionDTO CreateDTOFromDomainObject(TargetDefinition domainObject)
        {
            return new TargetDefinitionDTO(domainObject);
        }

        private void ShowActionItemDefinitionForm(TargetDefinition targetDefinition)
        {
            if (!targetDefinition.AutoGenerateActionItemDefinitionRequired) return;

            var generator = new ActionItemDefinitionGenerator(targetDefinitionService);
            ActionItemDefinition actionItemDefinition = generator.BuildActionItemDefinition(targetDefinition);
            page.DisplayActionItemDefinitionForm(actionItemDefinition);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_TargetDefinition; }
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return null;
        }

        protected override IList<TargetDefinitionDTO> GetDtos(Range<Date> dateRange)
        {
            return targetDefinitionService.QueryDTOByFunctionalLocations(ClientSession.GetUserContext().RootFlocSet, dateRange);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.TargetDefinitions; }
        }
    }
}