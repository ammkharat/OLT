using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface ITargetDefinitionPage : IDomainPage<TargetDefinitionDTO, ITargetDefinitionDetails>
    {
        void DisplayTargetDeleteDeniedMessage(List<string> parentTargetNames);
        void DisplayTargetDeleteDeniedMessageCausedByExistingActionItemDefinition(List<string> actionItemNames);

        void DisplayActionItemDefinitionForm(ActionItemDefinition actionItemDefinition);
    }
}
