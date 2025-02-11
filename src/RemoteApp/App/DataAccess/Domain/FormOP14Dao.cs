﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.XtraRichEdit.API.Word;


namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormOP14Dao : AbstractManagedDao, IFormOP14Dao
    {
        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IDocumentLinkDao documentLinkDao;

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormOP14ById";
        private const string QUERY_BY_ID_AndSiteId_STORED_PROCEDURE = "QueryFormOP14ByIdAndSiteId";    //ayman generic forms
        private const string INSERT_STORED_PROCEDURE = "InsertFormOP14";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormOP14";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertFormOP14FunctionalLocation";
        private const string DELETE_FORM_FUNCTIONAL_LOCATION = "DeleteFormOP14FunctionalLocationsByFormOP14Id";
        private const string INSERT_FORM_APPROVAL = "InsertFormOP14Approval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormOP14Approval";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormOP14";
        private const string UPDATE_EMAIL_STORED_PROCEDURE = "UpdateFormOP14EMail";//Added by ppanigrahi
        private const string QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_10_DAYS =
            "QueryAllFormOP14ThatAreApprovedAndOutOfServiceForMoreThan10Days";
        
        /*RITM0265746 - Sarnia CSD marked as read  start*/
        private const string INSERT_MarkAs_Read_STORED_PROCEDURE = "InsertFormOP14Read";
        private const string QUERY_USER_ALREADY_MARKED_Form_OP14_AS_READ = "QueryUserMarkedFormOP14AsRead";
        private const string QUERY_MARK_AS_READ_FORM_OP14_REPORT = "QueryFormOP14MarkedAsReadReport";
        /*RITM0265746 - Sarnia CSD marked as read  start*/
        public FormOP14Dao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();

        }

        public FormOP14 Insert(FormOP14 form)    //ayman generic forms
        {
            
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, form);
            InsertApprovals(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            return form;
        }


        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormOP14Id);
        }
        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormOP14);
        }

        // ayman generic forms
        public FormOP14 QueryByIdAndSiteId(long id, long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormOP14>(id,siteid, PopulateInstance, QUERY_BY_ID_AndSiteId_STORED_PROCEDURE);
        }

        public FormOP14 QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormOP14>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<FormOP14> QueryAllThatAreApprovedAndAreMoreThan10DaysOutOfService(DateTime now)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Now", now);
            return command.QueryForListResult<FormOP14>(PopulateInstance,
                QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_10_DAYS);
        }
      

        public void Update(FormOP14 form)
        {
            SqlCommand command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateFunctionalLocations(command, form);
            
            UpdateApprovals(command, form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
        }

        public void Remove(FormOP14 form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private void AddUpdateParameters(FormOP14 form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private void UpdateApprovals(SqlCommand command, FormOP14 form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = UPDATE_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@Id", approval.Id);
                    command.AddParameter("@ApprovedByUserId",
                        approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateFunctionalLocations(SqlCommand command, FormOP14 form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@FormOP14Id", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void InsertApprovals(SqlCommand command, FormOP14 form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormOP14Id", form.Id);
                    command.AddParameter("@Approver", approval.Approver);
                    command.AddParameter("@ApprovedByUserId",
                        approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@DisplayOrder", approval.DisplayOrder);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                    approval.Id = long.Parse(idParameter.Value.ToString());
                }
            }
        }

        private void InsertFunctionalLocations(SqlCommand command, FormOP14 form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@FormOP14Id", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddInsertParameters(FormOP14 form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
          
        }

        private void SetCommonAttributes(FormOP14 form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@Content", form.Content);
            command.AddParameter("@PlainTextContent", form.PlainTextContent);
            command.AddParameter("@IsTheCSDForAPressureSafetyValve", form.IsTheCSDForAPressureSafetyValve);
            command.AddParameter("@CriticalSystemDefeated", form.CriticalSystemDefeated);
            command.AddParameter("@DepartmentId", form.Department.Id);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@siteid", form.SiteId);       //ayman generic forms
            command.AddParameter("@IsSCADAsupportRequired", form.IsSCADASupport);//DMND0010261-SELC CSD EdmontonPipeline
        }

        private FormOP14 PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            List<FunctionalLocation> functionalLocations = flocDao.QueryByFormOP14Id(id);
            List<FormApproval> approvals = formApprovalDao.QueryByFormOP14Id(id);
            List<DocumentLink> documentLinks = documentLinkDao.QueryByFormOP14Id(id);


            string content = reader.Get<string>("Content");
            string plainTextContent = reader.Get<string>("PlainTextContent");
          

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            bool isTheCSDForAPressureSafetyValve = reader.Get<bool>("IsTheCSDForAPressureSafetyValve");
            string criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");
            int departmentId = reader.Get<int>("DepartmentId");
            FormOP14Department department = FormOP14Department.GetById(departmentId);

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            long siteId = reader.Get<long>("siteid");
            
            FormOP14 form = new FormOP14(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime,siteId);
            form.FunctionalLocations = functionalLocations;
            form.Approvals = approvals;
            form.LastModifiedBy = lastModifiedBy;
            form.DocumentLinks = documentLinks;
            form.LastModifiedDateTime = lastModifiedDateTime;
            form.ApprovedDateTime = approvedDateTime;
            form.ClosedDateTime = closedDateTime;
            form.Content = content;
            form.PlainTextContent = plainTextContent;
            form.Department = department;
            form.IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve;
            form.CriticalSystemDefeated = criticalSystemDefeated;

            //DMND0010261-SELC CSD EdmontonPipeline
            if(ColumnExists(reader,"IsSCADAsupportRequired"))
            {
            if(reader.Get<bool>("IsSCADAsupportRequired")!=null)
            {
                form.IsSCADASupport = reader.Get<bool>("IsSCADAsupportRequired");
            }
            }
             //end DMND0010261-SELC CSD EdmontonPipeline
            return form;
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

        /*RITM0265746 - Sarnia CSD marked as read  start*/
        public List<ItemReadBy> UserMarkedFormOp14AsRead(long formOp14Id, long? userId, long shiftId )
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormOP14Id", formOp14Id);
            command.AddParameter("@UserId", userId);
             command.AddParameter("@ShiftId", shiftId);
            return command.QueryForListResult<ItemReadBy>(PopulateInstanceForMarkAsRead, QUERY_USER_ALREADY_MARKED_Form_OP14_AS_READ);
        }

        //Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD

        public List<ItemReadBy> UserMarkedFormOp14AsReadOnPriorityPage(long formOp14Id, long? userId, long shiftId, Date date)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormOP14Id", formOp14Id);
            command.AddParameter("@UserId", userId);
            command.AddParameter("@ShiftId", shiftId);
            command.AddParameter("@CurrentDate", date.ToString());
            return command.QueryForListResult<ItemReadBy>(PopulateInstanceForMarkAsRead, "QueryUserMarkedFormOP14AsReadOnPriorityPage");
        }


        public FormOP14Read InsertFormOp14MarkAsRead(long id, long userId, DateTime datetimenow, long shiftId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@FormOP14Id", id);
            command.AddParameter("@DateTime", datetimenow);
            command.AddParameter("@ShiftId", shiftId);
            command.Insert(INSERT_MarkAs_Read_STORED_PROCEDURE);
            return new FormOP14Read(id, userId, datetimenow);
        }

       private static ItemReadBy PopulateInstanceForMarkAsRead(SqlDataReader reader)
        {
            string firstName = reader.Get<string>("Firstname");
            string lastName = reader.Get<string>("Lastname");
            string userName = reader.Get<string>("Username");
            DateTime dateTime = reader.Get<DateTime>("DateTime");
            return new ItemReadBy(User.ToFullNameWithUserName(lastName, firstName, userName),
                dateTime);
        }

       public List<CSDMarkAsReadReportItem> GetFormOP14MarkedAsReadReport(DateRange startendDate, long siteId)
       {
           SqlCommand command = ManagedCommand;
           command.AddParameter("@StartDate", startendDate.SqlFriendlyStart);
           command.AddParameter("@EndDate", startendDate.SqlFriendlyEnd);
           command.AddParameter("@siteid", siteId);
           return command.QueryForListResult<CSDMarkAsReadReportItem>(PopulateInstanceForMarkAsReadReport, QUERY_MARK_AS_READ_FORM_OP14_REPORT);
       }
       private static CSDMarkAsReadReportItem PopulateInstanceForMarkAsReadReport(SqlDataReader reader)
       {
           string firstName = reader.Get<string>("Firstname");
           string lastName = reader.Get<string>("Lastname");
           string userName = reader.Get<string>("Username");
           DateTime dateTime = reader.Get<DateTime>("DateTime");
           string shiftName = reader.Get<string>("Name");
           Date theDates = new Date(reader.Get<DateTime>("theDate"));
           string csdDesc = reader.Get<string>("CriticalSystemDefeated");
           return new CSDMarkAsReadReportItem(User.ToFullNameWithUserName(lastName, firstName, userName),
               dateTime,csdDesc, theDates,shiftName);

       }

        /*RITM0265746 - Sarnia CSD marked as read End*/
       //Addded by ppanigrahi
       public void UpdateEmail(long Id, long siteId, long lastModifiedByUserId, int formStatusId)
       {
           SqlCommand command = ManagedCommand;
           command.AddParameter("@id", Id);
           command.AddParameter("@siteId", siteId);
           command.AddParameter("@LastModifiedByUserId", lastModifiedByUserId);
           command.AddParameter("@FormStatusId", formStatusId);
           command.Update(UPDATE_EMAIL_STORED_PROCEDURE);

       }
       //Added by ppanigrahi
       public long QueryByUserName(string username)
       {
           SqlCommand command = ManagedCommand;
           command.CommandText = "SelectUserID";
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.AddWithValue("@UserName", username);
           SqlDataReader dr = command.ExecuteReader();

           if (dr.Read())
           {

               long id = dr.Get<long>("Id");

               dr.Close();

               return id;

           }
           else
           {
               dr.Close();
               return 0;
           }



       }
        //Added by ppanigrahi
       //Added by ppanigrahi
       public long QueryByFormOp14ApprovalId(long? formOp14Id, string approver)
       {
           SqlCommand command = ManagedCommand;
           command.CommandText = "QueryByFormOP14ApprovalID";
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.AddWithValue("@FormOP14Id", formOp14Id);
           command.Parameters.AddWithValue("@Approver", approver);
           SqlDataReader dr = command.ExecuteReader();

           if (dr.Read())
           {

               long id = dr.Get<long>("Id");

               dr.Close();

               return id;

           }
           else
           {
               dr.Close();
               return 0;
           }



       }
       //Added by ppanigrahi
       public int UpdaterRest(long Id, int FormStatusId, string CriticalSystemDefeated, long LastModifiedByUserId, long siteid, long ApproveId, long ApprovedByUserId, string ApprovalDateTime, int ShouldBeEnabledBehaviourId, bool Enabled)
       {
           int success = 1;
           string LastModifiedDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

           //string connStr = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();


           //_connection.Open();
           //string connStr = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
           SqlCommand cmd = ManagedCommand;

           cmd.CommandText = "UpdateFormOP14EMail";
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Id", Id);
           cmd.Parameters.AddWithValue("@FormStatusId", FormStatusId);

           cmd.Parameters.AddWithValue("@CriticalSystemDefeated", CriticalSystemDefeated);


           cmd.Parameters.AddWithValue("@LastModifiedByUserId", LastModifiedByUserId);
           cmd.Parameters.AddWithValue("@LastModifiedDateTime", LastModifiedDateTime);
           cmd.Parameters.AddWithValue("@siteid", siteid);

           success = cmd.ExecuteNonQuery();

           UpdateApproval(ApproveId, ApprovedByUserId, ApprovalDateTime, ShouldBeEnabledBehaviourId, Enabled);

           return success;
       }
       //Added by ppanigrahi
       private void UpdateApproval(long Id, long ApprovedByUserId, string ApprovalDateTime, int ShouldBeEnabledBehaviourId, bool Enabled)
       {


           SqlCommand cmd = ManagedCommand;

           cmd.CommandText = "UpdateFormOP14Approval";
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Id", Id);
           cmd.Parameters.AddWithValue("@ApprovedByUserId", ApprovedByUserId);
           cmd.Parameters.AddWithValue("@ApprovalDateTime", ApprovalDateTime);
           cmd.Parameters.AddWithValue("@ShouldBeEnabledBehaviourId", ShouldBeEnabledBehaviourId);
           cmd.Parameters.AddWithValue("@Enabled", Enabled);

           int success = cmd.ExecuteNonQuery();





       }

    }
}