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
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    class PriorityPageEdmontonFormSectionPresenter : PriorityPageSectionPresenter<FormEdmontonDTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool authorizedToViewForms;
        private readonly bool authorizedToViewOvertimeForms;
        private readonly Range<Date> dateRange;
        private readonly EipIssueTimerManager timerManager;    //ayman Sarnia eip DMND0008992

        public PriorityPageEdmontonFormSectionPresenter(IPage invokeControl, PriorityPageTree tree, IAuthorized authorized,
                                                UserContext userContext,
                                                IRemoteEventRepeater remoteEventRepeater,
                                                IFormEdmontonService formService, 
                                                PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            authorizedToViewForms = authorized.ToViewFormsOnThePrioritiesPage(userContext.UserRoleElements);
            authorizedToViewOvertimeForms = authorized.ToViewOvertimeForm(userContext.UserRoleElements);
            timerManager = new EipIssueTimerManager();    //ayman Sarnia eip DMND0008992

            if (authorizedToViewForms)
            {
                dateRange = new Range<Date>(Clock.DateNow.SubtractDays(userContext.SiteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage),Date.MaxValue);

                AddSectionNode(PriorityPageSectionKey.EdmontonForm);
                AddCatchAllSubSectionNode(StringResources.PriorityPage_FormsRequireApprovalSubSection);

                remoteEventRepeater.ServerGN7FormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGN7FormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGN7FormRemoved += HandleRepeaterRemoved;
                                
                remoteEventRepeater.ServerGN59FormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGN59FormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGN59FormRemoved += HandleRepeaterRemoved;  
              
                remoteEventRepeater.ServerOP14FormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerOP14FormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerOP14FormRemoved += HandleRepeaterRemoved;

                remoteEventRepeater.ServerGN24FormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGN24FormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGN24FormRemoved += HandleRepeaterRemoved;

                remoteEventRepeater.ServerGN6FormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGN6FormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGN6FormRemoved += HandleRepeaterRemoved;

                remoteEventRepeater.ServerGN75AFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGN75AFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGN75AFormRemoved += HandleRepeaterRemoved;

                remoteEventRepeater.ServerGN1FormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGN1FormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGN1FormRemoved += HandleRepeaterRemoved;

                //ayman Sarnia eip DMND0008992
                remoteEventRepeater.ServerGN75BFormUpdated += HandleEipIssueRepeaterUpdated;    //ayman Sarnia eip DMND0008992
                remoteEventRepeater.ServerGN75BFormCreated += HandleEipIssueRepeaterCreated;    //ayman Sarnia eip DMND0008992
                remoteEventRepeater.ServerGN75BFormRemoved += HandleEipIssueRepeaterRemoved; //Aarti


                //generic template - mangesh
                remoteEventRepeater.ServerGenericTemplateFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGenericTemplateFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGenericTemplateFormRemoved += HandleRepeaterRemoved;
                //---
                if (authorizedToViewOvertimeForms)
                {
                    remoteEventRepeater.ServerOvertimeFormCreated += HandleRepeaterCreated;
                    remoteEventRepeater.ServerOvertimeFormUpdated += HandleRepeaterUpdated;
                    remoteEventRepeater.ServerOvertimeFormRemoved += HandleRepeaterRemoved;
                }
            }
        }

        private void HandleRepeaterCreated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        //ayman Sarnia eip DMND0008992
        private void HandleEipIssueRepeaterUpdated<T>(object sender,DomainEventArgs<T> e) where T : FormGN75B
        {
            FormEdmontonGN75BDTO eipIssuedto = new FormEdmontonGN75BDTO(e.SelectedItem);

            if (e.SelectedItem is FormGN75B)
            {
                var formgn75b = e.SelectedItem as FormGN75B;
                var dto = formgn75b.CreateDTO() as FormEdmontonGN75BDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_UpdatedForEipIssue(eipIssuedto);
        }

        private void HandleEipIssueRepeaterCreated<T>(object sender, DomainEventArgs<T> e) where T : FormGN75B
        {
            FormEdmontonGN75BDTO eipIssuedto = new FormEdmontonGN75BDTO(e.SelectedItem);

            if (e.SelectedItem is FormGN75B)
            {
                var formgn75b = e.SelectedItem as FormGN75B;
                var dto = formgn75b.CreateDTO() as FormEdmontonGN75BDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_UpdatedForEipIssue(eipIssuedto);
        }

        //INC0508086:OLT::Sarnia:: Deleted EIP issues still show on priorities screen...
        private void HandleEipIssueRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : FormGN75B
        {
            FormEdmontonGN75BDTO eipIssuedto = new FormEdmontonGN75BDTO(e.SelectedItem);

            if (e.SelectedItem is FormGN75B)
            {
                var formgn75b = e.SelectedItem as FormGN75B;
                var dto = formgn75b.CreateDTO() as FormEdmontonGN75BDTO;
               RegisterRenderTimer(dto);
            }

          //  Repeater_UpdatedForEipIssue(eipIssuedto);
          
            RemoveEipIssue(eipIssuedto);
        }


        //ayman Sarnia eip DMND0008992
        private void RegisterRenderTimer(FormEdmontonGN75BDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            if (dto.LastModifiedDateTime.AddSeconds(10) < now) return;
            var timeUntilActive = dto.LastModifiedDateTime.AddSeconds(10).Subtract(now);
            SetupTimerCallback(TimeSpan.FromSeconds(2), dto);
        }

        //ayman Sarnia eip DMND0008992
        private void SetupTimerCallback(TimeSpan differenceInTime, FormEdmontonGN75BDTO dto)
        {
         //   var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime.TotalMilliseconds > 0 )
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
        }

        //ayman Sarnia eip DMND0008992
        private void HandleTimerFire(object dto)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<FormEdmontonGN75BDTO>(RefreshItem), dto);
            }
            else
            {
                RefreshItem(dto);
            }
        }

        //ayman Sarnia eip DMND0008992
        private void RefreshItem(object dto)
        {
            if (!ClientSession.GetUserContext().IsSarniaSite)//INC0508086:OLT::Sarnia:: Deleted EIP issues still show on priorities screen...
            {
                if (invokeControl.IsNotDisposed())
                {
                    if (!(dto is FormEdmontonGN75BDTO)) return;
                    var item = (FormEdmontonGN75BDTO) dto;
                    RegisterRenderTimer(item);
                    RemoveEipIssue(item);
                    AddEipIssue(item);
                }
            }
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<FormEdmontonDTO> QueryDtos()
        {
            if (!authorizedToViewForms)
            {
                return new List<FormEdmontonDTO>();
            }

            List<FormEdmontonDTO> dtos;

            if (userContext.SiteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) && userContext.HasFlocsForWorkPermits)
            {
                dtos = formService.QueryAllRequiringApprovalByFunctionalLocationsAndDateRange(userContext.RootFlocSetForWorkPermits, new DateRange(dateRange), authorizedToViewOvertimeForms);
            }
            else
            {
                dtos = formService.QueryAllRequiringApprovalByFunctionalLocationsAndDateRange(userContext.RootFlocSet, new DateRange(dateRange), authorizedToViewOvertimeForms);
            }

   

            return dtos;
        }

        public void LoadDtos(List<FormEdmontonDTO> dtos)
        
        {
            //waiting for approval and not showing draft or expired in waiting for approval section for all forms but FormGN75B


            dtos.RemoveAll(dto => (dto.Status == FormStatus.Draft || dto.Status == FormStatus.Expired || dto.Status == FormStatus.Closed));  //ayman waiting for approval  (Komal Sahu -- RITM0142432-- Changes to filter out 'Closed' eForms)
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN7FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN7FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN7FormRemoved -= HandleRepeaterRemoved;

            remoteEventRepeater.ServerGN59FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN59FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN59FormRemoved -= HandleRepeaterRemoved;

            remoteEventRepeater.ServerOP14FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerOP14FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerOP14FormRemoved -= HandleRepeaterRemoved;

            remoteEventRepeater.ServerGN24FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN24FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN24FormRemoved -= HandleRepeaterRemoved;

            remoteEventRepeater.ServerGN6FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN6FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN6FormRemoved -= HandleRepeaterRemoved;

            remoteEventRepeater.ServerGN75AFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN75AFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN75AFormRemoved -= HandleRepeaterRemoved;

            remoteEventRepeater.ServerGN1FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN1FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN1FormRemoved -= HandleRepeaterRemoved;

            remoteEventRepeater.ServerOvertimeFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerOvertimeFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerOvertimeFormRemoved -= HandleRepeaterRemoved;

            //ayman Sarnia eip DMND0008992
            remoteEventRepeater.ServerGN75BFormUpdated -= HandleEipIssueRepeaterUpdated;

            //generic template - mangesh
            remoteEventRepeater.ServerGenericTemplateFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGenericTemplateFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGenericTemplateFormRemoved -= HandleRepeaterRemoved;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            //return item.FromDateTime.ToDate() <= dateRange.UpperBound &&
            //       item.ToDateTime.ToDate() >= dateRange.LowerBound &&
            //       item.FormStatus == FormStatus.Draft;
            return item.FromDateTime.ToDate() <= dateRange.UpperBound &&
                   item.ToDateTime.ToDate() >= dateRange.LowerBound &&
                   item.FormStatus == FormStatus.WaitingForApproval; //mangesh Draft to WaitingForApproval
        }

        //ayman Sarnia eip DMND0008992
        //protected override void Repeater_Updated(DomainEventArgs<BaseEdmontonForm> e)
        //{
        //    base.Repeater_Updated(e);
        //}



        protected override FormEdmontonDTO GetDto(BaseEdmontonForm item,string ForAddUpdate)     //ayman action item reading
        {
            return (FormEdmontonDTO) item.CreateDTO();
        }

      


        protected override NodeData GetNodeData(FormEdmontonDTO dto)
        {
            return new FormNodeData(dto);
        }
    }

}