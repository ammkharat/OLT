using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Annotations;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class DeviationAlertCopyLastResponseForm : BaseForm, IDeviationAlertResponseView
    {
        private readonly DomainSummaryGrid<DeviationAlertResponseReasonCodeAssignment> assignmentGrid;
        private RestrictionLocationItem lastSelectedlLocationItem;

        public DeviationAlertCopyLastResponseForm(DeviationAlert deviationAlert, bool canEditComments, bool canRespond, List<DeviationAlertDTO> selectedItems)
        {
            InitializeComponent();
            //InitializePresenter(deviationAlert, canEditComments, canRespond);

            assignmentGrid = new DomainSummaryGrid<DeviationAlertResponseReasonCodeAssignment>(
                new DeviationAlertResponseReasonCodeAssignmentGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty)
                                 {Dock = DockStyle.Fill};

            assignmentGrid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(assignmentGrid);

            InitializePresenter(deviationAlert, canEditComments, canRespond, selectedItems);

        }


        private void InitializePresenter(DeviationAlert deviationAlert, bool canEditComments, bool canRespond, List<DeviationAlertDTO> selectedItems)
        {
            copyLastResponseButton.Visible = false;

            DeviationAlertResponsePresenter presenter = 
                new DeviationAlertResponsePresenter(this, deviationAlert, canEditComments, canRespond, selectedItems);

        
            Load += presenter.HandleLoad;
            
            saveAndCloseButton.Click += presenter.SaveAndCloseButton_Click;
            cancelButton.Click += presenter.CancelButton_Click;

            //newButton.Click += presenter.NewButton_Click;
            //editButton.Click += presenter.EditButton_Click;
            //deleteButton.Click += presenter.DeleteButton_Click;
            
            copyLastResponseButton.Click += presenter.CopyLastResponseButton_Click;
            
           // copyLastResponseButton.PerformClick();

            presenter.CopyLastResponseButton_Click();

        }
        
        public string StartDate
        {
            set {  }
        }

        public string EndDate
        {
            set { }
        }

        public string TargetTagName
        {
            set {  }
        }

        public string MeasuredTagName
        {
            set {}
        }

        public string TargetValue
        {
            set { }
        }

        public string MeasuredValue
        {
            set {  }
        }

        public string SummaryDeviationValue
        {
            set {  }
        }

        public string SummaryTotalAssigned
        {
            set {  }
        }

        public string SummaryAmountRemainingToBeAssigned
        {
            set {  }
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
            get { return ""; }
            set {  }
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
            //errorProvider.SetError(summaryAmountRemainingToBeAssignedTextBox, message);            
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
            //commentsTextBox.ReadOnly = !canEditComments;            

            //newButton.Enabled = canRespond;
            //editButton.Enabled = canRespond;
            //deleteButton.Enabled = canRespond;
            //copyLastResponseButton.Enabled = canRespond;
        }

        private void DeviationAlertCopyLastResponseForm_Load(object sender, EventArgs e)
        {

        }

       
    }
}