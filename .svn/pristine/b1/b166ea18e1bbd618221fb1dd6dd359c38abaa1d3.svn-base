using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IDirectivePage : IDomainPage<DirectiveDTO, IDirectiveDetails>
    {
        void ExpireSuccessfulMessage();
        DialogResult ShowEditingActiveDirectiveWarning();
        DialogResult ShowExpireAndCloneActiveReadDirectiveWarning();
    }
}