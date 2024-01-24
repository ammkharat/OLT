using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PriorityPageSectionConfigurationService : IPriorityPageSectionConfigurationService
    {
        private readonly IPriorityPageSectionConfigurationDao priorityPageSectionConfigurationDao;

        public PriorityPageSectionConfigurationService()
        {
            priorityPageSectionConfigurationDao = DaoRegistry.GetDao<IPriorityPageSectionConfigurationDao>();
        }

        public List<PriorityPageSectionConfiguration> QuerySectionConfigurations(long userId)
        {
            return priorityPageSectionConfigurationDao.QueryByUserId(userId);
        }

        public PriorityPageSectionConfiguration QueryBySectionKeyAndUserId(PriorityPageSectionKey priorityPageSectionKey, long userId)
        {
            return priorityPageSectionConfigurationDao.QueryBySectionKeyAndUserId(priorityPageSectionKey, userId);
        }

        public void Save(PriorityPageSectionConfiguration priorityPageSectionConfiguration)
        {
            if (!priorityPageSectionConfiguration.IsInDatabase())
            {
                priorityPageSectionConfigurationDao.Insert(priorityPageSectionConfiguration);
            }
            else
            {
                priorityPageSectionConfigurationDao.Update(priorityPageSectionConfiguration);
            }            
        }

        public void DeleteConfiguration(long configurationId)
        {
            priorityPageSectionConfigurationDao.Delete(configurationId);
        }
    }
}
