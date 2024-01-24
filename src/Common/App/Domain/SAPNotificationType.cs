namespace Com.Suncor.Olt.Common.Domain
{
    public static class SAPNotificationType
    {
        public const string WorkRequest = "WR";
        public const string EmergencyIncident = "EI";
        public const string ActivityReport = "AR";
        public const string ActionManagement = "AM";
        public const string ManagementChange = "MC";

        public static readonly string[] All =
        {
            WorkRequest,
            EmergencyIncident,
            ActivityReport,
            ActionManagement,
            ManagementChange
        };
    }
}