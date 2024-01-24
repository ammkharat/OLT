using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ConfinedSpaceMontrealReportAdapter : IReportAdapter
    {
        private readonly ConfinedSpace confinedSpace;

        public ConfinedSpaceMontrealReportAdapter(ConfinedSpace confinedSpace)
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
    }
}