using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitRequestFortHillsWorkOrderSourceDao : IDao
    {
        List<PermitRequestWorkOrderSource> QueryByPermitRequest(PermitRequestFortHills permitRequest);
        void DeleteByPermitRequestId(SqlCommand command, long permitRequestId);
        void InsertWorkOrderSourceList(SqlCommand command, PermitRequestFortHills permitRequest);
    }
}