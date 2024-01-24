using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN75BDropDownValueKeys
    {
        public const string IsolationTypes = "gn75b_isolation_types";
        public const string EquipmentTypes = "gn75b_equipment_types";
        public const string DevicePosition = "gn75b_device_position";    //ayman Sarnia eip DMND0008992

        public static List<string> EquipmentTypesDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(EquipmentTypes, dropdownValues);
        }

        public static List<string> IsolationTypesDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(IsolationTypes, dropdownValues);
        }

        //ayman Sarnia eip DMND0008992
        public static List<string> DevicePositionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(DevicePosition, dropdownValues);
        }
    }
}