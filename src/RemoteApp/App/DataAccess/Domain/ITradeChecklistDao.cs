using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // This is only used within the GN1 object. Trade Checklists don't make sense outside of a GN1
    public interface ITradeChecklistDao : IDao
    {        
        void Insert(TradeChecklist tradeChecklist);
        
        List<TradeChecklist> QueryByGN1Id(long id);
      
        void Update(TradeChecklist tradeChecklist);               

        void DeleteByFormGN1Id(long formGN1Id);

        void Remove(TradeChecklist tradeChecklist);

        int? GetMaxSequenceNumber(long formGN1Id);
    }
}