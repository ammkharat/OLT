using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormApprovalDao : AbstractManagedDao, IFormApprovalDao
    {
        private const string QUERY_BY_FORM_GN7_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormGN7Id";
        private const string QUERY_BY_FORM_GN59_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormGN59Id";
        private const string QUERY_BY_FORM_OP14_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormOP14Id";
        private const string QUERY_BY_FORM_MONTREAL_CSD_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormMontrealCsdId";
        private const string QUERY_BY_FORM_LUBESCSD_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormLubesCsdId";


        private const string QUERY_BY_FORM_LUBES_ALARMDISABLE_ID_STORED_PROCEDURE =
            "QueryFormApprovalsByFormLubesAlarmDisableId";

        private const string QUERY_BY_FORM_GN24_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormGN24Id";
        private const string QUERY_BY_FORM_GN6_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormGN6Id";
        private const string QUERY_BY_FORM_GN75A_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormGN75AId";
        private const string QUERY_BY_FORM_GN75B_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormGN75BId";                  //ayman Sarnia eip DMND0008992
        private const string QUERY_BY_FORM_GN75BSarnia_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormGN75BSarniaId";                  //ayman Sarnia eip DMND0008992
        private const string QUERY_BY_OVERTIME_FORM_ID_STORED_PROCEDURE = "QueryFormApprovalsByOvertimeFormId";

        private const string QUERY_PLANNING_WORKSHEET_APPROVALS_BY_FORM_GN1_ID_STORED_PROCEDURE =
            "QueryPlanningWorksheetFormApprovalsByFormGN1Id";

        private const string QUERY_RESCUE_PLAN_APPROVALS_BY_FORM_GN1_ID_STORED_PROCEDURE =
            "QueryRescuePlanFormApprovalsByFormGN1Id";

        private const string QUERY_BY_FORM_OILSANDS_TRAINING_ID_STORED_PROCEDURE =
            "QueryFormApprovalsByFormOilsandsTrainingId";

        //generic template - mangesh
        private const string QUERY_BY_FORM_GenericTemplate_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormGenericTemplateId";
        private const string QUERY_BY_FORM_GenericTemplateApprover_STORED_PROCEDURE = "QueryFormGenericTemplateApproverListBySite";

        //RITM0268131 - mangesh
        private const string QUERY_BY_FORM_MUDS_TemporaryInstallation_ID_STORED_PROCEDURE = "QueryFormApprovalsByFormMudsTemporaryInstallationId";

        //ayman Sarnia eip DMND0008992
        private const string QUERY_BY_FORM_SarniaEipIssue_Approver_STORED_PROCEDURE = "QueryFormSarniaEipIssueApproverListBySite";

        //Added by ppanigrahi

        private const string QUERY_BY_FORM_SarniaCsd_Approver_STORED_PROCEDURE = "QueryFormSarniaCSDApproverListBySite";


        private readonly IUserDao userDao;

        public FormApprovalDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormApproval> QueryByFormGN7Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN7Id", id);

            return command.QueryForListResult(PopulateInstanceForGN7, QUERY_BY_FORM_GN7_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryByFormGN59Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN59Id", id);

            return command.QueryForListResult(PopulateInstanceForGN59, QUERY_BY_FORM_GN59_ID_STORED_PROCEDURE);
        }
        public List<FormApproval> QueryByFormOP14Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormOP14Id", id);

            return command.QueryForListResult(PopulateInstanceForOP14, QUERY_BY_FORM_OP14_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryByFormOP14EmailId(long Id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormOP14Id", Id);
            return command.QueryForListResult(PopulateInstanceForOP14Email, QUERY_BY_FORM_OP14_ID_STORED_PROCEDURE);
        
        }

        //generic template - mangesh
        public List<FormApproval> QueryByFormGenericTemplateId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGenericTemplateId", id);

            return command.QueryForListResult(PopulateInstanceForGenericTemplate, QUERY_BY_FORM_GenericTemplate_ID_STORED_PROCEDURE);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormApproval> QueryByFormSarniaEipIssueApprover(long siteid, long formtypeid, long plantid)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteid);
            command.AddParameter("@FormTypeID", formtypeid);
            command.AddParameter("@PlantID", plantid);

            return command.QueryForListResult(PopulateInstanceForGenericTemplate, QUERY_BY_FORM_SarniaEipIssue_Approver_STORED_PROCEDURE);
        }
        //Added by ppanigrahi
        public List<FormApproval> QueryByFormSarniaCsdApprover(long siteid, long formtypeid, long plantid)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteid);
            command.AddParameter("@FormTypeID", formtypeid);
            command.AddParameter("@PlantID", plantid);

            return command.QueryForListResult(PopulateInstanceForSarniaCsd, QUERY_BY_FORM_SarniaCsd_Approver_STORED_PROCEDURE);
        }

        public int Updatemailsentflag(long? Id, bool isMailSent)
        {
            SqlCommand command = ManagedCommand;
          //  SqlParameter prm = new SqlParameter("@Id");
           // SqlCommand command = ManagedCommand;
            command.CommandText = "UpdateEmailSentFlag";
            command.Parameters.Clear();
            command.AddParameter("@Id",Id);
            command.AddParameter("@isMailSent", isMailSent);
           int success= command.ExecuteNonQuery();
            return success;

        }

        public List<FormApproval> QueryByFormGenericTemplateApprover(long siteid, long formtypeid, long plantid)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteid);
            command.AddParameter("@FormTypeID", formtypeid);
            command.AddParameter("@PlantID", plantid);

            return command.QueryForListResult(PopulateInstanceForGenericTemplate, QUERY_BY_FORM_GenericTemplateApprover_STORED_PROCEDURE);
        }
        //---------------------------------

        public List<FormApproval> QueryByFormMontrealCsdId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormMontrealCsdId", id);

            return command.QueryForListResult(PopulateInstanceForMontrealCsd,
                QUERY_BY_FORM_MONTREAL_CSD_ID_STORED_PROCEDURE);
        }

        //RITM0268131 - mangesh
        public List<FormApproval> QueryByFormMudsTemporaryInstallationId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormMudsTemporaryInstallationId", id);

            return command.QueryForListResult(PopulateInstanceForMudsTemporaryInstallation,
                QUERY_BY_FORM_MUDS_TemporaryInstallation_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryByFormLubesCsdId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormLubesCsdId", id);

            return command.QueryForListResult(PopulateInstanceForLubesCsd, QUERY_BY_FORM_LUBESCSD_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryByFormLubesAlarmDisableId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormLubesAlarmDisableId", id);

            return command.QueryForListResult(PopulateInstanceForLubesAlarmDisable,
                QUERY_BY_FORM_LUBES_ALARMDISABLE_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryByFormGN24Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN24Id", id);

            return command.QueryForListResult(PopulateInstanceForGN24, QUERY_BY_FORM_GN24_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryByFormGN6Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN6Id", id);

            return command.QueryForListResult(PopulateInstanceForGN6, QUERY_BY_FORM_GN6_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryByFormGN75AId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN75AId", id);

            return command.QueryForListResult(PopulateInstanceForGN75A, QUERY_BY_FORM_GN75A_ID_STORED_PROCEDURE);
        }


        //ayman Sarnia eip DMND0008992
        public List<FormApproval> QueryByFormGN75BSarniaId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN75BId", id);

            return command.QueryForListResult(PopulateInstanceForGN75B, QUERY_BY_FORM_GN75BSarnia_ID_STORED_PROCEDURE);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormApproval> QueryByFormGN75BId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN75BId", id);

            return command.QueryForListResult(PopulateInstanceForGN75B, QUERY_BY_FORM_GN75B_ID_STORED_PROCEDURE);
        }


        public List<FormApproval> QueryByOvertimeFormId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@OvertimeFormId", id);
            return command.QueryForListResult(PopulateInstanceForOvertimeForm,
                QUERY_BY_OVERTIME_FORM_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryPlanningWorksheetApprovalsByFormGN1Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN1Id", id);

            return command.QueryForListResult(PopulateInstanceForGN1,
                QUERY_PLANNING_WORKSHEET_APPROVALS_BY_FORM_GN1_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryRescuePlanApprovalsByFormGN1Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN1Id", id);

            return command.QueryForListResult(PopulateInstanceForGN1,
                QUERY_RESCUE_PLAN_APPROVALS_BY_FORM_GN1_ID_STORED_PROCEDURE);
        }

        public List<FormApproval> QueryByFormOilsandsTrainingId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormOilsandsTrainingId", id);

            return command.QueryForListResult(PopulateInstanceForOilsandsTraining,
                QUERY_BY_FORM_OILSANDS_TRAINING_ID_STORED_PROCEDURE);
        }

        private FormApproval PopulateInstanceForOP14(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormOP14Id");
        }

        //generic template - mangesh
        private FormApproval PopulateInstanceForGenericTemplate(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormGenericTemplateId");
        }

        //RITM0268131 - mangesh
        private FormApproval PopulateInstanceForMudsTemporaryInstallation(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormMudsTemporaryInstallationId");
        }

        //ayman Sarnia eip DMND0008992
        private FormApproval PopulateInstanceForSarniaEipIssue(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormSarniaEipIssueId");
        }
        //Added by ppanigrahi
        private FormApproval PopulateInstanceForSarniaCsd(SqlDataReader reader)
        {
            return PopulateInstanceSarniaCsd(reader, "FormSarniaCsdID");
        }

        private FormApproval PopulateInstanceForMontrealCsd(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormMontrealCsdId");
        }

        private FormApproval PopulateInstanceForLubesCsd(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormLubesCsdId");
        }

        private FormApproval PopulateInstanceForLubesAlarmDisable(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormLubesAlarmDisableId");
        }

        private FormApproval PopulateInstanceForGN24(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormGN24Id");
        }

        private FormApproval PopulateInstanceForGN6(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormGN6Id");
        }

        private FormApproval PopulateInstanceForGN75A(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormGN75AId");
        }

        //ayman Sarnia eip DMND0008992
        private FormApproval PopulateInstanceForGN75B(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormGN75BId");
        }

        private FormApproval PopulateInstanceForOvertimeForm(SqlDataReader reader)
        {
            var overtimeFormApproval = PopulateInstance(reader, "OvertimeFormId");
            var workAssignmentDisplayName = reader.Get<string>("WorkAssignmentDisplayName");
            overtimeFormApproval.WorkAssignmentDisplayName = workAssignmentDisplayName;
            return overtimeFormApproval;
        }

        private FormApproval PopulateInstanceForGN1(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormGN1Id");
        }

        private FormApproval PopulateInstanceForGN7(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormGN7Id");
        }

        private FormApproval PopulateInstanceForGN59(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormGN59Id");
        }

        private FormApproval PopulateInstanceForOilsandsTraining(SqlDataReader reader)
        {
            return PopulateInstance(reader, "FormOilsandsTrainingId");
        }

        private FormApproval PopulateInstance(SqlDataReader reader, String formIdColumnName)
        {
            User approvedByUser = null;

            var id = reader.Get<long>("Id");
            var formId = reader.Get<long>(formIdColumnName);
            var approver = reader.Get<string>("Approver");
            var approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            var approvalDateTime = reader.Get<DateTime?>("ApprovalDateTime");
            var displayOrder = reader.Get<int>("DisplayOrder");
            var shouldBeEnabledBehaviourId = reader.Get<int>("ShouldBeEnabledBehaviourId");
            var behaviour = ApprovalShouldBeEnabledBehaviour.GetById(shouldBeEnabledBehaviourId);
            var enabled = reader.Get<bool>("Enabled");

            if (approvedByUserId != null)
            {
                approvedByUser = userDao.QueryById(approvedByUserId.Value);
            }

            return new FormApproval(id, formId, approver, approvedByUser, approvalDateTime, null, displayOrder,
                behaviour, enabled);
        }
        //Added by ppanigrahi
        private FormApproval PopulateInstanceSarniaCsd(SqlDataReader reader, String formIdColumnName)
        {
            User approvedByUser = null;

            var id = reader.Get<long>("Id");
            var formId = reader.Get<long>(formIdColumnName);
            var approver = reader.Get<string>("Approver");
            var approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            var approvalDateTime = reader.Get<DateTime?>("ApprovalDateTime");
            var displayOrder = reader.Get<int>("DisplayOrder");
            var shouldBeEnabledBehaviourId = reader.Get<int>("ShouldBeEnabledBehaviourId");
            var behaviour = ApprovalShouldBeEnabledBehaviour.GetById(shouldBeEnabledBehaviourId);
            var enabled = reader.Get<bool>("Enabled");
            var EmailList = reader.Get<string>("EmailList");
            //var isMailSent = reader.Get<bool>("isMailSent");
            //FormApproval formApprovl= t
            
           // SqlDataReader readerEmail = command.EndExecuteReader("QueryByFormOP14EmailCSDApprovalID");

            if (approvedByUserId != null)
            {

                approvedByUser = userDao.QueryById(approvedByUserId.Value);
            }

            return new FormApproval(id, formId, approver, approvedByUser, approvalDateTime, null, displayOrder,behaviour, enabled, EmailList,false);
        }
        private FormApproval PopulateInstanceForOP14Email(SqlDataReader reader)
        {
            return PopulateInstanceEmail(reader, "FormOP14Id");
        }
        private FormApproval PopulateInstanceEmail(SqlDataReader reader, String formIdColumnName)
        {
            User approvedByUser = null;

            var id = reader.Get<long>("Id");
            var formId = reader.Get<long>(formIdColumnName);
            var approver = reader.Get<string>("Approver");
            var approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            var approvalDateTime = reader.Get<DateTime?>("ApprovalDateTime");
            var displayOrder = reader.Get<int>("DisplayOrder");
            var shouldBeEnabledBehaviourId = reader.Get<int>("ShouldBeEnabledBehaviourId");
            var behaviour = ApprovalShouldBeEnabledBehaviour.GetById(shouldBeEnabledBehaviourId);
            var enabled = reader.Get<bool>("Enabled");
            var isMailSent = reader.Get<bool>("isMailSent");

            if (approvedByUserId != null)
            {
                approvedByUser = userDao.QueryById(approvedByUserId.Value);
            }

            return new FormApproval(id, formId, approver, approvedByUser, approvalDateTime, null, displayOrder,
                behaviour, enabled,isMailSent);
        }
    }
}