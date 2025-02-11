﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraPrinting;
using log4net;


namespace Com.Suncor.Olt.Client.Presenters
{
    class PopupSarniaExtensionPresenter //: AddEditBaseFormPresenter<T, WorkPermit>, IWorkPermitSarniaPrintable where T : IWorkPermitFormView
    {
        private readonly IWorkPermitService service;
        // private DateTime? extensiondatetime;
        WorkPermit permit;
        private IPopupSarniaExtension view;
        private IWorkPermitPage page;
        private readonly IReportPrintManager<WorkPermit> reportPrintManager;
        private readonly WorkPermitForms workPermitForms;
        public delegate void Notify();
        //  public event Notify PrintReport;


        // public PopupSarniaExtensionPresenter() : this(null);
        public PopupSarniaExtensionPresenter(WorkPermit editobject, bool isExtensible, IPopupSarniaExtension view, IWorkPermitPage page)
        //  : base(new WorkPermitFormSarnia(), editobject)
        {
            //ExtensionDateTime = view.ExtensionDateTime;

            var clientServiceRegistry = ClientServiceRegistry.Instance;
            service = clientServiceRegistry.GetService<IWorkPermitService>();
            this.permit = editobject;
            SubscribeToEvents(view);
            this.view = view;
            this.page = page;
            workPermitForms = new WorkPermitFormsFactory().Build();
            // this.PrintReport += new Notify(PrinttheReport);

        }

        private void SubscribeToEvents(IPopupSarniaExtension view)
        {
            view.SaveButtonClicked += view_SaveButtonClicked;
            view.CancelButtonClick += view_CancelButtonClick;
            view.FormLoad += HandleViewLoad;
            view.ExpiryDateTime = permit.EndDateTime.Value;
            //view.ExtensionDateTime = permit.EndDateTime.Value;


        }
        public bool? AskIfTheyWantToPrintTheForms()
        {
            var dialogResult =
                OltMessageBox.Show(Form.ActiveForm,
                    "Do you want to print all forms associated to this safe work permit?",
                    "Print Associated Forms?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Cancel) return null;
            return dialogResult == DialogResult.Yes;
        }
        public void ShowPrintingFailedMessage()
        {
            view.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }
        public bool IsOnlyPrintingOnePermit { get; set; }
        public bool ShouldNotPrintForms { get; set; }
        public void ShowUnableToPrintWithExpiryDateInPastMessage()
        {

            view.DisplayErrorMessageDialog(StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPast,
                StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPastDialogTitle);
        }
        public void UpdateWorkPermit(WorkPermit permit)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, permit);
        }

        private void view_SaveButtonClicked(object args, EventArgs e)
        {

            CreateForExtension(permit);

        }

        private void view_CancelButtonClick(object args, EventArgs e)
        {
            // view.Close();
        }

        private void HandleViewLoad()
        {
            ExpiryDateTime = ClientSession.GetUserContext().UserShift.EndDateTime;
            ExtensionDateTime = new DateTime(); //permit.EndDateTime;
            view.ExtensionDateEnable = false;
            view.ExtensionTimeEnable = false;
            view.ExpiryDateTime = permit.EndDateTime.Value;
            //view.ExtensionDateEnable=fa


        }

        public DateTime? ExtensionDateTime { get; set; }

        public DateTime? ExpiryDateTime { get; set; }


        public void CreateForExtension(WorkPermit workpermit)
        {

            workpermit.ExtensionEnable = true;
            workpermit.RevalidationEnable = false;


            Time extensionTime = view.ExtensionTime;
            // DateTime expiryTime = workpermit.EndDateTime.Value.AddMinutes();
            double differenceInMinutes;
            // permit.ExtensionRevalidationDateTime=permit.EndDateTime+Convert.ToDateTime(extensionTime)
            // double differenceInMinutes = (Convert.ToDateTime(ExtensionDateTime).AddSeconds(-Convert.ToDateTime(ExtensionDateTime).Second) - expiryTime).TotalMinutes;
            User user = ClientSession.GetUserContext().User;
            string username = user.Username;
            double differenceInworktime = (Convert.ToDateTime(workpermit.EndDateTime)
                           .AddSeconds(-Convert.ToDateTime(workpermit.EndDateTime).Second) -
                                              workpermit.StartDateTime).TotalMinutes+extensionTime.TotalMinutes;
            if (differenceInworktime <= 960)
            {
                if (username.Equals(workpermit.ApprovedBy.Username))
                {
                    if (workpermit.ExtensionTimeIssuer == null)
                    {
                        workpermit.ExtensionTimeIssuer = workpermit.EndDateTime.Value;

                    }
                    if (workpermit.BeforeExtensionDateTime == null)
                    {
                        workpermit.BeforeExtensionDateTime = workpermit.EndDateTime.Value;

                    }
                    if (workpermit.MidExtensionvalueIssuer == null)
                    {

                        workpermit.MidExtensionvalueIssuer = workpermit.EndDateTime.Value;
                    }

                    
                   
                        differenceInMinutes =
                            (Convert.ToDateTime(workpermit.ExtensionTimeIssuer)
                                .AddSeconds(-Convert.ToDateTime(workpermit.ExtensionTimeIssuer).Second) -
                             workpermit.MidExtensionvalueIssuer.Value).TotalMinutes + extensionTime.TotalMinutes;

                        
                    if (differenceInMinutes > 120 || 0 > differenceInMinutes)
                    {
                        // DialogResult result = OltMessageBox.Show(Form.ActiveForm, "permit can be extended by 2 hrs only", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //  OltMessageBox.Show("Permit can be extended by 2 hrs only");
                        view.ExtensionWork("Permit can be extended by a total of 2 hrs only");

                        //return null;
                        //if (dialogResult == DialogResult.OK) return;

                    }
                    else
                    {
                        if (workpermit.ExtensionRevalidationDateTime == null)
                        {

                            workpermit.ExtensionRevalidationDateTime = workpermit.EndDateTime.Value;
                        }
                        if (workpermit.ISSUER_SOURCEXTENSION == null)
                        {
                            workpermit.ISSUER_SOURCEXTENSION =
                                Convert.ToString(ClientSession.GetUserContext().User.FirstName).ToUpper() + " " +
                                Convert.ToString(ClientSession.GetUserContext().User.LastName).ToUpper();
                        }
                        else
                        {
                            workpermit.ISSUER_SOURCEXTENSION =
                                Convert.ToString(ClientSession.GetUserContext().User.FirstName).ToUpper() + " " +
                                Convert.ToString(ClientSession.GetUserContext().User.LastName).ToUpper();
                        }
                       // workpermit.MidExtensionvalueIssuer = workpermit.ExtensionTimeIssuer.Value;
                        workpermit.ExtensionTimeIssuer =
                            workpermit.ExtensionTimeIssuer.Value.AddMinutes(extensionTime.TotalMinutes);
                        workpermit.ExtensionRevalidationDateTime =
                            workpermit.ExtensionRevalidationDateTime.Value.AddMinutes(extensionTime.TotalMinutes);
                        workpermit.Specifics.EndDateTime =
                            workpermit.EndDateTime.Value.AddMinutes(extensionTime.TotalMinutes);
                       
                        if (workpermit.Extension == null)
                        {
                            workpermit.Extension = 1;
                        }
                        else
                        {
                            workpermit.Extension = workpermit.Extension.Value + 1;
                        }

                        Print(workpermit);



                    }
                }

                else
                {
                    if (workpermit.ExtensionTimeNonIssuer == null)
                    {
                        workpermit.ExtensionTimeNonIssuer = workpermit.EndDateTime.Value;

                    }
                    if (workpermit.BeforeExtensionDateTime == null)
                    {
                        workpermit.BeforeExtensionDateTime = workpermit.EndDateTime.Value;
                    }
                    if (workpermit.MidExtensionvaluenonIssuer == null)
                    {
                        workpermit.MidExtensionvaluenonIssuer = workpermit.EndDateTime.Value;
                    }

                     differenceInMinutes =
                            (Convert.ToDateTime(workpermit.ExtensionTimeNonIssuer)
                                .AddSeconds(-Convert.ToDateTime(workpermit.ExtensionTimeNonIssuer).Second) -
                             workpermit.MidExtensionvaluenonIssuer.Value).TotalMinutes +
                            extensionTime.TotalMinutes;
                  

                    if (differenceInMinutes > 960 || 0 > differenceInMinutes)
                    {
                        view.ExtensionWork("Permit can be extended by a total of 16 hrs only");

                    }
                    else
                    {
                        if (workpermit.ExtensionRevalidationDateTime == null)
                        {

                            workpermit.ExtensionRevalidationDateTime = workpermit.EndDateTime.Value;
                        }
                        if (workpermit.ISSUER_SOURCEXTENSION == null)
                        {
                            workpermit.ISSUER_SOURCEXTENSION =
                                Convert.ToString(ClientSession.GetUserContext().User.FirstName).ToUpper() + " " +
                                Convert.ToString(ClientSession.GetUserContext().User.LastName).ToUpper();
                        }
                        else
                        {
                            workpermit.ISSUER_SOURCEXTENSION =
                                Convert.ToString(ClientSession.GetUserContext().User.FirstName).ToUpper() + " " +
                                Convert.ToString(ClientSession.GetUserContext().User.LastName).ToUpper();
                        }
                      //  workpermit.MidExtensionvaluenonIssuer = workpermit.ExtensionTimeNonIssuer.Value;
                        workpermit.ExtensionTimeNonIssuer =
                            workpermit.ExtensionTimeNonIssuer.Value.AddMinutes(extensionTime.TotalMinutes);
                        workpermit.ExtensionRevalidationDateTime =
                            workpermit.ExtensionRevalidationDateTime.Value.AddMinutes(extensionTime.TotalMinutes);
                        workpermit.Specifics.EndDateTime =
                            workpermit.EndDateTime.Value.AddMinutes(extensionTime.TotalMinutes);
                        if (workpermit.Extension == null)
                        {
                            workpermit.Extension = 1;
                        }
                        else
                        {
                            workpermit.Extension = workpermit.Extension.Value + 1;
                        }

                        Print(workpermit);

                        //        //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update,
                        //        //   workpermit);

                        //        //FinalizePermitAndSaveAndPrint(workpermit);
                        //        //workPermitForms.ReportPrintManager(service, page, workpermit.Version).PreviewReport(workpermit);


                    }
                }
            }

            else
            {
                // DialogResult = DialogResult.None;
                //if(OltMessageBox.Show(Form.ActiveForm, "A Safe Work Permit can only be valid for upto 16hrs");

                view.ExtensionWork("A Safe Work Permit can only be valid for up to 16hrs");

            }




        }
        private void Print(WorkPermit workpermit)
        {
            List<WorkPermitDTO> permitDtos = page.SelectedItems;
            List<WorkPermit> permits = ConvertAllTo(permitDtos);


            PrintReport(permits, workpermit);
        }
        public void PrintReport(List<WorkPermit> objectsToPrint, WorkPermit workpermit)
        {
            WorkPermitSarniaPrintActions printActions = new WorkPermitSarniaPrintActions(service, page);
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

            workpermit.LastModifiedBy = ClientSession.GetUserContext().User; ;
            workpermit.LastModifiedDate = Clock.Now;

            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, workpermit);
            SplashScreenManager.CloseForm(false, 0, activeForm, true);
        }
        protected List<WorkPermit> ConvertAllTo(List<WorkPermitDTO> dtos)
        {
            return dtos.ConvertAll(dto => QueryByDto(dto));
        }
        private WorkPermit QueryByDto(WorkPermitDTO dto)
        {
            if (ClientSession.GetUserContext().IsUSPipelineSite || ClientSession.GetUserContext().IsSELCSite) // mangesh uspipeline to selc
                return service.QueryByIdForUSPipeline(dto.IdValue);
            //ayman USPipeline workpermit
            return service.QueryById(dto.IdValue);
        }
        protected void PrintWithDialogFocus(Action performPrint)
        {
            new PrintWithDialogFocus().Print(performPrint);
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


    }
}
