using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormOilsandsTrainingItemDao : AbstractManagedDao, IFormOilsandsTrainingItemDao
    {
        private readonly ITrainingBlockDao trainingBlockDao;

        private const string QUERY_TRAINING_ITEMS_BY_FORM_ID = "QueryFormOilsandsTrainingItemByFormOilsandsTrainingId";
        private const string INSERT_STORED_PROCEDURE = "InsertFormOilsandsTrainingItem";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormOilsandsTrainingItem";
        private const string REMOVE_ALL_NOT_IN_LIST_STORED_PROCEDURE = "RemoveFormOilsandsTrainingItemsNotInTheList";

        public FormOilsandsTrainingItemDao()
        {
            trainingBlockDao = DaoRegistry.GetDao<ITrainingBlockDao>();
        }

        public void Insert(FormOilsandsTrainingItem trainingItem)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(trainingItem, AddInsertParameters, INSERT_STORED_PROCEDURE);
            trainingItem.Id = long.Parse(idParameter.Value.ToString());
        }

        public List<FormOilsandsTrainingItem> QueryByFormOilsandsTrainingId(long formOilsandsTrainingId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormOilsandsTrainingId", formOilsandsTrainingId);

            return command.QueryForListResult<FormOilsandsTrainingItem>(PopulateInstance, QUERY_TRAINING_ITEMS_BY_FORM_ID);
        }

        public void RemoveAllThatAreNotInThisList(long formOilsandsTrainingId, List<FormOilsandsTrainingItem> items)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormOilsandsTrainingId", formOilsandsTrainingId);
            command.AddParameter("@CsvItemIds", items.BuildIdStringFromList());
            command.ExecuteNonQuery(REMOVE_ALL_NOT_IN_LIST_STORED_PROCEDURE);
        }

        public void Update(FormOilsandsTrainingItem trainingItem)
        {
            SqlCommand command = ManagedCommand;
            command.Update(trainingItem, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private static void AddInsertParameters(FormOilsandsTrainingItem trainingItem, SqlCommand command)
        {
            command.AddParameter("@FormOilsandsTrainingId", trainingItem.FormOilsandsTrainingId);
            SetCommonAttributes(trainingItem, command);
        }

        private static void AddUpdateParameters(FormOilsandsTrainingItem trainingItem, SqlCommand command)
        {
            command.AddParameter("@Id", trainingItem.Id);
            SetCommonAttributes(trainingItem, command);
        }

        private static void SetCommonAttributes(FormOilsandsTrainingItem trainingItem, SqlCommand command)
        {
            command.AddParameter("@TrainingBlockId", trainingItem.TrainingBlock.IdValue);
            command.AddParameter("@Comments", trainingItem.Comments);
            command.AddParameter("@Supervisor", trainingItem.Supervisor);                   //ayman training form add column
            command.AddParameter("@BlockCompleted", trainingItem.BlockCompleted);
            command.AddParameter("@Hours", trainingItem.Hours);
        }

        private FormOilsandsTrainingItem PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            long formOilsandsTrainingId = reader.Get<long>("FormOilsandsTrainingId");

            long trainingBlockId = reader.Get<long>("TrainingBlockId");
            TrainingBlock trainingBlock = trainingBlockDao.QueryById(trainingBlockId);

            string comments = reader.Get<string>("Comments");
            string supervisor = reader.Get<string>("Supervisor");            //ayman training form add column
            bool blockCompleted = reader.Get<bool>("BlockCompleted");

            decimal hours = reader.Get<decimal>("Hours");

            return new FormOilsandsTrainingItem(id, formOilsandsTrainingId, trainingBlock, comments,supervisor, blockCompleted, hours);           //ayman training form add column
        }
    }
}