using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPriorityPageSectionConfigurationDao : IDao
    {
        List<PriorityPageSectionConfiguration> QueryByUserId(long userId);
        PriorityPageSectionConfiguration QueryBySectionKeyAndUserId(PriorityPageSectionKey priorityPageSectionKey, long userId);        

        void Insert(PriorityPageSectionConfiguration sectionConfiguration);
        void Update(PriorityPageSectionConfiguration sectionConfiguration);
        void Delete(long configurationId);
    }
}
