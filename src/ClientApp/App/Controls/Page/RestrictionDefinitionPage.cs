using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class RestrictionDefinitionPage : AbstractPage<RestrictionDefinitionDTO, IRestrictionDefinitionDetails>, IRestrictionDefinitionPage
    {
        public RestrictionDefinitionPage()
            : base(
                new DomainSummaryGrid<RestrictionDefinitionDTO>(
                    new RestrictionDefinitionGridRenderer(),
                    OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), 
                    string.Empty),
                new RestrictionDefinitionDetails())
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.RESTRICTION_DEFINITION_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(RestrictionDefinitionDTO definition)
        {
            // TODO: This should use created by user
            return definition != null  && definition.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

        protected override bool IsUpdatedByCurrentUser(RestrictionDefinitionDTO definition)
        {
            return definition != null && definition.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

    }
}