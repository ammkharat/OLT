using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class MultiGridContextDateFilter : IMultiGridContextFilter
    {
        private readonly WidgetAppearance defaultWidgetAppearance = Constants.SHOW_DATE_RANGE_WIDGET_APPEARANCE;
        private Range<Date> userSelectedDateRange;

        public void HandleFilterToggle(IMultiGridContext context)
        {
            if (context.Details.ShowButtonAppearance == Constants.SHOW_CURRENT_WIDGET_APPEARANCE)
            {
                userSelectedDateRange = context.GetDefaultDateRange();
                RefreshData(context, false);
            }
            else
            {
                DialogResultAndOutput<Range<Date>> dialogResultAndOutput = context.Page.DisplayDateRangeDialog();
                if (dialogResultAndOutput.Result == DialogResult.OK)
                {
                    userSelectedDateRange = dialogResultAndOutput.Output;
                    RefreshData(context, false);
                }
            }
        }

        public void SetPageTitle(IMultiGridContext context)
        {
            AbstractMultiGridPage page = context.Page;
            if (page.PageKey.Equals(PageKey.MULTIGRID_CSD_FORM_PAGE))
            {
                page.PageTitle = StringResources.CSDPagelabeltext;
                page.gridSelectionComboBoxVisible = false;
                return;
                
            }
            Range<Date> range = userSelectedDateRange ?? context.GetDefaultDateRange();

            Date lowerBound = range.LowerBound;
            Date upperBound = range.UpperBound;
            if (lowerBound == upperBound)
            {
                page.PageTitle = string.Format(StringResources.DateRangeIncludesTextForOneDay, page.PageKey.TitleText + " : ", lowerBound);
            }
            else
            {
                string upperBounds = upperBound != null ? upperBound.ToString() : StringResources.NoEnd_LowerCase;
                page.PageTitle = string.Format(StringResources.DateRangeIncludesText, page.PageKey.TitleText + " : ", lowerBound, upperBounds);
            }
        }

        public void RefreshData(IMultiGridContext context, bool loadInForeground)
        {
            if (userSelectedDateRange == null)
            {
                context.Details.ShowButtonAppearance = defaultWidgetAppearance;
            }
            else
            {
                context.Details.ShowButtonAppearance = Equals(userSelectedDateRange, context.GetDefaultDateRange())
                    ? Constants.SHOW_DATE_RANGE_WIDGET_APPEARANCE : Constants.SHOW_CURRENT_WIDGET_APPEARANCE;
            }

            Range<Date> range = userSelectedDateRange ?? context.GetDefaultDateRange();
            GetBackgroundHelper(context, loadInForeground).Run(new DtoFilters(range, FormStatus.All));
        }

        public Range<Date> GetDateRange(IMultiGridContext context)
        {
            return userSelectedDateRange ?? context.GetDefaultDateRange();
        }

        public FormStatus GetFormStatusFilter(IMultiGridContext context)
        {
            return null;
        }

        private IBackgroundHelper<DtoFilters> GetBackgroundHelper(IMultiGridContext context, bool loadInForeground)
        {
            return loadInForeground
                       ? (IBackgroundHelper<DtoFilters>) new FakeBackgroundHelper<DtoFilters, IList<DomainObject>>(new DtoFetcher(context, defaultWidgetAppearance))
                       : new BackgroundHelper<DtoFilters, IList<DomainObject>>(new ClientBackgroundWorker(), new DtoFetcher(context, defaultWidgetAppearance));
        }
    }
}