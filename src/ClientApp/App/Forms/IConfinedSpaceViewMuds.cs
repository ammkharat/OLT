using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfinedSpaceViewMuds : IConfinedSpaceValidationActionMuds, IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action FunctionalLocationSelector;
        event Action PreparationCheckChanged;        
        event Action<ConfiguredDocumentLink> ViewDocumentLinkClicked;
        event Action<ConfiguredDocumentLink> ViewPssClicked;
        event Action WorkPermitTypeChanged;

        bool IsPreparation { get; }
        FunctionalLocation FunctionalLocation { get; set; }
        string ConfinedSpaceNumber { set; }

         bool SO2 { get; set; }
         bool NH3 { get; set; }
         bool AcideSulfurique { get; set; }
         bool CO { get; set; }
         bool Azote { get; set; }
         bool Reflux { get; set; }
         bool NaOH { get; set; }
         bool SBS { get; set; }
         bool Soufre { get; set; }
         bool Amiante { get; set; }
         bool Bacteries { get; set; }
         bool Depressurise { get; set; }
         bool Rince { get; set; }
         bool Obture { get; set; }
         bool Nettoyes { get; set; }
         bool Purge { get; set; }
         bool Vide { get; set; }
         bool Dessins { get; set; }
         bool DetectionDeGaz { get; set; }
         bool PSS { get; set; }
         bool VentilationEn { get; set; }
         bool VentilationForce { get; set; }
         bool Harnis { get; set; }
        


        bool H2S { get; set; }
        bool Hydrocarbure { get; set; }
        bool Ammoniaque { get; set; }
        TernaryString Corrosif { get; set; }
        TernaryString Aromatique { get; set; }
        TernaryString AutresSubstances { get; set; }

        bool ObtureOuDebranche { get; set; }
        bool DepressuriseEtVidange { get; set; }
        bool EnPresenceDeGazInerte { get; set; }
        bool PurgeALaVapeur { get; set; }
        TernaryString DessinsRequis { get; set; }
        bool PlanDeSauvetage { get; set; }

        bool CablesChauffantsMisHorsTension { get; set; }
        bool InterrupteursElectriquesVerrouilles { get; set; }
        bool PurgeParUnGazInerte { get; set; }
        bool RinceALeau { get; set; }
        bool VentilationMecanique { get; set; }

        bool BouchesDegoutProtegees { get; set; }
        bool PossibiliteDeSulfureDeFer { get; set; }
        bool AereVentile { get; set; }
        TernaryString AutreConditions { get; set; }
        bool VentilationNaturelle { get; set; }

        string InstructionsSpeciales { get; set; }
        
        DateTime StartDateTime { get; set; }
        DateTime EndDateTime { get; set; }
        List<string> CorrosifValues { set; }
        List<string> AromatiqueValues { set; }
        List<string> AutresSubstancesValues { set; }
        List<string> AutreConditionsValues { set; }
        List<ConfiguredDocumentLink> ConfiguredDocumentLinks { set; }
        FunctionalLocation ShowFunctionalLocationSelector();
        void DisableConfiguredDocumentLinks();
        void OpenFileOrDirectoryOrWebsite(string link);

        //Added for Gas test by ppanigrahi
       // List<WorkPermitMudsType> PermitTypes { set; }
       // WorkPermitMudsType SelectedPermitType { get; set; }
        void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> list);
        List<GasTestElementDetailsMuds> GasTestElementDetailsList { get; }
        Time FirtTestResult { set; get; }
        Time SecondTestResult { set; get; }
        Time ThirdTestResult { set; get; }
        Time FourthTestResult { set; get; }
        void EnbaleGasTest(bool val);
    }
}