using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Client.Controls.Details;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageActionItemDefinitionDetailsPresenter : PriorityPageDetailsPresenter<IActionItemDefinitionDetails>
    {
        
        public PriorityPageActionItemDefinitionDetailsPresenter(long id, IActionItemDefinitionService service)
            
            : base(
                StringResources.DomainObjectName_ActionItem,
                new ActionItemDefinitionDetails())
        {
            view.Title = StringResources.ActionItemDefinitionFormTitle;
            ActionItemDefinition actionItemDefinition = service.QueryById(id);
            details.SetDetails(actionItemDefinition, userContext.IsEdmontonSite);
        }

        protected override void UnsubscribeToEvents()
        {

        }
    }
}
