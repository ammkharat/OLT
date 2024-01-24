using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RolePermissionDao : AbstractManagedDao, IRolePermissionDao
    {
        private const string QUERY_BY_ROLE_ID_FOR_ROLE_PERMISSIONS = "QueryRolePermissionByRole";
        private const string DELETE = "DeleteRolePermission";
        private const string INSERT = "InsertRolePermission";

        private static RolePermission PopulateInstance(SqlDataReader reader)
        {
            var roleElement = new RolePermission(reader.Get<long>("RoleId"), reader.Get<long>("RoleElementId"),
                                                 reader.Get<long>("CreatedByRoleId"));

            return roleElement;
        }

        public List<RolePermission> QueryByRoleId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RoleId",  id);
            return command.QueryForListResult<RolePermission>(PopulateInstance, QUERY_BY_ROLE_ID_FOR_ROLE_PERMISSIONS);
        }

        public void Delete(RolePermission rolePermission)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("RoleId", rolePermission.RoleId);
            command.AddParameter("RoleElementId", rolePermission.RoleElementId);
            command.AddParameter("CreatedByRoleId", rolePermission.CreatedByRoleId);

            command.ExecuteNonQuery(DELETE);
        }

        public void Insert(RolePermission rolePermission)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("RoleId", rolePermission.RoleId);
            command.AddParameter("RoleElementId", rolePermission.RoleElementId);
            command.AddParameter("CreatedByRoleId", rolePermission.CreatedByRoleId);

            command.Insert(INSERT);
        }
    }
}
