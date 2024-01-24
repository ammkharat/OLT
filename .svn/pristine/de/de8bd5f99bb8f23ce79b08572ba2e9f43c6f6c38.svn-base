using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    internal class PriorityPageMontrealFormSectionPresenter :
        PriorityPageSectionPresenter<MontrealCsdDTO, BaseEdmontonForm>
    {
        private readonly bool authorizedToViewForms;
        private readonly Range<Date> dateRange;
        private readonly IFormEdmontonService formService;

        public PriorityPageMontrealFormSectionPresenter(IPage invokeControl, PriorityPageTree tree,
            IAuthorized authorized,
            UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IFormEdmontonService formService,
            PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            authorizedToViewForms = authorized.ToViewFormsOnThePrioritiesPage(userContext.UserRoleElements);

            if (authorizedToViewForms)
            {
                dateRange =
                    new Range<Date>(
                        Clock.DateNow.SubtractDays(
                            userContext.SiteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage), Date.MaxValue);

                AddSectionNode(PriorityPageSectionKey.MontrealForm);
                AddCatchAllSubSectionNode(StringResources.PriorityPage_FormsRequireApprovalSubSection);

                remoteEventRepeater.ServerMontrealCsdFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerMontrealCsdFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerMontrealCsdFormRemoved += HandleRepeaterRemoved;
            }
        }

        private void HandleRepeaterCreated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<MontrealCsdDTO> QueryDtos()
        {
            if (!authorizedToViewForms)
            {
                return new List<MontrealCsdDTO>();
            }

            var dtos =
                formService.QueryAllMontrealCsdsRequiringApprovalByFunctionalLocationsAndDateRange(
                    userContext.RootFlocSet, new DateRange(dateRange));

            return dtos;
        }

        public void LoadDtos(List<MontrealCsdDTO> dtos)
        {
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerMontrealCsdFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerMontrealCsdFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerMontrealCsdFormRemoved -= HandleRepeaterRemoved;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            return item.FromDateTime.ToDate() <= dateRange.UpperBound &&
                   item.ToDateTime.ToDate() >= dateRange.LowerBound &&
                   item.FormStatus == FormStatus.Draft;
        }

        protected override MontrealCsdDTO GetDto(BaseEdmontonForm item,string ForAddUpdate)    //ayman action item reading
        {
            return (MontrealCsdDTO) item.CreateDTO();
        }

        protected override NodeData GetNodeData(MontrealCsdDTO dto)
        {
            return new FormNodeData(dto);
        }
    }
}