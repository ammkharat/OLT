using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class WorkPermitMontrealReportAdapter : IReportAdapter
    {
        private const int MAX_FUNCTIONAL_LOCATIONS_LENGTH = 90;
        private const string ELLIPSIS = "...";

        private readonly WorkPermitMontreal permit;
        private readonly WorkPermitMontrealTemplate template;

        public WorkPermitMontrealReportAdapter(WorkPermitMontreal permit)
        {
            this.permit = permit;
            template = permit.Template ?? WorkPermitMontrealTemplate.NULL;
        }

        public string PermitNumber
        {
            get { return permit.PermitNumber.HasValue ? permit.PermitNumber.ToString() : string.Empty; }
        }
        //DMND0010609-OLT - Edmonton Work permit Scan
        public string WorkpermitScanText
        { get; set; }
        public string PermitType
        {
            get { return permit.WorkPermitType.Name; }
        }

        public string TemplateName
        {
            get { return template.DisplayName; }
        }

        public DateTime StartDateTime
        {
            get { return permit.StartDateTime; }
        }

        public DateTime EndDateTime
        {
            get { return permit.EndDateTime; }
        }

        public string FunctionalLocation
        {
            get { return TruncatedFunctionalLocations(permit.FunctionalLocations); }
        }

        public string Trade
        {
            get { return permit.Trade; }
        }

        public string Description
        {
            get { return permit.Description; }
        }

        public string InstructionsSpeciales
        {
            get { return permit.InstructionsSpeciales; }
        }

        public bool SignatureOperateurSurLeTerrain_Visible
        {
            get { return template.SignatureOperateurSurLeTerrain != TemplateState.Invisible; }
        }

        public bool SignatureOperateurSurLeTerrain_CheckBox
        {
            get { return permit.SignatureOperateurSurLeTerrain; }
        }

        public bool SignatureOperateurSurLeTerrain
        {
            get { return permit.SignatureOperateurSurLeTerrain; }
        }

        public bool DetectionDesGazs
        {
            get { return permit.DetectionDesGazs; }
        }

        public bool SignatureContremaitre
        {
            get { return permit.SignatureContremaitre; }
        }

        public bool SignatureAutorise
        {
            get { return permit.SignatureAutorise; }
        }

        public bool H2S_Visible
        {
            get { return template.H2S != TemplateState.Invisible; }
        }

        public bool H2S_CheckBox
        {
            get { return permit.H2S; }
        }

        public bool Hydrocarbure_Visible
        {
            get { return template.Hydrocarbure != TemplateState.Invisible; }
        }

        public bool Hydrocarbure_CheckBox
        {
            get { return permit.Hydrocarbure; }
        }

        public bool Ammoniaque_Visible
        {
            get { return template.Ammoniaque != TemplateState.Invisible; }
        }

        public bool Ammoniaque_CheckBox
        {
            get { return permit.Ammoniaque; }
        }

        public bool Corrosif_Visible
        {
            get { return template.Corrosif != TemplateState.Invisible; }
        }

        public bool Corrosif_CheckBox
        {
            get { return permit.Corrosif.StateAsBool; }
        }

        public string Corrosif_Text
        {
            get { return permit.Corrosif.Text; }
        }

        public bool Aromatique_Visible
        {
            get { return template.Aromatique != TemplateState.Invisible; }
        }

        public bool Aromatique_CheckBox
        {
            get { return permit.Aromatique.StateAsBool; }
        }

        public string Aromatique_Text
        {
            get { return permit.Aromatique.Text; }
        }

        public bool AutresSubstances_Visible
        {
            get { return template.AutresSubstances != TemplateState.Invisible; }
        }

        public bool AutresSubstances_CheckBox
        {
            get { return permit.AutresSubstances.StateAsBool; }
        }

        public string AutresSubstances_Text
        {
            get { return permit.AutresSubstances.Text; }
        }

        public bool ObtureOuDebranche_Visible
        {
            get { return template.ObtureOuDebranche != TemplateState.Invisible; }
        }

        public bool ObtureOuDebranche_CheckBox
        {
            get { return permit.ObtureOuDebranche; }
        }

        public bool DepressuriseEtVidange_Visible
        {
            get { return template.DepressuriseEtVidange != TemplateState.Invisible; }
        }

        public bool DepressuriseEtVidange_CheckBox
        {
            get { return permit.DepressuriseEtVidange; }
        }

        public bool EnPresenceDeGazInerte_Visible
        {
            get { return template.EnPresenceDeGazInerte != TemplateState.Invisible; }
        }

        public bool EnPresenceDeGazInerte_CheckBox
        {
            get { return permit.EnPresenceDeGazInerte; }
        }

        public bool PurgeALaVapeur_Visible
        {
            get { return template.PurgeALaVapeur != TemplateState.Invisible; }
        }

        public bool PurgeALaVapeur_CheckBox
        {
            get { return permit.PurgeALaVapeur; }
        }

        public bool RinceALeau_Visible
        {
            get { return template.RinceALeau != TemplateState.Invisible; }
        }

        public bool RinceALeau_CheckBox
        {
            get { return permit.RinceALeau; }
        }

        public bool Excavation_Visible
        {
            get { return template.Excavation != TemplateState.Invisible; }
        }

        public bool Excavation_CheckBox
        {
            get { return permit.Excavation; }
        }

        public bool DessinsRequis_Visible
        {
            get { return template.DessinsRequis != TemplateState.Invisible; }
        }

        public bool DessinsRequis_CheckBox
        {
            get { return permit.DessinsRequis.StateAsBool; }
        }

        public string DessinsRequis_Text
        {
            get { return permit.DessinsRequis.Text; }
        }

        public bool CablesChauffantsMisHorsTension_Visible
        {
            get { return template.CablesChauffantsMisHorsTension != TemplateState.Invisible; }
        }

        public bool CablesChauffantsMisHorsTension_CheckBox
        {
            get { return permit.CablesChauffantsMisHorsTension; }
        }

        public bool PompeOuVerinPneumatique_Visible
        {
            get { return template.PompeOuVerinPneumatique != TemplateState.Invisible; }
        }

        public bool PompeOuVerinPneumatique_CheckBox
        {
            get { return permit.PompeOuVerinPneumatique; }
        }

        public bool ChaineEtCadenasseOuScelle_Visible
        {
            get { return template.ChaineEtCadenasseOuScelle != TemplateState.Invisible; }
        }

        public bool ChaineEtCadenasseOuScelle_CheckBox
        {
            get { return permit.ChaineEtCadenasseOuScelle; }
        }

        public bool InterrupteursElectriquesVerrouilles_Visible
        {
            get { return template.InterrupteursElectriquesVerrouilles != TemplateState.Invisible; }
        }

        public bool InterrupteursElectriquesVerrouilles_CheckBox
        {
            get { return permit.InterrupteursElectriquesVerrouilles; }
        }

        public bool PurgeParUnGazInerte_Visible
        {
            get { return template.PurgeParUnGazInerte != TemplateState.Invisible; }
        }

        public bool PurgeParUnGazInerte_CheckBox
        {
            get { return permit.PurgeParUnGazInerte; }
        }

        public bool OutilsElectriquesOuABatteries_Visible
        {
            get { return template.OutilsElectriquesOuABatteries != TemplateState.Invisible; }
        }

        public bool OutilsElectriquesOuABatteries_CheckBox
        {
            get { return permit.OutilsElectriquesOuABatteries; }
        }

        public bool BoiteEnergieZero_Visible
        {
            get { return template.BoiteEnergieZero != TemplateState.Invisible; }
        }

        public bool BoiteEnergieZero_CheckBox
        {
            get { return permit.BoiteEnergieZero.StateAsBool; }
        }

        public string BoiteEnergieZero_Text
        {
            get { return permit.BoiteEnergieZero.Text; }
        }

        public bool OutilsPneumatiques_Visible
        {
            get { return template.OutilsPneumatiques != TemplateState.Invisible; }
        }

        public bool OutilsPneumatiques_CheckBox
        {
            get { return permit.OutilsPneumatiques; }
        }

        public bool MoteurACombustionInterne_Visible
        {
            get { return template.MoteurACombustionInterne != TemplateState.Invisible; }
        }

        public bool MoteurACombustionInterne_CheckBox
        {
            get { return permit.MoteurACombustionInterne; }
        }

        public bool TravauxSuperPoses_Visible
        {
            get { return template.TravauxSuperPoses != TemplateState.Invisible; }
        }

        public bool TravauxSuperPoses_CheckBox
        {
            get { return permit.TravauxSuperPoses; }
        }

        public bool FormulaireDespaceClosAffiche_Visible
        {
            get { return template.FormulaireDespaceClosAffiche != TemplateState.Invisible; }
        }

        public bool FormulaireDespaceClosAffiche_CheckBox
        {
            get { return permit.FormulaireDespaceClosAffiche.StateAsBool; }
        }

        public string FormulaireDespaceClosAffiche_Text
        {
            get { return permit.FormulaireDespaceClosAffiche.Text; }
        }

        public bool ExisteIlUneAnalyseDeTache_Visible
        {
            get { return template.ExisteIlUneAnalyseDeTache != TemplateState.Invisible; }
        }

        public bool ExisteIlUneAnalyseDeTache_CheckBox
        {
            get { return permit.ExisteIlUneAnalyseDeTache; }
        }

        public bool PossibiliteDeSulfureDeFer_Visible
        {
            get { return template.PossibiliteDeSulfureDeFer != TemplateState.Invisible; }
        }

        public bool PossibiliteDeSulfureDeFer_CheckBox
        {
            get { return permit.PossibiliteDeSulfureDeFer; }
        }

        public bool AereVentile_Visible
        {
            get { return template.AereVentile != TemplateState.Invisible; }
        }

        public bool AereVentile_CheckBox
        {
            get { return permit.AereVentile; }
        }

        public bool SoudureALelectricite_Visible
        {
            get { return template.SoudureALelectricite != TemplateState.Invisible; }
        }

        public bool SoudureALelectricite_CheckBox
        {
            get { return permit.SoudureALelectricite; }
        }

        public bool BrulageAAcetylene_Visible
        {
            get { return template.BrulageAAcetylene != TemplateState.Invisible; }
        }

        public bool BrulageAAcetylene_CheckBox
        {
            get { return permit.BrulageAAcetylene; }
        }

        public bool Nacelle_Visible
        {
            get { return template.Nacelle != TemplateState.Invisible; }
        }

        public bool Nacelle_CheckBox
        {
            get { return permit.Nacelle; }
        }

        public bool AutreConditions_Visible
        {
            get { return template.AutreConditions != TemplateState.Invisible; }
        }

        public bool AutreConditions_CheckBox
        {
            get { return permit.AutreConditions.StateAsBool; }
        }

        public string AutreConditions_Text
        {
            get { return permit.AutreConditions.Text; }
        }

        public bool LunettesMonocoques_Visible
        {
            get { return template.LunettesMonocoques != TemplateState.Invisible; }
        }

        public bool LunettesMonocoques_CheckBox
        {
            get { return permit.LunettesMonocoques; }
        }

        public bool HarnaisDeSecurite_Visible
        {
            get { return template.HarnaisDeSecurite != TemplateState.Invisible; }
        }

        public bool HarnaisDeSecurite_CheckBox
        {
            get { return permit.HarnaisDeSecurite; }
        }

        public bool EcranFacial_Visible
        {
            get { return template.EcranFacial != TemplateState.Invisible; }
        }

        public bool EcranFacial_CheckBox
        {
            get { return permit.EcranFacial; }
        }

        public bool ProtectionAuditive_Visible
        {
            get { return template.ProtectionAuditive != TemplateState.Invisible; }
        }

        public bool ProtectionAuditive_CheckBox
        {
            get { return permit.ProtectionAuditive; }
        }

        public bool Trepied_Visible
        {
            get { return template.Trepied != TemplateState.Invisible; }
        }

        public bool Trepied_CheckBox
        {
            get { return permit.Trepied; }
        }

        public bool DispositifAntichute_Visible
        {
            get { return template.DispositifAntichute != TemplateState.Invisible; }
        }

        public bool DispositifAntichute_CheckBox
        {
            get { return permit.DispositifAntichute; }
        }

        public bool ProtectionRespiratoire_Visible
        {
            get { return template.ProtectionRespiratoire != TemplateState.Invisible; }
        }

        public bool ProtectionRespiratoire_CheckBox
        {
            get { return permit.ProtectionRespiratoire.StateAsBool; }
        }

        public string ProtectionRespiratoire_Text
        {
            get { return permit.ProtectionRespiratoire.Text; }
        }

        public bool Habits_Visible
        {
            get { return template.Habits != TemplateState.Invisible; }
        }

        public bool Habits_CheckBox
        {
            get { return permit.Habits.StateAsBool; }
        }

        public string Habits_Text
        {
            get { return permit.Habits.Text; }
        }

        public bool AutreProtection_Visible
        {
            get { return template.AutreProtection != TemplateState.Invisible; }
        }

        public bool AutreProtection_CheckBox
        {
            get { return permit.AutreProtection.StateAsBool; }
        }

        public string AutreProtection_Text
        {
            get { return permit.AutreProtection.Text; }
        }

        public bool Extincteur_Visible
        {
            get { return template.Extincteur != TemplateState.Invisible; }
        }

        public bool Extincteur_CheckBox
        {
            get { return permit.Extincteur; }
        }

        public bool BouchesDegoutProtegees_Visible
        {
            get { return template.BouchesDegoutProtegees != TemplateState.Invisible; }
        }

        public bool BouchesDegoutProtegees_CheckBox
        {
            get { return permit.BouchesDegoutProtegees; }
        }

        public bool CouvertureAntiEtincelles_Visible
        {
            get { return template.CouvertureAntiEtincelles != TemplateState.Invisible; }
        }

        public bool CouvertureAntiEtincelles_CheckBox
        {
            get { return permit.CouvertureAntiEtincelles; }
        }

        public bool SurveillantPouretincelles_Visible
        {
            get { return template.SurveillantPouretincelles != TemplateState.Invisible; }
        }

        public bool SurveillantPouretincelles_CheckBox
        {
            get { return permit.SurveillantPouretincelles; }
        }

        public bool PareEtincelles_Visible
        {
            get { return template.PareEtincelles != TemplateState.Invisible; }
        }

        public bool PareEtincelles_CheckBox
        {
            get { return permit.PareEtincelles; }
        }

        public bool MiseAlaTerrePresDuLieuDeTravail_Visible
        {
            get { return template.MiseAlaTerrePresDuLieuDeTravail != TemplateState.Invisible; }
        }

        public bool MiseAlaTerrePresDuLieuDeTravail_CheckBox
        {
            get { return permit.MiseAlaTerrePresDuLieuDeTravail; }
        }

        public bool BoyauAVapeur_Visible
        {
            get { return template.BoyauAVapeur != TemplateState.Invisible; }
        }

        public bool BoyauAVapeur_CheckBox
        {
            get { return permit.BoyauAVapeur; }
        }

        public bool AutresEquipementDincendie_Visible
        {
            get { return template.AutresEquipementDincendie != TemplateState.Invisible; }
        }

        public bool AutresEquipementDincendie_CheckBox
        {
            get { return permit.AutresEquipementDincendie.StateAsBool; }
        }

        public string AutresEquipementDincendie_Text
        {
            get { return permit.AutresEquipementDincendie.Text; }
        }

        public bool Ventulateur_Visible
        {
            get { return template.Ventulateur != TemplateState.Invisible; }
        }

        public bool Ventulateur_CheckBox
        {
            get { return permit.Ventulateur; }
        }

        public bool Barrieres_Visible
        {
            get { return template.Barrieres != TemplateState.Invisible; }
        }

        public bool Barrieres_CheckBox
        {
            get { return permit.Barrieres; }
        }

        public bool Surveillant_Visible
        {
            get { return template.Surveillant != TemplateState.Invisible; }
        }

        public bool Surveillant_CheckBox
        {
            get { return permit.Surveillant.StateAsBool; }
        }

        public string Surveillant_Text
        {
            get { return permit.Surveillant.Text; }
        }

        public bool RadioEmetteur_Visible
        {
            get { return template.RadioEmetteur != TemplateState.Invisible; }
        }

        public bool RadioEmetteur_CheckBox
        {
            get { return permit.RadioEmetteur; }
        }

        public bool PerimetreDeSecurite_Visible
        {
            get { return template.PerimetreDeSecurite != TemplateState.Invisible; }
        }

        public bool PerimetreDeSecurite_CheckBox
        {
            get { return permit.PerimetreDeSecurite; }
        }

        public bool DetectionContinueDesGaz_Visible
        {
            get { return template.DetectionContinueDesGaz != TemplateState.Invisible; }
        }

        public bool DetectionContinueDesGaz_CheckBox
        {
            get { return permit.DetectionContinueDesGaz.StateAsBool; }
        }

        public string DetectionContinueDesGaz_Text
        {
            get { return permit.DetectionContinueDesGaz.Text; }
        }

        public bool KlaxonSonore_Visible
        {
            get { return template.KlaxonSonore != TemplateState.Invisible; }
        }

        public bool KlaxonSonore_CheckBox
        {
            get { return permit.KlaxonSonore; }
        }

        public bool Localiser_Visible
        {
            get { return template.Localiser != TemplateState.Invisible; }
        }

        public bool Localiser_CheckBox
        {
            get { return permit.Localiser; }
        }

        public bool Amiante_Visible
        {
            get { return template.Amiante != TemplateState.Invisible; }
        }

        public bool Amiante_CheckBox
        {
            get { return permit.Amiante; }
        }

        public bool AutreEquipementsSecurite_Visible
        {
            get { return template.AutreEquipementsSecurite != TemplateState.Invisible; }
        }

        public bool AutreEquipementsSecurite_CheckBox
        {
            get { return permit.AutreEquipementsSecurite.StateAsBool; }
        }

        public string AutreEquipementsSecurite_Text
        {
            get { return permit.AutreEquipementsSecurite.Text; }
        }

        public static bool WillTruncateFunctionalLocations(List<FunctionalLocation> functionalLocations)
        {
            return TruncatedFunctionalLocations(functionalLocations).EndsWith(ELLIPSIS);
        }

        public static string TruncatedFunctionalLocations(List<FunctionalLocation> functionalLocations)
        {
            var isTruncated = false;
            var truncatedFlocString = string.Empty;

            var functionalLocationFullHierarchies = functionalLocations.FullHierarchyList(true);

            foreach (var t in functionalLocationFullHierarchies)
            {
                string potentialString;
                if (truncatedFlocString.Length == 0)
                {
                    potentialString = t;
                }
                else
                {
                    potentialString = truncatedFlocString + ", " + t;
                }

                if (potentialString.Length < MAX_FUNCTIONAL_LOCATIONS_LENGTH)
                {
                    truncatedFlocString = potentialString;
                }
                else
                {
                    isTruncated = true;
                }
            }

            if (isTruncated)
            {
                truncatedFlocString += ", " + ELLIPSIS;
            }

            return truncatedFlocString;
        }
    }
}