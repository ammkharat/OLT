﻿using System;
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
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PermitRequestEdmontonTemplatePagePresenter : AbstractPermitRequestPagePresenter<PermitRequestEdmontonDTO, PermitRequestEdmonton, IPermitRequestEdmontonDetails, IPermitRequestEdmontonPage>
    {
        protected readonly IPermitRequestEdmontonService permitRequestEdmontonService;
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;

        public PermitRequestEdmontonTemplatePagePresenter(PageKey pageKey)
            : base(new PermitRequestEdmontonTemplatePage(pageKey))
        {
            permitRequestEdmontonService = ClientServiceRegistry.Instance.GetService<IPermitRequestEdmontonService>();
            workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            page.Details.Submit += Details_Submit;
            page.Details.Import += Details_Import;
            page.Details.Clone += Details_Clone;

            page.Details.MarkAsTemplate += MarkAsTemplate;

            page.Details.RefreshAll += RefreshAll;

            page.Details.EditTemplate += EditTemplate; //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Submit -= Details_Submit;
            page.Details.Import -= Details_Import;
            page.Details.Clone -= Details_Clone;

            page.Details.MarkAsTemplate -= MarkAsTemplate;
            page.Details.RefreshAll -= RefreshAll;

            page.Details.EditTemplate -= EditTemplate; //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        }

        private void Details_Submit(object sender, EventArgs e)
        {
            List<PermitRequestEdmontonDTO> dtos = page.SelectedItems;
            if (dtos.Count > 0)
            {
                SubmitPermitRequests<PermitRequestEdmontonDTO> submitPermitRequests = SubmitPermitRequests;
                CheckPermitRequestAssociationAlreadyExists<PermitRequestEdmontonDTO> shouldGoAheadWithTheSubmissionProcess =
                    (workPermitDate, requestDtos) => workPermitEdmontonService.DoesPermitRequestEdmontonAssociationExist(requestDtos, workPermitDate);

                SubmitPermitRequestEdmontonFormPresenter presenter =
                    new SubmitPermitRequestEdmontonFormPresenter(dtos, submitPermitRequests, shouldGoAheadWithTheSubmissionProcess, false);
                presenter.Run(page.ParentForm);
            }
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestEdmontonDTO> requestDtos, User user)
        {
            if (requestDtos.Count == 0)
            {
                OltMessageBox.Show(page.ParentForm, "There were no permit requests found for the provided criteria.");
            }
            else
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.Submit, workPermitDate, requestDtos, user);
            }
        }

        private void Details_Clone(object sender, EventArgs e)
        {
            PermitRequestEdmonton permitRequest = QueryForFirstSelectedItem();
            //permitRequest.ConvertToClone(userContext.User);
            //mangesh - Clone
            string formList = permitRequest.ConvertToCloneNew(userContext.User);
            if (formList != string.Empty)
            {
                DialogResult est = OltMessageBox.Show(page.ParentForm,
                    "Following forms were not extended as they have expired\n\n" + formList +
                    "\nDo You Want to continue.", "Messege",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (est.Equals(DialogResult.No) || est.Equals(DialogResult.Cancel))
                {
                    return;
                }
            }

            IForm form = CreateEditForm(permitRequest);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void Details_Import(object sender, EventArgs e)
        {
            ImportPermitRequestEdmontonFormPresenter presenter = new ImportPermitRequestEdmontonFormPresenter(permitRequestEdmontonService);
            presenter.Run(page.ParentForm);
        }

        protected override PermitRequestEdmonton QueryByDto(PermitRequestEdmontonDTO dto)
        {
            return permitRequestEdmontonService.QueryById(dto.IdValue);
        }

        protected override IList<PermitRequestEdmontonDTO> GetDtos(Range<Date> range)
        {
            DateRange queryDateRange = new DateRange(range);

            if (page.TabText == StringResources.PermitRequestTemplates)
            {
                var username = ClientSession.GetUserContext().User.Username;
                return permitRequestEdmontonService.QueryByDateRangeAndFlocsForTemplate(userContext.RootFlocSetForWorkPermits, queryDateRange, username);
            }

            else if (userContext.HasFlocsForWorkPermits)
            {
                return permitRequestEdmontonService.QueryByDateRangeAndFlocsForAllButTurnaround(userContext.RootFlocSetForWorkPermits, queryDateRange);
            }
            else
            {
                return permitRequestEdmontonService.QueryByDateRangeAndFlocsForAllButTurnaround(userContext.RootFlocSet, queryDateRange);
            }
        }

        protected override PermitRequestEdmontonDTO CreateDTOFromDomainObject(PermitRequestEdmonton item)
        {
            return new PermitRequestEdmontonDTO(item);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_PermitRequest; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerPermitRequestEdmontonCreated += repeater_Created;
            remoteEventRepeater.ServerPermitRequestEdmontonUpdated += repeater_Updated;
            remoteEventRepeater.ServerPermitRequestEdmontonRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerPermitRequestEdmontonCreated -= repeater_Created;
            remoteEventRepeater.ServerPermitRequestEdmontonUpdated -= repeater_Updated;
            remoteEventRepeater.ServerPermitRequestEdmontonRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
            List<PermitRequestEdmontonDTO> selectedDTOs = page.SelectedItems;
            List<BasePermitRequestDTO> baseDTOs = selectedDTOs.ConvertAll(item => (BasePermitRequestDTO) item);
            bool hasSingleItemSelected = selectedDTOs.Count == 1;
            bool hasItemsSelected = selectedDTOs.Count > 0;

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            IPermitRequestEdmontonDetails details = page.Details;
            details.DeleteVisible = hasSingleItemSelected;
                //hasItemsSelected && authorized.ToDeletePermitRequest(userRoleElements, baseDTOs, userContext.User);

            details.editVisible = false;
                //hasSingleItemSelected && authorized.ToEditPermitRequest(userRoleElements, selectedDTOs);

            details.editHistoryButtonVisible = false;
            details.submitButtonVisible = false;
            details.MarkTemplateEnabled = false;
            details.CloneEnabled = hasSingleItemSelected && authorized.ToClonePermitRequest(userRoleElements);

            details.editTemplateVisible = hasSingleItemSelected;
        }

        protected override void SetDetailData(IPermitRequestEdmontonDetails details, PermitRequestEdmonton item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(PermitRequestEdmonton item)
        {
            return new EditPermitRequestEdmontonHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(PermitRequestEdmonton item)
        {
            PermitRequestEdmontonFormPresenter presenter = new PermitRequestEdmontonFormPresenter(item);
            return presenter.View;
        }

        protected override void Delete(PermitRequestEdmonton item)
        {
            //item.LastModifiedBy = ClientSession.GetUserContext().User;
            //item.LastModifiedDateTime = Clock.Now;
            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.Remove, item);

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

            List<PermitRequestEdmontonDTO> permitDtos = page.SelectedItems;
            try
            {
                item.LastModifiedBy = ClientSession.GetUserContext().User;
                item.LastModifiedDateTime = Clock.Now;
                if (permitDtos.Count == 1)
                {
                    item.TemplateId = permitDtos[0].TemplateId;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.RemoveTemplate, item);
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

        protected override bool IsItemInDateRange(PermitRequestEdmonton item, Range<Date> range)
        {
            return true;
            //if (item.CreatedBy.Id == userContext.User.Id)
            //{
            //    return true;
            //}
            //DateRange theRange = new DateRange(range ?? GetDefaultDateRange());
            //return theRange.Overlaps(item.RequestedStartDate.ToDateTimeAtStartOfDay(), item.EndDate.ToDateTimeAtStartOfDay());
        }

        protected override bool ShouldBeDisplayed(PermitRequestEdmonton item)
        {
            return true;//item.Group == null || (!item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P3.IdValue) && !item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P4.IdValue));
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.EdmontonTemplateorkPermits; }
        }

        private void MarkAsTemplate(object sender, EventArgs e)
        {
            //bool isWorkPermit = false;
            //MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);
            //nameForm.ShowDialog();
            //PermitRequestEdmonton permitRequest = QueryForFirstSelectedItem();
            //permitRequest.TemplateName = nameForm.WorkPermitTemplateName;
            //permitRequest.Categories = nameForm.Category;

            //if (permitRequest.TemplateName != string.Empty)
            //{
            //    permitRequest.IsTemplate = true;
            //    permitRequest.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;

            //}
            //else
            //{
            //    permitRequest.IsTemplate = false;

            //}

            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.Update, permitRequest);
        }

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void EditTemplate(object sender, EventArgs e)
        {
            //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

            List<PermitRequestEdmontonDTO> permitDtos = page.SelectedItems;
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

                PermitRequestEdmonton workPermit = QueryForFirstSelectedItem();
                workPermit.TemplateName = nameForm.WorkPermitTemplateName;
                workPermit.Categories = nameForm.Category;
                workPermit.Global = nameForm.Global;
                workPermit.Individual = nameForm.Individual;

                workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
                workPermit.LastModifiedDateTime = Clock.Now;

                var wp = permitRequestEdmontonService.QueryByIdTemplate(workPermit.IdValue, workPermit.TemplateName, workPermit.Categories);

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
                        ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.UpdateTemplate, workPermit);
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

