using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using System;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class LabAlertPagePresenter : AbstractRespondableDomainPagePresenter<LabAlertDTO, LabAlert, ILabAlertDetails, ILabAlertPage>
    {
        private readonly ILabAlertService labAlertService;

        public LabAlertPagePresenter() : this(new LabAlertPage())
        {
        }

        public LabAlertPagePresenter(ILabAlertPage labAlertPage) : base(labAlertPage)
        {
            labAlertService = ClientServiceRegistry.Instance.GetService<ILabAlertService>();
        }

        //DMND0010124 mangesh
        protected override IForm CreateCopyLastResponseForm(LabAlert alert)
        {
            throw new NotImplementedException();
        }

        protected override IForm CreateResponseForm(LabAlert alert)
        {
            return new LabAlertResponseForm(alert);
        }

        protected override PageKey GetDefinitionPageKey()
        {
            return PageKey.LAB_ALERT_DEFINITION_PAGE;
        }

        public static bool ShouldShowOnPrioritiesPage(LabAlert item)
        {
            return ClientSession.GetUserContext().RootsForSelectedFunctionalLocations.Exists(selected =>
                item.FunctionalLocation.IsOrIsAncestorOfOrIsDescendantOf(selected));
        }

        protected override bool ShouldBeDisplayed(LabAlert item)
        {
            return ClientSession.GetUserContext().RootsForSelectedFunctionalLocations.Exists(selected =>
                item.FunctionalLocation.IsOrIsAncestorOfOrIsDescendantOf(selected));
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLabAlertCreated += repeater_Created;
            remoteEventRepeater.ServerLabAlertUpdated += repeater_Updated;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLabAlertCreated -= repeater_Created;
            remoteEventRepeater.ServerLabAlertUpdated -= repeater_Updated;
        }

        protected override LabAlert QueryByDto(LabAlertDTO dto)
        {
            return labAlertService.QueryById(dto.IdValue);
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List <LabAlertDTO> selectedItems = page.SelectedItems;
            bool hasSingleItemSelected = selectedItems.Count == 1;

            //COMMENT: trg - if this changes .. it means that the PriorityPagePresenter needs to reflect change as well.
            ILabAlertDetails details = page.Details;
            details.RespondEnabled = hasSingleItemSelected &&
                authorized.ToRespondToLabAlerts(userRoleElements);
            details.GoToDefinitionEnabled = hasSingleItemSelected;
        }

        protected override void SetDetailData(ILabAlertDetails details, LabAlert alert)
        {
            if (alert != null)
            {
                details.CreatedDateTime = alert.CreatedDateTime.ToLongDateAndTimeString();
                details.DefinitionName = alert.Name;
                details.FunctionalLocation = alert.FunctionalLocation.FullHierarchyWithDescription;
                details.Tag = alert.TagInfo.NameAndDescription;
                details.Description = alert.Description;
                details.ActualNumberOfSamples = alert.ActualNumberOfSamples;
                details.MinimumNumberOfSamples = alert.MinimumNumberOfSamples;
                details.LabAlertTagQueryRangeFromDateTime = alert.LabAlertTagQueryRangeFromDateTime.ToLongDateAndTimeString();
                details.LabAlertTagQueryRangeToDateTime = alert.LabAlertTagQueryRangeToDateTime.ToLongDateAndTimeString();
                details.Schedule = alert.ScheduleDescription;
                details.Responses = alert.Responses;
            }
            else
            {
                details.CreatedDateTime = string.Empty;
                details.DefinitionName = string.Empty;
                details.FunctionalLocation = string.Empty;
                details.Tag = string.Empty;
                details.Description = string.Empty;
                details.ActualNumberOfSamples = 0;
                details.MinimumNumberOfSamples = 0;
                details.LabAlertTagQueryRangeFromDateTime = string.Empty;
                details.LabAlertTagQueryRangeToDateTime = string.Empty;
                details.Schedule = string.Empty;
                details.Responses = new List<LabAlertResponse>();
            }
        }

        protected override LabAlertDTO CreateDTOFromDomainObject(LabAlert labAlert)
        {
            return new LabAlertDTO(labAlert);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_LabAlert; }
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForLabAlerts(userContext.SiteConfiguration);
        }

        protected override IList<LabAlertDTO> GetDtos(Range<Date> dateRange)
        {
            return labAlertService.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(userContext.RootFlocSet, dateRange, null);            
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.LabAlerts; }
        }
    }
}