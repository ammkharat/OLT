using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class FormOilsandsTrainingReportDTODaoTest : AbstractDaoTest
    {
        private IFormOilsandsTrainingReportDTODao formOilsandsTrainingReportDtoDao;
        private IFormOilsandsTrainingDao formOilsandsTrainingDao;
        private ITrainingBlockDao trainingBlockDao;
        private TrainingBlock trainingBlock;

        protected override void TestInitialize()
        {
            formOilsandsTrainingReportDtoDao = DaoRegistry.GetDao<IFormOilsandsTrainingReportDTODao>();
            formOilsandsTrainingDao = DaoRegistry.GetDao<IFormOilsandsTrainingDao>();

            trainingBlockDao = DaoRegistry.GetDao<ITrainingBlockDao>();
            trainingBlock = trainingBlockDao.QueryById(TrainingBlockFixture.IdOfTrainingBlockInDatabase);
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryFormOilsandsTrainingReportDtos_VaryFloc()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateNightShift();
            
            FormOilsandsTraining form = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock, user);
            form.TrainingDate = new Date(2013, 6, 10);
            form.ShiftPattern = shift;
            form.TrainingItems.Clear();
            form.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "hey there","", false, 3.0m));
            formOilsandsTrainingDao.Insert(form);

            {
                List<FormOilsandsTrainingReportDTO> results = formOilsandsTrainingReportDtoDao.QueryFormOilsandsTrainingReportData(new RootFlocSet(floc1), new DateTime(2013, 6, 9), new DateTime(2013, 6, 11), new List<WorkAssignment> { form.WorkAssignment });
                Assert.IsTrue(results.Exists(dto => dto.FormId == form.IdValue));                
            }

            {
                List<FormOilsandsTrainingReportDTO> results = formOilsandsTrainingReportDtoDao.QueryFormOilsandsTrainingReportData(new RootFlocSet(floc2), new DateTime(2013, 6, 9), new DateTime(2013, 6, 11), new List<WorkAssignment> { form.WorkAssignment });
                Assert.IsFalse(results.Exists(dto => dto.FormId == form.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryFormOilsandsTrainingReportDtos_VaryDateRange()
        {
            const string form1Item1Comments = "1-item1";
            const string form1Item2Comments = "1-item2";
            const string form2Item1Comments = "2-item1";
            const string form2Item2Comments = "2-item2";

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();     // 6 to 18
            ShiftPattern nightShift = ShiftPatternFixture.CreateNightShift();  // 18 to 6

            FormOilsandsTraining form1 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock, user);
            form1.TrainingDate = new Date(2013, 6, 10);
            form1.ShiftPattern = dayShift;
            form1.TrainingItems.Clear();
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, form1Item1Comments,"", false, 3.0m));
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, form1Item2Comments,"", false, 3.0m));
            formOilsandsTrainingDao.Insert(form1);

            FormOilsandsTraining form2 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock, user);
            form2.TrainingDate = new Date(2013, 6, 10);
            form2.ShiftPattern = nightShift;
            form2.TrainingItems.Clear();
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, form2Item1Comments,"", false, 3.0m));
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, form2Item2Comments,"", false, 3.0m));
            formOilsandsTrainingDao.Insert(form2);

            {
                List<FormOilsandsTrainingReportDTO> results = formOilsandsTrainingReportDtoDao.QueryFormOilsandsTrainingReportData(new RootFlocSet(floc1), new DateTime(2013, 6, 10, 6, 0, 0), new DateTime(2013, 6, 10, 18, 0, 0), new List<WorkAssignment> { form1.WorkAssignment });
                Assert.IsTrue(results.Exists(dto => dto.Comments == form1Item1Comments));
                Assert.IsTrue(results.Exists(dto => dto.Comments == form1Item2Comments));
                Assert.IsFalse(results.Exists(dto => dto.Comments == form2Item1Comments));
                Assert.IsFalse(results.Exists(dto => dto.Comments == form2Item2Comments));
            }

            {
                List<FormOilsandsTrainingReportDTO> results = formOilsandsTrainingReportDtoDao.QueryFormOilsandsTrainingReportData(new RootFlocSet(floc1), new DateTime(2013, 6, 10, 6, 0, 0), new DateTime(2013, 6, 11, 6, 0, 0), new List<WorkAssignment> { form1.WorkAssignment });
                Assert.IsTrue(results.Exists(dto => dto.Comments == form1Item1Comments));
                Assert.IsTrue(results.Exists(dto => dto.Comments == form1Item2Comments));
                Assert.IsTrue(results.Exists(dto => dto.Comments == form2Item1Comments));
                Assert.IsTrue(results.Exists(dto => dto.Comments == form2Item2Comments));
            }

            {
                List<FormOilsandsTrainingReportDTO> results = formOilsandsTrainingReportDtoDao.QueryFormOilsandsTrainingReportData(new RootFlocSet(floc1), new DateTime(2013, 6, 10, 18, 0, 0), new DateTime(2013, 6, 11, 6, 0, 0), new List<WorkAssignment> { form1.WorkAssignment });
                Assert.IsFalse(results.Exists(dto => dto.Comments == form1Item1Comments));
                Assert.IsFalse(results.Exists(dto => dto.Comments == form1Item2Comments));
                Assert.IsTrue(results.Exists(dto => dto.Comments == form2Item1Comments));
                Assert.IsTrue(results.Exists(dto => dto.Comments == form2Item2Comments));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryFormOilsandsTrainingReportDtos_VaryWorkAssignment()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateNightShift();
            Date trainingDate = new Date(2013, 6, 10);

            FormOilsandsTraining form1 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock, user);
            form1.WorkAssignment = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();
            form1.TrainingDate = trainingDate;
            form1.ShiftPattern = shift;
            form1.TrainingItems.Clear();
            form1.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "hey there","", false, 3.0m));
            formOilsandsTrainingDao.Insert(form1);

            FormOilsandsTraining form2 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock, user);
            form2.WorkAssignment = WorkAssignmentFixture.GetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData();
            form2.TrainingDate = trainingDate;
            form2.ShiftPattern = shift;
            form2.TrainingItems.Clear();
            form2.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "hey there","", false, 3.0m));
            formOilsandsTrainingDao.Insert(form2);

            FormOilsandsTraining form3 = FormOilsandsTrainingFixture.CreateForInsert(new List<FunctionalLocation> { floc1 }, FormStatus.Draft, trainingBlock, user);
            form3.WorkAssignment = null;
            form3.TrainingDate = trainingDate;
            form3.ShiftPattern = shift;
            form3.TrainingItems.Clear();
            form3.TrainingItems.Add(new FormOilsandsTrainingItem(null, null, trainingBlock, "hey there","", false, 3.0m));
            formOilsandsTrainingDao.Insert(form3);

            {
                List<FormOilsandsTrainingReportDTO> results = formOilsandsTrainingReportDtoDao.QueryFormOilsandsTrainingReportData(new RootFlocSet(floc1), new DateTime(2013, 6, 9), new DateTime(2013, 6, 11), new List<WorkAssignment> { form1.WorkAssignment });
                Assert.IsTrue(results.Exists(dto => dto.FormId == form1.IdValue));
                Assert.IsFalse(results.Exists(dto => dto.FormId == form2.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.FormId == form3.IdValue));
            }

            {
                List<FormOilsandsTrainingReportDTO> results = formOilsandsTrainingReportDtoDao.QueryFormOilsandsTrainingReportData(new RootFlocSet(floc1), new DateTime(2013, 6, 9), new DateTime(2013, 6, 11), new List<WorkAssignment> { form2.WorkAssignment });
                Assert.IsFalse(results.Exists(dto => dto.FormId == form1.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.FormId == form2.IdValue));
                Assert.IsTrue(results.Exists(dto => dto.FormId == form3.IdValue));
            }
        }


    }
}
