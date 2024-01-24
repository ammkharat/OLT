using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class GasTestElementInfoConfigurationHistoryDao : AbstractManagedDao, IGasTestElementInfoConfigurationHistoryDao
    {
        private const string QUERY_GAS_TEST_ELEMENT_INFO_CONFIGURATION_HISTORY_BY_SITE_ID = "QueryGasTestElementInfoConfigurationHistoryBySiteId";
        private const string INSERT_GAS_TEST_ELEMENT_INFO_CONFIGURATION_HISTORY = "InsertGasTestElementInfoConfigurationHistory";

        private readonly IUserDao userDao;

        public GasTestElementInfoConfigurationHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<GasTestElementInfoConfigurationHistory> QueryAllBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult<GasTestElementInfoConfigurationHistory>(PopulateInstance, QUERY_GAS_TEST_ELEMENT_INFO_CONFIGURATION_HISTORY_BY_SITE_ID);
        }

        public GasTestElementInfoConfigurationHistory Insert(GasTestElementInfoConfigurationHistory gasTestElementInfoConfigurationHistory, long siteId)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@SiteId", siteId);
            command.Insert(gasTestElementInfoConfigurationHistory, AddInsertParameters, INSERT_GAS_TEST_ELEMENT_INFO_CONFIGURATION_HISTORY);
            gasTestElementInfoConfigurationHistory.Id = long.Parse(idParameter.Value.ToString());
            return gasTestElementInfoConfigurationHistory;
        }

        protected static void AddInsertParameters(GasTestElementInfoConfigurationHistory gasElementInfoConfigurationHistory, SqlCommand command)
        {
            SetCommonAttributes(gasElementInfoConfigurationHistory, command);
        }

        private static void SetCommonAttributes(GasTestElementInfoConfigurationHistory gasTestElementInfoConfigurationHistory, SqlCommand command)
        {
            GasTestElementInfoConfigurationFieldMapper.AddUpdateInsertParameters(gasTestElementInfoConfigurationHistory, command);
            
            command.AddParameter("@Name", gasTestElementInfoConfigurationHistory.Name);
            command.AddParameter("@RangedLimit", gasTestElementInfoConfigurationHistory.IsRangedLimit);
            command.AddParameter("@LastModifiedUserId", gasTestElementInfoConfigurationHistory.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", gasTestElementInfoConfigurationHistory.LastModifiedDate);
            command.AddParameter("@DecimalPlaceCount", gasTestElementInfoConfigurationHistory.DecimalPlaceCount);
        }
        
        private GasTestElementInfoConfigurationHistory PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");

            long? unitId = reader.Get<long?>("GasLimitUnitId");
            GasLimitUnit unit = GasLimitUnit.QueryById(unitId);

            double? coldMax = reader.Get<double?>("ColdMaxValue");
            double? coldMin = reader.Get<double?>("ColdMinValue");
            GasLimitRange coldLimit = new GasLimitRange(coldMin, coldMax);

            double? hotMax = reader.Get<double?>("HotMaxValue");
            double? hotMin = reader.Get<double?>("HotMinValue");
            GasLimitRange hotLimit = new GasLimitRange(hotMin, hotMax);

            double? cseMax = reader.Get<double?>("CSEMaxValue");
            double? cseMin = reader.Get<double?>("CSEMinValue");
            GasLimitRange cseLimit = new GasLimitRange(cseMin, cseMax);

            double? inertCSEMax = reader.Get<double?>("InertCSEMaxValue");
            double? inertCSEMin = reader.Get<double?>("InertCSEMinValue");
            var inertCSELimit = new GasLimitRange(inertCSEMin, inertCSEMax);

            bool isRangedLimit = reader.Get<bool>("RangedLimit");

            int decimalPlaceCount = reader.Get<int>("DecimalPlaceCount");
            
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            
            long lastModifiedUserId = reader.Get<long>("LastModifiedUserId");
            User lastModifiedUser = userDao.QueryById(lastModifiedUserId);

            var result = new GasTestElementInfoConfigurationHistory
                                                    (
                                                        id,
                                                        name,
                                                        coldLimit.ToLimitString(isRangedLimit, decimalPlaceCount),
                                                        hotLimit.ToLimitString(isRangedLimit, decimalPlaceCount),
                                                        cseLimit.ToLimitString(isRangedLimit, decimalPlaceCount),
                                                        inertCSELimit.ToLimitString(isRangedLimit, decimalPlaceCount),
                                                        unit.UnitName,
                                                        isRangedLimit,
                                                        decimalPlaceCount,
                                                        lastModifiedDateTime,
                                                        lastModifiedUser
                                                    );
            return result;
        }
    }
}
