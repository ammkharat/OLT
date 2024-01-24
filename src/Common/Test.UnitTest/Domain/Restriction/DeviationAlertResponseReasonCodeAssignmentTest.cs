using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [TestFixture]
    public class DeviationAlertResponseReasonCodeAssignmentTest
    {
        private static void AssertCopyAssignmentsAndAllocateAmountsInProportion(
            int totalAmountToBeAssigned,
            int assignedAmount1, int assignedAmount2, int assignedAmount3,
            int expectedAssignedAmount1, int expectedAssignedAmount2, int expectedAssignedAmount3)
        {
            AssertCopyAssignmentsAndAllocateAmountsInProportion(
                new List<DeviationAlertResponseReasonCodeAssignment>(),
                totalAmountToBeAssigned,
                assignedAmount1, assignedAmount2, assignedAmount3,
                expectedAssignedAmount1, expectedAssignedAmount2, expectedAssignedAmount3);
        }

        private static void AssertCopyAssignmentsAndAllocateAmountsInProportion(
            IEnumerable<DeviationAlertResponseReasonCodeAssignment> existingAssignments,
            int totalAmountToBeAssigned,
            int assignedAmount1, int assignedAmount2, int assignedAmount3,
            params int[] expectedAssignedAmounts)
        {
            DeviationAlert alertToCopy = DeviationAlertFixture.Create();
            alertToCopy.DeviationAlertResponse = new DeviationAlertResponse("Test comments", null, new DateTime(), new DateTime());

            RestrictionReasonCode reasonCode1 = new RestrictionReasonCode("code1", null, new DateTime(),0);
            RestrictionReasonCode reasonCode2 = new RestrictionReasonCode("code2", null, new DateTime(),0);
            RestrictionReasonCode reasonCode3 = new RestrictionReasonCode("code3", null, new DateTime(),0);
            RestrictionLocationItem item1 = RestrictionLocationItemFixture.CreateWithReasonCodes(FunctionalLocationFixture.CreateNew("floc1"), reasonCode1);
            RestrictionLocationItem item2 = RestrictionLocationItemFixture.CreateWithReasonCodes(FunctionalLocationFixture.CreateNew("floc2"), reasonCode2);
            RestrictionLocationItem item3 = RestrictionLocationItemFixture.CreateWithReasonCodes(FunctionalLocationFixture.CreateNew("floc3"), reasonCode3);

            alertToCopy.DeviationAlertResponse.ReasonCodeAssignments.Add(new DeviationAlertResponseReasonCodeAssignment(item1, reasonCode1, "plant state 1", assignedAmount1, "comments1", null, new DateTime(), new DateTime()));
            alertToCopy.DeviationAlertResponse.ReasonCodeAssignments.Add(new DeviationAlertResponseReasonCodeAssignment(item2, reasonCode2, "plant state 2", assignedAmount2, "comments2", null, new DateTime(), new DateTime()));

            alertToCopy.DeviationAlertResponse.ReasonCodeAssignments.Add(new DeviationAlertResponseReasonCodeAssignment(item3, reasonCode3, "plant state 3", assignedAmount3, "comments3", null, new DateTime(), new DateTime()));

            List<DeviationAlertResponseReasonCodeAssignment> results =
                DeviationAlertResponseReasonCodeAssignment.CopyAssignmentsAndAllocateAmountsInProportion(
                    existingAssignments,
                    totalAmountToBeAssigned,
                    alertToCopy,
                    null, new DateTime(2001, 2, 3));

            Assert.AreEqual(expectedAssignedAmounts.Length, results.Count);
            for (int i = 0; i < expectedAssignedAmounts.Length; i++)
            {
                int expectedAssignedAmount = expectedAssignedAmounts[i];
                Assert.AreEqual(expectedAssignedAmount, results[i].AssignedAmount);
            }
            {
                int i = results.Count - 3;
                Assert.AreEqual("floc1", results[i].FunctionalLocation.FullHierarchy);
                Assert.AreEqual("code1", results[i].RestrictionReasonCode.Name);
                Assert.AreEqual("comments1", results[i].Comments);
            }
            {
                int i = results.Count - 2;
                Assert.AreEqual("floc2", results[i].FunctionalLocation.FullHierarchy);
                Assert.AreEqual("code2", results[i].RestrictionReasonCode.Name);
                Assert.AreEqual("comments2", results[i].Comments);
            }
            {
                int i = results.Count - 1;
                Assert.AreEqual("floc3", results[i].FunctionalLocation.FullHierarchy);
                Assert.AreEqual("code3", results[i].RestrictionReasonCode.Name);
                Assert.AreEqual("comments3", results[i].Comments);
            }
        }

        [Test]
        public void ShouldCopyAssignmentsAndAllocateAmountsInProportion()
        {
            AssertCopyAssignmentsAndAllocateAmountsInProportion(
                10,
                30, 10, 60,
                3, 1, 6);
            AssertCopyAssignmentsAndAllocateAmountsInProportion(
                -10,
                30, 10, 60,
                -3, -1, -6);
            AssertCopyAssignmentsAndAllocateAmountsInProportion(
                10,
                -30, -10, -60,
                3, 1, 6);
        }

        [Test]
        public void ShouldAllocateRoundingDifferencesWhenCopyingAssignments()
        {
            AssertCopyAssignmentsAndAllocateAmountsInProportion(
                1,
                30, 30, 40,
                0, 0, 1);
            AssertCopyAssignmentsAndAllocateAmountsInProportion(
                -1,
                30, 30, 40,
                0, 0, -1);
        }

        [Test]
        public void ShouldAllocateZeroAmountsWhenOriginalHasZeroAsAmount()
        {
            AssertCopyAssignmentsAndAllocateAmountsInProportion(
                10,
                0, 0, 0,
                0, 0, 0);
            AssertCopyAssignmentsAndAllocateAmountsInProportion(
                0,
                1, 2, 3,
                0, 0, 0);
        }

        [Test]
        public void ShouldTakeIntoAccountExistingAssignmentsWhenCalculatingAmountToBeAllocated()
        {
            {
                List<DeviationAlertResponseReasonCodeAssignment> existingAssignments = new List<DeviationAlertResponseReasonCodeAssignment>();
                existingAssignments.Add(new DeviationAlertResponseReasonCodeAssignment(null, null, null, null, 4000, null, null, new DateTime(), new DateTime()));

                AssertCopyAssignmentsAndAllocateAmountsInProportion(
                    existingAssignments,
                    4010,
                    30, 10, 60,
                    4000, 3, 1, 6);
            }
            {
                List<DeviationAlertResponseReasonCodeAssignment> existingAssignments = new List<DeviationAlertResponseReasonCodeAssignment>();
                existingAssignments.Add(new DeviationAlertResponseReasonCodeAssignment(null, null, null, null, -4000, null, null, new DateTime(), new DateTime()));

                AssertCopyAssignmentsAndAllocateAmountsInProportion(
                    existingAssignments,
                    -4010,
                    30, 10, 60,
                    -4000, -3, -1, -6);
            }
        }
    }
}
