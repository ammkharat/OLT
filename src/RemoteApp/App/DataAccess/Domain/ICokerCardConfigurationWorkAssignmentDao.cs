using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICokerCardConfigurationWorkAssignmentDao : IDao
    {
        // #3003 - Move the Configuration Id inside of the CokerCardConfigurationDrum object and find a way to clear the list cache by configuration id in order to cache insert and update
        List<CokerCardConfigurationWorkAssignment> QueryByConfigurationId(long configurationId);
        void Insert(CokerCardConfigurationWorkAssignment configurationWorkAssignment);
        void DeleteByConfigurationId(long configurationId);
    }
}
