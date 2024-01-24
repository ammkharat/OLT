using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class EdmontonGN75BTemplateContext : AbstractEdmontonFormContext<FormEdmontonGN75BDTO, FormGN75B, FormEdmontonGN75BDetails>
    {
          private readonly IReportPrintManager<FormGN75B> reportPrintManager;

        public EdmontonGN75BTemplateContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(formService, page, EdmontonFormType.GN75BTemplate, new FormEdmontonGN75BDetails("Template #","Work Scope"), new FormEdmontonGN75BGridRenderer(), new MultiGridContextStatusFilter())
        {
            PrintActions<FormGN75B, FormGN75BReport, FormGN75BReportAdapter> printActions = new EdmontonGN75BFormPrintActions(formService, page);
            reportPrintManager = new ReportPrintManager<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>(printActions);
        }

        public override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
            details.DocumentLinkOpened += HandleDocumentLinkOpened;
        }

        public override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            details.DocumentLinkOpened -= HandleDocumentLinkOpened;
        }

        private void HandleDocumentLinkOpened()
        {
            ClientBackgroundWorker worker = new ClientBackgroundWorker();
          //  worker.DoWork += (sender, args) => formService.InsertGN75BUserReadDocumentLinkAssociation(FirstSelectedItem.IdValue, ClientSession.GetUserContext().User.IdValue);
           worker.DoWork += (sender, args) => formService.InsertGN75BUserReadDocumentLinkAssociationTemplateSarnia(FirstSelectedItem.IdValue, ClientSession.GetUserContext().User.IdValue);//INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
            worker.RunWorkerAsync();            
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<FormEdmontonGN75BDTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;

            details.DeleteEnabled = hasSingleItemSelected && authorized.ToDeleteForm(userRoleElements) && FormStatus.Approved.DoesNotEqual(selectedItems[0].Status);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditEipIssue(userRoleElements) && FormStatus.Approved.DoesNotEqual(selectedItems[0].Status);

            details.EditEnabled = hasSingleItemSelected && authorized.ToEditEipIssue(userRoleElements)
                && FormStatus.Closed.DoesNotEqual(selectedItems[0].Status);   // INC0433288 : Added by vibhor (After Closing an EIP Template form Edit button should be disabled)

            details.DeleteEnabled = hasSingleItemSelected && authorized.ToDeleteForm(userRoleElements) &&
                                    FormStatus.Closed.DoesNotEqual(selectedItems[0].Status); //INC0458131:-Added by Aarti(After Closing an EIP Template form Delete button should be disabled)

            //authorized.ToEditFormGN75B(userRoleElements, selectedItems[0].Status) && FormStatus.Approved.DoesNotEqual(selectedItems[0].Status);

        }

        protected override FormEdmontonGN75BDTO CreateDtoFromDomainObject(FormGN75B item)
        {
            if (item.FormStatus != FormStatus.Closed)
            {
                item.FormStatus = FormStatus.WaitingForApproval;      //ayman Sarnia eip DMND0008992
            }
            else
            {
                item.FormStatus = FormStatus.Closed;   // INC0433199 : Added by vibhor ( Fixed issue of Closing a EIP Template)
            }
            return new FormEdmontonGN75BDTO(item);
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN75BTemplateFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGN75BTemplateFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN75BTemplateFormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN75BTemplateFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN75BTemplateFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN75BTemplateFormRemoved -= HandleRepeaterRemoved;
        }

        protected override bool ShouldBeDisplayed(FormGN75B item)
        {
            FormStatus formStatusFilter = filter.GetFormStatusFilter(this);
            return Equals(item.FormStatus, formStatusFilter);
        }

        public override FormStatus GetDefaultFormStatus()
        {
            return FormStatus.Approved;
        }

        protected override bool IsItemInDateRange(FormGN75B item, Range<Date> range)
        {
            // date is a non-factor in whether or not we show Gn75b.  Only the status and filtering of statuses makes a difference.
            return true;
        }

        protected override void Delete(FormGN75B item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formGn75B => formService.RemoveGN75B(formGn75B, userContext.User), item);
        }

        protected override void DeleteWithOkCancelDialog(string entityName)
        {
            entityName = "Eip Template";

            List<FormEdmontonGN75BDTO> selectedDTOs = grid.SelectedItems;

            List<long> idsForSelectedItems = selectedDTOs.ConvertAll(dto => dto.IdValue);

            //bool confirmed = formService.GN75BIsAssociatedToAGN75AOrActionItem(idsForSelectedItems)
            //    ? page.ShowOKCancelDialog(string.Format(StringResources.DeleteGN75BWithAssociatedGN75OrActionItem, entityName),
            //        string.Format(StringResources.DeleteItemDialogTitle, entityName))
            //    : ShowOKCancelDialogForDelete(entityName);

            //if (confirmed)
            //{
                LockAndDeleteSelectedItems();
          //  }
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormGN75B item)
        {
            return new EditFormGN75BHistoryFormPresenter(item);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormGN75B; }
        }

        protected override IReportPrintManager<FormGN75B> ReportPrintManager
        {
            get
            {
                return reportPrintManager;
            }
        }

        public override DialogResultAndOutput<FormGN75B> Edit(FormGN75B domainObject, IBaseForm view)
        {

            FormGN75BSarniaTemplatePresenter presenter = new FormGN75BSarniaTemplatePresenter(domainObject,false);           //ayman Sarnia eip - 3
            return presenter.RunAndReturnTheEditObject(view);


        }

        public override DialogResultAndOutput<FormGN75B> CreateNew(IBaseForm view)
        {
            FormGN75BSarniaTemplatePresenter presenter = new FormGN75BSarniaTemplatePresenter();            //ayman Sarnia eip - 2
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override void SetDetailData(FormEdmontonGN75BDetails details, FormGN75B item)
        {
            //ayman Sarnia eip DMND0008992
            //get all eip issues that the template approved by

            details.PrintButtonVisible = false;
            details.PrintPreviewButtonVisible = false;

            List<FormEdmontonGN75BDTO> TemplateApprovedBy = new List<FormEdmontonGN75BDTO>();
           TemplateApprovedBy = QueryApprovedTemplateToshowEipForms(item.FormNumber, ClientSession.GetUserContext().SiteId);

            var formnumberstring = "";


            if (TemplateApprovedBy.Count > 0)
            {
               // formnumberstring = item.FormNumber + "    Approved By eip Issues: " +
                                   TemplateApprovedBy.ConvertAll(ids => ids.Id.ToString()).BuildCommaSeparatedList();
                details.FormNumberString = item.FormNumber + "    Approved By eip Issue: " + TemplateApprovedBy[0].Id; // formnumberstring;
            }
            else
            {
                details.FormNumber = item.FormNumber;                
            }
            details.CreatedByUser = item.CreatedBy;
            details.CreatedDateTime = item.CreatedDateTime;
            details.LastModifiedByUser = item.LastModifiedBy;
            details.LastModifiedDateTime = item.LastModifiedDateTime;
            details.ClosedDateTime = item.ClosedDateTime;
            
            details.FunctionalLocation = item.FunctionalLocation.FullHierarchyWithDescription;
            details.LocationOfWork = item.LocationOfWork;
            details.DocumentLinks = item.DocumentLinks;
            details.Schematic = item.SchematicImage;
            details.BlindsRequired = item.BlindsRequired.BooleanToYesNoString();
            details.EquipmentType = item.EquipmentType;
            details.LockBoxNumber = item.LockBoxNumber;
            details.LockBoxLocation = item.LockBoxLocation;

            details.Isolations = item.IsolationItems;
            
        }

        //ayman generic forms
        public override FormGN75B QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryFormGN75BTemplateByIdAndSiteId(id,siteid);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonGN75BDTO> QueryApprovedTemplateToshowEipForms(long id, long siteid)
        {
            return formService.QueryApprovedTemplateToShowEipFormsQueryApprovedTemplateToShowEipForms(id, siteid);
        }

        public override FormGN75B QueryById(long id)
        {
            return formService.QueryFormGN75BTemplateByIdAndSiteId(id,ClientSession.GetUserContext().SiteId);          //ayman Sarnia eip DMND0008992
        }

        public override IList<FormEdmontonGN75BDTO> GetData(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            if (formStatuses.Contains(FormStatus.Closed))
            {
                return formService.QueryFormGN75BTemplateDTOsByCriteria(flocSet, formStatuses);
            }
            //INC0458131 (Aarti) (All status shouls be visible in "view All")
            else
            {
                formStatuses.Add(FormStatus.WaitingForApproval);  // Sarnia eip Template needs to show Approved and Waiting for approval       ayman Sarnia eip DMND0008992
                formStatuses.Add(FormStatus.Approved);
                formStatuses.Add(FormStatus.Expired);
                formStatuses.Add(FormStatus.Draft);
                return formService.QueryFormGN75BTemplateDTOsByCriteria(flocSet, formStatuses);
            }
            
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.GN75B;
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormGN75B; }
        }

        protected override void Update(FormGN75B form)
        {
            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formGn75B => formService.UpdateGN75B(formGn75B, false), form);
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification
                (formGn75B => formService.UpdateSarniaGN75B(formGn75B, false, "EIP Template"), form); // INC0433199 : Added by vibhor ( Fixed issue of Closing a EIP Template)
        }

        protected override IForm CreateEditForm(FormGN75B form)
        {
            FormGN75BSarniaTemplatePresenter presenter = new FormGN75BSarniaTemplatePresenter(form,false);
            return presenter.View;
        }

        //ayman Sarnia eip DMND0008992
        protected IForm ViewForm(FormGN75B form)
        {
            FormGN75BSarniaTemplatePresenter presenter = new FormGN75BSarniaTemplatePresenter(form,false);
            return presenter.View;
        }

        protected override void HandleClone()
        {
            FormGN75B form = QueryForFirstSelectedItem();
            form.ConvertToClone(ClientSession.GetUserContext().User);

            // get the latest version of the image that is stored at the path.
            string pathToSchematic = form.PathToSchematic;
            if (pathToSchematic.HasValue() && File.Exists(pathToSchematic))
            {
                byte[] imageAsBytes = File.ReadAllBytes(pathToSchematic);
                form.AddSchematic(pathToSchematic, imageAsBytes);
            }
            else if (pathToSchematic.HasValue())
            {
                OltMessageBox.Show(StringResources.FormGn75B_NotAbleToCloneImage);
                // if the user doesn't have permission to the file, or the file no longer exists clear the Schemetic data.
                form.ClearSchematic();
            }


            IForm editForm = CreateEditForm(form);

            if (editForm != null)
            {
                editForm.ShowDialog(page.ParentForm);
                editForm.Dispose();
            }

        }
    }
}
