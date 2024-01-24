using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using System;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class TargetAlertPagePresenter :
        AbstractRespondableDomainPagePresenter<TargetAlertDTO, TargetAlert, ITargetAlertDetails, ITargetAlertPage>
    {
        private readonly ILogService logService;
        private readonly ITargetAlertService service;

        public TargetAlertPagePresenter() : this(new TargetAlertPage())
        {
        }

        public TargetAlertPagePresenter(ITargetAlertPage targetAlertPage) : this(
            targetAlertPage,
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ITargetAlertService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<ILogService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        protected TargetAlertPagePresenter(
            ITargetAlertPage targetAlertPage,
            IAuthorized authorized,
            IRemoteEventRepeater remoteEventRepeater,
            IObjectLockingService objectLockingService,
            ITargetAlertService targetAlertService,
            ITimeService timeService,
            ILogService logService,
            IUserService userService)
            : base(targetAlertPage, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {
            service = targetAlertService;
            this.logService = logService;

            SubscribeToEvents();
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_TargetAlert; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.TargetAlerts; }
        }

        private void SubscribeToEvents()
        {
            page.Details.Acknowledge += Acknowledge;
            page.Details.ViewAssociatedLogs += ViewAssociatedLogs;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Acknowledge -= Acknowledge;
            page.Details.ViewAssociatedLogs -= ViewAssociatedLogs;
        }

        private void ViewAssociatedLogs()
        {
            var associatedLogDtos = logService.QueryDTOsByTargetAlert(page.FirstSelectedItem.IdValue);
            page.ShowAssociatedLogForm(associatedLogDtos);
        }

        public IForm CreateResponseForm(List<TargetAlert> targetAlert)
        {
            var responseView = new TargetAlertResponseForm();
            var flocSelectionView =
                new SingleSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(userContext.SiteConfiguration));
            new TargetAlertResponseFormPresenter(responseView, flocSelectionView, targetAlert);
            return responseView;
        }

        public override void RespondButton_Clicked()
        {
            LockMultipleDomainObjects(RespondToMultiple, LockType.Edit);
        }

        private void RespondToMultiple(List<TargetAlert> items)
        {
            var form = CreateResponseForm(items);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        //DMND0010124 mangesh
        protected override IForm CreateCopyLastResponseForm(TargetAlert item)
        {
            throw new NotImplementedException();
        }

        protected override IForm CreateResponseForm(TargetAlert item)
        {
            return CreateResponseForm(new List<TargetAlert> {item});
        }

        protected override PageKey GetDefinitionPageKey()
        {
            return PageKey.TARGET_DEFINITION_PAGE;
        }

        public void Acknowledge()
        {
            var confirmed = page.ShowOKCancelDialog(
                string.Format(StringResources.AcknowledgeItemDialogText, DomainObjectName),
                string.Format(StringResources.AcknowledgeItemDialogTitle, DomainObjectName));
            if (confirmed)
            {
                LockMultipleDomainObjects(Acknowledge, null);
            }
        }

        private void Acknowledge(TargetAlert targetAlert)
        {
            if (targetAlert.RequiresResponse)
            {
                Respond(targetAlert);
            }
            else
            {
                targetAlert.Acknowledge(ClientSession.GetUserContext().User, Clock.Now);
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateTargetAlert,
                    targetAlert);
            }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerTargetAlertCreated += repeater_Created;
            remoteEventRepeater.ServerTargetAlertUpdated += repeater_Updated;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerTargetAlertCreated -= repeater_Created;
            remoteEventRepeater.ServerTargetAlertUpdated -= repeater_Updated;
        }

        protected override TargetAlert QueryByDto(TargetAlertDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        protected override void ControlDetailButtons()
        {
            var user = userContext.UserRoleElements;

            var selectedItems = page.SelectedItems;
            var hasSingleItemSelected = selectedItems.Count == 1;
            var hasItemsSelected = selectedItems.Count > 0;

            //COMMENT: trg - if this changes .. it means that the PriorityPagePresenter AuthorizeTargetAlertContextMenu needs to reflect change as well.
            var details = page.Details;
            details.RespondEnabled = hasItemsSelected && authorized.ToRespondToTargetAlerts(user);
            details.AcknowledgeEnabled = hasItemsSelected && authorized.ToAcknowledgeTargetAlerts(user, selectedItems);
            details.GoToDefinitionEnabled = hasSingleItemSelected;
            EnableViewAssociatedLogsButtonIfNecessary();
        }

        private void EnableViewAssociatedLogsButtonIfNecessary()
        {
            var hasSingleItemSelected = page.SelectedItems.Count == 1;
            page.Details.ViewAssociatedLogsEnabled = hasSingleItemSelected &&
                                                     (logService.CountOfLogsAssociatedToTargetAlert(
                                                         page.FirstSelectedItem.IdValue) > 0);
        }

        protected override void SetDetailData(ITargetAlertDetails details, TargetAlert value)
        {
            SetDetails(details, value);
        }

        public static void SetDetails(ITargetAlertDetails details, TargetAlert value)
        {
            if (value != null)
            {
                details.TargetName = value.TargetName;
                details.FunctionalLocationName = value.FunctionalLocation.FullHierarchyWithDescription;
                details.WorkAssignmentName = value.WorkAssignmentName;
                details.Description = value.Description;
                details.TagName = value.Tag.Name;
                details.TagUnits = value.Tag.Units;
                details.Category = value.Category.Name;
                details.LastViolatedDateTime = value.LastViolatedDateTime;
                details.NeverToExceedMax = NullableDecimalAsString(value.NeverToExceedMaximum);
                details.Max = NullableDecimalAsString(value.MaxValue);
                details.Min = NullableDecimalAsString(value.MinValue);
                details.NeverToExceedMin = NullableDecimalAsString(value.NeverToExceedMinimum);
                details.TargetValue = value.TargetValue.Title;
                details.GapUnitValue = GapUnitValueAsString(value.GapUnitValue);
                details.GapUnitValueUnits = value.GapUnitValue.HasValue ? value.Tag.Units : string.Empty;
                details.ActualValue = NullableDecimalAsString(value.ActualValue);
                details.CalculatedLosses = LossesAsString(value.Losses);
                details.Schedule = value.Schedule;
                details.DocumentLinks = value.DocumentLinks;
            }
            else
            {
                details.TargetName = string.Empty;
                details.FunctionalLocationName = string.Empty;
                details.WorkAssignmentName = string.Empty;
                details.Description = string.Empty;
                details.TagName = string.Empty;
                details.TagUnits = string.Empty;
                details.Category = string.Empty;
                details.LastViolatedDateTime = null;
                details.NeverToExceedMax = string.Empty;
                details.Max = string.Empty;
                details.Min = string.Empty;
                details.NeverToExceedMin = string.Empty;
                details.TargetValue = string.Empty;
                details.GapUnitValue = string.Empty;
                details.GapUnitValueUnits = string.Empty;
                details.ActualValue = string.Empty;
                details.CalculatedLosses = string.Empty;
                details.Schedule = null;
                details.DocumentLinks = new List<DocumentLink>();
            }
        }

        protected override bool ShouldBeDisplayed(TargetAlert item)
        {
            return TargetAlertStatus.AllNeedingAttention.Contains(item.Status);
        }
        //RITM0252906-changed by Mukesh
        private static string NullableDecimalAsString(decimal? value)
        {
            return value.HasValue ? value.Value.ToString("N3") : String.Empty;//return value.Format();
        }

        private static string LossesAsString(decimal? losses)
        {
            if (losses.HasValue)
            {
                return losses.Value.ToCurrencyForLosses();
            }
            return string.Empty;
        }


        private static string GapUnitValueAsString(decimal? guv)
        {
            if (guv.HasValue)
            {
                return guv.Value.ToCurrency();
            }

            return string.Empty;
        }

        protected override TargetAlertDTO CreateDTOFromDomainObject(TargetAlert targetAlert)
        {
            return new TargetAlertDTO(targetAlert);
        }

        protected override IList<TargetAlertDTO> GetDtos(Range<Date> dateRange)
        {
            return service.QueryDTOsNeedingAttention(ClientSession.GetUserContext().RootFlocSet, dateRange);
        }
    }
}