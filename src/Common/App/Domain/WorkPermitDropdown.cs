using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Domain
{
    public class WorkPermitDropdown : SimpleDomainObject
    {
        public static readonly WorkPermitDropdown PROTECTION_RESPIRATOIRE = new WorkPermitDropdown(0, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.ProtectionRespiratoireKey,
            "Equipements de protection individuelle - Protection respiratoire");

        public static readonly WorkPermitDropdown PROTECTION_HABITS = new WorkPermitDropdown(1, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.HabitsKey, "Equipements de protection individuelle - Habits");

        public static readonly WorkPermitDropdown PROTECTION_AUTRE = new WorkPermitDropdown(2, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.AutreProtectionKey, "Equipements de protection individuelle - Autre");

        public static readonly WorkPermitDropdown CONDITIONS_AUTRE = new WorkPermitDropdown(3, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.AutresConditionsKey,
            "Conditions et outils permis pour ce travail - Autre");

        public static readonly WorkPermitDropdown SUBSTANCES_CORROSIF = new WorkPermitDropdown(4, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.CorrosifKey,
            "Substances normalement à l'intérieur de l'équipement - Corrosif");

        public static readonly WorkPermitDropdown SUBSTANCES_AROMATIQUE = new WorkPermitDropdown(5, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.AromatiqueKey,
            "Substances normalement à l'intérieur de l'équipement - Aromatique");

        public static readonly WorkPermitDropdown SUBSTANCES_AUTRES = new WorkPermitDropdown(6, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.AutresSubstancesKey,
            "Substances normalement à l'intérieur de l'équipement - Autres");

        public static readonly WorkPermitDropdown INCENDIE_AUTRES = new WorkPermitDropdown(7, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.AutresEquipementDIncendieKey,
            "Protection incendie - Autres équipement d'incendie");

        public static readonly WorkPermitDropdown SECURITY_SURVEILLANT = new WorkPermitDropdown(8, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.SurveillantKey, "Autres équipements de sécurité - Surveillant");

        public static readonly WorkPermitDropdown SECURITY_DETECTION_CONTINUE = new WorkPermitDropdown(9,
            Site.MONTREAL_ID, WorkPermitMontrealDropDownValueKeys.DetectionContinueDesGazKey,
            "Autres équipements de sécurité - Détection continue des gaz");

        public static readonly WorkPermitDropdown SECURITY_AUTRE = new WorkPermitDropdown(10, Site.MONTREAL_ID,
            WorkPermitMontrealDropDownValueKeys.AutreSecuriteKey, "Autres équipements de sécurité - Autre");

        public static readonly WorkPermitDropdown EDM_SHIFT_SUPERVISORS = new WorkPermitDropdown(11, Site.EDMONTON_ID,
            WorkPermitEdmontonDropDownValueKeys.ShiftSupervisors, "Shift Supervisors");

        public static readonly WorkPermitDropdown LUBES_SPECIAL_WORK_TYPES = new WorkPermitDropdown(12, Site.LUBES_ID,
            WorkPermitLubesDropDownValueKeys.SpecialWorkTypes, "Special Work Types");
        
        /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
        public static readonly WorkPermitDropdown FH_SHIFT_SUPERVISORS = new WorkPermitDropdown(13, Site.FORT_HILLS_ID,
           WorkPermitEdmontonDropDownValueKeys.ShiftSupervisors, "Shift Supervisors");

        //RITM0301321 mangesh
        public static readonly WorkPermitDropdown CONDITION_AUTRES = new WorkPermitDropdown(13, Site.MontrealSulphur_ID,
            WorkPermitMudsDropDownValueKeys.AutresConditionsKey,
            "CONDITIONS PRÉPARATOIRES - Autres");

        public static readonly WorkPermitDropdown RISQUES_AUTRES = new WorkPermitDropdown(14, Site.MontrealSulphur_ID,
            WorkPermitMudsDropDownValueKeys.AutresRisquesKey,
            "RISQUES D’EXPOSITION / PHYSIQUES - Autres risques");

        public static readonly WorkPermitDropdown RISQUES_ElectronicVolt = new WorkPermitDropdown(15, Site.MontrealSulphur_ID,
           WorkPermitMudsDropDownValueKeys.ElectronicVoltRisquesKey,
           "RISQUES D’EXPOSITION / PHYSIQUES - Électricité Volt");

        public static readonly WorkPermitDropdown EQUIPEMENTS_PROTECTION_Gants = new WorkPermitDropdown(16, Site.MontrealSulphur_ID,
            WorkPermitMudsDropDownValueKeys.GantsEquipementDeProtectionKey,
            "ÉQUIPEMENTS DE PROTECTION PERSONNELLE - Gants (Sauf cuir)");

        public static readonly WorkPermitDropdown EQUIPEMENTS_PROTECTION_HabitProtecteur = new WorkPermitDropdown(17, Site.MontrealSulphur_ID,
        WorkPermitMudsDropDownValueKeys.HabitProtecteurEquipementDeProtectionKey,
           "ÉQUIPEMENTS DE PROTECTION PERSONNELLE - Habit protecteur");

        public static readonly WorkPermitDropdown EQUIPEMENTS_PROTECTION_EpiAntiArcCat = new WorkPermitDropdown(18, Site.MontrealSulphur_ID, WorkPermitMudsDropDownValueKeys.EpiAntiArcCatProtecteurEquipementDeProtectionKey,
            "ÉQUIPEMENTS DE PROTECTION PERSONNELLE - EPI Anti-arc CAT");

        public static readonly WorkPermitDropdown EQUIPEMENTS_PROTECTION_AppareilProtecteur = new WorkPermitDropdown(19, Site.MontrealSulphur_ID,
           WorkPermitMudsDropDownValueKeys.AppareilProtecteurEquipementDeProtectionKey,
           "ÉQUIPEMENTS DE PROTECTION PERSONNELLE - Appareil respiratoire");

        public static readonly WorkPermitDropdown EQUIPEMENTS_PREVENTION_AUTRES = new WorkPermitDropdown(20, Site.MontrealSulphur_ID,
            WorkPermitMudsDropDownValueKeys.AutresEquipementDePreventionKey,
            "ÉQUIPEMENTS DE PRÉVENTION -  Autres");

        public static readonly WorkPermitDropdown EQUIPEMENTS_PREVENTION_OutilManuel = new WorkPermitDropdown(21, Site.MontrealSulphur_ID,
           WorkPermitMudsDropDownValueKeys.OutilManuelEquipementDePreventionKey,
           "ÉQUIPEMENTS DE PRÉVENTION - Outil manuel");

        public static readonly WorkPermitDropdown EQUIPEMENTS_PREVENTION_PerimetreDeSecurity = new WorkPermitDropdown(22, Site.MontrealSulphur_ID,
            WorkPermitMudsDropDownValueKeys.PerimetreDeSecurityEquipementDePreventionKey,
            "ÉQUIPEMENTS DE PRÉVENTION - Périmètre de sécurité");

        public static readonly WorkPermitDropdown RISQUES_Appareil = new WorkPermitDropdown(23, Site.MontrealSulphur_ID,
           WorkPermitMudsDropDownValueKeys.AppareilEquipementDePreventionKey,
           "RISQUES D’EXPOSITION / PHYSIQUES - Appareil/Véhicule à combustion");

        public static readonly WorkPermitDropdown TRAVAUX_AUTRES = new WorkPermitDropdown(24, Site.MontrealSulphur_ID,
            WorkPermitMudsDropDownValueKeys.AutresTravauxKey,
            "Travaux à chaud à risque élevé - Autres");

        public static readonly WorkPermitDropdown INSTRUCTIONS_AUTRES = new WorkPermitDropdown(25, Site.MontrealSulphur_ID,
           WorkPermitMudsDropDownValueKeys.AutresInstructionsKey,
           "Travaux à chaud – Risque modéré - Autres");

        public static readonly WorkPermitDropdown CSD_SUBSTANCES_AUTRES = new WorkPermitDropdown(25, Site.MontrealSulphur_ID,
          WorkPermitMudsDropDownValueKeys.CsdAutresSubstancesKey,
          "CSD - SUBSTANCES NORMALEMENT À L’INTÉRIEUR DE L’ÉQUIPEMENT - Autres");

        public static readonly WorkPermitDropdown CSD_CONDITIONS_AUTRES = new WorkPermitDropdown(26, Site.MontrealSulphur_ID,
          WorkPermitMudsDropDownValueKeys.CsdAutresConditionsKey,
          "CSD - CONDITIONS AUTORISÉS - Autres");

        private readonly string key;
        private readonly string name;
        private readonly long siteId;

        private WorkPermitDropdown(long id, long siteId, string key, string name) : base(id)
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

        private static List<WorkPermitDropdown> AllDropdowns()
        {
            return new List<WorkPermitDropdown>
            {
                PROTECTION_RESPIRATOIRE,
                PROTECTION_HABITS,
                PROTECTION_AUTRE,
                CONDITIONS_AUTRE,
                SUBSTANCES_CORROSIF,
                SUBSTANCES_AROMATIQUE,
                SUBSTANCES_AUTRES,
                INCENDIE_AUTRES,
                SECURITY_SURVEILLANT,
                SECURITY_DETECTION_CONTINUE,
                SECURITY_AUTRE,
                EDM_SHIFT_SUPERVISORS,
                LUBES_SPECIAL_WORK_TYPES,
                
                FH_SHIFT_SUPERVISORS,
                LUBES_SPECIAL_WORK_TYPES,

                //RITM0301321 - mangesh
                CONDITION_AUTRES,
                RISQUES_AUTRES,
                RISQUES_ElectronicVolt,
                EQUIPEMENTS_PROTECTION_Gants,
                EQUIPEMENTS_PROTECTION_HabitProtecteur,
                EQUIPEMENTS_PROTECTION_EpiAntiArcCat,
                EQUIPEMENTS_PROTECTION_AppareilProtecteur,
                EQUIPEMENTS_PREVENTION_AUTRES,
                EQUIPEMENTS_PREVENTION_OutilManuel,
                EQUIPEMENTS_PREVENTION_PerimetreDeSecurity,
                RISQUES_Appareil,
                TRAVAUX_AUTRES,
                INSTRUCTIONS_AUTRES,
                CSD_SUBSTANCES_AUTRES,
                CSD_CONDITIONS_AUTRES
            };
        }

        public static List<WorkPermitDropdown> AllDropdowns(long siteId)
        {
            return AllDropdowns().FindAll(dropdown => dropdown.siteId == siteId);
        }

        public static WorkPermitDropdown FindByKey(string key)
        {
            return AllDropdowns().Find(dropdown => dropdown.Key == key);
        }
    }
}