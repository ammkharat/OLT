using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public abstract class AbstractLogDefinitionPage : AbstractPage<LogDefinitionDTO, ILogDefinitionDetails>, ILogDefinitionPage
    {
        protected AbstractLogDefinitionPage(LogDefinitionGridRenderer gridRenderer)
            : base(new DomainSummaryGrid<LogDefinitionDTO>(gridRenderer, OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, string.Empty), new LogDefinitionDetails())
        {
        }

        protected override bool IsCreatedByCurrentUser(LogDefinitionDTO logDefinition)
        {
            return logDefinition != null &&
                 logDefinition.CreatedByUserId == ClientSession.GetUserContext().User.Id;
        }

        protected override bool IsUpdatedByCurrentUser(LogDefinitionDTO logDefinition)
        {
            return logDefinition != null &&
                 logDefinition.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }
    }
}
