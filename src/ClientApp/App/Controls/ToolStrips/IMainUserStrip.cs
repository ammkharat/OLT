using System.Windows.Forms;
namespace Com.Suncor.Olt.Client.Controls.ToolStrips
{
    public interface IMainUserStrip
    {
        string FullName { set; }
        string Shift { set; }
        string Site { set; }
        string Role { set; }
        string WorkAssignment { set; }

        bool CreateActionItemVisible { set; }
        bool CreateTargetVisible { set; }
        bool CreateRestrictionVisible { set; }
        bool CreateShiftHandoverQuestionnaireVisible { set; }
        bool CreatePermitVisible { set; }
        bool CreateLabAlertVisible { set; }
        bool CreatePermitRequestVisible { set; }
        bool CreateNewItemEnabled { set; }
        bool CreateConfinedSpaceVisible { set; }
        bool CreateDirectiveVisible { set; }
        bool ChangePermitFLOCButtonVisible { set; }
        bool ChangeRestrictionFLOCButtonVisible { set; }
        bool ChangeSiteEnabled { set; } //RITM0386914 : OLT users to switch from one site to another - Added By Vibhor
        string SetShiftLogMenuItemName { set; } //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        string SetShiftSummaryLogMenuItemName { set; } //RITM0443261 : Added by Amit {Change the name for Shift Summary log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}

        bool CreateGenericCsdItemVisible { set; } // DMND0011225 CSD for WBR


        void CreateLogVisible(
            bool createShiftLogVisible,
            bool createShiftSummaryLogVisible,
            bool createDailyDirectivesVisible,
            bool createCokerCardVisible,
            bool createLogDefinitionVisible,
            bool createStandingOrdersVisible);

        
        //ayman sarnia - ayman selc - ayman forthills - ayman E&U - ayman forthills questionnaire
        void CreateFormsVisible(bool createGN7Visible,bool createSarniaFormsVisible, bool createSelcCSDFormVisible,bool createForthillsTrainingVisible , bool createOilsandsTrainingVisible,
            bool createEdmontonOvertimeFormsVisible, bool createLubesCsdFormVisible, bool createMontrealCsdAuthorized,
            bool createLubesAlarmDisableAuthorized, bool createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized,
            bool createFormDocumentSuggestionAuthorized,
            bool createFormProcedureDeviationAuthorized, bool createSiteWideTrainingVisible, bool createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized
            ,bool createETFTrainingVisible //mangesh  ETF
		    ,bool createMudsTemporaryInstallationsAuthorized, //RITM0268131 - mangesh
            bool createFortHillOilSampleFormAuthorized, bool createFortHillDailyInspectionFormAuthorized, //RITM0341710 - mangesh
             bool createGenericCsdAuthorized);

        //generic template - mangesh
        void CreateGenericTemplateFormVisible(bool createEdmontonOdourNoiseFormAuthorized,
            bool createEdmontonDeviationFormAuthorized, bool createEdmontonRoadClosureFormAuthorized,
            bool createEdmontonGN11GroundDistrubanceFormAuthorized, bool createEdmontonGN27FreezePlugFormAuthorized,
            bool createEdmontonHazardAssessmentFormAuthorized,
            bool createEdmontonNonEmergencyWaterSystemApproval); // TASK0593631 - mangesh


        //ayman Sarnia eip DMND0008992
        void CreateEipIssueVisible(bool createEipIssueAuthorised);

        //Mukesh for Permit search Demand
        AutoCompleteStringCollection AutoSearchPermitNumber { set; }
        bool SetSearchvisible { set; }

    }
}