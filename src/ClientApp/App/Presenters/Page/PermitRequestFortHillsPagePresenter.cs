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
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PermitRequestFortHillsPagePresenter : AbstractPermitRequestPagePresenter<PermitRequestFortHillsDTO, PermitRequestFortHills, IPermitRequestFortHillsDetails, IPermitRequestFortHillsPage>
    {
        protected readonly IPermitRequestFortHillsService permitRequestFortHillsService;
        private readonly IWorkPermitFortHillsService workPermitFortHillsService;

        public PermitRequestFortHillsPagePresenter(PageKey pageKey) : base(new PermitRequestFortHillsPage(pageKey))
        {
            permitRequestFortHillsService = ClientServiceRegistry.Instance.GetService<IPermitRequestFortHillsService>();
            workPermitFortHillsService = ClientServiceRegistry.Instance.GetService<IWorkPermitFortHillsService>();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            page.Details.Submit += Details_Submit;
            page.Details.Import += Details_Import;
            page.Details.Clone += Details_Clone;            
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.Submit -= Details_Submit;
            page.Details.Import -= Details_Import;
            page.Details.Clone -= Details_Clone;
        }

        private void Details_Submit(object sender, EventArgs e)
        {
            List<PermitRequestFortHillsDTO> dtos = page.SelectedItems;
            if (dtos.Count > 0)
            {
                SubmitPermitRequests<PermitRequestFortHillsDTO> submitPermitRequests = SubmitPermitRequests;
                CheckPermitRequestAssociationAlreadyExists<PermitRequestFortHillsDTO> shouldGoAheadWithTheSubmissionProcess =
                    (workPermitDate, requestDtos) => workPermitFortHillsService.DoesPermitRequestFortHillsAssociationExist(requestDtos, workPermitDate);

                SubmitPermitRequestFortHillsFormPresenter presenter =
                    new SubmitPermitRequestFortHillsFormPresenter(dtos, submitPermitRequests, shouldGoAheadWithTheSubmissionProcess, false);
                presenter.Run(page.ParentForm);
            }
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestFortHillsDTO> requestDtos, User user)
        {
            if (requestDtos.Count == 0)
            {
                OltMessageBox.Show(page.ParentForm, "There were no permit requests found for the provided criteria.");
            }
            else
            {
                
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestFortHillsService.Submit, workPermitDate, requestDtos, user);
            }
        }

        private void Details_Clone(object sender, EventArgs e)
        {
            PermitRequestFortHills permitRequest = QueryForFirstSelectedItem();
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
            //permitRequest.RequestedStartTime = ClientSession.GetUserContext().UserShift.StartDateTime.ToTime();
            //permitRequest.RequestedEndTime = ClientSession.GetUserContext().UserShift.EndDateTime.ToTime();
            IForm form = CreateEditForm(permitRequest);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void Details_Import(object sender, EventArgs e)
        {
            ImportPermitRequestFortHillsFormPresenter presenter = new ImportPermitRequestFortHillsFormPresenter(permitRequestFortHillsService);
            presenter.Run(page.ParentForm);
        }

        protected override PermitRequestFortHills QueryByDto(PermitRequestFortHillsDTO dto)
        {
            return permitRequestFortHillsService.QueryById(dto.IdValue);
        }

        protected override IList<PermitRequestFortHillsDTO> GetDtos(Range<Date> range)
        {
            DateRange queryDateRange = new DateRange(range);

            if (userContext.HasFlocsForWorkPermits)
            {
                return permitRequestFortHillsService.QueryByDateRangeAndFlocsForAllButTurnaround(userContext.RootFlocSetForWorkPermits, queryDateRange);
            }
            else
            {
                return permitRequestFortHillsService.QueryByDateRangeAndFlocsForAllButTurnaround(userContext.RootFlocSet, queryDateRange);
            }
        }

        protected override PermitRequestFortHillsDTO CreateDTOFromDomainObject(PermitRequestFortHills item)
        {
            return new PermitRequestFortHillsDTO(item);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_PermitRequest; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {/* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            remoteEventRepeater.ServerPermitRequestFortHillsCreated += repeater_Created;
            remoteEventRepeater.ServerPermitRequestFortHillsUpdated += repeater_Updated;
            remoteEventRepeater.ServerPermitRequestFortHillsRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {/* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            remoteEventRepeater.ServerPermitRequestFortHillsCreated -= repeater_Created;
            remoteEventRepeater.ServerPermitRequestFortHillsUpdated -= repeater_Updated;
            remoteEventRepeater.ServerPermitRequestFortHillsRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
            List<PermitRequestFortHillsDTO> selectedDTOs = page.SelectedItems;
            List<BasePermitRequestDTO> baseDTOs = selectedDTOs.ConvertAll(item => (BasePermitRequestDTO) item);
            bool hasSingleItemSelected = selectedDTOs.Count == 1;
            bool hasItemsSelected = selectedDTOs.Count > 0;

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            IPermitRequestFortHillsDetails details = page.Details;
            details.DeleteEnabled = hasItemsSelected && authorized.ToDeletePermitRequest(userRoleElements, baseDTOs, userContext.User);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditPermitRequest(userRoleElements, selectedDTOs);
            details.CloneEnabled = hasSingleItemSelected && authorized.ToClonePermitRequest(userRoleElements);
            details.ViewEditHistoryEnabled = hasSingleItemSelected;

            details.SubmitEnabled = 
                hasItemsSelected && 
                authorized.ToSubmitPermitRequest(userRoleElements) &&
                selectedDTOs.TrueForAll(obj => obj.EndDate >= Clock.DateNow && PermitRequestFortHills.IsSubmittableStatus(obj.CompletionStatus));

            details.ImportEnabled = authorized.ToImportPermitRequests(userRoleElements);
        }

        protected override void SetDetailData(IPermitRequestFortHillsDetails details, PermitRequestFortHills item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(PermitRequestFortHills item)
        {
            return new EditPermitRequestFortHillsHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(PermitRequestFortHills item)
        {
            PermitRequestFortHillsFormPresenter presenter = new PermitRequestFortHillsFormPresenter(item);
            return presenter.View;
        }

        protected override void Delete(PermitRequestFortHills item)
        {
            item.LastModifiedBy = ClientSession.GetUserContext().User;
            item.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestFortHillsService.Remove, item);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForPermitRequests(userContext.SiteConfiguration);
        }

        protected override bool IsItemInDateRange(PermitRequestFortHills item, Range<Date> range)
        {
            if (item.CreatedBy.Id == userContext.User.Id)
            {
                return true;
            }
            DateRange theRange = new DateRange(range ?? GetDefaultDateRange());
            return theRange.Overlaps(item.RequestedStartDate.ToDateTimeAtStartOfDay(), item.EndDate.ToDateTimeAtStartOfDay());
        }

        protected override bool ShouldBeDisplayed(PermitRequestFortHills item)
        {
            return item.Group == null || (!item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P3.IdValue) && !item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P4.IdValue));
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FortHillsRunningUnitPermitRequests; }
        }
    }
}
