using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class PermitRequestLubesMergeTool : AbstractMergeTool<PermitRequestLubes>
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<PermitRequestLubesMergeTool>();

        private const int MAX_LENGTH_OF_OP_LINE_TEXT = 144;
        private readonly List<WorkOrderImportData> workOrderImportDataList;

        public PermitRequestLubesMergeTool(List<WorkOrderImportData> workOrderImportDataList)
        {
            this.workOrderImportDataList = workOrderImportDataList;
        }

        public PermitRequestLubes Merge(List<PermitRequestLubes> permitRequestsToMerge)
        {
            if (permitRequestsToMerge == null || permitRequestsToMerge.Count == 0)
            {
                return null;
            }

            List<PermitRequestLubes> permitRequests = new List<PermitRequestLubes>(permitRequestsToMerge);

            permitRequests.Sort((pr1, pr2) => pr1.PermitKeySortValue.CompareTo(pr2.PermitKeySortValue));

            PermitRequestLubes anyPermitRequest = permitRequests[0];

            Date earliestStartDate;
            Date latestEndDate;
            
            bool isVehicleEntry;
            WorkPermitLubesType workPermitType = GetWorkPermitType(permitRequests, out isVehicleEntry);
            string description = BuildDescription(permitRequests);

            GetStartAndEndDateTimeInformation(out earliestStartDate, out latestEndDate, permitRequests);

            PermitRequestLubes mergedRequest = new PermitRequestLubes(null, latestEndDate, description, description, null, DataSource.SAP, anyPermitRequest.LastImportedByUser, anyPermitRequest.LastImportedDateTime, 
                anyPermitRequest.LastSubmittedByUser, anyPermitRequest.LastSubmittedDateTime, anyPermitRequest.CreatedBy, anyPermitRequest.CreatedDateTime, anyPermitRequest.LastModifiedBy, 
                anyPermitRequest.LastModifiedDateTime, anyPermitRequest.CreatedByRole);

            mergedRequest.FunctionalLocation = anyPermitRequest.FunctionalLocation; // SAP
            mergedRequest.Location = anyPermitRequest.Location; // SAP                                                
            mergedRequest.RequestedByGroup = anyPermitRequest.RequestedByGroup; // For sure from SAP

            mergedRequest.WorkPermitType = workPermitType;
            mergedRequest.IsVehicleEntry = isVehicleEntry;
            mergedRequest.Trade = anyPermitRequest.Trade; // SAP
            mergedRequest.SAPWorkCentre = anyPermitRequest.SAPWorkCentre; // SAP

            mergedRequest.RequestedStartDate = earliestStartDate;
            mergedRequest.EndDate = latestEndDate;
            SetStartTime(mergedRequest, permitRequestsToMerge);

            mergedRequest.ConfinedSpace = permitRequests.Exists(pr => pr.ConfinedSpace); // y
            mergedRequest.RescuePlan = permitRequests.Exists(pr => pr.RescuePlan); // y

            // Forms
            mergedRequest.HighEnergy = GetFormState(pr => pr.HighEnergy, permitRequests); // y
            mergedRequest.CriticalLift = GetFormState(pr => pr.CriticalLift, permitRequests); // y
            mergedRequest.Excavation = GetFormState(pr => pr.Excavation, permitRequests); // y
            mergedRequest.EnergyControlPlan = GetFormState(pr => pr.EnergyControlPlan, permitRequests); // y
            mergedRequest.EquivalencyProc = GetFormState(pr => pr.EquivalencyProc, permitRequests); // y
            mergedRequest.TestPneumatic = GetFormState(pr => pr.TestPneumatic, permitRequests); // y
            mergedRequest.LiveFlareWork = GetFormState(pr => pr.LiveFlareWork, permitRequests); // y
            mergedRequest.EntryAndControlPlan = GetFormState(pr => pr.EntryAndControlPlan, permitRequests); // y
            mergedRequest.EnergizedElectrical = GetFormState(pr => pr.EnergizedElectrical, permitRequests); // y
            
            // Specific hazards
            mergedRequest.HazardHydrocarbonGas = permitRequests.Exists(pr => pr.HazardHydrocarbonGas); // y
            mergedRequest.HazardHydrocarbonLiquid = permitRequests.Exists(pr => pr.HazardHydrocarbonLiquid); // y
            mergedRequest.HazardHydrogenSulphide = permitRequests.Exists(pr => pr.HazardHydrogenSulphide); // y
            mergedRequest.HazardInertGasAtmosphere = permitRequests.Exists(pr => pr.HazardInertGasAtmosphere); // y
            mergedRequest.HazardOxygenDeficiency = permitRequests.Exists(pr => pr.HazardOxygenDeficiency); // y 
            mergedRequest.HazardRadioactiveSources = permitRequests.Exists(pr => pr.HazardRadioactiveSources); // y
            mergedRequest.HazardUndergroundOverheadHazards = permitRequests.Exists(pr => pr.HazardUndergroundOverheadHazards); // y
            mergedRequest.HazardDesignatedSubstance = permitRequests.Exists(pr => pr.HazardDesignatedSubstance); // y

            // Specific requirements
            mergedRequest.FireWatch = permitRequests.Exists(pr => pr.FireWatch);
            mergedRequest.HydrantPermit = permitRequests.Exists(pr => pr.HydrantPermit);
            mergedRequest.DesignateHotOrColdCutChecked = permitRequests.Exists(pr => pr.DesignateHotOrColdCutChecked);
         
            SetWorkOrderSources(mergedRequest, permitRequests);

            mergedRequest.SpecificRequirementsSectionNotApplicableToJob = !mergedRequest.AtLeastOneAttributeInTheSpecificRequirementsSectionIsSelected();

            return mergedRequest;
        }

        private void SetStartTime(PermitRequestLubes mergedRequest, List<PermitRequestLubes> permitRequestsToMerge)
        {
            if (permitRequestsToMerge[0].RequestedByGroup.IsConstructionOrTurnaround)
            {
                mergedRequest.RequestedStartTimeDay = PermitRequestLubes.DefaultStartTimeForConstructionOrTurnaround;
            }
            else
            {
                PermitRequestLubes earliest = null;
                DateTime earliestDateTime = DateTime.MaxValue;

                foreach (PermitRequestLubes currentRequest in permitRequestsToMerge)
                {
                    DateTime currentDateTime = GetStartDateTime(currentRequest);

                    if (currentDateTime < earliestDateTime)
                    {
                        earliest = currentRequest;
                        earliestDateTime = currentDateTime;
                    }
                }

                if(earliest != null) // This should never be null
                {
                    mergedRequest.RequestedStartDate = earliest.RequestedStartDate;

                    Time time = new Time(earliestDateTime);

                    if (WorkPermitLubes.IsDayShift(time))
                    {
                        mergedRequest.RequestedStartTimeDay = time;
                    }
                    else
                    {
                        mergedRequest.RequestedStartTimeNight = time;
                    }     

                }                
            }
        }

        private DateTime GetStartDateTime(PermitRequestLubes request)
        {
            Time time = request.RequestedStartTimeDay ?? request.RequestedStartTimeNight;
            Date date = request.RequestedStartDate;

            return date.CreateDateTime(time);
        }

        private WorkPermitSafetyFormState GetFormState(Func<PermitRequestLubes, WorkPermitSafetyFormState> getStateToCheck, List<PermitRequestLubes> permitRequests)
        {
            if (permitRequests.Exists(pr => getStateToCheck(pr).Equals(WorkPermitSafetyFormState.Required)))
            {
                return WorkPermitSafetyFormState.Required;
            }

            return WorkPermitSafetyFormState.NotApplicable;
        }

        private string BuildDescription(List<PermitRequestLubes> permitRequests)
        {
            List<string> opLineDescriptions = new List<string>();

            string headerDescription = null;

            foreach (PermitRequestLubes permitRequest in permitRequests)
            {
                WorkOrderImportData workOrderImportData = workOrderImportDataList.Find(woid => permitRequest.ContainsWorkOrderSource(woid));

                if (workOrderImportData != null)
                {
                    string opLineText = workOrderImportData.LongText.TrimWhitespace();
                    
                    opLineText = opLineText.Truncate(MAX_LENGTH_OF_OP_LINE_TEXT, "");
                    opLineDescriptions.Add(opLineText);

                    if (headerDescription == null)
                    {
                        headerDescription = workOrderImportData.ShortText.TrimWhitespace(); // This is the "header" text from the import. It should be the same for all items that we are merging.
                    }
                }
                else
                {
                    logger.Error(string.Format(
                        "Problem: trying to merge a permit but the original data wasn't found in the import list when trying to build the description. " +
                        "Using the description from the pre-merged generated permit request. Work order: {0}-{1}-{2}", 
                            permitRequest.WorkOrderNumber, permitRequest.OperationNumberListAsString, permitRequest.SubOperationNumberListAsString));

                    opLineDescriptions.Add(permitRequest.Description);
                }
            }
                      
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(headerDescription);
            opLineDescriptions.ForEach(t => sb.AppendLine(t));

            return sb.ToString().TrimWhitespace();
        }

        private WorkPermitLubesType GetWorkPermitType(List<PermitRequestLubes> permitRequests, out bool isVehicleEntry)
        {
            if (permitRequests.Exists(pr => pr.IsVehicleEntry))
            {
                isVehicleEntry = true;
                return WorkPermitLubesType.HOT_WORK;
            }
                       
            if(permitRequests.Exists(pr => WorkPermitLubesType.HOT_WORK.Equals(pr.WorkPermitType)))
            {
                isVehicleEntry = false;
                return WorkPermitLubesType.HOT_WORK;
            }

            isVehicleEntry = false;
            return WorkPermitLubesType.HAZARDOUS_COLD_WORK;
        }
    }
}
