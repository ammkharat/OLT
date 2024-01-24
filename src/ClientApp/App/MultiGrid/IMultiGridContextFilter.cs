using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public interface IMultiGridContextFilter
    {
        void HandleFilterToggle(IMultiGridContext context);
        void SetPageTitle(IMultiGridContext context);
        void RefreshData(IMultiGridContext context, bool loadInForeground);
        Range<Date> GetDateRange(IMultiGridContext context);
        FormStatus GetFormStatusFilter(IMultiGridContext context);
    }
}