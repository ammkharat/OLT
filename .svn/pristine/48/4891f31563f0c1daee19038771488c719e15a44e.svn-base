using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGN24ReportAdapter : BaseEdmontonFormReportAdapter
    {
        public FormGN24ReportAdapter(FormGN24 form) : base(form)
        {
            IsSafeWorkPermitPlanForPsvRemovalYes = form.IsTheSafeWorkPlanForPSVRemovalOrInstallation;
            IsSafeWorkPermitPlanForPsvRemovalNo = !IsSafeWorkPermitPlanForPsvRemovalYes;

            IsSafeWorkPermitPlanForPsvAlkylationYes = form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit;
            IsSafeWorkPermitPlanForPsvAlkylationNo = !IsSafeWorkPermitPlanForPsvAlkylationYes;

            AlkylationClass = form.AlkylationClass != null ? form.AlkylationClass.Name : string.Empty;

            CommentsAsRtf = form.Content;
            PreJobMeetingSignatures = form.PreJobMeetingSignatures;
        }

        public bool IsSafeWorkPermitPlanForPsvRemovalYes { get; private set; }
        public bool IsSafeWorkPermitPlanForPsvRemovalNo { get; private set; }

        public bool IsSafeWorkPermitPlanForPsvAlkylationYes { get; private set; }
        public bool IsSafeWorkPermitPlanForPsvAlkylationNo { get; private set; }

        public string AlkylationClass { get; private set; }

        public string PreJobMeetingSignatures { get; private set; }

        public override string Label_Title
        {
            get
            {
                if (IsSafeWorkPermitPlanForPsvRemovalYes)
                {
                    return StringResources.FormGN24ReportTitle_PSV;
                }
                return StringResources.FormGN24ReportTitle_NonPSV;
            }
            protected set { base.Label_Title = value; }
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

        public override List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                return
                    ((FormGN24) edmontonForm).FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }
    }
}