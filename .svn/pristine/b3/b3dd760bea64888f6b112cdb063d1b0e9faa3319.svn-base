using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public interface ISiteSpecificDateTimeHandler
    {
        void InitializeDateTimes(WorkPermitSpecifics specifics, UserWorkPermitDefaultTimePreferences prefs,
            UserShift currentShift, DateTime now);

        void ReinitializeStartAndOrEndDateTimes(WorkPermitSpecifics specifics,
            UserWorkPermitDefaultTimePreferences prefs, UserShift currentShift, DateTime now);

        void Initialize(WorkPermitEquipmentPreparationCondition equipmentCondition);
    }
}