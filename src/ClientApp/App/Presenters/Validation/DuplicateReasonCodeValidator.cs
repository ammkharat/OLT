using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class DuplicateReasonCodeValidator
    {
        private readonly List<DeviationAlertResponseReasonCodeAssignment> deviationAlertResponseReasonCodeAssignments;

        public DuplicateReasonCodeValidator(List<DeviationAlertResponseReasonCodeAssignment> deviationAlertResponseReasonCodeAssignments)
        {
            this.deviationAlertResponseReasonCodeAssignments = deviationAlertResponseReasonCodeAssignments;
        }

        public bool HasDuplicateAssignments()
        {
            foreach (DeviationAlertResponseReasonCodeAssignment assignment in deviationAlertResponseReasonCodeAssignments)
            {
                bool hasDuplicateReasonCode = deviationAlertResponseReasonCodeAssignments.Exists(
                    responseReasonCodeAssignment =>
                        assignment != responseReasonCodeAssignment &&
                        assignment.RestrictionReasonCode.Id == responseReasonCodeAssignment.RestrictionReasonCode.Id &&
                        assignment.FunctionalLocation.Id == responseReasonCodeAssignment.FunctionalLocation.Id);

                if (hasDuplicateReasonCode)
                    return true;
            }

            return false;
        }
    }
}
