using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class WorkPermitSarniaTemplatePagePresenter : AbstractApprovableDomainPagePresenter<WorkPermitDTO, WorkPermit, IWorkPermitDetails, IWorkPermitPage>
    {
        private readonly IWorkPermitService workPermitService;
        private readonly IGasTestElementInfoService gasTestElementInfoService;

        private readonly IWorkPermitFilterSelectorPresenter filterPresenter;
        private readonly WorkPermitForms workPermitForms;
        private readonly IWorkPermitBinder workPermitBinder;

        public WorkPermitSarniaTemplatePagePresenter()
            : this(new WorkPermitTemplatePage())
        {
        }

        public WorkPermitSarniaTemplatePagePresenter(IWorkPermitPage page)
            : this(
                page,
                new WorkPermitFilterSelectorPresenter(new WorkPermitFilterSelectorForm()),
                new Authorized(),
                new WorkPermitBinder(ClientSession.GetUserContext().SiteId),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<IWorkPermitService>(),
                ClientServiceRegistry.Instance.GetService<IGasTestElementInfoService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        protected WorkPermitSarniaTemplatePagePresenter(
            IWorkPermitPage page,
            IWorkPermitFilterSelectorPresenter filterPresenter,
            IAuthorized authorized,
            IWorkPermitBinder workPermitBinder,
            IRemoteEventRepeater remoteEventRepeater,
            IObjectLockingService objectLockingService,
            IWorkPermitService workPermitService,
            IGasTestElementInfoService gasTestElementInfoService,
            ITimeService timeService,
            IUserService userService)
            : base(page, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {
            this.workPermitBinder = workPermitBinder;
            this.workPermitService = workPermitService;
            this.gasTestElementInfoService = gasTestElementInfoService;

            workPermitForms = new WorkPermitFormsFactory().Build();

            this.filterPresenter = filterPresenter;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            page.Details.CloseWorkPermit += CloseWorkPermit;
            page.Details.Print += Print;
            page.Details.PrintPreview += PrintPreview;
            page.Details.Copy += Copy;
            page.Details.Clone += Clone;
            page.Details.RefreshAll += RefreshAll;
            page.Details.SetFilter += SetFilter;

            page.Details.ViewAttachment += ViewAttachment;
            //Added by ppanigrahi
            page.Details.Extension += ExtensionWorkpermit;
            page.Details.Revalidation += RevalidationWorkpermit;

            //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            page.Details.MarkAsTemplate += MarkAsTemplate;
            page.Details.UnMarkTemplate += UnMarkTemplate;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.CloseWorkPermit -= CloseWorkPermit;
            page.Details.Print -= Print;
            page.Details.PrintPreview -= PrintPreview;
            page.Details.Copy -= Copy;
            page.Details.Clone -= Clone;
            page.Details.RefreshAll -= RefreshAll;
            page.Details.SetFilter -= SetFilter;

            page.Details.ViewAttachment -= ViewAttachment;

            //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            page.Details.MarkAsTemplate -= MarkAsTemplate;
            page.Details.UnMarkTemplate -= UnMarkTemplate;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(WorkPermit item)
        {
            return new EditWorkPermitHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(WorkPermit item)
        {
            return workPermitForms.EditForm(item);
        }

        protected override void Edit(WorkPermit domainObject)
        {
            //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

            List<WorkPermitDTO> permitDtos = page.SelectedItems;
            if (permitDtos.Count == 1)
            {
                bool isWorkPermit = true;
                MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);

                nameForm.WorkPermitTemplateName = permitDtos[0].TemplateName;
                nameForm.Category = permitDtos[0].Categories;
                nameForm.Global = permitDtos[0].Global;

                if (nameForm.Global)
                {
                    nameForm.Individual = false;
                }
                else
                {
                    nameForm.Individual = true;
                }

                nameForm.ShowDialog();
                
                WorkPermit workPermit = QueryForFirstSelectedItem();
                workPermit.TemplateName = nameForm.WorkPermitTemplateName;
                workPermit.Categories = nameForm.Category;
                workPermit.Global = nameForm.Global;
                workPermit.Individual = nameForm.Individual;

                workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
                workPermit.LastModifiedDate = Clock.Now;

                var wp = workPermitService.QueryByIdTemplate(workPermit.IdValue, workPermit.TemplateName, workPermit.Categories);

                if (wp != null)
                {
                    if (workPermit.TemplateName == wp._templateName && workPermit.Categories == wp._categories && nameForm.Save != false)
                    {
                        OltMessageBox.ShowError("Same Template Name and Category entry is already present. " +
                                                "Cannot proceed further, please change the Temlate name and Category");
                    }
                }
                else
                {
                    if (workPermit.TemplateName != string.Empty)
                    {
                        workPermit.TemplateId = permitDtos[0].TemplateId;
                        workPermit.IsTemplate = true;
                        workPermit.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;
                        ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.UpdateTemplate, workPermit);
                    }
                    else
                    {
                        workPermit.IsTemplate = false;
                    }
                }


            }
        }

        protected virtual WorkAssignment WorkAssignment
        {
            // This is null for this presenter because it is used to query data, and 'null' means 'all work assignments'
            get { return null; }
        }

        public override void ApproveButton_Clicked()
        {
            List<WorkPermitDTO> permitDtos = page.SelectedItems;

            if (page.ShowOKCancelDialog(string.Format(StringResources.ApproveItemDialogText, DomainObjectName),
                                        string.Format(StringResources.ApproveItemDialogTitle, DomainObjectName)))
            {
                List<WorkPermit> permits = ConvertAllTo(permitDtos);

                if (permits.Count == 1)
                {
                    ApproveSingleSelectedPermit(permits[0]);
                }
                else
                {
                    ApproveMultipleSelectedPermits(permits);
                }
            }
        }

        private void ApproveSingleSelectedPermit(WorkPermit permit)
        {
            if (AllowPermitToBeApproved(permit))
            {
                LockMultipleDomainObjects(Approve, new List<WorkPermit> { permit }, null);
            }
        }

        private void ApproveMultipleSelectedPermits(List<WorkPermit> permits)
        {
            var validPermits = new List<WorkPermit>();
            var permitsWithWarnings = new List<WorkPermit>();

            permits.Classify(validPermits, permitsWithWarnings,
                             permit =>
                             {
                                 var issues = new WorkPermitSectionsValidator(permit, authorized).Validate();
                                 return issues.Count == 0;
                             });

            LockMultipleDomainObjects(Approve, validPermits, null);

            if (permitsWithWarnings.Count > 0 &&
                page.ShowYesNoDialog(ApprovePermitsWithWarningsConfirmationMessage(permitsWithWarnings),
                                     StringResources.ApprovePermitsWithWarningsConfirmationTitle))
            {
                LockMultipleDomainObjects(Approve, permitsWithWarnings, null);
            }
        }

        private static string ApprovePermitsWithWarningsConfirmationMessage(List<WorkPermit> permits)
        {
            using (StringWriter writer = new StringWriter())
            {
                writer.WriteLine(StringResources.ApprovePermitsWithWarningsConfirmationHeader);
                writer.WriteLine();

                permits.ForEach(
                    permit =>
                    writer.WriteLine(StringResources.ApprovePermitsWithWarningsConfirmationBodyDetail, permit.PermitNumber));

                writer.WriteLine();
                writer.WriteLine(StringResources.ApprovePermitsWithWarningsConfirmationFooter);
                return writer.ToString();
            }
        }

        public void Print(object sender, EventArgs args)
        {
            if (ClientSession.GetUserContext().IsSarniaSite &&
                ClientSession.GetUserContext().SiteConfiguration.EnableWorkPermitSignature &&
                page.SelectedItems.Count == 1)
            {
                WorkPermitSarniaSign workPermitSign = new WorkPermitSarniaSign(page.SelectedItems[0]);
                DialogResult Result = workPermitSign.ShowDialog();
                if (Result == DialogResult.Yes)
                {
                    PrintWithDialogFocus(Print);

                }
                return;
            }

            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            List<WorkPermit> permits = ConvertAllTo(page.SelectedItems);
            //ayman USPipeline workpermit
            if (ClientSession.GetUserContext().IsDenverSite)
            {
                int numberOfOldPermits = permits.Count(permit => WorkPermit.IsOldVersionForDenver(permit.Version));
                int numberOfNewPermits = permits.Count(permit => !WorkPermit.IsOldVersionForDenver(permit.Version));

                if (numberOfOldPermits > 0 && numberOfNewPermits > 0)
                {
                    OltMessageBox.ShowError(StringResources.WorkPermit_CannotPrintMultipleFormats, StringResources.WorkPermit_CannotPrintMultipleFormats_Title);
                    return;
                }
            }

            if (ClientSession.GetUserContext().IsUSPipelineSite || ClientSession.GetUserContext().IsSELCSite) // mangesh uspipeline to selc
            {
                int numberOfOldPermitsUSPipeline = permits.Count(permit => WorkPermit.IsOldVersionForUSPipeline(permit.Version));
                int numberOfNewPermitsUSPipeline = permits.Count(permit => !WorkPermit.IsOldVersionForUSPipeline(permit.Version));
                if (numberOfOldPermitsUSPipeline > 0 && numberOfNewPermitsUSPipeline > 0)
                {
                    OltMessageBox.ShowError(StringResources.WorkPermit_CannotPrintMultipleFormats, StringResources.WorkPermit_CannotPrintMultipleFormats_Title);
                    return;
                }
            }

            workPermitForms.ReportPrintManager(workPermitService, page, permits[0].Version).PrintReport(permits);

           
        }

        public void PrintPreview(object sender, EventArgs args)
        {
            WorkPermit permit = QueryForFirstSelectedItem();
            workPermitForms.ReportPrintManager(workPermitService, page, permit.Version).PreviewReport(permit);
        }

        public static List<WorkPermitStatus> DefaultStatuses
        {
            get
            {
                return new List<WorkPermitStatus>
                           {
                               WorkPermitStatus.Pending,
                               WorkPermitStatus.Approved,
                               WorkPermitStatus.Complete,
                               WorkPermitStatus.Rejected,
                               WorkPermitStatus.Issued
                           };
            }
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            UserShift userShift = userContext.UserShift;

            List<WorkPermit> workPermits = ConvertAllTo(page.SelectedItems);
            bool hasSingleItemSelected = workPermits.Count == 1;
            bool hasItemsSelected = workPermits.Count > 0;

            WorkPermit workPermit = QueryForFirstSelectedItem();   //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

            IWorkPermitDetails details = page.Details;

            details.DeleteVisible = hasSingleItemSelected;

            details.editVisible = hasSingleItemSelected;

            details.closeButtonVisible = false;
            details.printButtonVisible = false;
            details.printPreviewButtonVisible = false;
            details.editHistoryButtonVisible = false;
            details.approveButtonVisible = false;
            details.ScanbuttonButtonVisible = false;
            details.rejectButtonVisible = false;
            details.commentButtonVisible = false;
            details.copyButtonVisible = false;
            details.ExtensionButtonVisible = false;
            details.revalidationButtonVisible = false;
            details.MarkTemplateEnabled = false;
            details.viewAttachementbuttonVisible = false;
            details.CloneEnabled = hasSingleItemSelected && (authorized.ToCloneWorkPermitWithNoRestriction(userRoleElements) || authorized.ToCloneWorkPermitWithSomeRestrictions(userRoleElements));
        }
        private static bool Isworkpermitexpired(WorkPermit dto)
        {
            return dto.EndDateTime < Clock.Now;
        }
        private static bool Isworkpermitexpiredforrevalidation(WorkPermit dto)
        {
            return (dto.ExtensionDateTime != null) ? dto.ExtensionDateTime < Clock.Now : dto.EndDateTime < Clock.Now;
            //if (dto.ExtensionDateTime != null) { return dto.ExtensionDateTime < Clock.Now; }
            //else { return dto.EndDateTime < Clock.Now; } 
        }
        private static bool PermitHasBeenIssued(WorkPermit dto)
        {
            return (WorkPermitStatus.Issued.Equals(dto.WorkPermitStatus));
        }
        private static bool PermitHasBeenRejected(WorkPermit dto)
        {
            return (WorkPermitStatus.Rejected.Equals(dto.WorkPermitStatus));
        }

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void SetStatusAndUpdate(WorkPermit workPermit, WorkPermitStatus status)
        {
            User approver = ClientSession.GetUserContext().User;
            workPermit.SetWorkPermitStatusAndApprover(status, approver);
            workPermit.LastModifiedBy = approver;
            workPermit.LastModifiedDate = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, workPermit);
        }

        public void CloseWorkPermit(object sender, EventArgs e)
        {
            LockMultipleDomainObjects(CloseWorkPermits, LockType.Close);
        }

        private void CloseWorkPermits(List<WorkPermit> workPermits)
        {
            IWorkPermitCloseFormView workPermitCloseView = new WorkPermitCloseForm();
            new WorkPermitCloseFormPresenter(workPermitCloseView, workPermits);
            workPermitCloseView.ShowDialog(page.ParentForm);
        }

        protected override void Comment(WorkPermit workPermit)
        {
            page.DisplayCommentsForm(workPermit);
        }

        protected override void Approve(WorkPermit permit)
        {
            try
            {
                if (permit.StartAndOrEndTimesFinalized == false)
                {
                    permit.StartAndOrEndTimesFinalized = true;
                }

                SetStatusAndUpdate(permit, WorkPermitStatus.Approved);
            }
            catch (Exception)
            {
                page.DisplayInvalidActionMessage(
                    StringResources.WorkPermitApprovalFailureMessageBoxText,
                    StringResources.WorkPermitApprovalFailureMessageBoxCaption);
            }
        }

        protected override void Reject(WorkPermit workPermit)
        {
            try
            {
                SetStatusAndUpdate(workPermit, WorkPermitStatus.Rejected);
            }
            catch
            {
                page.DisplayInvalidActionMessage(
                    StringResources.WorkPermitRejectionFailureMessageBoxText,
                    StringResources.WorkPermitRejectionFailureMessageBoxCaption);
            }
        }

        protected override void Delete(WorkPermit workPermit)
        {

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

            List<WorkPermitDTO> permitDtos = page.SelectedItems;
            try
            {
                workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
                workPermit.LastModifiedDate = Clock.Now;
                if (permitDtos.Count == 1)
                {
                    workPermit.TemplateId = permitDtos[0].TemplateId;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.RemoveTemplate, workPermit); 
                }
                
            }
            catch
            {
                page.DisplayInvalidActionMessage(
                    StringResources.WorkPermitDeletionFailureMessageBoxText,
                    StringResources.WorkPermitDeletionFailureMessageBoxCaption);
            }
        }

        protected override bool ShouldBeDisplayed(WorkPermit item)
        {
            return item.IsNot(WorkPermitStatus.Archived);
        }

        public void Clone(object sender, EventArgs args)
        {
            WorkPermit workPermit = QueryForFirstSelectedItem();
            if (workPermit != null)
            {
                ICloneWorkPermitFormView cloneWorkPermitView = workPermitForms.CloneForm();
                cloneWorkPermitView.OriginalWorkPermit = workPermit;
                if (cloneWorkPermitView.ShowDialog(page.ParentForm) == DialogResult.OK)
                {

                    WorkPermit clonedWorkPermit = cloneWorkPermitView.ClonedWorkPermit;

                    // Added by Vibhor : DMND0011077 - Work Permit Clone History

                    if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                    {
                        clonedWorkPermit.ClonedFormDetailSarnia = cloneWorkPermitView.OriginalWorkPermit.PermitNumber;
                    }
                    if (ClientSession.GetUserContext().Site.Id == Site.DENVER_ID)
                    {
                        clonedWorkPermit.ClonedFormDetailDenver = cloneWorkPermitView.OriginalWorkPermit.PermitNumber;
                    }



                    
                    //update the created by to the current user
                    clonedWorkPermit.SetCreatedBy(userContext.User, !userContext.Role.IsWorkPermitNonOperationsRole);
                    clonedWorkPermit.LastModifiedDate = Clock.Now;

                    ////clonedWorkPermit.CraftOrTradeName = "";
                    ////(clonedWorkPermit.Specifics.craftOrTrade).Name = "";
                    //(clonedWorkPermit.Specifics.CraftOrTrade).Name = null;
                    //clonedWorkPermit.Specifics.CraftOrTradeName = null;


                    clonedWorkPermit.Specifics.FunctionalLocation = null;
                    
                    
                    clonedWorkPermit.Specifics.WorkOrderNumber = "";
                    clonedWorkPermit.Specifics.ContractorCompanyName = "";
                    clonedWorkPermit.EquipmentPreparationCondition.EnergyIsolationPlanNumber = "";


                    

                    IForm newForm = workPermitForms.EditForm(clonedWorkPermit);
                    newForm.ShowDialog(page.ParentForm);
                }
            }
        }
        //Added by ppanigrahi
        private void ExtensionWorkpermit(object sender, EventArgs e)
        {
            
            WorkPermit workPermit = QueryForFirstSelectedItem();
            if (workPermit.EndDateTime < Clock.Now)
            {

                OltMessageBox.Show(Form.ActiveForm,"Permit has already Expired", "Alert");
                return;

            }
            if (workPermit.FunctionalLocation.Site.Id == Site.SARNIA_ID)
            {
                //if(workPermit.)      
                workPermit.ExtensionEnable = true;
                PopupSarniaExtension form = new PopupSarniaExtension(workPermit, true, page);

               //  form.StartPosition = FormStartPosition.Manual;
    
              //  Screen scr = Screen.FromPoint(form.Location);
             //   form.Location = new Point(scr.WorkingArea.Left - form.Width, scr.WorkingArea.Top);
             //  form.Location= new Point(page.Details..Location.X + (this.Width - loadingCircle.Width) / 2, this.Location.Y + (this.Height - loadingCircle.Height) / 2););
                if (form != null)
                {
                    form.ShowDialog();
                    form.Dispose();
                }
            }
        }

        //Added by ppanigrahi
        private void RevalidationWorkpermit(object sender, EventArgs e)
        {

            WorkPermit workPermit = QueryForFirstSelectedItem();
            //workpermit.EndDateTime.Value = ExtensionDateTime.Value;
            //UserContext userContext = ClientSession.GetUserContext();
            // UserShift currentShift = userContext.UserShift;

            // UserShift shiftOnPermitStartDate = currentShift.RollToStartDate(currentShift.StartDate);
            //  workPermit.Specifics.ReInitializeStartAndOrEndDateTimes(ClientSession.GetUserContext().User.WorkPermitDefaultTimePreferences, shiftOnPermitStartDate, Clock.Now);
            //   workPermit.EndDateTime.Value = Clock.Now;
            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, workPermit);
            //  workPermit.ExtensionRevalidationDateTime = workPermit.EndDateTime;
            if (workPermit.EndDateTime < Clock.Now)
            {

                OltMessageBox.Show(Form.ActiveForm, "Permit has already Expired", "Alert");
                return;

            }
            workPermit.RevalidationEnable = true;
            workPermit.ExtensionEnable = false;
            if (workPermit.Revalidation == null)
            {
                workPermit.Revalidation = 1;
            }
            else
            {
                workPermit.Revalidation = workPermit.Revalidation.Value + 1;
            }
            if (workPermit.ISSUER_SOURCEXTENSION == null)
            {
                workPermit.ISSUER_SOURCEXTENSION = Convert.ToString(ClientSession.GetUserContext().User.FirstName).ToUpper() + " " + Convert.ToString(ClientSession.GetUserContext().User.LastName).ToUpper();
                
            }
            else
            {
                workPermit.ISSUER_SOURCEXTENSION = Convert.ToString(ClientSession.GetUserContext().User.FirstName).ToUpper() + " " + Convert.ToString(ClientSession.GetUserContext().User.LastName).ToUpper();
            }
            //UpdateWorkPermit(workPermit);
            if (workPermit.BeforeExtensionDateTime == null)
            {
                workPermit.BeforeExtensionDateTime = workPermit.EndDateTime;
            }

            page.Details.ToolStripEnabled = false;
            Print(workPermit);
            page.Details.ToolStripEnabled = true;
           
           
           
        }

        //Added by ppanigrahi
        private void Print(WorkPermit workpermit)
        {
            List<WorkPermitDTO> permitDtos = page.SelectedItems;
            List<WorkPermit> permits = ConvertAllTo(permitDtos);
          //  IReportPrintManager<WorkPermit> reportPrintManager;
          //  LockMultipleDomainObjects(permits => reportPrintManager.PrintReport(permits,), LockType.Print);
           //  reportPrintManager = new ReportPrintManager<WorkPermit, WorkPermitSarniaReport, WorkPermitSarniaReportAdapter>(new WorkPermitSarniaPrintActions(workPermitService,page));
          // reportPrintManager.PrintReport()
          //   LockMultipleDomainObjects(permits => reportPrintManager.PrintReport(permits,workPermitService), LockType.Print);
           PrintReport(permits, workpermit);
          
            
            
        }
        public void PrintReport(List<WorkPermit> objectsToPrint, WorkPermit workpermit)
        {
            WorkPermitSarniaPrintActions printActions = new WorkPermitSarniaPrintActions(workPermitService, page);
            bool shouldContinuePrinting = printActions.BeforeFirstPrint(objectsToPrint);
            ILog logger = GenericLogManager.GetLogger<ReportPrintManager<WorkPermit, WorkPermitSarniaReport, WorkPermitSarniaReportAdapter>>();
            if (!shouldContinuePrinting)
                return;

            ReportPrintPreference reportPrintPreferences = printActions.CreateReportPrintPreferences();
           PrintOptions selectedPrintOptions = reportPrintPreferences.GetPrintOptionsViaPrintDialog();

            if (selectedPrintOptions == null)  // Print was cancelled
                return;

            Form activeForm = Form.ActiveForm;
            SplashScreenManager.ShowForm(activeForm, typeof(WaitForm), true, true, false);

            foreach (WorkPermit domainObject in objectsToPrint)
            {
                // pre-processing of the report domain object.
                printActions.BeforePrintAction(domainObject);

                XtraReport report = printActions.CreateReport(domainObject);

                bool printSucceeded = Print(report, selectedPrintOptions, logger, printActions);
                if (printSucceeded)
                {
                    printActions.AfterPrintAction(domainObject);
                }

            }


           // ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, workpermit);
            UpdateWorkPermit(workpermit);
            SplashScreenManager.CloseForm(false, 0, activeForm, true);
        }
        private bool Print(XtraReport report, PrintOptions selectedPrintOptions, ILog logger, WorkPermitSarniaPrintActions printActions)
        {
            SplashScreenManager splashScreenManager = new SplashScreenManager(Form.ActiveForm, typeof(WaitForm), true, true);

            try
            {
                selectedPrintOptions.ApplyToReport(report); // maybe move this into start print?
                ReportPrintTool tool = new ReportPrintTool(report);
                tool.PrintingSystem.ShowPrintStatusDialog = false;

                tool.PrintingSystem.StartPrint += delegate(object sender, PrintDocumentEventArgs args)
                {
                    if (!splashScreenManager.IsSplashFormVisible)
                        splashScreenManager.ShowWaitForm();

                    PrinterSettings printerSettings = args.PrintDocument.PrinterSettings;
                    printerSettings.Duplex = selectedPrintOptions.Duplex;
                    printerSettings.Copies = (short)selectedPrintOptions.NumberOfCopies;
                    printerSettings.Collate = selectedPrintOptions.Collate;
                    printerSettings.PrintRange = selectedPrintOptions.PrintRange;
                };

                tool.PrintingSystem.EndPrint += delegate
                {
                    if (splashScreenManager.IsSplashFormVisible)
                    {
                        splashScreenManager.CloseWaitForm();
                        splashScreenManager.WaitForSplashFormClose();
                    }
                };

                tool.PrintingSystem.PrintProgress += delegate(object sender, PrintProgressEventArgs args)
                {
                    if (!splashScreenManager.IsSplashFormVisible)
                    {
                        splashScreenManager.ShowWaitForm();
                    }

                    splashScreenManager.SetWaitFormCaption(StringResources.ReportPrinting_Caption);
                    splashScreenManager.SetWaitFormDescription(GetPrintWaitFormDescription(sender, args));
                };

                tool.Print(selectedPrintOptions.PrinterName);
                return true;
            }
            catch (Exception e)
            {
                if (splashScreenManager.IsSplashFormVisible)
                {
                    splashScreenManager.CloseWaitForm();
                    splashScreenManager.WaitForSplashFormClose();
                }
                logger.Error("There was an error printing.", e);
                printActions.ShowNotAbleToPrintError();
                return false;
            }
        }
        private string GetPrintWaitFormDescription(object sender, PrintProgressEventArgs args)
        {
            string text;
            if (args.PageSettings.PrinterSettings.PrintRange == PrintRange.AllPages && sender is PrintingSystemBase)
            {
                PrintingSystemBase printingSystem = sender as PrintingSystemBase;
                text = string.Format(StringResources.ReportPrinting_Description_Format_With_Total, args.PageIndex + 1, printingSystem.Pages.Count);
            }
            else
            {
                text = string.Format(StringResources.ReportPrinting_Description_Format, args.PageIndex + 1);
            }
            return text;
        }
      
        public void UpdateWorkPermit(WorkPermit permit)
        {
            permit.LastModifiedBy = ClientSession.GetUserContext().User; ;
            permit.LastModifiedDate = Clock.Now;
            permit.ExtensionRevalidationDateTime = permit.EndDateTime;
            // permit.Specifics.EndDateTime = workpermit.ExtensionRevalidationDateTime.Value;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, permit);
        }

        public void Copy(object sender, EventArgs args)
        {
            WorkPermit workPermit = QueryForFirstSelectedItem();
            if (workPermit != null)
            {
                ICopyWorkPermitFormView copyForm = workPermitForms.CopyForm();
                new CopyWorkPermitFormPresenter(copyForm, workPermit);
                copyForm.ShowDialog(page.ParentForm);
            }
        }

        private void SetFilter(object sender, EventArgs e)
        {
            if (page.Details.ShowButtonAppearance == Constants.SHOW_DATE_RANGE_WIDGET_APPEARANCE)
            {
                bool confirmedChanges = filterPresenter.DisplaySelector();

                if (confirmedChanges)
                {
                    Range<Date> dateRange = filterPresenter.DateRange;
                    List<WorkPermitStatus> statuses = filterPresenter.SelectedStatuses;

                    List<WorkPermitDTO> dtos = workPermitService.QueryByDateRangeAndStatuses(
                        ClientSession.GetUserContext().RootFlocSet,
                        statuses,
                        dateRange,
                        WorkAssignment);

                    RefreshData(dtos, dateRange);
                    page.Details.ShowButtonAppearance = Constants.SHOW_CURRENT_WIDGET_APPEARANCE;
                }
            }
            else
            {
                IList<WorkPermitDTO> workPermitDtos = GetDtos(null);
                RefreshData(workPermitDtos, GetDefaultDateRange());
                page.Details.ShowButtonAppearance = Constants.SHOW_DATE_RANGE_WIDGET_APPEARANCE;
            }
        }

        protected override bool IsItemInDateRange(WorkPermit workPermit, Range<Date> dateRange)
        {
            DateTime startDateTime = dateRange.LowerBound.CreateDateTime(Time.START_OF_DAY);
            Date bound = dateRange.UpperBound;

            if (bound == null)
            {
                return workPermit.StartDateTime >= startDateTime;
            }

            DateTime endDateTime = bound.CreateDateTime(Time.END_OF_DAY);
            return workPermit.StartDateTime >= startDateTime && workPermit.StartDateTime <= endDateTime;
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;
            DateTime currentTimeAtSite = Clock.Now;

            int daysToDisplayWorkPermitsBackwards = siteConfiguration != null ? siteConfiguration.DaysToDisplayWorkPermitsBackwards : 15;
            Date startRange = new Date(currentTimeAtSite.SubtractDays(daysToDisplayWorkPermitsBackwards));

            Date endRange = null;
            if (siteConfiguration != null && siteConfiguration.DaysToDisplayWorkPermitsForwards > 0)
            {
                endRange = new Date(currentTimeAtSite.AddDays(siteConfiguration.DaysToDisplayWorkPermitsForwards));
            }

            return new Range<Date>(startRange, endRange);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitCreated += repeater_Created;
            remoteEventRepeater.ServerWorkPermitUpdated += repeater_Updated;
            remoteEventRepeater.ServerWorkPermitRemoved += repeater_Removed;

            //remoteEventRepeater.ServerWorkPermitCreated_Template += repeater_Created;

            
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitCreated -= repeater_Created;
            remoteEventRepeater.ServerWorkPermitUpdated -= repeater_Updated;
            remoteEventRepeater.ServerWorkPermitRemoved -= repeater_Removed;

            //remoteEventRepeater.ServerWorkPermitCreated_Template -= repeater_Created;
            
            
        }

        protected override WorkPermit QueryByDto(WorkPermitDTO dto)
        {
            if (ClientSession.GetUserContext().IsUSPipelineSite || ClientSession.GetUserContext().IsSELCSite) // mangesh uspipeline to selc
                return workPermitService.QueryByIdForUSPipeline(dto.IdValue);         //ayman USPipeline workpermit
            return workPermitService.QueryById(dto.IdValue);
        }

        protected override void SetDetailData(IWorkPermitDetails details, WorkPermit permit)
        {
            // Need to set version first, before any other properties on the details.
            // When we have more time to make bigger changes, we can enforce this.
            details.WorkPermitVersion = permit.Version;

            details.SetRequiredSpecialPrecautionsComments(); // JOE: Not going to do it this way anymore, going to define an ISpecialPrecautionXYZ property on the interface
            details.SpecialProtectiveClothingTypeAcidClothingTypeChoices = new List<AcidClothingType>(AcidClothingType.All);

            workPermitBinder.ToView(permit, details.BindingTarget, permit.Version);

            // JOE: Not flagged with the attribute (CreatedBy, ApprovedBy, LastModifiedBy)
            details.Author = permit.CreatedBy;
            details.Approver = permit.ApprovedBy;
            details.LastModifier = permit.LastModifiedBy;

            LoadWorkItemGasTests(details, permit);
        }


        private static void LoadWorkItemGasTests(IWorkPermitDetails details, WorkPermit permit)
        {
            details.GasTestElementResults = new GasTestElementResultDTOConverter().ConvertAll(permit);

        }

        private bool AllowPermitToBeApproved(WorkPermit workPermit)
        {
            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, authorized);
            var issues = workPermitSectionsValidator.Validate();
            if (issues.Count == 0)
            {
                return true;
            }

            // TODO: Not sure how you get here if the button is disabled first because there are required and required for approval validation issues.

            var requiredPermitSections = issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning)
                .ConvertAll(issue => ((SectionValidationError)issue).WorkPermitSection);
            var optionalPermitSections = issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning)
                .ConvertAll(issue => ((SectionValidationError)issue).WorkPermitSection);

            string requiredText = BuildRequiredValidationText(workPermit, requiredPermitSections);
            string optionalText = BuildOptionalValidationText(workPermit, optionalPermitSections);

            if (issues.Exists(issue => issue.ProblemLevel == ProblemLevel.Warning) && issues.Exists(issue => issue.ProblemLevel > ProblemLevel.Warning))
            {
                page.DisplayInvalidWorkPermitMessage(optionalText + requiredText, StringResources.PermitMissingRequiredSectionsTitle);
                return false;
            }
            if (issues.Exists(issue => issue.ProblemLevel > ProblemLevel.Warning))
            {
                page.DisplayInvalidWorkPermitMessage(requiredText, StringResources.PermitMissingRequiredSectionsTitle);
                return false;
            }
            if (issues.Exists(issue => issue.ProblemLevel == ProblemLevel.Warning))
            {
                string message = optionalText + " " + StringResources.PermitMissingOptionalSectionsFooter;
                return page.DisplayOptionalInvalidWorkPermitMessage(message,
                                                                    StringResources.PermitMissingOptionalSectionsTitle);
            }

            return true;
        }

        private static string BuildOptionalValidationText(WorkPermit workPermit, ICollection<WorkPermitSection> sections)
        {
            var optionalText = new StringBuilder();

            if (sections.Count > 0)
            {
                optionalText.AppendFormat(StringResources.PermitMissingOptionalSectionsMessage,
                                          workPermit.PermitNumber);
                optionalText.AppendLine();
                optionalText.AppendLine();
                foreach (WorkPermitSection section in sections)
                {
                    optionalText.AppendFormat(StringResources.PermitMissingSectionName, section.Name);
                    optionalText.AppendLine();
                }
                optionalText.AppendLine();
            }

            return optionalText.ToString();
        }

        private static string BuildRequiredValidationText(WorkPermit workPermit, ICollection<WorkPermitSection> sections)
        {
            var requiredText = new StringBuilder();

            if (sections.Count > 0)
            {
                requiredText.AppendFormat(StringResources.PermitMissingRequiredSectionsMessage,
                                          workPermit.PermitNumber);
                requiredText.AppendLine();
                requiredText.AppendLine();
                foreach (WorkPermitSection section in sections)
                {
                    requiredText.AppendFormat(StringResources.PermitMissingSectionName, section.Name);
                    requiredText.AppendLine();
                }

                requiredText.AppendLine();
                requiredText.AppendFormat(StringResources.PermitMissingRequiredSectionsFooter);
                requiredText.AppendLine();
            }

            return requiredText.ToString();
        }

        protected override WorkPermitDTO CreateDTOFromDomainObject(WorkPermit domainObject)
        {
            return new WorkPermitDTO(domainObject);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override IList<WorkPermitDTO> GetDtos(Range<Date> dateRange)
        {
            if (dateRange == null)
            {
                return workPermitService.QueryByDateRangeAndStatuses(
                    ClientSession.GetUserContext().RootFlocSet,
                    DefaultStatuses,
                    GetDefaultDateRange(),
                    WorkAssignment);
            }
           //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            if (page.TabText == StringResources.WorkPermitTemplates)
            {
                var username = ClientSession.GetUserContext().User.Username;

                return workPermitService.QueryByDateRangeAndStatusesForTemplate(
                ClientSession.GetUserContext().RootFlocSet,
                DefaultStatuses,
                dateRange,
                WorkAssignment, true, username);
            }
            else
            {
                return workPermitService.QueryByDateRangeAndStatuses(
                  ClientSession.GetUserContext().RootFlocSet,
                  DefaultStatuses,
                  dateRange,
                  WorkAssignment);  
            }
            
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.WorkPermits; }
        }


        private void ViewAttachment(object sender, EventArgs e)
        {

            WorkPermit workPermit = QueryForFirstSelectedItem();
            IWorkPermitEdmontonService workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            List<WorkpermitScan> lst = workPermitEdmontonService.GetWorkpermitScan(Convert.ToString(workPermit.PermitNumber), Convert.ToInt32(userContext.Site.Id));
            WorkPermitAttachment AttachementForm = new WorkPermitAttachment(lst);

            if (lst != null && lst.Count > 0)
            {

                AttachementForm.ShowDialog();
            }
            //workPermit.Id
        }

       //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        private void MarkAsTemplate(object sender, EventArgs e)
        {
            //bool isWorkPermit = true;
            //MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);
            //nameForm.ShowDialog();
            //WorkPermit workPermit = QueryForFirstSelectedItem();
            //workPermit.TemplateName = nameForm.WorkPermitTemplateName;
            //workPermit.Categories = nameForm.Category;
            //workPermit.Global = nameForm.Global;
            //workPermit.Individual = nameForm.Individual;
            

            //var wp = workPermitService.QueryByIdTemplate(workPermit.IdValue, workPermit.TemplateName, workPermit.Categories);

            //if (wp != null)
            //{
            //    if (workPermit.TemplateName == wp._templateName && workPermit.Categories == wp._categories)
            //    {
            //        OltMessageBox.ShowError("Same Template Name and Category entry is already present. " +
            //                                "Cannot proceed further, please change the Temlate name and Category");
            //    }
            //}
            //else
            //{
            //    if (workPermit.TemplateName != string.Empty)
            //    {
            //        workPermit.IsTemplate = true;
            //        workPermit.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;
            //        ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, workPermit);
            //    }
            //    else
            //    {
            //        workPermit.IsTemplate = false;
            //    }
            //}
            
        }


        private void UnMarkTemplate(object sender, EventArgs e)
        {

            //WorkPermit workPermit = QueryForFirstSelectedItem();

            //if (workPermit.IsTemplate)
            //{
            //    workPermit.IsTemplate = false;
            //    workPermit.IsActiveTemplate = false;
            //    workPermit.TemplateName = "";
            //}

            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, workPermit);
        }

    }
}
