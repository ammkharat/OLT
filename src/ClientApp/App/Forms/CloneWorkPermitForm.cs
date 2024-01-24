using System;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CloneWorkPermitForm : BaseForm, ICloneWorkPermitFormView
    {
        private WorkPermit originalWorkPermit;
        private WorkPermit clonedWorkPermit;

        public CloneWorkPermitForm()
        {
            InitializeComponent();
            CloneWorkPermitFormPresenter presenter = new CloneWorkPermitFormPresenter(this, new Authorized());
            Load += presenter.HandleFormLoad;
            createButton.Click += presenter.HandleCreateButtonClick;
            workPermitSectionPicker.SelectAllSections += presenter.SelectAllSections;
            workPermitSectionPicker.DeselectAllSections += presenter.DeselectAllSections;
        }

        public string WorkPermitNumber
        {
            set 
            {
                SetTitle(StringResources.CloneWorkPermitFormTitle);
                SetHeader(string.Format(StringResources.CloneWorkPermitFormHeader,
                  value));

            }
        }

        private void SetHeader(string header)
        {
            titleLabel.Text = header;
        }

        public WorkPermit OriginalWorkPermit
        {
            get
            {
                return originalWorkPermit;
            }
            set
            {
                originalWorkPermit = value;
            }
        }
        public WorkPermit ClonedWorkPermit
        {
            get
            {
                return clonedWorkPermit;
            }
            set
            {
                clonedWorkPermit = value;
            }
        }

        public bool ShowCommunicationMethod
        {
            get { return workPermitSectionPicker.ShowCommunicationMethod;  }
            set { workPermitSectionPicker.ShowCommunicationMethod = value; }
        }

        public bool ShowTools
        {
            get { return workPermitSectionPicker.ShowTools; }
            set { workPermitSectionPicker.ShowTools = value; }
        }

        public bool ShowRadiation
        {
            get { return workPermitSectionPicker.ShowRadiation; }
            set { workPermitSectionPicker.ShowRadiation = value; }
        }

        public bool ShowAsbestos
        {
            get { return workPermitSectionPicker.ShowAsbestos; }
            set { workPermitSectionPicker.ShowAsbestos = value; }
        }

        #region Options

        public bool ClonePermitTypeAttributes
        {
            get { return workPermitSectionPicker.PermitTypeAttributesChecked; }
            set { workPermitSectionPicker.PermitTypeAttributesChecked = value; }
        }

        public bool CloneAdditionalForms
        {
            get { return workPermitSectionPicker.AdditionalFormsChecked; }
            set { workPermitSectionPicker.AdditionalFormsChecked = value; }
        }

        public bool CloneLocationJobSpecifics
        {
            get { return workPermitSectionPicker.LocationJobSpecificsChecked; }
            set { workPermitSectionPicker.LocationJobSpecificsChecked = value; }
        }
        
        public bool CloneTools
        {
            get { return workPermitSectionPicker.ToolsChecked; }
            set { workPermitSectionPicker.ToolsChecked = value; }
        }

        public bool CloneEquipmentPreparationCondition
        {
            get { return workPermitSectionPicker.EquipmentPreparationConditionChecked; }
            set { workPermitSectionPicker.EquipmentPreparationConditionChecked = value; }
        }

        public bool CloneJobWorksitePreparation
        {
            get { return workPermitSectionPicker.JobWorksitePreparationChecked; }
            set { workPermitSectionPicker.JobWorksitePreparationChecked = value; }
        }

        public bool CloneCommunicationMethod
        {
            get { return workPermitSectionPicker.CommunicationMethodChecked; }
            set { workPermitSectionPicker.CommunicationMethodChecked = value; }
        }

        public bool CloneRadiationInformation
        {
            get { return workPermitSectionPicker.RadiationInformationChecked; }
            set { workPermitSectionPicker.RadiationInformationChecked = value; }
        }

        public bool CloneAsbestos
        {
            get { return workPermitSectionPicker.AsbestosChecked; }
            set { workPermitSectionPicker.AsbestosChecked = value; }
        }

        public bool CloneFireConfinedSpaceRequirements
        {
            get { return workPermitSectionPicker.FireConfinedSpaceProtectionRequirementsChecked; }
            set { workPermitSectionPicker.FireConfinedSpaceProtectionRequirementsChecked = value; }
        }

        public bool CloneRespiratoryProtectionRequirements
        {
            get { return workPermitSectionPicker.RespiratoryProtectionRequirementsChecked; }
            set { workPermitSectionPicker.RespiratoryProtectionRequirementsChecked = value; }
        }

        public bool CloneSpecialPPERequirements
        {
            get { return workPermitSectionPicker.SpecialPpeRequirementsChecked; }
            set { workPermitSectionPicker.SpecialPpeRequirementsChecked = value; }
        }

        public bool CloneSpecialPrecautionsOrConsiderations
        {
            get { return workPermitSectionPicker.SpecialPrecautionsConsiderationsChecked; }
            set { workPermitSectionPicker.SpecialPrecautionsConsiderationsChecked = value; }
        }

        public bool CloneGasTests
        {
            get { return workPermitSectionPicker.GasTestInformationChecked; }
            set { workPermitSectionPicker.GasTestInformationChecked = value; }
        }

        public bool CloneNotificationAuthorization
        {
            get { return workPermitSectionPicker.NotificationsAuthorizationsChecked; }
            set { workPermitSectionPicker.NotificationsAuthorizationsChecked = value; }
        }

        public bool CloneMiscellaneous
        {
            get { return workPermitSectionPicker.MiscellaneousChecked; }
            set { workPermitSectionPicker.MiscellaneousChecked = value; }
        }

        #endregion

        #region Permission-Related

        public bool ClonePermitTypeAttributesEnabled
        {
            set { workPermitSectionPicker.PermitTypeAttributesEnabled = value; }
        }

        public bool CloneAdditionalFormsEnabled
        {
            set { workPermitSectionPicker.AdditionalFormsEnabled = value; }
        }

        public bool CloneLocationJobSpecificsEnabled
        {
            set { workPermitSectionPicker.LocationJobSpecificsEnabled = value; }
        }

        public bool CloneToolsEnabled
        {
            set { workPermitSectionPicker.ToolsEnabled = value; }
        }

        public bool CloneEquipmentPreparationConditionEnabled
        {
            set { workPermitSectionPicker.EquipmentPreparationConditionEnabled = value; }
        }

        public bool CloneJobWorksitePreparationEnabled
        {
            set { workPermitSectionPicker.JobWorksitePreparationEnabled = value; }
        }

        public bool CloneCommunicationMethodEnabled
        {
            set { workPermitSectionPicker.CommunicationMethodEnabled = value; }
        }

        public bool CloneRadiationInformationEnabled
        {
            set { workPermitSectionPicker.RadiationInformationEnabled = value; }
        }

        public bool CloneAsbestosEnabled
        {
            set { workPermitSectionPicker.AsbestosEnabled = value; }
        }

        public bool CloneFireConfinedSpaceRequirementsEnabled
        {
            set { workPermitSectionPicker.FireConfinedSpaceProtectionRequirementsEnabled = value; }
        }

        public bool CloneRespiratoryProtectionRequirementsEnabled
        {
            set { workPermitSectionPicker.RespiratoryProtectionRequirementsEnabled = value; }
        }

        public bool CloneSpecialPPERequirementsEnabled
        {
            set { workPermitSectionPicker.SpecialPpeRequirementsEnabled = value; }
        }

        public bool CloneSpecialPrecautionsOrConsiderationsEnabled
        {
            set { workPermitSectionPicker.SpecialPrecautionsConsiderationsEnabled = value; }
        }

        public bool CloneGasTestsEnabled
        {
            set { workPermitSectionPicker.GasTestInformationEnabled = value; }
        }

        public bool CloneNotificationAuthorizationEnabled
        {
            set { workPermitSectionPicker.NotificationsAuthorizationsEnabled = value; }
        }

        public bool CloneMiscellaneousEnabled
        {
            set { workPermitSectionPicker.MiscellaneousEnabled = value; }
        }

        #endregion

        private void SetTitle(string title)
        {
            Text = title;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (ConfirmCancelDialog()) { Close(); }
        }
    }
}