using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class WorkPermitMudsNettoyageReportAdapter : IReportAdapter
    {
        private readonly WorkPermitMuds permit;
        private readonly WorkPermitMudsTemplate template;

        public WorkPermitMudsNettoyageReportAdapter(WorkPermitMuds permit)
        {
            this.permit = permit;
            template = permit.Template ?? WorkPermitMudsTemplate.NULL;
        }

        public string PermitNumber
        {
            get { return permit.PermitNumber.HasValue ? permit.PermitNumber.ToString() : string.Empty; }
        }

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
            get { return WorkPermitMudsReportAdapter.TruncatedFunctionalLocations(permit.FunctionalLocations); }
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
            //get { return template.SignatureOperateurSurLeTerrain != TemplateState.Invisible; }
            get { return false; }//TODO

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

        //public bool H2S_Visible
        //{
        //    get { return template.H2S != TemplateState.Invisible; }
        //}

        //public bool H2S_CheckBox
        //{
        //    get { return permit.H2S; }
        //}

        //public bool Hydrocarbure_Visible
        //{
        //    get { return template.Hydrocarbure != TemplateState.Invisible; }
        //}

        //public bool Hydrocarbure_CheckBox
        //{
        //    get { return permit.Hydrocarbure; }
        //}

        //public bool Ammoniaque_Visible
        //{
        //    get { return template.Ammoniaque != TemplateState.Invisible; }
        //}

        //public bool Ammoniaque_CheckBox
        //{
        //    get { return permit.Ammoniaque; }
        //}

        //public bool Corrosif_Visible
        //{
        //    get { return template.Corrosif != TemplateState.Invisible; }
        //}

        //public bool Corrosif_CheckBox
        //{
        //    get { return permit.Corrosif.StateAsBool; }
        //}

        //public string Corrosif_Text
        //{
        //    get { return permit.Corrosif.Text; }
        //}

        //public bool Aromatique_Visible
        //{
        //    get { return template.Aromatique != TemplateState.Invisible; }
        //}

        //public bool Aromatique_CheckBox
        //{
        //    get { return permit.Aromatique.StateAsBool; }
        //}

        //public string Aromatique_Text
        //{
        //    get { return permit.Aromatique.Text; }
        //}

        //public bool AutresSubstances_Visible
        //{
        //    get { return template.AutresSubstances != TemplateState.Invisible; }
        //}

        //public bool AutresSubstances_CheckBox
        //{
        //    get { return permit.AutresSubstances.StateAsBool; }
        //}

        //public string AutresSubstances_Text
        //{
        //    get { return permit.AutresSubstances.Text; }
        //}

        //public bool LunettesMonocoques_Visible
        //{
        //    get { return template.LunettesMonocoques != TemplateState.Invisible; }
        //}

        //public bool LunettesMonocoques_CheckBox
        //{
        //    get { return permit.LunettesMonocoques; }
        //}

        //public bool EcranFacial_Visible
        //{
        //    get { return template.EcranFacial != TemplateState.Invisible; }
        //}

        //public bool EcranFacial_CheckBox
        //{
        //    get { return permit.EcranFacial; }
        //}

        //public bool ProtectionAuditive_Visible
        //{
        //    get { return template.ProtectionAuditive != TemplateState.Invisible; }
        //}

        //public bool ProtectionAuditive_CheckBox
        //{
        //    get { return permit.ProtectionAuditive; }
        //}

        //public bool ProtectionRespiratoire_Visible
        //{
        //    get { return template.ProtectionRespiratoire != TemplateState.Invisible; }
        //}

        //public bool ProtectionRespiratoire_CheckBox
        //{
        //    get { return permit.ProtectionRespiratoire.StateAsBool; }
        //}

        //public string ProtectionRespiratoire_Text
        //{
        //    get { return permit.ProtectionRespiratoire.Text; }
        //}

        //public bool Habits_Visible
        //{
        //    get { return template.Habits != TemplateState.Invisible; }
        //}

        //public bool Habits_CheckBox
        //{
        //    get { return permit.Habits.StateAsBool; }
        //}

        //public string Habits_Text
        //{
        //    get { return permit.Habits.Text; }
        //}

        //public bool AutreProtection_Visible
        //{
        //    get { return template.AutreProtection != TemplateState.Invisible; }
        //}

        //public bool AutreProtection_CheckBox
        //{
        //    get { return permit.AutreProtection.StateAsBool; }
        //}

        //public string AutreProtection_Text
        //{
        //    get { return permit.AutreProtection.Text; }
        //}

        //public bool PerimetreDeSecurite_Visible
        //{
        //    get { return template.PerimetreDeSecurite != TemplateState.Invisible; }
        //}

        //public bool PerimetreDeSecurite_CheckBox
        //{
        //    get { return permit.PerimetreDeSecurite; }
        //}

        //public bool DetectionContinueDesGaz_Visible
        //{
        //    get { return template.DetectionContinueDesGaz != TemplateState.Invisible; }
        //}

        //public bool DetectionContinueDesGaz_CheckBox
        //{
        //    get { return permit.DetectionContinueDesGaz.StateAsBool; }
        //}

        //public string DetectionContinueDesGaz_Text
        //{
        //    get { return permit.DetectionContinueDesGaz.Text; }
        //}

        //public bool AutreEquipementsSecurite_Visible
        //{
        //    get { return template.AutreEquipementsSecurite != TemplateState.Invisible; }
        //}

        //public bool AutreEquipementsSecurite_CheckBox
        //{
        //    get { return permit.AutreEquipementsSecurite.StateAsBool; }
        //}

        //public string AutreEquipementsSecurite_Text
        //{
        //    get { return permit.AutreEquipementsSecurite.Text; }
        //}
    }
}