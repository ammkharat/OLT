using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Validation.FortHills
{
    public class WorkPermitFortHillsValidator
    {
        private readonly WorkPermitFortHillsBaseValidationAdapter adapter;
        private readonly LabelAttributes attributesForHazardsLabel;
        private bool hasErrors;
        private bool hasWarnings;

        public WorkPermitFortHillsValidator(WorkPermitFortHillsBaseValidationAdapter adapter,
            LabelAttributes attributesForHazardsLabel)
        {
            this.adapter = adapter;
            this.attributesForHazardsLabel = attributesForHazardsLabel;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public bool HasWarnings
        {
            get { return hasWarnings; }
        }

        //private List<bool> FireProtectiveMeasuresValues
        //{
        //    get
        //    {
        //        return new List<bool>
        //        {
        //            adapter.EquipmentGrounded,
        //            adapter.FireBlanket,
        //            adapter.FireExtinguisher,
        //            adapter.FireMonitorManned,
        //            adapter.FireWatch,
        //            adapter.SewersDrainsCovered,
        //            adapter.SteamHose,
        //            adapter.Other2
        //        };
        //    }
        //}

        protected void SetHasError()
        {
            hasErrors = true;
        }

        protected void SetHasWarning()
        {
            hasWarnings = true;
        }

        protected void ClearErrors()
        {
            adapter.ClearErrors();
            hasErrors = false;
            hasWarnings = false;
        }

        public void ValidateAndSetErrors(DateTime nowInFortHills)
        {
            ClearErrors();
            ValidateHasContractorIfContractorCheckboxIsChecked();
            ValidateHasOccupation();
            //ValidateHasGroup();

            ValidateHasFunctionalLocation();
            ValidateHasPermitType();
            ValidateHasDescription();
            ValidateHasContractorIfContractorCheckboxIsChecked();
            //ValidateHasAreaAndPersonNotifiedIfOtherAreasAffected();
            ValidateNumberOfWorkersIsPositive();

            ValidateHasLocation();

            ValidateHasLockBoxAndIsolationNo();
           // ValidateHasEquipmentNo();
            ValidateHasEmergencyDetails();
            ValidateHasFieldTourconductedBy();
            ValidateHasAtLeastOneSafetyRequirementIfSectionIsEnabledPartC();
            ValidateNoHazardsAndRequirementsDescriptionPartD();
            ValidateHazardsAndRequirementsDescription();
            ValidateHasAtLeastOneSafetyRequirementPartE();
            ValidateHasAtLeastOneControlOfHazardusEnergyPartF();
            ValidateHasAtLeastOneControlOfHazardusEnergyPartG();
           // ValidateExtensionDate();
            
            ValidateOtherIfTheyAreChecked();
            //ValidateTypeOfWorkFieldsHaveValuesIfTheyAreChecked();
            ValidateRequestedAndExpiryDateTimes(nowInFortHills);
            //ValidateHasStatusOfPipingEquipmentSectionFilledOutIfItIsEnabled();
            //ValidateAllGasTestsFieldsAreFilledInIfSectionIsEnabled();
            //ValidateAtLeastOneIssuedToOptionIsSelected();
            //ValidateHasHazardsAndOrRequirements();
            //ValidateAtLeastOneFireProtectiveMeasureIsSelectedIfPermitTypeIsHighEnergy();
            //ValidateQuestionOneIsAnsweredYesIfSectionIsEnabled();
            //ValidateRadioNumber();
            //ValidateMonitorNumber();
           
            //ValidateFormNumbers();
            //commented as per adity's mail Feb 6,2016- to remove validation
            //ValidateHasNumeric();//mangesh - for numeric
        }

        private void ValidateNumberOfWorkersIsPositive()
        {
            if (adapter.NumberOfWorkers != null && adapter.NumberOfWorkers.Value <= 0)
            {
                adapter.ActionForNumberOfWorkersLessThanOrEqualToZero();
                SetHasWarning();
            }
        }

        //private void ValidateHasGroup()
        //{
        //    if (adapter.Group == null)
        //    {
        //        adapter.ActionForNoGroup();
        //        SetHasWarning();
        //    }
        //}

        protected void ValidateHasFunctionalLocation()
        {
            if (adapter.FunctionalLocation == null)
            {
                adapter.ActionForNoFunctionalLocation();
                SetHasError();
            }
        }

        protected void ValidateHasPermitType()
        {
            if (adapter.WorkPermitType == null || WorkPermitType.NULL.Equals(adapter.WorkPermitType))
            {
                adapter.ActionForNoPermitType();
                SetHasError();
            }
        }

        protected void ValidateHasDescription()
        {
            if (adapter.Description.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoDescription();
                SetHasError();
            }
        }

        //private void ValidateHasNumeric()
        //{
        //    if (adapter.GasTestDataLine1CombustibleGas.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine1CombustibleGas");
        //        SetHasError();
        //    }
            
        //    if (adapter.GasTestDataLine2CombustibleGas.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine2CombustibleGas");
        //        SetHasError();
        //    }
        //    if (adapter.GasTestDataLine3CombustibleGas.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine3CombustibleGas");
        //        SetHasError();
        //    }
        //    if (adapter.GasTestDataLine4CombustibleGas.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine4CombustibleGas");
        //        SetHasError();
        //    }

        //    if (adapter.GasTestDataLine1Oxygen.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine1Oxygen");
        //        SetHasError();
        //    }
        //    if (adapter.GasTestDataLine2Oxygen.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine2Oxygen");
        //        SetHasError();
        //    }
        //    if (adapter.GasTestDataLine3Oxygen.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine3Oxygen");
        //        SetHasError();
        //    }
        //    if (adapter.GasTestDataLine4Oxygen.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine4Oxygen");
        //        SetHasError();
        //    }

        //    if (adapter.GasTestDataLine1ToxicGas.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine1ToxicGas");
        //        SetHasError();
        //    }
        //    if (adapter.GasTestDataLine2ToxicGas.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine2ToxicGas");
        //        SetHasError();
        //    }
        //    if (adapter.GasTestDataLine3ToxicGas.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine3ToxicGas");
        //        SetHasError();
        //    }
        //    if (adapter.GasTestDataLine4ToxicGas.IsAlphaNumeric())
        //    {
        //        adapter.ActionForNoNumeric("GasTestDataLine4ToxicGas");
        //        SetHasError();
        //    }
        //}

        protected void ValidateHasContractorIfContractorCheckboxIsChecked()
        {
            if (adapter.IssuedToContractor && adapter.Company.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoContractor();
                SetHasWarning();
            }
        }

        //protected void ValidateHasAreaAndPersonNotifiedIfOtherAreasAffected()
        //{
        //    if (!adapter.OtherAreasAndOrUnitsAffected)
        //    {
        //        return;
        //    }

        //    if (adapter.OtherAreasAndOrUnitsAffectedArea.IsNullOrEmptyOrWhitespace())
        //    {
        //        adapter.ActionForNoAreaAffected();
        //        SetHasWarning();
        //    }

        //    if (adapter.OtherAreasAndOrUnitsAffectedPersonNotified.IsNullOrEmptyOrWhitespace())
        //    {
        //        adapter.ActionForNoPersonNotified();
        //        SetHasWarning();
        //    }
        //}

        protected void ValidateHasOccupation()
        {
            if (adapter.Occupation.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoOccupation();
                SetHasWarning();
            }
        }

        protected void ValidateHasLocation()
        {
            if (adapter.Location.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoLocation();
                SetHasWarning();
            }
        }
        protected void ValidateHasLockBoxAndIsolationNo()
        {
            if (adapter.IsLockboxNumberrequired && (adapter.LockBoxNumber.IsNullOrEmptyOrWhitespace() || adapter.IsolationNo.IsNullOrEmptyOrWhitespace()))
            {
                adapter.ActionForNoLockBoxAndIsolationNo();
                SetHasError();
            }
        }
        //protected void ValidateHasEquipmentNo()
        //{
        //    if (adapter.EquipmentNo.IsNullOrEmptyOrWhitespace())
        //    {
        //        adapter.ActionForNoEquipmentNo();
        //        SetHasError();
        //    }
        //}
        protected void ValidateHasEmergencyDetails()
        {
            if (adapter.EmergencyMeetingPoint.IsNullOrEmptyOrWhitespace() | adapter.EmergencyAssemblyArea.IsNullOrEmptyOrWhitespace() || adapter.EmergencyContactNo.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoEmergencyDetails();
                SetHasError();
            }
        }
        protected void ValidateHasFieldTourconductedBy()
        {
            if (adapter.IsFieldTourRequired && adapter.FieldTourConductedBy.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForIsFieldTourRequiredYes();
                SetHasError();
            }
        }
        protected void ValidateHasAtLeastOneSafetyRequirementIfSectionIsEnabledPartC()
        {
            if (!adapter.PartCWorkSectionNotApplicableToJob)
            {
                var values = new List<bool>
                {
                    adapter.FlameResistantWorkWear,
                    adapter.ChemicalSuit,
                    adapter.FireWatch,
                    adapter.FireBlanket,
                    adapter.SuppliedBreathingAir,
                    adapter.AirMover,
                    adapter.PersonalFlotationDevice,
                    adapter.HearingProtection,
                    adapter.Other1,
                    adapter.Other2Value!=null,
                    adapter.MonoGoggles,
                    adapter.ConfinedSpaceMoniter,
                    adapter.FireExtinguisher,
                    adapter.SparkContainment,
                    adapter.BottleWatch,
                    adapter.StandbyPerson,
                    adapter.WorkingAlone,
                    adapter.SafetyGloves,
                    adapter.Other2,
                    adapter.Other2Value!=null,
                    adapter.FaceShield,
                    adapter.FallProtection,
                    adapter.ChargedFireHouse,
                    adapter.CoveredSewer,
                    adapter.AirPurifyingRespirator,
                    adapter.SingalPerson,
                    adapter.CommunicationDevice  ,
                    adapter.ReflectiveStrips  ,
                    adapter.Other3 ,
                    adapter.Other3Value!=null

                };

                var noValueIsChecked = values.TrueForAll(value => value == false);
                if (noValueIsChecked)
                {
                    adapter.ActionForNoSpecialSafetyEquipmentRequirementChosenPartC();
                    SetHasError();
                }
            }
        }

        protected void ValidateOtherIfTheyAreChecked()
        {
            if (!adapter.PartCWorkSectionNotApplicableToJob)
            {
                if (adapter.Other1 && adapter.Other1Value.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther1CheckedWithNoValue();
                    SetHasError();
                }

                if (adapter.Other2 && adapter.Other2Value.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther2CheckedWithNoValue();
                    SetHasError();
                }

                if (adapter.Other3 && adapter.Other3Value.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther3CheckedWithNoValue();
                    SetHasError();
                }
            }

            if (!adapter.PartEWorkSectionNotApplicableToJob)
            {
                if (adapter.OthersPartEChecked && adapter.OthersPartE.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOtherPartECheckedWithNoValue();
                    SetHasError();
                }
            }
            if (!adapter.PartGWorkSectionNotApplicableToJob)
            {
                if (adapter.Other1PartG && adapter.Other1PartGValue.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther1PartGCheckedWithNoValue();
                    SetHasError();
                }
                if (adapter.Other2PartG && adapter.Other2PartGValue.IsNullOrEmptyOrWhitespace())
                {
                    adapter.ActionForOther2PartGCheckedWithNoValue();
                    SetHasError();
                }
            }
        }

        protected virtual void ValidateHasAtLeastOneSafetyRequirementPartE()
        {
            if (!adapter.PartEWorkSectionNotApplicableToJob)
            {
                var values = new List<bool>
                {
                    adapter.ConfinedSpace,
                    adapter.GroundDisturbance,
                    adapter.FireProtectionAuthorization,
                    adapter.CriticalOrSeriousLifts,
                    adapter.VehicleEntry,
                    adapter.IndustrialRadiography,
                    adapter.ElectricalEncroachment,
                    adapter.MSDS,
                    adapter.OthersPartEChecked,
                    adapter.OthersPartE!=null,
                    adapter.ConfinedSpaceClass!=null
                };

                var noValueIsChecked = values.TrueForAll(value => value == false);
                if (noValueIsChecked)
                {
                    adapter.ActionForNoworkAuthorizationAndDocumentationChosenPartE();
                    SetHasError();
                }
            }
        }

        protected virtual void ValidateHasAtLeastOneControlOfHazardusEnergyPartF()
        {
            if (!adapter.PartFWorkSectionNotApplicableToJob)
            {
                var values = new List<bool>
                {
                    adapter.MechanicallyIsolated,
                    adapter.BlindedOrBlanked,
                    adapter.DoubleBlockedandBled,
                    adapter.DrainedAndDepressurised,
                    adapter.PurgedorNeutralised,
                    adapter.ElectricallyIsolated,
                    adapter.TestBumped,
                    adapter.NuclearSource,
                    adapter.ReceiverStafingRequirements,
                };

                var noValueIsChecked = values.TrueForAll(value => value == false);
                if (noValueIsChecked)
                {
                    adapter.ActionForNoControlOfHazardusEnergyChosenPartF();
                    SetHasError();
                }
            }
        }
        protected virtual void ValidateHasAtLeastOneControlOfHazardusEnergyPartG()
        {
            if (!adapter.PartGWorkSectionNotApplicableToJob)
            {
                var values = new List<bool>
                {
                    adapter.Frequency != null,
                    adapter.Continuous,
                    adapter.TesterName.Trim() !=string.Empty,
                    adapter.Oxygen,
                    adapter.LEL,
                    adapter.H2SPPM,
                    adapter.So2PPM,
                    adapter.CoPPM,
                    adapter.NuclearSource,
                    adapter.Other1PartG,
                    adapter.Other1PartGValue!=null,
                    adapter.Other2PartG,
                    adapter.Other2PartGValue!=null
                };

                var noValueIsChecked = values.TrueForAll(value => value == false);
                if (noValueIsChecked)
                {
                    adapter.ActionForNoAtmosphericMoniteringChosenPartG();
                    SetHasError();
                }
            }
        }
        private void ValidateHazardsAndRequirementsDescription()
        {
            if (!DevExpressMeasurementUtility.StringWillFitIntoField(attributesForHazardsLabel,
                    adapter.HazardsAndOrRequirements))
            {
                adapter.ActionForHazardsTooLong();
                SetHasError();
            }
        }
        private void ValidateNoHazardsAndRequirementsDescriptionPartD()
        {
            if (!adapter.PartDWorkSectionNotApplicableToJob && adapter.HazardsAndOrRequirements.IsNullOrEmptyOrWhitespace())
            {
                adapter.ActionForNoHazardsAndOrRequirements();
                SetHasError();
            }
        }
        //private void ValidateExtensionDate()
        //{
        //    if (adapter.ExtensionDateTime != DateTime.MinValue)
        //    {
        //       double differenceInMinutes = (Convert.ToDateTime(adapter.ExtensionDateTime) - adapter.ExpiryDateTime).TotalMinutes;
        //       if (differenceInMinutes>240)
        //        adapter.ActionForExtensionDategraterThen4HrsFromExpieryDate();
        //        SetHasError();
        //    }
        //}
        //protected void ValidateTypeOfWorkFieldsHaveValuesIfTheyAreChecked()
        //{
        //    //if (adapter.AlkylationEntry && adapter.AlkylationEntryClassOfClothing.IsNullOrEmptyOrWhitespace())
        //    //{
        //    //    adapter.ActionForNoClassOfClothing();
        //    //    SetHasWarning();
        //    //}

        //    //if (adapter.FlarePitEntry && adapter.FlarePitEntryType.IsNullOrEmptyOrWhitespace())
        //    //{
        //    //    adapter.ActionForNoFlarePitEntryType();
        //    //    SetHasWarning();
        //    //}

        //    if (adapter.ConfinedSpace && adapter.ConfinedSpaceClass.IsNullOrEmptyOrWhitespace())
        //    {
        //        adapter.ActionForNoConfinedSpaceClass();
        //        SetHasWarning();
        //    }

        //    //if (adapter.ConfinedSpace && adapter.ConfinedSpaceCardNumber.IsNullOrEmptyOrWhitespace())
        //    //{
        //    //    if (adapter.ConfinedSpaceClass != WorkPermitFortHills.ConfinedSpaceLevel3)
        //    //    {
        //    //        adapter.ActionForNoConfinedSpaceCardNumber();
        //    //        SetHasWarning();
        //    //    }
        //    //}

        //    //if (adapter.RescuePlan && adapter.RescuePlanFormNumber.IsNullOrEmptyOrWhitespace())
        //    //{
        //    //    adapter.ActionForNoRescuePlanFormNumber();
        //    //    SetHasWarning();
        //    //}

        //    //if (adapter.SpecialWork && adapter.SpecialWorkType == null) 
        //    //{
        //    //    adapter.ActionForNoSpecialWorkType();
        //    //    SetHasWarning();
        //    //}

        //    //if (adapter.SpecialWork)
        //    //{
        //    //    if (string.IsNullOrEmpty(adapter.SpecialWorkName) || string.IsNullOrWhiteSpace(adapter.SpecialWorkName))
        //    //    {
        //    //        adapter.ActionForNoSpecialWorkType();
        //    //        SetHasWarning();
        //    //    }
        //    //}
        //    //mangesh for RoadAccessOnPermit
        //    //if (adapter.RoadAccessOnPermit && adapter.RoadAccessOnPermitType.IsNullOrEmptyOrWhitespace())
        //    //{
        //    //    adapter.ActionForNoRoadAccessOnPermitType();
        //    //    SetHasWarning();
        //    //}

        //    //if (WorkPermitSafetyFormState.Required.Equals(adapter.GN11))
        //    //{
        //    //    adapter.ActionForInvalidGN11Value();
        //    //    SetHasWarning();
        //    //}

        //    //if (WorkPermitSafetyFormState.Required.Equals(adapter.GN27))
        //    //{
        //    //    adapter.ActionForInvalidGN27Value();
        //    //    SetHasWarning();
        //    //}
        //}

     //   private void ValidateFormNumbers()
       // {
        /*  if (adapter.GN6 && (adapter.FormGN6 == null || !adapter.FormGN6.IsApproved()))
            {
                adapter.ActionForNoApprovedGN6Form();
                SetHasWarning();
            }

            if (adapter.GN7 && (adapter.FormGN7 == null || !adapter.FormGN7.IsApproved()))
            {
                adapter.ActionForNoApprovedGN7Form();
                SetHasWarning();
            }

            if (adapter.GN59 && (adapter.FormGN59 == null || !adapter.FormGN59.IsApproved()))
            {
                adapter.ActionForNoApprovedGN59Form();
                SetHasWarning();
            }

            if (adapter.GN24 && (adapter.FormGN24 == null || !adapter.FormGN24.IsApproved()))
            {
                adapter.ActionForNoApprovedGN24Form();
                SetHasWarning();
            }

            if (adapter.GN75A && (adapter.FormGN75A == null || !adapter.FormGN75A.IsApproved()))
            {
                adapter.ActionForNoApprovedGN75AForm();
                SetHasWarning();
            }

           if (adapter.GN1 && (adapter.FormGN1 == null || !adapter.FormGN1.IsApproved()))
            {
                
               adapter.ActionForNoApprovedGN1Form();
               SetHasWarning();
               
            }
            */
        // if (adapter.Group != null) // Swapnil Patki For DMND0005325 Point Number 9
          //   {
           //if (adapter.GN1 && adapter.AggrementAndSignature == null && (adapter.Group.Value == 1) || adapter.GN6 && adapter.AggrementAndSignature == null && (adapter.Group.Value == 1) ||
           //     adapter.GN59 && adapter.AggrementAndSignature == null&& (adapter.Group.Value == 1))
           // {
           //     adapter.ActionForGroupMaintenance();
           //     SetHasError();
           // }
                //mangesh - comment above and added below  For DMND0005325 Point Number 9
           //if (adapter.Group.Value == 1 && adapter.AggrementAndSignature == null && (adapter.GN1 || adapter.GN6 || adapter.GN59))
           //{
           //    adapter.ActionForGroupMaintenance();
           //    SetHasError();
           //}
           // }
            //Start Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016

            
            //if ((adapter.GN1 && (adapter.FormGN1 == null || adapter.FormGN1.TradeChecklists.Count > 0)) && 
            //       adapter.ConfinedSpaceCardNumber == null || !adapter.FormGN1.TradeChecklists.Exists(x => x.TradeChecklistInformationDisplayText == adapter.ConfinedSpaceCardNumber))
            //{
            //    adapter.ActionForValidTradeCheckGN1Form();
            //    SetHasWarning();
            //}

            //if(adapter.GN1 && (adapter .FormGN1 != null && adapter.FormGN1.TradeChecklists.Count > 0) &&
            //    (adapter.ConfinedSpaceCardNumber != null &&
            //        !adapter.FormGN1.TradeChecklists.Exists(x => x.TradeChecklistInformationDisplayText == adapter.ConfinedSpaceCardNumber)))
            //{
            //    adapter.ActionForValidTradeCheckGN1Form();
            //    SetHasWarning();
            //}

            //List<Form.TradeChecklist> _A = adapter.FormGN1.TradeChecklists;
            //bool value = _A.Exists(x => x.TradeChecklistInformationDisplayText == adapter.ConfinedSpaceCardNumber);

            //End Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
            
        //}

      

        

        //private void ValidateQuestionOneIsAnsweredYesIfSectionIsEnabled()
        //{
        //    if (adapter.QuestionOneResponse != YesNoNotApplicable.YES &&
        //        !adapter.ConfinedSpaceWorkSectionNotApplicableToJob)
        //    {
        //        adapter.ActionForQuestionOneNotSetToYes();
        //        SetHasWarning();
        //    }
        //}

        //private void ValidateAtLeastOneFireProtectiveMeasureIsSelectedIfPermitTypeIsHighEnergy()
        //{
        //    if (adapter.WorkPermitType != null &&
        //        adapter.WorkPermitType.Equals(WorkPermitFortHillsType.BLANKET_HOT))
        //    {
        //        var noValueIsChecked = FireProtectiveMeasuresValues.TrueForAll(value => value == false);
        //        if (noValueIsChecked)
        //        {
        //            adapter.ActionForNoFireProtectiveMeasuresChosenButTypeIsHighEnergyHotWork();
        //            SetHasWarning();
        //        }
        //    }
        //}

        //private void ValidateHasHazardsAndOrRequirements()
        //{
        //    if (adapter.HazardsAndOrRequirements.IsNullOrEmptyOrWhitespace())
        //    {
        //        adapter.ActionForNoHazardsAndOrRequirements();
        //        SetHasWarning();
        //    }
        //}

        //private void ValidatelockBoxRequiredOptionIsSelected()
        //{
        //    if (adapter.IssuedToContractor == false && adapter.IssuedToSuncor == false)
        //    {
        //        adapter.ActionForNoContractor();
        //        SetHasWarning();
        //    }
        //}

        //private void ValidateAllGasTestsFieldsAreFilledInIfSectionIsEnabled()
        //{
        //    if (adapter.WorkerToProvideGasTestData)
        //    {
        //        return;
        //    }

        //    if (!adapter.GasTestsSectionNotApplicableToJob)
        //    {
        //        var line1Okay = GasTestLineIsValid(
        //            adapter.GasTestDataLine1CombustibleGas, adapter.GasTestDataLine1Oxygen,
        //            adapter.GasTestDataLine1ToxicGas, adapter.GasTestDataLine1Time);

        //        var line2Okay = GasTestLineIsValid(
        //            adapter.GasTestDataLine2CombustibleGas, adapter.GasTestDataLine2Oxygen,
        //            adapter.GasTestDataLine2ToxicGas, adapter.GasTestDataLine2Time);

        //        var line3Okay = GasTestLineIsValid(
        //            adapter.GasTestDataLine3CombustibleGas, adapter.GasTestDataLine3Oxygen,
        //            adapter.GasTestDataLine3ToxicGas, adapter.GasTestDataLine3Time);

        //        var line4Okay = GasTestLineIsValid(
        //            adapter.GasTestDataLine4CombustibleGas, adapter.GasTestDataLine4Oxygen,
        //            adapter.GasTestDataLine4ToxicGas, adapter.GasTestDataLine4Time);

        //        var line1Empty = GasTestLineIsEmpty(
        //            adapter.GasTestDataLine1CombustibleGas, adapter.GasTestDataLine1Oxygen,
        //            adapter.GasTestDataLine1ToxicGas, adapter.GasTestDataLine1Time);

        //        var line2Empty = GasTestLineIsEmpty(
        //            adapter.GasTestDataLine2CombustibleGas, adapter.GasTestDataLine2Oxygen,
        //            adapter.GasTestDataLine2ToxicGas, adapter.GasTestDataLine2Time);

        //        var line3Empty = GasTestLineIsEmpty(
        //            adapter.GasTestDataLine3CombustibleGas, adapter.GasTestDataLine3Oxygen,
        //            adapter.GasTestDataLine3ToxicGas, adapter.GasTestDataLine3Time);

        //        var line4Empty = GasTestLineIsEmpty(
        //            adapter.GasTestDataLine4CombustibleGas, adapter.GasTestDataLine4Oxygen,
        //            adapter.GasTestDataLine4ToxicGas, adapter.GasTestDataLine4Time);

        //        var allValuesAreEmpty = line1Empty && line2Empty && line3Empty && line4Empty;

        //        if (allValuesAreEmpty)
        //        {
        //            adapter.ActionForAtLeastOneGasTestsTableLineMustBeFilledOut();
        //            SetHasWarning();
        //        }
        //        else if (!line1Okay)
        //        {
        //            adapter.ActionForGasTestsTableLine1IsInvalid();
        //            SetHasWarning();
        //        }
        //        else if (!line2Okay)
        //        {
        //            adapter.ActionForGasTestsTableLine2IsInvalid();
        //            SetHasWarning();
        //        }
        //        else if (!line3Okay)
        //        {
        //            adapter.ActionForGasTestsTableLine3IsInvalid();
        //            SetHasWarning();
        //        }
        //        else if (!line4Okay)
        //        {
        //            adapter.ActionForGasTestsTableLine4IsInvalid();
        //            SetHasWarning();
        //        }

        //        if (adapter.OperatorGasDetectorNumber.IsNullOrEmptyOrWhitespace())
        //        {
        //            adapter.ActionForNoOperatorGasDetectorNumber();
        //            SetHasWarning();
        //        }
        //    }
        //}

        //private void ValidateHasStatusOfPipingEquipmentSectionFilledOutIfItIsEnabled()
        //{
        //    if (!adapter.StatusOfPipingEquipmentSectionNotApplicableToJob)
        //    {
        //        if (adapter.ProductNormallyInPipingEquipment.IsNullOrEmptyOrWhitespace())
        //        {
        //            adapter.ActionForNoProductNormallyInPipingEquipment();
        //            SetHasWarning();
        //        }
        //    }
        //}

        private void ValidateRequestedAndExpiryDateTimes(DateTime nowInFortHills)
        {
            var requestedDateTime = adapter.RequestedStartDateTime;
            var expiryDateTime = adapter.ExpiryDateTime;

            if (requestedDateTime > expiryDateTime)
            {
                adapter.ActionForStartDateTimeNotBeforeEndDateTime();
                SetHasError();
            }

            if (expiryDateTime < nowInFortHills)
            {
                adapter.ActionForExpiryDateTimeInThePast();
                SetHasError();
            }
        }
    }
}