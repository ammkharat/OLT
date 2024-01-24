using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
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
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;
using Timer = System.Threading.Timer;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class EdmontonGN75BSarniaEIPContext : AbstractEdmontonFormContext<FormEdmontonGN75BDTO, FormGN75B, FormEdmontonGN75BDetails>
    {
        private readonly IReportPrintManager<FormGN75B> reportPrintManager;
        private readonly EipIssueTimerManager timerManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private static readonly ILog logger = LogManager.GetLogger(typeof(EdmontonOP14FormContext));

        public EdmontonGN75BSarniaEIPContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(formService, page, EdmontonFormType.GN75BSarniaEIP, new FormEdmontonGN75BDetails("Issue #", "Work Scope"), new FormEdmontonGN75BGridRenderer(), new MultiGridContextStatusFilter())
        {
            PrintActions<FormGN75B, SarniaEipIssueReport, SarniaEipIssueReportAdapter> printActions = new SarniaEipIssuePrintActions(formService, page);
            reportPrintManager = new ReportPrintManager<FormGN75B, SarniaEipIssueReport, SarniaEipIssueReportAdapter>(printActions);
            synchronizationContext = (WindowsFormsSynchronizationContext)SynchronizationContext.Current;
            timerManager = new EipIssueTimerManager();
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
            worker.DoWork += (sender, args) => formService.InsertGN75BUserReadDocumentLinkAssociationSarnia(FirstSelectedItem.IdValue, ClientSession.GetUserContext().User.IdValue);//INC0453097 Aarti
            worker.RunWorkerAsync();
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<FormEdmontonGN75BDTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;

            details.DeleteEnabled = hasSingleItemSelected && authorized.ToDeleteForm(userRoleElements) && FormStatus.Approved.Equals(selectedItems[0].Status);
          //details.EditEnabled = hasSingleItemSelected && authorized.ToEditEipIssue(userRoleElements);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditEipIssue(userRoleElements) &&
                FormStatus.Closed.DoesNotEqual(selectedItems[0].Status);  // RITM0424573 : Added by vibhor (After Closing an EIP issue form Edit butoon should be disabled) 
 //authorized.ToEditFormGN75B(userRoleElements, selectedItems[0].Status);
            details.DeleteEnabled = hasSingleItemSelected && authorized.ToDeleteForm(userRoleElements) &&
                                    FormStatus.Closed.DoesNotEqual(selectedItems[0].Status); //INC0458131:-Added by Aarti(After Closing an EIP Template form Delete button should be disabled)

        }

        protected override FormEdmontonGN75BDTO CreateDtoFromDomainObject(FormGN75B item)
        {
            return new FormEdmontonGN75BDTO(item);
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN75BFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGN75BFormUpdated += HandleEipIssueRepeaterUpdated;
            remoteEventRepeater.ServerGN75BTemplateFormUpdated += HandleRepeaterUpdated;                     //ayman test test
            remoteEventRepeater.ServerGN75BFormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN75BFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN75BFormUpdated -= HandleEipIssueRepeaterUpdated;
            remoteEventRepeater.ServerGN75BFormRemoved -= HandleRepeaterRemoved;
        }

        protected override bool ShouldBeDisplayed(FormGN75B item)
        {
            FormStatus formStatusFilter = filter.GetFormStatusFilter(this);
            return Equals(item.FormStatus, formStatusFilter);
        }

        public override FormStatus GetDefaultFormStatus()
        {
            return FormStatus.WaitingForApproval;
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
            List<FormEdmontonGN75BDTO> selectedDTOs = grid.SelectedItems;

            List<long> idsForSelectedItems = selectedDTOs.ConvertAll(dto => dto.IdValue);

            //bool confirmed = formService.GN75BIsAssociatedToAGN75AOrActionItem(idsForSelectedItems)
            //    ? page.ShowOKCancelDialog(string.Format(StringResources.DeleteGN75BWithAssociatedGN75OrActionItem, entityName),
            //        string.Format(StringResources.DeleteItemDialogTitle, entityName))
            //    : ShowOKCancelDialogForDelete(entityName);

            if (idsForSelectedItems.Count > 0)
            {
                LockAndDeleteSelectedItems();
            }
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


        //ayman Sarnia eip DMND0008992
        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<FormGN75B> e)
        {
            if (page != null && !page.IsDisposed)
            {
                if (e.SelectedItem != null && e.SelectedItem.FormStatus != FormStatus.Approved)
                {
                    RegisterRenderTimer(CreateDtoFromDomainObject(e.SelectedItem));
                }
            }
            base.HandleRepeaterUpdated(sender, e);
        }

        private void RegisterRenderTimer(FormEdmontonGN75BDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            if (dto.LastModifiedDateTime.AddSeconds(10) < now) return;

            var timeUntilActive = dto.LastModifiedDateTime.Subtract(now);
            SetupTimerCallback(timeUntilActive, dto);
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, FormEdmontonGN75BDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            //if (differenceInTime < timeRemainingInShift)
            //{
            SetupTimerForCallback(dto, differenceInTime);
            // }
        }

        private void SetupTimerForCallback(FormEdmontonGN75BDTO dto, TimeSpan differenceInTime)
        {
            try
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
            catch (TimerDueTimeNegativeException e)
            {
                logger.Error("Encountered negative timer due time for directive:<" + dto.Id + ">", e);
            }
        }

        private void HandleTimerFire(object dto)
        {
            // we are often in a background thread at this point but we need to manipulate the UI, so we make sure to do
            // the real work on the UI thread
            synchronizationContext.Post(RefreshItem, dto);
        }

        private void RefreshItem(object dto)
        {
            if (!(dto is FormEdmontonGN75BDTO)) return;

            if (!(page.Grid is DomainSummaryGrid<FormEdmontonGN75BDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var eipissueDTO = (FormEdmontonGN75BDTO)dto;
            RegisterRenderTimer(eipissueDTO);

            var domainSummaryGrid = ((DomainSummaryGrid<FormEdmontonGN75BDTO>)page.Grid);
            var oldVersion = domainSummaryGrid.FindItem(eipissueDTO.Id);

            if (oldVersion == null) return;

            var updateIndex = domainSummaryGrid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                domainSummaryGrid.AddItem(eipissueDTO);
            }
            else
            {
                domainSummaryGrid.UpdateItem(updateIndex, eipissueDTO);
            }
        }










































        public override DialogResultAndOutput<FormGN75B> Edit(FormGN75B domainObject, IBaseForm view)
        {
            FormGN75BFormPresenter presenter = new FormGN75BFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<FormGN75B> CreateNew(IBaseForm view)
        {
            FormGN75BFormPresenter presenter = new FormGN75BFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override void SetDetailData(FormEdmontonGN75BDetails details, FormGN75B item)
        {
            if (item != null)             //ayman Sarnia eip DMND0008992
            {
                details.Visible = true;
                details.FormNumberString = item.FormNumber.ToString() + " Template #: " + item.TemplateID.ToString();
                //ayman Sarnia eip DMND0008992

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
            else
            {
                details.Visible = false;        //ayman Sarnia eip DMND0008992
            }
        }

        //ayman generic forms
        public override FormGN75B QueryByIdAndSiteId(long id, long siteid)
        {
            return formService.QueryFormGN75BSarniaByIdAndSiteId(id, siteid);
        }

        public override FormGN75B QueryById(long id)
        {
            return formService.QueryFormGN75BSarniaById(id);          //ayman Sarnia eip - 3
        }

        public override IList<FormEdmontonGN75BDTO> GetData(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            //INC0458131 (Aarti)
            if (formStatuses.Contains(FormStatus.Closed))
            {
                // formStatuses.Add(FormStatus.Approved);  //Added approved because the default status is Waiting for approval //INC0453097  Aarti (code commented)
                var eipIssueDtos = formService.QueryFormGN75BSarniaFormDTOsByCriteria(flocSet, formStatuses, ClientSession.GetUserContext().SiteId);    //ayman Sarnia eip DMND0008992
                timerManager.Clear();
                eipIssueDtos.ForEach(RegisterRenderTimer);
                return eipIssueDtos;
            }
            else
            {
                formStatuses.Add(FormStatus.WaitingForApproval);  
                formStatuses.Add(FormStatus.Approved);
                formStatuses.Add(FormStatus.Expired);
                formStatuses.Add(FormStatus.Draft);
                var eipIssueDtos = formService.QueryFormGN75BSarniaFormDTOsByCriteria(flocSet, formStatuses, ClientSession.GetUserContext().SiteId);   
                timerManager.Clear();
                eipIssueDtos.ForEach(RegisterRenderTimer);
                return eipIssueDtos;
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
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formGn75B => formService.UpdateSarniaGN75B(formGn75B, false,"EIP Issue"), form);
        }

        protected override IForm CreateEditForm(FormGN75B form)
        {
            FormGN75BSarniaFormPresenter presenter = new FormGN75BSarniaFormPresenter(form);
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
