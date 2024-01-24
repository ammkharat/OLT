using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageDirectiveLogSectionPresenter : PriorityPageSectionPresenter<LogPriorityPageDTO, Log>
    {
        private readonly ILogService logService;
        private readonly bool shouldShowDirectivesSection;
        private readonly Range<Date> dateRange;
        private readonly RootFlocSet queryFlocSet;
        private readonly HashSet<long> idsOfDirectivesReadByCurrentUser = new HashSet<long>();

      
      

        public PriorityPageDirectiveLogSectionPresenter(
            IPage invokeControl, PriorityPageTree tree, IAuthorized authorized, UserContext userContext, IRemoteEventRepeater remoteEventRepeater,
            ILogService logService, PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.logService = logService;
            shouldShowDirectivesSection = userContext.SiteConfiguration.UseLogBasedDirectives && authorized.ToViewDirectiveLogsOnPrioritiesPage(userContext.UserRoleElements);

            if (shouldShowDirectivesSection)
            {
                dateRange = new Range<Date>(
                    Clock.DateNow.AddDays(-1 * userContext.SiteConfiguration.DaysToDisplayDirectivesOnPriorityPage), 
                    Clock.DateNow.AddDays(1));
                
                queryFlocSet = userContext.RootFlocSet;

                AddSectionNode(PriorityPageSectionKey.DirectiveLog);

                ////Change Start///DMND0005327 --Request No - 10///////////
                ////Changed By : Amit Shukla
                ////Below code part commented to remove daily directive name///
                ////Added a line to show blank test under 'Directive' header////
                ////Date: 09/06/2017
                //AddCatchAllSubSectionNode(String.Format(
                //    StringResources.PriorityPage_DirectivesSubSection,
                //    dateRange.LowerBound));

                AddCatchAllSubSectionNode(string.Empty);   //ayman temp merge
  
                ////Change End///DMND0005327 --Request No - 10///////////

                remoteEventRepeater.ServerLogCreated += Repeater_Created;
                remoteEventRepeater.ServerLogUpdated += Repeater_Updated;
                remoteEventRepeater.ServerLogRemoved += Repeater_Removed;
                remoteEventRepeater.ServerLogMarkedAsReadByCurrentUser += Repeater_MarkedAsReadByCurrentUser;

               
            }
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLogCreated -= Repeater_Created;
            remoteEventRepeater.ServerLogUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerLogRemoved -= Repeater_Removed;
            remoteEventRepeater.ServerLogMarkedAsReadByCurrentUser -= Repeater_MarkedAsReadByCurrentUser;            
        }

        public List<LogPriorityPageDTO> QueryDtos()
        {
            if (shouldShowDirectivesSection)
            {
                return logService.QueryDirectivesForPriorityPageDTOs(queryFlocSet, dateRange, userContext.User, userContext.ReadableVisibilityGroupIds);
            }
            return new List<LogPriorityPageDTO>();
        }

        public void LoadDtos(List<LogPriorityPageDTO> dtos)
        {            
            foreach (LogPriorityPageDTO dto in dtos)
            {
                if (dto.IsReadByCurrentUser)
                {
                    idsOfDirectivesReadByCurrentUser.Add(dto.IdValue);
                }
            }
            dtos = dtos.OrderByDescending(dto => dto.LogDateTime).ToList();
            Load(dtos);
        }

        private void Repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<Log> e)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<object, DomainEventArgs<Log>>(Invoked_Repeater_MarkedAsReadByCurrentUser),
                    sender,
                    e);
            }
            else
            {
                Invoked_Repeater_MarkedAsReadByCurrentUser(sender, e);
            }
        }

        private void Invoked_Repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<Log> e)
        {
            if (e.SelectedItem != null)
            {
                idsOfDirectivesReadByCurrentUser.Add(e.SelectedItem.IdValue);
                Repeater_Updated(sender, e);
            }
        }

        protected override bool IsRelevantItemFromServerEvent(Log item)
        {
            return item.LogType == LogType.DailyDirective && 
                   item.CreatedDateTime >= dateRange.LowerBound.CreateDateTime(Time.START_OF_DAY) &&
                   item.CreatedDateTime <= dateRange.UpperBound.CreateDateTime(Time.END_OF_DAY);
        }

        protected override LogPriorityPageDTO GetDto(Log item,string ForAddUpdate)    //ayman action item reading
        {
            LogDTO dto = new LogDTO(item);
            return new LogPriorityPageDTO(dto, IsReadByCurrentUser(dto));
        }

        protected override NodeData GetNodeData(LogPriorityPageDTO dto)
        {
            DirectiveLogNodeData nodeData = new DirectiveLogNodeData(dto, GetReadStatus(dto));
            return nodeData;
        }

        private ReadStatus GetReadStatus(LogPriorityPageDTO dto)
        {
            bool isReadByCurrentUser = dto.IsReadByCurrentUser || IsReadByCurrentUser(dto.IdValue, dto.CreatedByUserId);
            return isReadByCurrentUser ? ReadStatus.Read : ReadStatus.Unread;
        }

        private bool IsReadByCurrentUser(LogDTO dto)
        {
            return IsReadByCurrentUser(dto.IdValue, dto.CreatedByUserId);
        }

        private bool IsReadByCurrentUser(long logId, long createdByUserId)
        {
            return createdByUserId == userContext.User.IdValue ||
                   idsOfDirectivesReadByCurrentUser.Contains(logId);
        }
    }
}
