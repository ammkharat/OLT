using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftHandoverConfigurationWorkAssignmentDao : IDao
    {
        ShiftHandoverConfigurationWorkAssignment Insert(
            ShiftHandoverConfigurationWorkAssignment shiftHandoverConfigurationWorkAssignment);
        List<ShiftHandoverConfigurationWorkAssignment> QueryByShiftHandoverConfigurationId(long configurationId);
        void DeleteByShiftHandoverConfigurationId(long? configurationId);
    }
}
