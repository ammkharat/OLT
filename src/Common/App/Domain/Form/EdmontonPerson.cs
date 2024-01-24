using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public enum BadgeScanStatus
    {
        In,
        Out
    };

    /// <summary>
    ///     Contains information pulled from Edmonton's internal system about a user who has scanned/badged into site.
    /// </summary>
    [Serializable]
    public class EdmontonPerson : DomainObject
    {
        private const string DisplayFormat = "{0}, {1} (#{2})";

        public EdmontonPerson(long? id, string firstName, string lastName, string badgeId, DateTime lastScan,
            BadgeScanStatus scanStatus)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
            BadgeId = badgeId;
            LastScan = lastScan;
            ScanStatus = scanStatus;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string BadgeId { get; private set; }
        public DateTime LastScan { get; private set; }
        public BadgeScanStatus ScanStatus { get; private set; }

        public string DisplayString
        {
            get { return string.Format(DisplayFormat, LastName, FirstName, BadgeId); }
        }

        public void UpdateScanData(DateTime lastScan, BadgeScanStatus scanStatus)
        {
            LastScan = lastScan;
            ScanStatus = scanStatus;
        }
    }
}