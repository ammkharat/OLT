using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    /// <summary>
    /// This is the old close form used only in Sarnia and Denver.  All other sites use the CloseWithStatusForm.  
    /// This should go away when Sarnia and Denver go to the Pull model and have to line up with everyone else.
    /// </summary>
    public partial class WorkPermitCloseForm : BaseForm, IWorkPermitCloseFormView
    {
        public event EventHandler SubmitButtonClick;
        public event EventHandler CancelButtonClick;
        public event EventHandler CreateLogCheckedChanged;

        public WorkPermitCloseForm()
        {
            InitializeComponent();

            submitButton.Click += submitButton_Click;
            cancelButton.Click += cancelButton_Click;
            createLogCheckBox.CheckedChanged += createLogCheckBox_CheckedChanged;
        }

        public DateTime CreateDateTime
        {
            set { lastModifiedData.LastModifiedDate = value; }
            get { return lastModifiedData.LastModifiedDate; }
        }

        //ayman custom fields DMND0010030
        public void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries, bool reading)
        {
        }
        //ayman custom fields DMND0010030
        public void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField)
        {
        }
        //ayman custom fields DMND0010030
        public void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields, ActionItem respondTo)
        {
        }
        //ayman custom fields DMND0010030
        public void SetCustomFieldEntriesForTracker(List<ActionItemResponseTracker> customFieldEntries, List<CustomField> customFields)
        {
        }
        //ayman custom fields DMND0010030
        public void EnableCustomFieldsLabel(bool enable)
        {
        }
        //ayman action item reading
        public void EnableCustomFieldControl(bool enable)
        {
        }
        //ayman action item reading
        public void EnableCustomFieldControlForReading(bool enable)
        {
        }

        //ayman action item reading
        public void EnableTableLayoutPanel(bool enable)
        {
        }

        //ayman action item reading
        public void EnableCustomFieldAreaGroupBox(bool enable) //ayman action item reading
        {
        }

        //ayman action item reading
        public List<ActionItemResponseTracker> TrackerEntriesList
        {
            set
            {
            }
        }
        //ayman action item reading
        public List<ActionItemResponseTracker> TrackerList
        {
            set
            {
            }
        }
        //ayman action item reading
        public void SelectFirstCustomField()
        {
        }
        public List<ActionItemResponseForm.entriesText> GetEntriesTextForTracker()
        {
            return null;
        }
        //ayman action item reading
        public List<ActionItemResponseTracker> GetCustomFieldEntryTextForTracker(IEnumerable<CustomField> customfields)
        {
            return null;
        }

        public User Author
        {
            set { lastModifiedData.LastModifiedUser = value; }
        }

        public string Shift
        {
            set { shiftLabel.Text = value; }
        }

        public SimpleDomainObject SelectedStatus
        {
            get { return WorkPermitStatus.Complete; }
        }

        public string Comment
        {
            get { return commentTextBox.Text; }
        }

        public void DisableLogCreatedWithComments()
        {
            commentTextBox.Enabled = false;
        }

        public void EnableLogCreatedWithComments()
        {
            commentTextBox.Enabled = true;
        }

        
        
        //ayman custom fields DMND0010030
        public string GetCustomFieldEntryText(CustomFieldEntry entry)
        {
            return string.Empty;
        }
        public string GetCustomFieldEntryText(long field)
        {
            return string.Empty;
        }
        public void DisableControls()
        {
        }
        public void EnableControls()
        {
        }
        public void SetCustomFieldEntryText(CustomFieldEntry entry, string text)
        {
        }
        public void SetCustomFieldEntryTextForReading(List<ActionItemResponseTracker> entrieslist)
        {
        }



        public void EnableMakingAnOperatingEngineerLog()
        {
            makeLogAnOperatingEngineerCheckBox.Enabled = createLogCheckBox.Checked;
        }

        public void HideOperatingEngineerLogCheckbox()
        {
            makeLogAnOperatingEngineerCheckBox.Hide();
        }

        public string OperatingEngineerLogDisplayText
        {
            set { makeLogAnOperatingEngineerCheckBox.Text = value; }
        }

        public bool CreateLogChecked
        {
            set { createLogCheckBox.Checked = value; }
            get { return createLogCheckBox.Checked; }
        }

        public bool CreateLogEnabled
        {
            set { createLogCheckBox.Enabled = value; }
        }

        public string Description
        {
            set { descriptionTextBox.Text = value; }
        }

        public bool IsLogAnOperatingEngineeringLog
        {
            get
            {
                return makeLogAnOperatingEngineerCheckBox.Checked;
            }
            set
            {
                makeLogAnOperatingEngineerCheckBox.Checked = value;
            }
        }

        public string FormTitle
        {
            set { Text = value; }
        }

        public void HideDescription()
        {
            descriptionGroupBox.Hide();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (SubmitButtonClick != null)
            {
                SubmitButtonClick(sender, e);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClick != null)
            {
                CancelButtonClick(sender, e);
            }
        }

        private void createLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CreateLogCheckedChanged != null)
            {
                CreateLogCheckedChanged(sender, e);
            }
        }

        // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response
        public bool EnableActionItemImagePanel
        {
            get; set; }
    }
}
