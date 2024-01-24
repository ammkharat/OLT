using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Localization;
using System.Linq;
using Com.Suncor.Olt.Reports.SubReports.DailyShiftLog;
using Com.Suncor.Olt.Common.Domain;
using System.Data;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ReadingReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        public ReadingReportAdapter(String labelTitle, TrackerReport reportDTO)
        {
            graphtype =(DevExpress.XtraCharts.ViewType)reportDTO.GraphType;
            dt = reportDTO.dt;
            Label_Title = labelTitle;
            ActionItemDefinitionName = reportDTO.ActionItemDefinitionName;
            CustomFieldName = reportDTO.CustomFieldName;
            ListStr = reportDTO.ListValue;
            ListTime = reportDTO.ListTime;
            if(ListStr == null)
            {
                ListTime = null;
            }
            string[] lst = null;
            string[] timelst = null;
            if (ListStr != null)
            {
                lst = ListStr.Split(',');
                timelst = ListTime.Split(',');
            }

            var tmpList = lst;
//            string NewTempList = "";
            if (tmpList != null)
            {
                int i = 0;
                foreach (string item in tmpList)
                {
                    if (item != "Unavailable")
                    {
                        //NewTempList = NewTempList + item.ToString() + "\t";
                        switch(i+1)
                            {
                            case 1:
                                Val1 = item;
                                TS1 = timelst[i].ToString();
                                break;
                            case 2:
                                Val2 = item;
                                TS2 = timelst[i].ToString();
                                break;
                            case 3:
                                Val3 = item;
                                TS3 = timelst[i].ToString();
                                break;
                            case 4:
                                Val4 = item;
                                TS4 = timelst[i].ToString();
                                break;
                            case 5:
                                Val5 = item;
                                TS5 = timelst[i].ToString();
                                break;
                        }
                        i++;

                    }
                }
            }

            
            //if (ListTime != null)
            //{
            //    timelst = ListTime.Split(',');
            //}

            //var tmpTimeList = timelst;
            //if (tmpTimeList != null)
            //{
            //    int i = 1;
            //    foreach (string item in tmpTimeList)
            //    {
            //        if (item != null)
            //        {
            //            switch (i)
            //            {
            //                case 1:
            //                    TS1 = item;
            //                    break;
            //                case 2:
            //                    TS2 = item;
            //                    break;
            //                case 3:
            //                    TS3 = item;
            //                    break;
            //                case 4:
            //                    TS4 = item;
            //                    break;
            //                case 5:
            //                    TS5 = item;
            //                    break;
            //            }
            //            i++;
            //        }
            //    }
            //}
            ///NewList = NewTempList;
        }

        public string CustomFieldLabelText { get; private set; }
        public string AidDesc { get; private set; }
        public string ActionItemDefinitionName { get; private set;}
        public string CustomFieldName { get; private set; }
        public string ListStr { get; private set; }
        public string ListTime { get; private set; }
        public string NewList { get; private set; }
        public string TimeStamp { get; private set; }
        public string Val1 { get; private set; }
        public string Val2 { get; private set; }
        public string Val3 { get; private set; }
        public string Val4 { get; private set; }
        public string Val5 { get; private set; }
        public string TS1 { get; private set; }
        public string TS2 { get; private set; }
        public string TS3 { get; private set; }
        public string TS4 { get; private set; }
        public string TS5 { get; private set; }
        public DataTable dt;
        public DevExpress.XtraCharts.ViewType graphtype { get; set; }
    }


//    public class DailyShiftLogCommentsReportAdapter : AbstractLocalizedReportAdapter
//    {
//        public DailyShiftLogCommentsReportAdapter(LogReportDTO dto)
//        {
//            ShiftName = dto.ShiftName;
//            ShiftStartDate = dto.ShiftStartDateTime;
//            FunctionalLocationFullHierarchy = dto.FunctionalLocationFullHierarchy;
//            FunctionalLocationUnitLevel = dto.FunctionalLocationUnitLevel;
//            FunctionalLocationDescription = dto.FunctionalLocationDescription;
//            FunctionalLocationUnitLevelDescription = dto.FunctionalLocationUnitLevelDescription;
//            LoggedByUser = dto.LastModifiedByUser;
//            LoggedDate = dto.LogDateTime;
//            RtfComments = dto.RtfComments;

////            Label_Title = StringResources.ReportLabel_Title_DailyShiftLog;
//   //mangesh # RITM0208281
//            IsOnlyReturnLogsFlaggedAsOperatingEngineerLog = dto.IsOnlyReturnLogsFlaggedAsOperatingEngineerLog;
//            CustomFieldsReportAdapters = CustomFieldsReportAdapter.GetCustomFields(dto.IdValue, dto).ToList();
//            FunctionalLocations = dto.FunctionalLocationNames.Aggregate(new System.Text.StringBuilder(),
//                  (sb, a) => sb.AppendLine(String.Join(",", a)),
//                  sb => sb.ToString());
//            ShowCustomFields = dto.CustomFieldEntries != null &&
//                               dto.CustomFieldEntries.Count > 0 &&
//                               dto.CustomFieldEntries.Exists(obj => !string.IsNullOrEmpty(obj.FieldEntryForDisplay));
//            CustomFieldLabelText = IsOnlyReturnLogsFlaggedAsOperatingEngineerLog && ShowCustomFields ? StringResources.ReportLabel_CustomFields.ToUpper() : string.Empty;        }

//    //mangesh # RITM0208281
//        public List<CustomFieldsReportAdapter> CustomFieldsReportAdapters { get; set; }
//        public string FunctionalLocations { get; private set; }
//        public bool IsOnlyReturnLogsFlaggedAsOperatingEngineerLog { get; private set; }
//        public bool ShowCustomFields { get; private set; }
//        public string CustomFieldLabelText { get; private set; }
//        public string ShiftName { get; private set; }
//        public DateTime ShiftStartDate { get; private set; }

//        public string FunctionalLocationFullHierarchy { get; private set; }
//        public string FunctionalLocationUnitLevel { get; private set; }
//        public string FunctionalLocationDescription { get; private set; }
//        public string FunctionalLocationUnitLevelDescription { get; private set; }

//        public string LoggedByUser { get; private set; }
//        public DateTime LoggedDate { get; private set; }

//        public string RtfComments { get; private set; }
//    }
}