using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMudsTemplateFormPresenter : AddEditBaseFormPresenter<IWorkPermitMudsFormView, WorkPermitMudsTemplate>
    {
        private readonly IWorkPermitMudsTemplateService workPermitTemplateService;

        public WorkPermitMudsTemplateFormPresenter() : this(null)
        {
        }

        public WorkPermitMudsTemplateFormPresenter(WorkPermitMudsTemplate editObject) : base(new WorkPermitMudsForm(), editObject)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            workPermitTemplateService = clientServiceRegistry.GetService<IWorkPermitMudsTemplateService>();
            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.FormLoad += OnFormLoad;
        }

        private void OnFormLoad()
        {
            view.PutInTemplateMode();
            List<WorkPermitMudsType> workPermitTypes = new List<WorkPermitMudsType>(WorkPermitMudsType.All);
            workPermitTypes.Insert(0, WorkPermitMudsType.NULL);
            view.PermitTypes = workPermitTypes;
            
            if (IsEdit)
            {
                view.SelectedPermitType = editObject.WorkPermitType;
                view.SelectedPermitTemplateName = editObject.Name;
                

                new WorkPermitMudsTemplateViewMapper(view, editObject).MapTemplateToView();
            }
        }

        protected override bool ValidateViewHasError()
        {
            WorkPermitMudsValidator validator = new WorkPermitMudsValidator(view);
            validator.ValidateTemplateFormAndSetErrors(view);
            return validator.HasErrors;
        }

        protected override void Insert()
        {
            editObject = new WorkPermitMudsTemplate(0, view.SelectedPermitTemplateName, view.SelectedPermitType, true, false, WorkPermitMudsTemplate.NET_NEW_TEMPLATE); 
            UpdateEditObjectFromView();
            workPermitTemplateService.Insert(editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            
            // Insert new row with updated template data (keeping existing Template Number)
            workPermitTemplateService.Insert(editObject); 

            // Mark old Template as deleted
            workPermitTemplateService.Delete(editObject);
        }

        private void UpdateEditObjectFromView()
        {
            editObject.WorkPermitType = view.SelectedPermitType;
            editObject.Name = view.SelectedPermitTemplateName;

            editObject.RemplirLeFormulaireDeCondition = CreateTemplateStateFromVisible(view.RemplirLeFormulaireDeCondition);
            editObject.RemplirLeFormulaireDeConditionValue = CreateTemplateValueFromVisible(view.RemplirLeFormulaireDeCondition);
            editObject.AnalyseCritiqueDeLaTache = CreateTemplateStateFromVisible(view.AnalyseCritiqueDeLaTache);
            editObject.Depressurises = CreateTemplateStateFromVisible(view.Depressurises);
            editObject.Vides = CreateTemplateStateFromVisible(view.Vides);
            editObject.ContournementDesGda = CreateTemplateStateFromVisible(view.ContournementDesGda);
            editObject.Rinces = CreateTemplateStateFromVisible(view.Rinces);
            editObject.NettoyesLaVapeur = CreateTemplateStateFromVisible(view.NettoyesLaVapeur);
            editObject.Purges = CreateTemplateStateFromVisible(view.Purges);
            editObject.Ventiles = CreateTemplateStateFromVisible(view.Ventiles);
            editObject.Aeres = CreateTemplateStateFromVisible(view.Aeres);
            editObject.Energies = CreateTemplateStateFromVisible(view.Energies); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            editObject.ProcedureEntretien = CreateTemplateStateFromVisible(view.ProcedureEntretien);
            editObject.ProcedureEntretienValue = CreateTemplateValueFromVisible(view.ProcedureEntretien);
            editObject.AutresConditions = CreateTemplateStateFromVisible(view.AutresConditions);
            editObject.AutresConditionsValue = CreateTemplateValueFromVisible(view.AutresConditions);
            editObject.InterrupteursEtVannesCadenasses = CreateTemplateStateFromVisible(view.InterrupteursEtVannesCadenasses);
            editObject.InterrupteursEtVannesCadenassesValue = CreateTemplateValueFromVisible(view.InterrupteursEtVannesCadenasses);
            editObject.VerrouillagesParTravailleurs = CreateTemplateStateFromVisible(view.VerrouillagesParTravailleurs);
            editObject.SourcesDesenergisees = CreateTemplateStateFromVisible(view.SourcesDesenergisees);
            editObject.DepartsLocauxTestes = CreateTemplateStateFromVisible(view.DepartsLocauxTestes);
            editObject.ConduitesDesaccouplees = CreateTemplateStateFromVisible(view.ConduitesDesaccouplees);
            editObject.ObturateursInstallees = CreateTemplateStateFromVisible(view.ObturateursInstallees);
            editObject.EtiquettObturateur = CreateTemplateStateFromVisible(view.EtiquettObturateur);
            editObject.EtiquettObturateurValue = CreateTemplateValueFromVisible(view.EtiquettObturateur);
            editObject.PvciSuncorEffectuee = CreateTemplateStateFromVisible(view.PvciSuncorEffectuee);
            editObject.PvciEntExtEffectuee = CreateTemplateStateFromVisible(view.PvciEntExtEffectuee);
            editObject.Amiante = CreateTemplateStateFromVisible(view.Amiante);
            editObject.AcideSulfurique = CreateTemplateStateFromVisible(view.AcideSulfurique);
            editObject.Azote = CreateTemplateStateFromVisible(view.Azote);
            editObject.Caustique = CreateTemplateStateFromVisible(view.Caustique);
            editObject.DioxydeDeSoufre = CreateTemplateStateFromVisible(view.DioxydeDeSoufre);
            editObject.Sbs = CreateTemplateStateFromVisible(view.Sbs);
            editObject.Soufre = CreateTemplateStateFromVisible(view.Soufre);
            editObject.EquipementsNonRinces = CreateTemplateStateFromVisible(view.EquipementsNonRinces);
            editObject.Hydrocarbures = CreateTemplateStateFromVisible(view.Hydrocarbures);
            editObject.HydrogeneSulfure = CreateTemplateStateFromVisible(view.HydrogeneSulfure);
            editObject.MonoxydeCarbone = CreateTemplateStateFromVisible(view.MonoxydeCarbone);
            editObject.Reflux = CreateTemplateStateFromVisible(view.Reflux);
            editObject.ProduitsVolatilsUtilises = CreateTemplateStateFromVisible(view.ProduitsVolatilsUtilises);
            editObject.Bacteries = CreateTemplateStateFromVisible(view.Bacteries);
            editObject.AppareilEquipementDePrevention = CreateTemplateStateFromVisible(view.AppareilEquipementDePrevention);
            editObject.AppareilEquipementDePreventionValue = CreateTemplateValueFromVisible(view.AppareilEquipementDePrevention);
            editObject.AppareilProtecteurEquipementDeProtection = CreateTemplateStateFromVisible(view.AppareilProtecteurEquipementDeProtection);
            editObject.AppareilProtecteurEquipementDeProtectionValue = CreateTemplateValueFromVisible(view.AppareilProtecteurEquipementDeProtection);
            editObject.InterferencesEntreTravaux = CreateTemplateStateFromVisible(view.InterferencesEntreTravaux);
            editObject.PiecesEnRotation = CreateTemplateStateFromVisible(view.PiecesEnRotation);
            editObject.IncendieExplosion = CreateTemplateStateFromVisible(view.IncendieExplosion);
            editObject.ContrainteThermique = CreateTemplateStateFromVisible(view.ContrainteThermique);
            editObject.Radiations = CreateTemplateStateFromVisible(view.Radiations);
            editObject.Silice = CreateTemplateStateFromVisible(view.Silice);
            editObject.Vanadium = CreateTemplateStateFromVisible(view.Vanadium);
            editObject.AsphyxieIntoxication = CreateTemplateStateFromVisible(view.AsphyxieIntoxication);
            editObject.AutresRisques = CreateTemplateStateFromVisible(view.AutresRisques);
            editObject.AutresRisquesValue = CreateTemplateValueFromVisible(view.AutresRisques);
            //editObject.ElectriciteVolt = CreateTemplateStateFromVisible(view.ElectronicVoltRisques);
            //editObject.ElectriciteVoltValue = CreateTemplateValueFromVisible(view.ElectronicVoltRisques);
            editObject.ElectronicVoltRisques = CreateTemplateStateFromVisible(view.ElectronicVoltRisques);
            editObject.ElectronicVoltRisquesValue = CreateTemplateValueFromVisible(view.ElectronicVoltRisques);
           
            //editObject.OutillageElectrique = CreateTemplateStateFromVisible(view.OutillageElectrique);
            
           editObject.TravailEnHauteur6EtPlus = CreateTemplateStateFromVisible(view.TravailEnHauteur6EtPlus);

           editObject.AnalyseCritiqueDeLaTache = CreateTemplateStateFromVisible(view.AnalyseCritiqueDeLaTache); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
           editObject.ProcedureEntretien = CreateTemplateStateFromVisible(view.ProcedureEntretien);  // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

           editObject.VapeurCondensat = CreateTemplateStateFromVisible(view.VapeurCondensat); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

           editObject.FeSValue = CreateTemplateStateFromVisible(view.FeSValue);
            
            
            editObject.Electrisation = CreateTemplateStateFromVisible(view.Electrisation);
            editObject.LunettesMonocoques = CreateTemplateStateFromVisible(view.LunettesMonocoques);
            editObject.Visiere = CreateTemplateStateFromVisible(view.Visiere);
            editObject.ProtectionAuditive = CreateTemplateStateFromVisible(view.ProtectionAuditive);
            editObject.CagouleIgnifuge = CreateTemplateStateFromVisible(view.CagouleIgnifuge);
            editObject.Harnais2LiensDeRetenue = CreateTemplateStateFromVisible(view.Harnais2LiensDeRetenue);
            //editObject.Gants = CreateTemplateStateFromVisible(view.GantsEquipementDeProtection);
            //editObject.GantsValue = CreateTemplateValueFromVisible(view.GantsEquipementDeProtection);
            editObject.GantsEquipementDeProtection = CreateTemplateStateFromVisible(view.GantsEquipementDeProtection);
            editObject.GantsEquipementDeProtectionValue = CreateTemplateValueFromVisible(view.GantsEquipementDeProtection);

            //editObject.MasqueACartouches = CreateTemplateStateFromVisible(view.MasqueACartouches);
            //editObject.MasqueACartouchesValue = CreateTemplateValueFromVisible(view.MasqueACartouches);
            
            //editObject.EpiAntiArcCat = CreateTemplateStateFromVisible(view.EpiAntiArcCatProtecteurEquipementDeProtection);
            //editObject.EpiAntiArcCatValue = CreateTemplateValueFromVisible(view.EpiAntiArcCatProtecteurEquipementDeProtection);
            editObject.EpiAntiArcCatProtecteurEquipementDeProtection = CreateTemplateStateFromVisible(view.EpiAntiArcCatProtecteurEquipementDeProtection);
            editObject.EpiAntiArcCatProtecteurEquipementDeProtectionValue = CreateTemplateValueFromVisible(view.EpiAntiArcCatProtecteurEquipementDeProtection);
            editObject.EpiAntiChoc = CreateTemplateStateFromVisible(view.EpiAntiChoc);
            editObject.HabitProtecteurEquipementDeProtection = CreateTemplateStateFromVisible(view.HabitProtecteurEquipementDeProtection);
            editObject.HabitProtecteurEquipementDeProtectionValue = CreateTemplateValueFromVisible(view.HabitProtecteurEquipementDeProtection);
            editObject.EcranDeflecteur = CreateTemplateStateFromVisible(view.EcranDeflecteur);
            editObject.MaltDesEquipements = CreateTemplateStateFromVisible(view.MaltDesEquipements);
            editObject.Rallonges = CreateTemplateStateFromVisible(view.Rallonges);
            editObject.ApprobationPourEquipDeLevage = CreateTemplateStateFromVisible(view.ApprobationPourEquipDeLevage);
            editObject.BarricadeRigide = CreateTemplateStateFromVisible(view.BarricadeRigide);
            //editObject.AutresE = CreateTemplateStateFromVisible(view.AutresEquipementDePrevention);
            //editObject.AutresEValue = CreateTemplateValueFromVisible(view.AutresEquipementDePrevention);
            editObject.AutresEquipementDePrevention = CreateTemplateStateFromVisible(view.AutresEquipementDePrevention);
            editObject.AutresEquipementDePreventionValue = CreateTemplateValueFromVisible(view.AutresEquipementDePrevention);
            editObject.AlarmeDcs = CreateTemplateStateFromVisible(view.AlarmeDcs);
            editObject.AlarmeDcsValue = CreateTemplateValueFromVisible(view.AlarmeDcs);
            editObject.EchelleSecurisee = CreateTemplateStateFromVisible(view.EchelleSecurisee);
            editObject.EchafaudageApprouve = CreateTemplateStateFromVisible(view.EchafaudageApprouve);
            editObject.OutilDeLaiton = CreateTemplateStateFromVisible(view.OutilDeLaiton);

            editObject.OutilDeLaitonPrevention = CreateTemplateStateFromVisible(view.OutilDeLaitonPrevention);

            //editObject.OutilDeLaitonManel = CreateTemplateStateFromVisible(view.OutilManuelEquipementDePrevention);
            //editObject.OutilDeLaitonManelValue = CreateTemplateValueFromVisible(view.OutilManuelEquipementDePrevention);
            editObject.OutilManuelEquipementDePrevention = CreateTemplateStateFromVisible(view.OutilManuelEquipementDePrevention);
            editObject.OutilManuelEquipementDePreventionValue = CreateTemplateValueFromVisible(view.OutilManuelEquipementDePrevention);

            //editObject.PerimetreSecurite = CreateTemplateStateFromVisible(view.PerimetreDeSecurityEquipementDePrevention);
            editObject.PerimetreDeSecurityEquipementDePrevention = CreateTemplateStateFromVisible(view.PerimetreDeSecurityEquipementDePrevention);
            editObject.PerimetreDeSecurityEquipementDePreventionValue = CreateTemplateValueFromVisible(view.PerimetreDeSecurityEquipementDePrevention);

            editObject.Radio = CreateTemplateStateFromVisible(view.Radio);

            editObject.Signaleur = CreateTemplateStateFromVisible(view.Signaleur);
            editObject.InstructionsSpeciales = view.InstructionsSpeciales;
            editObject.SignatureOperateurSurLeTerrain = CreateTemplateStateFromVisible(view.SignatureOperateurSurLeTerrain);
            editObject.DetectionDesGazs = CreateTemplateStateFromVisible(view.DetectionDesGazs);
            editObject.SignatureContremaitre = CreateTemplateStateFromVisible(view.SignatureContremaitre);
            editObject.SignatureAutorise = CreateTemplateStateFromVisible(view.SignatureAutorise);
            editObject.NettoyageTransfertHorsSite = CreateTemplateStateFromVisible(view.NettoyageTransfertHorsSite);

            editObject.Soudage = CreateTemplateStateFromVisible(view.Soudage);
            editObject.Traitement = CreateTemplateStateFromVisible(view.Traitement);
            editObject.Cuissons = CreateTemplateStateFromVisible(view.Cuissons);
            editObject.Perçage = CreateTemplateStateFromVisible(view.Perçage);
            editObject.Chaufferette = CreateTemplateStateFromVisible(view.Chaufferette);
            editObject.Meulage = CreateTemplateStateFromVisible(view.Meulage);
            editObject.Nettoyage = CreateTemplateStateFromVisible(view.Nettoyage);
            editObject.AutresTravaux = CreateTemplateStateFromVisible(view.AutresTravaux);
            editObject.AutresTravauxValue = CreateTemplateValueFromVisible(view.AutresTravaux);
            editObject.TravauxDansZone = CreateTemplateStateFromVisible(view.TravauxDansZone);
            editObject.Combustibles = CreateTemplateStateFromVisible(view.Combustibles);
            editObject.Ecran = CreateTemplateStateFromVisible(view.Ecran);
            editObject.Boyau = CreateTemplateStateFromVisible(view.Boyau);
            editObject.BoyauDe = CreateTemplateStateFromVisible(view.BoyauDe);
            editObject.Couverture = CreateTemplateStateFromVisible(view.Couverture);
            editObject.Extincteur = CreateTemplateStateFromVisible(view.Extincteur);
            editObject.Bouche = CreateTemplateStateFromVisible(view.Bouche);
            editObject.RadioS = CreateTemplateStateFromVisible(view.RadioS);
            editObject.Surveillant = CreateTemplateStateFromVisible(view.Surveillant);
            editObject.UtilisationMoteur = CreateTemplateStateFromVisible(view.UtilisationMoteur);
            editObject.NettoyageAu = CreateTemplateStateFromVisible(view.NettoyageAu);
            editObject.UtilisationElectronics = CreateTemplateStateFromVisible(view.UtilisationElectronics);
            editObject.Radiographie = CreateTemplateStateFromVisible(view.Radiographie);
            editObject.UtilisationOutlis = CreateTemplateStateFromVisible(view.UtilisationOutlis);
            //editObject.UtilisationEquipments = CreateTemplateStateFromVisible(view.UtilisationEquipments);
            editObject.Demolition = CreateTemplateStateFromVisible(view.Demolition);
            editObject.MhAutres  = CreateTemplateStateFromVisible(view.MhAutres);
            editObject.AutresInstruction = CreateTemplateStateFromVisible(view.AutresInstruction);
            editObject.AutresInstructionValue = CreateTemplateValueFromVisible(view.AutresInstruction);
            
            editObject.MhAutres = CreateTemplateStateFromVisible(view.MhAutres);
            editObject.EffondrementEnsevelissement = CreateTemplateStateFromVisible(view.EffondrementEnsevelissement);
            editObject.MasqueSoudeur = CreateTemplateStateFromVisible(view.MasqueSoudeur);
            

            //##########################
            //editObject.RemplirLeFormulaireDeCondition = CreateTemplateStateFromVisible(view.RemplirLeFormulaireDeCondition);
            //editObject.InterrupteursEtVannesCadenasses = CreateTemplateStateFromVisible(view.InterrupteursEtVannesCadenasses);
            ////editObject.Appareil = CreateTemplateStateFromVisible(view.Appareil);
            //editObject.AutresRisques = CreateTemplateStateFromVisible(view.AutresRisques);
            ////editObject.ElectriciteVolt = CreateTemplateStateFromVisible(view.ElectriciteVolt);
            ////editObject.Gants = CreateTemplateStateFromVisible(view.Gants);
            ////editObject.MasqueACartouches = CreateTemplateStateFromVisible(view.MasqueACartouches);
            ////editObject.EpiAntiArcCat = CreateTemplateStateFromVisible(view.EpiAntiArcCat);
            ////editObject.Autres = CreateTemplateStateFromVisible(view.Autres);
            //editObject.AlarmeDcs = CreateTemplateStateFromVisible(view.AlarmeDcs);

            //editObject.RemplirLeFormulaireDeConditionValue = CreateTemplateValueFromVisible(view.RemplirLeFormulaireDeCondition);
            //editObject.InterrupteursEtVannesCadenassesValue = CreateTemplateValueFromVisible(view.InterrupteursEtVannesCadenasses);
            ////editObject.AppareilValue = CreateTemplateValueFromVisible(view.Appareil);
            //editObject.AutresRisquesValue = CreateTemplateValueFromVisible(view.AutresRisques);
            ////editObject.ElectriciteVoltValue = CreateTemplateValueFromVisible(view.ElectriciteVolt);
            ////editObject.GantsValue = CreateTemplateValueFromVisible(view.Gants);
            ////editObject.MasqueACartouchesValue = CreateTemplateValueFromVisible(view.MasqueACartouches);
            ////editObject.EpiAntiArcCatValue = CreateTemplateValueFromVisible(view.EpiAntiArcCat);
            ////editObject.AutresEValue = CreateTemplateValueFromVisible(view.AutresE);
            //editObject.AlarmeDcsValue = CreateTemplateValueFromVisible(view.AlarmeDcs);

            //editObject.AnalyseCritiqueDeLaTache = CreateTemplateStateFromVisible(view.AnalyseCritiqueDeLaTache);
            //editObject.Depressurises = CreateTemplateStateFromVisible(view.Depressurises);
            //editObject.Vides = CreateTemplateStateFromVisible(view.Vides);
            //editObject.ContournementDesGda = CreateTemplateStateFromVisible(view.ContournementDesGda);
            //editObject.Rinces = CreateTemplateStateFromVisible(view.Rinces);
            //editObject.NettoyesLaVapeur = CreateTemplateStateFromVisible(view.NettoyesLaVapeur);
            //editObject.Purges = CreateTemplateStateFromVisible(view.Purges);
            //editObject.Ventiles = CreateTemplateStateFromVisible(view.Ventiles);
            //editObject.Aeres = CreateTemplateStateFromVisible(view.Aeres);
            //editObject.VerrouillagesParTravailleurs = CreateTemplateStateFromVisible(view.VerrouillagesParTravailleurs);
            //editObject.SourcesDesenergisees = CreateTemplateStateFromVisible(view.SourcesDesenergisees);
            //editObject.DepartsLocauxTestes = CreateTemplateStateFromVisible(view.DepartsLocauxTestes);
            //editObject.ConduitesDesaccouplees = CreateTemplateStateFromVisible(view.ConduitesDesaccouplees);
            //editObject.ObturateursInstallees = CreateTemplateStateFromVisible(view.ObturateursInstallees);
            //editObject.PvciSuncorEffectuee = CreateTemplateStateFromVisible(view.PvciSuncorEffectuee);
            //editObject.PvciEntExtEffectuee = CreateTemplateStateFromVisible(view.PvciEntExtEffectuee);
            //editObject.Amiante = CreateTemplateStateFromVisible(view.Amiante);
            //editObject.AcideSulfurique = CreateTemplateStateFromVisible(view.AcideSulfurique);
            //editObject.Azote = CreateTemplateStateFromVisible(view.Azote);
            //editObject.Caustique = CreateTemplateStateFromVisible(view.Caustique);
            //editObject.DioxydeDeSoufre = CreateTemplateStateFromVisible(view.DioxydeDeSoufre);
            //editObject.Sbs = CreateTemplateStateFromVisible(view.Sbs);
            //editObject.Soufre = CreateTemplateStateFromVisible(view.Soufre);
            //editObject.EquipementsNonRinces = CreateTemplateStateFromVisible(view.EquipementsNonRinces);
            //editObject.Hydrocarbures = CreateTemplateStateFromVisible(view.Hydrocarbures);
            //editObject.HydrogeneSulfure = CreateTemplateStateFromVisible(view.HydrogeneSulfure);
            //editObject.MonoxydeCarbone = CreateTemplateStateFromVisible(view.MonoxydeCarbone);
            //editObject.Reflux = CreateTemplateStateFromVisible(view.Reflux);
            //editObject.ProduitsVolatilsUtilises = CreateTemplateStateFromVisible(view.ProduitsVolatilsUtilises);
            //editObject.Bacteries = CreateTemplateStateFromVisible(view.Bacteries);
            //editObject.InterferencesEntreTravaux = CreateTemplateStateFromVisible(view.InterferencesEntreTravaux);
            //editObject.PiecesEnRotation = CreateTemplateStateFromVisible(view.PiecesEnRotation);
            //editObject.IncendieExplosion = CreateTemplateStateFromVisible(view.IncendieExplosion);
            //editObject.ContrainteThermique = CreateTemplateStateFromVisible(view.ContrainteThermique);
            //editObject.Radiations = CreateTemplateStateFromVisible(view.Radiations);
            //editObject.Silice = CreateTemplateStateFromVisible(view.Silice);
            //editObject.Vanadium = CreateTemplateStateFromVisible(view.Vanadium);
            //editObject.AsphyxieIntoxication = CreateTemplateStateFromVisible(view.AsphyxieIntoxication);
            //editObject.TravailEnHauteur6EtPlus = CreateTemplateStateFromVisible(view.TravailEnHauteur6EtPlus);
            //editObject.Electrisation = CreateTemplateStateFromVisible(view.Electrisation);
            //editObject.LunettesMonocoques = CreateTemplateStateFromVisible(view.LunettesMonocoques);
            //editObject.Visiere = CreateTemplateStateFromVisible(view.Visiere);
            //editObject.ProtectionAuditive = CreateTemplateStateFromVisible(view.ProtectionAuditive);
            ////editObject.ManteauAntiEclaboussure = CreateTemplateStateFromVisible(view.ManteauAntiEclaboussure);
            //editObject.CagouleIgnifuge = CreateTemplateStateFromVisible(view.CagouleIgnifuge);
            //editObject.Harnais2LiensDeRetenue = CreateTemplateStateFromVisible(view.Harnais2LiensDeRetenue);
            ////editObject.MasqueAntiPoussiere = CreateTemplateStateFromVisible(view.MasqueAntiPoussiere);
            ////editObject.FiltresParticules = CreateTemplateStateFromVisible(view.FiltresParticules);
            ////editObject.HabitCompletAntiEclaboussure = CreateTemplateStateFromVisible(view.HabitCompletAntiEclaboussure);
            ////editObject.HabitCouvreToutJetable = CreateTemplateStateFromVisible(view.HabitCouvreToutJetable);
            //editObject.EpiAntiChoc = CreateTemplateStateFromVisible(view.EpiAntiChoc);
            ////editObject.SystemeDAdductionDAir = CreateTemplateStateFromVisible(view.SystemeDAdductionDAir);
            //editObject.EcranDeflecteur = CreateTemplateStateFromVisible(view.EcranDeflecteur);
            //editObject.MaltDesEquipements = CreateTemplateStateFromVisible(view.MaltDesEquipements);
            //editObject.Rallonges = CreateTemplateStateFromVisible(view.Rallonges);
            //editObject.ApprobationPourEquipDeLevage = CreateTemplateStateFromVisible(view.ApprobationPourEquipDeLevage);
            //editObject.BarricadeRigide = CreateTemplateStateFromVisible(view.BarricadeRigide);
            ////editObject.AutresE = CreateTemplateStateFromVisible(view.AutresE);
            //editObject.EchelleSecurisee = CreateTemplateStateFromVisible(view.EchelleSecurisee);
            //editObject.EchafaudageApprouve = CreateTemplateStateFromVisible(view.EchafaudageApprouve);
            ////editObject.OutilDeLaiton = CreateTemplateStateFromVisible(view.OutilDeLaiton);
            ////editObject.PerimetreSecurite = CreateTemplateStateFromVisible(view.PerimetreSecurite);
            //editObject.Radio = CreateTemplateStateFromVisible(view.Radio);
            //editObject.Signaleur = CreateTemplateStateFromVisible(view.Signaleur);
            
            //editObject.InstructionsSpeciales = view.InstructionsSpeciales;
            //editObject.SignatureOperateurSurLeTerrain = CreateTemplateStateFromVisible(view.SignatureOperateurSurLeTerrain);
            //editObject.DetectionDesGazs = CreateTemplateStateFromVisible(view.DetectionDesGazs);
            //editObject.SignatureContremaitre = CreateTemplateStateFromVisible(view.SignatureContremaitre);
            //editObject.SignatureAutorise = CreateTemplateStateFromVisible(view.SignatureAutorise);
            //editObject.NettoyageTransfertHorsSite = CreateTemplateStateFromVisible(view.NettoyageTransfertHorsSite);

            //editObject.AutresConditions = CreateTemplateStateFromVisible(view.AutresConditions);
            //editObject.AutresConditionsValue = CreateTemplateValueFromVisible(view.AutresConditions);

            //editObject.AutresRisques = CreateTemplateStateFromVisible(view.AutresRisques);
            //editObject.AutresRisquesValue = CreateTemplateValueFromVisible(view.AutresRisques);

            //editObject.ElectronicVoltRisques = CreateTemplateStateFromVisible(view.ElectronicVoltRisques);
            //editObject.ElectronicVoltRisquesValue = CreateTemplateValueFromVisible(view.ElectronicVoltRisques);

            //editObject.GantsEquipementDeProtection = CreateTemplateStateFromVisible(view.GantsEquipementDeProtection);
            //editObject.GantsEquipementDeProtectionValue = CreateTemplateValueFromVisible(view.GantsEquipementDeProtection);

            //editObject.HabitProtecteurEquipementDeProtection = CreateTemplateStateFromVisible(view.HabitProtecteurEquipementDeProtection);
            //editObject.HabitProtecteurEquipementDeProtectionValue = CreateTemplateValueFromVisible(view.HabitProtecteurEquipementDeProtection);

            //editObject.EpiAntiArcCatProtecteurEquipementDeProtection = CreateTemplateStateFromVisible(view.EpiAntiArcCatProtecteurEquipementDeProtection);
            //editObject.EpiAntiArcCatProtecteurEquipementDeProtectionValue = CreateTemplateValueFromVisible(view.EpiAntiArcCatProtecteurEquipementDeProtection);

            //editObject.AppareilProtecteurEquipementDeProtection = CreateTemplateStateFromVisible(view.AppareilProtecteurEquipementDeProtection);
            //editObject.AppareilProtecteurEquipementDeProtectionValue = CreateTemplateValueFromVisible(view.AppareilProtecteurEquipementDeProtection);

            //editObject.AutresEquipementDePrevention = CreateTemplateStateFromVisible(view.AutresEquipementDePrevention);
            //editObject.AutresEquipementDePreventionValue = CreateTemplateValueFromVisible(view.AutresEquipementDePrevention);

            //editObject.OutilManuelEquipementDePrevention = CreateTemplateStateFromVisible(view.OutilManuelEquipementDePrevention);
            //editObject.OutilManuelEquipementDePreventionValue = CreateTemplateValueFromVisible(view.OutilManuelEquipementDePrevention);

            //editObject.PerimetreDeSecurityEquipementDePrevention = CreateTemplateStateFromVisible(view.PerimetreDeSecurityEquipementDePrevention);
            //editObject.PerimetreDeSecurityEquipementDePreventionValue = CreateTemplateValueFromVisible(view.PerimetreDeSecurityEquipementDePrevention);

            //editObject.AppareilEquipementDePrevention = CreateTemplateStateFromVisible(view.AppareilEquipementDePrevention);
            //editObject.AppareilEquipementDePreventionValue = CreateTemplateValueFromVisible(view.AppareilEquipementDePrevention);

            //editObject.AutresTravaux = CreateTemplateStateFromVisible(view.AutresTravaux);
            //editObject.AutresTravauxValue = CreateTemplateValueFromVisible(view.AutresTravaux);
            
        }

        private string CreateTemplateValueFromVisible(Visible<TernaryString> visibleTernaryString)
        {
            if (visibleTernaryString.VisibleState == VisibleState.Visible && visibleTernaryString.Value.StateAsBool)
            {
                return visibleTernaryString.Value.Text;
            }
            return null;
        }

        private TemplateStateMuds CreateTemplateStateFromVisible(Visible<TernaryString> visibleValue)
        {
            if (visibleValue.VisibleState == VisibleState.Invisible)
            {
                return TemplateStateMuds.Invisible;
            }
            if (visibleValue.VisibleState == VisibleState.Visible && visibleValue.Value.StateAsBool)
            {
                return TemplateStateMuds.Checked;
            }
            return TemplateStateMuds.Default;
        }

        private TemplateStateMuds CreateTemplateStateFromVisible(Visible<bool> visibleValue)
        {
            if (visibleValue.VisibleState == VisibleState.Invisible)
            {
                return TemplateStateMuds.Invisible;
            }
            if (visibleValue.VisibleState == VisibleState.Visible && visibleValue.Value)
            {
                return TemplateStateMuds.Checked;
            }
            return TemplateStateMuds.Default;
        }
    }
}