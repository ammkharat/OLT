using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.XtraPrinting.Export.Pdf;
using DevExpress.XtraRichEdit.Layout;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitEdmontonBusinessLogic
    {
        private readonly IWorkPermitEdmontonView view;

        public bool AllowEventsToOverrideUserSelectedCheckboxes { private get; set; }

        public WorkPermitEdmontonBusinessLogic(IWorkPermitEdmontonView view)
        {
            this.view = view;
        }

        public void ForceExecutionOfBusinessLogic()
        {
            AllowEventsToOverrideUserSelectedCheckboxes = false;

            HandleSpecialWorkTypeChanged();
            HandleConfinedSpaceCheckBoxCheckChanged();
            HandleConfinedSpaceClassChanged();
            HandleContinuousGasMonitorCheckBoxCheckChanged();

            HandleGn75SelectedValueChanged();
            HandlePermitTypeSelectedValueChanged();
            HandleVehicleEntryCheckBoxCheckChanged();
            HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged();

            AllowEventsToOverrideUserSelectedCheckboxes = true;
        }
        public void HandleSpecialWorkTypeChanged()
        {
            //EdmontonPermitSpecialWorkType specialWorkType = view.SpecialWorkType;
            //if (view.SpecialWork && EdmontonPermitSpecialWorkType.DivingOperations.Equals(specialWorkType))
            //{
            //    view.RadioChannelChecked = true;
            //    view.RadioChannelEnabled = false;
            //}
            //else
            //{
            //    if (AllowEventsToOverrideUserSelectedCheckboxes)
            //    {
            //        view.RadioChannelChecked = false;
            //    }

            //    view.RadioChannelEnabled = true;
            //}
            //mangesh for SpecialWork
            if (view.SpecialWork)
            {
                if (view.SpecialWorkName != null)
                {
                    if (view.SpecialWorkName.Equals("Diving Operations"))
                    {
                        view.RadioChannelChecked = true;
                        view.RadioChannelEnabled = false;
                    }
                    else
                    {
                        SetRadioChannelChecked();
                    }
                }
                else
                {
                    SetRadioChannelChecked();
                }
            }
            else
            {
                SetRadioChannelChecked();
            }

            PutSafetyWatchInCorrectState();
            PutBarriersSlashSignsInCorrectState();
            PutContinuousGasMonitorCheckBoxInCorrectState();
            PutGasTestSectionInCorrectState();
            PutWorkersMinimumSafetyRequirementsSectionInCorrectState();
        }

        private void SetRadioChannelChecked()
        {
            if (AllowEventsToOverrideUserSelectedCheckboxes)
            {
                view.RadioChannelChecked = false;
            }
            view.RadioChannelEnabled = true;
        }

        public void HandleRoadAccessOnPermitChanged()
        {
            //EdmontonPermitSpecialWorkType specialWorkType = view.SpecialWorkType;

            //if (view.SpecialWork && EdmontonPermitSpecialWorkType.DivingOperations.Equals(specialWorkType))
            //{
            //    view.RadioChannelChecked = true;
            //    view.RadioChannelEnabled = false;
            //}
            //else
            //{
            //    if (AllowEventsToOverrideUserSelectedCheckboxes)
            //    {
            //        view.RadioChannelChecked = false;
            //    }

            //    view.RadioChannelEnabled = true;
            //}
        }

        private void PutSafetyWatchInCorrectState()
        {
            EdmontonPermitSpecialWorkType specialWorkType = view.SpecialWorkType;

            if ((view.SpecialWork && EdmontonPermitSpecialWorkType.DivingOperations.ToString().Equals(view.SpecialWorkName)) || view.ConfinedSpace)  //mangesh - Special Work
            {
                view.SafetyWatch = true;
                view.SafetyWatchEnabled = false;
            }
            else
            {
                if (AllowEventsToOverrideUserSelectedCheckboxes)
                {
                    view.SafetyWatch = false;
                }
                view.SafetyWatchEnabled = true;
            }

            PutWorkersMinimumSafetyRequirementsSectionInCorrectState();
        }

        private void PutBarriersSlashSignsInCorrectState()
        {
            EdmontonPermitSpecialWorkType specialWorkType = view.SpecialWorkType;

            if ((view.SpecialWork && EdmontonPermitSpecialWorkType.Excavation.ToString().Equals(view.SpecialWorkName)) || view.ConfinedSpace) //mangesh - Special Work
            {
                view.BarriersSigns = true;
                view.BarriersSignsEnabled = false;
            }
            else
            {
                if (AllowEventsToOverrideUserSelectedCheckboxes)
                {
                    view.BarriersSigns = false;
                }

                view.BarriersSignsEnabled = true;
            }

            PutWorkersMinimumSafetyRequirementsSectionInCorrectState();
        }

        private void PutContinuousGasMonitorCheckBoxInCorrectState()
        {
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Normal Hot- 15-Oct-2018 start
            WorkPermitEdmontonType selectedPermitType = view.WorkPermitType;
            //if (ContinuousGasMonitorCheckBoxMustBeCheckedAndDisabled())
            //Added selectedPermitType!=null  condition to fix mergr issue for INC0370129
            if (selectedPermitType!=null && WorkPermitEdmontonType.HOT_WORK.Equals(selectedPermitType) || WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK.Equals(selectedPermitType))
            {
                /// dharmesh on 03-Dec-2018 _start INC0360166 added clone and edit condition 
                bool isEdit = view.IsEdit;
                bool isClone = view.IsClone;
                if (isClone != true && isEdit != true)
                {
                    //view.ContinuousGasMonitor = true;
                    //view.ContinuousGasMonitorEnabled = false;
                    view.ContinuousGasMonitor = false;
                    view.ContinuousGasMonitorEnabled = true;
                    view.WorkersMonitor = false;
                    view.WorkersMonitorEnabled = true;
                    view.BumpTestMonitorPriorToUse = false;
                    view.BumpTestMonitorPriorToUseEnabled = true;
                    if (WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK.Equals(selectedPermitType))
                    {
                        view.WorkersMonitor = true;
                        view.WorkersMonitorEnabled = false;
                        view.BumpTestMonitorPriorToUse = true;
                        view.BumpTestMonitorPriorToUseEnabled = false;
                    }
                    //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Normal Hot- 15-Oct-2018 end
                }
            }
            else
            {
                if (AllowEventsToOverrideUserSelectedCheckboxes)
                {
                    view.ContinuousGasMonitor = false;
                }
                view.ContinuousGasMonitorEnabled = true;
            }

            PutWorkersMinimumSafetyRequirementsSectionInCorrectState();
        }

        /// <summary>
        /// Mingle # 4001 Created on: April 4, 2016 by mangesh
        /// Update for Mingle # 4004 on April 5
        /// </summary>

        [Obsolete("EnableDisable() is deprecated, and logics are moved to PutContinuousGasMonitorCheckBoxInCorrectState() and PutWorkersMinimumSafetyRequirementsSectionInCorrectState() instead.pls refer the same.")]
        private void EnableDisable()
        {

            WorkPermitEdmontonType selectedPermitType = view.WorkPermitType;
            // Mingle # 4001 start //           
            if (selectedPermitType != null && (selectedPermitType.Equals(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK) || selectedPermitType.Equals(WorkPermitEdmontonType.HOT_WORK)))   //ayman work permit RITM0232335  Dharmesh
            {
                //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Normal Hot- 15-Oct-2018 start
                //if (view.Group != null && view.Group.IsTurnaround)
                //{
                //    view.ContinuousGasMonitorEnabled = true; 
                //    view.ContinuousGasMonitorChecked = false;
                //}
                //else
                //{
                //    view.ContinuousGasMonitorEnabled = false;
                //    view.ContinuousGasMonitorChecked = true;
                //}
                
                ///Comment by dharmesh on 03-Dec-2018 _start INC0360166
                //view.ContinuousGasMonitorEnabled = true;  
                //view.ContinuousGasMonitorChecked = false;
                ///Comment by dharmesh on 03-Dec-2018 _End 
                
                //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Normal Hot- 15-Oct-2018 End

            }
            // Mingle # 4001 End //


            // Mingle # 4004 Start // start to End of Mingle #4004  has commented by Dharmesh
            //commented for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh

            //if (selectedPermitType != null && selectedPermitType.Equals(WorkPermitEdmontonType.ROUTINE_MAINTENANCE))
            //{
            //    view.ConfinedSpaceCardNumber = string.Empty;
            //    view.ConfinedSpaceCheckBoxEnabled = false;
            //    view.ConfinedSpace = false;
            //    view.ConfinedSpaceClassEnabled = false;
            //    view.ConfinedSpaceWorkSectionNotApplicableToJob = true;
            //    view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = false;
            //}
            //else
            //{
            //    view.ConfinedSpaceCheckBoxEnabled = true;
            //    view.ConfinedSpaceWorkSectionNotApplicableToJob = false;
            //    view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = true;
            //}
            // Mingle # 4004 End //
            //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s
            EnableDisableConfinedSpace();
            //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_e
        }

        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s
        private void EnableDisableConfinedSpace()
        {
            WorkPermitEdmontonType selectedPermitType = view.WorkPermitType;
            bool isEdit = view.IsEdit;
            bool isClone = view.IsClone;
            if (isClone == false && isEdit == false)
            { //for New Create
                if (selectedPermitType != null && selectedPermitType.Equals(WorkPermitEdmontonType.ROUTINE_MAINTENANCE))
                {
                    view.ConfinedSpaceCardNumber = string.Empty;
                    view.ConfinedSpaceCheckBoxEnabled = false;
                    view.ConfinedSpace = false;
                    view.ConfinedSpaceClassEnabled = false;
                    view.ConfinedSpaceWorkSectionNotApplicableToJob = true;
                    view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = false;
                }
                else
                {
                    view.ConfinedSpaceCheckBoxEnabled = true;
                    view.ConfinedSpaceWorkSectionNotApplicableToJob = false;
                    view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = true;
                }
            }
            else
            { //for Clone or Edit 
                if (selectedPermitType != null && selectedPermitType.Equals(WorkPermitEdmontonType.ROUTINE_MAINTENANCE))
                {
                    view.ConfinedSpaceCardNumber = string.Empty;
                    view.ConfinedSpaceCheckBoxEnabled = false;
                    view.ConfinedSpace = false;
                    view.ConfinedSpaceClassEnabled = false;
                    view.ConfinedSpaceWorkSectionNotApplicableToJob = true;
                    view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = false;
                }
                else
                {
                    view.ConfinedSpaceCheckBoxEnabled = true;
                    view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = true;
                }
            }


        }
        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_e

        private void PutGasTestSectionInCorrectState()
        {
            WorkPermitEdmontonType selectedPermitType = view.WorkPermitType;
            EdmontonPermitSpecialWorkType specialWorkType = view.SpecialWorkType;
            if (WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK.Equals(selectedPermitType) ||
                view.VehicleEntry ||
                (view.SpecialWork && (view.SpecialWork && EdmontonPermitSpecialWorkType.PowderActuatedTool.ToString().Equals(view.SpecialWorkName)) || //mangesh- specialwork
                view.ConfinedSpace))
            {
                view.GasTestsSectionNotApplicableToJob = false;

                if (view.Group != null && view.Group.IsTurnaround && !view.VehicleEntry && !view.ConfinedSpace) //Mingle # 4001, Changed on April 4,2016 Mangesh
                {
                    view.GasTestsSectionNotApplicableToJobEnabled = true;
                }
                else
                {
                    view.GasTestsSectionNotApplicableToJobEnabled = false;
                }
            }
            else
            {
                if (AllowEventsToOverrideUserSelectedCheckboxes)
                {
                    view.GasTestsSectionNotApplicableToJob = false;
                }
                view.GasTestsSectionNotApplicableToJobEnabled = true;
            }

            if (view.ConfinedSpace || view.SpecialWork || WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK.Equals(selectedPermitType) || WorkPermitEdmontonType.COLD_WORK.Equals(selectedPermitType))
            {
                //Dharmesh DMND0009363-OLT - Edmonton Enhancements 2018DMND0009363-OLT - Edmonton Enhancements 2018 - #950321829 11-Sep-2018 start
                if (WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK.Equals(selectedPermitType))
                    view.WorkerToProvideGasTestData = false;

                //view.WorkerToProvideGasTestDataEnabled = false;
                view.WorkerToProvideGasTestDataEnabled = WorkPermitEdmontonType.COLD_WORK.Equals(selectedPermitType) ? true : false;
                //Dharmesh DMND0009363-OLT - Edmonton Enhancements 2018DMND0009363-OLT - Edmonton Enhancements 2018 - #950321829 11-Sep-2018 end

                if (StringResources.WorkerToProvideGasTest.Equals(view.OperatorGasDetectorNumber))
                {
                    view.OperatorGasDetectorNumber = null;
                }
            }
            else
            {
                view.WorkerToProvideGasTestDataEnabled = true;
            }
        }

        private void PutWorkersMinimumSafetyRequirementsSectionInCorrectState()
        {
            EdmontonPermitSpecialWorkType specialWorkType = view.SpecialWorkType;

            bool confinedSpaceCheckBoxIsChecked = view.ConfinedSpace;
            string confinedSpaceClass = view.ConfinedSpaceClass;

            if ((confinedSpaceCheckBoxIsChecked && WorkPermitEdmonton.ConfinedSpaceLevel1.Equals(confinedSpaceClass)) ||
                (view.SpecialWork && EdmontonPermitSpecialWorkType.DivingOperations.ToString().Equals(view.SpecialWorkName)) ||  //mangesh - specialwork
                (view.SpecialWork && EdmontonPermitSpecialWorkType.Excavation.ToString().Equals(view.SpecialWorkName)) ||
                ContinuousGasMonitorCheckBoxMustBeCheckedAndDisabled() ||
                confinedSpaceCheckBoxIsChecked)
            {
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled = false;
            }
            else
            {
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled = true;
            }
            //Start Minlge Story #4002, Change By : Swapnil, Changed On : 30 Mar 2016
            if (confinedSpaceCheckBoxIsChecked && confinedSpaceClass == "3")
            {
                view.oltlabel43 = "4. Does Permit Issuer or Acceptor require Knowledge Operations representative at Part II meeting (mandatory for Initial Entry Permit - Level 1 and Level 2 ONLY)?";
            }
            else
            {
                view.oltlabel43 = "4. Does Permit Issuer or Acceptor require Knowledge Operations representative at Part II meeting (mandatory for Initial Entry Permit)?";
            }
            //End Minlge Story #4002, Change By : Swapnil, Changed On : 30 Mar 2016
        }

        private bool ContinuousGasMonitorCheckBoxMustBeCheckedAndDisabled()
        {
            WorkPermitEdmontonType selectedPermitType = view.WorkPermitType;

            bool specialWorkChecked = view.SpecialWork;
            bool permitTypeRequiresContinuousGasMonitor = (WorkPermitEdmontonType.HOT_WORK.Equals(selectedPermitType) || WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK.Equals(selectedPermitType));
            bool specialWorkTypeRequiresContinuousGasMonitor = specialWorkChecked && ContinuousGasMonitorIsRequired(view.SpecialWorkName); //mangesh - SpecialWork
            return (permitTypeRequiresContinuousGasMonitor || specialWorkTypeRequiresContinuousGasMonitor);

        }

        //mangesh- added new function
        private bool ContinuousGasMonitorIsRequired(string value)
        {
            return EdmontonPermitSpecialWorkType.HotTapping.ToString().Equals(value) || EdmontonPermitSpecialWorkType.PowderActuatedTool.ToString().Equals(value) ||
                EdmontonPermitSpecialWorkType.OnstreamLeakSealing.ToString().Equals(value) ||
                   EdmontonPermitSpecialWorkType.HighVoltageElectricalWork.ToString().Equals(value);
        }

        public void HandleVehicleEntryCheckBoxCheckChanged()
        {
            PutGasTestSectionInCorrectState();
        }

        public void HandleContinuousGasMonitorCheckBoxCheckChanged()
        {
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Hot- 15-Oct-2018 start
            WorkPermitEdmontonType selectedPermitType = view.WorkPermitType;
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Hot- 15-Oct-2018 end
            /// dharmesh on 03-Dec-2018 _start INC0360166 added clone and edit condition 
            bool isEdit = view.IsEdit;
            bool isClone = view.IsClone;

            if (isClone != true && isEdit != true && selectedPermitType!=null)
            {
                if (view.ContinuousGasMonitor)
                {
                    //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Hot- 15-Oct-2018 start
                    //29-Oct-2018

                    if (selectedPermitType.Equals(WorkPermitEdmontonType.HOT_WORK))
                    {
                        view.WorkersMonitor = true;
                        view.WorkersMonitorEnabled = true;
                        view.BumpTestMonitorPriorToUse = true;
                        view.BumpTestMonitorPriorToUseEnabled = true;
                    }

                    //29-Oct-2018
                    if (!selectedPermitType.Equals(WorkPermitEdmontonType.HOT_WORK))
                    {
                        view.WorkersMonitor = true;
                        view.WorkersMonitorEnabled = false;
                        view.BumpTestMonitorPriorToUse = true;
                        view.BumpTestMonitorPriorToUseEnabled = false;
                    }
                    //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Hot- 15-Oct-2018 end
                }
                else
                {
                    //Mingle # 4001,  Added If condition on April 1, 2016 by mangesh
                    //WorkPermitEdmontonType selectedPermitType = view.WorkPermitType; //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Hot- 15-Oct-2018 start
                    if (selectedPermitType != null &&
                        !selectedPermitType.Equals(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK))
                    {
                        if (AllowEventsToOverrideUserSelectedCheckboxes)
                        {
                            view.WorkersMonitor = false;
                            view.BumpTestMonitorPriorToUse = false;
                        }

                        view.WorkersMonitorEnabled = true;
                        view.BumpTestMonitorPriorToUseEnabled = true;
                    }
                    else
                    {
                        if (selectedPermitType != null &&
                            selectedPermitType.Equals(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK))
                        {
                            view.WorkersMonitorEnabled = false;
                            view.BumpTestMonitorPriorToUseEnabled = false;
                        }
                    }
                }
            }
            PutWorkersMinimumSafetyRequirementsSectionInCorrectState();

        }

        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - unique and special circumstances - 29-Oct-2018 start
        public void HandleworkersMonitorNumberCheckBoxCheckChanged()
        {
            WorkPermitEdmontonType selectedPermitType = view.WorkPermitType;
            //Added selectedPermitType!=null  condition to fix mergr issue for INC0370129
            if (selectedPermitType != null && view.WorkersMonitor)
            {
                if (selectedPermitType.Equals(WorkPermitEdmontonType.HOT_WORK))
                {
                    view.BumpTestMonitorPriorToUse = true;
                    view.BumpTestMonitorPriorToUseEnabled = true;
                }
                if (!selectedPermitType.Equals(WorkPermitEdmontonType.HOT_WORK))
                {
                    view.BumpTestMonitorPriorToUse = true;
                    view.BumpTestMonitorPriorToUseEnabled = false;
                }
            }
            else
            {
                //Added selectedPermitType!=null  condition to fix mergr issue for INC0370129
                if (selectedPermitType != null && !selectedPermitType.Equals(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK))
                {
                    if (AllowEventsToOverrideUserSelectedCheckboxes)
                    {
                        view.BumpTestMonitorPriorToUse = false;
                    }
                    view.BumpTestMonitorPriorToUseEnabled = true;
                }
                else
                {
                    if (selectedPermitType != null && selectedPermitType.Equals(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK))
                    {
                        view.BumpTestMonitorPriorToUseEnabled = false;
                    }
                }
                /// dharmesh on 03-Dec-2018 _start INC0360166  
                view.WorkersMonitorNumber = null;
                /// dharmesh on 03-Dec-2018 _end INC0360166  
            }
        }
        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - unique and special circumstances - 29-Oct-2018 end

        public void HandleConfinedSpaceCheckBoxCheckChanged()
        {
            if (view.ConfinedSpace)
            {
                view.ConfinedSpaceWorkSectionNotApplicableToJob = false;
                view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = false;

                view.AirHorn = true;
                view.AirHornEnabled = false;
            }
            else
            {
                view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = true;

                if (AllowEventsToOverrideUserSelectedCheckboxes)
                {
                    view.AirHorn = false;
                }
                view.AirHornEnabled = true;
            }

            HandleConfinedSpaceClassChanged();  // because unchecking confined space is effectively like changing the class
            PutSafetyWatchInCorrectState();
            PutBarriersSlashSignsInCorrectState();
            PutWorkersMinimumSafetyRequirementsSectionInCorrectState();
            PutGasTestSectionInCorrectState();
        }



        public void HandleConfinedSpaceClassChanged()
        {
            bool confinedSpaceCheckBoxIsChecked = view.ConfinedSpace;
            string confinedSpaceClass = view.ConfinedSpaceClass;

            if (confinedSpaceCheckBoxIsChecked && WorkPermitEdmonton.ConfinedSpaceLevel1.Equals(confinedSpaceClass))
            {
                view.BreathingAirApparatus = true;
                view.BreathingAirApparatusEnabled = false;
            }
            else
            {
                if (AllowEventsToOverrideUserSelectedCheckboxes)
                {
                    view.BreathingAirApparatus = false;
                }
                view.BreathingAirApparatusEnabled = true;
            }

            if (confinedSpaceCheckBoxIsChecked && (WorkPermitEdmonton.ConfinedSpaceLevel1.Equals(confinedSpaceClass) || WorkPermitEdmonton.ConfinedSpaceLevel2.Equals(confinedSpaceClass)))
            {
                view.RescuePlan = true;
                view.RescuePlanEnabled = false;
            }
            else if (confinedSpaceCheckBoxIsChecked && WorkPermitEdmonton.ConfinedSpaceLevel3.Equals(confinedSpaceClass))
            {
                view.RescuePlan = false;
                view.RescuePlanFormNumber = null;
                view.RescuePlanEnabled = false;
            }
            else
            {
                if (AllowEventsToOverrideUserSelectedCheckboxes && confinedSpaceClass != null)
                {
                    view.RescuePlan = false;
                }
                view.RescuePlanEnabled = true;
            }

            PutWorkersMinimumSafetyRequirementsSectionInCorrectState();
        }

        public void HandlePermitTypeSelectedValueChanged()
        {
            PutGasTestSectionInCorrectState();
            PutContinuousGasMonitorCheckBoxInCorrectState();
            EnableDisable(); //Mingle # 4001, added on April 4,2016 by mangesh
        }

        public void HandleGn75SelectedValueChanged()
        {
            bool gn75ASelected = view.GN75A;

            if (gn75ASelected)
            {
                view.StatusOfPipingEquipmentSectionNotApplicableToJob = false;
                view.StatusOfPipingEquipmentSectionNotApplicableToJobEnabled = false;
            }
            else
            {
                view.StatusOfPipingEquipmentSectionNotApplicableToJobEnabled = true;
            }
        }

        public void HandleWorkersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBoxCheckChanged()
        {
            if (!view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob)
            {
                ForceExecutionOfBusinessLogic();
            }


        }

        public void HandleGasTestsSectionNotApplicableToJobCheckBoxCheckChanged()
        {
            if (!view.GasTestsSectionNotApplicableToJob)
            {
                PutGasTestSectionInCorrectState();
            }
        }

        public void HandleStatusOfPipingEquipmentNotApplicabletoJobCheckBoxCheckChanged(bool thereIsAlreadyAPermitNumber)
        {

            if (!view.StatusOfPipingEquipmentSectionNotApplicableToJob)
            {
                HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged();
            }
        }

        public void HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged()
        {
            if (view.UseCurrentPermitNumberForZeroEnergyFormNumber)
            {
                if (view.PermitNumber.IsNullOrEmptyOrWhitespace())
                {
                    view.ZeroEnergyFormNumber = string.Empty;
                }
                else
                {
                    view.ZeroEnergyFormNumber = view.PermitNumber;
                }

                view.ZeroEnergyFormNumberEnabled = false;
            }
            else
            {
                view.ZeroEnergyFormNumberEnabled = true;
            }
        }
    }
}
