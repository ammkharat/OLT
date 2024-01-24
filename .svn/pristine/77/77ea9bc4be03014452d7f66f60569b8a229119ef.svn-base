using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CopyWorkPermitForm : BaseForm, ICopyWorkPermitFormView
    {
        public CopyWorkPermitForm()
        {
            InitializeComponent();

            cancelButton.Click += cancelButton_Click;
        }

        public event EventHandler LoadView;
        public event EventHandler Copy;
        public event EventHandler Cancel;
        public event EventHandler SelectAllSections;
        public event EventHandler DeselectAllSections;

        public string WorkPermitNumber
        {
            set
            {
                Text = StringResources.CopyWorkPermitFormTitle;
                titleLabel.Text = string.Format(StringResources.CopyWorkPermitFormHeader,
                  value);
            }
        }

        public bool ToolsChecked
        {
            get { return workPermitSectionPicker.ToolsChecked; }
            set { workPermitSectionPicker.ToolsChecked = value; }
        }

        public bool EquipmentPreparationConditionChecked
        {
            get { return workPermitSectionPicker.EquipmentPreparationConditionChecked; }
            set { workPermitSectionPicker.EquipmentPreparationConditionChecked = value; }
        }

        public bool JobWorksitePreparationChecked
        {
            get { return workPermitSectionPicker.JobWorksitePreparationChecked; }
            set { workPermitSectionPicker.JobWorksitePreparationChecked = value; }
        }

        public bool RadiationInformationChecked
        {
            get { return workPermitSectionPicker.RadiationInformationChecked; }
            set { workPermitSectionPicker.RadiationInformationChecked = value; }
        }

        public bool AsbestosChecked
        {
            get { return workPermitSectionPicker.AsbestosChecked; }
            set { workPermitSectionPicker.AsbestosChecked = value; }
        }

        public bool FireConfinedSpaceRequirementsChecked
        {
            get { return workPermitSectionPicker.FireConfinedSpaceProtectionRequirementsChecked; }
            set { workPermitSectionPicker.FireConfinedSpaceProtectionRequirementsChecked = value; }
        }

        public bool RespiratoryProtectionRequirementsChecked
        {
            get { return workPermitSectionPicker.RespiratoryProtectionRequirementsChecked; }
            set { workPermitSectionPicker.RespiratoryProtectionRequirementsChecked = value; }
        }

        public bool SpecialPPERequirementsChecked
        {
            get { return workPermitSectionPicker.SpecialPpeRequirementsChecked; }
            set { workPermitSectionPicker.SpecialPpeRequirementsChecked = value; }
        }

        public bool SpecialPrecautionsOrConsiderationsChecked
        {
            get { return workPermitSectionPicker.SpecialPrecautionsConsiderationsChecked; }
            set { workPermitSectionPicker.SpecialPrecautionsConsiderationsChecked = value; }
        }

        public bool GasTestsChecked
        {
            get { return workPermitSectionPicker.GasTestInformationChecked; }
            set { workPermitSectionPicker.GasTestInformationChecked = value; }
        }

        public bool NotificationAuthorizationChecked
        {
            get { return workPermitSectionPicker.NotificationsAuthorizationsChecked; }
            set { workPermitSectionPicker.NotificationsAuthorizationsChecked = value; }
        }

        public bool MiscellaneousChecked
        {
            get { return workPermitSectionPicker.MiscellaneousChecked; }
            set { workPermitSectionPicker.MiscellaneousChecked = value; }
        }

        public bool CommunicationMethodChecked
        {
            get { return workPermitSectionPicker.CommunicationMethodChecked;  }
            set { workPermitSectionPicker.CommunicationMethodChecked = value; }
        }

        public bool ToolsEnabled
        {
            set { workPermitSectionPicker.ToolsEnabled = value; }
        }

        public bool ShowTools
        {
            set { workPermitSectionPicker.ShowTools = value; }
        }

        public bool ShowRadiation
        {
            set { workPermitSectionPicker.ShowRadiation = value; }
        }

        public bool ShowAsbestos
        {
            set { workPermitSectionPicker.ShowAsbestos = value; }
        }

        public bool EquipmentPreparationConditionEnabled
        {
            set { workPermitSectionPicker.EquipmentPreparationConditionEnabled = value; }
        }

        public bool JobWorksitePreparationEnabled
        {
            set { workPermitSectionPicker.JobWorksitePreparationEnabled = value; }
        }

        public bool RadiationInformationEnabled
        {
            set { workPermitSectionPicker.RadiationInformationEnabled = value; }
        }

        public bool AsbestosEnabled
        {
            set { workPermitSectionPicker.AsbestosEnabled = value; }
        }

        public bool FireConfinedSpaceRequirementsEnabled
        {
            set { workPermitSectionPicker.FireConfinedSpaceProtectionRequirementsEnabled = value; }
        }

        public bool RespiratoryProtectionRequirementsEnabled
        {
            set { workPermitSectionPicker.RespiratoryProtectionRequirementsEnabled = value; }
        }

        public bool SpecialPPERequirementsEnabled
        {
            set { workPermitSectionPicker.SpecialPpeRequirementsEnabled = value; }
        }

        public bool SpecialPrecautionsOrConsiderationsEnabled
        {
            set { workPermitSectionPicker.SpecialPrecautionsConsiderationsEnabled = value; }
        }

        public bool GasTestsEnabled
        {
            set { workPermitSectionPicker.GasTestInformationEnabled = value; }
        }

        public bool NotificationAuthorizationEnabled
        {
            set { workPermitSectionPicker.NotificationsAuthorizationsEnabled = value; }
        }

        public bool MiscellaneousEnabled
        {
            set { workPermitSectionPicker.MiscellaneousEnabled = value; }
        }

        public bool ShowCommunicationMethod
        {
            set { workPermitSectionPicker.ShowCommunicationMethod = value; }
        }

        public bool CommunicationMethodEnabled
        {
            set { workPermitSectionPicker.CommunicationMethodEnabled = value; }
        }

        public void CloseView()
        {
            Close();
        }

        public DialogResult ShowDialog(string text, string caption)
        {
            return OltMessageBox.Show(ActiveForm, text, caption);
        }

        private void CopyWorkPermitForm_Load(object sender, EventArgs e)
        {
            if(LoadView != null)
            {
                LoadView(sender, e);
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if(Copy != null)
            {
                Copy(sender, e);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                Cancel(sender, e);
            }
        }

        private void workPermitSectionPicker_SelectAllSections(object sender, EventArgs e)
        {
            if(SelectAllSections != null)
            {
                SelectAllSections(sender, e);
            }
        }

        private void workPermitSectionPicker_DeselectAllSections(object sender, EventArgs e)
        {
            if(DeselectAllSections != null)
            {
                DeselectAllSections(sender, e);
            }
        }
    }
}