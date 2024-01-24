using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class HistorySnapshotExtensions
    {
        public static List<DomainObjectChangeSet> ConvertToChangeSet<T>(this List<T> snapshots)
            where T : IHistorySnapshot
        {
            var changeSets = new List<DomainObjectChangeSet>();
            IHistorySnapshot previousSnapshot = null;
            foreach (var snapshot in snapshots)
            {
                var changeDate = snapshot.LastModifiedDate;
                var username = snapshot.LastModifiedBy == null ? null : snapshot.LastModifiedBy.FullNameWithUserName;
                if (previousSnapshot == null)
                {
                    changeSets.Add(new DomainObjectChangeSet(changeDate, username));
                }
                else
                {
                    var changes =
                        new List<PropertyChange>(
                            new DifferenceBuilder(previousSnapshot, snapshot)
                                .ReflectionAppendAll()
                                .Ignore("LastModifiedBy")
                                .Ignore("LastModifiedDate")
                                .Changes);
                    changeSets.Add(new DomainObjectChangeSet(changeDate, username, changes));
                }
                previousSnapshot = snapshot;
            }
            return changeSets;
        }
    }
}