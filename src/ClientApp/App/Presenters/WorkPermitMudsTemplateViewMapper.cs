using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMudsTemplateViewMapper
    {
        private readonly IWorkPermitMudsFormView view;
        private readonly WorkPermitMudsTemplate template;


        public WorkPermitMudsTemplateViewMapper(IWorkPermitMudsFormView view, WorkPermitMudsTemplate template)
        {
            this.view = view;
            this.template = template;
        }

        public void MapTemplateToView()
        {
            if (template == null)
                return;
            
            view.RemplirLeFormulaireDeCondition = CreateVisibleFromTemplate(template.RemplirLeFormulaireDeCondition, template.RemplirLeFormulaireDeConditionValue);
            view.AnalyseCritiqueDeLaTache = CreateVisibleFromTemplate(template.AnalyseCritiqueDeLaTache);
            view.Depressurises = CreateVisibleFromTemplate(template.Depressurises);
            view.Vides = CreateVisibleFromTemplate(template.Vides);
            view.ContournementDesGda = CreateVisibleFromTemplate(template.ContournementDesGda);
            view.Rinces = CreateVisibleFromTemplate(template.Rinces);
            view.NettoyesLaVapeur = CreateVisibleFromTemplate(template.NettoyesLaVapeur);
            view.Purges = CreateVisibleFromTemplate(template.Purges);
            view.Ventiles = CreateVisibleFromTemplate(template.Ventiles);
            view.Aeres = CreateVisibleFromTemplate(template.Aeres);
            view.Energies = CreateVisibleFromTemplate(template.Energies); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            view.ProcedureEntretien = CreateVisibleFromTemplate(template.ProcedureEntretien, template.ProcedureEntretienValue);
            view.AutresConditions = CreateVisibleFromTemplate(template.AutresConditions, template.AutresConditionsValue);
            view.InterrupteursEtVannesCadenasses = CreateVisibleFromTemplate(template.InterrupteursEtVannesCadenasses, template.InterrupteursEtVannesCadenassesValue);
            view.VerrouillagesParTravailleurs = CreateVisibleFromTemplate(template.VerrouillagesParTravailleurs);
            view.SourcesDesenergisees = CreateVisibleFromTemplate(template.SourcesDesenergisees);
            view.DepartsLocauxTestes = CreateVisibleFromTemplate(template.DepartsLocauxTestes);
            view.ConduitesDesaccouplees = CreateVisibleFromTemplate(template.ConduitesDesaccouplees);
            view.ObturateursInstallees = CreateVisibleFromTemplate(template.ObturateursInstallees);
            view.EtiquettObturateur = CreateVisibleFromTemplate(template.EtiquettObturateur, template.EtiquettObturateurValue);
            view.PvciSuncorEffectuee = CreateVisibleFromTemplate(template.PvciSuncorEffectuee);
            view.PvciEntExtEffectuee = CreateVisibleFromTemplate(template.PvciEntExtEffectuee);
            view.Amiante = CreateVisibleFromTemplate(template.Amiante);
            view.AcideSulfurique = CreateVisibleFromTemplate(template.AcideSulfurique);
            view.Azote = CreateVisibleFromTemplate(template.Azote);
            view.Caustique = CreateVisibleFromTemplate(template.Caustique);
            view.DioxydeDeSoufre = CreateVisibleFromTemplate(template.DioxydeDeSoufre);
            view.Sbs = CreateVisibleFromTemplate(template.Sbs);
            view.Soufre = CreateVisibleFromTemplate(template.Soufre);
            view.EquipementsNonRinces = CreateVisibleFromTemplate(template.EquipementsNonRinces);
            view.Hydrocarbures = CreateVisibleFromTemplate(template.Hydrocarbures);
            view.HydrogeneSulfure = CreateVisibleFromTemplate(template.HydrogeneSulfure);
            view.MonoxydeCarbone = CreateVisibleFromTemplate(template.MonoxydeCarbone);
            view.Reflux = CreateVisibleFromTemplate(template.Reflux);
            view.ProduitsVolatilsUtilises = CreateVisibleFromTemplate(template.ProduitsVolatilsUtilises);
            view.Bacteries = CreateVisibleFromTemplate(template.Bacteries);
            view.AppareilEquipementDePrevention = CreateVisibleFromTemplate(template.AppareilEquipementDePrevention, template.AppareilEquipementDePreventionValue);
            view.InterferencesEntreTravaux = CreateVisibleFromTemplate(template.InterferencesEntreTravaux);
            view.PiecesEnRotation = CreateVisibleFromTemplate(template.PiecesEnRotation);
            view.IncendieExplosion = CreateVisibleFromTemplate(template.IncendieExplosion);
            view.EffondrementEnsevelissement = CreateVisibleFromTemplate(template.EffondrementEnsevelissement);
            view.ContrainteThermique = CreateVisibleFromTemplate(template.ContrainteThermique);
            view.Radiations = CreateVisibleFromTemplate(template.Radiations);
            view.Silice = CreateVisibleFromTemplate(template.Silice);
            view.Vanadium = CreateVisibleFromTemplate(template.Vanadium);
            view.AsphyxieIntoxication = CreateVisibleFromTemplate(template.AsphyxieIntoxication);
            view.AutresRisques = CreateVisibleFromTemplate(template.AutresRisques, template.AutresRisquesValue);
            //view.ElectronicVoltRisques = CreateVisibleFromTemplate(template.ElectronicVoltRisques, template.ElectronicVoltRisquesValue);
            view.OutilManuelEquipementDePrevention = CreateVisibleFromTemplate(template.OutilManuelEquipementDePrevention, template.OutilManuelEquipementDePreventionValue);
            view.ElectronicVoltRisques = CreateVisibleFromTemplate(template.ElectriciteVolt, template.ElectriciteVoltValue);
            view.OutilManuelEquipementDePrevention = CreateVisibleFromTemplate(template.OutilDeLaitonManel, template.OutilDeLaitonManelValue);
            view.TravailEnHauteur6EtPlus = CreateVisibleFromTemplate(template.TravailEnHauteur6EtPlus);

            view.AnalyseCritiqueDeLaTache = CreateVisibleFromTemplate(template.AnalyseCritiqueDeLaTache); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            view.ProcedureEntretien = CreateVisibleFromTemplate(template.ProcedureEntretien, template.ProcedureEntretienValue); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            view.VapeurCondensat = CreateVisibleFromTemplate(template.VapeurCondensat); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            view.FeSValue = CreateVisibleFromTemplate(template.FeSValue);
            


            view.Electrisation = CreateVisibleFromTemplate(template.Electrisation);
            view.LunettesMonocoques = CreateVisibleFromTemplate(template.LunettesMonocoques);
            view.Visiere = CreateVisibleFromTemplate(template.Visiere);
            view.ProtectionAuditive = CreateVisibleFromTemplate(template.ProtectionAuditive);
            view.CagouleIgnifuge = CreateVisibleFromTemplate(template.CagouleIgnifuge);
            view.Harnais2LiensDeRetenue = CreateVisibleFromTemplate(template.Harnais2LiensDeRetenue);
            view.AppareilEquipementDePrevention = CreateVisibleFromTemplate(template.AppareilEquipementDePrevention, template.AppareilEquipementDePreventionValue);
            view.GantsEquipementDeProtection = CreateVisibleFromTemplate(template.GantsEquipementDeProtection, template.GantsEquipementDeProtectionValue);
            //view.MasqueACartouches = CreateVisibleFromTemplate(template.MasqueACartouches, template.MasqueACartouchesValue);
            view.MasqueSoudeur = CreateVisibleFromTemplate(template.MasqueSoudeur);
            view.EpiAntiArcCatProtecteurEquipementDeProtection = CreateVisibleFromTemplate(template.EpiAntiArcCatProtecteurEquipementDeProtection, template.EpiAntiArcCatProtecteurEquipementDeProtectionValue);
            view.EpiAntiChoc = CreateVisibleFromTemplate(template.EpiAntiChoc);
            view.HabitProtecteurEquipementDeProtection = CreateVisibleFromTemplate(template.HabitProtecteurEquipementDeProtection, template.HabitProtecteurEquipementDeProtectionValue);
            view.EcranDeflecteur = CreateVisibleFromTemplate(template.EcranDeflecteur);
            view.MaltDesEquipements = CreateVisibleFromTemplate(template.MaltDesEquipements);
            view.Rallonges = CreateVisibleFromTemplate(template.Rallonges);
            view.ApprobationPourEquipDeLevage = CreateVisibleFromTemplate(template.ApprobationPourEquipDeLevage);
            view.BarricadeRigide = CreateVisibleFromTemplate(template.BarricadeRigide);
            view.AutresEquipementDePrevention = CreateVisibleFromTemplate(template.AutresEquipementDePrevention, template.AutresEquipementDePreventionValue);
            view.AlarmeDcs = CreateVisibleFromTemplate(template.AlarmeDcs, template.AlarmeDcsValue);
            view.EchelleSecurisee = CreateVisibleFromTemplate(template.EchelleSecurisee);
            view.EchafaudageApprouve = CreateVisibleFromTemplate(template.EchafaudageApprouve);
            view.OutilDeLaiton = CreateVisibleFromTemplate(template.OutilDeLaiton);
           // view.OutilManuelEquipementDePrevention = CreateVisibleFromTemplate(template.OutilManuelEquipementDePrevention, template.OutilManuelEquipementDePreventionValue);
            view.PerimetreDeSecurityEquipementDePrevention = CreateVisibleFromTemplate(template.PerimetreDeSecurityEquipementDePrevention, template.PerimetreDeSecurityEquipementDePreventionValue);
            view.Radio = CreateVisibleFromTemplate(template.Radio);

            view.OutilDeLaitonPrevention = CreateVisibleFromTemplate(template.OutilDeLaitonPrevention);
            
            view.Signaleur = CreateVisibleFromTemplate(template.Signaleur);
            view.InstructionsSpeciales = template.InstructionsSpeciales;
            view.SignatureOperateurSurLeTerrain = CreateVisibleFromTemplate(template.SignatureOperateurSurLeTerrain);
            view.DetectionDesGazs = CreateVisibleFromTemplate(template.DetectionDesGazs);
            view.SignatureContremaitre = CreateVisibleFromTemplate(template.SignatureContremaitre);
            view.SignatureAutorise = CreateVisibleFromTemplate(template.SignatureAutorise);
            view.NettoyageTransfertHorsSite = CreateVisibleFromTemplate(template.NettoyageTransfertHorsSite);

            view.Soudage = CreateVisibleFromTemplate(template.Soudage);
            view.Traitement = CreateVisibleFromTemplate(template.Traitement);
            view.Cuissons = CreateVisibleFromTemplate(template.Cuissons);
            view.Per�age = CreateVisibleFromTemplate(template.Per�age);
            view.Chaufferette = CreateVisibleFromTemplate(template.Chaufferette);
            view.Meulage = CreateVisibleFromTemplate(template.Meulage);
            view.Nettoyage = CreateVisibleFromTemplate(template.Nettoyage);
            view.AutresTravaux = CreateVisibleFromTemplate(template.AutresTravaux, template.AutresTravauxValue);
            view.TravauxDansZone = CreateVisibleFromTemplate(template.TravauxDansZone);
            view.Combustibles = CreateVisibleFromTemplate(template.Combustibles);
            view.Ecran = CreateVisibleFromTemplate(template.Ecran);
            view.Boyau = CreateVisibleFromTemplate(template.Boyau);
            view.BoyauDe = CreateVisibleFromTemplate(template.BoyauDe);
            view.Couverture = CreateVisibleFromTemplate(template.Couverture);
            view.Extincteur = CreateVisibleFromTemplate(template.Extincteur);
            view.Bouche = CreateVisibleFromTemplate(template.Bouche);
            view.RadioS = CreateVisibleFromTemplate(template.RadioS);
            view.Surveillant = CreateVisibleFromTemplate(template.Surveillant);
            view.UtilisationMoteur = CreateVisibleFromTemplate(template.UtilisationMoteur);
            view.NettoyageAu = CreateVisibleFromTemplate(template.NettoyageAu);
            view.UtilisationElectronics = CreateVisibleFromTemplate(template.UtilisationElectronics);
            view.Radiographie = CreateVisibleFromTemplate(template.Radiographie);
            view.UtilisationOutlis = CreateVisibleFromTemplate(template.UtilisationOutlis);
            //view.UtilisationEquipments = CreateVisibleFromTemplate(template.UtilisationEquipments);
            view.Demolition = CreateVisibleFromTemplate(template.Demolition);
            view.AutresInstruction = CreateVisibleFromTemplate(template.AutresInstruction,template.AutresInstructionValue);

            view.MhAutres = CreateVisibleFromTemplate(template.MhAutres);
            
            view.AppareilProtecteurEquipementDeProtection = CreateVisibleFromTemplate(template.AppareilProtecteurEquipementDeProtection, template.AppareilProtecteurEquipementDeProtectionValue);
           // view.AppareilProtecteurEquipementDeProtection = CreateVisibleFromTemplate(template.Appareil, template.AppareilValue);

          
            
        }

        private Visible<bool> CreateVisibleFromTemplate(TemplateStateMuds state)
        {
            if (state == TemplateStateMuds.Invisible)
            {
                return new Visible<bool>(VisibleState.Invisible, false);
            }
            return new Visible<bool>(VisibleState.Visible, state == TemplateStateMuds.Checked);
        }

        private Visible<TernaryString> CreateVisibleFromTemplate(TemplateStateMuds state, string value)
        {
            if (state == TemplateStateMuds.Invisible)
            {
                return new Visible<TernaryString>(VisibleState.Invisible, new TernaryString(false, null));
            }
            return new Visible<TernaryString>(VisibleState.Visible, new TernaryString(state == TemplateStateMuds.Checked, value));
        }


    }
}