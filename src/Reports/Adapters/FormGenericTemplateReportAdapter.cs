using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGenericTemplateReportAdapter : FormReportAdapter
    {
        private readonly FormGenericTemplate form;

        public FormGenericTemplateReportAdapter(FormGenericTemplate form)
            : base(form)
        {
            this.form = form;
        }

        public override string ReturnedBackToService
        {
            get
            {
                return form.ClosedDateTime != null ? form.ClosedDateTime.Value.ToLongDateAndTimeString() : string.Empty;
            }
        }

        public override bool IsOperationsRequested
        {
            get { return form.Department == FormOP14Department.Operations; }
        }

        public override bool IsMaintenanceRequested
        {
            get { return form.Department == FormOP14Department.Maintenance; }
        }

        public override string Status
        {
            get
            {
                if ((base.Status == FormStatus.Approved.GetName() || base.Status == FormStatus.Draft.GetName()) &&
                    (Clock.Now > DateTime.Parse(base.ValidTo)))
                    return FormStatus.Expired.GetName();
                return base.Status;
            }
        }

        public bool IsCriticalSystemsDefeatedForSafeyValueYes
        {
            get { return form.IsTheCSDForAPressureSafetyValve; }
        }

        public bool IsCriticalSystemsDefeatedForSafeyValueNo
        {
            get { return !form.IsTheCSDForAPressureSafetyValve; }
        }

        public string CriticalSystemDefeated
        {
            get { return form.CriticalSystemDefeated; }
        }

        public override string ValidFromLabel
        {
            get { return "Start Date:"; }
        }

        public override string ValidToLabel
        {
            get { return "End Date:"; }
        }

        public override string CommentsAsRtf
        {
            get { return form.Content; }
        }

        public override List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                return
                    ((FormGenericTemplate) edmontonForm).FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }
    }
}