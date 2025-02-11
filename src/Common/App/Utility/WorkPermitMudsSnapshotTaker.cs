﻿using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    public class WorkPermitMudsSnapshotTaker
    {
        private readonly WorkPermitMuds workPermitMuds;

        public WorkPermitMudsSnapshotTaker(WorkPermitMuds workPermitMuds)
        {
            this.workPermitMuds = workPermitMuds;
        }

        public WorkPermitMudsHistory CreateWorkPermitMudsHistorySnapshot()
        {
            var history = new WorkPermitMudsHistory(workPermitMuds.IdValue, workPermitMuds.LastModifiedBy,
                workPermitMuds.LastModifiedDateTime)
            {
                WorkPermitType = workPermitMuds.WorkPermitType,
                WorkPermitStatus = workPermitMuds.WorkPermitStatus,
                StartDateTime = workPermitMuds.StartDateTime,
                EndDateTime = workPermitMuds.EndDateTime,
                PermitNumber = workPermitMuds.PermitNumber,
                FunctionalLocations = workPermitMuds.FunctionalLocationsAsCommaSeparatedFullHierarchyList,
                Trade = workPermitMuds.Trade,
                Description = workPermitMuds.Description,
                IssuedDateTime = workPermitMuds.IssuedDateTime,


                RemplirLeFormulaireDeCondition = workPermitMuds.RemplirLeFormulaireDeCondition,
                AnalyseCritiqueDeLaTache = workPermitMuds.AnalyseCritiqueDeLaTache,
                Depressurises = workPermitMuds.Depressurises,
                Vides = workPermitMuds.Vides,
                ContournementDesGda = workPermitMuds.ContournementDesGda,
                Rinces = workPermitMuds.Rinces,
                NettoyesLaVapeur = workPermitMuds.NettoyesLaVapeur,
                Purges = workPermitMuds.Purges,
                Ventiles = workPermitMuds.Ventiles,
                Aeres = workPermitMuds.Aeres,
                Energies = workPermitMuds.Energies, // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                
                //Autres = workPermitMuds.Autres,
                ProcedureEntretien = workPermitMuds.ProcedureEntretien,
                AutresConditions = workPermitMuds.AutresConditions,
                InterrupteursEtVannesCadenasses = workPermitMuds.InterrupteursEtVannesCadenasses,
                VerrouillagesParTravailleurs = workPermitMuds.VerrouillagesParTravailleurs,
                SourcesDesenergisees = workPermitMuds.SourcesDesenergisees,
                DepartsLocauxTestes = workPermitMuds.DepartsLocauxTestes,
                ConduitesDesaccouplees = workPermitMuds.ConduitesDesaccouplees,
                ObturateursInstallees = workPermitMuds.ObturateursInstallees,
                EtiquettObturateur = workPermitMuds.Etiquette,
                PvciSuncorEffectuee = workPermitMuds.PvciSuncorEffectuee,
                PvciEntExtEffectuee = workPermitMuds.PvciEntExtEffectuee,
                Amiante = workPermitMuds.Amiante,
                AcideSulfurique = workPermitMuds.AcideSulfurique,
                Azote = workPermitMuds.Azote,
                Caustique = workPermitMuds.Caustique,
                DioxydeDeSoufre = workPermitMuds.DioxydeDeSoufre,
                Sbs = workPermitMuds.Sbs,
                Soufre = workPermitMuds.Soufre,
                EquipementsNonRinces = workPermitMuds.EquipementsNonRinces,
                Hydrocarbures = workPermitMuds.Hydrocarbures,
                HydrogeneSulfure = workPermitMuds.HydrogeneSulfure,
                MonoxydeCarbone = workPermitMuds.MonoxydeCarbone,
                Reflux = workPermitMuds.Reflux,
                ProduitsVolatilsUtilises = workPermitMuds.ProduitsVolatilsUtilises,
                Bacteries = workPermitMuds.Bacteries,
                Appareil = workPermitMuds.Appareil,
                InterferencesEntreTravaux = workPermitMuds.InterferencesEntreTravaux,
                PiecesEnRotation = workPermitMuds.PiecesEnRotation,
                IncendieExplosion = workPermitMuds.IncendieExplosion,
                ContrainteThermique = workPermitMuds.ContrainteThermique,
                Radiations = workPermitMuds.Radiations,
                Silice = workPermitMuds.Silice,
                Vanadium = workPermitMuds.Vanadium,
                AsphyxieIntoxication = workPermitMuds.AsphyxieIntoxication,
                AutresRisques = workPermitMuds.AutresRisques,
                ElectriciteVolt = workPermitMuds.ElectriciteVolt,
                TravailEnHauteur6EtPlus = workPermitMuds.TravailEnHauteur6EtPlus,
                VapeurCondensat = workPermitMuds.VapeurCondensat, // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

                FeSValue = workPermitMuds.FeSValue,
                
                WorkPermitCloseComments = workPermitMuds.WorkPermitCloseComments,
                
                Electrisation = workPermitMuds.Electrisation,
                LunettesMonocoques = workPermitMuds.LunettesMonocoques,
                Visiere = workPermitMuds.Visiere,
                ProtectionAuditive = workPermitMuds.ProtectionAuditive,
                //ManteauAntiEclaboussure = workPermitMuds.ManteauAntiEclaboussure,
                CagouleIgnifuge = workPermitMuds.CagouleIgnifuge,
                Harnais2LiensDeRetenue = workPermitMuds.Harnais2LiensDeRetenue,
                //MasqueAntiPoussiere = workPermitMuds.MasqueAntiPoussiere,
                //FiltresParticules = workPermitMuds.FiltresParticules,
                Gants = workPermitMuds.Gants,
                MasqueACartouches = workPermitMuds.MasqueACartouches,
                EpiAntiArcCat = workPermitMuds.EpiAntiArcCat,
                //HabitCompletAntiEclaboussure = workPermitMuds.HabitCompletAntiEclaboussure,
                //HabitCouvreToutJetable = workPermitMuds.HabitCouvreToutJetable,
                HabitProtecteurEquipementDeProtection = workPermitMuds.HabitProtecteur,
                EpiAntiChoc = workPermitMuds.EpiAntiChoc,
                //SystemeDAdductionDAir = workPermitMuds.SystemeDAdductionDAir,
                EcranDeflecteur = workPermitMuds.EcranDeflecteur,
                MaltDesEquipements = workPermitMuds.MaltDesEquipements,
                Rallonges = workPermitMuds.Rallonges,
                ApprobationPourEquipDeLevage = workPermitMuds.ApprobationPourEquipDeLevage,
                BarricadeRigide = workPermitMuds.BarricadeRigide,
                AutresE = workPermitMuds.AutresE,
                AlarmeDcs = workPermitMuds.AlarmeDcs,
                EchelleSecurisee = workPermitMuds.EchelleSecurisee,
                EchafaudageApprouve = workPermitMuds.EchafaudageApprouve,
                OutilDeLaiton = workPermitMuds.OutilDeLaiton,
                OutilDeLaitonManel = workPermitMuds.OutilManuelEquipementDePrevention,
                PerimetreDeSecurityEquipementDePrevention = workPermitMuds.PerimetreDeSecurityEquipementDePrevention,
                //PerimetreSecurite = workPermitMuds.PerimetreSecurite,
                Radio = workPermitMuds.Radio,
                Signaleur = workPermitMuds.Signaleur,

                InstructionsSpeciales = workPermitMuds.InstructionsSpeciales,
                SignatureOperateurSurLeTerrain = workPermitMuds.SignatureOperateurSurLeTerrain,
                DetectionDesGazs = workPermitMuds.DetectionDesGazs,
                SignatureContremaitre = workPermitMuds.SignatureContremaitre,
                SignatureAutorise = workPermitMuds.SignatureAutorise,
                NettoyageTransfertHorsSite = workPermitMuds.NettoyageTransfertHorsSite,

                // Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

            MudsAnswerTextBox = workPermitMuds.MudsAnswerTextBox,
            MudsQuestionlabel = workPermitMuds.MudsQuestionlabel,

                 Soudage =  workPermitMuds.Soudage,
            Traitement =  workPermitMuds.Traitement,
            Cuissons =  workPermitMuds.Cuissons,
            Perçage =  workPermitMuds.Perçage,
            Chaufferette =  workPermitMuds.Chaufferette,
            Meulage =  workPermitMuds.Meulage,
            Nettoyage =  workPermitMuds.Nettoyage,
            AutresTravaux =  workPermitMuds.AutresTravaux,
            TravauxDansZone =  workPermitMuds.TravauxDansZone,
            Combustibles =  workPermitMuds.Combustibles,
            Ecran =  workPermitMuds.Ecran,
            Boyau =  workPermitMuds.Boyau,
            BoyauDe =  workPermitMuds.BoyauDe,
            Couverture =  workPermitMuds.Couverture,
            Extincteur =  workPermitMuds.Extincteur,
            Bouche =  workPermitMuds.Bouche,
            RadioS =  workPermitMuds.RadioS,
            Surveillant =  workPermitMuds.Surveillant,
            UtilisationMoteur =  workPermitMuds.UtilisationMoteur,
            NettoyageAu =  workPermitMuds.NettoyageAu,
            UtilisationElectronics =  workPermitMuds.UtilisationElectronics,
            Radiographie =  workPermitMuds.Radiographie,
            UtilisationOutlis =  workPermitMuds.UtilisationOutlis,
            UtilisationEquipments =  workPermitMuds.UtilisationEquipments,
            Demolition =  workPermitMuds.Demolition,
            AutresInstruction =  workPermitMuds.AutresInstruction,

                DocumentLinks = workPermitMuds.DocumentLinks.AsString(link => link.TitleWithUrl),
                RequestedByGroup =
                    workPermitMuds.RequestedByGroup == null ? null : workPermitMuds.RequestedByGroup.Name,

                RequestedByGroupText = workPermitMuds.RequestedByGroupText
            };

            // Populate values on the history object from the actual work permit:

            if (workPermitMuds.Template != null) history.Template = workPermitMuds.Template.DisplayName;
            if (workPermitMuds.WorkOrderNumber.HasValue())
                history.WorkOrderNumber = workPermitMuds.WorkOrderNumber;

            AssignGasTests(history);

            return history;
        }

        private void AssignGasTests(WorkPermitMudsHistory history)
        {
            if (workPermitMuds.GasTests != null)
            {
                history.FirstResultTime = workPermitMuds.GasTests.GasTestFirstResultTime;
                history.ThirdResultTime = workPermitMuds.GasTests.GasTestSecondResultTime;
                history.FourthResultTime = workPermitMuds.GasTests.GasTestThirdResultTime;

                var gasTestElements = workPermitMuds.GasTests.Elements;
                history.GasTestElements = gasTestElements.AsString(gasTestElement => gasTestElement.ToHistoryStringForMuds());
            }
        }

    }
}