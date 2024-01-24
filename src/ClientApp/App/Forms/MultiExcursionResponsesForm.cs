using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Excursions;
using DevExpress.XtraSplashScreen;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class MultiExcursionResponsesForm : BaseForm, IMultiExcursionResponsesForm
    {
        private readonly SplashScreenManager splashScreenManager;

        public MultiExcursionResponsesForm()
        {
            components = null;
            InitializeComponent();
            excursionsToUpdateOltGrid.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;
            excursionsToUpdateOltGrid.DisplayLayout.Override.RowSizingAutoMaxLines = 6;
            excursionsToUpdateOltGrid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True;
            excursionsToUpdateOltGrid.DisplayLayout.Override.CellAppearance.TextTrimming = TextTrimming.EllipsisWord;
            cancelButton.Click += HandleCancelButtonClicked;
            saveAndCloseButton.Click += HandleSaveButtonClicked;
            responsesWillBeOverwrittenWarning.Visible = false;
            splashScreenManager = new SplashScreenManager(ParentForm, typeof(WaitForm), true, true);

            if (ClientSession.GetUserContext().Site.Id == Common.Domain.Site.FORT_HILLS_ID)
            {
                LoadValuesToDropDown();
            }
            else
            {
                AssetComboBox.Visible = false;
                CodeComboBox.Visible = false;
                oltGroupBox1.Visible = false;
                oltGroupBox2.Visible = false;
            }
            


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
//            throw new NotImplementedException();
        }


        public List<ExcursionResponseEditingGridRowDTO> ExcursionsToUpdate
        {
            get { return (List<ExcursionResponseEditingGridRowDTO>) excursionsToUpdateOltGrid.DataSource; }
            set
            {
                excursionsToUpdateOltGrid.DataSource = value;
                excursionsToUpdateOltGrid.ResetBindings();
            }
        }

        public string ExcursionResponseCommentForAllExcursions
        {
            get { return bulkCauseAndActionOltTextBox.Text; }
        }



        public void SetErrorForMissingResponse()
        {
            errorProvider.SetError(bulkCauseAndActionOltTextBox, "A response is required");
        }

        public void WarnThatSomePreviousExcursionResponsesWillBeOverwritten()
        {
            responsesWillBeOverwrittenWarning.Visible = true;
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

        private void excursionsToUpdateOltGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn column in e.Layout.Bands[0].Columns)
            {
                string key = column.Key;

                switch (key)
                {
                    case "Assest":
                            column.Hidden = true;
                        break;
                }

                switch (key)
                {
                    case "Code":
                            column.Hidden = true;
                        break;
                }
            }
        }

        private void LoadValuesToDropDown()
        {
            #region Assign values to Asset Dropdown

          AssetComboBox.Items.Add("Shovels");
          AssetComboBox.Items.Add("Shift Change");
          AssetComboBox.Items.Add("Trucks");
          AssetComboBox.Items.Add("Support Equipment");
          AssetComboBox.Items.Add("Incident");
          AssetComboBox.Items.Add("Crushing Plant 1");
          AssetComboBox.Items.Add("Crushing Plant 2");
          AssetComboBox.Items.Add("Slurry Prep 1");
          AssetComboBox.Items.Add("Slurry Prep 2");
          AssetComboBox.Items.Add("Slurry Prep 3");
          AssetComboBox.Items.Add("Extraction Train 1");
          AssetComboBox.Items.Add("Extraction Train 2");
          AssetComboBox.Items.Add("Tailings 1");
          AssetComboBox.Items.Add("Tailings 2");
          AssetComboBox.Items.Add("Tailings 3");
          AssetComboBox.Items.Add("Secondary");
          AssetComboBox.Items.Add("Utilities");
          AssetComboBox.Items.Add("Ore");
          AssetComboBox.Items.Add("Other");

            
            #endregion


            #region Assign values to Code Dropdown

          CodeComboBox.Items.Add("GET - Replace/Repair");
          CodeComboBox.Items.Add("Shovel Move/Relocation");
          CodeComboBox.Items.Add("Cable/Utility Work ");
          CodeComboBox.Items.Add("Shovel Availability ");
          CodeComboBox.Items.Add("Frozen Lumps");
          CodeComboBox.Items.Add("Damage");
          CodeComboBox.Items.Add("Having Bucket Cleaned");
          CodeComboBox.Items.Add("Stuck");
          CodeComboBox.Items.Add("High D50");
          CodeComboBox.Items.Add("High Fines");
          CodeComboBox.Items.Add("Split face");
          CodeComboBox.Items.Add("Waste");
          CodeComboBox.Items.Add("Other blend restriction");
          CodeComboBox.Items.Add("Air Compressor/Hydraulics/Mechanical ");
          CodeComboBox.Items.Add("Face Prep/Overhang/Pit Clean up");
          CodeComboBox.Items.Add("Other");
          CodeComboBox.Items.Add("Safety stand down");
          CodeComboBox.Items.Add("Park-up Congestion/Start up Delay");
          CodeComboBox.Items.Add("Shift Change Bus/Truck Availability ");
          CodeComboBox.Items.Add("Soft pit conditions");
          CodeComboBox.Items.Add("Visibility (Dust/Dawn/Dusk)");
          CodeComboBox.Items.Add("Long Haul/Roads/Routes");
          CodeComboBox.Items.Add("Operators");
          CodeComboBox.Items.Add("Availability");
          CodeComboBox.Items.Add("AHS");
          CodeComboBox.Items.Add("Haul road restriction");
          CodeComboBox.Items.Add("Dozer");
          CodeComboBox.Items.Add("RTD");
          CodeComboBox.Items.Add("Loader");
          CodeComboBox.Items.Add("Excavator");
          CodeComboBox.Items.Add("EMS Entry/Emergency in Mine");
          CodeComboBox.Items.Add("Fire");
          CodeComboBox.Items.Add("Power Supply");
          CodeComboBox.Items.Add("Equipment Damage ");
          CodeComboBox.Items.Add("Right of Way/Mine Rule Violation");
          CodeComboBox.Items.Add("Weather");
          CodeComboBox.Items.Add("Sizer");
          CodeComboBox.Items.Add("Conveyor");
          CodeComboBox.Items.Add("Apron Feeder");
          CodeComboBox.Items.Add("Voith Coupling");
          CodeComboBox.Items.Add("Back feeding");
          CodeComboBox.Items.Add("Pluggage");
          CodeComboBox.Items.Add("RWS");
          CodeComboBox.Items.Add("HT pump speed");
          CodeComboBox.Items.Add("HT pump motor load");
          CodeComboBox.Items.Add("HT Pressure");
          CodeComboBox.Items.Add("Rupture disc/leaks");
          CodeComboBox.Items.Add("Instrument Air");
          CodeComboBox.Items.Add("PSC UF Velocity");
          CodeComboBox.Items.Add("PSC UF Density");
          CodeComboBox.Items.Add("PSC UF Pump Performance");
          CodeComboBox.Items.Add("High Middlings Density");
          CodeComboBox.Items.Add("Tertiary's");
          CodeComboBox.Items.Add("Secondary's");
          CodeComboBox.Items.Add("Cyclopak/Thickener bypass");
          CodeComboBox.Items.Add("Leak");
          CodeComboBox.Items.Add("Line pressure");
          CodeComboBox.Items.Add("Tailings Density");
          CodeComboBox.Items.Add("Flow");
          CodeComboBox.Items.Add("Pump Speed");
          CodeComboBox.Items.Add("Pump Motor Load");
          CodeComboBox.Items.Add("leaks (include rupture disk events)");
          CodeComboBox.Items.Add("delay in RTS");
          CodeComboBox.Items.Add("Pacing froth inventory");
          CodeComboBox.Items.Add("Fouling/skin temps");
          CodeComboBox.Items.Add("Unplanned maintenance");
          CodeComboBox.Items.Add("CLCW");
          CodeComboBox.Items.Add("Utility Instrument Air");
          CodeComboBox.Items.Add("Steam");
          CodeComboBox.Items.Add("Power Supply");
          CodeComboBox.Items.Add("Hot Process Water");
          CodeComboBox.Items.Add("Process Effected Water");

          #endregion

        }

        public string AssetDropdown
        {
            get { return AssetComboBox.Text; }
        }
        public string CodeDropdown
        {
            get { return CodeComboBox.Text; }
        }

        

    }
}