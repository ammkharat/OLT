using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public class GasTestElementInfoConfigurationHistoryList : List<GasTestElementInfoConfigurationHistory>,
        IHistorySnapshot
    {
        private readonly User lastModifiedBy;
        private DateTime lastModifiedDate;

        public GasTestElementInfoConfigurationHistoryList(DateTime lastModifiedDate, User lastModifiedBy)
        {
            this.lastModifiedDate = lastModifiedDate;
            this.lastModifiedBy = lastModifiedBy;
        }

        public GasTestElementInfoConfigurationHistoryList(IEnumerable<GasTestElementInfoConfigurationHistory> snapshot,
            DateTime lastModifiedDate, User lastModifiedBy)
            : this(lastModifiedDate, lastModifiedBy)
        {
            AddRange(snapshot);
        }

        public User LastModifiedBy
        {
            get { return lastModifiedBy; }
        }

        public DateTime LastModifiedDate
        {
            get { return lastModifiedDate; }
        }

        public override int GetHashCode()
        {
            var result = 17;
            result = 29*result + lastModifiedDate.GetHashCode();
            result = 29*result + (lastModifiedBy != null ? lastModifiedBy.GetHashCode() : 0);
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            var gasTestElementInfoConfigurationHistoryList = obj as GasTestElementInfoConfigurationHistoryList;
            if (gasTestElementInfoConfigurationHistoryList == null) return false;
            if (!Equals(lastModifiedDate, gasTestElementInfoConfigurationHistoryList.lastModifiedDate)) return false;
            if (!Equals(lastModifiedBy, gasTestElementInfoConfigurationHistoryList.lastModifiedBy)) return false;
            return true;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]: {2}", lastModifiedBy, lastModifiedDate, base.ToString());
        }
    }

    public static class GasTestElementInfoConfigurationHistoryListExtensions
    {
        public static List<DomainObjectChangeSet> ConvertGasTestElementInfoConfigurationHistories(
            this List<GasTestElementInfoConfigurationHistoryList> snapshots)
        {
            var changeSets = new List<DomainObjectChangeSet>();
            List<GasTestElementInfoConfigurationHistory> previousSnapshot = null;
            foreach (var snapshot in snapshots)
            {
                var changeDate = snapshot[0].LastModifiedDate;
                var username = snapshot[0].LastModifiedBy == null
                    ? null
                    : snapshot[0].LastModifiedBy.FullNameWithUserName;
                if (previousSnapshot == null)
                {
                    changeSets.Add(
                        new DomainObjectChangeSet(changeDate, username));
                }
                else
                {
                    var totalChanges = new List<PropertyChange>();

                    for (var i = 0; i < snapshot.Count; i++)
                    {
                        var changes =
                            new List<PropertyChange>(
                                new DifferenceBuilder(previousSnapshot[i], snapshot[i])
                                    .ReflectionAppendAll(snapshot[i].Name)
                                    .Ignore("LastModifiedBy")
                                    .Ignore("LastModifiedDate")
                                    .Ignore("Id")
                                    .Changes);

                        if (changes.Count > 0)
                            totalChanges.AddRange(changes);
                    }
                    changeSets.Add(new DomainObjectChangeSet(changeDate, username, totalChanges));
                }
                previousSnapshot = snapshot;
            }

            return changeSets;
        }
    }
}