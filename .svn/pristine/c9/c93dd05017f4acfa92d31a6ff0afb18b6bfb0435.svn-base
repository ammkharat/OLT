using System;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IApprovableDetails : IDeletableDetails
    {
        event EventHandler Approve;
        event EventHandler Reject;
        event EventHandler Comment;

        bool ApproveEnabled { set; }
        bool RejectEnabled { set; }
        bool CommentEnabled { set; }
    }
}
