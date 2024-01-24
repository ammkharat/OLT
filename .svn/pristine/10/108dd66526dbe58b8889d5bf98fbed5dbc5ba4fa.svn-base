using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OvertimeFormDao : AbstractManagedDao, IOvertimeFormDao
    {
        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IOnPremiseContractorDao onPremiseContractorDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFormApprovalDao formApprovalDao;

        public OvertimeFormDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            onPremiseContractorDao = DaoRegistry.GetDao<IOnPremiseContractorDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();
        }

        public void Insert(OvertimeForm form)
        {
            SqlCommand command = ManagedCommand;
            command.InsertAndSetId(form, AddParameters, "InsertOvertimeForm");
            InsertOnPremiseContractors(form);
            InsertApprovals(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        private void InsertApprovals(SqlCommand command, OvertimeForm form)
        {
            if (!form.Approvals.IsEmpty())
            {
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@OvertimeFormId", form.IdValue);
                    command.AddParameter("@Approver", approval.Approver);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@WorkAssignmentDisplayName", approval.WorkAssignmentDisplayName);
                    command.AddParameter("@DisplayOrder", approval.DisplayOrder);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    long approvalId = command.InsertAndReturnId("InsertOvertimeFormApproval");
                    approval.Id = approvalId;
                }
            }
        }

        private void UpdateApprovals(SqlCommand command, OvertimeForm form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = "UpdateOvertimeFormApproval";
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@Id", approval.Id);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@WorkAssignmentDisplayName", approval.WorkAssignmentDisplayName);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN6Id);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedOvertimeForm);
        }

        private void InsertOnPremiseContractors(OvertimeForm form)
        {
            form.OnPremiseContractors.ForEach(contractor =>
            {
                contractor.OvertimeFormId = form.Id;
                onPremiseContractorDao.Insert(contractor);
            });
        }

        private void AddParameters(OvertimeForm form, SqlCommand command)
        {
            command.AddParameter("CreatedByUserId", form.CreatedBy.IdValue);
            command.AddParameter("CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("FunctionalLocationId", form.FunctionalLocation.IdValue);

            AddCommonParameters(form, command);
        }

        private static void AddCommonParameters(OvertimeForm form, SqlCommand command)
        {
            command.AddParameter("FormStatusId", form.FormStatus.IdValue);
            command.AddParameter("ValidFromDateTime", form.FromDateTime);
            command.AddParameter("ValidToDateTime", form.ToDateTime);
            command.AddParameter("ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("CancelledDateTime", form.CancelledDateTime);
            command.AddParameter("LastModifiedByUserId", form.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("Trade", form.Trade);
        }

        //ayman generic forms
        public OvertimeForm QueryByIdAndSiteId(long id,long siteid)
        {
            return ManagedCommand.QueryByIdAndSiteId(id,siteid, PopulateInstance, "QueryOvertimeFormById");
        }

        public OvertimeForm QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, "QueryOvertimeFormById");
        }

        private OvertimeForm PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            //ayman generic forms
            long siteid = reader.Get<long>("SiteId");

            int formStatusId = reader.Get<byte>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);
            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            User createdByUser = userDao.QueryById(createdByUserId);

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            User lastModifiedUser = userDao.QueryById(lastModifiedByUserId);

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? cancelledDateTime = reader.Get<DateTime?>("CancelledDateTime");
            
            string trade = reader.Get<string>("Trade");
            
            long functionalLocationId = reader.Get<long>("FunctionalLocationId");
            FunctionalLocation functionalLocation = functionalLocationDao.QueryById(functionalLocationId);

            List<OnPremiseContractor> onPremiseContractors = onPremiseContractorDao.QueryByOvertimeForm(id);
            List<DocumentLink> documentLinks = documentLinkDao.QueryByOvertimeFormId(id);
            
            List<FormApproval> approvals = formApprovalDao.QueryByOvertimeFormId(id);

            OvertimeForm form = new OvertimeForm(id, formStatus, validFromDateTime, validToDateTime, createdByUser, createdDateTime, onPremiseContractors, functionalLocation, trade,
                lastModifiedUser, lastModifiedDateTime, cancelledDateTime,siteid)
            {
                ApprovedDateTime = approvedDateTime,
                DocumentLinks = documentLinks,
                Approvals = approvals
            };
            return form;
        }

        public void Update(OvertimeForm form)
        {
            SqlCommand command = ManagedCommand;

            command.Update(form, AddUpdateParameters, "UpdateOvertimeForm");
            UpdateApprovals(command, form);
            UpdateOnPremiseContractors(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        private void UpdateOnPremiseContractors(OvertimeForm form)
        {
            List<OnPremiseContractor> itemsToUpdate = new List<OnPremiseContractor>();
            List<OnPremiseContractor> itemsToInsert = new List<OnPremiseContractor>();

            foreach (OnPremiseContractor onPremiseContractor in form.OnPremiseContractors)
            {
                onPremiseContractor.OvertimeFormId = form.IdValue;

                if (onPremiseContractor.IsInDatabase())
                {
                    itemsToUpdate.Add(onPremiseContractor);
                }
                else
                {
                    itemsToInsert.Add(onPremiseContractor);
                }
            }

            onPremiseContractorDao.RemoveAllThatAreNotInThisList(form.IdValue, itemsToUpdate);

            itemsToInsert.ForEach(item => onPremiseContractorDao.Insert(item));
            itemsToUpdate.ForEach(item => onPremiseContractorDao.Update(item));
        }

        private void AddUpdateParameters(OvertimeForm overtimeForm, SqlCommand command)
        {
            command.AddParameter("@Id", overtimeForm.IdValue);
            AddCommonParameters(overtimeForm, command);
        }

        public void Remove(OvertimeForm form)
        {
            throw new NotImplementedException();
        }
    }
}