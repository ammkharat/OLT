using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGN75RosterReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        public FormGN75RosterReportAdapter(IEdmontonForm form)
        {
            FormNumber = PadFormNumber(form.FormNumber);
        }

        public string FormNumber { get; private set; }
    }
}