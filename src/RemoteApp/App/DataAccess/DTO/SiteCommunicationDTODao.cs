using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class SiteCommunicationDTODao : AbstractManagedDao, ISiteCommunicationDTODao
    {
        public List<SiteCommunicationDTO> QueryBySiteAndDateTime(long siteId, DateTime dateTime)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@DateTime", dateTime);
            return command.QueryForListResult<SiteCommunicationDTO>(PopulateInstance , "QuerySiteCommunicationDTOBySiteAndDateTime");
        }

        private SiteCommunicationDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string message = reader.Get<string>("Message");

            return new SiteCommunicationDTO(id, message);
        }
    }
}
