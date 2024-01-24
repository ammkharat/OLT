using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMontrealTemplateViewMapper
    {
        private readonly IWorkPermitMontrealFormView view;
        private readonly WorkPermitMontrealTemplate template;

        public WorkPermitMontrealTemplateViewMapper(IWorkPermitMontrealFormView view, WorkPermitMontrealTemplate template)
        {
            this.view = view;
            this.template = template;
        }

        public void MapTemplateToView()
        {
            if (template == null)
                return;

            view.H2S = CreateVisibleFromTemplate(template.H2S);
            view.Hydrocarbure = CreateVisibleFromTemplate(template.Hydrocarbure);

            view.Ammoniaque = CreateVisibleFromTemplate(template.Ammoniaque);
            view.Corrosif = CreateVisibleFromTemplate(template.Corrosif, template.CorrosifValue);
            view.Aromatique = CreateVisibleFromTemplate(template.Aromatique, template.AromatiqueValue);
            view.AutresSubstances = CreateVisibleFromTemplate(template.AutresSubstances, template.AutresSubstancesValue);

            view.ObtureOuDebranche = CreateVisibleFromTemplate(template.ObtureOuDebranche);
            view.DepressuriseEtVidange = CreateVisibleFromTemplate(template.DepressuriseEtVidange);
            view.EnPreenceDeGazInerte = CreateVisibleFromTemplate(template.EnPresenceDeGazInerte);
            view.PurgeALaVapeur = CreateVisibleFromTemplate(template.PurgeALaVapeur);
            view.RinceALeau = CreateVisibleFromTemplate(template.RinceALeau);
            view.Excavation = CreateVisibleFromTemplate(template.Excavation);

            view.DessinsRequis = CreateVisibleFromTemplate(template.DessinsRequis, template.DessinsRequisValue);

            view.CablesChauffantsMisHorsTension = CreateVisibleFromTemplate(template.CablesChauffantsMisHorsTension);
            view.PompeOuVerinPneumatique = CreateVisibleFromTemplate(template.PompeOuVerinPneumatique);
            view.ChaineEtCadenasseOuScelle = CreateVisibleFromTemplate(template.ChaineEtCadenasseOuScelle);
            view.InterrupteursElectriquesVerrouilles = CreateVisibleFromTemplate(template.InterrupteursElectriquesVerrouilles);
            view.PurgeParUnGazInerte = CreateVisibleFromTemplate(template.PurgeParUnGazInerte);
            view.OutilsElectriquesOuABatteries = CreateVisibleFromTemplate(template.OutilsElectriquesOuABatteries);

            view.BoiteEnergieZero = CreateVisibleFromTemplate(template.BoiteEnergieZero, template.BoiteEnergieZeroValue);

            view.OutilsPneumatiques = CreateVisibleFromTemplate(template.OutilsPneumatiques);
            view.MoteurACombustionInterne = CreateVisibleFromTemplate(template.MoteurACombustionInterne);
            view.TravauxSuperPoses = CreateVisibleFromTemplate(template.TravauxSuperPoses);
            view.FormulaireDespaceClosAffiche = CreateVisibleFromTemplate(template.FormulaireDespaceClosAffiche, template.FormulaireDespaceClosAfficheValue);

            view.ExisteIlUneAnalyseDeTache = CreateVisibleFromTemplate(template.ExisteIlUneAnalyseDeTache);
            view.PossibiliteDeSulfureDeFer = CreateVisibleFromTemplate(template.PossibiliteDeSulfureDeFer);
            view.AereVentile = CreateVisibleFromTemplate(template.AereVentile);
            view.SoudureALelectricite = CreateVisibleFromTemplate(template.SoudureALelectricite);
            view.BrulageAAcetylene = CreateVisibleFromTemplate(template.BrulageAAcetylene);
            view.Nacelle = CreateVisibleFromTemplate(template.Nacelle);
            view.AutreConditions = CreateVisibleFromTemplate(template.AutreConditions, template.AutreConditionsValue);

            view.LunettesMonocoques = CreateVisibleFromTemplate(template.LunettesMonocoques);
            view.HarnaisDeSecurite = CreateVisibleFromTemplate(template.HarnaisDeSecurite);
            view.EcranFacial = CreateVisibleFromTemplate(template.EcranFacial);
            view.ProtectionAuditive = CreateVisibleFromTemplate(template.ProtectionAuditive);
            view.Trepied = CreateVisibleFromTemplate(template.Trepied);
            view.DispositifAntichute = CreateVisibleFromTemplate(template.DispositifAntichute);
            view.ProtectionRespiratoire = CreateVisibleFromTemplate(template.ProtectionRespiratoire, template.ProtectionRespiratoireValue);

            view.Habits = CreateVisibleFromTemplate(template.Habits, template.HabitsValue);
            view.AutreProtection = CreateVisibleFromTemplate(template.AutreProtection, template.AutreProtectionValue);

            view.Extincteur = CreateVisibleFromTemplate(template.Extincteur);
            view.BouchesDegoutProtegees = CreateVisibleFromTemplate(template.BouchesDegoutProtegees);
            view.CouvertureAntiEtincelles = CreateVisibleFromTemplate(template.CouvertureAntiEtincelles);
            view.SurveillantPouretincelles = CreateVisibleFromTemplate(template.SurveillantPouretincelles);
            view.PareEtincelles = CreateVisibleFromTemplate(template.PareEtincelles);
            view.MiseAlaTerrePresDuLieuDeTravail = CreateVisibleFromTemplate(template.MiseAlaTerrePresDuLieuDeTravail);
            view.BoyauAVapeur = CreateVisibleFromTemplate(template.BoyauAVapeur);
            view.AutresEquipementDincendie = CreateVisibleFromTemplate(template.AutresEquipementDincendie, template.AutresEquipementDincendieValue);

            view.Ventulateur = CreateVisibleFromTemplate(template.Ventulateur);
            view.Barrieres = CreateVisibleFromTemplate(template.Barrieres);
            view.Surveillant = CreateVisibleFromTemplate(template.Surveillant, template.SurveillantValue);
            view.RadioEmetteur = CreateVisibleFromTemplate(template.RadioEmetteur);
            view.PerimetreDeSecurite = CreateVisibleFromTemplate(template.PerimetreDeSecurite);

            view.DetectionContinueDesGaz = CreateVisibleFromTemplate(template.DetectionContinueDesGaz, template.DetectionContinueDesGazValue);

            view.KlaxonSonore = CreateVisibleFromTemplate(template.KlaxonSonore);
            view.Localiser = CreateVisibleFromTemplate(template.Localiser);
            view.Amiante = CreateVisibleFromTemplate(template.Amiante);
            view.AutreEquipementsSecurite = CreateVisibleFromTemplate(template.AutreEquipementsSecurite, template.AutreEquipementsSecuriteValue);

            view.InstructionsSpeciales = template.InstructionsSpeciales;
            view.SignatureOperateurSurLeTerrain = CreateVisibleFromTemplate(template.SignatureOperateurSurLeTerrain);
            view.DetectionDesGazs = CreateVisibleFromTemplate(template.DetectionDesGazs);
            view.SignatureContremaitre = CreateVisibleFromTemplate(template.SignatureContremaitre);
            view.SignatureAutorise = CreateVisibleFromTemplate(template.SignatureAutorise);
            view.NettoyageTransfertHorsSite = CreateVisibleFromTemplate(template.NettoyageTransfertHorsSite);
        }

        
        private Visible<bool> CreateVisibleFromTemplate(TemplateState state)
        {
            if (state == TemplateState.Invisible)
            {
                return new Visible<bool>(VisibleState.Invisible, false);
            }
            return new Visible<bool>(VisibleState.Visible, state == TemplateState.Checked);
        }

        private Visible<TernaryString> CreateVisibleFromTemplate(TemplateState state, string value)
        {
            if (state == TemplateState.Invisible)
            {
                return new Visible<TernaryString>(VisibleState.Invisible, new TernaryString(false, null));
            }
            return new Visible<TernaryString>(VisibleState.Visible, new TernaryString(state == TemplateState.Checked, value));
        }


    }
}