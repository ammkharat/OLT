using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitMudsDropDownValueKeys
    {
        public const string AutresConditionsKey = "muds_autres_conditions";
        public const string AutresRisquesKey = "muds_autres_risques";
        public const string ElectronicVoltRisquesKey = "muds_electronicvolt_risques";
        public const string GantsEquipementDeProtectionKey = "muds_gants_equipement_protection";
        public const string HabitProtecteurEquipementDeProtectionKey = "muds_habit_protecteur_equipement_protection";
        public const string EpiAntiArcCatProtecteurEquipementDeProtectionKey = "muds_epiantiarc_protecteur_equipement_protection";
        public const string AppareilProtecteurEquipementDeProtectionKey = "muds_appareil_protecteur_equipement_protection";
        public const string AutresEquipementDePreventionKey = "muds_autres_equipement_prevention";
        public const string OutilManuelEquipementDePreventionKey = "muds_outil_equipement_prevention";
        public const string PerimetreDeSecurityEquipementDePreventionKey = "muds_perimetre_equipement_prevention";
        public const string AppareilEquipementDePreventionKey = "muds_appareil_equipement_prevention";
        public const string AutresTravauxKey = "muds_autres_travaux";
        public const string AutresInstructionsKey = "muds_autres_instructions";
        public const string CsdAutresConditionsKey = "muds_csd_autres_conditions";
        public const string CsdAutresSubstancesKey = "muds_csd_autres_substances";


        public static List<String> CsdAutresConditionsDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(CsdAutresConditionsKey, dropdownValues);
        }
        public static List<String> CsdAutresSubstancessDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(CsdAutresSubstancesKey, dropdownValues);
        }

        public static List<String> AutresConditionsDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(AutresConditionsKey, dropdownValues);
        }

        public static List<String> AutresRisquesDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(AutresRisquesKey, dropdownValues);
        }

        public static List<String> ElectronicVoltRisquesDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(ElectronicVoltRisquesKey, dropdownValues);
        }

        public static List<String> GantsEquipementDeProtectionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(GantsEquipementDeProtectionKey, dropdownValues);
        }

        public static List<String> HabitProtecteurEquipementDeProtectionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(HabitProtecteurEquipementDeProtectionKey, dropdownValues);
        }

        public static List<String> EpiAntiArcCatProtecteurEquipementDeProtectionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(EpiAntiArcCatProtecteurEquipementDeProtectionKey, dropdownValues);
        }

        public static List<String> AppareilProtecteurEquipementDeProtectionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(AppareilProtecteurEquipementDeProtectionKey, dropdownValues);// AppareilEquipementDePreventionKey
        }

        public static List<String> AutresEquipementDePreventionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(AppareilEquipementDePreventionKey, dropdownValues);// AppareilProtecteurEquipementDeProtectionKey
        }

        public static List<String> OutilManuelEquipementDePreventionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(OutilManuelEquipementDePreventionKey, dropdownValues);
        }

        public static List<String> PerimetreDeSecurityEquipementDePreventionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(PerimetreDeSecurityEquipementDePreventionKey, dropdownValues);
        }

        public static List<String> AppareilEquipementDePreventionDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(AutresEquipementDePreventionKey, dropdownValues);//AppareilEquipementDePreventionKey
        }

        public static List<String> AutresTravauxDropdownValues(List<DropdownValue> dropdownValues)
        {
            return DropdownValue.DropdownValuesForKey(AutresTravauxKey, dropdownValues);
        }
    }
}