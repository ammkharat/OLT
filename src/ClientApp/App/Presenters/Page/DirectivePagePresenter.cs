﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class DirectivePagePresenter :
        AbstractDeletableDomainPagePresenter<DirectiveDTO, Directive, IDirectiveDetails, IDirectivePage>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (DirectivePagePresenter));
        private readonly HashSet<long> idsOfDirectivesReadByCurrentUser = new HashSet<long>();

        private readonly IReportPrintManager<Directive> reportPrintManager;

        private readonly IDirectiveService service;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly DirectiveTimerManager timerManager;

        public DirectivePagePresenter() : base(new DirectivePage())
        {
            service = ClientServiceRegistry.Instance.GetService<IDirectiveService>();

            timerManager = new DirectiveTimerManager();

            // get the synchronization context for the current thread, which is the UI thread, which results in a WindowsFormsSynchronizationContext;
            // see http://blogs.msdn.com/b/kaelr/archive/2007/09/05/synchronizationcallback.aspx?Redirected=true
            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;

            reportPrintManager =
                new ReportPrintManager<Directive, DirectiveReport, DirectiveReportAdapter>(new DirectivePrintActions());

            page.Details.Expire += HandleExpire;
            page.Details.Clone += HandleClone;
            page.Details.Print += HandlePrint;
            page.Details.Preview += HandlePreview;
            page.Disposed += HandleFormDisposed;
            page.Details.MarkedAsReadByToggled += HandleMarkedAsReadByToggled;
            page.Details.MarkAsRead += HandleMarkAsRead;
            page.Details.MarkAsNotRead += HandleMarkAsNotRead;
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_DailyDirective; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.Directives; }
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();

            page.Details.Expire -= HandleExpire;
            page.Details.Clone -= HandleClone;
            page.Details.Print -= HandlePrint;
            page.Details.Preview -= HandlePreview;
            page.Disposed -= HandleFormDisposed;
            page.Details.MarkedAsReadByToggled -= HandleMarkedAsReadByToggled;
            page.Details.MarkAsRead -= HandleMarkAsRead;
            page.Details.MarkAsNotRead -= HandleMarkAsNotRead;//Added by PPanigrahi
        }

        private void HandleMarkAsRead()
        {
            var directive = QueryForFirstSelectedItem();
            if (directive != null)
            {
                service.MarkAsRead(directive.IdValue, userContext.User.IdValue, Clock.Now);
                idsOfDirectivesReadByCurrentUser.Add(directive.IdValue);
                ItemUpdated(directive);
                remoteEventRepeater.Dispatch(ApplicationEvent.DirectiveMarkedAsReadByCurrentUser, directive);
            }
        }

        private void HandleMarkAsNotRead()
        {
            var directive = QueryForFirstSelectedItem();
            if (directive != null)
            {
                Directive requeriedDirective = service.QueryById(directive.IdValue);
                MarkAsNotReadForm frm = new MarkAsNotReadForm(requeriedDirective.IdValue);
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        protected override Directive QueryByDto(DirectiveDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        protected override IList<DirectiveDTO> GetDtos(Range<Date> dateRange)
        {
            timerManager.Clear();

            var dtos = service.QueryDTOsByDateRangeAndFlocs(dateRange, userContext.RootFlocSet,
                userContext.ReadableVisibilityGroupIds, userContext.User.Id);

            foreach (var dto in dtos)
            {
                RegisterRenderTimer(dto);
            }

            if (!authorized.ToViewFutureDirectives(userContext.UserRoleElements))
            {
                dtos.RemoveAll(dto => dto.IsInFuture(Clock.Now));
            }

            idsOfDirectivesReadByCurrentUser.Clear();
            foreach (var dto in dtos)
            {
                if (dto.CreatedByUserId == userContext.User.IdValue)
                {
                    dto.IsReadByCurrentUser = true;
                }

                if (dto.IsReadByCurrentUser.HasValue && dto.IsReadByCurrentUser.Value)
                {
                    idsOfDirectivesReadByCurrentUser.Add(dto.IdValue);
                }
            }

            return dtos;
        }

        protected override void repeater_Created(object sender, DomainEventArgs<Directive> e)
        {
            var directive = e.SelectedItem;
            var dto = new DirectiveDTO(directive);
            RegisterRenderTimer(dto);

            base.repeater_Created(sender, e);
        }

        protected override void repeater_Updated(object sender, DomainEventArgs<Directive> e)
        {
            var directive = e.SelectedItem;
            var dto = new DirectiveDTO(directive);
            RegisterRenderTimer(dto);

            base.repeater_Updated(sender, e);
        }

        protected override void repeater_Removed(object sender, DomainEventArgs<Directive> e)
        {
            var directive = e.SelectedItem;
            var dto = new DirectiveDTO(directive);
            timerManager.Unregister(dto);
            base.repeater_Removed(sender, e);
        }

        protected override bool ShouldBeDisplayed(Directive item)
        {
            return authorized.ToViewFutureDirectives(userContext.UserRoleElements) ||
                   !(new DirectiveDTO(item).IsInFuture(Clock.Now));
        }

        protected override DirectiveDTO CreateDTOFromDomainObject(Directive item)
        {
            var dto = new DirectiveDTO(item);
            dto.IsReadByCurrentUser = dto.CreatedByUserId == userContext.User.IdValue ||
                                      idsOfDirectivesReadByCurrentUser.Contains(dto.IdValue);
            return dto;
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerDirectiveCreated += repeater_Created;
            remoteEventRepeater.ServerDirectiveUpdated += repeater_Updated;
            remoteEventRepeater.ServerDirectiveRemoved += repeater_Removed;
            remoteEventRepeater.ServerDirectiveMarkedAsReadByCurrentUser += repeater_MarkedAsReadByCurrentUser;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerDirectiveCreated -= repeater_Created;
            remoteEventRepeater.ServerDirectiveUpdated -= repeater_Updated;
            remoteEventRepeater.ServerDirectiveRemoved -= repeater_Removed;
            remoteEventRepeater.ServerDirectiveMarkedAsReadByCurrentUser -= repeater_MarkedAsReadByCurrentUser;
        }

        protected override void ControlDetailButtons()
        {
            var details = page.Details;

            var selectedItems = page.SelectedItems;
            var hasItemsSelected = selectedItems.Count > 0;
            var hasSingleItemSelected = selectedItems.Count == 1;

            var now = Clock.Now;

            details.PrintEnabled = hasItemsSelected;
            details.PrintPreviewEnabled = hasSingleItemSelected;
            details.CloneEnabled = hasSingleItemSelected && authorized.ToCreateDirectives(userContext.UserRoleElements);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditDirective(page.FirstSelectedItem, userContext, now);
            details.ExpireEnabled = hasItemsSelected &&
                                    authorized.ToExpireDirectives(page.SelectedItems, userContext, now);
            details.DeleteEnabled = hasItemsSelected &&
                                    authorized.ToDeleteDirectives(page.SelectedItems, userContext, now);
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.MarkAsReadEnabled = hasSingleItemSelected &&
                                        authorized.ToMarkDirectiveAsRead(userContext.User, selectedItems[0], now) &&
                                        !service.UserMarkedDirectiveAsRead(page.FirstSelectedItem.IdValue,
                                            userContext.User.IdValue);
        }

        protected override void SetDetailData(IDirectiveDetails details, Directive item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(Directive item)
        {
            return new EditDirectiveHistoryFormPresenter(item);
        }

        protected override void Edit(Directive directive)
        {
            if (directive.IsActive(Clock.Now))
            {
                if (ExpireAndCloneDirectiveIfRead(directive))
                {
                    return;
                }

                var dialogResult = page.ShowEditingActiveDirectiveWarning();

                if (!DialogResult.Yes.Equals(dialogResult))
                {
                    return;
                }
            }

            base.Edit(directive);
        }

        private bool ExpireAndCloneDirectiveIfRead(Directive directive)
        {
            var readByUsers = service.UsersThatMarkedDirectiveAsRead(directive.IdValue);
            if (readByUsers.IsNullOrEmpty()) return false;

            var result = page.ShowExpireAndCloneActiveReadDirectiveWarning();

            if (!DialogResult.Yes.Equals(result))
            {
                return true;
            }

            Expire(directive);

            CloneDirective(directive);

            return true;
        }

        protected override IForm CreateEditForm(Directive item)
        {
            var presenter = new DirectiveFormPresenter(item, false);
            return presenter.View;
        }

        protected override void Delete(Directive item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Remove, item,
                userContext.User);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForDirectives(userContext.SiteConfiguration);
        }

        protected override bool IsItemInDateRange(Directive directive, Range<Date> range)
        {
            if (directive.LastModifiedBy.Id == userContext.User.Id)
            {
                return true;
            }

            var dateRange = new DateRange(range ?? GetDefaultDateRange());
            return dateRange.Overlaps(directive.ActiveFromDateTime, directive.ActiveToDateTime);
        }

        private void HandleExpire(object sender, EventArgs e)
        {
            ExpireWithOkCancelDialog();
        }

        protected override IForm CreateEditFormForClone(Directive domainObject)
        {
            var presenter = new DirectiveFormPresenter(domainObject, true);
            return presenter.View;
        }

        private void CloneDirective(Directive directive)
        {
            var userSelectedFlocRoots = ClientSession.GetUserContext().RootsForSelectedFunctionalLocations;
            directive.ConvertToClone(ClientSession.GetUserContext().UserShift, ClientSession.GetUserContext().User,
                ClientSession.GetUserContext().Role, userSelectedFlocRoots);
            base.EditForClone(directive);
        }

        private void HandleClone(object sender, EventArgs e)
        {
            var selectedDirective = QueryForFirstSelectedItem();
            CloneDirective(selectedDirective);
        }

        private void ExpireWithOkCancelDialog()
        {
            var confirmed = page.ShowOKCancelDialog(
                string.Format(StringResources.AreYouSureExpireDialogMessage, DomainObjectName),
                string.Format(StringResources.ExpireDialogTitle, DomainObjectName));

            if (confirmed)
            {
                LockMultipleDomainObjects(Expire, () => page.ExpireSuccessfulMessage());
            }
        }

        protected void Expire(Directive item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Expire, item,
                userContext.User);
        }

        private void HandleFormDisposed(object sender, EventArgs e)
        {
            timerManager.Clear();
        }

        private void RegisterRenderTimer(DirectiveDTO dto)
        {
            timerManager.Unregister(dto);

            if (dto.IsExpired(Clock.Now))
            {
                return;
            }

            var now = Clock.Now;
            if (dto.IsInFuture(now))
            {
                var timeUntilStartOfDirective = dto.ActiveFromDateTime.Subtract(now);
                SetupTimerCallback(timeUntilStartOfDirective, dto);
            }
            else // dto is active
            {
                var timeUntilDirectiveIsExpired = dto.ActiveToDateTime.Subtract(now);
                SetupTimerCallback(timeUntilDirectiveIsExpired, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, DirectiveDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(DirectiveDTO dto, TimeSpan differenceInTime)
        {
            try
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
            catch (TimerDueTimeNegativeException e)
            {
                logger.Error("Encountered negative timer due time for directive:<" + dto.Id + ">", e);
            }
        }

        private void HandleTimerFire(object dto)
        {
            // we are often in a background thread at this point but we need to manipulate the UI, so we make sure to do
            // the real work on the UI thread
            synchronizationContext.Post(RefreshItem, dto);
        }

        private void RefreshItem(object dto)
        {
            if (!(dto is DirectiveDTO)) return;
            var directiveDto = (DirectiveDTO) dto;
            RegisterRenderTimer(directiveDto);

            var oldVersion = page.Grid.FindItem(directiveDto.Id);
            var updateIndex = page.Grid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                page.Grid.AddItem(directiveDto);
            }
            else
            {
                page.Grid.UpdateItem(updateIndex, directiveDto);
            }
        }

        private void HandleMarkedAsReadByToggled(Directive directive)
        {
            page.Details.MarkedAsReadBy = service.UsersThatMarkedDirectiveAsRead(directive.IdValue);
        }

        private void repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<Directive> e)
        {
            if (page.IsDisposed || e.SelectedItem == null)
            {
                return;
            }

            page.Invoke(
                new Action<Directive>(Invoked_Repeater_MarkedAsReadByCurrentUser),
                e.SelectedItem);
        }

        private void Invoked_Repeater_MarkedAsReadByCurrentUser(Directive directive)
        {
            if (directive != null && !idsOfDirectivesReadByCurrentUser.Contains(directive.IdValue))
            {
                idsOfDirectivesReadByCurrentUser.Add(directive.IdValue);
                ItemUpdated(directive);
            }

            // directive may have been removed from the grid when column filters are applied; if so, put it back in and select it
            var directiveDto = new DirectiveDTO(directive);
            page.Grid.SelectItemByReference(directiveDto);
        }

        private void HandlePrint(object sender, EventArgs e)
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(ConvertAllTo(page.SelectedItems));
        }

        private void HandlePreview(object sender, EventArgs e)
        {
            Directive directive = QueryForFirstSelectedItem();

            directive.itemReadBy=service.UsersThatMarkedDirectiveAsRead(directive.IdValue);
          
           // reportPrintManager.PreviewReport(QueryForFirstSelectedItem());

            reportPrintManager.PreviewReport(directive);

        }
    }
}