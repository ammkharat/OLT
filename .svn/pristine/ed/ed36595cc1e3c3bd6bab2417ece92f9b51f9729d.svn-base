using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LabAlertDefinitionFormPresenter : AbstractFormPresenter <ILabAlertDefinitionFormView, LabAlertDefinition>
    {
        private readonly ILabAlertDefinitionService service;

        public LabAlertDefinitionFormPresenter(ILabAlertDefinitionFormView view) 
            : this(view, CreateDefaultLabAlertDefinition())
        {
        }

        public LabAlertDefinitionFormPresenter(ILabAlertDefinitionFormView view, LabAlertDefinition definition) 
            : base(view, definition)
        {            
            service = ClientServiceRegistry.Instance.GetService<ILabAlertDefinitionService>();
        }

        public void Form_Load(object sender, EventArgs e)
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.LabAlertDefinitionFormTitle);
            view.ViewEditHistoryEnabled = IsEdit;
            
            UpdateViewFromEditObject();
        }

        protected void UpdateViewWithDefaults()
        {
            editObject = CreateDefaultLabAlertDefinition();
            UpdateViewFromEditObject();
        }

        private static LabAlertDefinition CreateDefaultLabAlertDefinition()
        {
            DateTime now = Clock.Now;

            LabAlertDefinition definition = new LabAlertDefinition(
                null,
                null,
                null,
                null,
                1,
                new LabAlertTagQueryDailyRange(new Time(0), new Time(0)),
                new RecurringDailySchedule(new Date(now), null, new Time(0), new Time(0), 1, ClientSession.GetUserContext().Site),
                true,
                ClientSession.GetUserContext().User,
                now,
                ClientSession.GetUserContext().User,
                now,
                LabAlertDefinitionStatus.Valid);
            return definition;
        }

        private void UpdateViewFromEditObject()
        {
            view.Name = editObject.Name;
            view.Description = editObject.Description;
            view.FunctionalLocation = editObject.FunctionalLocation;
            view.TagInfo = editObject.TagInfo;
            view.MinimumNumberOfSamples = editObject.MinimumNumberOfSamples;
            view.LabAlertTagQueryRange = editObject.LabAlertTagQueryRange;
            view.Schedule = editObject.Schedule;
            view.IsActive = editObject.IsActive;
            view.Author = editObject.LastModifiedBy;
            view.CreateDateTime = editObject.LastModifiedDate;
        }

        private void PopulateLabAlertDefinitionFromView()
        {           
            editObject.Name = view.Name;
            editObject.Description = view.Description;
            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.TagInfo = view.TagInfo;
            editObject.MinimumNumberOfSamples = view.MinimumNumberOfSamples;
            editObject.LabAlertTagQueryRange = view.LabAlertTagQueryRange;
            editObject.Schedule = view.Schedule;
            editObject.IsActive = view.IsActive;
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDate = Clock.Now;
        }

        public void SchedulePicker_ScheduleTypeChanged(ScheduleType scheduleType, Time dailyTime)
        {
            if (scheduleType == ScheduleType.Daily)
            {
                if (view.LabAlertTagQueryRange.LabAlertTagQueryRangeType != LabAlertTagQueryRangeType.Daily)
                {
                    view.LabAlertTagQueryRange = new LabAlertTagQueryDailyRange(dailyTime, dailyTime);
                }
            }
            else if (scheduleType == ScheduleType.Weekly)
            {
                if (view.LabAlertTagQueryRange.LabAlertTagQueryRangeType != LabAlertTagQueryRangeType.Weekly)
                {
                    view.LabAlertTagQueryRange = new LabAlertTagQueryWeeklyRange(new Time(0), new Time(0), DayOfWeek.Sunday, DayOfWeek.Sunday);
                }
            }
            else if (scheduleType == ScheduleType.MonthlyDayOfWeek)
            {
                if (view.LabAlertTagQueryRange.LabAlertTagQueryRangeType != LabAlertTagQueryRangeType.MonthlyDayOfWeek)
                {
                    view.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfWeekRange(new Time(0), new Time(0), WeekOfMonth.First, WeekOfMonth.First, DayOfWeek.Sunday, DayOfWeek.Sunday);
                }
            }
            else if (scheduleType == ScheduleType.MonthlyDayOfMonth)
            {
                if (view.LabAlertTagQueryRange.LabAlertTagQueryRangeType != LabAlertTagQueryRangeType.MonthlyDayOfMonth)
                {
                    view.LabAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(0), new Time(0), DayOfMonth.First, DayOfMonth.First);
                }
            }
            else
            {
                throw new Exception("Unrecognized schedule type: " + scheduleType);
            }
        }

        public void FunctionalLocationButton_Click(object sender, EventArgs e)
        {
            DialogResultAndOutput<FunctionalLocation> result = view.ShowFunctionalLocationSelector();
            if (result.Result == DialogResult.OK)
            {
                view.FunctionalLocation = result.Output;
            }
        }

        public void SearchTagButtonClick(object sender, EventArgs eventArgs)
        {
            DialogResultAndOutput<TagInfo> result = view.ShowTagSelector();
            if(result.Result == DialogResult.OK)
            {
                TagInfo tagInfo = result.Output;
                view.TagInfo = tagInfo;
            }
        }

        public void ViewEditHistoryButton_Click(object sender, EventArgs e)
        {
            EditLabAlertDefinitionHistoryFormPresenter presenter = new EditLabAlertDefinitionHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public override void Insert(SaveUpdateDomainObjectContainer<LabAlertDefinition> itemToInsert)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, itemToInsert.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<LabAlertDefinition> itemToUpdate)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, itemToUpdate.Item);
        }

        protected override SaveUpdateDomainObjectContainer<LabAlertDefinition> GetNewObjectToInsert()
        {
            PopulateLabAlertDefinitionFromView();
            return new SaveUpdateDomainObjectContainer<LabAlertDefinition>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<LabAlertDefinition> GetPopulatedEditObjectToUpdate()
        {
            PopulateLabAlertDefinitionFromView();
            return new SaveUpdateDomainObjectContainer<LabAlertDefinition>(editObject);
        }
             
        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();
            bool hasError = false;

            if (view.Description.IsNullOrEmptyOrWhitespace())
            {
                view.ShowDescriptionIsEmptyError();
                hasError = true;
            }
            if(view.FunctionalLocation == null)
            {
                view.ShowNoFunctionalLocationsSelectedError();
                hasError = true;
            }
            if (view.TagInfo == null)
            {
                view.ShowNoTagInfoSelectedError();
                hasError = true;                
            }
            if (view.HasScheduleError)
            {
                hasError = true;
            }

            if (view.Name.IsNullOrEmptyOrWhitespace())
            {
                view.ShowNameIsEmptyError();
                hasError = true;
            }
            else
            {
                Site site = userContext.Site;
                Error nameError = service.IsValidName(view.Name, site, editObject);
                if (nameError.HasError)
                {
                    view.ShowNameError(nameError.Message);
                    hasError = true;
                }
            }

            return hasError;
        }

    }
}
