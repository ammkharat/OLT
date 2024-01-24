using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class MontrealCsdDao : AbstractManagedDao, IMontrealCsdDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFormMontrealCsdById";
        private const string INSERT_STORED_PROCEDURE = "InsertFormMontrealCsd";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormMontrealCsd";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertFormMontrealCsdFunctionalLocation";

        private const string DELETE_FORM_FUNCTIONAL_LOCATION =
            "DeleteFormMontrealCsdFunctionalLocationsByFormMontrealCsdId";

        private const string INSERT_FORM_APPROVAL = "InsertFormMontrealCsdApproval";
        private const string UPDATE_FORM_APPROVAL = "UpdateFormMontrealCsdApproval";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormMontrealCsd";

        private const string QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_3_DAYS =
            "QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan3Days";
 private const string QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_5_DAYS =
            "QueryAllFormMontrealCsdThatAreApprovedAndOutOfServiceForMoreThan5Days";

        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormApprovalDao formApprovalDao;
        private readonly IUserDao userDao;

        public MontrealCsdDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        public MontrealCsd Insert(MontrealCsd form)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, form);
            InsertApprovals(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            return form;
        }

        //ayman generic forms
        public MontrealCsd QueryByIdAndSiteId(long id, long siteid)
        {
            var command = ManagedCommand;
            return command.QueryByIdAndSiteId(id, siteid, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }
        
        public MontrealCsd QueryById(long id)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<MontrealCsd> QueryAllThatAreApprovedAndAreMoreThan3DaysOutOfService(DateTime now)
        {
            var command = ManagedCommand;
            command.AddParameter("@Now", now);
            return command.QueryForListResult(PopulateInstance,
                QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_3_DAYS);
        }

        public List<MontrealCsd> QueryAllThatAreApprovedAndAreMoreThan5DaysOutOfService(DateTime currentTimeAtSite)
        {
            var command = ManagedCommand;
            command.AddParameter("@Now", currentTimeAtSite);
            return command.QueryForListResult(PopulateInstance,
                QUERY_ALL_APPROVED_AND_OUT_OF_SERVICE_FOR_MORE_THAN_5_DAYS);
    
        }

        public void Update(MontrealCsd form)
        {
            var command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateFunctionalLocations(command, form);
            UpdateApprovals(command, form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
        }

        public void Remove(MontrealCsd form)
        {
            var command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormMontrealCsdId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormMontrealCsd);
        }

        private void AddUpdateParameters(MontrealCsd form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private void UpdateApprovals(SqlCommand command, MontrealCsd form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = UPDATE_FORM_APPROVAL;
                foreach (var approval in form.Approvals)
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

        private void UpdateFunctionalLocations(SqlCommand command, MontrealCsd form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@FormMontrealCsdId", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void InsertApprovals(SqlCommand command, MontrealCsd form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (var approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    var idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormMontrealCsdId", form.Id);
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

        private void InsertFunctionalLocations(SqlCommand command, MontrealCsd form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (var functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@FormMontrealCsdId", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddInsertParameters(MontrealCsd form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
        }

        private void SetCommonAttributes(MontrealCsd form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@Content", form.Content);
            command.AddParameter("@CsdReason", form.CsdReason);
            command.AddParameter("@PlainTextContent", form.PlainTextContent);
            command.AddParameter("@IsTheCSDForAPressureSafetyValve", form.IsTheCSDForAPressureSafetyValve);
            command.AddParameter("@CriticalSystemDefeated", form.CriticalSystemDefeated);
            command.AddParameter("@HasBeenCommunicated", form.HasBeenCommunicated);
            command.AddParameter("@HasBeenApproved", form.HasBeenApproved);
            command.AddParameter("@HasAttachments", form.HasAttachments);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
        }

        private MontrealCsd PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");

            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            var functionalLocations = flocDao.QueryByFormMontrealCsdId(id);
            var approvals = formApprovalDao.QueryByFormMontrealCsdId(id);
            var documentLinks = documentLinkDao.QueryByFormMontrealCsdId(id);

            var content = reader.Get<string>("Content");
            var plainTextContent = reader.Get<string>("PlainTextContent");


            var approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            var closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            var isTheCSDForAPressureSafetyValve = reader.Get<bool>("IsTheCSDForAPressureSafetyValve");
            var criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");
            var hasBeenCommunicated = reader.Get<bool>("HasBeenCommunicated");
            var hasAttachments = reader.Get<bool>("HasAttachments");
            var csdReason = reader.Get<string>("CsdReason");

            var createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            var hasBeenApproved = reader.Get<bool>("HasBeenApproved");


//            var siteid = reader.Get<long>("SiteId");    //ayman generic forms remove siteid



            var form = new MontrealCsd(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)    //ayman generic forms
            {
                FunctionalLocations = functionalLocations,
                Approvals = approvals,
                LastModifiedBy = lastModifiedBy,
                DocumentLinks = documentLinks,
                LastModifiedDateTime = lastModifiedDateTime,
                ApprovedDateTime = approvedDateTime,
                ClosedDateTime = closedDateTime,
                Content = content,
                PlainTextContent = plainTextContent,
                HasBeenCommunicated = hasBeenCommunicated,
                HasAttachments = hasAttachments,
                CsdReason = csdReason,
                IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve,
                CriticalSystemDefeated = criticalSystemDefeated,
                HasBeenApproved = hasBeenApproved
            };
            return form;
        }
    }
}