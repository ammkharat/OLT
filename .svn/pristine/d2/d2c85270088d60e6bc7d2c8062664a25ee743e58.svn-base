using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class LabAlertDefinitionPagePresenter
        : AbstractDeletableDomainPagePresenter<LabAlertDefinitionDTO, LabAlertDefinition, ILabAlertDefinitionDetails, ILabAlertDefinitionPage>
    {
        private readonly ILabAlertDefinitionService definitionService;

        public LabAlertDefinitionPagePresenter() 
            : base(new LabAlertDefinitionPage())
        {
            definitionService = ClientServiceRegistry.Instance.GetService<ILabAlertDefinitionService>();
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(LabAlertDefinition item)
        {
            return new EditLabAlertDefinitionHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(LabAlertDefinition item)
        {
            return new LabAlertDefinitionForm(item);
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements user = ClientSession.GetUserContext().UserRoleElements;
            if (user != null)
            {
                List<LabAlertDefinitionDTO> selectedItems = page.SelectedItems;
                bool hasSingleItemSelected = selectedItems.Count == 1;
                bool hasItemsSelected = selectedItems.Count > 0;
                
                LabAlertDefinitionDTO firstSelectedItem = page.FirstSelectedItem;

                ILabAlertDefinitionDetails details = page.Details;
                details.DeleteEnabled = hasItemsSelected && authorized.ToDeleteLabAlertDefinitions(user, selectedItems);
                details.EditEnabled = hasSingleItemSelected && authorized.ToEditLabAlertDefinition(user, firstSelectedItem);
                details.ViewEditHistoryEnabled = hasSingleItemSelected;
            }
        }

        protected override bool ShouldBeDisplayed(LabAlertDefinition item)
        {
            return ClientSession.GetUserContext().RootsForSelectedFunctionalLocations.Exists(selected =>
                item.FunctionalLocation.IsOrIsAncestorOfOrIsDescendantOf(selected));
        }

        protected override void Delete(LabAlertDefinition definition)
        {
            definition.LastModifiedBy = ClientSession.GetUserContext().User;
            definition.LastModifiedDate = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(definitionService.Remove, definition);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLabAlertDefinitionCreated += repeater_Created;
            remoteEventRepeater.ServerLabAlertDefinitionUpdated += repeater_Updated;
            remoteEventRepeater.ServerLabAlertDefinitionRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLabAlertDefinitionCreated -= repeater_Created;
            remoteEventRepeater.ServerLabAlertDefinitionUpdated -= repeater_Updated;
            remoteEventRepeater.ServerLabAlertDefinitionRemoved -= repeater_Removed;
        }

        protected override LabAlertDefinition QueryByDto(LabAlertDefinitionDTO dto)
        {
            return definitionService.QueryById(dto.IdValue);
        }

        protected override void SetDetailData(ILabAlertDefinitionDetails details, LabAlertDefinition definition)
        {
            new LabAlertDefinitionDetailsPresenter(details, definition).LoadView();
        }

        protected override LabAlertDefinitionDTO CreateDTOFromDomainObject(LabAlertDefinition domainObject)
        {
            return new LabAlertDefinitionDTO(domainObject);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_LabAlertDefinition; }
        }

        protected override IList<LabAlertDefinitionDTO> GetDtos(Range<Date> dateRange)
        {
            return definitionService.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(
                ClientSession.GetUserContext().RootFlocSet, dateRange);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.LabAlertDefinitions; }
        }
    }
}