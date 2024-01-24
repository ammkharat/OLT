using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class LogByAssignmentPage : AbstractLogPage
    {
        public LogByAssignmentPage() : base(new LogDetails())
        {
        }

        public override PageKey PageKey
        {
            get
            {
                return
                    ClientSession.GetUserContext().Site.Id == Common.Domain.Site.Contruction_Mgnt_ID ?
                    PageKey.LOG_BY_WORK_ASSIGNMENT_PAGE_ConstMgntSite : PageKey.LOG_BY_WORK_ASSIGNMENT_PAGE;//RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
            }
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
