﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN7HistoryDao : AbstractManagedDao, IFormGN7HistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormGN7HistoryById";
        private const string INSERT = "InsertFormGN7History";

        private readonly IUserDao userDao;

        public FormGN7HistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormGN7History> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<FormGN7History>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(FormGN7History history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(FormGN7History history, SqlCommand command)
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

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
        }

        private FormGN7History PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);

            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string approvals = reader.Get<string>("Approvals");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            string plainTextContent = reader.Get<string>("PlainTextContent");
            string documentLinks = reader.Get<string>("DocumentLinks");

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            FormGN7History history = new FormGN7History(id, formStatus, functionalLocations, plainTextContent, validFromDateTime, validToDateTime, approvals, lastModifiedBy, lastModifiedDateTime, approvedDateTime, closedDateTime,documentLinks);

            return history;
        }
    }
}