using System.Data.Common;
using Oracle.DataAccess.Client;

namespace Com.Suncor.Olt.PlantHistorian
{
    internal class HoneywellOracleTagDefinitionReader : AbstractHoneywellTagDefinitionReader
    {
        internal HoneywellOracleTagDefinitionReader(string databaseConnectionString, long? siteId,long? scadaConnectionInfoId)
            : base(databaseConnectionString, siteId, scadaConnectionInfoId)
        {
        }

        protected override DbConnection CreateConnection()
        {
            return new OracleConnection(databaseConnectionString);
        }

        protected override string EscapeCharacters(string prefixCharacters)
        {
            // Escape oracle Special characters that can exist in the search string
            return prefixCharacters.Replace("_", @"\_").Replace("%", @"\%");
        }
    }
}