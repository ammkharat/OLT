using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PermitRequestLubesPagePresenter : AbstractPermitRequestPagePresenter<PermitRequestLubesDTO, PermitRequestLubes, IPermitRequestLubesDetails, IPermitRequestLubesPage>
    {
        private readonly IPermitRequestLubesService permitRequestService;
        private readonly ILubesPermitRequestMultiDayImportService importService;
        private readonly IWorkPermitLubesService workPermitService;

        public PermitRequestLubesPagePresenter() : base(new PermitRequestLubesPage())
        {
            permitRequestService = ClientServiceRegistry.Instance.GetService<IPermitRequestLubesService>();
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitLubesService>();
            importService = ClientServiceRegistry.Instance.GetService<ILubesPermitRequestMultiDayImportService>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            page.Details.Import += HandleImportButtonClicked;
            page.Details.Submit += HandleSubmitButtonClicked;
            page.Details.Clone += HandleCloneButtonClicked;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Import -= HandleImportButtonClicked;
            page.Details.Submit -= HandleSubmitButtonClicked;
            page.Details.Clone -= HandleCloneButtonClicked;
        }

        private void HandleSubmitButtonClicked(object sender, EventArgs e)
        {
            List<PermitRequestLubesDTO> dtos = page.SelectedItems;
            if (dtos.Count > 0)
            {
                SubmitPermitRequests<PermitRequestLubesDTO> submitPermitRequests = SubmitPermitRequests;
                CheckPermitRequestAssociationAlreadyExists<PermitRequestLubesDTO> shouldGoAheadWithTheSubmissionProcess =
                    (workPermitDate, requestDtos) => workPermitService.DoesPermitRequestLubesAssociationExist(requestDtos, workPermitDate);

                SubmitPermitRequestLubesFormPresenter presenter =
                    new SubmitPermitRequestLubesFormPresenter(dtos, submitPermitRequests, shouldGoAheadWithTheSubmissionProcess, false);
                presenter.Run(page.ParentForm);
            }
        }
        
        private void HandleCloneButtonClicked()
        {
            PermitRequestLubes permitRequest = QueryForFirstSelectedItem();
            permitRequest.ConvertToClone(userContext.User, userContext.Role, userContext.UserShift);

            IForm form = CreateEditForm(permitRequest);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestLubesDTO> requestDtos, User user)
        {
            if (requestDtos.Count == 0)
            {
                OltMessageBox.Show(page.ParentForm, StringResources.PermitRequestLubes_NoPermitRequestsFound);
            }
            else
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Submit, workPermitDate, requestDtos, user);
            }
        }

        private void HandleImportButtonClicked(object sender, EventArgs e)
        {
            ImportPermitRequestMultiDayFormPresenter presenter = new ImportPermitRequestMultiDayFormPresenter(importService, 14);
            presenter.Run(page.ParentForm);
        }

        protected override PermitRequestLubes QueryByDto(PermitRequestLubesDTO dto)
        {
            return permitRequestService.QueryById(dto.IdValue);
        }

        protected override IList<PermitRequestLubesDTO> GetDtos(Range<Date> dateRange)
        {
            return permitRequestService.QueryByDateRangeAndFlocs(userContext.RootFlocSet, new DateRange(dateRange));
        }

        protected override PermitRequestLubesDTO CreateDTOFromDomainObject(PermitRequestLubes item)
        {
            return new PermitRequestLubesDTO(item);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_PermitRequest; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerPermitRequestLubesCreated += repeater_Created;
            remoteEventRepeater.ServerPermitRequestLubesUpdated += repeater_Updated;
            remoteEventRepeater.ServerPermitRequestLubesRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerPermitRequestLubesCreated -= repeater_Created;
            remoteEventRepeater.ServerPermitRequestLubesUpdated -= repeater_Updated;
            remoteEventRepeater.ServerPermitRequestLubesRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            List<PermitRequestLubesDTO> selectedDtos = page.SelectedItems;
            bool hasSingleItemSelected = selectedDtos.Count == 1;
            bool hasItemsSelected = selectedDtos.Count > 0;

            bool atLeastOneIsExpired = selectedDtos.Exists(pr => PermitRequestCompletionStatus.Expired.Equals(pr.CompletionStatus));

            IPermitRequestLubesDetails details = page.Details;
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditPermitRequest(userContext, selectedDtos[0]) && !atLeastOneIsExpired;
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.ImportEnabled = authorized.ToImportPermitRequests(userRoleElements);
            details.SubmitEnabled =
                hasItemsSelected &&
                authorized.ToSubmitPermitRequest(userRoleElements) &&
                selectedDtos.TrueForAll(obj => obj.EndDate >= Clock.DateNow && PermitRequestLubes.IsSubmittableStatus(obj.CompletionStatus));
            details.CloneEnabled = hasSingleItemSelected && authorized.ToClonePermitRequest(userRoleElements);
            details.DeleteEnabled = hasItemsSelected && authorized.ToDeletePermitRequests(userContext, selectedDtos) && !atLeastOneIsExpired;
        }

        protected override void SetDetailData(IPermitRequestLubesDetails details, PermitRequestLubes item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(PermitRequestLubes item)
        {
            return new EditPermitRequestLubesHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(PermitRequestLubes item)
        {
            PermitRequestLubesFormPresenter presenter = new PermitRequestLubesFormPresenter(item);
            return presenter.View;
        }

        protected override void Delete(PermitRequestLubes item)
        {
            item.LastModifiedBy = ClientSession.GetUserContext().User;
            item.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Remove, item);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.LubesPermitRequests; }
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForPermitRequests(userContext.SiteConfiguration);
        }

        protected override bool IsItemInDateRange(PermitRequestLubes item, Range<Date> range)
        {
            if (item.CreatedBy.Id == userContext.User.Id)
            {
                return true;
            }
            DateRange theRange = new DateRange(range ?? GetDefaultDateRange());
            return theRange.Overlaps(item.RequestedStartDate.ToDateTimeAtStartOfDay(), item.EndDate.ToDateTimeAtStartOfDay());
        }
    }
}