using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CustomFieldTrendPresenter : BaseFormPresenter<CustomFieldTrendForm>
    {
        private readonly long customFieldId;
        private readonly string customFieldName;
        private readonly long workAssignmentId;
        private readonly string workAssignmentName;

        private readonly INumericAndNonnumericCustomFieldEntryListService service;

        public CustomFieldTrendPresenter(INumericAndNonnumericCustomFieldEntryListService service, CustomField customField, long workAssignmentId, string workAssignmentName)
            : this(service, customField.IdValue, customField.Name, workAssignmentId, workAssignmentName)
        {
        }

        public CustomFieldTrendPresenter(INumericAndNonnumericCustomFieldEntryListService service, CustomFieldEntry customFieldEntry, long workAssignmentId, string workAssignmentName)
            : this(service, customFieldEntry.CustomFieldId.Value, customFieldEntry.CustomFieldName, workAssignmentId, workAssignmentName)
        {
            
        }

        private CustomFieldTrendPresenter(INumericAndNonnumericCustomFieldEntryListService service, long customFieldId, string customFieldName, long workAssignmentId, string workAssignmentName) : base(new CustomFieldTrendForm(customFieldName))
        {
            this.service = service;
            
            this.customFieldId = customFieldId;
            this.customFieldName = customFieldName;
            this.workAssignmentId = workAssignmentId;
            this.workAssignmentName = workAssignmentName;

            view.Load += ViewLoad;
            view.Shown += ViewShown;
            view.RefreshButtonClicked += RefreshChart;            
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            view.FormTitle = String.Format("{0} - {1}", workAssignmentName, customFieldName);

            view.AddFixedRangeDuration(Duration.OneWeek);
            view.AddFixedRangeDuration(Duration.OneMonth);
            view.AddFixedRangeDuration(Duration.ThreeMonths);
            view.AddFixedRangeDuration(Duration.SixMonths);
            view.AddFixedRangeDuration(Duration.OneYear);
            view.SelectedFixedRangeDuration = Duration.OneWeek;
            view.FixedRangeChecked = true;
            
            Date date = Clock.Now.ToDate();
            view.EndDate = date;
            view.StartDate = date.SubtractDays(7);

        }

        private void RefreshChart()
        {
            view.ShowWait();
            List<NumericCustomFieldEntryDTO> list;
            DateRange dateRange = null;
            if (view.CustomRangeChecked)
            {
                Date startDate = view.StartDate;
                Date endDate = view.EndDate;
                dateRange = new DateRange(startDate, endDate);
                list = service.QueryNumericCustomFieldEntries(customFieldId, workAssignmentId, ClientSession.GetUserContext().Site, dateRange);
            }

            else if (view.FixedRangeChecked)
            {
                Duration duration = view.SelectedFixedRangeDuration;
                DateTime now = Clock.Now;
                Date today = new Date(now);
                Date durationAgo = duration.Before(today);
                dateRange = new DateRange(durationAgo, today);
                list = service.QueryNumericCustomFieldEntries(customFieldId, workAssignmentId, ClientSession.GetUserContext().Site, dateRange);
            }
            else
            {
                list = new List<NumericCustomFieldEntryDTO>(0);
            }

            view.UpdateChart(list, dateRange);
            view.CloseWait();

        }

        private void ViewShown(object sender, EventArgs e)
        {
            RefreshChart();
        }
    }
}