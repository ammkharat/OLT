using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Just like a regular string, this class in Immutable.
    /// </summary>
    [Serializable]
    public class TernaryString
    {
        private readonly TernaryState state;
        private readonly string value;

        public TernaryString(bool @checked, string value)
        {
            if (@checked == false)
            {
                state = TernaryState.NoValueApplicable;
            }
            else if (string.IsNullOrEmpty(value))
            {
                state = TernaryState.HasNoValue;
            }
            else
            {
                state = TernaryState.HasValue;
                this.value = value;
            }
        }

        public bool CheckedWithNoValue
        {
            get { return StateAsBool && Text.IsNullOrEmptyOrWhitespace(); }
        }

        public bool StateAsBool
        {
            get { return state != TernaryState.NoValueApplicable; }
        }

        [IgnoreComparing]
        public bool HasValue
        {
            get { return TernaryState.HasValue == state; }
        }

        public string Text
        {
            get { return TernaryState.HasValue == state ? value : null; }
        }

        public override bool Equals(object obj)
        {
            return this.ReflectionEquals(obj);
        }

        public override int GetHashCode()
        {
            return this.ReflectionGetHashCode();
        }

        public override string ToString()
        {
            if (!StateAsBool)
                return StringResources.TernaryString_UnChecked;

            return string.IsNullOrEmpty(Text)
                ? StringResources.TernaryString_Checked_With_No_Value
                : string.Format(StringResources.TernaryString_Checked_With_Value, value);
        }

        private enum TernaryState
        {
            NoValueApplicable, // un-checked and therefore no text
            HasValue, // checked and has text
            HasNoValue
        }
    }
}