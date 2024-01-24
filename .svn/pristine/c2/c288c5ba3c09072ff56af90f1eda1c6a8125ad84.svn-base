using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class FormOilsandsPriorityPageDTODaoTest : AbstractDaoTest
    {
        private IFormOilsandsPriorityPageDTODao dtoDao;
        private IFormOilsandsTrainingDao formOilsandsTrainingDao;
        private ITrainingBlockDao trainingBlockDao;
        private TrainingBlock trainingBlock;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IFormOilsandsPriorityPageDTODao>();
            formOilsandsTrainingDao = DaoRegistry.GetDao<IFormOilsandsTrainingDao>();
            trainingBlockDao = DaoRegistry.GetDao<ITrainingBlockDao>();

            trainingBlock = trainingBlockDao.QueryById(TrainingBlockFixture.IdOfTrainingBlockInDatabase);
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void QueryAwaitingApprovalsShouldOnlyBringBackFormsThatFallWithinDateRangeSpecified()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007() };

            FormOilsandsTraining form1 = FormOilsandsTrainingFixture.CreateForInsert(flocs, FormStatus.Draft, trainingBlock);
            form1.TrainingDate = new Date(2012, 10, 4);
            form1.TrainingItems.Clear();
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "comments","supervisor", false, 3.5m));
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "comments","supervisor", false, 3.5m));
            form1.MarkAsUnapproved();

            FormOilsandsTraining form2 = FormOilsandsTrainingFixture.CreateForInsert(flocs, FormStatus.Draft, trainingBlock);
            form2.TrainingDate = new Date(2012, 10, 8);
            form2.TrainingItems.Clear();
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "comments","supervisor", false, 3.5m));
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "comments","supervisor", false, 3.5m));
            form2.MarkAsUnapproved();

            formOilsandsTrainingDao.Insert(form1);
            formOilsandsTrainingDao.Insert(form2);

            AssertQueryByDateRange(true, null, null, form1);
            AssertQueryByDateRange(true, null, null, form2);

            AssertQueryByDateRange(false, new Date(2012, 10, 1), new Date(2012, 10, 2), form1);
            AssertQueryByDateRange(false, new Date(2012, 10, 1), new Date(2012, 10, 2), form2);

            AssertQueryByDateRange(true, new Date(2012, 10, 1), new Date(2012, 10, 4), form1);
            AssertQueryByDateRange(false, new Date(2012, 10, 1), new Date(2012, 10, 4), form2);

            AssertQueryByDateRange(false, new Date(2012, 10, 5), new Date(2012, 10, 5), form1);
            AssertQueryByDateRange(false, new Date(2012, 10, 5), new Date(2012, 10, 5), form2);

            AssertQueryByDateRange(false, new Date(2012, 10, 7), new Date(2012, 10, 9), form1);
            AssertQueryByDateRange(true, new Date(2012, 10, 7), new Date(2012, 10, 9), form2);

            AssertQueryByDateRange(false, new Date(2012, 10, 8), new Date(2012, 10, 8), form1);
            AssertQueryByDateRange(true, new Date(2012, 10, 8), new Date(2012, 10, 8), form2);
        }

        [Ignore] [Test]
        public void QueryAwaitingApprovalsShouldOnlyBringBackFormsThatFallUnderOrAboveOrEqualToTheSpecifiedFLOC()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal("ED1-A001");

            FormOilsandsTraining form1 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc2 }, FormStatus.Draft, trainingBlock);
            FormOilsandsTraining form2 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc3 }, FormStatus.Draft, trainingBlock);
            FormOilsandsTraining form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1, floc3 }, FormStatus.Draft, trainingBlock);
            FormOilsandsTraining form4 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc4 }, FormStatus.Draft, trainingBlock);

            form1.MarkAsUnapproved();
            form2.MarkAsUnapproved();
            form3.MarkAsUnapproved();
            form4.MarkAsUnapproved();

            formOilsandsTrainingDao.Insert(form1);
            formOilsandsTrainingDao.Insert(form2);
            formOilsandsTrainingDao.Insert(form3);
            formOilsandsTrainingDao.Insert(form4);

            {
                List<FormOilsandsPriorityPageDTO> results = dtoDao.QueryAwaitingApprovalByFunctionalLocationsAndDateRange(new RootFlocSet(floc1), new DateRange(null, null));
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                List<FormOilsandsPriorityPageDTO> results = dtoDao.QueryAwaitingApprovalByFunctionalLocationsAndDateRange(new RootFlocSet(floc2), new DateRange(null, null));
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                List<FormOilsandsPriorityPageDTO> results = dtoDao.QueryAwaitingApprovalByFunctionalLocationsAndDateRange(new RootFlocSet(floc3), new DateRange(null, null));
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                List<FormOilsandsPriorityPageDTO> results = dtoDao.QueryAwaitingApprovalByFunctionalLocationsAndDateRange(new RootFlocSet(new List<FunctionalLocation> { floc1, floc3 }), new DateRange(null, null));
                Assert.AreEqual(4, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }
        }

        [Ignore] [Test]
        public void QueryAwaitingApprovalsShouldOnlyBringBackFormsThatNeedApproval()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormOilsandsTraining form1 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock);
            FormOilsandsTraining form2 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock);
            FormOilsandsTraining form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock);
            FormOilsandsTraining form4 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock);

            form1.MarkAsUnapproved();
            form2.MarkAsUnapproved();
            form3.MarkAsApproved(Clock.Now);
            form4.MarkAsApproved(Clock.Now);

            formOilsandsTrainingDao.Insert(form1);
            formOilsandsTrainingDao.Insert(form2);
            formOilsandsTrainingDao.Insert(form3);
            formOilsandsTrainingDao.Insert(form4);

            {
                List<FormOilsandsPriorityPageDTO> results = dtoDao.QueryAwaitingApprovalByFunctionalLocationsAndDateRange(new RootFlocSet(floc1), new DateRange(null, null));
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
            }
        }

        private void AssertQueryByDateRange(bool exists, Date from, Date to, FormOilsandsTraining form)
        {
            List<FunctionalLocation> functionalLocations = form.FunctionalLocations;
            List<FormOilsandsPriorityPageDTO> results = dtoDao.QueryAwaitingApprovalByFunctionalLocationsAndDateRange(new RootFlocSet(functionalLocations), new DateRange(@from, to));
            Assert.AreEqual(exists, results.Exists(obj => obj.Id == form.Id));
        }
    }
}
