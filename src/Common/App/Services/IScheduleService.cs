using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        void Update(ISchedule schedule);
    }
}