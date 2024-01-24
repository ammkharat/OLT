using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class GN7FormReportAdapter : FormReportAdapter
    {
        private readonly FormGN7 form;

        public GN7FormReportAdapter(FormGN7 form)
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
                    ((FormGN7) edmontonForm).FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }
    }
}