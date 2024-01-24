using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class RestrictionDefinitionPagePresenter
        :
            AbstractDeletableDomainPagePresenter
                <RestrictionDefinitionDTO, RestrictionDefinition, IRestrictionDefinitionDetails,
                    IRestrictionDefinitionPage>
    {
        private readonly IRestrictionDefinitionService definitionService;

        public RestrictionDefinitionPagePresenter() : base(new RestrictionDefinitionPage())
        {
            definitionService = ClientServiceRegistry.Instance.GetService<IRestrictionDefinitionService>();
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_RestrictionDefinition; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.RestrictionDefinitions; }
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(RestrictionDefinition item)
        {
            return new EditRestrictionDefinitionHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(RestrictionDefinition item)
        {
            return new RestrictionDefinitionForm(item);
        }

        protected override void ControlDetailButtons()
        {
            var user = ClientSession.GetUserContext().UserRoleElements;
            if (user != null)
            {
                var selectedItems = page.SelectedItems;
                var hasSingleItemSelected = selectedItems.Count == 1;
                var hasItemsSelected = selectedItems.Count > 0;

                var firstSelectedItem = page.FirstSelectedItem;

                var details = page.Details;
                details.DeleteEnabled = hasItemsSelected &&
                                        authorized.ToDeleteRestrictionDefinitions(user, selectedItems);
                details.EditEnabled = hasSingleItemSelected &&
                                      authorized.ToEditRestrictionDefinition(user, firstSelectedItem);
                details.ViewEditHistoryEnabled = hasSingleItemSelected;
            }
        }

        protected override void Delete(RestrictionDefinition definition)
        {
            definition.LastModifiedBy = ClientSession.GetUserContext().User;
            definition.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(definitionService.Remove, definition);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerRestrictionDefinitionCreated += repeater_Created;
            remoteEventRepeater.ServerRestrictionDefinitionUpdated += repeater_Updated;
            remoteEventRepeater.ServerRestrictionDefinitionRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerRestrictionDefinitionCreated -= repeater_Created;
            remoteEventRepeater.ServerRestrictionDefinitionUpdated -= repeater_Updated;
            remoteEventRepeater.ServerRestrictionDefinitionRemoved -= repeater_Removed;
        }

        protected override RestrictionDefinition QueryByDto(RestrictionDefinitionDTO dto)
        {
            return definitionService.QueryById(dto.IdValue);
        }

        protected override void SetDetailData(IRestrictionDefinitionDetails details, RestrictionDefinition definition)
        {
            new RestrictionDefinitionDetailsPresenter(details, definition).LoadView();
        }

        protected override RestrictionDefinitionDTO CreateDTOFromDomainObject(RestrictionDefinition domainObject)
        {
            return new RestrictionDefinitionDTO(domainObject);
        }

        protected override IList<RestrictionDefinitionDTO> GetDtos(Range<Date> dateRange)
        {
            if (userContext.HasFlocsForRestrictions)
            {
                return
                    definitionService.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(
                        userContext.RootFlocSetForRestrictions, dateRange);
            }
            return definitionService.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(
                ClientSession.GetUserContext().RootFlocSet, dateRange);
        }
    }
}