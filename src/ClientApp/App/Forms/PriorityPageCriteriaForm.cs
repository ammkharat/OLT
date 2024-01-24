using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PriorityPageCriteriaForm : BaseForm, IPriorityPageCriteriaView
    {
        public PriorityPageCriteriaForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClick;
            cancelButton.Click += HandleCancelButtonClick;

            displayIncompleteActionItemsFromXDaysAgoRadioButton.Click += HandleIncompleteActionItemsRadioButtonClick;
            displayIncompleteActionItemsFromPreviousShiftRadioButton.Click +=
                HandleIncompleteActionItemsRadioButtonClick;

            mainPanel.Layout += MainPanelOnLayout;
        }

        public string MaximumAllowableExcursionEventDurationMins
        {
            get { return maximumAllowableExcursionEventDurationMinsTextBox.Text; }
            set { maximumAllowableExcursionEventDurationMinsTextBox.Text = value; }
        }

        public string MaximumAllowableExcursionEventTimeframeMins
        {
            get { return maximumAllowableExcursionEventTimeframeMinsTextBox.Text; }
            set { maximumAllowableExcursionEventTimeframeMinsTextBox.Text = value; }
        }

        public event Action FormLoad;
        public event Action SaveButtonClick;

        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public bool ShowActionItemsByWorkAssignment
        {
            get { return actionItemByWorkAssignmentAndFlocRadioButton.Checked; }
            set { actionItemByWorkAssignmentAndFlocRadioButton.Checked = value; }
        }

        public bool ShowShiftHandoversByWorkAssignment
        {
            get { return handoverByWorkAssignmentAndFlocRadioButton.Checked; }
            set { handoverByWorkAssignmentAndFlocRadioButton.Checked = value; }
        }

        public string DaysToDisplayDirectives
        {
            get { return daysToDisplayDirectivesTextBox.Text; }
            set { daysToDisplayDirectivesTextBox.Text = value; }
        }

        public string DaysToDisplayShiftHandovers
        {
            get { return daysToDisplayShiftHandoversTextBox.Text; }
            set { daysToDisplayShiftHandoversTextBox.Text = value; }
        }

        public string DaysToDisplayForms
        {
            get { return daysToDisplayFormsTextBox.Text; }
            set { daysToDisplayFormsTextBox.Text = value; }
        }

        public string DaysToDisplayDocumentSuggestions
        {
            get { return daysToDisplayDocumentSuggestionsTextBox.Text; }
            set { daysToDisplayDocumentSuggestionsTextBox.Text = value; }
        }

        public bool DisplayIncompleteActionItemsFromXDaysAgo
        {
            get { return displayIncompleteActionItemsFromXDaysAgoRadioButton.Checked; }
            set
            {
                displayIncompleteActionItemsFromXDaysAgoRadioButton.Checked = value;
                HandleIncompleteActionItemsRadioButtonClick(this, EventArgs.Empty);
            }
        }

        public bool DisplayIncompleteActionItemsFromPreviousShift
        {
            get { return displayIncompleteActionItemsFromPreviousShiftRadioButton.Checked; }
            set
            {
                displayIncompleteActionItemsFromPreviousShiftRadioButton.Checked = value;
                HandleIncompleteActionItemsRadioButtonClick(this, EventArgs.Empty);
            }
        }

        public string DaysToDisplayIncompleteActionItems
        {
            get { return daysToDisplayIncompleteActionItemsTextBox.Text; }
            set
            {
                daysToDisplayIncompleteActionItemsTextBox.Text = value;
                if (value == null)
                {
                    DisplayIncompleteActionItemsFromPreviousShift = true;
                }
                else
                {
                    DisplayIncompleteActionItemsFromXDaysAgo = true;
                }
            }
        }

        public bool DisplayActionItemWorkAssignment
        {
            get { return displayActionItemWorkAssignmentCheckBox.Checked; }
            set { displayActionItemWorkAssignmentCheckBox.Checked = value; }
        }

        public void SetErrorForDirectives(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayDirectivesTextBox, errorMessage);
        }

        public void SetErrorForShiftHandovers(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayShiftHandoversTextBox, errorMessage);
        }

        public void SetErrorForForms(string errorMessage)
        {
            itemCountErrorProvider.SetError(maximumAllowableExcursionEventDurationMinsTextBox, errorMessage);
        }

        public void SetErrorForDocumentSuggestions(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayDocumentSuggestionsTextBox, errorMessage);
        }

        public void SetErrorForDaysToDisplayIncompleteActionItems(string errorMessage)
        {
            itemCountErrorProvider.SetError(displayIncompleteActionItemsFromXDaysAgoRadioButton, errorMessage);
        }

        public void SetErrorForMaximumAllowableExcursionEventDurationMins(string errorMessage)
        {
            itemCountErrorProvider.SetError(maximumAllowableExcursionEventDurationMinsTextBox, errorMessage);
        }

        public void SetErrorForMaximumAllowableExcursionEventTimeframeMins(string errorMessage)
        {
            itemCountErrorProvider.SetError(maximumAllowableExcursionEventTimeframeMinsTextBox, errorMessage);
        }

        public void ClearErrors()
        {
            itemCountErrorProvider.Clear();
        }

        public void HideElectronicFormsGroupBox()
        {
            electronicFormsGroupBox.Visible = false;
        }

        public void HideDocumentSuggestionFormsGroupBox()
        {
            documentSuggestionsGroupBox.Visible = false;
        }

        public void HideDirectiveLogsGroupBox()
        {
            directiveLogsGroupBox.Visible = false;
        }

        public void HideExcursionEventsGroupBox()
        {
            excursionEventsGroupBox.Visible = false;
        }

        private void HandleIncompleteActionItemsRadioButtonClick(object sender, EventArgs eventArgs)
        {
            if (displayIncompleteActionItemsFromPreviousShiftRadioButton.Checked)
            {
                daysToDisplayIncompleteActionItemsTextBox.Enabled = false;
            }
            else
            {
                daysToDisplayIncompleteActionItemsTextBox.Enabled = true;
            }
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            if (SaveButtonClick != null)
            {
                SaveButtonClick();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        private void MainPanelOnLayout(object sender, LayoutEventArgs layoutEventArgs)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }

    public interface IPriorityPageCriteriaView : IBaseForm
    {
        string SiteName { set; }
        bool ShowActionItemsByWorkAssignment { get; set; }
        bool ShowShiftHandoversByWorkAssignment { get; set; }
        string DaysToDisplayDirectives { get; set; }
        string DaysToDisplayShiftHandovers { get; set; }
        bool DisplayActionItemWorkAssignment { get; set; }
        string DaysToDisplayForms { get; set; }
        string DaysToDisplayDocumentSuggestions { get; set; }
        string MaximumAllowableExcursionEventDurationMins { get; set; }
        string MaximumAllowableExcursionEventTimeframeMins { get; set; }

        bool DisplayIncompleteActionItemsFromXDaysAgo { get; set; }
        bool DisplayIncompleteActionItemsFromPreviousShift { get; set; }
        string DaysToDisplayIncompleteActionItems { get; set; }
        event Action FormLoad;
        event Action SaveButtonClick;

        void SetErrorForDirectives(string errorMessage);
        void SetErrorForShiftHandovers(string errorMessage);
        void SetErrorForForms(string errorMessage);
        void SetErrorForDocumentSuggestions(string errorMessage);
        void SetErrorForDaysToDisplayIncompleteActionItems(string errorMessage);
        void SetErrorForMaximumAllowableExcursionEventDurationMins(string errorMessage);
        void SetErrorForMaximumAllowableExcursionEventTimeframeMins(string errorMessage);
        void ClearErrors();

        void HideElectronicFormsGroupBox();
        void HideDirectiveLogsGroupBox();
        void HideExcursionEventsGroupBox();
        void HideDocumentSuggestionFormsGroupBox();
    }
}