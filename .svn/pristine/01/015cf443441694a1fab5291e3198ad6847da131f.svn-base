using System;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class FormGN1Test
    {
        [Test]
        public void ShouldHaveUniqueTradeChecklistNames()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();

            var tradeChecklist = form.TradeChecklists.First();
            var clonedChecklist = new TradeChecklist(new TradeChecklist(tradeChecklist));
            clonedChecklist.ConvertToClone(form.CreatedBy);
            form.TradeChecklists.Add(clonedChecklist);

            Assert.AreEqual("Refractionation Organizer, Indoor Precipitation Collection Agent", form.TradeChecklistNames);
            Assert.IsTrue(form.TradeChecklists.Count ==3);
        }

        [Test]
        public void ShouldSetTradeChecklistNamesWhenChangingTradeChecklists()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();
            SetAllTradeChecklistsToApproved(form, 1, 1, 1);

            Assert.AreEqual(form.TradeChecklistNames,
                form.TradeChecklists.ConvertAll(input => input.Trade).ToCommaSeparatedString());
        }

        [Test]
        public void ShouldKnowIfAllApprovalsAreIn()
        {
            // Base case - all approvals are in, CSE level is not 3
            {
                FormGN1 form = FormGN1Fixture.CreateForInsert();
                form.CSELevel = WorkPermitEdmonton.ConfinedSpaceLevel1;
                form.AllApprovals.ForEach(ap => ap.ApprovedByUser = UserFixture.CreateUserWithGivenId(1));
                SetAllTradeChecklistsToApproved(form, 1, 1, 1);
                Assert.IsTrue(form.AllApprovalsAreIn());
            }

            // Base case - missing a regular approval, and CSE Leve is 3 (it should ignore the missing regular approval)
            {
                FormGN1 form = FormGN1Fixture.CreateForInsert();
                form.CSELevel = WorkPermitEdmonton.ConfinedSpaceLevel1;
                form.AllApprovals.ForEach(ap => ap.ApprovedByUser = UserFixture.CreateUserWithGivenId(1));
                form.AllApprovals[0].ApprovedByUser = null;
                SetAllTradeChecklistsToApproved(form, 1, 1, 1);
                Assert.IsFalse(form.AllApprovalsAreIn());

                form.CSELevel = WorkPermitEdmonton.ConfinedSpaceLevel3;
                Assert.IsTrue(form.AllApprovalsAreIn());
            }
        }

        [Test]
        public void ShouldKnowIfThereAreApprovalsByOtherUsers()
        {
            // All approvals are by user 1.
            {
                FormGN1 sourceForm = FormGN1Fixture.CreateForInsert();
                GN1Stub form = new GN1Stub(sourceForm);
                form.CSELevel = WorkPermitEdmonton.ConfinedSpaceLevel1;
                form.AllApprovals.ForEach(ap => ap.ApprovedByUser = UserFixture.CreateUserWithGivenId(1));
                SetAllTradeChecklistsToApproved(form, 1, 1, 1);
                Assert.IsFalse(form.HasApprovalsByOtherPeople(UserFixture.CreateUserWithGivenId(1)));
            }

            // All approvals are by user 1, level 3.
            {
                FormGN1 sourceForm = FormGN1Fixture.CreateForInsert();
                GN1Stub form = new GN1Stub(sourceForm);
                form.CSELevel = WorkPermitEdmonton.ConfinedSpaceLevel3;
                form.AllApprovals.ForEach(ap => ap.ApprovedByUser = UserFixture.CreateUserWithGivenId(1));
                SetAllTradeChecklistsToApproved(form, 1, 1, 1);
                Assert.IsFalse(form.HasApprovalsByOtherPeople(UserFixture.CreateUserWithGivenId(1)));
            }

            // At least one regular approval isn't user 1, but no worries because we're level 3 here.
            {
                FormGN1 sourceForm = FormGN1Fixture.CreateForInsert();
                GN1Stub form = new GN1Stub(sourceForm);
                form.CSELevel = WorkPermitEdmonton.ConfinedSpaceLevel3;
                form.AllApprovals.ForEach(ap => ap.ApprovedByUser = UserFixture.CreateUserWithGivenId(1));
                form.AllApprovals[0].ApprovedByUser = UserFixture.CreateUserWithGivenId(2);
                SetAllTradeChecklistsToApproved(form, 1, 1, 1);
                Assert.IsFalse(form.HasApprovalsByOtherPeople(UserFixture.CreateUserWithGivenId(1)));
            }

            // At least one regular approval isn't user 1. Since it's level 2 the other approval should be recognized.
            {
                FormGN1 sourceForm = FormGN1Fixture.CreateForInsert();
                GN1Stub form = new GN1Stub(sourceForm);
                form.CSELevel = WorkPermitEdmonton.ConfinedSpaceLevel2;
                form.AllApprovals.ForEach(ap => ap.ApprovedByUser = UserFixture.CreateUserWithGivenId(1));
                form.AllApprovals[0].ApprovedByUser = UserFixture.CreateUserWithGivenId(2);
                SetAllTradeChecklistsToApproved(form, 1, 1, 1);
                Assert.IsTrue(form.HasApprovalsByOtherPeople(UserFixture.CreateUserWithGivenId(1)));
            }
        }

        private void SetAllTradeChecklistsToApproved(FormGN1 form, long constFieldMaintCoordApproverId,
            long opsCoordApproverId, long areaManagerApproverId)
        {
            DateTime approvalDate = new DateTime(2014, 3, 5, 4, 30, 0);

            form.TradeChecklists.ForEach(delegate(TradeChecklist checklist)
            {
                checklist.SetConstFieldMaintApproval(true,
                    UserFixture.CreateUserWithGivenId(constFieldMaintCoordApproverId), approvalDate);
                checklist.SetOpsCoordApproval(true, UserFixture.CreateUserWithGivenId(constFieldMaintCoordApproverId),
                    approvalDate);
                checklist.SetAreaManagerApproval(true, UserFixture.CreateUserWithGivenId(constFieldMaintCoordApproverId),
                    approvalDate);
            });
        }

        private class GN1Stub : FormGN1
        {
            public GN1Stub(FormGN1 source)
                : base(
                    -1, FormStatus.Draft, FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                    WorkPermitEdmonton.ConfinedSpaceLevel2, Clock.Now, Clock.Now, UserFixture.CreateUserWithGivenId(1),
                    Clock.Now,0)      //ayman generic forms
            {
                PlanningWorksheetApprovals.Clear();
                RescuePlanApprovals.Clear();
                TradeChecklists.Clear();

                PlanningWorksheetApprovals.AddRange(source.PlanningWorksheetApprovals);
                RescuePlanApprovals.AddRange(source.RescuePlanApprovals);
                TradeChecklists.AddRange(source.TradeChecklists);
            }

            public bool HasApprovalsByOtherPeople(User currentUser)
            {
                return ThereAreCurrentlyApprovalsByOtherPeople(currentUser);
            }
        }
    }
}