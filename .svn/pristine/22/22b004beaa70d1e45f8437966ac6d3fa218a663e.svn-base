using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftHandoverConfigurationDao : IDao
    {
        ShiftHandoverConfiguration QueryById(long id);
        List<ShiftHandoverConfiguration> QueryByWorkAssignment(long workAssignmentId);
        ShiftHandoverConfiguration Insert(ShiftHandoverConfiguration configuration);
        void Update(ShiftHandoverConfiguration shiftHandoverConfiguration, List<ShiftHandoverQuestion> deletedQuestions);
        void Delete(long configurationId);
    }
}
