using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IDirectiveConversionService
    {
        [OperationContract]
        void SwitchFromLogBasedDirectives(long siteId, int batchNumber, FunctionalLocation floc);

        [OperationContract]
        void ConvertStandingOrdersToDirectiveAndThenCancelThem(long siteId, FunctionalLocation floc);

        [OperationContract]
        void ChangeSiteConfigurationAndUpdateRolesToSupportNonLogBasedDirectives(long siteId);

        [OperationContract]
        int QueryNumberOfBatches(long siteId, FunctionalLocation floc);
    }
}