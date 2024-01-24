using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class GasTestElementInfoDTODao : AbstractManagedDao, IGasTestElementInfoDTODao 
    {
        private const string QUERY_STANDARD_DTO_INFOS_BY_SITE_ID = "QueryStandardGasTestElementInfoDTOsBySiteId";
        private const string UPDATE_STORED_PROCEDURE = "UpdateGasTestElementInfoDTO";

        public List<GasTestElementInfoDTO> QueryStandardInfoDTOsBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult<GasTestElementInfoDTO>(PopulateInstance , QUERY_STANDARD_DTO_INFOS_BY_SITE_ID);
        }

        public void Update(GasTestElementInfoDTO dtoToBeUpdated)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", dtoToBeUpdated.Id);
            command.Update(dtoToBeUpdated, GasTestElementInfoConfigurationFieldMapper.AddUpdateInsertParameters, UPDATE_STORED_PROCEDURE);
        }

        private GasTestElementInfoDTO PopulateInstance(SqlDataReader reader)
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
            GasLimitRange inertCSELimit = new GasLimitRange(inertCSEMin, inertCSEMax);

            bool isRangedLimit = reader.Get<bool>("RangedLimit");

            int decimalPlaceCount = reader.Get<int>("DecimalPlaceCount");
            var result = new GasTestElementInfoDTO
                                                    (
                                                        id,
                                                        name,
                                                        unit.UnitName,
                                                        coldLimit.ToLimitString(isRangedLimit, decimalPlaceCount),
                                                        hotLimit.ToLimitString(isRangedLimit, decimalPlaceCount),
                                                        cseLimit.ToLimitString(isRangedLimit, decimalPlaceCount),
                                                        inertCSELimit.ToLimitString(isRangedLimit, decimalPlaceCount),
                                                        isRangedLimit,
                                                        decimalPlaceCount
                                                    );
            return result;
        }
    }
}
