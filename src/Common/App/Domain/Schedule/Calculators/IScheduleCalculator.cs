using System;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public interface IScheduleCalculator
    {
        DateTime GetNextInvokeDateTime();
    }
}