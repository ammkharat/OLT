using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SapAutoImportConfigurationDao : AbstractManagedDao, ISapAutoImportConfigurationDao
    {
        private readonly IScheduleDao scheduleDao;

        public SapAutoImportConfigurationDao()
        {
            scheduleDao = DaoRegistry.GetDao<IScheduleDao>();
        }

        public SapAutoImportConfiguration QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("SiteId", siteId);

            return command.QueryForSingleResult<SapAutoImportConfiguration>(PopulateInstance , "QuerySapAutoImportConfigurationBySiteId");            
        }

        public void Update(SapAutoImportConfiguration configuration)
        {
            if (configuration.Schedule.Id != null)
            {
                scheduleDao.Update(configuration.Schedule);    
            }
            else
            {
                scheduleDao.Insert(configuration.Schedule);

                SqlCommand command = ManagedCommand;
                command.AddParameter("SiteId", configuration.SiteId);                
                command.Update(configuration, AddInsertAndUpdateParameters, "UpdateSapAutoImportConfiguration");
            }                                                                        
        }

        public void Disable(SapAutoImportConfiguration configuration)
        {
            if (configuration.Schedule != null)
            {
                scheduleDao.Delete(configuration.Schedule);                
                // In this method, I chose to not set the configuration's schedule to null. It gets nulled out in the DB, but the schedule has to stay intact so that there is a
                // real schedule for the 'remove' events caught by the scheduler.
            }

            SqlCommand command = ManagedCommand;
            command.AddParameter("SiteId", configuration.SiteId);
            command.Update(configuration, AddInsertAndUpdateParametersToDisable, "UpdateSapAutoImportConfiguration");
        }

        private void AddInsertAndUpdateParameters(SapAutoImportConfiguration configuration, SqlCommand command)
        {
            if (configuration.Schedule != null)
            {
                command.AddParameter("ScheduleId", configuration.Schedule.IdValue);
            }
            else
            {
                command.AddParameter("ScheduleId", null);
            }            
        }

        private void AddInsertAndUpdateParametersToDisable(SapAutoImportConfiguration configuration, SqlCommand command)
        {            
            command.AddParameter("ScheduleId", null);                       
        }

        private SapAutoImportConfiguration PopulateInstance(SqlDataReader reader)
        {
            long siteId = reader.Get<long>("SiteId");
            long? scheduleId = reader.Get<long?>("ScheduleId");

            RecurringDailySchedule schedule = null;

            if (scheduleId != null)
            {
                schedule = (RecurringDailySchedule) scheduleDao.QueryById(scheduleId.Value);
            }

            return new SapAutoImportConfiguration(siteId, schedule);
        }
    }

}
