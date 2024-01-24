using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class PermitRequestEdmontonMergeTool : AbstractMergeTool<PermitRequestEdmonton>
    {
        private readonly List<WorkPermitEdmontonType> PriorityList = new List<WorkPermitEdmontonType> { WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK, WorkPermitEdmontonType.HOT_WORK, WorkPermitEdmontonType.COLD_WORK, WorkPermitEdmontonType.ROUTINE_MAINTENANCE };        

        public PermitRequestEdmonton Merge(List<PermitRequestEdmonton> permitRequests)
        {
            if (permitRequests == null || permitRequests.Count == 0)
            {
                return null;
            }

            // several fields on the incoming permit requests are going to be the same, so pick a permit request to use just to get those shared fields
            PermitRequestEdmonton anyPermitRequest = permitRequests[0];

            PermitRequestEdmonton mergedRequest = new PermitRequestEdmonton(null, anyPermitRequest.EndDate, null, null, null, anyPermitRequest.DataSource, anyPermitRequest.LastImportedByUser, 
                anyPermitRequest.LastImportedDateTime, null, null, anyPermitRequest.CreatedBy, anyPermitRequest.CreatedDateTime, anyPermitRequest.LastModifiedBy, anyPermitRequest.LastModifiedDateTime);

            mergedRequest.Group = anyPermitRequest.Group;
            mergedRequest.FunctionalLocation = anyPermitRequest.FunctionalLocation;
            mergedRequest.Location = anyPermitRequest.Location;
            mergedRequest.Occupation = anyPermitRequest.Occupation;
            mergedRequest.SAPWorkCentre = anyPermitRequest.SAPWorkCentre;
            mergedRequest.WorkOrderNumber = anyPermitRequest.WorkOrderNumber;
            mergedRequest.AreaLabel = anyPermitRequest.AreaLabel;

            mergedRequest.AlkylationEntry = GetBooleanValue(permitRequests.ConvertAll(r => r.AlkylationEntry));
            mergedRequest.FlarePitEntry = GetBooleanValue(permitRequests.ConvertAll(r => r.FlarePitEntry));
            mergedRequest.ConfinedSpace = GetBooleanValue(permitRequests.ConvertAll(r => r.ConfinedSpace));
            mergedRequest.ConfinedSpaceClass = GetConfinedSpaceClass(permitRequests);

            mergedRequest.RescuePlan = GetBooleanValue(permitRequests.ConvertAll(r => r.RescuePlan));
            mergedRequest.VehicleEntry = GetBooleanValue(permitRequests.ConvertAll(r => r.VehicleEntry));
            SetSpecialWorkAndSpecialWorkType(mergedRequest, permitRequests);

            mergedRequest.GN59 = permitRequests.Exists(r => r.GN59);
            mergedRequest.GN6 = permitRequests.Exists(r => r.GN6);
            mergedRequest.GN7 = permitRequests.Exists(r => r.GN7);
            mergedRequest.GN24 = permitRequests.Exists(r => r.GN24);
            mergedRequest.GN75A = permitRequests.Exists(r => r.GN75A);

            mergedRequest.GN11 = GetSafetyFormState(permitRequests.ConvertAll(r => r.GN11));
            mergedRequest.GN27 = GetSafetyFormState(permitRequests.ConvertAll(r => r.GN27));            

            mergedRequest.Description = BuildDescription(permitRequests.ConvertAll(r => r.Description));
            mergedRequest.SapDescription = BuildDescription(permitRequests.ConvertAll(r => r.SapDescription));

            mergedRequest.WorkPermitType = ChoosePermitType(permitRequests.ConvertAll(r => r.WorkPermitType));
            mergedRequest.Priority = ChoosePriority(permitRequests.ConvertAll(r => r.Priority));

            SetMinimumSafetyRequirementsValues(mergedRequest, permitRequests);

            Date earliestStartDate;
            Date latestEndDate;

            GetStartAndEndDateTimeInformation(out earliestStartDate, out latestEndDate, permitRequests);

            mergedRequest.RequestedStartDate = earliestStartDate;
            mergedRequest.RequestedStartTimeDay = WorkPermitEdmonton.PermitDefaultDayStart;
            mergedRequest.RequestedStartTimeNight = null;
            mergedRequest.EndDate = latestEndDate;        

            SetWorkOrderSources(mergedRequest, permitRequests);

            mergedRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = !mergedRequest.AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected();

            return mergedRequest;
        }

        private string GetConfinedSpaceClass(List<PermitRequestEdmonton> permitRequests)
        {
            const int fakeHighestLevel = 4;                      
            int highestPriorityLevel = fakeHighestLevel;

            foreach (PermitRequestEdmonton currentPermitRequest in permitRequests)
            {
                int currentLevel = string.IsNullOrEmpty(currentPermitRequest.ConfinedSpaceClass) ? fakeHighestLevel : Convert.ToInt32(currentPermitRequest.ConfinedSpaceClass);

                if(currentLevel < highestPriorityLevel)
                {
                    highestPriorityLevel = currentLevel;
                }
            }

            return highestPriorityLevel == fakeHighestLevel ? null : highestPriorityLevel.ToString();
        }

        private Priority ChoosePriority(List<Priority> priorities)
        {
            return Priority.CriticalPath.IsOneOf(priorities) ? Priority.CriticalPath : Priority.Normal;
        }

        private void SetSpecialWorkAndSpecialWorkType(PermitRequestEdmonton mergedRequest, List<PermitRequestEdmonton> permitRequests)
        {
            mergedRequest.SpecialWork = GetBooleanValue(permitRequests.ConvertAll(r => r.SpecialWork));

            List<EdmontonPermitSpecialWorkType> uniqueTypes = permitRequests.FindAll(pr => pr.SpecialWorkType != null).ConvertAll(pr => pr.SpecialWorkType).Unique();

            if (uniqueTypes.Count == 1)
            {
                mergedRequest.SpecialWorkType = uniqueTypes[0];
            }
            else
            {
                mergedRequest.SpecialWorkType = null;
            }
        }
              
        private void SetMinimumSafetyRequirementsValues(PermitRequestEdmonton mergedRequest, List<PermitRequestEdmonton> permitRequests)
        {
            mergedRequest.AirHorn = GetBooleanValue(permitRequests.ConvertAll(r => r.AirHorn));
            mergedRequest.AirMover = GetBooleanValue(permitRequests.ConvertAll(r => r.AirMover));
            mergedRequest.AirPurifyingRespirator = GetBooleanValue(permitRequests.ConvertAll(r => r.AirPurifyingRespirator));
            mergedRequest.AsbestosMMCPrecautions = GetBooleanValue(permitRequests.ConvertAll(r => r.AsbestosMMCPrecautions));
            mergedRequest.BarriersSigns = GetBooleanValue(permitRequests.ConvertAll(r => r.BarriersSigns));
            mergedRequest.BreathingAirApparatus = GetBooleanValue(permitRequests.ConvertAll(r => r.BreathingAirApparatus));
            mergedRequest.BumpTestMonitorPriorToUse = GetBooleanValue(permitRequests.ConvertAll(r => r.BumpTestMonitorPriorToUse));
            mergedRequest.ContinuousGasMonitor = GetBooleanValue(permitRequests.ConvertAll(r => r.ContinuousGasMonitor));
            mergedRequest.DustMask = GetBooleanValue(permitRequests.ConvertAll(r => r.DustMask));
            mergedRequest.EquipmentGrounded = GetBooleanValue(permitRequests.ConvertAll(r => r.EquipmentGrounded));
            mergedRequest.FaceShield = GetBooleanValue(permitRequests.ConvertAll(r => r.FaceShield));
            mergedRequest.FireBlanket = GetBooleanValue(permitRequests.ConvertAll(r => r.FireBlanket));
            mergedRequest.FireExtinguisher = GetBooleanValue(permitRequests.ConvertAll(r => r.FireExtinguisher));
            mergedRequest.FireMonitorManned = GetBooleanValue(permitRequests.ConvertAll(r => r.FireMonitorManned));
            mergedRequest.FireWatch = GetBooleanValue(permitRequests.ConvertAll(r => r.FireWatch));
            mergedRequest.Goggles = GetBooleanValue(permitRequests.ConvertAll(r => r.Goggles));
            mergedRequest.HighVoltagePPE = GetBooleanValue(permitRequests.ConvertAll(r => r.HighVoltagePPE));
            mergedRequest.LifeSupportSystem = GetBooleanValue(permitRequests.ConvertAll(r => r.LifeSupportSystem));
            mergedRequest.MechVentilationComfortOnly = GetBooleanValue(permitRequests.ConvertAll(r => r.MechVentilationComfortOnly));
            mergedRequest.RadioChannel = GetBooleanValue(permitRequests.ConvertAll(r => r.RadioChannel));
            mergedRequest.RubberBoots = GetBooleanValue(permitRequests.ConvertAll(r => r.RubberBoots));
            mergedRequest.RubberGloves = GetBooleanValue(permitRequests.ConvertAll(r => r.RubberGloves));
            mergedRequest.RubberSuit = GetBooleanValue(permitRequests.ConvertAll(r => r.RubberSuit));
            mergedRequest.SafetyHarnessLifeline = GetBooleanValue(permitRequests.ConvertAll(r => r.SafetyHarnessLifeline));
            mergedRequest.SafetyWatch = GetBooleanValue(permitRequests.ConvertAll(r => r.SafetyWatch));
            mergedRequest.SewersDrainsCovered = GetBooleanValue(permitRequests.ConvertAll(r => r.SewersDrainsCovered));
            mergedRequest.SteamHose = GetBooleanValue(permitRequests.ConvertAll(r => r.SteamHose));
            mergedRequest.WorkersMonitor = GetBooleanValue(permitRequests.ConvertAll(r => r.WorkersMonitor));
        }

        private bool GetBooleanValue(List<bool> values)
        {
            return true.IsOneOf(values);
        }

        private WorkPermitSafetyFormState GetSafetyFormState(List<WorkPermitSafetyFormState> safetyFormStates)
        {
            if (WorkPermitSafetyFormState.Required.IsOneOf(safetyFormStates))
            {
                return WorkPermitSafetyFormState.Required;
            }
            return WorkPermitSafetyFormState.NotApplicable;
        }

        private WorkPermitEdmontonType ChoosePermitType(List<WorkPermitEdmontonType> permitTypes)
        {
            int lowestIndex = PriorityList.IndexOf(permitTypes[0]);

            foreach (WorkPermitEdmontonType workPermitEdmontonType in permitTypes)
            {
                int index = PriorityList.IndexOf(workPermitEdmontonType);
                if (index < lowestIndex)
                {
                    lowestIndex = index;
                }
            }

            return PriorityList[lowestIndex];
        }

        private string BuildDescription(List<string> descriptions)
        {
            List<string> pieces = new List<string>();

            foreach (string description in descriptions)
            {
                if (description != null)
                {
                    pieces.Add(string.Format("-> {0}", description.Truncate(300)));    
                }                
            }

            return pieces.Join(Environment.NewLine);
        }
    }
}