using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN75BDao : AbstractManagedDao, IFormGN75BDao
    {

        //ayman generic forms
        private const string QueryByIdAndSiteIdStoredProcedure = "QueryFormGN75BByIdAndSiteId";
        private const string QueryByIdAndSiteIdSarniaStoredProcedure = "QueryFormGN75BSarniaByIdAndSiteId";   //ayman Sarnia eip DMND0008992
        private const string QueryTemplateByIdAndSiteIdStoredProcedure = "QueryFormGN75BTemplateByIdAndSiteId";             //ayman Sarnia eip DMND0008992
        private const string QueryTemplateByIDToShowApprovedByHowManyeipforms = "QueryTemplateByIDToShowApprovedByHowManyeipforms";        //ayman Sarnia eip DMND0008992
        private const string QueryByIdStoredProcedure = "QueryFormGN75BById";
        private const string QueryGN75BSarniaByIdStoredProcedure = "QueryFormGN75BSarniaById";
        private const string QueryGN75BUserReadDocumentLinkAssociationCount = "QueryFormGN75BUserReadDocumentLinkAssociationCount";
        private const string QueryGN75BUserReadDocumentLinkAssociationCountSarnia = "QueryFormGN75BUserReadDocumentLinkAssociationCountSarnia";//INC0453097 Aarti
        private const string QueryGN75BUserReadDocumentLinkAssociationCountTemplateSarnia = "QueryFormGN75BUserReadDocumentLinkAssociationCountTemplateSarnia";//INC0453097 Aarti (OLT::EIP template Sarnia:: attachment crash)
        private const string InsertFormGN75BUserReadDocumentLinkAssociationStoredProcedure = "InsertFormGN75BUserReadDocumentLinkAssociation";//INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        private const string InsertFormGN75BUserReadDocumentLinkAssociationStoredProcedureSarnia = "InsertFormGN75BUserReadDocumentLinkAssociationSarnia";//INC0453097 Aarti
        private const string InsertFormGN75BUserReadDocumentLinkAssociationTemplateSarnia = "InsertFormGN75BUserReadDocumentLinkAssociationTemplateSarnia";
        private const string INSERT_FORM_APPROVAL = "InsertFormGN75BApproval";      //ayman Sarnia eip DMND0008992
        private const string INSERT_FORM_APPROVAL_SARNIA = "InsertFormGN75BSarniaApproval";      //ayman Sarnia eip DMND0008992

        private const string UPDATE_FORM_APPROVAL = "UpdateFormGN75BApproval";
        private const string UPDATE_FORM_APPROVAL_SARNIA = "UpdateFormGN75BSarniaApproval";           //ayman Sarnia eip - 3
        private FormGN75B templatedata;            //ayman Sarnia eip - 2
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IFormGN75BIsolationDao formGn75BIsolationDao;
        private readonly IFormGN75BDevicePositionDao formGn75BDevicepositionDao;    //ayman Sarnia eip DMND0008992
        
        private readonly IFormApprovalDao formApprovalDao;              //ayman Sarnia eip DMND0008992

        public FormGN75BDao()
        {

            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            formGn75BIsolationDao = DaoRegistry.GetDao<IFormGN75BIsolationDao>();
            formApprovalDao = DaoRegistry.GetDao<IFormApprovalDao>();                    //ayman Sarnia eip DMND0008992
            formGn75BDevicepositionDao = DaoRegistry.GetDao<IFormGN75BDevicePositionDao>();  //ayman Sarnia eip DMND0008992


        }


        public void InsertFormGN75BSarnia(FormGN75B form)
        {
            SqlCommand command = ManagedCommand;

            //ayman Sarnia eip DMND0008992
            templatedata = QueryTemplateByIdAndSiteId(form.TemplateID, form.SiteID);              //ayman Sarnia eip - 2
            command.Parameters.Clear();                                                   //ayman Sarnia eip - 2


            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.IdValue);

            long formId = command.InsertAndReturnId(form, AddOrUpdateParameterHandler, "InsertFormGN75BSarniaNew");
            form.Id = formId;     //ayman Sarnia eip

            if (form.DocumentLinks != null && form.DocumentLinks.Count > 0)    //ayman Sarnia eip DMND0008992
            {
                InsertNewDocumentLinks(form);
                //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
                RemoveDeletedDocumentLinksSarnia(form); //INC0453097 Aarti (Remove document link for Sarnia)
                //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            }

            //ayman Sarnia eip DMND0008992

                //Insert approvals
                if (form.Approvals.Count > 0)
                {
                    command = ManagedCommand;
                    InsertApprovalsSarnia(command, form);
                }

            //ayman Sarnia eip
            //insert Template history and change template formstatus to Approved
        }








        public void Insert(FormGN75B form)
        {
            SqlCommand command = ManagedCommand;

            //ayman Sarnia eip DMND0008992
            templatedata = QueryTemplateByIdAndSiteId(form.TemplateID, form.SiteID);              //ayman Sarnia eip - 2
            command.Parameters.Clear();                                                   //ayman Sarnia eip - 2


            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.IdValue);

            long formId = command.InsertAndReturnId(form, AddOrUpdateParameterHandler, "InsertFormGN75BNew");
            form.Id = formId;     //ayman Sarnia eip
            if (form.SiteID != 1)
            {
                InsertIsolationItems(form);
            }
            if (form.DocumentLinks != null && form.DocumentLinks.Count > 0)    //ayman Sarnia eip DMND0008992
            {
                InsertNewDocumentLinks(form);
                //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
                RemoveDeletedDocumentLinks(form);
                //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            }

            //ayman Sarnia eip DMND0008992
            if (form.SiteID == 1) //sarnia
            {
                //Insert approvals
                if (form.Approvals.Count > 0)
                {
                    command = ManagedCommand;
                    InsertApprovals(command, form);
                }
            }
            //ayman Sarnia eip
            //insert Template history and change template formstatus to Approved
        }

        //ayman Sarnia eip DMND0008992
        public void InsertTemplate(FormGN75B form)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.IdValue);

            long formId = command.InsertAndReturnId(form, AddOrUpdateParameterHandlerForEIPTemplate, "InsertFormGN75BTemplate");
            form.Id = formId;
            InsertTemplateIsolationItems(form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            if (form.SiteID == Site.SARNIA_ID)
            {
                RemoveDeletedDocumentLinksTemplateSarnia(form); //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
            }
            else
            {
                RemoveDeletedDocumentLinks(form);
            }
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        //ayman Sarnia eip - 3
        private void InsertTemplateIsolationItems(FormGN75B form)
        {
            if (form.IsolationItems.IsEmpty())
                return;

            foreach (IsolationItem item in form.IsolationItems)
            {
                item.FormGn75BId = form.Id;
                item.SiteId = form.SiteID;                //ayman Sarnia eip DMND0008992

                formGn75BIsolationDao.InsertForTemplate(item);
            }
        }

        private void InsertIsolationItems(FormGN75B form)
        {
            if (form.IsolationItems.IsEmpty())
                return;

            foreach (IsolationItem item in form.IsolationItems)
            {
                item.FormGn75BId = form.Id;
                item.SiteId = form.SiteID;                //ayman Sarnia eip DMND0008992

                formGn75BIsolationDao.Insert(item);
            }
        }

        private void InsertNewDocumentLinks(FormGN75B form)
        {
            //INC0453097 Aarti
            if (form.SiteID == Site.SARNIA_ID)
            {
                documentLinkDao.InsertNewDocumentLinks(form, documentLinkDao.InsertForAssociatedFormGN75BSarnia);
            }
            else
            {
                documentLinkDao.InsertNewDocumentLinks(form, documentLinkDao.InsertForAssociatedFormGN75B);
            }
        }

        private void UpdateParameterHandlerForEIPTemplate(FormGN75B form, SqlCommand command)
        {
            command.AddParameter("@Id", form.IdValue);
            AddOrUpdateParameterHandlerForEIPTemplate(form, command);
        }

        private void UpdateParameterHandler(FormGN75B form, SqlCommand command)
        {
            command.AddParameter("@Id", form.IdValue);
            AddOrUpdateParameterHandler(form, command);
        }

        private void AddOrUpdateParameterHandler(FormGN75B form, SqlCommand command)
        {

            command.AddParameter("@FormStatusId", form.FormStatus.IdValue);
            command.AddParameter("@FunctionalLocationId", form.FunctionalLocation.IdValue);
            command.AddParameter("@Location", form.LocationOfWork);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@BlindsRequired", form.BlindsRequired);
            if (form.SiteID != 1)
            {
                command.AddParameter("@EquipmentType", form.EquipmentType);
                command.AddParameter("@LockBoxNumber", form.LockBoxNumber);
                command.AddParameter("@LockBoxLocation", form.LockBoxLocation);
                command.AddParameter("@DeadLeg", 0);            //ayman Sarnia eip DMND0008992
                command.AddParameter("@DeadLegRisk", 0);        //ayman Sarnia eip - 2
                command.AddParameter("@SpecialPrecautions", string.Empty);     //ayman Sarnia eip DMND0008992
            }
            else
            {
                if (templatedata != null && form.SiteID == 1)
                {
                    command.AddParameter("@EquipmentType", templatedata.EquipmentType);
                }
                else
                {
                    command.AddParameter("@EquipmentType", form.EquipmentType);
                }
                command.AddParameter("@LockBoxNumber", null);
                command.AddParameter("@LockBoxLocation", null);
                command.AddParameter("@DeadLeg", form.DeadLeg);           //ayman Sarnia eip DMND0008992
                command.AddParameter("@DeadLegRisk", form.DeadLegRisk);   //ayman Sarnia eip - 2
                command.AddParameter("@SpecialPrecautions", form.SpecialPrecautions);
            }
            command.AddParameter("@PathToSchematic", form.PathToSchematic);

            byte[] schematicImage = form.SchematicImage;
            SqlParameter imageParameter = schematicImage == null
                ? new SqlParameter("@SchematicImage", SqlDbType.VarBinary, 0) { Value = null }
                : new SqlParameter("@SchematicImage", SqlDbType.VarBinary, schematicImage.Length) { Value = schematicImage };
            command.Parameters.Add(imageParameter);
            command.AddParameter("@siteid", form.SiteID);   //ayman generic forms
            command.AddParameter("@templateid", form.TemplateID);    //ayman Sarnia eip DMND0008992

        }

        //ayman Sarnia eip - 3
        private void InsertApprovalsSarnia(SqlCommand command, FormGN75B form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL_SARNIA;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormGN75BId", form.Id);
                    command.AddParameter("@Approver", approval.ApprovedByUser == null ? approval.Approver : approval.ApprovedByUser.FullNameWithFirstNameFirst);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@DisplayOrder", approval.DisplayOrder);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                    approval.Id = long.Parse(idParameter.Value.ToString());
                }
            }
        }

        //ayman Sarnia eip DMND0008992
        private void InsertApprovals(SqlCommand command, FormGN75B form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = INSERT_FORM_APPROVAL;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.AddParameter("@FormGN75BId", form.Id);
                    command.AddParameter("@Approver", approval.ApprovedByUser == null ? approval.Approver : approval.ApprovedByUser.FullNameWithFirstNameFirst);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@DisplayOrder", approval.DisplayOrder);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                    approval.Id = long.Parse(idParameter.Value.ToString());
                }
            }
        }

        private void AddOrUpdateParameterHandlerForEIPTemplate(FormGN75B form, SqlCommand command)
        {
            //command.AddParameter("@FormStatusId", FormStatus.WaitingForApproval.Id);
            command.AddParameter("@FormStatusId", form.FormStatus.IdValue); // INC0433199 : Added by vibhor (Fixed issue of Closing a EIP Template)
            command.AddParameter("@FunctionalLocationId", form.FunctionalLocation.IdValue);
            command.AddParameter("@Location", form.LocationOfWork);
            command.AddParameter("@ClosedDateTime", form.ClosedDateTime);
            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@EquipmentType", form.EquipmentType);
            command.AddParameter("@PathToSchematic", form.PathToSchematic);
            byte[] schematicImage = form.SchematicImage;
            SqlParameter imageParameter = schematicImage == null
                ? new SqlParameter("@SchematicImage", SqlDbType.VarBinary, 0) { Value = null }
                : new SqlParameter("@SchematicImage", SqlDbType.VarBinary, schematicImage.Length) { Value = schematicImage };
            command.Parameters.Add(imageParameter);
            command.AddParameter("@siteid", form.SiteID);   //ayman generic forms

        }


        //ayman generic forms
        public FormGN75B QueryByIdAndSiteId(long id, long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGN75B>(id, siteid, PopulateInstance, QueryByIdAndSiteIdStoredProcedure);
        }

        //ayman Sarnia eip DMND0008992
        public FormGN75B QuerySarniaFormByIdAndSiteId(long id, long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGN75B>(id, siteid, PopulateSarniaInstance, QueryByIdAndSiteIdSarniaStoredProcedure);
        }

        //ayman Sarnia eip DMND0008992
        public FormGN75B QueryTemplateByIdAndSiteId(long id, long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdAndSiteId<FormGN75B>(id, siteid, PopulateTemplateInstance, QueryTemplateByIdAndSiteIdStoredProcedure);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormGN75B> QueryApprovedTemplateByIDAndSiteIDToShoweipforms(long id, long siteid)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryApprovedTemplateByIdAndSiteIdToShowEipForms<FormGN75B>(id, siteid,
                PopulateTemplateInstance, QueryTemplateByIDToShowApprovedByHowManyeipforms);
        }

        public FormGN75B QueryGN75BSarniaById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormGN75B>(id, PopulateInstance, QueryGN75BSarniaByIdStoredProcedure);
        }


        public FormGN75B QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<FormGN75B>(id, PopulateInstance, QueryByIdStoredProcedure);
        }

        //ayman Sarnia eip DMND0008992
        public void UpdateSarnia(FormGN75B form, string formType)
        {
            SqlCommand command = ManagedCommand;

            //ayman Sarnia eip
            if (form.SiteID == 1)
            {
                if (formType == "EIP Template")
                {
                    command.Update(form, UpdateParameterHandlerForEIPTemplate, "UpdateFormGN75BTemplate");
                    UpdateTemplateIsolations(form);
                }
                else if (formType == "EIP Issue")
                {
                    command.Update(form, UpdateParameterHandler, "UpdateFormGN75BSarniaNew");
                    UpdateApprovalsSarnia(command, form);    //ayman Sarnia eip - 3
               //     UpdateIsolations(form);
                }
            }


            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinksSarnia(form); //INC0453097 Aarti 
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        public void Update(FormGN75B form)
        {
            SqlCommand command = ManagedCommand;
            command.Update(form, UpdateParameterHandler, "UpdateFormGN75BNew");
            UpdateApprovals(command, form);
            if (form.FormType != EdmontonFormType.GN75BSarniaEIP)     //ayman Sarnia eip DMND0008992
            {
                UpdateIsolations(form);
            }

            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        //ayman Sarnia eip - 3
        //ayman Sarnia eip DMND0008992
        private void UpdateApprovalsSarnia(SqlCommand command, FormGN75B form)
        {
            if (!form.Approvals.IsEmpty())
            {
                command.CommandText = UPDATE_FORM_APPROVAL_SARNIA;
                foreach (FormApproval approval in form.Approvals)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@Id", approval.Id);
                    command.AddParameter("@ApprovedByUserId", approval.ApprovedByUser == null ? null : approval.ApprovedByUser.Id);
                    command.AddParameter("@ApprovalDateTime", approval.ApprovalDateTime);
                    command.AddParameter("@Approver", approval.Approver);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                }
            }
        }


        //ayman Sarnia eip DMND0008992
        private void UpdateApprovals(SqlCommand command, FormGN75B form)
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
                    command.AddParameter("@Approver", approval.Approver);
                    command.AddParameter("@ShouldBeEnabledBehaviourId", approval.ShouldBeEnabledBehaviourId);
                    command.AddParameter("@Enabled", approval.Enabled);
                    command.ExecuteNonQuery();
                }
            }
        }



        public bool HasUserReadAtLeastOneDocumentLink(long userId, long formGN75BId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@FormGN75BId", formGN75BId);
            int count = command.GetCount(QueryGN75BUserReadDocumentLinkAssociationCount);
            return count > 0;
        }
        //INC0453097 Aarti
        public bool HasUserReadAtLeastOneDocumentLinkSarnia(long userId, long formGN75BSarniaId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@FormGN75BSarniaId", formGN75BSarniaId);
            int count = command.GetCount(QueryGN75BUserReadDocumentLinkAssociationCountSarnia);
            return count > 0;
        }

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        public bool HasUserReadAtLeastOneDocumentLinkTemplateSarnia(long userId, long formGN75BTemplateId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@FormGN75BTemplateId", formGN75BTemplateId);
            int count = command.GetCount(QueryGN75BUserReadDocumentLinkAssociationCountTemplateSarnia);
            return count > 0;
        }

        public void InsertUserReadDocumentLinkAssociation(long userId, long formGN75BId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = InsertFormGN75BUserReadDocumentLinkAssociationStoredProcedure;
            command.Parameters.Clear();
            command.AddParameter("@UserId", userId);
            command.AddParameter("@FormGN75BId", formGN75BId);
            command.ExecuteNonQuery();
        }

        //INC0453097 Aarti
        public void InsertUserReadDocumentLinkAssociationSarnia(long userId, long formGN75BSarniaId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = InsertFormGN75BUserReadDocumentLinkAssociationStoredProcedureSarnia;
            command.Parameters.Clear();
            command.AddParameter("@UserId", userId);
            command.AddParameter("@FormGN75BSarniaId", formGN75BSarniaId);
            command.ExecuteNonQuery();
        }

        //INC0453097 Aarti
        private void RemoveDeletedDocumentLinksSarnia(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN75BIdSarnia);
        }

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        private void RemoveDeletedDocumentLinksTemplateSarnia(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN75BIdTemplateSarnia);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
           
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormGN75BId);
        }

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        public void InsertUserReadDocumentLinkAssociationTemplateSarnia(long userId, long formGN75BTemplateId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = InsertFormGN75BUserReadDocumentLinkAssociationTemplateSarnia;
            command.Parameters.Clear();
            command.AddParameter("@UserId", userId);
            command.AddParameter("@FormGN75BTemplateId", formGN75BTemplateId);
            command.ExecuteNonQuery();
        }


        //ayman Sarnia eip - 3
        private void UpdateTemplateIsolations(FormGN75B form)
        {
            List<IsolationItem> itemsToUpdate = new List<IsolationItem>();
            List<IsolationItem> itemsToInsert = new List<IsolationItem>();

            foreach (IsolationItem isolationItem in form.IsolationItems)
            {
                isolationItem.FormGn75BId = form.IdValue;

                if (isolationItem.IsInDatabase())
                {
                    itemsToUpdate.Add(isolationItem);
                }
                else
                {
                    itemsToInsert.Add(isolationItem);
                }
            }

           // formGn75BIsolationDao.RemoveAllThatAreNotInThisList(form.IdValue, itemsToUpdate);
            formGn75BIsolationDao.RemoveAllThatAreNotInThisListTemplate(form.IdValue, itemsToUpdate);////Aarti INC0548411 

            itemsToInsert.ForEach(item => formGn75BIsolationDao.InsertForTemplate(item));
            itemsToUpdate.ForEach(item => formGn75BIsolationDao.UpdateForTemplate(item));
        }


        private void UpdateIsolations(FormGN75B form)
        {
            List<IsolationItem> itemsToUpdate = new List<IsolationItem>();
            List<IsolationItem> itemsToInsert = new List<IsolationItem>();

            foreach (IsolationItem isolationItem in form.IsolationItems)
            {
                isolationItem.FormGn75BId = form.IdValue;

                if (isolationItem.IsInDatabase())
                {
                    itemsToUpdate.Add(isolationItem);
                }
                else
                {
                    itemsToInsert.Add(isolationItem);
                }
            }

            formGn75BIsolationDao.RemoveAllThatAreNotInThisList(form.IdValue, itemsToUpdate);

            itemsToInsert.ForEach(item => formGn75BIsolationDao.Insert(item));
            itemsToUpdate.ForEach(item => formGn75BIsolationDao.Update(item));
        }

        //ayman Sarnia eip - 3
        public void RemoveTemplate(FormGN75B form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form.IdValue, "RemoveFormGN75BTemplate");
        }

        //ayman Sarnia eip - 3

        public void RemoveSarniaEip(FormGN75B form)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(form.IdValue, "RemoveFormGN75BSarnia");
        }

        public void Remove(FormGN75B form)
        {
                SqlCommand command = ManagedCommand;
                command.Remove(form.IdValue, "RemoveFormGN75B");
        }

        public List<long> QueryGn75AFormsAssociatedToFormGn75BById(long gn75BFormId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN75BId", gn75BFormId);
            return command.QueryForListResult(reader => reader.Get<long>("Id"), "QueryFormGn75AByGn75BId");
        }

        //ayman Sarnia eip DMND0008992
        private FormGN75B PopulateTemplateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            FunctionalLocation functionalLocation = flocDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            string location = reader.Get<string>("Location");
            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            bool isDeleted = reader.Get<bool>("Deleted");

            string equipmentType = reader.Get<string>("EquipmentType");

            //ayman generic forms
            long siteId = reader.Get<long>("siteid");

            List<IsolationItem> isolationItems = formGn75BIsolationDao.QueryByFormGN75BTemplateId(id);

            List<DevicePosition> devicePositions = formGn75BDevicepositionDao.QueryByFormGN75BId(id);   //ayman Sarnia eip DMND0008992

           // long templateid = reader.Get<long>("templateid");                   //ayman Sarnia eip DMND0008992

            ///INC0453097 Aarti (for documnet link)
            if (siteId == Site.SARNIA_ID)
            {
                FormGN75B formGn75B = new FormGN75B(id, formStatus, functionalLocation, location, isolationItems,
                   createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime,
                   closedDateTime, false, false, false, equipmentType, null, null, siteId, devicePositions, id, null,
                   null, null) //ayman generic forms     ayman Sarnia eip DMND0008992
                {
                    DocumentLinks = documentLinkDao.QueryByFormGN75BIdSarnia(id),
                    IsDeleted = isDeleted
                };


                byte[] schematicImage = reader.Get<byte[]>("SchematicImage");
                string pathToSchematic = reader.Get<string>("PathToSchematic");

                formGn75B.AddSchematic(pathToSchematic, schematicImage);
                formGn75B.FormType = EdmontonFormType.GN75BTemplate; //ayman Sarnia eip DMND0008992
                return formGn75B;
            }
            else
            {

                FormGN75B formGn75B = new FormGN75B(id, formStatus, functionalLocation, location, isolationItems,
                    createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime,
                    closedDateTime, false, false, false, equipmentType, null, null, siteId, devicePositions, id, null,
                    null, null) //ayman generic forms     ayman Sarnia eip DMND0008992
                {
                    DocumentLinks = documentLinkDao.QueryByFormGN75BId(id),
                    IsDeleted = isDeleted
                };


                byte[] schematicImage = reader.Get<byte[]>("SchematicImage");
                string pathToSchematic = reader.Get<string>("PathToSchematic");

                formGn75B.AddSchematic(pathToSchematic, schematicImage);
                formGn75B.FormType = EdmontonFormType.GN75BTemplate; //ayman Sarnia eip DMND0008992
                return formGn75B;
            }
        }

        private FormGN75B PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            FunctionalLocation functionalLocation = flocDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            string location = reader.Get<string>("Location");
            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            bool isDeleted = reader.Get<bool>("Deleted");

            bool blindsRequired = reader.Get<bool>("BlindsRequired");
            bool deadleg = reader.Get<bool>("DeadLeg");
            bool deadlegrisk = reader.Get<bool>("DeadLegRisk");                       //ayman Sarnia eip - 2
            string specialprecautions = reader.Get<string>("SpecialPrecautions");            
            string equipmentType = reader.Get<string>("EquipmentType");
            string lockBoxNumber = reader.Get<string>("LockBoxNumber");
            string lockBoxLocation = reader.Get<string>("LockBoxLocation");
            //ayman generic forms
            long siteId = reader.Get<long>("siteid");

            List<IsolationItem> isolationItems = formGn75BIsolationDao.QueryByFormGN75BId(id);

            List<DevicePosition> devicePositions = formGn75BDevicepositionDao.QueryByFormGN75BId(id);   //ayman Sarnia eip DMND0008992
            long templateid = reader.Get<long>("templateid");                  //ayman Sarnia eip DMND0008992

            //INC0453097 Aarti (for document link)
            if (siteId == Site.SARNIA_ID)
            {

                FormGN75B formGn75B = new FormGN75B(id, formStatus, functionalLocation, location, isolationItems,
                    createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime,
                    closedDateTime, blindsRequired, deadleg, deadlegrisk, equipmentType, lockBoxNumber, lockBoxLocation,
                    siteId, devicePositions, templateid, null, string.Empty, specialprecautions)
                //ayman generic forms     ayman Sarnia eip DMND0008992
                {

                    DocumentLinks = documentLinkDao.QueryByFormGN75BIdSarnia(id),
                    IsDeleted = isDeleted
                };
                byte[] schematicImage = reader.Get<byte[]>("SchematicImage");
                string pathToSchematic = reader.Get<string>("PathToSchematic");

                formGn75B.AddSchematic(pathToSchematic, schematicImage);

                return formGn75B;
            }
            else
            {

                FormGN75B formGn75B = new FormGN75B(id, formStatus, functionalLocation, location, isolationItems,
                    createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime,
                    closedDateTime, blindsRequired, deadleg, deadlegrisk, equipmentType, lockBoxNumber, lockBoxLocation,
                    siteId, devicePositions, templateid, null, string.Empty, specialprecautions)
                    //ayman generic forms     ayman Sarnia eip DMND0008992
                {

                    DocumentLinks = documentLinkDao.QueryByFormGN75BId(id),
                    IsDeleted = isDeleted
                };
                byte[] schematicImage = reader.Get<byte[]>("SchematicImage");
                string pathToSchematic = reader.Get<string>("PathToSchematic");

                formGn75B.AddSchematic(pathToSchematic, schematicImage);

                return formGn75B;
            }
        }

        private FormGN75B PopulateSarniaInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            FunctionalLocation functionalLocation = flocDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            string location = reader.Get<string>("Location");
            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));


            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            bool isDeleted = reader.Get<bool>("Deleted");

            bool blindsRequired = reader.Get<bool>("BlindsRequired");
            bool deadleg = reader.Get<bool>("DeadLeg");                    //ayman Sarnia eip DMND0008992
            bool deadlegrisk = reader.Get<bool>("DeadLegRisk");            //ayman Sarnia eip - 2
            string specialprecautions = reader.Get<string>("SpecialPrecautions");     //ayman Sarnia eip DMND0008992
            string equipmentType = reader.Get<string>("EquipmentType");
            string lockBoxNumber = ""; // reader.Get<string>("LockBoxNumber");
            string lockBoxLocation = ""; // reader.Get<string>("LockBoxLocation");
            //ayman generic forms
            long siteId = reader.Get<long>("siteid");
            long templateid = reader.Get<long>("templateid");                  //ayman Sarnia eip DMND0008992
            string flocdesc = reader.Get<string>("FlocDesc");

            List<IsolationItem> isolationItems = formGn75BIsolationDao.QueryByFormGN75BTemplateId(templateid);
            List<FormApproval> formApprovals = formApprovalDao.QueryByFormGN75BSarniaId(id);                 //ayman Sarnia eip DMND0008992
            List<DevicePosition> devicePositions = formGn75BDevicepositionDao.QueryByFormGN75BSarniaId(id);   //ayman Sarnia eip DMND0008992

            //ayman Sarnia eip - 2
            var approvals = formApprovals;

            DateTime createdDateTime;
            if (approvals.Count > 0 && approvals[0].IsApproved)
            {
                createdDateTime = (DateTime)approvals[0].ApprovalDateTime;
            }
            else
            {
                createdDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            }

            //INC0453097 Aarti
            if (siteId == Site.SARNIA_ID)
            {
                FormGN75B formGn75B = new FormGN75B(id, formStatus, functionalLocation, location, isolationItems,
                    createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime,
                    closedDateTime, blindsRequired, deadleg, deadlegrisk, equipmentType, lockBoxNumber, lockBoxLocation,
                    siteId, devicePositions, templateid, formApprovals, flocdesc, specialprecautions)
                //ayman generic forms     ayman Sarnia eip
                {
                    DocumentLinks = documentLinkDao.QueryByFormGN75BIdSarnia(id),
                    IsDeleted = isDeleted,
                };

                byte[] schematicImage = reader.Get<byte[]>("SchematicImage");
                string pathToSchematic = reader.Get<string>("PathToSchematic");

                formGn75B.AddSchematic(pathToSchematic, schematicImage);

                return formGn75B;
            }
            else
            {

                FormGN75B formGn75B = new FormGN75B(id, formStatus, functionalLocation, location, isolationItems,
                    createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime,
                    closedDateTime, blindsRequired, deadleg, deadlegrisk, equipmentType, lockBoxNumber, lockBoxLocation,
                    siteId, devicePositions, templateid, formApprovals, flocdesc, specialprecautions)
                    //ayman generic forms     ayman Sarnia eip
                {
                    DocumentLinks = documentLinkDao.QueryByFormGN75BId(id),
                    IsDeleted = isDeleted,
                };

                byte[] schematicImage = reader.Get<byte[]>("SchematicImage");
                string pathToSchematic = reader.Get<string>("PathToSchematic");

                formGn75B.AddSchematic(pathToSchematic, schematicImage);

                return formGn75B;
            }


            
        }
    }
}