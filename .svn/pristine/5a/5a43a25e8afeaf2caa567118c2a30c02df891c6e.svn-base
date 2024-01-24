using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public abstract class AbstractLogPage : AbstractPage<LogDTO, ILogDetails>, ILogPage
    {
        protected AbstractLogPage(ILogDetails logDetails)
            : this(logDetails, new LogGridRenderer(true, LogType.Standard, false))
        {
        }

        protected AbstractLogPage(ILogDetails logDetails, IGridRenderer gridRenderer)
            : base(new DomainSummaryGrid<LogDTO>(gridRenderer, OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "LogGrid"),
                   logDetails)
        {
        }

        protected abstract IForm GetCopyForm(Log log);
        protected abstract IForm GetReplyForm(Log replyToLog);

        public void SelectThreadItem(IThreadableDTO selectedDto)
        {
            Details.SelectThreadItem(selectedDto);
        }

        public void SetIsParentMissing(bool isMissing)
        {
            Details.ParentIsMissingMessageEnabled = isMissing;
        }

        public void LaunchCreateForm(Log log)
        {
            IForm newForm = GetCopyForm(log);
            newForm.ShowDialog(ParentForm);
            newForm.Dispose();
        }

        public void LaunchCreateReplyForm(Log replyToLog)
        {
            IForm newForm = GetReplyForm(replyToLog);
            newForm.ShowDialog(ParentForm);
            newForm.Dispose();
        }

        public bool ShowLogThread
        {
            set { Details.ShowTreePanel = value; }
            get { return Details.ShowTreePanel; }
        }
       
        protected override bool IsCreatedByCurrentUser(LogDTO log)
        {
            return (log != null && log.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(LogDTO log)
        {
            return (log != null && log.LastModifiedFullNameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

        public IThreadableDTO FirstSelectedThreadableItem
        {
            get { return FirstSelectedItem; }
        }

        public List<IThreadableDTO> ThreadableItems
        {
            get { return new List<LogDTO>(Items).ConvertAll(o => (IThreadableDTO) o); }
        }

        public IThreadedItemDetails ThreadedItemDetails
        {
            get { return Details; }
        }
    }
}
