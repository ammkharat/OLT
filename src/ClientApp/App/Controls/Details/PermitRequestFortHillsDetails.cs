using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class PermitRequestFortHillsDetails : AbstractDetails, IPermitRequestFortHillsDetails
    {
        private readonly Dictionary<Control, int> originalControlHeights = new Dictionary<Control, int>();

        public event EventHandler RefreshAll;
            
        public PermitRequestFortHillsDetails()
        {
            InitializeComponent();

            deleteButton.Click += DeleteButton_Click;
            importButton.Click += ImportButton_Click;
            cloneButton.Click += CloneButton_Click;
            editHistoryButton.Click += HistoryButton_Click;
            exportAllButton.Click += ExportAllButton_Click;

            editButton.Click += EditButton_Click;
            submitButton.Click += SubmitButton_Click;

            mainPanel.Layout += HandleMainPanelLayout;
            Disposed += HandleDisposed;
        }

        protected override Panel Details
        {
            get { return mainPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        protected bool ShowSapDescription
        {
            set
            {
                currentSAPDescriptionGroupBox.Visible = value;
                currentSapDescriptionTextBox.Visible = value;
            }
        }

        //protected bool ShowLastImportData
        //{
        //    set
        //    {
        //        //lastImportedDateTimeLabelPanel.Visible = value;
        //        //lastImportedTableLayoutPanel.Visible = value;
        //    }
        //}

        public event EventHandler Delete;
        public event EventHandler Clone;
        public event EventHandler Edit;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;
        public event EventHandler Submit;
        public event EventHandler Import;

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public bool SubmitEnabled
        {
            set { submitButton.Enabled = value; }
        }

        public bool ImportEnabled
        {
            set { importButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                EditButton_Click(this, new EventArgs());
            }
        }

        public void SetDetails(PermitRequestFortHills request)
        {
            if (request == null)
            {
                lastSubmittedDateDataLabel.Text = string.Empty;
                lastSubmittedByDataLabel.Text = string.Empty;

                lastModifiedByDataLabel.Text = string.Empty;
                lastModifiedDateDataLabel.Text = string.Empty;

                priorityDataLabel.Text = string.Empty;
                contractorCheckBox.Checked = false;
                suncorEnergyCheckBox.Checked = false;
                occupationDataLabel.Text = string.Empty;
                numberOfWorkersDataLabel.Text = string.Empty;
                groupDataLabel.Text = string.Empty;

                workPermitTypeDataLabel.Text = string.Empty;
                functionalLocationDataLabel.Text = string.Empty;
                locationOfWorkDataLabel.Text = string.Empty;
                requestedStartDataLabel.Text = string.Empty;
                workOrderNumberDataLabel.Text = string.Empty;
                operationNumberDataLabel.Text = string.Empty;
                subOperationDataLabel.Text = string.Empty;
                taskDescriptionTextBox.Text = string.Empty;
                currentSapDescriptionTextBox.Text = string.Empty;
                hazardsAndOrRequirementsTextBox.Text = string.Empty;
                ShowSapDescription = false;
                documentLinksControl.DataSource = new List<DocumentLink>();
                confinedSpaceClassDataLabel.Text = string.Empty;
                
                //classOfClothingDataLabel.Text = string.Empty;
                //flarePitEntryTypeDataLabel.Text = string.Empty;
                //confinedSpaceCardNumberDataLabel.Text = string.Empty;
                //rescuePlanFormNumberDataLabel.Text = string.Empty;
                //specialWorkTypeDataLabel.Text = string.Empty;
                //specialWorkFormNumber.Text = string.Empty;
                //roadAccessOnPermitType.Text = string.Empty;//mangesh for RoadAccessOnPermit 
                //roadAccessOnPermitFormNo.Text = string.Empty;
                //gn1FormNumberDataLabel.Text = string.Empty;
                //gn59FormNumberDataLabel.Text = string.Empty;
                //gn6FormNumberDataLabel.Text = string.Empty;
                //gn7FormNumberDataLabel.Text = string.Empty;
                //gn24FormNumberDataLabel.Text = string.Empty;
                //gn75AFormNumberDataLabel.Text = string.Empty;
                //gn11DataLabel.Text = string.Empty;
                //gn27DataLabel.Text = string.Empty;
                //requestedStartTimeDayDataLabel.Text = string.Empty;
                //requestedStartTimeNightDataLabel.Text = string.Empty;
               

               // ShowLastImportData = true;
               // areaLabelDataLabel.Text = string.Empty;
            }
            else
            {

               

                lastModifiedByDataLabel.Text = request.LastModifiedBy.NullableToString();
                lastModifiedDateDataLabel.Text = request.LastModifiedDateTime.ToLongDateAndTimeString();
                lastSubmittedByDataLabel.Text = request.LastSubmittedByUser.NullableToString();
                lastSubmittedDateDataLabel.Text = request.LastSubmittedDateTime.ToLongDateAndTimeStringOrEmptyString();

                contractorCheckBox.Checked = !request.Company.IsNullOrEmptyOrWhitespace();
                contractorCheckBox.Text = string.Format(StringResources.WorkPermitEdmonton_ContractorDetailLabel,
                    request.Company);
                suncorEnergyCheckBox.Checked = request.IssuedToSuncor;
                occupationDataLabel.Text = request.Occupation;
                numberOfWorkersDataLabel.Text = request.NumberOfWorkers.NullableToString();
                groupDataLabel.Text = request.Group.NullableToString();

                priorityDataLabel.Text = request.Priority.GetName();
                workPermitTypeDataLabel.Text = request.WorkPermitType.ToString();

                functionalLocationDataLabel.Text = request.FunctionalLocation.FullHierarchyWithDescription;
                locationOfWorkDataLabel.Text = request.Location;

                vehicleEntryCheckBox.Checked = request.VehicleEntry;

                requestedStartDataLabel.Text = string.Join(" ",request.RequestedStartDate.ToString(),request.RequestedStartTime.ToString());
                requestedEndDataLabel.Text = string.Join(" ", request.EndDate.ToString(), request.RequestedEndTime.ToString());
                //if (request.RevalidationDate != DateTime.MinValue.ToDate() && request.RevalidationTime != null)
                //{
                //    revalidationDateLabelData.Text = string.Join(" ", request.RevalidationDate.ToString(),request.RevalidationTime.ToString());
                //}
                //else{revalidationDateLabelData.Text = string.Empty;}

                //if (request.ExtensionDate != DateTime.MinValue.ToDate() && request.ExtensionTime !=null)
                //{
                //    extensionDateLabelData.Text = string.Join(" ", request.ExtensionDate.ToString(), request.ExtensionTime.ToString());
                //}
                // else {extensionDateLabelData.Text = string.Empty;}


                craftLabel.Text = request.Craft;
                crewSizeLabel.Text = request.Craft;
                jobCoordinatorLabelData.Text = request.JobCoordinator;
                CoOrdContactNoLabelData.Text = request.CoOrdContactNumber;
                EmergencyAssemblyAreaLabelData.Text = request.EmergencyAssemblyArea;
                EmergencyMeetingPointLabelData.Text = request.EmergencyMeetingPoint;
                emergencyContactNoLabelData.Text = request.EmergencyContactNo;
                equipomentNoLabelData.Text = request.EquipmentNo;
                if (request.LockBoxnumberChecked )
                LockBoxnumberCheckedLabelData.Text = "Yes";
                else
                LockBoxnumberCheckedLabelData.Text = "No";

                workOrderNumberDataLabel.Text = request.WorkOrderNumber;
                operationNumberDataLabel.Text = request.OperationNumberListAsString;
                toolTip.SetToolTip(operationNumberGroupBox, request.OperationNumberListAsString);
                subOperationDataLabel.Text = request.SubOperationNumberListAsString;
                toolTip.SetToolTip(subOperationNumberGroupBox, request.SubOperationNumberListAsString);
                
                taskDescriptionTextBox.Text = request.Description;
                currentSapDescriptionTextBox.Text = request.SapDescription;
                hazardsAndOrRequirementsTextBox.Text = request.HazardsAndOrRequirements;

                ShowSapDescription = request.IsSAPDescriptionAvailableForDisplay;
                ShowSapDescription = request.DataSource.Id == DataSource.SAP.Id &&
                                     request.Description != request.SapDescription;

                flameResistantWorkWearCheckBox.Checked = request.FlameResistantWorkWear;
                chemicalSuitCheckBox.Checked = request.ChemicalSuit;
                fireBlanketCheckBox.Checked = request.FireBlanket;
                fireWatchCheckBox.Checked = request.FireWatch;
                suppliedBreathingAir.Checked = request.SuppliedBreathingAir;
                airMoverCheckBox.Checked = request.AirMover;
                personalFlotationDeviceCheckBox.Checked = request.PersonalFlotationDevice;
                hearingProtectionCheckBox.Checked = request.HearingProtection;
                other1CheckBox.Checked = !request.Other1.IsNullOrEmptyOrWhitespace();
                other1ValueDataLabel.Text = request.Other1;

                MonoGogglesCheckBox.Checked = request.MonoGoggles;
                confinedSpaceMoniterCheckBox.Checked = request.ConfinedSpaceMoniter;
                fireExtinguisherCheckBox.Checked = request.FireExtinguisher;
                sparkContainmentCheckBox.Checked = request.SparkContainment;
                BottleWatchCheckBox.Checked = request.BottleWatch;
                standbyPersonCheckBox.Checked = request.StandbyPerson;
                WorkingAloneCheckBox.Checked = request.WorkingAlone;
                safetyGlovesCheckBox.Checked = request.SafetyGloves;
                other2CheckBox.Checked = !request.Other2.IsNullOrEmptyOrWhitespace();
                other2ValueDataLabel.Text = request.Other2;

                faceShieldCheckBox.Checked = request.FaceShield;
                fallProtectionCheckBox.Checked = request.FallProtection;
                chargedFireHouseCheckBox.Checked = request.ChargedFireHouse;
                coveredSewerCheckBox.Checked = request.CoveredSewer;
                airPurifyingRespiratorCheckBox.Checked = request.AirPurifyingRespirator;
                singalPersonCheckBox.Checked = request.SingalPerson;
                communicationDeviceCheckBox.Checked = request.CommunicationDevice;
                reflectiveStripsCheckBox.Checked = request.ReflectiveStrips;
                other3CheckBox.Checked = !request.Other3.IsNullOrEmptyOrWhitespace();
                other3ValueDataLabel.Text = request.Other3;

                confinedSpaceCheckBox.Checked = request.ConfinedSpace;
                confinedSpaceClassDataLabel.Text = request.ConfinedSpaceClass;
                groundDisturbanceCheckBox.Checked = request.GroundDisturbance;
                fireProtectionAuthorizationCheckBox.Checked = request.FireProtectionAuthorization;
                criticalOrSeriousLiftsCheckBox.Checked = request.CriticalOrSeriousLifts;
                vehicleEntryCheckBox.Checked = request.VehicleEntry;
                industrialRadiographyCheckBox.Checked = request.IndustrialRadiography;
                electricalEncroachmentCheckBox.Checked = request.ElectricalEncroachment;
                mSDSCheckBox.Checked = request.MSDS;
                othersPartECheckBox.Checked = !request.OthersPartE.IsNullOrEmptyOrWhitespace();
                OthersPartEValueDataLabel.Text = request.OthersPartE;

                documentLinksControl.DataSource = request.DocumentLinks;
                
                AdjustTextBoxHeights();
            }
        }

        private void HandleDisposed(object sender, EventArgs e)
        {
            originalControlHeights.Clear();
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        private void CloneButton_Click(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(this, e);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Submit != null)
            {
                Submit(this, e);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (Import != null)
            {
                Import(this, e);
            }
        }

        private void AdjustTextBoxHeights()
        {
            StoreOriginalHeight(taskDescriptionGroupBox);
            StoreOriginalHeight(hazardsAndOrRequirementsGroupBox);
            StoreOriginalHeight(currentSAPDescriptionGroupBox);

            taskDescriptionGroupBox.Height = originalControlHeights[taskDescriptionGroupBox];
            hazardsAndOrRequirementsGroupBox.Height = originalControlHeights[hazardsAndOrRequirementsGroupBox];
            currentSAPDescriptionGroupBox.Height = originalControlHeights[currentSAPDescriptionGroupBox];

            AdjustTextBoxHeightToFitText(taskDescriptionTextBox, taskDescriptionGroupBox);
            AdjustTextBoxHeightToFitText(hazardsAndOrRequirementsTextBox, hazardsAndOrRequirementsGroupBox);
            AdjustTextBoxHeightToFitText(currentSapDescriptionTextBox, currentSAPDescriptionGroupBox);
        }

        private void StoreOriginalHeight(OltGroupBox control)
        {
            if (!originalControlHeights.ContainsKey(control))
            {
                originalControlHeights.Add(control, control.Height);
            }
        }

        private void AdjustTextBoxHeightToFitText(TextBox textBox, GroupBox containerGroupBox)
        {
            var oldContainerHeight = containerGroupBox.Height;
            var size = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, Int32.MaxValue),
                TextFormatFlags.WordBreak);
            var heightRequired = size.Height + 30;
            if (heightRequired > oldContainerHeight)
            {
                containerGroupBox.Height = heightRequired;
            }
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone



        public event EventHandler MarkAsTemplate;

        public bool MarkTemplateEnabled
        {
            set { }
        }


        public bool DeleteVisible
        {
            set { }
        }

        public bool editVisible
        {
            set { }
        }

        public bool editHistoryButtonVisible
        {
            set { }
        }

        public bool submitButtonVisible
        {
            set { }
        }


        public bool editTemplateVisible
        {
            set {  }
        }

        public event EventHandler EditTemplate;
    }
}