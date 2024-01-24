using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Validation.Lubes
{
    public class PermitRequestLubesValidationDomainAdapter : PermitRequestLubesBaseValidationAdapter
    {
        private readonly List<string> missingFields = new List<string>();
        private readonly PermitRequestLubes permitRequest;

        public PermitRequestLubesValidationDomainAdapter(PermitRequestLubes permitRequest)
        {
            this.permitRequest = permitRequest;
        }

        public override List<string> MissingImportFieldList
        {
            get { return missingFields; }
        }

        public override int? NumberOfWorkers
        {
            get { return permitRequest.NumberOfWorkers; }
        }

        public override FunctionalLocation FunctionalLocation
        {
            get { return permitRequest.FunctionalLocation; }
        }

        public override WorkPermitLubesType WorkPermitType
        {
            get { return permitRequest.WorkPermitType; }
        }

        public override Date RequestedStartDate
        {
            get { return permitRequest.RequestedStartDate; }
        }

        public override Time RequestedStartTimeDay
        {
            get { return permitRequest.RequestedStartTimeDay; }
        }

        public override Time RequestedStartTimeNight
        {
            get { return permitRequest.RequestedStartTimeNight; }
        }

        public override Date RequestedEndDate
        {
            get { return permitRequest.EndDate; }
        }

        public override string WorkOrderNumber
        {
            get { return permitRequest.WorkOrderNumber; }
        }

        public override string OperationNumber
        {
            get { return permitRequest.OperationNumber; }
        }

        public override string SubOperationNumber
        {
            get { return permitRequest.SubOperationNumber; }
        }

        public override string Description
        {
            get { return permitRequest.Description; }
        }

        public override bool IssuedToContractor
        {
            get { return permitRequest.IssuedToCompany; }
        }

        public override string Company
        {
            get { return permitRequest.Company; }
        }

        public override string Trade
        {
            get { return permitRequest.Trade; }
        }

        public override string Location
        {
            get { return permitRequest.Location; }
        }

        public override bool OtherAreasAndOrUnitsAffected
        {
            get { return permitRequest.OtherAreasAndOrUnitsAffected; }
        }

        public override string OtherAreasAndOrUnitsAffectedArea
        {
            get { return permitRequest.OtherAreasAndOrUnitsAffectedArea; }
        }

        public override string OtherAreasAndOrUnitsAffectedPersonNotified
        {
            get { return permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified; }
        }

        public override WorkPermitLubesGroup RequestedByGroup
        {
            get { return permitRequest.RequestedByGroup; }
        }

        public override bool SpecialWork
        {
            get { return permitRequest.SpecialWork; }
        }

        public override string SpecialWorkType
        {
            get { return permitRequest.SpecialWorkType; }
        }

        public override WorkPermitSafetyFormState HighEnergy
        {
            get { return permitRequest.HighEnergy; }
        }

        public override WorkPermitSafetyFormState CriticalLift
        {
            get { return permitRequest.CriticalLift; }
        }

        public override WorkPermitSafetyFormState Excavation
        {
            get { return permitRequest.Excavation; }
        }

        public override WorkPermitSafetyFormState EnergyControlPlan
        {
            get { return permitRequest.EnergyControlPlan; }
        }

        public override WorkPermitSafetyFormState EquivalencyProc
        {
            get { return permitRequest.EquivalencyProc; }
        }

        public override WorkPermitSafetyFormState TestPneumatic
        {
            get { return permitRequest.TestPneumatic; }
        }

        public override WorkPermitSafetyFormState LiveFlareWork
        {
            get { return permitRequest.LiveFlareWork; }
        }

        public override WorkPermitSafetyFormState EntryAndControlPlan
        {
            get { return permitRequest.EntryAndControlPlan; }
        }

        public override WorkPermitSafetyFormState EnergizedElectrical
        {
            get { return permitRequest.EnergizedElectrical; }
        }

        public override bool SpecificRequirementsSectionNotApplicableToJob
        {
            get { return permitRequest.SpecificRequirementsSectionNotApplicableToJob; }
        }

        public override bool AttendedAtAllTimes
        {
            get { return permitRequest.AttendedAtAllTimes; }
        }

        public override bool EyeProtection
        {
            get { return permitRequest.EyeProtection; }
        }

        public override bool FallProtectionEquipment
        {
            get { return permitRequest.FallProtectionEquipment; }
        }

        public override bool FullBodyHarnessRetrieval
        {
            get { return permitRequest.FullBodyHarnessRetrieval; }
        }

        public override bool HearingProtection
        {
            get { return permitRequest.HearingProtection; }
        }

        public override bool ProtectiveClothing
        {
            get { return permitRequest.ProtectiveClothing; }
        }

        public override bool Other1Checked
        {
            get { return permitRequest.Other1Checked; }
        }

        public override string Other1Value
        {
            get { return permitRequest.Other1Value; }
        }

        public override bool EquipmentBondedGrounded
        {
            get { return permitRequest.EquipmentBondedGrounded; }
        }

        public override bool FireBlanket
        {
            get { return permitRequest.FireBlanket; }
        }

        public override bool FireFightingEquipment
        {
            get { return permitRequest.FireFightingEquipment; }
        }

        public override bool FireWatch
        {
            get { return permitRequest.FireWatch; }
        }

        public override bool HydrantPermit
        {
            get { return permitRequest.HydrantPermit; }
        }

        public override bool WaterHose
        {
            get { return permitRequest.WaterHose; }
        }

        public override bool SteamHose
        {
            get { return permitRequest.SteamHose; }
        }

        public override bool Other2Checked
        {
            get { return permitRequest.Other2Checked; }
        }

        public override string Other2Value
        {
            get { return permitRequest.Other2Value; }
        }

        public override bool AirMover
        {
            get { return permitRequest.AirMover; }
        }

        public override bool ContinuousGasMonitor
        {
            get { return permitRequest.ContinuousGasMonitor; }
        }

        public override bool DrowningProtection
        {
            get { return permitRequest.DrowningProtection; }
        }

        public override bool RespiratoryProtection
        {
            get { return permitRequest.RespiratoryProtection; }
        }

        public override bool Other3Checked
        {
            get { return permitRequest.Other3Checked; }
        }

        public override string Other3Value
        {
            get { return permitRequest.Other3Value; }
        }

        public override bool AdditionalLighting
        {
            get { return permitRequest.AdditionalLighting; }
        }

        public override bool DesignateHotOrColdCutChecked
        {
            get { return permitRequest.DesignateHotOrColdCutChecked; }
        }

        public override string DesignateHotOrColdCutValue
        {
            get { return permitRequest.DesignateHotOrColdCutValue; }
        }

        public override bool HoistingEquipment
        {
            get { return permitRequest.HoistingEquipment; }
        }

        public override bool Ladder
        {
            get { return permitRequest.Ladder; }
        }

        public override bool MotorizedEquipment
        {
            get { return permitRequest.MotorizedEquipment; }
        }

        public override bool Scaffold
        {
            get { return permitRequest.Scaffold; }
        }

        public override bool ReferToTipsProcedure
        {
            get { return permitRequest.ReferToTipsProcedure; }
        }

        public override void ClearErrors()
        {
            missingFields.Clear();
        }

        public override void ActionForNumberOfWorkersLessThanOrEqualToZero()
        {
            ;
        }

        public override void ActionForNoFunctionalLocation()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_FunctionalLocation);
        }

        public override void ActionForNoPermitType()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_WorkPermitType);
        }

        public override void ActionForNoRequestedStartDate()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_StartDate);
        }

        public override void ActionForNoRequestedEndDate()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_EndDate);
        }

        public override void ActionForNoWorkOrderNumber()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_WorkOrderNumber);
        }

        public override void ActionForNoOperationNumber()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_OperationNumber);
        }

        public override void ActionForNoSubOperationNumber()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_SubOperationNumber);
        }

        public override void ActionForNoDescription()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Description);
        }

        public override void ActionForNoContractor()
        {
            ; // IMPORTTODO: not sure if we validate on this yet.
        }

        public override void ActionForNoTrade()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Trade);
        }

        public override void ActionForNoLocation()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_Location);
        }

        public override void ActionForNoRequestedByGroup()
        {
            missingFields.Add(StringResources.PermitRequestFieldName_RequestedByGroup);
        }
    }
}