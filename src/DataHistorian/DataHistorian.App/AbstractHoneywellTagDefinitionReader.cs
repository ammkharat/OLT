using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;

namespace Com.Suncor.Olt.PlantHistorian
{
    public abstract class AbstractHoneywellTagDefinitionReader : IHoneywellPhdTagDefinitionReader
    {
        private const string QueryTemplate = @"SELECT TAGNAME, DSCR, UNITS FROM IP_TAG 
                WHERE LOWER(TagName) LIKE '{0}%'
                AND ACTIVE_CHK IS NOT NULL AND CLASS_TAG IS NULL";
        protected readonly string databaseConnectionString;
        private readonly long? scadaConnectionInfoId;
        private readonly long? siteId;

        protected AbstractHoneywellTagDefinitionReader(string databaseConnectionString, long? siteId,
            long? scadaConnectionInfoId)
        {
            this.databaseConnectionString = databaseConnectionString;
            this.siteId = siteId;
            this.scadaConnectionInfoId = scadaConnectionInfoId;
        }

        public List<TagInfo> GetTagInfoList(string prefixCharacters)
        {
            var tags = new List<TagInfo>();
            using (var dbConnection = CreateConnection())
            {
                dbConnection.Open();
                using (var dbCommand = dbConnection.CreateCommand())
                {
                    var cleanedUpPrefixCharacters = EscapeCharacters(prefixCharacters);
                    var strSql = string.Format(QueryTemplate, cleanedUpPrefixCharacters.ToLower());
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = strSql;
                    using (var reader = dbCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            var tagName = reader["TAGNAME"] as string;
                            var tagUnits = reader["UNITS"] as string;
                            var tagDescription = reader["DSCR"] as string;
                            tags.Add(new TagInfo(siteId, tagName, tagDescription, tagUnits, false, scadaConnectionInfoId));
                        }
                    }
                }

                return tags;
            }
        }

        protected abstract DbConnection CreateConnection();

        protected abstract string EscapeCharacters(string prefixCharacters);

        public static IHoneywellPhdTagDefinitionReader CreateReader(HoneywellPhdDatabaseInfo databaseInfo, long? siteId,
            long? scadaConnectionInfoId)
        {
            IHoneywellPhdTagDefinitionReader reader;
            switch (databaseInfo.DatabaseType)
            {
                case HoneywellPhdDatabaseType.Oracle:
                    reader = new HoneywellOracleTagDefinitionReader(databaseInfo.DatabaseConnectionString, siteId,
                        scadaConnectionInfoId);
                    break;
                case HoneywellPhdDatabaseType.SqlServer:
                    reader = new HoneywellSqlServerTagDefinitionReader(databaseInfo.DatabaseConnectionString, siteId,
                        scadaConnectionInfoId);
                    break;
                default:
                    reader = null;
                    break;
            }
            return reader;
        }
    }
}