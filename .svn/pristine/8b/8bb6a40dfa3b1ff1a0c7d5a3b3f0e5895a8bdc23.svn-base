using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftPatternDao : AbstractManagedDao, IShiftPatternDao
    {
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryAllShifts";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryShiftById";
        private const string QUERY_BY_SITE_ID = "QueryShiftsBySiteId";
        private const string INSERT_SHIFT = "InsertShift";

        private readonly ISiteDao siteDao;

        public ShiftPatternDao()
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        public List<ShiftPattern> QueryAll()
        {
            return ManagedCommand.QueryForListResult<ShiftPattern>(PopulateInstance, QUERY_ALL_STORED_PROCEDURE);
        }

        public ShiftPattern QueryById(long id)
        {
            return ManagedCommand.QueryById<ShiftPattern>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<ShiftPattern> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult<ShiftPattern>(PopulateInstance, QUERY_BY_SITE_ID);
        }

        private ShiftPattern PopulateInstance(SqlDataReader reader)
        {
            Site site = siteDao.QueryById(reader.Get<long>("SiteId"));

            TimeSpan preShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PreShiftPaddingInMinutes"), 0);
            TimeSpan postShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PostShiftPaddingInMinutes"), 0);

            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            Time startTime = new Time(reader.Get<TimeSpan>("StartTime"));
            Time endTime = new Time(reader.Get<TimeSpan>("EndTime"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            ShiftPattern shiftPattern = new ShiftPattern(id,
                                                name,
                                                startTime,
                                                endTime,
                                                createdDateTime,
                                                site,
                                                preShiftPaddingInMinutes,
                                                postShiftPaddingInMinutes);

            return shiftPattern;
        }

        public ShiftPattern Insert(ShiftPattern shift)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(shift, AddInsertParameters, INSERT_SHIFT);
            shift.Id = long.Parse(idParameter.Value.ToString());

            return shift;
        }

        private static void AddInsertParameters(ShiftPattern shift, SqlCommand command)
        {
            command.AddParameter("@name", shift.Name);
            command.AddParameter("@startTime", shift.StartTime.ToDateTime());
            command.AddParameter("@endTime", shift.EndTime.ToDateTime());
            command.AddParameter("@siteId", shift.Site.Id);
            command.AddParameter("@createdDateTime", shift.CreatedDateTime);
        }
    }
}