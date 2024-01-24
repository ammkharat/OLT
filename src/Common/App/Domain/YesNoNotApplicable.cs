using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class YesNoNotApplicable : SimpleDomainObject
    {
        public static readonly YesNoNotApplicable NOT_APPLICABLE = new YesNoNotApplicable(0, null, "N/A");
        public static readonly YesNoNotApplicable YES = new YesNoNotApplicable(1, true, "Yes");
        public static readonly YesNoNotApplicable NO = new YesNoNotApplicable(2, false, "No");

        private static readonly List<YesNoNotApplicable> ALL = new List<YesNoNotApplicable> {NOT_APPLICABLE, YES, NO};

        // blank is only used as a display value; it is not persisted
        public static readonly YesNoNotApplicable BLANK = new YesNoNotApplicable(3, null, "");
        private readonly string name;
        private readonly bool? value;

        private YesNoNotApplicable(int id, bool? value, string name) : base(id)
        {
            this.value = value;
            this.name = name;
        }

        public bool? BoolValue
        {
            get { return value; }
        }

        public override string GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return name;
        }

        public static string ToString(YesNoNotApplicable yesNoNotApplicable)
        {
            if (yesNoNotApplicable == null)
            {
                return FindForValue(null).ToString();
            }
            return yesNoNotApplicable.ToString();
        }

        public static YesNoNotApplicable FindForValue(bool? value)
        {
            return ALL.Find(obj => obj.BoolValue == value);
        }
    }
}