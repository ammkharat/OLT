using System;
using System.IO;
using Com.Suncor.Olt.Client.Excel;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Services;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class RoleMatrixPresenter
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(RoleMatrixPresenter));

        private readonly IStreamingRoleService streamingRoleService;

        public RoleMatrixPresenter()
        {
            streamingRoleService = ClientServiceRegistry.Instance.GetService<IStreamingRoleService>();
        }

        public void Run()
        {
            try
            {
                Stream stream = streamingRoleService.QueryRoleMatrix(ClientSession.GetUserContext().Site);
                ExcelExporter excelExporter = new ExcelExporter();
                excelExporter.Export(stream);
            }
            catch (Exception exception)
            {
                logger.Error("Error generating role matrix: " + exception);
            }
        }
    }
}
