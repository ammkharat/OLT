using System;
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
    public class PermitRequestMontrealTemplatePagePresenter :
        AbstractPermitRequestPagePresenter
            <PermitRequestMontrealDTO, PermitRequestMontreal, IPermitRequestMontrealDetails, IPermitRequestMontrealPage>
    {
        private readonly IMontrealPermitRequestMultiDayImportService importService;
        private readonly IPermitRequestMontrealService permitRequestService;
        private readonly IWorkPermitMontrealService workPermitMontrealService;

        public PermitRequestMontrealTemplatePagePresenter()
            : base(new PermitRequestMontrealTemplatePage())
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

            //page.Details.MarkAsTemplate += MarkAsTemplate;
            page.Details.RefreshAll += RefreshAll;

            page.Details.EditTemplate += EditTemplate; //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Submit -= Details_Submit;
            page.Details.Import -= Details_Import;
            page.Details.Clone -= Details_Clone;

            //page.Details.MarkAsTemplate -= MarkAsTemplate;
            page.Details.RefreshAll -= RefreshAll;

            page.Details.EditTemplate -= EditTemplate; //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
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
            details.DeleteVisible = hasSingleItemSelected;
                //hasItemsSelected && authorized.ToDeletePermitRequest(userRoleElements, baseDTOs, userContext.User);

            details.editVisible = false;
                //hasSingleItemSelected && authorized.ToEditPermitRequest(userRoleElements, selectedDTOs, userContext.User);

            details.editTemplateVisible = hasSingleItemSelected;

            details.editHistoryButtonVisible = false;
            details.submitButtonVisible = false;
            details.MarkTemplateEnabled = false;
            details.CloneEnabled = hasSingleItemSelected && (authorized.ToClonePermitRequest(userRoleElements));
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
            //item.LastModifiedBy = ClientSession.GetUserContext().User;
            //item.LastModifiedDateTime = Clock.Now;
            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Remove, item);

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

            List<PermitRequestMontrealDTO> permitDtos = page.SelectedItems;
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

        protected override bool IsItemInDateRange(PermitRequestMontreal item, Range<Date> range)
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
        //    PermitRequestMontreal permitRequest = QueryForFirstSelectedItem();
        //    permitRequest.TemplateName = nameForm.WorkPermitTemplateName;


        //    if (permitRequest.TemplateName != string.Empty)
        //    {
        //        permitRequest.IsTemplate = true;
        //        permitRequest.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;

        //    }
        //    else
        //    {
        //        permitRequest.IsTemplate = false;

        //    }

        //    //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.Update(permitRequest), permitRequest);

        //    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Update, permitRequest);
        //}

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void EditTemplate(object sender, EventArgs e)
        {
            //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

            List<PermitRequestMontrealDTO> permitDtos = page.SelectedItems;
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

                PermitRequestMontreal workPermit = QueryForFirstSelectedItem();
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