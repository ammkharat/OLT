using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class WorkPermitEdmontonReportAdapter : DomainObject, IReportAdapter
    {
        private readonly WorkPermitEdmonton permit;
        private readonly bool taskDescriptionTooLong;

        public WorkPermitEdmontonReportAdapter(WorkPermitEdmonton permit, bool taskDescriptionTooLong)
        {
            this.permit = permit;
            this.taskDescriptionTooLong = taskDescriptionTooLong;
        }

        public string WorkPermitTitle
        {
            get { return string.Format("{0} - Safe Work Permit", WorkPermitType); }
        }

        public string WorkPermitStatus
        {
            get { return permit.WorkPermitStatus.ToString(); }
        }

        public string DataSource
        {
            get { return permit.DataSource.ToString(); }
        }

        public string PermitNumber
        {
            get { return permit.PermitNumber.NullableToString(); }
        }

        public bool IssuedToSuncor
        {
            get { return permit.IssuedToSuncor; }
        }

        public bool IssuedToContractor
        {
            get { return permit.IssuedToCompany; }
        }

        public bool IsRoutineMaintenanceType
        {
            get { return permit.WorkPermitType == WorkPermitEdmontonType.ROUTINE_MAINTENANCE; }
        }

        public bool IsColdWorkType
        {
            get { return permit.WorkPermitType == WorkPermitEdmontonType.COLD_WORK; }
        }

        public bool IsNormalHotWorkType
        {
            get { return permit.WorkPermitType == WorkPermitEdmontonType.HOT_WORK; }
        }

        public bool IsHighEnergyHotWorkType
        {
            get { return permit.WorkPermitType == WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK; }
        }

        public bool IsDurationPermitType
        {
            get { return permit.DurationPermit; }
        }

        public string Company
        {
            get { return permit.Company; }
        }

        public string Occupation
        {
            get { return permit.Occupation; }
        }

        public int? NumberOfWorkers
        {
            get { return permit.NumberOfWorkers; }
        }

        public string Group
        {
            get { return permit.Group != null ? permit.Group.Name : string.Empty; }
        }

        public string WorkPermitType
        {
            get { return permit.WorkPermitType.ToString(); }
        }

        public string FunctionalLocation
        {
            get { return permit.FunctionalLocation.FullHierarchy; }
        }

        public string Location
        {
            get { return permit.Location; }
        }

        public bool AlkylationEntry
        {
            get { return permit.AlkylationEntry; }
        }

        public string AlkylationEntryClassOfClothing
        {
            get { return permit.AlkylationEntryClassOfClothing; }
        }

        public bool FlarePitEntry
        {
            get { return permit.FlarePitEntry; }
        }

        public string FlarePitEntryType
        {
            get { return permit.FlarePitEntryType; }
        }

        public bool ConfinedSpace
        {
            get { return permit.ConfinedSpace; }
        }

        public string ConfinedSpaceCardNumber
        {
            get { return permit.ConfinedSpaceCardNumber; }
        }

        public string ConfinedSpaceClass
        {
            get { return permit.ConfinedSpaceClass; }
        }

        public bool RescuePlan
        {
            get { return permit.RescuePlan; }
        }

        public string RescuePlanFormNumber
        {
            get { return permit.RescuePlanFormNumber; }
        }

        public bool VehicleEntry
        {
            get { return permit.VehicleEntry; }
        }

        public int? VehicleEntryTotal
        {
            get { return permit.VehicleEntryTotal; }
        }

        public string VehicleEntryType
        {
            get { return permit.VehicleEntryType; }
        }

        public bool SpecialWork
        {
            get { return permit.SpecialWork; }
        }

        public string SpecialWorkFormNumber
        {
            get { return permit.SpecialWorkFormNumber; }
        }

        public string SpecialWorkType
        {
            //get { return permit.SpecialWorkType != null ? permit.SpecialWorkType.Name : null; }
            get { return permit.SpecialWorkName; }
        }

        public bool RoadAccessOnPermit
        {
            get { return permit.RoadAccessOnPermit; }
        }

        public string RoadAccessOnPermitFormNumber
        {
            get { return permit.RoadAccessOnPermitFormNumber; }
        }

        public string RoadAccessOnPermitType
        {
            get { return permit.RoadAccessOnPermitType; }
        }

        public long? GN59FormNumber
        {
            get { return permit.FormGN59 != null ? permit.FormGN59.FormNumber : default(long?); }
        }

        public long? GN7FormNumber
        {
            get { return permit.FormGN7 != null ? permit.FormGN7.FormNumber : default(long?); }
        }

        public long? GN24FormNumber
        {
            get { return permit.FormGN24 != null ? permit.FormGN24.FormNumber : default(long?); }
        }

        public long? GN6FormNumber
        {
            get { return permit.FormGN6 != null ? permit.FormGN6.FormNumber : default(long?); }
        }

        public long? GN75AFormNumber
        {
            get { return permit.FormGN75A != null ? permit.FormGN75A.FormNumber : default(long?); }
        }

        public string GN6
        {
            get { return permit.GN6.ToString(); }
        }

        public string GN11
        {
            get { return permit.GN11.ToString(); }
        }

        public string GN27
        {
            get { return permit.GN27.ToString(); }
        }

        public string Forms
        {
            get
            {
                var forms = new List<string>();

                if (permit.GN6)
                {
                    if (permit.FormGN6 != null)
                    {
                        forms.Add(string.Format("GN-6 #{0}", permit.FormGN6.FormNumber));
                    }
                    else
                    {
                        forms.Add("GN-6");
                    }
                }

                if (permit.FormGN7 != null)
                {
                    forms.Add(string.Format("GN-7 #{0}", permit.FormGN7.FormNumber));
                }

                if (permit.GN11 == WorkPermitSafetyFormState.Approved)
                {
                    forms.Add("GN-11");
                }

                if (permit.GN24)
                {
                    if (permit.FormGN24 != null)
                    {
                        forms.Add(string.Format("GN-24 #{0}", permit.FormGN24.FormNumber));
                    }
                    else
                    {
                        forms.Add("GN-24");
                    }
                }

                if (permit.GN75A)
                {
                    if (permit.FormGN75A != null)
                    {
                        forms.Add(string.Format("GN-75A #{0}", permit.FormGN75A.FormNumber));
                    }
                    else
                    {
                        forms.Add("GN-75A");
                    }
                }

                if (permit.GN27 == WorkPermitSafetyFormState.Approved)
                {
                    forms.Add("GN-27");
                }

                if (permit.FormGN59 != null)
                {
                    forms.Add(string.Format("GN-59 #{0}", permit.FormGN59.FormNumber));
                }

                if (permit.FormGN1 != null && permit.FormGN1TradeChecklistId.HasValue &&
                    permit.FormGN1TradeChecklistDisplayNumber.HasValue())
                {
                    forms.Add(string.Format("GN-1 #{0}", permit.FormGN1TradeChecklistDisplayNumber));
                }

                return forms.ToCommaSeparatedString();
            }
        }

        public string RequestedStartDateTime
        {
            get { return permit.RequestedStartDateTime.ToShortDateString(); }
        }

        public DateTime? IssuedDateTime
        {
            get { return permit.IssuedDateTime; }
        }

        public DateTime ExpiredDateTime
        {
            get { return permit.ExpiredDateTime; }
        }

        public string WorkOrderNumber
        {
            get { return permit.WorkOrderNumber; }
        }

        public string OperationNumber
        {
            get { return permit.OperationNumber; }
        }

        public string SubOperationNumber
        {
            get { return permit.SubOperationNumber; }
        }

        public string TaskDescription
        {
            get { return permit.TaskDescription; }
        }

        public string TaskDescriptionTooLongWarning
        {
            get
            {
                if (taskDescriptionTooLong)
                {
                    return
                        "Please refer to the electronic version of the Safe Work Permit for the full Task Description as entered by the Permit Issuer.";
                }
                return string.Empty;
            }
        }

        public string HazardsAndOrRequirements
        {
            get { return permit.HazardsAndOrRequirements; }
        }

        public bool OtherAreasAndOrUnitsAffectedYes
        {
            get { return !permit.OtherAreasAndOrUnitsAffectedArea.IsNullOrEmptyOrWhitespace(); }
        }

        public bool OtherAreasAndOrUnitsAffectedNo
        {
            get { return !OtherAreasAndOrUnitsAffectedYes; }
        }

        public string OtherAreasAndOrUnitsAffectedArea
        {
            get { return permit.OtherAreasAndOrUnitsAffectedArea; }
        }

        public string OtherAreasAndOrUnitsAffectedPersonNotified
        {
            get { return permit.OtherAreasAndOrUnitsAffectedPersonNotified; }
        }

        // Status of Piping/Equipment
        public bool StatusOfPipingEquipmentSectionNotApplicableToJob
        {
            get { return permit.StatusOfPipingEquipmentSectionNotApplicableToJob; }
        }

        public string ProductNormallyInPipingEquipment
        {
            get { return permit.ProductNormallyInPipingEquipment; }
        }

        public bool IsolationValvesLockedYes
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.IsolationValvesLocked == YesNoNotApplicable.YES;
            }
        }

        public bool IsolationValvesLockedNo
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.IsolationValvesLocked == YesNoNotApplicable.NO;
            }
        }

        public bool IsolationValvesLockedNA
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.IsolationValvesLocked == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public bool DepressuredDrainedYes
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.DepressuredDrained == YesNoNotApplicable.YES;
            }
        }

        public bool DepressuredDrainedNo
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.DepressuredDrained == YesNoNotApplicable.NO;
            }
        }

        public bool DepressuredDrainedNA
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.DepressuredDrained == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public bool VentilatedYes
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob && permit.Ventilated == YesNoNotApplicable.YES;
            }
        }

        public bool VentilatedNo
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob && permit.Ventilated == YesNoNotApplicable.NO;
            }
        }

        public bool VentilatedNA
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.Ventilated == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public bool PurgedYes
        {
            get { return !StatusOfPipingEquipmentSectionNotApplicableToJob && permit.Purged == YesNoNotApplicable.YES; }
        }

        public bool PurgedNo
        {
            get { return !StatusOfPipingEquipmentSectionNotApplicableToJob && permit.Purged == YesNoNotApplicable.NO; }
        }

        public bool PurgedNA
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.Purged == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public bool BlindedAndTaggedYes
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.BlindedAndTagged == YesNoNotApplicable.YES;
            }
        }

        public bool BlindedAndTaggedNo
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.BlindedAndTagged == YesNoNotApplicable.NO;
            }
        }

        public bool BlindedAndTaggedNa
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.BlindedAndTagged == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public bool DoubleBlockAndBleedYes
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.DoubleBlockAndBleed == YesNoNotApplicable.YES;
            }
        }

        public bool DoubleBlockAndBleedNo
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.DoubleBlockAndBleed == YesNoNotApplicable.NO;
            }
        }

        public bool DoubleBlockAndBleedNA
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.DoubleBlockAndBleed == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public bool ElectricalLockoutYes
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.ElectricalLockout == YesNoNotApplicable.YES;
            }
        }

        public bool ElectricalLockoutNo
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.ElectricalLockout == YesNoNotApplicable.NO;
            }
        }

        public bool ElectricalLockoutNA
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.ElectricalLockout == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public bool MechanicalLockoutYes
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.MechanicalLockout == YesNoNotApplicable.YES;
            }
        }

        public bool MechanicalLockoutNo
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.MechanicalLockout == YesNoNotApplicable.NO;
            }
        }

        public bool MechanicalLockoutNA
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.MechanicalLockout == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public bool BlindSchematicAvailableYes
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.BlindSchematicAvailable == YesNoNotApplicable.YES;
            }
        }

        public bool BlindSchematicAvailableNA
        {
            get
            {
                return !StatusOfPipingEquipmentSectionNotApplicableToJob &&
                       permit.BlindSchematicAvailable == YesNoNotApplicable.NOT_APPLICABLE;
            }
        }

        public string ZeroEnergyFormNumber
        {
            get
            {
                return StatusOfPipingEquipmentSectionNotApplicableToJob ? string.Empty : permit.ZeroEnergyFormNumber;
            }
        }

        public string LockBoxNumber
        {
            get { return StatusOfPipingEquipmentSectionNotApplicableToJob ? string.Empty : permit.LockBoxNumber; }
        }

        public bool JobsiteEquipmentInspectedYes
        {
            get { return !StatusOfPipingEquipmentSectionNotApplicableToJob && permit.JobsiteEquipmentInspected; }
        }

        public bool JobsiteEquipmentInspectedNo
        {
            get { return !permit.JobsiteEquipmentInspected; }    // !StatusOfPipingEquipmentSectionNotApplicableToJob &&  //ayman Edmonton work permit
        }

        //ayman Edmonton work permit
        public bool SignatureForJobSiteInspected
        {
            get { return permit.JobsiteEquipmentInspected; }
        }



        // Confined space work 
        public bool ConfinedSpaceWorkSectionNotApplicableToJob
        {
            get { return permit.ConfinedSpaceWorkSectionNotApplicableToJob; }
        }

        public bool QuestionOneYes
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.YES.Equals(permit.QuestionOneResponse);
            }
        }

        public bool QuestionTwoYes
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.YES.Equals(permit.QuestionTwoResponse);
            }
        }

        public bool QuestionTwoNo
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.NO.Equals(permit.QuestionTwoResponse);
            }
        }

        public bool QuestionTwoNotApplicable
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.NOT_APPLICABLE.Equals(permit.QuestionTwoResponse);
            }
        }

        public bool QuestionTwoAYes
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.YES.Equals(permit.QuestionTwoAResponse);
            }
        }

        public bool QuestionTwoANotApplicable
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.NOT_APPLICABLE.Equals(permit.QuestionTwoAResponse);
            }
        }

        public bool QuestionTwoBYes
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.YES.Equals(permit.QuestionTwoBResponse);
            }
        }

        public bool QuestionTwoBNotApplicable
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.NOT_APPLICABLE.Equals(permit.QuestionTwoBResponse);
            }
        }

        public bool QuestionThreeYes
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.YES.Equals(permit.QuestionThreeResponse);
            }
        }

        public bool QuestionThreeNotApplicable
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.NOT_APPLICABLE.Equals(permit.QuestionThreeResponse);
            }
        }

        public bool QuestionFourYes
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.YES.Equals(permit.QuestionFourResponse);
            }
        }

        public bool QuestionFourNo
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.NO.Equals(permit.QuestionFourResponse);
            }
        }

        public bool QuestionFourNotApplicable
        {
            get
            {
                return !ConfinedSpaceWorkSectionNotApplicableToJob &&
                       YesNoNotApplicable.NOT_APPLICABLE.Equals(permit.QuestionFourResponse);
            }
        }

        // Gas Tests
        public bool GasTestsSectionNotApplicableToJob
        {
            get { return permit.GasTestsSectionNotApplicableToJob; }
        }

        public string OperatorGasDetectorNumber
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.OperatorGasDetectorNumber; }
        }

        public string GasTestDataLine1CombustibleGas
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine1CombustibleGas; }
        }

        public string GasTestDataLine1Oxygen
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine1Oxygen; }
        }

        public string GasTestDataLine1ToxicGas
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine1ToxicGas; }
        }

        public string GasTestDataLine1Time
        {
            get
            {
                return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine1Time.NullableToString();
            }
        }

        public string GasTestDataLine2CombustibleGas
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine2CombustibleGas; }
        }

        public string GasTestDataLine2Oxygen
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine2Oxygen; }
        }

        public string GasTestDataLine2ToxicGas
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine2ToxicGas; }
        }

        public string GasTestDataLine2Time
        {
            get
            {
                return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine2Time.NullableToString();
            }
        }

        public string GasTestDataLine3CombustibleGas
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine3CombustibleGas; }
        }

        public string GasTestDataLine3Oxygen
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine3Oxygen; }
        }

        public string GasTestDataLine3ToxicGas
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine3ToxicGas; }
        }

        public string GasTestDataLine3Time
        {
            get
            {
                return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine3Time.NullableToString();
            }
        }

        public string GasTestDataLine4CombustibleGas
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine4CombustibleGas; }
        }

        public string GasTestDataLine4Oxygen
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine4Oxygen; }
        }

        public string GasTestDataLine4ToxicGas
        {
            get { return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine4ToxicGas; }
        }

        public string GasTestDataLine4Time
        {
            get
            {
                return GasTestsSectionNotApplicableToJob ? string.Empty : permit.GasTestDataLine4Time.NullableToString();
            }
        }

        //Workers Minimum Safety Requirements
        public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob
        {
            get { return permit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob; }
        }

        public bool FaceShield
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.FaceShield; }
        }

        public bool Goggles
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.Goggles; }
        }

        public bool RubberBoots
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.RubberBoots; }
        }

        public bool RubberGloves
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.RubberGloves; }
        }

        public bool RubberSuit
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.RubberSuit; }
        }

        public bool SafetyHarnessLifeline
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.SafetyHarnessLifeline; }
        }

        public bool HighVoltagePPE
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.HighVoltagePPE; }
        }

        public bool Other1HasValue
        {
            get
            {
                return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob &&
                       !permit.Other1.IsNullOrEmptyOrWhitespace();
            }
        }

        public string Other1
        {
            get { return WorkersMinimumSafetyRequirementsSectionNotApplicableToJob ? string.Empty : permit.Other1; }
        }

        public bool EquipmentGrounded
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.EquipmentGrounded; }
        }

        public bool FireBlanket
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.FireBlanket; }
        }

        public bool FireExtinguisher
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.FireExtinguisher; }
        }

        public bool FireMonitorManned
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.FireMonitorManned; }
        }

        public bool FireWatch
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.FireWatch; }
        }

        public bool SewersDrainsCovered
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.SewersDrainsCovered; }
        }

        public bool SteamHose
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.SteamHose; }
        }

        public bool Other2HasValue
        {
            get
            {
                return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob &&
                       !permit.Other2.IsNullOrEmptyOrWhitespace();
            }
        }

        public string Other2
        {
            get { return WorkersMinimumSafetyRequirementsSectionNotApplicableToJob ? string.Empty : permit.Other2; }
        }

        public bool AirPurifyingRespirator
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.AirPurifyingRespirator; }
        }

        public bool BreathingAirApparatus
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.BreathingAirApparatus; }
        }

        public bool DustMask
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.DustMask; }
        }

        public bool LifeSupportSystem
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.LifeSupportSystem; }
        }

        public bool SafetyWatch
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.SafetyWatch; }
        }

        public bool ContinuousGasMonitor
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.ContinuousGasMonitor; }
        }

        public bool WorkersMonitorNumberHasValue
        {
            get
            {
                return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob &&
                       !permit.WorkersMonitorNumber.IsNullOrEmptyOrWhitespace();
            }
        }

        public string WorkersMonitorNumber
        {
            get
            {
                return WorkersMinimumSafetyRequirementsSectionNotApplicableToJob
                    ? string.Empty
                    : permit.WorkersMonitorNumber;
            }
        }

        public bool BumpTestMonitorPriorToUse
        {
            get
            {
                return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.BumpTestMonitorPriorToUse;
            }
        }

        public bool Other3HasValue
        {
            get
            {
                return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob &&
                       !permit.Other3.IsNullOrEmptyOrWhitespace();
            }
        }

        public string Other3
        {
            get { return WorkersMinimumSafetyRequirementsSectionNotApplicableToJob ? string.Empty : permit.Other3; }
        }

        public bool AirMover
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.AirMover; }
        }

        public bool BarriersSigns
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.BarriersSigns; }
        }

        public bool RadioChannelNumberHasValue
        {
            get
            {
                return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob &&
                       !permit.RadioChannelNumber.IsNullOrEmptyOrWhitespace();
            }
        }

        public string RadioChannelNumber
        {
            get
            {
                return WorkersMinimumSafetyRequirementsSectionNotApplicableToJob
                    ? string.Empty
                    : permit.RadioChannelNumber;
            }
        }

        public bool AirHorn
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.AirHorn; }
        }

        public bool MechVentilationComfortOnly
        {
            get
            {
                return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.MechVentilationComfortOnly;
            }
        }

        public bool AsbestosMMCPrecautions
        {
            get { return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob && permit.AsbestosMMCPrecautions; }
        }

        public bool Other4HasValue
        {
            get
            {
                return !WorkersMinimumSafetyRequirementsSectionNotApplicableToJob &&
                       !permit.Other4.IsNullOrEmptyOrWhitespace();
            }
        }

        public string Other4
        {
            get { return WorkersMinimumSafetyRequirementsSectionNotApplicableToJob ? string.Empty : permit.Other4; }
        }

        public string CreatedDateTime
        {
            get { return permit.CreatedDateTime.ToString(); }
        }

        public string CreatedBy
        {
            get { return permit.CreatedBy.FullNameWithUserName; }
        }

        public string IssuedByUser
        {
            get { return permit.IssuedByUser != null ? permit.IssuedByUser.FullNameWithFirstNameFirst : string.Empty; }
        } // This should never be null when printing but I'm paranoid since its nullable in the DB

        public string PermitAcceptor
        {
            get { return permit.PermitAcceptor; }
        }

        public string ShiftSupervisor
        {
            get { return permit.ShiftSupervisor; }
        }

        public string WaterMarkText { get; set; }

        public WorkPermitEdmonton Permit
        {
            get { return permit; }
        }

        //DMND0010609-OLT - Edmonton Work permit Scan
        public string WorkpermitScanText
        { get; set; }
    }
}