using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class PermitAssessmentDTODaoTest : AbstractDaoTest
    {
        private QuestionnaireConfiguration configuration;
        private IPermitAssessmentDTODao permitAssessmentDTODao;
        private IPermitAssessmentDao permitAssessmentDao;
        private IQuestionnaireConfigurationDao questionnaireConfigurationDao;


        [Ignore] [Test]
        public void QueryPermitAssessmentsByFlocShouldFullyPopulateADTO()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 10, 1, 1, 1, 1);
            var insertedPermitAssessment =
                permitAssessmentDao.Insert(PermitAssessmentFixture.CreateForInsert(new List<FunctionalLocation> {floc1},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved, new DateTime(2012, 10, 2),
                    UserFixture.CreateOilSandsUserWithUserPrintPreference(), configuration.IdValue));

            {
                var permitAssessmentDTO = permitAssessmentDTODao.QueryPermitAssessmentDtos(new RootFlocSet(floc1),
                    new DateRange(new Date(2012, 10, 1), new Date(2012, 10, 2))).First();


                Assert.AreEqual(insertedPermitAssessment.CreationUserShiftPatternId, permitAssessmentDTO.CreationUserShiftPatternId);
                Assert.AreEqual(insertedPermitAssessment.JobDescription, permitAssessmentDTO.JobDescription);
                Assert.AreEqual(insertedPermitAssessment.LastModifiedDateTime,
                    permitAssessmentDTO.LastModified);
                Assert.AreEqual(insertedPermitAssessment.OilsandsWorkPermitType,
                    permitAssessmentDTO.WorkPermitType);
                Assert.AreEqual(insertedPermitAssessment.OverallFeedback, permitAssessmentDTO.OverallFeedback);
                Assert.AreEqual(insertedPermitAssessment.PermitNumber, permitAssessmentDTO.PermitNumber);
                Assert.AreEqual(insertedPermitAssessment.ToDateTime, permitAssessmentDTO.ValidTo);
                Assert.AreEqual(insertedPermitAssessment.FromDateTime, permitAssessmentDTO.ValidFrom);
                Assert.AreEqual(insertedPermitAssessment.CreatedDateTime, permitAssessmentDTO.CreatedDateTime);
            }
            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void QueryPermitAssessmentsByFlocShouldOnlyBringBackFormsThatAreNotDeleted()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 10, 1, 1, 1, 1);
            var form1 =
                permitAssessmentDao.Insert(PermitAssessmentFixture.CreateForInsert(new List<FunctionalLocation> {floc1},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved, new DateTime(2012, 10, 2),
                    UserFixture.CreateOilSandsUserWithUserPrintPreference(), configuration.IdValue));
            permitAssessmentDao.Insert(PermitAssessmentFixture.CreateForInsert(new List<FunctionalLocation> {floc1},
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Draft, new DateTime(2012, 10, 2), UserFixture.CreateOilSandsUserWithUserPrintPreference(), configuration.IdValue));
            permitAssessmentDao.Insert(PermitAssessmentFixture.CreateForInsert(new List<FunctionalLocation> {floc1},
                new DateTime(2012, 10, 4),
                new DateTime(2012, 10, 5),
                FormStatus.Closed, new DateTime(2012, 10, 4), UserFixture.CreateOilSandsUserWithUserPrintPreference(), configuration.IdValue));
            {
                var results = permitAssessmentDTODao.QueryPermitAssessmentDtos(new RootFlocSet(floc1),
                    new DateRange(new Date(2012, 10, 1), new Date(2012, 10, 2)));
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
            }

            Clock.UnFreeze();
        }

        protected override void TestInitialize()
        {
            permitAssessmentDTODao = DaoRegistry.GetDao<IPermitAssessmentDTODao>();
            permitAssessmentDao = DaoRegistry.GetDao<IPermitAssessmentDao>();
            questionnaireConfigurationDao = DaoRegistry.GetDao<IQuestionnaireConfigurationDao>();

            var type = QuestionnaireConfigurationType.SafeWorkPermit.GetName();
            configuration = QuestionnaireConfigurationFixture.Create(Site.OILSAND_ID, type, "Configuration 2");
            questionnaireConfigurationDao.Insert(configuration);
        }

        protected override void Cleanup()
        {
        }
    }
}