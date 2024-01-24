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
    public class FormOvertimeFormHistoryDaoTest : AbstractDaoTest
    {
        private IFormOvertimeFormHistoryDao dao;
        private IOvertimeFormDao formDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormOvertimeFormHistoryDao>();
            formDao = DaoRegistry.GetDao<IOvertimeFormDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            User someUser = UserFixture.CreateUser("uname", "firstname", "lastname");

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            DateTime validFromDateTime = new DateTime(2012, 10, 1, 1, 0, 0);
            DateTime validToDateTime = new DateTime(2012, 10, 3, 8, 0, 0);

            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());

            DateTime lastModifiedDateTime = new DateTime(2009, 3, 3, 4, 2, 0);
            List<OnPremiseContractor> onPremiseContractors = new List<OnPremiseContractor>
            {
                new OnPremiseContractor(100, 10, "Mike", "Edmonton", lastModifiedDateTime, lastModifiedDateTime,
                    true, true, "403 222 4444", "12", "heres a description", "Joe Contracting Inc", "ABC WO223", 4)
            };
            var form = new OvertimeForm(10, FormStatus.Approved, lastModifiedDateTime, lastModifiedDateTime,
                createdBy, lastModifiedDateTime, onPremiseContractors, FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                "the trade", createdBy, lastModifiedDateTime, null,0)   //ayman generic forms
            {
                DocumentLinks = new List<DocumentLink>() {DocumentLinkFixture.CreateNewDocumentLink(10)}
            };
            formDao.Insert(form);

            FormOvertimeFormHistory history = form.TakeSnapshot();

            dao.Insert(history);

            List<FormOvertimeFormHistory> histories = dao.GetById(form.IdValue);
            Assert.AreEqual(1, histories.Count);
            FormOvertimeFormHistory requeried = histories[0];

            {
                Assert.IsNotNull(requeried);

                Assert.AreEqual(form.IdValue, requeried.IdValue);

                Assert.AreEqual(
                    "Person: Mike Primary Location: Edmonton Start: Tuesday, March 03, 2009 4:02 AM End: Tuesday, March 03, 2009 4:02 AM Shifts: Day/Night Phone: 403 222 4444 Radio: 12 Description: heres a description Company: Joe Contracting Inc WO#/PO#: ABC WO223 OT Hrs: 4.00",
                    requeried.OnSitePersonnel);
                Assert.AreEqual(FunctionalLocationFixture.GetReal_ED1_A001_U007().FullHierarchy,
                    requeried.FunctionalLocation);
                Assert.AreEqual("the trade", requeried.TradeOccupation);
                Assert.AreEqual("Title for document (http:\\URL for Document)", requeried.DocumentLinks);
            }
        }
    }
}