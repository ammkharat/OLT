using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class DeviationAlertPagePresenter :
        AbstractRespondableDomainPagePresenter
            <DeviationAlertDTO, DeviationAlert, IDeviationAlertDetails, IDeviationAlertPage>
    {
        private readonly IDeviationAlertService service;

        public DeviationAlertPagePresenter() : this(new DeviationAlertPage())
        {
        }

        public DeviationAlertPagePresenter(IDeviationAlertPage page) : base(page)
        {
            service = ClientServiceRegistry.Instance.GetService<IDeviationAlertService>();

            SubscribeToEvents();
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_DeviationAlert; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.DeviationAlerts; }
        }

        private void SubscribeToEvents()
        {
            page.Details.ViewResponseHistory += HistoryButton_Clicked;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.ViewResponseHistory -= HistoryButton_Clicked;
        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {
            var item = QueryForFirstSelectedItem();
            if (item != null)
            {
                EditHistoryFormPresenter presenter = new EditDeviationAlertResponseHistoryFormPresenter(item);
                presenter.Run(page.ParentForm);
            }
        }

        protected override IForm CreateResponseForm(DeviationAlert alert)
        {
            var userRoleElements = userContext.UserRoleElements;
            var selectedItems = page.SelectedItems;

            var canRespond = authorized.ToRespondToDeviationAlerts(userRoleElements, userContext.UserShift,
                selectedItems[0]);
            var canEditComments = authorized.ToEditDeviationAlertComments(userRoleElements);

            return new DeviationAlertResponseForm(alert, canEditComments, canRespond);
        }

        //DMND0010124 mangesh
        protected override IForm CreateCopyLastResponseForm(DeviationAlert alert)
        {
            //var userRoleElements = userContext.UserRoleElements;
            var selectedItems = page.SelectedItems;



            return new DeviationAlertCopyLastResponseForm(alert, false, true, selectedItems);
        }

        protected override PageKey GetDefinitionPageKey()
        {
            return PageKey.RESTRICTION_DEFINITION_PAGE;
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerDeviationAlertCreated += repeater_Created;
            remoteEventRepeater.ServerDeviationAlertUpdated += repeater_Updated;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerDeviationAlertCreated -= repeater_Created;
            remoteEventRepeater.ServerDeviationAlertUpdated -= repeater_Updated;
        }

        protected override DeviationAlert QueryByDto(DeviationAlertDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        protected override void ControlDetailButtons()
        {
            var userRoleElements = userContext.UserRoleElements;
            var selectedItems = page.SelectedItems;
            var hasSingleItemSelected = selectedItems.Count == 1;

            //COMMENT: trg - if this changes .. it means that the PriorityPagePresenter needs to reflect change as well.
            var details = page.Details;
            details.RespondEnabled = hasSingleItemSelected &&
                                     (authorized.ToEditDeviationAlertComments(userRoleElements) ||
                                      authorized.ToRespondToDeviationAlerts(userRoleElements, userContext.UserShift,
                                          selectedItems[0])) &&
                                     service.IsWithinDaysToEditResponse(userContext.Site, selectedItems);

            //details.RespondEnabled = true;


            details.GoToDefinitionEnabled = hasSingleItemSelected;
            details.ViewReponseHistoryEnabled = hasSingleItemSelected &&
                                                selectedItems.TrueForAll(obj => obj.HasUserEnteredResponse);

            //DMND0010124 mangesh
           if(page.SelectedItems.Count == 0) return;
            
            var item = page.SelectedItems.First();
            bool isAllNameAreSame = page.SelectedItems.All(x => x.RestrictionDefinitionName == item.RestrictionDefinitionName);
            details.CopyLastResponseEnabled = page.SelectedItems.Count > 1 && isAllNameAreSame; 
        }

        protected override void SetDetailData(IDeviationAlertDetails details, DeviationAlert value)
        {
            details.Assignments = new List<DeviationAlertResponseReasonCodeAssignment>();

            if (value != null)
            {
                details.RestrictionDefinitionName = value.RestrictionDefinitionName;
                details.RestrictionDefinitionDescription = value.RestrictionDefinitionDescription;
                details.FunctionalLocationName = value.FunctionalLocation.FullHierarchyWithDescription;

                details.MeasurementTagName = value.MeasurementTagName;
                details.MeasurementTagValue = Convert.ToString(value.MeasurementValue);

                details.ProductionTargetTagName = value.ProductionTargetTagName;
                details.ProductionTargetTagValue = Convert.ToString(value.ProductionTargetValue);

                details.DeviationValue = Convert.ToString(value.DeviationValue);

                details.Comments = value.Comments;

                details.StartTime = value.StartDateTime.ToLongDateAndTimeString();
                details.EndTime = value.EndDateTime.ToLongDateAndTimeString();

                if (value.DeviationAlertResponse != null)
                {
                    details.Assignments = value.DeviationAlertResponse.ReasonCodeAssignments;
                }
            }
            else
            {
                details.RestrictionDefinitionName = string.Empty;
                details.RestrictionDefinitionDescription = string.Empty;
                details.FunctionalLocationName = string.Empty;

                details.MeasurementTagName = string.Empty;
                details.MeasurementTagValue = string.Empty;

                details.ProductionTargetTagName = string.Empty;
                details.ProductionTargetTagValue = string.Empty;

                details.DeviationValue = string.Empty;

                details.StartTime = string.Empty;
                details.EndTime = string.Empty;

                details.Comments = string.Empty;
            }
        }

        protected override DeviationAlertDTO CreateDTOFromDomainObject(DeviationAlert deviationAlert)
        {
            return new DeviationAlertDTO(deviationAlert);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForDeviationAlerts(userContext.SiteConfiguration);
        }

        protected override IList<DeviationAlertDTO> GetDtos(Range<Date> range)
        {
            if (userContext.HasFlocsForRestrictions)
            {
                return service.QueryDTOsByFLOCAndDaysPrecedingGivenDate(userContext.RootFlocSetForRestrictions, range);
            }
            return service.QueryDTOsByFLOCAndDaysPrecedingGivenDate(userContext.RootFlocSet, range);
        }
    }
}