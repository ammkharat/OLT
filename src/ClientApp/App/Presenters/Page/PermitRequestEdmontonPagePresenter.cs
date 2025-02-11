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
    public class PermitRequestEdmontonPagePresenter : AbstractPermitRequestPagePresenter<PermitRequestEdmontonDTO, PermitRequestEdmonton, IPermitRequestEdmontonDetails, IPermitRequestEdmontonPage>
    {
        protected readonly IPermitRequestEdmontonService permitRequestEdmontonService;
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;

        public PermitRequestEdmontonPagePresenter(PageKey pageKey) : base(new PermitRequestEdmontonPage(pageKey))
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

            if (page.TabText == StringResources.PermitRequestTemplates)  //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
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
            details.DeleteEnabled = hasItemsSelected && authorized.ToDeletePermitRequest(userRoleElements, baseDTOs, userContext.User);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditPermitRequest(userRoleElements, selectedDTOs);
            details.CloneEnabled = hasSingleItemSelected && authorized.ToClonePermitRequest(userRoleElements);
            details.ViewEditHistoryEnabled = hasSingleItemSelected;

            details.SubmitEnabled = 
                hasItemsSelected && 
                authorized.ToSubmitPermitRequest(userRoleElements) &&
                selectedDTOs.TrueForAll(obj => obj.EndDate >= Clock.DateNow && PermitRequestEdmonton.IsSubmittableStatus(obj.CompletionStatus));

            details.ImportEnabled = authorized.ToImportPermitRequests(userRoleElements);

            details.MarkTemplateEnabled = hasSingleItemSelected &&
                                              ClientSession.GetUserContext()
                                                  .SiteConfiguration.EnableTemplateFeatureForWorkPermit &&
                                              (authorized.ToCreatePermitRequest(userRoleElements));
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
            item.LastModifiedBy = ClientSession.GetUserContext().User;
            item.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.Remove, item);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForPermitRequests(userContext.SiteConfiguration);
        }

        protected override bool IsItemInDateRange(PermitRequestEdmonton item, Range<Date> range)
        {
            if (item.CreatedBy.Id == userContext.User.Id)
            {
                return true;
            }
            DateRange theRange = new DateRange(range ?? GetDefaultDateRange());
            return theRange.Overlaps(item.RequestedStartDate.ToDateTimeAtStartOfDay(), item.EndDate.ToDateTimeAtStartOfDay());
        }

        protected override bool ShouldBeDisplayed(PermitRequestEdmonton item)
        {
            return item.Group == null || (!item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P3.IdValue) && !item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P4.IdValue));
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests; }
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        private void MarkAsTemplate(object sender, EventArgs e)
        {
            bool isWorkPermit = false;
            MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);
            nameForm.ShowDialog();
            PermitRequestEdmonton permitRequest = QueryForFirstSelectedItem();
            permitRequest.TemplateName = nameForm.WorkPermitTemplateName;
            permitRequest.Categories = nameForm.Category;
            permitRequest.Global = nameForm.Global;
            permitRequest.Individual = nameForm.Individual;


            var wp = permitRequestEdmontonService.QueryByIdTemplate(permitRequest.IdValue, permitRequest.TemplateName, permitRequest.Categories);

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
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestEdmontonService.Update, permitRequest);
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
