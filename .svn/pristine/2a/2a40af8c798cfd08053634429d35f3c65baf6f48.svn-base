using System.IO;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IStreamingCokerCardService
    {
        [OperationContract]
        Stream QueryCycleStepDTOsByConfigurationIdsAndDateRange(string configurationName, Date startOfRange,
            Date endOfRange);
    }
}