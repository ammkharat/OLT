using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Common.Domain
{
    public class FormDropdown : SimpleDomainObject
    {
        public static readonly FormDropdown PRIMARY_LOCATION_LIST = new FormDropdown(0, Site.EDMONTON_ID,
            OvertimePrimaryLocationDropDownValueKeys.OvertimePrimaryLocations,
            "On Premise Personnel - Primary Location list");

        public static readonly FormDropdown CRITICALITY_LIST = new FormDropdown(1, Site.LUBES_ID,
            LubesAlarmDisableDropDownValueKeys.Criticality,
            "Temporary Alarm Disable - Criticality List");

        private readonly string key;
        private readonly string name;
        private readonly long siteId;

        private FormDropdown(long id, long siteId, string key, string name) : base(id)
        {
            this.key = key;
            this.name = name;
            this.siteId = siteId;
        }

        public string Key
        {
            get { return key; }
        }

        public long SiteId
        {
            get { return siteId; }
        }

        public override string GetName()
        {
            return name;
        }

        private static List<FormDropdown> AllDropdowns()
        {
            return new List<FormDropdown>
            {
                PRIMARY_LOCATION_LIST,
                CRITICALITY_LIST
            };
        }

        public static List<FormDropdown> AllDropdowns(long siteId)
        {
            return AllDropdowns().FindAll(dropdown => dropdown.siteId == siteId);
        }

        public static FormDropdown FindByKey(string key)
        {
            return AllDropdowns().Find(dropdown => dropdown.Key == key);
        }

        public static string GetNameAlreadyExistsErrorMessage(string key)
        {
            var alreadyExistsMessage = "A value with that name already exists.";

            if (key == LubesAlarmDisableDropDownValueKeys.Criticality)
            {
                alreadyExistsMessage = LubesAlarmDisableDropDownValueKeys.ValueAlreadyExistsErrorMessage;
            }
            else if (key == OvertimePrimaryLocationDropDownValueKeys.OvertimePrimaryLocations)
            {
                alreadyExistsMessage = OvertimePrimaryLocationDropDownValueKeys.ValueAlreadyExistsErrorMessage;
            }

            return alreadyExistsMessage;
        }
    }
}