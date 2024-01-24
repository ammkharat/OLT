using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using NMock2;
using Clock = Com.Suncor.Olt.Common.Utility.Clock;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class SchedulePickerPresenterTest
    {
        private Mockery mocks;
        private ISchedulePickerView viewMock;
        private SchedulePickerPresenter presenter;
        private readonly Date startDate = new Date(2000, 10, 20);
        private readonly Date endDate = new Date(2001, 10, 20);
        private readonly Time startTime = new Time(8, 0);
        private readonly Time endTime = new Time(10, 0);

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            viewMock = mocks.NewMock<ISchedulePickerView>();
            presenter = new SchedulePickerPresenter(viewMock);
            Clock.Freeze();
            Clock.TimeZone = TimeZoneFixture.GetSarniaTimeZone();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void TestCreateSingleScheduleFromView()
        {

            ClientSession.GetUserContext().User = UserFixture.CreateUser(SiteFixture.Sarnia());
            
            Stub.On(viewMock).GetProperty("SelectedScheduleType").Will(Return.Value(ScheduleType.Single));
            Stub.On(viewMock).GetProperty("StartDate").Will(Return.Value(startDate));
            Stub.On(viewMock).GetProperty("StartTime").Will(Return.Value(startTime));
            Stub.On(viewMock).GetProperty("EndDate").Will(Return.Value(endDate));
            Stub.On(viewMock).GetProperty("EndTime").Will(Return.Value(endTime));

            ISchedule schedule = presenter.CreateScheduleFromView();

            Assert.IsTrue(schedule is SingleSchedule);
        }

        [Test]
        public void TestCreateRoundTheClockSchedule()
        {
            ClientSession.GetUserContext().User = UserFixture.CreateUser(SiteFixture.Sarnia());

            Stub.On(viewMock).GetProperty("SelectedScheduleType").Will(Return.Value(ScheduleType.RoundTheClock));
            Stub.On(viewMock).GetProperty("StartDate").Will(Return.Value(startDate));
            Stub.On(viewMock).GetProperty("StartTime").Will(Return.Value(startTime));
            Stub.On(viewMock).GetProperty("EndDate").Will(Return.Value(endDate));
            Stub.On(viewMock).GetProperty("EndTime").Will(Return.Value(endTime));
            Stub.On(viewMock).GetProperty("Frequency").Will(Return.Value(2));

            ISchedule schedule = presenter.CreateScheduleFromView();

            Assert.IsTrue(schedule is RoundTheClockSchedule);
        }


        [Test]
        public void OnLoadSetViewEndTimeToTheSameAsTheViewStartTimeIfSchedulePresenterModeIsALog()
        {
            DateTime now = new DateTime(2000, 1, 1, 15, 0, 0);
            Date today = new Date(2000, 1, 1);
            Clock.Now = now;
            Time expectedNow = new Time(16, 0, 0);
            Expect.Once.On(viewMock).GetProperty("StartTime").Will(Return.Value(expectedNow));
            Stub.On(viewMock).GetProperty("Mode").Will(Return.Value(SchedulePresenterMode.Log));
            SetOnLoadExpectations(today, expectedNow, expectedNow);

            presenter.SchedulePicker_Load(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldInitializeToStartOnTheNextHourIfModeIsNotLog()
        {
            Clock.Now = new DateTime(2005, 12, 31, 23, 59, 59);
            Stub.On(viewMock).GetProperty("Mode").Will(Return.Value(SchedulePresenterMode.ActionItem));

            // Default start date/time should be the next hour from now. In this case, 
            // the next hour coming up after 2005/12/31 at 23:59:59 is 2006/01/01 at 00:00:00.
            Date nextHourDate = new Date(2006, 1, 1);
            Time nextHourTime = Time.MIDNIGHT;
            Time oneHourFromStartTime = new Time(1, 0, 0);

            SetOnLoadExpectations(nextHourDate, nextHourTime, oneHourFromStartTime);

            // Execute:
            presenter.SchedulePicker_Load(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetStartAndEndTimeFor24HoursIfModeIsTargetDefinitionAndTypeIsByMinute()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedScheduleType").Will(Return.Value(ScheduleType.ByMinute));
            Expect.Once.On(viewMock).GetProperty("Mode").Will(Return.Value(SchedulePresenterMode.Target));
            Expect.Once.On(viewMock).SetProperty("StartTime").To(new Time(00, 00));
            Expect.Once.On(viewMock).SetProperty("EndTime").To(new Time(23, 59));
            OltStub.On(viewMock);
            
            // Execute:
            presenter.ScheduleTypesComboBox_SelectedIndexChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetStartAndEndTimeFor24HoursIfModeIsTargetDefinitionAndTypeIsHourly()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedScheduleType").Will(Return.Value(ScheduleType.Hourly));
            Expect.Once.On(viewMock).GetProperty("Mode").Will(Return.Value(SchedulePresenterMode.Target));
            Expect.Once.On(viewMock).SetProperty("StartTime").To(new Time(00, 00));
            Expect.Once.On(viewMock).SetProperty("EndTime").To(new Time(23, 59));
            OltStub.On(viewMock);

            // Execute:
            presenter.ScheduleTypesComboBox_SelectedIndexChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetStartAndEndTimeFor24HoursIfModeIsTargetDefinitionAndTypeIsRoundTheClock()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedScheduleType").Will(Return.Value(ScheduleType.RoundTheClock));
            Expect.Once.On(viewMock).GetProperty("Mode").Will(Return.Value(SchedulePresenterMode.Target));
            Expect.Once.On(viewMock).SetProperty("StartTime").To(new Time(00, 00));
            Expect.Once.On(viewMock).SetProperty("EndTime").To(new Time(23, 59));
            Expect.Once.On(viewMock).SetProperty("TimeRangeLabel").To("Start/End Times");
            OltStub.On(viewMock);

            // Execute:
            presenter.ScheduleTypesComboBox_SelectedIndexChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetStartAndEndTimeForNextHourIfTypeIsDaily()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedScheduleType").Will(Return.Value(ScheduleType.Daily));
            Expect.Once.On(viewMock).SetProperty("StartTime").To(new Time(11, 00));
            Expect.Once.On(viewMock).SetProperty("EndTime").To(new Time(12, 00));
            OltStub.On(viewMock);
            
            // Execute:
            Clock.Now = new DateTime(2006, 08, 31, 10, 30, 00);
            presenter.SchedulePicker_Load(null, EventArgs.Empty);
            presenter.ScheduleTypesComboBox_SelectedIndexChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetStartAndEndTimeForNextHourIfTypeIsWeekly()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedScheduleType").Will(Return.Value(ScheduleType.Weekly));
            Expect.Once.On(viewMock).SetProperty("StartTime").To(new Time(11, 00));
            Expect.Once.On(viewMock).SetProperty("EndTime").To(new Time(12, 00));
            OltStub.On(viewMock);

            // Execute:
            Clock.Now = new DateTime(2006, 08, 31, 10, 30, 00);
            presenter.SchedulePicker_Load(null, EventArgs.Empty);
            presenter.ScheduleTypesComboBox_SelectedIndexChanged(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDefaultFrequencyToOnLoad()
        {
            Stub.On(viewMock).GetProperty("Mode").Will(Return.Value(SchedulePresenterMode.ActionItem));
            Stub.On(viewMock).Method(TestUtil.IsSetterNotEndingWith("Frequency"));
            SetOnLoadCommonExpectations();

            // Execute:
            presenter.SchedulePicker_Load(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldValidateAtLeastOneDayOfWeekPickedIfRecurringByWeek()
        {
            // If a recurring weekly schedule is picked, at least one of the days of the week should be selected:
            Expect.Once.On(viewMock).GetProperty("SelectedScheduleType")
                .Will(Return.Value(ScheduleType.Weekly));
            Expect.Once.On(viewMock).GetProperty("DaysToInclude")
                .Will(Return.Value(new List<DayOfWeek>()));
            Expect.Once.On(viewMock).GetProperty("WeeklyFrequency").Will(Return.Value(1));

            Expect.Once.On(viewMock).Method("ShowWeeklyAtLeastOneDayOfWeekRequiredError");

            // Execute:
            Assert.IsTrue(presenter.ValidateViewHasError());

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldValidateAtLeastOneMonthPickedIfRecurringMonthlyDayOfMonth()
        {
            // If a recurring monthly schedule is picked, at least one of the months should be selected:
            Expect.Once.On(viewMock).GetProperty("SelectedScheduleType")
                .Will(Return.Value(ScheduleType.MonthlyDayOfMonth));
            Expect.Once.On(viewMock).GetProperty("MonthsToInclude")
                .Will(Return.Value(new List<Month>()));

            Expect.Once.On(viewMock).Method("ShowMonthlyAtLeastOneMonthRequiredError");

            // Execute:
            Assert.IsTrue(presenter.ValidateViewHasError());

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldValidateAtLeastOneMonthPickedIfRecurringMonthlyDayOfWeek()
        {
            // If a recurring monthly schedule is picked, at least one of the months should be selected:
            Expect.Once.On(viewMock).GetProperty("SelectedScheduleType")
                .Will(Return.Value(ScheduleType.MonthlyDayOfWeek));
            Expect.Once.On(viewMock).GetProperty("MonthsToInclude")
                .Will(Return.Value(new List<Month>()));

            Expect.Once.On(viewMock).Method("ShowMonthlyAtLeastOneMonthRequiredError");

            // Execute:
            Assert.IsTrue(presenter.ValidateViewHasError());

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldValidateIfContinuousWithStartBeforeEnd()
        {
            Clock.Now = new DateTime(2006, 05, 05, 3, 55, 0);
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);

            Expect.AtLeastOnce.On(viewMock).GetProperty("SelectedScheduleType")
                .Will(Return.Value(ScheduleType.Continuous));
            Expect.Once.On(viewMock).GetProperty("StartDate").Will(Return.Value(new Date(2006, 05, 05)));
            Expect.Once.On(viewMock).GetProperty("EndDate").Will(Return.Value(new Date(2006, 05, 05)));
            Expect.Once.On(viewMock).GetProperty("StartTime").Will(Return.Value(new Time(5, 0, 0)));
            Expect.Once.On(viewMock).GetProperty("EndTime").Will(Return.Value(new Time(6, 0, 0)));
            Expect.Never.On(viewMock).Method("ShowScheduleWillNotFireError");
            
            Assert.IsFalse(presenter.ValidateViewHasError());
        }
        
        [Test]
        public void ShouldNotValidateIfContinuousWithStartAfterEnd()
        {
            Clock.Now = new DateTime(2206, 05, 05, 4, 55, 0);
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
            
            Expect.AtLeastOnce.On(viewMock).GetProperty("SelectedScheduleType")
                .Will(Return.Value(ScheduleType.Continuous));
            Expect.Once.On(viewMock).GetProperty("StartDate").Will(Return.Value(new Date(2006, 05, 05)));
            Expect.Once.On(viewMock).GetProperty("EndDate").Will(Return.Value(new Date(2006, 05, 05)));
            Expect.Once.On(viewMock).GetProperty("StartTime").Will(Return.Value(new Time(5, 0, 0)));
            Expect.Once.On(viewMock).GetProperty("EndTime").Will(Return.Value(new Time(2, 0, 0)));

            Expect.Once.On(viewMock).Method("ShowScheduleWillNotFireError");
            
            Assert.IsTrue(presenter.ValidateViewHasError());
        }

        private void SetOnLoadExpectations(Date startDate, Time startTime, Time endTime)
        {
            Expect.Once.On(viewMock).SetProperty("StartDate").To(startDate);
            Expect.Once.On(viewMock).SetProperty("StartTime").To(startTime);
            Expect.Once.On(viewMock).SetProperty("EndTime").To(endTime);

            SetOnLoadCommonExpectations();
        }

        private void SetOnLoadCommonExpectations()
        {
            // Expect a good, non-zero frequency for a repeating schedule:
            Expect.Once.On(viewMock).SetProperty("Frequency").To(1);
            Expect.Once.On(viewMock).SetProperty("WeeklyFrequency").To(1);
        }
    }
}