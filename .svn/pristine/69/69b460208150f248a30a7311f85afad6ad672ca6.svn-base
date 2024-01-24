using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGN75AReportAdapter : BaseEdmontonFormReportAdapter
    {
        public FormGN75AReportAdapter(FormGN75A form, string permitNumbers) : base(form)
        {
            CommentsAsRtf = form.Content;
            SafeWorkPermitNumbersDisplayText = permitNumbers;
        }

        public override string ValidFromLabel
        {
            get { return "Start:"; }
        }

        public override string ValidToLabel
        {
            get { return "End:"; }
        }

        public string CommentsAsRtf { get; private set; }

        public string FunctionalLocation
        {
            get { return InternalFormGN75A.FunctionalLocation.FullHierarchyWithDescription; }
        }

        public long? AssociatedGN75BFormNumber
        {
            get { return InternalFormGN75A.AssociatedFormGN75BNumber; }
        }

        public string SafeWorkPermitNumbersDisplayText { get; private set; }

        private FormGN75A InternalFormGN75A
        {
            get { return (FormGN75A) edmontonForm; }
        }

        public override List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get { throw new NotImplementedException("The GN-75A form does not have mutiple Functional Locations"); }
        }
    }
}