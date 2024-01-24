using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraEditors.Senders;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditCustomFieldForm : BaseForm, IAddEditCustomFieldFormView
    {
        private readonly AddEditCustomFieldFormPresenter presenter;
        private bool cancelClicked;
        private ITagSearchFormView tagSelectorFormView;
        private string hiddenFieldName;
        private bool isEdit;

        public AddEditCustomFieldForm(CustomField editObject)
        {
            InitializeComponent();
            isEdit = editObject == null ? false : true;

            presenter = new AddEditCustomFieldFormPresenter(this, editObject);
            RegisterEvents();

            TurnOffDeletedTagIndicators();
        }

        private void RegisterEvents()
        {
            Load += presenter.Form_Load;
            okButton.Click += presenter.OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            tagSearchButton.Click += presenter.TagSearchButton_Click;
            tagRefreshButton.Click += presenter.TagRefreshButton_Click;
            tagRemoveButton.Click += presenter.TagRemoveButton_Click;
            FormClosing += presenter.Form_Close;
            customFieldTypeComboBox.SelectedValueChanged += presenter.CustomFieldType_Changed;
            addDropDownValueButton.Click += presenter.AddDropDownValueButton_Click;
            editDropDownValueButton.Click += presenter.EditDropDownValueButton_Click;
            deleteDropDownValueButton.Click += presenter.DeleteDropDownValueButton_Click;

            phdLinkTypeOffRadioButton.CheckedChanged += phdLinkTypeRadioButton_CheckedChanged;

            //rangeCheckBox.CheckedChanged += rangeCheckBox_CheckedChanged; // Custom Field Changes By : Swapnil Patki
            //GreaterThanRadioButton.CheckedChanged += GreaterThanRadioButton_CheckedChanged; // Custom Field Changes By : Swapnil Patki
            //LessThanRadioButton.CheckedChanged += LessThanRadioButton_CheckedChanged; // Custom Field Changes By : Swapnil Patki
            //RangeRadioButton.CheckedChanged += RangeRadioButton_CheckedChanged; // Custom Field Changes By : Swapnil Patki
            GreaterThanRadioButton.CheckedChanged += RadioButtonCheckedChangedInRangePanel;// Custom Field Changes By : Swapnil Patki
            LessThanRadioButton.CheckedChanged += RadioButtonCheckedChangedInRangePanel;// Custom Field Changes By : Swapnil Patki
            RangeRadioButton.CheckedChanged += RadioButtonCheckedChangedInRangePanel;// Custom Field Changes By : Swapnil Patki
            rangeCheckBox.CheckedChanged += RadioButtonCheckedChangedInRangePanel; // Custom Field Changes By : Swapnil Patki
        }

        // Start Custom Field Changes By : Swapnil Patki
        //private void RangeRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    greaterthanTextBox.Enabled = false;
        //    greaterthanTextBox.Text = string.Empty;
        //    lessthanTextBox.Enabled = false;
        //    lessthanTextBox.Text = string.Empty;
        //    maxvalueTextBox.Enabled = true;
        //    minvalueTextBox.Enabled = true;
        //}

        //void LessThanRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    greaterthanTextBox.Enabled = false;
        //    greaterthanTextBox.Text = string.Empty;
        //    lessthanTextBox.Enabled = true;
        //    maxvalueTextBox.Enabled = false;
        //    minvalueTextBox.Enabled = false;
        //    maxvalueTextBox.Text = string.Empty;
        //    minvalueTextBox.Text = string.Empty;
        //}

        //private void GreaterThanRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    greaterthanTextBox.Enabled = true;
        //    lessthanTextBox.Enabled = false;
        //    lessthanTextBox.Text = string.Empty;
        //    maxvalueTextBox.Enabled = false;
        //    minvalueTextBox.Enabled = false;
        //    maxvalueTextBox.Text = string.Empty;
        //    minvalueTextBox.Text = string.Empty;
        //}

        void RadioButtonCheckedChangedInRangePanel(object sender, EventArgs e)
        {
            //foreach (TextBox tb in oltPanel1.Controls.OfType<TextBox>())
            //{
            //    tb.Text = isEdit == false ? String.Empty : tb.Text;
            //}
            greaterthanTextBox.Enabled = GreaterThanRadioButton.Checked;
            lessthanTextBox.Enabled = LessThanRadioButton.Checked;
            maxvalueTextBox.Enabled = RangeRadioButton.Checked;
            minvalueTextBox.Enabled = RangeRadioButton.Checked;
            rangeGroupBox.Enabled = rangeCheckBox.Checked;

            greaterthanTextBox.Text = GreaterThanRadioButton.Checked ? greaterthanTextBox.Text : string.Empty;
            lessthanTextBox.Text = LessThanRadioButton.Checked ? lessthanTextBox.Text : string.Empty;
            maxvalueTextBox.Text = RangeRadioButton.Checked ? maxvalueTextBox.Text : string.Empty;
            minvalueTextBox.Text = RangeRadioButton.Checked ? minvalueTextBox.Text : string.Empty;
        }

        //void rangeCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    rangeGroupBox.Enabled = rangeCheckBox.Checked;
        //}
        // End Custom Field Changes By : Swapnil Patki
        // Added by Mukesh:-RITM0238302
        void phdLinkTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //tagGroupBox.Enabled = !phdLinkTypeOffRadioButton.Checked;         //RITM0350921 :  by Vibhor
           
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            cancelClicked = true;
            presenter.CancelButton_Click(sender, e);
        }

        public bool RefreshButtonEnabled
        {
            set { tagRefreshButton.Enabled = value; }
        }

        public List<CustomFieldType> Types
        {
            set { customFieldTypeComboBox.DataSource = value; }
        }

        public CustomFieldType Type
        {
            get { return (CustomFieldType) customFieldTypeComboBox.SelectedItem; }
            set { customFieldTypeComboBox.SelectedItem = value; }
        }

        public CustomFieldPhdLinkType PhdLinkType
        {
            get
            {
                if (phdLinkTypeOffRadioButton.Checked)
                    return CustomFieldPhdLinkType.Off;
                if (phdLinkTypeReadRadioButton.Checked)
                    return CustomFieldPhdLinkType.Read;
                return CustomFieldPhdLinkType.Write;
            }
            set
            {
                if (value == CustomFieldPhdLinkType.Off)
                {
                    phdLinkTypeOffRadioButton.Checked = true;
                }
                else if (value == CustomFieldPhdLinkType.Read)
                {
                    phdLinkTypeReadRadioButton.Checked = true;
                }
                else
                {
                    phdLinkTypeWriteRadioButton.Checked = true;
                }
            }
        }

        public CustomField ShowDialogAndReturnCustomField(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : presenter.EditObject;
        }

        public string FieldName
        {
            get
            {
                if (nameTextBox.Text == null)
                {
                    return nameTextBox.Text;
                }
                return nameTextBox.Text.Trim();
            }
            set { nameTextBox.Text = value; }
        }

        // Start Custom Field Changes By : Swapnil Patki

        public bool? IsActive
        {   
            get { return rangeCheckBox.Checked; }
            set
            {
                rangeCheckBox.Checked = value.GetValueOrDefault(false);
                rangeGroupBox.Enabled = value.GetValueOrDefault(false);
            }
        }

        public decimal? MinRangeValue
        {
            get {
                if (minvalueTextBox.Text == string.Empty)
                {
                    return null;
                }
                return Convert.ToDecimal(minvalueTextBox.Text); }
            set
            {
                minvalueTextBox.DecimalValue = value;
                if (minvalueTextBox.DecimalValue != null)
                {
                    RangeRadioButton.Checked = true;
                    minvalueTextBox.Enabled = true;
                }
            }
        }
       
        public decimal? MaxRangeValue//swapnil
        {
            get {
                 
                if (maxvalueTextBox.Text == string.Empty)
                {
                    return null;
                }
                return Convert.ToDecimal(maxvalueTextBox.Text); }
            set
            {
                maxvalueTextBox.DecimalValue = value;
                maxvalueTextBox.Enabled = true;
            }
        }

        public decimal? GreaterThanValue //swapnil
        {
            get
            {
                if (greaterthanTextBox.Text == string.Empty)
                {
                    return null;
                }
                return Convert.ToDecimal(greaterthanTextBox.Text);
            }
            set
            {
                greaterthanTextBox.DecimalValue = value;
                if (greaterthanTextBox.DecimalValue != null)
                {
                    GreaterThanRadioButton.Checked = true;
                    greaterthanTextBox.Enabled = true;
                }
            }
        }

        public decimal? LessThanValue //swapnil
        {
            get
            {
                if (lessthanTextBox.Text == string.Empty)
                {
                    return null;
                }
                return Convert.ToDecimal(lessthanTextBox.Text);
            }
            set
            {
                lessthanTextBox.DecimalValue = value;
                if (lessthanTextBox.DecimalValue != null)
                {
                    LessThanRadioButton.Checked = true;
                    lessthanTextBox.Enabled = true;
                }
            }
        }
        // End Custom Field Changes By : Swapnil Patki

        public string HiddenFieldName
        {
            get { return hiddenFieldName; }
            set { hiddenFieldName = value; }
        }

        public TagInfo TagInfo
        {
            get { return (TagInfo) tagInfoTextBox.Tag; }
            set
            {
                if (value != null)
                {
                    tagInfoTextBox.Text = string.Format("{0} ({1})", value.Name, value.Description);
                    tagInfoTextBox.Tag = value;
                }
                else
                {
                    tagInfoTextBox.Text = string.Empty;
                    tagInfoTextBox.Tag = null;
                }
            }
        }

        public string TagValue
        {
            set { tagValueTextBox.Text = value; }
        }

        public bool DropDownListEditingEnabled
        {
            set { dropDownListGroupBox.Enabled = value; }
        }

        // Start Custom Field Changes By : Swapnil Patki
        //public bool DisableRangeGroupBox
        //{
        //    set { rangeGroupBox.Enabled = true; }
        //}
        // End Custom Field Changes By : Swapnil Patki

        public CustomFieldDropDownValue SelectedDropDownValue
        {
            get { return (CustomFieldDropDownValue) dropDownValueListBox.SelectedItem; }
            set { dropDownValueListBox.SelectedItem = value; }
        }

        public List<CustomFieldDropDownValue> DropDownValues
        {
            set
            {
                dropDownValueListBox.DataSource = new List<CustomFieldDropDownValue>(value);
            }
        }

        public bool EditAndDeleteDropDownButtonsEnabled
        {
            set 
            { 
                editDropDownValueButton.Enabled = value;
                deleteDropDownValueButton.Enabled = value;
            }
        }

        public bool NameEditingEnabled { set { nameTextBox.Enabled = value; } }

        public bool PhdLinkTypeEditingEnabled
        {
            set
            {
                phdLinkTypeReadRadioButton.Enabled = value;
                phdLinkTypeWriteRadioButton.Enabled = value;
            }
        }

        public void ClearAllErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorForNoNameProvided()
        {
            errorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        public void SetErrorForDropDownValuesRequired()
        {
            errorProvider.SetError(dropDownValueListBox, StringResources.ValueRequiredError);
        }

        public bool ShowWarningForNonNumericTypeAndReturnUserResult()
        {
            DialogResult result = MessageBox.Show(this, StringResources.CustomFieldNonNumericWarning, StringResources.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return DialogResult.Yes == result;
        }

        public void SetErrorForWriteMustUseNumericType()
        {
            errorProvider.SetError(customFieldTypeComboBox, StringResources.CustomFieldWriteTypeInvalid);
        }

        public void SetErrorForNoPhdTagSelected()
        {
            errorProvider.SetError(tagInfoTextBox, StringResources.CustomFieldReadWriteTagRequired);
        }

        public void SetErrorForNotAWriteTag()
        {
            errorProvider.SetError(tagInfoTextBox, StringResources.CustomFieldMustSelectWritableTag);
        }

        public void SetErrorForCustomFieldRange()
        {
            errorProvider.SetError(rangeGroupBox, StringResources.CustomFieldMustBeInRange);
        }

        // Added by Mukesh:-RITM0238302
        public bool DisableRangeGroupBox
        {
            set
            {
                rangeCheckBox.Enabled = value;
                oltPanel1.Enabled = value;
                
            }
        }
        public void SetErrorForStringTagMustUseTextType()
        {
            errorProvider.SetError(tagInfoTextBox, StringResources.InvalidTagTypeSelectd);
        }

        public DialogResultAndOutput<TagInfo> ShowTagSelector()
        {
            tagSelectorFormView = new TagSearchForm(true, phdLinkTypeWriteRadioButton.Checked);
            DialogResult result = tagSelectorFormView.ShowDialog(this);
            return new DialogResultAndOutput<TagInfo>(result, tagSelectorFormView.SelectedTag);
        }

        public void DisablePlantHistorianSection()
        {
            PlantHistorianControlsEnabled = false;
        }

        private bool PlantHistorianControlsEnabled
        {
            set
            {
                tagRefreshButton.Enabled = value;
                tagRemoveButton.Enabled = value;
                tagSearchButton.Enabled = value;
            }
        }

        public void DisableControlsForBackgroundWorker()
        {
            ControlsEnabled = false;
        }

        public void EnableControlsForBackgroundWorker()
        {
            ControlsEnabled = true;
        }

        public void TurnOffDeletedTagIndicators()
        {
            tagInfoTextBox.BackColor = tagValueTextBox.BackColor;
            tagDeletedLabel.Visible = false;
        }

        public void IndicateThatTagInfoIsDeleted()
        {
            tagInfoTextBox.BackColor = Color.Red;
            tagDeletedLabel.Visible = true;
        }

        private bool ControlsEnabled
        {
            set
            {
                okButton.Enabled = value;
                cancelButton.Enabled = value;

                nameTextBox.Enabled = value;
                PlantHistorianControlsEnabled = value;
            }
        }

        public CustomFieldDropDownValue LaunchAddEditValueForm(CustomFieldDropDownValue editObject)
        {
            AddEditCustomFieldDropDownValueForm form = new AddEditCustomFieldDropDownValueForm(editObject);
            return form.ShowDialogAndReturnValue(this);
        }

        public void SelectFirstDropDownValue()
        {
            if (dropDownValueListBox.Items.Count > 0)
            {
                dropDownValueListBox.SelectedIndex = 0;    
            }            
        }

    }
}