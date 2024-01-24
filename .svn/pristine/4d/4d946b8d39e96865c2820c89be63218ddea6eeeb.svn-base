
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IWorkPermitFortHillsPage : IDomainPage<WorkPermitFortHillsDTO, IWorkPermitFortHillsDetails>
    {
        void DisplayInvalidPrintMessage(string workPermitPrintFailureMessageBoxText);
        void DisplayInvalidMergeDueToFunctionalLocationMessage();
        bool DisplayInvalidMergeDueToParticularFieldsMessage(List<string> fieldNames);

        void ShowAssociatedLogForm(List<LogDTO> associatedLogDtos);
        bool? AskIfTheyWantToPrintTheForms();
    }
}
