using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Localization;
using ResourcesResx = Com.Suncor.Olt.Client.Properties.Resources;

namespace Com.Suncor.Olt.Client
{
    public class Constants
    {
        public static readonly WidgetAppearance SHOW_DATE_RANGE_WIDGET_APPEARANCE =
            new WidgetAppearance(StringResources.DateRangeButtonRangeText,
                                StringResources.DateRangeButtonRangeLongText,
                                 ResourcesResx.show_date_range);

        public static readonly WidgetAppearance SHOW_CURRENT_WIDGET_APPEARANCE =
            new WidgetAppearance(StringResources.DateRangeButtonCurrentText,
                                 StringResources.DateRangeButtonCurrentLongText,
                                 ResourcesResx.view_current);
        
        //public static readonly WidgetAppearance SHOW_APPROVED_WIDGET_APPEARANCE =
        //    new WidgetAppearance("View " + StringResources.FormStatus_Approved,
        //        "View " + StringResources.FormStatus_Approved,
        //        ResourcesResx.approved);
        //INC0458131 Aarti (Change View Approved button to View All)
        public static readonly WidgetAppearance SHOW_APPROVED_WIDGET_APPEARANCE =
           new WidgetAppearance("View " + StringResources.Formstatus_All,
               "View " + StringResources.Formstatus_All,
               ResourcesResx.approved);

        public static readonly WidgetAppearance SHOW_CLOSED_WIDGET_APPEARANCE =
            new WidgetAppearance("View " + StringResources.FormStatus_Closed,
                "View " + StringResources.FormStatus_Closed,
                ResourcesResx.completedPermit);

        public static WidgetAppearance GetPlantHistorianReadAppearance(bool valid)
        {
            return valid ? PH_TAG_READ_VALID_STATUS_APPEARANCE : PH_TAG_READ_INVALID_STATUS_APPEARANCE;
        }
        public static WidgetAppearance GetPlantHistorianWriteAppearance(bool valid)
        {
            return valid ? PH_TAG_WRITE_VALID_STATUS_APPEARANCE : PH_TAG_WRITE_INVALID_STATUS_APPEARANCE;
        }

        public static readonly WidgetAppearance PH_TAG_READ_VALID_STATUS_APPEARANCE =
            new WidgetAppearance(StringResources.ValidPlantHistorianRead,
                                 StringResources.ValidPlantHistorianRead,
                                 ResourceUtils.APPROVED);

        public static readonly WidgetAppearance PH_TAG_READ_INVALID_STATUS_APPEARANCE =
            new WidgetAppearance(StringResources.InvalidPlantHistorianRead,
                                 StringResources.InvalidPlantHistorianRead,
                                 ResourceUtils.REJECTED);

        public static readonly WidgetAppearance PH_TAG_WRITE_VALID_STATUS_APPEARANCE =
           new WidgetAppearance(StringResources.ValidPlantHistorianWrite,
                                StringResources.ValidPlantHistorianWrite,
                                ResourceUtils.APPROVED);

        public static readonly WidgetAppearance PH_TAG_WRITE_INVALID_STATUS_APPEARANCE =
            new WidgetAppearance(StringResources.InvalidPlantHistorianWrite,
                                 StringResources.InvalidPlantHistorianWrite,
                                 ResourceUtils.REJECTED);
    }
}
