using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IPriorityPageSectionConfigurationService
    {
        [OperationContract]
        List<PriorityPageSectionConfiguration> QuerySectionConfigurations(long siteId);

        [OperationContract]
        PriorityPageSectionConfiguration QueryBySectionKeyAndUserId(PriorityPageSectionKey priorityPageSectionKey,
            long userId);

        [OperationContract]
        void Save(PriorityPageSectionConfiguration priorityPageSectionConfiguration);

        [OperationContract]
        void DeleteConfiguration(long configurationId);
    }
}