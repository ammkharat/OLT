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
    public class WorkPermitFortHillsPrintActions :
        PrintActions<WorkPermitFortHills, WorkPermitFortHillsReport, WorkPermitFortHillsReportAdapter>
    {
        private const string TitleString = "Safe Work Permit";
      //  private readonly IFormFortHillsService formFortHillsService;
        private readonly IWorkPermitFortHillsPrintable printable;

        private string permitType;

        public WorkPermitFortHillsPrintActions(IWorkPermitFortHillsPrintable printable)
        {
            this.printable = printable;
          //  formFortHillsService = ClientServiceRegistry.Instance.GetService<IFormFortHillsService>();
        }

        protected override WorkPermitFortHillsReport CreateSpecificReport()
        {
            return new WorkPermitFortHillsReport();
        }

        protected override List<WorkPermitFortHillsReportAdapter> CreateReportAdapter(WorkPermitFortHills workPermit)
        {
            var report = new WorkPermitFortHillsReport(); // temp for doing some calculations
            var descriptionTooLong = !report.StringWillFitIntoTaskDescriptionField(workPermit.TaskDescription);

            var numberOfCopies = GetNumberOfCopiesFromUserPrintPreferences(workPermit);

            var adapters = new List<WorkPermitFortHillsReportAdapter>();
            var permitIssuer = new WorkPermitFortHillsReportAdapter(workPermit, descriptionTooLong)
            {
                WaterMarkText = "Permit Issuer"
            };
            var permitAcceptor = new WorkPermitFortHillsReportAdapter(workPermit, descriptionTooLong)
            {
                WaterMarkText = "Permit Acceptor"
            };

            adapters.Add(permitIssuer);
            adapters.Add(permitAcceptor);

            if (numberOfCopies == 3)
            {
                var workersPermit = new WorkPermitFortHillsReportAdapter(workPermit, descriptionTooLong)
                {
                    ////Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 5 - 01-Oct-2018 start
                    ////WaterMarkText = "Workers"
                    WaterMarkText = "Worker/Verifier"
                    ////Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 5 - 01-Oct-2018 start
                };
                adapters.Add(workersPermit);
            }

            return adapters;
        }

        private int GetNumberOfCopiesFromUserPrintPreferences(WorkPermitFortHills workPermit)
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

        public override string ReportTitle(WorkPermitFortHills domainObject)
        {
            return permitType.HasValue() ? string.Format("{0} - {1}", TitleString, permitType) : TitleString;
        }

        protected override void AddPageSpecificWatermarks(WorkPermitFortHillsReport report,
            IEnumerable<WorkPermitFortHillsReportAdapter> adapters)
        {
            var index = 0;
            foreach (var adapter in adapters)
            {
                report.Pages[index].AssignWatermark(CreateTextWatermark(adapter.WaterMarkText));
                index++;
            }
        }

        protected override void AddAssociatedReports(WorkPermitFortHillsReport mainReport,
            WorkPermitFortHills domainObject)
        {
            if (mainReport == null || printable.ShouldNotPrintForms)
                return;
            
        }

        public override bool BeforeFirstPrint(List<WorkPermitFortHills> objectsToPrint)
        {
            if (!objectsToPrint.TrueForAll(wp => wp.HasBeenIssued || ExpiryDateTimeIsInTheFuture(wp)))
            {
                printable.ShowUnableToPrintWithExpiryDateInPastMessage();
                return false;
            }
            printable.IsOnlyPrintingOnePermit = objectsToPrint.Count == 1;
            printable.ShouldNotPrintForms = false;

            if (! printable.IsOnlyPrintingOnePermit) return true;

            //if (objectsToPrint[0].FormGN1 == null && objectsToPrint[0].FormGN24 == null &&
            //    objectsToPrint[0].FormGN59 == null && objectsToPrint[0].FormGN6 == null &&
            //    objectsToPrint[0].FormGN7 == null && objectsToPrint[0].FormGN75A == null)
            //    return true;

            //var askIfTheyWantToPrintTheForms = printable.AskIfTheyWantToPrintTheForms();
            //if (askIfTheyWantToPrintTheForms == null) return false;
            //if (!askIfTheyWantToPrintTheForms.Value)
            //{
            //    printable.ShouldNotPrintForms = true;
            //}
            return true;
        }

        private bool ExpiryDateTimeIsInTheFuture(WorkPermitFortHills workPermit)
        {
            return (workPermit.ExpiredDateTime > Clock.Now);
        }

        public override void BeforePrintAction(WorkPermitFortHills workPermit)
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

        public override void AfterPrintAction(WorkPermitFortHills permit)
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

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitFortHillsReport report,
            UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, true, userPrintPreference.PrinterName,
                userPrintPreference.ShowPrintDialog);
        }
    }
}