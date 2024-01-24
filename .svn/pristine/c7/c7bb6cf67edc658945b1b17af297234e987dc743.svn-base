using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    public class FormTemplateKeys
    {
        public const string GN24_PSV = "psv";
        public const string GN24_NONPSV = "nonpsv";
        public const string GN24_PREJOBSIGNATURES = "prejobsignatures";

        public const string GN6_MANBASKET = "manbasket";
        public const string GN6_CRANECHART = "cranechart";
        public const string GN6_POWERLINES = "powerlines";
        public const string GN6_ACIDDRUMS = "aciddrums";
        public const string GN6_ALOTOFCRANES = "alotofcranes";
        public const string GN6_OTHER = "other";
        public const string GN6_PREJOBSIGNATURES = "prejobsignaturesgn6";

        public const string GN1_PLANNING_WORKSHEET = "cseplanningworksheet";
        public const string GN1_INITIAL_ENTRY_MTG = "cseinitialentryandreviewpage";
        public const string GN1_TRADE_CHECKLIST = "csetradechecklist";
        public const string GN1_RESCUE_PLAN = "cserescueplan";

        public static FormTemplate FormTemplateForKey(string key, List<FormTemplate> templates)
        {
            return templates.Find(template => template.Key == key);
        }
    }
}