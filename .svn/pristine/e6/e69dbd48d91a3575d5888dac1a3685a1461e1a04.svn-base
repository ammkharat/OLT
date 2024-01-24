using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IWorkPermitMontrealPage : IDomainPage<WorkPermitMontrealDTO, IWorkPermitMontrealDetails>
    {
        void DisplayInvalidPrintMessage(string message);
        void OpenDocument(string document);
        DialogResult ShowUserHasNotReadDocumentLinksMessage();
        void ShowAssociatedLogForm(List<LogDTO> logDtos);
    }
}