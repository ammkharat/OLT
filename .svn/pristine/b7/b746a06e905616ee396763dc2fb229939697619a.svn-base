using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class GasTestElementLayoutPanel : UserControl
    {
        private readonly GasTestElementTimeResults gasTestElementTimeResults;
        private bool gasTestEventsEnabled = true;

        public GasTestElementLayoutPanel()
        {
            InitializeComponent();
            gasTestElementTimeResults = new GasTestElementTimeResults();            
        }

        public void BuildGasTestElementControls(List<GasTestElementInfo> list, Site site)
        {
            AddControlToPanel(new GasTestElementDetailsHeader());                
            list.ForEach(info => AddControlToPanel(CreateStandardGasTestElementDetails(info)));
            AddControlToPanel(CreateStandardGasTestElementDetails(GasTestElementInfo.CreateOtherGasTestElementInfo(site)));
            AddControlToPanel(CreateStandardGasTestElementDetails(GasTestElementInfo.CreateOtherGasTestElementInfo_Other(site))); // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            AddControlToPanel(gasTestElementTimeResults);
        }

        private GasTestElementDetails CreateStandardGasTestElementDetails(GasTestElementInfo info)
        {
            GasTestElementDetails details = new GasTestElementDetails(info);
            details.ConfinedSpaceTestRequiredChanged += gasTestDetails_ConfinedSpaceTestRequiredChanged;
            details.ImmediateAreaRequiredTestChanged += gasTestDetails_RequiredTestChanged;

            details.AutoSize = true;
            details.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            details.Dock = DockStyle.None;
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
            foreach (IGasTestElementDetails details in GasTestElementDetailsList)
            {
                if (details.ImmediateAreaTestRequired)
                    return true;
            }
            return false;
        }

        private bool IsAConfinedSpaceTestResultActive()
        {
            foreach (IGasTestElementDetails details in GasTestElementDetailsList)
            {
                if (details.ConfinedSpaceTestRequired)
                    return true;
            }
            return false;
        }

        public List<IGasTestElementDetails> GasTestElementDetailsList
        {
            // TODO: Hack to return only the gas test element details back.  Filter out header/time details.
            get
            {
                var list = new List<IGasTestElementDetails>();
                foreach (Control control in layoutPanel.Controls)
                {
                    if (typeof(IGasTestElementDetails).IsAssignableFrom(control.GetType()))
                    {
                        list.Add((IGasTestElementDetails)control);
                    }
                }
                return list;
            }
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

        public bool GasTestEventsEnabled
        {
            set { gasTestEventsEnabled = value; }
        }

        private void AddControlToPanel(Control control)
        {
            layoutPanel.Controls.Add(control);
        }
    }
}
