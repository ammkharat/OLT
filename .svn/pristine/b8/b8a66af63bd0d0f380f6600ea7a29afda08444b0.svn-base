using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class GasTestElementLayoutPanelMuds : UserControl
    {
        private readonly GasTestElementTimeResultsMuds gasTestElementTimeResults;
        GasTestElementDetailsSignrMuds SignControl;
        private bool gasTestEventsEnabled = true;
        public bool showonlyFirstColum = false;
        public bool disbaleFirstColumn = false;
        public GasTestElementLayoutPanelMuds()
        {
            InitializeComponent();
            gasTestElementTimeResults = new GasTestElementTimeResultsMuds();            
        }

        public void BuildGasTestElementControls(List<GasTestElementInfo> list, Site site)
        {
            GasTestElementDetailsHeaderMuds  HeaderControl= new GasTestElementDetailsHeaderMuds();
            HeaderControl.showonlyFirstColum = showonlyFirstColum;
           // gasTestElementTimeResults.DisableFirstReading = true;
           AddControlToPanel(HeaderControl);
            AddControlToPanel(gasTestElementTimeResults);   
            list.ForEach(info => AddControlToPanel(CreateStandardGasTestElementDetails(info)));
           // AddControlToPanel(CreateStandardGasTestElementDetails(GasTestElementInfo.CreateOtherGasTestElementInfo(site)));
           // AddControlToPanel(CreateStandardGasTestElementDetails(GasTestElementInfo.CreateOtherGasTestElementInfo_Other(site))); // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            gasTestElementTimeResults.showonlyFirstColum = showonlyFirstColum;
            gasTestElementTimeResults.ImmediateAreaTimePickerEnabled = !disbaleFirstColumn;
           // AddControlToPanel(gasTestElementTimeResults
             SignControl = new GasTestElementDetailsSignrMuds();
             SignControl.Visible = !showonlyFirstColum;//make sign control as visible false when showonlyFirstColum=true;   
            SignControl.Name = "SignControl";
            AddControlToPanel(SignControl); 
        }

        private GasTestElementDetailsMuds CreateStandardGasTestElementDetails(GasTestElementInfo info)
        {
            GasTestElementDetailsMuds details = new GasTestElementDetailsMuds(info);
            details.ConfinedSpaceTestRequiredChanged += gasTestDetails_ConfinedSpaceTestRequiredChanged;
            details.ImmediateAreaRequiredTestChanged += gasTestDetails_RequiredTestChanged;
            details.ThirdTestRequiredChanged += gasTestDetails_ThirdTestRequiredChanged;
            details.FourthTestRequiredChanged += gasTestDetails_FourthTestRequiredChanged;
            details.showonlyFirstColum = showonlyFirstColum;
            details.AutoSize = true;
            details.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            details.Dock = DockStyle.None;
            details.DisableFirstReading = disbaleFirstColumn;

            return details;
        }

        private void gasTestDetails_RequiredTestChanged(object sender, EventArgs e)
        {
            if (gasTestEventsEnabled)
            {
                if (gasTestElementTimeResults.ImmediateAreaTime != null || IsAnImmediateAreaTestResultActive())
                {
                    gasTestElementTimeResults.ImmediateAreaTimePickerEnabled = true;
                    gasTestElementTimeResults.ImmediateAreaTimePickerChecked = true;
                }
                else
                {
                    gasTestElementTimeResults.ImmediateAreaTimePickerEnabled = false;
                    gasTestElementTimeResults.ImmediateAreaTimePickerChecked = false;
                    gasTestElementTimeResults.ImmediateAreaTime = null;
                }
            }
        }

        private void gasTestDetails_ConfinedSpaceTestRequiredChanged(object sender, EventArgs e)
        {
            if (gasTestEventsEnabled)
            {
                if (gasTestElementTimeResults.ConfinedSpaceTime != null || IsAConfinedSpaceTestResultActive())
                {
                    gasTestElementTimeResults.ConfinedSpaceTimePickerEnabled = true;
                    gasTestElementTimeResults.ConfinedSpaceTimePickerChecked = true;
                }
                else
                {
                    gasTestElementTimeResults.ConfinedSpaceTimePickerEnabled = false;
                    gasTestElementTimeResults.ConfinedSpaceTimePickerChecked = false;
                    gasTestElementTimeResults.ConfinedSpaceTime = null;
                }
            }
        }

        private bool IsAnImmediateAreaTestResultActive()
        {
            foreach (GasTestElementDetailsMuds details in GasTestElementDetailsList)
            {
                if (details.ImmediateAreaTestRequired)
                    return true;
            }
            return false;
        }

        private bool IsAConfinedSpaceTestResultActive()
        {
            foreach (GasTestElementDetailsMuds details in GasTestElementDetailsList)
            {
                if (details.ConfinedSpaceTestRequired)
                    return true;
            }
            return false;
        }

        public List<GasTestElementDetailsMuds> GasTestElementDetailsList
        {
            // TODO: Hack to return only the gas test element details back.  Filter out header/time details.
            get
            {
                var list = new List<GasTestElementDetailsMuds>();
                foreach (Control control in layoutPanel.Controls)
                {
                    if (typeof(GasTestElementDetailsMuds).IsAssignableFrom(control.GetType()))
                    {
                        list.Add((GasTestElementDetailsMuds)control);
                    }
                }
                return list;
            }
        }

        public GasTestElementDetailsSignrMuds GetSignControl
        {
            get { return SignControl; }
        }

        [Browsable(false)]
        public Time ImmediateAreaTime
        {
            get { return gasTestElementTimeResults.ImmediateAreaTime; }
            set
            {
                gasTestElementTimeResults.ImmediateAreaTime = value;
            }
        }

        [Browsable(false)]
        public Time ConfinedSpaceTime
        {
            get { return gasTestElementTimeResults.ConfinedSpaceTime; }
            set
            {
                gasTestElementTimeResults.ConfinedSpaceTime = value;
            }
        }

        [Browsable(false)]
        public Time FourthResultTime
        {
            get { return gasTestElementTimeResults.FourthTime; }
            set
            {
                gasTestElementTimeResults.FourthTime = value;
            }
        }

        [Browsable(false)]
        public Time ThirdResultTime
        {
            get { return gasTestElementTimeResults.ThirdTime; }
            set
            {
                gasTestElementTimeResults.ThirdTime = value;
            }
        }
        [Browsable(false)]
        public Time ResultTime
        {
            get { return gasTestElementTimeResults.ImmediateAreaTime; }
            set
            {
                gasTestElementTimeResults.ImmediateAreaTime = value;
            }
        }

        public bool GasTestEventsEnabled
        {
            set { gasTestEventsEnabled = value; }
        }

        private void AddControlToPanel(Control control)
        {
            layoutPanel.Controls.Add(control);
        }

        private bool IsThirdTestResultActive()
        {
            foreach (GasTestElementDetailsMuds details in GasTestElementDetailsList)
            {
                if (details.ThirdTestRequired)
                    return true;
            }
            return false;
        }

        private void gasTestDetails_ThirdTestRequiredChanged(object sender, EventArgs e)
        {
            if (gasTestEventsEnabled)
            {
                if (gasTestElementTimeResults.ThirdTime != null || IsThirdTestResultActive())
                {
                    gasTestElementTimeResults.ThirdTimePickerEnabled = true;
                    gasTestElementTimeResults.ThirdTimePickerChecked = true;
                }
                else
                {
                    gasTestElementTimeResults.ThirdTimePickerEnabled = false;
                    gasTestElementTimeResults.ThirdTimePickerChecked = false;
                    gasTestElementTimeResults.ThirdTime = null;
                }
            }
        }
        private bool IsFourthTestResultActive()
        {
            foreach (GasTestElementDetailsMuds details in GasTestElementDetailsList)
            {
                if (details.FourthTestRequired)
                    return true;
            }
            return false;
        }

        private void gasTestDetails_FourthTestRequiredChanged(object sender, EventArgs e)
        {
            if (gasTestEventsEnabled)
            {
                if (gasTestElementTimeResults.FourthTime != null || IsFourthTestResultActive())
                {
                    gasTestElementTimeResults.FourthTimePickerEnabled = true;
                    gasTestElementTimeResults.FourthTimePickerChecked = true;
                }
                else
                {
                    gasTestElementTimeResults.FourthTimePickerEnabled = false;
                    gasTestElementTimeResults.FourthTimePickerChecked = false;
                    gasTestElementTimeResults.FourthTime = null;
                }
            }
        }

        public bool DisbaleFirstTime
        {
            set { gasTestElementTimeResults.DisableFirstReading = value; }
        }


    }
}
