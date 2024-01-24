using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class WorkPermitMontrealHistoryDaoTest : AbstractDaoTest
    {
        private IWorkPermitMontrealHistoryDao workPermitMontrealHistoryDao;
        private IWorkPermitMontrealTemplateDao workPermitMontrealTemplateDao;
        private IUserDao userDao;
        const long fakeIdForTest = 1977;

        protected override void TestInitialize()
        {
            workPermitMontrealHistoryDao = DaoRegistry.GetDao<IWorkPermitMontrealHistoryDao>();
            workPermitMontrealTemplateDao = DaoRegistry.GetDao<IWorkPermitMontrealTemplateDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        protected override void Cleanup() { }

        [Ignore] [Test]
        public void ShouldInsertAWorkPermitMontrealHistoryEntry()
        {
            WorkPermitMontreal workPermitMontreal = WorkPermitMontrealFixture.CreateForInsert();
            workPermitMontreal.Id = fakeIdForTest;
            workPermitMontreal.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            workPermitMontreal.IssuedDateTime = new DateTime(2013, 1, 1, 13, 0, 0);

            WorkPermitMontrealTemplate workPermitMontrealTemplate = workPermitMontrealTemplateDao.QueryById(1);
            workPermitMontreal.Template = workPermitMontrealTemplate;

            WorkPermitMontrealSnapshotTaker snapshotTaker = new WorkPermitMontrealSnapshotTaker(workPermitMontreal);           
            WorkPermitMontrealHistory workPermitMontrealHistory = snapshotTaker.CreateWorkPermitMontrealHistorySnapshot();
            workPermitMontrealHistory.LastModifiedBy = userDao.QueryById(1);
            
            workPermitMontrealHistoryDao.Insert(workPermitMontrealHistory);

            List<WorkPermitMontrealHistory> workPermitMontrealHistories = workPermitMontrealHistoryDao.GetById(fakeIdForTest);
            Assert.AreEqual(1, workPermitMontrealHistories.Count);

            WorkPermitMontrealHistory queriedPermitMontrealHistory = workPermitMontrealHistories[0];

            Assert.AreEqual(workPermitMontrealHistory.Id, queriedPermitMontrealHistory.Id);
            Assert.AreEqual(workPermitMontrealHistory.WorkPermitType.Id, queriedPermitMontrealHistory.WorkPermitType.Id);
            Assert.AreEqual(workPermitMontrealHistory.Template, queriedPermitMontrealHistory.Template);
            Assert.AreEqual(workPermitMontrealHistory.WorkPermitStatus.Id, queriedPermitMontrealHistory.WorkPermitStatus.Id);
            Assert.That(workPermitMontrealHistory.StartDateTime, Is.EqualTo(queriedPermitMontrealHistory.StartDateTime).Within(TimeSpan.FromSeconds(10)));
            Assert.That(workPermitMontrealHistory.EndDateTime, Is.EqualTo(queriedPermitMontrealHistory.EndDateTime).Within(TimeSpan.FromSeconds(10)));
            Assert.AreEqual(workPermitMontrealHistory.PermitNumber, queriedPermitMontrealHistory.PermitNumber);
            Assert.AreEqual(workPermitMontrealHistory.WorkOrderNumber, queriedPermitMontrealHistory.WorkOrderNumber);
            Assert.AreEqual(workPermitMontrealHistory.FunctionalLocations, queriedPermitMontrealHistory.FunctionalLocations);
            Assert.AreEqual(workPermitMontrealHistory.Trade, queriedPermitMontrealHistory.Trade);
            Assert.AreEqual(workPermitMontrealHistory.Description, queriedPermitMontrealHistory.Description);
            Assert.That(workPermitMontrealHistory.LastModifiedDate, Is.EqualTo(queriedPermitMontrealHistory.LastModifiedDate).Within(TimeSpan.FromSeconds(10)));
            Assert.AreEqual(workPermitMontrealHistory.LastModifiedBy.Id, queriedPermitMontrealHistory.LastModifiedBy.Id);
            Assert.That(workPermitMontrealHistory.IssuedDateTime, Is.EqualTo(queriedPermitMontrealHistory.IssuedDateTime).Within(TimeSpan.FromSeconds(10)));
            Assert.AreEqual(workPermitMontrealHistory.H2S, queriedPermitMontrealHistory.H2S);
            Assert.AreEqual(workPermitMontrealHistory.Hydrocarbure, queriedPermitMontrealHistory.Hydrocarbure);
            Assert.AreEqual(workPermitMontrealHistory.Ammoniaque, queriedPermitMontrealHistory.Ammoniaque);
            Assert.AreEqual(workPermitMontrealHistory.Corrosif, queriedPermitMontrealHistory.Corrosif);
            Assert.AreEqual(workPermitMontrealHistory.Aromatique, queriedPermitMontrealHistory.Aromatique);
            Assert.AreEqual(workPermitMontrealHistory.AutresSubstances, queriedPermitMontrealHistory.AutresSubstances);
            Assert.AreEqual(workPermitMontrealHistory.ObtureOuDebranche, queriedPermitMontrealHistory.ObtureOuDebranche);
            Assert.AreEqual(workPermitMontrealHistory.DepressuriseEtVidange, queriedPermitMontrealHistory.DepressuriseEtVidange);
            Assert.AreEqual(workPermitMontrealHistory.EnPresenceDeGazInerte, queriedPermitMontrealHistory.EnPresenceDeGazInerte);
            Assert.AreEqual(workPermitMontrealHistory.PurgeALaVapeur, queriedPermitMontrealHistory.PurgeALaVapeur);
            Assert.AreEqual(workPermitMontrealHistory.RinceALeau, queriedPermitMontrealHistory.RinceALeau);
            Assert.AreEqual(workPermitMontrealHistory.Excavation, queriedPermitMontrealHistory.Excavation);
            Assert.AreEqual(workPermitMontrealHistory.DessinsRequis, queriedPermitMontrealHistory.DessinsRequis);
            Assert.AreEqual(workPermitMontrealHistory.CablesChauffantsMisHorsTension, queriedPermitMontrealHistory.CablesChauffantsMisHorsTension);
            Assert.AreEqual(workPermitMontrealHistory.PompeOuVerinPneumatique, queriedPermitMontrealHistory.PompeOuVerinPneumatique);
            Assert.AreEqual(workPermitMontrealHistory.ChaineEtCadenasseOuScelle, queriedPermitMontrealHistory.ChaineEtCadenasseOuScelle);
            Assert.AreEqual(workPermitMontrealHistory.InterrupteursElectriquesVerrouilles, queriedPermitMontrealHistory.InterrupteursElectriquesVerrouilles);
            Assert.AreEqual(workPermitMontrealHistory.PurgeParUnGazInerte, queriedPermitMontrealHistory.PurgeParUnGazInerte);
            Assert.AreEqual(workPermitMontrealHistory.OutilsElectriquesOuABatteries, queriedPermitMontrealHistory.OutilsElectriquesOuABatteries);
            Assert.AreEqual(workPermitMontrealHistory.BoiteEnergieZero, queriedPermitMontrealHistory.BoiteEnergieZero);
            Assert.AreEqual(workPermitMontrealHistory.OutilsPneumatiques, queriedPermitMontrealHistory.OutilsPneumatiques);
            Assert.AreEqual(workPermitMontrealHistory.MoteurACombustionInterne, queriedPermitMontrealHistory.MoteurACombustionInterne);
            Assert.AreEqual(workPermitMontrealHistory.TravauxSuperPoses, queriedPermitMontrealHistory.TravauxSuperPoses);
            Assert.AreEqual(workPermitMontrealHistory.FormulaireDespaceClosAffiche, queriedPermitMontrealHistory.FormulaireDespaceClosAffiche);
            Assert.AreEqual(workPermitMontrealHistory.ExisteIlUneAnalyseDeTache, queriedPermitMontrealHistory.ExisteIlUneAnalyseDeTache);
            Assert.AreEqual(workPermitMontrealHistory.PossibiliteDeSulfureDeFer, queriedPermitMontrealHistory.PossibiliteDeSulfureDeFer);
            Assert.AreEqual(workPermitMontrealHistory.AereVentile, queriedPermitMontrealHistory.AereVentile);
            Assert.AreEqual(workPermitMontrealHistory.SoudureALelectricite, queriedPermitMontrealHistory.SoudureALelectricite);
            Assert.AreEqual(workPermitMontrealHistory.BrulageAAcetylene, queriedPermitMontrealHistory.BrulageAAcetylene);
            Assert.AreEqual(workPermitMontrealHistory.Nacelle, queriedPermitMontrealHistory.Nacelle);
            Assert.AreEqual(workPermitMontrealHistory.AutreConditions, queriedPermitMontrealHistory.AutreConditions);
            Assert.AreEqual(workPermitMontrealHistory.LunettesMonocoques, queriedPermitMontrealHistory.LunettesMonocoques);
            Assert.AreEqual(workPermitMontrealHistory.HarnaisDeSecurite, queriedPermitMontrealHistory.HarnaisDeSecurite);
            Assert.AreEqual(workPermitMontrealHistory.EcranFacial, queriedPermitMontrealHistory.EcranFacial);
            Assert.AreEqual(workPermitMontrealHistory.ProtectionAuditive, queriedPermitMontrealHistory.ProtectionAuditive);
            Assert.AreEqual(workPermitMontrealHistory.Trepied, queriedPermitMontrealHistory.Trepied);
            Assert.AreEqual(workPermitMontrealHistory.DispositifAntichute, queriedPermitMontrealHistory.DispositifAntichute);
            Assert.AreEqual(workPermitMontrealHistory.ProtectionRespiratoire, queriedPermitMontrealHistory.ProtectionRespiratoire);
            Assert.AreEqual(workPermitMontrealHistory.Habits, queriedPermitMontrealHistory.Habits);
            Assert.AreEqual(workPermitMontrealHistory.AutreProtection, queriedPermitMontrealHistory.AutreProtection);
            Assert.AreEqual(workPermitMontrealHistory.Extincteur, queriedPermitMontrealHistory.Extincteur);
            Assert.AreEqual(workPermitMontrealHistory.BouchesDegoutProtegees, queriedPermitMontrealHistory.BouchesDegoutProtegees);
            Assert.AreEqual(workPermitMontrealHistory.CouvertureAntiEtincelles, queriedPermitMontrealHistory.CouvertureAntiEtincelles);
            Assert.AreEqual(workPermitMontrealHistory.SurveillantPouretincelles, queriedPermitMontrealHistory.SurveillantPouretincelles);
            Assert.AreEqual(workPermitMontrealHistory.PareEtincelles, queriedPermitMontrealHistory.PareEtincelles);
            Assert.AreEqual(workPermitMontrealHistory.MiseAlaTerrePresDuLieuDeTravail, queriedPermitMontrealHistory.MiseAlaTerrePresDuLieuDeTravail);
            Assert.AreEqual(workPermitMontrealHistory.BoyauAVapeur, queriedPermitMontrealHistory.BoyauAVapeur);
            Assert.AreEqual(workPermitMontrealHistory.AutresEquipementDincendie, queriedPermitMontrealHistory.AutresEquipementDincendie);
            Assert.AreEqual(workPermitMontrealHistory.Ventulateur, queriedPermitMontrealHistory.Ventulateur);
            Assert.AreEqual(workPermitMontrealHistory.Barrieres, queriedPermitMontrealHistory.Barrieres);
            Assert.AreEqual(workPermitMontrealHistory.Surveillant, queriedPermitMontrealHistory.Surveillant);
            Assert.AreEqual(workPermitMontrealHistory.RadioEmetteur, queriedPermitMontrealHistory.RadioEmetteur);
            Assert.AreEqual(workPermitMontrealHistory.PerimetreDeSecurite, queriedPermitMontrealHistory.PerimetreDeSecurite);
            Assert.AreEqual(workPermitMontrealHistory.DetectionContinueDesGaz, queriedPermitMontrealHistory.DetectionContinueDesGaz);
            Assert.AreEqual(workPermitMontrealHistory.KlaxonSonore, queriedPermitMontrealHistory.KlaxonSonore);
            Assert.AreEqual(workPermitMontrealHistory.Localiser, queriedPermitMontrealHistory.Localiser);
            Assert.AreEqual(workPermitMontrealHistory.Amiante, queriedPermitMontrealHistory.Amiante);
            Assert.AreEqual(workPermitMontrealHistory.AutreEquipementsSecurite, queriedPermitMontrealHistory.AutreEquipementsSecurite);
            Assert.AreEqual(workPermitMontrealHistory.InstructionsSpeciales, queriedPermitMontrealHistory.InstructionsSpeciales);
            Assert.AreEqual(workPermitMontrealHistory.SignatureOperateurSurLeTerrain, queriedPermitMontrealHistory.SignatureOperateurSurLeTerrain);
            Assert.AreEqual(workPermitMontrealHistory.DetectionDesGazs, queriedPermitMontrealHistory.DetectionDesGazs);
            Assert.AreEqual(workPermitMontrealHistory.SignatureContremaitre, queriedPermitMontrealHistory.SignatureContremaitre);
            Assert.AreEqual(workPermitMontrealHistory.SignatureAutorise, queriedPermitMontrealHistory.SignatureAutorise);
            Assert.AreEqual(workPermitMontrealHistory.NettoyageTransfertHorsSite, queriedPermitMontrealHistory.NettoyageTransfertHorsSite);
            Assert.AreEqual(workPermitMontrealHistory.DocumentLinks, queriedPermitMontrealHistory.DocumentLinks);
            Assert.AreEqual(workPermitMontrealHistory.RequestedByGroup, queriedPermitMontrealHistory.RequestedByGroup);
        }
    }
}