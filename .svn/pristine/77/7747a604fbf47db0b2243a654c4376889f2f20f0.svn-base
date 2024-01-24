using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class FormOilsandsTrainingTest
    {
        [Test]
        public void ShouldConvertToClone()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            floc.Id = 22;

            var anotherFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            anotherFloc.Id = 55;

            var flocs = new List<FunctionalLocation> {floc, anotherFloc};

            var createdBy = UserFixture.CreateUserWithGivenId(1);
            var someOtherUser = UserFixture.CreateUserWithGivenId(2);

            var trainingBlock = new TrainingBlock(1, "heyo", "code",0, new List<FunctionalLocation> {floc});     //ayman training block

            var form = FormOilsandsTrainingFixture.CreateForInsert(flocs, FormStatus.Draft, trainingBlock, createdBy);

            var now = Clock.Now;

            form.ConvertToClone(someOtherUser, now);

            Assert.IsNull(form.Id);
            Assert.IsNull(form.ApprovedDateTime);

            Assert.AreEqual(now, form.CreatedDateTime);
            Assert.AreEqual(2, form.CreatedBy.IdValue);

            Assert.AreEqual(now, form.LastModifiedDateTime);
            Assert.AreEqual(2, form.LastModifiedBy.IdValue);

            Assert.AreEqual(FormStatus.Draft, form.FormStatus);
        }

        [Test]
        public void ShouldKnowWhenReapprovalIsNeeded()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            floc.Id = 22;

            var anotherFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            anotherFloc.Id = 55;

            var someUser = UserFixture.CreateUserWithGivenId(1);
            var someOtherUser = UserFixture.CreateUserWithGivenId(2);

            var trainingBlock = new TrainingBlock(1, "heyo", "code",0, new List<FunctionalLocation> {floc});   //ayman training block

            var form = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Approved, trainingBlock);
            form.ShiftPattern = ShiftPatternFixture.CreateEdmontonNightShift();
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", someUser, new DateTime(2012, 1, 3, 13, 0, 0), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));

            // change stuff but the current user is the one who approved it all in the first place
            {
                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    form.TrainingItems,
                    new List<FunctionalLocation> {anotherFloc},
                    someUser);
                Assert.IsFalse(willNeedReapproval);
            }

            // change floc
            {
                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    form.TrainingItems,
                    new List<FunctionalLocation> {anotherFloc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change date of form
            {
                var newDate = new Date(form.TrainingDate.Year, form.TrainingDate.Month, form.TrainingDate.Day + 1);

                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    newDate,
                    form.ShiftPattern,
                    form.TrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change general comments
            {
                const string newGeneralComments = "blazinga whoa yeah";

                var willNeedReapproval = form.WillNeedReapproval(newGeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    form.TrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change comment of training item
            {
                var newTrainingItems = new List<FormOilsandsTrainingItem>();
                form.TrainingItems.ForEach(item => newTrainingItems.Add(item.DeepClone()));
                newTrainingItems[0].Comments = "runlolarun";

                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    newTrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change shift
            {
                var newShift = ShiftPatternFixture.CreateEdmontonDayShift();

                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    newShift,
                    form.TrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change training block of training item
            {
                var newTrainingItems = new List<FormOilsandsTrainingItem>();
                form.TrainingItems.ForEach(item => newTrainingItems.Add(item.DeepClone()));
                newTrainingItems[0].TrainingBlock = new TrainingBlock(23, "blah", "whatever",0, null);                //ayman training block

                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    newTrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change block completed bit of training item
            {
                var newTrainingItems = new List<FormOilsandsTrainingItem>();
                form.TrainingItems.ForEach(item => newTrainingItems.Add(item.DeepClone()));
                newTrainingItems[0].BlockCompleted = !form.TrainingItems[0].BlockCompleted;

                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    newTrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // change hours of training item
            {
                var newTrainingItems = new List<FormOilsandsTrainingItem>();
                form.TrainingItems.ForEach(item => newTrainingItems.Add(item.DeepClone()));
                newTrainingItems[0].Hours = 23.45m;

                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    newTrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // add new training item
            {
                var newTrainingItems = new List<FormOilsandsTrainingItem>();
                form.TrainingItems.ForEach(item => newTrainingItems.Add(item.DeepClone()));
                newTrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10));

                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    newTrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // delete training item
            {
                var newTrainingItems = new List<FormOilsandsTrainingItem>();

                var willNeedReapproval = form.WillNeedReapproval(form.GeneralComments,
                    form.TrainingDate,
                    form.ShiftPattern,
                    newTrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsTrue(willNeedReapproval);
            }

            // nothing has changed
            {
                var newTrainingItems = new List<FormOilsandsTrainingItem>();
                form.TrainingItems.ForEach(item => newTrainingItems.Add(item.DeepClone()));

                var newGeneralComments = form.GeneralComments.DeepClone();
                var newTrainingDate = form.TrainingDate.DeepClone();
                var newShift = form.ShiftPattern.DeepClone();

                var willNeedReapproval = form.WillNeedReapproval(newGeneralComments,
                    newTrainingDate,
                    newShift,
                    newTrainingItems,
                    new List<FunctionalLocation> {floc},
                    someOtherUser);
                Assert.IsFalse(willNeedReapproval);
            }
        }
    }
}