using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ScadaConfigurationDao : AbstractManagedDao, IScadaConfigurationDao
    {
        public List<ScadaConnectionInfo> QueryBySiteId(long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("SiteId", siteId);
            return command.QueryForListResult(PopulateInstance, "QueryScadaConnectionBySite");
        }

        public List<ScadaConnectionInfo> QueryAll()
        {
            var command = ManagedCommand;
            return command.QueryForListResult(PopulateInstance, "QueryAllScadaConnections");
        }

        public void Update(ScadaConnectionInfo connectionInfo)
        {
            var dbInfo = connectionInfo.DatabaseInfo;

            var command = ManagedCommand;
            command.AddParameter("Id", connectionInfo.Id);
            command.AddParameter("PhdUsername", connectionInfo.PhdUsername);
            command.AddParameter("PhdPassword", connectionInfo.PhdPassword);
            command.AddParameter("PhdServer", connectionInfo.PhdServer);
            command.AddParameter("ApiVersion", connectionInfo.ApiVersion);
            command.AddParameter("UseWindowsAuthentication", connectionInfo.UseWindowsAuthentication);
            command.AddParameter("DatabaseType", dbInfo.DatabaseType.ToString());
            command.AddParameter("DatabaseUsername", dbInfo.Username);
            command.AddParameter("DatabasePassword", dbInfo.Password);
            command.AddParameter("DatabaseServer", dbInfo.Server);
            command.AddParameter("DatabaseInstance", dbInfo.DbName);
            command.AddParameter("PiUsername", connectionInfo.PiUsername);
            command.AddParameter("PiPassword", connectionInfo.PiPassword);
            command.AddParameter("PiServer", connectionInfo.PiServer);
        
            command.AddParameter("StartTimeOffset", connectionInfo.StartTimeOffset);
            command.AddParameter("EndTimeOffset", connectionInfo.EndTimeOffset);
            command.AddParameter("SampleType", connectionInfo.SampleType);
            command.AddParameter("SampleFrequency", connectionInfo.SampleFrequency);
            command.AddParameter("DataReductionType", connectionInfo.DataReductionType);
            command.AddParameter("DataReductionFrequency", connectionInfo.DataReductionFrequency);
            command.AddParameter("DataReductionOffset", connectionInfo.DataReductionOffset);
            command.AddParameter("MinimumConfidence", connectionInfo.MinimumConfidence);

            command.Update("UpdateScadaConnectionInfo");
        }

        public ScadaConnectionInfo QueryByScadaConnectionInfoId(long scadaConnectionInfoId)
        {
            var command = ManagedCommand;
            command.AddParameter("ScadaConnectionInfoId", scadaConnectionInfoId);
            return command.QueryForSingleResult(PopulateInstance, "QueryScadaConnectionByScadaConnectionInfoId");
   
        }

        private ScadaConnectionInfo PopulateInstance(SqlDataReader reader)
        {
            var databaseType = reader.Get<string>("DatabaseType");
            var scadaConnectionType = ScadaConnectionType.GetById(reader.Get<byte>("ScadaConnectionTypeId"));
            HoneywellPhdDatabaseType? honeywellPhdDatabaseType = null;
            if (scadaConnectionType == ScadaConnectionType.PhdConnection)
            {
                 honeywellPhdDatabaseType = databaseType.Parse<HoneywellPhdDatabaseType>();
            }

            var honeywellConnectionInfo = new ScadaConnectionInfo(
                reader.Get<long>("Id"),reader.Get<long>("SiteId"), reader.Get<string>("PhdUsername"), reader.Get<string>("PhdPassword"),
                reader.Get<string>("PhdServer"), reader.Get<string>("ApiVersion"),
                reader.Get<bool>("UseWindowsAuthentication"), honeywellPhdDatabaseType.GetValueOrDefault(HoneywellPhdDatabaseType.Oracle),
                reader.Get<string>("DatabaseUsername"),
                reader.Get<string>("DatabasePassword"), reader.Get<string>("DatabaseServer"),
                reader.Get<string>("DatabaseInstance"), reader.Get<int>("StartTimeOffset"),
                reader.Get<int>("EndTimeOffset"),
                reader.Get<string>("SampleType"), reader.Get<int?>("SampleFrequency"),
                reader.Get<string>("DataReductionType"),
                reader.Get<int?>("DataReductionFrequency"), reader.Get<string>("DataReductionOffset"),
                reader.Get<int>("MinimumConfidence"),
                reader.Get<bool>("MockTagWrites"), reader.Get<DateTime>("LastModifiedDateTime"),
                reader.Get<string>("PiServer"), reader.Get<string>("PiUserName"), reader.Get<string>("PiPassword"),
                scadaConnectionType,
                reader.Get<string>("Description"));
            return honeywellConnectionInfo;
        }
    }
}