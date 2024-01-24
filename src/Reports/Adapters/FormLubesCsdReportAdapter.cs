using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormLubesCsdReportAdapter : FormReportAdapter
    {
        private readonly LubesCsdForm form;

        public FormLubesCsdReportAdapter(LubesCsdForm form) : base(form)
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

        public string FunctionalLocation
        {
            get { return form.FunctionalLocation.FullHierarchyWithDescription; }
        }

        public string Location
        {
            get { return form.Location; }
        }

        public bool? IsCriticalSystemsDefeatedForSafeyValueYes
        {
            get { return form.IsTheCSDForAPressureSafetyValve; }
        }

        public bool? IsCriticalSystemsDefeatedForSafeyValueNo
        {
            get { return !form.IsTheCSDForAPressureSafetyValve; }
        }

        public string CriticalSystemDefeated
        {
            get { return form.CriticalSystemDefeated; }
        }

        public override string ValidFromLabel
        {
            get { return "System Defeated:"; }
        }

        public override string ValidToLabel
        {
            get { return "Estimated Back in Service:"; }
        }

        public override string CommentsAsRtf
        {
            get { return form.Content; }
        }

        public override List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                var functionalLocationReportAdapter = new FunctionalLocationReportAdapter(-1, FunctionalLocation);
                return new List<FunctionalLocationReportAdapter> {functionalLocationReportAdapter};
            }
        }
    }
}