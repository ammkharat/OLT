using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class OperatingEngineerLogPage : AbstractLogPage
    {
        private readonly string siteConfiguredDisplayName;

        public OperatingEngineerLogPage(string siteConfiguredDisplayName)
            : base(
            new LogDetails(),
            new LogGridRenderer(true, LogType.Standard, false))
        {
            this.siteConfiguredDisplayName = siteConfiguredDisplayName;
        }

        public override PageKey PageKey
        {
            get { return PageKey.OPERATING_ENGINEER_LOG_PAGE; }
        }

        public override string TabText
        {
            get { return siteConfiguredDisplayName; }
        }

        protected override IForm GetCopyForm(Log log)
        {
            return LogForm.CreateForCopy(log);
        }

        protected override IForm GetReplyForm(Log replyToLog)
        {
            return new LogReplyForm(replyToLog);
        }
    }
}