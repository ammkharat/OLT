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
    public class LubesCsdFormDTODaoTest : AbstractDaoTest
    {
        private ILubesCsdFormDTODao dtoDao;
        private IFormLubesCsdDao formLubesCsdDao;

        [Ignore] [Test]
        public void QueryApprovedCsdsByFlocShouldOnlyBringBackFormsThatAreCsdAndAreApprovedDraftOrExpired()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 10, 1, 1, 1, 1);
            var lubesCsdForm = FormLubesCsdFixture.CreateForInsert(floc1,
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Approved);
            lubesCsdForm.MarkAsApproved(new DateTime(2012, 10, 2));
            var form1 =
                formLubesCsdDao.Insert(lubesCsdForm);
            formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc1,
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Draft));
            formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc1,
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Closed));

            {
                var results =
                    dtoDao.QueryFormCsdsThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(floc1),
                        Clock.Now);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
            }

            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void QueryApprovedCsdsByFlocShouldOnlyBringBackFormsThatFallUnderOrAboveOrEqualToTheSpecifiedFLOCs()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 10, 1, 1, 1, 1);
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            var floc3 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var floc4 = FunctionalLocationFixture.GetReal("ED1-A001");

            var form1 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc2,
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));
            var form2 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc3,
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));
            var form3 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc1,
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));
            var form4 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc4,
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Approved));

            {
                var results =
                    dtoDao.QueryFormCsdsThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(floc1),
                        Clock.Now);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results =
                    dtoDao.QueryFormCsdsThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(floc2),
                        Clock.Now);
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results =
                    dtoDao.QueryFormCsdsThatAreApprovedDraftExpiredByFunctionalLocations(new RootFlocSet(floc3),
                        Clock.Now);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results =
                    dtoDao.QueryFormCsdsThatAreApprovedDraftExpiredByFunctionalLocations(
                        new RootFlocSet(new List<FunctionalLocation> {floc1, floc3}),
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
            var flocs = new List<FunctionalLocation> {floc1};

            var form = FormLubesCsdFixture.CreateForInsert(floc1, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2),
                FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", null, null, null, 0));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0),
                null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 3", someUser, new DateTime(2012, 1, 1, 10, 0, 0),
                null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver 4", null, null, null, 3));

            formLubesCsdDao.Insert(form);

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
            var flocs = new List<FunctionalLocation> {floc1};

            var form = FormLubesCsdFixture.CreateForInsert(floc1, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2),
                FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "d", null, null, null, 2));
            form.Approvals.Add(new FormApproval(null, null, "x", null, null, null, 1));
            form.Approvals.Add(new FormApproval(null, null, "t", null, null, null, 3));
            formLubesCsdDao.Insert(form);

            var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(flocs), new DateRange(null, null));
            Assert.AreEqual(1, results.Count);

            var lubesCsdDTO = results.Find(dto => dto.FormType == EdmontonFormType.LubesCsd);
            Assert.AreEqual(3, lubesCsdDTO.RemainingApprovals.Count);
            Assert.AreEqual("x", lubesCsdDTO.RemainingApprovals[0]);
            Assert.AreEqual("d", lubesCsdDTO.RemainingApprovals[1]);
            Assert.AreEqual("t", lubesCsdDTO.RemainingApprovals[2]);
        }

        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldIgnoreDisabledApprovals()
        {
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var flocs = new List<FunctionalLocation> {floc1};

            var form = FormLubesCsdFixture.CreateForInsert(floc1, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2),
                FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "disabled approver 1", null, null, null, 0,
                ApprovalShouldBeEnabledBehaviour.OP14PressureSafetyValve, false));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0),
                null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 3", someUser, new DateTime(2012, 1, 1, 10, 0, 0),
                null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver 4", null, null, null, 3));

            formLubesCsdDao.Insert(form);

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
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc2,
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form2 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc3,
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form3 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc3,
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));
            var form4 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc4,
                    new DateTime(2012, 10, 1),
                    new DateTime(2012, 10, 2),
                    FormStatus.Draft));

            {
                var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(floc1), new DateRange(null, null));
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(floc2), new DateRange(null, null));
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
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
                var results =
                    QueryByFunctionalLocationsAndDateRange(
                        new RootFlocSet(new List<FunctionalLocation> {floc1, floc3}), new DateRange(null, null));
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
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var flocs = new List<FunctionalLocation> {floc1};

            var form1 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc1, new DateTime(2012, 10, 3, 10, 0, 0),
                    new DateTime(2012, 10, 6, 13, 0, 0), FormStatus.Draft));
            var form2 =
                formLubesCsdDao.Insert(FormLubesCsdFixture.CreateForInsert(floc1, new DateTime(2012, 10, 5, 10, 0, 0),
                    new DateTime(2012, 10, 16, 13, 0, 0), FormStatus.Draft));

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

            var draftForm1 = FormLubesCsdFixture.CreateForInsert(floc1,
                validFromDateTime,
                validToDateTime,
                FormStatus.Draft);
            formLubesCsdDao.Insert(draftForm1);

            var draftForm2 = FormLubesCsdFixture.CreateForInsert(floc2,
                validFromDateTime,
                validToDateTime,
                FormStatus.Draft);
            formLubesCsdDao.Insert(draftForm2);

            var approvedForm1 = FormLubesCsdFixture.CreateForInsert(floc1,
                validFromDateTime,
                validToDateTime,
                FormStatus.Approved);
            approvedForm1.MarkAsApproved(validToDateTime);
            formLubesCsdDao.Insert(approvedForm1);

            var approvedForm2 = FormLubesCsdFixture.CreateForInsert(floc2,
                validFromDateTime,
                validToDateTime,
                FormStatus.Approved);
            formLubesCsdDao.Insert(approvedForm2);

            var closedForm1 = FormLubesCsdFixture.CreateForInsert(floc1,
                validFromDateTime,
                validToDateTime,
                FormStatus.Closed);
            formLubesCsdDao.Insert(closedForm1);

            var closedForm2 = FormLubesCsdFixture.CreateForInsert(floc2,
                validFromDateTime,
                validToDateTime,
                FormStatus.Closed);
            formLubesCsdDao.Insert(closedForm2);

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
                    new List<FormStatus> {FormStatus.Approved});
                Assert.AreEqual(2, results.Count);
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
            dtoDao = DaoRegistry.GetDao<ILubesCsdFormDTODao>();
            formLubesCsdDao = DaoRegistry.GetDao<IFormLubesCsdDao>();
        }

        protected override void Cleanup()
        {
        }

        private void AssertQueryByDateRange(bool exists, Date from, Date to, LubesCsdForm form)
        {
            var functionalLocation = form.FunctionalLocation;
            var results = QueryByFunctionalLocationsAndDateRange(new RootFlocSet(functionalLocation),
                new DateRange(@from, to));
            Assert.AreEqual(exists, results.Exists(obj => obj.Id == form.Id));
        }

        private List<LubesCsdFormDTO> QueryByFunctionalLocationsAndDateRangeAndStatuses(RootFlocSet flocSet,
            DateRange dateRange, IEnumerable<FormStatus> formStatuses)
        {
            return dtoDao.QueryFormCsd(flocSet, dateRange, formStatuses, false);
        }

        private List<LubesCsdFormDTO> QueryByFunctionalLocationsAndDateRange(RootFlocSet flocSet,
            DateRange dateRange)
        {
            return QueryByFunctionalLocationsAndDateRangeAndStatuses(flocSet, dateRange, FormStatus.All);
        }
    }
}