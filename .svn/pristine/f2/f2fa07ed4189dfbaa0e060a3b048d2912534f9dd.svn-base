using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class LogTemplate : ModifiableDomainObject
    {
        public enum LogType
        {
            Standard = 1,
            SummaryLog = 2,
            DailyDirective = 3
        }

        public LogTemplate(string name, string text, List<WorkAssignment> workAssignments, bool appliesToLogs,
            bool appliesToSummaryLogs, bool appliesToDirectives,
            User lastModifiedBy, DateTime lastModifiedDateTime, User createdBy, DateTime createdDateTime)
        {
            Name = name;
            Text = text;
            AppliesToLogs = appliesToLogs;
            AppliesToSummaryLogs = appliesToSummaryLogs;
            AppliesToDirectives = appliesToDirectives;
            WorkAssignments = workAssignments;

            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;

            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
        }

        public LogTemplate(LogTemplate logTemplate)
            : this(
                logTemplate.Name, logTemplate.Text, logTemplate.WorkAssignments, logTemplate.AppliesToLogs,
                logTemplate.AppliesToSummaryLogs, logTemplate.AppliesToDirectives,
                logTemplate.LastModifiedBy, logTemplate.LastModifiedDateTime, logTemplate.CreatedBy,
                logTemplate.CreatedDateTime)
        {
            Id = logTemplate.Id;
        }

        public string Name { get; set; }

        public string Text { get; set; }

        public bool AppliesToLogs { get; set; }

        public bool AppliesToSummaryLogs { get; set; }

        public bool AppliesToDirectives { get; set; }

        public List<WorkAssignment> WorkAssignments { get; private set; }

        public User CreatedBy { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public string WorkAssignmentsString
        {
            get
            {
                WorkAssignments.Sort(wa => wa.Name, true);
                return WorkAssignments.BuildNameStringFromWorkAssignmentList();
            }
        }

        public bool SharesWorkAssignmentWith(LogTemplate otherLogTemplate)
        {
            // TODO Troy: TDD this and use comments code instead. 
//            return FunctionalLocation.IntersectionContainsAtLeastOneItem(functionalLocations,
//                                                                         otherLogTemplate.FunctionalLocations);
            foreach (var workAssignment in WorkAssignments)
            {
                if (otherLogTemplate.WorkAssignments.Contains(workAssignment))
                {
                    return true;
                }
            }

            return false;
        }
    }
}