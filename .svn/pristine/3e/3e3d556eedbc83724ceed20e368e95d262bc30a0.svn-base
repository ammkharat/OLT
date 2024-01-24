using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class RestrictionDefinitionForm : BaseForm, IRestrictionDefinitionFormView
    {
        private ISingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;
        private ITagSearchFormView tagSelectorFormView;
        private bool viewEditHistoryEnabled;
        
        public RestrictionDefinitionForm() : this(null)
        {
        }

        public RestrictionDefinitionForm(RestrictionDefinition definition)
        {
            Initialize();
            RegisterRadioGroupEventHandlers();
            RestrictionDefinitionFormPresenter presenter = CreatePresenter(definition);
            RegisterEventHandlersOnPresenter(presenter);
            
        }

        private void RegisterRadioGroupEventHandlers()
        {
            productionTargetValueRadioButton.Click += ProductionTargetTypeChanged;
            productionTargetValueRadioButton.CheckedChanged += ProductionTargetTypeChanged;

            productionTargetValueNumericBox.Click += ProductionTargetValueSelected;
            productionTargetValueNumericBox.Enter += ProductionTargetValueSelected;

            productionTargetTagRadioButton.Click += ProductionTargetTypeChanged;
            productionTargetTagRadioButton.CheckedChanged += ProductionTargetTypeChanged;

            searchProductionTargetTagButton.Click += ProductionTargetTagSelected;
            refreshProductionTargetTagValueButton.Click += ProductionTargetTagSelected;
        }

        private void ProductionTargetTypeChanged(object sender, EventArgs e)
        {
            UpdateControlsBasedOnProductionTargetType(productionTargetValueRadioButton.Checked);
        }

        private void ProductionTargetValueSelected(object sender, EventArgs e)
        {
            UpdateControlsBasedOnProductionTargetType(true);
        }

        private void ProductionTargetTagSelected(object sender, EventArgs e)
        {
            UpdateControlsBasedOnProductionTargetType(false);
        }

        private void UpdateControlsBasedOnProductionTargetType(bool isTargetValue)
        {
            productionTargetValueRadioButton.CheckedChanged -= ProductionTargetTypeChanged;
            productionTargetTagRadioButton.CheckedChanged -= ProductionTargetTypeChanged;

            productionTargetValueRadioButton.Checked = isTargetValue;
            productionTargetTagRadioButton.Checked = !isTargetValue;

            productionTargetValueRadioButton.CheckedChanged += ProductionTargetTypeChanged;
            productionTargetTagRadioButton.CheckedChanged += ProductionTargetTypeChanged;

            if (isTargetValue)
            {
                ProductionTargetTagInfo = null;
            }
            else
            {
                ProductionTargetValue = null;
            }
        }

        private RestrictionDefinitionFormPresenter CreatePresenter(RestrictionDefinition definition)
        {
            if (definition == null)
            {
                return new RestrictionDefinitionFormPresenter(this);
            }
            return new RestrictionDefinitionFormPresenter(this, definition);
        }

        private void Initialize()
        {
            InitializeComponent();
            functionalLocationSelectorForm =
                new SingleSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter());
            tagSelectorFormView = new TagSearchForm(false, false);
        }
      
        private void RegisterEventHandlersOnPresenter(RestrictionDefinitionFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;

            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;

            functionalLocationButton.Click += presenter.HandleFunctionalLocationButtonClick;
            searchMeasurementTagButton.Click += presenter.HandleSearchMeasurementTagButtonClick;
            refreshMeasurementTagValueButton.Click += presenter.HandleRefreshMeasurementTagValueButtonClick;
            searchProductionTargetTagButton.Click += presenter.HandleSearchProductionTargetTagButtonClick;
            refreshProductionTargetTagValueButton.Click += presenter.HandleRefreshProductionTargetTagValueButtonClick;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;
        }

        public DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector()
        {
            DialogResult result = functionalLocationSelectorForm.ShowDialog(this);
            return new DialogResultAndOutput<FunctionalLocation>(result, functionalLocationSelectorForm.SelectedFunctionalLocation);
        }

        public DialogResultAndOutput<TagInfo> ShowTagSelector()
        {
            DialogResult result = tagSelectorFormView.ShowDialog(this);
            return new DialogResultAndOutput<TagInfo>(result, tagSelectorFormView.SelectedTag);
        }

        public User Author
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public DateTime CreateDateTime
        {
            set { lastModifiedDateAuthorHeader.LastModifiedDate = value; }
            get { return lastModifiedDateAuthorHeader.LastModifiedDate; }
        }

        public new string Name
        {
            get { return nameTextBox.Text.Trim(); }
            set { nameTextBox.Text = value; }
        }

        public string Description
        {
            get { return descriptionTextBox.Text.Trim(); }
            set { descriptionTextBox.Text = value; }
        }

        //DMND0010124 mangesh
        public string HourFrequency
        {
            get { return Convert.ToString(hourComboBox.SelectedItem); }
            set { hourComboBox.SelectedItem = value; }
        }

        public FunctionalLocation FunctionalLocation
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
                    functionalLocationTextBox.Tag = value;
                }
            }
        }
        
        public TagInfo MeasurementTagInfo
        {
            get { return measurementTagInfoTextBox.Tag as TagInfo; }
            set
            {
                if(value != null)
                {
                    measurementTagInfoTextBox.Text = string.Format("{0} ({1})", value.Name, value.Description);
                    measurementTagInfoTextBox.Tag = value;
                }
                else
                {
                    measurementTagInfoTextBox.Text = string.Empty;
                    measurementTagInfoTextBox.Tag = null;
                }
            }
        }

        public bool IsProductionTargetTypeValue
        {
            set
            {
                if (value)
                {
                    productionTargetValueRadioButton.Checked = true;
                }
                else
                {
                    productionTargetTagRadioButton.Checked = true;
                }
            }
        }

        public string MeasurementTagValue
        {
            set { measurementTagValueTextBox.Text = value; }
        }

        public bool RefreshMeasurmentTagValueEnabled
        {
            set { refreshMeasurementTagValueButton.Enabled = value; }
        }
        //Added by Mukesh for RITM0219490
        public int? ToleranceValue {

            get
            {
                object value = toleranceValueNumericBox.Value;

                if (value == DBNull.Value)
                {
                    return null;
                }

                if (value is int)
                {
                    return (int)value;
                }

                double? doubleValue = (double?)value;
                if (!doubleValue.HasValue)
                {
                    return null;
                }

                return Convert.ToInt32(doubleValue.Value);
            }
            set
            {
                toleranceValueNumericBox.Value = value;
            }
        
        
        }
        //End
        public int? ProductionTargetValue
        {
            get
            {
                object value = productionTargetValueNumericBox.Value;

                if (value == DBNull.Value)
                {
                    return null;
                }

                if (value is int)
                {
                    return (int)value;
                }

                double? doubleValue = (double?)value;
                if (!doubleValue.HasValue)
                {
                    return null;
                }

                return Convert.ToInt32(doubleValue.Value);                
            }
            set
            {
                productionTargetValueNumericBox.Value = value;
            }
        }

        public TagInfo ProductionTargetTagInfo
        {
            get { return productionTargetTagInfoTextBox.Tag as TagInfo; }
            set
            {
                if (value != null)
                {
                    productionTargetTagInfoTextBox.Text = string.Format("{0} ({1})", value.Name, value.Description);
                    productionTargetTagInfoTextBox.Tag = value;
                }
                else
                {
                    productionTargetTagInfoTextBox.Text = string.Empty;
                    productionTargetTagInfoTextBox.Tag = null;
                    productionTargetTagValueTextBox.Text = string.Empty;
                }
            }
        }

        public string ProductionTargetTagValue
        {
            set { productionTargetTagValueTextBox.Text = value; }
        }

        public bool RefreshProductionTargetTagValueEnabled
        {
            set { refreshProductionTargetTagValueButton.Enabled = value; }
        }

        public bool IsActive
        {
            get { return !temporarilyInactiveCheckBox.Checked; }
            set { temporarilyInactiveCheckBox.Checked = !value; }
        }

        public bool IsActiveCheckBoxEnabled
        {
            get { return temporarilyInactiveCheckBox.Enabled; }
            set { temporarilyInactiveCheckBox.Enabled = value; }
        }

        public bool HideDeviationAlerts
        {
            get { return hideDeviationAlertsCheckBox.Checked; }
            set { hideDeviationAlertsCheckBox.Checked = value; }
        }

        public void ClearErrorProviders()
        {
            nameErrorProvider.Clear();
            descriptionErrorProvider.Clear();
            functionalLocationErrorProvider.Clear();
            measurementTagInfoErrorProvider.Clear();
            productionTargetValueErrorProvider.Clear();
            productionTargetTagErrorProvider.Clear(); 
            frequencyErrorProvider.Clear(); //DMND0010124 mangesh
        }

        public void ShowNameIsEmptyError()
        {
            nameErrorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        //DMND0010124 mangesh
        public void ShowHourFrequencyIsEmptyError()
        {
            frequencyErrorProvider.SetError(hourComboBox, StringResources.HourFrequencyEmptyError);
        }
        
        public void ShowDescriptionIsEmptyError()
        {
            descriptionErrorProvider.SetError(descriptionTextBox, StringResources.DescriptionEmptyError);
        }

        public void ShowNoFunctionalLocationsSelectedError()
        {
            functionalLocationErrorProvider.SetError(functionalLocationTextBox, StringResources.FieldEmptyError);
        }

        public void ShowNoMeasurementTagInfoSelectedError()
        {
            measurementTagInfoErrorProvider.SetError(measurementTagInfoTextBox, StringResources.FieldEmptyError);
        }

        public void ShowNoProductionTargetValueError()
        {
            productionTargetValueErrorProvider.SetError(productionTargetValueNumericBox, StringResources.ProductionTargetValueOrTagRequiredError);
        }

        public void ShowNoProductionTargetTagInfoError()
        {
            productionTargetTagErrorProvider.SetError(productionTargetTagInfoTextBox, StringResources.ProductionTargetValueOrTagRequiredError);
        }

        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }

        public void ShowNameError(string message)
        {
            nameErrorProvider.SetError(nameTextBox, message);
        }

        public bool ViewEditHistoryEnabled
        {
            set
            {
                viewEditHistoryEnabled = value;
                viewEditHistoryButton.Enabled = value;
            }
        }

        private bool ControlsEnabled
        {
            set
            {
                saveAndCloseButton.Enabled = value;
                cancelButton.Enabled = value;

                functionalLocationButton.Enabled = value;
                searchMeasurementTagButton.Enabled = value;
                refreshMeasurementTagValueButton.Enabled = value;
                searchProductionTargetTagButton.Enabled = value;
                refreshProductionTargetTagValueButton.Enabled = value;
                viewEditHistoryButton.Enabled = value && viewEditHistoryEnabled;

                productionTargetValueRadioButton.Enabled = value;
                productionTargetTagRadioButton.Enabled = value;

                nameTextBox.Enabled = value;
                descriptionTextBox.Enabled = value;
                productionTargetValueNumericBox.Enabled = value;
                temporarilyInactiveCheckBox.Enabled = value;
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
    }
}