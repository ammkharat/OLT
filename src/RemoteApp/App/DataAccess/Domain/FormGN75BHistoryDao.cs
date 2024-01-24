using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN75BHistoryDao : AbstractManagedDao, IFormGN75BHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormGN75BHistoryById";
        private const string INSERT = "InsertFormGN75BHistory";

        private readonly IUserDao userDao;

        public FormGN75BHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        //Aarti INC0548411
        public List<FormGN75BHistory> GetById(long id, long SiteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            command.AddParameter("@SiteId", SiteId);
            return command.QueryForListResult<FormGN75BHistory>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }
        //Aarti
        public void Insert(FormGN75BHistory history, long SiteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("SiteId", SiteId);
            command.Insert(history, AddInsertParameters, INSERT);
        }

   
        private void AddInsertParameters(FormGN75BHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);
            command.AddParameter("FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("Location", history.Location);
            
            command.AddParameter("BlindsRequired", history.BlindsRequired);
            command.AddParameter("EquipmentType", history.EquipmentType);
            command.AddParameter("LockBoxLocation", history.LockBoxLocation);
            command.AddParameter("LockBoxNumber", history.LockBoxNumber);

            command.AddParameter("ClosedDateTime", history.ClosedDateTime);

            command.AddParameter("Isolations", history.Isolations);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);

            byte[] schematicImage = history.SchematicImage;
            SqlParameter imageParameter = schematicImage == null
                ? new SqlParameter("@SchematicImage", SqlDbType.VarBinary, 0) { Value = null }
                : new SqlParameter("@SchematicImage", SqlDbType.VarBinary, schematicImage.Length) { Value = schematicImage };

           // command.AddParameter("SiteId",history.); //Aarti INC0548411
            command.Parameters.Add(imageParameter);
        }

        private FormGN75BHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            string functionalLocation = reader.Get<string>("FunctionalLocation");
            string location = reader.Get<string>("Location");
            string documentLinks = reader.Get<string>("DocumentLinks");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);

            bool blindsRequired = reader.Get<bool>("BlindsRequired");
            string equipmentType = reader.Get<string>("EquipmentType");
            string lockBoxNumber = reader.Get<string>("LockBoxNumber");
            string lockBoxLocation = reader.Get<string>("LockBoxLocation");

            string isolations = reader.Get<string>("Isolations");

            byte[] schematicImage = reader.Get<byte[]>("SchematicImage");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            return new FormGN75BHistory(id, functionalLocation, location, blindsRequired, equipmentType, lockBoxNumber, lockBoxLocation, isolations, documentLinks, closedDateTime, formStatus, schematicImage, lastModifiedBy, lastModifiedDateTime);
        }

    }
}