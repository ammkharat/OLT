using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ScheduleDao : AbstractManagedDao, IScheduleDao
    {
        private const string UPDATE_STORED_PROCEDURE = "UpdateSchedule";
        private const string INSERT_STORED_PROCEDURE = "InsertSchedule";
        private const string DELETE_STORED_PROCEDURE = "RemoveSchedule";
        
        private static readonly Dictionary<int, string> scheduleDaysColumnMapping = new Dictionary<int, string>(7)
        {
            {7, "Sunday"},
            {1, "Monday"},
            {2, "Tuesday"},
            {3, "Wednesday"},
            {4, "Thursday"},
            {5, "Friday"},
            {6, "Saturday"}
        };

        private static readonly Dictionary<int, string> scheduleMonthsColumnMapping = new Dictionary<int, string>(12)
        {
            {1, "January"},
            {2, "February"},
            {3, "March"},
            {4, "April"},
            {5, "May"},
            {6, "June"},
            {7, "July"},
            {8, "August"},
            {9, "September"},
            {10, "October"},
            {11, "November"},
            {12, "December"}
        };

        public ISchedule QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "QueryScheduleById";
            command.AddParameter("@Id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    ISchedule schedule = PopulateScheduleInstanceForDTO(reader, false);
                    return schedule;
                }
                return null;
            }
        }

        public void Insert(ISchedule schedule)
        {
            // TODO: See Update() -steve
            if (schedule is SingleSchedule)
            {
                Insert(schedule as SingleSchedule);
            }
            else if (schedule is ContinuousSchedule)
            {
                Insert(schedule as ContinuousSchedule);
            }
            else if (schedule is RecurringDailySchedule)
            {
                Insert(schedule as RecurringDailySchedule);
            }
            else if (schedule is RecurringWeeklySchedule)
            {
                Insert(schedule as RecurringWeeklySchedule);
            }
            else if (schedule is RecurringMonthlyDayOfMonthSchedule)
            {
                Insert(schedule as RecurringMonthlyDayOfMonthSchedule);
            }
            else if (schedule is RecurringMonthlyDayOfWeekSchedule)
            {
                Insert(schedule as RecurringMonthlyDayOfWeekSchedule);
            }
            else if (schedule is RecurringHourlySchedule)
            {
                Insert(schedule as RecurringHourlySchedule);
            }
            else if (schedule is RoundTheClockSchedule)
            {
                Insert(schedule as RoundTheClockSchedule);
            }
            else if (schedule is RecurringMinuteSchedule)
            {
                Insert(schedule as RecurringMinuteSchedule);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #region Specific Schedule Type Insert

        public void Insert(SingleSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            SetCommonScheduleInsertParameters(command, schedule.StartDateTime, schedule.EndDateTime, schedule.LastInvokedDateTime, schedule.Site);
            command.AddParameter("@ScheduleTypeId", ScheduleType.Single.Id);

            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        public void Insert(ContinuousSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            command.AddParameter("@LastInvokedDateTime", schedule.LastInvokedDateTime);
            command.AddParameter("@LastModifiedDateTime", DateTime.Now.GetNetworkPortable());
            command.AddParameter("@StartDateTime", schedule.StartDateTime);
            command.AddParameter("@SiteId", schedule.Site.Id);
            if (schedule.HasEndDate)
            {
                command.AddParameter("@EndDateTime", schedule.EndDateTime);
            }
            command.AddParameter("@ScheduleTypeId", ScheduleType.Continuous.Id);

            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        public void Insert(RecurringDailySchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            SetCommonScheduleInsertParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime, schedule.Site);
            command.AddParameter("@ScheduleTypeId", ScheduleType.Daily.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@DailyFrequency", schedule.Frequency);
            command.AddParameter("@EveryShift", schedule.EveryShift);// RITM0265710 - mangesh   commented by Ayman to fix code overlap
            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        public void Insert(RecurringHourlySchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            SetCommonScheduleInsertParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime, schedule.Site);
            command.AddParameter("@ScheduleTypeId", ScheduleType.Hourly.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@DailyFrequency", schedule.Frequency);

            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        public void Insert(RecurringMinuteSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            SetCommonScheduleInsertParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime, schedule.Site);
            command.AddParameter("@ScheduleTypeId", ScheduleType.ByMinute.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@DailyFrequency", schedule.Frequency);

            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        public void Insert(RoundTheClockSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            SetCommonScheduleInsertParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime, schedule.Site);
            command.AddParameter("@ScheduleTypeId", ScheduleType.RoundTheClock.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@DailyFrequency", schedule.Frequency);

            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        public void Insert(RecurringWeeklySchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            SetCommonScheduleInsertParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime, schedule.Site);
            command.AddParameter("@ScheduleTypeId", ScheduleType.Weekly.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@WeeklyFrequency", schedule.Frequency);
            command.AddParameter("@Sunday", schedule.Contains(DayOfWeek.Sunday));
            command.AddParameter("@Monday", schedule.Contains(DayOfWeek.Monday));
            command.AddParameter("@Tuesday", schedule.Contains(DayOfWeek.Tuesday));
            command.AddParameter("@Wednesday", schedule.Contains(DayOfWeek.Wednesday));
            command.AddParameter("@Thursday", schedule.Contains(DayOfWeek.Thursday));
            command.AddParameter("@Friday", schedule.Contains(DayOfWeek.Friday));
            command.AddParameter("@Saturday", schedule.Contains(DayOfWeek.Saturday));

            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        public void Insert(RecurringMonthlyDayOfWeekSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            SetCommonScheduleInsertParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime, schedule.Site);
            SetCommonMonthlyParameters(command, schedule);
            command.AddParameter("@ScheduleTypeId", ScheduleType.MonthlyDayOfWeek.Id);
            command.AddParameter("@WeekOfMonth", schedule.WeekOfMonth.Value);
            command.AddParameter("@DayOfWeek", schedule.DayOfWeek.Value);

            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        public void Insert(RecurringMonthlyDayOfMonthSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            SetCommonScheduleInsertParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime, schedule.Site);
            SetCommonMonthlyParameters(command, schedule);
            command.AddParameter("@ScheduleTypeId", ScheduleType.MonthlyDayOfMonth.Id);
            command.AddParameter("@DayOfMonth", schedule.DayOfMonth.Value);

            command.ExecuteNonQuery(INSERT_STORED_PROCEDURE);
            SetIdForScheduleOrThrowException(schedule, idParameter);
        }

        private static void SetIdForScheduleOrThrowException(ISchedule schedule, IDataParameter idParameter)
        {
            if (idParameter.Value != null)
                schedule.Id = long.Parse(idParameter.Value.ToString());
            else
                throw new DataException("Unable to get id for schedule");
        }

        #endregion

        public void Delete(ISchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);
            command.ExecuteNonQuery(DELETE_STORED_PROCEDURE);
        }

        public void Update(ISchedule schedule)
        {
            // TODO: This whole method is total barf. OLT v.3 folks, please use your polymorphic fairy dust. 
            //       Kisses, Steve.
            if (schedule is SingleSchedule)
            {
                Update(schedule as SingleSchedule);
            }
            else if (schedule is ContinuousSchedule)
            {
                Update(schedule as ContinuousSchedule);
            }
            else if (schedule is RecurringDailySchedule)
            {
                Update(schedule as RecurringDailySchedule);
            }
            else if (schedule is RecurringWeeklySchedule)
            {
                Update(schedule as RecurringWeeklySchedule);
            }
            else if (schedule is RecurringMonthlyDayOfMonthSchedule)
            {
                Update(schedule as RecurringMonthlyDayOfMonthSchedule);
            }
            else if (schedule is RecurringMonthlyDayOfWeekSchedule)
            {
                Update(schedule as RecurringMonthlyDayOfWeekSchedule);
            }
            else if (schedule is RecurringHourlySchedule)
            {
                Update(schedule as RecurringHourlySchedule);
            }
            else if (schedule is RoundTheClockSchedule)
            {
                Update(schedule as RoundTheClockSchedule);
            }
            else if (schedule is RecurringMinuteSchedule)
            {
                Update(schedule as RecurringMinuteSchedule);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #region Specific Schedule Type Updates

        private void Update(SingleSchedule schedule)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@Id", schedule.Id);
            SetCommonScheduleUpdateParameters(command, schedule.StartDateTime, schedule.EndDateTime, schedule.LastInvokedDateTime);
            command.AddParameter("@ScheduleTypeId", ScheduleType.Single.Id);

            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        private void Update(ContinuousSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);

            command.AddParameter("@LastInvokedDateTime", schedule.LastInvokedDateTime);
            command.AddParameter("@LastModifiedDateTime", DateTime.Now.GetNetworkPortable());
            command.AddParameter("@StartDateTime", schedule.StartDateTime);
            if (schedule.HasEndDate)
            {
                command.AddParameter("@EndDateTime", schedule.EndDateTime);
            }
            command.AddParameter("@ScheduleTypeId", ScheduleType.Continuous.Id);

            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        private void Update(RecurringDailySchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);

            SetCommonScheduleUpdateParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime);
            command.AddParameter("@ScheduleTypeId", ScheduleType.Daily.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@DailyFrequency", schedule.Frequency);
            command.AddParameter("@EveryShift", schedule.EveryShift);// RITM0265710 - mangesh  commented by ayman to fix code overlap
            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        private void Update(RecurringHourlySchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);

            SetCommonScheduleUpdateParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime);
            command.AddParameter("@ScheduleTypeId", ScheduleType.Hourly.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@DailyFrequency", schedule.Frequency);

            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        private void Update(RecurringMinuteSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);

            SetCommonScheduleUpdateParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime);
            command.AddParameter("@ScheduleTypeId", ScheduleType.ByMinute.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@DailyFrequency", schedule.Frequency);

            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        private void Update(RoundTheClockSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);

            SetCommonScheduleUpdateParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime);
            command.AddParameter("@ScheduleTypeId", ScheduleType.RoundTheClock.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@DailyFrequency", schedule.Frequency);

            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        private void Update(RecurringWeeklySchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);

            SetCommonScheduleUpdateParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime);
            command.AddParameter("@ScheduleTypeId", ScheduleType.Weekly.Id);
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@WeeklyFrequency", schedule.Frequency);
            command.AddParameter("@Sunday", schedule.Contains(DayOfWeek.Sunday));
            command.AddParameter("@Monday", schedule.Contains(DayOfWeek.Monday));
            command.AddParameter("@Tuesday", schedule.Contains(DayOfWeek.Tuesday));
            command.AddParameter("@Wednesday", schedule.Contains(DayOfWeek.Wednesday));
            command.AddParameter("@Thursday", schedule.Contains(DayOfWeek.Thursday));
            command.AddParameter("@Friday", schedule.Contains(DayOfWeek.Friday));
            command.AddParameter("@Saturday", schedule.Contains(DayOfWeek.Saturday));

            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        private void Update(RecurringMonthlyDayOfWeekSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);

            SetCommonScheduleUpdateParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime);
            SetCommonMonthlyParameters(command, schedule);
            command.AddParameter("@ScheduleTypeId", ScheduleType.MonthlyDayOfWeek.Id);
            command.AddParameter("@WeekOfMonth", schedule.WeekOfMonth.Value);
            command.AddParameter("@DayOfWeek", schedule.DayOfWeek.Value);

            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        private void Update(RecurringMonthlyDayOfMonthSchedule schedule)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", schedule.Id);

            SetCommonScheduleUpdateParameters(command, Date.ToDateTimeOrMaxValue(schedule.StartDate), Date.ToDateTimeOrNull(schedule.EndDate), schedule.LastInvokedDateTime);
            SetCommonMonthlyParameters(command, schedule);
            command.AddParameter("@ScheduleTypeId", ScheduleType.MonthlyDayOfMonth.Id);
            command.AddParameter("@DayOfMonth", schedule.DayOfMonth.Value);

            command.ExecuteNonQuery(UPDATE_STORED_PROCEDURE);
        }

        #endregion

        private static void SetCommonScheduleInsertParameters(SqlCommand command, DateTime startDateTime, DateTime? endDateTime, DateTime? lastInvokedDateTime, Site site)
        {
            command.AddParameter("@SiteId", site.Id);
            SetCommonScheduleUpdateParameters(command, startDateTime, endDateTime, lastInvokedDateTime);
        }

        private static void SetCommonScheduleUpdateParameters(SqlCommand command, DateTime startDateTime, DateTime? endDateTime, DateTime? lastInvokedDateTime)
        {
            command.AddParameter("@LastModifiedDateTime", DateTime.Now.GetNetworkPortable());
            command.AddParameter("@StartDateTime", startDateTime);
            command.AddParameter("@EndDateTime", endDateTime);
            command.AddParameter("@LastInvokedDateTime", lastInvokedDateTime);
        }

        private void SetCommonMonthlyParameters(SqlCommand command, RecurringMonthlySchedule schedule)
        {
            command.AddParameter("@FromTime", schedule.StartTime.ToDateTime());
            command.AddParameter("@ToTime", schedule.EndTime.ToDateTime());
            command.AddParameter("@January", schedule.ContainsMonth(Month.January));
            command.AddParameter("@February", schedule.ContainsMonth(Month.February));
            command.AddParameter("@March", schedule.ContainsMonth(Month.March));
            command.AddParameter("@April", schedule.ContainsMonth(Month.April));
            command.AddParameter("@May", schedule.ContainsMonth(Month.May));
            command.AddParameter("@June", schedule.ContainsMonth(Month.June));
            command.AddParameter("@July", schedule.ContainsMonth(Month.July));
            command.AddParameter("@August", schedule.ContainsMonth(Month.August));
            command.AddParameter("@September", schedule.ContainsMonth(Month.September));
            command.AddParameter("@October", schedule.ContainsMonth(Month.October));
            command.AddParameter("@November", schedule.ContainsMonth(Month.November));
            command.AddParameter("@December", schedule.ContainsMonth(Month.December));
        }

        /// <summary>
        /// Populates an ISchedule, without any other database hits because of object graphs/relationships.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ISchedule PopulateScheduleInstanceForDTO(SqlDataReader reader)
        {
            return PopulateScheduleInstanceForDTO(reader, true);
        }

        // TODO: (Troy/Joe) Get rid of the isShallowDataRetrieval, and build a ScheduleDTO instead.
        private static ISchedule PopulateScheduleInstanceForDTO(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            ISchedule result = null;
            int type = reader.Get<int>("ScheduleTypeId");
           
            if (type == ScheduleType.Single.Id)
            {
                result = PopulateSingleSchedule(reader, isShallowDataRetrieval);
            }
            else if (type == ScheduleType.Continuous.Id)
            {
                result = PopulateContinuousSchedule(reader, isShallowDataRetrieval);
            }
            else if (type == ScheduleType.Daily.Id)
            {
                result = PopulateRecurringDailySchedule(reader, isShallowDataRetrieval);
            }
            else if (type == ScheduleType.Weekly.Id)
            {
                result = PopulateRecurringWeeklySchedule(reader, isShallowDataRetrieval);
            }
            else if (type == ScheduleType.MonthlyDayOfMonth.Id)
            {
                result = PopulateRecurringMonthlyDayOfMonthSchedule(reader, isShallowDataRetrieval);
            }
            else if (type == ScheduleType.MonthlyDayOfWeek.Id)
            {
                result = PopulateRecurringMonthlyDayOfWeekSchedule(reader, isShallowDataRetrieval);
            }
            else if (type == ScheduleType.Hourly.Id)
            {
                result = PopulateRecurringHourlySchedule(reader, isShallowDataRetrieval);
            }
            else if (type == ScheduleType.RoundTheClock.Id)
            {
                result = PopulateRoundTheClockSchedule(reader, isShallowDataRetrieval);
            }
            else if (type == ScheduleType.ByMinute.Id)
            {
                result = PopulateRecurringMinuteSchedule(reader, isShallowDataRetrieval);
            }
            bool deleted = reader.Get<bool>("Deleted");
            result.Deleted = deleted;

            return result;
        }

        // TODO: (Troy) There is a lot of repeated stuff on each method. Has to be a better way. Use an object builder or something?
        private static ISchedule PopulateSingleSchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime = reader.Get<DateTime>("EndDateTime");
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");

            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));    
            }
            
            return new SingleSchedule(id, new Date(startDateTime), new Time(startDateTime), new Time(endDateTime), lastInvokedDateTime, site);
        }


        private static ISchedule PopulateContinuousSchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");

            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));
            }

            return new ContinuousSchedule(id, new Date(startDateTime), endDateTime.ToDate(), new Time(startDateTime), endDateTime.ToTime(), lastInvokedDateTime, site);
        }

        private static ISchedule PopulateRecurringDailySchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");
            Time fromTime = (reader.Get<DateTime?>("FromTime")).ToTime();
            Time toTime = (reader.Get<DateTime?>("ToTime")).ToTime();
            int dailyFrequency = reader.Get<int>("DailyFrequency");
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");
            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));
            }

            bool everyShift = false;
            everyShift = reader.Get<bool>("EveryShift");//RITM0265710 - mangesh   commented by ayman to fix code overlap

            List<ShiftPattern> shifts = DaoRegistry.GetDao<IShiftPatternDao>().QueryBySiteId(reader.Get<long>("SiteId"));
            return new RecurringDailySchedule(id, startDateTime.ToDate(), endDateTime.ToDate(), fromTime, toTime, dailyFrequency, lastInvokedDateTime, site, everyShift, shifts);

            //return new RecurringDailySchedule(id, startDateTime.ToDate(), endDateTime.ToDate(), fromTime, toTime, dailyFrequency, lastInvokedDateTime, site);
        }

        private static ISchedule PopulateRecurringHourlySchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");
            Time fromTime = (reader.Get<DateTime?>("FromTime")).ToTime();
            Time toTime = (reader.Get<DateTime?>("ToTime")).ToTime();
            int frequency = reader.Get<int>("DailyFrequency");
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");
            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));
            }

            return new RecurringHourlySchedule(id, startDateTime.ToDate(), endDateTime.ToDate(), fromTime, toTime, frequency, lastInvokedDateTime, site);
        }

        private static ISchedule PopulateRecurringMinuteSchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");
            Time fromTime = (reader.Get<DateTime?>("FromTime")).ToTime();
            Time toTime = (reader.Get<DateTime?>("ToTime")).ToTime();
            int frequency = reader.Get<int>("DailyFrequency");
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");
            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));
            }

            return new RecurringMinuteSchedule(id, startDateTime.ToDate(), endDateTime.ToDate(), fromTime, toTime, frequency, lastInvokedDateTime, site);
        }

        private static ISchedule PopulateRoundTheClockSchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");
            Time fromTime = (reader.Get<DateTime?>("FromTime")).ToTime();
            Time toTime = (reader.Get<DateTime?>("ToTime")).ToTime();
            int frequency = reader.Get<int>("DailyFrequency");
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");
            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));
            }

            return new RoundTheClockSchedule(id, startDateTime.ToDate(), endDateTime.ToDate(), fromTime, toTime, frequency, lastInvokedDateTime, site);
        }

        private static ISchedule PopulateRecurringWeeklySchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");
            Time fromTime = (reader.Get<DateTime?>("FromTime")).ToTime();
            Time toTime = (reader.Get<DateTime?>("ToTime")).ToTime();
            int weeklyFrequency = reader.Get<int>("WeeklyFrequency");
            List<DayOfWeek> daysOfWeek = GetSelectedDaysOfWeek(reader);
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");
            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));
            }

            return
                new RecurringWeeklySchedule(id, startDateTime.ToDate(), endDateTime.ToDate(), fromTime, toTime, daysOfWeek,
                                            weeklyFrequency, lastInvokedDateTime, site);
        }


        private static ISchedule PopulateRecurringMonthlyDayOfMonthSchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");
            Time fromTime = (reader.Get<DateTime?>("FromTime")).ToTime();
            Time toTime = (reader.Get<DateTime?>("ToTime")).ToTime();
            DayOfMonth dayOfMonth = DayOfMonth.Day(reader.Get<int>("DayOfMonth"));
            List<Month> months = GetSelectedMonths(reader);
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");
            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));
            }
            return
                new RecurringMonthlyDayOfMonthSchedule(id, startDateTime.ToDate(), endDateTime.ToDate(), fromTime, toTime,
                                                       dayOfMonth, months, lastInvokedDateTime, site);
        }


        private static ISchedule PopulateRecurringMonthlyDayOfWeekSchedule(SqlDataReader reader, bool isShallowDataRetrieval)
        {
            long id = reader.Get<long>("Id");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");
            Time fromTime = (reader.Get<DateTime?>("FromTime")).ToTime();
            Time toTime = (reader.Get<DateTime?>("ToTime")).ToTime();
            WeekOfMonth weekOfMonth = WeekOfMonth.Week(reader.Get<int>("WeekOfMonth"));
            DayOfWeek dayOfWeek = DayOfWeek.Get(reader.Get<int>("DayOfWeek"));
            List<Month> months = GetSelectedMonths(reader);
            DateTime? lastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime");
            Site site = null;
            if (!isShallowDataRetrieval)
            {
                site = DaoRegistry.GetDao<ISiteDao>().QueryById(reader.Get<long>("SiteId"));
            }

            return
                new RecurringMonthlyDayOfWeekSchedule(id, startDateTime.ToDate(), endDateTime.ToDate(), fromTime, toTime,
                                                      weekOfMonth, dayOfWeek, months, lastInvokedDateTime, site);
        }

        private static List<DayOfWeek> GetSelectedDaysOfWeek(SqlDataReader reader)
        {
            List<DayOfWeek> selectedDaysOfWeek = new List<DayOfWeek>();
            foreach (DayOfWeek dayOfWeek in DayOfWeek.All)
            {
                string columnName = scheduleDaysColumnMapping[dayOfWeek.Value];

                bool dayOfWeekIsSet = reader.Get<bool>(columnName);
                if (dayOfWeekIsSet)
                {
                    selectedDaysOfWeek.Add(dayOfWeek);
                }
            }
            return selectedDaysOfWeek;
        }

        private static List<Month> GetSelectedMonths(SqlDataReader reader)
        {
            List<Month> selectedMonths = new List<Month>();
            foreach (Month month in Month.All)
            {
                string columnName = scheduleMonthsColumnMapping[month.Value];

                bool monthIsSet = reader.Get<bool>(columnName);
                if (monthIsSet)
                {
                    selectedMonths.Add(month);
                }
            }
            return selectedMonths;
        }
    }
}
