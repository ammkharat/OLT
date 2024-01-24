using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageDirectiveSectionPresenter : PriorityPageSectionPresenter<DirectiveDTO, Directive>
    {
        private readonly IDirectiveService directiveService;
        private readonly bool shouldShowDirectivesSection;
      
        
        
        
        
        
        
        
        
        //private readonly bool shouldShowDirectivesLogSection;   //ayman temp merge   testing
        
        
        
        
        
        
        
        
        
        
        
        private readonly RootFlocSet queryFlocSet;
        private readonly HashSet<long> idsOfDirectivesReadByCurrentUser = new HashSet<long>();
        private readonly DirectiveTimerManager timerManager;

 
        

        public PriorityPageDirectiveSectionPresenter(
            IPage invokeControl, PriorityPageTree tree, IAuthorized authorized, UserContext userContext, IRemoteEventRepeater remoteEventRepeater,
            IDirectiveService directiveService, PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.directiveService = directiveService;
            shouldShowDirectivesSection = authorized.ToViewDirectivesOnPrioritiesPage(userContext.UserRoleElements);
          
            
            
            
            
            
            
            
            
            
            
            
            //shouldShowDirectivesLogSection = userContext.SiteConfiguration.UseLogBasedDirectives && authorized.ToViewDirectiveLogsOnPrioritiesPage(userContext.UserRoleElements);   //ayman temp merge    testing
            
            
            
            
            
            
            
            
            
            
            
            timerManager = new DirectiveTimerManager();

            queryFlocSet = userContext.RootFlocSet;                     //ayman temp merge moved it out site the if condition

            
            
            
            
            
            
            
            
            
            if (shouldShowDirectivesSection) // testing || shouldShowDirectivesLogSection)            //ayman temp merge

            
            
            
            
            
            
            
            
            {

                AddSectionNode(PriorityPageSectionKey.Directive);

                AddCatchAllSubSectionNode(StringResources.ActiveDirectives);    //ayman temp merge (return the caption)
                


                remoteEventRepeater.ServerDirectiveCreated += Repeater_Created;
                remoteEventRepeater.ServerDirectiveUpdated += Repeater_Updated;
                remoteEventRepeater.ServerDirectiveRemoved += Repeater_Removed;
                remoteEventRepeater.ServerDirectiveMarkedAsReadByCurrentUser += Repeater_MarkedAsReadByCurrentUser;
            }
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerDirectiveCreated -= Repeater_Created;
            remoteEventRepeater.ServerDirectiveUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerDirectiveRemoved -= Repeater_Removed;
            remoteEventRepeater.ServerDirectiveMarkedAsReadByCurrentUser -= Repeater_MarkedAsReadByCurrentUser;
        }


        public List<DirectiveDTO> QueryDtos()   //priority page query
        {
            if (shouldShowDirectivesSection)
            {
                Date shiftEndDate = userContext.UserShift.EndDate;

               List<DirectiveDTO> dtos = directiveService.QueryDTOsByDateRangeAndFlocs(new Range<Date>(Clock.DateNow, shiftEndDate), queryFlocSet, userContext.ReadableVisibilityGroupIds, userContext.User.Id);          //ayman temp merge
                return dtos.FindAll(dto => dto.IsRelevantToAssignment(userContext.Assignment));
            }
            return new List<DirectiveDTO>();
        }



        public void LoadDtos(List<DirectiveDTO> dtos)
        {
            dtos.RemoveAll(dto => dto.IsExpired(Clock.Now));

            foreach (DirectiveDTO dto in dtos)
            {
                RegisterRenderTimer(dto);

                if (dto.IsReadByCurrentUser.GetValueOrDefault(false))
                {
                    idsOfDirectivesReadByCurrentUser.Add(dto.IdValue);
                }
            }

            dtos.RemoveAll(dto => dto.IsInFuture(Clock.Now));
            dtos = dtos.OrderByDescending(dto => dto.ActiveFromDateTime).ToList();


            Load(dtos);
        }

        protected override void Repeater_Created(DomainEventArgs<Directive> e)
        {
            Directive directive = e.SelectedItem;
            if (directive != null)
            {
                DirectiveDTO dto = new DirectiveDTO(directive);
                RegisterRenderTimer(dto);

                if (!dto.IsInFuture(Clock.Now))
                {
                    base.Repeater_Created(e);
                }
            }
        }

        protected override void Repeater_Updated(DomainEventArgs<Directive> e)
        {
            Directive directive = e.SelectedItem;
            if (directive != null)
            {
                DirectiveDTO dto = new DirectiveDTO(directive);
                RegisterRenderTimer(dto);

                base.Repeater_Updated(e);
            }
        }

        protected override bool IsRelevantItemFromServerEvent(Directive item)
        {
            DirectiveDTO dto = new DirectiveDTO(item);
            DateTime now = Clock.Now;
            return !dto.IsExpired(now) && !dto.IsInFuture(now) && dto.IsRelevantToAssignment(userContext.Assignment);
        }

        protected override DirectiveDTO GetDto(Directive item,string ForAddUpdate)   //ayman action item reading
        {
            DirectiveDTO dto = new DirectiveDTO(item);
            dto.IsReadByCurrentUser = IsReadByCurrentUser(dto);
            return dto;
        }

        protected override NodeData GetNodeData(DirectiveDTO dto)
        {
            return new DirectiveNodeData(dto, GetReadStatus(dto));
        }

        private void Repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<Directive> e)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<object, DomainEventArgs<Directive>>(Invoked_Repeater_MarkedAsReadByCurrentUser),
                    sender,
                    e);
            }
            else
            {
                Invoked_Repeater_MarkedAsReadByCurrentUser(sender, e);
            }
        }

        private void Invoked_Repeater_MarkedAsReadByCurrentUser(object sender, DomainEventArgs<Directive> e)
        {
            if (e.SelectedItem != null)
            {
                idsOfDirectivesReadByCurrentUser.Add(e.SelectedItem.IdValue);
                Repeater_Updated(sender, e);
            }
        }

        private ReadStatus GetReadStatus(DirectiveDTO dto)
        {
            bool isReadByCurrentUser = dto.IsReadByCurrentUser.GetValueOrDefault(false) || IsReadByCurrentUser(dto.IdValue, dto.CreatedByUserId);
            return isReadByCurrentUser ? ReadStatus.Read : ReadStatus.Unread;
        }

        private bool IsReadByCurrentUser(DirectiveDTO dto)
        {
            return IsReadByCurrentUser(dto.IdValue, dto.CreatedByUserId);
        }

        private bool IsReadByCurrentUser(long directiveId, long createdByUserId)
        {
            return createdByUserId == userContext.User.IdValue ||
                   idsOfDirectivesReadByCurrentUser.Contains(directiveId);
        }

        private void RegisterRenderTimer(DirectiveDTO dto)
        {
            timerManager.Unregister(dto);

            if (dto.IsExpired(Clock.Now))
            {
                return;
            }

            DateTime now = Clock.Now;
            if (dto.IsInFuture(now))
            {
                TimeSpan timeUntilStartOfDirective = dto.ActiveFromDateTime.Subtract(now);
                SetupTimerCallback(timeUntilStartOfDirective, dto);
            }
            else   // dto is active
            {
                TimeSpan timeUntilDirectiveIsExpired = dto.ActiveToDateTime.Subtract(now);
                SetupTimerCallback(timeUntilDirectiveIsExpired, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, DirectiveDTO dto)
        {
            TimeSpan timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
        }
        
        private void HandleTimerFire(object dto)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<DirectiveDTO>(RefreshItem), dto);
            }
            else
            {
                RefreshItem(dto);
            }
        }

        private void RefreshItem(object dto)
        {
            if (invokeControl.IsNotDisposed())
            {
                if (!(dto is DirectiveDTO)) return;
                DirectiveDTO item = (DirectiveDTO)dto;
                RegisterRenderTimer(item);

                Remove(item);
                
                if (item.IsActive(Clock.Now))
                {
                    Add(item);
                }
            }
        }

        public void HandleDisposed()
        {
            timerManager.Clear();
        }
    }
}
