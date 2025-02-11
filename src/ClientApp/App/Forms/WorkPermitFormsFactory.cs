﻿using System;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Forms
{
    public class WorkPermitFormsFactory
    {
        public WorkPermitForms Build()
        {
            Site site = ClientSession.GetUserContext().Site;
            switch (site.Id)
            {
                case Site.SARNIA_ID:
                    return new SarniaWorkPermitForms();
                case Site.DENVER_ID:
                    return new DenverWorkPermitForms();
                    //ayman work permit fort hills

                case Site.USPipeline_ID:
                    return new USPipelineWorkPermitForms();

                case Site.SELC_ID: // mangesh uspipeline to selc - SWP
                    return new USPipelineWorkPermitForms();

                //ayman work permit fort hills
                case Site.FORT_HILLS_ID:
                    return new ForthillsWorkPermitForms();
                default:
                    throw new ApplicationException(string.Format("Work Permits are invalid for site {0}.", site.Name));
            }
        }
    }

    public abstract class WorkPermitForms
    {
        public abstract IWorkPermitDetails DetailsForm();
        public abstract IWorkPermitFormView NewForm();
        public abstract IWorkPermitFormView EditForm(WorkPermit workPermit);
        public abstract IReportPrintManager<WorkPermit> ReportPrintManager(IWorkPermitService workPermitService, IWorkPermitPage page, Version version);

        public virtual ICopyWorkPermitFormView CopyForm()
        {
            return new CopyWorkPermitForm();    
        }

        public virtual ICloneWorkPermitFormView CloneForm()
        {
            return new CloneWorkPermitForm();
        }
    }


    //ayman USPipeline workpermit
    public class USPipelineWorkPermitForms : WorkPermitForms
    {
        public override IWorkPermitDetails DetailsForm()
        {
            return new WorkPermitDetailsUSPipelineVersionController();
        }

        public override IWorkPermitFormView NewForm()
        {
            return new WorkPermitFormUSPipeline();
        }

        public override IWorkPermitFormView EditForm(WorkPermit workPermit)
        {
            return new WorkPermitFormUSPipeline(workPermit);
        }

        public override IReportPrintManager<WorkPermit> ReportPrintManager(IWorkPermitService workPermitService, IWorkPermitPage page, Version version)
        {
            if (WorkPermit.IsOldVersionForUSPipeline(version))
            {
                return new ReportPrintManager<WorkPermit, WorkPermitUSPipelineReport_Pre_4_10, WorkPermitUSPipelineReportAdapter>(new WorkPermitUSPipelinePrintActions_Pre_4_10(workPermitService, page));
            }
            else
            {  // Changed by Vibhor : RITM0630157 - US Pipeline site was pointing to Denver site Report
                return new ReportPrintManager<WorkPermit, WorkPermitUSPipelineReport, WorkPermitUSPipelineReportAdapter>(new WorkPermitUSPipelinePrintActions(workPermitService, page));
            }
        }
    }

    public class DenverWorkPermitForms : WorkPermitForms
    {
        public override IWorkPermitDetails DetailsForm()
        {
            return new WorkPermitDetailsDenverVersionController();
        }

        public override IWorkPermitFormView NewForm()
        {
            return new WorkPermitFormDenver();
        }

        public override IWorkPermitFormView EditForm(WorkPermit workPermit)
        {
            return new WorkPermitFormDenver(workPermit);
        }

        public override IReportPrintManager<WorkPermit> ReportPrintManager(IWorkPermitService workPermitService, IWorkPermitPage page, Version version)
        {
            if (WorkPermit.IsOldVersionForDenver(version))
            {
                return new ReportPrintManager<WorkPermit, WorkPermitDenverReport_Pre_4_10, WorkPermitDenverReportAdapter>(new WorkPermitDenverPrintActions_Pre_4_10(workPermitService, page));
            }
            else
            {
                return new ReportPrintManager<WorkPermit, WorkPermitDenverReport, WorkPermitDenverReportAdapter>(new WorkPermitDenverPrintActions(workPermitService, page));
            }
        }
}

    //ayman work permit fort hills
    public class ForthillsWorkPermitForms : WorkPermitForms
    {
        public override IWorkPermitDetails DetailsForm()
        {
            return new WorkPermitDetailSarniaVersionController();
        }

        public override IWorkPermitFormView NewForm()
        {
            return new WorkPermitFormSarnia();
        }

        public override IWorkPermitFormView EditForm(WorkPermit workPermit)
        {
            return new WorkPermitFormSarnia(workPermit);
        }

        public override IReportPrintManager<WorkPermit> ReportPrintManager(IWorkPermitService workPermitService, IWorkPermitPage page, Version version)
        {
            return new ReportPrintManager<WorkPermit, WorkPermitSarniaReport, WorkPermitSarniaReportAdapter>(new WorkPermitSarniaPrintActions(workPermitService, page));
        }
    }


    public class SarniaWorkPermitForms : WorkPermitForms
    {
        public override IWorkPermitDetails DetailsForm()
        {
            return new WorkPermitDetailSarniaVersionController();
        }

        public override IWorkPermitFormView NewForm()
        {
            return new WorkPermitFormSarnia();
        }

        public override IWorkPermitFormView EditForm(WorkPermit workPermit)
        {
            return new WorkPermitFormSarnia(workPermit);
        }

        public override IReportPrintManager<WorkPermit> ReportPrintManager(IWorkPermitService workPermitService, IWorkPermitPage page, Version version)
        {
            return new ReportPrintManager<WorkPermit, WorkPermitSarniaReport, WorkPermitSarniaReportAdapter>(new WorkPermitSarniaPrintActions(workPermitService, page));
        }
    }
}