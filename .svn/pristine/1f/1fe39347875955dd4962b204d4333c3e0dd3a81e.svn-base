using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class OnPremisePersonnelAuditPagePresenter :
        AbstractPagePresenter<OnPremisePersonnelAuditDTO, OnPremisePersonnel, IOnPremisePersonnelDetails, IOnPremisePersonnelAuditPage>
    {
        private readonly IFormEdmontonService service;

        public OnPremisePersonnelAuditPagePresenter()
            : base(new OnPremisePersonnelAuditPage(),
                new Authorized(),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
        }

        protected override OnPremisePersonnel QueryByDto(OnPremisePersonnelAuditDTO dto)
        {
            return null;
        }

        protected override IList<OnPremisePersonnelAuditDTO> GetDtos(Range<Date> dateRange)
        {
            return service.QueryOnPremisePersonnelAuditView(dateRange);
        }

        protected override OnPremisePersonnelAuditDTO CreateDTOFromDomainObject(OnPremisePersonnel item)
        {
            OnPremiseContractor contractor = item.OnPremiseContractor;
            OvertimeForm overtimeForm = item.OvertimeForm;

            string approvedByUser = string.Empty;

            List<FormApproval> formApprovals = overtimeForm.Approvals;
            if (formApprovals.Count > 0 && formApprovals[0].ApprovedByUser != null)
            {
                approvedByUser = formApprovals[0].ApprovedByUser.FullName;
            }

            return new OnPremisePersonnelAuditDTO(contractor.IdValue, overtimeForm.FormNumber, contractor.Company, overtimeForm.Trade, contractor.PersonnelName,
                contractor.StartDateTime, contractor.EndDateTime, contractor.PrimaryLocation, contractor.ExpectedHours, contractor.Description, contractor.WorkOrderNumber,
                overtimeForm.FormStatus, approvedByUser);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_OnPremisePersonnelAudit; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            repeater.ServerOnPremisePersonnelCreated += repeater_Created;
            repeater.ServerOnPremisePersonnelUpdated += repeater_Updated;
            repeater.ServerOnPremisePersonnelRemoved += repeater_Removed;
        }

        protected override bool IsItemInDateRange(OnPremisePersonnel item)
        {
            Range<Date> range = userSelectedDateRange ?? GetDefaultDateRange();
            return new DateRange(range).Overlaps(item.OnPremiseContractor.StartDateTime, item.OnPremiseContractor.EndDateTime);
        }

        protected override bool IsItemInDateRange(OnPremisePersonnel item, Range<Date> range)
        {
            return new DateRange(range).Overlaps(item.OnPremiseContractor.StartDateTime, item.OnPremiseContractor.EndDateTime);
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            repeater.ServerOnPremisePersonnelCreated -= repeater_Created;
            repeater.ServerOnPremisePersonnelUpdated -= repeater_Updated;
            repeater.ServerOnPremisePersonnelRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
        }

        protected override void SetDetailData(IOnPremisePersonnelDetails details, OnPremisePersonnel item)
        {
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.OnPremisePersonnelAuditView; }
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return new Range<Date>(Clock.DateNow, null);
        }
    }
}