using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    public class ShiftSummaryItemSource : SortableSimpleDomainObject
    {
        public static readonly ShiftSummaryItemSource HandoverQuestions = new ShiftSummaryItemSource(0, 0);
        public static readonly ShiftSummaryItemSource HandoverLog = new ShiftSummaryItemSource(1, 1);
        public static readonly ShiftSummaryItemSource ShiftLog = new ShiftSummaryItemSource(2, 2);
        //add new logformsummary to filter newtest ayman
      //  public static readonly ShiftSummaryItemSource ShiftLogSummary = new ShiftSummaryItemSource(3, 3);
        public static readonly ShiftSummaryItemSource ActionItemResponse = new ShiftSummaryItemSource(4, 4);
        public static readonly ShiftSummaryItemSource TargetAlertResponse = new ShiftSummaryItemSource(5, 5);
        public static readonly ShiftSummaryItemSource SafeWorkPermit = new ShiftSummaryItemSource(6, 6);
        public static readonly ShiftSummaryItemSource LabAlertResponse = new ShiftSummaryItemSource(7, 7);
        public static readonly ShiftSummaryItemSource SapNotificationLog = new ShiftSummaryItemSource(8, 8);



        private ShiftSummaryItemSource(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            string name = null;
            switch (IdValue)
            {
                case 0:
                    name = StringResources.HandoverQuestions;
                    break;
                case 1:
                    name = StringResources.HandoverLog;
                    break;
                case 2:
                    name = StringResources.DomainObjectName_Log;
                    break;
                //case 3:
                //    name = StringResources.DomainObjectName_SummaryLog;
                //    break;
                case 4:
                    name = StringResources.ActionItemResponse;
                    break;
                case 5:
                    name = StringResources.TargetAlertResponse;
                    break;
                case 6:
                    name = StringResources.SafeWorkPermit;
                    break;
                case 7:
                    name = StringResources.LabAlertResponse;
                    break;

                    //ayman test to add shiftlogsummary to filter
                case 8:
                    name = StringResources.DomainObjectName_SAPNotification;                    
                    break;
            }

            return name;
        }
    }
}