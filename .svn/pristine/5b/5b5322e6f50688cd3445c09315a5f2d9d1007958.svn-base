using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.FortHills;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.Charts.Native;
using Error = DevExpress.PivotGrid.OLAP.AdoWrappers.Error;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitFortHillsForm : BaseForm, IWorkPermitFortHillsView
    {
        private SingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;
        private WorkPermitFortHillsBusinessLogic workPermitFortHillsBusinessLogic;


        public event EventHandler SaveButtonClicked;
        public event Action SaveAndIssueButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action ValidateButtonClicked;
        public event Action PrintPreferencesButtonClicked;

        public event Action FunctionalLocationBrowseClicked;
        public event Action FormLoad;
        //public event Action SelectFormGN6ButtonClicked;
        //public event Action SelectFormGN7ButtonClicked;
        //public event Action SelectFormGN59ButtonClicked;
        //public event Action SelectFormGN24ButtonClicked;
        //public event Action SelectFormGN75AButtonClicked;
        //public event Action SelectFormGN1ButtonClicked;
        //public event Action IsFieldTourRequiredCheckChangedYes;
        //public event Action IsFieldTourRequiredCheckChangedNo;
        //public event Action ViewConfiguredDocumentLinkClicked;
        public event Action GroupChanged;
        public event Action ExpireTimeChangedByUser;

        public WorkPermitFortHillsForm()
        {
            InitializeComponent();

            issuedToContractorCheckBox.CheckedChanged += IssuedToContractorOnCheckedChanged;
            workPermitFortHillsBusinessLogic = new WorkPermitFortHillsBusinessLogic(this);
            confinedSpaceCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            permitTypeComboBox.SelectedValueChanged += HandlePermitTypeSelectedValueChanged;
            //groupComboBox.SelectedValueChanged += HandlePermitTypeSelectedValueChanged;
            validateButton.Click += HandleValidateButtonClicked;
            printPreferencesButton.Click += HandlePrintPreferencesButtonClicked;
            saveAndIssueButton.Click += HandleSaveAndIssueButtonClicked;
            GroupComboBoxChangedByUserEventsEnabled = true;
            requestedEndTimeTimePickerWP.ValueChanged += HandleExpiredTimeChanged;
            Disposed += HandleDisposed;

            lockBoxNumberoltCheckBox.CheckedChanged += LockBoxNumberOnCheckedChanged;

            other1CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other2CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other3CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            othersPartECheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other1PartGCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other2PartGCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            PermitFormHelper.SetupSectionNotApplicableToJob(partCWorkSectionNotApplicableToJobCheckBox, specialSafetyEquipmentRequirementGroupBox);
            PermitFormHelper.SetupSectionNotApplicableToJob(partDWorkSectionNotApplicableToJobCheckBox, safetyPrecautionsHazardousGroupBox);
            PermitFormHelper.SetupSectionNotApplicableToJob(partEWorkSectionNotApplicableToJobCheckBox, workAuthorizationAndDocumentationGroupBox);
            PermitFormHelper.SetupSectionNotApplicableToJob(partFWorkSectionNotApplicableToJobCheckBox, controlOfHazardousenergyGroupBox);
            PermitFormHelper.SetupSectionNotApplicableToJob(partGWorkSectionNotApplicableToJobCheckBox, atmosphericMoniteringGroupBox);
            isFieldTourRequiredYesRadioButton.CheckedChanged += IsFieldTourRequiredCheckedChanged;
            isFieldTourRequiredNoRadioButton.CheckedChanged += IsFieldTourRequiredCheckedChanged;
            lockBoxNumberoltCheckBox.Checked = true;
           
        }


        #region["Properties"]

        //public DateTime RequestedStartDateTIme
        //{
        //    get
        //    {
        //        Date date = requestedStartDateDatePickerWP.Value;
        //        Time time = requestedStartTimeTimePickerWP.Value;
        //        return date.CreateDateTime(time);
        //    }
        //    set
        //    {
        //        requestedStartDateDatePickerWP.Value = new Date(value);
        //      //  requestedStartDateDatePickerWP.ValueChanged -= HandleExpiredTimeChanged;
        //        requestedStartTimeTimePickerWP.Value = new Time(value);
        //      //  requestedStartTimeTimePickerWP.ValueChanged += HandleExpiredTimeChanged;
        //    }
        //} 

        //public Date EndDate
        //{
        //    get { return requestedEndDateDatePickerWP.Value; }
        //    set { requestedEndDateDatePickerWP.Value = value; }
        //} //IPermitRequestFortHillsFormView
        //public Time RequestedEndTime
        //{
        //    get { return requestedEndTimeTimePickerWP.Value; }
        //    set { requestedEndTimeTimePickerWP.Value = value; }
        //} //IPermitRequestFortHillsFormView

        public DateTime? RevalidationDateTime { get; set; }
        public DateTime? ExtensionDateTime
        {
            get
            {
                Date date = extensionDatePickerWP.Value;
                Time time = extensionTimePickerWP.Value;

                return date.CreateDateTime(time);
            }
            set
            {
                if (value != null)
                {
                    extensionDatePickerWP.Value = new Date(Convert.ToDateTime(value));
                    // extensionDatePickerWP.ValueChanged -= HandleExpiredTimeChanged;
                    extensionTimePickerWP.Value = new Time(Convert.ToDateTime(value));
                    //  extensionTimePickerWP.ValueChanged += HandleExpiredTimeChanged;
                }
                else
                {
                    extensionDatePickerWP.Value = null;
                    //extensionDatePickerWP.ValueChanged -= HandleExpiredTimeChanged;
                    extensionTimePickerWP.Value = null; 
                }
            }
        }

        public string ExtensionComments
        {
            get { return extensionCommentsTextBox.Text; }
            set { extensionCommentsTextBox.Text = value; }
        }

        public string EquipmentNo
        {
            get { return equipmentIntegerBox.Text; }
            set { equipmentIntegerBox.Text = value; }
        }

        public string JobCoordinator
        {
            get { return jobCoordinatorTextBox.Text.EmptyToNull(); }
            set { jobCoordinatorTextBox.Text = value; }
        }
        public string CoOrdContactNumber
        {
            get { return coOrdConactNoTextBox.Text.EmptyToNull(); }
            set { coOrdConactNoTextBox.Text = value; }
        }
        public string EmergencyAssemblyArea
        {
            get { return emergencyAssemblyAreaTextBox.Text.EmptyToNull(); }
            set { emergencyAssemblyAreaTextBox.Text = value; }
        }
        public string EmergencyMeetingPoint
        {
            get { return emergencyMeetingPointTextBox.Text.EmptyToNull(); }
            set { emergencyMeetingPointTextBox.Text = value; }
        }
        public string EmergencyContactNo
        {
            get { return emergencyContactNoTextBox.Text.EmptyToNull(); }
            set { emergencyContactNoTextBox.Text = value; }
        }

        #region[" PART C-1" ]

        public bool PartCWorkSectionNotApplicableToJob
        {
            get { return partCWorkSectionNotApplicableToJobCheckBox.Checked; }
            set { partCWorkSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        public bool FlameResistantWorkWear
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(flameResistantWorkWearCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, flameResistantWorkWearCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool ChemicalSuit
        {

            get { return PermitFormHelper.GetCheckBoxValueForSection(chemicalSuitCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, chemicalSuitCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool FireWatch
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireWatchCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireWatchCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool FireBlanket
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireblanketCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireblanketCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool SuppliedBreathingAir
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(suppliedBreathingAirCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, suppliedBreathingAirCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool AirMover
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(airMoverCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, airMoverCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }

        public bool PersonalFlotationDevice
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(personalFlotationDeviceCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, personalFlotationDeviceCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool HearingProtection
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(hearingProtectionCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, hearingProtectionCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }

        }
        public bool Other1
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other1CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { }
        }
        public String Other1Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other1TextBox, other1CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other1TextBox, other1CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        #endregion
        #region[" PART C-2" ]
        public bool MonoGoggles
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(monoGogglesCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, monoGogglesCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool ConfinedSpaceMoniter
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(confinedSpaceMoniterCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, confinedSpaceMoniterCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }

        }
        public bool FireExtinguisher
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireExtinguisherCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireExtinguisherCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }

        }
        public bool SparkContainment
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(sparkContainmentCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, sparkContainmentCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }

        }
        public bool BottleWatch
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(bottleWatchCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, bottleWatchCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }

        }
        public bool StandbyPerson
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(standbyPersonCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, standbyPersonCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }

        }
        public bool WorkingAlone
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(workingAloneCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, workingAloneCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }

        }
        public bool SafetyGloves
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(safetyGlovesCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, safetyGlovesCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }

        }
        public bool Other2
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other2CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { }
        }
        public String Other2Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other2TextBox, other2CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other2TextBox, other2CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        #endregion
        #region[" PART C-3" ]
        public bool FaceShield
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(faceShieldCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, faceShieldCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool FallProtection
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fallProtectionCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fallProtectionCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool ChargedFireHouse
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(chargedFireHouseCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, chargedFireHouseCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool CoveredSewer
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(coveredSewerCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, coveredSewerCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool AirPurifyingRespirator
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(airPurifyingRespiratorCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, airPurifyingRespiratorCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool SingalPerson
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(singalPersonCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, singalPersonCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool CommunicationDevice
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(communicationDeviceCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, communicationDeviceCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool ReflectiveStrips
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(reflectiveStripsCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, reflectiveStripsCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool Other3
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(othersPartECheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { }
        }
        public String Other3Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other3TextBox, other3CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other3TextBox, other3CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }
        #endregion
        #region["PART D  SAFETY PRECAUTIONS / HAZARDOUS"]
        //PART D  SAFETY PRECAUTIONS / HAZARDOUS
        public bool PartDWorkSectionNotApplicableToJob
        {
            get { return partDWorkSectionNotApplicableToJobCheckBox.Checked; }
            set { partDWorkSectionNotApplicableToJobCheckBox.Checked = value; }
        }
        public string HazardsAndOrRequirements
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(hazardsAndOrRequirementsTextBox, partDWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, hazardsAndOrRequirementsTextBox, partDWorkSectionNotApplicableToJobCheckBox); }
        }

        #endregion
        #region["PART E WORK AUTHORIZATION AND OR DOCUMENTATION"]
        // PART E WORK AUTHORIZATION AND OR DOCUMENTATION 
        public bool PartEWorkSectionNotApplicableToJob
        {
            get { return partEWorkSectionNotApplicableToJobCheckBox.Checked; }
            set { partEWorkSectionNotApplicableToJobCheckBox.Checked = value; }
        }
        public bool PartEWorkSectionNotApplicableToJobEnabled
        {
            get { return partEWorkSectionNotApplicableToJobCheckBox.Enabled; }
            set { partEWorkSectionNotApplicableToJobCheckBox.Enabled = value; }
        }
        public List<string> ConfinedSpaceClassSelectionList
        {
            set { confinedSpaceClassComboBox.DataSource = value; }
        }
        public bool ConfinedSpace
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(confinedSpaceCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, confinedSpaceCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }
        public string ConfinedSpaceClass
        {
            get { return PermitFormHelper.GetTextComboBoxValue(confinedSpaceClassComboBox, confinedSpaceCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, confinedSpaceClassComboBox, confinedSpaceCheckBox); }
        }
        public bool GoundDisturbance
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(groundDisturbanceCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, groundDisturbanceCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool FireProtectionAuthorization
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireProtectionAuthorizationCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireProtectionAuthorizationCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool CriticalOrSeriousLifts //AirHorn
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(criticalOrSeriousLiftsCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, criticalOrSeriousLiftsCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool VehicleEntry
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(vehicleEntryCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, vehicleEntryCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool IndustrialRadiography  //AsbestosMMCPrecautions
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(industrialRadiographyCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, industrialRadiographyCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool ElectricalEncroachment
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(electricalEncroachmentCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, electricalEncroachmentCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }

        public bool MSDS
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(mSDSCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, mSDSCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool OthersPartEChecked
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(othersPartECheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { }
        }
        public String OthersPartE
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(othersPartETextBox, other3CheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, othersPartETextBox, other3CheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }

        #endregion
        #region["PART F CONTROL OF HAZARDOUS ENERGY AND SAFING STATUS"]
        public bool PartFWorkSectionNotApplicableToJob
        {
            get { return partFWorkSectionNotApplicableToJobCheckBox.Checked; }
            set { partFWorkSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        // PART F CONTROL OF HAZARDOUS ENERGY AND SAFING STATUS 
        public bool MechanicallyIsolated
        {
            get { return mechanicallyIsolatedCheckBox.Checked; }
            set { mechanicallyIsolatedCheckBox.Checked = value; }
        }
        public bool BlindedOrBlanked
        {
            get { return blindedOrBlankedCheckBox.Checked; }
            set { blindedOrBlankedCheckBox.Checked = value; }
        }
        public bool DoubleBlockedandBled
        {
            get { return doubleBlockedandBledCheckBox.Checked; }
            set { doubleBlockedandBledCheckBox.Checked = value; }
        }
        public bool DrainedAndDepressurised
        {
            get { return drainedAndDepressurisedCheckBox.Checked; }
            set { drainedAndDepressurisedCheckBox.Checked = value; }
        }
        public bool PurgedorNeutralised
        {
            get { return purgedorNeutralisedCheckBox.Checked; }
            set { purgedorNeutralisedCheckBox.Checked = value; }
        }
        public bool ElectricallyIsolated
        {
            get { return electricallyIsolatedCheckBox.Checked; }
            set { electricallyIsolatedCheckBox.Checked = value; }
        }
        public bool TestBumped
        {
            get { return testBumpedCheckBox.Checked; }
            set { testBumpedCheckBox.Checked = value; }
        }
        public bool NuclearSource
        {
            get { return nuclearSourceCheckBox.Checked; }
            set { nuclearSourceCheckBox.Checked = value; }
        }
        public bool ReceiverStafingRequirements
        {
            get { return receiverStafingRequirementsCheckBox.Checked; }
            set { receiverStafingRequirementsCheckBox.Checked = value; }
        }
        #endregion
        #region ["PART G Atmospheric Monitering"]
        public bool PartGWorkSectionNotApplicableToJob
        {
            get { return partGWorkSectionNotApplicableToJobCheckBox.Checked; }
            set { partGWorkSectionNotApplicableToJobCheckBox.Checked = value; }
        }
        public bool PartGWorkSectionNotApplicableToJobEnabled
        {
            get { return partGWorkSectionNotApplicableToJobCheckBox.Enabled; }
            set { partGWorkSectionNotApplicableToJobCheckBox.Enabled = value; }
        }

        public string Frequency
        {
            get { return PermitFormHelper.GetTextComboBoxValueIfNotChecked(frequencyPartGComboBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { frequencyPartGComboBox.SelectedItem = value; }
        }
        public bool Continuous 
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(continuousCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, continuousCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
        }

        public string TesterName
        {
            get { return testerNameoltTextBox.Text; }
            set { testerNameoltTextBox.Text = value; }
        }

        public bool Oxygen
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(oxygenPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, oxygenPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool LEL
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(lelPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, lelPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool H2SPPM
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(h2sPpmPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, h2sPpmPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool CoPPM
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(coPpmPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, coPpmPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool SO2PPM
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(so2PpmPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, so2PpmPartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool Other1PartG
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other1PartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { }
        }
        public string Other1PartGValue
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other1PartGTextBox, other1PartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other1PartGTextBox, other1PartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
        }
        public bool Other2PartG
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other2PartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { }
        }
        public string Other2PartGValue
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other2PartGTextBox, other2PartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other2PartGTextBox, other2PartGCheckBox, partGWorkSectionNotApplicableToJobCheckBox); }
        }
        #endregion

        #region ["Contact Details Part"]
        public string PermitIssuer
        {
            get { return permitIssuerTextBox.Text.EmptyToNull(); }
            set { permitIssuerTextBox.Text = value; }
        }
        public string AreaAuthority
        {
            get { return areaAuthorityTextBox.Text.EmptyToNull(); }
            set { areaAuthorityTextBox.Text = value; }
        }
        public string CoAuthorizingIssuer
        {
            get { return coAuthorizingIssuerTextBox.Text.EmptyToNull(); }
            set { coAuthorizingIssuerTextBox.Text = value; }
        }
        public string AddationalAuthority
        {
            get { return addationalAuthorityTextBox.Text.EmptyToNull(); }
            set { addationalAuthorityTextBox.Text = value; }
        }
        public string PermitIssuerContact
        {
            get { return permitIssuerContactinfoTextBox.Text.EmptyToNull(); }
            set { permitIssuerContactinfoTextBox.Text = value; }
        }
        public string AreaAuthorityContact
        {
            get { return areaAuthorityContactInfoTextBox.Text.EmptyToNull(); }
            set { areaAuthorityContactInfoTextBox.Text = value; }
        }
        public string CoAuthorizingIssuerContact
        {
            get { return coAuthorizingIssuerContactInfoTextBox.Text.EmptyToNull(); }
            set { coAuthorizingIssuerContactInfoTextBox.Text = value; }
        }
        public string AddationalAuthorityContact
        {
            get { return addationalAuthorityContactInfoTextBox.Text.EmptyToNull(); }
            set { addationalAuthorityContactInfoTextBox.Text = value; }
        }
        public bool IsFieldTourRequired
        {
            get { return isFieldTourRequiredYesRadioButton.Checked; }
            set
            {
                isFieldTourRequiredYesRadioButton.Checked = value;
                isFieldTourRequiredNoRadioButton.Checked = !value;
            }
        }

        public bool IsFieldTourRequiredEnabled 
        {
            get { return isFieldTourRequiredYesRadioButton.Enabled; }
            set
            {
                isFieldTourRequiredYesRadioButton.Enabled = value;
                isFieldTourRequiredNoRadioButton.Enabled = !value;
            }
        }
       
        public string FieldTourConductedBy
        {
            get { return fieldTourConductedByTextBox.Text; }
            set { fieldTourConductedByTextBox.Text = value; }
        }

        private void IsFieldTourRequiredCheckedChanged(object sender, EventArgs eventArgs)
        {
            fieldTourConductedByTextBox.Enabled = IsFieldTourRequired;
        }
        #endregion

        #endregion

        #region ["Enable disable controls"]

        public bool ExtensionDateTimeEnable
        {
            set
            {
               extensionDatePickerWP.Enabled = value;
               extensionTimePickerWP.Enabled = value;
               
            }
            get { return extensionDatePickerWP.Enabled; }
        }
        public bool ExtensionDateTimeVisible
        {
            set
            {
                extensionDatePickerWP.Visible = value;
                extensionTimePickerWP.Visible = value;
                entensionoltLabel.Visible = value;
                extensioncommentsoltLabel.Visible = value;
                extensionCommentsTextBox.Visible = value;

            }
            get { return extensionDatePickerWP.Visible; }
        }
        //public bool RevalidationDateTimeEnable
        //{
        //    set
        //    {
        //        revalidationDatePickerWP.Enabled = value;
        //        revalidationTimePickerWP.Enabled = value;

        //    }
        //}

        public bool ConfinedSpaceCheckBoxEnabled
        {
            set { confinedSpaceCheckBox.Enabled = value; }
        }

        private bool GroupComboBoxChangedByUserEventsEnabled
        {
            set
            {
                if (value)
                {
                    groupComboBox.SelectedValueChanged += HandleGroupChanged;
                }
                else
                {
                    groupComboBox.SelectedValueChanged -= HandleGroupChanged;
                }
            }
        }

        public bool SaveAndIssueButtonEnabled
        {
            set { saveAndIssueButton.Enabled = value; }
        }

        public bool ConfinedSpaceClassEnabled
        {
            set { confinedSpaceClassComboBox.Enabled = value; }
        }
        public bool LockBoxNumberEnabled
        {
            set { lockBoxNoIntegerBox.Enabled = value; }
        }
        public bool IsolationNoEnabled
        {
            set { isolationNoIntegerBox.Enabled = value; }
        }

        public bool WorkOrderNumberReadOnly
        {
            set { workOrderNumberTextBox.ReadOnly = value; }
        }

        public bool OperationNumberReadOnly
        {
            set { operationNumberTextBox.ReadOnly = value; }
        }

        public bool SubOperationNumberReadOnly
        {
            set { subOperationNumberTextBox.ReadOnly = value; }
        }
        #endregion

        private void HandlePermitTypeSelectedValueChanged(object sender, EventArgs e)
        {
            workPermitFortHillsBusinessLogic.HandlePermitTypeSelectedValueChanged();

        }
        private void HandleGroupChanged(object sender, EventArgs e)
        {
            if (GroupChanged != null) GroupChanged();
        }

        private void HandleExpiredTimeChanged(object sender, EventArgs e)
        {
            if (ExpireTimeChangedByUser != null) ExpireTimeChangedByUser();
        }

        public List<Priority> Priorities
        {
            set { priorityComboBox.DataSource = value; }
        }

        public Priority Priority
        {
            get { return (Priority)priorityComboBox.SelectedItem; }
            set { priorityComboBox.SelectedItem = value; }
        }

        private void HandleSaveAndIssueButtonClicked(object sender, EventArgs e)
        {
            if (SaveAndIssueButtonClicked != null)
            {
                //check if extension is grater then 4 hrs 
                if (extensionDatePickerWP.Enabled)
                {
                    double differenceInMinutes = (Convert.ToDateTime(ExtensionDateTime).AddSeconds(-Convert.ToDateTime(ExtensionDateTime).Second) - ExpiryDateTime).TotalMinutes;
                    if (differenceInMinutes > 240 || 0 > differenceInMinutes)
                    {
                        DialogResult result = OltMessageBox.Show(Form.ActiveForm, "permit can be extended by 4 hrs only","Alert",MessageBoxButtons.OK,MessageBoxIcon.Error);
                       return; 
                    }
                }
                SaveAndIssueButtonClicked();
            }
        }

        private void HandleValidateButtonClicked(object sender, EventArgs e)
        {
            if (ValidateButtonClicked != null)
            {
                ValidateButtonClicked();
            }
        }

      
        // public static bool job;
        private void HandlePrintPreferencesButtonClicked(object sender, EventArgs e)
        {

            if (PrintPreferencesButtonClicked != null)
            {
                // job = JobsiteEquipmentInspected;
                PrintPreferencesButtonClicked();
            }
        }


        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        private void LockBoxNumberOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (lockBoxNumberoltCheckBox.Checked)
            {
                lockBoxNoIntegerBox.Enabled = true;
                isolationNoIntegerBox.Enabled = true;
            }
            else
            {
                lockBoxNoIntegerBox.Enabled = false;
                isolationNoIntegerBox.Enabled = false;
            }
            workPermitFortHillsBusinessLogic.HandleLockBoxRequiredCheckChange();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //PopulateYesNoNotApplicableDropDowns();
           // PopulateYesNotApplicableDropDowns();
           // PopulateConfinedSpaceWorkDropDowns();

            if (FormLoad != null)
            {
                FormLoad();
            }

        }

        private void IssuedToContractorOnCheckedChanged(object sender, EventArgs e)
        {
            contractorComboBox.Enabled = issuedToContractorCheckBox.Checked;
        }

        public List<WorkPermitFortHillsType> AllPermitTypes
        {
            set
            {
                permitTypeComboBox.DataSource = value;
                permitTypeComboBox.DisplayMember = "Name";
            }
        }

        public List<Contractor> AllCompanies
        {
            set
            {
                contractorComboBox.DataSource = value;
                contractorComboBox.DisplayMember = "CompanyName";
            }
        }

        public List<WorkPermitFortHillsGroup> AllGroups
        {
            set
            {
                GroupComboBoxChangedByUserEventsEnabled = false;
                groupComboBox.DataSource = value;
                GroupComboBoxChangedByUserEventsEnabled = true;
            }
        }

        public List<CraftOrTrade> AllCraftOrTrades
        {
            set
            {
                occupationComboBox.DataSource = value;
                occupationComboBox.DisplayMember = "ListDisplayText";
            }
        }


        public WorkPermitFortHillsGroup Group
        {
            get { return (WorkPermitFortHillsGroup)groupComboBox.SelectedItem; }
            set
            {
                GroupComboBoxChangedByUserEventsEnabled = false;
                groupComboBox.SelectedItem = value;
                GroupComboBoxChangedByUserEventsEnabled = true;
            }
        }

        public WorkPermitFortHillsType WorkPermitType
        {
            get { return (WorkPermitFortHillsType)permitTypeComboBox.SelectedItem; }
            set { permitTypeComboBox.SelectedItem = value; }
        }


        public string Description
        {
            get { return workAndScopeDescriptionTextBox.Text; }
            set { workAndScopeDescriptionTextBox.Text = value; }
        }


        public string LockBoxNumber
        {
            get { return lockBoxNoIntegerBox.Text; }
            set { lockBoxNoIntegerBox.Text = value; }
        }
        public bool LockBoxnumberChecked
        {
            get { return lockBoxNumberoltCheckBox.Checked; }
            set { lockBoxNumberoltCheckBox.Checked = value; }
        } //IWorkPermitFortHillsSharedView

        public string IsolationNo
        {
            get { return isolationNoIntegerBox.Text; }
            set { isolationNoIntegerBox.Text = value; }
        }




        public DateTime ExpiryDateTime
        {
            get
            {
                Date date = requestedEndDateDatePickerWP.Value;
                Time time = requestedEndTimeTimePickerWP.Value;
                return date.CreateDateTime(time);
            }
            set
            {
                requestedEndDateDatePickerWP.Value = new Date(value);
                requestedEndTimeTimePickerWP.ValueChanged -= HandleExpiredTimeChanged;
                requestedEndTimeTimePickerWP.Value = new Time(value);
                requestedEndTimeTimePickerWP.ValueChanged += HandleExpiredTimeChanged;
            }
        }

        public bool IssuedToSuncor
        {
            get { return issuedToSuncorCheckBox.Checked; }
            set { issuedToSuncorCheckBox.Checked = value; }
        }

        public bool IssuedToContractor
        {
            get { return issuedToContractorCheckBox.Checked; }
            set { issuedToContractorCheckBox.Checked = value; }
        }

        public int? NumberOfWorkers
        {
            get { return numberOfWorkersTextBox.IntegerValue; }
            set { numberOfWorkersTextBox.IntegerValue = value; }
        }


        public string Occupation
        {
            get { return occupationComboBox.Text; }
            set { occupationComboBox.Text = value; }
        }



        public string Company
        {
            get { return PermitFormHelper.GetTextComboBoxValue(contractorComboBox, issuedToContractorCheckBox); }
            set { contractorComboBox.Text = value; }
        }

        public new string Location
        {
            get { return locationTextBox.Text.EmptyToNull(); }
            set { locationTextBox.Text = value; }
        }


        public DateTime RequestedStartDateTime
        {
            get
            {
                Date date = requestedStartDateDatePickerWP.Value;
                Time time = requestedStartTimeTimePickerWP.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                requestedStartDateDatePickerWP.Value = new Date(value);
                requestedStartTimeTimePickerWP.Value = new Time(value);
            }
        }
        
        public string WorkOrderNumber
        {
            get { return workOrderNumberTextBox.Text.EmptyToNull(); }
            set { workOrderNumberTextBox.Text = value; }
        }

        public string OperationNumber
        {
            get { return operationNumberTextBox.Text.EmptyToNull(); }
            set
            {
                operationNumberTextBox.Text = value;
                toolTip.SetToolTip(operationNumberTextBox, value);
            }
        }

        public string SubOperationNumber
        {
            get { return subOperationNumberTextBox.Text.EmptyToNull(); }
            set
            {
                subOperationNumberTextBox.Text = value;
                toolTip.SetToolTip(subOperationNumberTextBox, value);
            }
        }

       public DateTime LastModifiedDateTime
        {
            set { oltLastModifiedDateAuthorHeader1.LastModifiedDate = value; }
        }

        public User LastModifiedBy
        {
            set { oltLastModifiedDateAuthorHeader1.LastModifiedUser = value; }
        }

       public void ShowIsValidMessageBox()
        {
            string title = StringResources.WorkPermitEdmonton_Validation_IsValidTitle;
            string message = StringResources.WorkPermitEdmonton_Validation_IsValid;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowHasValidationErrorsMessageBox()
        {
            string title = StringResources.WorkPermit_IncompleteWorkPermit;
            string message = StringResources.WorkPermit_Validation_ErrorsOnlyMessage;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowHasValidationWarningsMessageBox()
        {
            string title = StringResources.WorkPermit_IncompleteWorkPermit;
            string message = StringResources.WorkPermit_Validation_WarningsOnlyMessage;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowHasValidationWarningsAndErrorsMessageBox()
        {
            string title = StringResources.WorkPermit_IncompleteWorkPermit;
            string message = StringResources.WorkPermit_Validation_WarningsAndErrorsMessage;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowWarnings(WorkPermitFortHillsOtherWarnings otherWarnings, bool validationWarning)
        {
            string messageOne = StringResources.WarningsListBox_MessageOne;
            string messageTwo = StringResources.WarningsListBox_MessageTwo;

            List<string> warnings = otherWarnings.Warnings(validationWarning);
            return OltListMessageBox.Show(this, messageOne, messageTwo, warnings, StringResources.WarningsListBox_Title,
                                          MessageBoxIcon.Warning, false);
        }

        public void SetErrorForLockBoxNumberandisolationNo()
        {  
            if (lockBoxNoIntegerBox.Text.Trim()==string.Empty)
            errorProvider.SetError(lockBoxNumberoltCheckBox, StringResources.WorkPermit_FieldEmptyButChecked);
            if (isolationNoIntegerBox.Text.Trim() == string.Empty)
            errorProvider.SetError(isolationNoIntegerBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }
        public void SetErrorForNoEquipmentNo()
        {
            errorProvider.SetError(equipmentIntegerBox, StringResources.FieldEmptyError);  
        }

        public void SetErrorForIsFieldTourRequiredYes()
        {
            errorProvider.SetError(fieldtourTblLayoutPanel, StringResources.WorkPermit_FieldEmptyButChecked);  
        }

       
        //Start Minlge Story #4002, Change By : Swapnil, Changed On : 30 Mar 2016
       
        // End Minlge Story #4002, Change By : Swapnil, Changed On : 30 Mar 2016

        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s
        public bool IsEdit
        {
            get;
            set;
        }
        public bool IsExtension
        {
            get;
            set;
        }
        public bool IsClone
        {
            get;
            set;
        }
        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s

        #region["Set Error Functions"]

        public void SetErrorForNoContractor()
        {
            warningProvider.SetError(contractorComboBox, StringResources.WorkPermitEdmonton_ContractorEmpty);
        }
        
        public void SetErrorForNumberOfWorkersLessThanOrEqualToZero()
        {
            warningProvider.SetError(numberOfWorkersTextBox, StringResources.WorkPermitEdmonton_NumberOfWorkersIsLessThanOrEqualtoZero);
        }

        public void SetErrorForStartDateTimeNotBeforeEndDateTime()
        {
            ClearAutosetIndicatorsForDateTimes(); // This is because the two icons conflict
            warningProvider.SetError(requestedEndTimeTimePickerWP, StringResources.RequestedStartDateBeforeExpiredDate);
        }

        public void SetErrorForExpiryDateTimeInThePast()
        {
            ClearAutosetIndicatorsForDateTimes(); // This is because the two icons conflict
            errorProvider.SetError(requestedEndTimeTimePickerWP, StringResources.DateCannotBeInThePast);
        }

        public void SetErrorForNoIssuedToOptionSelected()
        {
            warningProvider.SetError(contractorComboBox, StringResources.ValueRequired);
        }

        public void SetErrorForNoHazardsAndOrRequirements()
        {
              errorProvider.SetError(hazardsAndOrRequirementsTextBox, StringResources.WorkPermitEdmonton_HazardsAndOrRequirementsEmpty);
        }
        public void SetErrorForEmergencyDetails()
        {
            if (emergencyAssemblyAreaTextBox.Text.Trim() == string.Empty)
                errorProvider.SetError(emergencyAssemblyAreaTextBox, StringResources.ValueRequired);
            if (emergencyContactNoTextBox.Text.Trim() == string.Empty)
                errorProvider.SetError(emergencyContactNoTextBox, StringResources.ValueRequired);
            if (emergencyMeetingPointTextBox.Text.Trim() == string.Empty)
                errorProvider.SetError(emergencyMeetingPointTextBox, StringResources.ValueRequired);
        }
        public void SetErrorForHazardsTooLong()
        {
            warningProvider.SetError(hazardsAndOrRequirementsTextBox, StringResources.WorkPermit_HazardsTooLong);
        }
        public void SetErrorForPartCOptionNotChosen()
        {
            errorProvider.SetError(specialSafetyEquipmentRequirementGroupBox,
                StringResources.WorkPermitEdmonton_NoSafetyRequirementChosen);
        }
       
        public void SetErrorForPartEOptionNotChosen()
        {
            errorProvider.SetError(workAuthorizationAndDocumentationGroupBox,
                StringResources.WorkPermitEdmonton_NoSafetyRequirementChosen);
        }
        public void SetErrorForPartFOptionNotChosen()
        {
            errorProvider.SetError(controlOfHazardousenergyGroupBox,
                StringResources.WorkPermitEdmonton_NoSafetyRequirementChosen);
        }
        public void SetErrorForPartGOptionNotChosen()
        {
            errorProvider.SetError(atmosphericMoniteringGroupBox,
                StringResources.WorkPermitEdmonton_NoSafetyRequirementChosen);
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            warningProvider.Clear();
        }
        

        public void SetErrorForNoOccupation()
        {
            warningProvider.SetError(occupationComboBox, StringResources.WorkPermitEdmonton_OccupationEmpty);
        }

        public void SetErrorForNoGroup()
        {
            warningProvider.SetError(groupComboBox, StringResources.WorkPermit_GroupEmpty);
        }

        public void SetErrorForNoLocation()
        {
            warningProvider.SetError(locationTextBox, StringResources.WorkPermit_LocationEmpty);
        }

        public void SetErrorForOther1CheckedWithNoValue()
        {
            warningProvider.SetError(other1TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther2CheckedWithNoValue()
        {
            warningProvider.SetError(other2TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther3CheckedWithNoValue()
        {
            warningProvider.SetError(other3TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOtherPartECheckedWithNoValue()
        {
            warningProvider.SetError(othersPartETextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther1PartGCheckedWithNoValue()
        {
            errorProvider.SetError(other1PartGCheckBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther2PartGCheckedWithNoValue()
        {
            errorProvider.SetError(other2PartGCheckBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoFunctionalLocation()
        {
            errorProvider.SetError(functionalLocationBrowseButton, StringResources.FlocEmptyError);
        }

        public void SetErrorForNoPermitType()
        {
            errorProvider.SetError(permitTypeComboBox, StringResources.WorkPermit_PermitType_Not_Selected);
        }

        public void SetErrorForNoDescription()
        {
            errorProvider.SetError(workAndScopeDescriptionTextBox, StringResources.WorkPermit_Description_Empty);
        }

        #endregion
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, e);
            }
        }

        private void functionalLocationBrowseButton_Click(object sender, EventArgs e)
        {
            if (FunctionalLocationBrowseClicked != null)
            {
                FunctionalLocationBrowseClicked();
            }
        }

        private void HandleDisposed(object sender, EventArgs eventArgs)
        {
            if (functionalLocationSelectorForm != null)
            {
                functionalLocationSelectorForm.Dispose();
            }
        }

        public void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations)
        {
            functionalLocationSelectorForm = new SingleSelectFunctionalLocationSelectionForm(
                FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2, functionalLocations));
        }

        public FunctionalLocation ShowSecondLevelOrLowerFunctionalLocationSelector()
        {
            DialogResult result = functionalLocationSelectorForm.ShowDialog(this);
            return result == DialogResult.OK ? functionalLocationSelectorForm.SelectedFunctionalLocation : null;
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = null;
                }
            }
        }

        public string PermitNumber
        {
            get { return permitNumberValue.Text.EmptyToNull(); }
            set { permitNumberValue.Text = value.NullToEmpty(); }
        }

       
        //public void OpenFileOrDirectoryOrWebsite(string path)
        //{
        //    FileUtility.OpenFileOrDirectoryOrWebsite(path);
        //}

        public string PermitAcceptor
        {
            get { return permitAcceptorField.Text.EmptyToNull(); }
            set { permitAcceptorField.Text = value; }
        }

        private void WorkPermitEdmontonForm_ResizeEnd(object sender, EventArgs e)
        {
            UpdateMaximumSize();
        }

        private void WorkPermitEdmontonForm_Shown(object sender, EventArgs e)
        {
            UpdateMaximumSize();
        }

        private void UpdateMaximumSize()
        {
            Screen screen = Screen.FromControl(this);
            Size size = screen.WorkingArea.Size;
            if (size.Height > size.Width)
            {
                // Screen is turned size-ways, re-set the maximums.
                MaximumSize = new Size(MaximumSize.Width, size.Height);
            }
            else
            {
                MaximumSize = new Size(MaximumSize.Width, size.Height);
            }
        }

        public void TurnOnAutosetIndicatorsForDateTimes()
        {
            infoProvider.SetError(requestedEndTimeTimePickerWP, StringResources.AutosetWorkPermitDateTimesInfoMessage);
        }

        public void ClearAutosetIndicatorsForDateTimes()
        {
            infoProvider.Clear();
        }

        public void DisplayInvalidPrintMessage(string message)
        {
            OltMessageBox.Show(ActiveForm, message, StringResources.WorkPermitPrintFailureMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void DisplayErrorMessageDialog(string message, string title)
        {
            OltMessageBox.Show(ActiveForm, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetErrorForNoAlphaNumeric(string name)
        {
            //if (name == "GasTestDataLine1CombustibleGas") errorProvider.SetError(gasTestDataLine1CombustibleGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine2CombustibleGas") errorProvider.SetError(gasTestDataLine2CombustibleGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine3CombustibleGas") errorProvider.SetError(gasTestDataLine3CombustibleGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine4CombustibleGas") errorProvider.SetError(gasTestDataLine4CombustibleGasTextBox, StringResources.WorkPermit_OnlyNumeric);

            //if (name == "GasTestDataLine1Oxygen") errorProvider.SetError(gasTestDataLine1OxygenTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine2Oxygen") errorProvider.SetError(gasTestDataLine2OxygenTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine3Oxygen") errorProvider.SetError(gasTestDataLine3OxygenTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine4Oxygen") errorProvider.SetError(gasTestDataLine4OxygenTextBox, StringResources.WorkPermit_OnlyNumeric);

            //if (name == "GasTestDataLine1ToxicGas") errorProvider.SetError(gasTestDataLine1ToxicGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine2ToxicGas") errorProvider.SetError(gasTestDataLine2ToxicGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine3ToxicGas") errorProvider.SetError(gasTestDataLine3ToxicGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            //if (name == "GasTestDataLine4ToxicGas") errorProvider.SetError(gasTestDataLine4ToxicGasTextBox, StringResources.WorkPermit_OnlyNumeric);
        }


        public void DisableAllcontrolsforExtension()
        {
            SetEnableOnAllChildControls(issuedToGroupBox, false);
            SetEnableOnAllChildControls(functionalLocationGroupBox, false);
            permitTypeComboBox.Enabled = false;
            priorityComboBox.Enabled = false;
            SetEnableOnAllChildControls(documentLinksControl,false);
           // SetEnableOnAllChildControls(typeOfWorkGroupBox, false);
            SetEnableOnAllChildControls(requestedStartGroupBox, false);
            SetEnableOnAllChildControls(requestedEndDateGroupBox, false);
            workOrderNumberTextBox.Enabled = false;
            operationNumberTextBox.Enabled = false;
            subOperationNumberTextBox.Enabled = false;
            SetEnableOnAllChildControls(taskDescriptionGroupBox, false);
            SetEnableOnAllChildControls(currentSAPDescriptionGroupBox, false);
            SetEnableOnAllChildControls(workAuthorizationAndDocumentationGroupBox, false);
            SetEnableOnAllChildControls(controlOfHazardousenergyGroupBox, false);
            SetEnableOnAllChildControls(atmosphericMoniteringGroupBox, false);
            SetEnableOnAllChildControls(permitAgreementIssuanceGroupBox, false);
            SetEnableOnAllChildControls(safetyPrecautionsHazardousGroupBox, false);

            /**/
            equipmentIntegerBox.Enabled = false;
            jobCoordinatorTextBox.Enabled = false;
            coOrdConactNoTextBox.Enabled = false;
            emergencyAssemblyAreaTextBox.Enabled = false;
            emergencyContactNoTextBox.Enabled = false;
            emergencyMeetingPointTextBox.Enabled = false;
            lockBoxNumberoltCheckBox.Enabled = false;
            lockBoxNoIntegerBox.Enabled = false;
            isolationNoIntegerBox.Enabled = false;
            //revalidationDatePickerWP.Enabled = false;
            //revalidationTimePickerWP.Enabled = false;
            permitAcceptorField.Enabled = false;
            extensionDatePickerWP.Enabled = true;
            extensionTimePickerWP.Enabled = true;
            extensionCommentsTextBox.Enabled = true;
            partCWorkSectionNotApplicableToJobCheckBox.Enabled = false;
            partDWorkSectionNotApplicableToJobCheckBox.Enabled = false;
            partEWorkSectionNotApplicableToJobCheckBox.Enabled = false;
            partGWorkSectionNotApplicableToJobCheckBox.Enabled = false;
            partFWorkSectionNotApplicableToJobCheckBox.Enabled = false;

            saveButton.Enabled = false;
            validateButton.Enabled = false;
            saveButton.Enabled = false;
            validateButton.Enabled = false;
            ExtensionDateTimeVisible = true;


        }
        public static void SetEnableOnAllChildControls( Control control, bool isEnabled)
        {
            control.Enabled = isEnabled;
            if (control.Controls.Count > 0)
            {
                foreach (Control childControl in control.Controls)
                {
                    childControl.SetEnableOnAllChildControls(isEnabled);
                }
            }
        }
        public void ForceExecutionOfBusinessLogic()
        {
            workPermitFortHillsBusinessLogic.ForceExecutionOfBusinessLogic();
        }

        public string ClonedFormDetailFortHills { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History
    }
}