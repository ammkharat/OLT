using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class WorkPermitFormSiteSpecificEventHandler
    {
        public static WorkPermitFormSiteSpecificEventHandler Create(IWorkPermitFormView view)
        {
            if (view is IWorkPermitFormViewSarnia)
            {
                return new WorkPermitFormEventHandlerSarnia(view as IWorkPermitFormViewSarnia);
            }
            if (view is IWorkPermitFormViewDenver)
            {
                return new WorkPermitFormEventHandlerDenver(view as IWorkPermitFormViewDenver);
            }
            //ayman USPipeline workpermit
            if (view is IWorkPermitFormViewUSPipeline)
            {
                return new WorkPermitFormEventHandlerUSPipeline(view as IWorkPermitFormViewUSPipeline);
            }
            throw new Exception("Unexpected request to create WorkPermitViewHandler for view " + view.GetType());
        }
        public virtual void HandleBurnOpenFlameCheckChanged(){}
        public virtual void HandlePermitTypeHotCheckChanged(){}
        public virtual void HandleVehicleEntryCheckChanged(){}
        public virtual void HandleSpecialPPEClothingTypeAcidCheckChanged(){}
        public virtual void HandleStartDateValueChanged() {}
        public virtual void HandleExcavationCheckChanged() {}
        public virtual void HandleConfinedSpaceEntryCheckChanged() {}

        //RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        public virtual void HandleRadiationRadiographyCheckChanged() { } 
        public virtual void HandleVestedBuddySystemInEffectYesRadioButtonCheckChanged() { } 
        public virtual void HandleequipmentIsHazardousEnergyIsolationRequiredYesRadioButtonCheckChanged() { } 
        public virtual void HandleequipmentIsHazardousEnergyIsolationRequiredNoRadioButtonCheckChanged() { } 
        public virtual void HandleasbestosHazardsConsideredNACheckBoxCheckChanged() { } 
        public virtual void HandlefreshAirCheckBoxCheckChanged() { } 
        public virtual void HandleAsbestosHazardsConsideredYesRadioButtonCheckChanged() { } 
        public virtual void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButtonCheckChanged() { } 
        public virtual void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBoxCheckChanged() { } 
        public virtual void HandleasbestosHazardsConsideredNoRadioButtonChanged() { } 
        public virtual void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButtonCheckChanged() { } 

        //END

        //DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
        
        public virtual void HandleequipmentLockOutMethodIndividualByOperationsRadioButtonCheckChanged() { }

        //END

        
        
        

        public virtual void HandleFunctionalLocationChanged(
                FunctionalLocation functionalLocation, 
                List<WorkAssignment> sourceWorkAssignments, 
                IFunctionalLocationService flocService, 
                IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfigurationService) { }
        public virtual void HandleAdditionalElectricalCheckChanged() {}
        public virtual void HandleEquipmentLockOutMethodComplexGroupCheckChanged() {}
    }

    public class WorkPermitFormEventHandlerSarnia : WorkPermitFormSiteSpecificEventHandler
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WorkPermitFormEventHandlerSarnia));

        private readonly IWorkPermitFormViewSarnia view;

        internal WorkPermitFormEventHandlerSarnia(IWorkPermitFormViewSarnia view)
        {
            this.view = view;
        }

        public override void HandleBurnOpenFlameCheckChanged()
        {
            if (view.IsBurnOrOpenFlame)
            {
                view.AdditionalIsBurnOrOpenFlameAssessment = true;
                // Check HOT Work Permit Type
                view.WorkPermitType = WorkPermitType.HOT;
                // Check Sewers and 20#
                SetFieldsForHotWorkPermit();
                // Check Spark Containment
                view.FireIsFireResistantTarpOrFireIsSparkContainment = true;
                // Check Vested Watchman
                view.FireIsWatchmen = true;

                view.JobWorksiteIsWeldingGroundWireInTestAreaNotApplicable = false;
                view.JobWorksiteIsWeldingGroundWireInTestArea = true;

                // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                {
                    view.GasTestsConstantMonitoringRequired = true;
                }
                //END
            }
            else
            {
                view.JobWorksiteIsWeldingGroundWireInTestAreaNotApplicable = true;
            }
        }

        public override void HandlePermitTypeHotCheckChanged()
        {
            if (view.WorkPermitType == WorkPermitType.HOT)
            {
                SetFieldsForHotWorkPermit();
            }
        }

        public override void HandleVehicleEntryCheckChanged()
        {
            if (view.IsVehicleEntry)
            {
                view.WorkPermitType = WorkPermitType.HOT;  // This in turn, generates an event.

                SetFieldsForHotWorkPermit();
            }
        }

        private void SetFieldsForHotWorkPermit()
        {
            view.FireIsNotApplicable = false;
            view.FireIsTwentyABCorDryChemicalExtinguisher = true;

            view.JobWorksiteIsSewerIsolationMethodNotApplicable = false;
            view.JobWorksiteIsSewerIsolationMethodSealedOrCovered = true;
        }

        public override void HandleStartDateValueChanged()
        {
            if (view.StartDateTime.Date == Clock.Now.Date)
            {
                view.StartDateTime = Clock.Now.BuildDateTimeWithNoSecondsOrMilliseconds();
            }
            else
            {
                UserShift currentShift = ClientSession.GetUserContext().UserShift;
                if (currentShift != null)
                {
                    Range<DateTime> dateTimeRange =
                        ClientSession.GetUserContext().User.WorkPermitDefaultTimePreferences.DefaultDateTimeRange(currentShift);
                    view.StartTime = dateTimeRange.LowerBound;
                }
            }
        }

        public override void HandleExcavationCheckChanged()
        {
            if (view.IsExcavation)
            {
                view.AdditionalIsExcavation = true;
            }            
        }

        public override void HandleConfinedSpaceEntryCheckChanged()
        {
           if (view.IsConfinedSpaceEntry)
           {
               view.FireIsNotApplicable = false;
               view.FireIsWatchmen = true;

               view.AdditionalIsCSEAssessmentOrAuthorization = true;

               // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
               if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
               {
                   view.GasTestsConstantMonitoringRequired = true;
               }
               //END
           }
        }

        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        public override void HandleRadiationRadiographyCheckChanged()
        {
            if (view.IsRadiationRadiography && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                view.JobWorksiteIsAreaPreparationBoundaryRopeTape = true; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                // Check HOT Work Permit Type
                view.WorkPermitType = WorkPermitType.HOT;

                //view.ControlRoomsHasBeenContactedGroupBox = true;
                view.JobWorksiteIsControlRoomContactedNotApplicable = false;
                view.ControlRoomContactedYes = false;
                view.ControlRoomContactedNo = false;
                if (view.JobWorksiteIsAreaPreparationNotApplicable == true)
                {
                    view.JobWorksiteIsAreaPreparationNotApplicable = false;
                }
            }
            else
            {
                view.JobWorksiteIsAreaPreparationBoundaryRopeTape = false; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                view.JobWorksiteIsControlRoomContactedNotApplicable = true;
            }
        }
        public override void HandleVestedBuddySystemInEffectYesRadioButtonCheckChanged()
        {
            if (view.JobWorksiteIsVestedBuddySystemInEffect.GetValueOrDefault() && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                view.CommunicationMethodByRadio = true; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                if (view.CommunicationMethodIsWorkPermitCommunicationNotApplicable == true)
                {
                    view.CommunicationMethodIsWorkPermitCommunicationNotApplicable = false;
                }
            }
        }

        public override void HandleequipmentIsHazardousEnergyIsolationRequiredYesRadioButtonCheckChanged()
        {
            if (view.EquipmentIsHazardousEnergyIsolationRequired.GetValueOrDefault() && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                //view.JobWorksiteIsPermitReceiverFieldOrEquipmentOrientation = false; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                view.JobWorksiteIsPermitReceiverFieldOrEquipmentOrientationNotApplicable = false;
            }
        }

        public override void HandleequipmentIsHazardousEnergyIsolationRequiredNoRadioButtonCheckChanged()
        {

            if (view.EquipmentLockOutMethodIndividualByOperationsRadioButtonChecked == true &&
                view.JobWorksiteIsPermitReceiverFieldNObutton == true &&
                ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                view.EquipmentLockOutMethodIndividualByWorkerRadioButtonChecked = false;
                view.EquipmentLockOutMethodIndividualByOperationsRadioButtonChecked = false;
                view.EquipmentLockOutMethodComplexGroupRadioButtonChecked = false;
                
            }
            if (view.EquipmentLockOutMethodComplexGroupRadioButtonChecked == true &&
                view.JobWorksiteIsPermitReceiverFieldNObutton == true &&
                ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                view.EquipmentLockOutMethodIndividualByWorkerRadioButtonChecked = false;
                view.EquipmentLockOutMethodIndividualByOperationsRadioButtonChecked = false;
                view.EquipmentLockOutMethodComplexGroupRadioButtonChecked = false;
            }
  //DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
            if (view.EquipmentLockOutMethodIndividualByOperationsRadioButtonChecked == true &&
                view.JobWorksiteIsPermitReceiverFieldOrEquipmentOrientationNotApplicable == true &&
                view.JobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButtonChecked == true &&
                ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                view.EquipmentLockOutMethodIndividualByWorkerRadioButtonChecked = false;
                view.EquipmentLockOutMethodIndividualByOperationsRadioButtonChecked = false;
                view.EquipmentLockOutMethodComplexGroupRadioButtonChecked = false;
            }
                
           
        }
        public override void HandleasbestosHazardsConsideredNACheckBoxCheckChanged()
        {
            //if (view.AsbestosHazardsConsideredNotApplicable == true &&
            //    view.AsbestosHazardsConsideredYesRadioButtonChecked &&
            //    ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            //{
            //    view.CommentsRequiredForAsbestosHazardImageLabelVisible = false;
            //    view.IsAsbestosHazardPanel = false;
            //}
            //else
            //{
            //    view.CommentsRequiredForAsbestosHazardImageLabelVisible = true;
            //    view.IsAsbestosHazardPanel = true;
            //    if (view.AsbestosHazardsConsidered == null || view.AsbestosHazardsConsidered == false)
            //    {
            //        view.IsAsbestosHazardPanel = false;
            //        view.CommentsRequiredForAsbestosHazardImageLabelVisible = false;
            //    }
            //}
            //if (view.AsbestosHazardsConsideredNotApplicable == true &&
            //   !view.AsbestosHazardsConsideredYesRadioButtonChecked &&
            //   ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            //{
            //    view.CommentsRequiredForAsbestosHazardImageLabelVisible = false;

            //}
        }
        public override void HandlefreshAirCheckBoxCheckChanged()
        {
            if (view.IsFreshAir && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                view.RespiratoryIsNotApplicableEnableDisable = false;
                if (view.RespiratoryIsNotApplicable == true)
                {
                    view.RespiratoryIsNotApplicable = false;
                }
            }
            else
            {
                view.RespiratoryIsNotApplicableEnableDisable = true;
            }
        }
        public override void HandleAsbestosHazardsConsideredYesRadioButtonCheckChanged()
        {

            //if (view.AsbestosHazardsConsidered.GetValueOrDefault() && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            //{
            //    view.IsAsbestosHazardPanel = true; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            //}
        }
        public override void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButtonCheckChanged()
        {

        }
        public override void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBoxCheckChanged()
        {
            if (view.IsHazardousEnergyIsolationChecked==true && view.EquipmentLockOutMethodComplexGroupRadioButtonChecked == true)
            {
                view.CommentsRequiredForHazardousEneryImageLabelEnableDisable = true;
            }
            if (view.IsHazardousEnergyIsolationChecked == true && view.EquipmentLockOutMethodIndividualByOperationsRadioButtonChecked == true)
            {
                view.CommentsRequiredForHazardousEneryImageLabelEnableDisable = true;
            }
            
        }
        public override void HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButtonCheckChanged()
        {
            
        }
        
        

        //END


        public override void HandleFunctionalLocationChanged(
            FunctionalLocation functionalLocation, 
            List<WorkAssignment> sourceWorkAssignments, 
            IFunctionalLocationService flocService,
            IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfigurationService)
        {
            if (functionalLocation == null)
            {
                return;
            }
                        
            long? assignmentId =
                workPermitAutoAssignmentConfigurationService.GetWorkAssignmentIdForFunctionalLocation(
                    functionalLocation, ClientSession.GetUserContext().SiteId);

            if (assignmentId == null)
            {
                view.WorkAssignment = WorkAssignment.NoneWorkAssignment;
            }
            else
            {
                WorkAssignment assignment = sourceWorkAssignments.FindById(assignmentId);

                if (assignment == null)
                {
                    logger.Error("No work assignment was returned when one was expected. This is an exceptional error.");
                    view.WorkAssignment = WorkAssignment.NoneWorkAssignment;
                }

                view.WorkAssignment = assignment;
            }           
        }

        public override void HandleAdditionalElectricalCheckChanged()
        {
            string text = String.Format("If this Safe Work Permit references an Electrical Hazard Assessment, the people identified on the EHA, and the Permit Receiver, are accountable for ensuring hazards are identified and controlled.{0}The Safe Work Permit issuer is only verifying that the area in which electrical work is occurring is safe from process related hazards at the time of issuing the permit and that they are aware that there are workers in the area.", Environment.NewLine + Environment.NewLine);

            if (!view.AdditionalIsElectrical)
            {
                RemoveTextFromSpecialPrecautionsOrConsiderations(text);
            }
            else
            {
                AppendTextToSpecialPrecautionsOrConsiderations(text);
            }
        }

        private void RemoveTextFromSpecialPrecautionsOrConsiderations(string text)
        {
            if (!view.SpecialPrecautionsOrConsiderations.IsNullOrEmptyOrWhitespace() && view.SpecialPrecautionsOrConsiderations.Contains(text))                
            {
                int indexOfText = view.SpecialPrecautionsOrConsiderations.IndexOf(text, 0);
                view.SpecialPrecautionsOrConsiderations = view.SpecialPrecautionsOrConsiderations.Remove(indexOfText, text.Length);                                                                                                         
            }
        }

        public override void HandleEquipmentLockOutMethodComplexGroupCheckChanged()
        {
            string text = String.Format("If this Safe Work Permit references an Energy Isolation Plan for an electrical scope of work (non-process based) it is understood that those identified on the Energy Isolation Plan (ie, the Preparer, the Reviewer and Establisher) are accountable for the accuracy and effectiveness of the Energy Isolation Plan.{0}The Safe Work Permit issuer is only verifying that the area in which electrical work is occurring is safe from process related hazards at the time of issuing the permit and that they are aware that there are workers in the area.", Environment.NewLine + Environment.NewLine);

            if (!WorkPermitLockOutMethodType.COMPLEX_GROUP.Equals(view.EquipmentLockOutMethod) || !view.EquipmentLockOutMethodEnabled)
            {
                RemoveTextFromSpecialPrecautionsOrConsiderations(text);
            }
            else
            {
                AppendTextToSpecialPrecautionsOrConsiderations(text);
            }
        }

        // INC0478174 : Added By Vibhor - Changes in work permit for Sarnia 
        
        public override void HandleequipmentLockOutMethodIndividualByOperationsRadioButtonCheckChanged()
        {
            if ( view.IsHazardousEnergyIsolationChecked == true)  
            {
                view.JobWorksiteIsPermitReceiverFieldOrEquipmentOrientation = true;  // DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
                view.JobWorksiteIsPermitReceiverFieldOrEquipmentOrientationNotApplicable = false;
            }
        }

        //END

        private void AppendTextToSpecialPrecautionsOrConsiderations(string text)
        {
            if (view.SpecialPrecautionsOrConsiderations.IsNullOrEmptyOrWhitespace())
            {
                view.SpecialPrecautionsOrConsiderations = text;
            }
            else
            {
                view.SpecialPrecautionsOrConsiderations += (Environment.NewLine + Environment.NewLine + text);
            }
        }
    }

    public class WorkPermitFormEventHandlerDenver : WorkPermitFormSiteSpecificEventHandler
    {
        private readonly IWorkPermitFormViewDenver view;

        internal WorkPermitFormEventHandlerDenver(IWorkPermitFormViewDenver view)
        {
            this.view = view;
        }
    }

    //ayman USPipeline workpermit
    public class WorkPermitFormEventHandlerUSPipeline : WorkPermitFormSiteSpecificEventHandler
    {
        private readonly IWorkPermitFormViewUSPipeline view;

        internal WorkPermitFormEventHandlerUSPipeline(IWorkPermitFormViewUSPipeline view)
        {
            this.view = view;
        }
    }

}



