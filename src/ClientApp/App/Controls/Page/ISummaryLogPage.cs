using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface ISummaryLogPage : IDomainPage<SummaryLogDTO, ISummaryLogDetails>, IThreadedItemsPage
    {
        void LaunchCreateReplyForm(SummaryLog log);           
    }
}
