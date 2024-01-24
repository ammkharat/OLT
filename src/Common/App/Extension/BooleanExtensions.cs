using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class BooleanExtensions
    {
        public static bool HasFalseValue(this bool? aNullableBool)
        {
            return aNullableBool.HasValue && aNullableBool == false;
        }

        public static bool HasTrueValue(this bool? aNullableBool)
        {
            return aNullableBool.HasValue && aNullableBool == true;
        }

        public static bool DoesNotHaveAValue(this bool? aNullableBool)
        {
            return !aNullableBool.HasValue;
        }

        public static string BooleanToYesNoString(this bool value)
        {
            return value ? StringResources.Boolean_Yes : StringResources.Boolean_No;
        }

        public static string ToLocalizedString(this bool value)
        {
            return value ? StringResources.Boolean_True : StringResources.Boolean_False;
        }

        public static string ToLocalizedString(this bool? value)
        {
            if (!value.HasValue) return string.Empty;

            return value.Value ? StringResources.Boolean_True : StringResources.Boolean_False;
        }
    }
}