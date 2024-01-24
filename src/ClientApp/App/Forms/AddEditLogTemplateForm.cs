using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditLogTemplateForm : BaseForm, IAddEditLogTemplateFormView
    {
        private AddEditLogTemplateFormPresenter presenter;        
        private bool cancelClicked;

        private readonly IAssignmentMultiSelectFormView assignmentMultiSelectForm;
        private readonly SummaryGrid<LogTemplateAssignmentGridDisplayAdapter> assignmentGrid;

        public AddEditLogTemplateForm(LogTemplate editObject, List<LogTemplate> logTemplatesForSite)
        {
            InitializeComponent();
            InitializePresenter(editObject, logTemplatesForSite);

            assignmentMultiSelectForm = new AssignmentMultiSelectForm();

            assignmentGrid = new SummaryGrid<LogTemplateAssignmentGridDisplayAdapter>(new LogTemplateAssignmentGridRenderer(), OltGridAppearance.EDIT_ROW_SELECT_WITH_FILTER);
            assignmentGrid.Dock = DockStyle.Fill;
            assignmentGridPanel.Controls.Add(assignmentGrid);
        }

        private void InitializePresenter(LogTemplate editObject, List<LogTemplate> logTemplatesForSite)
        {
            presenter = new AddEditLogTemplateFormPresenter(this, editObject, logTemplatesForSite);

            Load += presenter.HandleLoad;
            saveButton.Click += presenter.HandleSubmit;
            cancelButton.Click += OnCancelClick;
            cancelButton.Click += presenter.HandleCancel;
            workAssignmentButton.Click += presenter.SelectWorkAssignments_Click;            
        }

        public void SetErrorForAssignmentAlreadyHasAnAutoInsertedTemplate(string errorMessage)
        {
            errorProvider.SetError(assignmentGridPanel, errorMessage);
        }

        public DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> selectedAssignments)
        {
            assignmentMultiSelectForm.ShowMultiSelectDialog(selectedAssignments);

            DialogResultAndOutput<IList<WorkAssignment>> result =
                new DialogResultAndOutput<IList<WorkAssignment>>(
                    assignmentMultiSelectForm.DialogResult, assignmentMultiSelectForm.SelectedAssignments);

            return result;
        }

        public LogTemplate ShowDialogAndReturnLogTemplate(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : presenter.EditObject;
        }

        public string LogTemplateName
        {
            get { return nameTextBox.Text.Trim(); }
            set { nameTextBox.Text = value; }
        }

        public string LogTemplateText
        {
            get { return logTemplateTextTextBox.Text; }
            set { logTemplateTextTextBox.Text = value; }
        }

        public string LogTemplateTextAsPlainText
        {
            get { return logTemplateTextTextBox.PlainText; }
        }

        public new Site Site
        {
            set { siteLabelData.Text = value.Name; }
        }

        public List<LogTemplateAssignmentGridDisplayAdapter> LogTemplateAssignmentGridDisplayAdapters
        {
            get { return new List<LogTemplateAssignmentGridDisplayAdapter>(assignmentGrid.Items); }
            set { assignmentGrid.Items = value; }
        }

        public bool AppliesToLogs
        {
            get { return appliesToLogsCheckBox.Checked; }
            set { appliesToLogsCheckBox.Checked = value; }
        }

        public bool AppliesToSummaryLogs
        {
            get { return appliesToSummaryLogsCheckBox.Checked; }
            set { appliesToSummaryLogsCheckBox.Checked = value; }
        }

        public bool AppliesToDirectives
        {
            get { return appliesToDirectivesCheckBox.Checked; }
            set { appliesToDirectivesCheckBox.Checked = value; }
        }

        public void CloseForm()
        {
            Close();
        }
              
        public void ClearAllErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorForNoAssociatedWorkAssignments()
        {
            errorProvider.SetError(assignmentGridPanel, StringResources.AtLeastOneWorkAssignmentMustBeSelected);
        }

        public void SetErrorForNoNameProvided()
        {
            errorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        public void SetErrorForDuplicateName()
        {
            errorProvider.SetError(nameTextBox, StringResources.NameNotUniqueError);
        }

        public void SetErrorForNoTextProvided()
        {
            errorProvider.SetError(logTemplateTextTextBox, StringResources.FieldEmptyError);
        }

        public void SetErrorForAtLeastOneApplicationAreaIsRequired()
        {
            errorProvider.SetError(appliesToDirectivesCheckBox, StringResources.LogTemplateMustApplyToAtLeastOneArea);
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            cancelClicked = true;
        }
    }
}
