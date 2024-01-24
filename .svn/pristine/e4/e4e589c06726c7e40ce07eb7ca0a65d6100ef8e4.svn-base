using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class FormEdmontonGN1DTODaoTest : AbstractDaoTest
    {
        private IFormGN1Dao dao;
        private IFormEdmontonGN1DTODao dtoDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormGN1Dao>();
            dtoDao = DaoRegistry.GetDao<IFormEdmontonGN1DTODao>();
        }

        protected override void Cleanup()
        {
            
        }

        
        [Ignore] [Test]
        public void ShouldGetItemsWithinDateRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            DateTime fromDateTime = new DateTime(2014, 1, 8);
            DateTime toDateTime = new DateTime(2014, 1, 10);

            FormGN1 form1_draft_inrange = FormGN1Fixture.CreateForInsert(floc, fromDateTime, toDateTime, FormStatus.Draft);
            FormGN1 form1_draft_outsiderange= FormGN1Fixture.CreateForInsert(floc, new DateTime(2014, 1, 11), new DateTime(2014, 1, 12), FormStatus.Draft);
            FormGN1 form1_approved_inrange= FormGN1Fixture.CreateForInsert(floc, fromDateTime, toDateTime, FormStatus.Approved);
            FormGN1 form1_approved_outsiderange = FormGN1Fixture.CreateForInsert(floc, new DateTime(2014, 1, 11), new DateTime(2014, 1, 12), FormStatus.Approved);

            dao.Insert(form1_draft_inrange);
            dao.Insert(form1_draft_outsiderange);
            dao.Insert(form1_approved_inrange);
            dao.Insert(form1_approved_outsiderange);
            
            List<FormEdmontonGN1DTO> results = dtoDao.QueryDTOs(new RootFlocSet(floc), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, false);

            Assert.AreEqual(2, results.Count);

            Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange.IdValue));
            Assert.IsFalse(results.Exists(r => r.IdValue == form1_draft_outsiderange.IdValue));
            Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange.IdValue));
            Assert.IsFalse(results.Exists(r => r.IdValue == form1_approved_outsiderange.IdValue));            
        }

       
        [Ignore] [Test]
        public void ShouldGetTradeChecklistNames()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            DateTime fromDateTime = new DateTime(2014, 1, 8);
            DateTime toDateTime = new DateTime(2014, 1, 10);

            FormGN1 gn1 = FormGN1Fixture.CreateForInsert(floc, fromDateTime, toDateTime, FormStatus.Draft);            
            gn1.TradeChecklists.ForEach(tc => 
                {
                    tc.ClearAreaManagerApproval();
                    tc.ClearConstFieldMaintCoordApproval();
                    tc.ClearOpsCoordApproval();
                });

            dao.Insert(gn1);       

            List<FormEdmontonGN1DTO> results = dtoDao.QueryDTOs(new RootFlocSet(floc), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, true);
            Assert.AreEqual("Refractionation Organizer, Indoor Precipitation Collection Agent", results.First().TradeChecklistNames);
        }

       
        [Ignore] [Test]
        public void ShouldGetRemainingApprovals()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            DateTime fromDateTime = new DateTime(2014, 1, 8);
            DateTime toDateTime = new DateTime(2014, 1, 10);

            FormGN1 gn1 = FormGN1Fixture.CreateForInsert(floc, fromDateTime, toDateTime, FormStatus.Draft);            
            gn1.AllApprovals.ForEach(approval =>
                {
                    approval.ApprovedByUser = UserFixture.CreateUserWithGivenId(1);
                    approval.ApprovalDateTime = new DateTime(2014, 1, 8, 14, 0, 0);
                });

            gn1.TradeChecklists.ForEach(tc => 
                {
                    tc.ClearAreaManagerApproval();
                    tc.ClearConstFieldMaintCoordApproval();
                    tc.ClearOpsCoordApproval();
                });

            dao.Insert(gn1);       

            List<FormEdmontonGN1DTO> results = dtoDao.QueryDTOs(new RootFlocSet(floc), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, true);

            Assert.AreEqual(1, results.Count);

            FormEdmontonGN1DTO dto = results.Find(r => r.IdValue == gn1.IdValue);
        }

       
        [Ignore] [Test]
        public void ShouldGetItemsWithinFloc()
        {
            FunctionalLocation flocU007 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation flocU008 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            DateTime fromDateTime = new DateTime(2014, 1, 8);
            DateTime toDateTime = new DateTime(2014, 1, 10);

            FormGN1 form1_draft_inrange_u007 = FormGN1Fixture.CreateForInsert(flocU007, fromDateTime, toDateTime, FormStatus.Draft);
            FormGN1 form1_draft_inrange_u008 = FormGN1Fixture.CreateForInsert(flocU008, fromDateTime, toDateTime, FormStatus.Draft);
            
            FormGN1 form1_approved_inrange_u007 = FormGN1Fixture.CreateForInsert(flocU007, fromDateTime, toDateTime, FormStatus.Approved);            
            FormGN1 form1_approved_inrange_u008 = FormGN1Fixture.CreateForInsert(flocU008, fromDateTime, toDateTime, FormStatus.Approved);

            dao.Insert(form1_draft_inrange_u007);
            dao.Insert(form1_draft_inrange_u008);
            dao.Insert(form1_approved_inrange_u007);
            dao.Insert(form1_approved_inrange_u008);

            {
                List<FormEdmontonGN1DTO> results = dtoDao.QueryDTOs(new RootFlocSet(flocU007), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, true);            

                Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange_u007.IdValue));
                Assert.IsFalse(results.Exists(r => r.IdValue == form1_draft_inrange_u008.IdValue));
                Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange_u007.IdValue));
                Assert.IsFalse(results.Exists(r => r.IdValue == form1_approved_inrange_u008.IdValue));                            
            }

            {
                List<FormEdmontonGN1DTO> results = dtoDao.QueryDTOs(new RootFlocSet(flocU007, flocU008), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, true);            

                Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange_u007.IdValue));
                Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange_u008.IdValue));
                Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange_u007.IdValue));
                Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange_u008.IdValue));                            
            }
        }
     
        [Ignore] [Test]
        public void ShouldGetDraftItemsRegardlessOfDateRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            DateTime fromDateTime = new DateTime(2014, 1, 8);
            DateTime toDateTime = new DateTime(2014, 1, 10);

            FormGN1 form1_draft_inrange = FormGN1Fixture.CreateForInsert(floc, fromDateTime, toDateTime, FormStatus.Draft);
            FormGN1 form1_draft_outsiderange = FormGN1Fixture.CreateForInsert(floc, new DateTime(2014, 1, 11), new DateTime(2014, 1, 12), FormStatus.Draft);
            FormGN1 form1_approved_inrange = FormGN1Fixture.CreateForInsert(floc, fromDateTime, toDateTime, FormStatus.Approved);
            FormGN1 form1_approved_outsiderange = FormGN1Fixture.CreateForInsert(floc, new DateTime(2014, 1, 11), new DateTime(2014, 1, 12), FormStatus.Approved);

            dao.Insert(form1_draft_inrange);
            dao.Insert(form1_draft_outsiderange);
            dao.Insert(form1_approved_inrange);
            dao.Insert(form1_approved_outsiderange);

            List<FormEdmontonGN1DTO> results = dtoDao.QueryDTOs(new RootFlocSet(floc), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, true);

            Assert.AreEqual(3, results.Count);

            Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange.IdValue));
            Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_outsiderange.IdValue));
            Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange.IdValue));
            Assert.IsFalse(results.Exists(r => r.IdValue == form1_approved_outsiderange.IdValue));
        }

    }
}