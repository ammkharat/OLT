using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGN6ReportAdapter : BaseEdmontonFormReportAdapter
    {
        public FormGN6ReportAdapter(FormGN6 form)
            : base(form)
        {
            JobDescription = form.JobDescription;
            ReasonForCriticalLift = form.ReasonForCriticalLift;
            PreJobMeetingSignatures = form.PreJobMeetingSignatures;

            FormGN6SectionReportAdapters = new List<FormGN6SectionReportAdapter>
            {
                new FormGN6SectionReportAdapter(1, "Section 1 - Hoisting Personnel Using a Manbasket",
                    form.Section1NotApplicableToJob, form.Section1Content),
                new FormGN6SectionReportAdapter(2, "Section 2 – Total Load Exceeds 75% of Crane Chart Capacity",
                    form.Section2NotApplicableToJob, form.Section2Content),
                new FormGN6SectionReportAdapter(3,
                    "Section 3 - Can Enter Within Limit of Approach of High Voltage Power Lines or Outdoor Substation",
                    form.Section3NotApplicableToJob, form.Section3Content),
                new FormGN6SectionReportAdapter(4, "Section 4 - Lift on or Over Alky Acid Drums",
                    form.Section4NotApplicableToJob, form.Section4Content),
                new FormGN6SectionReportAdapter(5,
                    "Section 5 - Lift Using Two or More Cranes (Total Load Exceeds 75% of any Involved Crane Chart Capacity)",
                    form.Section5NotApplicableToJob, form.Section5Content),
                new FormGN6SectionReportAdapter(6, "Section 6 – Other", form.Section6NotApplicableToJob,
                    form.Section6Content),
                new FormGN6SectionReportAdapter(7, "Workers Responsibilities", false,
                    form.WorkerResponsibiltiesTemplateText)
            };
        }

        public string JobDescription { get; private set; }
        public string ReasonForCriticalLift { get; private set; }

        public string PreJobMeetingSignatures { get; private set; }

        public List<FormGN6SectionReportAdapter> FormGN6SectionReportAdapters { get; private set; }

        public override List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                return
                    ((FormGN6) edmontonForm).FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }
    }

    public class FormGN6SectionReportAdapter
    {
        public FormGN6SectionReportAdapter(int displayOrder, string sectionTitle, bool sectionNotFilledOut,
            string sectionContentAsRtf)
        {
            DisplayOrder = displayOrder;
            SectionTitle = sectionTitle;
            SectionNotFilledOut = sectionNotFilledOut;
            SectionContentsAsRtf = sectionContentAsRtf;
        }

        public int DisplayOrder { get; private set; }
        public string SectionTitle { get; private set; }
        public bool SectionNotFilledOut { get; private set; }
        public string SectionContentsAsRtf { get; private set; }
    }
}