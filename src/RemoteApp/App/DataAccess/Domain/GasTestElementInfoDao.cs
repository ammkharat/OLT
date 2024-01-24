using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class GasTestElementInfoDao : AbstractManagedDao, IGasTestElementInfoDao
    {
        private const string QUERY_GAS_TEST_ELEMENT_INFO_BY_ID = "QueryGasTestElementInfoById";
        private const string INSERT_GAS_TEST_ELEMENT_INFO = "InsertGasTestElementInfo";
        private const string REMOVE_GAS_TEST_ELEMENT_INFO = "RemoveGasTestElementInfo";

        private const string QUERY_STANDARD_GAS_TEST_ELEMENT_INFOS_BY_SITE_ID = "QueryStandardGasTestElementInfosBySiteId";

        private const string UPDATE_STORED_PROCEDUERE = "UpdateGasTestElementInfo";

        private readonly ISiteDao siteDao;

        public GasTestElementInfoDao()
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        #region IGasTestElementInfoDao Members

        public GasTestElementInfo QueryById(long id)
        {
            return ManagedCommand.QueryById<GasTestElementInfo>(id, PopulateInstance, QUERY_GAS_TEST_ELEMENT_INFO_BY_ID);
        }

        public GasTestElementInfo Insert(GasTestElementInfo gasTestElementInfo)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(gasTestElementInfo, AddInsertParameters, INSERT_GAS_TEST_ELEMENT_INFO);
            gasTestElementInfo.Id = long.Parse(idParameter.Value.ToString());
            return gasTestElementInfo;
        }

        public List<GasTestElementInfo> QueryStandardInfosBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult<GasTestElementInfo>(PopulateInstance, QUERY_STANDARD_GAS_TEST_ELEMENT_INFOS_BY_SITE_ID);
        }

        public void Update(GasTestElementInfo infoToBeUpdated)
        {
            ManagedCommand.Update(infoToBeUpdated, AddUpdateParameters, UPDATE_STORED_PROCEDUERE);
        }

        public void Remove(GasTestElementInfo elementInfo)
        {
            if (elementInfo.IsInDatabase())
            {
                ManagedCommand.Remove(elementInfo.IdValue, REMOVE_GAS_TEST_ELEMENT_INFO);
            }
        }

        #endregion

        private GasTestElementInfo PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            bool isStandard = reader.Get<bool>("Standard");

            long siteId = reader.Get<long>("SiteId");
            Site site = siteDao.QueryById(siteId);

            int displayOrder = reader.Get<int?>("DisplayOrder").GetValueOrDefault(-1);
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
            GasLimitRange inertCSELimit = new GasLimitRange(inertCSEMin, inertCSEMax);

            string otherLimits = reader.Get<string>("OtherLimits").NullToEmpty();

            bool isRangedLimit = reader.Get<bool>("RangedLimit");
            int decimalPlaceCount = reader.Get<int>("DecimalPlaceCount");

            GasTestElementInfo result = new GasTestElementInfo
                                                    (
                                                        id,
                                                        name,
                                                        site,
                                                        isStandard,
                                                        displayOrder,
                                                        coldLimit,
                                                        hotLimit,
                                                        cseLimit,
                                                        inertCSELimit,
                                                        otherLimits,
                                                        unit,
                                                        isRangedLimit,
                                                        decimalPlaceCount
                                                    );
            return result;
        }

        private static void AddInsertParameters(GasTestElementInfo gasElementInfo, SqlCommand command)
        {
            SetCommonAttributes(gasElementInfo, command);
        }

        private static void AddUpdateParameters(GasTestElementInfo info, SqlCommand command)
        {
            command.AddParameter("@Id", info.Id);
            command.AddParameter("@Standard", info.IsStandard);
            command.AddParameter("@DisplayOrder", info.DisplayOrder);
            SetCommonAttributes(info, command);
        }

        private static void SetCommonAttributes(GasTestElementInfo gasTestElementInfo, SqlCommand command)
        {
            command.AddParameter("@Name", gasTestElementInfo.Name);
            command.AddParameter("@SiteId", gasTestElementInfo.Site.IdValue);

            if ( gasTestElementInfo.ColdLimit.Max.HasValue )
                command.AddParameter("@ColdMaxValue", gasTestElementInfo.ColdLimit.Max);

            if ( gasTestElementInfo.ColdLimit.Min.HasValue )
                command.AddParameter("@ColdMinValue", gasTestElementInfo.ColdLimit.Min);

            if ( gasTestElementInfo.HotLimit.Max.HasValue)
                command.AddParameter("@HotMaxValue", gasTestElementInfo.HotLimit.Max.Value);

            if ( gasTestElementInfo.HotLimit.Min.HasValue)
                command.AddParameter("@HotMinValue", gasTestElementInfo.HotLimit.Min.Value);

            if ( gasTestElementInfo.CSELimit.Max.HasValue )
                command.AddParameter("@CSEMaxValue", gasTestElementInfo.CSELimit.Max.Value);

            if ( gasTestElementInfo.CSELimit.Min.HasValue )
                command.AddParameter("@CSEMinValue", gasTestElementInfo.CSELimit.Min.Value);

            if (gasTestElementInfo.InertCSELimit.Max.HasValue)
                command.AddParameter("@InertCSEMaxValue", gasTestElementInfo.InertCSELimit.Max.Value);

            if (gasTestElementInfo.InertCSELimit.Min.HasValue)
                command.AddParameter("@InertCSEMinValue", gasTestElementInfo.InertCSELimit.Min.Value);

            command.AddParameter("@OtherLimits", gasTestElementInfo.OtherLimits);

            if ( gasTestElementInfo.Unit.Equals(GasLimitUnit.UNKNOWN) == false )
                command.AddParameter("@GasLimitUnitId", gasTestElementInfo.Unit.IdValue);

            command.AddParameter("@RangedLimit", gasTestElementInfo.IsRangedLimit);
            command.AddParameter("@DecimalPlaceCount", gasTestElementInfo.DecimalPlaceCount);
        }
    }
}