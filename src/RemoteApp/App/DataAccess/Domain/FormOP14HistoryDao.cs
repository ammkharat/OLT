using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using System.Data;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormOP14HistoryDao : AbstractManagedDao, IFormOP14HistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormOP14HistoryById";
        private const string INSERT = "InsertFormOP14History";

        private readonly IUserDao userDao;

        public FormOP14HistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormOP14History> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<FormOP14History>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(FormOP14History history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(FormOP14History history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("PlainTextContent", history.PlainTextContent);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("Approvals", history.Approvals);
            command.AddParameter("FunctionalLocations", history.FunctionalLocations);

            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("ClosedDateTime", history.ClosedDateTime);

            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("IsTheCSDForAPressureSafetyValve", history.IsTheCSDForAPressureSafetyValve);
            command.AddParameter("CriticalSystemDefeated", history.CriticalSystemDefeated);
            command.AddParameter("DepartmentId", history.Department.Id);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
            //DMND0010261-SELC CSD EdmontonPipeline
            command.AddParameter("IsSCADAsupportRequired", history.IsSCADASupport);
        }

        private FormOP14History PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);

            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string approvals = reader.Get<string>("Approvals");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            string plainTextContent = reader.Get<string>("PlainTextContent");

            bool isTheCSDForAPressureSafetyValve = reader.Get<bool>("IsTheCSDForAPressureSafetyValve");
            string criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");

            int departmentId = reader.Get<int>("DepartmentId");
            FormOP14Department department = FormOP14Department.GetById(departmentId);

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");
            string documentLinks = reader.Get<string>("DocumentLinks");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            FormOP14History objFormOP14History = new FormOP14History(id, formStatus, functionalLocations, plainTextContent, validFromDateTime,
               validToDateTime, approvals, lastModifiedBy,
               lastModifiedDateTime, approvedDateTime, closedDateTime, department, isTheCSDForAPressureSafetyValve,
               criticalSystemDefeated, documentLinks);
            //DMND0010261-SELC CSD EdmontonPipeline
            if (ColumnExists(reader, "IsSCADAsupportRequired"))
            {
                if (reader.Get<bool>("IsSCADAsupportRequired") != null)
                {
                    objFormOP14History.IsSCADASupport = reader.Get<bool>("IsSCADAsupportRequired");
                }
            }
            //end DMND0010261-SELC CSD EdmontonPipeline

            return objFormOP14History;

        }

        //DMND0010261-SELC CSD EdmontonPipeline
        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}