using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class CustomFieldGroup : DomainObject
    {
        private readonly List<WorkAssignment> workAssignments;

        public CustomFieldGroup(string name, List<WorkAssignment> workAssignments, List<CustomField> fields,
            bool appliesToLogs, bool appliesToSummaryLogs, bool appliesToDailyDirectives, bool appliesToActionItems)            //ayman custom fields DMND0010030
            : this(
                null, null, name, workAssignments, fields, appliesToLogs, appliesToSummaryLogs, appliesToDailyDirectives, appliesToActionItems
                )
        {
        }

        public CustomFieldGroup(long? id, long? originCustomFieldGroupId, string name,
            List<WorkAssignment> workAssignments, List<CustomField> fields, bool appliesToLogs,
            bool appliesToSummaryLogs, bool appliesToDailyDirectives, bool appliesToActionItems)          //ayman custom fields DMND0010030
        {
            this.id = id;
            OriginCustomFieldGroupId = originCustomFieldGroupId;
            Name = name;
            this.workAssignments = workAssignments ?? new List<WorkAssignment>();
            Fields = fields ?? new List<CustomField>();
            AppliesToLogs = appliesToLogs;
            AppliesToSummaryLogs = appliesToSummaryLogs;
            AppliesToDailyDirectives = appliesToDailyDirectives;
            AppliesToActionItems = appliesToActionItems;                     //ayman custom fields DMND0010030
        }

        public string Name { get; set; }

        public List<WorkAssignment> WorkAssignments
        {
            get { return workAssignments; }
        }

        public List<CustomField> Fields { get; private set; }

        public bool AppliesToLogs { get; set; }

        public bool AppliesToSummaryLogs { get; set; }

        public bool AppliesToDailyDirectives { get; set; }

        //ayman custom fields DMND0010030
        public bool AppliesToActionItems { get; set; }

        public string WorkAssignmentsAsString
        {
            get
            {
                workAssignments.Sort(wa => wa.Name, true);
                return workAssignments.BuildCommaSeparatedList(wa => wa.Name);
            }
        }

        public long? OriginCustomFieldGroupId { get; set; }

        public CustomFieldGroup Clone()
        {
            var clone = this.DeepClone();
            clone.Id = null;
            return clone;
        }
    }
}