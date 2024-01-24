using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class RolePermissionServiceTest
    {
        private Mockery mock;

        private const string QUERY_BY_ROLE_ID = "QueryByRoleId";
        private const long SUPERVISOR_ROLE_ID = 49;

        private IRolePermissionDao dao;
        private List<RolePermission> rolePermissions = new List<RolePermission>();
        private RolePermissionService service;

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            dao = mock.NewMock<IRolePermissionDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(dao);
            
            service = new RolePermissionService();

            RolePermission rolePermission = new RolePermission(SUPERVISOR_ROLE_ID, 34, SUPERVISOR_ROLE_ID);
            rolePermissions.Add(rolePermission);
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }


        [Ignore] [Test]
        public void ShouldGetRolePermissionsByRoleId()
        {
            Expect.Once.On(dao).Method(QUERY_BY_ROLE_ID).Will(Return.Value(rolePermissions));
            service.QueryByRoleId(SUPERVISOR_ROLE_ID);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

    }
}
