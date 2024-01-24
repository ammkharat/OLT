using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SiteConfigurationDefaults : DomainObject
    {
        public SiteConfigurationDefaults(long siteId, bool copyTargetAlertResponseToLog)
        {
            id = siteId;
            CopyTargetAlertResponseToLog = copyTargetAlertResponseToLog;
        }

        public long SiteId
        {
            get { return IdValue; }
            set { id = value; }
        }

        public bool CopyTargetAlertResponseToLog { get; private set; }
    }
}