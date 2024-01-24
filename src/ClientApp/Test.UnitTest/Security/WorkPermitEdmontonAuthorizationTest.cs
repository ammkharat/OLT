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
    public class WorkPermitEdmontonAuthorizationTest
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
        public void PeopleWithPrintPermitRoleShouldBeAbleToPrintPendingWorkPermits()
        {            
            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
            WorkPermitEdmontonDTO dto = new WorkPermitEdmontonDTO(workPermit);

            Role supervisorRole = RoleFixture.CreateSupervisorRole();

            List<RoleElement> canPrintPermitRoleElements = new List<RoleElement> { RoleElement.PRINT_PERMIT, RoleElement.VIEW_PERMIT };
            List<RoleElement> cannotPrintPermitRoleElements = new List<RoleElement> { RoleElement.VIEW_PERMIT };

            Assert.IsTrue(authorized.ToPrintWorkPermit(new UserRoleElements(supervisorRole, canPrintPermitRoleElements), dto));
            Assert.IsFalse(authorized.ToPrintWorkPermit(new UserRoleElements(supervisorRole, cannotPrintPermitRoleElements), dto));
        }

        [Test]
        public void PendingPermitsShouldOnlyBePrintableIfThePermitHasntExpiredYet()
        {
            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
            Role supervisorRole = RoleFixture.CreateSupervisorRole();
            List<RoleElement> canPrintPermitRoleElements = new List<RoleElement> { RoleElement.PRINT_PERMIT, RoleElement.VIEW_PERMIT };

            {
                workPermit.ExpiredDateTime = Clock.Now.AddHours(-1);
                WorkPermitEdmontonDTO dto = new WorkPermitEdmontonDTO(workPermit);

                Assert.IsFalse(authorized.ToPrintWorkPermit(new UserRoleElements(supervisorRole, canPrintPermitRoleElements), dto));
            }

            {
                workPermit.ExpiredDateTime = Clock.Now.AddHours(1);
                WorkPermitEdmontonDTO dto = new WorkPermitEdmontonDTO(workPermit);

                Assert.IsTrue(authorized.ToPrintWorkPermit(new UserRoleElements(supervisorRole, canPrintPermitRoleElements), dto));
            }

            {
                workPermit.ExpiredDateTime = Clock.Now.AddHours(-1).AddDays(1);
                WorkPermitEdmontonDTO dto = new WorkPermitEdmontonDTO(workPermit);

                Assert.IsTrue(authorized.ToPrintWorkPermit(new UserRoleElements(supervisorRole, canPrintPermitRoleElements), dto));
            }

            {
                workPermit.ExpiredDateTime = Clock.Now.AddHours(1).AddDays(-1);
                WorkPermitEdmontonDTO dto = new WorkPermitEdmontonDTO(workPermit);

                Assert.IsFalse(authorized.ToPrintWorkPermit(new UserRoleElements(supervisorRole, canPrintPermitRoleElements), dto));
            }
        }

        [Test]
        public void ShouldOnlyBeAbleToPrintPermitsThatAreNotInRequestedState()
        {
            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            Role supervisorRole = RoleFixture.CreateSupervisorRole();
            List<RoleElement> canPrintPermitRoleElements = new List<RoleElement> { RoleElement.PRINT_PERMIT, RoleElement.VIEW_PERMIT };
            UserRoleElements roleElements = new UserRoleElements(supervisorRole, canPrintPermitRoleElements);

            foreach (PermitRequestBasedWorkPermitStatus status in PermitRequestBasedWorkPermitStatus.All)
            {
                workPermit.WorkPermitStatus = status;
                WorkPermitEdmontonDTO dto = new WorkPermitEdmontonDTO(workPermit);

                if (status == PermitRequestBasedWorkPermitStatus.Requested)
                {
                    Assert.IsFalse(authorized.ToPrintWorkPermit(roleElements, dto), String.Format("Should not be able to print a permit with status {0}", status.GetName()));
                }
                else
                {
                    Assert.IsTrue(authorized.ToPrintWorkPermit(roleElements, dto), String.Format("Should be able to print a permit with status {0}", status.GetName()));
                }                
            }
        }

        [Test]
        public void AbilityToEditAPermitRequestShouldBeBasedPurelyOnRoleElementsAndNotOnWhoCreatedIt()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, FunctionalLocationFixture.GetReal_ED1_A001_U007(), WorkPermitEdmontonGroupFixture.CreateForInsert());

            Role supervisorRole = RoleFixture.CreateSupervisorRole();
            UserRoleElements canEditPermitRequestUserRoleElements = new UserRoleElements(supervisorRole, new List<RoleElement> { RoleElement.EDIT_PERMIT_REQUEST });
            UserRoleElements cannotEditPermitRequestUserRoleElements = new UserRoleElements(supervisorRole, new List<RoleElement> { RoleElement.VIEW_PERMIT_REQUESTS });

            Assert.IsTrue(authorized.ToEditPermitRequest(canEditPermitRequestUserRoleElements, new List<PermitRequestEdmontonDTO> { new PermitRequestEdmontonDTO(permitRequest) }));
            Assert.IsFalse(authorized.ToEditPermitRequest(cannotEditPermitRequestUserRoleElements, new List<PermitRequestEdmontonDTO> { new PermitRequestEdmontonDTO(permitRequest) }));
        }
    }
}
