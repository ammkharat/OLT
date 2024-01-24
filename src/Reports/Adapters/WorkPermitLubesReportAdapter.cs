using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class WorkPermitLubesReportAdapter : DomainObject, IReportAdapter
    {
        private const string TwoDigitFormat = "00";

        private readonly WorkPermitLubes permit;

        public WorkPermitLubesReportAdapter(WorkPermitLubes permit, bool taskDescriptionTooLong,
            bool hazardsDescriptionToLong) : this(permit, taskDescriptionTooLong, hazardsDescriptionToLong, false)
        {
        }

        public WorkPermitLubesReportAdapter(WorkPermitLubes permit, bool isEmptyAdapter)
            : this(permit, false, false, isEmptyAdapter)
        {
        }

        public WorkPermitLubesReportAdapter(WorkPermitLubes permit, bool taskDescriptionTooLong,
            bool hazardsDescriptionToLong, bool isEmptyAdapter)
        {
            TaskDescriptionTooLong = taskDescriptionTooLong;
            HazardsDescriptionToLong = hazardsDescriptionToLong;
            this.permit = permit;
            IsEmptyAdapter = isEmptyAdapter;
        }

        private bool TaskDescriptionTooLong { get; set; }
        private bool HazardsDescriptionToLong { get; set; }
        public bool IsEmptyAdapter { get; private set; }

        public string WaterMarkText { get; set; }

        public bool IsPermitIssuerCopy { get; set; }
        public bool IsPermitAcceptorCopy { get; set; }

        // Heading section
        public string PermitNumber
        {
            get { return permit.PermitNumberDisplayValue; }
        }

        public bool IssuedToSuncor
        {
            get { return permit.IssuedToSuncor; }
        }

        public bool IssuedToContractor
        {
            get { return permit.IssuedToCompany; }
        }

        public string Company
        {
            get { return permit.Company == null ? null : permit.Company.Truncate(32, string.Empty); }
        }

        public string Occupation
        {
            get { return permit.Trade == null ? null : permit.Trade.Truncate(27, string.Empty); }
        }

        public int? NumberOfWorkers
        {
            get { return permit.NumberOfWorkers; }
        }

        public string PermitType
        {
            get { return permit.WorkPermitType != null ? permit.WorkPermitType.Name + " - " : string.Empty; }
        }

        // Section 1 - Type of Permit
        public bool IsHazardousColdWorkType
        {
            get { return WorkPermitLubesType.HAZARDOUS_COLD_WORK.Equals(permit.WorkPermitType); }
        }

        public bool IsHotWorkType
        {
            get { return WorkPermitLubesType.HOT_WORK.Equals(permit.WorkPermitType); }
        }

        public bool IsVehicleEntryWorkType
        {
            get { return permit.IsVehicleEntry; }
        }

        // Section 2 - Type of Work
        public bool IsHazardousWorkApproverAdvised
        {
            get { return permit.HazardousWorkApproverAdvised; }
        }

        public bool IsConfinedSpace
        {
            get { return permit.ConfinedSpace; }
        }

        public string ConfinedSpaceClass
        {
            get { return permit.ConfinedSpace ? permit.ConfinedSpaceClass : string.Empty; }
        }

        public bool IsConfinedSpaceSafetyWatchChecklist
        {
            get { return permit.ConfinedSpaceSafetyWatchChecklist; }
        }

        public bool RescuePlan
        {
            get { return permit.RescuePlan; }
        }

        public bool SpecialWork
        {
            get { return permit.SpecialWork; }
        }

        public string SpecialWorkType
        {
            get { return permit.SpecialWork ? permit.SpecialWorkType : string.Empty; }
        }

        public string Forms
        {
            get
            {
                var forms = new List<string>();
                if (permit.HighEnergy != null && !permit.HighEnergy.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("High Energy");
                }
                if (permit.CriticalLift != null && !permit.CriticalLift.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("Critical Lift");
                }
                if (permit.Excavation != null && !permit.Excavation.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("Excavation");
                }
                if (permit.EnergyControlPlanFormRequirement != null &&
                    !permit.EnergyControlPlanFormRequirement.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("Energy Control Plan");
                }
                if (permit.EquivalencyProc != null &&
                    !permit.EquivalencyProc.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("Equivalency Proc");
                }
                if (permit.TestPneumatic != null &&
                    !permit.TestPneumatic.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("Test/Pneumatic");
                }
                if (permit.LiveFlareWork != null &&
                    !permit.LiveFlareWork.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("Live Flare Work");
                }
                if (permit.EntryAndControlPlan != null &&
                    !permit.EntryAndControlPlan.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("Entry and Control Plan");
                }
                if (permit.EnergizedElectrical != null &&
                    !permit.EnergizedElectrical.Equals(WorkPermitSafetyFormState.NotApplicable))
                {
                    forms.Add("Energized Electrical JHA");
                }

                return forms.ToCommaSeparatedString();
            }
        }

        // Section 3 - Location
        public string FunctionalLocation
        {
            get { return IsEmptyAdapter ? null : permit.FunctionalLocation.FullHierarchy; }
        }

        public string Location
        {
            get { return permit.Location; }
        }

        // Section 4 - Description of Work
        public string TaskDescription
        {
            get { return permit.TaskDescription; }
        }

        public string TaskDescriptionTooLongWarning
        {
            get
            {
                return TaskDescriptionTooLong
                    ? "Please refer to the electronic version of the Safe Work Permit for the full Task Description as entered by the Permit Issuer."
                    : string.Empty;
            }
        }


        // Section 5 - Specific Hazards
        public bool HazardHydrocarbonGas
        {
            get { return permit.HazardHydrocarbonGas; }
        }

        public bool HazardHydrocarbonLiquid
        {
            get { return permit.HazardHydrocarbonLiquid; }
        }

        public bool HazardHydrogenSulphide
        {
            get { return permit.HazardHydrogenSulphide; }
        }

        public bool HazardInertGasAtmosphere
        {
            get { return permit.HazardInertGasAtmosphere; }
        }

        public bool HazardOxygenDeficiency
        {
            get { return permit.HazardOxygenDeficiency; }
        }

        public bool HazardRadioactiveSources
        {
            get { return permit.HazardRadioactiveSources; }
        }

        public bool HazardUndergroundOverheadHazards
        {
            get { return permit.HazardUndergroundOverheadHazards; }
        }

        public bool HazardDesignatedSubstance
        {
            get { return permit.HazardDesignatedSubstance; }
        }

        // Section 6 - Other Hazards
        public string OtherHazardsAndOrRequirements
        {
            get { return permit.OtherHazardsAndOrRequirements; }
        }

        public string HazardsTooLongWarning
        {
            get
            {
                return HazardsDescriptionToLong
                    ? "Please refer to the electronic version of the Safe Work Permit for the full Hazards and/or Requirements Description as entered by the Permit Issuer."
                    : string.Empty;
            }
        }


        // Section 7 - Other Areas and Units Affected
        public bool OtherAreasAndOrUnitsAffectedYes
        {
            get { return !IsEmptyAdapter && permit.OtherAreasAndOrUnitsAffected; }
        }

        public bool OtherAreasAndOrUnitsAffectedNo
        {
            get { return !IsEmptyAdapter && !permit.OtherAreasAndOrUnitsAffected; }
        }

        public string OtherAreasAndOrUnitsAffectedArea
        {
            get { return permit.OtherAreasAndOrUnitsAffected ? permit.OtherAreasAndOrUnitsAffectedArea : string.Empty; }
        }

        public string OtherAreasAndOrUnitsAffectedPersonNotified
        {
            get
            {
                return permit.OtherAreasAndOrUnitsAffected
                    ? permit.OtherAreasAndOrUnitsAffectedPersonNotified
                    : string.Empty;
            }
        }

        // Section 8 - Work Preparations Completed
        public bool WorkPreparationsCompletedNotApplicable
        {
            get { return permit.WorkPreparationsCompletedSectionNotApplicableToJob; }
        }

        public string ProductNormallyInPipingEquipment
        {
            get
            {
                return WorkPreparationsCompletedNotApplicable ? string.Empty : permit.ProductNormallyInPipingEquipment;
            }
        }

        public bool DepressuredDrainedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.DepressuredDrained == YesNoNotApplicable.YES);
            }
        }

        public bool DepressuredDrainedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.DepressuredDrained == YesNoNotApplicable.NO);
            }
        }

        public bool DepressuredDrainedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.DepressuredDrained == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool WaterWashedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.WaterWashed == YesNoNotApplicable.YES);
            }
        }

        public bool WaterWashedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.WaterWashed == YesNoNotApplicable.NO);
            }
        }

        public bool WaterWashedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.WaterWashed == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool ChemicallyWashedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.ChemicallyWashed == YesNoNotApplicable.YES);
            }
        }

        public bool ChemicallyWashedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.ChemicallyWashed == YesNoNotApplicable.NO);
            }
        }

        public bool ChemicallyWashedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.ChemicallyWashed == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool SteamedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Steamed == YesNoNotApplicable.YES);
            }
        }

        public bool SteamedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Steamed == YesNoNotApplicable.NO);
            }
        }

        public bool SteamedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Steamed == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool PurgedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Purged == YesNoNotApplicable.YES);
            }
        }

        public bool PurgedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Purged == YesNoNotApplicable.NO);
            }
        }

        public bool PurgedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Purged == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool DisconnectedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Disconnected == YesNoNotApplicable.YES);
            }
        }

        public bool DisconnectedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Disconnected == YesNoNotApplicable.NO);
            }
        }

        public bool DisconnectedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.Disconnected == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool DePressuredAndVentedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.DepressuredAndVented == YesNoNotApplicable.YES);
            }
        }

        public bool DePressuredAndVentedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.DepressuredAndVented == YesNoNotApplicable.NO);
            }
        }

        public bool DePressuredAndVentedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.DepressuredAndVented == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool VentilatedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Ventilated == YesNoNotApplicable.YES);
            }
        }

        public bool VentilatedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Ventilated == YesNoNotApplicable.NO);
            }
        }

        public bool VentilatedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.Ventilated == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool BlankedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Blanked == YesNoNotApplicable.YES);
            }
        }

        public bool BlankedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Blanked == YesNoNotApplicable.NO);
            }
        }

        public bool BlankedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.Blanked == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool DrainsCoveredYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.DrainsCovered == YesNoNotApplicable.YES);
            }
        }

        public bool DrainsCoveredNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.DrainsCovered == YesNoNotApplicable.NO);
            }
        }

        public bool DrainsCoveredNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.DrainsCovered == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool AreaBarricadedYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.AreaBarricaded == YesNoNotApplicable.YES);
            }
        }

        public bool AreaBarricadedNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable && permit.AreaBarricaded == YesNoNotApplicable.NO);
            }
        }

        public bool AreaBarricadedNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.AreaBarricaded == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public bool EnergySourcesLockedOutTaggedOutYes
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.EnergySourcesLockedOutTaggedOut == YesNoNotApplicable.YES);
            }
        }

        public bool EnergySourcesLockedOutTaggedOutNo
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.EnergySourcesLockedOutTaggedOut == YesNoNotApplicable.NO);
            }
        }

        public bool EnergySourcesLockedOutTaggedOutNA
        {
            get
            {
                return !IsEmptyAdapter &&
                       (!WorkPreparationsCompletedNotApplicable &&
                        permit.EnergySourcesLockedOutTaggedOut == YesNoNotApplicable.NOT_APPLICABLE);
            }
        }

        public string OtherPreparations
        {
            get { return WorkPreparationsCompletedNotApplicable ? string.Empty : permit.OtherPreparations; }
        }

        public string EnergyControlPlan
        {
            get { return WorkPreparationsCompletedNotApplicable ? string.Empty : permit.EnergyControlPlan; }
        }

        public string LockBoxNumber
        {
            get { return WorkPreparationsCompletedNotApplicable ? string.Empty : permit.LockBoxNumber; }
        }

        // Section 9 - Specific Requirements
        public bool SpecificRequirementsSectionNotApplicableToJob
        {
            get { return permit.SpecificRequirementsSectionNotApplicableToJob; }
        }

        public bool AttendedAtAllTimes
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.AttendedAtAllTimes; }
        }

        public bool EyeProtection
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.EyeProtection; }
        }

        public bool FallProtectionEquipment
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.FallProtectionEquipment; }
        }

        public bool FullBodyHarnessRetrieval
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.FullBodyHarnessRetrieval; }
        }

        public bool HearingProtection
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.HearingProtection; }
        }

        public bool ProtectiveClothing
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.ProtectiveClothing; }
        }

        public bool OtherPersonalProtectiveEquipmentChecked
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.Other1Checked; }
        }

        public string OtherPersonalProtectiveEquipmentText
        {
            get { return OtherPersonalProtectiveEquipmentChecked ? permit.Other1Value : string.Empty; }
        }

        public bool EquipmentBondedGrounded
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.EquipmentBondedGrounded; }
        }

        public bool FireBlanket
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.FireBlanket; }
        }

        public bool FireFightingEquipment
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.FireFightingEquipment; }
        }

        public bool FireWatch
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.FireWatch; }
        }

        public bool HydrantPermit
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.HydrantPermit; }
        }

        public bool WaterHose
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.WaterHose; }
        }

        public bool SteamHose
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.SteamHose; }
        }

        public bool OtherFireProtectiveEquipmentChecked
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.Other2Checked; }
        }

        public string OtherFireProtectiveEquipmentText
        {
            get { return OtherFireProtectiveEquipmentChecked ? permit.Other2Value : string.Empty; }
        }

        public bool AirMover
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.AirMover; }
        }

        public bool ContinuousGasMonitor
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.ContinuousGasMonitor; }
        }

        public bool DrowningProtection
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.DrowningProtection; }
        }

        public bool RespiratoryProtection
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.RespiratoryProtection; }
        }

        public bool OtherRespitoryProtectionChecked
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.Other3Checked; }
        }

        public string OtherRespitoryProtectionText
        {
            get { return OtherRespitoryProtectionChecked ? permit.Other3Value : string.Empty; }
        }

        public bool AdditionalLighting
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.AdditionalLighting; }
        }

        public bool DesignateHotOrColdCutChecked
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.DesignateHotOrColdCutChecked; }
        }

        public string DesignateHotOrColdCutValue
        {
            get { return DesignateHotOrColdCutChecked ? permit.DesignateHotOrColdCutValue : string.Empty; }
        }

        public bool HoistingEquipment
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.HoistingEquipment; }
        }

        public bool Ladder
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.Ladder; }
        }

        public bool MotorizedEquipment
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.MotorizedEquipment; }
        }

        public bool Scaffold
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.Scaffold; }
        }

        public bool ReferToTipsProcedure
        {
            get { return !SpecificRequirementsSectionNotApplicableToJob && permit.ReferToTipsProcedure; }
        }

        // Section 10 - Atmospheric Gas Test Results
        public bool GasDetectorBumpTested
        {
            get { return permit.GasDetectorBumpTested; }
        }

        public bool AtmosphericGasTestRequired
        {
            get { return permit.AtmosphericGasTestRequired; }
        }

        // Section 12 - Agreement and Signature
        public string StartDateYear
        {
            get { return IsEmptyAdapter ? string.Empty : permit.StartDateTime.Year.ToString().Substring(2, 2); }
        }

        public string StartDateMonth
        {
            get { return IsEmptyAdapter ? string.Empty : permit.StartDateTime.Month.ToString(TwoDigitFormat); }
        }

        public string StartDateDay
        {
            get { return IsEmptyAdapter ? string.Empty : permit.StartDateTime.Day.ToString(TwoDigitFormat); }
        }

        public string StartTime
        {
            get { return IsEmptyAdapter ? string.Empty : permit.StartDateTime.ToTimeString(); }
        }

        public string ExpireDateYear
        {
            get { return IsEmptyAdapter ? string.Empty : permit.ExpireDateTime.Year.ToString().Substring(2, 2); }
        }

        public string ExpireDateMonth
        {
            get { return IsEmptyAdapter ? string.Empty : permit.ExpireDateTime.Month.ToString(TwoDigitFormat); }
        }

        public string ExpireDateDay
        {
            get { return IsEmptyAdapter ? string.Empty : permit.ExpireDateTime.Day.ToString(TwoDigitFormat); }
        }

        public string ExpireTime
        {
            get { return IsEmptyAdapter ? string.Empty : permit.ExpireDateTime.ToTimeString(); }
        }
    }
}