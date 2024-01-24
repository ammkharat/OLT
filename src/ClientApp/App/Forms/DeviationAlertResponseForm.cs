using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class DeviationAlertResponseForm : BaseForm, IDeviationAlertResponseView
    {
        private readonly DomainSummaryGrid<DeviationAlertResponseReasonCodeAssignment> assignmentGrid;
        private RestrictionLocationItem lastSelectedlLocationItem;

        public DeviationAlertResponseForm(DeviationAlert deviationAlert, bool canEditComments, bool canRespond)
        {
            InitializeComponent();
            InitializePresenter(deviationAlert, canEditComments, canRespond);

            assignmentGrid = new DomainSummaryGrid<DeviationAlertResponseReasonCodeAssignment>(
                new DeviationAlertResponseReasonCodeAssignmentGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty)
                                 {Dock = DockStyle.Fill};

            assignmentGrid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(assignmentGrid);
        }

        private void InitializePresenter(DeviationAlert deviationAlert, bool canEditComments, bool canRespond)
        {
            DeviationAlertResponsePresenter presenter = 
                new DeviationAlertResponsePresenter(this, deviationAlert, canEditComments, canRespond);

            Load += presenter.HandleLoad;
            
            saveAndCloseButton.Click += presenter.SaveAndCloseButton_Click;
            cancelButton.Click += presenter.CancelButton_Click;

            newButton.Click += presenter.NewButton_Click;
            editButton.Click += presenter.EditButton_Click;
            deleteButton.Click += presenter.DeleteButton_Click;
            copyLastResponseButton.Click += presenter.CopyLastResponseButton_Click;
        }

        public string StartDate
        {
            set { startDateData.Text = value; }
        }

        public string EndDate
        {
            set { endDateData.Text = value; }
        }

        public string TargetTagName
        {
            set { targetTagData.Text = value; }
        }

        public string MeasuredTagName
        {
            set { measuredTagData.Text = value; }
        }

        public string TargetValue
        {
            set { targetTextBox.Text = value; }
        }

        public string MeasuredValue
        {
            set { measuredTextBox.Text = value; }
        }

        public string SummaryDeviationValue
        {
            set { summaryDeviationTextBox.Text = value; }
        }

        public string SummaryTotalAssigned
        {
            set { summaryTotalAssignedTextBox.Text = value; }
        }

        public string SummaryAmountRemainingToBeAssigned
        {
            set { summaryAmountRemainingToBeAssignedTextBox.Text = value; }
        }

        public List<DeviationAlertResponseReasonCodeAssignment> Assignments
        {
            set { assignmentGrid.Items = value; }
        }

        public DeviationAlertResponseReasonCodeAssignment SelectedAssignment
        {
            get { return assignmentGrid.SelectedItem; }
            set { assignmentGrid.SelectItemByReference(value);}
        }

        public string Comments
        {
            get { return commentsTextBox.Text; }
            set { commentsTextBox.Text = value; }
        }

        public DeviationAlertResponseReasonCodeAssignment OpenAssociationPresenter(RestrictionLocation restrictionLocation, DeviationAlertResponseReasonCodeAssignment assignment, DeviationAlert deviationAlert, int amountRemainingToBeAllocated)
        {
            DeviationReasonCodeAssignmentForm assignmentForm = new DeviationReasonCodeAssignmentForm(
                assignment, 
                deviationAlert, 
                amountRemainingToBeAllocated,
                restrictionLocation,
                lastSelectedlLocationItem);
            
            DialogResult result = assignmentForm.ShowDialog(this);
            DeviationAlertResponseReasonCodeAssignment newAssignment = null;
            if (result == DialogResult.OK)
            {
                newAssignment = assignmentForm.Assignment;
                lastSelectedlLocationItem = newAssignment.RestrictionLocationItem;
            }

            return newAssignment;
        }

        public void ClearAllErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorOnRemainingToBeAssigned(string message)
        {
            errorProvider.SetError(summaryAmountRemainingToBeAssignedTextBox, message);            
        }

        public void SetErrorOnGrid(string message)
        {
            errorProvider.SetError(gridPanel, message);
        }

        public void ShowNoLastResponseToCopyFrom()
        {
            OltMessageBox.Show(
               this,
               StringResources.DeviationAlertResponseNoLastResponseToCopyFromMessageBoxText,
               StringResources.DeviationAlertResponseNoLastResponseToCopyFromMessageBoxCaption,
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        public DialogResult ConfirmCopyLastResponseWhenAssignmentsExist()
        {
            return OltMessageBox.Show(
                this,
                StringResources.DeviationAlertResponseConfirmCopyLastResponseWhenAssignmentExistsMessageBoxText,
                StringResources.DeviationAlertResponseConfirmCopyLastResponseWhenAssignmentExistsMessageBoxCaption,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
        }

        public void EnableControls(bool canEditComments, bool canRespond)
        {
            commentsTextBox.ReadOnly = !canEditComments;            

            newButton.Enabled = canRespond;
            editButton.Enabled = canRespond;
            deleteButton.Enabled = canRespond;
            copyLastResponseButton.Enabled = canRespond;
        }

    }
}