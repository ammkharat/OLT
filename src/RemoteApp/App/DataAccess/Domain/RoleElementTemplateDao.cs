using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using DevExpress.XtraRichEdit.Ruler;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RoleElementTemplateDao : AbstractManagedDao, IRoleElementTemplateDao
    {
        private const string InsertStoredProcedure = "InsertRoleElementTemplate";
        private const string DeleteStoredProcedure = "DeleteRoleElementTemplate";
        private const string GetSarniaEipIssueApproverStoredProcedure = "GetSarniaEipIssueApprover";

        public void DeleteRoleElementTemplate(Site site, string roleName, string roleElementName)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("SiteId", site.IdValue);
            command.AddParameter("RoleName", roleName);
            command.AddParameter("RoleElementName", roleElementName);

            command.ExecuteNonQuery(DeleteStoredProcedure);
        }

        public void InsertRoleElementTemplate(Site site, string roleName, string roleElementName)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("SiteId", site.IdValue);
            command.AddParameter("RoleName", roleName);
            command.AddParameter("RoleElementName", roleElementName);

            command.Insert(InsertStoredProcedure);
        }

        //ayman Sarnia eip DMND0008992
        public string GetSarniaeipIssueApprover(Site site, string roleElementName)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",site.IdValue);
            command.AddParameter("@RoleElementName",roleElementName);
            command.CommandType=CommandType.StoredProcedure;
            command.CommandText = GetSarniaEipIssueApproverStoredProcedure;
            var eipApprover = (string) command.ExecuteScalar();
            return eipApprover;
        }
    }
}
