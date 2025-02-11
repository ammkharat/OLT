using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using DevExpress.XtraSplashScreen;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ExcursionResponseForm : BaseForm, IExcursionResponseForm
    {
        private string lastUpdatedComment;
        private string lastUpdatedAsset;
        private string lastUpdatedCode;
        private string toeOpmHistoryUrl;
        private readonly SplashScreenManager splashScreenManager;

        public ExcursionResponseForm()
        {
            components = null;
            InitializeComponent();
            excursionsToUpdateOltGrid.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;
            excursionsToUpdateOltGrid.DisplayLayout.Override.RowSizingAutoMaxLines = 3;
            excursionsToUpdateOltGrid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True;
            excursionsToUpdateOltGrid.DisplayLayout.Override.CellAppearance.TextTrimming = TextTrimming.EllipsisWord;
            excursionsToUpdateOltGrid.AfterCellUpdate += ExcursionsToUpdateOltGridOnAfterCellUpdate;
            excursionsToUpdateOltGrid.AfterSelectChange += ExcursionsToUpdateOltGridOnAfterSelectChange;
            viewTrendButton.Click += ViewTrendButtonOnClick;
            toeDefinitionHistoryButton.Click += ToeHistoryButtonOnClick;
            excursionsToUpdateOltGrid.AfterCellUpdate += ExcursionsToUpdateOltGridOnAfterCellUpdate;
            copyLastResponseButton.Click += CopyLastResponseButtonOnClick;
            toeEngineerCommentYes.Click += ToeEngineerCommentYesNoOnClick;
            toeEngineerCommentNo.Click += ToeEngineerCommentYesNoOnClick;
            cancelButton.Click += HandleCancelButtonClicked;
            saveAndCloseButton.Click += HandleSaveButtonClicked;
            splashScreenManager = new SplashScreenManager(ParentForm, typeof(WaitForm), true, true);

        }

        private ExcursionResponseEditingGridRowDTO SelectedExcursionResponseRow
        {
            get
            {
                var ultraGridRow = excursionsToUpdateOltGrid.ActiveRow;
                if (ultraGridRow == null) return null;
                var excursionResponseEditingGridRowDTO = ultraGridRow.ListObject as ExcursionResponseEditingGridRowDTO;
                return excursionResponseEditingGridRowDTO;
            }
        }

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public string ExcursionToeName
        {
            set { excursionToeNameLabelValue.Text = value; }
        }

        public string CurrentTagValue
        {
            set
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate { currentTagValueLabelValue.Text = value; }));
                }
                else
                {
                    currentTagValueLabelValue.Text = value;
                }
            }
        }

        public string ExcursionHistorianTag
        {
            set { excursionHistorianTagValueLabel.Text = value; }
            get { return excursionHistorianTagValueLabel.Text; }
        }

        public string ExcursionUnitOfMeasure
        {
            set { excursionUnitValueLabel.Text = value; }
        }

        public string ToeOpmHistoryUrl
        {
            set
            {
                toeOpmHistoryUrl = value;
                toeDefinitionHistoryButton.Enabled = !value.IsNullOrEmptyOrWhitespace();
            }
        }

        public bool CopyToLog
        {
            get { return copyResponseToLogCheckBox.Checked; }
        }

        public bool EditEnabled
        {
            set
            {
                excursionsToUpdateOltGrid.DisplayLayout.Bands[0].Columns["ExcursionResponseComment"].CellActivation =
                    (value) ? Activation.AllowEdit : Activation.NoEdit;
                copyResponseToLogCheckBox.Enabled = value;
                copyLastResponseButton.Enabled = value;
                blindsRequiredPanel.Enabled = value;
                saveAndCloseButton.Enabled = value;
            }
        }

        public string ToeFloc
        {
            set { toeFunctionalLocationValueLabel.Text = value; }
        }

        public DateTime? ToePublishDate
        {
            set { toePublishDateValueLabel.Text = value.ToShortDateAndTimeStringOrEmptyString(); }
        }

        public bool IsToeDefinitionCommentingEnabled
        {
            set
            {
                toeEngineerCommentYes.Enabled = value;
                toeEngineerCommentNo.Enabled = value;
            }
            get { return toeEngineerCommentYes.Enabled; }
        }

        public bool HasCommentForEngineer
        {
            set
            {
                toeEngineerCommentYes.Checked = value;
                toeEngineerCommentNo.Checked = !value;
                toeDefinitionOltCommentsForEngineerTextBox.Enabled = value;
            }
            get { return toeEngineerCommentYes.Checked; }
        }

        public string ToeCommentForEngineer
        {
            set { toeDefinitionOltCommentsForEngineerTextBox.Text = value; }
            get { return toeDefinitionOltCommentsForEngineerTextBox.Text; }
        }

        public string ToeCauseOfDeviation
        {
            set { toeCauseOfDeviationOltTextBox.Text = value; }
        }

        public string ToeReferenceDocuments
        {
            set { documentLinksControl.Text = value; }
        }

        public string ToeConsequencesOfDeviation
        {
            set { toeConsequencesOfDeviationOltTextBox.Text = value; }
        }

        public string ToeCorrectiveActions
        {
            set { toeDefinitionCorrectiveActionOltTextBox.Text = value; }
        }

        public List<ExcursionResponseEditingGridRowDTO> ExcursionsToUpdate
        {
            get { return (List<ExcursionResponseEditingGridRowDTO>) excursionsToUpdateOltGrid.DataSource; }
            set
            {
                excursionsToUpdateOltGrid.DataSource = value;
                excursionsToUpdateOltGrid.ResetBindings();
                viewTrendButton.Enabled = value.Count > 0 && !value.First().OpmTrendUrl.IsNullOrEmptyOrWhitespace();
            }
        }

        public string MostRecentExcursionResponseComment
        {
            set
            {
                lastUpdatedComment = value; 
                
            }
        }

        public string MostRecentExcursionAsset
        {
            set
            {
                lastUpdatedAsset = value;

            }
        }

        public string MostRecentExcursionResponseCode
        {
            set
            {
                lastUpdatedCode = value;

            }
        }

        public void SetErrorForMissingResponses()
        {
            errorProvider.SetError(excursionsToUpdateOltGrid, "All Exursions must have a Response");
        }

        public void SetErrorForMissingToeCommentForEngineer()
        {
            errorProvider.SetError(toeDefinitionOltCommentsForEngineerTextBox,
                "Comment for Engineer is required when Yes is checked");
        }

        public event Action HistoryButtonClicked;

        private void HandleSaveButtonClicked(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                splashScreenManager.ShowWaitForm();
                SaveButtonClicked(sender, e);
                splashScreenManager.CloseWaitForm();
                splashScreenManager.WaitForSplashFormClose();    
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void ToeEngineerCommentYesNoOnClick(object sender, EventArgs eventArgs)
        {
            if (!toeDefinitionOltCommentsForEngineerTextBox.Text.IsNullOrEmptyOrWhitespace() &&
                toeEngineerCommentNo.Checked)
            {
                toeDefinitionOltCommentsForEngineerTextBox.Text = null;
            }

            ToggleComments();
        }

        private void ToggleComments()
        {
            toeDefinitionOltCommentsForEngineerTextBox.Enabled = toeEngineerCommentYes.Checked;
        }

        private void CopyLastResponseButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (lastUpdatedComment.IsNullOrEmptyOrWhitespace()) return;
            excursionsToUpdateOltGrid.BeginUpdate();
            var excursions = ExcursionsToUpdate;
            foreach (var excursion in excursions)
            {
                if (excursion.ExcursionResponseComment.IsNullOrEmptyOrWhitespace())
                {
                    excursion.ExcursionResponseComment = lastUpdatedComment;
                    //excursion.Assest = lastUpdatedAsset;
                    //excursion.Code = lastUpdatedCode;
                }
                if (excursion.Assest.IsNullOrEmptyOrWhitespace())
                {
                    excursion.Assest = lastUpdatedAsset;
                    //excursion.Code = lastUpdatedCode;
                }
                if (excursion.Code.IsNullOrEmptyOrWhitespace())
                {
                    //excursion.Assest = lastUpdatedAsset;
                    excursion.Code = lastUpdatedCode;
                }
               
            }
            ExcursionsToUpdate = excursions;
            excursionsToUpdateOltGrid.EndUpdate();
        }

        private void SetupTrendUrl()
        {
            viewTrendButton.Enabled = SelectedExcursionResponseRow != null &&
                                      !SelectedExcursionResponseRow.OpmTrendUrl.IsNullOrEmptyOrWhitespace();
        }

        private void ExcursionsToUpdateOltGridOnAfterSelectChange(object sender,
            AfterSelectChangeEventArgs afterSelectChangeEventArgs)
        {
            SetupTrendUrl();
        }

        private void ViewTrendButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (SelectedExcursionResponseRow != null &&
                !SelectedExcursionResponseRow.OpmTrendUrl.IsNullOrEmptyOrWhitespace())
            {
                UIUtils.LaunchURL(SelectedExcursionResponseRow.OpmTrendUrl);
            }
        }

        private void ToeHistoryButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (toeOpmHistoryUrl.IsNullOrEmptyOrWhitespace()) return;
            UIUtils.LaunchURL(toeOpmHistoryUrl);
        }


        private void ExcursionsToUpdateOltGridOnAfterCellUpdate(object sender, CellEventArgs cellEventArgs)
        {
            var ultraGridCell = cellEventArgs.Cell;
            ultraGridCell.Row.PerformAutoSize();
            if (ultraGridCell.Column.Key == "ExcursionResponseComment" &&
                !ultraGridCell.Text.IsNullOrEmptyOrWhitespace())
            {
                lastUpdatedComment = ultraGridCell.Text;
            }
            if (ultraGridCell.Column.Key == "Assest" &&
                !ultraGridCell.Text.IsNullOrEmptyOrWhitespace())
            {
                lastUpdatedAsset = ultraGridCell.Text;
            }
            if (ultraGridCell.Column.Key == "Code" &&
                !ultraGridCell.Text.IsNullOrEmptyOrWhitespace())
            {
                lastUpdatedCode = ultraGridCell.Text;
            }
        }
//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM

        private void excursionsToUpdateOltGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
             foreach (UltraGridColumn column in e.Layout.Bands[0].Columns)
             {
                 string key = column.Key;

                 switch (key)
                 {
                     case "Assest":

                         if (ClientSession.GetUserContext().Site.Id == Common.Domain.Site.FORT_HILLS_ID)
                         {
                             ValueList vl = new ValueList();

                             #region Assign values to dropdown

                             //vl.ValueListItems.Add("Shovels");
                             //vl.ValueListItems.Add("Shift Change");
                             //vl.ValueListItems.Add("Trucks");
                             //vl.ValueListItems.Add("Support Equipment");
                             //vl.ValueListItems.Add("Incident");
                             //vl.ValueListItems.Add("Crushing Plant 1");
                             //vl.ValueListItems.Add("Crushing Plant 2");
                             //vl.ValueListItems.Add("Slurry Prep 1");
                             //vl.ValueListItems.Add("Slurry Prep 2");
                             //vl.ValueListItems.Add("Slurry Prep 3");
                             //vl.ValueListItems.Add("Extraction Train 1");
                             //vl.ValueListItems.Add("Extraction Train 2");
                             //vl.ValueListItems.Add("Tailings 1");
                             //vl.ValueListItems.Add("Tailings 2");
                             //vl.ValueListItems.Add("Tailings 3");
                             //vl.ValueListItems.Add("Secondary");
                             //vl.ValueListItems.Add("Utilities");
                             //vl.ValueListItems.Add("Ore");
                             //vl.ValueListItems.Add("Other");

                             vl.ValueListItems.Add("Ore");
                             vl.ValueListItems.Add("Shovels");
                             vl.ValueListItems.Add("Trucks");
                             vl.ValueListItems.Add("Support Equipment");
                             vl.ValueListItems.Add("Crushing Plant 1 General");
                             vl.ValueListItems.Add("Crushing Plant 1 Apron Feeder");
                             vl.ValueListItems.Add("Crushing Plant 1 Sizer");
                             vl.ValueListItems.Add("Crushing Plant 1 Conveyor");
                             vl.ValueListItems.Add("Crushing Plant 2");
                             vl.ValueListItems.Add("Crushing Plant 2 Apron Feeder");
                             vl.ValueListItems.Add("Crushing Plant 2 Sizer");
                             vl.ValueListItems.Add("Crushing Plant 2 Conveyor");
                             vl.ValueListItems.Add("Surge Bin General");
                             vl.ValueListItems.Add("Ore Prep Common Systems");
                             vl.ValueListItems.Add("Slurry Prep 1 General");
                             vl.ValueListItems.Add("Slurry Prep 1 Apron Feeder");
                             vl.ValueListItems.Add("Slurry Prep 1 RWS");
                             vl.ValueListItems.Add("Slurry Prep 1 HT Pumps");
                             vl.ValueListItems.Add("Slurry Prep 1 HT Line");
                             vl.ValueListItems.Add("Slurry Prep 2 General");
                             vl.ValueListItems.Add("Slurry Prep 2 Apron Feeder");
                             vl.ValueListItems.Add("Slurry Prep 2 RWS");
                             vl.ValueListItems.Add("Slurry Prep 2 HT Pumps");
                             vl.ValueListItems.Add("Slurry Prep 2 HT Line");
                             vl.ValueListItems.Add("Slurry Prep 3 General");
                             vl.ValueListItems.Add("Slurry Prep 3 Apron Feeder");
                             vl.ValueListItems.Add("Slurry Prep 3 RWS");
                             vl.ValueListItems.Add("Slurry Prep 3 HT Pumps");
                             vl.ValueListItems.Add("Slurry Prep 3 HT Line");
                             vl.ValueListItems.Add("Extraction Common Systems");
                             vl.ValueListItems.Add("Extraction Train 1 General");
                             vl.ValueListItems.Add("Extraction Train 1 PSC");
                             vl.ValueListItems.Add("Extraction Train 1 Floatation");
                             vl.ValueListItems.Add("Extraction Train 1 Cyclopaks");
                             vl.ValueListItems.Add("Extraction Train 1 Thickener");
                             vl.ValueListItems.Add("Tailings 1");
                             vl.ValueListItems.Add("Extraction Train 2 General");
                             vl.ValueListItems.Add("Extraction Train 2 PSC");
                             vl.ValueListItems.Add("Extraction Train 2 Floatation");
                             vl.ValueListItems.Add("Extraction Train 2 Cyclopaks");
                             vl.ValueListItems.Add("Extraction Train 2 Thickener");
                             vl.ValueListItems.Add("Tailings 2");
                             vl.ValueListItems.Add("Tailings 3");
                             vl.ValueListItems.Add("FSU1/TSRU1");
                             vl.ValueListItems.Add("FSU2TSRU2");
                             vl.ValueListItems.Add("FSU3/TSRU3");
                             vl.ValueListItems.Add("TSRU Second Stage");
                             vl.ValueListItems.Add("SRU1");
                             vl.ValueListItems.Add("SRU2");
                             vl.ValueListItems.Add("Utilities");
                             vl.ValueListItems.Add("External");
                             vl.ValueListItems.Add("Other");


                             column.ValueList = vl;
#endregion

                         }
                         else
                         {
                             column.Hidden = true;
                         }
                         break;
                 }

                 switch (key)

                 {
                     case "Code":

                         if (ClientSession.GetUserContext().Site.Id == Common.Domain.Site.FORT_HILLS_ID)
                         {
                             ValueList vl = new ValueList();

        #region Assign values to dropdown

                             //vl.ValueListItems.Add("GET - Replace/Repair");
                             //vl.ValueListItems.Add("Shovel Move/Relocation");
                             //vl.ValueListItems.Add("Cable/Utility Work ");
                             //vl.ValueListItems.Add("Shovel Availability ");
                             //vl.ValueListItems.Add("Frozen Lumps");
                             //vl.ValueListItems.Add("Damage");
                             //vl.ValueListItems.Add("Having Bucket Cleaned");
                             //vl.ValueListItems.Add("Stuck");
                             //vl.ValueListItems.Add("High D50");
                             //vl.ValueListItems.Add("High Fines");
                             //vl.ValueListItems.Add("Split face");
                             //vl.ValueListItems.Add("Waste");
                             //vl.ValueListItems.Add("Other blend restriction");
                             //vl.ValueListItems.Add("Air Compressor/Hydraulics/Mechanical ");
                             //vl.ValueListItems.Add("Face Prep/Overhang/Pit Clean up");
                             //vl.ValueListItems.Add("Other");
                             //vl.ValueListItems.Add("Safety stand down");
                             //vl.ValueListItems.Add("Park-up Congestion/Start up Delay");
                             //vl.ValueListItems.Add("Shift Change Bus/Truck Availability ");
                             //vl.ValueListItems.Add("Soft pit conditions");
                             //vl.ValueListItems.Add("Visibility (Dust/Dawn/Dusk)");
                             //vl.ValueListItems.Add("Long Haul/Roads/Routes");
                             //vl.ValueListItems.Add("Operators");
                             //vl.ValueListItems.Add("Availability");
                             //vl.ValueListItems.Add("AHS");
                             //vl.ValueListItems.Add("Haul road restriction");
                             //vl.ValueListItems.Add("Dozer");
                             //vl.ValueListItems.Add("RTD");
                             //vl.ValueListItems.Add("Loader");
                             //vl.ValueListItems.Add("Excavator");
                             //vl.ValueListItems.Add("EMS Entry/Emergency in Mine");
                             //vl.ValueListItems.Add("Fire");
                             //vl.ValueListItems.Add("Power Supply");
                             //vl.ValueListItems.Add("Equipment Damage ");
                             //vl.ValueListItems.Add("Right of Way/Mine Rule Violation");
                             //vl.ValueListItems.Add("Weather");
                             //vl.ValueListItems.Add("Sizer");
                             //vl.ValueListItems.Add("Conveyor");
                             //vl.ValueListItems.Add("Apron Feeder");
                             //vl.ValueListItems.Add("Voith Coupling");
                             //vl.ValueListItems.Add("Back feeding");
                             //vl.ValueListItems.Add("Pluggage");
                             //vl.ValueListItems.Add("RWS");
                             //vl.ValueListItems.Add("HT pump speed");
                             //vl.ValueListItems.Add("HT pump motor load");
                             //vl.ValueListItems.Add("HT Pressure");
                             //vl.ValueListItems.Add("Rupture disc/leaks");
                             //vl.ValueListItems.Add("Instrument Air");
                             //vl.ValueListItems.Add("PSC UF Velocity");
                             //vl.ValueListItems.Add("PSC UF Density");
                             //vl.ValueListItems.Add("PSC UF Pump Performance");
                             //vl.ValueListItems.Add("High Middlings Density");
                             //vl.ValueListItems.Add("Tertiary's");
                             //vl.ValueListItems.Add("Secondary's");
                             //vl.ValueListItems.Add("Cyclopak/Thickener bypass");
                             //vl.ValueListItems.Add("Leak");
                             //vl.ValueListItems.Add("Line pressure");
                             //vl.ValueListItems.Add("Tailings Density");
                             //vl.ValueListItems.Add("Flow");
                             //vl.ValueListItems.Add("Pump Speed");
                             //vl.ValueListItems.Add("Pump Motor Load");
                             //vl.ValueListItems.Add("leaks (include rupture disk events)");
                             //vl.ValueListItems.Add("delay in RTS");
                             //vl.ValueListItems.Add("Pacing froth inventory");
                             //vl.ValueListItems.Add("Fouling/skin temps");
                             //vl.ValueListItems.Add("Unplanned maintenance");
                             //vl.ValueListItems.Add("CLCW");
                             //vl.ValueListItems.Add("Utility Instrument Air");
                             //vl.ValueListItems.Add("Steam");
                             //vl.ValueListItems.Add("Power Supply");
                             //vl.ValueListItems.Add("Hot Process Water");
                             //vl.ValueListItems.Add("Process Effected Water");



                             vl.ValueListItems.Add("Availability");
                             vl.ValueListItems.Add("Shovel Move/Relocation");
                             vl.ValueListItems.Add("Frozen Lumps");
                             vl.ValueListItems.Add("Damage");
                             vl.ValueListItems.Add("Stuck");
                             vl.ValueListItems.Add("High D50");
                             vl.ValueListItems.Add("High Fines");
                             vl.ValueListItems.Add("Split Face");
                             vl.ValueListItems.Add("Prioritizing Waste");
                             vl.ValueListItems.Add("Waste");
                             vl.ValueListItems.Add("Other blend restriction");
                             vl.ValueListItems.Add("Ore Availability");
                             vl.ValueListItems.Add("Other");
                             vl.ValueListItems.Add("Incident");
                             vl.ValueListItems.Add("Shift Change");
                             vl.ValueListItems.Add("Pit / Road Conditions");
                             vl.ValueListItems.Add("AHS");
                             vl.ValueListItems.Add("Haul road restriction");
                             vl.ValueListItems.Add("Foreign material");
                             vl.ValueListItems.Add("Equipment Damage ");
                             vl.ValueListItems.Add("Weather");
                             vl.ValueListItems.Add("Back feeding");
                             vl.ValueListItems.Add("Pluggage");
                             vl.ValueListItems.Add("Trip");
                             vl.ValueListItems.Add("Throughput");
                             vl.ValueListItems.Add("Temperature");
                             vl.ValueListItems.Add("Pressure");
                             vl.ValueListItems.Add("Density");
                             vl.ValueListItems.Add("Velocity / Flow");
                             vl.ValueListItems.Add("Speed");
                             vl.ValueListItems.Add("Load");
                             vl.ValueListItems.Add("Instrument Air");
                             vl.ValueListItems.Add("Rupture disc");
                             vl.ValueListItems.Add("Leak");
                             vl.ValueListItems.Add("Cyclopak/Thickener bypass");
                             vl.ValueListItems.Add("Line Switch-Ped Swap");
                             vl.ValueListItems.Add("Froth Tank Level");
                             vl.ValueListItems.Add("Pacing Froth Inventory");
                             vl.ValueListItems.Add("Fouling/skin temps");
                             vl.ValueListItems.Add("Planned maintenance");
                             vl.ValueListItems.Add("Unplanned maintenance");
                             vl.ValueListItems.Add("CLCW");
                             vl.ValueListItems.Add("Steam");
                             vl.ValueListItems.Add("Power Supply");
                             vl.ValueListItems.Add("Hot Process Water");
                             vl.ValueListItems.Add("Process Effected Water");
                             vl.ValueListItems.Add("Bit % higher than plan");
                             vl.ValueListItems.Add("Bit % higher than predicted model");
                             vl.ValueListItems.Add("Bit % lower than plan");
                             vl.ValueListItems.Add("Bit % lower than predicted model");
                             vl.ValueListItems.Add("Recovery below plan");
                             vl.ValueListItems.Add("Recovery above plan");
                             vl.ValueListItems.Add("Filling bin so less froth make per ton of ore delivered");
                             vl.ValueListItems.Add("Drawing down bin so more froth make per ton of ore delivered");
                             vl.ValueListItems.Add("Off feed event");
                             vl.ValueListItems.Add("Flaring");


#endregion

                             column.ValueList = vl;
                             
                             
                         }
                         else
                         {
                             column.Hidden = true;
                         }
                         break;
                        
                 }
             }
        }
    }
}