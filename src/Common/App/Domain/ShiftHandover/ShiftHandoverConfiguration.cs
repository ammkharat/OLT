using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    [Serializable]
    public class ShiftHandoverConfiguration : DomainObject
    {
        public ShiftHandoverConfiguration()
        {
            Questions = new List<ShiftHandoverQuestion>();
            WorkAssignments = new List<WorkAssignment>();
        }

        public ShiftHandoverConfiguration(
            long? id,
            List<WorkAssignment> workAssignments,
            string name,
            List<ShiftHandoverQuestion> questions)
        {
            WorkAssignments = new List<WorkAssignment>();
            this.id = id;

            if (workAssignments != null)
            {
                WorkAssignments.AddRange(workAssignments);
            }

            Name = name;
            Questions = questions ?? new List<ShiftHandoverQuestion>();
        }

        public List<WorkAssignment> WorkAssignments { get; private set; }

        public string Name { get; set; }

        public List<ShiftHandoverQuestion> Questions { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}