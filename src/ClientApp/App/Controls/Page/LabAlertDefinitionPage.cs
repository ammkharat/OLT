using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class LabAlertDefinitionPage : AbstractPage<LabAlertDefinitionDTO, ILabAlertDefinitionDetails>, ILabAlertDefinitionPage
    {
        public LabAlertDefinitionPage()
            : base(
                new DomainSummaryGrid<LabAlertDefinitionDTO>(
                    new LabAlertDefinitionGridRenderer(),
                    OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), 
                    string.Empty),
                new LabAlertDefinitionDetails())
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.LAB_ALERT_DEFINITION_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(LabAlertDefinitionDTO definition)
        {
            // TODO: This should use created by user
            return definition != null  && definition.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

        protected override bool IsUpdatedByCurrentUser(LabAlertDefinitionDTO definition)
        {
            return definition != null && definition.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

    }
}