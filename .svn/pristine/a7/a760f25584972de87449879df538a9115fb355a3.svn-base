using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogTemplateAssignmentGridDisplayAdapter
    {
        private readonly WorkAssignment assignment;

        public LogTemplateAssignmentGridDisplayAdapter(WorkAssignment assignment, bool autoInsert)
        {
            this.assignment = assignment;
            this.AutoInsert = autoInsert;
        }

        public WorkAssignment GetAssignment()
        {
            return assignment;
        }

        public string WorkAssignmentName { get { return assignment.Name; } }

        public bool AutoInsert { get; set; }
    }
}
