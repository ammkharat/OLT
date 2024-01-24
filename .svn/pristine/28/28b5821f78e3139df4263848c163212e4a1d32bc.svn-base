using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     One of a list of system 'preset' craft or trades for a work permit.
    /// </summary>
    [Serializable]
    public class CraftOrTrade : DomainObject, ICraftOrTrade//, ICacheBySiteId
    {
        public static readonly CraftOrTrade EMPTY =
            new CraftOrTrade(new long?(), string.Empty, string.Empty, 0);

        private readonly long siteId;

        public CraftOrTrade(string name, string workCenterCode, long siteId) :
            this(null, name, workCenterCode, siteId)
        {
        }

        public CraftOrTrade(long? id, string name, string workCenterCode, long siteId)
        {
            Id = id;
            Name = name;
            WorkCenterCode = workCenterCode;
            this.siteId = siteId;
        }

        public string WorkCenterCode { get; set; }

        public string ListDisplayText
        {
            get
            {
                if (this == EMPTY)
                {
                    return string.Empty;
                }

                return Name;
            }
        }

        public long SiteId
        {
            get { return siteId; }
        }

        public string Name { get; set; }

        public ICraftOrTrade Copy()
        {
            return (ICraftOrTrade) Clone();
        }

        public void PerformAction(CraftOrTradeAction actionForSystem, CraftOrTradeAction actionForUserSpecified)
        {
            actionForSystem();
        }

        public override string ToString()
        {
            return this.ReflectionToString();
        }
    }
}