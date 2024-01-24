using System;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class WorkPermitSectionPicker : UserControl
    {
        private static readonly string SELECT_ALL = StringResources.All;
        private static readonly string DESELECT_ALL = StringResources.None;

        /// <summary>
        /// Occurs when user wants to select All available sections.
        /// </summary>
        public event EventHandler SelectAllSections;

        /// <summary>
        /// Occurs when user wants to deselect All available sections.
        /// </summary>
        public event EventHandler DeselectAllSections;

        public WorkPermitSectionPicker()
        {
            InitializeComponent();

            string selectLabel = string.Format("{0}: ", StringResources.WorkPermitSectionPicker_SelectLabel);

            sectionSelectionLinkLabel1.Clear();
            sectionSelectionLinkLabel1.AddTextSegment(selectLabel);
            sectionSelectionLinkLabel1.AddLink(SELECT_ALL, FireSelectAllSectionsEvent);
            sectionSelectionLinkLabel1.AddTextSegment(", ");
            sectionSelectionLinkLabel1.AddLink(DESELECT_ALL, FireDeselectAllSectionsEvent);
        }

        [Browsable(false)]
        public bool PermitTypeAttributesChecked
        {
            get { return permitTypeAttributeCheckBox.Checked; }
            set { permitTypeAttributeCheckBox.Checked = value; }
        }

        public bool PermitTypeAttributesEnabled
        {
            set { permitTypeAttributeCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool AdditionalFormsChecked
        {
            get { return additionalFormsCheckBox.Checked; }
            set { additionalFormsCheckBox.Checked = value; }
        }

        public bool AdditionalFormsEnabled
        {
            set { additionalFormsCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool LocationJobSpecificsChecked
        {
            get { return locationCheckBox.Checked; }
            set { locationCheckBox.Checked = value; }
        }

        public bool LocationJobSpecificsEnabled
        {
            set { locationCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool ToolsChecked
        {
            get { return toolsCheckBox.Checked; }
            set { toolsCheckBox.Checked = value; }
        }

        public bool ToolsEnabled
        {
            set { toolsCheckBox.Enabled = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowTools
        {
            get { return toolsCheckBox.Visible; }
            set { toolsCheckBox.Visible = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowRadiation
        {
            get { return radiationInformationCheckBox.Visible; }
            set { radiationInformationCheckBox.Visible = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowAsbestos
        {
            get { return asbestosCheckBox.Visible; }
            set { asbestosCheckBox.Visible = value; }
        }

        [Browsable(false)]
        public bool EquipmentPreparationConditionChecked
        {
            get { return equipmentPreparationConditionCheckBox.Checked; }
            set { equipmentPreparationConditionCheckBox.Checked = value; }
        }

        public bool EquipmentPreparationConditionEnabled
        {
            set { equipmentPreparationConditionCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool JobWorksitePreparationChecked
        {
            get { return jobWorksitePreparationCheckBox.Checked; }
            set { jobWorksitePreparationCheckBox.Checked = value; }
        }

        public bool JobWorksitePreparationEnabled
        {
            set { jobWorksitePreparationCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool CommunicationMethodChecked
        {
            get { return communicationMethodCheckBox.Checked; }
            set { communicationMethodCheckBox.Checked = value; }
        }

        [Browsable(false)]
        public bool RadiationInformationChecked
        {
            get { return radiationInformationCheckBox.Checked; }
            set { radiationInformationCheckBox.Checked = value; }
        }

        public bool RadiationInformationEnabled
        {
            set { radiationInformationCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool AsbestosChecked
        {
            get { return asbestosCheckBox.Checked; }
            set { asbestosCheckBox.Checked = value; }
        }

        public bool AsbestosEnabled
        {
            set { asbestosCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool FireConfinedSpaceProtectionRequirementsChecked
        {
            get { return fireConfinedSpaceProtectionRequirementsCheckBox.Checked; }
            set { fireConfinedSpaceProtectionRequirementsCheckBox.Checked = value; }
        }

        public bool FireConfinedSpaceProtectionRequirementsEnabled
        {
            set { fireConfinedSpaceProtectionRequirementsCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool RespiratoryProtectionRequirementsChecked
        {
            get { return respiratoryProtectionRequirementsCheckBox.Checked; }
            set { respiratoryProtectionRequirementsCheckBox.Checked = value; }
        }

        public bool RespiratoryProtectionRequirementsEnabled
        {
            set { respiratoryProtectionRequirementsCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool SpecialPpeRequirementsChecked
        {
            get { return specialPpeRequirementsCheckBox.Checked; }
            set { specialPpeRequirementsCheckBox.Checked = value; }
        }

        public bool SpecialPpeRequirementsEnabled
        {
            set { specialPpeRequirementsCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool SpecialPrecautionsConsiderationsChecked
        {
            get { return specialPrecautionsConsiderationsCheckBox.Checked; }
            set { specialPrecautionsConsiderationsCheckBox.Checked = value; }
        }

        public bool SpecialPrecautionsConsiderationsEnabled
        {
            set { specialPrecautionsConsiderationsCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool GasTestInformationChecked
        {
            get { return gasTestInformationCheckBox.Checked; }
            set { gasTestInformationCheckBox.Checked = value; }
        }

        public bool GasTestInformationEnabled
        {
            set { gasTestInformationCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool NotificationsAuthorizationsChecked
        {
            get { return notificationsAuthorizationsCheckBox.Checked; }
            set { notificationsAuthorizationsCheckBox.Checked = value; }
        }

        public bool NotificationsAuthorizationsEnabled
        {
            set { notificationsAuthorizationsCheckBox.Enabled = value; }
        }

        [Browsable(false)]
        public bool MiscellaneousChecked
        {
            get { return miscellaneousCheckBox.Checked; }
            set { miscellaneousCheckBox.Checked = value; }
        }

        public bool MiscellaneousEnabled
        {
            set { miscellaneousCheckBox.Enabled = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ExtraCloneSectionsEnabled
        {
            get { return extraCloneSectionsPanel1.Visible && extraCloneSectionsPanel2.Visible; }
            set
            {
                extraCloneSectionsPanel1.Visible = value;
                extraCloneSectionsPanel2.Visible = value;
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowCommunicationMethod
        {
            get { return communicationMethodCheckBox.Visible; }
            set { communicationMethodCheckBox.Visible = value; }
        }

        public bool CommunicationMethodEnabled
        {
            set { communicationMethodCheckBox.Enabled = value; }
        }

        private void FireSelectAllSectionsEvent(object sender, EventArgs e)
        {
            if (SelectAllSections != null)
            {
                SelectAllSections(sender, e);
            }
        }

        private void FireDeselectAllSectionsEvent(object sender, EventArgs e)
        {
            if (DeselectAllSections != null)
            {
                DeselectAllSections(sender, e);
            }
        }
    }
}