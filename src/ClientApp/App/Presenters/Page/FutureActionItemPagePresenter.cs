using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class FutureActionItemPagePresenter :
        AbstractRespondableDomainPagePresenter
            <FutureActionItemDTO, ActionItem, IFutureActionItemDetails, IFutureActionItemPage>

    {
        private readonly IFormEdmontonService formService;
        private readonly ILogService logService;

        protected readonly IActionItemService service;


        public FutureActionItemPagePresenter()
            : this(new FutureActionItemPage())
        {
        }

        public FutureActionItemPagePresenter(IFutureActionItemPage page)
            : this(
                page,
                ClientServiceRegistry.Instance.GetService<IActionItemService>(),
                new Authorized(),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<ILogService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>(),
                ClientServiceRegistry.Instance.GetService<IFormEdmontonService>())
        {
        }

        protected FutureActionItemPagePresenter(
            IFutureActionItemPage page,
            IActionItemService service,
            IAuthorized authorized,
            IRemoteEventRepeater remoteEventRepeater,
            IObjectLockingService objectLockingService,
            ILogService logService,
            ITimeService timeService,
            IUserService userService,
            IFormEdmontonService formService)
            : base(page, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {
            this.service = service;
            this.logService = logService;
            this.formService = formService;
            page.Details.GoToDefinitionVisible =
                authorized.ToViewActionItemDefinitions(ClientSession.GetUserContext().UserRoleElements);
            SubscribeToEvents();
        }


        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ActionItem; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ActionItems; }
        }

        protected override string SetSecondLineOfPageTitle()
        {
            return string.Format("{0}: {1}", StringResources.LastRefreshedAt, Clock.Now.ToShortTimeString());
        }

        protected override FutureActionItemDTO CreateDTOFromDomainObject(ActionItem actionItem)
        {
            return new FutureActionItemDTO(actionItem.Id.GetValueOrDefault(),
                actionItem.StartDateTime,
                actionItem.StartDateTime,
                actionItem.EndDateTime.GetValueOrDefault(),
                actionItem.EndDateTime.GetValueOrDefault(),
                actionItem.Status.IdValue,
                actionItem.Priority,
                actionItem.CategoryName,
                actionItem.Source.IdValue,
                actionItem.Description,
                actionItem.CreatedByScheduleType.Name,
                actionItem.FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                actionItem.FunctionalLocations.ConvertAll(floc => floc.FullHierarchyWithDescription),
                actionItem.ResponseRequired,
                actionItem.LastModifiedBy.Id,
                actionItem.Name,
                actionItem.Assignment != null ? actionItem.Assignment.Name : null,
                actionItem.Assignment != null ? actionItem.Assignment.Id : null,
                actionItem.WritableWorkAssignmentVisibilityGroups.ConvertAll(wavg => wavg.VisibilityGroupName), false,
                false, OperationalMode.Normal.GetName(),actionItem.DefinitionId,actionItem.VisGroupsStartingWith,actionItem.DefinitionId,actionItem.Reading);             //ayman visibility group      ayman action item definition
        }


        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
        }

        protected override void ControlDetailButtons()
        {
        }

        protected override void SetDetailData(IFutureActionItemDetails details, ActionItem item)
        {
        }

        protected override ActionItem QueryByDto(FutureActionItemDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshData();
        }


        protected override IList<FutureActionItemDTO> GetDtos(Range<Date> range)
        {
            var definitionWindow = new Range<DateTime>(userContext.UserShift.EndDateTime.AddSeconds(1),
                userContext.UserShift.EndDateTime.AddDays(userContext.SiteConfiguration.DaysToDisplayActionItems));
            if (range.LowerBound != null && range.UpperBound != null && range.LowerBound <= range.UpperBound &&
                !Equals(range, GetDefaultDateRange()))
            {
                var lowerBoundToUse = range.LowerBound.ToDateTimeAtStartOfDay() < definitionWindow.LowerBound
                    ? definitionWindow.LowerBound
                    : range.LowerBound.ToDateTimeAtStartOfDay();
                definitionWindow = new Range<DateTime>(lowerBoundToUse, range.UpperBound.ToDateTimeAtEndOfDay());
            }

            var actionItemDefinitions = service.QueryFutureActionItemDefinitions(userContext.RootFlocSet,
                definitionWindow.LowerBound.AddDays(-1), definitionWindow.UpperBound,
                userContext.ReadableVisibilityGroupIds);

            var futureActionItemDtos = new List<FutureActionItemDTO>();
            foreach (var actionItemDefinition in actionItemDefinitions)
            {
                var flocSets = GetFlocSets(actionItemDefinition);

                var nextInvokeDateTimes = actionItemDefinition.Schedule.ScheduledOccurencesWithin(definitionWindow);

                foreach (var invocationDateTimeRange in nextInvokeDateTimes)
                {
                    foreach (var flocs in flocSets)
                    {
                        futureActionItemDtos.Add(new FutureActionItemDTO(-1,
                            invocationDateTimeRange.LowerBound,
                            invocationDateTimeRange.LowerBound,
                            invocationDateTimeRange.UpperBound,
                            invocationDateTimeRange.UpperBound,
                            actionItemDefinition.Status.IdValue,
                            actionItemDefinition.Priority,
                            actionItemDefinition.Category.Name,
                            actionItemDefinition.Source.IdValue,
                            actionItemDefinition.Description,
                            actionItemDefinition.Schedule.Type.Name,
                            new List<string> {flocs},
                            new List<string> {flocs},
                            actionItemDefinition.ResponseRequired,
                            actionItemDefinition.LastModifiedBy.IdValue,
                            actionItemDefinition.Name,
                            actionItemDefinition.Assignment != null ? actionItemDefinition.Assignment.Name : null,
                            actionItemDefinition.Assignment != null ? actionItemDefinition.Assignment.Id : null,
                            actionItemDefinition.WritableWorkAssignmentVisibilityGroups.ConvertAll(
                                wavg => wavg.VisibilityGroupName), actionItemDefinition.RequiresApproval,
                            !actionItemDefinition.Active, actionItemDefinition.OperationalMode.GetName(),actionItemDefinition.IdValue,actionItemDefinition.VisGroupsStartingWith,actionItemDefinition.IdValue,actionItemDefinition.Reading));    //ayman visibility group    ayman action item definition
                    }
                }
            }
            return futureActionItemDtos;
        }

        //DMND0010124 mangesh
        protected override IForm CreateCopyLastResponseForm(ActionItem item)
        {
            throw new NotImplementedException();
        }

        protected override IForm CreateResponseForm(ActionItem item)
        {
            throw new NotImplementedException();
        }

        protected override PageKey GetDefinitionPageKey()
        {
            return PageKey.ACTION_ITEM_DEFINITION_PAGE;
        }

        private void SubscribeToEvents()
        {
            page.Details.RefreshAll += RefreshAll;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.RefreshAll -= RefreshAll;
        }

        private List<string> GetFlocSets(ActionItemDefinition actionItemDefinition)
        {
            var actionItemDefinitionFlocs = actionItemDefinition.FunctionalLocations;

            var flocSets = new List<string>();
            if (actionItemDefinition.CreateAnActionItemForEachFunctionalLocation)
            {
                foreach (var actionItemDefinitionFloc in actionItemDefinitionFlocs)
                {
                    if (
                        userContext.RootFlocSet.FunctionalLocations.Exists(
                            qf => qf.Id == actionItemDefinitionFloc.Id || qf.IsParentOf(actionItemDefinitionFloc)))
                    {
                        {
                            flocSets.Add(actionItemDefinitionFloc.FullHierarchy);
                        }
                    }
                }
            }
            else
            {
                flocSets.Add(actionItemDefinitionFlocs.FullHierarchyListToString(true, false));
            }
            return flocSets;
        }


        protected override Range<Date> GetDefaultDateRange()
        {
            var nextShiftStartTime = userContext.UserShift.EndDateTime;
            return DateRangeUtilities.GetDefaultDateRangeForFutureActionItems(userContext.SiteConfiguration,
                nextShiftStartTime);
        }
    }
}