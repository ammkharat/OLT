﻿using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitMuds : ModifiableDomainObject, IFunctionalLocationRelevant, IDocumentLinksObject
    {
        private List<PermitAttribute> attributes = new List<PermitAttribute>();

        /// <summary>
        ///     For creating a Work Permit from a Work Order
        /// </summary>
        public WorkPermitMuds(DataSource dataSource, PermitRequestBasedWorkPermitStatus workPermitStatus,
            WorkPermitMudsType workPermitType, WorkPermitMudsTemplate template, DateTime startDateTime,
            DateTime endDateTime, List<FunctionalLocation> functionalLocations, string workOrderNumber, string trade,
            string description, DateTime createdDateTime, User createdBy, DateTime lastModifiedDateTime,
            User lastModifiedUser, WorkPermitMudsGroup requestedByGroup, DateTime? issuedDateTime, string requestedByGroupText,
            string nbTravail, bool formationCheck, string nomsEnt, string nomsEnt_1, string nomsEnt_2, string nomsEnt_3, string surveilant) // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        {
            DataSource = dataSource;
            WorkPermitStatus = workPermitStatus;
            WorkPermitType = workPermitType;

            Template = template ?? WorkPermitMudsTemplate.NULL;
            RequestedByGroup = requestedByGroup;

            RequestedByGroupText = requestedByGroupText;

            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            FunctionalLocations = functionalLocations;
            WorkOrderNumber = workOrderNumber;
            Trade = trade;
            Description = description;

            NbTravail = nbTravail;
            FormationCheck = formationCheck;
            NomsEnt = nomsEnt;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            NomsEnt_1 = nomsEnt_1;
            NomsEnt_2 = nomsEnt_2;
            NomsEnt_3 = nomsEnt_3;

            Surveilant = surveilant;


            RemplirLeFormulaireDeCondition = new TernaryString(false, null);
            InterrupteursEtVannesCadenasses = new TernaryString(false, null);
            Appareil = new TernaryString(false, null);
            ElectriciteVolt = new TernaryString(false, null);
            Gants = new TernaryString(false, null);
            MasqueACartouches = new TernaryString(false, null);
            EpiAntiArcCat = new TernaryString(false, null);
            AlarmeDcs = new TernaryString(false, null);
            AutresE = new TernaryString(false, null);

            AutresConditions = new TernaryString(false, null);
            AutresRisques = new TernaryString(false, null);
            ElectronicVoltRisques = new TernaryString(false, null);
            GantsEquipementDeProtection = new TernaryString(false, null);
            HabitProtecteurEquipementDeProtection = new TernaryString(false, null);
            EpiAntiArcCatProtecteurEquipementDeProtection = new TernaryString(false, null);
            AppareilProtecteurEquipementDeProtection = new TernaryString(false, null);
            AutresEquipementDePrevention = new TernaryString(false, null);
            OutilManuelEquipementDePrevention = new TernaryString(false, null);
            PerimetreDeSecurityEquipementDePrevention = new TernaryString(false, null);
            AppareilEquipementDePrevention = new TernaryString(false, null);
            AutresTravaux = new TernaryString(false, null);
            AutresInstruction = new TernaryString(false,null);

            Procedure = new TernaryString(false, null);
            AutresCondition = new TernaryString(false, null);
            Etiquette = new TernaryString(false, null);
            HabitProtecteur = new TernaryString(false, null);
            AutresInstructionValue = new TernaryString(false, null);
            ProcedureEntretien = new TernaryString(false, null);
            EtiquettObturateur = new TernaryString(false, null);

            MasqueACartouches = new TernaryString(false, null);

            CreatedDateTime = createdDateTime;
            CreatedBy = createdBy;

            LastModifiedDateTime = lastModifiedDateTime;
            LastModifiedBy = lastModifiedUser;

            DocumentLinks = new List<DocumentLink>();
            IssuedDateTime = issuedDateTime;
        }



        public WorkPermitMuds(long id, long? permitNumber, DataSource dataSource,
            PermitRequestBasedWorkPermitStatus workPermitStatus, WorkPermitMudsType workPermitType,
            WorkPermitMudsTemplate template, DateTime startDateTime, DateTime endDateTime,
            List<FunctionalLocation> functionalLocations, string workOrderNumber, string trade, string description,
            DateTime createdDateTime, User createdBy, DateTime lastModifiedDateTime, User lastModifiedUser,
            WorkPermitMudsGroup requestedByGroup, DateTime? issuedDateTime, string requestedByGroupText,
            string nbTravail, bool formationCheck, string nomsEnt, string nomsEnt_1, string nomsEnt_2, string nomsEnt_3, string surveilant)
            : this(
                dataSource, workPermitStatus, workPermitType, template, startDateTime, endDateTime, functionalLocations,
                trade,
                trade, description, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedUser, requestedByGroup,
                issuedDateTime, requestedByGroupText,
            nbTravail, formationCheck, nomsEnt,nomsEnt_1,nomsEnt_2,nomsEnt_3, surveilant)
        {
            Id = id;
            PermitNumber = permitNumber;
            WorkOrderNumber = workOrderNumber;

            NbTravail = nbTravail;
            FormationCheck = formationCheck;
            NomsEnt = nomsEnt;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            NomsEnt_1 = nomsEnt_1;
            NomsEnt_2 = nomsEnt_2;
            NomsEnt_3 = nomsEnt_3;
            Surveilant = surveilant;
        }
//Added by ppanigrahi
        public WorkPermitMuds(long id, long? permitNumber, DataSource dataSource,
           PermitRequestBasedWorkPermitStatus workPermitStatus, WorkPermitMudsType workPermitType,
           WorkPermitMudsTemplate template, DateTime startDateTime, DateTime endDateTime,
           List<FunctionalLocation> functionalLocations, string workOrderNumber, string trade, string description,
           DateTime createdDateTime, User createdBy, DateTime lastModifiedDateTime, User lastModifiedUser,
           WorkPermitMudsGroup requestedByGroup, DateTime? issuedDateTime, string requestedByGroupText,
           string nbTravail, bool formationCheck, string nomsEnt, string nomsEnt_1, string nomsEnt_2, string nomsEnt_3, string surveilant,string WorkPermitCloseComment, long WorkpermitClosedById, User WorkpermitClosedBy, long ActionItemCloseById, User ActionItemCloseBy, DateTime? PermitCloseDateTime, DateTime? ActionItemCloseDateTime, bool? ActionItemCheckboxchecked)
            : this(
                dataSource, workPermitStatus, workPermitType, template, startDateTime, endDateTime, functionalLocations,
                trade,
                trade, description, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedUser, requestedByGroup,
                issuedDateTime, requestedByGroupText,
            nbTravail, formationCheck, nomsEnt, nomsEnt_1, nomsEnt_2, nomsEnt_3, surveilant)
        {
            Id = id;
            PermitNumber = permitNumber;
            WorkOrderNumber = workOrderNumber;

            NbTravail = nbTravail;
            FormationCheck = formationCheck;
            NomsEnt = nomsEnt;
            // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            NomsEnt_1 = nomsEnt_1;
            NomsEnt_2 = nomsEnt_2;
            NomsEnt_3 = nomsEnt_3;
            Surveilant = surveilant;
            this.PermitCloseDateTime = PermitCloseDateTime;
            this.WorkpermitClosedById = WorkpermitClosedById;
            this.ActionItemCloseById = ActionItemCloseById;
            this.ActionItemCloseBy = ActionItemCloseBy;
            this.ActionItemCloseDateTime = ActionItemCloseDateTime;
            this.WorkpermitClosedBy = WorkpermitClosedBy;
            this.WorkPermitCloseComments = WorkPermitCloseComment;
            this.ActionItemCheckboxchecked = ActionItemCheckboxchecked;
        }
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
 public WorkPermitMuds(string templatename, string categories)
        {
            _templateName = templatename;
            _categories = categories;
        }        
        
        public string ClonedFormDetailMuds { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History
        public bool UsePreviousPermitAnswered { get; set; }
        public DataSource DataSource { get; private set; }
        public PermitRequestBasedWorkPermitStatus WorkPermitStatus { get; set; }
        public WorkPermitMudsType WorkPermitType { get; set; }
        public DateTime StartDateTime { get;  set; }
        public DateTime EndDateTime { get;  set; }
        public List<FunctionalLocation> FunctionalLocations { get; private set; }
        public string WorkOrderNumber { get; private set; }
        public long? PermitNumber { get; set; }
        public string Trade { get; private set; }
        public string Description { get; private set; }

        public string NbTravail { get; set; }
        public bool FormationCheck { get; set; }
        public string NomsEnt { get; set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string NomsEnt_1 { get; set; }
        public string NomsEnt_2 { get; set; }
        public string NomsEnt_3 { get; set; }
        public string Surveilant { get; set; }

        public DateTime CreatedDateTime { get; private set; }
        public User CreatedBy { get; private set; }

        public ConfinedSpaceMuds ConfinedSpace { get; set; }

        public WorkPermitMudsTemplate Template { get; set; }
        public WorkPermitMudsGroup RequestedByGroup { get; set; }

        public string RequestedByGroupText { get; set; }

        public DateTime? IssuedDateTime { get; set; }

        public string FunctionalLocationsAsCommaSeparatedFullHierarchyList
        {
            get { return FunctionalLocations.FullHierarchyListToString(true, false); }
        }

        public string InstructionsSpeciales { get; set; }
        public bool SignatureOperateurSurLeTerrain { get; set; }
        public bool DetectionDesGazs { get; set; }
        public bool SignatureContremaitre { get; set; }
        public bool SignatureAutorise { get; set; }
        public bool NettoyageTransfertHorsSite { get; set; }

        public DateTime? RequestedDateTime { get; set; }
        public User RequestedByUser { get; set; }
        public string Company { get; set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string Company_1 { get; set; }
        public string Company_2 { get; set; }
        public string Supervisor { get; set; }
        public string ExcavationNumber { get; set; }

        public List<PermitAttribute> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }


        public TernaryString RemplirLeFormulaireDeCondition { get; set; }
        public TernaryString InterrupteursEtVannesCadenasses { get; set; }
        public TernaryString Appareil { get; set; }
        //public TernaryString AutresRisques { get; set; }
        public TernaryString ElectriciteVolt { get; set; }
        public TernaryString Gants { get; set; }
        public TernaryString EpiAntiArcCat { get; set; }
        public TernaryString AlarmeDcs { get; set; }
        public TernaryString AutresE { get; set; }
        public TernaryString MasqueACartouches { get; set; }

        public bool Autres { get; set; }
        public bool AnalyseCritiqueDeLaTache { get; set; }
        public bool Depressurises { get; set; }
        public bool Vides { get; set; }
        public bool ContournementDesGda { get; set; }
        public bool Rinces { get; set; }
        public bool NettoyesLaVapeur { get; set; }
        public bool Purges { get; set; }
        public bool Ventiles { get; set; }
        public bool Aeres { get; set; }
        public bool Energies { get; set; } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        
        public bool VerrouillagesParTravailleurs { get; set; }
        public bool SourcesDesenergisees { get; set; }
        public bool DepartsLocauxTestes { get; set; }
        public bool ConduitesDesaccouplees { get; set; }
        public bool ObturateursInstallees { get; set; }
        public bool PvciSuncorEffectuee { get; set; }
        public bool PvciEntExtEffectuee { get; set; }
        public bool Amiante { get; set; }
        public bool AcideSulfurique { get; set; }
        public bool Azote { get; set; }
        public bool Caustique { get; set; }
        public bool DioxydeDeSoufre { get; set; }
        public bool Sbs { get; set; }
        public bool Soufre { get; set; }
        public bool EquipementsNonRinces { get; set; }
        public bool Hydrocarbures { get; set; }
        public bool HydrogeneSulfure { get; set; }
        public bool MonoxydeCarbone { get; set; }
        public bool Reflux { get; set; }
        public bool ProduitsVolatilsUtilises { get; set; }
        public bool Bacteries { get; set; }
        public bool InterferencesEntreTravaux { get; set; }
        public bool PiecesEnRotation { get; set; }
        public bool IncendieExplosion { get; set; }
        public bool ContrainteThermique { get; set; }
        public bool Radiations { get; set; }
        public bool Silice { get; set; }
        public bool Vanadium { get; set; }
        public bool AsphyxieIntoxication { get; set; }
        public bool TravailEnHauteur6EtPlus { get; set; }
        public bool VapeurCondensat { get; set; } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        public bool FeSValue { get; set; } 
        
        
        public bool Electrisation { get; set; }
        public bool LunettesMonocoques { get; set; }
        public bool Visiere { get; set; }
        public bool ProtectionAuditive { get; set; }
        public bool ManteauAntiEclaboussure { get; set; }
        public bool CagouleIgnifuge { get; set; }
        public bool Harnais2LiensDeRetenue { get; set; }
        public bool MasqueAntiPoussiere { get; set; }
        public bool FiltresParticules { get; set; }
        public bool HabitCompletAntiEclaboussure { get; set; }
        public bool HabitCouvreToutJetable { get; set; }
        public bool EpiAntiChoc { get; set; }
        public bool SystemeDAdductionDAir { get; set; }
        public bool EcranDeflecteur { get; set; }
        public bool MaltDesEquipements { get; set; }
        public bool Rallonges { get; set; }
        public bool ApprobationPourEquipDeLevage { get; set; }
        public bool BarricadeRigide { get; set; }
        public bool EchelleSecurisee { get; set; }
        public bool EchafaudageApprouve { get; set; }
        public bool OutilDeLaiton { get; set; } // Taken for Outillage électrique/ à batterie: OutillageElectriqueBooleanControl
        public bool PerimetreSecurite { get; set; }
        public bool Radio { get; set; }
        public bool Signaleur { get; set; }

        public bool OutilDeLaitonPrevention { get; set; }

        public TernaryString AutresConditions { get; set; }
        public TernaryString AutresRisques { get; set; }
        public TernaryString ElectronicVoltRisques { get; set; }
        public TernaryString GantsEquipementDeProtection { get; set; }
        public TernaryString HabitProtecteurEquipementDeProtection { get; set; }
        public TernaryString EpiAntiArcCatProtecteurEquipementDeProtection { get; set; }
        public TernaryString AppareilProtecteurEquipementDeProtection { get; set; }
        public TernaryString AutresEquipementDePrevention { get; set; }
        public TernaryString OutilManuelEquipementDePrevention { get; set; } //Taken for Outil Manual: outilDeLaitonDropDownControl
        public TernaryString PerimetreDeSecurityEquipementDePrevention { get; set; }
        public TernaryString AppareilEquipementDePrevention { get; set; }
        public TernaryString AutresTravaux { get; set; }

        public TernaryString Procedure { get; set; }
        public TernaryString AutresCondition { get; set; }
        public TernaryString Etiquette { get; set; }
        public TernaryString HabitProtecteur { get; set; }
        public TernaryString AutresInstructionValue { get; set; }

        public TernaryString ProcedureEntretien { get; set; }
        public TernaryString EtiquettObturateur { get; set; }
        public TernaryString AutresInstruction { get; set; }

        public bool MasqueSoudeur { get; set; }

        public bool Soudage { get; set; }
        public bool Traitement { get; set; }
        public bool Cuissons { get; set; }
        public bool Perçage { get; set; }
        public bool Chaufferette { get; set; }
        public bool Meulage { get; set; }
        public bool Nettoyage { get; set; }
        public bool TravauxDansZone { get; set; }
        public bool Combustibles { get; set; }
        public bool Ecran { get; set; }
        public bool Boyau { get; set; }
        public bool BoyauDe { get; set; }
        public bool Couverture { get; set; }
        public bool Extincteur { get; set; }
        public bool Bouche { get; set; }
        public bool RadioS { get; set; }
        public bool Surveillant { get; set; }
        public bool UtilisationMoteur { get; set; }
        public bool NettoyageAu { get; set; }
        public bool UtilisationElectronics { get; set; }
        public bool Radiographie { get; set; }
        public bool UtilisationOutlis { get; set; }
        public bool UtilisationEquipments { get; set; }
        public bool Demolition { get; set; }
        public bool MhAutres { get; set; }
        public bool Masque { get; set; }
        public bool OutillageElectrique { get; set; }
        public bool EffondrementEnsevelissement { get; set; }

        public List<DocumentLink> DocumentLinks { get; set; }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionsFullHierarchies, SiteConfiguration siteConfiguration)
        {
            foreach (var floc in FunctionalLocations)
            {
                var isRelevant = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
                if (isRelevant)
                {
                    return true;
                }
            }
            return false;
        }

        public string DescriptionForLog()
        {
            var sb = new StringBuilder();

            string firstLineFormat;
            if (IssuedDateTime != null)
            {
                firstLineFormat = "{0}: {1}, {2}, {3}";
            }
            else
            {
                firstLineFormat = "{0}: {1}, " + StringResources.WorkPermitDescription_NotIssued + ", {2}, {3}";
            }

            sb.AppendLine(String.Format(firstLineFormat,
                StringResources.WorkPermitDescription_PermitNumberLabel,
                PermitNumber,
                WorkPermitType.Name,
                WorkPermitStatus.Name
                ));
            sb.AppendLine(String.Format("{0}: {1}", StringResources.WorkPermitMontrealHistoryClassDescriptionPropertyKey, //TODO value change
                Description));

            return sb.ToString();
        }

        public void CopyContentsIntoNextDayPermit(ref WorkPermitMuds nextDayPermit, User currentUser)
        {
            WorkPermitMuds newNextDayPermit = this.DeepClone();
            newNextDayPermit.Id = nextDayPermit.Id;
            newNextDayPermit.Template = this.Template;
            newNextDayPermit.WorkPermitStatus = nextDayPermit.WorkPermitStatus;
            newNextDayPermit.PermitNumber = null;
            newNextDayPermit.LastModifiedBy = nextDayPermit.LastModifiedBy;
            newNextDayPermit.LastModifiedDateTime = nextDayPermit.LastModifiedDateTime;
            newNextDayPermit.IssuedDateTime = null;
            newNextDayPermit.WorkOrderNumber = nextDayPermit.WorkOrderNumber;
            newNextDayPermit.DocumentLinks = newNextDayPermit.DocumentLinks.ConvertAll(link => link.CloneWithoutId());

            newNextDayPermit.NbTravail = nextDayPermit.NbTravail;
            newNextDayPermit.FormationCheck = nextDayPermit.FormationCheck;
            newNextDayPermit.NomsEnt = nextDayPermit.NomsEnt;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            newNextDayPermit.NomsEnt_1 = nextDayPermit.NomsEnt_1;
            newNextDayPermit.NomsEnt_2 = nextDayPermit.NomsEnt_2;
            newNextDayPermit.NomsEnt_3 = nextDayPermit.NomsEnt_3;
            newNextDayPermit.Surveilant = nextDayPermit.Surveilant;

            // Keep the existing Details from the "Detials de le demande" section
            newNextDayPermit.RequestedDateTime = nextDayPermit.RequestedDateTime;
            newNextDayPermit.RequestedByUser = nextDayPermit.RequestedByUser;
            newNextDayPermit.Company = nextDayPermit.Company;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            newNextDayPermit.Company_1 = nextDayPermit.Company_1;
            newNextDayPermit.Company_2 = nextDayPermit.Company_2;
            newNextDayPermit.Supervisor = nextDayPermit.Supervisor;
            newNextDayPermit.ExcavationNumber = nextDayPermit.ExcavationNumber;
            newNextDayPermit.Attributes = nextDayPermit.Attributes.DeepClone();

            // Keep the original start and end datetime
            newNextDayPermit.StartDateTime = nextDayPermit.StartDateTime;
            newNextDayPermit.EndDateTime = nextDayPermit.EndDateTime;

            nextDayPermit = newNextDayPermit;
        }

        public void ConvertToClone()
        {
            Id = null;
            PermitNumber = null;
            WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
            LastModifiedBy = null;
            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());

            // Do not clone any Details from the "Detials de le demande" section
            RequestedByUser = null;
            RequestedDateTime = null;
            //Company = null; : commented by vibhor // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            Supervisor = null;
            ExcavationNumber = null;
            Attributes.Clear();
        }

        //TODO check use of below function
        //public static bool IsDayShift(Time time)
        //{
        //    return (time >= PermitRequestMuds.StartOfDefaultDayShift && time < PermitRequestMuds.StartOfDefaultNightShift);
        //}
        public WorkPermitGasTests GasTests { get; set; }
        //public List<GasTestElement> GasTests { get; set; }

      //Added by ppanigrahi
      public bool ActionItemCheckBoxclick { get; set; }

       public string lastModifiedUsername { get; set; }

       public string WorkPermitCloseComments { get; set; }

       public long WorkpermitClosedById { get; set; }
       public User WorkpermitClosedBy { get; set; }
       public long ActionItemCloseById { get; set; }
        public User ActionItemCloseBy { get; set; }
        public DateTime? PermitCloseDateTime { get; set; }
        public DateTime? ActionItemCloseDateTime { get; set; }
        public bool? ActionItemCheckboxchecked { get; set; }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public string TemplateCreatedBy { get; set; }
        public string Categories { get; set; }
        public bool Global { get; set; }
        public bool Individual { get; set; }

        public string _templateName { get; set; }
        public string _categories { get; set; }

        public long TemplateId { get; set; } //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        // Added By Vibhor : RITM0556998 - Add new status signed

        public string VERIFICATEUR_Text{get; set; }
        public string EMETTEUR_Text{get; set; }
        public string DETENTEUR_Text{get; set; }
        public string GasResultat_Text{get; set; }

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

        public string MudsAnswerTextBox{get; set; }
        public string MudsQuestionlabel{get; set; }

         

    }
}

