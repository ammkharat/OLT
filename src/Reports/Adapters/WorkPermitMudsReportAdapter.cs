﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class WorkPermitMudsReportAdapter : IReportAdapter
    {
        private const int MAX_FUNCTIONAL_LOCATIONS_LENGTH = 90;
        private const string ELLIPSIS = "...";

        public readonly WorkPermitMuds permit;
        private readonly WorkPermitMudsTemplate template;
        private readonly List<ConfinedSpaceMudsReportAdapter> confinedSpaceAdapters;

        public WorkPermitMudsReportAdapter(WorkPermitMuds permit)
        {
            this.permit = permit;
            template = permit.Template ?? WorkPermitMudsTemplate.NULL;
            

            ConfinedSpaceMudsReportAdapter adapter = new ConfinedSpaceMudsReportAdapter(permit.ConfinedSpace);
            //return new List<ConfinedSpaceMudsReportAdapter> { adapter };
            confinedSpaceAdapters = new List<ConfinedSpaceMudsReportAdapter> { adapter };
        }
        //DMND0010609-OLT - Edmonton Work permit Scan
        public string WorkpermitScanText
        { get; set; }
        public List<ConfinedSpaceMudsReportAdapter> ConfinedSpaceAdapters
        {
            get { return confinedSpaceAdapters; }
        }

        public string WaterMarkText { get; set; }

        public string PermitNumber
        {
            get { return permit.PermitNumber.HasValue ? permit.PermitNumber.ToString() : string.Empty; }
        }

        public ConfinedSpaceMuds ConfinedSpace
        {
            get { return permit.ConfinedSpace; }
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
            get { return TruncatedFunctionalLocations(permit.FunctionalLocations); }
        }

      
        public string Trade
        {
            get { return permit.Trade; }
        }

        public string NomsEntrepreneurs
        {
            get
            {
                string _nomsEntrepreneurs = string.Empty;
                string C1 = CompanyName + " (" + Noms_1 + ").  ";
                string C2 = CompanyName_1 + " (" + Noms_2 + ").  ";
                string C3 = CompanyName_2 + " (" + Noms_3 + ").";

                _nomsEntrepreneurs = C1 + " " + C2 + " " + C3;
                return _nomsEntrepreneurs;
            }
        }



        public string CompanyName
        {
            get { return permit.Company; }
        }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string CompanyName_1
        {
            get { return permit.Company_1; }
        }
        public string CompanyName_2
        {
            get { return permit.Company_2; }
        }

        public string NbTravail
        {
            get { return permit.NbTravail; }
        }

        public bool Formation
        {
            get { return permit.FormationCheck; }
        }

        public string Noms
        {
            get { return permit.NomsEnt; }
        }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string Noms_1
        {
            get { return permit.NomsEnt_1; }
        }
        public string Noms_2
        {
            get { return permit.NomsEnt_2; }
        }
        public string Noms_3
        {
            get { return permit.NomsEnt_3; }
        }

        public string Survelient
        {
            get { return permit.Surveilant; }
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
            get { return template.SignatureOperateurSurLeTerrain != TemplateStateMuds.Invisible; }
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

        public bool RemplirLeFormulaireDeCondition_Visible
        {
            get { return template.RemplirLeFormulaireDeCondition != TemplateStateMuds.Invisible; }
        }

        public bool RemplirLeFormulaireDeCondition_CheckBox
        {
            get { return permit.RemplirLeFormulaireDeCondition.StateAsBool; }
        }

        public string RemplirLeFormulaireDeCondition_Text
        {
            get { return permit.RemplirLeFormulaireDeCondition.Text; }
        }

        public bool AnalyseCritiqueDeLaTache_Visible
        {
            get { return template.AnalyseCritiqueDeLaTache != TemplateStateMuds.Invisible; }
        }

        public bool AnalyseCritiqueDeLaTache_CheckBox
        {
            get { return permit.AnalyseCritiqueDeLaTache; }
        }
        public bool Depressurises_Visible
        {
            get { return template.Depressurises != TemplateStateMuds.Invisible; }
        }

        public bool Depressurises_CheckBox
        {
            get { return permit.Depressurises; }
        }
        public bool Vides_Visible
        {
            get { return template.Vides != TemplateStateMuds.Invisible; }
        }

        public bool Vides_CheckBox
        {
            get { return permit.Vides; }
        }
        public bool ContournementDesGda_Visible
        {
            get { return template.ContournementDesGda != TemplateStateMuds.Invisible; }
        }

        public bool ContournementDesGda_CheckBox
        {
            get { return permit.ContournementDesGda; }
        }
        public bool Rinces_Visible
        {
            get { return template.Rinces != TemplateStateMuds.Invisible; }
        }

        public bool Rinces_CheckBox
        {
            get { return permit.Rinces; }
        }
        public bool NettoyesLaVapeur_Visible
        {
            get { return template.NettoyesLaVapeur != TemplateStateMuds.Invisible; }
        }

        public bool NettoyesLaVapeur_CheckBox
        {
            get { return permit.NettoyesLaVapeur; }
        }
        public bool Purges_Visible
        {
            get { return template.Purges != TemplateStateMuds.Invisible; }
        }

        public bool Purges_CheckBox
        {
            get { return permit.Purges; }
        }
        public bool Ventiles_Visible
        {
            get { return template.Ventiles != TemplateStateMuds.Invisible; }
        }

        public bool Ventiles_CheckBox
        {
            get { return permit.Ventiles; }
        }
        public bool Aeres_Visible
        {
            get { return template.Aeres != TemplateStateMuds.Invisible; }
        }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public bool Energies_Visible
        {
            get { return template.Energies != TemplateStateMuds.Invisible; }
        }
        

        public bool Aeres_CheckBox
        {
            get { return permit.Aeres; }
        }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public bool Energies_CheckBox
        {
            get { return permit.Energies; }
        }
        
        public bool Autres_Visible
        {
            get { return template.Autres != TemplateStateMuds.Invisible; }
        }

        public bool Autres_CheckBox
        {
            get { return permit.AutresCondition.StateAsBool; }
        }

        public string AutresC_Text
        {
            get { return permit.AutresCondition.Text; }
        }

        public bool InterrupteursEtVannesCadenasses_Visible
        {
            get { return template.InterrupteursEtVannesCadenasses != TemplateStateMuds.Invisible; }
        }

        public bool InterrupteursEtVannesCadenasses_CheckBox
        {
            get { return permit.InterrupteursEtVannesCadenasses.StateAsBool; }
        }

        public string InterrupteursEtVannesCadenasses_Text
        {
            get { return permit.InterrupteursEtVannesCadenasses.Text; }
        }

        public bool VerrouillagesParTravailleurs_Visible
        {
            get { return template.VerrouillagesParTravailleurs != TemplateStateMuds.Invisible; }
        }

        public bool VerrouillagesParTravailleurs_CheckBox
        {
            get { return permit.VerrouillagesParTravailleurs; }
        }
        public bool SourcesDesenergisees_Visible
        {
            get { return template.SourcesDesenergisees != TemplateStateMuds.Invisible; }
        }

        public bool SourcesDesenergisees_CheckBox
        {
            get { return permit.SourcesDesenergisees; }
        }
        public bool DepartsLocauxTestes_Visible
        {
            get { return template.DepartsLocauxTestes != TemplateStateMuds.Invisible; }
        }

        public bool DepartsLocauxTestes_CheckBox
        {
            get { return permit.DepartsLocauxTestes; }
        }
        public bool ConduitesDesaccouplees_Visible
        {
            get { return template.ConduitesDesaccouplees != TemplateStateMuds.Invisible; }
        }

        public bool ConduitesDesaccouplees_CheckBox
        {
            get { return permit.ConduitesDesaccouplees; }
        }
        public bool ObturateursInstallees_Visible
        {
            get { return template.ObturateursInstallees != TemplateStateMuds.Invisible; }
        }

        public bool ObturateursInstallees_CheckBox
        {
            get { return permit.ObturateursInstallees; }
        }
        public bool PvciSuncorEffectuee_Visible
        {
            get { return template.PvciSuncorEffectuee != TemplateStateMuds.Invisible; }
        }

        public bool PvciSuncorEffectuee_CheckBox
        {
            get { return permit.PvciSuncorEffectuee; }
        }
        public bool PvciEntExtEffectuee_Visible
        {
            get { return template.PvciEntExtEffectuee != TemplateStateMuds.Invisible; }
        }

        public bool PvciEntExtEffectuee_CheckBox
        {
            get { return permit.PvciEntExtEffectuee; }
        }
        public bool Amiante_Visible
        {
            get { return template.Amiante != TemplateStateMuds.Invisible; }
        }

        public bool Amiante_CheckBox
        {
            get { return permit.Amiante; }
        }
        public bool AcideSulfurique_Visible
        {
            get { return template.AcideSulfurique != TemplateStateMuds.Invisible; }
        }

        public bool AcideSulfurique_CheckBox
        {
            get { return permit.AcideSulfurique; }
        }
        public bool Azote_Visible
        {
            get { return template.Azote != TemplateStateMuds.Invisible; }
        }

        public bool Azote_CheckBox
        {
            get { return permit.Azote; }
        }
        public bool Caustique_Visible
        {
            get { return template.Caustique != TemplateStateMuds.Invisible; }
        }

        public bool Caustique_CheckBox
        {
            get { return permit.Caustique; }
        }
        public bool DioxydeDeSoufre_Visible
        {
            get { return template.DioxydeDeSoufre != TemplateStateMuds.Invisible; }
        }

        public bool DioxydeDeSoufre_CheckBox
        {
            get { return permit.DioxydeDeSoufre; }
        }
        public bool Sbs_Visible
        {
            get { return template.Sbs != TemplateStateMuds.Invisible; }
        }

        public bool Sbs_CheckBox
        {
            get { return permit.Sbs; }
        }
        public bool Soufre_Visible
        {
            get { return template.Soufre != TemplateStateMuds.Invisible; }
        }

        public bool Soufre_CheckBox
        {
            get { return permit.Soufre; }
        }
        public bool EquipementsNonRinces_Visible
        {
            get { return template.EquipementsNonRinces != TemplateStateMuds.Invisible; }
        }

        public bool EquipementsNonRinces_CheckBox
        {
            get { return permit.EquipementsNonRinces; }
        }
        public bool Hydrocarbures_Visible
        {
            get { return template.Hydrocarbures != TemplateStateMuds.Invisible; }
        }

        public bool Hydrocarbures_CheckBox
        {
            get { return permit.Hydrocarbures; }
        }
        public bool HydrogeneSulfure_Visible
        {
            get { return template.HydrogeneSulfure != TemplateStateMuds.Invisible; }
        }

        public bool HydrogeneSulfure_CheckBox
        {
            get { return permit.HydrogeneSulfure; }
        }
        public bool MonoxydeCarbone_Visible
        {
            get { return template.MonoxydeCarbone != TemplateStateMuds.Invisible; }
        }

        public bool MonoxydeCarbone_CheckBox
        {
            get { return permit.MonoxydeCarbone; }
        }
        public bool Reflux_Visible
        {
            get { return template.Reflux != TemplateStateMuds.Invisible; }
        }

        public bool Reflux_CheckBox
        {
            get { return permit.Reflux; }
        }
        public bool ProduitsVolatilsUtilises_Visible
        {
            get { return template.ProduitsVolatilsUtilises != TemplateStateMuds.Invisible; }
        }

        public bool ProduitsVolatilsUtilises_CheckBox
        {
            get { return permit.ProduitsVolatilsUtilises; }
        }
        public bool Bacteries_Visible
        {
            get { return template.Bacteries != TemplateStateMuds.Invisible; }
        }

        public bool Bacteries_CheckBox
        {
            get { return permit.Bacteries; }
        }
        public bool Appareil_Visible
        {
            get { return template.Appareil != TemplateStateMuds.Invisible; }
        }

        public bool Appareil_CheckBox
        {
            get { return permit.Appareil.StateAsBool; }
        }

        public string Appareil_Text
        {
            get { return permit.Appareil.Text; }
        }

        public bool InterferencesEntreTravaux_Visible
        {
            get { return template.InterferencesEntreTravaux != TemplateStateMuds.Invisible; }
        }

        public bool InterferencesEntreTravaux_CheckBox
        {
            get { return permit.InterferencesEntreTravaux; }
        }
        public bool PiecesEnRotation_Visible
        {
            get { return template.PiecesEnRotation != TemplateStateMuds.Invisible; }
        }

        public bool PiecesEnRotation_CheckBox
        {
            get { return permit.PiecesEnRotation; }
        }
        public bool IncendieExplosion_Visible
        {
            get { return template.IncendieExplosion != TemplateStateMuds.Invisible; }
        }

        public bool IncendieExplosion_CheckBox
        {
            get { return permit.IncendieExplosion; }
        }
        public bool ContrainteThermique_Visible
        {
            get { return template.ContrainteThermique != TemplateStateMuds.Invisible; }
        }

        public bool ContrainteThermique_CheckBox
        {
            get { return permit.ContrainteThermique; }
        }
        public bool Radiations_Visible
        {
            get { return template.Radiations != TemplateStateMuds.Invisible; }
        }

        public bool Radiations_CheckBox
        {
            get { return permit.Radiations; }
        }
        public bool Silice_Visible
        {
            get { return template.Silice != TemplateStateMuds.Invisible; }
        }

        public bool Silice_CheckBox
        {
            get { return permit.Silice; }
        }
        public bool Vanadium_Visible
        {
            get { return template.Vanadium != TemplateStateMuds.Invisible; }
        }

        public bool Vanadium_CheckBox
        {
            get { return permit.Vanadium; }
        }
        public bool AsphyxieIntoxication_Visible
        {
            get { return template.AsphyxieIntoxication != TemplateStateMuds.Invisible; }
        }

        public bool AsphyxieIntoxication_CheckBox
        {
            get { return permit.AsphyxieIntoxication; }
        }
        public bool AutresRisques_Visible
        {
            get { return template.AutresRisques != TemplateStateMuds.Invisible; }
        }

        public bool AutresRisques_CheckBox
        {
            get { return permit.AutresRisques.StateAsBool; }
        }

        public string AutresRisques_Text
        {
            get { return permit.AutresRisques.Text; }
        }

        public bool ElectriciteVolt_Visible
        {
            get { return template.ElectriciteVolt != TemplateStateMuds.Invisible; }
        }

        public bool ElectriciteVolt_CheckBox
        {
            get { return permit.ElectriciteVolt.StateAsBool; }
        }

        public string ElectriciteVolt_Text
        {
            get { return permit.ElectriciteVolt.Text; }
        }

        public bool TravailEnHauteur6EtPlus_Visible
        {
            get { return template.TravailEnHauteur6EtPlus != TemplateStateMuds.Invisible; }
        }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public bool VapeurCondensat_Visible
        {
            get { return template.VapeurCondensat != TemplateStateMuds.Invisible; }
        }
        
        public bool TravailEnHauteur6EtPlus_CheckBox
        {
            get { return permit.TravailEnHauteur6EtPlus; }
        }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public bool VapeurCondensat_CheckBox
        {
            get { return permit.VapeurCondensat; }
        }

        public bool FeSValue_CheckBox
        {
            get { return permit.FeSValue; }
        }

        
        
        public bool Electrisation_Visible
        {
            get { return template.Electrisation != TemplateStateMuds.Invisible; }
        }

        public bool Electrisation_CheckBox
        {
            get { return permit.Electrisation; }
        }
        public bool LunettesMonocoques_Visible
        {
            get { return template.LunettesMonocoques != TemplateStateMuds.Invisible; }
        }

        public bool LunettesMonocoques_CheckBox
        {
            get { return permit.LunettesMonocoques; }
        }
        public bool Visiere_Visible
        {
            get { return template.Visiere != TemplateStateMuds.Invisible; }
        }

        public bool Visiere_CheckBox
        {
            get { return permit.Visiere; }
        }
        public bool ProtectionAuditive_Visible
        {
            get { return template.ProtectionAuditive != TemplateStateMuds.Invisible; }
        }

        public bool ProtectionAuditive_CheckBox
        {
            get { return permit.ProtectionAuditive; }
        }
        public bool ManteauAntiEclaboussure_Visible
        {
            get { return template.ManteauAntiEclaboussure != TemplateStateMuds.Invisible; }
        }

        public bool ManteauAntiEclaboussure_CheckBox
        {
            get { return permit.ManteauAntiEclaboussure; }
        }
        public bool CagouleIgnifuge_Visible
        {
            get { return template.CagouleIgnifuge != TemplateStateMuds.Invisible; }
        }

        public bool CagouleIgnifuge_CheckBox
        {
            get { return permit.CagouleIgnifuge; }
        }
        public bool Harnais2LiensDeRetenue_Visible
        {
            get { return template.Harnais2LiensDeRetenue != TemplateStateMuds.Invisible; }
        }

        public bool Harnais2LiensDeRetenue_CheckBox
        {
            get { return permit.Harnais2LiensDeRetenue; }
        }
        public bool MasqueAntiPoussiere_Visible
        {
            get { return template.MasqueAntiPoussiere != TemplateStateMuds.Invisible; }
        }

        public bool MasqueAntiPoussiere_CheckBox
        {
            get { return permit.MasqueAntiPoussiere; }
        }
        public bool FiltresParticules_Visible
        {
            get { return template.FiltresParticules != TemplateStateMuds.Invisible; }
        }

        public bool FiltresParticules_CheckBox
        {
            get { return permit.FiltresParticules; }
        }
        public bool Gants_Visible
        {
            get { return template.Gants != TemplateStateMuds.Invisible; }
        }

        public bool Gants_CheckBox
        {
            get { return permit.Gants.StateAsBool; }
        }

        public string Gants_Text
        {
            get { return permit.Gants.Text; }
        }

        public bool MasqueACartouches_Visible
        {
            get { return template.MasqueACartouches != TemplateStateMuds.Invisible; }
        }

        public bool MasqueACartouches_CheckBox
        {
            get { return permit.MasqueACartouches.StateAsBool; }
        }

        public string MasqueACartouches_Text
        {
            get { return permit.MasqueACartouches.Text; }
        }

        public bool EpiAntiArcCat_Visible
        {
            get { return template.EpiAntiArcCat != TemplateStateMuds.Invisible; }
        }

        public bool EpiAntiArcCat_CheckBox
        {
            get { return permit.EpiAntiArcCat.StateAsBool; }
        }

        public string EpiAntiArcCat_Text
        {
            get { return permit.EpiAntiArcCat.Text; }
        }

        public bool HabitCompletAntiEclaboussure_Visible
        {
            get { return template.HabitCompletAntiEclaboussure != TemplateStateMuds.Invisible; }
        }

        public bool HabitCompletAntiEclaboussure_CheckBox
        {
            get { return permit.HabitProtecteur.StateAsBool; }
        }
        public bool HabitCouvreToutJetable_Visible
        {
            get { return template.HabitCouvreToutJetable != TemplateStateMuds.Invisible; }
        }

        public bool HabitCouvreToutJetable_CheckBox
        {
            get { return permit.HabitCouvreToutJetable; }
        }
        public bool EpiAntiChoc_Visible
        {
            get { return template.EpiAntiChoc != TemplateStateMuds.Invisible; }
        }

        public bool EpiAntiChoc_CheckBox
        {
            get { return permit.EpiAntiChoc; }
        }
        public bool SystemeDAdductionDAir_Visible
        {
            get { return template.SystemeDAdductionDAir != TemplateStateMuds.Invisible; }
        }

        public bool SystemeDAdductionDAir_CheckBox
        {
            get { return permit.SystemeDAdductionDAir; }
        }
        public bool EcranDeflecteur_Visible
        {
            get { return template.EcranDeflecteur != TemplateStateMuds.Invisible; }
        }

        public bool EcranDeflecteur_CheckBox
        {
            get { return permit.EcranDeflecteur; }
        }
        public bool MaltDesEquipements_Visible
        {
            get { return template.MaltDesEquipements != TemplateStateMuds.Invisible; }
        }

        public bool MaltDesEquipements_CheckBox
        {
            get { return permit.MaltDesEquipements; }
        }
        public bool Rallonges_Visible
        {
            get { return template.Rallonges != TemplateStateMuds.Invisible; }
        }

        public bool Rallonges_CheckBox
        {
            get { return permit.Rallonges; }
        }
        public bool ApprobationPourEquipDeLevage_Visible
        {
            get { return template.ApprobationPourEquipDeLevage != TemplateStateMuds.Invisible; }
        }

        public bool ApprobationPourEquipDeLevage_CheckBox
        {
            get { return permit.ApprobationPourEquipDeLevage; }
        }
        public bool BarricadeRigide_Visible
        {
            get { return template.BarricadeRigide != TemplateStateMuds.Invisible; }
        }

        public bool BarricadeRigide_CheckBox
        {
            get { return permit.BarricadeRigide; }
        }
        public bool AutresE_Visible
        {
            get { return template.AutresE != TemplateStateMuds.Invisible; }
        }

        public bool AutresE_CheckBox
        {
            get { return permit.AutresE.StateAsBool; }
        }

        public string AutresE_Text
        {
            get { return permit.AutresE.Text; }
        }

        public bool AlarmeDcs_Visible
        {
            get { return template.AlarmeDcs != TemplateStateMuds.Invisible; }
        }

        public bool AlarmeDcs_CheckBox
        {
            get { return permit.AlarmeDcs.StateAsBool; }
        }

        public string AlarmeDcs_Text
        {
            get { return permit.AlarmeDcs.Text; }
        }

        public bool EchelleSecurisee_Visible
        {
            get { return template.EchelleSecurisee != TemplateStateMuds.Invisible; }
        }

        public bool EchelleSecurisee_CheckBox
        {
            get { return permit.EchelleSecurisee; }
        }
        public bool EchafaudageApprouve_Visible
        {
            get { return template.EchafaudageApprouve != TemplateStateMuds.Invisible; }
        }

        public bool EchafaudageApprouve_CheckBox
        {
            get { return permit.EchafaudageApprouve; }
        }


        public bool OutilDeLaitonManel_CheckBox
        {
            get { return permit.OutilDeLaitonPrevention; }
        }


        public bool OutilDeLaiton_Visible
        {
            get { return template.OutilDeLaiton != TemplateStateMuds.Invisible; }
        }

        public bool OutilDeLaiton_CheckBox
        {
            get { return permit.OutilDeLaiton; }
        }
        public bool PerimetreSecurite_Visible
        {
            get { return template.PerimetreSecurite != TemplateStateMuds.Invisible; }
        }

        public bool PerimetreSecurite_CheckBox
        {
            get { return permit.PerimetreSecurite; }
        }

        public string PerimetreSecurite_Text
        {
            get { return permit.PerimetreDeSecurityEquipementDePrevention.Text; }
        }


        public bool Radio_Visible
        {
            get { return template.Radio != TemplateStateMuds.Invisible; }
        }

        public bool Radio_CheckBox
        {
            get { return permit.Radio; }
        }
        public bool Signaleur_Visible
        {
            get { return template.Signaleur != TemplateStateMuds.Invisible; }
        }

        public bool Signaleur_CheckBox
        {
            get { return permit.Signaleur; }
        }

        //-- Hot

        public bool Soudage_Visible
        {
            get { return template.Soudage != TemplateStateMuds.Invisible; }
        }

        public bool Soudage_CheckBox
        {
            get { return permit.Soudage; }
        }

        public bool Traitement_Visible
        {
            get { return template.Traitement != TemplateStateMuds.Invisible; }
        }

        public bool Traitement_CheckBox
        {
            get { return permit.Traitement; }
        }

        public bool Cuissons_Visible
        {
            get { return template.Cuissons != TemplateStateMuds.Invisible; }
        }

        public bool Cuissons_CheckBox
        {
            get { return permit.Cuissons; }
        }

        public bool Perçage_Visible
        {
            get { return template.Perçage != TemplateStateMuds.Invisible; }
        }

        public bool Perçage_CheckBox
        {
            get { return permit.Perçage; }
        }

        public bool Chaufferette_Visible
        {
            get { return template.Chaufferette != TemplateStateMuds.Invisible; }
        }

        public bool Chaufferette_CheckBox
        {
            get { return permit.Chaufferette; }
        }

        public bool Nettoyage_Visible
        {
            get { return template.Nettoyage != TemplateStateMuds.Invisible; }
        }

        public bool Nettoyage_CheckBox
        {
            get { return permit.Nettoyage; }
        }

        public bool Meulage_Visible
        {
            get { return template.Meulage != TemplateStateMuds.Invisible; }
        }

        public bool Meulage_CheckBox
        {
            get { return permit.Meulage; }
        }

        public bool AutresTravaux_Visible
        {
            get { return template.AutresTravaux != TemplateStateMuds.Invisible; }
        }

        public bool AutresTravaux_CheckBox
        {
            get { return permit.AutresTravaux.StateAsBool; }
        }

        public string AutresTravaux_Text
        {
            get { return permit.AutresTravaux.Text; }
        }

        public bool TravauxDansZone_Visible
        {
            get { return template.TravauxDansZone != TemplateStateMuds.Invisible; }
        }

        public bool TravauxDansZone_CheckBox
        {
            get { return permit.TravauxDansZone; }
        }

        public bool Combustibles_Visible
        {
            get { return template.Combustibles != TemplateStateMuds.Invisible; }
        }

        public bool Combustibles_CheckBox
        {
            get { return permit.Combustibles; }
        }

        public bool Ecran_Visible
        {
            get { return template.Ecran != TemplateStateMuds.Invisible; }
        }

        public bool Ecran_CheckBox
        {
            get { return permit.Ecran; }
        }

        public bool Boyau_Visible
        {
            get { return template.Boyau != TemplateStateMuds.Invisible; }
        }

        public bool Boyau_CheckBox
        {
            get { return permit.Boyau; }
        }

        public bool BoyauDe_Visible
        {
            get { return template.BoyauDe != TemplateStateMuds.Invisible; }
        }

        public bool BoyauDe_CheckBox
        {
            get { return permit.BoyauDe; }
        }

        public bool Couverture_Visible
        {
            get { return template.Couverture != TemplateStateMuds.Invisible; }
        }

        public bool Couverture_CheckBox
        {
            get { return permit.Couverture; }
        }

        public bool Extincteur_Visible
        {
            get { return template.Extincteur != TemplateStateMuds.Invisible; }
        }

        public bool Extincteur_CheckBox
        {
            get { return permit.Extincteur; }
        }

        public bool Bouche_Visible
        {
            get { return template.Bouche != TemplateStateMuds.Invisible; }
        }

        public bool Bouche_CheckBox
        {
            get { return permit.Bouche; }
        }

        public bool RadioS_Visible
        {
            get { return template.RadioS != TemplateStateMuds.Invisible; }
        }

        public bool RadioS_CheckBox
        {
            get { return permit.RadioS; }
        }

        public bool Surveillant_Visible
        {
            get { return template.Surveillant != TemplateStateMuds.Invisible; }
        }

        public bool Surveillant_CheckBox
        {
            get { return permit.Surveillant; }
        }


        //-- Mod and Cold

        public bool UtilisationMoteur_Visible
        {
            get { return template.UtilisationMoteur != TemplateStateMuds.Invisible; }
        }

        public bool UtilisationMoteur_CheckBox
        {
            get { return permit.UtilisationMoteur; }
        }

        public bool NettoyageAu_Visible
        {
            get { return template.NettoyageAu != TemplateStateMuds.Invisible; }
        }

        public bool NettoyageAu_CheckBox
        {
            get { return permit.NettoyageAu; }
        }

        public bool UtilisationElectronics_Visible
        {
            get { return template.UtilisationElectronics != TemplateStateMuds.Invisible; }
        }

        public bool UtilisationElectronics_CheckBox
        {
            get { return permit.UtilisationElectronics; }
        }

        public bool Radiographie_Visible
        {
            get { return template.Radiographie != TemplateStateMuds.Invisible; }
        }

        public bool Radiographie_CheckBox
        {
            get { return permit.Radiographie; }
        }

        public bool UtilisationOutlis_Visible
        {
            get { return template.UtilisationOutlis != TemplateStateMuds.Invisible; }
        }

        public bool UtilisationOutlis_CheckBox
        {
            get { return permit.UtilisationOutlis; }
        }
        
        public bool UtilisationEquipments_Visible
        {
            get { return template.UtilisationEquipments != TemplateStateMuds.Invisible; }
        }

        public bool UtilisationEquipments_CheckBox
        {
            get { return permit.UtilisationEquipments; }
        }

        public bool Demolition_Visible
        {
            get { return template.Demolition != TemplateStateMuds.Invisible; }
        }

        public bool Demolition_CheckBox
        {
            get { return permit.Demolition; }
        }

        public bool AutresInstruction_Visible
        {
            get { return template.AutresInstruction != TemplateStateMuds.Invisible; }
        }

        public bool AutresInstruction_CheckBox
        {
            get { return permit.AutresInstruction.StateAsBool; }
        }

        public string AutresInstruction_Text
        {
            get { return permit.AutresInstruction.Text; }
        }

        //--newly added

        public bool ProcédureEntretien_Visible
        {
            get { return template.ProcedureEntretien != TemplateStateMuds.Invisible; }
        }

        public bool ProcédureEntretien_CheckBox
        {
            get { return permit.ProcedureEntretien.StateAsBool; }
        }

        public string ProcédureEntretien_Text
        {
            get { return permit.ProcedureEntretien.Text; }
        }

        public bool EtiquettObturateur_Visible
        {
            get { return template.EtiquettObturateur != TemplateStateMuds.Invisible; }
        }

        public bool EtiquettObturateur_CheckBox
        {
            get { return permit.Etiquette.StateAsBool; }
        }

        public string EtiquettObturateur_Text
        {
            get { return permit.Etiquette.Text; }
        }

        public bool HabitProtecteurEquipementDeProtection_Visible
        {
            get { return template.HabitProtecteurEquipementDeProtection != TemplateStateMuds.Invisible; }
        }

        public bool HabitProtecteurEquipementDeProtection_CheckBox
        {
            get { return permit.HabitProtecteur.StateAsBool; }
        }

        public string HabitProtecteurEquipementDeProtection_Text
        {
            get { return permit.HabitProtecteur.Text; }
        }

        public bool MasqueSoudeur_Visible
        {
            get { return template.MasqueSoudeur != TemplateStateMuds.Invisible; }
        }

        public bool MasqueSoudeur_CheckBox
        {
            get { return permit.MasqueSoudeur; }
        }
        
        //--
        public bool OutillageElectrique_Visible
        {
            get { return template.OutillageElectrique != TemplateStateMuds.Invisible; }
        }

        public bool OutillageElectrique_CheckBox
        {
            get { return permit.OutillageElectrique; }
        }

        public bool EffondrementEnsevelissement_Visible
        {
            get { return template.EffondrementEnsevelissement != TemplateStateMuds.Invisible; }
        }

        public bool EffondrementEnsevelissement_CheckBox
        {
            get { return permit.EffondrementEnsevelissement; }
        }

        //public bool Masque_Visible
        //{
        //    get { return template.Masque != TemplateStateMuds.Invisible; }
        //}

        //public bool Masque_CheckBox
        //{
        //    get { return permit.Masque; }
        //}
        //--
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

        //Added for Workpermit Sign
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

        public string FirstGastestInitial { get; set; }
        public string SecondGastestInitial { get; set; }
        public string ThirdGastestInitial { get; set; }
        public string FourthGastestInitial { get; set; }

        public string LastModifiedUserName
        {

            get
            {
                if (permit.WorkPermitCloseComments !=null)
                {
                    return permit.WorkpermitClosedBy.Username;
                }
                else if (permit.ActionItemCheckboxchecked.HasValue.Equals(true) && permit.ActionItemCloseById !=0)
                {
                    return permit.ActionItemCloseBy.Username;
                }
                else
                {
                    return null;
                }
               

            }

            

          
        }

        public string LastModifiedDatetime
        {

            get
            {
                if (permit.WorkPermitCloseComments !=null)
                {

                    return permit.PermitCloseDateTime.ToString();
                }
                else
                {
                    return permit.ActionItemCloseDateTime.ToString();
                }
            }

        }

        public string UserFullName
        {

            get
            {
            //    if (permit.WorkPermitCloseComments != null)
            //    {
            //        return permit.WorkpermitClosedBy.FullName;
            //    }
            //    else if (permit.ActionItemCheckboxchecked.HasValue.Equals(true) && permit.ActionItemCloseById !=0)
            //    {
            //        return permit.ActionItemCloseBy.FullName;
            //    }
            //    else
            //    {
            //        return permit.Surveilant;
            //    }

                return permit.Surveilant;
            }
        }
      

    }

}