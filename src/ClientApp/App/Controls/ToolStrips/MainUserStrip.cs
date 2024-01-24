using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using ResourcesResx = Com.Suncor.Olt.Client.Properties.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.Page;

namespace Com.Suncor.Olt.Client.Controls.ToolStrips
{
    public partial class MainUserStrip : UserControl, IMainUserStrip
    {
        private readonly List<Site> AllsiteList;
        //AutoCompleteStringCollection allowedStatorTypes= new AutoCompleteStringCollection(); 
        public MainUserStrip()
        {
          
            InitializeComponent();
            Load += MainUserStrip_Load;

           
        }

        public List<string> ActiveFLOCNames
        {
            set
            {
                var toolTipText = new StringBuilder();
                toolTipText.AppendLine(StringResources.MainUserStripActiveFlocToolTipText);
                toolTipText.AppendLine();
                value.ForEach(name => toolTipText.AppendLine(name));
                changeActiveFLOCButton.ToolTipText = toolTipText.ToString();
            }
        }

        public string FullName
        {
            set { fullnameLabelData.Text = value; }
        }

        public string Shift
        {
            set { shiftLabelData.Text = value; }
        }

        public new string Site
        {
            set { siteLabelData.Text = value; }
        }

        public string Role
        {
            set { roleLabelData.Text = value; }
        }

        public string WorkAssignment
        {
            set { workAssignmentLabelData.Text = value; }
        }

        // DMND0011225 CSD for WBR
        public bool CreateGenericCsdItemVisible
        {
            set { formGenericCsdMenuItem.Visible = value; }
        }

        public bool CreateActionItemVisible
        {
            set { actionItemMenuItem.Visible = value; }
        }

        public bool CreateTargetVisible
        {
            set { targetMenuItem.Visible = value; }
        }

        public bool CreateRestrictionVisible
        {
            set { restrictionMenuItem.Visible = value; }
        }

        public bool CreateShiftHandoverQuestionnaireVisible
        {
            set { shiftHandoverToolStripMenuItem.Visible = value; }
        }

        public bool CreatePermitVisible
        {
            set { permitMenuItem.Visible = value; }
        }

        public bool CreateLabAlertVisible
        {
            set { labAlertMenuItem.Visible = value; }
        }

        public bool CreatePermitRequestVisible
        {
            set { permitRequestToolStripMenuItem.Visible = value; }
        }

        public bool CreateNewItemEnabled
        {
            set { newSplitButton.Enabled = value; }
        }

        public bool CreateConfinedSpaceVisible
        {
            set { confinedSpaceDocumentToolStripMenuItem.Visible = value; }
        }

        public bool ChangePermitFLOCButtonVisible
        {
            set { changeWorkPermitFLOCToolStripButton.Visible = value; }
        }

        //RITM0386914 : OLT users to switch from one site to another - Added By Vibhor
        public bool ChangeSiteEnabled 
        {
            set { ChangeSite.Enabled = value; }
            
        }
        //END

        public bool ChangeRestrictionFLOCButtonVisible
        {
            set { changeActiveRestrictionFlocToolStripButton.Visible = value; }
        }

        public bool CreateDirectiveVisible
        {
            set { directiveToolStripMenuItem.Visible = value; }
        }

        //ayman Sarnia eip DMND0008992
        public void CreateEipIssueVisible(bool createEipIssueAuthorised)
        {
            formSarniaGN75BFormMenuItem.Visible = createEipIssueAuthorised;
            formSarniaGN75BTemplateMenuItem.Visible = createEipIssueAuthorised; //INC0398755 : added by Vibhor
        }


        public void CreateLogVisible(
            bool createShiftLogVisible,
            bool createShiftSummaryLogVisible,
            bool createDailyDirectivesVisible,
            bool createCokerCardVisible,
            bool createLogDefinitionVisible,
            bool createStandingOrdersVisible)
        {
            shiftLogMenuItem.Visible = createShiftLogVisible;
            logDefinitionMenuItem.Visible = createLogDefinitionVisible;
            shiftSummaryLogMenuItem.Visible = createShiftSummaryLogVisible;
            dailyDirectiveMenuItem.Visible = createDailyDirectivesVisible;
            standingOrderMenuItem.Visible = createStandingOrdersVisible;
            cokerCardMenuItem.Visible = createCokerCardVisible;

            logMenuItem.Visible =
                createShiftLogVisible ||
                createShiftSummaryLogVisible ||
                createDailyDirectivesVisible ||
                createCokerCardVisible ||
                createLogDefinitionVisible ||
                createStandingOrdersVisible
                ;
        }


        //generic template - mangesh
        public void CreateGenericTemplateFormVisible(bool createEdmontonOdourNoiseFormAuthorized, bool createEdmontonDeviationFormAuthorized, bool createEdmontonRoadClosureFormAuthorized,
                                                    bool createEdmontonGN11GroundDistrubanceFormAuthorized, bool createEdmontonGN27FreezePlugFormAuthorized, bool createEdmontonHazardAssessmentFormAuthorized
                                                    , bool createEdmontonNonEmergencyWaterSystemApproval)
        {
            //TODO- implent for Visible Or Enable ?
            formOdourNoiseMenuItem.Visible = createEdmontonOdourNoiseFormAuthorized;
            formDeviationMenuItem.Visible = createEdmontonDeviationFormAuthorized;
            formRoadClosureMenuItem.Visible = createEdmontonRoadClosureFormAuthorized;
            formGN11GroundDisturbanceMenuItem.Visible = createEdmontonGN11GroundDistrubanceFormAuthorized;
            formGN27FreezePlugMenuItem.Visible = createEdmontonGN27FreezePlugFormAuthorized;
            formHazardAssessmentMenuItem.Visible = createEdmontonHazardAssessmentFormAuthorized;
            formNonEmergencyWaterSystemApprovalMenuItem.Visible = createEdmontonNonEmergencyWaterSystemApproval; // TASK0593631 - mangesh
        }

        //ayman sarnia - ayman selc - ayman forthills - ayman E&U - ayman forthills questionnaire
        public void CreateFormsVisible(bool createEdmontonFormsVisible, bool createSarniaFormsVisible, bool createSelcCSDFormsVisisble, bool createForthillsTrainingVisible, bool createOilsandsTrainingVisible,
            bool createEdmontonOvertimeFormsVisible, bool createLubesCsdFormVisible, bool createMontrealCsdAuthorized,
            bool createLubesAlarmDisableAuthorized, bool createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized,
            bool createFormDocumentSuggestionAuthorized,
            bool createFormProcedureDeviationAuthorized, bool createSiteWideTrainingVisible, bool createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized
            , bool createETFTrainingVisible
            , bool createMudsTemporaryInstallationsAuthorized //RITM0268131 - mangesh)
            , bool createFortHillOilSampleFormAuthorized, bool createFortHillDailyInspectionFormAuthorized,  //RITM0341710 - mangesh
            bool createGenericCsdAuthorized)
        {

            gN75AppendixBToolStripMenuItem.Visible = createEdmontonFormsVisible;
            formOP14MenuItem.Visible = createEdmontonFormsVisible;
            formGN1MenuItem.Visible = createEdmontonFormsVisible;
            formGN6MenuItem.Visible = createEdmontonFormsVisible;
            formGN7MenuItem.Visible = createEdmontonFormsVisible;
            formGN24MenuItem.Visible = createEdmontonFormsVisible;
            formGN59MenuItem.Visible = createEdmontonFormsVisible;
            gN75AppendixAToolStripMenuItem.Visible = createEdmontonFormsVisible;

            formLubesCsdMenuItem.Visible = createLubesCsdFormVisible;
            formLubesAlarmDisableMenuItem.Visible = createLubesAlarmDisableAuthorized;

            formMontrealCsdMenuItem.Visible = createMontrealCsdAuthorized;

            // DMND0011225 CSD for WBR
            formGenericCsdMenuItem.Visible = createGenericCsdAuthorized;
            
            formOilsandsTrainingMenuItem.Visible = createOilsandsTrainingVisible;

            //ayman forthills
            formForthillsTrainingMenuItem.Visible = createForthillsTrainingVisible;

            //ayman E&U
            formSiteWideTrainingMenuItem.Visible = createSiteWideTrainingVisible;

            //mangesh ETF    
            formETFTrainingMenuItem.Visible = createETFTrainingVisible;

            overtimeRequestToolStripMenuItem.Visible = createEdmontonOvertimeFormsVisible;

            formOilSandsSafeWorkPermitAuditQuestionnaireToolStripMenuItem.Visible =
                createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized;

            //ayman forthills questionnaire
            formForthillsSafeWorkPermitAuditQuestionnaireToolStripMenuItem.Visible =
            createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized;

            formDocumentSuggestionMenuItem.Visible = createFormDocumentSuggestionAuthorized;


            formProcedureDeviationMenuItem.Visible = createFormProcedureDeviationAuthorized;



            //    formGN75BMenuItem.Visible = createEdmontonFormsVisible;
            formSarniaGN75BTemplateMenuItem.Visible = createSarniaFormsVisible;     //ayman generic forms             ayman Sarnia eip DMND0008992
            formSarniaGN75BFormMenuItem.Visible = createSarniaFormsVisible;     //ayman Sarnia eip DMND0008992
            formSarniaOP14MenuItem.Visible = createSarniaFormsVisible;      //ayman generic forms

            formSelcOP14MenuItem.Visible = createSelcCSDFormsVisisble;      //ayman selc

            formMudsTemporaryInstallationMenuItem.Visible = createMudsTemporaryInstallationsAuthorized; //RITM0268131 - mangesh

            //RITM0341710 - mangesh
            formOilSampleMenuItem.Visible = createFortHillOilSampleFormAuthorized;
            formDailyInspectionMenuItem.Visible = createFortHillDailyInspectionFormAuthorized;

            formMenuItem.Visible = createEdmontonFormsVisible || createSarniaFormsVisible || createSelcCSDFormsVisisble ||
                                   createOilsandsTrainingVisible || createForthillsTrainingVisible ||
                                   //ayman selc - ayman forthills - ayman E&U
                                   createEdmontonOvertimeFormsVisible || createLubesCsdFormVisible ||
                                   createMontrealCsdAuthorized || createLubesAlarmDisableAuthorized ||
                                   createFormOilSandsSafeWorkPermitAuditQuestionnaireAuthorized ||
                                   createFormDocumentSuggestionAuthorized || createFormProcedureDeviationAuthorized ||
                                   createSiteWideTrainingVisible ||
                                   createFormForthillsSafeWorkPermitAuditQuestionnaireAuthorized
                //ayman forthills questionnaire
                                   || createETFTrainingVisible // mangesh ETF   
                                   || createMudsTemporaryInstallationsAuthorized //RITM0268131 - mangesh  
                                   || createFortHillOilSampleFormAuthorized ||
                                   createFortHillDailyInspectionFormAuthorized //RITM0341710 - mangesh
                                   || createGenericCsdAuthorized;
        }

        public event EventHandler ChangeActiveFLOCsButtonClick;
        public event EventHandler ChangeActivePermitFLOCsButtonClick;
        public event EventHandler ChangeRestrictionFLOCsButtonClick;
        public event EventHandler LogOutClick;
        public event EventHandler CreateActionItemClick;
        public event EventHandler CreateReadingClick;                //ayman action item reading
        public event EventHandler CreateTargetClick;
        public event EventHandler CreateRestrictionClick;
        public event EventHandler CreatePermitClick;
        public event EventHandler CreateLabAlertClick;
        public event EventHandler CreateLogClick;
        public event EventHandler CreateRepeatingLogClick;
        public event EventHandler CreateShiftSummaryLogClick;
        public event EventHandler CreateDirectiveLogClick;
        public event EventHandler CreateDirectiveClick;
        public event EventHandler CreateStandingOrderClick;
        public event EventHandler CreateShiftHandoverQuestionnaireClick;
        public event EventHandler CreateCokerCardClick;
        public event EventHandler CreatePermitRequestClick;
        public event EventHandler CreateConfinedSpaceClick;
        public event EventHandler CreateFormGN7Click;
        public event EventHandler CreateFormGN59Click;
        public event EventHandler CreateFormOP14Click;
        public event EventHandler CreateFormLubesCsdClick;
        public event EventHandler CreateFormMontrealCsdClick;
        public event EventHandler CreateFormLubesAlarmDisableClick;
        public event EventHandler CreateFormGN24Click;
        public event EventHandler CreateFormGN6Click;
        public event EventHandler CreateFormOilsandsTrainingClick;
        public event EventHandler ChangeSiteClick; //RITM0386914 : OLT users to switch from one site to another - Added By Vibhor

        //generic template - mangesh
        public event EventHandler CreateFormOdourNoiseClick;
        public event EventHandler CreateFormDeviationClick;
        public event EventHandler CreateFormRoadClosureClick;
        public event EventHandler CreateFormGN11GroundDisturbanceClick;
        public event EventHandler CreateFormGN27FreezePlugClick;
        public event EventHandler CreateFormHazardAssessmentClick;

        public event EventHandler CreateFormNonEmergencyWaterSystemApprovalClick; // TASK0593631 - mangesh

        //ayman forthills
        public event EventHandler CreateFormForthillsTrainingClick;

        //RITM0341710 - mangesh
        public event EventHandler CreateFormFortHillOilSampleClick;
        public event EventHandler CreateFormFortHillDailyInspectionClick;

        //ayman E&U
        public event EventHandler CreateFormSiteWideTrainingClick;

        //mangesh ETF
        public event EventHandler CreateFormETFTrainingClick;

        public event EventHandler CreateFormOverTimeFormClick;
        public event EventHandler CreateFormGN75AClick;
        public event EventHandler CreateFormGN75BClick;
        public event EventHandler CreateFormGN1Click;
        public event EventHandler NewButtonClick;
        public event EventHandler CreateFormOilSandsSafeWorkPermitAuditQuestionnaireClick;

        // DMND0011225 CSD for WBR
        public event EventHandler CreateGenericCSDItemClick;

        //ayman Forthills Questionnaire
        public event EventHandler CreateFormForthillsSafeWorkPermitAuditQuestionnaireClick;

        public event EventHandler CreateFormDocumentSuggestionClick;
        public event EventHandler CreateFormProcedureDeviationClick;

        //ayman generic forms
        public event EventHandler CreateFormSarniaOP14Click;
        public event EventHandler CreateFormSarniaGN75BTemplateClick;        //ayman Sarnia eip DMND0008992
        public event EventHandler CreateFormSarniaGN75BFormClick;            //ayman Sarnia eip DMND0008992

        //ayman selc
        public event EventHandler CreateFormSelcOP14Click;

 //RITM0268131 - mangesh
        public event EventHandler CreateFormMudsTemporaryInstallationClick;

        private void MainUserStrip_Load(object sender, EventArgs e)
        {
            timeButton.Visible = AssemblyUtil.IsDebugMode();
        }

        // DMND0011225 CSD for WBR
        private void genericCsdItemMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateGenericCSDItemClick != null)
            {
                CreateGenericCSDItemClick(this, e);
            }
        }


        private void actionItemMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateActionItemClick != null)
            {
                CreateActionItemClick(this, e);
            }
        }

        //ayman action item reading
        private void readingMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateReadingClick != null)
            {
                CreateReadingClick(this, e);
            }
        }

        private void targetMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateTargetClick != null)
            {
                CreateTargetClick(this, e);
            }
        }

        private void restrictionMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateRestrictionClick != null)
            {
                CreateRestrictionClick(this, e);
            }
        }

        private void permitMenuItem_Click(object sender, EventArgs e)
        {
            if (CreatePermitClick != null)
            {
                CreatePermitClick(this, e);
            }
        }

        private void labAlertMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateLabAlertClick != null)
            {
                CreateLabAlertClick(this, e);
            }
        }

        private void shiftLogMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateLogClick != null)
            {
                CreateLogClick(this, e);
            }
        }

        private void logDefinitionMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateRepeatingLogClick != null)
            {
                CreateRepeatingLogClick(this, e);
            }
        }

        private void shiftSummaryLogMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateShiftSummaryLogClick != null)
            {
                CreateShiftSummaryLogClick(this, e);
            }
        }

        private void cokerCardMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateCokerCardClick != null)
            {
                CreateCokerCardClick(this, e);
            }
        }

        private void permitRequestMenuItem_Click(object sender, EventArgs e)
        {
            if (CreatePermitRequestClick != null)
            {
                CreatePermitRequestClick(this, e);
            }
        }

        private void confinedSpaceDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateConfinedSpaceClick != null)
            {
                CreateConfinedSpaceClick(this, e);
            }
        }

        private void shiftHandoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateShiftHandoverQuestionnaireClick != null)
            {
                CreateShiftHandoverQuestionnaireClick(this, e);
            }
        }

        private void dailyDirectiveMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateDirectiveLogClick != null)
            {
                CreateDirectiveLogClick(this, e);
            }
        }

        private void directiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateDirectiveClick != null)
            {
                CreateDirectiveClick(this, e);
            }
        }

        private void standingOrderMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateStandingOrderClick != null)
            {
                CreateStandingOrderClick(this, e);
            }
        }

        public void logOutButton_Click(object sender, EventArgs e)
        {
            if (LogOutClick != null)
            {
                LogOutClick(sender, e);
            }
        }

        private void changeActiveFLOCButton_Click(object sender, EventArgs e)
        {
            if (ChangeActiveFLOCsButtonClick != null)
            {
                ChangeActiveFLOCsButtonClick(sender, e);
            }
        }

        private void changeWorkPermitFLOCToolStripButton_Click(object sender, EventArgs e)
        {
            if (ChangeActivePermitFLOCsButtonClick != null)
            {
                ChangeActivePermitFLOCsButtonClick(sender, e);
            }
        }

        private void changeRestrictionFLOCToolStripButton_Click(object sender, EventArgs e)
        {
            if (ChangeRestrictionFLOCsButtonClick != null)
            {
                ChangeRestrictionFLOCsButtonClick(sender, e);
            }
        }

        private void formGN7MenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN7Click != null)
            {
                CreateFormGN7Click(sender, e);
            }
        }

        private void formGN59MenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN59Click != null)
            {
                CreateFormGN59Click(sender, e);
            }
        }

        private void formOP14MenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormOP14Click != null)
            {
                CreateFormOP14Click(sender, e);
            }
        }

        //TASK0593631 - mangesh
        private void formNonEmergencyWaterSystemApprovalMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormNonEmergencyWaterSystemApprovalClick != null)
            {
                CreateFormNonEmergencyWaterSystemApprovalClick(sender, e);
            }
        }

        private void formOdourNoiseMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormOdourNoiseClick != null)
            {
                CreateFormOdourNoiseClick(sender, e);
            }
        }
        private void formDeviationMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormDeviationClick != null)
            {
                CreateFormDeviationClick(sender, e);
            }
        }
        private void formRoadClosureMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormRoadClosureClick != null)
            {
                CreateFormRoadClosureClick(sender, e);
            }
        }
        private void formGN11GroundDisturbanceMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN11GroundDisturbanceClick != null)
            {
                CreateFormGN11GroundDisturbanceClick(sender, e);
            }
        }
        private void formGN27FreezePlugMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN27FreezePlugClick != null)
            {
                CreateFormGN27FreezePlugClick(sender, e);
            }
        }
        private void formHazardAssessmentMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormHazardAssessmentClick != null)
            {
                CreateFormHazardAssessmentClick(sender, e);
            }
        }

        private void formLubesCsdMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormLubesCsdClick != null)
            {
                CreateFormLubesCsdClick(sender, e);
            }
        }

        private void formMontrealCsdMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormMontrealCsdClick != null)
            {
                CreateFormMontrealCsdClick(sender, e);
            }
        }

        //RITM0341710 - mangesh
        private void formOilSampleMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormFortHillOilSampleClick != null)
            {
                CreateFormFortHillOilSampleClick(sender, e);
            }
        }
        private void formDailyInspectionMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormFortHillDailyInspectionClick != null)
            {
                CreateFormFortHillDailyInspectionClick(sender, e);
            }
        }

   //RITM0268131 - mangesh
        private void formMudsTemporaryInstallationMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormMudsTemporaryInstallationClick != null)
            {
                CreateFormMudsTemporaryInstallationClick(sender, e);
            }
        }

        //ayman sarnia eip DMND0008992
        private void formSarniaGN75BTemplateMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormSarniaGN75BTemplateClick != null)
            {
                CreateFormSarniaGN75BTemplateClick(sender, e);
            }
        }

        //ayman Sarnia eip DMND0008992
        private void formSarniaGN75BFormMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormSarniaGN75BFormClick != null)
            {
                CreateFormSarniaGN75BFormClick(sender, e);
            }
        }

        private void formSarniaOP14MenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormSarniaOP14Click != null)
            {
                CreateFormSarniaOP14Click(sender, e);
            }
        }


        //ayman selc
        private void formSelcOP14MenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormSelcOP14Click != null)
            {
                CreateFormSelcOP14Click(sender, e);
            }
        }

        private void formLubesAlarmDisableMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormLubesAlarmDisableClick != null)
            {
                CreateFormLubesAlarmDisableClick(sender, e);
            }
        }

        private void formOilSandsSafeWorkPermitAuditQuestionnaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormOilSandsSafeWorkPermitAuditQuestionnaireClick != null)
            {
                CreateFormOilSandsSafeWorkPermitAuditQuestionnaireClick(sender, e);
            }
        }

        //ayman Forthills Questionnaire
        private void formForthillsSafeWorkPermitAuditQuestionnaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormForthillsSafeWorkPermitAuditQuestionnaireClick != null)
            {
                CreateFormForthillsSafeWorkPermitAuditQuestionnaireClick(sender, e);
            }
        }

        private void formGN24MenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN24Click != null)
            {
                CreateFormGN24Click(sender, e);
            }
        }

        private void formGN6MenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN6Click != null)
            {
                CreateFormGN6Click(sender, e);
            }
        }

        private void formGN75AMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN75AClick != null)
            {
                CreateFormGN75AClick(sender, e);
            }
        }

        private void formGN75BMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN75BClick != null)
            {
                CreateFormGN75BClick(sender, e);
            }
        }

        private void formGN1MenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormGN1Click != null)
            {
                CreateFormGN1Click(sender, e);
            }
        }

        private void formOilsandsTrainingMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormOilsandsTrainingClick != null)
            {
                CreateFormOilsandsTrainingClick(sender, e);
            }
        }

        //ayman forthills
        private void formForthillsTrainingMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormForthillsTrainingClick != null)
            {
                CreateFormForthillsTrainingClick(sender, e);
            }
        }

        //ayman E&U
        private void formSiteWideTrainingMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormSiteWideTrainingClick != null)
            {
                CreateFormSiteWideTrainingClick(sender, e);
            }
        }

        //mangesh ETF
        private void formETFTrainingMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormETFTrainingClick != null)
            {
                CreateFormETFTrainingClick(sender, e);
            }
        }

        private void overtimeRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormOverTimeFormClick != null)
            {
                CreateFormOverTimeFormClick(sender, e);
            }
        }

        private void newSplitButton_ButtonClick(object sender, EventArgs e)
        {
            NewButtonClick(sender, e);
        }

        private void timeButton_Click(object sender, EventArgs e)
        {
            OltMessageBox.Show(Form.ActiveForm, Clock.TimeNow.ToStringWithSeconds());
        }

        private void formDocumentSuggestionMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormDocumentSuggestionClick != null)
            {
                CreateFormDocumentSuggestionClick(sender, e);
            }
        }

        private void formProcedureDeviationMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateFormProcedureDeviationClick != null)
            {
                CreateFormProcedureDeviationClick(sender, e);
            }
        }

        //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        public string SetShiftLogMenuItemName
        {
            set
            {
                shiftLogMenuItem.Text = value;
                logMenuItem.Text = value; 
            }
        }
//RITM0443261 : Added by Amit {Change the name for Shift Summary log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        public string SetShiftSummaryLogMenuItemName
        {
            set
            {
                shiftSummaryLogMenuItem.Text = value;
                shiftSummaryLogMenuItem.Text = value; 
            }
        }
        //END

        //RITM0386914 : OLT users to switch from one site to another - Added By Vibhor
        private void ChangeSite_Click(object sender, EventArgs e)
        {
            if (ChangeSiteClick != null)
            {
                ChangeSiteClick(sender, e);
            }

        }

        //Mukesh for Permit search Demand
        public AutoCompleteStringCollection AutoSearchPermitNumber
        {
            set {  
                txtSearchText.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSearchText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtSearchText.AutoCompleteCustomSource = value;
               
                }
        }

        public bool SetSearchvisible
        {
            set
            {
                btnSearch.Visible = value;

            }
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {          

            txtSearchText.Visible =   txtSearchText.Visible?false:true;
            if(txtSearchText.Visible)
            {
               txtSearchText.LostFocus += txtSearchText_LostFocus;
                txtSearchText.Focus();
            }
        }

        private void txtSearchText_LostFocus(object sender, EventArgs e)
        {
            txtSearchText.Visible = false;
        }



        private void txtSearchText_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.Enter)
            {
                string SearchText = txtSearchText.Text;
                if (!ClientSession.GetUserContext().IsSarniaSite)
                {
                    int indexofFirst = txtSearchText.Text.IndexOf("-");
                    int indexoflast = txtSearchText.Text.LastIndexOf("-");
                    if (indexofFirst >= 0 && indexoflast > 0 && indexofFirst!=indexoflast)
                    {
                        SearchText = SearchText.Substring(indexofFirst + 1, (SearchText.LastIndexOf("-") - (SearchText.IndexOf("-") + 1)));
                        txtSearchText.Text = SearchText;
                    }
                    
                  
                }
                else if (ClientSession.GetUserContext().IsSarniaSite)
                {
                    var cnt= txtSearchText.Text.Split('-').Length-1; 
                    if( cnt>1)
                    {
                        int indexofFirst = txtSearchText.Text.IndexOf("-");
                        int indexoflast = txtSearchText.Text.LastIndexOf("-");
                        if (indexofFirst >= 0 && indexoflast > 0 && indexofFirst != indexoflast)
                        {
                            SearchText = SearchText.Substring(indexofFirst + 1, (SearchText.LastIndexOf("-") - (SearchText.IndexOf("-") + 1)));
                            txtSearchText.Text = SearchText;
                        }
                    }


                }
                if (ClientSession.GetUserContext().IsEdmontonSite)
                {
                    ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                    int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(SearchText);
                    if (WOrkPermitId > 0)
                    {
                        var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                        Com.Suncor.Olt.Common.Services.IWorkPermitEdmontonService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitEdmontonService>(); ;
                        var presenter = new Com.Suncor.Olt.Client.Presenters.Page.PriorityPageWorkPermitEdmontonDetailsPresenter(WOrkPermitId, true);
                        presenter.Run(this.ParentForm);
                    }
                    else
                    {
                        OltMessageBox.Show(StringResources.MessageErrorPermitnotExists, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                
                }
                else if (ClientSession.GetUserContext().IsMontrealSulphurSite)
                {
                    ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                    int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(SearchText);
                    if (WOrkPermitId > 0)
                    {
                        var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                        Com.Suncor.Olt.Common.Services.IWorkPermitMudsService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitMudsService>(); ;
                        var presenter = new Com.Suncor.Olt.Client.Presenters.Page.PriorityPageWorkPermitMudsDetailsPresenter(WOrkPermitId,true);
                        presenter.Run(this.ParentForm);
                       
                    }
                    else
                    {
                        OltMessageBox.Show(StringResources.MessageErrorPermitnotExists, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else if (ClientSession.GetUserContext().IsMontrealSite)
                {
                    ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                    int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(SearchText);
                    if (WOrkPermitId > 0)
                    {
                        var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                        Com.Suncor.Olt.Common.Services.IWorkPermitMontrealService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitMontrealService>(); ;
                        var presenter = new Com.Suncor.Olt.Client.Presenters.Page.PriorityPageWorkPermitMontrealDetailsPresenter(WOrkPermitId, true);
                        presenter.Run(this.ParentForm);

                    }
                    else
                    {
                        OltMessageBox.Show(StringResources.MessageErrorPermitnotExists, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                
                else if (ClientSession.GetUserContext().IsDenverSite)
                {
                    ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                    int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(SearchText);
                    if (WOrkPermitId > 0)
                    {
                        var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                        Com.Suncor.Olt.Common.Services.IWorkPermitService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitService>(); ;
                        var presenter = new Com.Suncor.Olt.Client.Presenters.Page.SearchSarniaWorkpemitPresenter(WOrkPermitId, true);
                        presenter.Run(this.ParentForm);

                    }
                    else
                    {
                        OltMessageBox.Show(StringResources.MessageErrorPermitnotExists, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else if (ClientSession.GetUserContext().IsSarniaSite)
                {
                    ScanPdfFormPresenter scanPdfFormPresenter = new ScanPdfFormPresenter();
                    int WOrkPermitId = scanPdfFormPresenter.WorkpermitIdfromNumuber(txtSearchText.Text);
                    if (WOrkPermitId > 0)
                    {
                        var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
                        Com.Suncor.Olt.Common.Services.IWorkPermitService formService = clientServiceRegistry.GetService<Com.Suncor.Olt.Common.Services.IWorkPermitService>(); ;
                        var presenter = new Com.Suncor.Olt.Client.Presenters.Page.SearchSarniaWorkpemitPresenter(WOrkPermitId,true);
                        presenter.Run(this.ParentForm);

                    }
                    else
                    {
                        OltMessageBox.Show(StringResources.MessageErrorPermitnotExists,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }


                }
            }
        }

      
        //END-Mukesh for Permit search Demand
    }
}