using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleDao scheduleDao;

        public ScheduleService()
        {
            scheduleDao = DaoRegistry.GetDao<IScheduleDao>();
        }
     
        public void Update(ISchedule schedule)
        {
            scheduleDao.Update(schedule);
        }         
    }
}