using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.Services.Excel;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class StreamingCokerCardService : IStreamingCokerCardService
    {
        private readonly ICokerCardService cokerCardService;

        public StreamingCokerCardService()
        {
            cokerCardService = new CokerCardService();
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream QueryCycleStepDTOsByConfigurationIdsAndDateRange(string configurationName, Date startOfRange, Date endOfRange)
        {
            List<CokerCardCycleStepEntryDTO> result = cokerCardService.QueryCycleStepDTOsByConfigurationIdsAndDateRange(configurationName, startOfRange, endOfRange);

            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream = excelStreamWriter.RenderExcelDataToMemoryStream(new CokerCardReportExcelDataRenderer(result));

            return stream;
        }
    }
}