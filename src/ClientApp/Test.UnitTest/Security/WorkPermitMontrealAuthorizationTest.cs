using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class WorkPermitMontrealAuthorizationTest
    {
        private IAuthorized authorized;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(Clock.DateNow.Year, Clock.DateNow.Month, Clock.DateNow.Day, 11, 0, 0);

            authorized = new Authorized();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void PermitsThatAreClosedButHaveNeverBeenIssuedShouldNotBePrintable()
        {
            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();            
            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.CompletionUnknown;

            Role supervisorRole = RoleFixture.CreateSupervisorRole();
            List<RoleElement> canPrintPermitRoleElements = new List<RoleElement> { RoleElement.PRINT_PERMIT, RoleElement.VIEW_PERMIT };
            UserRoleElements roleElements = new UserRoleElements(supervisorRole, canPrintPermitRoleElements);

            {
                workPermit.IssuedDateTime = null;
                WorkPermitMontrealDTO dto = new WorkPermitMontrealDTO(workPermit);

                Assert.IsFalse(authorized.ToPrintWorkPermit(roleElements, dto));
                Assert.IsFalse(authorized.ToPrintWorkPermits(roleElements, new List<WorkPermitMontrealDTO> { dto }));
            }

            {
                workPermit.IssuedDateTime = Clock.Now.AddDays(-1);
                WorkPermitMontrealDTO dto = new WorkPermitMontrealDTO(workPermit);

                Assert.IsTrue(authorized.ToPrintWorkPermit(roleElements, dto));
                Assert.IsTrue(authorized.ToPrintWorkPermits(roleElements, new List<WorkPermitMontrealDTO> { dto }));
            }
        }

        [Test]
        public void PeopleWithPrintPermitRoleShouldBeAbleToPrintPendingWorkPermits()
        {            
            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
            workPermit.IssuedDateTime = null;
            WorkPermitMontrealDTO dto = new WorkPermitMontrealDTO(workPermit);

            Role supervisorRole = RoleFixture.CreateSupervisorRole();

            List<RoleElement> canPrintPermitRoleElements = new List<RoleElement> { RoleElement.PRINT_PERMIT, RoleElement.VIEW_PERMIT };
            List<RoleElement> cannotPrintPermitRoleElements = new List<RoleElement> { RoleElement.VIEW_PERMIT };

            Assert.IsTrue(authorized.ToPrintWorkPermit(new UserRoleElements(supervisorRole, canPrintPermitRoleElements), dto));
            Assert.IsFalse(authorized.ToPrintWorkPermit(new UserRoleElements(supervisorRole, cannotPrintPermitRoleElements), dto));

            Assert.IsTrue(authorized.ToPrintWorkPermits(new UserRoleElements(supervisorRole, canPrintPermitRoleElements), new List<WorkPermitMontrealDTO> { dto }));
            Assert.IsFalse(authorized.ToPrintWorkPermits(new UserRoleElements(supervisorRole, cannotPrintPermitRoleElements), new List<WorkPermitMontrealDTO> { dto }));
        }

        [Test]
        public void ShouldBeAbleToPrintPermitsThatAreInPendingStateButNotInRequestedState()
        {
            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermit.IssuedDateTime = null;

            Role supervisorRole = RoleFixture.CreateSupervisorRole();
            List<RoleElement> canPrintPermitRoleElements = new List<RoleElement> { RoleElement.PRINT_PERMIT, RoleElement.VIEW_PERMIT };
            UserRoleElements roleElements = new UserRoleElements(supervisorRole, canPrintPermitRoleElements);

            {
                workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Requested;
                WorkPermitMontrealDTO dto = new WorkPermitMontrealDTO(workPermit);

                Assert.IsFalse(authorized.ToPrintWorkPermit(roleElements, dto));
                Assert.IsFalse(authorized.ToPrintWorkPermits(roleElements, new List<WorkPermitMontrealDTO> { dto }));
            }

            {
                workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
                WorkPermitMontrealDTO dto = new WorkPermitMontrealDTO(workPermit);

                Assert.IsTrue(authorized.ToPrintWorkPermit(roleElements, dto));
                Assert.IsTrue(authorized.ToPrintWorkPermits(roleElements, new List<WorkPermitMontrealDTO> { dto }));
            }
        }
    }
}
