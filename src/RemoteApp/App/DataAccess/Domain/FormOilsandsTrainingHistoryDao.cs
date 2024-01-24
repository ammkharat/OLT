using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormOilsandsTrainingHistoryDao : AbstractManagedDao, IFormOilsandsTrainingHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormOilsandsTrainingHistoryById";
        private const string INSERT = "InsertFormOilsandsTrainingHistory";

        private readonly IUserDao userDao;

        public FormOilsandsTrainingHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormOilsandsTrainingHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<FormOilsandsTrainingHistory>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(FormOilsandsTrainingHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private FormOilsandsTrainingHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);

            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string approvals = reader.Get<string>("Approvals");
            string trainingItems = reader.Get<string>("TrainingItems");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");

            Date trainingDate = reader.Get<DateTime>("TrainingDate").ToDate();
            string shiftName = reader.Get<string>("ShiftName");
            decimal totalHours = reader.Get<decimal>("TotalHours");
            string generalComments = reader.Get<string>("GeneralComments");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            FormOilsandsTrainingHistory history = new FormOilsandsTrainingHistory(id, formStatus, functionalLocations, approvals, trainingItems, approvedDateTime, trainingDate,
                shiftName, totalHours, generalComments, lastModifiedBy, lastModifiedDateTime);
            history.Id = id;
            history.FormStatus = formStatus;
            history.FunctionalLocations = functionalLocations;
            history.Approvals = approvals;
            history.TrainingItems = trainingItems;
            history.ApprovedDateTime = approvedDateTime;
            history.TrainingDate = trainingDate;
            history.ShiftName = shiftName;
            history.TotalHours = totalHours;
            history.GeneralComments = generalComments;
            history.LastModifiedBy = lastModifiedBy;
            history.LastModifiedDate = lastModifiedDateTime;

            return history;
        }

        private void AddInsertParameters(FormOilsandsTrainingHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("Approvals", history.Approvals);
            command.AddParameter("FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("TrainingItems", history.TrainingItems);

            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);

            command.AddParameter("TrainingDate", history.TrainingDate.ToDateTimeAtStartOfDay());
            command.AddParameter("ShiftName", history.ShiftName);
            command.AddParameter("TotalHours", history.TotalHours);
            command.AddParameter("GeneralComments", history.GeneralComments);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
        }
    }
}