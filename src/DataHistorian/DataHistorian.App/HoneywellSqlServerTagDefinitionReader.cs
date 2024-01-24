using System.Data.Common;
using System.Data.SqlClient;

namespace Com.Suncor.Olt.PlantHistorian
{
    internal class HoneywellSqlServerTagDefinitionReader : AbstractHoneywellTagDefinitionReader
    {
        internal HoneywellSqlServerTagDefinitionReader(string databaseConnectionString, long? siteId,long? scadaConnectionInfoId)
            : base(databaseConnectionString, siteId,scadaConnectionInfoId)
        {
        }

        protected override DbConnection CreateConnection()
        {
            return new SqlConnection(databaseConnectionString);
        }

        protected override string EscapeCharacters(string prefixCharacters)
        {
            // Escape SQL Server Special characters that can exist in the search string
            return prefixCharacters.Replace("_", "[_]").Replace("%", "[%]");
        }
    }
}