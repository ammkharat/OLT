using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IWorkPermitPage : IDomainPage<WorkPermitDTO, IWorkPermitDetails>
    {
        void DisplayInvalidWorkPermitMessage(string message, string title);
        bool DisplayOptionalInvalidWorkPermitMessage(string message, string title);
        void DisplayInvalidPrintMessage(string message);
        void DisplayInvalidActionMessage(string message, string title);
        void DisplayCommentsForm(WorkPermit permit);

        bool ShowYesNoDialog(string message, string title);
    }
}