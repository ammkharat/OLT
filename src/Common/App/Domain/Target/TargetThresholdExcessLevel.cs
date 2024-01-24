using System;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public enum TargetThresholdExcessLevel
    {
        // Threshold not exceeded:
        None,
        // Operating thresholds exceeded:
        StandardMin,
        StandardMax,
        // Design thresholds exceeded:
        NeverToExceedMin,
        NeverToExceedMax
    }
}