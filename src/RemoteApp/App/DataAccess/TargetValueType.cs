using System;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    /// <summary>
    /// This is a helper object for DAO's to translate between target value types and their
    /// values in the database.
    /// </summary>
    public static class TargetValueType
    {
        public const long SPECIFIED = 0;
        public const long MINIMIZE = 1;
        public const long MAXIMIZE = 2;

        public static TargetValue ToTargetValue(long targetValueTypeId, decimal? targetValue)
        {
            switch (targetValueTypeId)
            {
                case SPECIFIED:
                    return targetValue.HasValue ? TargetValue.CreateSpecifiedTarget(targetValue.Value) : TargetValue.CreateEmptyTarget();
                case MINIMIZE:
                    return TargetValue.CreateMinimizeTarget();
                case MAXIMIZE:
                    return TargetValue.CreateMaximizeTarget();
                default:
                    throw new NotSupportedException("Unsupported target value type id:<" + targetValueTypeId + ">");
            }
        }
    }
}
