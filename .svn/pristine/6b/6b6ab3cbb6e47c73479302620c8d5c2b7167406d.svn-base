using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CustomFieldTablePresenter : BaseFormPresenter<ICustomFieldTableView>
    {
        private readonly long customFieldId;
        private readonly string customFieldName;
        private readonly long workAssignmentId;
        private readonly string workAssignmentName;
        private readonly INumericAndNonnumericCustomFieldEntryListService service;

        public CustomFieldTablePresenter(CustomFieldEntry customFieldEntry, long workAssignmentId, string workAssignmentName, INumericAndNonnumericCustomFieldEntryListService service)
            : this(new CustomFieldTableForm(), customFieldEntry.CustomFieldId.Value, customFieldEntry.CustomFieldName, workAssignmentId, workAssignmentName, service)
        {            
        }

        public CustomFieldTablePresenter(CustomField customField, long workAssignmentId, string workAssignmentName, INumericAndNonnumericCustomFieldEntryListService service)
            : this(new CustomFieldTableForm(), customField.IdValue, customField.Name, workAssignmentId, workAssignmentName, service)
        {            
        }

        public CustomFieldTablePresenter(ICustomFieldTableView view, long customFieldId, string customFieldName, long workAssignmentId, string workAssignmentName, INumericAndNonnumericCustomFieldEntryListService service)
            : base(view)
        {
            this.customFieldId = customFieldId;
            this.customFieldName = customFieldName;
            this.workAssignmentId = workAssignmentId;
            this.workAssignmentName = workAssignmentName;
            this.service = service;

            view.CloseButtonClick += HandleCloseButtonClick;
            view.ViewLoad += HandleViewLoad;
            view.ViewShown += HandleViewShown;
            view.RefreshClick += HandleRefreshClick;
            view.ExportClick += HandleExportClick;

            view.DisclaimerLabel = StringResources.CustomFieldTrendDisclaimer;
        }

        private void HandleExportClick()
        {
            view.ExportToExcel();
        }

        private void HandleRefreshClick()
        {
            RefreshTable();
        }

        private void HandleCloseButtonClick()
        {
            view.Close();
        }

        private void HandleViewLoad()
        {
            view.Title = String.Format("{0} - {1}", workAssignmentName, customFieldName);

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

        private void HandleViewShown()
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            List<NonnumericCustomFieldEntryDTO> list = new List<NonnumericCustomFieldEntryDTO>();
            DateRange dateRange = null;

            if (view.CustomRangeChecked)
            {
                Date startDate = view.StartDate;
                Date endDate = view.EndDate;
                dateRange = new DateRange(startDate, endDate);
            }
            else if (view.FixedRangeChecked)
            {
                Duration duration = view.SelectedFixedRangeDuration;
                DateTime now = Clock.Now;
                Date today = new Date(now);
                Date durationAgo = duration.Before(today);
                dateRange = new DateRange(durationAgo, today);
            }

            if (dateRange != null)
            {
                list.AddRange(service.QueryNonnumericCustomFieldEntries(customFieldId, workAssignmentId, ClientSession.GetUserContext().Site, dateRange));
            }

            view.CustomFieldEntries = list;
        }
    }
}
