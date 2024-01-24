using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class WorkPermitPrintPreferenceTabPage : UserControl, IWorkPermitPrintPreferenceTabPage
    {
        public event Action FormLoad;

        private readonly WorkPermitPrintPreferenceTabPagePresenter presenter;
        
        private float initialNumberOfCopiesRowHeight;        
        private float initialNumberOfTACopiesRowHeight;

        private const int NumberOfCopiesRowIndex = 1;        
        private const int NumberOfTACopiesRowIndex = 2;

        public WorkPermitPrintPreferenceTabPage()
        {
            presenter = new WorkPermitPrintPreferenceTabPagePresenter(this);

            InitializeComponent();            
            InitializeEvents();    
        
            numberOfCopiesAlternateLabel.Hide();
        }       

        public bool IsDesignMode
        {
            get { return DesignMode; }
        }

        public List<int> NumberOfCopiesValueList
        {
            set { numberOfCopiesComboBox.DataSource = value; }
        }

        public List<int> NumberOfTurnaroundCopiesValueList
        {
            set { numberOfTurnaroundCopiesComboBox.DataSource = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            initialNumberOfCopiesRowHeight = tableLayoutPanel.RowStyles[NumberOfCopiesRowIndex].Height;            
            initialNumberOfTACopiesRowHeight = tableLayoutPanel.RowStyles[NumberOfTACopiesRowIndex].Height;

            if (FormLoad != null)
            {
                FormLoad();
            }
        }
       
        private void InitializeEvents()
        {
            FormLoad += presenter.HandleFormLoad;
        }

        public List<string> AvailablePrinters
        {
            set { printersComboBox.DataSource = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PrinterName
        {
            get { return printersComboBox.SelectedItem.ToString(); }
            set { printersComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NumberOfCopies
        {
            get { return (int) numberOfCopiesComboBox.SelectedItem; }
            set { numberOfCopiesComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NumberOfTurnaroundCopies
        {
            get { return (int)numberOfTurnaroundCopiesComboBox.SelectedItem; }
            set { numberOfTurnaroundCopiesComboBox.SelectedItem = value; }
        }

        public bool ShowAlternativeNumberOfCopiesLabel
        {
            set
            {
                numberOfCopiesAlternateLabel.Visible = value;
                defaultNumberOfCopiesLabel.Visible = !value;
            }
        }
       
        public bool ShowPrintDialog
        {
            get { return showDialogCheckBox.Checked; }
            set { showDialogCheckBox.Checked = value; }
        }

        //RITM0387753-Shift Handover creation alert(Aarti)
        public bool ShowShiftHandoverAlertDialog
        {
            get { return ShiftHandoveralertCheckBox1.Checked; }
            set { ShiftHandoveralertCheckBox1.Checked = value; }
        }

        public bool NumberOfCopiesVisible
        {
            set { SetRowVisible(NumberOfCopiesRowIndex, initialNumberOfCopiesRowHeight, value); }
        }
        
        public bool NumberOfTACopiesVisible
        {
            set { SetRowVisible(NumberOfTACopiesRowIndex, initialNumberOfTACopiesRowHeight, value); }
        }

        private void SetRowVisible(int index, float initialHeight, bool setVisible)
        {
            RowStyle rowStyle = tableLayoutPanel.RowStyles[index];

            if (setVisible)
            {
                rowStyle.Height = initialHeight;
            }
            else
            {
                rowStyle.Height = 0;
            }
        }

        public bool IsTabValid
        {
            get { return presenter.Validate(); }
        }
        
        public void UpdatePreference()
        {
            presenter.Update();
        }

        public bool SoundAlertEnable
        {
            get { return soundAlertEnableCheckBox.Checked; }
            set { soundAlertEnableCheckBox.Checked = value; }
        }
    }
}