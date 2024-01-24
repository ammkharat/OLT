using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{    
    public interface IPermitRequestEdmontonWorkOrderSourceDao : IDao
    {        
        List<PermitRequestWorkOrderSource> QueryByPermitRequest(PermitRequestEdmonton permitRequest);
        void DeleteByPermitRequestId(SqlCommand command, long permitRequestId);
        void InsertWorkOrderSourceList(SqlCommand command, PermitRequestEdmonton permitRequest);
    }
}