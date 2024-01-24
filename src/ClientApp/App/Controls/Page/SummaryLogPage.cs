using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class SummaryLogPage : AbstractPage<SummaryLogDTO, ISummaryLogDetails>, ISummaryLogPage
    {
        public SummaryLogPage() : base(
            new DomainSummaryGrid<SummaryLogDTO>(
                new SummaryLogGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, string.Empty),
                new SummaryLogDetails()
            )
        {
        }

        public override PageKey PageKey
        {
            get
            {
                return 
                ClientSession.GetUserContext().Site.Id == Common.Domain.Site.Contruction_Mgnt_ID ?
                    PageKey.SUMMARY_LOG_PAGE_ConstMgntSite : PageKey.SUMMARY_LOG_PAGE;//RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
                
            }
        }

        protected override bool IsCreatedByCurrentUser(SummaryLogDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(SummaryLogDTO dto)
        {
            return (dto != null && dto.LastModifiedFullNameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

        protected IForm GetReplyForm(Log replyToLog)
        {
            return new LogReplyForm(replyToLog);
        }

        public void LaunchCreateReplyForm(SummaryLog summaryLogToReplyTo)
        {
            IForm newForm = new LogReplyForm(summaryLogToReplyTo);
            newForm.ShowDialog(ParentForm);
            newForm.Dispose();
        }

        public bool ShowLogThread
        {
            set { Details.ShowTreePanel = value; }
            get { return Details.ShowTreePanel; }
        }

        public void SelectThreadItem(IThreadableDTO dto)
        {
            Details.SelectThreadItem(dto);
        }

        public void SetIsParentMissing(bool isMissing)
        {
            Details.ParentIsMissingMessageEnabled = isMissing;
        }

        public IThreadableDTO FirstSelectedThreadableItem
        {
            get { return FirstSelectedItem; }
        }

        public List<IThreadableDTO> ThreadableItems
        {
            get { return new List<SummaryLogDTO>(Items).ConvertAll(o => (IThreadableDTO) o); }
        }

        public IThreadedItemDetails ThreadedItemDetails
        {
            get { return Details; }
        }
    }
}
