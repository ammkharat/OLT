﻿using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ConfinedSpaceMudsReportAdapter : IReportAdapter
    {
        public readonly ConfinedSpaceMuds confinedSpace;
        //Added by ppanigrahi
        public string FirstGastestInitial { get; set; }
        public string SecondGastestInitial { get; set; }
        public string ThirdGastestInitial { get; set; }
        public string FourthGastestInitial { get; set; }

        public ConfinedSpaceMudsReportAdapter(ConfinedSpaceMuds confinedSpace)
        {
            this.confinedSpace = confinedSpace;
        }

        public string ConfinedSpaceNumber
        {
            get { return confinedSpace.ConfinedSpaceNumber.HasValue ? "EC " + confinedSpace.ConfinedSpaceNumber : ""; }
        }

        public DateTime StartDateTime
        {
            get { return confinedSpace.StartDateTime; }
        }

        public DateTime EndDateTime
        {
            get { return confinedSpace.EndDateTime; }
        }

        public string FunctionalLocationWithDescription
        {
            get { return confinedSpace.FunctionalLocation.FullHierarchy + "(" + confinedSpace.FunctionalLocation.Description + ")"; }
        }

        public string FunctionalLocation
        {
            get { return confinedSpace.FunctionalLocation.FullHierarchy; }
        }

        public string FunctionalLocationDescription
        {
            get { return "(" + confinedSpace.FunctionalLocation.Description + ")"; }
        }

        public string InstructionsSpeciales
        {
            get { return confinedSpace.InstructionsSpeciales; }
        }

        public bool H2S_CheckBox
        {
            get { return confinedSpace.H2S; }
        }

        public bool Hydrocarbure_CheckBox
        {
            get { return confinedSpace.Hydrocarbure; }
        }

        public bool Ammoniaque_CheckBox
        {
            get { return confinedSpace.Ammoniaque; }
        }

        public bool Corrosif_CheckBox
        {
            get { return confinedSpace.Corrosif.StateAsBool; }
        }

        public string Corrosif_Text
        {
            get { return confinedSpace.Corrosif.Text; }
        }

        public bool Aromatique_CheckBox
        {
            get { return confinedSpace.Aromatique.StateAsBool; }
        }

        public string Aromatique_Text
        {
            get { return confinedSpace.Aromatique.Text; }
        }

        public bool AutresSubstances_CheckBox
        {
            get { return confinedSpace.AutresSubstances.StateAsBool; }
        }

        public string AutresSubstances_Text
        {
            get { return confinedSpace.AutresSubstances.Text; }
        }

        public bool ObtureOuDebranche_CheckBox
        {
            get { return confinedSpace.ObtureOuDebranche; }
        }

        public bool DepressuriseEtVidange_CheckBox
        {
            get { return confinedSpace.DepressuriseEtVidange; }
        }

        public bool EnPresenceDeGazInerte_CheckBox
        {
            get { return confinedSpace.EnPresenceDeGazInerte; }
        }

        public bool PurgeALaVapeur_CheckBox
        {
            get { return confinedSpace.PurgeALaVapeur; }
        }

        public bool DessinsRequis_CheckBox
        {
            get { return confinedSpace.DessinsRequis.StateAsBool; }
        }

        public string DessinsRequis_Text
        {
            get { return confinedSpace.DessinsRequis.Text; }
        }

        public bool PlanDeSauvetage
        {
            get { return confinedSpace.PlanDeSauvetage; }
        }

        public bool CablesChauffantsMisHorsTension_CheckBox
        {
            get { return confinedSpace.CablesChauffantsMisHorsTension; }
        }

        public bool InterrupteursElectriquesVerrouilles_CheckBox
        {
            get { return confinedSpace.InterrupteursElectriquesVerrouilles; }
        }

        public bool PurgeParUnGazInerte_CheckBox
        {
            get { return confinedSpace.PurgeParUnGazInerte; }
        }

        public bool RinceALeau_CheckBox
        {
            get { return confinedSpace.RinceAlEau; }
        }

        public bool VentilationMecanique_CheckBox
        {
            get { return confinedSpace.VentilationMecanique; }
        }

        public bool BouchesDegoutProtegees_CheckBox
        {
            get { return confinedSpace.BouchesDegoutProtegees; }
        }

        public bool PossibiliteDeSulfureDeFer_CheckBox
        {
            get { return confinedSpace.PossibiliteDeSulfureDeFer; }
        }

        public bool AereVentile_CheckBox
        {
            get { return confinedSpace.AereVentile; }
        }

        public bool AutreConditions_CheckBox
        {
            get { return confinedSpace.AutreConditions.StateAsBool; }
        }

        public string AutreConditions_Text
        {
            get { return confinedSpace.AutreConditions.Text; }
        }

        public bool VentilationNaturelle_CheckBox
        {
            get { return confinedSpace.VentilationNaturelle; }
        }

        public bool SO2_Checkbox
        {
            get { return confinedSpace.SO2; }
        }
        public bool NH3_Checkbox
        {
            get { return confinedSpace.NH3; }
        }
        public bool AcideSulfurique_Checkbox
        {
            get { return confinedSpace.AcideSulfurique; }
        }
        public bool CO_Checkbox
        {
            get { return confinedSpace.CO; }
        }
        public bool Azote_Checkbox
        {
            get { return confinedSpace.Azote; }
        }
        public bool Reflux_Checkbox
        {
            get { return confinedSpace.Reflux; }
        }
        public bool NaOH_Checkbox
        {
            get { return confinedSpace.NaOH; }
        }
        public bool SBS_Checkbox
        {
            get { return confinedSpace.SBS; }
        }
        public bool Soufre_Checkbox
        {
            get { return confinedSpace.Soufre; }
        }
        public bool Amiante_Checkbox
        {
            get { return confinedSpace.Amiante; }
        }
        public bool Bacteries_Checkbox
        {
            get { return confinedSpace.Bacteries; }
        }
        public bool Depressurise_Checkbox
        {
            get { return confinedSpace.Depressurise; }
        }
        public bool Rince_Checkbox
        {
            get { return confinedSpace.Rince; }
        }
        public bool Obture_Checkbox
        {
            get { return confinedSpace.Obture; }
        }
        public bool Nettoyes_Checkbox
        {
            get { return confinedSpace.Nettoyes; }
        }
        public bool Purge_Checkbox
        {
            get { return confinedSpace.Purge; }
        }
        public bool Vide_Checkbox
        {
            get { return confinedSpace.Vide; }
        }
        public bool Dessins_Checkbox
        {
            get { return confinedSpace.Dessins; }
        }
        public bool DetectionDeGaz_Checkbox
        {
            get { return confinedSpace.DetectionDeGaz; }
        }
        public bool PSS_Checkbox
        {
            get { return confinedSpace.PSS; }
        }
        public bool VentilationEn_Checkbox
        {
            get { return confinedSpace.VentilationEn; }
        }
        public bool VentilationForce_Checkbox
        {
            get { return confinedSpace.VentilationForce; }
        }
        public bool Harnis_CheckBox
        {
            get { return confinedSpace.Harnis; }
        }

        //Added for Workpermit Sign by ppanigrahi
        public string Verifier_NAME { get; set; }
        public string Verifier_BADGENUMBER { get; set; }
        public string Verifier_BADGETYPE { get; set; }
        public string Verifier_SOURCE { get; set; }

        public string DETENTEUR_NAME { get; set; }
        public string DETENTEUR_BADGENUMBER { get; set; }
        public string DETENTEUR_BADGETYPE { get; set; }
        public string DETENTEUR_SOURCE { get; set; }

        public string EMETTEUR_NAME { get; set; }
        public string EMETTEUR_BADGENUMBER { get; set; }
        public string EMETTEUR_BADGETYPE { get; set; }
        public string EMETTEUR_SOURCE { get; set; }

    }
}