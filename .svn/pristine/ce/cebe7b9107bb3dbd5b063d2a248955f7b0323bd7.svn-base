using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PermitRequestFortHillsForm : BaseForm, IPermitRequestFortHillsFormView
    {
        private SingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action ViewEditHistoryButtonClicked;
        public event Action FunctionalLocationButtonClicked;
        public event Action SubmitAndCloseButtonClicked;
        public event Action ValidateButtonClicked;
       
        public PermitRequestFortHillsForm()
        {
            InitializeComponent();
            issuedToContractorCheckBox.CheckedChanged += HandleIssuedToContractorCheckedChanged;
            
           // otherAreasAffectedNoRadioButton.CheckedChanged += HandleOtherAreasAffectedRadioButtonCheckChanged;

            saveAndCloseButton.Click += HandleSaveAndCloseButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            viewEditHistoryButton.Click += HandleViewEditHistoryButtonClick;
            functionalLocationBrowseButton.Click += HandleFunctionalLocationButtonClick;
            submitAndCloseButton.Click += HandleSubmitAndCloseButtonClick;
            validateButton.Click += HandleValidateButtonClick;
            other1CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other2CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other3CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            othersPartECheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            confinedSpaceCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            permitTypeComboBox.SelectedValueChanged += HandlePermitTypeSelectedValueChanged;
            PermitFormHelper.SetupSectionNotApplicableToJob(partCWorkSectionNotApplicableToJobCheckBox, workersMinimumSafetyRequirementsGroupBox);
            PermitFormHelper.SetupSectionNotApplicableToJob(partDWorkSectionNotApplicableToJobCheckBox, hazardsAndOrRequirementsGroupBox);
            PermitFormHelper.SetupSectionNotApplicableToJob(partEWorkSectionNotApplicableToJobCheckBox, workAuthorizationAndDocumentationGroupBox);
            lockBoxNumberoltCheckBox.CheckedChanged += LockBoxNumberOnCheckedChanged;
            Disposed += HandleDisposed;
        }


        #region ["Properties"]
        //AMIT START
        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }  //IWorkPermitFortHillsSharedView
        public User LastModifiedBy
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }  //IWorkPermitFortHillsSharedView
        public bool IssuedToSuncor
        {
            get { return issuedToSuncorCheckBox.Checked; }
            set { issuedToSuncorCheckBox.Checked = value; }
        }   //IWorkPermitFortHillsSharedView
        public bool IssuedToContractor
        {
            get { return issuedToContractorCheckBox.Checked; }
            set { issuedToContractorCheckBox.Checked = value; }
        }   
        public string Company
        {
            get { return PermitFormHelper.GetTextComboBoxValue(contractorComboBox, issuedToContractorCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, contractorComboBox, issuedToContractorCheckBox); }
        }   //IWorkPermitFortHillsSharedView
        public string Occupation
        {
            get { return occupationComboBox.Text; }
            set { occupationComboBox.Text = value; }
        }   //IWorkPermitFortHillsSharedView
        public int? NumberOfWorkers
        {
            get { return numberOfWorkersTextBox.IntegerValue; }
            set { numberOfWorkersTextBox.IntegerValue = value; }
        }  //IWorkPermitFortHillsSharedView
        public WorkPermitFortHillsGroup Group
        {
            get { return (WorkPermitFortHillsGroup)groupComboBox.SelectedItem; }
            set { groupComboBox.SelectedItem = value; }
        }  //IWorkPermitFortHillsSharedView
        public List<WorkPermitFortHillsGroup> AllGroups
        {
            set { groupComboBox.DataSource = value; }
        }  //IPermitRequestFortHillsFormView
        public WorkPermitFortHillsType WorkPermitType
        {
            get { return (WorkPermitFortHillsType)permitTypeComboBox.SelectedItem; }
            set { permitTypeComboBox.SelectedItem = value; }
        }  //IWorkPermitFortHillsSharedView
        public Priority Priority
        {
            get { return (Priority)priorityComboBox.SelectedItem; }
            set { priorityComboBox.SelectedItem = value; }
        }  //IPermitRequestFortHillsFormView
        public List<Priority> Priorities
        {
            set { priorityComboBox.DataSource = value; }
        } //IPermitRequestFortHillsFormView

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
        }//IWorkPermitFortHillsSharedView
        public string Location  // same as edmonton
        {
            get { return locationTextBox.Text.EmptyToNull(); }
            set { locationTextBox.Text = value; }
        }//IWorkPermitFortHillsSharedView  //IPermitRequestFortHillsFormView
        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }  //IWorkPermitFortHillsSharedView  //IPermitRequestFortHillsFormView

        public string WorkOrderNumber
        {
            get { return workOrderNumberTextBox.Text.EmptyToNull(); }
            set { workOrderNumberTextBox.Text = value; }
        } //IWorkPermitFortHillsSharedView
        public string OperationNumber
        {
            get { return operationNumberTextBox.Text.EmptyToNull(); }
            set
            {
                operationNumberTextBox.Text = value;
                toolTip.SetToolTip(operationNumberTextBox, value);
            }
        } //IWorkPermitFortHillsSharedView
        public string SubOperationNumber
        {
            get { return subOperationNumberTextBox.Text.EmptyToNull(); }
            set
            {
                subOperationNumberTextBox.Text = value;
                toolTip.SetToolTip(subOperationNumberTextBox, value);
            }
        } //IWorkPermitFortHillsSharedView
        public List<CraftOrTrade> AllCraftOrTrades 
        {
            set
            {
                occupationComboBox.DataSource = value;
                occupationComboBox.DisplayMember = "ListDisplayText";
            }
        } //IPermitRequestFortHillsFormView
        
        public Date RequestedStartDate
        {
            get { return requestedStartDatePicker.Value; }
            set { requestedStartDatePicker.Value = value; }
        } //IPermitRequestFortHillsFormView
        public Time RequestedStartTime
        {
            get { return requestedStartTimePicker.Value; }
            set { requestedStartTimePicker.Value = value; }
        } //IPermitRequestFortHillsFormView
        public Date RequestedEndDate
        {
            get { return requestedEndDatePicker.Value; }
            set { requestedEndDatePicker.Value = value; }
        } //IPermitRequestFortHillsFormView
        public Time RequestedEndTime
        {
            get { return requestedEndTimePicker.Value; }
            set { requestedEndTimePicker.Value = value; }
        } //IPermitRequestFortHillsFormView
        //public Date RevalidationDate
        //{
        //    get { return revalidationDatePicker.Value; }
        //    set { revalidationDatePicker.Value = value; }
        //} //IPermitRequestFortHillsFormView
        //public Time RevalidationTime
        //{
        //    get { return revalidationTimePicker.Value; }
        //    set { revalidationTimePicker.Value = value; }
        //} //IPermitRequestFortHillsFormView
        //public Date ExtensionDate
        //{
        //    get { return extensionDatePicker.Value; }
        //    set { extensionDatePicker.Value = value; }
        //} //IPermitRequestFortHillsFormView
        //public Time ExtensionTime
        //{
        //    get { return extensionTimePicker.Value; }
        //    set { extensionTimePicker.Value = value; }
        //} //IPermitRequestFortHillsFormView

        //public string Craft
        //{
        //    get { return craftTextBox.Text.EmptyToNull(); }
        //    set { craftTextBox.Text = value; }
        //} //IWorkPermitFortHillsSharedView
        //public Int32? CrewSize
        //{
        //    get { return crewSizeIntegerBox.IntegerValue; }
        //    set { crewSizeIntegerBox.IntegerValue = value; }
        //} //IWorkPermitFortHillsSharedView
        public string JobCoordinator
        {
            get { return jobCoordinatorTextBox.Text.EmptyToNull(); }
            set { jobCoordinatorTextBox.Text = value; }
        } //IWorkPermitFortHillsSharedView
        public string CoOrdContactNumber
        {
            get { return coOrdConactNoTextBox.Text.EmptyToNull(); }
            set { coOrdConactNoTextBox.Text = value; }
        } //IWorkPermitFortHillsSharedView
        //public string EmergencyAssemblyArea
        //{
        //    get { return emergencyAssemblyAreaTextBox.Text.EmptyToNull(); }
        //    set { emergencyAssemblyAreaTextBox.Text = value; }
        //} //IWorkPermitFortHillsSharedView
        //public string EmergencyMeetingPoint
        //{
        //    get { return emergencyMeetingPointTextBox.Text.EmptyToNull(); }
        //    set { emergencyMeetingPointTextBox.Text = value; }
        //} //IWorkPermitFortHillsSharedView
        //public string EmergencyContactNo
        //{
        //    get { return emergencyContactNoTextBox.Text.EmptyToNull(); }
        //    set { emergencyContactNoTextBox.Text = value; }
        //} //IWorkPermitFortHillsSharedView
        public string EquipmentNo //IWorkPermitFortHillsSharedView
        {
            get { return equipmentIntegerBox.Text; }
            set { equipmentIntegerBox.Text = value; }
        } //IPermitRequestFortHillsFormView
        public bool LockBoxnumberChecked
        {
            get { return lockBoxNumberoltCheckBox.Checked; }
            set { lockBoxNumberoltCheckBox.Checked = value; }
        } //IWorkPermitFortHillsSharedView
        //public string LockBoxNumber
        //{
        //    get { return lockBoxNoIntegerBox.Text; }
        //    set { lockBoxNoIntegerBox.Text= value; }
        //}
        //public string   IsolationNo
        //{
        //    get { return isolationNoIntegerBox.Text; }
        //    set { lockBoxNoIntegerBox.Text = value; }
        //}

       public string Description
        {
            get { return workAndScopeDescriptionTextBox.Text.EmptyToNull(); }
            set { workAndScopeDescriptionTextBox.Text = value; }
        }  //IWorkPermitFortHillsSharedView
        public string SapDescription
        {
            get { return sapDescriptionTextBox.Text.EmptyToNull(); }
            set { sapDescriptionTextBox.Text = value; }
        }  //IPermitRequestFortHillsFormView
        public bool SapDescriptionVisible
        {
            set { currentSAPDescriptionGroupBox.Visible = value; }
        }  //IPermitRequestFortHillsFormView


        // PART C-1   all at IWorkPermitFortHillsSharedView
        public  bool PartCWorkSectionNotApplicableToJob
        {
            get { return partCWorkSectionNotApplicableToJobCheckBox.Checked;  }
            set { partCWorkSectionNotApplicableToJobCheckBox.Checked=value; }
        }
        public bool FlameResistantWorkWear
        {
           get { return PermitFormHelper.GetCheckBoxValueForSection(flameResistantWorkWearCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
           set { PermitFormHelper.SetCheckBoxValueForSection(value, flameResistantWorkWearCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }  
        public bool ChemicalSuit
        {
            //get { return chemicalSuitCheckBox.Checked; }
            //set { chemicalSuitCheckBox.Checked = value; }
            get { return PermitFormHelper.GetCheckBoxValueForSection(chemicalSuitCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, chemicalSuitCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }  
        public bool FireWatch
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireWatchCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireWatchCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            //get { return fireWatchCheckBox.Checked; }
            //set { fireWatchCheckBox.Checked = value; }
        }  
        public bool FireBlanket
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireBlanketCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireBlanketCheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            //get { return fireBlanketCheckBox.Checked; }
            //set { fireBlanketCheckBox.Checked = value; }
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
            get { return PermitFormHelper.GetTextBoxValueForSection(other1TextBox, other1CheckBox,partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other1TextBox, other1CheckBox,partCWorkSectionNotApplicableToJobCheckBox); }
        }  


        // PART C-2  all at IWorkPermitFortHillsSharedView
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
           get { return PermitFormHelper.GetTextBoxValueForSection(other2TextBox, other2CheckBox,partCWorkSectionNotApplicableToJobCheckBox); }
           set { PermitFormHelper.SetTextBoxValueForSection(value, other2TextBox, other2CheckBox,partCWorkSectionNotApplicableToJobCheckBox); }
        }

        // PART C-3  all at IWorkPermitFortHillsSharedView
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
            get { return PermitFormHelper.GetCheckBoxValueForSection(other3CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { }
        }
        public String Other3Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other3TextBox, other3CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other3TextBox, other3CheckBox, partCWorkSectionNotApplicableToJobCheckBox); }
        }

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
        } //add datat to confined space dropdown
        public bool ConfinedSpace
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(confinedSpaceCheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
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
        {   get { return PermitFormHelper.GetCheckBoxValueForSection(othersPartECheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { }
        }
        public String OthersPartE
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(othersPartETextBox, othersPartECheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, othersPartETextBox, othersPartECheckBox, partEWorkSectionNotApplicableToJobCheckBox); }
        }
        public void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations)
        {
            functionalLocationSelectorForm = new SingleSelectFunctionalLocationSelectionForm(
                FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2, functionalLocations));
        }

       public void ClearErrorProviders()
        {
            errorProvider.Clear();
            warningProvider.Clear();
        }

        public List<WorkPermitFortHillsType> AllPermitTypes
        {
            set
            {
                permitTypeComboBox.DataSource = value;
                permitTypeComboBox.DisplayMember = "Name";
            }
        }

       
        public List<CraftOrTrade> AllRoadAccessOnPermitType
        {
            set
            {
                //roadAccessOnPermitComboBox.DataSource = value;
                //roadAccessOnPermitComboBox.DisplayMember = "ListDisplayText";
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



        public FunctionalLocation ShowFunctionalLocationSelector()
        {
            var result = functionalLocationSelectorForm.ShowDialog(this);
            return result == DialogResult.OK ? functionalLocationSelectorForm.SelectedFunctionalLocation : null;
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public bool WorkOrderNumberEnabled
        {
            set { workOrderNumberTextBox.ReadOnly = !value; }
        }

        public bool OperationNumberEnabled
        {
            set { operationNumberTextBox.ReadOnly = !value; }
        }

        public bool SubOperationNumberEnabled
        {
            set { subOperationNumberTextBox.ReadOnly = !value; }
        }
        
        public bool ConfinedSpaceCheckBoxEnabled
        {
            set { confinedSpaceCheckBox.Enabled = value; }
        }

        public bool RescuePlanCheckBoxEnabled
        {
            set { }
            //  set { rescuePlanCheckBox.Enabled = value; }
        }

        private void HandleDisposed(object sender, EventArgs eventArgs)
        {
            if (functionalLocationSelectorForm != null)
            {
                functionalLocationSelectorForm.Dispose();
            }
        }

        #region[Enable Disable Control Property]

       
        public bool RequestedEndDatePickerEnabled
        {
            set { requestedEndDatePicker.Enabled = value; }
        }
        public bool RequestedEndTimePickerEnabled
        {
            set { requestedEndTimePicker.Enabled = value; }
        }

        public bool RequestedStartDatePickerEnabled
        {
            set { requestedStartDatePicker.Enabled = value; }
        }
        public bool RequestedStartTimePickerEnabled
        {
            set { requestedStartTimePicker.Enabled = value; }
        }

        #endregion
       
        
        private void HandlePermitTypeSelectedValueChanged(object sender, EventArgs e)
        {
        
        }

       

        #endregion

        #region["Handle Click"]
        

        private void HandleIssuedToContractorCheckedChanged(object sender, EventArgs e)
        {
            contractorComboBox.Enabled = issuedToContractorCheckBox.Checked;
        }

        private void HandleSaveAndCloseButtonClick(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, e);
            }
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            if (ViewEditHistoryButtonClicked != null)
            {
                ViewEditHistoryButtonClicked();
            }
        }

        private void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            if (FunctionalLocationButtonClicked != null)
            {
                FunctionalLocationButtonClicked();
            }
        }

        private void HandleSubmitAndCloseButtonClick(object sender, EventArgs e)
        {
            if (SubmitAndCloseButtonClicked != null)
            {
                SubmitAndCloseButtonClicked();
            }
        }

        private void HandleValidateButtonClick(object sender, EventArgs e)
        {
            if (ValidateButtonClicked != null)
            {
                ValidateButtonClicked();
            }
        }
        private void LockBoxNumberOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            PermitFormHelper.HandleLockBoxNumberOnCheckedChanged(lockBoxNumberoltCheckBox,
                partEWorkSectionNotApplicableToJobCheckBox);
        }
        #endregion
      
        public void ShowSaveAndCloseMessageForErrors()
        {
            var message = StringResources.PermitRequestEdmonton_Validation_ErrorsOnlyMessage;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowSaveAndCloseMessageForWarnings_NonTurnaroundCase()
        {
            var message = StringResources.PermitRequestEdmonton_SaveAndClose_WarningsOnlyMessage_NonTurnaround;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult ShowSaveAndCloseMessageForWarnings_TurnaroundCase()
        {
            var message = StringResources.PermitRequestEdmonton_SaveAndClose_WarningsOnlyMessage_Turnaround;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public void ShowSaveAndCloseMessageForWarningsAndErrors_NonTurnaroundCase()
        {
            var message = StringResources.PermitRequestEdmonton_Validation_WarningsAndErrorsMessage_NonTurnaround;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSaveAndCloseMessageForWarningsAndErrors_TurnaroundCase()
        {
            var message = StringResources.PermitRequestEdmonton_Validation_WarningsAndErrorsMessage_Turnaround;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSubmitAndCloseMessageForErrors()
        {
            ShowSubmitAndCloseMessageBox(StringResources.PermitRequestEdmonton_Validation_ErrorsOnlyMessage);
        }

        public void ShowSubmitAndCloseMessageForWarnings()
        {
            ShowSubmitAndCloseMessageBox(StringResources.PermitRequestEdmonton_SubmitAndClose_WarningsOnlyMessage);
        }

        public void ShowSubmitAndCloseMessageForWarningsAndErrors_NonTurnaroundCase()
        {
            ShowSubmitAndCloseMessageBox(
                StringResources.PermitRequestEdmonton_Validation_WarningsAndErrorsMessage_NonTurnaround);
        }

        public void ShowSubmitAndCloseMessageForWarningsAndErrors_TurnaroundCase()
        {
            ShowSubmitAndCloseMessageBox(
                StringResources.PermitRequestEdmonton_Validation_WarningsAndErrorsMessage_Turnaround);
        }

        public void ShowValidationMessageForTurnaroundWarnings()
        {
            ShowSubmitAndCloseMessageBox(StringResources.PermitRequestEdmonton_Validation_WarningsOnlyMessage_Turnaround);
        }

        private void ShowSubmitAndCloseMessageBox(string message)
        {
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowIsValidMessageBox()
        {
            var title = StringResources.PermitRequestEdmonton_Validation_IsValidTitle;
            var message = StringResources.PermitRequestEdmonton_Validation_IsValid;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Type of Work Section


        public bool ConfinedSpaceClassEnabled
        {
            set { confinedSpaceClassComboBox.Enabled = value; }
        }


        /*
        public bool ConfinedSpaceCardNumberEnabled
        {
            set { }
            // set { confinedSpaceCardNumberTextBox.ReadOnly = !value; }
        }

        

        public bool VehicleEntryTypeEnabled
        {
            set { }
            //set { vehicleEntryTypeTextBox.ReadOnly = !value; }
        }

        public bool AlkylationEntry { set; get;
            //get { return alkylationEntryCheckBox.Checked; }
            //set { alkylationEntryCheckBox.Checked = value; }
        }

        public string AlkylationEntryClassOfClothing
        {
            set;
            get;
            //get { return PermitFormHelper.GetTextComboBoxValue(classOfClothingComboBox, alkylationEntryCheckBox); }
            //set { PermitFormHelper.SetTextComboBoxValue(value, classOfClothingComboBox, alkylationEntryCheckBox); }
        }

        public bool FlarePitEntry
        {
            set;
            get;
            //get { return flarePitEntryCheckBox.Checked; }
            //set { flarePitEntryCheckBox.Checked = value; }
        }

        public string FlarePitEntryType
        {
            set;
            get;
            //get { return PermitFormHelper.GetTextComboBoxValue(flarePitEntryTypeComboBox, flarePitEntryCheckBox); }
            //set { PermitFormHelper.SetTextComboBoxValue(value, flarePitEntryTypeComboBox, flarePitEntryCheckBox); }
        }

       

        public string ConfinedSpaceCardNumber { get; set;
            //get { return PermitFormHelper.GetTextBoxValue(confinedSpaceCardNumberTextBox, confinedSpaceCheckBox); }
            //set { PermitFormHelper.SetTextBoxValue(value, confinedSpaceCardNumberTextBox, confinedSpaceCheckBox); }
        }

        

        public bool RescuePlan
        {
            set;
            get;
            //get { return rescuePlanCheckBox.Checked; }
            //set { rescuePlanCheckBox.Checked = value; }
        }

        public string RescuePlanFormNumber
        {
            set;
            get;
            //get { return PermitFormHelper.GetTextBoxValue(rescuePlanFormNumberTextBox, rescuePlanCheckBox); }
            //set { PermitFormHelper.SetTextBoxValue(value, rescuePlanFormNumberTextBox, rescuePlanCheckBox); }
        }

       

        public int? VehicleEntryTotal
        {
            set;
            get;
            //get
            //{
            //    return PermitFormHelper.GetIntegerTextBoxValue(vehicleEntryTotalNumberTextBox, vehicleEntryCheckBox);
            //}
            //set
            //{
            //    PermitFormHelper.SetIntegerTextBoxValue(value, vehicleEntryTotalNumberTextBox, vehicleEntryCheckBox);
            //}
        }

        public string VehicleEntryType
        {
            set;
            get;
            //get { return PermitFormHelper.GetTextBoxValue(vehicleEntryTypeTextBox, vehicleEntryCheckBox); }
            //set { PermitFormHelper.SetTextBoxValue(value, vehicleEntryTypeTextBox, vehicleEntryCheckBox); }
        }

        
        public bool RoadAccessOnPermit
        {
            set;
            get;
            //get { return roadAccessOnPermitCheckBox.Checked; }
            //set
            //{
            //    roadAccessOnPermitCheckBox.Checked = value;
            //}
        }
        public string RoadAccessOnPermitFormNumber
        {
            set;
            get;
            //get { return PermitFormHelper.GetTextBoxValue(roadAccessOnPermitFormNumberTextBox, roadAccessOnPermitCheckBox); }
            //set { PermitFormHelper.SetTextBoxValue(value, roadAccessOnPermitFormNumberTextBox, roadAccessOnPermitCheckBox); }
        }

        public string RoadAccessOnPermitType
        {
            set;
            get;
            //get { return roadAccessOnPermitComboBox.Text; }
            //set { roadAccessOnPermitComboBox.Text = value; }
        }

       
        public FormGN59 FormGN59
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn59FormNumberTextBox, gn59CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN59) gn59FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn59FormNumberTextBox,
                    gn59CheckBox);
                gn59FormNumberTextBox.Tag = value;
            }
        }

        public bool GN59CheckBoxEnabled
        {
            set { gn59CheckBox.Enabled = value; }
        }

        public bool GN6
        {
            get { return gn6CheckBox.Checked; }
            set { gn6CheckBox.Checked = value; }
        }

        public FormGN6 FormGN6
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn6FormNumberTextBox, gn6CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN6) gn6FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn6FormNumberTextBox,
                    gn6CheckBox);
                gn6FormNumberTextBox.Tag = value;
            }
        }

        public bool GN7
        {
            get { return gn7CheckBox.Checked; }
            set { gn7CheckBox.Checked = value; }
        }

        public FormGN7 FormGN7
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn7FormNumberTextBox, gn7CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN7) gn7FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn7FormNumberTextBox,
                    gn7CheckBox);
                gn7FormNumberTextBox.Tag = value;
            }
        }

        public bool GN24
        {
            get { return gn24CheckBox.Checked; }
            set { gn24CheckBox.Checked = value; }
        }

        public FormGN24 FormGN24
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn24FormNumberTextBox, gn24CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN24) gn24FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn24FormNumberTextBox,
                    gn24CheckBox);
                gn24FormNumberTextBox.Tag = value;
            }
        }

        public bool GN75A
        {
            get { return gn75ACheckBox.Checked; }
            set { gn75ACheckBox.Checked = value; }
        }

        public FormGN75A FormGN75A
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn75AFormNumberTextBox, gn75ACheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN75A) gn75AFormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn75AFormNumberTextBox,
                    gn75ACheckBox);
                gn75AFormNumberTextBox.Tag = value;
            }
        }

        public bool GN1
        {
            get { return gn1CheckBox.Checked; }
            set { gn1CheckBox.Checked = value; }
        }

        public FormGN1 FormGN1
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn1FormNumberTextBox, gn1CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN1) gn1FormNumberTextBox.Tag;
            }
            set { gn1FormNumberTextBox.Tag = value; }
        }

        public string FormGN1TradeChecklistNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(gn1FormNumberTextBox, gn1CheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, gn1FormNumberTextBox, gn1CheckBox); }
        }

        public long? FormGN1TradeChecklistId { get; set; }

        public WorkPermitSafetyFormState GN11
        {
            get { return (WorkPermitSafetyFormState) gn11ComboBox.SelectedItem; }
            set { gn11ComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState GN27
        {
            get { return (WorkPermitSafetyFormState) gn27ComboBox.SelectedItem; }
            set { gn27ComboBox.SelectedItem = value; }
        }

        public List<WorkPermitSafetyFormState> GN11Values
        {
            set { gn11ComboBox.DataSource = value; }
        }

        public List<WorkPermitSafetyFormState> GN27Values
        {
            set { gn27ComboBox.DataSource = value; }
        }
        */

        #endregion

        #region Workers Minimum Safety Requirements

        
        //public string WorkersMonitorNumber { get; set;
        //    //get
        //    //{
        //    //    return PermitFormHelper.GetTextBoxValueForSection(workersMonitorNumberTextBox,
        //    //        workersMonitorNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
        //    //}
        //    //set
        //    //{
        //    //    PermitFormHelper.SetTextBoxValueForSection(value, workersMonitorNumberTextBox,
        //    //        workersMonitorNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
        //    //}
        //}
        //public string RadioChannelNumber { get; set;
        //    //get
        //    //{
        //    //    return PermitFormHelper.GetTextBoxValueForSection(radioChannelNumberTextBox, radioChannelNumberCheckBox,
        //    //        workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
        //    //}
        //    //set
        //    //{
        //    //    PermitFormHelper.SetTextBoxValueForSection(value, radioChannelNumberTextBox, radioChannelNumberCheckBox,
        //    //        workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
        //    //}
        //}


        //public String OthersPartE { get; set;
            //get
            //{
            //    return PermitFormHelper.GetTextBoxValueForSection(other4TextBox, other4CheckBox,
            //        workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            //}
            //set
            //{
            //    PermitFormHelper.SetTextBoxValueForSection(value, other4TextBox, other4CheckBox,
            //        workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            //}
        //}

        #endregion

        #region Error Setters
       
        public void SetErrorForEndDateMustBeOnOrAfterToday()
        {
            errorProvider.SetError(requestedStartDatePicker, "ESWPTODO");
        }

        public void SetErrorForNoStartTime()
        {
            errorProvider.SetError(requestedStartTimePicker, StringResources.WorkPermitEdmonton_NoStartTime);
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
        public void SetErrorForNoHazardsAndOrRequirements()//partD
        {
            errorProvider.SetError(hazardsAndOrRequirementsTextBox, StringResources.WorkPermitEdmonton_HazardsAndOrRequirementsEmpty);
        }
        //mangesh - for numeric field
        public void SetErrorForNoAlphaNumeric(string name)
        {
            errorProvider.SetError(workAndScopeDescriptionTextBox, StringResources.WorkPermit_OnlyNumeric);
        }

        public void SetErrorForNoContractor()
        {
            errorProvider.SetError(contractorComboBox, StringResources.WorkPermitEdmonton_ContractorEmpty);
        }
        public void SetErrorForNoIssuedToOptionSelected()
        {
            errorProvider.SetError(contractorComboBox, StringResources.WorkPermitEdmonton_NoIssuedToOptionChosen);
        }
        public void SetErrorForNumberOfWorkersLessThanOrEqualToZero()
        {
            errorProvider.SetError(numberOfWorkersTextBox,
                StringResources.WorkPermitEdmonton_NumberOfWorkersIsLessThanOrEqualtoZero);
        }

        //public void SetErrorForNoAreaAffected()
        //{
        //    errorProvider.SetError(areaComboBox, StringResources.WorkPermitEdmonton_AreaAffectedEmpty);
        //}

        //public void SetErrorForNoPersonNotified()
        //{
        //    errorProvider.SetError(personNotifiedTextBox, StringResources.WorkPermitEdmonton_PersonNotifiedEmpty);
        //}

        public void SetErrorForStartDateTimeNotBeforeEndDateTime()
        {
            errorProvider.SetError(requestedEndDatePicker, StringResources.EndDateBeforeStartDate);
        }

        public void SetErrorForNoOccupation()
        {
            errorProvider.SetError(occupationComboBox, StringResources.WorkPermitEdmonton_OccupationEmpty);
        }

        public void SetErrorForNoGroup()
        {
            errorProvider.SetError(groupComboBox, StringResources.WorkPermit_GroupEmpty);
        }

        public void SetErrorForNoLocation()
        {
            errorProvider.SetError(locationTextBox, StringResources.WorkPermit_LocationEmpty);
        }

        public void SetErrorForNoConfinedSpaceCardNumber(string message)
        {
           // warningProvider.SetError(confinedSpaceCardNumberTextBox, message);
        }

        public void SetErrorForNoConfinedSpaceClass(string message)
        {
            warningProvider.SetError(confinedSpaceClassComboBox, message);
        }

        public void SetErrorForNoRescuePlanFormNumber(string message)
        {
           //warningProvider.SetError(rescuePlanFormNumberTextBox, message);
        }
        /*
        public void SetErrorForNoClassOfClothing()
        {
           // errorProvider.SetError(classOfClothingComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoFlarePitEntryType()
        {
           // errorProvider.SetError(flarePitEntryTypeComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }
        public void SetErrorForNoApprovedGN59Form(string message)
        
        public void SetErrorForNoVehicleEntryTotalNumber()
        {
           // warningProvider.SetError(vehicleEntryTotalNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoVehicleEntryType()
        {
           // warningProvider.SetError(vehicleEntryTypeTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoSpecialWorkFormNumber()
        {
           // warningProvider.SetError(specialWorkFormNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoSpecialWorkType()
        {
            //warningProvider.SetError(specialWorkTypeComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
           // warningProvider.SetError(specialWorkComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoRoadAccessOnPermitFormNumber()
        {
         //   warningProvider.SetError(roadAccessOnPermitFormNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }
        public void SetErrorForNoRoadAccessOnPermit()
        {
         //   warningProvider.SetError(roadAccessOnPermitComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

       
        {
            warningProvider.SetError(selectFormGN59Button, message);
        }

        public void SetErrorForNoApprovedGN6Form(string message)
        {
            warningProvider.SetError(selectFormGN6Button, message);
        }

        public void SetErrorForNoApprovedGN7Form(string message)
        {
            warningProvider.SetError(selectFormGN7Button, message);
        }

        public void SetErrorForNoApprovedGN24Form(string message)
        {
            warningProvider.SetError(selectFormGN24Button, message);
        }

        public void SetErrorForNoApprovedGN75AForm(string message)
        {
            warningProvider.SetError(selectFormGN75AButton, message);
        }

        public void SetErrorForNoApprovedGN1Form(string message)
        {
            warningProvider.SetError(selectFormGN1Button, message);
        }

        //Start Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        public void ActionForValidTradeCheckGN1Form(string message) 
        {
            warningProvider.SetError(selectFormGN1Button, message);
        }
        //End Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016

        public void SetErrorForInvalidGN11Value(string message)
        {
            warningProvider.SetError(gn11ComboBox, message);
        }

        public void SetErrorForInvalidGN27Value(string message)
        {
            warningProvider.SetError(gn27ComboBox, message);
        }
        */
       
        public void SetErrorForOther1CheckedWithNoValue()
        {
            errorProvider.SetError(other1TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther2CheckedWithNoValue()
        {
            errorProvider.SetError(other2TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther3CheckedWithNoValue()
        {
            errorProvider.SetError(other3TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOtherPartECheckedWithNoValue()
        {
            errorProvider.SetError(othersPartETextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoSafetyRequirementChosen() //partC
        {
            errorProvider.SetError(workersMinimumSafetyRequirementsGroupBox,
                StringResources.WorkPermitEdmonton_NoSafetyRequirementChosen);
        }
        public void SetErrorForNoworkAuthorizationAndDocumentationChosen()//partE
        {
            errorProvider.SetError(workAuthorizationAndDocumentationGroupBox,
                StringResources.WorkPermitEdmonton_NoSafetyRequirementChosen);
        }
       
        #endregion


        public string ClonedFormDetailFortHills { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History
    }
}