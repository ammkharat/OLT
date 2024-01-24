using System;

namespace Com.Suncor.Olt.Common.DTO
{
    public interface IHasStartAndEndDateTimes
    {
        DateTime StartDateTime { get; }
        DateTime EndDateTime { get; }
    }
}