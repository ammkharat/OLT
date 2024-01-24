using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface ITargetDefinitionDetails : IApprovableDetails
    {
        string EditedBy { set; }

        bool RequiredApproval { set; }
        bool RequiredAlert { set; }
        bool RequiresResponseWhenAlerted { set; }
        bool Active { set; }
        bool GenerateActionItem { set; }

        string TargetName { set; }
        string FunctionalLocation { set; }
        string Description { set; }
        string Tag { set; }
        string Category { set; }
        string Priority { set; }

        // Threshold
        string NeverToExceedMinValue { set; }
        string NeverToExceedMaxValue { set; }
        string MinValue { set; }
        string MaxValue { set; }
        string TargetValue { set; }
        string GapUnitValue { set; }
        string GapUnitValueUnits { set; }
        string NeverToExceedMaxFrequency { set; }
        string NeverToExceedMinFrequency { set; }
        string MaxValueFrequency { set; }
        string MinValueFrequency { set; }

        string PreApprovedNeverToExceedMinValue { set; }
        string PreApprovedNeverToExceedMaxValue { set; }
        string PreApprovedMinValue { set; }
        string PreApprovedMaxValue { set; }

        TagDirection MaxReadWriteDirection { set;}
        TagDirection MinReadWriteDirection { set;}
        TagDirection TargetReadWriteDirection { set;}
        TagDirection GapUnitReadWriteDirection { set;}

        ISchedule Schedule { set; }

        List<Comment> Comments { set; }
        List<TargetDefinitionDTO> TargetDefinitions { set; }

        string OperationalMode { set; }

        List<DocumentLink> DocumentLinks { set; }
        string WorkAssignment { set; }
    }
}