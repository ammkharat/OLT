using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class DailyDirectivesLogPage : AbstractLogPage
    {
        public DailyDirectivesLogPage()
            : base(new LogDetails(), new LogGridRenderer(false, LogType.DailyDirective, true))
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.DAILY_DIRECTIVES_LOG_PAGE; }
        }

        public override bool CanSelectItemFromAnotherPage
        {
            get { return false; }
        }

        protected override IForm GetCopyForm(Log log)
        {
            return DirectiveLogForm.CreateForCopy(log);
        }

        protected override IForm GetReplyForm(Log replyToLog)
        {
            return new LogReplyForm(replyToLog);
        }
    }
}