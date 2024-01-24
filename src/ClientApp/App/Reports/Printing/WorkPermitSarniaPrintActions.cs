using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Client.Presenters;
using System;
using Com.Suncor.Olt.Client.Services;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class WorkPermitSarniaPrintActions : PrintActions<WorkPermit, WorkPermitSarniaReport, WorkPermitSarniaReportAdapter>
    {
        private readonly IWorkPermitService workPermitService;
        private readonly IWorkPermitPage page;
        //private readonly IWorkPermitSarniaPrintable printable;//Added by ppanigrahi.

        public WorkPermitSarniaPrintActions(IWorkPermitService workPermitService, IWorkPermitPage page)
        {
            this.workPermitService = workPermitService;
            this.page = page;
        }
        //Added by ppanigrahi
        //public WorkPermitSarniaPrintActions(IWorkPermitSarniaPrintable  printable)
        //{
        //    //this.workPermitService = workPermitService;
        //    this.printable = printable;
        //}

        protected override WorkPermitSarniaReport CreateSpecificReport()
        {
            return new WorkPermitSarniaReport();
        }

        protected override List<WorkPermitSarniaReportAdapter> CreateReportAdapter(WorkPermit workPermit)
        {
            
            WorkPermitSarniaReportAdapter adapter1 = new WorkPermitSarniaReportAdapter(workPermit, "Permit Issuer");
            SetSIgnPropertis(workPermit.PermitNumber, adapter1);
            WorkPermitSarniaReportAdapter adapter2 = new WorkPermitSarniaReportAdapter(workPermit, "Permit Receiver");
            SetSIgnPropertis(workPermit.PermitNumber, adapter2);

            //DMND0010609-OLT - Edmonton Work permit Scan
            IApplicationService applicationService = ClientServiceRegistry.Instance.GetService<IApplicationService>();
            var buildEnvironment = applicationService.GetBuildConfiguration();
            adapter1.WorkpermitScanText = buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-IU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-I";
            adapter2.WorkpermitScanText = buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-RU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-R";
            //End

            return new List<WorkPermitSarniaReportAdapter> { adapter1, adapter2 };
        }
        protected void SetSIgnPropertis(string strWorkPermitId,WorkPermitSarniaReportAdapter adapter)
        {
            WorkPermitSarniaSignFormPresenter Wp = new WorkPermitSarniaSignFormPresenter();
            WorkPermitSign WS =  Wp.GetSign(strWorkPermitId);
           
            if(WS!=null)
            {
                if (!(WS.ISSUER_SOURCE == null || WS.ISSUER_SOURCE == "" || WS.ISSUER_SOURCE == "Manual"))
                {

                    adapter.ISSUER_NAME = Convert.ToString(WS.ISSUER_FNAME) + " " + Convert.ToString(WS.ISSUER_LNAME);
                }

               adapter.ISSUER_BADGENUMBER =WS.ISSUER_BADGENUMBER ;
               adapter.ISSUER_BADGETYPE =WS.ISSUER_BADGETYPE;
               adapter.ISSUER_SOURCE = WS.ISSUER_SOURCE == null || WS.ISSUER_SOURCE == "" || WS.ISSUER_SOURCE == "Manual" ? "" : "Via  " + WS.ISSUER_SOURCE.Replace("LENEL", "Accesscard"); ;

               adapter.NEXT_LVL_ISSUER_NAME =Convert.ToString(WS.NEXT_LVL_ISSUER_FNAME)+" "+Convert.ToString(WS.NEXT_LVL_ISSUER_LNAME);
               adapter.NEXT_LVL_ISSUER_BADGENUMBER =WS.NEXT_LVL_ISSUER_BADGENUMBER ;
               adapter.NEXT_LVL_ISSUER_BADGETYPE =WS.NEXT_LVL_ISSUER_BADGETYPE ;
               adapter.NEXT_LVL_ISSUER_SOURCE = WS.NEXT_LVL_ISSUER_SOURCE == null || WS.NEXT_LVL_ISSUER_SOURCE == "" || WS.NEXT_LVL_ISSUER_SOURCE == "Manual" ? "": "Via  " + WS.NEXT_LVL_ISSUER_SOURCE.Replace("LENEL","Accesscard"); 

               adapter.PERMIT_RECEIVER_NAME =Convert.ToString(WS.PERMIT_RECEIVER_FNAME)+" "+Convert.ToString(WS.PERMIT_RECEIVER_LNAME);
              
               adapter.PERMIT_RECEIVER_BADGENUMBER =WS.PERMIT_RECEIVER_BADGENUMBER;
               adapter.PERMIT_RECEIVER_BADGETYPE =WS.PERMIT_RECEIVER_BADGETYPE ;
               adapter.PERMIT_RECEIVER_SOURCE = WS.PERMIT_RECEIVER_SOURCE == null || WS.PERMIT_RECEIVER_SOURCE == "" || WS.PERMIT_RECEIVER_SOURCE == "Manual" ? "" : "Via  " + WS.PERMIT_RECEIVER_SOURCE.Replace("LENEL", "Accesscard"); ; 

               adapter.CROSS_ZONE_AUTHO_NAME =Convert.ToString(WS.CROSS_ZONE_AUTHO_FNAME)+" "+Convert.ToString(WS.CROSS_ZONE_AUTHO_LNAME); ;
               adapter.CROSS_ZONE_AUTHO_BADGENuMBER =WS.CROSS_ZONE_AUTHO_BADGENuMBER ;
               adapter.CROSS_ZONE_AUTHO_BADGETYPE = adapter.CROSS_ZONE_AUTHO_BADGETYPE;
               adapter.CROSS_ZONE_AUTHO_SOURCE = WS.CROSS_ZONE_AUTHO_SOURCE == null || WS.CROSS_ZONE_AUTHO_SOURCE == "" || WS.CROSS_ZONE_AUTHO_SOURCE == "Manual" ? "" : "Via  " + WS.CROSS_ZONE_AUTHO_SOURCE.Replace("LENEL", "Accesscard"); ; ;

                if(WS.IMMIDIATE_FNAME!=null && WS.IMMIDIATE_LNAME!=null)
                {
                    adapter.IMMIDIATE_NAME=WS.IMMIDIATE_FNAME.Substring(0,1)+WS.IMMIDIATE_LNAME.Substring(0,1);
                }
               adapter.IMMIDIATE_BADGENUMBER =WS.IMMIDIATE_BADGENUMBER ;
               adapter.IMMIDIATE_BADGETYPE =  adapter.IMMIDIATE_BADGETYPE ;
               adapter.IMMIDIATE_SOURCE = WS.IMMIDIATE_SOURCE == null || WS.IMMIDIATE_SOURCE == "" || WS.IMMIDIATE_SOURCE == "Manual" ? "" : "Via  " + WS.IMMIDIATE_SOURCE.Replace("LENEL", "Accesscard"); ; 

               if (WS.CONFINED_FNAME != null && WS.CONFINED_LNAME != null)
               {
                   adapter.CONFINED_NAME = WS.CONFINED_FNAME.Substring(0, 1) + WS.CONFINED_LNAME.Substring(0, 1);
               }
              
               adapter.CONFINED_BADGENUMBER =WS.CONFINED_BADGENUMBER ;
               adapter.CONFINED_BADGETYPE =WS.CONFINED_BADGETYPE;
               adapter.CONFINED_SOURCE = WS.CONFINED_SOURCE == null || WS.CONFINED_SOURCE == "" || WS.CONFINED_SOURCE == "Manual" ? "" : "Via  " + WS.CONFINED_SOURCE.Replace("LENEL", "Accesscard"); ; 


            }
        }


        public override void AfterPrintAction(WorkPermit permit)
        {
            if (permit.IsNot(WorkPermitStatus.Issued))
            {
                User issuer = ClientSession.GetUserContext().User;
                permit.ChangeToIssuedPermit(issuer, Clock.Now);
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, permit);
            }
        }

        public override void ShowNotAbleToPrintError()
        {
            page.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitSarniaReport report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, true, true, userPrintPreferences.PrinterName, userPrintPreferences.ShowPrintDialog);
        }

        public override string ReportTitle(WorkPermit domainObject)
        {
            return StringResources.WorkPermitPrintFormTitle;
        }

        //protected override void AddPageSpecificWatermarks(WorkPermitSarniaReport report,
        //    IEnumerable<WorkPermitSarniaReportAdapter> adapters)
        //{
        //    var index = 0;
        //    foreach (var adapter in adapters)
        //    {
        //        report.Pages[index].AssignWatermark(CreateTextWatermark(adapter.WaterMarkText));
        //        index++;
        //    }
        //}
    }
}