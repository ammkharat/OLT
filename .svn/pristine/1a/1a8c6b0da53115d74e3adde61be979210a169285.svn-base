using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class TradeChecklistHistory : DomainObjectHistorySnapshot
    {
        public TradeChecklistHistory(long id, string trade, string content, User lastModifiedBy,
            DateTime lastModifiedDateTime) : base(id, lastModifiedBy, lastModifiedDateTime)
        {
            Trade = trade;
            Content = content;
        }

        public string Trade { get; private set; }

        public string Content { get; private set; }
    }
}