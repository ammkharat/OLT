using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfinedSpaceView : IConfinedSpaceValidationAction, IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action FunctionalLocationSelector;
        event Action PreparationCheckChanged;        
        event Action<ConfiguredDocumentLink> ViewDocumentLinkClicked;

        bool IsPreparation { get; }
        FunctionalLocation FunctionalLocation { get; set; }
        string ConfinedSpaceNumber { set; }

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
    }
}