using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IOnPremisePersonnelSupervisorPage : IDomainPage<OnPremisePersonnelSupervisorDTO, IOnPremisePersonnelDetails>
    {
      
    }

    public interface IOnPremisePersonnelAuditPage : IDomainPage<OnPremisePersonnelAuditDTO, IOnPremisePersonnelDetails>
    {
    }
}