using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class WorkAssignmentServiceTest
    {
        private Mockery mocks;
        private IWorkAssignmentDao orgDao;
        private IRoleDao roleDao;
        private WorkAssignmentService service;
        private WorkAssignment workAssignment;

        [SetUp]
        public void SetUp()
        {
            DaoRegistry.Clear();

            mocks = new Mockery();
            orgDao = mocks.NewMock<IWorkAssignmentDao>();
            DaoRegistry.RegisterDaoFor(orgDao);

            roleDao = mocks.NewMock<IRoleDao>();
            DaoRegistry.RegisterDaoFor(roleDao);

            service = new WorkAssignmentService();

            workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldInsertWorkAssignment()
        {
            Expect.Once.On(orgDao).Method("Insert").With(workAssignment);
            service.Insert(workAssignment);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldQueryAllOrganizationalAssignments()
        {
            Expect.Once.On(orgDao).Method("QueryBySiteId").With(SiteFixture.Sarnia().IdValue);
            service.QueryBySite(SiteFixture.Sarnia());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldQueryAssignmentsThatHaveRolesApplicableToUser()
        {
            var user = UserFixture.CreateSupervisor();
            var site = SiteFixture.Sarnia();
            var siteId = site.IdValue;
            user.SiteRolePlants.Clear();
            user.SiteRolePlants.Add(new SiteRolePlant(site, RoleFixture.CreateOperatorRole(), site.Plants[0].IdValue));

            var operatorAssignment = new WorkAssignment(3, "SS", "Some Operator", null, siteId,
                RoleFixture.CreateOperatorRole(), true, true, null, null, null, true,true);
            var supervisorAssignment = new WorkAssignment(4, "SS", "Some Supervisor", null, siteId,
                RoleFixture.CreateSupervisorRole(), true, true, null, null, null, true,true);

            var assignmentsForSite = new List<WorkAssignment>
            {
                operatorAssignment,
                supervisorAssignment
            };

            Stub.On(orgDao).Method("QueryBySiteId").With(siteId).Will(Return.Value(assignmentsForSite));

            var assignmentsForUser = service.QueryByUserAndSite(user, site);

            Assert.AreEqual(1, assignmentsForUser.Count);
            Assert.AreEqual(operatorAssignment, assignmentsForUser[0]);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldRemoveWorkAssignment()
        {
            Expect.Once.On(orgDao).Method("Remove").With(workAssignment);
            service.Remove(workAssignment);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateWorkAssignment()
        {
            Expect.Once.On(orgDao).Method("Update").With(workAssignment);
            service.Update(workAssignment);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}