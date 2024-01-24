using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class WorkPermitEdmontonMergeTool
    {
        private readonly IFunctionalLocationService flocService;
        private readonly User merger;
        private bool hasIncompatibleFunctionalLocations;
        private bool hasIncompatibleFields;
        private List<string> incompatibleFieldNames;

        public WorkPermitEdmontonMergeTool(User merger) : this(ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>(), merger)
        {            
        }

        public WorkPermitEdmontonMergeTool(IFunctionalLocationService flocService, User merger)
        {
            this.flocService = flocService;
            this.merger = merger;
        }

        public WorkPermitEdmonton Merge(List<WorkPermitEdmonton> permits)
        {
            hasIncompatibleFunctionalLocations = false;
            hasIncompatibleFields = false;
            incompatibleFieldNames = new List<string>();

            WorkPermitEdmonton mergedPermit = null;

            string fullHierarchyOfClosestAncestor = permits.ConvertAll(permit => permit.FunctionalLocation).FullHierarchyOfClosestAncestor();
            if (fullHierarchyOfClosestAncestor == null || new FunctionalLocationHierarchy(fullHierarchyOfClosestAncestor).Level == 1)
            {
                hasIncompatibleFunctionalLocations = true;
                return null;
            }

            mergedPermit = new WorkPermitEdmonton(DataSource.MERGE, PermitRequestBasedWorkPermitStatus.Requested, null, Clock.Now, merger);

            incompatibleFieldNames = DetermineIncompatibleTypeOfWorkFieldNamesAndMergeAsAppropriate(mergedPermit, permits);
            if (incompatibleFieldNames.Count > 0)
            {
                hasIncompatibleFields = true;
            }

            FunctionalLocation floc = flocService.QueryByFullHierarchy(fullHierarchyOfClosestAncestor, Site.EDMONTON_ID);

            {
                mergedPermit.FunctionalLocation = floc;
                mergedPermit.Location = WorkPermitEdmonton.GetLocation(floc);
                mergedPermit.WorkPermitType = null;

                mergedPermit.TaskDescription = BuildDescription(permits);
                mergedPermit.HazardsAndOrRequirements = BuildHazards(permits);

                SetFormFields(mergedPermit, permits);
                SetMinimumSafetyRequirementsFields(mergedPermit, permits);
                SetIssuedToSectionFields(mergedPermit, permits);
                SetOtherAreasSectionFields(mergedPermit, permits);
                SetAreaLabel(mergedPermit, permits);
            }

            return mergedPermit;
        }

        private void SetAreaLabel(WorkPermitEdmonton mergedPermit, List<WorkPermitEdmonton> permits)
        {
            WorkPermitEdmonton firstPermit = permits[0];

            if (permits.TrueForAll(p => Equals(p.AreaLabel, firstPermit.AreaLabel)))
            {
                mergedPermit.AreaLabel = firstPermit.AreaLabel;
            }
        }

        private void SetOtherAreasSectionFields(WorkPermitEdmonton mergedPermit, List<WorkPermitEdmonton> permits)
        {
            WorkPermitEdmonton firstPermit = permits[0];

            mergedPermit.OtherAreasAndOrUnitsAffected = permits.Exists(p => p.OtherAreasAndOrUnitsAffected);

            if (permits.TrueForAll(p => p.OtherAreasAndOrUnitsAffectedArea == firstPermit.OtherAreasAndOrUnitsAffectedArea))
            {
                mergedPermit.OtherAreasAndOrUnitsAffectedArea = firstPermit.OtherAreasAndOrUnitsAffectedArea;
            }

            if (permits.TrueForAll(p => p.OtherAreasAndOrUnitsAffectedPersonNotified == firstPermit.OtherAreasAndOrUnitsAffectedPersonNotified))
            {
                mergedPermit.OtherAreasAndOrUnitsAffectedPersonNotified = firstPermit.OtherAreasAndOrUnitsAffectedPersonNotified;
            }
        }

        private void SetIssuedToSectionFields(WorkPermitEdmonton mergedPermit, List<WorkPermitEdmonton> permits)
        {
            WorkPermitEdmonton firstPermit = permits[0];

            mergedPermit.IssuedToSuncor = permits.Exists(p => p.IssuedToSuncor);
            mergedPermit.IssuedToCompany = permits.Exists(p => p.IssuedToCompany);

            if (permits.TrueForAll(p => p.Company == firstPermit.Company))
            {
                mergedPermit.Company = firstPermit.Company;
            }

            if (permits.TrueForAll(p => p.Occupation == firstPermit.Occupation))
            {
                mergedPermit.Occupation = firstPermit.Occupation;
            }

            if (permits.TrueForAll(p => p.NumberOfWorkers == firstPermit.NumberOfWorkers))
            {
                mergedPermit.NumberOfWorkers = firstPermit.NumberOfWorkers;
            }

            if (permits.TrueForAll(p => p.Group == firstPermit.Group))
            {
                mergedPermit.Group = firstPermit.Group;
            }
        }

        private List<string> DetermineIncompatibleTypeOfWorkFieldNamesAndMergeAsAppropriate(WorkPermitEdmonton mergedPermit, List<WorkPermitEdmonton> permits)
        {
            WorkPermitEdmonton firstPermit = permits[0];
            List<string> badFields = new List<string>();

            if (permits.TrueForAll(p => p.DurationPermit == firstPermit.DurationPermit))
            {
                mergedPermit.DurationPermit = firstPermit.DurationPermit;
            }
            else
            {
                badFields.Add("Duration Permit");
            }

            if (permits.TrueForAll(p => p.AlkylationEntry == firstPermit.AlkylationEntry))
            {
                mergedPermit.AlkylationEntry = firstPermit.AlkylationEntry;
            }
            else
            {
                badFields.Add("Alkylation Entry");
            }

            if (permits.TrueForAll(p => firstPermit.AlkylationEntryClassOfClothing == p.AlkylationEntryClassOfClothing))
            {
                mergedPermit.AlkylationEntryClassOfClothing = firstPermit.AlkylationEntryClassOfClothing;
            }
            else
            {
                badFields.Add("Class of Clothing (Alkylation Entry)");
            }

            if (permits.TrueForAll(p => p.FlarePitEntry == firstPermit.FlarePitEntry))
            {
                mergedPermit.FlarePitEntry = firstPermit.FlarePitEntry;
            }
            else
            {
                badFields.Add("Flare Pit Entry");
            }

            if (permits.TrueForAll(p => firstPermit.FlarePitEntryType == p.FlarePitEntryType))
            {
                mergedPermit.FlarePitEntryType = firstPermit.FlarePitEntryType;
            }
            else
            {
                badFields.Add("Type (Flare Pit Entry)");
            }

            if (permits.TrueForAll(p => p.ConfinedSpace == firstPermit.ConfinedSpace))
            {
                mergedPermit.ConfinedSpace = firstPermit.ConfinedSpace;
            }
            else
            {
                badFields.Add("Confined Space");
            }

            if (permits.TrueForAll(p => firstPermit.ConfinedSpaceClass == p.ConfinedSpaceClass))
            {
                mergedPermit.ConfinedSpaceClass = firstPermit.ConfinedSpaceClass;
            }
            else
            {
                badFields.Add("Class (Confined Space)");
            }

            if (permits.TrueForAll(p => firstPermit.ConfinedSpaceCardNumber == p.ConfinedSpaceCardNumber))
            {
                mergedPermit.ConfinedSpaceCardNumber = firstPermit.ConfinedSpaceCardNumber;
            }
            else
            {
                badFields.Add("Card Number (Confined Space)");
            }

            if (permits.TrueForAll(p => p.RescuePlan == firstPermit.RescuePlan))
            {
                mergedPermit.RescuePlan = firstPermit.RescuePlan;
            }
            else
            {
                badFields.Add("Rescue Plan");
            }

            if (permits.TrueForAll(p => firstPermit.RescuePlanFormNumber == p.RescuePlanFormNumber))
            {
                mergedPermit.RescuePlanFormNumber = firstPermit.RescuePlanFormNumber;
            }
            else
            {
                badFields.Add("Form Number (Rescue Plan)");
            }

            if (permits.TrueForAll(p => p.VehicleEntry == firstPermit.VehicleEntry))
            {
                mergedPermit.VehicleEntry = firstPermit.VehicleEntry;
            }
            else
            {
                badFields.Add("Vehicle Entry");
            }

            if (permits.TrueForAll(p => firstPermit.VehicleEntryTotal == p.VehicleEntryTotal))
            {
                mergedPermit.VehicleEntryTotal = firstPermit.VehicleEntryTotal;
            }
            else
            {
                badFields.Add("Total (Vehicle Entry)");
            }

            if (permits.TrueForAll(p => firstPermit.VehicleEntryType == p.VehicleEntryType))
            {
                mergedPermit.VehicleEntryType = firstPermit.VehicleEntryType;
            }
            else
            {
                badFields.Add("Type (Vehicle Entry)");
            }

            if (permits.TrueForAll(p => p.SpecialWork == firstPermit.SpecialWork))
            {
                mergedPermit.SpecialWork = firstPermit.SpecialWork;
            }
            else
            {
                badFields.Add("Special Work");
            }

            if (permits.TrueForAll(p => firstPermit.SpecialWorkFormNumber == p.SpecialWorkFormNumber))
            {
                mergedPermit.SpecialWorkFormNumber = firstPermit.SpecialWorkFormNumber;
            }
            else
            {
                badFields.Add("Form Number (Special Work)");
            }

            if (permits.TrueForAll(p => firstPermit.SpecialWorkType == p.SpecialWorkType))
            {
                mergedPermit.SpecialWorkType = firstPermit.SpecialWorkType;
            }
            else
            {
                badFields.Add("Type (Special Work)");
            }

            return badFields;
        }

        private void SetFormFields(WorkPermitEdmonton mergedPermit, List<WorkPermitEdmonton> permits)
        {
            mergedPermit.GN6 = permits.Exists(p => p.GN6);
            mergedPermit.GN7 = permits.Exists(p => p.GN7);
            mergedPermit.GN59 = permits.Exists(p => p.GN59);
            mergedPermit.GN24 = permits.Exists(p => p.GN24);
            mergedPermit.GN75A = permits.Exists(p => p.GN75A);

            if (permits.Exists(permit => WorkPermitSafetyFormState.Approved.Equals(permit.GN11)))
            {
                mergedPermit.GN11 = WorkPermitSafetyFormState.Approved;
            }

            if (permits.Exists(permit => WorkPermitSafetyFormState.Approved.Equals(permit.GN27)))
            {
                mergedPermit.GN27 = WorkPermitSafetyFormState.Approved;
            }
        }

        private void SetMinimumSafetyRequirementsFields(WorkPermitEdmonton mergedPermit, List<WorkPermitEdmonton> permits)
        {
            WorkPermitEdmonton firstPermit = permits[0];

            mergedPermit.FaceShield = permits.Exists(p => p.FaceShield);
            mergedPermit.Goggles = permits.Exists(p => p.Goggles);
            mergedPermit.RubberBoots = permits.Exists(p => p.RubberBoots);
            mergedPermit.RubberGloves = permits.Exists(p => p.RubberGloves);
            mergedPermit.RubberSuit = permits.Exists(p => p.RubberSuit);
            mergedPermit.SafetyHarnessLifeline = permits.Exists(p => p.SafetyHarnessLifeline);
            mergedPermit.HighVoltagePPE = permits.Exists(p => p.HighVoltagePPE);
            mergedPermit.Other1Checked = permits.Exists(p => p.Other1Checked);
            if (permits.TrueForAll(p => p.Other1 == firstPermit.Other1))
            {
                mergedPermit.Other1 = firstPermit.Other1;
            }

            mergedPermit.EquipmentGrounded = permits.Exists(p => p.EquipmentGrounded); 
            mergedPermit.FireBlanket = permits.Exists(p => p.FireBlanket); 
            mergedPermit.FireExtinguisher = permits.Exists(p => p.FireExtinguisher); 
            mergedPermit.FireMonitorManned = permits.Exists(p => p.FireMonitorManned);
            mergedPermit.FireWatch = permits.Exists(p => p.FireWatch);
            mergedPermit.SewersDrainsCovered = permits.Exists(p => p.SewersDrainsCovered);
            mergedPermit.SteamHose = permits.Exists(p => p.SteamHose);
            mergedPermit.Other2Checked = permits.Exists(p => p.Other2Checked);
            if (permits.TrueForAll(p => p.Other2 == firstPermit.Other2))
            {
                mergedPermit.Other2 = firstPermit.Other2;
            }

            mergedPermit.AirPurifyingRespirator = permits.Exists(p => p.AirPurifyingRespirator);
            mergedPermit.BreathingAirApparatus = permits.Exists(p => p.BreathingAirApparatus);
            mergedPermit.DustMask = permits.Exists(p => p.DustMask);
            mergedPermit.LifeSupportSystem = permits.Exists(p => p.LifeSupportSystem);
            mergedPermit.SafetyWatch = permits.Exists(p => p.SafetyWatch);
            mergedPermit.ContinuousGasMonitor = permits.Exists(p => p.ContinuousGasMonitor);
            mergedPermit.WorkersMonitor = permits.Exists(p => p.WorkersMonitor);
            if (permits.TrueForAll(p => p.WorkersMonitorNumber == firstPermit.WorkersMonitorNumber))
            {
                mergedPermit.WorkersMonitorNumber = firstPermit.WorkersMonitorNumber;
            }
            mergedPermit.BumpTestMonitorPriorToUse = permits.Exists(p => p.BumpTestMonitorPriorToUse);
            mergedPermit.Other3Checked = permits.Exists(p => p.Other3Checked);
            if (permits.TrueForAll(p => p.Other3 == firstPermit.Other3))
            {
                mergedPermit.Other3 = firstPermit.Other3;
            }

            mergedPermit.AirMover = permits.Exists(p => p.AirMover);
            mergedPermit.BarriersSigns = permits.Exists(p => p.BarriersSigns);
            mergedPermit.RadioChannel = permits.Exists(p => p.RadioChannel);
            if (permits.TrueForAll(p => p.RadioChannelNumber == firstPermit.RadioChannelNumber))
            {
                mergedPermit.RadioChannelNumber = firstPermit.RadioChannelNumber;
            }
            mergedPermit.AirHorn = permits.Exists(p => p.AirHorn);
            mergedPermit.MechVentilationComfortOnly = permits.Exists(p => p.MechVentilationComfortOnly);
            mergedPermit.AsbestosMMCPrecautions = permits.Exists(p => p.AsbestosMMCPrecautions);
            mergedPermit.Other4Checked = permits.Exists(p => p.Other4Checked);
            if (permits.TrueForAll(p => p.Other4 == firstPermit.Other4))
            {
                mergedPermit.Other4 = firstPermit.Other4;
            }
        }

        private string BuildDescription(List<WorkPermitEdmonton> permits)
        {
            List<string> pieces = new List<string>();

            foreach (WorkPermitEdmonton permit in permits)
            {
                string woNumberPart = "";

                if (!permit.WorkOrderNumber.IsNullOrEmptyOrWhitespace())
                {
                     woNumberPart = string.Format("WO#{0} ", permit.WorkOrderNumber);
                }
                
                pieces.Add(string.Format("-> {0}{1}: {2}", woNumberPart, permit.FunctionalLocation.FullHierarchy, permit.TaskDescription));
            }

            return pieces.Join(Environment.NewLine);
        }

        private string BuildHazards(List<WorkPermitEdmonton> permits)
        {
            List<string> pieces = new List<string>();

            foreach (WorkPermitEdmonton permit in permits)
            {
                if (!permit.HazardsAndOrRequirements.IsNullOrEmptyOrWhitespace())
                {
                    if (!pieces.Contains(permit.HazardsAndOrRequirements))
                    {
                        pieces.Add(permit.HazardsAndOrRequirements);
                    }
                }
            }

            return pieces.Join(Environment.NewLine);
        }

        public bool HasIncompatibleFunctionalLocations
        {
            get { return hasIncompatibleFunctionalLocations; }
        }

        public bool HasIncompatibleFields
        {
            get { return hasIncompatibleFields; }
        }

        public List<string> IncompatibleFieldNames
        {
            get { return incompatibleFieldNames; }
        }
    }
}
