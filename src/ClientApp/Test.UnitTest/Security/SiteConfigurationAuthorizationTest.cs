using System;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class SiteConfigurationAuthorizationTest
    {
        IAuthorized authorized;
        
        [SetUp]
        public void SetUp()
        {
            authorized = new Authorized();
            Clock.Freeze();
            Clock.Now = new DateTime(Clock.DateNow.Year, Clock.DateNow.Month, Clock.DateNow.Day, 11, 0, 0);

            authorized = new Authorized();
        }

        [Test]
        public void ShouldAllowAdminToConfigureWorkPermitArchivalProcess()
        {
            Assert.IsTrue(authorized.ToConfigureWorkPermitArchivalProcess(UserRoleElementsFixture.CreateRoleElementsForAdmin()));
        }

        [Test]
        public void ShouldNotAllowNonAdminToConfigureWorkPermitArchivalProcess()
        {
            Assert.IsFalse(authorized.ToConfigureDisplayLimits(UserRoleElementsFixture.CreateRoleElementsForOperator()));
            Assert.IsFalse(authorized.ToConfigureDisplayLimits(UserRoleElementsFixture.CreateRoleElementsForSupervisor()));
            Assert.IsFalse(authorized.ToConfigureDisplayLimits(UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport()));
            Assert.IsFalse(authorized.ToConfigureDisplayLimits(UserRoleElementsFixture.CreateRoleElementsForPermitScreener()));
        }

        [Test]
        public void ShouldAllowAdminToConfigureWorkPermitContractor()
        {
            Assert.IsTrue(authorized.ToConfigureWorkPermitContractor(UserRoleElementsFixture.CreateRoleElementsForAdmin()));
        }

        [Test]
        public void ShouldNotAllowNonAdminToConfigureWorkPermitContractor()
        {
            Assert.IsFalse(authorized.ToConfigureWorkPermitContractor(UserRoleElementsFixture.CreateRoleElementsForOperator()));
            Assert.IsFalse(authorized.ToConfigureWorkPermitContractor(UserRoleElementsFixture.CreateRoleElementsForSupervisor()));
            Assert.IsFalse(authorized.ToConfigureWorkPermitContractor(UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport()));
            Assert.IsFalse(authorized.ToConfigureWorkPermitContractor(UserRoleElementsFixture.CreateRoleElementsForPermitScreener()));
        }
        
        [Test]
        public void ShouldAllowSupervisorOperatorAndEngineeringSupportToConfigurePlantHistorianTagList()
        {
            Assert.IsTrue(authorized.ToConfigurePlantHistorianTagList(UserRoleElementsFixture.CreateRoleElementsForSupervisor()));
            Assert.IsTrue(authorized.ToConfigurePlantHistorianTagList(UserRoleElementsFixture.CreateRoleElementsForOperator()));
            Assert.IsTrue(authorized.ToConfigurePlantHistorianTagList(UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport()));
        }

        [Test]
        public void ShouldNotAllowNonSupervisorOperatorAndEngineeringSupportToConfigurePlantHistorianTagList()
        {
            Assert.IsFalse(authorized.ToConfigurePlantHistorianTagList(UserRoleElementsFixture.CreateRoleElementsForAdmin()));
            Assert.IsFalse(authorized.ToConfigurePlantHistorianTagList(UserRoleElementsFixture.CreateRoleElementsForPermitScreener()));
        }

        [Test]
        public void ShouldAllowSupervisorAndAdminToConfigureAutoReApprovalByField()
        {
            Assert.IsTrue(authorized.ToConfigureAutoReApprovalByField(UserRoleElementsFixture.CreateRoleElementsForAdmin()));
            Assert.IsTrue(authorized.ToConfigureAutoReApprovalByField(UserRoleElementsFixture.CreateRoleElementsForSupervisor()));
        }

        [Test]
        public void ShouldNotAllowNonSupervisorAndAdminToConfigureAutoReApprovalByField()
        {
            Assert.IsFalse(authorized.ToConfigureAutoReApprovalByField(UserRoleElementsFixture.CreateRoleElementsForPermitScreener()));
            Assert.IsFalse(authorized.ToConfigureAutoReApprovalByField(UserRoleElementsFixture.CreateRoleElementsForOperator()));
            Assert.IsFalse(authorized.ToConfigureAutoReApprovalByField(UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport()));
        }
    }
}
