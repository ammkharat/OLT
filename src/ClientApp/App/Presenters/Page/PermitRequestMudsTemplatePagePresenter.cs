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
    public class PermitRequestMudsTemplatePagePresenter :
        AbstractPermitRequestPagePresenter
            <PermitRequestMudsDTO, PermitRequestMuds, IPermitRequestMudsDetails, IPermitRequestMudsPage>
    {
        private readonly IMudsPermitRequestMultiDayImportService importService;
        private readonly IPermitRequestMudsService permitRequestService;
        private readonly IWorkPermitMudsService workPermitMontrealService;

        public PermitRequestMudsTemplatePagePresenter()
            : base(new PermitRequestMudsTemplatePage())
        {
            permitRequestService = ClientServiceRegistry.Instance.GetService<IPermitRequestMudsService>();
            workPermitMontrealService = ClientServiceRegistry.Instance.GetService<IWorkPermitMudsService>();
            importService = ClientServiceRegistry.Instance.GetService<IMudsPermitRequestMultiDayImportService>();

            SubscribeToEvents();
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_PermitRequest; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.MudsPermitRequests; }
        }

        private void SubscribeToEvents()
        {
            page.Details.Submit += Details_Submit;
            page.Details.Import += Details_Import;
            page.Details.Clone += Details_Clone;

            page.Details.RefreshAll += RefreshAll;

            //page.Details.MarkAsTemplate += MarkAsTemplate;

            page.Details.EditTemplate += EditTemplate; //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Submit -= Details_Submit;
            page.Details.Import -= Details_Import;
            page.Details.Clone -= Details_Clone;

            page.Details.RefreshAll -= RefreshAll;

            page.Details.EditTemplate -= EditTemplate; //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature*-

            //page.Details.MarkAsTemplate -= MarkAsTemplate;

            
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
                SubmitPermitRequests<PermitRequestMudsDTO> submitPermitRequests = SubmitPermitRequests;
                CheckPermitRequestAssociationAlreadyExists<PermitRequestMudsDTO>
                    checkPermitRequestAssociationAlreadyExists =
                        (workPermitDate, requestDtos) =>
                            workPermitMontrealService.DoesPermitRequestMudsAssociationExist(requestDtos,
                                workPermitDate);
                var presenter = new SubmitPermitRequestFormPresenter<PermitRequestMudsDTO>(dtos,
                    submitPermitRequests, checkPermitRequestAssociationAlreadyExists,
                    new SubmitPermitRequestFormPresenterHelper<PermitRequestMudsDTO>());
                presenter.Run(page.ParentForm);
            }
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestMudsDTO> requestDtos, User user)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Submit,
                workPermitDate, requestDtos, user);
        }

        private void Details_Import(object sender, EventArgs e)
        {
            var presenter = new ImportPermitRequestMultiDayFormPresenter(importService, 7);
            presenter.Run(page.ParentForm);
        }

        protected override PermitRequestMuds QueryByDto(PermitRequestMudsDTO dto)
        {
            return permitRequestService.QueryById(dto.IdValue);
        }

        protected override IList<PermitRequestMudsDTO> GetDtos(Range<Date> range)
        {
            if (page.TabText == StringResources.PermitRequestTemplates)
            {
                var username = ClientSession.GetUserContext().User.Username;
                return permitRequestService.QueryByFlocUnitAndBelowForTemlate(userContext.RootFlocSet, new DateRange(range), username);
            }
            else
            {
                return permitRequestService.QueryByFlocUnitAndBelow(userContext.RootFlocSet, new DateRange(range));
            }
            
        }

        protected override PermitRequestMudsDTO CreateDTOFromDomainObject(PermitRequestMuds item)
        {
            return new PermitRequestMudsDTO(item);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            //remoteEventRepeater.ServerPermitRequestMudsCreated += repeater_Created;
            //remoteEventRepeater.ServerPermitRequestMudsUpdated += repeater_Updated;
            //remoteEventRepeater.ServerPermitRequestMudsRemoved += repeater_Removed;
            repeater.ServerPermitRequestMudsTemplateCreated += repeater_Created;
            
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            //remoteEventRepeater.ServerPermitRequestMudsCreated -= repeater_Created;
            //remoteEventRepeater.ServerPermitRequestMudsUpdated -= repeater_Updated;
            //remoteEventRepeater.ServerPermitRequestMudsRemoved -= repeater_Removed;
            repeater.ServerPermitRequestMudsTemplateCreated -= repeater_Created;
        }

        protected override void ControlDetailButtons()
        {
            var selectedDTOs = page.SelectedItems;
            var baseDTOs = selectedDTOs.ConvertAll(dto => (BasePermitRequestDTO) dto);
            var hasSingleItemSelected = selectedDTOs.Count == 1;
            var hasItemsSelected = selectedDTOs.Count > 0;

            var userRoleElements = userContext.UserRoleElements;

            var details = page.Details;


            details.DeleteVisible = hasSingleItemSelected;
            //hasItemsSelected && authorized.ToDeletePermitRequest(userRoleElements, baseDTOs, userContext.User);

            details.editVisible = false;
            details.editTemplateVisible = hasSingleItemSelected;
                
                //hasSingleItemSelected && authorized.ToEditPermitRequest(userRoleElements, selectedDTOs, userContext.User);
            
            details.editHistoryButtonVisible = false;
            details.submitButtonVisible = false;
            details.MarkTemplateEnabled = false;
            details.CloneEnabled = hasSingleItemSelected && (authorized.ToClonePermitRequest(userRoleElements));
        }

        protected override void SetDetailData(IPermitRequestMudsDetails details, PermitRequestMuds item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(PermitRequestMuds item)
        {
            return new EditPermitRequestMudsHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(PermitRequestMuds item)
        {
            var presenter = new PermitRequestMudsFormPresenter(item);
            return presenter.View;
        }

        protected override void Delete(PermitRequestMuds item)
        {
            //item.LastModifiedBy = ClientSession.GetUserContext().User;
            //item.LastModifiedDateTime = Clock.Now;
            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Remove, item);
//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

            List<PermitRequestMudsDTO> permitDtos = page.SelectedItems;
            try
            {
                item.LastModifiedBy = ClientSession.GetUserContext().User;
                item.LastModifiedDateTime = Clock.Now;
                if (permitDtos.Count == 1)
                {
                    item.TemplateId = permitDtos[0].TemplateId;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.RemoveTemplate, item);
                }

            }
            catch
            {
                //page.DisplayInvalidActionMessage(
                //    StringResources.WorkPermitDeletionFailureMessageBoxText,
                //    StringResources.WorkPermitDeletionFailureMessageBoxCaption);
            }
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForPermitRequests(userContext.SiteConfiguration);
        }

        protected override bool IsItemInDateRange(PermitRequestMuds item, Range<Date> range)
        {
            // regardless of the date range, in this case if the item was created by the user then the item should show up on add/update/delete.
            if (Nullable.Equals(userContext.User.Id, item.CreatedBy.Id))
                return true;

            var theDateRange = new DateRange(range ?? GetDefaultDateRange());
            return theDateRange.Overlaps(item.StartDate.ToDateTimeAtStartOfDay(), item.EndDate.ToDateTimeAtStartOfDay());
        }

        //private void MarkAsTemplate(object sender, EventArgs e)
        //{
        //    bool isWorkPermit = false;
        //    MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);
        //    nameForm.ShowDialog();
        //    PermitRequestMuds workPermit = QueryForFirstSelectedItem();
        //    workPermit.TemplateName = nameForm.WorkPermitTemplateName;


        //    if (workPermit.TemplateName != string.Empty)
        //    {
        //        workPermit.IsTemplate = true;
        //        workPermit.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;

        //    }
        //    else
        //    {
        //        workPermit.IsTemplate = false;

        //    }

        //    //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.Update(permitRequest), permitRequest);

        //    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Update, workPermit);
        //}

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void EditTemplate(object sender, EventArgs e)
        {
            //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

            List<PermitRequestMudsDTO> permitDtos = page.SelectedItems;
            if (permitDtos.Count == 1)
            {
                bool isWorkPermit = false;
                MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);

                nameForm.WorkPermitTemplateName = permitDtos[0].TemplateName;
                nameForm.Category = permitDtos[0].Categories;
                nameForm.Global = permitDtos[0].Global;

                if (nameForm.Global)
                {
                    nameForm.Individual = false;
                }
                else
                {
                    nameForm.Individual = true;
                }

                nameForm.ShowDialog();

                PermitRequestMuds workPermit = QueryForFirstSelectedItem();
                workPermit.TemplateName = nameForm.WorkPermitTemplateName;
                workPermit.Categories = nameForm.Category;
                workPermit.Global = nameForm.Global;
                workPermit.Individual = nameForm.Individual;

                workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
                workPermit.LastModifiedDateTime = Clock.Now;

                var wp = permitRequestService.QueryByIdTemplate(workPermit.IdValue, workPermit.TemplateName, workPermit.Categories);

                if (wp != null)
                {
                    if (workPermit.TemplateName == wp._templateName && workPermit.Categories == wp._categories && nameForm.Save != false)
                    {
                        OltMessageBox.ShowError("Same Template Name and Category entry is already present. " +
                                                "Cannot proceed further, please change the Temlate name and Category");
                    }
                }
                else
                {
                    if (workPermit.TemplateName != string.Empty)
                    {
                        workPermit.TemplateId = permitDtos[0].TemplateId;
                        workPermit.IsTemplate = true;
                        workPermit.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;
                        ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.UpdateTemplate, workPermit);
                    }
                    else
                    {
                        workPermit.IsTemplate = false;
                    }
                }


            }
        }

    }
}