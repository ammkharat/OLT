using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using System;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.Utilities;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    class PriorityPageFormOilsandsSectionPresenter : PriorityPageSectionPresenter<FormOilsandsPriorityPageDTO, BaseFormOilsands>
    {
        private readonly IFormOilsandsService formService;
        private readonly bool authorizedToViewFormsOnPriorityPage;
        private readonly Range<Date> dateRange;
        private readonly GenericTemplateFormTimerManager timerManager;

        public PriorityPageFormOilsandsSectionPresenter(IPage invokeControl, PriorityPageTree tree, IAuthorized authorized,
                                                UserContext userContext,
                                                IRemoteEventRepeater remoteEventRepeater,
                                                IFormOilsandsService formService, 
                                                PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            authorizedToViewFormsOnPriorityPage = authorized.ToViewFormsOnThePrioritiesPage(userContext.UserRoleElements);   // ayman Dharmesh issue INC0030409  ( #3656)
            timerManager = new GenericTemplateFormTimerManager();
            if (authorizedToViewFormsOnPriorityPage)
            {
                dateRange = new Range<Date>(Clock.DateNow.SubtractDays(userContext.SiteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage), Date.MaxValue);

                AddSectionNode(PriorityPageSectionKey.FormOilsands);
                AddCatchAllSubSectionNode(StringResources.PriorityPage_FormsRequireApprovalSubSection);

                remoteEventRepeater.ServerFormOilsandsCreated += Repeater_Created;
                remoteEventRepeater.ServerFormOilsandsUpdated += Repeater_Updated;
                remoteEventRepeater.ServerFormOilsandsRemoved += Repeater_Removed;

                //RITM0341710 - mangesh
                remoteEventRepeater.ServerGenericTemplateFormCreated += HandleGTRepeaterCreated;
                remoteEventRepeater.ServerGenericTemplateFormUpdated += HandleGTRepeaterUpdated;
                //remoteEventRepeater.ServerGenericTemplateFormRemoved += HandleRepeaterRemoved;
            }
        }

        private void HandleRepeaterCreated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Created(sender, new DomainEventArgs<BaseFormOilsands>(e.SelectedItem));
        }

        private void HandleGTRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : FormGenericTemplate
        {
            FormGenericTemplateDTO formGenericTemplateDto = new FormGenericTemplateDTO(e.SelectedItem);

            if (e.SelectedItem is FormGenericTemplate)
            {
                var formGenericTemplate = e.SelectedItem as FormGenericTemplate;
                var dto = formGenericTemplate.CreateDTO() as FormGenericTemplateDTO;
                RegisterRenderTimer(dto);
            }
            Repeater_UpdatedForGT(formGenericTemplateDto);
        }

        private void HandleGTRepeaterCreated<T>(object sender, DomainEventArgs<T> e) where T : FormGenericTemplate
        {
            FormGenericTemplateDTO formGenericTemplateDto = new FormGenericTemplateDTO(e.SelectedItem);

            if (e.SelectedItem is FormGenericTemplate)
            {
                var formGenericTemplate = e.SelectedItem as FormGenericTemplate;
                var dto = formGenericTemplate.CreateDTO() as FormGenericTemplateDTO;
                RegisterRenderTimer(dto);
            }
            Repeater_UpdatedForGT(formGenericTemplateDto);
        }

        private void RegisterRenderTimer(FormGenericTemplateDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            //if (dto.LastModifiedDateTime.AddSeconds(10) < now) return;
            //var timeUntilActive = dto.LastModifiedDateTime.AddSeconds(10).Subtract(now);
            SetupTimerCallback(TimeSpan.FromSeconds(2), dto);
        }

        private void HandleTimerFire(object dto)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<FormGenericTemplateDTO>(RefreshItem), dto);
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
                if (!(dto is FormGenericTemplateDTO)) return;
                var item = (FormGenericTemplateDTO)dto;
                RegisterRenderTimer(item);
                RemoveFortHillGT(item);
                AddFortHillGT(item);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, FormGenericTemplateDTO dto)
        {
            if (differenceInTime.TotalMilliseconds > 0)
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
        }


        public List<FormOilsandsPriorityPageDTO> QueryDtos()
        {
            if (!authorizedToViewFormsOnPriorityPage)
            {
                return new List<FormOilsandsPriorityPageDTO>();
            }

            return formService.QueryAllOilsandsFormsRequiringApprovalByFunctionalLocationsAndDateRange(userContext.RootFlocSet, new DateRange(dateRange));
        }

        public void LoadDtos(List<FormOilsandsPriorityPageDTO> dtos)
        {
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerFormOilsandsCreated -= Repeater_Created;
            remoteEventRepeater.ServerFormOilsandsUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerFormOilsandsRemoved -= Repeater_Removed;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseFormOilsands item)
        {
            return item.FromDate <= dateRange.UpperBound &&
                   item.ToDate >= dateRange.LowerBound && 
                   !item.AllApprovalsAreIn();
        }

        protected override FormOilsandsPriorityPageDTO GetDto(BaseFormOilsands item,string ForAddUpdate)    //ayman action item reading
        {
            return item.CreatePriorityPageDTO();
        }

        protected override NodeData GetNodeData(FormOilsandsPriorityPageDTO dto)
        {
            return new FormOilsandsNodeData(dto);
        }
    }

}