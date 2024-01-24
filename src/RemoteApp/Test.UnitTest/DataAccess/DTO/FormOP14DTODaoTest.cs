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
    public class FormOP14DTODaoTest : AbstractDaoTest
    {
        private IFormEdmontonOP14DTODao dtoDao;
        private IFormOP14Dao formOP14Dao;

        [Ignore] [Test]
        public void QueryApprovedOP14sByFlocShouldOnlyBringBackFormsThatAreOP14AndAreApprovedDraftOrExpired()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 10, 1, 1, 1, 1);
            var form1 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc1},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));
            formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc1},
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Draft));
            formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc1},
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Closed));

            {
                var results = dtoDao.QueryFormOP14sThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(floc1), Clock.Now);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
            }

            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void QueryApprovedOP14sByFlocShouldOnlyBringBackFormsThatFallUnderOrAboveOrEqualToTheSpecifiedFLOCs()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 10, 1, 1, 1, 1);
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            var floc3 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var floc4 = FunctionalLocationFixture.GetReal("ED1-A001");

            var form1 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc2},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));
            var form2 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc3},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));
            var form3 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc1, floc3},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));
            var form4 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc4},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));

            {
                var results = dtoDao.QueryFormOP14sThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(floc1), Clock.Now);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = dtoDao.QueryFormOP14sThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(floc2), Clock.Now);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = dtoDao.QueryFormOP14sThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(floc3), Clock.Now);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = dtoDao.QueryFormOP14sThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(new List<FunctionalLocation> {floc1, floc3}),
                    Clock.Now);
                Assert.AreEqual(4, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldBringBackApprovalInformation()
        {
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var form = FormOP14Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", null, null, null, 0));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 3", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver 4", null, null, null, 3));

            formOP14Dao.Insert(form);

            var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(flocs), new DateRange(null, null));
            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(2, results[0].RemainingApprovals.Count);
            Assert.AreEqual("approver 1", results[0].RemainingApprovals[0]);
            Assert.AreEqual("approver 4", results[0].RemainingApprovals[1]);
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldBringBackApprovalInformationInOrderOfDisplay()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var formOP14 = FormOP14Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            formOP14.Approvals.Clear();
            formOP14.Approvals.Add(new FormApproval(null, null, "d", null, null, null, 2));
            formOP14.Approvals.Add(new FormApproval(null, null, "x", null, null, null, 1));
            formOP14.Approvals.Add(new FormApproval(null, null, "t", null, null, null, 3));
            formOP14Dao.Insert(formOP14);

            var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(flocs), new DateRange(null, null));
            Assert.AreEqual(1, results.Count);

            FormEdmontonDTO op14Dto = results.Find(dto => dto.FormType == EdmontonFormType.OP14);
            Assert.AreEqual(3, op14Dto.RemainingApprovals.Count);
            Assert.AreEqual("x", op14Dto.RemainingApprovals[0]);
            Assert.AreEqual("d", op14Dto.RemainingApprovals[1]);
            Assert.AreEqual("t", op14Dto.RemainingApprovals[2]);
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldIgnoreDisabledApprovals()
        {
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var form = FormOP14Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "disabled approver 1", null, null, null, 0, ApprovalShouldBeEnabledBehaviour.OP14PressureSafetyValve, false));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 3", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver 4", null, null, null, 3));

            formOP14Dao.Insert(form);

            var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(flocs), new DateRange(null, null));
            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(1, results[0].RemainingApprovals.Count);
            Assert.AreEqual("approver 4", results[0].RemainingApprovals[0]);
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackFormsThatFallUnderOrAboveOrEqualToTheSpecifiedFLOC()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            var floc3 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var floc4 = FunctionalLocationFixture.GetReal("ED1-A001");

            var form1 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc2},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form2 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc3},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form3 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc1, floc3},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form4 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc4},
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));

            {
                var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(floc1), new DateRange(null, null));
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(floc2), new DateRange(null, null));
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(floc3), new DateRange(null, null));
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(new List<FunctionalLocation> {floc1, floc3}), new DateRange(null, null));
                Assert.AreEqual(4, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackFormsThatFallWithinDateRangeSpecified()
        {
            var flocs = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal_ED1_A001_U007()};

            var form1 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 3, 10, 0, 0), new DateTime(2012, 10, 6, 13, 0, 0), FormStatus.Draft));
            var form2 =
                formOP14Dao.Insert(FormOP14Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 5, 10, 0, 0), new DateTime(2012, 10, 16, 13, 0, 0), FormStatus.Draft));

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

        [Ignore] [Test]
        public void QueryByManyThingsShouldBringBackThingsWithWhateverStatusesIChoose()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            Clock.Freeze();
            Clock.Now = new DateTime(2012, 9, 1);
            var validFromDateTime = new DateTime(2012, 9, 1);
            var validToDateTime = new DateTime(2012, 9, 2);

            var draftForm1 = FormOP14Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Draft);
            formOP14Dao.Insert(draftForm1);

            var draftForm2 = FormOP14Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Draft);
            formOP14Dao.Insert(draftForm2);

            var approvedForm1 = FormOP14Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Approved);
            formOP14Dao.Insert(approvedForm1);

            var approvedForm2 = FormOP14Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Approved);
            formOP14Dao.Insert(approvedForm2);

            var closedForm1 = FormOP14Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Closed);
            formOP14Dao.Insert(closedForm1);

            var closedForm2 = FormOP14Fixture.CreateForInsert(flocs, validFromDateTime, validToDateTime, FormStatus.Closed);
            formOP14Dao.Insert(closedForm2);

            var dateRange = new DateRange(new Date(2012, 9, 1), new Date(2012, 9, 2));

            {
                var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs),
                    dateRange,
                    new List<FormStatus> {FormStatus.Draft, FormStatus.Approved});
                Assert.AreEqual(4, results.Count);

                Assert.IsTrue(results.Exists(dto => dto.Id == draftForm1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == draftForm2.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == approvedForm1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == approvedForm2.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRangeAndStatuses(new RootFlocSet(flocs),
                    dateRange,
                    new List<FormStatus> {FormStatus.Draft, FormStatus.Closed});
                Assert.AreEqual(4, results.Count);

                Assert.IsTrue(results.Exists(dto => dto.Id == draftForm1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == draftForm2.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == closedForm1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == closedForm2.Id));
            }
            Clock.UnFreeze();
        }

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IFormEdmontonOP14DTODao>();
            formOP14Dao = DaoRegistry.GetDao<IFormOP14Dao>();
        }

        protected override void Cleanup()
        {
        }

        private void AssertQueryByDateRange(bool exists, Date from, Date to, FormOP14 form)
        {
            var functionalLocations = form.FunctionalLocations;
            var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(functionalLocations), new DateRange(@from, to));
            Assert.AreEqual(exists, results.Exists(obj => obj.Id == form.Id));
        }

        private List<FormEdmontonOP14DTO> QueryByFunctionalLocationsAndDateRangeAndStatuses(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses)
        {
            return dtoDao.QueryFormOP14(flocSet, dateRange, formStatuses, false);
        }

        private List<FormEdmontonOP14DTO> QueryByFunctionalLocationsAndDateRange(RootFlocSet flocSet, DateRange dateRange)
        {
            return QueryByFunctionalLocationsAndDateRangeAndStatuses(flocSet, dateRange, FormStatus.All);
        }
    }
}