﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PermitRequestMontrealPagePresenter :
        AbstractPermitRequestPagePresenter
            <PermitRequestMontrealDTO, PermitRequestMontreal, IPermitRequestMontrealDetails, IPermitRequestMontrealPage>
    {
        private readonly IMontrealPermitRequestMultiDayImportService importService;
        private readonly IPermitRequestMontrealService permitRequestService;
        private readonly IWorkPermitMontrealService workPermitMontrealService;

        public PermitRequestMontrealPagePresenter() : base(new PermitRequestMontrealPage())
        {
            permitRequestService = ClientServiceRegistry.Instance.GetService<IPermitRequestMontrealService>();
            workPermitMontrealService = ClientServiceRegistry.Instance.GetService<IWorkPermitMontrealService>();
            importService = ClientServiceRegistry.Instance.GetService<IMontrealPermitRequestMultiDayImportService>();

            SubscribeToEvents();
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_PermitRequest; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.MontrealPermitRequests; }
        }

        private void SubscribeToEvents()
        {
            page.Details.Submit += Details_Submit;
            page.Details.Import += Details_Import;
            page.Details.Clone += Details_Clone;

            page.Details.MarkAsTemplate += MarkAsTemplate;
            page.Details.RefreshAll += RefreshAll;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Submit -= Details_Submit;
            page.Details.Import -= Details_Import;
            page.Details.Clone -= Details_Clone;

            page.Details.MarkAsTemplate -= MarkAsTemplate;
            page.Details.RefreshAll -= RefreshAll;
        }

        private void Details_Clone(object sender, EventArgs e)
        {
            var permitRequest = QueryForFirstSelectedItem();
            permitRequest.ConvertToClone(ClientSession.GetUserContext().User);

            var form = CreateEditForm(permitRequest);

            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void Details_Submit(object sender, EventArgs e)
        {
            var dtos = page.SelectedItems;
            if (dtos.Count > 0)
            {
                SubmitPermitRequests<PermitRequestMontrealDTO> submitPermitRequests = SubmitPermitRequests;
                CheckPermitRequestAssociationAlreadyExists<PermitRequestMontrealDTO>
                    checkPermitRequestAssociationAlreadyExists =
                        (workPermitDate, requestDtos) =>
                            workPermitMontrealService.DoesPermitRequestMontrealAssociationExist(requestDtos,
                                workPermitDate);
                var presenter = new SubmitPermitRequestFormPresenter<PermitRequestMontrealDTO>(dtos,
                    submitPermitRequests, checkPermitRequestAssociationAlreadyExists,
                    new SubmitPermitRequestFormPresenterHelper<PermitRequestMontrealDTO>());
                presenter.Run(page.ParentForm);
            }
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestMontrealDTO> requestDtos, User user)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Submit,
                workPermitDate, requestDtos, user);
        }

        private void Details_Import(object sender, EventArgs e)
        {
            var presenter = new ImportPermitRequestMultiDayFormPresenter(importService, 7);
            presenter.Run(page.ParentForm);
        }

        protected override PermitRequestMontreal QueryByDto(PermitRequestMontrealDTO dto)
        {
            return permitRequestService.QueryById(dto.IdValue);
        }

        protected override IList<PermitRequestMontrealDTO> GetDtos(Range<Date> range)
        {
            if (page.TabText == StringResources.PermitRequestTemplates) //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            {
                var username = ClientSession.GetUserContext().User.Username;
                return permitRequestService.QueryByFlocUnitAndBelowForTemlate(userContext.RootFlocSet, new DateRange(range), username);
            }
            else
            {
                return permitRequestService.QueryByFlocUnitAndBelow(userContext.RootFlocSet, new DateRange(range)); 
            }
            
        }

        protected override PermitRequestMontrealDTO CreateDTOFromDomainObject(PermitRequestMontreal item)
        {
            return new PermitRequestMontrealDTO(item);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerPermitRequestCreated += repeater_Created;
            remoteEventRepeater.ServerPermitRequestUpdated += repeater_Updated;
            remoteEventRepeater.ServerPermitRequestRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerPermitRequestCreated -= repeater_Created;
            remoteEventRepeater.ServerPermitRequestUpdated -= repeater_Updated;
            remoteEventRepeater.ServerPermitRequestRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
            var selectedDTOs = page.SelectedItems;
            var baseDTOs = selectedDTOs.ConvertAll(dto => (BasePermitRequestDTO) dto);
            var hasSingleItemSelected = selectedDTOs.Count == 1;
            var hasItemsSelected = selectedDTOs.Count > 0;

            var userRoleElements = userContext.UserRoleElements;

            var details = page.Details;
            details.DeleteEnabled = hasItemsSelected &&
                                    authorized.ToDeletePermitRequest(userRoleElements, baseDTOs, userContext.User);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditPermitRequest(userRoleElements, selectedDTOs, userContext.User);
            details.CloneEnabled = hasSingleItemSelected && (authorized.ToClonePermitRequest(userRoleElements));
            details.ViewEditHistoryEnabled = hasSingleItemSelected;

            details.editTemplateVisible = false;

            details.SubmitEnabled =
                hasItemsSelected &&
                authorized.ToSubmitPermitRequest(userRoleElements) &&
                selectedDTOs.TrueForAll(
                    obj =>
                        obj.CompletionStatus == PermitRequestCompletionStatus.Complete && obj.EndDate >= Clock.DateNow);

            details.ImportEnabled = authorized.ToImportPermitRequests(userRoleElements);

            details.MarkTemplateEnabled = hasSingleItemSelected &&
                                              ClientSession.GetUserContext()
                                                  .SiteConfiguration.EnableTemplateFeatureForWorkPermit &&
                                              (authorized.ToCreatePermitRequest(userRoleElements));
        }

        protected override void SetDetailData(IPermitRequestMontrealDetails details, PermitRequestMontreal item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(PermitRequestMontreal item)
        {
            return new EditPermitRequestMontrealHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(PermitRequestMontreal item)
        {
            var presenter = new PermitRequestMontrealFormPresenter(item);
            return presenter.View;
        }

        protected override void Delete(PermitRequestMontreal item)
        {
            item.LastModifiedBy = ClientSession.GetUserContext().User;
            item.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Remove, item);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForPermitRequests(userContext.SiteConfiguration);
        }

        protected override bool IsItemInDateRange(PermitRequestMontreal item, Range<Date> range)
        {
            // regardless of the date range, in this case if the item was created by the user then the item should show up on add/update/delete.
            if (Nullable.Equals(userContext.User.Id, item.CreatedBy.Id))
                return true;

            var theDateRange = new DateRange(range ?? GetDefaultDateRange());
            return theDateRange.Overlaps(item.StartDate.ToDateTimeAtStartOfDay(), item.EndDate.ToDateTimeAtStartOfDay());
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        private void MarkAsTemplate(object sender, EventArgs e)
        {
            bool isWorkPermit = false;
            MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);
            nameForm.ShowDialog();
            PermitRequestMontreal permitRequest = QueryForFirstSelectedItem();
            permitRequest.TemplateName = nameForm.WorkPermitTemplateName;
            permitRequest.Categories = nameForm.Category;
            permitRequest.Global = nameForm.Global;
            permitRequest.Individual = nameForm.Individual;

            var wp = permitRequestService.QueryByIdTemplate(permitRequest.IdValue, permitRequest.TemplateName, permitRequest.Categories);

            if (wp != null)
            {
                if (permitRequest.TemplateName == wp._templateName && permitRequest.Categories == wp._categories)
                {
                    OltMessageBox.ShowError("Same Template Name and Category entry is already present. " +
                                            "Cannot proceed further, please change the Temlate name and Category");
                }
            }
            else
            {
                if (permitRequest.TemplateName != string.Empty && nameForm.Save == true)
                {
                    permitRequest.IsTemplate = true;
                    permitRequest.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Update, permitRequest);
                }
                else
                {
                    permitRequest.IsTemplate = false;
                }
            }
        }

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}