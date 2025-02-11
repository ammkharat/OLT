﻿using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitMontreal : ModifiableDomainObject, IFunctionalLocationRelevant, IDocumentLinksObject
    {
        private List<PermitAttribute> attributes = new List<PermitAttribute>();

        /// <summary>
        ///     For creating a Work Permit from a Work Order
        /// </summary>
        public WorkPermitMontreal(DataSource dataSource, PermitRequestBasedWorkPermitStatus workPermitStatus,
            WorkPermitMontrealType workPermitType, WorkPermitMontrealTemplate template, DateTime startDateTime,
            DateTime endDateTime, List<FunctionalLocation> functionalLocations, string workOrderNumber, string trade,
            string description, DateTime createdDateTime, User createdBy, DateTime lastModifiedDateTime,
            User lastModifiedUser, WorkPermitMontrealGroup requestedByGroup, DateTime? issuedDateTime)
        {
            DataSource = dataSource;
            WorkPermitStatus = workPermitStatus;
            WorkPermitType = workPermitType;

            Template = template ?? WorkPermitMontrealTemplate.NULL;
            RequestedByGroup = requestedByGroup;

            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            FunctionalLocations = functionalLocations;
            WorkOrderNumber = workOrderNumber;
            Trade = trade;
            Description = description;

            Corrosif = new TernaryString(false, null);
            Aromatique = new TernaryString(false, null);
            AutresSubstances = new TernaryString(false, null);

            DessinsRequis = new TernaryString(false, null);
            BoiteEnergieZero = new TernaryString(false, null);
            FormulaireDespaceClosAffiche = new TernaryString(false, null);
            AutreConditions = new TernaryString(false, null);

            ProtectionRespiratoire = new TernaryString(false, null);
            Habits = new TernaryString(false, null);
            AutreProtection = new TernaryString(false, null);

            AutresEquipementDincendie = new TernaryString(false, null);

            Surveillant = new TernaryString(false, null);
            DetectionContinueDesGaz = new TernaryString(false, null);
            AutreEquipementsSecurite = new TernaryString(false, null);

            CreatedDateTime = createdDateTime;
            CreatedBy = createdBy;

            LastModifiedDateTime = lastModifiedDateTime;
            LastModifiedBy = lastModifiedUser;

            DocumentLinks = new List<DocumentLink>();
            IssuedDateTime = issuedDateTime;
        }



        public WorkPermitMontreal(long id, long? permitNumber, DataSource dataSource,
            PermitRequestBasedWorkPermitStatus workPermitStatus, WorkPermitMontrealType workPermitType,
            WorkPermitMontrealTemplate template, DateTime startDateTime, DateTime endDateTime,
            List<FunctionalLocation> functionalLocations, string workOrderNumber, string trade, string description,
            DateTime createdDateTime, User createdBy, DateTime lastModifiedDateTime, User lastModifiedUser,
            WorkPermitMontrealGroup requestedByGroup, DateTime? issuedDateTime)
            : this(
                dataSource, workPermitStatus, workPermitType, template, startDateTime, endDateTime, functionalLocations,
                trade,
                trade, description, createdDateTime, createdBy, lastModifiedDateTime, lastModifiedUser, requestedByGroup,
                issuedDateTime)
        {
            Id = id;
            PermitNumber = permitNumber;
            WorkOrderNumber = workOrderNumber;
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public WorkPermitMontreal(string templatename, string categories)
        {
            _templateName = templatename;
            _categories = categories;
        }

        public bool UsePreviousPermitAnswered { get; set; }
        public DataSource DataSource { get; private set; }
        public PermitRequestBasedWorkPermitStatus WorkPermitStatus { get; set; }
        public WorkPermitMontrealType WorkPermitType { get; set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public List<FunctionalLocation> FunctionalLocations { get; private set; }
        public string WorkOrderNumber { get; private set; }
        public long? PermitNumber { get; set; }
        public string Trade { get; private set; }
        public string Description { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public User CreatedBy { get; private set; }

        public WorkPermitMontrealTemplate Template { get; set; }
        public WorkPermitMontrealGroup RequestedByGroup { get; set; }

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
        public string Supervisor { get; set; }
        public string ExcavationNumber { get; set; }

        public string ClonedFormDetailMontreal { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History

        public List<PermitAttribute> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        #region Substances

        public bool H2S { get; set; }
        public bool Hydrocarbure { get; set; }
        public bool Ammoniaque { get; set; }
        public TernaryString Corrosif { get; set; }
        public TernaryString Aromatique { get; set; }
        public TernaryString AutresSubstances { get; set; }

        #endregion

        #region Conditions

        public bool ObtureOuDebranche { get; set; }
        public bool DepressuriseEtVidange { get; set; }
        public bool EnPresenceDeGazInerte { get; set; }
        public bool PurgeALaVapeur { get; set; }
        public bool RinceALeau { get; set; }
        public bool Excavation { get; set; }
        public TernaryString DessinsRequis { get; set; }
        public bool CablesChauffantsMisHorsTension { get; set; }
        public bool PompeOuVerinPneumatique { get; set; }

        public bool ChaineEtCadenasseOuScelle { get; set; }
        public bool InterrupteursElectriquesVerrouilles { get; set; }
        public bool PurgeParUnGazInerte { get; set; }
        public bool OutilsElectriquesOuABatteries { get; set; }
        public TernaryString BoiteEnergieZero { get; set; }
        public bool OutilsPneumatiques { get; set; }
        public bool MoteurACombustionInterne { get; set; }
        public bool TravauxSuperPoses { get; set; }

        public TernaryString FormulaireDespaceClosAffiche { get; set; }
        public bool ExisteIlUneAnalyseDeTache { get; set; }
        public bool PossibiliteDeSulfureDeFer { get; set; }
        public bool AereVentile { get; set; }
        public bool SoudureALelectricite { get; set; }
        public bool BrulageAAcetylene { get; set; }
        public bool Nacelle { get; set; }
        public TernaryString AutreConditions { get; set; }

        #endregion

        #region Personal Protective Equipment (PPE)

        public bool LunettesMonocoques { get; set; }
        public bool HarnaisDeSecurite { get; set; }
        public bool EcranFacial { get; set; }
        public bool ProtectionAuditive { get; set; }
        public bool Trepied { get; set; }
        public bool DispositifAntichute { get; set; }
        public TernaryString ProtectionRespiratoire { get; set; }
        public TernaryString Habits { get; set; }
        public TernaryString AutreProtection { get; set; }

        #endregion

        #region Fire Protection

        public bool Extincteur { get; set; }
        public bool BouchesDegoutProtegees { get; set; }
        public bool CouvertureAntiEtincelles { get; set; }
        public bool SurveillantPouretincelles { get; set; }
        public bool PareEtincelles { get; set; }
        public bool MiseAlaTerrePresDuLieuDeTravail { get; set; }
        public bool BoyauAVapeur { get; set; }
        public TernaryString AutresEquipementDincendie { get; set; }

        #endregion

        #region OtherSafetyEquipment

        public bool Ventulateur { get; set; }
        public bool Barrieres { get; set; }
        public TernaryString Surveillant { get; set; }
        public bool RadioEmetteur { get; set; }
        public bool PerimetreDeSecurite { get; set; }
        public TernaryString DetectionContinueDesGaz { get; set; }
        public bool KlaxonSonore { get; set; }
        public bool Localiser { get; set; }
        public bool Amiante { get; set; }
        public TernaryString AutreEquipementsSecurite { get; set; }

        #endregion

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
            sb.AppendLine(String.Format("{0}: {1}", StringResources.WorkPermitMontrealHistoryClassDescriptionPropertyKey,
                Description));

            return sb.ToString();
        }

        public void CopyContentsIntoNextDayPermit(ref WorkPermitMontreal nextDayPermit, User currentUser)
        {
            WorkPermitMontreal newNextDayPermit = this.DeepClone();
            newNextDayPermit.Id = nextDayPermit.Id;
            newNextDayPermit.Template = this.Template;
            newNextDayPermit.WorkPermitStatus = nextDayPermit.WorkPermitStatus;
            newNextDayPermit.PermitNumber = null;
            newNextDayPermit.LastModifiedBy = nextDayPermit.LastModifiedBy;
            newNextDayPermit.LastModifiedDateTime = nextDayPermit.LastModifiedDateTime;
            newNextDayPermit.IssuedDateTime = null;
            newNextDayPermit.WorkOrderNumber = nextDayPermit.WorkOrderNumber;
            newNextDayPermit.DocumentLinks = newNextDayPermit.DocumentLinks.ConvertAll(link => link.CloneWithoutId());

            // Keep the existing Details from the "Detials de le demande" section
            newNextDayPermit.RequestedDateTime = nextDayPermit.RequestedDateTime;
            newNextDayPermit.RequestedByUser = nextDayPermit.RequestedByUser;
            newNextDayPermit.Company = nextDayPermit.Company;
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

            if (FormulaireDespaceClosAffiche != null && FormulaireDespaceClosAffiche.HasValue)
            {
                FormulaireDespaceClosAffiche = new TernaryString(true, string.Empty);
            }

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());

            // Do not clone any Details from the "Detials de le demande" section
            RequestedByUser = null;
            RequestedDateTime = null;
            Company = null;
            Supervisor = null;
            ExcavationNumber = null;
            Attributes.Clear();
        }

        public static bool IsDayShift(Time time)
        {
            return (time >= PermitRequestMontreal.StartOfDefaultDayShift && time < PermitRequestMontreal.StartOfDefaultNightShift);
        }
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

    }
}