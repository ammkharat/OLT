using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class DeviationAlertResponseReasonCodeAssignment : DomainObject
    {
        /// <summary>
        ///     Only to be used by the Dao. When creating new Assignments, everything needed is in the constructor below.
        /// </summary>
        /// <param name="locationItem"></param>
        /// <param name="functionalLocation"></param>
        /// <param name="restrictionReasonCode"></param>
        /// <param name="plantState"></param>
        /// <param name="assignedAmount"></param>
        /// <param name="comments"></param>
        /// <param name="lastModifiedBy"></param>
        /// <param name="lastModifiedDateTime"></param>
        /// <param name="createdDateTime"></param>
        public DeviationAlertResponseReasonCodeAssignment(RestrictionLocationItem locationItem,
            FunctionalLocation functionalLocation, RestrictionReasonCode restrictionReasonCode,
            string plantState, int assignedAmount, string comments, User lastModifiedBy, DateTime lastModifiedDateTime,
            DateTime createdDateTime)
        {
            FunctionalLocation = functionalLocation;
            RestrictionReasonCode = restrictionReasonCode;
            RestrictionLocationItem = locationItem;
            PlantState = plantState;
            AssignedAmount = assignedAmount;
            Comments = comments;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
            CreatedDateTime = createdDateTime;
        }

        /// <summary>
        ///     For use in Release 4.13 and newer as all assignments are created with a location item and a selected restriction
        ///     reason code.
        /// </summary>
        /// <param name="locationItem"></param>
        /// <param name="restrictionReasonCode"></param>
        /// <param name="plantState"></param>
        /// <param name="assignedAmount"></param>
        /// <param name="comments"></param>
        /// <param name="lastModifiedBy"></param>
        /// <param name="lastModifiedDateTime"></param>
        /// <param name="createdDateTime"></param>
        public DeviationAlertResponseReasonCodeAssignment(RestrictionLocationItem locationItem,
            RestrictionReasonCode restrictionReasonCode,
            string plantState, int assignedAmount, string comments, User lastModifiedBy, DateTime lastModifiedDateTime,
            DateTime createdDateTime)
        {
            FunctionalLocation = locationItem.FunctionalLocation;
            RestrictionReasonCode = restrictionReasonCode;
            RestrictionLocationItem = locationItem;
            PlantState = plantState;
            AssignedAmount = assignedAmount;
            Comments = comments;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
            CreatedDateTime = createdDateTime;
        }

        public RestrictionLocationItem RestrictionLocationItem { get; private set; }

        public FunctionalLocation FunctionalLocation { get; private set; }

        public RestrictionReasonCode RestrictionReasonCode { get; private set; }

        public string PlantState { get; private set; }

        public int AssignedAmount { get; private set; }

        public string Comments { get; private set; }

        public string ReasonCodeFunctionalLocationName
        {
            get { return FunctionalLocation.FullHierarchyWithDescription; }
        }

        public string ReasonCodeName
        {
            get { return RestrictionReasonCode.Name; }
        }

        public User LastModifiedBy { get; private set; }

        public DateTime LastModifiedDateTime { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public static List<DeviationAlertResponseReasonCodeAssignment> CopyAssignmentsAndAllocateAmountsInProportion(
            IEnumerable<DeviationAlertResponseReasonCodeAssignment> existingAssignments,
            int totalAmountToBeAssigned,
            DeviationAlert alertToCopy,
            User user,
            DateTime createDateTime)
        {
            var results = new List<DeviationAlertResponseReasonCodeAssignment>();
            results.AddRange(existingAssignments);

            var amountRemainingToBeAssigned = totalAmountToBeAssigned - GetTotalAssignedInList(results);

            var totalCopyAmount = 0;
            foreach (var toCopy in alertToCopy.DeviationAlertResponse.ReasonCodeAssignments)
            {
                totalCopyAmount += Math.Abs(toCopy.AssignedAmount);
            }

            var copiedAssignments = new List<DeviationAlertResponseReasonCodeAssignment>();
            foreach (var toCopy in alertToCopy.DeviationAlertResponse.ReasonCodeAssignments)
            {
                var assignedAmount = 0;
                if (totalCopyAmount > 0)
                {
                    var ratio = Math.Abs(toCopy.AssignedAmount)/(decimal) totalCopyAmount;
                    assignedAmount = Convert.ToInt32(Math.Round(amountRemainingToBeAssigned*ratio, 0));
                }

                copiedAssignments.Add(new DeviationAlertResponseReasonCodeAssignment(toCopy.RestrictionLocationItem,
                    toCopy.RestrictionReasonCode,
                    toCopy.PlantState, assignedAmount,
                    toCopy.Comments, user, createDateTime, createDateTime));
            }

            results.AddRange(copiedAssignments);

            var roundingDifference = totalAmountToBeAssigned - GetTotalAssignedInList(results);
            if (totalCopyAmount > 0 && roundingDifference != 0 && results.Count > 0)
            {
                results[results.Count - 1].AssignedAmount = results[results.Count - 1].AssignedAmount +
                                                            roundingDifference;
            }

            return results;
        }

        public static int GetTotalAssignedInList(List<DeviationAlertResponseReasonCodeAssignment> list)
        {
            var totalAssigned = 0;

            foreach (var assignment in list)
            {
                if (assignment != null)
                {
                    totalAssigned += assignment.AssignedAmount;
                }
                else
                {
                    list.Remove(assignment);
                }
            }
            return totalAssigned;
        }
    }
}