using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class TradeChecklistInfo
    {
        public TradeChecklistInfo(TradeChecklist tradeChecklist)
            : this(tradeChecklist.IdValue, tradeChecklist.Trade, tradeChecklist.TradeChecklistInformationDisplayText)
        {
        }

        public TradeChecklistInfo(long id, string trade, string informationDisplayText)
        {
            Id = id;
            Trade = trade;
            InformationDisplayText = informationDisplayText;
        }

        public long Id { get; private set; }
        public string Trade { get; private set; }
        public string InformationDisplayText { get; private set; }

        public string ListDisplayString
        {
            get { return string.Format("{0} ({1})", InformationDisplayText, Trade); }
        }
    }
}