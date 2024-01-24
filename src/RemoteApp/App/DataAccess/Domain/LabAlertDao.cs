using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LabAlertDao : AbstractManagedDao, ILabAlertDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryLabAlertByID";
        private const string INSERT_STORED_PROCEDURE = "InsertLabAlert";
        private const string UPDATE_STATUS_STORED_PROCEDURE = "UpdateLabAlertStatus";

        private readonly ILabAlertResponseDao responseDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ITagDao tagDao;
        private readonly IUserDao userDao;

        public LabAlertDao()
        {
            responseDao = DaoRegistry.GetDao<ILabAlertResponseDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();            
        }

        public LabAlert QueryById(long id)
        {
            return ManagedCommand.QueryById(id, (PopulateInstance<LabAlert>) PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public LabAlert Insert(LabAlert alert)
        {
            SqlCommand command = ManagedCommand;
            
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(alert, AddInsertParameters, INSERT_STORED_PROCEDURE);
            alert.Id = (long?)idParameter.Value;

            return alert;
        }

        public void UpdateStatusAndResponses(LabAlert alert)
        {
            SqlCommand command = ManagedCommand;

            command.Update(alert, AddUpdateParameters, UPDATE_STATUS_STORED_PROCEDURE);

            foreach (LabAlertResponse response in alert.Responses)
            {
                if (!response.IsInDatabase())
                {
                    responseDao.Insert(response);
                }
            }
        }

        private static void AddUpdateParameters(LabAlert alert, SqlCommand command)
        {
            command.AddParameter("@Id", alert.Id);
            command.AddParameter("@LastModifiedByUserId", alert.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", alert.LastModifiedDate);
            command.AddParameter("@LabAlertStatusId", alert.Status.Id);
        }

        private static void AddInsertParameters(LabAlert alert, SqlCommand command)
        {
            command.AddParameter("@Name", alert.Name);            
            command.AddParameter("@Description", alert.Description);          
            command.AddParameter("@FunctionalLocationId", alert.FunctionalLocation.IdValue);            
            command.AddParameter("@TagId", alert.TagInfo.IdValue);
            command.AddParameter("@MinimumNumberOfSamples", alert.MinimumNumberOfSamples);
            command.AddParameter("@ActualNumberOfSamples", alert.ActualNumberOfSamples);

            command.AddParameter("@LabAlertTagQueryRangeFromDateTime", alert.LabAlertTagQueryRangeFromDateTime);
            command.AddParameter("@LabAlertTagQueryRangeToDateTime", alert.LabAlertTagQueryRangeToDateTime);                        
            
            command.AddParameter("@ScheduleDescription", alert.ScheduleDescription);                        
            command.AddParameter("@LabAlertDefinitionId", alert.LabAlertDefinitionId);

            command.AddParameter("@LastModifiedByUserId", alert.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", alert.LastModifiedDate);
            command.AddParameter("@CreatedDateTime", alert.CreatedDateTime);

            command.AddParameter("@LabAlertStatusId", alert.Status.Id);
        }

        private LabAlert PopulateInstance(SqlDataReader reader)
        {
            LabAlert alert = new LabAlert();

            alert.Id = reader.Get<long?>("Id");
            alert.Name = reader.Get<string>("Name");
            alert.Description = reader.Get<string>("Description");
            alert.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            alert.TagInfo = tagDao.QueryById(reader.Get<long>("TagId"));
            alert.MinimumNumberOfSamples = reader.Get<int>("MinimumNumberOfSamples");
            alert.ActualNumberOfSamples = reader.Get<int>("ActualNumberOfSamples");
            alert.LabAlertTagQueryRangeFromDateTime = reader.Get<DateTime>("LabAlertTagQueryRangeFromDateTime");
            alert.LabAlertTagQueryRangeToDateTime = reader.Get<DateTime>("LabAlertTagQueryRangeToDateTime");
            alert.ScheduleDescription = reader.Get<string>("ScheduleDescription");
            alert.LabAlertDefinitionId = reader.Get<long>("LabAlertDefinitionId");
            alert.CreatedDateTime = reader.Get<DateTime>("CreatedDateTime");            
            alert.LastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            alert.LastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            alert.Status = LabAlertStatus.Get(reader.Get<long>("LabAlertStatusId"));

            alert.Responses = responseDao.QueryByLabAlertId(alert.IdValue);
                        
            return alert;
        }
    }

}
