using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormGN1Form : BaseForm, IFormGN1View
    {
        private const string ConstFieldMaintCoordApprovalColumnName = "ConstFieldMaintCoordApproval";
        private const string OpsCoordApprovalColumnName = "OpsCoordApproval";
        private const string AreaManagerApprovalColumnName = "AreaManagerApproval";

        public event EventHandler SaveButtonClicked;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
        public event EventHandler CancelButtonClicked;
        public event Action FormLoad;
        public event Action ExpandPlanningWorksheetContentClicked;
        public event Action ExpandRescuePlanContentClicked;
        public event Action SaveAndEmailButtonClicked;
        public event Action HistoryButtonClicked;
        public event Action BrowseFunctionalLocationButtonClicked;
        public event Action AddTradeChecklistButtonClicked;
        public event Action EditTradeChecklistButtonClicked;
        public event Action RemoveTradeChecklistButtonClicked;
        public event Action CloneTradeChecklistButtonClicked;
        public event Action SelectedCSELevelChanged;
        public event Action<FormApproval> PlanningWorksheetApprovalSelected;
        public event Action<FormApproval> PlanningWorksheetApprovalUnselected;
        public event Action<FormApproval> RescuePlanApprovalSelected;
        public event Action<FormApproval> RescuePlanApprovalUnselected;

        public event Action<TradeChecklist> TradeChecklistConstFieldMaintCoordApprovalSelected;
        public event Action<TradeChecklist> TradeChecklistConstFieldMaintCoordApprovalUnselected;

        public event Action<TradeChecklist> TradeChecklistOpsCoordApprovalSelected;
        public event Action<TradeChecklist> TradeChecklistOpsCoordApprovalUnselected;

        public event Action<TradeChecklist> TradeChecklistAreaManagerApprovalSelected;
        public event Action<TradeChecklist> TradeChecklistAreaManagerApprovalUnselected;

        private readonly ISingleSelectFunctionalLocationSelectionForm flocSelector;

        private float initialHeightOfPlanningWorksheetSectionContentRow;
        private float initialHeightOfRescuePlanSectionContentRow;
        private float initialHeightOfTableLayoutPanel;


        
        public FormGN1Form()
        {
            InitializeComponent();

            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector = new SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetLevelThreeAndBelow(
                userContext.SiteConfiguration),
                new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1, rootFlocsForActiveSelection));

            saveButton.Click += HandleSaveButtonClicked;
            waitingApproval.Click += HandleWaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            expandPlanningWorksheetContentLinkLabel.Click += HandleExpandPlanningWorksheetContentClicked;
            expandRescuePlanContentLinkLabel.Click += HandleExpandRescuePlanContentClicked;
            browseFunctionalLocationButton.Click += HandleBrowseFunctionalLocationButtonClicked;
            historyButton.Click += HandleHistoryButtonClick;

            addTradeChecklistButton.Click += HandleAddTradeChecklistButtonClicked;
            editTradeChecklistButton.Click += HandleEditTradeChecklistButtonClicked;
            removeTradeChecklistButton.Click += HandleRemoveTradeChecklistButtonClicked;
            cloneTradeChecklistButton.Click += HandleCloneTradeChecklistButtonClicked;

            planningWorksheetApprovalsGridControl.ApprovalSelected += HandlePlanningWorksheetApprovalSelected;
            planningWorksheetApprovalsGridControl.ApprovalUnselected += HandlePlanningWorksheetApprovalUnselected;

            rescuePlanApprovalsGridControl.ApprovalSelected += HandleRescuePlanApprovalSelected;
            rescuePlanApprovalsGridControl.ApprovalUnselected += HandleRescuePlanApprovalUnselected;

            cseLevelComboBox.SelectedIndexChanged += HandleCSELevelComboBoxSelectedIndexChanged;

            tradeChecklistGrid.CellChange += HandleTradeChecklistGridCellChange;
            tradeChecklistGrid.AfterSelectChange += TradeChecklistGridOnAfterSelectChange;

            //ayman enable/disable waiting for approval button
            saveButton.Text = "Save as Draft";

        }



        private void HandleWaitingApprovalButtonClicked(object sender, EventArgs e) // Swapnil Patki For DMND0005325 Point Number 7
        {
           if (WaitingApprovalButtonClicked != null)
            {
                WaitingApprovalButtonClicked();
            }
        }
        

        
        private void TradeChecklistGridOnAfterSelectChange(object sender,
            AfterSelectChangeEventArgs afterSelectChangeEventArgs)
        {
            cloneTradeChecklistButton.Enabled = true;
        }

        private void HandleTradeChecklistGridCellChange(object sender, CellEventArgs e)
        {
            string text = e.Cell.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw);
            TradeChecklist activeItem = (TradeChecklist) tradeChecklistGrid.ActiveItem;

            if (e.Cell.Column.Key == "ConstFieldMaintCoordApproval")
            {
                if (text == "True")
                {
                    TradeChecklistConstFieldMaintCoordApprovalSelected(activeItem);

                }
                else
                {
                    TradeChecklistConstFieldMaintCoordApprovalUnselected(activeItem);

                }
            }
            else if (e.Cell.Column.Key == "OpsCoordApproval")
            {
                if (text == "True")
                {
                    TradeChecklistOpsCoordApprovalSelected(activeItem);

                }
                else
                {
                    TradeChecklistOpsCoordApprovalUnselected(activeItem);

                }
            }
            else if (e.Cell.Column.Key == "AreaManagerApproval")
            {
                if (text == "True")
                {
                    TradeChecklistAreaManagerApprovalSelected(activeItem);

                }
                else
                {
                    TradeChecklistAreaManagerApprovalUnselected(activeItem);

                }
            }
        }

        private void HandleCSELevelComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCSELevelChanged();
        }

        private void HandleAddTradeChecklistButtonClicked(object sender, EventArgs e)
        {
            AddTradeChecklistButtonClicked();
        }

        private void HandleEditTradeChecklistButtonClicked(object sender, EventArgs e)
        {
            EditTradeChecklistButtonClicked();
        }

        private void HandleRemoveTradeChecklistButtonClicked(object sender, EventArgs e)
        {
            RemoveTradeChecklistButtonClicked();
        }

        private void HandleCloneTradeChecklistButtonClicked(object sender, EventArgs e)
        {
            CloneTradeChecklistButtonClicked();
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (HistoryButtonClicked != null)
            {
                HistoryButtonClicked();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            initialHeightOfPlanningWorksheetSectionContentRow = GetPlanningWorksheetSectionRowStyle().Height;
            initialHeightOfRescuePlanSectionContentRow = GetRescuePlanSectionRowStyle().Height;
            initialHeightOfTableLayoutPanel = mainTableLayoutPanel.Height;
            cloneTradeChecklistButton.Enabled = false;
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        private void HandlePlanningWorksheetApprovalSelected(FormApproval formApproval)
        {
            if (PlanningWorksheetApprovalSelected != null)
            {
                PlanningWorksheetApprovalSelected(formApproval);
            }
        }

        private void HandlePlanningWorksheetApprovalUnselected(FormApproval formApproval)
        {
            if (PlanningWorksheetApprovalUnselected != null)
            {
                PlanningWorksheetApprovalUnselected(formApproval);
            }
        }


        private void HandleRescuePlanApprovalSelected(FormApproval approval)
        {
            if (RescuePlanApprovalSelected != null)
            {
                RescuePlanApprovalSelected(approval);
            }
        }

        private void HandleRescuePlanApprovalUnselected(FormApproval approval)
        {
            if (RescuePlanApprovalUnselected != null)
            {
                RescuePlanApprovalUnselected(approval);
            }
        }

        public List<TradeChecklist> TradeChecklists
        {
            get { return (List<TradeChecklist>) tradeChecklistBindingSource.DataSource; }
            set
            {
                tradeChecklistBindingSource.DataSource = value;
                tradeChecklistBindingSource.ResetBindings(true);
            }
        }

        public TradeChecklist SelectedTradeChecklist
        {
            get { return (TradeChecklist) tradeChecklistGrid.ActiveItem; }
        }

        public void ActivateFirstTradeChecklistRowAndEnableButtons()
        {
            tradeChecklistGrid.ActivateFirstRow();

            int checklistCount = TradeChecklists.Count;
            editTradeChecklistButton.Enabled = checklistCount > 0;
            removeTradeChecklistButton.Enabled = checklistCount > 0;
            cloneTradeChecklistButton.Enabled = true;
        }

        public DialogResult ShowRemoveSelectedTradeChecklistMessage()
        {
            return OltMessageBox.Show(this, StringResources.AreYouSureDeleteDialogMessage, "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public User CreatedByUser
        {
            set { createdByUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime CreatedDateTime
        {
            set { createdDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public DateTime ValidTo
        {
            get
            {
                Date date = validToDatePicker.Value;
                Time time = validToTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                validToDatePicker.Value = new Date(value);
                validToTimePicker.Value = new Time(value);
            }
        }

        public DateTime ValidFrom
        {
            get
            {
                Date date = validFromDatePicker.Value;
                Time time = validFromTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                validFromDatePicker.Value = new Date(value);
                validFromTimePicker.Value = new Time(value);
            }
        }

        public string JobDescription
        {
            get { return jobDescriptionTextBox.Text; }
            set { jobDescriptionTextBox.Text = value; }
        }

        public string SelectedCSELevel
        {
            get { return (string) cseLevelComboBox.SelectedItem; }
            set { cseLevelComboBox.SelectedItem = value; }
        }

        public List<string> CSELevelValues
        {
            set
            {
                cseLevelComboBox.Items.Clear();
                value.ForEach(item => cseLevelComboBox.Items.Add(item));
            }
        }

        public string PlanningWorksheetContent
        {
            get { return planningWorksheetContentRichTextEditor.Text; }
            set { planningWorksheetContentRichTextEditor.Text = value; }
        }

        public string PlanningWorksheetPlainTextContent
        {
            get { return planningWorksheetContentRichTextEditor.PlainText; }
        }

        public string RescuePlanContent
        {
            get { return rescuePlanContentRichTextEditor.Text; }
            set { rescuePlanContentRichTextEditor.Text = value; }
        }

        public string RescuePlanPlainTextContent
        {
            get { return rescuePlanContentRichTextEditor.PlainText; }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    toolTip.SetToolTip(functionalLocationTextBox, value.Description);
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    toolTip.RemoveAll();
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = null;
                }
            }
        }

        public string LocationText
        {
            get { return locationTextBox.Text; }
            set { locationTextBox.Text = value; }
        }

        public bool HistoryButtonEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public List<FormApproval> PlanningWorksheetApprovals
        {
            set
            {
                planningWorksheetApprovalsGridControl.Items =
                    value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval));
            }
            get
            {
                if (planningWorksheetApprovalsGridControl.Items == null)
                {
                    return new List<FormApproval>();
                }

                List<FormApprovalGridDisplayAdapter> list =
                    new List<FormApprovalGridDisplayAdapter>(planningWorksheetApprovalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public List<FormApproval> RescuePlanApprovals
        {
            set
            {
                rescuePlanApprovalsGridControl.Items =
                    value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval));
            }
            get
            {
                if (rescuePlanApprovalsGridControl.Items == null)
                {
                    return new List<FormApproval>();
                }

                List<FormApprovalGridDisplayAdapter> list =
                    new List<FormApprovalGridDisplayAdapter>(rescuePlanApprovalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector(
            FunctionalLocation functionalLocation)
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this);

            FunctionalLocation selectedFunctionalLocation = flocSelector.SelectedFunctionalLocation;
            return new DialogResultAndOutput<FunctionalLocation>(dialogResult, selectedFunctionalLocation);
        }

        public void DisplayExpandedPlanningWorksheetContentForm()
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(PlanningWorksheetContent, false);
            expandedLogCommentForm.ShowDialog(this);
            PlanningWorksheetContent = expandedLogCommentForm.TextEditorText;
            expandedLogCommentForm.Dispose();
        }

        public void DisplayExpandedRescuePlanContentForm()
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(RescuePlanContent, false);
            expandedLogCommentForm.ShowDialog(this);
            RescuePlanContent = expandedLogCommentForm.TextEditorText;
            expandedLogCommentForm.Dispose();
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationTextBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(validToTimePicker, StringResources.EndDateBeforeStartDate);
        }

        public void SetErrorForNoCSELevelSelected()
        {
            errorProvider.SetError(cseLevelComboBox, StringResources.ValueRequired);
        }

        public void SetErrorForNoJobDescription()
        {
            errorProvider.SetError(jobDescriptionTextBox, StringResources.EnterAValidValue);
        }

        public void SetErrorForNoTradeChecklists()
        {
            errorProvider.SetError(tradeChecklistPanel, StringResources.AddAtLeastOneTradeChecklist);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult DisplayNoAssociatedGN75BFormDialog()
        {
            string message = StringResources.NoAssociatedGN75BFormSelected;
            string title = StringResources.NoAssociatedGN75BFormSelectedTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public void DisableInvalidCSELevel3Sections()
        {
            SetEnabledStateOfCSELevel3InvalidSections(false);
            SetEnabledStateOfCSELevel3InvalidSections(false);
        }

        public void EnableInvalidCSELevel3Sections()
        {
            SetEnabledStateOfCSELevel3InvalidSections(true);
            SetEnabledStateOfCSELevel3InvalidSections(true);
        }

        private void SetEnabledStateOfCSELevel3InvalidSections(bool enabled)
        {
            planningWorksheetGroupBox.Enabled = enabled;
            rescuePlanGroupBox.Enabled = enabled;
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }


        private void HandleSaveAndEmailButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveAndEmailButtonClicked != null)
            {
                SaveAndEmailButtonClicked();
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void HandleExpandPlanningWorksheetContentClicked(object sender, EventArgs e)
        {
            if (ExpandPlanningWorksheetContentClicked != null)
            {
                ExpandPlanningWorksheetContentClicked();
            }
        }

        private void HandleExpandRescuePlanContentClicked(object sender, EventArgs e)
        {
            if (ExpandRescuePlanContentClicked != null)
            {
                ExpandRescuePlanContentClicked();
            }
        }

        private void HandleBrowseFunctionalLocationButtonClicked(object sender, EventArgs eventArgs)
        {
            if (BrowseFunctionalLocationButtonClicked != null)
            {
                BrowseFunctionalLocationButtonClicked();
            }
        }

        public bool EditTradeChecklistButtonEnabled
        {
            set { editTradeChecklistButton.Enabled = value; }
        }

        public bool RemoveTradeChecklistButtonEnabled
        {
            set { removeTradeChecklistButton.Enabled = value; }
        }

        private RowStyle GetPlanningWorksheetSectionRowStyle()
        {
            int row = mainTableLayoutPanel.GetRow(planningWorksheetGroupBox);
            return mainTableLayoutPanel.RowStyles[row];
        }

        private RowStyle GetRescuePlanSectionRowStyle()
        {
            int row = mainTableLayoutPanel.GetRow(rescuePlanGroupBox);
            return mainTableLayoutPanel.RowStyles[row];
        }

        public void CollapsePlanningWorksheetAndTradeChecklistSections()
        {
            HideRescuePlanAndPlanningWorksheetSections();
        }

        public void ExpandPlanningWorksheetAndTradeChecklistSections()
        {
            ShowRescuePlanAndPlanningWorksheetSections();
        }

        public void HideTradeChecklistApprovalColumns()
        {
            HideApprovalColumns(true);
        }

        public void ShowTradeChecklistApprovalColumns()
        {
            HideApprovalColumns(false);

        }

        
        //ayman enable/disable waiting for approval button
        public void EnableWaitingApprovalButton()
        {
            waitingApproval.Enabled = true;
            saveButton.Text = "Save as Draft";
        }

        public void DisableWaitingApprovalButton()
        {
            waitingApproval.Enabled = false;
            saveButton.Text = "Save && Close";
        }


        public void DisableCseLevelSelection()
        {
            cseLevelComboBox.Enabled = false;
        }

        private void HideApprovalColumns(bool hide)
        {
            tradeChecklistGrid.DisplayLayout.Bands[0].Columns[ConstFieldMaintCoordApprovalColumnName].Hidden = hide;
            tradeChecklistGrid.DisplayLayout.Bands[0].Columns[OpsCoordApprovalColumnName].Hidden = hide;
            tradeChecklistGrid.DisplayLayout.Bands[0].Columns[AreaManagerApprovalColumnName].Hidden = hide;
        }

        private void ShowRescuePlanAndPlanningWorksheetSections()
        {
            SuspendLayout();

            RowStyle planningWorksheetSectionRowStyle = GetPlanningWorksheetSectionRowStyle();
            planningWorksheetSectionRowStyle.Height = initialHeightOfPlanningWorksheetSectionContentRow;

            RowStyle rescuePlanSectionRowStyle = GetRescuePlanSectionRowStyle();
            rescuePlanSectionRowStyle.Height = initialHeightOfRescuePlanSectionContentRow;

            mainTableLayoutPanel.Height = (int) initialHeightOfTableLayoutPanel;
            mainTableLayoutPanel.RowStyles[6].Height = 1;

            ResumeLayout();
        }

        private void HideRescuePlanAndPlanningWorksheetSections()
        {
            SuspendLayout();

            RowStyle planningWorksheetSectionRowStyle = GetPlanningWorksheetSectionRowStyle();
            planningWorksheetSectionRowStyle.Height = 0;

            RowStyle rescuePlanSectionRowStyle = GetRescuePlanSectionRowStyle();
            rescuePlanSectionRowStyle.Height = 0;

            mainTableLayoutPanel.Height = (int) initialHeightOfTableLayoutPanel -
                                          (int) initialHeightOfPlanningWorksheetSectionContentRow -
                                          (int) initialHeightOfRescuePlanSectionContentRow;
            mainTableLayoutPanel.RowStyles[6].Height = 1;

            ResumeLayout();
        }
    }
}