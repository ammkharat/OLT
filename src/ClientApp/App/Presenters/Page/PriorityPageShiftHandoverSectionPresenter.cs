using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageShiftHandoverSectionPresenter : PriorityPageSectionPresenter<ShiftHandoverQuestionnairePriorityPageDTO, ShiftHandoverQuestionnaire>
    {
        private readonly IShiftHandoverService shiftHandoverService;
        private readonly Range<Date> dateRange;
        private readonly HashSet<long> idsOfHandoversReadByCurrentUser = new HashSet<long>();
        private readonly bool shouldShowHandovers;

        public PriorityPageShiftHandoverSectionPresenter(
            IPage invokeControl, PriorityPageTree tree, IAuthorized authorized, UserContext userContext, IRemoteEventRepeater remoteEventRepeater,
            IShiftHandoverService shiftHandoverService, PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.shiftHandoverService = shiftHandoverService;
            shouldShowHandovers = authorized.ToViewShiftHandoverOnPrioritiesPage(userContext.UserRoleElements);
            if (shouldShowHandovers)
            {
                dateRange = new Range<Date>(
                    Clock.DateNow.AddDays(-1 * userContext.SiteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage), 
                    Clock.DateNow.AddDays(1));

                AddSectionNode(PriorityPageSectionKey.ShiftHandover);
                if (ShouldQueryByWorkAssignment())
                {
                    AddCatchAllSubSectionNode(String.Format(
                        StringResources.PriorityPage_ShiftHandoversSubSection_WorkAssignment,
                        dateRange.LowerBound,
                        userContext.Assignment.Name));
                }
                else
                {
                    if (userContext.Assignment == null)
                    {
                        AddCatchAllSubSectionNode(String.Format(
                            StringResources.PriorityPage_ShiftHandoversSubSection,
                            dateRange.LowerBound));                        
                    }
                    else
                    {
                        AddCriteriaBasedSubSectionNode(
                            String.Format(
                                StringResources.PriorityPage_ShiftHandoversSubSection_WorkAssignment,
                                dateRange.LowerBound,
                                userContext.Assignment.Name),
                             new CurrentWorkAssignmentSubSectionCriteria(userContext));
                        AddCatchAllSubSectionNode(String.Format(
                            StringResources.PriorityPage_ShiftHandoversSubSection_OtherWorkAssignments,
                            dateRange.LowerBound));
                    }
                }

                remoteEventRepeater.ServerShiftHandoverQuestionnaireCreated += Repeater_Created;
                remoteEventRepeater.ServerShiftHandoverQuestionnaireUpdated += Repeater_Updated;
                remoteEventRepeater.ServerShiftHandoverQuestionnaireRemoved += Repeater_Removed;
                remoteEventRepeater.ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser += Repeater_MarkedAsReadByCurrentUser;
            }
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerShiftHandoverQuestionnaireCreated -= Repeater_Created;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireRemoved -= Repeater_Removed;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser -= Repeater_MarkedAsReadByCurrentUser;            
        }

        private bool ShouldQueryByWorkAssignment()
        {
            return userContext.SiteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage && userContext.Assignment != null;
        }

        public List<ShiftHandoverQuestionnairePriorityPageDTO> QueryDtos()
        {
            if (!shouldShowHandovers)
            {
                return new List<ShiftHandoverQuestionnairePriorityPageDTO>();
            }

            List<ShiftHandoverQuestionnairePriorityPageDTO> dtos = shiftHandoverService.QueryForPriorityPageDTOs(userContext.RootFlocSet, dateRange,
                ShouldQueryByWorkAssignment(), userContext.WorkAssignmentId,
                userContext.User.Id, userContext.ReadableVisibilityGroupIds, userContext.Role.IdValue);

            foreach (ShiftHandoverQuestionnairePriorityPageDTO dto in dtos)
            {
                if (dto.IsReadByCurrentUser)
                {
                    idsOfHandoversReadByCurrentUser.Add(dto.IdValue);
                }
            }
            
            if (ShouldFilterDTOsBasedOnSectionConfiguration())
            {
                 List<ShiftHandoverQuestionnairePriorityPageDTO> filteredDtos = SectionConfiguration.FilterDTOsByWorkAssignment(dtos, userContext.Assignment);
                 return filteredDtos;
            }
          
            return dtos;            
        }

        private bool ShouldFilterDTOsBasedOnSectionConfiguration()
        {
            return SectionConfiguration != null && // section configuration is set by the user
                SectionConfiguration.SectionKey.EnableFilteringByWorkAssignment && // filtering is enabled for this section (which it is for handovers, so this is redundant)
                !userContext.SiteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage; // The site doesn't use the alternative display for handovers. As of Jan 2014 it's only Voyageur.
        }

        public void LoadDtos(List<ShiftHandoverQuestionnairePriorityPageDTO> dtos)
        {
            Load(dtos);
        }

        private void Repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<ShiftHandoverQuestionnaire> e)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(
                    new Action<object, DomainEventArgs<ShiftHandoverQuestionnaire>>(Invoked_Repeater_MarkedAsReadByCurrentUser),
                    sender,
                    e);
            }
            else
            {
                Invoked_Repeater_MarkedAsReadByCurrentUser(sender, e);
            }
        }

        private void Invoked_Repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<ShiftHandoverQuestionnaire> e)
        {
            if (e.SelectedItem != null)
            {
                idsOfHandoversReadByCurrentUser.Add(e.SelectedItem.IdValue);
                Repeater_Updated(sender, e);
            }
        }

        protected override bool IsRelevantItemFromServerEvent(ShiftHandoverQuestionnaire item)
        {
            return item.CreateDateTime >= dateRange.LowerBound.CreateDateTime(Time.START_OF_DAY) &&
                   item.CreateDateTime <= dateRange.UpperBound.CreateDateTime(Time.END_OF_DAY) &&
                   (!ShouldQueryByWorkAssignment() ||
                    (userContext.Assignment != null &&
                     item.Assignment != null &&
                     userContext.Assignment.Id == item.Assignment.Id));                
        }

        protected override ShiftHandoverQuestionnairePriorityPageDTO GetDto(ShiftHandoverQuestionnaire item,string ForAddUpdate)    //ayman action item reading
        {
            ShiftHandoverQuestionnaireDTO dto = new ShiftHandoverQuestionnaireDTO(item);
            return new ShiftHandoverQuestionnairePriorityPageDTO(dto, IsReadByCurrentUser(dto));
        }

        protected override NodeData GetNodeData(ShiftHandoverQuestionnairePriorityPageDTO dto)
        {
            ShiftHandoverNodeData nodeData = new ShiftHandoverNodeData(dto, GetReadStatus(dto));
            return nodeData;
        }

        private ReadStatus GetReadStatus(ShiftHandoverQuestionnairePriorityPageDTO dto)
        {
            bool isReadByCurrentUser = dto.IsReadByCurrentUser || IsReadByCurrentUser(dto.IdValue, dto.CreateUserId);
            if (isReadByCurrentUser)
            {
                return ReadStatus.Read;
            }
            return ReadStatus.Unread;
        }

        private bool IsReadByCurrentUser(ShiftHandoverQuestionnaireDTO dto)
        {
            return IsReadByCurrentUser(dto.IdValue, dto.CreateUserId);
        }

        private bool IsReadByCurrentUser(long handoverId, long createUserId)
        {
            if (createUserId == userContext.User.IdValue ||
                idsOfHandoversReadByCurrentUser.Contains(handoverId))
            {
                return true;
            }
            return false;
        }

        private class CurrentWorkAssignmentSubSectionCriteria : ISubSectionCriteria
        {
            private readonly UserContext userContext;

            public CurrentWorkAssignmentSubSectionCriteria(UserContext userContext)
            {
                this.userContext = userContext;
            }

            public bool Matches(ShiftHandoverQuestionnairePriorityPageDTO dto)
            {
                return userContext.Assignment != null &&
                       dto.WorkAssignmentId.HasValue &&
                       userContext.Assignment.Id == dto.WorkAssignmentId;
            }
        }
    }
}
