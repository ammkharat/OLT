using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class GasTestElementInfoConfigurationFieldMapper
    {
        public static void AddUpdateInsertParameters(GasTestElementInfoDTO gasTestElementInfoConfiguration, SqlCommand command)
        {

            GasLimitRange coldLimit = GasLimitRange.FromString(gasTestElementInfoConfiguration.ColdLimit);
            if (coldLimit != null)
            {
                command.Parameters.AddWithValue("@ColdMinValue", coldLimit.Min);
                command.Parameters.AddWithValue("@ColdMaxValue", coldLimit.Max);
            }

            GasLimitRange hotLimit = GasLimitRange.FromString(gasTestElementInfoConfiguration.HotLimit);
            if (hotLimit != null)
            {
                command.Parameters.AddWithValue("@HotMinValue", hotLimit.Min);
                command.Parameters.AddWithValue("@HotMaxValue", hotLimit.Max);
            }

            GasLimitRange cseLimit = GasLimitRange.FromString(gasTestElementInfoConfiguration.CSELimit);
            if (cseLimit != null)
            {
                command.Parameters.AddWithValue("@CSEMinValue", cseLimit.Min);
                command.Parameters.AddWithValue("@CSEMaxValue", cseLimit.Max);
            }

            GasLimitRange inertCSELimit = GasLimitRange.FromString(gasTestElementInfoConfiguration.InertCSELimit);
            if (cseLimit != null)
            {
                command.Parameters.AddWithValue("@InertCSEMinValue", inertCSELimit.Min);
                command.Parameters.AddWithValue("@InertCSEMaxValue", inertCSELimit.Max);
            }

            GasLimitUnit unit = GasLimitUnit.QueryByName(gasTestElementInfoConfiguration.UnitName);
            command.Parameters.AddWithValue("@GasLimitUnitId", unit.Id);
        }
    }
}