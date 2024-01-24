using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class FormOilsandsTrainingHistoryDaoTest : AbstractDaoTest
    {
        private IFormOilsandsTrainingHistoryDao dao;
        private IFormOilsandsTrainingDao formDao;
        private ITrainingBlockDao trainingBlockDao;

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var someUser = UserFixture.CreateUser("uname", "firstname", "lastname");

            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            var trainingBlock = trainingBlockDao.QueryById(TrainingBlockFixture.IdOfTrainingBlockInDatabase);
            var anotherTrainingBlock = new TrainingBlock(null, "tb1", "tb1code",0, new List<FunctionalLocation> {floc1, floc2});   //ayman training
            trainingBlockDao.Insert(anotherTrainingBlock);

            var form = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> {floc2, floc1}, FormStatus.Draft, trainingBlock);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver1", someUser, new DateTime(2012, 10, 5), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver2", null, null, null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver3", someUser, new DateTime(2012, 10, 5), null, 3));
            form.TrainingItems.Clear();
            form.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "comments","supervisor", false, 3.5m));
            form.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, anotherTrainingBlock, "comments2","supervisor2", true, 4.3m));
            form = formDao.Insert(form);

            var history = form.TakeSnapshot();
            dao.Insert(history);

            var histories = dao.GetById(form.IdValue);
            Assert.AreEqual(1, histories.Count);
            var requeried = histories[0];

            {
                Assert.IsNotNull(requeried);

                Assert.AreEqual(form.IdValue, requeried.IdValue);

                Assert.AreEqual("approver1 (uname), approver3 (uname)", requeried.Approvals);
                Assert.AreEqual(form.FormStatus, requeried.FormStatus);
                Assert.AreEqual("ED1-A001-U007, ED1-A001-U008", requeried.FunctionalLocations);
                Assert.AreEqual("Tie shoelaces (comments) / Completed: No / Hours: 3.50, tb1 (comments2) / Completed: Yes / Hours: 4.30", requeried.TrainingItems);
                Assert.That(requeried.TrainingDate, Is.EqualTo(form.TrainingDate));
                Assert.That(requeried.TotalHours, Is.EqualTo(form.TotalHours));
                Assert.That(requeried.ShiftName, Is.EqualTo(form.ShiftPattern.DisplayName));
                Assert.That(requeried.GeneralComments, Is.EqualTo(form.GeneralComments));
                Assert.That(requeried.ApprovedDateTime, Is.EqualTo(form.ApprovedDateTime).Within(TimeSpan.FromSeconds(1)));
            }
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormOilsandsTrainingHistoryDao>();
            formDao = DaoRegistry.GetDao<IFormOilsandsTrainingDao>();
            trainingBlockDao = DaoRegistry.GetDao<ITrainingBlockDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }
    }
}