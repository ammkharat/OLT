using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RoleElementTemplateService : IRoleElementTemplateService
    {
        private readonly IRoleElementTemplateDao dao;

        public RoleElementTemplateService()
        {
            dao = DaoRegistry.GetDao<IRoleElementTemplateDao>();
        }

        public void DeleteRoleElementTemplate(Site site, string roleName, string roleElementName)
        {
            dao.DeleteRoleElementTemplate(site, roleName, roleElementName);
        }

        public void InsertRoleElementTemplate(Site site, string roleName, string roleElementName)
        {
            dao.InsertRoleElementTemplate(site, roleName, roleElementName);
        }

        //ayman Sarnia eip DMND0008992
        public string GetSarniaEipIssueApprover(Site site, string roleElementName)
        {
          return dao.GetSarniaeipIssueApprover(site, roleElementName);
        }
    }
}
