using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ExtensionReasonReportAdapter
    {
        private readonly string comment;
        private readonly long parentId;

        public ExtensionReasonReportAdapter(Comment comment)
            : this(-1, comment)
        {
        }

        public ExtensionReasonReportAdapter(long parentId, Comment comment)
        {
            this.parentId = parentId;
            this.comment = comment.Text;
        }

        public ExtensionReasonReportAdapter(long parentId, string comment)
        {
            this.parentId = parentId;
            this.comment = comment;
        }
      
        public string ParentId
        {
            get { return parentId.ToString(CultureInfo.InvariantCulture); }
        }

        public long ParentIdAsNumber
        {
            get { return parentId; }
        }

        public string Comment
        {
            get { return comment; }
        }
    }
}