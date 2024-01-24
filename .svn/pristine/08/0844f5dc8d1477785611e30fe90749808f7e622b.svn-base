using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class FormDTODaoTest : AbstractDaoTest
    {
        private IFormEdmontonDTODao dtoDao;
        private IFormGN59Dao formGN59Dao;
        private IFormGN7Dao formGN7Dao;

        [Ignore]
         [Test]
        public void QueryByDateRangeAndFLOCShouldBringBackApprovalInformation()
        {
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var form = FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", null, null, null, 0));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 3", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver 4", null, null, null, 3));

            formGN7Dao.Insert(form);

            var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs), new DateRange(null, null), FormStatus.All, false);
            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(2, results[0].RemainingApprovals.Count);
            Assert.AreEqual("approver 1", results[0].RemainingApprovals[0]);
            Assert.AreEqual("approver 4", results[0].RemainingApprovals[1]);
        }

        [Ignore]
         [Test]
        public void QueryByDateRangeAndFLOCShouldBringBackApprovalInformationInOrderOfDisplay()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var form = FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "b", null, null, null, 2));
            form.Approvals.Add(new FormApproval(null, null, "z", null, null, null, 1));
            form.Approvals.Add(new FormApproval(null, null, "r", null, null, null, 3));
            formGN7Dao.Insert(form);

            var formGN59 = FormGN59Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            formGN59.Approvals.Clear();
            formGN59.Approvals.Add(new FormApproval(null, null, "c", null, null, null, 2));
            formGN59.Approvals.Add(new FormApproval(null, null, "y", null, null, null, 1));
            formGN59.Approvals.Add(new FormApproval(null, null, "s", null, null, null, 3));
            formGN59Dao.Insert(formGN59);

            var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs), new DateRange(null, null), FormStatus.All, false);
            Assert.AreEqual(2, results.Count);

            var gn7Dto = results.Find(dto => dto.FormType == EdmontonFormType.GN7);
            Assert.AreEqual(3, gn7Dto.RemainingApprovals.Count);
            Assert.AreEqual("z", gn7Dto.RemainingApprovals[0]);
            Assert.AreEqual("b", gn7Dto.RemainingApprovals[1]);
            Assert.AreEqual("r", gn7Dto.RemainingApprovals[2]);

            var gn59Dto = results.Find(dto => dto.FormType == EdmontonFormType.GN59);
            Assert.AreEqual(3, gn59Dto.RemainingApprovals.Count);
            Assert.AreEqual("y", gn59Dto.RemainingApprovals[0]);
            Assert.AreEqual("c", gn59Dto.RemainingApprovals[1]);
            Assert.AreEqual("s", gn59Dto.RemainingApprovals[2]);
        }

        [Ignore]
         [Test]
        public void QueryByDateRangeAndFLOCShouldBringBackFormsOfAllFormTypes()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var formGn7Draft = FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Draft);
            formGN7Dao.Insert(formGn7Draft);

            var formGn59Draft = FormGN59Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Draft);
            formGN59Dao.Insert(formGn59Draft);

            var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs),
                new DateRange(new Date(2012, 9, 1), new Date(2012, 9, 2)),
                FormStatus.All,
                false);
            Assert.AreEqual(2, results.Count);

            Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Draft.Id));
            Assert.IsTrue(results.Exists(dto => dto.Id == formGn59Draft.Id));
        }
        [Ignore]
        [Test]
        public void QueryByDateRangeAndFLOCShouldBringBackFormsOfAllStatusTypes()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var formGn7Draft = FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Draft);
            formGN7Dao.Insert(formGn7Draft);

            var formGn59Draft = FormGN59Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Draft);
            formGN59Dao.Insert(formGn59Draft);

            var formGn7Approved = FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Approved);
            formGN7Dao.Insert(formGn7Approved);

            var formGn59Approved = FormGN59Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Approved);
            formGN59Dao.Insert(formGn59Approved);

            var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs),
                new DateRange(new Date(2012, 9, 1), new Date(2012, 9, 2)),
                FormStatus.All,
                false);
            Assert.AreEqual(4, results.Count);

            Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Draft.Id));
            Assert.IsTrue(results.Exists(dto => dto.Id == formGn59Draft.Id));
            Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Approved.Id));
            Assert.IsTrue(results.Exists(dto => dto.Id == formGn59Approved.Id));
        }
        [Ignore]
         [Test]
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackFormsThatFallUnderOrAboveOrEqualToTheSpecifiedFLOC()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            var floc3 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var floc4 = FunctionalLocationFixture.GetReal("ED1-A001");

            var form1 =
                formGN7Dao.Insert(FormGN7Fixture.CreateForInsert(new List<FunctionalLocation> {floc2},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form2 =
                formGN7Dao.Insert(FormGN7Fixture.CreateForInsert(new List<FunctionalLocation> {floc3},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form3 =
                formGN59Dao.Insert(FormGN59Fixture.CreateForInsert(new List<FunctionalLocation> {floc1, floc3},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form4 =
                formGN59Dao.Insert(FormGN59Fixture.CreateForInsert(new List<FunctionalLocation> {floc4},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));

            {
                var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(floc1), new DateRange(null, null), FormStatus.All, false);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(floc2), new DateRange(null, null), FormStatus.All, false);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(floc3), new DateRange(null, null), FormStatus.All, false);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(new List<FunctionalLocation> {floc1, floc3}),
                    new DateRange(null, null),
                    FormStatus.All,
                    false);
                Assert.AreEqual(4, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }
        }
        [Ignore]
         [Test]
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackFormsThatFallWithinDateRangeSpecified()
        {
            var flocs = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal_ED1_A001_U007()};

            var form1 =
                formGN7Dao.Insert(FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 3, 10, 0, 0), new DateTime(2012, 10, 6, 13, 0, 0), FormStatus.Draft));
            var form2 =
                formGN7Dao.Insert(FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 5, 10, 0, 0), new DateTime(2012, 10, 16, 13, 0, 0), FormStatus.Draft));

            AssertQueryByDateRange(true, null, null, form1);
            AssertQueryByDateRange(true, null, null, form2);

            AssertQueryByDateRange(false, new Date(2012, 10, 1), new Date(2012, 10, 2), form1);
            AssertQueryByDateRange(false, new Date(2012, 10, 1), new Date(2012, 10, 2), form2);

            AssertQueryByDateRange(true, new Date(2012, 10, 1), new Date(2012, 10, 4), form1);
            AssertQueryByDateRange(false, new Date(2012, 10, 1), new Date(2012, 10, 4), form2);

            AssertQueryByDateRange(true, new Date(2012, 10, 5), new Date(2012, 10, 5), form1);
            AssertQueryByDateRange(true, new Date(2012, 10, 5), new Date(2012, 10, 5), form2);

            AssertQueryByDateRange(false, new Date(2012, 10, 7), new Date(2012, 10, 9), form1);
            AssertQueryByDateRange(true, new Date(2012, 10, 7), new Date(2012, 10, 9), form2);

            AssertQueryByDateRange(false, new Date(2012, 10, 12), new Date(2012, 10, 14), form1);
            AssertQueryByDateRange(true, new Date(2012, 10, 12), new Date(2012, 10, 14), form2);
        }
        [Ignore]
         [Test]
        public void QueryByDateRangeAndFLOCShouldPopulateTheFormTypeCorrectly()
        {
            var floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            formGN7Dao.Insert(FormGN7Fixture.CreateForInsert(new List<FunctionalLocation> {floc},
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Draft));

            formGN59Dao.Insert(FormGN59Fixture.CreateForInsert(new List<FunctionalLocation> {floc},
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Draft));

            var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(floc), new DateRange(null, null), FormStatus.All, false);
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Exists(dto => dto.FormType == EdmontonFormType.GN7));
            Assert.IsTrue(results.Exists(dto => dto.FormType == EdmontonFormType.GN59));
        }
        
        [Ignore] [Test]
        public void QueryByDateRangeShouldStillBringBackFormsThatAreDraftAndOutsideOfTheRange()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var formGn7Draft = FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Draft);
            formGN7Dao.Insert(formGn7Draft);

            var formGn59Draft = FormGN59Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Draft);
            formGN59Dao.Insert(formGn59Draft);

            var formGn7Approved = FormGN7Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 2), new DateTime(2012, 9, 14), FormStatus.Approved);
            formGN7Dao.Insert(formGn7Approved);

            var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs),
                new DateRange(new Date(2012, 9, 3), new Date(2012, 9, 11)),
                FormStatus.All,
                true);
            Assert.AreEqual(3, results.Count);

            Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Draft.Id));
            Assert.IsTrue(results.Exists(dto => dto.Id == formGn59Draft.Id));
            Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Approved.Id));
        }
       
        [Ignore] [Test]
        public void QueryByManyThingsShouldBringBackThingsWithWhateverStatusesIChoose()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var validFromDateTime = new DateTime(2012, 9, 1);
            var validToDateTime = new DateTime(2012, 9, 2);

            var formGn7Draft = FormGN7Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Draft);
            formGN7Dao.Insert(formGn7Draft);

            var formGn59Draft = FormGN59Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Draft);
            formGN59Dao.Insert(formGn59Draft);

            var formGn7Approved = FormGN7Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Approved);
            formGN7Dao.Insert(formGn7Approved);

            var formGn59Approved = FormGN59Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Approved);
            formGN59Dao.Insert(formGn59Approved);

            var formGn7Closed = FormGN7Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Closed);
            formGN7Dao.Insert(formGn7Closed);

            var formGn59Closed = FormGN59Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Closed);
            formGN59Dao.Insert(formGn59Closed);

            var dateRange = new DateRange(new Date(2012, 9, 1), new Date(2012, 9, 2));

            {
                var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs),
                    dateRange,
                    new List<FormStatus> {FormStatus.Draft, FormStatus.Approved},
                    false);
                Assert.AreEqual(4, results.Count);

                Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Draft.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == formGn59Draft.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Approved.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == formGn59Approved.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs),
                    dateRange,
                    new List<FormStatus> {FormStatus.Draft, FormStatus.Closed},
                    false);
                Assert.AreEqual(4, results.Count);

                Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Draft.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == formGn59Draft.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == formGn7Closed.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == formGn59Closed.Id));
            }
        }

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IFormEdmontonDTODao>();
            formGN7Dao = DaoRegistry.GetDao<IFormGN7Dao>();
            formGN59Dao = DaoRegistry.GetDao<IFormGN59Dao>();
        }

        protected override void Cleanup()
        {
        }

        private void AssertQueryByDateRange(bool exists, Date from, Date to, FormGN7 form)
        {
            var functionalLocations = form.FunctionalLocations;
            var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(functionalLocations), new DateRange(@from, to), FormStatus.All, false);
            Assert.AreEqual(exists, results.Exists(obj => obj.Id == form.Id));
        }

        private List<FormEdmontonDTO> QueryByFunctionalLocationsAndDateRangeAndStatuses(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraft)
        {
            var dtos = new List<FormEdmontonDTO>();

            dtos.AddRange(dtoDao.QueryFormGN7(flocSet, dateRange, formStatuses, includeAllDraft));
            dtos.AddRange(dtoDao.QueryFormGN59(flocSet, dateRange, formStatuses, includeAllDraft));

            return dtos;
        }
    }
}