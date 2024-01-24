using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageActionItemSectionPresenter : PriorityPageSectionPresenter<ActionItemDTO, ActionItem>
    {
        private readonly IActionItemService actionItemService;
        private readonly bool authorizedToViewActionItems;

        private readonly SubSectionCriteria currentShiftSubSectionCriteria;
        private readonly SubSectionCriteria olderActionItemsSubsectionCriteria;

        public PriorityPageActionItemSectionPresenter(
            IPage invokeControl, PriorityPageTree tree, IAuthorized authorized, UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IActionItemService actionItemService, PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.actionItemService = actionItemService;

            authorizedToViewActionItems = authorized.ToViewActionItemsOnPrioritiesPage(userContext.UserRoleElements);
            if (authorizedToViewActionItems)
            {
                currentShiftSubSectionCriteria = new SubSectionCriteria(
                    ActionItemStatus.AvailableForCurrentView,
                    userContext.UserShift.StartDateTime,
                    userContext.UserShift.EndDateTime);

                DateTime olderActionItemsStartDateTime;
                if (ShouldQueryIncompleteActionItemsForPreviousShift())
                {
                    // Don't know how to figure out Firebag's previous shift.  Use 12 hours back to cover
                    // normal sites and as a best guess for Firebag.
                    olderActionItemsStartDateTime = userContext.UserShift.StartDateTime.AddHours(-12);
                }
                else
                {
                    olderActionItemsStartDateTime =
                        userContext.UserShift.StartDateTime.AddDays(-1*
                                                                    userContext.SiteConfiguration
                                                                        .DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage
                                                                        .GetValueOrDefault(1));
                }

                var olderActionItemsEndDateTime = userContext.UserShift.StartDateTime;

                olderActionItemsSubsectionCriteria = new SubSectionCriteria(ActionItemStatus.NotComplete,
                    olderActionItemsStartDateTime, olderActionItemsEndDateTime);

                var currentShiftSubSectionName = BuildCurrentShiftSubSectionName();
                var olderActionItemsSubSectionName = BuildOlderActionItemsSubSectionName(olderActionItemsStartDateTime,
                    olderActionItemsEndDateTime);

                AddSectionNode(PriorityPageSectionKey.ActionItem);
                AddCriteriaBasedSubSectionNode(currentShiftSubSectionName, currentShiftSubSectionCriteria);
                AddCatchAllSubSectionNode(olderActionItemsSubSectionName);

                remoteEventRepeater.ServerActionItemCreated += Repeater_Created;
                remoteEventRepeater.ServerActionItemUpdated += Repeater_Updated;
                remoteEventRepeater.ServerActionItemRemoved += Repeater_Removed;
                remoteEventRepeater.ServerActionItemRefresh += Repeater_ServerActionItemRefresh;
            }
        }

        private string BuildCurrentShiftSubSectionName()
        {
            string currentShiftSubSectionName;

            if (ShouldQueryByWorkAssignment())
            {
                currentShiftSubSectionName =
                    String.Format(StringResources.PriorityPage_ActionItemsSubSection_CurrentShift_WorkAssignment,
                        userContext.Assignment.Name);
            }
            else
            {
                currentShiftSubSectionName = StringResources.PriorityPage_ActionItemsSubSection_CurrentShift;
            }

            return currentShiftSubSectionName;
        }

        private string BuildOlderActionItemsSubSectionName(DateTime startDateTime, DateTime endDateTime)
        {
            string olderActionItemsSubSectionName;

            if (ShouldQueryByWorkAssignment())
            {
                if (ShouldQueryIncompleteActionItemsForPreviousShift())
                {
                    olderActionItemsSubSectionName =
                        String.Format(StringResources.PriorityPage_ActionItemsSubSection_PreviousShift_WorkAssignment,
                            userContext.Assignment.Name);
                }
                else
                {
                    olderActionItemsSubSectionName =
                        String.Format(StringResources.PriorityPage_ActionItemsSubSection_XDays_WorkAssignment,
                            userContext.Assignment.Name, startDateTime.ToShortDateAndTimeString(),
                            endDateTime.ToShortDateAndTimeString());
                }
            }
            else
            {
                if (ShouldQueryIncompleteActionItemsForPreviousShift())
                {
                    olderActionItemsSubSectionName = StringResources.PriorityPage_ActionItemsSubSection_PreviousShift;
                }
                else
                {
                    olderActionItemsSubSectionName =
                        String.Format(StringResources.PriorityPage_ActionItemsSubSection_XDays,
                            startDateTime.ToShortDateAndTimeString(), endDateTime.ToShortDateAndTimeString());
                }
            }

            return olderActionItemsSubSectionName;
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerActionItemCreated -= Repeater_Created;
            remoteEventRepeater.ServerActionItemUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerActionItemRemoved -= Repeater_Removed;
            remoteEventRepeater.ServerActionItemRefresh -= Repeater_ServerActionItemRefresh;
        }

        private bool ShouldQueryByWorkAssignment()
        {
            return userContext.SiteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage &&
            userContext.Assignment != null;
        }

        private bool ShouldQueryIncompleteActionItemsForPreviousShift()
        {
            return userContext.SiteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage == null;
        }

        public void LoadDtos(List<ActionItemDTO> dtos)
        {
            //if (dtos != null && dtos.Count > 0)
            //{
            //    // dtos.RemoveAll(fld => fld.Reading());

            //    List<ActionItemDTO> RemovalList = new List<ActionItemDTO>();
            //    foreach (ActionItemDTO aidto in dtos)
            //    {
            //        var aidef = actionItemService.QueryActionItemDefinitionByActionItemCreatedByActionItemDefId(aidto.DefinitionId());
            //        if (aidef.Reading)
            //            RemovalList.Add(aidto);
            //    }
            //    if (RemovalList != null && RemovalList.Count > 0)
            //    {
            //        foreach (ActionItemDTO aidremove in RemovalList)
            //        {
            //            dtos.Remove(aidremove);
            //        }
            //    }
            //}

            Load(dtos);
        }

        public List<ActionItemDTO> QueryDtos()
        {
            if (!authorizedToViewActionItems)
            {
                return new List<ActionItemDTO>();
            }

            var statuses = new List<ActionItemStatus>(currentShiftSubSectionCriteria.Statuses);
            foreach (var status in olderActionItemsSubsectionCriteria.Statuses)
            {
                if (!statuses.Exists(obj => obj.Id == status.Id))
                {
                    statuses.Add(status);
                }
            }

            var dtos = actionItemService.QueryDTOByPriorityPageCriteria(
                userContext.RootFlocSet,
                statuses,
                olderActionItemsSubsectionCriteria.From,
                currentShiftSubSectionCriteria.To,
                ShouldQueryByWorkAssignment(),
                userContext.Assignment,
                userContext.ReadableVisibilityGroupIds);

            ////Commented by Dharmesh Start on 16-Nov-2016 for INC0073637
            //if (ShouldFilterDTOsBasedOnSectionConfiguration())
            //{
            //    var filteredDtos = SectionConfiguration.FilterDTOsByWorkAssignment(dtos, userContext.Assignment);
            //    return filteredDtos;
            //}
            ////Commented by Dharmesh Start on 16-Nov-2016 for INC0073637


            // The query returns some extra ones for previous shift because it uses >= and <=. 
            // For example, it could return an action item for the previous shift that
            // ends on the current shift start time and has a status of complete. We don't
            // want that particular item because it is complete.
            dtos.RemoveAll(dto =>
                !(currentShiftSubSectionCriteria.MatchesDateRangeAndStatus(dto) ||
                  olderActionItemsSubsectionCriteria.MatchesDateRangeAndStatus(dto)));
            var vgids = ClientSession.GetUserContext().ReadableVisibilityGroupIds; //ayman visibility group



            dtos.RemoveAll(
                dto =>
                    (dto.ScheduleTypeName == ScheduleType.Continuous.Name
                     &&
                     dto.HasEndDate()
                     &&
                     (dto.Status == ActionItemStatus.Complete || dto.Status == ActionItemStatus.IefSubmitted)
                        //ayman action item new status 
                     &&
                     !userContext.UserShift.DateTimeRangeWithPadding.ContainsInclusive(dto.StartDateTime))
                );
            //// Added by Dharmesh Start on 16-Nov-2016 for INC0073637
            if (ShouldFilterDTOsBasedOnSectionConfiguration())
            {
                var filteredDtos = SectionConfiguration.FilterDTOsByWorkAssignment(dtos, userContext.Assignment);
                return filteredDtos;
            }
            //// Added by Dharmesh End on 16-Nov-2016 for INC0073637


            //ayman visibility group
            for (int i = dtos.Count - 1; i >= 0; i--)
            {
                if (dtos[i].VisGroupStartingWith != null)   
                    if (!dtos[i].VisGroupStartingWith.BuildLongArrayFromCsv().Any(vg => vg.IsOneOf(vgids)))
                        dtos.RemoveAt(i);
            }

            //ayman action item reading - remove reading dtos
            dtos.RemoveAll(fld => fld.Reading());

    return dtos;
        }

        private bool ShouldFilterDTOsBasedOnSectionConfiguration()
        {
            return SectionConfiguration != null && // section configuration is set by the user
                   SectionConfiguration.SectionKey.EnableFilteringByWorkAssignment &&
                   // filtering is enabled for this section (which it is for action items, so this is redundant)
                   !userContext.SiteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage;
                // The site doesn't use the alternative display for handovers. As of Jan 2014 it's only Voyageur.
        }

        private void LoadDtos()
        {
            LoadDtos(QueryDtos());
        }

        protected override bool IsRelevantItemFromServerEvent(ActionItem item)
        {
            var dto = new ActionItemDTO(item);
            return (currentShiftSubSectionCriteria.MatchesDateRangeAndStatus(dto) ||
                    olderActionItemsSubsectionCriteria.MatchesDateRangeAndStatus(dto)) &&
                   (!ShouldQueryByWorkAssignment() ||
                    (userContext.Assignment != null &&
                     item.Assignment != null &&
                     userContext.Assignment.Id == item.Assignment.Id));
        }

        protected override ActionItemDTO GetDto(ActionItem item,string ForAddUpdate)
        {
            if(item.Reading)
            {
                return null;
            }
            if (ForAddUpdate == "Update" && !item.Reading)
            {
                return new ActionItemDTO(item);
            }
            else if(ForAddUpdate == "Add" && !item.Reading)
            {
                if (!item.Reading)                          //ayman action item reading
                    return new ActionItemDTO(item);
                return null;
            }
            else
            {
                return new ActionItemDTO(item);
            }
        }

        protected override NodeData GetNodeData(ActionItemDTO dto)
        {
            return new ActionItemNodeData(dto,
                userContext.SiteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage);
        }

        private void Repeater_ServerActionItemRefresh(object sender, DomainEventArgs<Site> e)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(
                    new Action<object, DomainEventArgs<Site>>(Invoked_Repeater_ServerActionItemRefresh), sender, e);
            }
            else
            {
                Invoked_Repeater_ServerActionItemRefresh(sender, e);
            }
        }

        private void Invoked_Repeater_ServerActionItemRefresh(object sender, DomainEventArgs<Site> e)
        {
            if (invokeControl.IsNotDisposed() && e.SelectedItem != null && e.SelectedItem.Id == userContext.Site.Id)
            {
                ClearAllDataNodes();
                LoadDtos();
            }
        }

        private class SubSectionCriteria : ISubSectionCriteria
        {
            public SubSectionCriteria(ActionItemStatus[] statuses, DateTime from, DateTime to)
            {
                Statuses = statuses;
                From = from;
                To = to;
            }

            public ActionItemStatus[] Statuses { get; private set; }
            public DateTime From { get; private set; }
            public DateTime To { get; private set; }

            public bool Matches(ActionItemDTO dto)
            {
                if (dto == null)                               //ayman action item reading
                    return false;
                if (MatchesDateRange(dto) && !dto.Reading())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }

            public bool MatchesDateRangeAndStatus(ActionItemDTO dto)
            {
                return MatchesDateRange(dto) && MatchesStatus(dto.Status);
            }

            private bool MatchesDateRange(ActionItemDTO dto)
            {
                return (dto.StartDateTime < To && dto.EndDateTime > From) ||
                       (dto.StartDateTime == dto.EndDateTime && dto.StartDateTime == From);
            }

            private bool MatchesStatus(ActionItemStatus status)
            {
                foreach (var criteriaStatus in Statuses)
                {
                    if (status.Id == criteriaStatus.Id)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}