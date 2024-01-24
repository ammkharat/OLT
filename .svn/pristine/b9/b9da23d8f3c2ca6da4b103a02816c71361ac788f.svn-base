using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Utility
{
    public class PermitRequestLubesAttributes
    {
        public const string FormsConfinedSpace = "LA";
        public const string FormsConfinedSpaceEntryAndControlPlan = "LB";
        public const string FormsCriticalLift = "LC";
        public const string FormsEnergyControlPlan = "LD";
        public const string FormsEquivalencyProcedure = "LE";
        public const string FormsExcavation = "LF";
        public const string FormsHighEnergy = "LG";
        public const string FormsLiveFlareWork = "LH";
        public const string FormsRescuePlan = "LI";
        public const string FormsTestPneumatic = "LJ";
        public const string FormsElectricalJobHazardAssessment = "LV";
        public const string HazardsDesignatedSubstance = "LK";
        public const string HazardsHydrocarbonGas = "LL";
        public const string HazardsHydrocarbonLiquid = "LM";
        public const string HazardsHydrogenSulphide = "LN";
        public const string HazardsInertGasAtmosphere = "LO";
        public const string HazardsOxygenDeficiency = "LP";
        public const string HazardsRadioactiveSources = "LQ";
        public const string HazardsUndergroundOverheadHazards = "LR";
        public const string RequirementsDesignateLocationOfHotAndColdCuts = "LS";
        public const string RequirementsFireWatch = "LT";
        public const string RequirementsHydrantPermit = "LU";
        public const string NoFurtherAttributes = "X";
        public const string DoNotMerge = "FY";

        private readonly HashSet<string> attributes = new HashSet<string>();

        public PermitRequestLubesAttributes(IEnumerable<string> attributes)
        {
            this.attributes.UnionWith(attributes);
        }

        public void SetAttributesOnPermitRequest(PermitRequestLubes permitRequest)
        {
            permitRequest.ConfinedSpace = GetBooleanValue(FormsConfinedSpace);
            permitRequest.EntryAndControlPlan = GetFormState(FormsConfinedSpaceEntryAndControlPlan);
            permitRequest.CriticalLift = GetFormState(FormsCriticalLift);
            permitRequest.EnergyControlPlan = GetFormState(FormsEnergyControlPlan);
            permitRequest.EquivalencyProc = GetFormState(FormsEquivalencyProcedure);
            permitRequest.Excavation = GetFormState(FormsExcavation);
            permitRequest.HighEnergy = GetFormState(FormsHighEnergy);
            permitRequest.LiveFlareWork = GetFormState(FormsLiveFlareWork);
            permitRequest.RescuePlan = GetBooleanValue(FormsRescuePlan);
            permitRequest.TestPneumatic = GetFormState(FormsTestPneumatic);
            permitRequest.EnergizedElectrical = GetFormState(FormsElectricalJobHazardAssessment);
            permitRequest.HazardDesignatedSubstance = GetBooleanValue(HazardsDesignatedSubstance);
            permitRequest.HazardHydrocarbonGas = GetBooleanValue(HazardsHydrocarbonGas);
            permitRequest.HazardHydrocarbonLiquid = GetBooleanValue(HazardsHydrocarbonLiquid);
            permitRequest.HazardHydrogenSulphide = GetBooleanValue(HazardsHydrogenSulphide);
            permitRequest.HazardInertGasAtmosphere = GetBooleanValue(HazardsInertGasAtmosphere);
            permitRequest.HazardOxygenDeficiency = GetBooleanValue(HazardsOxygenDeficiency);
            permitRequest.HazardRadioactiveSources = GetBooleanValue(HazardsRadioactiveSources);
            permitRequest.HazardUndergroundOverheadHazards = GetBooleanValue(HazardsUndergroundOverheadHazards);
            permitRequest.DesignateHotOrColdCutChecked = GetBooleanValue(RequirementsDesignateLocationOfHotAndColdCuts);
            permitRequest.FireWatch = GetBooleanValue(RequirementsFireWatch);
            permitRequest.HydrantPermit = GetBooleanValue(RequirementsHydrantPermit);
            permitRequest.DoNotMerge = GetBooleanValue(DoNotMerge);
        }

        private bool GetBooleanValue(string attribute)
        {
            return attributes.Contains(attribute);
        }

        private WorkPermitSafetyFormState GetFormState(string attribute)
        {
            return attributes.Contains(attribute)
                ? WorkPermitSafetyFormState.Required
                : WorkPermitSafetyFormState.NotApplicable;
        }
    }
}