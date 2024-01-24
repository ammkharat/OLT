using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    public class WorkPermitMontrealSnapshotTaker
    {
        private readonly WorkPermitMontreal workPermitMontreal;

        public WorkPermitMontrealSnapshotTaker(WorkPermitMontreal workPermitMontreal)
        {
            this.workPermitMontreal = workPermitMontreal;
        }

        public WorkPermitMontrealHistory CreateWorkPermitMontrealHistorySnapshot()
        {
            var history = new WorkPermitMontrealHistory(workPermitMontreal.IdValue, workPermitMontreal.LastModifiedBy,
                workPermitMontreal.LastModifiedDateTime)
            {
                WorkPermitType = workPermitMontreal.WorkPermitType,
                WorkPermitStatus = workPermitMontreal.WorkPermitStatus,
                StartDateTime = workPermitMontreal.StartDateTime,
                EndDateTime = workPermitMontreal.EndDateTime,
                PermitNumber = workPermitMontreal.PermitNumber,
                FunctionalLocations = workPermitMontreal.FunctionalLocationsAsCommaSeparatedFullHierarchyList,
                Trade = workPermitMontreal.Trade,
                Description = workPermitMontreal.Description,
                IssuedDateTime = workPermitMontreal.IssuedDateTime,
                H2S = workPermitMontreal.H2S,
                Hydrocarbure = workPermitMontreal.Hydrocarbure,
                Ammoniaque = workPermitMontreal.Ammoniaque,
                Corrosif = workPermitMontreal.Corrosif,
                Aromatique = workPermitMontreal.Aromatique,
                AutresSubstances = workPermitMontreal.AutresSubstances,
                ObtureOuDebranche = workPermitMontreal.ObtureOuDebranche,
                DepressuriseEtVidange = workPermitMontreal.DepressuriseEtVidange,
                EnPresenceDeGazInerte = workPermitMontreal.EnPresenceDeGazInerte,
                PurgeALaVapeur = workPermitMontreal.PurgeALaVapeur,
                RinceALeau = workPermitMontreal.RinceALeau,
                Excavation = workPermitMontreal.Excavation,
                DessinsRequis = workPermitMontreal.DessinsRequis,
                CablesChauffantsMisHorsTension = workPermitMontreal.CablesChauffantsMisHorsTension,
                PompeOuVerinPneumatique = workPermitMontreal.PompeOuVerinPneumatique,
                ChaineEtCadenasseOuScelle = workPermitMontreal.ChaineEtCadenasseOuScelle,
                InterrupteursElectriquesVerrouilles = workPermitMontreal.InterrupteursElectriquesVerrouilles,
                PurgeParUnGazInerte = workPermitMontreal.PurgeParUnGazInerte,
                OutilsElectriquesOuABatteries = workPermitMontreal.OutilsElectriquesOuABatteries,
                BoiteEnergieZero = workPermitMontreal.BoiteEnergieZero,
                OutilsPneumatiques = workPermitMontreal.OutilsPneumatiques,
                MoteurACombustionInterne = workPermitMontreal.MoteurACombustionInterne,
                TravauxSuperPoses = workPermitMontreal.TravauxSuperPoses,
                FormulaireDespaceClosAffiche = workPermitMontreal.FormulaireDespaceClosAffiche,
                ExisteIlUneAnalyseDeTache = workPermitMontreal.ExisteIlUneAnalyseDeTache,
                PossibiliteDeSulfureDeFer = workPermitMontreal.PossibiliteDeSulfureDeFer,
                AereVentile = workPermitMontreal.AereVentile,
                SoudureALelectricite = workPermitMontreal.SoudureALelectricite,
                BrulageAAcetylene = workPermitMontreal.BrulageAAcetylene,
                Nacelle = workPermitMontreal.Nacelle,
                AutreConditions = workPermitMontreal.AutreConditions,
                LunettesMonocoques = workPermitMontreal.LunettesMonocoques,
                HarnaisDeSecurite = workPermitMontreal.HarnaisDeSecurite,
                EcranFacial = workPermitMontreal.EcranFacial,
                ProtectionAuditive = workPermitMontreal.ProtectionAuditive,
                Trepied = workPermitMontreal.Trepied,
                DispositifAntichute = workPermitMontreal.DispositifAntichute,
                ProtectionRespiratoire = workPermitMontreal.ProtectionRespiratoire,
                Habits = workPermitMontreal.Habits,
                AutreProtection = workPermitMontreal.AutreProtection,
                Extincteur = workPermitMontreal.Extincteur,
                BouchesDegoutProtegees = workPermitMontreal.BouchesDegoutProtegees,
                CouvertureAntiEtincelles = workPermitMontreal.CouvertureAntiEtincelles,
                SurveillantPouretincelles = workPermitMontreal.SurveillantPouretincelles,
                PareEtincelles = workPermitMontreal.PareEtincelles,
                MiseAlaTerrePresDuLieuDeTravail = workPermitMontreal.MiseAlaTerrePresDuLieuDeTravail,
                BoyauAVapeur = workPermitMontreal.BoyauAVapeur,
                AutresEquipementDincendie = workPermitMontreal.AutresEquipementDincendie,
                Ventulateur = workPermitMontreal.Ventulateur,
                Barrieres = workPermitMontreal.Barrieres,
                Surveillant = workPermitMontreal.Surveillant,
                RadioEmetteur = workPermitMontreal.RadioEmetteur,
                PerimetreDeSecurite = workPermitMontreal.PerimetreDeSecurite,
                DetectionContinueDesGaz = workPermitMontreal.DetectionContinueDesGaz,
                KlaxonSonore = workPermitMontreal.KlaxonSonore,
                Localiser = workPermitMontreal.Localiser,
                Amiante = workPermitMontreal.Amiante,
                AutreEquipementsSecurite = workPermitMontreal.AutreEquipementsSecurite,
                InstructionsSpeciales = workPermitMontreal.InstructionsSpeciales,
                SignatureOperateurSurLeTerrain = workPermitMontreal.SignatureOperateurSurLeTerrain,
                DetectionDesGazs = workPermitMontreal.DetectionDesGazs,
                SignatureContremaitre = workPermitMontreal.SignatureContremaitre,
                SignatureAutorise = workPermitMontreal.SignatureAutorise,
                NettoyageTransfertHorsSite = workPermitMontreal.NettoyageTransfertHorsSite,
                DocumentLinks = workPermitMontreal.DocumentLinks.AsString(link => link.TitleWithUrl),
                RequestedByGroup =
                    workPermitMontreal.RequestedByGroup == null ? null : workPermitMontreal.RequestedByGroup.Name
            };

            // Populate values on the history object from the actual work permit:

            if (workPermitMontreal.Template != null) history.Template = workPermitMontreal.Template.DisplayName;
            if (workPermitMontreal.WorkOrderNumber.HasValue())
                history.WorkOrderNumber = workPermitMontreal.WorkOrderNumber;

            return history;
        }
    }
}