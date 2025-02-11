﻿using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using System;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class WorkPermitSarniaReportAdapter : IReportAdapter
    {
        private readonly WorkPermit workpermit;//Added by ppanigrahi
        public WorkPermitSarniaReportAdapter(WorkPermit workPermit, string watermarkText)
        {
            // page one of the report
            //if else condition is added by ppanigrahi
            if (workPermit.ExtensionEnable)
            {
                PermitNumber = workPermit.PermitNumber + "-E"+workPermit.Extension;

            }
            else if (workPermit.RevalidationEnable)
            {
                PermitNumber = workPermit.PermitNumber + "-R"+workPermit.Revalidation;
            }
            else
            {
                PermitNumber = workPermit.PermitNumber;

            }

            

            IsColdType = workPermit.WorkPermitType.IsSame(WorkPermitType.COLD);
            IsHotType = workPermit.WorkPermitType.IsSame(WorkPermitType.HOT);

            var createdByUser = workPermit.CreatedBy;
            InitiatedByUser = createdByUser != null ? createdByUser.FullNameWithUserName : string.Empty;
            var approvedByUser = workPermit.ApprovedBy;
            ApprovedByUser = approvedByUser != null ? approvedByUser.FullNameWithUserName : string.Empty;
            ISSUER_NAME = Convert.ToString(approvedByUser.FirstName).ToUpper() + " " + Convert.ToString(approvedByUser.LastName).ToUpper();
            SetPermitAttributes(workPermit.Attributes);
            SetAdditionalForms(workPermit.AdditionItemsRequired);
            SetLocationAndJobSpecificsAndScope(workPermit.Specifics, workPermit.DocumentLinks);
            SetEquipmentPreparation(workPermit.EquipmentPreparationCondition);
            SetAsbestos(workPermit.Asbestos);
            SetJobWorksitePreparation(workPermit.JobWorksitePreparation);
            SetCommunicationMethods(workPermit.Specifics);

            // page 2 of the report
            SetConfinedSpaceRequirements(workPermit.FireConfinedSpaceRequirements);
            SetRespitoryProtectionRequirements(workPermit.RespiratoryProtectionRequirements);
            SetPPERequirements(workPermit.SpecialProtectionRequirements);

            SetGasTestInfomation(workPermit.GasTests, workPermit.WorkPermitType, workPermit.Attributes);
            SpecialPrecautionsOrConsiderations = BuildSpecialPrecautions(workPermit);

            SetNotificationAuthorization(workPermit);

            PermitWatermark = watermarkText;
            this.workpermit = workPermit;//Added by ppanigrahi

           // WorkpermitScanText = setWorkpermitScanText(PermitWatermark);
        }

        public string WaterMarkText { get; set; }

        public string PermitNumber { get; private set; }

        public bool IsColdType { get; private set; }
        public bool IsHotType { get; private set; }

        public string InitiatedByUser { get; private set; }
        public string ApprovedByUser { get; private set; }

        public string PermitWatermark { get; private set; }

        public string SpecialPrecautionsOrConsiderations { get; private set; }

        public bool CriticalConditionsRequireOperationsAtSiteNA { get; private set; }
        public bool ControlRoomContactedNotApplicable { get; private set; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        
        public bool CriticalConditionsRequireOperationsAtSiteYes { get; private set; }
        public bool CriticalConditionsRequireOperationsAtSiteNo { get; private set; }

        public bool PermitReceiverRequireFieldOrientationNA { get; private set; }
        public bool PermitReceiverRequireFieldOrientationYes { get; private set; }
        public bool PermitReceiverRequireFieldOrientationNo { get; private set; }

        public bool ControlRoomContactedNA { get; private set; }        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        public bool ControlRoomContactedYes { get; private set; }      // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        public bool ControlRoomContactedNo { get; private set; }        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

        public bool CoAuthorizationRequiredYes { get; private set; }
        public bool CoAuthorizationRequiredNo { get; private set; }
        public string CoAuthorizationDescription { get; private set; }
        //Added by ppanigrahi
        public DateTime? RevalidationDateTime
        {
            get { return workpermit.RevalidationDateTime; }
        }

        public DateTime? ExtensionDateTime
        {

            get { return workpermit.ExtensionDateTime; }
        }

        public string ExtensionRevalidationDateTime
        {
            get { return workpermit.ExtensionRevalidationDateTime.ToString(); }

        }
         public string ISSUER_SOURCEXTENSION { get { return workpermit.ISSUER_SOURCEXTENSION; } }

        public string EndDate
        {
            get
            {
            
                if(workpermit.ExtensionRevalidationDateTime!=null)
                return workpermit.ExtensionRevalidationDateTime.Value.ToLongDateString();
                else
                {
                    return null;
                }
            }

        }

        public string EndTime
        {
            get
            {

                if (workpermit.ExtensionRevalidationDateTime != null)
                    return (workpermit.ExtensionRevalidationDateTime.ToTime()).ToString();
                else
                {
                    return null;
                }
            }

        }

        //DMND0010609-OLT - Edmonton Work permit Scan
        private string _WorkpermitScanText;
        public string WorkpermitScanText
        {
            get
            {


                if (workpermit.ExtensionEnable)
                {
                    return

                   _WorkpermitScanText + "E";
                }
                else if (workpermit.RevalidationEnable)
                {
                    return

                   _WorkpermitScanText + "R";
                }
                else
                {
                    {
                        return

                            _WorkpermitScanText;
                    }
                }
               
            }
            set { _WorkpermitScanText = value; } 
        }
        public string setWorkpermitScanText(string watremark)
        {

            switch(watremark)
            {

                case "Permit Issuer": return "Perm No:" + PermitNumber + "-I" + "##";
                case "Permit Receiver": return "Perm No:" + PermitNumber + "-R" + "##";
                default: return "";
            }
           


        }

        private string BuildSpecialPrecautions(WorkPermit workPermit)
        {
            var builder = new StringBuilder();
            var prepConditions = workPermit.EquipmentPreparationCondition;
            if (prepConditions != null)
            {
                if (prepConditions.InServiceComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Equipment In Service - {0}>",
                        prepConditions.InServiceComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
                if (prepConditions.NoElectricalTestBumpComments.HasValue())
                {
                    builder.AppendLine(string.Format("<No Electrical Test Bump - {0}>",
                        prepConditions.NoElectricalTestBumpComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
                if (prepConditions.StillContainsResidualComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Still Contain Residue - {0}>",
                        prepConditions.StillContainsResidualComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
                if (prepConditions.LockOutMethodComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Equipment Isolation - {0}>",
                        prepConditions.LockOutMethodComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
                if (prepConditions.ConditionsOfEIPNotSatisfiedComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Conditions Of EIP Not Satisfied - {0}>",
                        prepConditions.ConditionsOfEIPNotSatisfiedComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
                if (prepConditions.LeakingValvesComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Leaking Valves - {0}>",
                        prepConditions.LeakingValvesComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
            }
            var worksitePrep = workPermit.JobWorksitePreparation;
            if (worksitePrep != null)
            {
                if (worksitePrep.FlowRequiredComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Flow Required for Job - {0}>",
                        worksitePrep.FlowRequiredComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
                if (worksitePrep.BondingGroundingNotRequiredComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Bonding/Grounding Not Required - {0}>",
                        worksitePrep.BondingGroundingNotRequiredComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
                if (worksitePrep.WeldingGroundWireNotWithinGasTestAreaComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Welding Ground Wire Not Within Gas Test Areas - {0}>",
                        worksitePrep.WeldingGroundWireNotWithinGasTestAreaComments.Trim()
                            .ReplaceWhitespaceWithDelimiter()));
                }
                if (worksitePrep.SurroundingConditionsAffectAreaComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Surrounding Conditions Affect Area - {0}>",
                        worksitePrep.SurroundingConditionsAffectAreaComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
            }
            if (workPermit.SpecialPrecautionsOrConsiderations.HasValue())
            {
                builder.AppendLine(string.Format("<Additional Comments - {0}>",
                    workPermit.SpecialPrecautionsOrConsiderations.Trim().ReplaceWhitespaceWithDelimiter()));
            }
            if (worksitePrep != null)
            {
                if (worksitePrep.CriticalConditionsComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Critical Conditions - {0}>",
                        worksitePrep.CriticalConditionsComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
                if (worksitePrep.PermitReceiverRequiresOrientationComments.HasValue())
                {
                    builder.AppendLine(string.Format("<Permit Receiver Requires Orientation Comments - {0}>",
                        worksitePrep.PermitReceiverRequiresOrientationComments.Trim().ReplaceWhitespaceWithDelimiter()));
                }
            }

            // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            if (workPermit.EquipmentPreparationCondition.InAsbestosHazardPresentComments.HasValue())
            {
                builder.AppendLine(string.Format("<Asbestos Hazard Present  - {0}>",
                workPermit.EquipmentPreparationCondition.InAsbestosHazardPresentComments.Trim().ReplaceWhitespaceWithDelimiter()));
                
            }
            //if (workPermit.EquipmentPreparationCondition.InHazardousEnergyIsolationComments.HasValue())
            //{
            //    builder.AppendLine(string.Format("<Hazardous Energy Isolation Required  - {0}>",
            //    workPermit.EquipmentPreparationCondition.InHazardousEnergyIsolationComments.Trim().ReplaceWhitespaceWithDelimiter()));
            //}

            

            

            //END

            return builder.ToString();
        }

        public void SetNotificationAuthorization(WorkPermit workPermit)
        {
            var workSitePrep = workPermit.JobWorksitePreparation;

            if (workSitePrep != null)
            {
                CriticalConditionsRequireOperationsAtSiteNA = workSitePrep.IsCriticalConditionRemainJobSiteNotApplicable;
                if (CriticalConditionsRequireOperationsAtSiteNA == false)
                {
                    CriticalConditionsRequireOperationsAtSiteYes =
                        workSitePrep.IsCriticalConditionRemainJobSite.HasTrueValue();
                    CriticalConditionsRequireOperationsAtSiteNo =
                        workSitePrep.IsCriticalConditionRemainJobSite.HasFalseValue();
                }

                PermitReceiverRequireFieldOrientationNA =
                    workSitePrep.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable;
                if (PermitReceiverRequireFieldOrientationNA == false)
                {
                    PermitReceiverRequireFieldOrientationYes =
                        workSitePrep.IsPermitReceiverFieldOrEquipmentOrientation.HasTrueValue();
                    PermitReceiverRequireFieldOrientationNo =
                        workSitePrep.IsPermitReceiverFieldOrEquipmentOrientation.HasFalseValue();
                }


                // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                
                    ControlRoomContactedNA =
                    workSitePrep.IsControlRoomContactedNotApplicable;
                    if (ControlRoomContactedNA == false)
                    {
                        ControlRoomContactedYes =
                            workSitePrep.IsControlRoomContactedOrNot.HasTrueValue();
                        ControlRoomContactedNo =
                            workSitePrep.IsControlRoomContactedOrNot.HasFalseValue();
                    }
                
            }

            CoAuthorizationRequiredYes = workPermit.IsCoauthorizationRequired.HasTrueValue();
            CoAuthorizationRequiredNo = workPermit.IsCoauthorizationRequired.HasFalseValue();
            CoAuthorizationDescription = workPermit.CoauthorizationDescription;
        }

        #region Permit Attributes

        public bool AttributeConfinedSpaceEntry { get; private set; }
        public bool AttributeExcavation { get; private set; }
        public bool AttributeOpenFlameOrWeld { get; private set; }
        public bool AttributeVehicleEntry { get; private set; }
        public bool AttributeAsbestos { get; private set; }
        public bool AttributeRadiationRadiography { get; private set; }

        public bool AttributeFreshAir { get; private set; }      // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        public bool AttributeRadiationSealed { get; private set; }

        private void SetPermitAttributes(WorkPermitAttributes workPermitAttributes)
        {
            if (workPermitAttributes == null)
                return;

            AttributeConfinedSpaceEntry = workPermitAttributes.IsConfinedSpaceEntry;
            AttributeVehicleEntry = workPermitAttributes.IsVehicleEntry;
            AttributeOpenFlameOrWeld = workPermitAttributes.IsBurnOrOpenFlame;
            AttributeExcavation = workPermitAttributes.IsExcavation;
            AttributeAsbestos = workPermitAttributes.IsAsbestos;
            AttributeRadiationRadiography = workPermitAttributes.IsRadiationRadiography;
            AttributeFreshAir = workPermitAttributes.IsFreshAir; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            AttributeRadiationSealed = workPermitAttributes.IsRadiationSealed;
        }

        #endregion

        #region Additional Forms / Assessments Required

        public bool AdditionalFormCseAssessmentAuthorization { get; private set; }
        public string AdditionalFormCseAssessmentAuthorizationDescription { get; private set; }
        public bool AdditionalFormOpenFlameWeldAssessment { get; private set; }
        public string AdditionalFormOpenFlameWeldAssessmentDescription { get; private set; }
        public bool AdditionalFormBlankBlindList { get; private set; }
        public bool AdditionalFormCriticalLiftAssessment { get; private set; }
        public string AdditionalFormCriticalLiftAssessmentDescription { get; private set; }
        public bool AdditionalFormDeviation { get; private set; }
        public string AdditionalFormDeviationDescription { get; private set; }
        public bool AdditionalFormElectricalHazardAssessment { get; private set; }
        public string AdditionalFormElectricalHazardAssessmentDescription { get; private set; }

        public bool AdditionalFormExcavationAssessment { get; private set; }
        public string AdditionalFormExcavationAssessmentDescription { get; private set; }
        public bool AdditionalFormAsbestosAssessment { get; private set; }
        public string AdditionalFormAsbestosAssessmentDescription { get; private set; }
        public bool AdditionalFormPJSRSafetyPause { get; private set; }
        public bool AdditionalFormMSDS { get; private set; }
        public bool AdditionalFormSpecialWasteDisposal { get; private set; }
        public bool AdditionalFormOther { get; private set; }
        public string AdditionalFormOtherDescription { get; private set; }

        private void SetAdditionalForms(WorkPermitAdditionalItemsRequired additionItemsRequired)
        {
            if (additionItemsRequired == null)
                return;

            AdditionalFormCseAssessmentAuthorization = additionItemsRequired.IsCSEAssessmentOrAuthorization;
            AdditionalFormCseAssessmentAuthorizationDescription =
                additionItemsRequired.CSEAssessmentOrAuthorizationDescription;
            AdditionalFormOpenFlameWeldAssessment = additionItemsRequired.IsBurnOrOpenFlameAssessment;
            AdditionalFormOpenFlameWeldAssessmentDescription =
                additionItemsRequired.BurnOrOpenFlameAssessmentDescription;
            AdditionalFormBlankBlindList = additionItemsRequired.IsBlankOrBlindLists;
            AdditionalFormCriticalLiftAssessment = additionItemsRequired.IsCriticalLift;
            AdditionalFormCriticalLiftAssessmentDescription = additionItemsRequired.CriticalLiftDescription;
            AdditionalFormDeviation = additionItemsRequired.IsWaiverOrDeviation;
            AdditionalFormDeviationDescription = additionItemsRequired.WaiverOrDeviationDescription;
            AdditionalFormElectricalHazardAssessment = additionItemsRequired.IsElectrical;
            AdditionalFormElectricalHazardAssessmentDescription = additionItemsRequired.ElectricalDescription;

            AdditionalFormExcavationAssessment = additionItemsRequired.IsExcavation;
            AdditionalFormExcavationAssessmentDescription = additionItemsRequired.ExcavationDescription;
            AdditionalFormAsbestosAssessment = additionItemsRequired.IsAsbestosHandling;
            AdditionalFormAsbestosAssessmentDescription = additionItemsRequired.AsbestosHandlingDescription;
            AdditionalFormPJSRSafetyPause = additionItemsRequired.IsPJSROrSafetyPause;
            AdditionalFormMSDS = additionItemsRequired.IsMSDS;
            AdditionalFormSpecialWasteDisposal = additionItemsRequired.IsSpecialWasteDisposal;
            // This is just reproducing a bug in production that says that if the value in the db is not null then allow the other to be checked. See #2578 for future fix
            AdditionalFormOther = additionItemsRequired.OtherItemDescription != null;
            AdditionalFormOtherDescription = AdditionalFormOther
                ? additionItemsRequired.OtherItemDescription
                : string.Empty;
        }

        #endregion

        #region Location / Job Specifics

        public string FunctionalLocation { get; private set; }
        public string WorkOrderNumber { get; private set; }
        public string StartDateTime { get; private set; }
        public string EndDateTime { get; private set; }
        public string ContactPerson { get; private set; }
        public string ContactorName { get; private set; }
        public string CraftOrTrade { get; private set; }
        public string WorkAssignment { get; private set; }

        public string WorkOrderAndJobStepText { get; private set; }

        private void SetLocationAndJobSpecificsAndScope(WorkPermitSpecifics specifics, List<DocumentLink> documentLinks)
        {
            if (specifics == null)
                return;

            FunctionalLocation = specifics.FunctionalLocation.FullHierarchy;
            WorkOrderNumber = specifics.WorkOrderNumber;
            StartDateTime = specifics.StartDateTime.ToLongDateAndTimeString();
            EndDateTime = specifics.EndDateTime.HasValue
                ? specifics.EndDateTime.Value.ToLongDateAndTimeString()
                : string.Empty;
            ContactPerson = specifics.ContactName;
            ContactorName = specifics.ContractorCompanyName;
            CraftOrTrade = specifics.CraftOrTradeName;
            WorkAssignment = specifics.WorkAssignment != null ? specifics.WorkAssignment.Name : string.Empty;

            WorkOrderAndJobStepText = BuildWorkOrderAndJobStepText(specifics, documentLinks);

            var communication = specifics.Communication;
            if (communication != null)
            {
                Radio = communication.IsRadio;
                RadioChannel = communication.RadioChannel.NullToEmpty();
                RadioColor = communication.RadioColor.NullToEmpty();
                RadioOther = communication.Description.NullToEmpty();
                RadioNA = communication.IsWorkPermitCommunicationNotApplicable;
            }
        }

        private static string GetDocumentLinks(List<DocumentLink> links)
        {
            if (links == null || links.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var documentLink in links)
            {
                sb.AppendLine(documentLink.TitleWithUrl);
            }
            return sb.ToString();
        }

        private string BuildWorkOrderAndJobStepText(WorkPermitSpecifics specifics, List<DocumentLink> links)
        {
            var workOrderDescription = specifics.WorkOrderDescription.ReplaceWhitespaceWithDelimiter();
            var jobStepDescription = specifics.JobStepDescription.ReplaceWhitespaceWithDelimiter();
            var documentLinks = GetDocumentLinks(links);

            var builder = new StringBuilder();
            if (workOrderDescription.HasValue())
            {
                builder.AppendLine("WORK ORDER DESCRIPTION");
                builder.AppendLine(workOrderDescription);
            }
            if (jobStepDescription.HasValue())
            {
                builder.AppendLine("JOB STEP DESCRIPTION");
                builder.AppendLine(jobStepDescription.Trim());
            }
            if (documentLinks.HasValue())
            {
                builder.AppendLine("DOCUMENT LINKS");
                builder.AppendLine(documentLinks.Trim());
            }
            return builder.ToString();
        }

        #endregion

        #region Communication Methods

        public bool Radio { get; private set; }
        public string RadioChannel { get; private set; }
        public string RadioColor { get; private set; }
        public string RadioOther { get; private set; }
        public bool RadioNA { get; private set; }

        private void SetCommunicationMethods(WorkPermitSpecifics specifics)
        {
            if (specifics == null)
                return;

            var communication = specifics.Communication;
            if (communication != null)
            {
                Radio = communication.IsRadio;
                RadioChannel = communication.RadioChannel.NullToEmpty();
                RadioColor = communication.RadioColor.NullToEmpty();
                RadioOther = communication.Description.NullToEmpty();
                RadioNA = communication.IsWorkPermitCommunicationNotApplicable;
            }
        }

        #endregion

        #region Equipment Preparation and Conditions

        public bool EquipmentInService { get; private set; }
        public bool EquipmentOutOfService { get; private set; }

        public bool EquipmentPriorContentsHydocarbon { get; private set; }
        public bool EquipmentPriorContentsAcid { get; private set; }
        public bool EquipmentPriorContentsCaustic { get; private set; }
        public bool EquipmentPriorContentsH2S { get; private set; }
        public bool EquipmentPriorContentsNA { get; private set; }
        public bool EquipmentPriorContentsOther { get; private set; }
        public string EquipmentPriorContentsOtherDescription { get; private set; }

        public bool StillContainsResidualYes { get; private set; }
        public bool StillContainsResidualNo { get; private set; }
        public bool StillContainsResidualNA { get; private set; }

        public bool LeakingTestValvesYes { get; private set; }
        public bool LeakingTestValvesNo { get; private set; }
        public bool LeakingTestValvesNA { get; private set; }

        public bool HazardousEnergyIsolationRequiredYes { get; private set; }
        public bool HazardousEnergyIsolationRequiredNo { get; private set; }
        public bool HazardousEnergyIsolationRequiredNA { get; private set; }

        public bool LockOutMethodIndividualByWorkers { get; private set; }
        public string LockOutMethodEIPNumber { get; private set; }
        public bool LockOutMethodIndividualByOperations { get; private set; }
        public bool LockOutMethodComplexGroup { get; private set; }

        public bool ConditionsOfEIPSatisfiedYes { get; private set; }
        public bool ConditionsOfEIPSatisfiedNo { get; private set; }
        public bool ConditionsOfEIPSatisfiedNA { get; private set; }

        public bool EquipmentConditionDepressured { get; private set; }
        public bool EquipmentConditionVentilated { get; private set; }
        public bool EquipmentConditionDrained { get; private set; }
        public bool EquipmentConditionH20Washed { get; private set; }
        public bool EquipmentConditionCleaned { get; private set; }
        public bool EquipmentConditionPurgedChecked { get; private set; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        public bool EquipmentConditionNeutralized { get; private set; }
        public bool EquipmentConditionPurgedN2 { get; private set; }
        public bool EquipmentConditionPurgedSteam { get; private set; }
        public bool EquipmentConditionPurgedAir { get; private set; }
        public bool EquipmentConditionOther { get; private set; }
        public string EquipmentConditionOtherDescription { get; private set; }
        public bool EquipmentConditionNA { get; private set; }

        public bool VentilationNaturalDraft { get; private set; }
        public bool VentilationLocalExhaust { get; private set; }
        public bool VentilationForced { get; private set; }
        public bool VentilationNA { get; private set; }

        private void SetEquipmentPreparation(WorkPermitEquipmentPreparationCondition condition)
        {
            if (condition == null)
                return;

            EquipmentInService = condition.IsInServiceSelected;
            EquipmentOutOfService = !condition.IsInServiceSelected;

            EquipmentPriorContentsNA = condition.IsPreviousContentsNotApplicable;
            if (EquipmentPriorContentsNA == false)
            {
                EquipmentPriorContentsHydocarbon = condition.IsPreviousContentsHydrocarbon;
                EquipmentPriorContentsAcid = condition.IsPreviousContentsAcid;
                EquipmentPriorContentsCaustic = condition.IsPreviousContentsCaustic;
                EquipmentPriorContentsH2S = condition.IsPreviousContentsH2S;
                EquipmentPriorContentsOther = condition.IsPreviousContentsOtherDescription;
                EquipmentPriorContentsOtherDescription = EquipmentPriorContentsOther
                    ? condition.PreviousContentsOtherDescription
                    : string.Empty;
            }

            StillContainsResidualNA = condition.IsStillContainsResidualNotApplicable;
            if (StillContainsResidualNA == false)
            {
                StillContainsResidualYes = condition.IsStillContainsResidual.HasTrueValue();
                StillContainsResidualNo = condition.IsStillContainsResidual.HasFalseValue();
            }

            LeakingTestValvesNA = condition.IsLeakingValvesNotApplicable;
            if (LeakingTestValvesNA == false)
            {
                LeakingTestValvesYes = condition.IsLeakingValves.HasTrueValue();
                LeakingTestValvesNo = condition.IsLeakingValves.HasFalseValue();
            }

            HazardousEnergyIsolationRequiredNA = condition.IsHazardousEnergyIsolationRequiredNotApplicable;
            if (HazardousEnergyIsolationRequiredNA == false)
            {
                HazardousEnergyIsolationRequiredYes = condition.IsHazardousEnergyIsolationRequired.HasTrueValue();
                HazardousEnergyIsolationRequiredNo = condition.IsHazardousEnergyIsolationRequired.HasFalseValue();
            }


            LockOutMethodIndividualByWorkers = condition.IsHazardousEnergyIsolationRequiredSelected &&
                                               condition.LockOutMethod != null &&
                                               condition.LockOutMethod ==
                                               WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER;
            LockOutMethodIndividualByOperations = condition.IsHazardousEnergyIsolationRequiredSelected &&
                                                  condition.LockOutMethod != null &&
                                                  condition.LockOutMethod ==
                                                  WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS;
            LockOutMethodComplexGroup = condition.IsHazardousEnergyIsolationRequiredSelected &&
                                        condition.LockOutMethod != null &&
                                        condition.LockOutMethod == WorkPermitLockOutMethodType.COMPLEX_GROUP;
            LockOutMethodEIPNumber = condition.IsHazardousEnergyIsolationRequiredSelected
                ? condition.EnergyIsolationPlanNumber.NullToEmpty()
                : string.Empty;

            ConditionsOfEIPSatisfiedNA = !condition.IsConditionsOfEIPSatisfiedApplicable;
            if (ConditionsOfEIPSatisfiedNA == false)
            {
                ConditionsOfEIPSatisfiedYes = condition.ConditionsOfEIPSatisfied.HasTrueValue();
                ConditionsOfEIPSatisfiedNo = condition.ConditionsOfEIPSatisfied.HasFalseValue();
            }

            EquipmentConditionNA = condition.IsConditionNotApplicable;
            if (EquipmentConditionNA == false)
            {
                EquipmentConditionDepressured = condition.IsConditionDepressured;
                EquipmentConditionVentilated = condition.IsConditionVentilated;
                EquipmentConditionDrained = condition.IsConditionDrained;
                EquipmentConditionH20Washed = condition.IsConditionH20Washed;
                EquipmentConditionCleaned = condition.IsConditionCleaned;
                EquipmentConditionPurgedChecked = condition.IsConditionPurgedCheckbox;// RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                
                EquipmentConditionNeutralized = condition.IsConditionNeutralized;
                EquipmentConditionPurgedN2 = condition.IsConditionPurgedN2;
                EquipmentConditionPurgedSteam = condition.IsConditionPurgedSteamed;
                EquipmentConditionPurgedAir = condition.IsConditionPurgedAir;
                // This is just reproducing a bug in production that says that if the value in the db is not null then allow the other to be checked. See #2577 and #2578 for future fix
                EquipmentConditionOther = condition.ConditionOtherDescription != null;
                EquipmentConditionOtherDescription = EquipmentConditionOther
                    ? condition.ConditionOtherDescription.NullToEmpty()
                    : string.Empty;
            }

            VentilationNA = condition.IsVentilationMethodNotApplicable;
            if (VentilationNA == false)
            {
                VentilationNaturalDraft = condition.IsVentilationMethodNaturalDraft;
                VentilationLocalExhaust = condition.IsVentilationMethodLocalExhaust;
                VentilationForced = condition.IsVentilationMethodForced;
            }
        }

        #endregion

        #region Asbestos

        public bool AsbestosHazardsConsideredNA { get; private set; }
        public bool AsbestosHazardsConsideredYes { get; private set; }
        public bool AsbestosHazardsConsideredNo { get; private set; }

        private void SetAsbestos(WorkPermitAsbestos asbestos)
        {
            if (asbestos == null)
                return;

            AsbestosHazardsConsideredNA = asbestos.HazardsConsideredNotApplicable;
            if (AsbestosHazardsConsideredNA == false)
            {
                AsbestosHazardsConsideredYes = asbestos.HazardsConsidered.HasTrueValue();
                AsbestosHazardsConsideredNo = asbestos.HazardsConsidered.HasFalseValue();
            }
        }

        #endregion

        #region Job / Worksite Preparation

        public bool SewerIsolationSealedCovered { get; private set; }
        public bool SewerIsolationPlugged { get; private set; }
        public bool SewerIsolationBlindBlank { get; private set; }
        public bool SewerIsolationOther { get; private set; }
        public string SewerIsolationOtherDescription { get; private set; }
        public bool SewerIsolationNA { get; private set; }

        public bool JobSitePreparationBarricade { get; private set; }
        public bool JobSitePreparationBoundaryTape { get; private set; }
        public bool JobSitePreparationOther { get; private set; }
        public string JobSitePreparationOtherDescription { get; private set; }
        public bool JobSitePreparationNA { get; private set; }

        public bool BondingGroundingRequiredYes { get; private set; }
        public bool BondingGroundingRequiredNo { get; private set; }
        public bool BondingGroundingRequiredNA { get; private set; }

        public bool WeldingGroundWireLocatedInGasTestAreaYes { get; private set; }
        public bool WeldingGroundWireLocatedInGasTestAreaNo { get; private set; }
        public bool WeldingGroundWireLocatedInGasTestAreaNA { get; private set; }

        public bool SurroundingConditionsAffectWorkAreaYes { get; private set; }
        public bool SurroundingConditionsAffectWorkAreaNo { get; private set; }
        public bool SurroundingConditionsAffectWorkAreaNA { get; private set; }

        public bool VestedBuddySystemInEffectYes { get; private set; }
        public bool VestedBuddySystemInEffectNo { get; private set; }
        public bool VestedBuddySystemInEffectNA { get; private set; }

        private void SetJobWorksitePreparation(WorkPermitJobWorksitePreparation jobPrep)
        {
            if (jobPrep == null)
                return;

            SewerIsolationNA = jobPrep.IsSewerIsolationMethodNotApplicable;
            if (SewerIsolationNA == false)
            {
                SewerIsolationSealedCovered = jobPrep.IsSewerIsolationMethodSealedOrCovered;
                SewerIsolationPlugged = jobPrep.IsSewerIsolationMethodPlugged;
                SewerIsolationBlindBlank = jobPrep.IsSewerIsolationMethodBlindedOrBlanked;
                SewerIsolationOther = jobPrep.SewerIsolationMethodOtherDescription.HasValue();
                SewerIsolationOtherDescription = SewerIsolationOther
                    ? jobPrep.SewerIsolationMethodOtherDescription
                    : string.Empty;
            }

            JobSitePreparationNA = jobPrep.IsAreaPreparationNotApplicable;
            if (JobSitePreparationNA == false)
            {
                JobSitePreparationBarricade = jobPrep.IsAreaPreparationBarricade;
                JobSitePreparationBoundaryTape = jobPrep.IsAreaPreparationBoundaryRopeTape;
                JobSitePreparationOther = jobPrep.AreaPreparationOtherDescription.HasValue();
                JobSitePreparationOtherDescription = JobSitePreparationOther
                    ? jobPrep.AreaPreparationOtherDescription
                    : string.Empty;
            }

            BondingGroundingRequiredNA = jobPrep.IsBondingOrGroundingRequiredNotApplicable;
            if (BondingGroundingRequiredNA == false)
            {
                BondingGroundingRequiredYes = jobPrep.IsBondingOrGroundingRequired.HasTrueValue();
                BondingGroundingRequiredNo = jobPrep.IsBondingOrGroundingRequired.HasFalseValue();
            }

            WeldingGroundWireLocatedInGasTestAreaNA = jobPrep.IsWeldingGroundWireInTestAreaNotApplicable;
            if (WeldingGroundWireLocatedInGasTestAreaNA == false)
            {
                WeldingGroundWireLocatedInGasTestAreaYes = jobPrep.IsWeldingGroundWireInTestArea.HasTrueValue();
                WeldingGroundWireLocatedInGasTestAreaNo = jobPrep.IsWeldingGroundWireInTestArea.HasFalseValue();
            }

            SurroundingConditionsAffectWorkAreaNA = jobPrep.IsSurroundingConditionsAffectOrContaminatedNotApplicable;
            if (SurroundingConditionsAffectWorkAreaNA == false)
            {
                SurroundingConditionsAffectWorkAreaYes =
                    jobPrep.IsSurroundingConditionsAffectOrContaminated.HasTrueValue();
                SurroundingConditionsAffectWorkAreaNo =
                    jobPrep.IsSurroundingConditionsAffectOrContaminated.HasFalseValue();
            }

            VestedBuddySystemInEffectNA = jobPrep.IsVestedBuddySystemInEffectNotApplicable;
            if (VestedBuddySystemInEffectNA == false)
            {
                VestedBuddySystemInEffectYes = jobPrep.IsVestedBuddySystemInEffect.HasTrueValue();
                VestedBuddySystemInEffectNo = jobPrep.IsVestedBuddySystemInEffect.HasFalseValue();
            }
        }

        #endregion

        #region Fire/Confined Space Protection Requirements / Hot

        public bool Cse20ABCDryChem { get; private set; }
        public bool CseSparkContainment { get; private set; }
        public bool CseSteamHose { get; private set; }
        public bool CseFireResistantTarp { get; private set; }
        public bool CseWaterHose { get; private set; }
        public bool CseVestedWatchman { get; private set; }
        public bool CseOther { get; private set; }
        public string CseOtherDescription { get; private set; }
        public bool CseNA { get; private set; }

        private void SetConfinedSpaceRequirements(WorkPermitFireConfinedSpaceRequirements cseRequirements)
        {
            CseNA = cseRequirements == null || cseRequirements.IsNotApplicable;

            if (CseNA)
                return;

            Cse20ABCDryChem = cseRequirements.IsTwentyABCorDryChemicalExtinguisher;
            CseSparkContainment = cseRequirements.IsSparkContainment;
            CseSteamHose = cseRequirements.IsSteamHose;
            CseFireResistantTarp = cseRequirements.IsFireResistantTarp;
            CseWaterHose = cseRequirements.IsWaterHose;
            CseVestedWatchman = cseRequirements.IsWatchmen;
            CseOther = cseRequirements.OtherDescription.HasValue();
            CseOtherDescription = CseOther ? cseRequirements.OtherDescription : string.Empty;
        }

        #endregion

        #region Respitory Protection Requirements

        public bool RpRAirCart { get; private set; }
        public bool RpRSCBA { get; private set; }
        public bool RpRHalfFaceRespirator { get; private set; }
        public bool RpRFullFaceRespirator { get; private set; }
        public bool RpRDustMask { get; private set; }
        public bool RpRAirHood { get; private set; }
        public string RpRCartridgeType { get; private set; }
        public bool RpROther { get; private set; }
        public string RpROtherDescription { get; private set; }
        public bool RpRNA { get; private set; }

        private void SetRespitoryProtectionRequirements(WorkPermitRespiratoryProtectionRequirements resRequirements)
        {
            RpRNA = resRequirements == null || resRequirements.IsNotApplicable;

            if (RpRNA)
                return;

            RpRAirCart = resRequirements.IsAirCartorAirLine;
            RpRSCBA = resRequirements.IsSCBA;
            RpRHalfFaceRespirator = resRequirements.IsHalfFaceRespirator;
            RpRFullFaceRespirator = resRequirements.IsFullFaceRespirator;
            RpRDustMask = resRequirements.IsDustMask;
            RpRAirHood = resRequirements.IsAirHood;
            RpRCartridgeType = resRequirements.CartridgeTypeDescription.NullToEmpty();
            RpROther = resRequirements.OtherDescription.HasValue();
            RpROtherDescription = RpROther ? resRequirements.OtherDescription : string.Empty;
        }

        #endregion

        #region Special PPE Requirements

        public bool PpeEyeGoggles { get; private set; }
        public bool PpeEyeFaceShield { get; private set; }
        public bool PpeEyeOther { get; private set; }
        public string PpeEyeOtherDescription { get; private set; }
        public bool PpeEyeNA { get; private set; }

        public bool PpeClothingRainCoat { get; private set; }
        public bool PpeClothingAcidClothing { get; private set; }
        public string PpeClothingAcidClothingType { get; private set; }
        public bool PpeClothingRainPants { get; private set; }
        public bool PpeClothingCausticWear { get; private set; }
        public bool PpeClothingOther { get; private set; }
        public string PpeClothingOtherDescription { get; private set; }
        public bool PpeClothingFireRetardantPaperCoveralls { get; private set; }
        public bool PpeClothingNA { get; private set; }
        
        public string AsbestosHazard { get; private set; }

        public bool PpeProtectiveFootwearChemicalImpreviousBoots { get; private set; }
        public bool PpeProtectiveFootwearMetatarsalGuard { get; private set; }
        public bool PpeProtectiveFootwearOther { get; private set; }
        public string PpeProtectiveFootwearOtherDescription { get; private set; }
        public bool PpeProtectiveFootwearNA { get; private set; }

        public bool PpeHandProtectionNeoprene { get; private set; }
        public bool PpeHandProtectionNaturalRubber { get; private set; }
        public bool PpeHandProtectionNitrile { get; private set; }
        public bool PpeHandProtectionLeather { get; private set; }
        public bool PpeHandProtectionWelding { get; private set; }
        public bool PpeHandProtectionHighVoltage { get; private set; }
        public bool PpeHandProtectionOther { get; private set; }
        public string PpeHandProtectionOtherDescription { get; private set; }
        public bool PpeHandProtectionNA { get; private set; }

        public bool PpeRescueBodyHarness { get; private set; }
        public bool PpeRescueLifeline { get; private set; }
        public bool PpeRescueDevice { get; private set; }
        public bool PpeRescueOther { get; private set; }
        public string PpeRescueOtherDescription { get; private set; }
        public bool PpeRescueNA { get; private set; }

        private void SetPPERequirements(WorkPermitSpecialPPERequirements ppe)
        {
            if (ppe == null)
                return;

            PpeEyeNA = ppe.IsEyeOrFaceProtectionNotApplicable;
            if (PpeEyeNA == false)
            {
                PpeEyeGoggles = ppe.IsEyeOrFaceProtectionGoggles;
                PpeEyeFaceShield = ppe.IsEyeOrFaceProtectionFaceshield;
                PpeEyeOther = ppe.EyeOrFaceProtectionOtherDescription.HasValue();
                PpeEyeOtherDescription = PpeEyeOther ? ppe.EyeOrFaceProtectionOtherDescription : string.Empty;
            }

            PpeClothingNA = ppe.IsProtectiveClothingTypeNotApplicable;
            if (PpeClothingNA == false)
            {
                PpeClothingRainCoat = ppe.IsProtectiveClothingTypeRainCoat;
                PpeClothingAcidClothing = ppe.IsProtectiveClothingTypeAcidClothing;
                PpeClothingAcidClothingType = PpeClothingAcidClothing
                    ? ppe.ProtectiveClothingTypeAcidClothingType.ToString()
                    : string.Empty;
                PpeClothingRainPants = ppe.IsProtectiveClothingTypeRainPants;
                PpeClothingCausticWear = ppe.IsProtectiveClothingTypeCausticWear;
                PpeClothingFireRetardantPaperCoveralls = ppe.IsProtectiveClothingTypePaperCoveralls;
                PpeClothingOther = ppe.ProtectiveClothingTypeOtherDescription.HasValue();
                PpeClothingOtherDescription = PpeClothingOther
                    ? ppe.ProtectiveClothingTypeOtherDescription
                    : string.Empty;
                
            }

            PpeProtectiveFootwearNA = ppe.IsProtectiveFootwearNotApplicable;
            if (PpeProtectiveFootwearNA == false)
            {
                PpeProtectiveFootwearChemicalImpreviousBoots = ppe.IsProtectiveFootwearChemicalImperviousBoots;
                PpeProtectiveFootwearMetatarsalGuard = ppe.IsProtectiveFootwearMetatarsalGuard;
                PpeProtectiveFootwearOther = ppe.ProtectiveFootwearOtherDescription.HasValue();
                PpeProtectiveFootwearOtherDescription = PpeProtectiveFootwearOther
                    ? ppe.ProtectiveFootwearOtherDescription
                    : string.Empty;
            }

            PpeHandProtectionNA = ppe.IsHandProtectionNotApplicable;
            if (PpeHandProtectionNA == false)
            {
                PpeHandProtectionNeoprene = ppe.IsHandProtectionChemicalNeoprene;
                PpeHandProtectionNaturalRubber = ppe.IsHandProtectionNaturalRubber;
                PpeHandProtectionNitrile = ppe.IsHandProtectionNitrile;
                PpeHandProtectionLeather = ppe.IsHandProtectionLeather;
                PpeHandProtectionWelding = ppe.IsHandProtectionWelding;
                PpeHandProtectionHighVoltage = ppe.IsHandProtectionHighVoltage;
                PpeHandProtectionOther = ppe.HandProtectionOtherDescription.HasValue();
                PpeHandProtectionOtherDescription = PpeHandProtectionOther
                    ? ppe.HandProtectionOtherDescription
                    : string.Empty;
            }

            PpeRescueNA = ppe.IsRescueOrFallNotApplicable;
            if (PpeRescueNA == false)
            {
                PpeRescueBodyHarness = ppe.IsRescueOrFallBodyHarness;
                PpeRescueLifeline = ppe.IsRescueOrFallLifeline;
                PpeRescueDevice = ppe.IsRescueOrFallRescueDevice;
                PpeRescueOther = ppe.RescueOrFallOtherDescription.HasValue();
                PpeRescueOtherDescription = PpeRescueOther ? ppe.RescueOrFallOtherDescription : string.Empty;
            }
        }

        #endregion

        #region GasTest Information

        public bool GasTestConstantMonitoringRequired { get; private set; }
        public string GasTestFrequencyOrDuration { get; private set; }
        public string GasTestImmediateAreaTimeOfTest { get; private set; }
        public string GasTestConfinedSpaceTimeOfTest { get; private set; }

        public string GasTestOxygenLimits { get; private set; }
        public bool GasTestOxygenImmediateAreaTestRequired { get; private set; }
        public string GasTestOxygenImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestOxygenConfinedSpaceTestRequired { get; private set; }
        public string GasTestOxygenConfinedSpaceFirstTestResult { get; private set; }

        public string GasTestLELLimits { get; private set; }
        public bool GasTestLELImmediateAreaTestRequired { get; private set; }
        public string GasTestLELImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestLELConfinedSpaceTestRequired { get; private set; }
        public string GasTestLELConfinedSpaceFirstTestResult { get; private set; }

        public string GasTestH2SLimits { get; private set; }
        public bool GasTestH2SImmediateAreaTestRequired { get; private set; }
        public string GasTestH2SImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestH2SConfinedSpaceTestRequired { get; private set; }
        public string GasTestH2SConfinedSpaceFirstTestResult { get; private set; }

        public string GasTestSO2Limits { get; private set; }
        public bool GasTestSO2ImmediateAreaTestRequired { get; private set; }
        public string GasTestSO2ImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestSO2ConfinedSpaceTestRequired { get; private set; }
        public string GasTestSO2ConfinedSpaceFirstTestResult { get; private set; }

        public string GasTestCOLimits { get; private set; }
        public bool GasTestCOImmediateAreaTestRequired { get; private set; }
        public string GasTestCOImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestCOConfinedSpaceTestRequired { get; private set; }
        public string GasTestCOConfinedSpaceFirstTestResult { get; private set; }

        public string GasTestBenzeneLimits { get; private set; }
        public bool GasTestBenzeneImmediateAreaTestRequired { get; private set; }
        public string GasTestBenzeneImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestBenzeneConfinedSpaceTestRequired { get; private set; }
        public string GasTestBenzeneConfinedSpaceFirstTestResult { get; private set; }

        public string GasTestTolueneLimits { get; private set; }
        public bool GasTestTolueneImmediateAreaTestRequired { get; private set; }
        public string GasTestTolueneImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestTolueneConfinedSpaceTestRequired { get; private set; }
        public string GasTestTolueneConfinedSpaceFirstTestResult { get; private set; }

        public string GasTestXyleneLimits { get; private set; }
        public bool GasTestXyleneImmediateAreaTestRequired { get; private set; }
        public string GasTestXyleneImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestXyleneConfinedSpaceTestRequired { get; private set; }
        public string GasTestXyleneConfinedSpaceFirstTestResult { get; private set; }

        public string GasTestAmmoniaLimits { get; private set; }
        public string Other1Limit { get; private set; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        
        public bool GasTestAmmoniaImmediateAreaTestRequired { get; private set; }
        public bool Other1ImmediateAreaTestRequired { get; private set; } //RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        
        public string GasTestAmmoniaImmediateAreaFirstTestResult { get; private set; }
        public string Other1ImmediateAreaFirstTestResult { get; private set; } //RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        

        public bool GasTestAmmoniaConfinedSpaceTestRequired { get; private set; }
        public bool Other1ConfinedSpaceTestRequired { get; private set; } //vibhor
        
        public string GasTestAmmoniaConfinedSpaceFirstTestResult { get; private set; }
        public string Other1ConfinedSpaceFirstTestResult { get; private set; } //RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        

        public string GasTestCustomName { get; private set; }
        public string GasTestCustomLimits { get; private set; }
        public bool GasTestCustomImmediateAreaTestRequired { get; private set; }
        public string GasTestCustomImmediateAreaFirstTestResult { get; private set; }
        public bool GasTestCustomConfinedSpaceTestRequired { get; private set; }
        public string GasTestCustomConfinedSpaceFirstTestResult { get; private set; }

        ////RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        public string GasTestCustomName_other1 { get; private set; }
        public string GasTestCustomLimits_other1 { get; private set; }
        public bool GasTestCustomImmediateAreaTestRequired_other1 { get; private set; }
        public string GasTestCustomImmediateAreaFirstTestResult_other1 { get; private set; }
        public bool GasTestCustomConfinedSpaceTestRequired_other1 { get; private set; }
        public string GasTestCustomConfinedSpaceFirstTestResult_other1 { get; private set; }

        //END

        private void SetGasTestInfomation(WorkPermitGasTests gasTests, WorkPermitType workPermitType,
            WorkPermitAttributes workPermitAttributes)
        {
            if (gasTests == null)
                return;

            GasTestConstantMonitoringRequired = gasTests.ConstantMonitoringRequired;
            GasTestFrequencyOrDuration = gasTests.FrequencyOrDuration;
            int counter = 0;
            var gasTestElements = gasTests.Elements;
            foreach (var element in gasTestElements)
            {
                var gasTestElementInfo = element.ElementInfo;

                var limits = gasTestElementInfo.IsStandard
                    ? gasTestElementInfo.GetLimitRange(workPermitType, workPermitAttributes)
                        .ToLimitStringWithUnit(gasTestElementInfo)
                    : gasTestElementInfo.OtherLimits;

                var gasTestName = gasTestElementInfo.Name;

                switch (gasTestName)
                {
                    case "Oxygen":
                        GasTestOxygenLimits = limits;
                        GasTestOxygenImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestOxygenImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestOxygenConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestOxygenConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    case "LEL":
                        GasTestLELLimits = limits;
                        GasTestLELImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestLELImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestLELConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestLELConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    case "H2S":
                        GasTestH2SLimits = limits;
                        GasTestH2SImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestH2SImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestH2SConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestH2SConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    case "SO2":
                        GasTestSO2Limits = limits;
                        GasTestSO2ImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestSO2ImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestSO2ConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestSO2ConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    case "CO":
                        GasTestCOLimits = limits;
                        GasTestCOImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestCOImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestCOConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestCOConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    case "Benzene":
                        GasTestBenzeneLimits = limits;
                        GasTestBenzeneImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestBenzeneImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestBenzeneConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestBenzeneConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    case "Toluene":
                        GasTestTolueneLimits = limits;
                        GasTestTolueneImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestTolueneImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestTolueneConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestTolueneConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    case "Xylene":
                        GasTestXyleneLimits = limits;
                        GasTestXyleneImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestXyleneImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestXyleneConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestXyleneConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    case "VOC":
                        GasTestAmmoniaLimits = limits;
                        GasTestAmmoniaImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestAmmoniaImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestAmmoniaConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestAmmoniaConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        break;

                    //case "Other (1)":
                    //    Other1Limit = limits;
                    //    Other1ImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                    //    Other1ImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                    //    Other1ConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                    //    Other1ConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                    //    break;

                    default:

                        counter += 1;
                        if (counter == 1) { 
                        GasTestCustomName = gasTestName.NullableToString();
                        GasTestCustomLimits = limits;
                        GasTestCustomImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
                        GasTestCustomImmediateAreaFirstTestResult = element.ImmediateAreaTestResult.NullableToString();
                        GasTestCustomConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
                        GasTestCustomConfinedSpaceFirstTestResult = element.ConfinedSpaceTestResult.NullableToString();
                        }
                        else
                        {
                        GasTestCustomName_other1 = gasTestName.NullableToString();
                        GasTestCustomLimits_other1 = limits;
                        GasTestCustomImmediateAreaTestRequired_other1 = element.ImmediateAreaTestRequired;
                        GasTestCustomImmediateAreaFirstTestResult_other1 = element.ImmediateAreaTestResult.NullableToString();
                        GasTestCustomConfinedSpaceTestRequired_other1 = element.ConfinedSpaceTestRequired;
                        GasTestCustomConfinedSpaceFirstTestResult_other1 = element.ConfinedSpaceTestResult.NullableToString();
                        }
                        break;
                }
            }

            GasTestImmediateAreaTimeOfTest = gasTests.ImmediateAreaTestTime.NullableToString();
            GasTestConfinedSpaceTimeOfTest = gasTests.ConfinedSpaceTestTime.NullableToString();
        }

        #endregion



        //Sign Properties Adde by Mukesh

        public string WorkPermitId { get; set; }
        public string ISSUER_NAME { get; set; }
        public string ISSUER_BADGENUMBER { get; set; }
        public string ISSUER_BADGETYPE { get; set; }
        public string ISSUER_SOURCE { get; set; }

        public string NEXT_LVL_ISSUER_NAME { get; set; }
        public string NEXT_LVL_ISSUER_BADGENUMBER { get; set; }
        public string NEXT_LVL_ISSUER_BADGETYPE { get; set; }
        public string NEXT_LVL_ISSUER_SOURCE { get; set; }

        public string PERMIT_RECEIVER_NAME { get; set; }
        public string PERMIT_RECEIVER_BADGENUMBER { get; set; }
        public string PERMIT_RECEIVER_BADGETYPE { get; set; }
        public string PERMIT_RECEIVER_SOURCE { get; set; }
        string _CROSS_ZONE_AUTHO_NAME;
        public string CROSS_ZONE_AUTHO_NAME { 
            get{
                if ((_CROSS_ZONE_AUTHO_NAME == null || _CROSS_ZONE_AUTHO_NAME.Trim() == "") && CoAuthorizationRequiredYes)
                {
                    return CoAuthorizationDescription;
                }
                else
                {
                    return _CROSS_ZONE_AUTHO_NAME;
                }
            }
            set{_CROSS_ZONE_AUTHO_NAME=value;}
        }
        public string CROSS_ZONE_AUTHO_BADGENuMBER { get; set; }
        public string CROSS_ZONE_AUTHO_BADGETYPE { get; set; }
        public string CROSS_ZONE_AUTHO_SOURCE { get; set; }

        public string IMMIDIATE_NAME { get; set; }
        public string IMMIDIATE_BADGENUMBER { get; set; }
        public string IMMIDIATE_BADGETYPE { get; set; }
        public string IMMIDIATE_SOURCE { get; set; }

        public string CONFINED_NAME { get; set; }
        public string CONFINED_BADGENUMBER { get; set; }
        public string CONFINED_BADGETYPE { get; set; }
        public string CONFINED_SOURCE { get; set; }

        public string BeforeExtensionDate
        {

            get
            {
                if (workpermit.ExtensionEnable || workpermit.RevalidationEnable)
                {
                    return workpermit.BeforeExtensionDateTime.Value.ToLongDateAndTimeString();
                    
                }
                else
                {
                    return workpermit.EndDateTime.Value.ToLongDateAndTimeString();
                }
            }
        }

        

       

    }
}