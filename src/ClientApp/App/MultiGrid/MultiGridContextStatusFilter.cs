using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class MultiGridContextStatusFilter : IMultiGridContextFilter
    {
        private FormStatus userSelectedFormStatus;
        private readonly WidgetAppearance defaultWidgetAppearance = Constants.SHOW_CLOSED_WIDGET_APPEARANCE;
        
        public void HandleFilterToggle(IMultiGridContext context)
        {
            userSelectedFormStatus = context.Details.ShowButtonAppearance == Constants.SHOW_CLOSED_WIDGET_APPEARANCE
                ? FormStatus.Closed : FormStatus.Approved;
            RefreshData(context, false);
        }

        public void SetPageTitle(IMultiGridContext context)
        {
            AbstractMultiGridPage page = context.Page;
            page.PageTitle = string.Format(StringResources.FormGn75B_Grid_Filter, GetFormStatusFilter(context).Name);
        }

        //INC0453097 Aarti
        public void RefreshData(IMultiGridContext context, bool loadInForeground)
        {
            if (userSelectedFormStatus == null || userSelectedFormStatus.ToString() == "Approved")
            {
                context.Details.ShowButtonAppearance = defaultWidgetAppearance;
            }
            else
            {
                context.Details.ShowButtonAppearance = Equals(userSelectedFormStatus, context.GetDefaultFormStatus())
                    ? Constants.SHOW_CLOSED_WIDGET_APPEARANCE: Constants.SHOW_APPROVED_WIDGET_APPEARANCE;
            }

            FormStatus status = userSelectedFormStatus ?? context.GetDefaultFormStatus();
            DtoFilters dtoFilters = new DtoFilters(null, new List<FormStatus>{status});
            GetBackgroundHelper(context, loadInForeground).Run(dtoFilters);
        }

        public Range<Date> GetDateRange(IMultiGridContext context)
        {
            return null;
        }

        public FormStatus GetFormStatusFilter(IMultiGridContext context)
        {
            return userSelectedFormStatus ?? context.GetDefaultFormStatus();
        }

        private IBackgroundHelper<DtoFilters> GetBackgroundHelper(IMultiGridContext context, bool loadInForeground)
        {
            return loadInForeground
                       ? (IBackgroundHelper<DtoFilters>)new FakeBackgroundHelper<DtoFilters, IList<DomainObject>>(new DtoFetcher(context, defaultWidgetAppearance))
                       : new BackgroundHelper<DtoFilters, IList<DomainObject>>(new ClientBackgroundWorker(), new DtoFetcher(context, defaultWidgetAppearance));
        }

    }
}