using System;
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
    [TestFixture]
    [Category("Database")]
    public class FormEdmontonGN75ADTODaoTest : AbstractDaoTest
    {
        private IFormGN75ADao dao;
        private IFormEdmontonGN75ADTODao dtoDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormGN75ADao>();
            dtoDao = DaoRegistry.GetDao<IFormEdmontonGN75ADTODao>();
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

            FormGN75A form1_draft_inrange = FormGN75AFixture.CreateForInsert(floc, fromDateTime, toDateTime, FormStatus.Draft);
            FormGN75A form1_draft_outsiderange= FormGN75AFixture.CreateForInsert(floc, new DateTime(2014, 1, 11), new DateTime(2014, 1, 12), FormStatus.Draft);
            FormGN75A form1_approved_inrange= FormGN75AFixture.CreateForInsert(floc, fromDateTime, toDateTime, FormStatus.Approved);
            FormGN75A form1_approved_outsiderange = FormGN75AFixture.CreateForInsert(floc, new DateTime(2014, 1, 11), new DateTime(2014, 1, 12), FormStatus.Approved);

            dao.Insert(form1_draft_inrange);
            dao.Insert(form1_draft_outsiderange);
            dao.Insert(form1_approved_inrange);
            dao.Insert(form1_approved_outsiderange);
            
            List<FormEdmontonGN75ADTO> results = dtoDao.QueryDTOs(new RootFlocSet(floc), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, true);

            Assert.AreEqual(3, results.Count);

            Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange.IdValue));
            Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_outsiderange.IdValue));
            Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange.IdValue));
            Assert.IsFalse(results.Exists(r => r.IdValue == form1_approved_outsiderange.IdValue));            
        }

        [Ignore] [Test]
        public void ShouldGetItemsWithinFloc()
        {
            FunctionalLocation flocU007 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation flocU008 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            DateTime fromDateTime = new DateTime(2014, 1, 8);
            DateTime toDateTime = new DateTime(2014, 1, 10);

            FormGN75A form1_draft_inrange_u007 = FormGN75AFixture.CreateForInsert(flocU007, fromDateTime, toDateTime, FormStatus.Draft);
            FormGN75A form1_draft_inrange_u008 = FormGN75AFixture.CreateForInsert(flocU008, fromDateTime, toDateTime, FormStatus.Draft);
            
            FormGN75A form1_approved_inrange_u007 = FormGN75AFixture.CreateForInsert(flocU007, fromDateTime, toDateTime, FormStatus.Approved);            
            FormGN75A form1_approved_inrange_u008 = FormGN75AFixture.CreateForInsert(flocU008, fromDateTime, toDateTime, FormStatus.Approved);

            dao.Insert(form1_draft_inrange_u007);
            dao.Insert(form1_draft_inrange_u008);
            dao.Insert(form1_approved_inrange_u007);
            dao.Insert(form1_approved_inrange_u008);

            {
                List<FormEdmontonGN75ADTO> results = dtoDao.QueryDTOs(new RootFlocSet(flocU007), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, true);            

                Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange_u007.IdValue));
                Assert.IsFalse(results.Exists(r => r.IdValue == form1_draft_inrange_u008.IdValue));
                Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange_u007.IdValue));
                Assert.IsFalse(results.Exists(r => r.IdValue == form1_approved_inrange_u008.IdValue));                            
            }

            {
                List<FormEdmontonGN75ADTO> results = dtoDao.QueryDTOs(new RootFlocSet(flocU007, flocU008), new DateRange(new Date(fromDateTime), new Date(toDateTime)), FormStatus.All, true);            

                Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange_u007.IdValue));
                Assert.IsTrue(results.Exists(r => r.IdValue == form1_draft_inrange_u008.IdValue));
                Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange_u007.IdValue));
                Assert.IsTrue(results.Exists(r => r.IdValue == form1_approved_inrange_u008.IdValue));                            
            }
        }
    }
}