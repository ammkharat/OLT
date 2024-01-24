using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.Services.Excel;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class StreamingRoleService : IStreamingRoleService
    {
        private readonly RoleService roleService;
        private readonly ISiteService siteService;
        private readonly IRoleElementService roleElementService;
        private readonly IRolePermissionService rolePermissionService;

        public StreamingRoleService()
        {
            siteService = new SiteService();

            roleService = new RoleService();
            roleElementService = new RoleElementService();
            rolePermissionService = new RolePermissionService();
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream QueryRoleMatrix(Site currentSite)
        {
            List<Site> sites = siteService.GetAll();

            Dictionary<Site, List<Role>> rolesBySite = new Dictionary<Site, List<Role>>();
            //foreach (Site site in sites)
            //{
            //    rolesBySite.Add(site, roleService.QueryRolesBySite(site));
            rolesBySite.Add(currentSite, roleService.QueryRolesBySite(currentSite));
            //  }

            Dictionary<Role, List<RoleElement>> roleElements = new Dictionary<Role, List<RoleElement>>();
            foreach (List<Role> roles in rolesBySite.Values)
            {
                foreach (Role role in roles)
                {
                    roleElements.Add(role, roleElementService.QueryTemplateForRoleIncludeFunctionalArea(role));
                }
            }

            Dictionary<Role, List<RolePermission>> rolePermissions = new Dictionary<Role, List<RolePermission>>();
            foreach (List<Role> roles in rolesBySite.Values)
            {
                foreach (Role role in roles)
                {
                    rolePermissions.Add(role, rolePermissionService.QueryByRoleId(role.IdValue));
                }
            }

            ExcelWriter excelStreamWriter = new ExcelWriter();
            return excelStreamWriter.RenderExcelDataToMemoryStream(new RoleMatrixExcelDataRenderer(currentSite, rolesBySite, roleElements, rolePermissions));
        }
    }
}