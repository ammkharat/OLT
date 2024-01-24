using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN6HistoryDao : AbstractManagedDao, IFormGN6HistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormGN6HistoryById";
        private const string INSERT = "InsertFormGN6History";

        private readonly IUserDao userDao;

        public FormGN6HistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormGN6History> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<FormGN6History>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(FormGN6History history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(FormGN6History history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("JobDescription", history.JobDescription);
            command.AddParameter("ReasonForCriticalLift", history.ReasonForCriticalLift);

            command.AddParameter("Section1NotApplicableToJob", history.Section1NotApplicableToJob);
            command.AddParameter("Section1PlainTextContent", history.Section1PlainTextContent);
            command.AddParameter("Section2NotApplicableToJob", history.Section2NotApplicableToJob);
            command.AddParameter("Section2PlainTextContent", history.Section2PlainTextContent);
            command.AddParameter("Section3NotApplicableToJob", history.Section3NotApplicableToJob);
            command.AddParameter("Section3PlainTextContent", history.Section3PlainTextContent);
            command.AddParameter("Section4NotApplicableToJob", history.Section4NotApplicableToJob);
            command.AddParameter("Section4PlainTextContent", history.Section4PlainTextContent);
            command.AddParameter("Section5NotApplicableToJob", history.Section5NotApplicableToJob);
            command.AddParameter("Section5PlainTextContent", history.Section5PlainTextContent);
            command.AddParameter("Section6NotApplicableToJob", history.Section6NotApplicableToJob);
            command.AddParameter("Section6PlainTextContent", history.Section6PlainTextContent);

            command.AddParameter("Approvals", history.Approvals);
            command.AddParameter("FunctionalLocations", history.FunctionalLocations);

            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("ClosedDateTime", history.ClosedDateTime);

            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("PlainTextPreJobMeetingSignatures", history.PlainTextPreJobMeetingSignatures);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
        }

        private FormGN6History PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);

            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string approvals = reader.Get<string>("Approvals");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            string jobDescription = reader.Get<string>("JobDescription");
            string reasonForCriticalLift = reader.Get<string>("ReasonForCriticalLift");

            bool section1NotApplicableToJob = reader.Get<bool>("Section1NotApplicableToJob");
            string section1PlainTextContent = reader.Get<string>("Section1PlainTextContent");
            bool section2NotApplicableToJob = reader.Get<bool>("Section2NotApplicableToJob");
            string section2PlainTextContent = reader.Get<string>("Section2PlainTextContent");
            bool section3NotApplicableToJob = reader.Get<bool>("Section3NotApplicableToJob");
            string section3PlainTextContent = reader.Get<string>("Section3PlainTextContent");
            bool section4NotApplicableToJob = reader.Get<bool>("Section4NotApplicableToJob");
            string section4PlainTextContent = reader.Get<string>("Section4PlainTextContent");
            bool section5NotApplicableToJob = reader.Get<bool>("Section5NotApplicableToJob");
            string section5PlainTextContent = reader.Get<string>("Section5PlainTextContent");
            bool section6NotApplicableToJob = reader.Get<bool>("Section6NotApplicableToJob");
            string section6PlainTextContent = reader.Get<string>("Section6PlainTextContent");            

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            string documentLinks = reader.Get<string>("DocumentLinks");
            string plainTextPreJobMeetingSignatures = reader.Get<string>("PlainTextPreJobMeetingSignatures");

            return new FormGN6History(id, formStatus, functionalLocations, validFromDateTime, validToDateTime, approvals, lastModifiedBy, lastModifiedDateTime, approvedDateTime, closedDateTime, jobDescription, reasonForCriticalLift, section1PlainTextContent, section1NotApplicableToJob, section2PlainTextContent, section2NotApplicableToJob, section3PlainTextContent, section3NotApplicableToJob, section4PlainTextContent, section4NotApplicableToJob, section5PlainTextContent, section5NotApplicableToJob, section6PlainTextContent, section6NotApplicableToJob, documentLinks, plainTextPreJobMeetingSignatures);
        }
    }
}
