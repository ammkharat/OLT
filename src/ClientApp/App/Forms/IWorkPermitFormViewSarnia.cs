using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using DevExpress.XtraSpellChecker.Native;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitFormViewSarnia : IWorkPermitFormView
    {
        bool JobWorksiteIsSewerIsolationMethodNotApplicable { set; }
        bool JobWorksiteIsSewerIsolationMethodSealedOrCovered { set; }
        bool JobWorksiteIsWeldingGroundWireInTestAreaNotApplicable { set; }
        bool JobWorksiteIsHazardousEnergyIsolationRequiredNotApplicable { get; set; }             //ayman Sarnia not applicable
        bool JobWorksiteIsAspestosRequiredNotApplicable { get; set; }                                          //ayman Sarnia not applicable
        bool? JobWorksiteIsWeldingGroundWireInTestArea { set; }
        bool FireIsNotApplicable { set; }
        bool FireIsTwentyABCorDryChemicalExtinguisher { set; }
        bool FireIsFireResistantTarpOrFireIsSparkContainment { set; }
        bool FireIsWatchmen { set; }
        DateTime StartDateTime { get; set; }
        DateTime StartTime { set; }
        bool AdditionalIsExcavation { set; }
        bool AdditionalIsCSEAssessmentOrAuthorization { set; }
        bool AdditionalIsBurnOrOpenFlameAssessment { set; }
        string SpecialPrecautionsOrConsiderations { get; set; }
        bool AdditionalIsElectrical { get; }
        WorkPermitLockOutMethodType EquipmentLockOutMethod { get; }
        bool EquipmentLockOutMethodEnabled { get; }

        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        //start

        bool GasTestsConstantMonitoringRequired { set; } 
        bool JobWorksiteIsAreaPreparationBoundaryRopeTape { set; } 
        bool? CommunicationMethodByRadio { set; } 
        bool? JobWorksiteIsVestedBuddySystemInEffect { get; set; } 
        bool? EquipmentIsHazardousEnergyIsolationRequired { get; set; } 
        bool? JobWorksiteIsPermitReceiverFieldOrEquipmentOrientation { get; set; } 
        bool RespiratoryIsAirCartorAirLine { get; set; } 
        bool RespiratoryIsHalfFaceRespirator { get; set; } 
        bool RespiratoryIsDustMask { get; set; } 
        bool RespiratoryIsSCBA { get; set; } 
        bool RespiratoryIsFullFaceRespirator { get; set; } 
        bool RespiratoryIsAirHood { get; set; } 
        bool RespiratoryOtherCheckbox { get; set; } 
        bool RespiratoryIsNotApplicable { get; set; } 
        bool? AsbestosHazardsConsidered { get; set; } 
        bool IsAsbestosHazardPanel { get; set; } 
        
        bool JobWorksiteIsPermitReceiverFieldOrEquipmentOrientationNotApplicable { get; set; } 
        bool JobWorksiteIsPermitReceiverFieldNObutton { get; set; } 
        bool ControlRoomsHasBeenContactedGroupBox { get; set; } 
        bool JobWorksiteIsControlRoomContactedNotApplicable { get; set; } 
        bool JobWorksiteIsAreaPreparationNotApplicable { get; set; } 
        bool IsHazardousEnergyIsolationChecked { get; set; }    
        bool CommunicationMethodIsWorkPermitCommunicationNotApplicable { get; set; }    
        bool CommentsRequiredForAsbestosHazardImageLabelVisible { get; set; }    
        bool CommentsRequiredForHazardousEneryImageLabelVisible { get; set; }    
        bool AsbestosHazardsConsideredNotApplicable { get; set; }    
        bool ControlRoomContactedYes { get; set; }   
        bool ControlRoomContactedNo { get; set; }    
        bool RespiratoryIsNotApplicableEnableDisable { get; set; }    
        bool IsHazardousEnergyIsolationNoChecked { get; set; }  
        bool CommentsRequiredForHazardousEneryImageLabelEnableDisable { get; set; }  

        //END

//DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
        bool EquipmentLockOutMethodComplexGroupRadioButtonChecked { get; set; }
        bool EquipmentLockOutMethodIndividualByOperationsRadioButtonChecked { get; set; }
        bool PermitReceiverRequiresOrientationCommentsPanelVisible { get; set; }
        bool EquipmentLockOutMethodIndividualByWorkerRadioButtonChecked { get; set; }
        bool JobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButtonChecked { get; set; }
        

        //END
        
        
        
        
    }
}
