using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormOilsandsTrainingDao : AbstractManagedDao, IFormOilsandsTrainingDao
    {
        private readonly IUserDao userDao;
        private readonly IRoleDao roleDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IFormOilsandsTrainingItemDao trainingItemDao;
        private readonly IWorkAssignmentDao workAssignmentDao;
        private readonly IShiftPatternDao shiftPatternDao;

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormOilsandsTrainingById";
        private const string QUERY_BY_DATE_USERIDS_WORKASSIGNMENTS_STORED_PROCEDURE = "QueryFormOilsandsTrainingByDateRangeAndUserIdsAndWorkAssignmentIds";
        private const string INSERT_STORED_PROCEDURE = "InsertFormOilsandsTraining";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormOilsandsTraining";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormOilsandsTraining";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertFormOilsandsTrainingFunctionalLocation";
        private const string DELETE_FORM_FUNCTIONAL_LOCATION = "DeleteFormOilsandsTrainingFunctionalLocationsByFormOilsandsTrainingId";
        private const string INSERT_FORM_APPROVAL = "InsertFormOilsandsTrainingApproval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormOilsandsTrainingApproval";
        private const string QUERY_FOR_DUPLICATE = "QueryFormOilsandsTrainingForDuplicate";

        public FormOilsandsTrainingDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            trainingItemDao = DaoRegistry.GetDao<IFormOilsandsTrainingItemDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
        }

        public FormOilsandsTraining Insert(FormOilsandsTraining form)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, form);
            InsertApprovals(command, form);
            InsertTrainingItems(form);
            return form;
        }

        //ayman generic forms
        public FormOilsandsTraining QueryByIdAndSiteId(long id,long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormOilsandsTraining>(id, siteid, PopulateInstance, "QueryFormOilsandsTrainingByIdAndSiteId");
        }
        
        public FormOilsandsTraining QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormOilsandsTraining>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public long? QueryTrainingDateAndShiftAndAssignmentDuplicatesOnOtherForms(long? formId, Date trainingDate, ShiftPattern shiftPattern, WorkAssignment workAssignment, User currentUser)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TrainingDate", trainingDate.ToDateTimeAtStartOfDay());
            command.AddParameter("@ShiftId", shiftPattern.IdValue);
            command.AddParameter("@WorkAssignmentId", workAssignment == null ? null : workAssignment.Id);
            command.AddParameter("@CurrentUserId", currentUser.IdValue);

            FormOilsandsTraining duplicateForm = command.QueryForSingleResult<FormOilsandsTraining>(PopulateInstance, QUERY_FOR_DUPLICATE);

            if (duplicateForm == null || duplicateForm.Id == formId)
            {
                return null;
            }

            return duplicateForm.Id;
        }

        public List<FormOilsandsTraining> QueryByDateAndUsersAndWorkAssignments(DateRange range, List<long> userIdList, List<long> workAssignmentIdList)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvUserIds", userIdList.BuildCommaSeparatedList());
            command.AddParameter("@CsvWorkAssignmentIds", workAssignmentIdList.BuildCommaSeparatedList());
            command.AddParameter("@StartOfDateRange", range.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", range.SqlFriendlyEnd);

            return command.QueryForListResult<FormOilsandsTraining>(PopulateInstance, QUERY_BY_DATE_USERIDS_WORKASSIGNMENTS_STORED_PROCEDURE);
        }

        public void Update(FormOilsandsTraining form)
        {
            SqlCommand command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateFunctionalLocations(command, form);
            UpdateApprovals(command, form);
            UpdateTrainingItems(form);
        }

        public void Remove(FormOilsandsTraining form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private FormOilsandsTraining PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            List<FunctionalLocation> functionalLocations = flocDao.QueryByFormOilsandsTrainingId(id);
            List<FormApproval> approvals = formApprovalDao.QueryByFormOilsandsTrainingId(id);
            List<FormOilsandsTrainingItem> trainingItems = trainingItemDao.QueryByFormOilsandsTrainingId(id);

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            Role createdByRole = roleDao.QueryById(reader.Get<long>("CreatedByRoleId"));

            ShiftPattern shiftPattern = shiftPatternDao.QueryById(reader.Get<long>("ShiftId"));
            Date trainingDate = reader.Get<DateTime>("TrainingDate").ToDate();
            string generalComments = reader.Get<string>("GeneralComments");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            long? workAssignmentId = reader.Get<long?>("WorkAssignmentId");
            WorkAssignment workAssignment = null;
            if (workAssignmentId != null)
            {
                workAssignment = workAssignmentDao.QueryById(workAssignmentId.Value);
            }

            FormOilsandsTraining form = new FormOilsandsTraining(id, formStatus, createdBy, createdDateTime, createdByRole);
            form.FunctionalLocations = functionalLocations;
            form.Approvals = approvals;
            form.TrainingItems = trainingItems;
            form.LastModifiedBy = lastModifiedBy;
            form.LastModifiedDateTime = lastModifiedDateTime;
            form.ApprovedDateTime = approvedDateTime;
            form.WorkAssignment = workAssignment;
            form.TrainingDate = trainingDate;
            form.ShiftPattern = shiftPattern;
            form.GeneralComments = generalComments;

            return form;
        }

        private static void AddInsertParameters(FormOilsandsTraining form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
            command.AddParameter("@CreatedByRoleId", form.CreatedByRole.Id);
            command.AddParameter("@WorkAssignmentId", form.WorkAssignment == null ? null : form.WorkAssignment.Id);
        }

        private static void AddUpdateParameters(FormOilsandsTraining form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private static void SetCommonAttributes(FormOilsandsTraining form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);

            command.AddParameter("@TrainingDate", form.TrainingDate.ToDateTimeAtStartOfDay());
            command.AddParameter("@ShiftId", form.ShiftPattern.IdValue);
            command.AddParameter("@TotalHours", form.TotalHours);
            command.AddParameter("@GeneralComments", form.GeneralComments);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@siteid",form.FunctionalLocations[0].Site.IdValue);    //ayman training form
        }

        private static void InsertFunctionalLocations(SqlCommand command, FormOilsandsTraining form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@FormOilsandsTrainingId", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertTrainingItems(FormOilsandsTraining form)
        {
            if (!form.TrainingItems.IsEmpty())
            {
                foreach (FormOilsandsTrainingItem trainingItem in form.TrainingItems)
                {
                    trainingItem.FormOilsandsTrainingId = form.IdValue;
                    trainingItemDao.Insert(trainingItem);
                }
            }
        }

        private void InsertApprovals(SqlCommand command, FormOilsandsTraining form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormOilsandsTrainingId", form.Id);
                    command.AddParameter("@Approver", approval.Approver);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@DisplayOrder", approval.DisplayOrder);
                    command.ExecuteNonQuery();
                    approval.Id = long.Parse(idParameter.Value.ToString());
                }
            }
        }

        private void UpdateFunctionalLocations(SqlCommand command, FormOilsandsTraining form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@FormOilsandsTrainingId", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void UpdateTrainingItems(FormOilsandsTraining form)
        {
            List<FormOilsandsTrainingItem> itemsToUpdate = new List<FormOilsandsTrainingItem>();
            List<FormOilsandsTrainingItem> itemsToInsert = new List<FormOilsandsTrainingItem>();            

            foreach (FormOilsandsTrainingItem trainingItem in form.TrainingItems)
            {
                trainingItem.FormOilsandsTrainingId = form.IdValue;

                if (trainingItem.IsInDatabase())
                {
                    itemsToUpdate.Add(trainingItem);
                }
                else
                {
                    itemsToInsert.Add(trainingItem);
                }
            }

            trainingItemDao.RemoveAllThatAreNotInThisList(form.IdValue, itemsToUpdate);
                        
            itemsToInsert.ForEach(item => trainingItemDao.Insert(item));
            itemsToUpdate.ForEach(item => trainingItemDao.Update(item));
        }

        private void UpdateApprovals(SqlCommand command, FormOilsandsTraining form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = UPDATE_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@Id", approval.Id);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
