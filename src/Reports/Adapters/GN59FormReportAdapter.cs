using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class GN59FormReportAdapter : FormReportAdapter
    {
        private readonly FormGN59 form;

        public GN59FormReportAdapter(FormGN59 form)
            : base(form)
        {
            this.form = form;
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
                    ((FormGN59) edmontonForm).FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }
    }
}