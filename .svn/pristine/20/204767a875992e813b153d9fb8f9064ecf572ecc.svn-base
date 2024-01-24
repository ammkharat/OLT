using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Services.Excel;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class StreamingRequestRoleService : IStreamingRequestRoleService
    {
        private readonly IRoleService roleService;
        private readonly IRoleElementService roleElementService;
        private readonly ISiteService siteService;

        public StreamingRequestRoleService()
        {
            roleService = new RoleService();
            roleElementService = new RoleElementService();
            siteService = new SiteService();
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public List<RoleElementChange> GenerateRoleChanges(Stream excelStream)
        {
            MemoryStream memoryStream = new MemoryStream();
            excelStream.CopyStream(memoryStream);
            Workbook workbook = Workbook.Load(memoryStream);

            RoleMatrixSqlGenerator roleMatrixSqlGenerator = new RoleMatrixSqlGenerator(workbook, roleService, roleElementService, siteService);
            List<RoleElementChange> changes = roleMatrixSqlGenerator.GenerateRoleMatrixSql();
            return changes;
        }
    }
}