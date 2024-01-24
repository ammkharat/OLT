using System;

namespace Com.Suncor.Olt.Common.Domain.PlantHistorian
{
    [Serializable]
    public class ScadaConnectionInfo
    {
        public ScadaConnectionInfo(long id, long siteId, string phdUsername, string phdPassword, string phdServer,
            string phdApiVersion, bool useWindowsAuthentication, HoneywellPhdDatabaseType databaseType,
            string databaseUser, string databasePassword, string databaseServer, string databaseName,
            int startTimeOffset, int endTimeOffset, string sampleType, int? sampleFrequency, string dataReductionType,
            int? dataReductionFrequency, string dataReductionOffset, int minimumConfidence, bool mockTagWrites,
            DateTime lastModifiedDateTime, string piServer, string piUsername, string piPassword,
            ScadaConnectionType scadaConnectionType, string description)
        {
            Id = id;
            SiteId = siteId;
            ScadaConnectionType = scadaConnectionType;
            Description = description;
            PhdUsername = phdUsername;
            PhdPassword = phdPassword;
            PhdServer = phdServer;
            PiUsername = piUsername;
            PiPassword = piPassword;
            PiServer = piServer;
            ApiVersion = phdApiVersion;
            UseWindowsAuthentication = useWindowsAuthentication;

            DatabaseInfo = HoneywellPhdDatabaseInfo.Create(databaseType, databaseUser, databasePassword, databaseServer,
                databaseName);
            StartTimeOffset = startTimeOffset;
            EndTimeOffset = endTimeOffset;

            SampleType = sampleType;
            SampleFrequency = sampleFrequency;

            DataReductionType = dataReductionType;
            DataReductionFrequency = dataReductionFrequency;
            DataReductionOffset = dataReductionOffset;

            MinimumConfidence = minimumConfidence;

            // these have never changed.  So, leaving as is here.
            ConnectionTimeout = 30000;
            RequestTimeout = 30000;
            MonitorTimeout = 240000;

            MockTagWrites = mockTagWrites;

            LastModifiedDateTime = lastModifiedDateTime;
        }

        public long Id { get; set; }

        public string Description { get; private set; }

        public bool UseWindowsAuthentication { get; private set; }
        public HoneywellPhdDatabaseInfo DatabaseInfo { get; private set; }

        public string PhdUsername { get; private set; }
        public string PhdPassword { get; private set; }

        public string PiUsername { get; private set; }
        public string PiPassword { get; private set; }

        public string PiServer { get; private set; }
        public string PhdServer { get; private set; }

        public string ApiVersion { get; private set; }

        public long SiteId { get; private set; }

        public int ConnectionTimeout { get; private set; }
        public int RequestTimeout { get; private set; }
        public int MonitorTimeout { get; private set; }

        public int StartTimeOffset { get; private set; }
        public int EndTimeOffset { get; private set; }
        public ScadaConnectionType ScadaConnectionType { get; private set; }

        public string SampleType { get; private set; }
        public int? SampleFrequency { get; private set; }

        public string DataReductionType { get; private set; }
        public int? DataReductionFrequency { get; private set; }
        public string DataReductionOffset { get; private set; }

        public int MinimumConfidence { get; private set; }

        public bool MockTagWrites { get; private set; }

        public DateTime LastModifiedDateTime { get; private set; }
    }

    [Serializable]
    public enum HoneywellPhdDatabaseType
    {
        Oracle = 1,
        SqlServer = 2
    };

    [Serializable]
    public abstract class HoneywellPhdDatabaseInfo
    {
        protected HoneywellPhdDatabaseInfo(HoneywellPhdDatabaseType databaseType, string username, string password,
            string server, string dbName)
        {
            DatabaseType = databaseType;
            Username = username;
            Password = password;
            Server = server;
            DbName = dbName;
        }

        public abstract string DatabaseConnectionString { get; }
        public HoneywellPhdDatabaseType DatabaseType { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Server { get; private set; }
        public string DbName { get; private set; }

        public static HoneywellPhdDatabaseInfo Create(HoneywellPhdDatabaseType databaseType, string username,
            string password, string server, string dbName)
        {
            if (databaseType == HoneywellPhdDatabaseType.Oracle)
                return new HoneywellOracleDatabaseInfo(username, password, server, dbName);
            return new HoneywellSqlServerDatabaseInfo(username, password, server, dbName);
        }
    }

    [Serializable]
    public class HoneywellOracleDatabaseInfo : HoneywellPhdDatabaseInfo
    {
        private const string ConnectionStringFormat =
            "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = {1})));User Id={2};Password={3};Enlist=false";

        private readonly string databaseConnectionString;

        public HoneywellOracleDatabaseInfo(string username, string password, string server, string serviceName)
            : base(HoneywellPhdDatabaseType.Oracle, username, password, server, serviceName)

        {
            databaseConnectionString = string.Format(ConnectionStringFormat, Server, DbName, Username, Password);
        }

        public override string DatabaseConnectionString
        {
            get { return databaseConnectionString; }
        }
    }

    [Serializable]
    public class HoneywellSqlServerDatabaseInfo : HoneywellPhdDatabaseInfo
    {
        private const string ConnectionStringFormat =
            "Data Source={0};Initial Catalog={1};User Id={2};Password={3};MultipleActiveResultSets=True;Connection Timeout=60";

        private readonly string databaseConnectionString;

        public HoneywellSqlServerDatabaseInfo(string username, string password, string server, string dbInstance)
            : base(HoneywellPhdDatabaseType.SqlServer, username, password, server, dbInstance)

        {
            databaseConnectionString = string.Format(ConnectionStringFormat, Server, DbName, Username, Password);
        }

        public override string DatabaseConnectionString
        {
            get { return databaseConnectionString; }
        }
    }
}