﻿using System;
using System.Collections.Generic;
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
    public class FormEdmontonGN6DTODaoTest : AbstractDaoTest
    {
        private IFormEdmontonGN6DTODao dtoDao;
        private IFormGN6Dao formGN6Dao;
        [Ignore]
         [Test]
        public void QueryByDateRangeAndFLOCShouldBringBackApprovalInformation()
        {
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SEG_IN0001();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SEG_LP0001();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var form = FormGN6Fixture.CreateForInsert(flocs, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver 1", null, null, null, 0));
            form.Approvals.Add(new FormApproval(null, null, "approver 2", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver 3", someUser, new DateTime(2012, 1, 1, 10, 0, 0), null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver 4", null, null, null, 3));

            formGN6Dao.Insert(form);

            var results = dtoDao.QueryDTOs(new RootFlocSet(flocs), new DateRange(null, null), FormStatus.All, false);
            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(2, results[0].RemainingApprovals.Count);
            Assert.AreEqual("approver 1", results[0].RemainingApprovals[0]);
            Assert.AreEqual("approver 4", results[0].RemainingApprovals[1]);
        }
      
        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldBringBackFormsOfAllStatusTypes()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var formGN6Draft = FormGN6Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Draft);
            formGN6Dao.Insert(formGN6Draft);

            var formGN6Approved = FormGN6Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Approved);
            formGN6Dao.Insert(formGN6Approved);

            var formGN6Closed = FormGN6Fixture.CreateForInsert(flocs, new DateTime(2012, 9, 1), new DateTime(2012, 9, 2), FormStatus.Closed);
            formGN6Dao.Insert(formGN6Closed);

            var results = dtoDao.QueryDTOs(new RootFlocSet(flocs), new DateRange(new Date(2012, 9, 1), new Date(2012, 9, 2)), FormStatus.All, false);
            Assert.AreEqual(3, results.Count);

            Assert.IsTrue(results.Exists(dto => dto.Id == formGN6Draft.Id));
            Assert.IsTrue(results.Exists(dto => dto.Id == formGN6Approved.Id));
            Assert.IsTrue(results.Exists(dto => dto.Id == formGN6Closed.Id));

            var resultsWithDraft = dtoDao.QueryDTOs(new RootFlocSet(flocs),
                new DateRange(new Date(2012, 9, 1), new Date(2012, 9, 2)),
                new List<FormStatus> {FormStatus.Draft},
                false);
            Assert.AreEqual(1, resultsWithDraft.Count);
            Assert.IsTrue(resultsWithDraft.Exists(dto => dto.Id == formGN6Draft.Id));
        }
       
        [Ignore] [Test]
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackFormsThatFallUnderOrAboveOrEqualToTheSpecifiedFLOC()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            var floc3 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var floc4 = FunctionalLocationFixture.GetReal("ED1-A001");

            var form1 = FormGN6Fixture.CreateForInsert(new List<FunctionalLocation> {floc2}, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            var form2 = FormGN6Fixture.CreateForInsert(new List<FunctionalLocation> {floc3}, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);
            var form3 = FormGN6Fixture.CreateForInsert(new List<FunctionalLocation> {floc1, floc3},
                new DateTime(2012, 10, 1),
                new DateTime(2012, 10, 2),
                FormStatus.Draft);
            var form4 = FormGN6Fixture.CreateForInsert(new List<FunctionalLocation> {floc4}, new DateTime(2012, 10, 1), new DateTime(2012, 10, 2), FormStatus.Draft);

            formGN6Dao.Insert(form1);
            formGN6Dao.Insert(form2);
            formGN6Dao.Insert(form3);
            formGN6Dao.Insert(form4);

            {
                var results = dtoDao.QueryDTOs(new RootFlocSet(floc1), new DateRange(null, null), FormStatus.All, false);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsFalse(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = dtoDao.QueryDTOs(new RootFlocSet(floc2), new DateRange(null, null), FormStatus.All, false);
                Assert.IsTrue(results.Exists(form => form.Id == form1.Id));
                Assert.IsFalse(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = dtoDao.QueryDTOs(new RootFlocSet(floc3), new DateRange(null, null), FormStatus.All, false);
                Assert.IsFalse(results.Exists(form => form.Id == form1.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form2.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form3.Id));
                Assert.IsTrue(results.Exists(form => form.Id == form4.Id));
            }

            {
                var results = dtoDao.QueryDTOs(new RootFlocSet(new List<FunctionalLocation> {floc1, floc3}), new DateRange(null, null), FormStatus.All, false);
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

            var form1From = new DateTime(2012, 10, 3, 10, 0, 0);
            var form1To = new DateTime(2012, 10, 6, 13, 0, 0);

            var form2From = new DateTime(2012, 10, 5, 10, 0, 0);
            var form2To = new DateTime(2012, 10, 16, 13, 0, 0);

            var form1 = FormGN6Fixture.CreateForInsert(flocs, form1From, form1To, FormStatus.Draft);
            var form2 = FormGN6Fixture.CreateForInsert(flocs, form2From, form2To, FormStatus.Draft);

            formGN6Dao.Insert(form1);
            formGN6Dao.Insert(form2);

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
        public void QueryByDateRangeAndFLOCShouldOnlyBringBackFormsThatFallWithinDateRangeSpecified_IncludeDraftItemsRegardlessOfDate()
        {
            var flocs = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal_ED1_A001_U007()};

            var form1From = new DateTime(2012, 10, 3, 10, 0, 0);
            var form1To = new DateTime(2012, 10, 6, 13, 0, 0);

            var form2From = new DateTime(2012, 10, 7, 10, 0, 0);
            var form2To = new DateTime(2012, 10, 16, 13, 0, 0);

            var form1_withinDate = FormGN6Fixture.CreateForInsert(flocs, form1From, form1To, FormStatus.Approved);
            var form2_outsideOfDateButIsDraft = FormGN6Fixture.CreateForInsert(flocs, form2From, form2To, FormStatus.Draft);

            formGN6Dao.Insert(form1_withinDate);
            formGN6Dao.Insert(form2_outsideOfDateButIsDraft);

            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(true, null, null, form1_withinDate);
            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(true, null, null, form2_outsideOfDateButIsDraft);

            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(true, new Date(2012, 10, 3), new Date(2012, 10, 6), form1_withinDate);
            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(true, new Date(2012, 10, 3), new Date(2012, 10, 6), form2_outsideOfDateButIsDraft);

            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(false, new Date(2012, 10, 7), new Date(2012, 10, 13), form1_withinDate);
            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(true, new Date(2012, 10, 7), new Date(2012, 10, 13), form2_outsideOfDateButIsDraft);

            // Make sure that different flocs will cause it to not come back, no matter what
            var differentList = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal_ED1_A001_U008()};
            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(false, differentList, new Date(2012, 10, 3), new Date(2012, 10, 13), form1_withinDate);
            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(false,
                differentList,
                new Date(2012, 10, 3),
                new Date(2012, 10, 13),
                form2_outsideOfDateButIsDraft);
        }

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IFormEdmontonGN6DTODao>();
            formGN6Dao = DaoRegistry.GetDao<IFormGN6Dao>();
        }

        protected override void Cleanup()
        {
        }

        private void AssertQueryByDateRange(bool exists, Date from, Date to, FormGN6 form)
        {
            var functionalLocations = form.FunctionalLocations;
            var results = dtoDao.QueryDTOs(new RootFlocSet(functionalLocations), new DateRange(@from, to), FormStatus.All, false);
            Assert.AreEqual(exists, results.Exists(obj => obj.Id == form.Id));
        }

        private void AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(bool exists, Date from, Date to, FormGN6 form)
        {
            AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(exists, form.FunctionalLocations, from, to, form);
        }

        private void AssertQueryByDateRange_ApprovedOnly_IncludeDraftsNoMatterWhat(bool exists,
            List<FunctionalLocation> functionalLocations,
            Date from,
            Date to,
            BaseEdmontonForm form)
        {
            var results = dtoDao.QueryDTOs(new RootFlocSet(functionalLocations), new DateRange(@from, to), new List<FormStatus> {FormStatus.Approved}, true);
            Assert.AreEqual(exists, results.Exists(obj => obj.Id == form.Id));
        }
    }
}