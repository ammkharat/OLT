using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class WorkPermitEdmontonPrintActions :
        PrintActions<WorkPermitEdmonton, WorkPermitEdmontonReport, WorkPermitEdmontonReportAdapter>
    {
        private const string TitleString = "Safe Work Permit";
        private readonly IFormEdmontonService formEdmontonService;
        private readonly IWorkPermitEdmontonPrintable printable;

        private string permitType;

        public WorkPermitEdmontonPrintActions(IWorkPermitEdmontonPrintable printable)
        {
            this.printable = printable;
            formEdmontonService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
        }

        protected override WorkPermitEdmontonReport CreateSpecificReport()
        {
            return new WorkPermitEdmontonReport();
        }

        protected override List<WorkPermitEdmontonReportAdapter> CreateReportAdapter(WorkPermitEdmonton workPermit)
        {
            var report = new WorkPermitEdmontonReport(); // temp for doing some calculations
            var descriptionTooLong = !report.StringWillFitIntoTaskDescriptionField(workPermit.TaskDescription);

            var numberOfCopies = GetNumberOfCopiesFromUserPrintPreferences(workPermit);
           
            
            var adapters = new List<WorkPermitEdmontonReportAdapter>();

            //DMND0010609-OLT - Edmonton Work permit Scan
            IApplicationService applicationService = ClientServiceRegistry.Instance.GetService<IApplicationService>();
            var buildEnvironment = applicationService.GetBuildConfiguration();
            var permitIssuer = new WorkPermitEdmontonReportAdapter(workPermit, descriptionTooLong)
            {
                WaterMarkText = "Permit Issuer",
                //DMND0010609-OLT - Edmonton Work permit Scan
                WorkpermitScanText = buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-IU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-I" 
               

            };
            var permitAcceptor = new WorkPermitEdmontonReportAdapter(workPermit, descriptionTooLong)
            {
                WaterMarkText = "Permit Acceptor",
                //DMND0010609-OLT - Edmonton Work permit Scan
                //WorkpermitScanText = ClientSession.GetUserContext().SiteId.ToString() +"-"+ workPermit.PermitNumber +"-A",
                WorkpermitScanText = buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-AU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-A"
            };

            adapters.Add(permitIssuer);
            adapters.Add(permitAcceptor);

            if (numberOfCopies == 3)
            {
                var workersPermit = new WorkPermitEdmontonReportAdapter(workPermit, descriptionTooLong)
                {
                    //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 5 - 01-Oct-2018 start
                    //WaterMarkText = "Workers"
                    WaterMarkText = "Worker/Verifier",
                    //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 5 - 01-Oct-2018 start

                  //DMND0010609-OLT - Edmonton Work permit Scan
                   // WorkpermitScanText = ClientSession.GetUserContext().SiteId + workPermit.PermitNumber + "-V"
                    WorkpermitScanText = buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-VU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-V"
                };
                adapters.Add(workersPermit);
            }

            return adapters;
        }

        private int GetNumberOfCopiesFromUserPrintPreferences(WorkPermitEdmonton workPermit)
        {
            var numberOfCopies = 3;
            var workPermitPrintPreference = ClientSession.GetUserContext().User.WorkPermitPrintPreference;

            // The Permit should not be allowed to be printed if the group is null, but the group is nullable in the DB so this is to be safe
            if (workPermit.Group != null)
            {
                if (workPermit.Group.IsTurnaround)
                {
                    numberOfCopies = workPermitPrintPreference.NumberOfTurnaroundCopies;
                }
                else
                {
                    numberOfCopies = workPermitPrintPreference.NumberOfCopies;
                }
            }

            return numberOfCopies;
        }

        public override string ReportTitle(WorkPermitEdmonton domainObject)
        {
            return permitType.HasValue() ? string.Format("{0} - {1}", TitleString, permitType) : TitleString;
        }

        protected override void AddPageSpecificWatermarks(WorkPermitEdmontonReport report,
            IEnumerable<WorkPermitEdmontonReportAdapter> adapters)
        {
            var index = 0;
            //foreach (var adapter in adapters)
            //{
            //    report.Pages[index].AssignWatermark(CreateTextWatermark(adapter.WaterMarkText));
            //    index++;
            //}
            for (var index1 = 1; index1 <= report.Pages.Count; index1++)
            {
                string Wtext="";
                if (index1 % 2 != 0)
                {
                    int adpCount=0;
                    foreach (var adapter in adapters)
                    {
                        if(adpCount== index)
                        Wtext=adapter.WaterMarkText;

                        adpCount++;
                   
                    }

                    report.Pages[index1 - 1].AssignWatermark(CreateTextWatermark(Wtext));
                    index++;
                }
                
            }
        }

        protected override void AddAssociatedReports(WorkPermitEdmontonReport mainReport,
            WorkPermitEdmonton domainObject)
        {
            if (mainReport == null || printable.ShouldNotPrintForms)
                return;
            if (domainObject.FormGN7 != null)
            {
                XtraReport formReport = new EdmontonGN7FormPrintActions().CreateReport(domainObject.FormGN7);
                mainReport.Pages.AddRange(formReport.Pages);
            }
            if (domainObject.FormGN59 != null)
            {
                XtraReport formReport = new EdmontonGN59FormPrintActions(true).CreateReport(domainObject.FormGN59);
                mainReport.Pages.AddRange(formReport.Pages);

                XtraReport checklistReport = new EdmontonGN59ChecklistPrintActions().CreateReport(domainObject);
                mainReport.Pages.AddRange(checklistReport.Pages);
            }
            if (domainObject.FormGN24 != null)
            {
                XtraReport formReport = new EdmontonGN24FormPrintActions(true).CreateReport(domainObject.FormGN24);
                mainReport.Pages.AddRange(formReport.Pages);
            }
            if (domainObject.FormGN6 != null)
            {
                XtraReport formReport = new EdmontonGN6FormPrintActions(true).CreateReport(domainObject.FormGN6);
                mainReport.Pages.AddRange(formReport.Pages);
            }
            if (domainObject.FormGN75A != null)
            {
                var workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
                XtraReport gn75AReport =
                    new EdmontonGN75AFormPrintActions(true, workPermitEdmontonService).CreateReport(
                        domainObject.FormGN75A);
                mainReport.Pages.AddRange(gn75AReport.Pages);
            }
            if (domainObject.FormGN1 != null && domainObject.FormGN1TradeChecklistId.HasValue)
            {
                var formGn1 = domainObject.FormGN1;
                var tradeChecklistId = domainObject.FormGN1TradeChecklistId.Value;
                // remove the Trades not associated with this Work Permit. 
                formGn1.TradeChecklists.RemoveAll(checklist => checklist.IdValue != tradeChecklistId);

                XtraReport gn1Report = new EdmontonGN1FormPrintActions(true, formEdmontonService).CreateReport(formGn1);
                mainReport.Pages.AddRange(gn1Report.Pages);
            }
        }

        public override bool BeforeFirstPrint(List<WorkPermitEdmonton> objectsToPrint)
        {
            if (!objectsToPrint.TrueForAll(wp => wp.HasBeenIssued || ExpiryDateTimeIsInTheFuture(wp)))
            {
                printable.ShowUnableToPrintWithExpiryDateInPastMessage();
                return false;
            }
            printable.IsOnlyPrintingOnePermit = objectsToPrint.Count == 1;
            printable.ShouldNotPrintForms = false;

            if (! printable.IsOnlyPrintingOnePermit) return true;

            if (objectsToPrint[0].FormGN1 == null && objectsToPrint[0].FormGN24 == null &&
                objectsToPrint[0].FormGN59 == null && objectsToPrint[0].FormGN6 == null &&
                objectsToPrint[0].FormGN7 == null && objectsToPrint[0].FormGN75A == null)
                return true;

            var askIfTheyWantToPrintTheForms = printable.AskIfTheyWantToPrintTheForms();
            if (askIfTheyWantToPrintTheForms == null) return false;
            if (!askIfTheyWantToPrintTheForms.Value)
            {
                printable.ShouldNotPrintForms = true;
            }
            return true;
        }

        private bool ExpiryDateTimeIsInTheFuture(WorkPermitEdmonton workPermit)
        {
            return (workPermit.ExpiredDateTime > Clock.Now);
        }

        public override void BeforePrintAction(WorkPermitEdmonton workPermit)
        {
            permitType = workPermit.WorkPermitType.GetName();

            // Temporarily set the Issued Date Time to now for printing a pending permit, but only do an update back to the service layer after a successful print.
            var newIssuedDateTime = Clock.Now;

            if (workPermit.WorkPermitStatus.Equals(PermitRequestBasedWorkPermitStatus.Pending))
            {
                workPermit.IssuedDateTime = newIssuedDateTime;
                workPermit.IssuedByUser = ClientSession.GetUserContext().User;
            }
        }

        public override void AfterPrintAction(WorkPermitEdmonton permit)
        {
            if (permit.WorkPermitStatus.Equals(PermitRequestBasedWorkPermitStatus.Pending))
            {
                // Developers: Issued Date Time and Issued By User were set in the BeforePrintAction method to make sure that they show in the preview of a Work Permit.  

                //  However, the following still need to be set before sending Update.
                permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;

                // Set the Last Modified By to the same user who issued the permit.
                permit.LastModifiedBy = permit.IssuedByUser;
                // Set the Last Modified Date Time to the same as the Issued Date Time since that's really what we would expect. 
                permit.LastModifiedDateTime = permit.IssuedDateTime.GetValueOrDefault(Clock.Now);

                printable.UpdateWorkPermit(permit);

            }
            printable.ShouldNotPrintForms = false;
        }

        public override void ShowNotAbleToPrintError()
        {
            printable.ShowPrintingFailedMessage();
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitEdmontonReport report,
            UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, true, true, userPrintPreference.PrinterName,
                userPrintPreference.ShowPrintDialog);
        }
    }
}