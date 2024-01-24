using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class OvertimeFormDaoTest : AbstractDaoTest
    {
        private IOvertimeFormDao dao;

        [Ignore] [Test]
        public void ShouldInsertAnOvertimeForm()
        {
            var realFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var now = Clock.Now;

            var form = new OvertimeForm(null,
                FormStatus.Draft,
                now,
                now,
                UserFixture.CreateSAPUser(),
                now,
                new List<OnPremiseContractor>
                {
                    new OnPremiseContractor(null,
                        null,
                        "Bob the builder",
                        "All Over",
                        now,
                        now,
                        true,
                        false,
                        "(403) 555-1212",
                        "Channel 1G",
                        "Description of work",
                        "Company Acme Trading",
                        "WO #800091231",
                        45.5m)
                },
                realFloc,
                "Electrician",
                UserFixture.CreateRemoteAppUser(),
                now,
                null,0);   //ayman generic forms

            form.DocumentLinks.Add(new DocumentLink("http://localhost:8090/test.html", "dummy doc"));
            var formApproval = new FormApproval(null, form.Id, "Approver dude", UserFixture.CreateSupervisor(SiteFixture.Edmonton()), now, "WORKASSIGNMENTNAME", 1);
            form.Approvals.Add(formApproval);
            form.FormStatus = FormStatus.Approved;
            dao.Insert(form);

            var returnedObject = dao.QueryById(form.IdValue);
            Assert.That(returnedObject, Is.Not.Null);
            Assert.That(returnedObject.OnPremiseContractors, Is.Not.Null);
            Assert.That(returnedObject.OnPremiseContractors.Count, Is.EqualTo(1));
            Assert.That(returnedObject.Approvals, Is.Not.Null);
            Assert.That(returnedObject.Approvals.Count, Is.EqualTo(2));
            Assert.That(returnedObject.Approvals.Last().WorkAssignmentDisplayName, Is.EqualTo("WORKASSIGNMENTNAME"));
        }

        [Ignore] [Test]
        public void ShouldUpdateAnOvertimeForm()
        {
            var realFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var now = Clock.Now;

            var form = new OvertimeForm(null,
                FormStatus.Draft,
                now,
                now,
                UserFixture.CreateSAPUser(),
                now,
                new List<OnPremiseContractor>
                {
                    new OnPremiseContractor(null,
                        null,
                        "Bob the builder",
                        "All Over",
                        now,
                        now,
                        true,
                        false,
                        "(403) 555-1212",
                        "Channel 1G",
                        "Description of work",
                        "Company Acme Trading",
                        "WO #800091231",
                        45.5m)               
                },
                realFloc,
                "Electrician",
                UserFixture.CreateRemoteAppUser(),
                now,
                null, 0);    //ayman generic forms

            form.DocumentLinks.Add(new DocumentLink("http://localhost:8090/test.html", "dummy doc"));

            dao.Insert(form);

            const string aNewTrade = "A New Trade";

            form.Trade = aNewTrade;
            form.Approvals.First().WorkAssignmentDisplayName = "WORKASSIGNMENTNAME";
            var formApproval = new FormApproval(null, form.Id, "Approver dude", UserFixture.CreateSupervisor(SiteFixture.Edmonton()), now, "WORKASSIGNMENTNAME", 2);
            form.Approvals.Add(formApproval);
            form.FormStatus = FormStatus.Approved;

            dao.Update(form);

            var returnedObject = dao.QueryById(form.IdValue);
            Assert.That(returnedObject.Trade, Is.EqualTo(aNewTrade));
            Assert.That(returnedObject, Is.Not.Null);
            Assert.That(returnedObject.Approvals, Is.Not.Null);
            Assert.That(returnedObject.Approvals.Count, Is.EqualTo(1));
            Assert.That(returnedObject.Approvals.First().WorkAssignmentDisplayName, Is.EqualTo("WORKASSIGNMENTNAME"));
        }

        [Ignore] [Test]
        public void ShouldUpdateOvertimeFormWithNewContractor()
        {
            var realFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var now = Clock.Now;

            var form = new OvertimeForm(null,
                FormStatus.Draft,
                now,
                now,
                UserFixture.CreateSAPUser(),
                now,
                new List<OnPremiseContractor>
                {
                    new OnPremiseContractor(null,
                        null,
                        "Bob the builder",
                        "All Over",
                        now,
                        now,
                        true,
                        false,
                        "(403) 555-1212",
                        "Channel 1G",
                        "Description of work",
                        "Company Acme Trading",
                        "WO #800091231",
                        45.5m)
                },
                realFloc,
                "Electrician",
                UserFixture.CreateRemoteAppUser(),
                now,
                null,0);  //ayman generic forms

            form.DocumentLinks.Add(new DocumentLink("http://localhost:8090/test.html", "dummy doc"));

            dao.Insert(form);

            var onPremiseContractor = new OnPremiseContractor(null,
                form.Id,
                "Handy Manny",
                "ED1",
                now,
                now,
                true,
                true,
                "(403) 555-1213",
                "Channel 14",
                "Description of work",
                "Company Acme Trading Ltd.",
                "WO #800091231",
                4.25m);
            form.OnPremiseContractors.Add(onPremiseContractor);

            dao.Update(form);

            var returnedObject = dao.QueryById(form.IdValue);
            Assert.That(returnedObject, Is.Not.Null);
            Assert.That(returnedObject.OnPremiseContractors, Is.Not.Null);
            Assert.That(returnedObject.OnPremiseContractors.Count, Is.EqualTo(2));
        }

        [Ignore] [Test]
        public void ShouldUpdateOvertimeFormWithRemovedContractor()
        {
            var realFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var now = Clock.Now;

            var contractorA = new OnPremiseContractor(null,
                null,
                "Handy Manny",
                "ED1",
                now,
                now,
                true,
                true,
                "(403) 555-1213",
                "Channel 14",
                "Description of work",
                "Company Acme Trading Ltd.",
                "WO #800091231",
                4.25m);

            var contractorB = new OnPremiseContractor(null,
                null,
                "Bob the builder",
                "All Over",
                now,
                now,
                true,
                false,
                "(403) 555-1212",
                "Channel 1G",
                "Description of work",
                "Company Acme Trading",
                "WO #800091231",
                45.5m);
            var onPremiseContractors = new List<OnPremiseContractor>
            {
                contractorA,
                contractorB
            };

            var form = new OvertimeForm(null,
                FormStatus.Draft,
                now,
                now,
                UserFixture.CreateSAPUser(),
                now,
                onPremiseContractors,
                realFloc,
                "Electrician",
                UserFixture.CreateRemoteAppUser(),
                now,
                null,0);   //ayman generic forms

            form.DocumentLinks.Add(new DocumentLink("http://localhost:8090/test.html", "dummy doc"));

            dao.Insert(form);

            form.OnPremiseContractors.RemoveAt(0);

            dao.Update(form);

            var returnedObject = dao.QueryById(form.IdValue);
            Assert.That(returnedObject, Is.Not.Null);
            Assert.That(returnedObject.OnPremiseContractors, Is.Not.Null);
            Assert.That(returnedObject.OnPremiseContractors.Count, Is.EqualTo(1));
        }

        [Ignore] [Test]
        public void ShouldUpdateOvertimeFormWithUpdatedContractor()
        {
            var realFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var now = Clock.Now;

            var contractorA = new OnPremiseContractor(null,
                null,
                "Handy Manny",
                "ED1",
                now,
                now,
                true,
                true,
                "(403) 555-1213",
                "Channel 14",
                "Description of work",
                "Company Acme Trading Ltd.",
                "WO #800091231",
                4.25m);

            var contractorB = new OnPremiseContractor(null,
                null,
                "Bob the builder",
                "All Over",
                now,
                now,
                true,
                false,
                "(403) 555-1212",
                "Channel 1G",
                "Description of work",
                "Company Acme Trading",
                "WO #800091231",
                45.5m);
            var onPremiseContractors = new List<OnPremiseContractor>
            {
                contractorA,
                contractorB
            };

            var form = new OvertimeForm(null,
                FormStatus.Draft,
                now,
                now,
                UserFixture.CreateSAPUser(),
                now,
                onPremiseContractors,
                realFloc,
                "Electrician",
                UserFixture.CreateRemoteAppUser(),
                now,
                null,0);    //ayman generic forms

            form.DocumentLinks.Add(new DocumentLink("http://localhost:8090/test.html", "dummy doc"));

            dao.Insert(form);

            form.OnPremiseContractors[0].StartDateTime = now.SubtractDays(2);

            dao.Update(form);

            var returnedObject = dao.QueryById(form.IdValue);
            Assert.That(returnedObject, Is.Not.Null);
            Assert.That(returnedObject.OnPremiseContractors, Is.Not.Null);
            Assert.That(returnedObject.OnPremiseContractors.Count, Is.EqualTo(2));
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IOvertimeFormDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}