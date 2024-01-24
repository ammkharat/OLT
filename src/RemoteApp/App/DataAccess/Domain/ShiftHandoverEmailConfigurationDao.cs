using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverEmailConfigurationDao : AbstractManagedDao, IShiftHandoverEmailConfigurationDao
    {
        private readonly IShiftPatternDao shiftDao;
        private readonly IWorkAssignmentDao workAssignmentDao;
        private readonly ISiteDao siteDao;
        private readonly IScheduleDao scheduleDao;

        public ShiftHandoverEmailConfigurationDao()
        {
            shiftDao = DaoRegistry.GetDao<IShiftPatternDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            scheduleDao = DaoRegistry.GetDao<IScheduleDao>();
        }

        public List<ShiftHandoverEmailConfiguration> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("SiteId", siteId);

            return command.QueryForListResult<ShiftHandoverEmailConfiguration>(PopulateInstance , "QueryShiftHandoverEmailConfigurationBySiteId");
        }

        public ShiftHandoverEmailConfiguration QueryById(long configurationId)
        {
            return ManagedCommand.QueryById(configurationId, (PopulateInstance<ShiftHandoverEmailConfiguration>)PopulateInstance, "QueryShiftHandoverEmailConfigurationById");
        }

        public void Insert(ShiftHandoverEmailConfiguration shiftHandoverEmailConfiguration)
        {
            SqlCommand command = ManagedCommand;
            scheduleDao.Insert(shiftHandoverEmailConfiguration.Schedule);
            long id = command.InsertAndReturnId(shiftHandoverEmailConfiguration, AddInsertParameters, "InsertShiftHandoverEmailConfiguration");
            shiftHandoverEmailConfiguration.Id = id;

            InsertWorkAssignmentReferences(shiftHandoverEmailConfiguration);
        }

        public void Update(ShiftHandoverEmailConfiguration configuration)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", configuration.IdValue);
            command.Update(configuration, AddInsertAndUpdateParameters, "UpdateShiftHandoverEmailConfiguration");

            command = ManagedCommand;
            command.AddParameter("ConfigurationId", configuration.IdValue);
            command.ExecuteNonQuery("DeleteShiftHandoverEmailConfigurationWorkAssignments");     

            InsertWorkAssignmentReferences(configuration);

            scheduleDao.Update(configuration.Schedule);            
        }

        public void Delete(ShiftHandoverEmailConfiguration emailConfiguration)
        {
            SqlCommand command = ManagedCommand;

            command.Parameters.Clear();
            command.AddParameter("Id", emailConfiguration.IdValue);
            command.ExecuteNonQuery("DeleteShiftHandoverEmailConfiguration");     
        }

        private void InsertWorkAssignmentReferences(ShiftHandoverEmailConfiguration shiftHandoverEmailConfiguration)
        {            
            foreach (WorkAssignment workAssignment in shiftHandoverEmailConfiguration.WorkAssignments)
            {
                SqlCommand command = ManagedCommand;
                command.AddParameter("ShiftHandoverEmailConfigurationId", shiftHandoverEmailConfiguration.IdValue);
                command.AddParameter("WorkAssignmentId", workAssignment.IdValue);
                command.Insert("InsertShiftHandoverEmailConfigurationWorkAssignment");
            }
        }

        private void AddInsertParameters(ShiftHandoverEmailConfiguration shiftHandoverEmailConfiguration, SqlCommand command)
        {
            AddInsertAndUpdateParameters(shiftHandoverEmailConfiguration, command);
            command.AddParameter("ScheduleId", shiftHandoverEmailConfiguration.Schedule.IdValue);
            command.AddParameter("SiteId", shiftHandoverEmailConfiguration.Site.IdValue);            
        }

        private void AddInsertAndUpdateParameters(ShiftHandoverEmailConfiguration shiftHandoverEmailConfiguration, SqlCommand command)
        {            
            command.AddParameter("ShiftId", shiftHandoverEmailConfiguration.ShiftPattern.IdValue);
            command.AddParameter("EmailAddresses", shiftHandoverEmailConfiguration.EmailAddressesAsDelimitedString);            
        }

        private ShiftHandoverEmailConfiguration PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long shiftId = reader.Get<long>("ShiftId");
            string delimitedListOfEmails = reader.Get<string>("EmailAddresses");
            long siteId = reader.Get<long>("SiteId");
            long scheduleId = reader.Get<long>("ScheduleId");

            ShiftPattern shiftPattern = shiftDao.QueryById(shiftId);
            List<EmailAddress> emailAddresses = EmailAddress.ConvertDelimitedListToEmailAddresses(delimitedListOfEmails);
            List<WorkAssignment> workAssignments = workAssignmentDao.QueryByShiftHandoverEmailConfigurationId(id);
            Site site = siteDao.QueryById(siteId);

            RecurringDailySchedule schedule = (RecurringDailySchedule) scheduleDao.QueryById(scheduleId);
            return new ShiftHandoverEmailConfiguration(id, shiftPattern, emailAddresses, workAssignments, site, schedule);
        }
    }
}
