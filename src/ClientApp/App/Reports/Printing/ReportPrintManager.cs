﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Services;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using log4net;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class ReportPrintManager<TDomainObject, TReport, TReportAdapter> : IReportPrintManager<TDomainObject>
        where TDomainObject : DomainObject
        where TReportAdapter : IReportAdapter
        where TReport : XtraReport, IOltReport<TReportAdapter>
        
    {
        private readonly PrintActions<TDomainObject, TReport, TReportAdapter> printActions;

        private readonly ILog logger = GenericLogManager.GetLogger<ReportPrintManager<TDomainObject, TReport, TReportAdapter>>();

        public ReportPrintManager(PrintActions<TDomainObject, TReport, TReportAdapter> printActions)
        {
            this.printActions = printActions;
        }

        //ayman action item email
        public void Email(TDomainObject domainObject, string emailSubjectPrefix, string emailSubject, string toRecipients)
        {
            var smtpServer = EmailSettings.SMTPServerURL;
            var port = EmailSettings.SMTPServerPort;
            var fromEmailAddress = EmailSettings.FromEmailAddress;
          //  var fromEmail = ClientSession.GetUserContext().User.Username + "@suncor.com";////Added by Aarti INC0482299:Outlook2016

            List<IOltReport> xtraReports = new List<IOltReport>();
            List<string> fileNames = new List<string>();


            ActionItem Actionitem = domainObject as ActionItem;

            string fname = emailSubjectPrefix + string.Format(" - {0} ", Actionitem.CreatedByActionItemDefinition.CreatedBy.Username);
            // ShiftDisplayName.Replace('/', '-'));
            fileNames.Add(fname);


            XtraReport xtraReport = printActions.CreateReport(domainObject);
            xtraReports.Add((IOltReport)xtraReport);

            //Added by Aarti INC0482299:Outlook2016
            var mailSender = new SMTPMailSender(smtpServer, port, new EmailAddress(fromEmailAddress));
            using (Stream memoryStream = new MemoryStream())
            {
                xtraReport.ExportToPdf(memoryStream);


                memoryStream.Position = 0;
                mailSender.SendEmail(memoryStream, emailSubjectPrefix, emailSubject, toRecipients);

            }
            //Added by Aarti INC0482299:Outlook2016
            // EmailPresenter emailPresenter = new EmailPresenter();
            //  emailPresenter.Email(xtraReports[0], emailSubjectPrefix, emailSubject, toRecipients);
        }

        public void Email(TDomainObject domainObject, string emailSubjectPrefix, string emailSubject)
        {
            XtraReport xtraReport = printActions.CreateReport(domainObject);
            EmailPresenter emailPresenter = new EmailPresenter();
            emailPresenter.Email((IOltReport) xtraReport, emailSubjectPrefix, emailSubject);
        }

        public void PreviewReport(TDomainObject objectToPreview)
        {
            printActions.BeforePrintAction(objectToPreview);

            IReportPrintPreviewView previewView = new ReportPrintPreviewForm();
            previewView.Title = printActions.ReportTitle(objectToPreview);
            
            TReport report = null;

            previewView.OnFormLoad += delegate
            {
                report = printActions.CreateReport(objectToPreview);
                previewView.Report = report;
            };

            previewView.OnPrintButtonClicked += delegate
            {
                bool shouldContinuePrinting = printActions.BeforeFirstPrint(new List<TDomainObject> { objectToPreview });
                if (!shouldContinuePrinting)
                    return;
                if (objectToPreview.Id.HasValue && objectToPreview.ObjectIdentifier.Contains("WorkPermitEdmonton"))
                {
                    report = printActions.CreateReport(objectToPreview);
                }
                //ReportPrintPreference reportPrintPreference = report.CreateReportPrintPreferences(ClientSession.GetUserContext().User.WorkPermitPrintPreference);
                ReportPrintPreference reportPrintPreference = printActions.CreateReportPrintPreferences();

                PrintOptions selectedPrintOptions = reportPrintPreference.GetPrintOptionsViaPrintDialog();

                if (selectedPrintOptions == null) // Print was cancelled
                    return;

                bool printSucceeded = Print(report, selectedPrintOptions);

                if (printSucceeded)
                {
                    printActions.AfterPrintAction(objectToPreview);
                }
            };
            
            previewView.ShowDialog();
        }

        public void PrintReport(List<TDomainObject> objectsToPrint)
        {
            bool shouldContinuePrinting = printActions.BeforeFirstPrint(objectsToPrint);
            if (!shouldContinuePrinting)
                return;

            ReportPrintPreference reportPrintPreferences = printActions.CreateReportPrintPreferences();
            PrintOptions selectedPrintOptions = reportPrintPreferences.GetPrintOptionsViaPrintDialog();

            if (selectedPrintOptions == null)  // Print was cancelled
                return;

            Form activeForm = Form.ActiveForm;
            SplashScreenManager.ShowForm(activeForm, typeof(WaitForm), true, true, false);

            foreach(TDomainObject domainObject in objectsToPrint)
            {
                // pre-processing of the report domain object.
                printActions.BeforePrintAction(domainObject);
            
                XtraReport report = printActions.CreateReport(domainObject);
                 
                bool printSucceeded = Print(report, selectedPrintOptions);
                if (printSucceeded)
                {
                    printActions.AfterPrintAction(domainObject);
                }
            }

            SplashScreenManager.CloseForm(false, 0, activeForm, true);
        }
      
        //RITM0468037EN50 : OLT:: Edmonton:: GN75B changes Aarti 
        public void PrintEdit(TDomainObject objectsToPrint)
        {
            ReportPrintPreference reportPrintPreferences = printActions.CreateReportPrintPreferences();
            PrintOptions selectedPrintOptions = reportPrintPreferences.GetPrintOptionsViaPrintDialog();

            if (selectedPrintOptions == null)  // Print was cancelled
                return;

            Form activeForm = Form.ActiveForm;
            SplashScreenManager.ShowForm(activeForm, typeof(WaitForm), true, true, false);
            printActions.BeforePrintAction(objectsToPrint);

            XtraReport report = printActions.CreateReport(objectsToPrint);

            bool printSucceeded = Print(report, selectedPrintOptions);
            if (printSucceeded)
            {
                printActions.AfterPrintAction(objectsToPrint);
            }
            SplashScreenManager.CloseForm(false, 0, activeForm, true);
        }
        private bool Print(XtraReport report, PrintOptions selectedPrintOptions)
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
                        printerSettings.Copies = (short) selectedPrintOptions.NumberOfCopies;
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

         // Added by Mukesh for RITM0218684
        public void Email(List<TDomainObject> domainObject, string emailSubjectPrefix, string emailSubject)
        {
            List<IOltReport> xtraReports = new List<IOltReport>();
            List<string> fileNames = new List<string>();
            foreach(var obj in domainObject)
            {
               if(obj.GetType()==typeof(SummaryLog))
               {
                   SummaryLog summaryLog = obj as SummaryLog;

                   string fname = emailSubjectPrefix + string.Format(" - {0} - {1}", summaryLog.CreationUser.Username,
                     summaryLog.ShiftDisplayName.Replace('/','-'));
                   fileNames.Add(fname);

               }
               if (obj.GetType() == typeof(Log))
               {
                   Log log = obj as Log;

                   string fname = emailSubjectPrefix + string.Format(" - {0} - {1}", log.CreationUser.Username,
                     log.ShiftDisplayName.Replace('/', '-'));
                   fileNames.Add(fname);

               }
               if (obj.GetType() == typeof(Com.Suncor.Olt.Common.Domain.ShiftHandover.ShiftHandoverQuestionnaire))
               {
                   Com.Suncor.Olt.Common.Domain.ShiftHandover.ShiftHandoverQuestionnaire shiftHandoverQuestionnaire = obj as Com.Suncor.Olt.Common.Domain.ShiftHandover.ShiftHandoverQuestionnaire;

                   string fname = emailSubjectPrefix + string.Format(" - {0} - {1}", shiftHandoverQuestionnaire.CreateUser.Username,
                     shiftHandoverQuestionnaire.ShiftDisplayName.Replace('/', '-'));
                   fileNames.Add(fname);

               }
               //ayman action item email
               if(obj.GetType() == typeof(ActionItem))
                {
                    Log log = obj as Log;

                    string fname = emailSubjectPrefix + string.Format(" - {0} - {1}", log.CreationUser.Username,
                      log.ShiftDisplayName.Replace('/', '-'));
                    fileNames.Add(fname);
                }

                XtraReport xtraReport = printActions.CreateReport(obj);
                xtraReports.Add((IOltReport)xtraReport);
            }
            
            EmailPresenter emailPresenter = new EmailPresenter();
            emailPresenter.Email(xtraReports, emailSubjectPrefix, emailSubject, fileNames);
        }
        //Added by ppanigrahi
        public void Email(TDomainObject domainObject, List<EmailAddress> toEmailAddress, string messageText, string subject, string attachmentFileName, bool isBodyHtml)
        {
            isBodyHtml = true;
            var smtpServer = EmailSettings.SMTPServerURL;
            var port = EmailSettings.SMTPServerPort;
            var fromEmailAddress = EmailSettings.FromEmailAddress;

            var mailSender = new SMTPMailSender(smtpServer, port, new EmailAddress(fromEmailAddress));

            XtraReport xtraReport = printActions.CreateReport(domainObject);

            using (Stream memoryStream = new MemoryStream())
            {
                xtraReport.ExportToPdf(memoryStream);

                foreach (var emailAddress in toEmailAddress)
                {
                    memoryStream.Position = 0;
                    mailSender.SendEmail(emailAddress, messageText, subject, memoryStream, attachmentFileName, isBodyHtml);
                }
            }
        }
        public void Email(TDomainObject domainObject, EmailAddress toEmailAddress, string messageText, string subject, string attachmentFileName, bool isBodyHtml)
        {
            isBodyHtml = true;
            var smtpServer = EmailSettings.SMTPServerURL;
            var port = EmailSettings.SMTPServerPort;
            var fromEmailAddress = EmailSettings.FromEmailAddress;

            var mailSender = new SMTPMailSender(smtpServer, port, new EmailAddress(fromEmailAddress));

            XtraReport xtraReport = printActions.CreateReport(domainObject);

            using (Stream memoryStream = new MemoryStream())
            {
                xtraReport.ExportToPdf(memoryStream);


                memoryStream.Position = 0;
                mailSender.SendEmail(toEmailAddress, messageText, subject, memoryStream, attachmentFileName, isBodyHtml);

            }
        }
        public void Email(TDomainObject domainObject, List<EmailAddress> emalAddresses, string emailSubjectPrefix,
           string emailSubject, string messageBodyText)
        {

            XtraReport xtraReport = printActions.CreateReport(domainObject);
            if (domainObject.GetType() == typeof(Com.Suncor.Olt.Common.Domain.Form.FormOP14))
            {
                Com.Suncor.Olt.Common.Domain.Form.FormOP14 formOp14 = domainObject as Com.Suncor.Olt.Common.Domain.Form.FormOP14;
                string fname = emailSubjectPrefix;
                var smtpServer = EmailSettings.SMTPServerURL;
                var port = EmailSettings.SMTPServerPort;
                var fromEmailAddress = EmailSettings.FromEmailAddress;

                var mailSender = new SMTPMailSender(smtpServer, port, new EmailAddress(fromEmailAddress));
                using (Stream memoryStream = new MemoryStream())
                {
                    xtraReport.ExportToPdf(memoryStream);

                    foreach (var emailAddress in emalAddresses)
                    {
                        memoryStream.Position = 0;
                        mailSender.SendEmail(emailAddress, messageBodyText, emailSubject, memoryStream, fname, true);
                    }
                }


            }


        }
    }
    

} 