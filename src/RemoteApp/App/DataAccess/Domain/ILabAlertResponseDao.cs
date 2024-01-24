using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILabAlertResponseDao : IDao
    {
        List<LabAlertResponse> QueryByLabAlertId(long labAlertId);
        LabAlertResponse Insert(LabAlertResponse response);
    }
}
