using System;
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
    public class OnPremisePersonnelSupervisorPagePresenter :
        AbstractPagePresenter<OnPremisePersonnelSupervisorDTO, OnPremisePersonnel, IOnPremisePersonnelDetails, IOnPremisePersonnelSupervisorPage>
    {
        private readonly IFormEdmontonService service;
        private UserShift currentShift;
        private UserShift nextShift;

        public OnPremisePersonnelSupervisorPagePresenter()
            : base(new OnPremisePersonnelSupervisorPage(),
                new Authorized(),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            SubscribeToEvents();
            QueryShifts();
        }

        private void SubscribeToEvents()
        {
            page.Details.RefreshAll += Details_RefreshAll;
        }

        private DateTime? lastRefreshedAt;

        public override void PreviouslyLoadedPageSelected()
        {
            if (lastRefreshedAt.HasValue && lastRefreshedAt.Value.Minute != DateTime.Now.Minute)
            {
                Details_RefreshAll();
                lastRefreshedAt = DateTime.Now;
            }

            if (!lastRefreshedAt.HasValue)
            {
                lastRefreshedAt = DateTime.Now;
            }
        }

        protected override bool IsItemInDateRange(OnPremisePersonnel item)
        {
            if (userSelectedDateRange == null)
            {
                // need to check overlap of a date/time in the case of using the default of current and next shift.
                Range<DateTime> defaultRange = new Range<DateTime>(currentShift.StartDateTime, nextShift.EndDateTime);
                return item.Overlaps(defaultRange);
            }
            return new DateRange(userSelectedDateRange).Overlaps(item.OvertimeForm.FromDateTime, item.OvertimeForm.ToDateTime);
        }

        void Details_RefreshAll()
        {
            SetSecondLineOfPageTitle();
            if (userSelectedDateRange != null)
            {
                RefreshData(userSelectedDateRange, false, false);
            }
            else
                RefreshData();
        }

        private void QueryShifts()
        {
            IShiftPatternService shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            List<ShiftPattern> allShifts = shiftPatternService.QueryBySite(userContext.Site);
            currentShift = userContext.UserShift;
            nextShift = currentShift.ChooseNextShift(allShifts);
        }

        protected override string GetPageTitleOverride()
        {
            return string.Format("{0}: {1}", PageTitleName, StringResources.DateRangeCurrentShiftAndNext);
        }

        protected override string SetSecondLineOfPageTitle()
        {
            return string.Format("Card Status as of {0}",  Clock.Now.ToShortTimeString());
        }

        protected override OnPremisePersonnel QueryByDto(OnPremisePersonnelSupervisorDTO dto)
        {
            return null;
        }

        protected override IList<OnPremisePersonnelSupervisorDTO> GetDtos(Range<Date> dateRange)
        {
            Range<DateTime> range = dateRange == null
                ? new Range<DateTime>(currentShift.StartDateTime, nextShift.EndDateTime)
                : new Range<DateTime>(dateRange.LowerBound.ToDateTimeAtStartOfDay(), dateRange.UpperBound.ToDateTimeAtEndOfDay());

            return service.QueryOnPremisePersonnelSupervisorView(range, userContext.Site);
        }

        protected override OnPremisePersonnelSupervisorDTO CreateDTOFromDomainObject(OnPremisePersonnel item)
        {
            OnPremiseContractor contractor = item.OnPremiseContractor;
            return new OnPremisePersonnelSupervisorDTO(contractor.IdValue, item.OvertimeForm.Trade, contractor.PersonnelName, contractor.PrimaryLocation, contractor.IsDayShift,
                contractor.IsNightShift, contractor.StartDateTime, contractor.EndDateTime, contractor.PhoneNumber, contractor.Radio, contractor.Company, contractor.Description, item.CardEntryStatus);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_OnPremisePersonnelSupervisor; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            repeater.ServerOnPremisePersonnelCreated += repeater_Created;
            repeater.ServerOnPremisePersonnelUpdated += repeater_Updated;
            repeater.ServerOnPremisePersonnelRemoved += repeater_Removed;
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
            get { return UserGridLayoutIdentifier.OnPremisePersonnelSupervisorView; }
        }
    }
}