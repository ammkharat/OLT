using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class FormOilsandsTrainingDaoTest : AbstractDaoTest
    {
        private IFormOilsandsTrainingDao dao;
        private IFormOilsandsTrainingDTODao dtoDao;
        private TrainingBlock trainingBlock;
        private ITrainingBlockDao trainingBlockDao;

        [Ignore] [Test]
        public void ShouldFindFormsByDateRangeAndUserIdsAndWorkAssignmentIds_VaryUser()
        {
            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };
            var createUser1 = UserFixture.CreateUserWithGivenId(1);
            var createUser2 = UserFixture.CreateUserWithGivenId(2);
            var createUser3 = UserFixture.CreateUserWithGivenId(3);

            var form1 = FormOilsandsTrainingFixture.CreateForInsert(functionalLocations, FormStatus.Draft, trainingBlock, createUser1);
            dao.Insert(form1);

            var form2 = FormOilsandsTrainingFixture.CreateForInsert(functionalLocations, FormStatus.Draft, trainingBlock, createUser2);
            dao.Insert(form2);

            var form3 = FormOilsandsTrainingFixture.CreateForInsert(functionalLocations, FormStatus.Draft, trainingBlock, createUser3);
            dao.Insert(form3);

            var range = new DateRange(form1.TrainingDate.AddDays(-1), form1.TrainingDate.AddDays(1));
            var result = dao.QueryByDateAndUsersAndWorkAssignments(range,
                new List<long> {form1.CreatedBy.IdValue, form2.CreatedBy.IdValue},
                new List<long> {form1.WorkAssignment.IdValue});

            Assert.IsNotEmpty(result);
            Assert.IsTrue(result.Exists(v => v.IdValue == form1.IdValue));
            Assert.IsTrue(result.Exists(v => v.IdValue == form2.IdValue));
            Assert.IsFalse(result.Exists(v => v.IdValue == form3.IdValue));
        }

        [Ignore] [Test]
        public void ShouldFindFormsWithDuplicateTrainingDateAndShiftCombination()
        {
            var user = UserFixture.CreateUserWithGivenId(1);
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var edmontonDayShift = ShiftPatternFixture.CreateEdmontonDayShift();
            var workAssignment = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            var trainingBlock2 = new TrainingBlock(null, "some tb", "somecode",0, new List<FunctionalLocation> {floc});    //ayman training block
            trainingBlockDao.Insert(trainingBlock2);

            var form1 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
            form1.TrainingDate = new Date(2013, 3, 22);
            form1.ShiftPattern = edmontonDayShift;
            form1.WorkAssignment = workAssignment;
            form1.TrainingItems.Clear();
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
            dao.Insert(form1);

            var form2 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
            form2.TrainingDate = new Date(2013, 3, 23);
            form2.ShiftPattern = edmontonDayShift;
            form2.WorkAssignment = workAssignment;
            form2.TrainingItems.Clear();
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
            dao.Insert(form2);

            {
                var form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
                form3.TrainingDate = new Date(2013, 3, 22);
                form3.ShiftPattern = edmontonDayShift;
                form3.WorkAssignment = workAssignment;
                form3.TrainingItems.Clear();
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
                // no insertion on purpose

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form3.Id,
                    form3.TrainingDate,
                    form3.ShiftPattern,
                    form3.WorkAssignment,
                    user);
                Assert.AreEqual(form1.IdValue, duplicateFormNumber);
            }

            // change date to not match
            {
                var form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
                form3.TrainingDate = new Date(2013, 3, 21);
                form3.ShiftPattern = edmontonDayShift;
                form3.WorkAssignment = workAssignment;
                form3.TrainingItems.Clear();
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
                // no insertion on purpose

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form3.Id,
                    form3.TrainingDate,
                    form3.ShiftPattern,
                    form3.WorkAssignment,
                    user);
                Assert.IsNull(duplicateFormNumber);
            }

            // change shift to not match
            {
                var form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
                form3.TrainingDate = new Date(2013, 3, 22);
                form3.ShiftPattern = ShiftPatternFixture.CreateEdmontonNightShift();
                form3.WorkAssignment = workAssignment;
                form3.TrainingItems.Clear();
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
                // no insertion on purpose

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form3.Id,
                    form3.TrainingDate,
                    form3.ShiftPattern,
                    form3.WorkAssignment,
                    user);
                Assert.IsNull(duplicateFormNumber);
            }

            // change assignment to not match
            {
                var form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
                form3.TrainingDate = new Date(2013, 3, 22);
                form3.ShiftPattern = edmontonDayShift;
                form3.WorkAssignment = WorkAssignmentFixture.GetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData();
                form3.TrainingItems.Clear();
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
                // no insertion on purpose

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form3.Id,
                    form3.TrainingDate,
                    form3.ShiftPattern,
                    form3.WorkAssignment,
                    user);
                Assert.IsNull(duplicateFormNumber);
            }

            {
                var form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
                form3.TrainingDate = new Date(2013, 3, 23);
                form3.ShiftPattern = edmontonDayShift;
                form3.WorkAssignment = workAssignment;
                form3.TrainingItems.Clear();
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
                // no insertion on purpose

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form3.Id,
                    form3.TrainingDate,
                    form3.ShiftPattern,
                    form3.WorkAssignment,
                    user);
                Assert.AreEqual(form2.IdValue, duplicateFormNumber);
            }

            // make sure the duplicate checking doesn't include the form being checked
            {
                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form2.Id,
                    form2.TrainingDate,
                    form2.ShiftPattern,
                    form2.WorkAssignment,
                    user);
                Assert.IsNull(duplicateFormNumber);
            }
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };

            var form = FormOilsandsTrainingFixture.CreateForInsert(functionalLocations, FormStatus.Draft, trainingBlock);

            dao.Insert(form);

            Assert.That(form.Id, Is.GreaterThan(0));

            RequeryAndAssertFieldsAreEqual(form);
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };

            var form = FormOilsandsTrainingFixture.CreateForInsert(functionalLocations, FormStatus.Draft, trainingBlock);
            dao.Insert(form);

            {
                var things = dtoDao.QueryByFunctionalLocationsAndDateRange(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(things.Exists(t => t.IdValue == form.IdValue));
            }

            dao.Remove(form);

            {
                var things = dtoDao.QueryByFunctionalLocationsAndDateRange(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsFalse(things.Exists(t => t.IdValue == form.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldSortApprovalsByDisplayOrder()
        {
            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };

            var form = FormOilsandsTrainingFixture.CreateForInsert(functionalLocations, FormStatus.Draft, trainingBlock);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "b", null, null, null, 2));
            form.Approvals.Add(new FormApproval(null, null, "z", null, null, null, 1));
            form.Approvals.Add(new FormApproval(null, null, "r", null, null, null, 3));

            dao.Insert(form);

            var requeried = dao.QueryById(form.IdValue);
            Assert.AreEqual(3, requeried.Approvals.Count);
            Assert.AreEqual("z", requeried.Approvals[0].Approver);
            Assert.AreEqual("b", requeried.Approvals[1].Approver);
            Assert.AreEqual("r", requeried.Approvals[2].Approver);
        }

        [Ignore] [Test]
        public void ShouldUpdateForm()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            var form = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc1, floc2}, FormStatus.Draft, trainingBlock);
            form = dao.Insert(form);

            form.FormStatus = FormStatus.Approved;
            form.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC());
            form.ApprovedDateTime = new DateTime(2016, 1, 2);

            var modifyUser = UserFixture.CreateUserWithGivenId(2);

            foreach (var approval in form.Approvals)
            {
                approval.ApprovedByUser = modifyUser;
                approval.ApprovalDateTime = approval.ApprovalDateTime == null
                    ? new DateTime(2012, 11, 1)
                    : approval.ApprovalDateTime.Value.AddHours(5);
            }

            dao.Update(form);

            RequeryAndAssertFieldsAreEqual(form);
        }

        [Ignore] [Test]
        public void ShouldUpdateTrainingItems()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var trainingBlock2 = new TrainingBlock(null, "some tb", "somecode",0, new List<FunctionalLocation> {floc});   //ayman training block
            trainingBlockDao.Insert(trainingBlock2);

            var form = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock);
            form = dao.Insert(form);

            var trainingItem = form.TrainingItems[0];
            trainingItem.TrainingBlock = trainingBlock2;
            trainingItem.Hours += 10;

            var newTrainingItem = new FormOilsandsTrainingItem(null, form.IdValue, trainingBlock, "some comments","", true, 7.2m);

            form.TrainingItems = new List<FormOilsandsTrainingItem> {trainingItem, newTrainingItem};
            dao.Update(form);
            RequeryAndAssertFieldsAreEqual(form);

            form.TrainingItems = new List<FormOilsandsTrainingItem> {newTrainingItem};
            dao.Update(form);
            RequeryAndAssertFieldsAreEqual(form);
        }

        [Ignore] [Test]
        public void WhenFindingFormsWithDuplicateTrainingBlocksAllowNullWorkAssignment()
        {
            var user = UserFixture.CreateUserWithGivenId(1);
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var trainingDate = new Date(2013, 3, 22);
            var shift = ShiftPatternFixture.CreateEdmontonDayShift();

            var trainingBlock2 = new TrainingBlock(null, "some tb", "somecode",0, new List<FunctionalLocation> {floc});    // ayman training block
            trainingBlockDao.Insert(trainingBlock2);

            var form1 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
            form1.TrainingDate = trainingDate;
            form1.ShiftPattern = shift;
            form1.WorkAssignment = null;
            form1.TrainingItems.Clear();
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
            dao.Insert(form1);

            {
                var form2 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
                form2.TrainingDate = trainingDate;
                form2.ShiftPattern = shift;
                form2.WorkAssignment = null;
                form2.TrainingItems.Clear();
                form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form2.Id,
                    form2.TrainingDate,
                    form2.ShiftPattern,
                    form2.WorkAssignment,
                    user);
                Assert.AreEqual(form1.IdValue, duplicateFormNumber);
            }
        }

        [Ignore] [Test]
        public void WhenFindingFormsWithDuplicateTrainingBlocksDoNotIncludeDeletedItems()
        {
            var user = UserFixture.CreateUserWithGivenId(1);
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var trainingDate = new Date(2013, 3, 22);
            var shift = ShiftPatternFixture.CreateEdmontonDayShift();
            var assignment = WorkAssignmentFixture.GetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            var trainingBlock2 = new TrainingBlock(null, "some tb", "somecode",0, new List<FunctionalLocation> {floc});    // ayman training block
            trainingBlockDao.Insert(trainingBlock2);

            var form1 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);

            form1.TrainingDate = trainingDate;
            form1.ShiftPattern = shift;
            form1.WorkAssignment = assignment;
            form1.TrainingItems.Clear();
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
            dao.Insert(form1);

            // remove the form
            dao.Remove(form1);

            {
                var form2 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user);
                form2.TrainingDate = trainingDate;
                form2.ShiftPattern = shift;
                form2.WorkAssignment = assignment;
                form2.TrainingItems.Clear();
                form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form2.Id,
                    form2.TrainingDate,
                    form2.ShiftPattern,
                    form2.WorkAssignment,
                    user);
                Assert.IsNull(duplicateFormNumber);
            }
        }

        [Ignore] [Test]
        public void WhenFindingFormsWithDuplicateTrainingBlocksTakeUserIntoConsideration()
        {
            var user1 = UserFixture.CreateUserWithGivenId(1);
            var user2 = UserFixture.CreateUserWithGivenId(2);
            var edmontonDayShift = ShiftPatternFixture.CreateEdmontonDayShift();
            var workAssignment = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var trainingBlock2 = new TrainingBlock(null, "some tb", "somecode",0, new List<FunctionalLocation> {floc});     //ayman training block
            trainingBlockDao.Insert(trainingBlock2);

            var form1 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user1);
            form1.TrainingDate = new Date(2013, 3, 22);
            form1.ShiftPattern = edmontonDayShift;
            form1.WorkAssignment = workAssignment;
            form1.TrainingItems.Clear();
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
            dao.Insert(form1);

            var form2 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user2);
            form2.TrainingDate = new Date(2013, 3, 23);
            form2.ShiftPattern = edmontonDayShift;
            form2.WorkAssignment = workAssignment;
            form2.TrainingItems.Clear();
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
            dao.Insert(form2);

            // user1 can duplicate the values on form2 since that was created by a different user
            {
                var form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user1);
                form3.TrainingDate = new Date(2013, 3, 23);
                form3.ShiftPattern = edmontonDayShift;
                form3.WorkAssignment = workAssignment;
                form3.TrainingItems.Clear();
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
                // no insertion on purpose

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form3.Id,
                    form3.TrainingDate,
                    form3.ShiftPattern,
                    form3.WorkAssignment,
                    user1);
                Assert.IsNull(duplicateFormNumber);
            }

            // user2 can duplicate the values on form1 since that was created by a different user
            {
                var form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user2);
                form1.TrainingDate = new Date(2013, 3, 22);
                form1.ShiftPattern = edmontonDayShift;
                form1.WorkAssignment = workAssignment;
                form3.TrainingItems.Clear();
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
                // no insertion on purpose

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form3.Id,
                    form3.TrainingDate,
                    form3.ShiftPattern,
                    form3.WorkAssignment,
                    user2);
                Assert.IsNull(duplicateFormNumber);
            }

            // user2 cannot duplicate the values on form2 because he (OR she!) created it
            {
                var form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc}, FormStatus.Draft, trainingBlock, user2);
                form3.TrainingDate = new Date(2013, 3, 23);
                form3.ShiftPattern = edmontonDayShift;
                form3.WorkAssignment = workAssignment;
                form3.TrainingItems.Clear();
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, null,null, false, 10.3m));
                form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock2, null,null, false, 10.3m));
                // no insertion on purpose

                var duplicateFormNumber = dao.QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(form3.Id,
                    form3.TrainingDate,
                    form3.ShiftPattern,
                    form3.WorkAssignment,
                    user2);
                Assert.IsNotNull(duplicateFormNumber);
            }
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormOilsandsTrainingDao>();
            dtoDao = DaoRegistry.GetDao<IFormOilsandsTrainingDTODao>();
            trainingBlockDao = DaoRegistry.GetDao<ITrainingBlockDao>();

            trainingBlock = trainingBlockDao.QueryById(TrainingBlockFixture.IdOfTrainingBlockInDatabase);
        }

        protected override void Cleanup()
        {
        }

        private void RequeryAndAssertFieldsAreEqual(FormOilsandsTraining form)
        {
            var requeried = dao.QueryById(form.IdValue);

            Assert.IsNotNull(requeried);

            Assert.AreEqual(form.FormStatus, requeried.FormStatus);

            Assert.That(form.ApprovedDateTime, Is.EqualTo(requeried.ApprovedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.That(form.TrainingDate, Is.EqualTo(requeried.TrainingDate));
            Assert.That(form.TotalHours, Is.EqualTo(requeried.TotalHours));
            Assert.That(form.ShiftPattern.IdValue, Is.EqualTo(requeried.ShiftPattern.IdValue));
            Assert.That(form.GeneralComments, Is.EqualTo(requeried.GeneralComments));

            if (form.WorkAssignment == null)
            {
                Assert.IsNull(requeried.WorkAssignment);
            }
            else
            {
                Assert.AreEqual(form.WorkAssignment.IdValue, requeried.WorkAssignment.IdValue);
            }

            Assert.AreEqual(form.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
            Assert.That(form.CreatedDateTime, Is.EqualTo(requeried.CreatedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.That(form.LastModifiedDateTime, Is.EqualTo(requeried.LastModifiedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.FunctionalLocations.Count, requeried.FunctionalLocations.Count);
            foreach (var floc in form.FunctionalLocations)
            {
                Assert.IsTrue(requeried.FunctionalLocations.Contains(floc));
            }

            Assert.AreEqual(form.Approvals.Count, requeried.Approvals.Count);
            foreach (var approval in form.Approvals)
            {
                var requeriedApproval = requeried.Approvals.Find(a => a.Approver == approval.Approver);
                Assert.AreEqual(form.IdValue, requeriedApproval.FormId);

                if (approval.ApprovedByUser == null)
                {
                    Assert.IsNull(requeriedApproval.ApprovedByUser);
                }
                else
                {
                    Assert.AreEqual(approval.ApprovedByUser.IdValue, requeriedApproval.ApprovedByUser.IdValue);
                }

                Assert.That(approval.ApprovalDateTime,
                    Is.EqualTo(requeriedApproval.ApprovalDateTime).Within(TimeSpan.FromSeconds(1)));
            }

            Assert.AreEqual(form.TrainingItems.Count, requeried.TrainingItems.Count);
            foreach (var trainingItem in form.TrainingItems)
            {
                var requeriedTrainingItem = requeried.TrainingItems.Find(item => item.IdValue == trainingItem.IdValue);
                Assert.AreEqual(trainingItem.FormOilsandsTrainingId, requeriedTrainingItem.FormOilsandsTrainingId);
                Assert.AreEqual(trainingItem.Hours, requeriedTrainingItem.Hours);
                Assert.AreEqual(trainingItem.Comments, requeriedTrainingItem.Comments);
                Assert.AreEqual(trainingItem.BlockCompleted, requeriedTrainingItem.BlockCompleted);
                Assert.AreEqual(trainingItem.TrainingBlock.Name, requeriedTrainingItem.TrainingBlock.Name);
            }
        }
    }
}